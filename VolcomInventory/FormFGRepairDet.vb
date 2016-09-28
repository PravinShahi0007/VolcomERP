Public Class FormFGRepairDet
    Public id_fg_repair As String = "-1"
    Public action As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_repair_det_list As New List(Of String)
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

    Private Sub FormFGRepairDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            TxtCodeCompFrom.Focus()
        ElseIf action = "upd" Then
            XTPSummary.PageVisible = True
            GVScan.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As ClassFGRepair = New ClassFGRepair()
            Dim query As String = query_c.queryMain("AND r.id_fg_repair='" + id_fg_repair + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_fg_repair = data.Rows(0)("id_fg_repair").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtNumber.Text = data.Rows(0)("fg_repair_number").ToString
            DEForm.Text = view_date_from(data.Rows(0)("fg_repair_datex").ToString, 0)
            MENote.Text = data.Rows(0)("fg_repair_note").ToString
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
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                Printing()
                Close()
            End If
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "91", id_fg_repair) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If
        PanelNavBarcode.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVScan.OptionsCustomization.AllowGroup = True

        'ATTACH
        If check_attach_report_status(id_report_status, "91", id_fg_repair) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
        TxtNumber.Focus()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND comp.id_departement = '" + id_departement_user + "' "
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                id_comp_from = "-1"
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_from = data.Rows(0)("id_comp").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                setDefaultDrawerFrom()
                viewDetail()
                codeAvailableIns()
                TxtCodeCompTo.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "-1"
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                id_comp_to = "-1"
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_to = data.Rows(0)("id_comp").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                setDefaultDrawerTo()
                Cursor = Cursors.Default
            End If
        End If
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
        query += "WHERE wh.id_comp='" + id_comp_from + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub viewDetail()
        Dim query As String = "CALL view_fg_repair('" + id_fg_repair + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCScan.DataSource = data
    End Sub

    Sub codeAvailableIns()
        SplashScreenManager1.ShowWaitForm()
        dt.Clear()
        Dim query As String = "CALL view_stock_fg_unique_del(0) "
        dt = execute_query(query, -1, True, "", "", "", "")
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "69"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "70"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        disableControl()
        is_delete_scan = False
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
    End Sub

    Sub disableControl()
        GVScan.OptionsCustomization.AllowSort = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        GroupGeneralHeader.Enabled = False
        GroupControl3.Enabled = False
        PanelControl3.Enabled = False
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        TxtScannedCode.Text = ""
        GVScan.OptionsCustomization.AllowSort = True
        TxtScannedCode.Visible = False
        LblScannedCode.Visible = False
        BStop.Enabled = False
        BScan.Enabled = True
        BDelete.Enabled = True
        GroupGeneralHeader.Enabled = True
        GroupControl3.Enabled = True
        PanelControl3.Enabled = True
        BScan.Focus()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        disableControl()
        is_delete_scan = True
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        TxtScannedCode.Focus()
        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        'If confirm = Windows.Forms.DialogResult.Yes Then
        '    GVScan.DeleteSelectedRows()
        '    GCScan.RefreshDataSource()
        '    GVScan.RefreshData()
        'End If
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        If e.KeyCode = Keys.Enter And TxtScannedCode.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            If Not is_delete_scan Then 'scan
                makeSafeGV(GVScan)
                checkAvailable(TxtScannedCode.Text)
                TxtScannedCode.Text = ""
                TxtScannedCode.Focus()
            Else 'delete scan
                GVScan.ActiveFilterString = "[code]='" + TxtScannedCode.Text + "'"
                If GVScan.RowCount <= 0 Then
                    stopCustom("Code not found.")
                    GVScan.ActiveFilterString = ""
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    If action = "ins" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_pl_prod_order_rec_det_unique As String = GVScan.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                            GVScan.DeleteRow(GVScan.FocusedRowHandle)
                            GVScan.ActiveFilterString = ""
                            GCScan.RefreshDataSource()
                            GVScan.RefreshData()
                        Else
                            GVScan.ActiveFilterString = ""
                        End If
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    End If
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub checkAvailable(ByVal code_par As String)
        'check in GV
        GVScan.ActiveFilterString = "[code]='" + code_par + "'"
        If GVScan.RowCount > 0 Then
            GVScan.ActiveFilterString = ""
            stopCustom("Duplicate code")
        Else
            GVScan.ActiveFilterString = ""
            Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_par + "' ")
            If dt_filter.Length > 0 Then
                Dim newRow As DataRow = (TryCast(GCScan.DataSource, DataTable)).NewRow()
                newRow("id_fg_repair_det") = "0"
                newRow("id_fg_repair") = 0
                newRow("id_product") = dt_filter(0)("id_product").ToString
                newRow("code") = dt_filter(0)("product_full_code").ToString
                newRow("product_code") = dt_filter(0)("product_code").ToString
                newRow("name") = dt_filter(0)("name").ToString
                newRow("size") = dt_filter(0)("size").ToString
                newRow("id_pl_prod_order_rec_det_unique") = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
                newRow("fg_repair_det_counting") = dt_filter(0)("product_counting_code").ToString
                TryCast(GCScan.DataSource, DataTable).Rows.Add(newRow)
                GCScan.RefreshDataSource()
                GVScan.RefreshData()
            Else
                stopCustom("Code not found!")
            End If
        End If
    End Sub

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSamplePLToWH.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSamplePLToWH.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        'Cursor = Cursors.WaitCursor
        'ReportSamplePLToWH.id_sample_pl = id_sample_pl
        'ReportSamplePLToWH.dt = GCItemList.DataSource
        'Dim Report As New ReportSamplePLToWH()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVItemList)

        ''Parse val
        'Report.LabelNumber.Text = TxtNumber.Text
        'Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        'Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        'Report.LabelCreated.Text = DEForm.Text
        'Report.LabelNote.Text = MENote.Text

        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGRepairDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "91"
        FormDocumentUpload.id_report = id_fg_repair
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "91"
        FormReportMark.id_report = id_fg_repair
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVScan)

        'insert to temporary
        Dim data_temp As DataTable = GCScan.DataSource
        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
        Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
        connection.Open()
        Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
        Dim qry As String = "DROP TABLE IF EXISTS tb_fg_repair_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_fg_repair_temp AS ( SELECT * FROM ("
        For d As Integer = 0 To data_temp.Rows.Count - 1
            Dim id_product As String = data_temp.Rows(d)("id_product").ToString
            Dim id_pl_prod_order_rec_det_unique As String = data_temp.Rows(d)("id_pl_prod_order_rec_det_unique").ToString
            Dim code As String = data_temp.Rows(d)("product_code").ToString
            Dim name As String = data_temp.Rows(d)("name").ToString
            Dim size As String = data_temp.Rows(d)("size").ToString
            If d > 0 Then
                qry += "UNION ALL "
            End If
            qry += "SELECT '" + id_product + "' AS `id_product`, '" + id_pl_prod_order_rec_det_unique + "' AS `id_pl_prod_order_rec_det_unique`, '" + code + "' AS `code`, '" + name + "' AS `name`, '" + size + "' AS `size`  "
        Next
        qry += ") a ); ALTER TABLE tb_fg_repair_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
        command.CommandText = qry
        command.ExecuteNonQuery()
        command.Dispose()
        'Console.WriteLine(qry)

        Dim data_view As New DataTable
        Dim qry_view As String = "SELECT a.id_product, a.code, a.name, a.size, COUNT(a.id_product) AS `qty` 
                                FROM tb_fg_repair_temp a 
                                GROUP BY a.id_product"
        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(qry_view, connection)
        adapter.SelectCommand.CommandTimeout = 300
        adapter.Fill(data_view)
        adapter.Dispose()

        connection.Close()
        connection.Dispose()

        'get data stock
        Dim query_stock As String = "call view_stock_fg('" + id_comp_from + "', '" + id_wh_locator_from + "', '" + id_wh_rack_from + "', '" + id_wh_drawer_from + "', '0', '4', '9999-01-01')"
        Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
        Dim tb1 = data_view.AsEnumerable()
        Dim tb2 = data_stock.AsEnumerable()
        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2 On table1("id_product").ToString Equals table_tmp("id_product").ToString
                    Into Group
                    From y1 In Group.DefaultIfEmpty()
                    Select New With
                    {
                        .code = table1.Field(Of String)("code").ToString,
                        .name = table1.Field(Of String)("name").ToString,
                        .size = table1.Field(Of String)("size").ToString,
                        .qty = table1("qty"),
                        .available_qty = If(y1 Is Nothing, 0, y1("qty_all_product")),
                        .price = If(y1 Is Nothing, 0, y1("design_price_retail")),
                        .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                        .status = If(table1("qty") <= If(y1 Is Nothing, 0, y1("qty_all_product")), "OK", "Can't exceed" + If(y1 Is Nothing, 0, y1("qty_all_product").ToString))
                    }
        GCScanSum.DataSource = Nothing
        GCScanSum.DataSource = query.ToList()
        GCScanSum.RefreshDataSource()
        GVScanSum.PopulateColumns()
        XTPSummary.PageVisible = True
        XtraTabControl1.SelectedTabPageIndex = 1

        'Customize column
        GVScanSum.Columns("id_product").Visible = False
        GVScanSum.Columns("no").VisibleIndex = 0
        GVScanSum.Columns("code").VisibleIndex = 1
        GVScanSum.Columns("name").VisibleIndex = 2
        GVScanSum.Columns("size").VisibleIndex = 3
        GVScanSum.Columns("qty").VisibleIndex = 4
        GVScanSum.Columns("available_qty").VisibleIndex = 5
        GVScanSum.Columns("price").VisibleIndex = 6
        GVScanSum.Columns("amount").VisibleIndex = 7
        GVScanSum.Columns("status").VisibleIndex = 8
        GVScanSum.Columns("price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVScanSum.Columns("price").DisplayFormat.FormatString = "{0:n2}"
        GVScanSum.Columns("amount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        GVScanSum.Columns("amount").DisplayFormat.FormatString = "{0:n2}"
    End Sub


End Class