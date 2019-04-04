Public Class FormFGProposePriceRev
    Public id As String = "-1"
    Public id_pp As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = ""
    Dim season As String = ""

    Private Sub FormFGProposePriceRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormFGProposePriceRev_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim r As New ClassFGProposePrice
        Dim data As DataTable = r.dataMainRev("AND ppr.id_fg_propose_price_rev='" + id + "' ", "1")
        id_pp = data.Rows(0)("id_fg_propose_price").ToString
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        TxtRevision.Text = data.Rows(0)("rev_count").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        season = data.Rows(0)("season").ToString
        rmt = "188"
        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRevision.DataSource = data
        GVRevision.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewPPAll()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
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

    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_fg_propose_price_rev SET id_report_status=5 WHERE id_fg_propose_price_rev='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGProposePrice.viewRevision()
            FormFGProposePrice.GVRev.FocusedRowHandle = find_row(FormFGProposePrice.GVRev, "id_fg_propose_price_rev", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVRevision)
        'cek file
        Dim cond_exist_file As Boolean = True
        'Dim query_file As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id + ""
        'Dim data_file As DataTable = execute_query(query_file, -1, True, "", "", "", "")
        'If data_file.Rows.Count <= 0 Then
        '    cond_exist_file = False
        'End If

        If Not cond_exist_file Then
            stopCustom("Please attach document first")
        ElseIf GVRevision.RowCount <= 0 Then
            stopCustom("No revisions were made. If you want to cancel this revision, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm PP revision ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update confirm
                Dim query As String = "UPDATE tb_fg_propose_price_rev SET is_confirm=1 WHERE id_fg_propose_price_rev='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("PP Revision submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'If Not check_allow_print(id_report_status, rmt, id) Then
        '    warningCustom("Can't print, please complete all approval on system first")
        'Else
        '    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    If XTCRevision.SelectedTabPageIndex = 0 Then
        '        gv = GVRevision
        '        ReportProdDemandRev.dt = GCRevision.DataSource
        '        ReportProdDemandRev.type = "1"
        '    ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
        '        gv = GVData
        '        ReportProdDemandRev.dt = GCData.DataSource
        '        ReportProdDemandRev.type = "2"
        '    End If
        '    ReportProdDemandRev.id = id
        '    If id_report_status <> "6" Then
        '        ReportProdDemandRev.is_pre = "1"
        '    Else
        '        ReportProdDemandRev.is_pre = "-1"
        '    End If
        '    ReportProdDemandRev.id_report_status = LEReportStatus.EditValue.ToString

        '    ReportProdDemandRev.rmt = rmt
        '    Dim Report As New ReportProdDemandRev()

        '    '' '... 
        '    '' ' creating and saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'style
        '    Report.GVData.OptionsPrint.UsePrintStyles = True
        '    Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        '    Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        '    Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
        '    Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        '    Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        '    Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        '    Report.GVData.OptionsPrint.ExpandAllDetails = True
        '    Report.GVData.OptionsPrint.UsePrintStyles = True
        '    Report.GVData.OptionsPrint.PrintDetails = True
        '    Report.GVData.OptionsPrint.PrintFooter = True

        '    Report.LabelNumber.Text = TxtProdDemandNumber.Text
        '    Report.LabelRev.Text = TxtRevision.Text
        '    Report.LabelDate.Text = DECreated.Text.ToUpper
        '    Report.LabelSeason.Text = season.ToUpper
        '    Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        '    Report.LNote.Text = MENote.Text

        '    ' Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'End If
        'Cursor = Cursors.Default
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

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRevision_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRevision.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCRevision_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRevision.SelectedPageChanged
        If XTCRevision.SelectedTabPageIndex = 1 Then
            viewPPAll()
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVData.RowStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim stt As String = "0"
            Try
                stt = currview.GetRowCellValue(e.RowHandle, "id_pd_status_rev").ToString
            Catch ex As Exception
                stt = "0"
            End Try

            If stt = "1" Then
                e.Appearance.BackColor = Color.Yellow
            ElseIf stt = "2" Then
                e.Appearance.BackColor = Color.Crimson
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVRevision.RowCount > 0 And GVRevision.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this article ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_fg_propose_price_rev_det As String = GVRevision.GetFocusedRowCellValue("id_fg_propose_price_rev_det").ToString
                Dim query As String = "DELETE FROM tb_fg_propose_price_rev_det WHERE id_fg_propose_price_rev_det='" + id_fg_propose_price_rev_det + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub
End Class