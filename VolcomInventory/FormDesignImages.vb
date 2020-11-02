Public Class FormDesignImages
    Private Sub FormDesignImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_images()
    End Sub

    Private Sub FormDesignImages_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDesignImages_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDesignImages_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_images()
        Dim query As String = "
            SELECT d.design_code, d.design_display_name, i.file_name, i.created_at, e.employee_name AS created_by, '' AS image
            FROM tb_design_images AS i
            LEFT JOIN tb_m_design AS d ON d.id_design = i.id_design
            LEFT JOIN tb_m_user AS u ON i.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            ORDER BY i.id_design_images DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCImageList.DataSource = data

        GVImageList.BestFitColumns()
    End Sub

    Sub browse_images()
        Dim browse As FolderBrowserDialog = New FolderBrowserDialog

        browse.ShowDialog()

        If Not browse.SelectedPath = "" Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim file() As String = IO.Directory.GetFiles(browse.SelectedPath)

            Dim is_valid As String = ""

            Dim uploaded_image As DataTable = execute_query("SELECT SUBSTRING(file_name, 1, (POSITION('.' IN file_name) - 1)) AS file_name FROM tb_design_images", -1, True, "", "", "", "")

            Dim store_code As DataTable = execute_query("SELECT id_comp_group, design_images_code FROM tb_m_comp_group WHERE design_images_code IS NOT NULL", -1, True, "", "", "", "")

            Dim design_code As DataTable = execute_query("SELECT id_design, design_code FROM tb_m_design WHERE design_code <> '' ORDER BY id_design DESC", -1, True, "", "", "", "")

            For i = 0 To file.Count - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking file " + (i + 1).ToString + " of " + file.Count.ToString)

                'check already uploaded
                Dim dv_uploaded As DataView = New DataView(uploaded_image)

                dv_uploaded.RowFilter = "file_name = '" + IO.Path.GetFileNameWithoutExtension(file(i)) + "'"

                If dv_uploaded.Count = 0 Then
                    Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(file(i)).Split("_")

                    If array_name.Length = 3 Then
                        'check store code
                        Dim dv_store As DataView = New DataView(store_code)

                        dv_store.RowFilter = "design_images_code = '" + array_name(0) + "'"

                        If dv_store.Count < 1 Then
                            is_valid += IO.Path.GetFileName(file(i)) + " store code not found." + Environment.NewLine
                        End If

                        'check design code
                        Dim dv_design As DataView = New DataView(design_code)

                        dv_design.RowFilter = "design_code = '" + array_name(1) + "'"

                        If dv_design.Count < 1 Then
                            is_valid += IO.Path.GetFileName(file(i)) + " design code not found." + Environment.NewLine
                        End If
                    Else
                        is_valid += IO.Path.GetFileName(file(i)) + " is not valid." + Environment.NewLine
                    End If
                Else
                    is_valid += IO.Path.GetFileName(file(i)) + " already uploaded." + Environment.NewLine
                End If
            Next

            If is_valid = "" Then
                'upload
                Dim cloud_host As String = get_setup_field("cloud_host").ToString
                Dim cloud_username As String = get_setup_field("cloud_username").ToString
                Dim cloud_password As String = get_setup_field("cloud_password").ToString
                Dim cloud_port As String = get_setup_field("cloud_port").ToString

                Dim cloud_image_path As String = get_setup_field("cloud_image_path").ToString

                Dim sftp As Renci.SshNet.SftpClient = New Renci.SshNet.SftpClient(cloud_host, cloud_username, cloud_password)

                sftp.Connect()

                If sftp.IsConnected Then
                    For i = 0 To file.Count - 1
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Uploading file " + (i + 1).ToString + " of " + file.Count.ToString)

                        Dim file_stream As IO.FileStream = New IO.FileStream(file(i), IO.FileMode.Open)

                        sftp.UploadFile(file_stream, cloud_image_path + "/" + IO.Path.GetFileName(file(i)))

                        Dim id_design As String = ""

                        'check design code
                        Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(file(i)).Split("_")

                        Dim dv_design As DataView = New DataView(design_code)

                        dv_design.RowFilter = "design_code = '" + array_name(1) + "'"

                        'store database
                        execute_non_query("INSERT INTO tb_design_images (id_design, file_name, created_at, created_by) VALUES (" + dv_design(0)("id_design").ToString + ", '" + IO.Path.GetFileName(file(i)) + "', NOW(), " + id_user + ")", True, "", "", "", "")
                    Next
                End If

                sftp.Disconnect()
                sftp.Dispose()

                view_images()
            Else
                FormMain.SplashScreenManager1.CloseWaitForm()

                stopCustom("Some files could not be uploaded: " + Environment.NewLine + is_valid)
            End If

            If FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.CloseWaitForm()
            End If
        End If
    End Sub

    Sub delete_images()

    End Sub

    Sub print_images()
        print(GCImageList, "Design Images")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_images()
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVImageList.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile("http://103.58.101.112/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseHover(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseLeave(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseLeave
        Cursor = Cursors.Default
    End Sub
End Class