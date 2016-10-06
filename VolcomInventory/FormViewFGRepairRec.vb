Public Class FormViewFGRepairRec
    Public id_fg_repair_rec As String = "-1"
    Public id_fg_repair_select As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_repair_rec_det_list As New List(Of String)
    Public id_pre As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_wh_locator_from As String = "-1"
    Public id_wh_rack_from As String = "-1"
    Public id_wh_drawer_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_wh_locator_to As String = "-1"
    Public id_wh_rack_to As String = "-1"
    Public id_wh_drawer_to As String = "-1"
    Public dt As New DataTable
    Dim is_delete_scan As Boolean = False
    Public id_type As String = "-1"

    Private Sub FormFGRepairRecDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        XTPSummary.PageVisible = True
        XtraTabControl1.SelectedTabPageIndex = 1
        GVScan.OptionsBehavior.AutoExpandAllGroups = True
        BMark.Enabled = True

        'query view based on edit id's
        Dim query_c As ClassFGRepairRec = New ClassFGRepairRec()
        Dim query As String = query_c.queryMain("AND rec.id_fg_repair_rec='" + id_fg_repair_rec + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_fg_repair_rec = data.Rows(0)("id_fg_repair_rec").ToString
        id_fg_repair_select = data.Rows(0)("id_fg_repair").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNumber.Text = data.Rows(0)("fg_repair_rec_number").ToString
        TxtNumberRepair.Text = data.Rows(0)("fg_repair_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_repair_rec_datex").ToString, 0)
        MENote.Text = data.Rows(0)("fg_repair_rec_note").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        setDefaultDrawerFrom()
        setDefaultDrawerTo()

        'detail2
        viewDetail()
        viewDetailSum()
        allow_status()

        If id_pre = "1" Then
            prePrinting()
            Close()
        ElseIf id_pre = "2" Then
            printing()
            Close()
        End If
    End Sub

    Sub viewRepair()
        Dim query_c As ClassFGRepair = New ClassFGRepair()
        Dim query As String = query_c.queryMain("AND r.id_fg_repair='" + id_fg_repair_select + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_fg_repair_select = data.Rows(0)("id_fg_repair").ToString
        TxtNumberRepair.Text = data.Rows(0)("fg_repair_number").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        setDefaultDrawerFrom()
        setDefaultDrawerTo()
        codeAvailableIns()
    End Sub

    Sub codeAvailableIns()

    End Sub


    Sub setDefaultDrawerFrom()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_from)
        If data.Rows.Count > 0 Then
            id_wh_locator_from = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_from = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_from = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            id_comp_from = "-1"
            id_wh_locator_from = "-1"
            id_wh_rack_from = "-1"
            id_wh_drawer_from = "-1"
        End If
    End Sub

    Sub setDefaultDrawerTo()
        'get drw def
        Dim data As DataTable = queryDefaultDrawer(id_comp_to)
        If data.Rows.Count > 0 Then
            id_wh_locator_to = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack_to = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer_to = data.Rows(0)("id_wh_drawer").ToString
        Else
            stopCustom("There is no drawer default for this company")
            id_comp_to = "-1"
            id_wh_locator_to = "-1"
            id_wh_rack_to = "-1"
            id_wh_drawer_to = "-1"
        End If
    End Sub

    Function queryDefaultDrawer(ByVal id_comp As String) As DataTable
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_comp + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Dim query As String = "CALL view_fg_repair_rec('" + id_fg_repair_rec + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScan.DataSource = data
    End Sub

    Sub viewDetailSum()
        Dim query As String = "CALL view_fg_repair_sum('" + id_fg_repair_select + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScanSum.DataSource = data
        GridColumnStatus.Visible = False
        GridColumnQtyAvail.Visible = False
    End Sub

    Sub allow_status()
        MENote.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVScan.OptionsCustomization.AllowGroup = True

        'ATTACH
        If check_attach_report_status(id_report_status, "92", id_fg_repair_rec) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairDet.id_pre = "1"
        Else
            ReportFGRepair.id_pre = "1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            ReportFGRepairDet.id_pre = "-1"
        Else
            ReportFGRepair.id_pre = "-1"
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        'Cursor = Cursors.WaitCursor
        'If XtraTabControl1.SelectedTabPageIndex = 0 Then
        '    GridColumnStatus.Visible = False
        '    ReportFGRepairRecDet.id_fg_repair_rec = id_fg_repair_rec
        '    ReportFGRepairRecDet.id_type = id_type
        '    ReportFGRepairRecDet.dt = GCScan.DataSource
        '    Dim Report As New ReportFGRepairRecDet()

        '    ' '... 
        '    ' ' creating and saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVScan.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'Grid Detail
        '    ReportStyleGridview(Report.GVScan)

        '    'Parse val
        '    Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        '    Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        '    Report.LRecNumber.Text = TxtNumber.Text
        '    Report.LRecDate.Text = DEForm.Text
        '    Report.LabelNote.Text = MENote.Text
        '    If id_type = "1" Then
        '        Report.XrPanel2.Visible = False
        '    End If

        '    ' Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreview()
        'Else
        '    GridColumnStatus.Visible = False
        '    ReportFGRepairRec.id_fg_repair = id_fg_repair_select
        '    ReportFGRepairRec.id_type = id_type
        '    ReportFGRepairRec.dt = GCScanSum.DataSource
        '    Dim Report As New ReportFGRepair()

        '    ' '... 
        '    ' ' creating and saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    GVScanSum.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVScanSum.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'Grid Detail
        '    ReportStyleGridview(Report.GVScanSum)

        '    'Parse val
        '    Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        '    Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        '    Report.LRecNumber.Text = TxtNumber.Text
        '    Report.LRecDate.Text = DEForm.Text
        '    Report.LabelNote.Text = MENote.Text
        '    If id_type = "1" Then
        '        Report.XrPanel2.Visible = False
        '    End If

        '    ' Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreview()
        'End If
        'Cursor = Cursors.Default
    End Sub


    Private Sub FormFGRepairRecDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "92"
        FormDocumentUpload.id_report = id_fg_repair_rec
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "92"
        FormReportMark.id_report = id_fg_repair_rec
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub



    Sub disableControl()
        GVScan.OptionsCustomization.AllowSort = False
        GroupGeneralHeader.Enabled = False
        GroupControl3.Enabled = False
        XTPSummary.PageVisible = False
    End Sub



    Private Sub checkAvailable(ByVal code_par As String)

    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.Name = "GridColumnNoSum" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class