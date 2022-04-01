Public Class FormSampleDevTargetPps
    Public id_pps As String = "-1"
    Public is_view As String = "-1"

    Dim id_report_status As String = "-1"

    Private Sub FormSampleDevTargetPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub load_head()
        view_vendor()

        If id_pps = "-1" Then
            'new
            BAttach.Visible = False
            BtnPrint.Visible = False
            BMark.Visible = False
        Else
            'update
            BAttach.Visible = True
            BtnPrint.Visible = True
            BMark.Visible = True
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
            End If
        End If

        load_det()
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

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSampleDevTargetAdd.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If GVPps.RowCount = 0 Then
            warningCustom("No data found, please put some design.")
        Else
            If id_pps = "-1" Then
                'new
                Dim q As String = "INSERT INTO `tb_sample_dev_pps`(created_date,id_comp,created_by,note,id_report_status)
VALUES(NOW(),'" & SLEVendor.EditValue.ToString & "','" & id_user & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                id_pps = execute_query(q, 0, True, "", "", "", "")

                execute_non_query("CALL gen_number('" & id_pps & "','403')", True, "", "", "", "")

                'detail
                q = "INSERT INTO `tb_sample_dev_pps_det`(`id_sample_dev_pps`,`id_design`,`labdip`,`strike_off_1`,`proto_sample_1`,`strike_off_2`,`proto_sample_2`,`copy_proto_sample_2`)"
                For i = 0 To GVPps.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "id_design").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "labdip").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "strike_off_1").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "proto_sample_1").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "strike_off_2").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "proto_sample_2").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVPps.GetRowCellValue(i, "copy_proto_sample_2").ToString).ToString) & "')"
                Next

                execute_non_query(q, True, "", "", "", "")

                submit_who_prepared("403", id_pps, id_user)

                Close()
            Else
                'no edit pls
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
End Class