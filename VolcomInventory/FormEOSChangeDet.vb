Public Class FormEOSChangeDet
    Public action As String
    Public id As String = "-1"
    Public id_report_status As String
    Dim rmt As String = "365"
    Public is_view = "-1"
    Dim id_pp As String = "-1"

    Private Sub FormEOSChangeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewMKD()
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormEOSChangeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewMKD()
        Dim query As String = "SELECT p.id_pp_change, p.number, p.effective_date, p.plan_end_date 
        FROM tb_pp_change p WHERE p.id_report_status=6 "
        If action = "ins" Then
            query += "AND p.id_design_mkd=1 AND p.plan_end_date>=NOW() "
        End If
        viewSearchLookupQuery(SLEMKD, query, "id_pp_change", "number", "id_pp_change")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            SLEMKD.EditValue = Nothing
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim r As New ClassEOSChange()
            Dim query As String = r.queryMain("AND s.id_eos_change='" + id + "'", "1")
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            SLEMKD.EditValue = data.Rows(0)("id_pp_change").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            DEForm.EditValue = data.Rows(0)("created_date")
            TxtSalesOrderNumber.Text = data.Rows(0)("number").ToString
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            DEPlanEndDate.EditValue = data.Rows(0)("plan_end_date")
            DENewEndDate.EditValue = data.Rows(0)("pps_date")
            id_pp = data.Rows(0)("id_pp_change").ToString

            'detail2
            viewDetail()
            allow_status()
        End If
    End Sub

    Private Sub SLEMKD_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMKD.EditValueChanged
        If action = "ins" Then
            id_pp = "-1"
            Dim endd As Date = Now
            Try
                id_pp = SLEMKD.EditValue.ToString
                endd = SLEMKD.Properties.View.GetFocusedRowCellValue("plan_end_date")
            Catch ex As Exception
            End Try
            DEPlanEndDate.EditValue = endd
            Dim min_date As Date = endd.AddDays(1)
            DENewEndDate.Properties.MinValue = min_date
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_pp_change_det, d.id_design, dsg.design_code AS `code`, cd.class,dsg.design_display_name AS `name`, cd.sht, cd.color,
        d.propose_price_final
        FROM tb_pp_change_det d
        INNER JOIN tb_m_design dsg ON dsg.id_design = d.id_design
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
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = dsg.id_design
        WHERE d.id_pp_change=" + id_pp + " AND d.id_extended_eos=1
        ORDER BY `class` ASC, `name` ASC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnPrint.Enabled = True
        SLEMKD.Enabled = False
        DEPlanEndDate.Enabled = False
        DENewEndDate.Enabled = False
        BtnSave.Enabled = False
        MENote.Properties.ReadOnly = True
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = rmt
        FormReportMark.form_origin = Name
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportEOSChange.id = id
        ReportEOSChange.dt = GCItemList.DataSource
        ReportEOSChange.rmt = rmt
        Dim Report As New ReportEOSChange()

        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse Val
        Report.LabelNumber.Text = TxtSalesOrderNumber.Text.ToUpper
        Report.LabelDate.Text = DEForm.Text.ToUpper
        Report.LNote.Text = MENote.Text
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LabelPPno.Text = SLEMKD.Text.ToUpper
        Report.LabelRencanaAkhir.Text = DEPlanEndDate.Text.ToUpper
        Report.LabelDiperpanjangHingga.Text = DENewEndDate.Text.ToUpper

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVItemList)
        If SLEMKD.EditValue = Nothing Or GVItemList.RowCount <= 0 Or MENote.Text = "" Then
            stopCustom("Please input all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to propose this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim note As String = addSlashes(MENote.Text)
                Dim pps_date As String = DateTime.Parse(DENewEndDate.EditValue.ToString).ToString("yyyy-MM-dd")

                'head
                Dim query As String = "INSERT INTO tb_eos_change(number, created_date, id_report_status, note, id_pp_change, pps_date)
                VALUES('', NOW(), 1, '" + note + "', '" + id_pp + "', '" + pps_date + "');SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", " + rmt + "); ", True, "", "", "", "")

                submit_who_prepared(rmt, id, id_user)

                FormEOSChange.viewData()
                FormEOSChange.GVData.FocusedRowHandle = find_row(FormEOSChange.GVData, "id_eos_change", id)
                action = "upd"
                actionLoad()
                infoCustom("Document #" + TxtSalesOrderNumber.Text + " was created successfully. Waiting for approval")
            End If
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        FormDocumentUpload.report_mark_type = rmt
        If id_report_status = 6 Then
            FormDocumentUpload.is_no_delete = "1"
        ElseIf id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class