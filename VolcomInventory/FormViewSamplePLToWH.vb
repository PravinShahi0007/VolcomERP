Public Class FormViewSamplePLToWH
    Public action As String = ""
    Public id_sample_pl As String = "-1"
    Public id_report_status As String = "-1"
    Public id_sample_pl_det_list As New List(Of String)
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public dt As New DataTable
    Public id_pre As String = "-1"

    Private Sub FormSamplePLToWHDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BMark.Enabled = True

        'query view based on edit id's
        Dim query_c As ClassSamplePLtoWH = New ClassSamplePLtoWH()
        Dim query As String = query_c.queryMain("AND pl.id_sample_pl='" + id_sample_pl + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sample_pl = data.Rows(0)("id_sample_pl").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtNumber.Text = data.Rows(0)("sample_pl_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("sample_pl_datex").ToString, 0)
        MENote.Text = data.Rows(0)("sample_pl_note").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_from_code").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_from_name").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_to_code").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_to_name").ToString
        id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
        id_wh_rack = data.Rows(0)("id_wh_rack").ToString
        id_wh_locator = data.Rows(0)("id_wh_locator").ToString
        TxtCodeDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
        TxtNameDrawer.Text = data.Rows(0)("wh_drawer").ToString

        'detail2
        viewDetail()
        allow_status()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub setDefaultDrawer()
        'get drw def
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_comp_from + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            id_wh_locator = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack = data.Rows(0)("id_wh_rack").ToString
            id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
            TxtCodeDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
            TxtNameDrawer.Text = data.Rows(0)("wh_drawer").ToString
        End If
    End Sub

    Sub codeAvailableIns()
        dt.Clear()
        Dim query As String = "CALL view_stock_sample('" + id_comp_from + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '9999-12-01', '2') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For k As Integer = 0 To (data.Rows.Count - 1)
            Dim R As DataRow = dt.NewRow
            R("id_sample") = data.Rows(k)("id_sample").ToString
            R("code") = data.Rows(k)("code").ToString
            R("code_us") = data.Rows(k)("code_us").ToString
            R("name") = data.Rows(k)("name").ToString
            R("size") = data.Rows(k)("size").ToString
            R("color") = data.Rows(k)("color").ToString
            R("class") = data.Rows(k)("class").ToString
            R("id_season") = data.Rows(k)("id_season").ToString
            R("season") = data.Rows(k)("season").ToString
            R("id_season_orign") = data.Rows(k)("id_season_orign").ToString
            R("season_orign") = data.Rows(k)("season_orign").ToString
            R("qty") = data.Rows(k)("qty_all_sample")
            R("id_cost") = data.Rows(k)("id_sample_price").ToString
            R("cost") = data.Rows(k)("sample_price")
            dt.Rows.Add(R)
        Next
    End Sub

    Private Sub checkAvailable(ByVal code_par As String)
        'check in GV
        GVItemList.ActiveFilterString = "[code]='" + code_par + "'"
        If GVItemList.RowCount > 0 Then
            Dim tot As Integer = GVItemList.GetFocusedRowCellValue("sample_pl_det_qty") + 1
            GVItemList.SetFocusedRowCellValue("sample_pl_det_qty", tot)
            GVItemList.ActiveFilterString = ""
        Else
            GVItemList.ActiveFilterString = ""
            Dim dt_filter As DataRow() = dt.Select("[code]='" + code_par + "' ")
            If dt_filter.Length > 0 Then
                Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_sample_pl_det") = "0"
                newRow("id_sample") = dt_filter(0)("id_sample").ToString
                newRow("id_sample_price") = dt_filter(0)("id_cost").ToString
                newRow("sample_price") = dt_filter(0)("cost")
                newRow("code") = dt_filter(0)("code").ToString
                newRow("code_us") = dt_filter(0)("code_us").ToString
                newRow("name") = dt_filter(0)("name").ToString
                newRow("size") = dt_filter(0)("size").ToString
                newRow("color") = dt_filter(0)("color").ToString
                newRow("class") = dt_filter(0)("class").ToString
                newRow("id_season") = dt_filter(0)("id_season").ToString
                newRow("season") = dt_filter(0)("season").ToString
                newRow("id_season_orign") = dt_filter(0)("id_season_orign").ToString
                newRow("season_orign") = dt_filter(0)("season_orign").ToString
                newRow("sample_pl_det_qty") = 1
                TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
            Else
                stopCustom("Code not found!")
            End If
        End If
    End Sub


    Sub viewDetail()
        Dim query As String = "CALL view_sample_pl('" + id_sample_pl + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub


    Private Sub FormSamplePLToWHDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "85", id_sample_pl) Then
            MENote.Enabled = True
        Else
            MENote.Enabled = False
        End If
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        TxtCodeDrawer.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVItemList.OptionsCustomization.AllowGroup = True

        'ATTACH
        If check_attach_report_status(id_report_status, "85", id_sample_pl) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub




    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "85"
        FormReportMark.id_report = id_sample_pl
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "85"
        FormDocumentUpload.id_report = id_sample_pl
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class