Public Class FormProductionClaimReturnDet
    Public action As String = ""
    Public id As String = "-1"
    Public id_report_status As String = "-1"
    Dim created_date As String = ""
    Public id_prod_order As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormProductionClaimReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'purc order detail
            BtnBrowse.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
        Else
            Dim r As New ClassProductionClaimReturn()
            Dim query As String = r.queryMain("AND cr.id_prod_claim_return='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("purc_rec_number").ToString
            created_date = DateTime.Parse(data.Rows(0)("date_created")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("date_created")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            TxtOrderNumber.Text = data.Rows(0)("purc_order_number").ToString
            TxtVendor.Text = data.Rows(0)("vendor").ToString

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVDetail.OptionsBehavior.Editable = False

        If check_edit_report_status(id_report_status, "151", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormProductionClaimReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_prod_claim_return SET id_report_status=5 WHERE id_prod_claim_return='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 151, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormProductionClaimReturn.viewData()
            FormProductionClaimReturn.GVData.FocusedRowHandle = find_row(FormProductionClaimReturn.GVData, "id_prod_claim_return", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            'Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            'Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'If XTCReceive.SelectedTabPageIndex = 0 Then
            '    gcx = GCSummary
            '    gvx = GVSummary
            'ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
            '    gcx = GCDetail
            '    gvx = GVDetail
            'ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
            '    gcx = GCOrderDetail
            '    gvx = GVOrderDetail
            'End If
            'ReportPurcReceive.id = id
            'ReportPurcReceive.dt = gcx.DataSource
            'Dim Report As New ReportPurcReceive()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''Grid Detail
            'ReportStyleGridview(Report.GVData)

            ''Parse val
            'Report.LabelNumber.Text = TxtOrderNumber.Text.ToUpper
            'Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
            'Report.LabelVendor.Text = TxtVendor.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToString
            'Report.LNote.Text = MENote.Text.ToString
            'If XTCReceive.SelectedTabPageIndex = 2 Then
            '    Report.LabelNumber.Visible = False
            '    Report.LabelDate.Visible = False
            '    Report.LNote.Visible = False
            '    Report.LNotex.Visible = False
            '    Report.XrLabel11.Visible = False
            '    Report.XrLabel10.Visible = False
            '    Report.XrLabel18.Visible = False
            '    Report.LabelTitle.Text = "ORDER DETAILS"
            '    Report.XrTable1.Visible = False   '
            'End If

            ''Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCDetail)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "151"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "151", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "151"
        FormReportMark.id_report = id
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged

    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub
End Class