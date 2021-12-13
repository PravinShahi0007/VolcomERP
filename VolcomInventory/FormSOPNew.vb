﻿Public Class FormSOPNew
    Public id As String = "-1"

    Private Sub FormSOPNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        DECreatedDate.EditValue = Now()
        TECreatedBy.Text = get_emp(id_employee_user, "2")
        DELastUpdate.EditValue = Now()
        TELastUpdate.Text = get_emp(id_employee_user, "2")
        '
        load_departement()
        load_modul_erp()
        '
        If id = "-1" Then

        Else
            CM.Enabled = True
            PCModul.Enabled = True
            PCUpload.Enabled = True
            '
            SLEDepartement.Properties.ReadOnly = True
            '
            Dim q As String = "SELECT s.*,empl.employee_name AS empl,empc.employee_name AS empc 
,d.doc_desc,d.ext,d.id_doc,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename
FROM tb_sop s
INNER JOIN tb_m_user usc ON usc.id_user=s.created_by
INNER JOIN tb_m_employee empc ON empc.id_employee=usc.id_employee
INNER JOIN tb_m_user usl ON usl.id_user=s.last_update_by
INNER JOIN tb_m_employee empl ON empl.`id_employee`=usl.id_employee
LEFT JOIN tb_doc d ON d.id_report=s.id_sop AND d.report_mark_type=371
WHERE id_sop='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TESOPName.Text = dt.Rows(0)("sop_name").ToString
                '
                SLEDepartement.EditValue = dt.Rows(0)("id_departement").ToString
                '
                DECreatedDate.EditValue = dt.Rows(0)("created_date")
                TECreatedBy.Text = dt.Rows(0)("empc").ToString
                DELastUpdate.EditValue = dt.Rows(0)("last_update")
                TELastUpdate.Text = dt.Rows(0)("empl").ToString
                '
                BUploadFile.Text = dt.Rows(0)("doc_desc").ToString
                TEFile.Text = dt.Rows(0)("filename").ToString
                '
                If TEFile.Text = "" Then
                    BDownload.Visible = False
                Else
                    BDownload.Visible = True
                End If
            End If
        End If
        '
        load_det()
        '
    End Sub

    Sub load_det()
        Dim q As String = "SELECT sm.id_menu,m.`description_menu_name`,m.`menu_caption`
FROM 
`tb_sop_menu_erp` sm
INNER JOIN tb_menu m ON m.`id_menu`=sm.id_menu
WHERE sm.id_sop='" & id & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCModulERP.DataSource = dt
        GVModulERP.BestFitColumns()
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement
FROM tb_m_departement"
        If Not FormSOPIndex.is_super_admin = "1" Then
            q += " WHERE id_departement='" & id_departement_user & "'"
        End If
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_modul_erp()
        Dim qw As String = ""

        If Not FormSOPIndex.is_super_admin = "1" Then
            qw += " AND emp.`id_departement`='" & id_departement_user & "' AND emp.`id_employee_active`=1 "
        End If

        Dim q As String = "SELECT m.id_menu,c.`form_control_name`,f.`form_name`,c.`form_control_name`,i.`id_menu`,m.`menu_name`,role.`role`,m.`description_menu_name`,m.`menu_caption`
FROM tb_m_user usr
INNER JOIN tb_m_employee emp ON usr.`id_employee`=emp.`id_employee` " & qw & "
INNER JOIN `tb_menu_acc` menu ON menu.`id_role`=usr.`id_role`
INNER JOIN tb_m_role role ON role.`id_role`=menu.`id_role`
INNER JOIN tb_menu_form_control c ON c.`id_form_control`=menu.`id_form_control`
INNER JOIN tb_menu_form f ON f.`id_form`=c.`id_form`
INNER JOIN `tb_menu_involved` i ON i.`id_form`=f.`id_form`
INNER JOIN tb_menu m ON m.`id_menu`=i.`id_menu`
GROUP BY m.`id_menu`"

        viewSearchLookupQuery(SLEModul, q, "id_menu", "menu_caption", "id_menu")
        SLEModul.EditValue = Nothing
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If TESOPName.Text = "" Then
            warningCustom("Please put SOP name")
        Else
            If id = "-1" Then
                Dim q As String = "INSERT INTO tb_sop(`sop_name`,`id_departement`,`created_date`,`created_by`,`is_locked`,`is_active`,`last_update`,`last_update_by`)
VALUES('" & addSlashes(TESOPName.Text) & "','" & SLEDepartement.EditValue.ToString & "',NOW(),'" & id_user & "','2','1',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(q, 0, True, "", "", "", "")

                infoCustom("SOP data entry success")
            Else
                'update
                Dim q As String = "UPDATE tb_sop SET sop_name='" & addSlashes(TESOPName.Text) & "',id_departement='" & SLEDepartement.EditValue.ToString & "',`last_update`=NOW(),`last_update_by`='" & id_user & "' WHERE id_sop='" & id & "'"
                execute_non_query(q, True, "", "", "", "")

                'modul
                ''delete first
                q = "DELETE FROM tb_sop_menu_erp WHERE id_sop='" & id & "'"
                execute_non_query(q, True, "", "", "", "")
                ''detail
                If GVModulERP.RowCount > 0 Then
                    q = ""
                    For i = 0 To GVModulERP.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id & "','" & GVModulERP.GetRowCellValue(i, "id_menu").ToString & "','" & id_user & "',NOW())"
                    Next
                    If Not q = "" Then

                    End If
                    q = "INSERT INTO tb_sop_menu_erp(id_sop,id_menu,created_by,created_datetime) VALUES" & q
                    execute_non_query(q, True, "", "", "", "")
                End If
                infoCustom("SOP detail updated")
            End If
            '
            load_head()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If Not SLEModul.EditValue = Nothing Then
            'check
            Dim is_already As Boolean = False
            For i = 0 To GVModulERP.RowCount - 1
                If GVModulERP.GetRowCellValue(i, "id_menu").ToString = SLEModul.EditValue.ToString Then
                    is_already = True
                    Exit For
                End If
            Next
            If is_already Then
                warningCustom("Already listed")
            Else
                Dim newRow As DataRow = (TryCast(GCModulERP.DataSource, DataTable)).NewRow()
                '
                newRow("id_menu") = SLEModul.EditValue.ToString
                newRow("description_menu_name") = SLEModul.Properties.View.GetFocusedRowCellValue("description_menu_name").ToString
                newRow("menu_caption") = SLEModul.Properties.View.GetFocusedRowCellValue("menu_caption").ToString

                TryCast(GCModulERP.DataSource, DataTable).Rows.Add(newRow)
            End If
        End If
    End Sub

    Private Sub DeleteModulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteModulToolStripMenuItem.Click
        If GVModulERP.RowCount > 0 Then
            GVModulERP.DeleteSelectedRows()
        End If
    End Sub

    Dim file_address As String = ""
    Dim file_name As String = ""
    Dim file_ext As String = ""

    Private Sub BUploadFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BUploadFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"

        fd.Filter = "Pdf Files|*.pdf"

        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            file_address = ""
            file_name = ""
            file_ext = ""

            If fd.FileNames.Length > 0 Then
                file_name = (System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileNames.GetValue(0)))
                file_address = (fd.FileNames.GetValue(0))
                file_ext = (System.IO.Path.GetExtension(fd.SafeFileNames.GetValue(0)))

                BUploadFile.Text = file_address
                TEFile.Text = file_name
            End If

            CenterToScreen()

            BDownload.Visible = False
        End If
    End Sub

    Private Sub BUpload_Click(sender As Object, e As EventArgs) Handles BUpload.Click
        Try
            If TEFile.Text = "" Or file_ext = "" Then
                warningCustom("Please upload first")
            Else
                Dim directory_upload As String = get_setup_field("upload_dir")
                'save db
                Dim qdel As String = "DELETE FROM tb_doc WHERE report_mark_type='371' AND id_report='" & id & "'"
                execute_non_query(qdel, True, "", "", "", "")
                Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFile.Text) & "','371','" & id & "',NOW(),'" & file_ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                'upload
                Dim path As String = directory_upload & "371" & "\"
                If Not IO.Directory.Exists(path) Then
                    IO.Directory.CreateDirectory(path)
                End If
                My.Computer.Network.UploadFile(file_address, path & last_id & "_371_" & id & file_ext, "", "", True, 100, True)
                load_head()
            End If
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub BDownload_Click(sender As Object, e As EventArgs) Handles BDownload.Click
        Dim FILE_NAME As String = ""
        Try
            Dim path As String = Application.StartupPath & "\download\"
            Dim source_path As String = get_setup_field("upload_dir")

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            'download
            My.Computer.Network.DownloadFile(source_path & "371" & "\" & TEFile.Text, path & BUploadFile.Text & "_" & TEFile.Text, "", "", True, 100, True)

            'open folder
            If IO.File.Exists(path & BUploadFile.Text & "_" & TEFile.Text) Then
                FILE_NAME = ""
                FILE_NAME = path & BUploadFile.Text & "_" & TEFile.Text

                Dim small_filename As String = ""
                small_filename = BUploadFile.Text & "_" & TEFile.Text

                If IO.File.Exists(FILE_NAME) = True Then
                    Dim processinfo As ProcessStartInfo = New ProcessStartInfo()
                    processinfo.WindowStyle = ProcessWindowStyle.Maximized
                    processinfo.WorkingDirectory = path
                    processinfo.FileName = small_filename
                    Process.Start(processinfo)
                Else
                    MsgBox("File Does Not Exist")
                End If
            Else
                stopCustom("No Supporting Document !")
            End If
        Catch ex As Exception
            log_error("Path : " & FILE_NAME & vbNewLine & "Errornya : " & ex.ToString)
        End Try
    End Sub
End Class