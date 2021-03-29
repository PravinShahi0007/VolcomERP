Public Class FormDesignImagesDet
    Public data As DataTable = New DataTable

    Private cloud_host As String = get_setup_field("cloud_host").ToString
    Private cloud_username As String = get_setup_field("cloud_username").ToString
    Private cloud_password As String = get_setup_field("cloud_password").ToString
    Private cloud_port As String = get_setup_field("cloud_port").ToString

    Private cloud_image_path As String = get_setup_field("cloud_image_path").ToString
    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString

    Private Sub FormDesignImagesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        GCList.DataSource = data

        GVList.BestFitColumns()

        'controls
        Dim is_valid As Boolean = True

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("status").ToString = "OK" And Not data.Rows(i)("status").ToString.Contains("Warning") Then
                is_valid = False
            End If
        Next

        If is_valid Then
            SBUpload.Visible = True
            SBBrowseFolder.Visible = False
        Else
            SBUpload.Visible = False
            SBBrowseFolder.Visible = True
        End If
    End Sub

    Private Sub FormDesignImagesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVList.RowCellStyle
        If GVList.GetRowCellValue(e.RowHandle, "status").ToString = "OK" Then
            e.Appearance.BackColor = Color.White
        ElseIf GVList.GetRowCellValue(e.RowHandle, "status").ToString.Contains("Warning") Then
            e.Appearance.BackColor = Color.LightYellow
        Else
            e.Appearance.BackColor = Color.LightPink
        End If
    End Sub

    Private Sub SBUpload_Click(sender As Object, e As EventArgs) Handles SBUpload.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload these images ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim design_replace As String = ""

            Dim group_upload As String = execute_query("SELECT (MAX(group_upload) + 1) AS group_upload FROM tb_design_images", 0, True, "", "", "", "")

            Dim design_code As DataTable = execute_query("SELECT id_design, design_code FROM tb_m_design WHERE design_code <> '' ORDER BY id_design DESC", -1, True, "", "", "", "")

            'upload
            Dim sftp As Renci.SshNet.SftpClient = New Renci.SshNet.SftpClient(cloud_host, cloud_username, cloud_password)

            sftp.Connect()

            If sftp.IsConnected Then
                For i = 0 To GVList.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Uploading file " + (i + 1).ToString + " of " + GVList.RowCount.ToString)

                    Dim file_stream As IO.FileStream = New IO.FileStream(GVList.GetRowCellValue(i, "file_name").ToString, IO.FileMode.Open)

                    Dim file_name As String = cloud_image_path + "/" + IO.Path.GetFileName(GVList.GetRowCellValue(i, "file_name").ToString)

                    'history
                    If GVList.GetRowCellValue(i, "status").ToString.Contains("Warning") Then
                        Dim log_number As String = execute_query("SELECT (COUNT(*) + 1) AS log_number FROM tb_design_images_log WHERE id_design_images = " + GVList.GetRowCellValue(i, "id_design_images").ToString, 0, True, "", "", "", "")

                        Dim log_file As String = IO.Path.GetFileName(GVList.GetRowCellValue(i, "file_name").ToString).Replace(".", "(" + log_number + ").")

                        Dim log_name As String = cloud_image_path + "/" + log_file

                        sftp.RenameFile(file_name, log_name)

                        execute_non_query("
                            INSERT INTO tb_design_images_log (id_design_images, file_name, created_at, created_by) 
                            SELECT " + GVList.GetRowCellValue(i, "id_design_images").ToString + " AS id_design_images, '" + log_file + "' AS file_name, created_at, created_by
                            FROM tb_design_images WHERE id_design_images = " + GVList.GetRowCellValue(i, "id_design_images").ToString + "
                        ", True, "", "", "", "")
                    End If

                    sftp.UploadFile(file_stream, file_name)

                    file_stream.Close()
                    file_stream.Dispose()

                    'check design code
                    Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(GVList.GetRowCellValue(i, "file_name").ToString).Split("_")

                    Dim dv_design As DataView = New DataView(design_code)

                    dv_design.RowFilter = "design_code = '" + array_name(1) + "'"

                    'store database
                    If GVList.GetRowCellValue(i, "status").ToString.Contains("Warning") Then
                        execute_non_query("UPDATE tb_design_images SET created_at = NOW(), created_by = " + id_user + ", group_upload = " + group_upload + " WHERE id_design_images = " + GVList.GetRowCellValue(i, "id_design_images").ToString, True, "", "", "", "")

                        If Not design_replace.Contains(array_name(1)) Then
                            design_replace += array_name(1) + ", "
                        End If
                    Else
                        execute_non_query("INSERT INTO tb_design_images (id_design, store, file_name, sort, created_at, created_by, group_upload) VALUES (" + dv_design(0)("id_design").ToString + ", '" + array_name(0) + "', '" + IO.Path.GetFileName(GVList.GetRowCellValue(i, "file_name").ToString) + "', " + array_name(2) + ", NOW(), " + id_user + ", " + group_upload + ")", True, "", "", "", "")
                    End If
                Next
            End If

            sftp.Disconnect()
            sftp.Dispose()

            If get_setup_field("is_notif_replace_images") = "1" Then
                If Not design_replace = "" Then
                    'email
                    Dim c_email As ClassFunctionEmail = New ClassFunctionEmail

                    Dim e_from As String() = {"system@volcom.co.id", "Replace Images - Volcom ERP"}
                    Dim e_to As List(Of String()) = New List(Of String())
                    Dim e_cc As List(Of String()) = New List(Of String())

                    Dim e_query As String = "SELECT e.email_external, e.employee_name, i.type FROM tb_design_images_email AS i LEFT JOIN tb_m_employee AS e ON i.id_employee = e.id_employee"
                    Dim e_data As DataTable = execute_query(e_query, -1, True, "", "", "", "")

                    For i = 0 To e_data.Rows.Count - 1
                        If e_data.Rows(i)("type").ToString = "to" Then
                            e_to.Add({e_data.Rows(i)("email_external").ToString, e_data.Rows(i)("employee_name").ToString})
                        End If

                        If e_data.Rows(i)("type").ToString = "cc" Then
                            e_cc.Add({e_data.Rows(i)("email_external").ToString, e_data.Rows(i)("employee_name").ToString})
                        End If
                    Next

                    Dim body As String = "
                        <table cellpadding='0' cellspacing='0' width='100%' style='background-color: #EEEEEE; border-collapse: collapse; padding: 30pt;'>
                            <tr>
                                <td align='center'>
                                    <table cellpadding='0' cellspacing='0' width='700' style='background-color: #FFFFFF; border-collapse: collapse;'>
                                        <tr>
                                            <td style='text-align: center; padding: 30pt 0pt;'>
                                                <a href='http://www.volcom.co.id' title='Volcom' target='_blank'>
                                                    <img src='https://d3k81ch9hvuctc.cloudfront.net/company/VFgA3P/images/de2b6f13-9275-426d-ae31-640f3dcfc744.jpeg' alt='Volcom' height='142' width='200'>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='background-color: #EEEEEE; padding: 5pt 0pt;'></td>
                                        </tr>
                                        <tr>
                                            <td style='padding: 30pt;'>
                                                <p style='font-size: 12pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt 0pt 10pt 0pt;'>Dear Team,</p>
                                                <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 5pt 0pt;'>" + get_emp(id_employee_user, "2") + " has replaced design images " + design_replace.Substring(0, design_replace.Length - 2) + ".</p>
                                                <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 25pt 0pt 10pt 0pt;'>Thank you</p>
                                                <p style='font-size: 12pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt;'>Volcom ERP</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='background-color: #EEEEEE; padding: 5pt 0pt;'></td>
                                        </tr>
                                        <tr>
                                            <td style='text-align: center; padding: 30pt 0pt;'>
                                                <p style='font-size: 9pt; font-family: Arial, sans-serif; color: #A0A0A0;'>This email send directly from system. Do not reply.</p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    "

                    c_email.send_email(e_from, e_to, e_cc, "Replace Images", body)
                End If
            End If

            FormMain.SplashScreenManager1.CloseWaitForm()

            Close()

            FormDesignImages.SLUESeason.EditValue = "LAST"

            FormDesignImages.view_images()
        End If
    End Sub

    Private Sub SBBrowseFolder_Click(sender As Object, e As EventArgs) Handles SBBrowseFolder.Click
        Dim browse As Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog = New Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog

        browse.IsFolderPicker = True

        If browse.ShowDialog() = Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim data_validation As DataTable = FormDesignImages.get_validation(browse.FileName)

            FormMain.SplashScreenManager1.CloseWaitForm()

            data = data_validation

            load_form()
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Process.Start("explorer.exe", "/select," + GVList.GetFocusedRowCellValue("file_name").ToString)
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseHover(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseLeave(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Close()
    End Sub
End Class