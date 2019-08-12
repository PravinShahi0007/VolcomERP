Public Class FormDocumentScanUpload
    Public id_report As String = ""
    Public report_mark_type As String = ""

    Private Sub FormDocumentScanUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEFilename.Text = "Scan " + Date.Parse(Now.ToString).ToString("dd MMMM yyyy hh-mm-ss")
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        PEScan.Image = Scanner.Scan
    End Sub

    Private zoomSpeedFactor As Single = 0.03F

    Private Sub PEScan_MouseWheel(sender As Object, e As MouseEventArgs) Handles PEScan.MouseWheel
        PEScan.Properties.ZoomPercent += e.Delta * zoomSpeedFactor
        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub BUpload_Click(sender As Object, e As EventArgs) Handles BUpload.Click
        upload_enc()
    End Sub

    Private Sub SBRotate_Click(sender As Object, e As EventArgs) Handles SBRotate.Click
        Try
            PEScan.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            PEScan.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormDocumentScanUpload_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub upload()
        Try
            If Not PEScan.Image Is Nothing Then
                Dim ext As String = ".jpg"
                save_image_ori(PEScan, Application.StartupPath + "\imagestemp\", "wiascanner" & ext)

                'save db
                Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFilename.Text) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                'upload
                Dim ftp_upload As String = get_setup_field("system_ftp_address")
                Dim directory_upload As String = get_setup_field("upload_dir")
                Dim user_upload As String = get_setup_field("system_ftp_user")
                Dim pass_upload As String = get_setup_field("system_ftp_pass")
                Dim path As String = directory_upload & report_mark_type & "\"
                Dim filename_upload As String = path & last_id & "_" & report_mark_type & "_" & id_report & ext
                Dim filename_temp As String = Application.StartupPath + "\imagestemp\wiascanner" & ext
                '
                Dim command As String = "/K net use " & ftp_upload & " /user:" & user_upload & " " & pass_upload & " & echo f | xcopy """ & filename_temp & """ """ & filename_upload & """ /Y & pause"
                Dim p As New ProcessStartInfo("CMD.EXE")

                p.WindowStyle = ProcessWindowStyle.Hidden
                p.CreateNoWindow = True
                p.UseShellExecute = False
                p.Arguments = command

                Process.Start(p)

                My.Computer.FileSystem.DeleteFile(filename_temp)

                'end upload
                FormDocumentUpload.refresh_load(report_mark_type)
                '
                Close()
            Else
                errorCustom("Please scan image first.")
            End If

        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Sub upload_enc()
        Try
            If Not PEScan.Image Is Nothing Then
                Dim ext As String = ".jpg"
                save_image_ori(PEScan, Application.StartupPath + "\imagestemp\", "wiascanner" & ext)

                'save db
                Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload,is_encrypted) VALUES('" & addSlashes(TEFilename.Text) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & ext & "','" & id_user & "','1');SELECT LAST_INSERT_ID() "
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                'upload
                Dim ftp_upload As String = get_setup_field("system_ftp_address")
                Dim directory_upload As String = get_setup_field("upload_dir")
                Dim user_upload As String = get_setup_field("system_ftp_user")
                Dim pass_upload As String = get_setup_field("system_ftp_pass")
                Dim path As String = directory_upload & report_mark_type & "\"
                Dim filename_upload As String = path & last_id & "_" & report_mark_type & "_" & id_report & ext
                Dim filename_temp As String = Application.StartupPath + "\imagestemp\wiascanner" & ext
                '
                Dim filename_temp_enc As String = Application.StartupPath + "\imagestemp\wiascanner_enc" & ext
                CryptFile.EncryptFile(get_setup_field("en_phrase"), filename_temp, filename_temp_enc)
                '
                Dim command As String = "/K net use " & ftp_upload & " /user:" & user_upload & " " & pass_upload & " & echo f | xcopy """ & filename_temp_enc & """ """ & filename_upload & """ /Y & pause"
                Dim p As New ProcessStartInfo("CMD.EXE")

                p.WindowStyle = ProcessWindowStyle.Hidden
                p.CreateNoWindow = True
                p.UseShellExecute = False
                p.Arguments = command

                Process.Start(p)

                'My.Computer.FileSystem.DeleteFile(filename_temp)
                'My.Computer.FileSystem.DeleteFile(filename_temp_enc)

                'end upload
                FormDocumentUpload.refresh_load(report_mark_type)
                '
                Close()
            Else
                errorCustom("Please scan image first.")
            End If

        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class