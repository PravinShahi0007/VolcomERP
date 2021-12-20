Public Class FormSOPNew
    Public id_sop As String = "-1"
    Public id_pps As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormSOPNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSOPNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        DECreatedDate.EditValue = Now()
        TECreatedBy.Text = get_emp(id_employee_user, "2")
        '
        load_departement()
        '
        If id_pps = "-1" Then
            XTPDepTerkait.Visible = False
            XTPDetail.Visible = False
            '
            SLEDepartement.Properties.ReadOnly = True
            SLEDepartement.EditValue = FormSOPIndex.GVBySOP.GetFocusedRowCellValue("id_departement").ToString
            TEProsedur.Text = FormSOPIndex.GVBySOP.GetFocusedRowCellValue("sop_prosedur").ToString
            TESubProsedur.Text = FormSOPIndex.GVBySOP.GetFocusedRowCellValue("sop_prosedur_sub").ToString
            TESOPName.Text = FormSOPIndex.GVBySOP.GetFocusedRowCellValue("sop_name").ToString
            BProposeSOPAsset.Visible = True
            PCSave.Visible = False
            XTPDepTerkait.PageVisible = False
            XTPDetail.PageVisible = False
        Else
            SLEDepartement.Properties.ReadOnly = True
            BProposeSOPAsset.Visible = False
            PCSave.Visible = True
            XTPDepTerkait.PageVisible = True
            XTPDetail.PageVisible = True
            '
            XtraTabControl1.SelectedTabPageIndex = 1
            '
            Dim q As String = "SELECT pps.*,s.sop_name,s.id_departement,empc.employee_name AS empc,spsub.sop_prosedur_sub,sp.sop_prosedur 
            ,d.doc_desc,d.ext,d.id_doc,CONCAT(d.id_doc,'_377_',pps.id_sop_dep_pps,d.ext) AS filename
            FROM tb_sop_dep_pps pps
            INNER JOIN tb_sop s ON s.id_sop=pps.id_sop
            INNER JOIN tb_sop_prosedur_sub spsub ON spsub.id_sop_prosedur_sub=s.id_sop_prosedur_sub
            INNER JOIN tb_sop_prosedur sp ON sp.id_sop_prosedur=spsub.id_sop_prosedur
            INNER JOIN tb_m_user usc ON usc.id_user=pps.created_by
            INNER JOIN tb_m_employee empc ON empc.id_employee=usc.id_employee
            LEFT JOIN tb_doc d ON d.id_report=pps.id_sop_dep_pps AND d.report_mark_type=377
            WHERE pps.id_sop_dep_pps='" & id_pps & "'"

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

            SLEDepartement.EditValue = dt.Rows(0)("id_departement").ToString
            TEProsedur.Text = dt.Rows(0)("sop_prosedur").ToString
            TESubProsedur.Text = dt.Rows(0)("sop_prosedur_sub").ToString
            TESOPName.Text = dt.Rows(0)("sop_name").ToString
            TECreatedBy.Text = dt.Rows(0)("empc").ToString
            DECreatedDate.EditValue = dt.Rows(0)("created_date").ToString
            '
            BUploadFile.Text = dt.Rows(0)("doc_desc").ToString
            TEFile.Text = dt.Rows(0)("filename").ToString
            If TEFile.Text = "" Then
                BDownload.Visible = False
            Else
                BDownload.Visible = True
            End If
            '
            If dt.Rows(0)("is_submit").ToString = "1" Then
                BtnMark.Visible = True
                BtnSave.Visible = False
                '
                CM.Enabled = False
                CMDepTerkait.Enabled = False
                '
                BAddModul.Enabled = False
                BUploadFile.Enabled = False
                BUploadFile2.Enabled = False
                BAddDepTerkait.Enabled = False
            Else
                BtnMark.Visible = False
                BtnSave.Visible = True
                '
                CM.Enabled = True
                CMDepTerkait.Enabled = True
                '
                BAddModul.Enabled = True
                BUploadFile.Enabled = True
                BUploadFile2.Enabled = True
                BAddDepTerkait.Enabled = True
            End If

            '            Dim q As String = "SELECT s.*,empl.employee_name AS empl,empc.employee_name AS empc 
            ',d.doc_desc,d.ext,d.id_doc,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename
            'FROM tb_sop s
            'INNER JOIN tb_m_user usc ON usc.id_user=s.created_by
            'INNER JOIN tb_m_employee empc ON empc.id_employee=usc.id_employee
            'INNER JOIN tb_m_user usl ON usl.id_user=s.last_update_by
            'INNER JOIN tb_m_employee empl ON empl.`id_employee`=usl.id_employee
            'LEFT JOIN tb_doc d ON d.id_report=s.id_sop AND d.report_mark_type=371
            'WHERE id_sop='" & id & "'"
            '            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            '            If dt.Rows.Count > 0 Then
            '                TESOPName.Text = dt.Rows(0)("sop_name").ToString
            '                '
            '                SLEDepartement.EditValue = dt.Rows(0)("id_departement").ToString
            '                '
            '                DECreatedDate.EditValue = dt.Rows(0)("created_date")
            '                TECreatedBy.Text = dt.Rows(0)("empc").ToString
            '                '
            '                BUploadFile.Text = dt.Rows(0)("doc_desc").ToString
            '                TEFile.Text = dt.Rows(0)("filename").ToString
            '                '
            '                If TEFile.Text = "" Then
            '                    BDownload.Visible = False
            '                Else
            '                    BDownload.Visible = True
            '                End If
            '            End If
        End If
        '
        load_modul_erp()
        '
        load_milestone()
        load_modul()
        load_dep_terkait()
        '
    End Sub

    Sub load_milestone()

    End Sub

    Sub load_dep_terkait()
        Dim q As String = "SELECT sm.id_departement,m.`departement`
FROM 
`tb_sop_dep_pps_dep_terkait` sm
INNER JOIN tb_m_departement m ON m.`id_departement`=sm.id_departement
WHERE sm.id_sop_dep_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDepartementTerkait.DataSource = dt
        GVDepartementTerkait.BestFitColumns()
    End Sub

    Sub load_modul()
        '        Dim q As String = "SELECT sm.id_menu,m.`description_menu_name`,m.`menu_caption`
        'FROM 
        '`tb_sop_menu_erp` sm
        'INNER JOIN tb_menu m ON m.`id_menu`=sm.id_menu
        'WHERE sm.id_sop='" & id_sop & "'"
        Dim q As String = "SELECT sm.id_menu,m.`description_menu_name`,m.`menu_caption`
FROM 
`tb_sop_dep_pps_menu` sm
INNER JOIN tb_menu m ON m.`id_menu`=sm.id_menu
WHERE sm.id_sop_dep_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCModulERP.DataSource = dt
        GVModulERP.BestFitColumns()
    End Sub

    Sub load_departement()
        Dim q As String = "SELECT id_departement,departement
FROM tb_m_departement WHERE is_kk_unit=2"
        viewSearchLookupQuery(SLEDepartementTerkait, q, "id_departement", "departement", "id_departement")
        viewSearchLookupQuery(SLEDepartement, q, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_modul_erp()
        Dim qw As String = ""

        qw += " AND emp.`id_departement`='" & SLEDepartement.EditValue.ToString & "' AND emp.`id_employee_active`=1 "

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

    Sub save()
        If TESOPName.Text = "" Then
            warningCustom("Please put SOP name")
        Else
            If id_sop = "-1" Then
                Dim q As String = "INSERT INTO tb_sop(`sop_name`,`id_departement`,`created_date`,`created_by`,`is_locked`,`is_active`,`last_update`,`last_update_by`)
VALUES('" & addSlashes(TESOPName.Text) & "','" & SLEDepartement.EditValue.ToString & "',NOW(),'" & id_user & "','2','1',NOW(),'" & id_user & "'); SELECT LAST_INSERT_ID(); "
                id_sop = execute_query(q, 0, True, "", "", "", "")

                infoCustom("SOP data entry sukses")
            Else
                'update
                Dim q As String = "UPDATE tb_sop SET sop_name='" & addSlashes(TESOPName.Text) & "',id_departement='" & SLEDepartement.EditValue.ToString & "',`last_update`=NOW(),`last_update_by`='" & id_user & "' WHERE id_sop='" & id_sop & "'"
                execute_non_query(q, True, "", "", "", "")

                'modul
                ''delete first
                q = "DELETE FROM tb_sop_menu_erp WHERE id_sop='" & id_sop & "'"
                execute_non_query(q, True, "", "", "", "")
                ''detail
                If GVModulERP.RowCount > 0 Then
                    q = ""
                    For i = 0 To GVModulERP.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_sop & "','" & GVModulERP.GetRowCellValue(i, "id_menu").ToString & "','" & id_user & "',NOW())"
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

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAddModul.Click
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
                warningCustom("Sudah ada pada list")
            Else
                'Dim newRow As DataRow = (TryCast(GCModulERP.DataSource, DataTable)).NewRow()
                ''
                'newRow("id_menu") = SLEModul.EditValue.ToString
                'newRow("description_menu_name") = SLEModul.Properties.View.GetFocusedRowCellValue("description_menu_name").ToString
                'newRow("menu_caption") = SLEModul.Properties.View.GetFocusedRowCellValue("menu_caption").ToString

                'TryCast(GCModulERP.DataSource, DataTable).Rows.Add(newRow)
                Dim q As String = "INSERT INTO tb_sop_dep_pps_menu(id_sop_dep_pps,id_menu) VALUES('" & id_pps & "','" & SLEModul.EditValue.ToString & "')"
                execute_non_query(q, True, "", "", "", "")
                load_modul()
            End If
        End If
    End Sub

    Private Sub DeleteModulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteModulToolStripMenuItem.Click
        If GVModulERP.RowCount > 0 Then
            'GVModulERP.DeleteSelectedRows()
            Dim q As String = "DELETE FROM tb_sop_dep_pps_menu WHERE id_sop_dep_pps='" & id_pps & "' AND id_menu='" & GVModulERP.GetFocusedRowCellValue("id_menu").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            load_modul()
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

    Private Sub BUpload_Click(sender As Object, e As EventArgs) Handles BUploadFile2.Click
        Try
            If TEFile.Text = "" Or file_ext = "" Then
                warningCustom("Please upload first")
            Else
                Dim directory_upload As String = get_setup_field("upload_dir")
                'save db
                Dim qdel As String = "DELETE FROM tb_doc WHERE report_mark_type='377' AND id_report='" & id_pps & "'"
                execute_non_query(qdel, True, "", "", "", "")
                Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFile.Text) & "','377','" & id_pps & "',NOW(),'" & file_ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                'upload
                Dim path As String = directory_upload & "377" & "\"
                If Not IO.Directory.Exists(path) Then
                    IO.Directory.CreateDirectory(path)
                End If
                My.Computer.Network.UploadFile(file_address, path & last_id & "_377_" & id_pps & file_ext, "", "", True, 100, True)
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
            My.Computer.Network.DownloadFile(source_path & "377" & "\" & TEFile.Text, path & BUploadFile.Text & "_" & TEFile.Text, "", "", True, 100, True)

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

    Private Sub BProposeSOPAsset_Click(sender As Object, e As EventArgs) Handles BProposeSOPAsset.Click
        Dim q As String = "SELECT * FROM tb_sop_dep_pps WHERE id_sop='" & id_sop & "' AND id_report_status!=5"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            warningCustom("SOP sedang dalam proses pengajuan perubahan. Batalkan pengajuan sebelumnya untuk melanjutkan.")
        Else
            q = "INSERT INTO tb_sop_dep_pps(id_sop,created_by,created_date,id_report_status,is_submit) VALUES('" & id_sop & "','" & id_user & "',NOW(),1,2); SELECT LAST_INSERT_ID(); "
            id_pps = execute_query(q, 0, True, "", "", "", "")

            execute_non_query("CALL gen_number('" & id_pps & "','377')", True, "", "", "", "")

            'upload dokumen lama, kopi nama menu existing, copy dep terkait existing jika ada
            '-- clean file
            Dim q_ins As String = "DELETE FROM tb_doc WHERE id_report='" & id_pps & "' AND report_mark_type='377'"
            execute_non_query(q_ins, True, "", "", "", "")

            Dim qfile As String = "SELECT id_doc,doc_desc,'377' AS report_mark_type,'" & id_pps & "' AS id_report,`datetime`,ext,id_user_upload,is_encrypted 
FROM tb_doc 
WHERE id_report='" & id_sop & "' AND report_mark_type='371'"
            Dim dtfile As DataTable = execute_query(qfile, -1, True, "", "", "", "")
            If dtfile.Rows.Count > 0 Then
                '-- add file
                q_ins = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,`datetime`,ext,id_user_upload,is_encrypted)
VALUES('" & dtfile.Rows(0)("doc_desc").ToString & "','" & dtfile.Rows(0)("report_mark_type").ToString & "','" & dtfile.Rows(0)("id_report").ToString & "','" & dtfile.Rows(0)("datetime").ToString & "','" & dtfile.Rows(0)("ext").ToString & "','" & dtfile.Rows(0)("id_user_upload").ToString & "','" & dtfile.Rows(0)("is_encrypted").ToString & "'); SELECT LAST_INSERT_ID(); "
                Dim last_id As String = execute_query(q_ins, 0, True, "", "", "", "")
                '-- transfer file
                Dim directory_upload As String = get_setup_field("upload_dir")
                Dim path As String = directory_upload & "377" & "\"
                Dim path_dl As String = directory_upload & "371" & "\"
                If Not IO.Directory.Exists(path) Then
                    IO.Directory.CreateDirectory(path)
                End If
                My.Computer.Network.UploadFile(path_dl & dtfile.Rows(0)("id_doc").ToString & "_371_" & id_sop & dtfile.Rows(0)("ext").ToString, path & last_id & "_377_" & id_pps & dtfile.Rows(0)("ext").ToString, "", "", True, 100, True)
            End If

            'menu
            q_ins = "DELETE FROM tb_sop_dep_pps_menu WHERE id_sop_dep_pps='" & id_pps & "'"
            execute_non_query(q_ins, True, "", "", "", "")
            q_ins = "INSERT INTO tb_sop_dep_pps_menu(id_sop_dep_pps,id_menu)
SELECT '" & id_pps & "' AS id_sop_dep_pps,id_menu
FROM tb_sop_menu_erp
WHERE id_sop='" & id_sop & "'"
            execute_non_query(q_ins, True, "", "", "", "")

            'departement terkait
            q_ins = "DELETE FROM tb_sop_dep_pps_dep_terkait WHERE id_sop_dep_pps='" & id_pps & "'"
            execute_non_query(q_ins, True, "", "", "", "")
            q_ins = "INSERT INTO tb_sop_dep_pps_dep_terkait(id_sop_dep_pps,id_departement)
SELECT '" & id_pps & "' AS id_sop_dep_pps,id_departement
FROM tb_sop_dep_terkait
WHERE id_sop='" & id_sop & "'"
            execute_non_query(q_ins, True, "", "", "", "")

            load_head()
        End If
    End Sub

    Private Sub BAddDepTerkait_Click(sender As Object, e As EventArgs) Handles BAddDepTerkait.Click
        If Not SLEDepartementTerkait.EditValue = Nothing Then
            'check
            Dim is_already As Boolean = False
            For i = 0 To GVDepartementTerkait.RowCount - 1
                If GVDepartementTerkait.GetRowCellValue(i, "id_departement").ToString = SLEDepartementTerkait.EditValue.ToString Then
                    is_already = True
                    Exit For
                End If
            Next
            If is_already Then
                warningCustom("Sudah ada pada list")
            Else
                'Dim newRow As DataRow = (TryCast(GCModulERP.DataSource, DataTable)).NewRow()
                ''
                'newRow("id_menu") = SLEModul.EditValue.ToString
                'newRow("description_menu_name") = SLEModul.Properties.View.GetFocusedRowCellValue("description_menu_name").ToString
                'newRow("menu_caption") = SLEModul.Properties.View.GetFocusedRowCellValue("menu_caption").ToString

                'TryCast(GCModulERP.DataSource, DataTable).Rows.Add(newRow)
                Dim q As String = "INSERT INTO tb_sop_dep_pps_dep_terkait(id_sop_dep_pps,id_departement) VALUES('" & id_pps & "','" & SLEDepartementTerkait.EditValue.ToString & "')"
                execute_non_query(q, True, "", "", "", "")
                load_dep_terkait()
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Anda yakin ingin mengunci data untuk SOP ini ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim q As String = "UPDATE tb_sop_dep_pps SET is_submit=1 WHERE id_sop_dep_pps='" & id_pps & "'"
            execute_non_query(q, True, "", "", "", "")
            submit_who_prepared("377", id_pps, id_user)

            load_head()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "377"
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If GVDepartementTerkait.RowCount > 0 Then
            'GVModulERP.DeleteSelectedRows()
            Dim q As String = "DELETE FROM tb_sop_dep_pps_dep_terkait WHERE id_sop_dep_pps='" & id_pps & "' AND id_departement='" & GVDepartementTerkait.GetFocusedRowCellValue("id_departement").ToString & "'"
            execute_non_query(q, True, "", "", "", "")
            load_dep_terkait()
        End If
    End Sub
End Class