Public Class FormSamplePLToWHDet
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
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_sample")
            dt.Columns.Add("code")
            dt.Columns.Add("code_us")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("class")
            dt.Columns.Add("id_season")
            dt.Columns.Add("season")
            dt.Columns.Add("id_season_orign")
            dt.Columns.Add("season_orign")
            dt.Columns.Add("qty")
            dt.Columns.Add("id_cost")
            dt.Columns.Add("cost")
            dt.Columns.Add("id_price")
            dt.Columns.Add("price")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

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
            check_but()
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

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
        Dim id_samplex As String = "0"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try

        'Constraint Status
        If GVItemList.RowCount > 0 And id_samplex <> "0" Then
            BDelete.Enabled = True
        Else
            BDelete.Enabled = False
        End If
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND comp.id_departement = '" + id_departement_user + "' "
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtNameCompFrom.Text = ""
                id_comp_from = "-1"
                id_comp_contact_from = "-1"
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_from = data.Rows(0)("id_comp").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                setDefaultDrawer()
                viewDetail()
                codeAvailableIns()
                TxtCodeCompTo.Focus()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Dim query_cond As String = "AND comp.id_departement = '" + id_departement_user + "' "
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, "-1")
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                TxtNameCompTo.Text = ""
                id_comp_to = "-1"
                id_comp_contact_to = "-1"
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_to = data.Rows(0)("id_comp").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                BScan.Focus()
                Cursor = Cursors.Default
            End If
        End If
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
            R("id_price") = data.Rows(k)("id_sample_ret_price").ToString
            R("price") = data.Rows(k)("sample_ret_price")
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
                If dt_filter(0)("id_price").ToString <> "0" Then
                    Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sample_pl_det") = "0"
                    newRow("id_sample") = dt_filter(0)("id_sample").ToString
                    newRow("id_sample_price") = dt_filter(0)("id_cost").ToString
                    newRow("sample_price") = dt_filter(0)("cost")
                    newRow("id_sample_ret_price") = dt_filter(0)("id_price").ToString
                    newRow("sample_ret_price") = dt_filter(0)("price")
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
                    'newRow("amount") = 0
                    TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                Else
                    stopCustom("Retail price is not available !")
                End If
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


    Private Sub BtnBrowseFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseFrom.Click
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.id_pop_up = "64"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnBrowseTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseTo.Click
        FormPopUpContact.id_pop_up = "65"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub FormSamplePLToWHDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        TxtScannedCode.Visible = True
        LblScannedCode.Visible = True
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        GroupGeneralHeader.Enabled = False
        GroupControl3.Enabled = False
        PanelControl3.Enabled = False
        TxtScannedCode.Focus()
    End Sub

    Private Sub BStop_Click(sender As Object, e As EventArgs) Handles BStop.Click
        TxtScannedCode.Text = ""
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

    Private Sub BtnBrowseDrawer_Click(sender As Object, e As EventArgs) Handles BtnBrowseDrawer.Click
        FormPopUpDrawer.id_pop_up = "6"
        FormPopUpDrawer.id_comp = id_comp_from
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        If e.KeyCode = Keys.Enter And TxtScannedCode.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVItemList)
            checkAvailable(TxtScannedCode.Text)
            TxtScannedCode.Text = ""
            TxtScannedCode.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVItemList.DeleteSelectedRows()
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "85", id_sample_pl) Then
            MENote.Enabled = True
            BtnSave.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
        End If
        PanelNavBarcode.Enabled = False
        TxtCodeCompFrom.Enabled = False
        TxtCodeCompTo.Enabled = False
        TxtCodeDrawer.Enabled = False
        BtnBrowseDrawer.Enabled = False
        BtnBrowseFrom.Enabled = False
        BtnBrowseTo.Enabled = False
        GridColumnQty.OptionsColumn.AllowEdit = False
        GVItemList.OptionsCustomization.AllowGroup = True

        'ATTACH
        If check_attach_report_status(id_report_status, "85", id_sample_pl) Then
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVItemList)

        'check stok
        GridColumnStatus.Visible = False
        Dim cond_stc As Boolean = True
        If action = "ins" Then
            Dim dt_cek As DataTable = execute_query("CALL view_stock_sample('" + id_comp_from + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '9999-12-01', '2') ", -1, True, "", "", "", "")
            For c As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(c, "sample_pl_det_qty")
                Dim id_sample_cek As String = GVItemList.GetRowCellValue(c, "id_sample").ToString
                Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_sample]='" + id_sample_cek + "' ")
                Dim qty_limit As Integer = 0
                If dt_filter_cek.Length > 0 Then
                    qty_limit = dt_filter_cek(0)("qty_all_sample")
                Else
                    qty_limit = 0
                End If
                If qty_cek > qty_limit Then
                    GVItemList.SetRowCellValue(c, "err_stt", "Can't exceed " + qty_limit.ToString + "")
                    cond_stc = False
                Else
                    GVItemList.SetRowCellValue(c, "err_stt", "OK")
                End If
            Next
        End If
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()

        If id_comp_contact_from = "-1" Or id_comp_contact_to = "-1" Or id_wh_drawer = "-1" Or id_wh_locator = "-1" Or id_wh_rack = "-1" Or GVItemList.RowCount <= 0 Then
            stopCustom("Data can't blank!")
        ElseIf Not cond_stc Then
            GridColumnStatus.Visible = True
            GridColumnStatus.VisibleIndex = 100
            stopCustom("Some item can't exceed qty limit, please see error in column status!")
        Else
            Dim sample_pl_number As String = TxtNumber.Text
            Dim sample_pl_note As String = MENote.Text
            If action = "ins" Then
                'code here
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Stock qty will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'main query
                    Dim query As String = "INSERT INTO tb_sample_pl(id_comp_contact_from, id_comp_contact_to, id_wh_drawer, sample_pl_number, sample_pl_date, sample_pl_note, id_report_status) VALUES "
                    query += "('" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + id_wh_drawer + "', '" + header_number("19") + "', NOW(), '" + sample_pl_note + "', '1'); SELECT LAST_INSERT_ID(); "
                    id_sample_pl = execute_query(query, 0, True, "", "", "", "")
                    increase_inc("19")

                    'insert who prepared
                    insert_who_prepared("85", id_sample_pl, id_user)

                    'Detail 
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sample_pl_det(id_sample_pl, id_sample, id_sample_price, sample_price, id_sample_ret_price, sample_ret_price, sample_pl_det_qty, sample_pl_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Dim id_sample = GVItemList.GetRowCellValue(j, "id_sample").ToString
                        Dim id_sample_price = GVItemList.GetRowCellValue(j, "id_sample_price").ToString
                        Dim sample_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_price").ToString)

                        Dim id_sample_ret_price = GVItemList.GetRowCellValue(j, "id_sample_ret_price").ToString
                        Dim sample_ret_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_ret_price").ToString)

                        Dim sample_pl_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sample_pl_det_qty").ToString)
                        Dim sample_pl_det_note As String = GVItemList.GetRowCellValue(j, "sample_pl_det_note").ToString

                        If jum_ins_j > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_sample_pl + "', '" + id_sample + "', '" + id_sample_price + "', '" + sample_price + "', '" + id_sample_ret_price + "', '" + sample_ret_price + "', '" + sample_pl_det_qty + "', '" + sample_pl_det_note + "') "
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'reserved stock
                    Dim rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                    rsv_stock.reservedStock(id_sample_pl, "85")

                    'refresh data
                    FormSamplePLToWH.viewSamplePL()
                    FormSamplePLToWH.GVSamplePL.FocusedRowHandle = find_row(FormSamplePLToWH.GVSamplePL, "id_sample_pl", id_sample_pl)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtNumber.Text + " was created successfully.")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                'code here
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'main query
                    Dim query As String = "UPDATE tb_sample_pl SET sample_pl_note ='" + sample_pl_note + "' WHERE id_sample_pl='" + id_sample_pl + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Dim id_sample_pl_det As String = GVItemList.GetRowCellValue(j, "id_sample_pl_det").ToString
                        Dim sample_pl_det_note As String = GVItemList.GetRowCellValue(j, "sample_pl_det_note").ToString

                        If id_sample_pl_det <> "0" Then
                            Dim query_detail_upd As String = "UPDATE tb_sample_pl_det SET sample_pl_det_note='" + sample_pl_det_note + "' WHERE id_sample_pl_det='" + id_sample_pl_det + "' "
                            execute_non_query(query_detail_upd, True, "", "", "", "")
                        End If
                    Next

                    'refresh data
                    FormSamplePLToWH.viewSamplePL()
                    FormSamplePLToWH.GVSamplePL.FocusedRowHandle = find_row(FormSamplePLToWH.GVSamplePL, "id_sample_pl", id_sample_pl)
                    action = "upd"
                    actionLoad()
                    infoCustom("Document #" + TxtNumber.Text + " was edited successfully.")
                    Cursor = Cursors.Default
                End If
            End If
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

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        Cursor = Cursors.WaitCursor
        printing()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        Cursor = Cursors.WaitCursor
        prePrinting()
        Cursor = Cursors.Default
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        ReportSamplePLToWH.id_sample_pl = id_sample_pl
        ReportSamplePLToWH.dt = GCItemList.DataSource
        Dim Report As New ReportSamplePLToWH()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LabelCreated.Text = DEForm.Text
        Report.LabelNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "85"
        FormReportMark.id_report = id_sample_pl
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "85"
        FormDocumentUpload.id_report = id_sample_pl
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class