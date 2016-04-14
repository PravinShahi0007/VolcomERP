Public Class FormViewSampleDelOrder 
    Public action As String = ""
    Public id_pl_sample_order_del As String = "-1"
    Public id_sample_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_store_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_report_status As String
    Public id_pl_sample_order_del_det_list As New List(Of String)
    Public id_pl_sample_order_del_det_drawer_list As New List(Of String)
    Public id_so_type As String = "-1"
    Public id_so_status As String = "-1"
    Dim id_season_default As String
    Dim id_comp_cat_wh As String = "-1"
    Dim is_scan As Boolean = False

    Private Sub FormViewSampleDelOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'get default store category for pick company
        id_comp_cat_wh = execute_query("SELECT id_comp_cat_wh FROM tb_opt", 0, True, "", "", "", "")

        viewReportStatus()
        viewSoType()
        viewSoStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        GroupControlListItem.Enabled = True
        GroupControlDrawerDetail.Enabled = True
        GroupControlScannedItem.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        XTPOutboundScanNew.PageEnabled = True

        'query view based on edit id's
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder()
        Dim query As String = query_c.queryMain("AND del_ord.id_pl_sample_order_del=''" + id_pl_sample_order_del + "'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_sample_order = data.Rows(0)("id_sample_order").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        id_store_to = data.Rows(0)("id_store_to").ToString
        id_report_status = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
        TxtNumber.Text = data.Rows(0)("pl_sample_order_del_number").ToString
        TxtSampleOrder.Text = data.Rows(0)("sample_order_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("pl_sample_order_del_datex").ToString, 0)
        MENote.Text = data.Rows(0)("pl_sample_order_del_note").ToString

        ''detail2
        viewDetailBC()
        viewDetail()
        viewDetailDrawer()
        check_but()
        allow_status()
    End Sub

    Sub viewSampleOrder()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryDetail(id_sample_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub check_but()
       
    End Sub

    Sub check_but2()
       
    End Sub

    Sub viewDetail()
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder()
        Dim query As String = query_c.queryDetail(id_pl_sample_order_del)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_pl_sample_order_del_det_list.Add(data.Rows(i)("id_pl_sample_order_del_det").ToString)
            For j As Integer = 0 To data.Rows(i)("pl_sample_order_del_det_qty") - 1
                GVBarcode.AddNewRow()
                GVBarcode.SetFocusedRowCellValue("id_sample", data.Rows(i)("id_sample"))
                GVBarcode.SetFocusedRowCellValue("code", data.Rows(i)("code"))
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            Next
        Next
        GCItemList.DataSource = data
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    Sub viewDetailDrawer()
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
        Dim query As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_pl_sample_order_del + "''", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To (data.Rows.Count - 1)
        '    id_pl_sample_order_del_det_drawer_list.Add(data.Rows(i)("id_pl_sample_order_del_det_drawer").ToString)
        'Next
        GCDrawer.DataSource = data
    End Sub

    Sub viewDetailBC()
        Dim query As String = "SELECT ('0') AS id_sample, ('') AS code, ('') AS no, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.DeleteSelectedRows()
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        GVItemList.OptionsCustomization.AllowGroup = True
        GridColumnQtyWH.Visible = False
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub deleteDetailBC(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVBarcode.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception

            End Try
            If id_sample = id_sample_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_sample_param As String)
        'delete detail
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            Dim id_sample As String = ""
            Try
                id_sample = GVDrawer.GetRowCellValue(i, "id_sample").ToString()
            Catch ex As Exception
            End Try
            If id_sample = id_sample_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub countQtyFromWh(ByVal id_sample_param As String)
        Dim jum As Decimal = 0.0
        Dim jum_amount As Decimal = 0.0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim id_sample_i As String = GVDrawer.GetRowCellValue(i, "id_sample").ToString
                If id_sample_i = id_sample_param Then
                    jum = jum + Decimal.Parse(GVDrawer.GetRowCellValue(i, "qty_all_sample"))
                    jum_amount = jum_amount + Decimal.Parse(GVDrawer.GetRowCellValue(i, "sample_amount_all"))
                End If
            Catch ex As Exception
            End Try
        Next
        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("pl_sample_order_del_det_qty_wh", jum)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        allowScanPage()
    End Sub

    Sub allowScanPage()
        'allow page scan
        Dim allow_scan = True
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                Dim qty_wh_cek As Decimal = Decimal.Parse(GVItemList.GetRowCellValue(i, "pl_sample_order_del_det_qty_wh"))
                If qty_wh_cek = 0.0 Then
                    allow_scan = False
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next

        If Not allow_scan Or (GVItemList.RowCount <= 0) Then
            XTPOutboundScanNew.PageEnabled = False
        Else
            XTPOutboundScanNew.PageEnabled = True
        End If
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        activeFilterDrawer()
    End Sub

    Sub activeFilterDrawer()
        Dim id_samplex As String = "-1"
        Try
            id_samplex = GVItemList.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception
        End Try
        GVDrawer.ActiveFilterString = "[id_sample]='" + id_samplex + "'"
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        'CEK BARCODE
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim id_sample As String = ""


        'check available code
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Dim code As String = GVItemList.GetRowCellValue(i, "code").ToString
            id_sample = GVItemList.GetRowCellValue(i, "id_sample").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found or duplicate!")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_sample", id_sample)
            countQty(id_sample)
            newRowsBc()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub countQty(ByVal id_sample_param As String)
        Dim tot As Decimal = 0.0
        Dim jum_amount_ret As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_sample As String = GVBarcode.GetRowCellValue(i, "id_sample").ToString
            If id_sample = id_sample_param Then
                tot = tot + 1.0
            End If
        Next

        GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sample", id_sample_param)
        GVItemList.SetFocusedRowCellValue("pl_sample_order_del_det_qty", tot)
        GVItemList.SetFocusedRowCellValue("pl_sample_order_del_det_amount_ret", tot * Decimal.Parse(GVItemList.GetFocusedRowCellValue("sample_ret_price").ToString))

        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub

    Sub startScan()
        
    End Sub

    Sub stopScan()
        
    End Sub

    Sub allowDelete()
       
    End Sub

    Sub infoSRS()
        FormSampleDelOrderInfo.LabelSubTitle.Text = "Sample Order No. : " + TxtSampleOrder.Text
        FormSampleDelOrderInfo.id_pl_sample_order_del = id_pl_sample_order_del
        FormSampleDelOrderInfo.id_sample_order = id_sample_order
        FormSampleDelOrderInfo.ShowDialog()
    End Sub

    Private Sub FormViewSampleDelOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "63"
        FormReportMark.id_report = id_pl_sample_order_del
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class