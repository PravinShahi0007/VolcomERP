Public Class FormFGProposePriceDetail
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Public id_division As String = "-1"
    Public id_source As String = "-1"
    Dim rmt As String = "70"


    Private Sub FormFGProposePriceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub


    Sub actionLoad()
        'main
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("AND tb_fg_propose_price.id_fg_propose_price=''" + id + "'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        MENote.Text = data.Rows(0)("fg_propose_price_note").ToString
        DECreated.EditValue = data.Rows(0)("fg_propose_price_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        id_division = data.Rows(0)("id_division").ToString
        id_source = data.Rows(0)("id_source").ToString
        TxtSource.Text = data.Rows(0)("source").ToString

        'detail
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()

    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

    End Sub

    Private Sub BtnUpdateCOP_Click(sender As Object, e As EventArgs) Handles BtnUpdateCOP.Click

    End Sub

    Private Sub FormFGProposePriceDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_fg_propose_price SET id_report_status=5 WHERE id_fg_propose_price='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGProposePrice.viewPropose()
            FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'If XTCRevision.SelectedTabPageIndex = 0 Then
            '    gv = GVRevision
            '    ReportProdDemandRev.dt = GCRevision.DataSource
            '    ReportProdDemandRev.type = "1"
            'ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
            '    gv = GVData
            '    ReportProdDemandRev.dt = GCData.DataSource
            '    ReportProdDemandRev.type = "2"
            'End If
            'ReportProdDemandRev.id = id
            'If id_report_status <> "6" Then
            '    ReportProdDemandRev.is_pre = "1"
            'Else
            '    ReportProdDemandRev.is_pre = "-1"
            'End If
            'ReportProdDemandRev.id_report_status = LEReportStatus.EditValue.ToString

            'ReportProdDemandRev.rmt = rmt
            'Dim Report As New ReportProdDemandRev()

            '... 
            ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''style
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            'Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            'Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            'Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            'Report.GVData.OptionsPrint.ExpandAllDetails = True
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.OptionsPrint.PrintDetails = True
            'Report.GVData.OptionsPrint.PrintFooter = True

            'Report.LabelNumber.Text = TxtProdDemandNumber.Text
            'Report.LabelRev.Text = TxtRevision.Text
            'Report.LabelDate.Text = DECreated.Text.ToUpper
            'Report.LabelSeason.Text = season.ToUpper
            'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            'Report.LNote.Text = MENote.Text

            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class