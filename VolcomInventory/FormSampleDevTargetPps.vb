Public Class FormSampleDevTargetPps
    Public id_pps As String = "-1"
    Public is_view As String = "-1"
    Public is_changes As String = "-1"

    Public is_actual As String = "-1"

    Dim id_report_status As String = "-1"

    Private Sub FormSampleDevTargetPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_type()
        Dim q As String = "SELECT '1' AS id_type,'Target' AS `type`
UNION ALL
SELECT '2' AS id_type,'Updates' AS `type`
UNION ALL
SELECT '3' AS id_type,'Actual' AS `type`
"
        viewSearchLookupQuery(SLEType, q, "id_type", "type", "id_type")
    End Sub

    Sub load_head()
        load_type()
        view_vendor()

        If id_pps = "-1" Then
            'new
            BGetTemplate.Visible = False
            BImportData.Visible = False
            PCAddDel.Visible = True
            '
            BtnSave.Visible = True
            BAttach.Visible = False
            BtnPrint.Visible = False
            BMark.Visible = False
            '
            load_det()
            '
            If is_changes = "1" Then
                PCAddDel.Visible = False
                load_det_changes()
                'SLEVendor.Properties.ReadOnly = True
                'PCAddDel.Visible = False
                ''
                'SLEVendor.EditValue = FormSampleDevelopment.GVTracker.GetRowCellValue(0, "id_comp").ToString
                'For i = 0 To FormSampleDevelopment.GVTracker.RowCount - 1
                '    Dim newRow As DataRow = (TryCast(GCPps.DataSource, DataTable)).NewRow()
                '    newRow("id_design") = FormSampleDevelopment.GVTracker.GetRowCellValue(i, "id_design").ToString
                '    newRow("design_display_name") = FormSampleDevelopment.GVTracker.GetRowCellValue(i, "design_display_name").ToString
                '    newRow("labdip") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "labdip_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "labdip"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "labdip_upd"))
                '    newRow("strike_off_1") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_1_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_1"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_1_upd"))
                '    newRow("proto_sample_1") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_1_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_1"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_1_upd"))
                '    newRow("strike_off_2") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_2_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_2"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "strike_off_2_upd"))
                '    newRow("proto_sample_2") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_2_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_2"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "proto_sample_2_upd"))
                '    newRow("copy_proto_sample_2") = If(FormSampleDevelopment.GVTracker.GetRowCellValue(i, "copy_proto_sample_2_upd").ToString = "", FormSampleDevelopment.GVTracker.GetRowCellValue(i, "copy_proto_sample_2"), FormSampleDevelopment.GVTracker.GetRowCellValue(i, "copy_proto_sample_2_upd"))
                '    TryCast(GCPps.DataSource, DataTable).Rows.Add(newRow)
                'Next

                SLEVendor.Properties.ReadOnly = True
                SLEType.EditValue = "2"
                FormImportExcel.id_pop_up = "65"
                FormImportExcel.ShowDialog()
            End If

            If is_actual = "1" Then
                PCAddDel.Visible = False
                load_det_actual()
                SLEVendor.Properties.ReadOnly = True
                SLEVendor.EditValue = FormSampleDevelopment.GVTracker.GetRowCellValue(0, "id_comp").ToString

                SLEType.EditValue = "3"
            End If
        Else
            'update
            BtnSave.Visible = False
            BAttach.Visible = True
            BtnPrint.Visible = True
            BMark.Visible = True
            BRelease.Visible = True
            '
            BAdd.Visible = False
            BDel.Visible = False
            '
            SLEVendor.Properties.ReadOnly = True
            MENote.Properties.ReadOnly = True
            '
            Dim q As String = "SELECT * FROM tb_sample_dev_pps pps
WHERE pps.id_sample_dev_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                SLEVendor.EditValue = dt.Rows(0)("id_comp").ToString
                MENote.Text = dt.Rows(0)("note").ToString
                '
                id_report_status = dt.Rows(0)("id_report_status").ToString
                SLEType.EditValue = dt.Rows(0)("id_type").ToString
                '
                If dt.Rows(0)("id_type").ToString = "2" Then
                    is_changes = "1"
                ElseIf dt.Rows(0)("id_type").ToString = "3" Then
                    is_actual = "1"
                End If
                '
                If id_report_status = "6" Or id_report_status = "5" Then
                    is_view = "1"
                    PCAddDel.Visible = False
                    BRelease.Visible = False
                End If
            End If

            If is_changes = "1" Then
                load_det_changes()
            ElseIf is_actual = "1" Then
                load_det_actual()
            Else
                load_det()
            End If
        End If

        If is_changes = "1" Then
            XTPUpdate.PageVisible = True
            XTPNew.PageVisible = False
            XTPActual.PageVisible = False
        ElseIf is_actual = "1" Then
            XTPUpdate.PageVisible = False
            XTPNew.PageVisible = False
            XTPActual.PageVisible = True
        Else
            XTPUpdate.PageVisible = False
            XTPNew.PageVisible = True
            XTPActual.PageVisible = False
        End If
    End Sub

    Sub view_vendor()
        Dim q As String = "SELECT id_comp,CONCAT(comp_number,' - ',comp_name) AS comp_name FROM tb_m_comp where is_active=1 AND id_comp_cat=1"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT ppsd.*,dsg.design_code,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name FROM tb_sample_dev_pps_det ppsd
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`,
	MAX(CASE WHEN cd.id_code=5 THEN cd.id_code_detail END) AS `src`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34, 5)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE ppsd.id_sample_dev_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPps.DataSource = dt
        GVPps.BestFitColumns()
    End Sub

    Sub load_det_actual()
        Dim q As String = "SELECT ppsd.*,dsg.design_code,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name
FROM tb_sample_dev_upd ppsd
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`,
	MAX(CASE WHEN cd.id_code=5 THEN cd.id_code_detail END) AS `src`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34, 5)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE ppsd.id_sample_dev_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCActual.DataSource = dt
        GVActual.BestFitColumns()
    End Sub

    Sub load_det_changes()
        Dim q As String = "SELECT ppsd.*,dsg.design_code,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name
FROM tb_sample_dev_upd ppsd
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`,
	MAX(CASE WHEN cd.id_code=5 THEN cd.id_code_detail END) AS `src`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34, 5)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE ppsd.id_sample_dev_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCChanges.DataSource = dt
        GVChanges.BestFitColumns()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSampleDevTargetAdd.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If is_changes = "1" Then
            If GVChanges.RowCount = 0 Then
                warningCustom("No data found.")
            Else
                If id_pps = "-1" Then
                    'check sudah ada apa belum
                    Dim is_ok As Boolean = True
                    '
                    If is_ok Then
                        Dim q As String = "INSERT INTO `tb_sample_dev_pps`(created_date,id_comp,created_by,note,id_report_status,id_type)
VALUES(NOW(),'" & SLEVendor.EditValue.ToString & "','" & id_user & "','" & addSlashes(MENote.Text) & "','1','" & SLEType.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                        id_pps = execute_query(q, 0, True, "", "", "", "")

                        execute_non_query("CALL gen_number('" & id_pps & "','403')", True, "", "", "", "")

                        'detail
                        q = "INSERT INTO `tb_sample_dev_upd`(`id_sample_dev_pps`,`id_design`,`tahapan`,`current_date`,`new_date`,`reason`) VALUES"
                        For i = 0 To GVChanges.RowCount - 1
                            If Not i = 0 Then
                                q += ","
                            End If

                            q += "('" & id_pps & "','" & GVChanges.GetRowCellValue(i, "id_design").ToString & "','" & GVChanges.GetRowCellValue(i, "tahapan").ToString & "'," & If(GVChanges.GetRowCellValue(i, "current_date").ToString = "", "NULL", "'" & Date.Parse(GVChanges.GetRowCellValue(i, "current_date").ToString).ToString("yyyy-MM-dd") & "'") & ",'" & Date.Parse(GVChanges.GetRowCellValue(i, "new_date").ToString).ToString("yyyy-MM-dd") & "','" & addSlashes(GVChanges.GetRowCellValue(i, "reason").ToString) & "')"
                        Next

                        execute_non_query(q, True, "", "", "", "")
                        submit_who_prepared("403", id_pps, id_user)
                        Close()
                    End If
                Else
                    'no edit pls
                End If
            End If
        Else
            If GVPps.RowCount = 0 Then
                warningCustom("No data found, please put some design.")
            Else
                If id_pps = "-1" Then
                    'check sudah ada apa belum
                    Dim is_ok As Boolean = True

                    'pps target
                    Dim ids As String = ""
                    For i = 0 To GVPps.RowCount - 1
                        If Not i = 0 Then
                            ids += ","
                        End If
                        ids += GVPps.GetRowCellValue(i, "id_design").ToString
                    Next

                    Dim qc As String = "SELECT id_design AS id_design FROM tb_sample_dev_tracking WHERE id_comp='" & SLEVendor.EditValue.ToString & "' AND id_design IN (" & ids & ")
UNION ALL
SELECT ppsd.id_design AS id_design FROM tb_sample_dev_pps pps
INNER JOIN tb_sample_dev_pps_det ppsd ON ppsd.id_sample_dev_pps=pps.id_sample_dev_pps
WHERE pps.id_comp='" & SLEVendor.EditValue.ToString & "' AND ppsd.id_design IN (" & ids & ") AND pps.id_report_status!=5 AND pps.id_type=1"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        warningCustom("Beberapa artikel sudah pernah diajukan")
                        is_ok = False
                    End If
                    '
                    If is_ok Then
                        Dim q As String = "INSERT INTO `tb_sample_dev_pps`(created_date,id_comp,created_by,note,id_report_status,id_type)
VALUES(NOW(),'" & SLEVendor.EditValue.ToString & "','" & id_user & "','" & addSlashes(MENote.Text) & "','1','" & SLEType.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                        id_pps = execute_query(q, 0, True, "", "", "", "")

                        execute_non_query("CALL gen_number('" & id_pps & "','403')", True, "", "", "", "")

                        'detail
                        q = "INSERT INTO `tb_sample_dev_pps_det`(`id_sample_dev_pps`,`id_design`,`labdip`,`strike_off_1`,`proto_sample_1`,`strike_off_2`,`proto_sample_2`,`copy_proto_sample_2`) VALUES"
                        For i = 0 To GVPps.RowCount - 1
                            If Not i = 0 Then
                                q += ","
                            End If

                            Dim labdip As String = "NULL"
                            Dim strike_off_1 As String = "NULL"
                            Dim proto_sample_1 As String = "NULL"
                            Dim strike_off_2 As String = "NULL"
                            Dim proto_sample_2 As String = "NULL"
                            Dim copy_proto_sample_2 As String = "NULL"

                            If Not GVPps.GetRowCellValue(i, "labdip").ToString = "" Then
                                labdip = "'" & Date.Parse(GVPps.GetRowCellValue(i, "labdip").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            If Not GVPps.GetRowCellValue(i, "strike_off_1").ToString = "" Then
                                strike_off_1 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "strike_off_1").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            If Not GVPps.GetRowCellValue(i, "proto_sample_1").ToString = "" Then
                                proto_sample_1 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "proto_sample_1").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            If Not GVPps.GetRowCellValue(i, "strike_off_2").ToString = "" Then
                                strike_off_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "strike_off_2").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            If Not GVPps.GetRowCellValue(i, "proto_sample_2").ToString = "" Then
                                proto_sample_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "proto_sample_2").ToString).ToString("yyyy-MM-dd") & "'"
                            End If
                            If Not GVPps.GetRowCellValue(i, "copy_proto_sample_2").ToString = "" Then
                                copy_proto_sample_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "copy_proto_sample_2").ToString).ToString("yyyy-MM-dd") & "'"
                            End If

                            q += "('" & id_pps & "','" & GVPps.GetRowCellValue(i, "id_design").ToString & "'," & labdip & "," & strike_off_1 & "," & proto_sample_1 & "," & strike_off_2 & "," & proto_sample_2 & "," & copy_proto_sample_2 & ")"
                        Next

                        execute_non_query(q, True, "", "", "", "")

                        submit_who_prepared("403", id_pps, id_user)

                        Close()
                    End If
                Else
                    '
                    'detail
                    Dim q As String = ""
                    execute_non_query("DELETE FROM tb_sample_dev_pps_det WHERE id_sample_dev_pps='" & id_pps & "'", True, "", "", "", "")

                    q = "INSERT INTO `tb_sample_dev_pps_det`(`id_sample_dev_pps`,`id_design`,`labdip`,`strike_off_1`,`proto_sample_1`,`strike_off_2`,`proto_sample_2`,`copy_proto_sample_2`) VALUES"
                    For i = 0 To GVPps.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If

                        Dim labdip As String = "NULL"
                        Dim strike_off_1 As String = "NULL"
                        Dim proto_sample_1 As String = "NULL"
                        Dim strike_off_2 As String = "NULL"
                        Dim proto_sample_2 As String = "NULL"
                        Dim copy_proto_sample_2 As String = "NULL"

                        If Not GVPps.GetRowCellValue(i, "labdip").ToString = "" Then
                            labdip = "'" & Date.Parse(GVPps.GetRowCellValue(i, "labdip").ToString).ToString("yyyy-MM-dd") & "'"
                        End If
                        If Not GVPps.GetRowCellValue(i, "strike_off_1").ToString = "" Then
                            strike_off_1 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "strike_off_1").ToString).ToString("yyyy-MM-dd") & "'"
                        End If
                        If Not GVPps.GetRowCellValue(i, "proto_sample_1").ToString = "" Then
                            proto_sample_1 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "proto_sample_1").ToString).ToString("yyyy-MM-dd") & "'"
                        End If
                        If Not GVPps.GetRowCellValue(i, "strike_off_2").ToString = "" Then
                            strike_off_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "strike_off_2").ToString).ToString("yyyy-MM-dd") & "'"
                        End If
                        If Not GVPps.GetRowCellValue(i, "proto_sample_2").ToString = "" Then
                            proto_sample_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "proto_sample_2").ToString).ToString("yyyy-MM-dd") & "'"
                        End If
                        If Not GVPps.GetRowCellValue(i, "copy_proto_sample_2").ToString = "" Then
                            copy_proto_sample_2 = "'" & Date.Parse(GVPps.GetRowCellValue(i, "copy_proto_sample_2").ToString).ToString("yyyy-MM-dd") & "'"
                        End If

                        q += "('" & id_pps & "','" & GVPps.GetRowCellValue(i, "id_design").ToString & "'," & labdip & "," & strike_off_1 & "," & proto_sample_1 & "," & strike_off_2 & "," & proto_sample_2 & "," & copy_proto_sample_2 & ")"
                    Next

                    execute_non_query(q, True, "", "", "", "")
                End If
            End If
        End If
    End Sub

    Private Sub FormSampleDevTargetPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "403"
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If Not check_allow_print(id_report_status, "403", id_pps) Then
            warningCustom("Can't print, please complete internal approval on system first")
        Else
            Cursor = Cursors.WaitCursor
            ReportSampleDevTarget.id_pps = id_pps
            ReportSampleDevTarget.dt = GCPps.DataSource
            Dim Report As New ReportSampleDevTarget()
            ' ...
            ' creating and saving the view's layout to a new memory stream 
            '
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVPps.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVPps.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVPps)
            Report.GVPps.BestFitColumns()

            Dim query As String = "SELECT IF(pps.id_type=1,'New Target',IF(pps.id_type=2,'Update','Actual')) AS type,DATE_FORMAT(pps.created_date,'%d %M %Y') AS created_date,c.comp_name AS vendor,pps.number,pps.note
FROM tb_sample_dev_pps pps
INNER JOIN tb_m_comp c ON c.id_comp=pps.id_comp
WHERE pps.id_sample_dev_pps='" & id_pps & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Report.DataSource = data

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BAttach_Click(sender As Object, e As EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "403"
        FormDocumentUpload.id_report = id_pps
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "403", id_pps) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BRelease_Click(sender As Object, e As EventArgs) Handles BRelease.Click
        'check attachment dan approval
        Dim is_ok As Boolean = True
        'check attachment
        Dim qc As String = "SELECT * FROM tb_doc WHERE report_mark_type='403' AND id_report='" & id_pps & "'"
        Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dtc.Rows.Count = 0 Then
            is_ok = False
            warningCustom("Please attach signed copy of this document")
        End If
        'status approval
        If Not id_report_status = "3" Then
            is_ok = False
            warningCustom("Please complete approval first")
        End If
        '
        If is_ok Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to complete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                FormReportMark.id_report = id_pps
                FormReportMark.report_mark_type = "403"
                FormReportMark.change_status("6")
                '
                load_head()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVPps_DoubleClick(sender As Object, e As EventArgs) Handles GVPps.DoubleClick
        If Not is_view = "1" And GVPps.RowCount > 0 Then
            FormSampleDevTargetAdd.is_change = "1"
            FormSampleDevTargetAdd.ShowDialog()
        End If
    End Sub

    Private Sub BGetTemplate_Click(sender As Object, e As EventArgs) Handles BGetTemplate.Click
        Cursor = Cursors.WaitCursor
        Dim Report As New ReportSampleTargetTemplate()
        Report.id_pps = id_pps
        '
        Dim q As String = "SELECT c.comp_name AS vendor,pps.number
FROM tb_sample_dev_pps pps
INNER JOIN tb_m_comp c ON c.id_comp=pps.id_comp
WHERE pps.id_sample_dev_pps = '" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        Report.DataSource = dt
        Report.Name = dt.Rows(0)("number").ToString
        '
        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BImportData_Click(sender As Object, e As EventArgs) Handles BImportData.Click
        FormImportExcel.id_pop_up = "66"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub BAddActual_Click(sender As Object, e As EventArgs) Handles BAddActual.Click

    End Sub

    Private Sub BDelActual_Click(sender As Object, e As EventArgs) Handles BDelActual.Click

    End Sub
End Class