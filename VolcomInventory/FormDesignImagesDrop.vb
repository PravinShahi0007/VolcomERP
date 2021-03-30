Public Class FormDesignImagesDrop
    Public id_design_images_drop As String = "-1"

    Private cloud_host As String = get_setup_field("cloud_host").ToString
    Private cloud_username As String = get_setup_field("cloud_username").ToString
    Private cloud_password As String = get_setup_field("cloud_password").ToString

    Private cloud_image_path As String = get_setup_field("cloud_image_path").ToString

    Private Sub FormDesignImagesDrop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'head
        Dim query_head As String = "
            SELECT d.number, d.reason, DATE_FORMAT(d.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by
            FROM tb_design_images_drop AS d
            LEFT JOIN tb_m_employee AS e ON d.created_by = e.id_employee
            WHERE d.id_design_images_drop = " + id_design_images_drop + "

            UNION ALL

            SELECT '[autogenerate]' AS `number`, '' AS reason, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at, '" + get_emp(id_employee_user, "2") + "' AS created_by
        "

        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")

        TENumber.EditValue = data_head.Rows(0)("number").ToString
        TEReason.EditValue = data_head(0)("reason").ToString
        TECreatedBy.EditValue = data_head.Rows(0)("created_by").ToString
        TECreatedAt.EditValue = data_head.Rows(0)("created_at").ToString

        'detail
        Dim query_detail As String = "
            SELECT s.id_design, d.design_code, d.design_display_name
            FROM tb_design_images_drop_det AS s
            LEFT JOIN tb_m_design AS d ON s.id_design = d.id_design
            WHERE s.id_design_images_drop = " + id_design_images_drop + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCDesignList.DataSource = data_detail

        'control
        If Not id_design_images_drop = "-1" Then
            SBAdd.Enabled = False
            SBRemove.Enabled = False
            SBDropImages.Enabled = False
            TEReason.ReadOnly = True
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormDesignImagesDropPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVDesignList.DeleteSelectedRows()
    End Sub

    Private Sub SBDropImages_Click(sender As Object, e As EventArgs) Handles SBDropImages.Click
        If Not GVDesignList.RowCount = 0 And Not TEReason.EditValue = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to drop images ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                FormMain.SplashScreenManager1.ShowWaitForm()

                'head
                Dim query_head As String = "
                    INSERT INTO tb_design_images_drop (`number`, reason, created_at, created_by) VALUES ('', '" + addSlashes(TEReason.EditValue.ToString) + "', NOW(), " + id_employee_user + ");
                    SELECT LAST_INSERT_ID();
                "

                id_design_images_drop = execute_query(query_head, 0, True, "", "", "", "")

                execute_non_query("UPDATE tb_design_images_drop SET number = CONCAT('DIMG', LPAD(" + id_design_images_drop + ", 7, '0')) WHERE id_design_images_drop = " + id_design_images_drop, True, "", "", "", "")

                'detail
                For i = 0 To GVDesignList.RowCount - 1
                    Dim query_detail As String = "INSERT INTO tb_design_images_drop_det (id_design_images_drop, id_design) VALUES (" + id_design_images_drop + ", " + GVDesignList.GetRowCellValue(i, "id_design").ToString + ")"

                    execute_non_query(query_detail, True, "", "", "", "")
                Next

                'image
                'database
                For i = 0 To GVDesignList.RowCount - 1
                    execute_non_query("
                        INSERT INTO tb_design_images_drop_images (id_design_images_drop, file_name, created_at, created_by)
                        SELECT " + id_design_images_drop + " AS id_design_images_drop, file_name, created_at, created_by
                        FROM tb_design_images
                        WHERE id_design = " + GVDesignList.GetRowCellValue(i, "id_design").ToString + "
                        UNION ALL
                        SELECT " + id_design_images_drop + " AS id_design_images_drop, file_name, created_at, created_by
                        FROM tb_design_images_log
                        WHERE id_design_images IN (SELECT id_design_images FROM tb_design_images WHERE id_design = " + GVDesignList.GetRowCellValue(i, "id_design").ToString + ")
                    ", True, "", "", "", "")

                    execute_non_query("
                        DELETE FROM tb_design_images_log WHERE id_design_images IN (SELECT id_design_images FROM tb_design_images WHERE id_design = " + GVDesignList.GetRowCellValue(i, "id_design").ToString + ");
                        DELETE FROM tb_design_images WHERE id_design = " + GVDesignList.GetRowCellValue(i, "id_design").ToString + ";
                    ", True, "", "", "", "")
                Next

                'cloud
                Dim sftp As Renci.SshNet.SftpClient = New Renci.SshNet.SftpClient(cloud_host, cloud_username, cloud_password)

                sftp.Connect()

                If sftp.IsConnected Then
                    Dim data_images As DataTable = execute_query("SELECT file_name FROM tb_design_images_drop_images WHERE id_design_images_drop = " + id_design_images_drop, -1, True, "", "", "", "")

                    'sftp.CreateDirectory(cloud_image_path + "/drop/" + id_design_images_drop)

                    For i = 0 To data_images.Rows.Count - 1
                        Dim old_name As String = cloud_image_path + "/" + IO.Path.GetFileName(data_images.Rows(i)("file_name").ToString)
                        'Dim new_name As String = cloud_image_path + "/drop/" + id_design_images_drop + "/" + IO.Path.GetFileName(data_images.Rows(i)("file_name").ToString)

                        'sftp.RenameFile(old_name, new_name)

                        sftp.DeleteFile(old_name)
                    Next
                End If

                sftp.Disconnect()
                sftp.Dispose()

                If get_setup_field("is_notif_drop_images") = "1" Then
                    'email
                    Dim c_email As ClassFunctionEmail = New ClassFunctionEmail

                    Dim e_from As String() = {"system@volcom.co.id", "Drop Images - Volcom ERP"}
                    Dim e_to As List(Of String()) = New List(Of String())
                    Dim e_cc As List(Of String()) = New List(Of String())

                    Dim e_query As String = "SELECT email_external, employee_name, 'cc' AS `type` FROM tb_m_employee WHERE id_employee = " + id_employee_user + " UNION ALL SELECT e.email_external, e.employee_name, i.type FROM tb_design_images_email AS i LEFT JOIN tb_m_employee AS e ON i.id_employee = e.id_employee"
                    Dim e_data As DataTable = execute_query(e_query, -1, True, "", "", "", "")

                    For i = 0 To e_data.Rows.Count - 1
                        If e_data.Rows(i)("type").ToString = "to" Then
                            e_to.Add({e_data.Rows(i)("email_external").ToString, e_data.Rows(i)("employee_name").ToString})
                        End If

                        If e_data.Rows(i)("type").ToString = "cc" Then
                            e_cc.Add({e_data.Rows(i)("email_external").ToString, e_data.Rows(i)("employee_name").ToString})
                        End If
                    Next

                    Dim design_list As String = ""

                    For i = 0 To GVDesignList.RowCount - 1
                        design_list += "
                            <tr>
                                <td><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 5pt 0pt;'>" + GVDesignList.GetRowCellValue(i, "design_code").ToString + "</p></td>
                                <td><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 5pt 0pt;'>" + GVDesignList.GetRowCellValue(i, "design_display_name").ToString + "</p></td>
                            </tr>
                        "
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
                                                <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 5pt 0pt;'>" + TECreatedBy.Text + " has dropped design images:</p>
                                                <table border='1' width='100%'>
                                                    <tr>
                                                        <td><p style='font-size: 10pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt 0pt 5pt 0pt;'>Code</p></td>
                                                        <td><p style='font-size: 10pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt 0pt 5pt 0pt;'>Design</p></td>
                                                    </tr>
                                                    " + design_list + "
                                                </table>
                                                <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 5pt 0pt 5pt 0pt;'>Reason: " + TEReason.Text + "</p>
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

                    c_email.send_email(e_from, e_to, e_cc, "Drop Images", body)
                End If

                FormMain.SplashScreenManager1.CloseWaitForm()

                Close()
            End If
        Else
            stopCustom("Please add design and fill reason.")
        End If
    End Sub

    Private Sub FormDesignImagesDrop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormDesignImages.view_drop_images()

        Dispose()
    End Sub
End Class