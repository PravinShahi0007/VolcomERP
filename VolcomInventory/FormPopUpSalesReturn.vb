Public Class FormPopUpSalesReturn 
    Public id_pop_up As String = "-1"
    Public id_sales_return As String = "-1"
    Public id_sales_return_det As String = "-1"
    Public indeks_edit As Integer = 0

    Private Sub FormPopUpSalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesReturn()
        If id_sales_return <> "-1" Then
            GVSalesReturn.FocusedRowHandle = find_row(GVSalesReturn, "id_sales_return", id_sales_return)
        End If
        If id_sales_return_det <> "-1" Then
            GVItemList.FocusedRowHandle = find_row(GVItemList, "id_sales_return_det", id_sales_return_det)
        End If
    End Sub

    Sub viewSalesReturn()
        Dim query As String = ""
        query += "SELECT a.id_sales_return, a.id_store_contact_from, a.id_comp_contact_to,(d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_note, a.sales_return_number, "
        query += "DATE_FORMAT(a.sales_return_date,'%d %M %Y') AS sales_return_date "
        query += "FROM tb_sales_return a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN "
        query += "( "
        query += "SELECT a.id_sales_return,  a.id_sales_return_det, "
        query += "(a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) AS jum "
        query += "FROM tb_sales_return_det a "
        query += "INNER JOIN tb_sales_return b ON b.id_sales_return = a.id_sales_return "
        query += "LEFT JOIN ( "
        query += "SELECT b1.id_sales_return_det, SUM(b1.sales_return_qc_det_qty) AS jum_ret FROM tb_sales_return_qc_det b1 "
        query += "INNER JOIN tb_sales_return_qc b2 ON b1.id_sales_return_qc = b2.id_sales_return_qc "
        query += "WHERE b2.id_report_status != '5' "
        query += "GROUP BY b1.id_sales_return_det "
        query += ")ret ON ret.id_sales_return_det = a.id_sales_return_det  "
        query += "WHERE b.id_report_status = '6' AND (a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) >'0' "
        query += "GROUP BY a.id_sales_return "
        query += ") g ON g.id_sales_return = a.id_sales_return "
        query += "WHERE a.id_report_status = '6' "
        If id_sales_return <> "-1" Then
            query += "AND a.id_sales_return_order = '" + id_sales_return + "' "
        End If
        query += "ORDER BY a.id_sales_return ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BSave.Visible = True
        Else
            BSave.Visible = False
        End If
    End Sub

    Sub viewListSalesReturnDet(ByVal id_sales_return As String)
        Dim query As String = "CALL view_sales_return('" + id_sales_return + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub FormPopUpSalesReturn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    '1 : delivery order
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            'Return 
            FormSalesReturnQCDet.id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
            FormSalesReturnQCDet.TxtSalesReturnNumber.Text = GVSalesReturn.GetFocusedRowCellValue("sales_return_number").ToString

            'store data
            Dim query_comp_from As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + GVSalesReturn.GetFocusedRowCellValue("id_store_contact_from").ToString + "'"
            Dim id_comp_from As String = execute_query(query_comp_from, 0, True, "", "", "", "")
            FormSalesReturnQCDet.id_store = id_comp_from
            FormSalesReturnQCDet.id_store_contact_from = GVSalesReturn.GetFocusedRowCellValue("id_store_contact_from").ToString
            FormSalesReturnQCDet.TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
            FormSalesReturnQCDet.TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
            FormSalesReturnQCDet.MEAdrressCompFrom.Text = get_company_x(id_comp_from, 3)

            Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + GVSalesReturn.GetFocusedRowCellValue("id_comp_contact_to").ToString + "'"
            Dim id_comp_to As String = execute_query(query_comp_to, 0, True, "", "", "", "")
            FormSalesReturnQCDet.id_comp_contact_to_return = GVSalesReturn.GetFocusedRowCellValue("id_comp_contact_to").ToString
            FormSalesReturnQCDet.TxtCodeFrom.Text = get_company_x(id_comp_to, 2)
            FormSalesReturnQCDet.TxtNameFrom.Text = get_company_x(id_comp_to, 1)


            'general
            FormSalesReturnQCDet.viewDetail()
            FormSalesReturnQCDet.viewDetailDrawer()
            FormSalesReturnQCDet.viewDetailDrawer2()
            FormSalesReturnQCDet.view_barcode_list()
            FormSalesReturnQCDet.GroupControlListItem.Enabled = True
            FormSalesReturnQCDet.GroupControlScannedItem.Enabled = True
            FormSalesReturnQCDet.BtnInfoSrs.Enabled = True
            FormSalesReturnQCDet.BtnBrowseRO.Enabled = False
            'FormSalesReturnQCDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            Close()
        ElseIf id_pop_up = "2" Then
            'Dim amount As Decimal = 0.0
            'If id_sales_return_order_det = "-1" Then 'new
            '    'cek duplikat
            '    Dim is_duplicate As Boolean = False
            '    For i As Integer = 0 To (FormSalesReturnDet.GVItemList.RowCount - 1)
            '        Dim id_product_cek As String = "0"
            '        Dim id_design_price_cek As String = "0"
            '        Dim design_price_cek As Decimal = 0.0
            '        Try
            '            id_product_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_product").ToString
            '            id_design_price_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
            '            design_price_cek = Decimal.Parse(FormSalesReturnDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
            '        Catch ex As Exception
            '        End Try
            '        If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString And id_design_price_cek = GVItemList.GetFocusedRowCellValue("id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString) Then
            '            'MsgBox(id_product_cek)
            '            'MsgBox(GVItemList.GetFocusedRowCellValue("id_product").ToString)
            '            is_duplicate = True
            '            Exit For
            '        End If
            '    Next

            '    If is_duplicate Then
            '        errorCustom("This product already exist in Delivery Item List !")
            '    Else
            '        Dim newRow As DataRow = (TryCast(FormSalesReturnDet.GCItemList.DataSource, DataTable)).NewRow()
            '        newRow("id_sales_return_det") = "0"
            '        newRow("id_sales_return_order_det") = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
            '        newRow("name") = GVItemList.GetFocusedRowCellValue("name").ToString
            '        newRow("code") = GVItemList.GetFocusedRowCellValue("code").ToString
            '        newRow("size") = GVItemList.GetFocusedRowCellValue("size").ToString
            '        newRow("sales_return_det_qty") = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
            '        newRow("qty_from_wh") = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
            '        newRow("id_design_price") = GVItemList.GetFocusedRowCellValue("id_design_price").ToString
            '        newRow("design_price") = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price"))
            '        newRow("sales_return_det_amount") = Decimal.Parse(amount.ToString)
            '        newRow("sales_return_order_det_note") = GVItemList.GetFocusedRowCellValue("sales_return_order_det_note").ToString
            '        newRow("id_design") = GVItemList.GetFocusedRowCellValue("id_design").ToString
            '        newRow("id_product") = GVItemList.GetFocusedRowCellValue("id_product").ToString
            '        newRow("id_sample") = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            '        newRow("design_price_type") = GVItemList.GetFocusedRowCellValue("design_price_type").ToString
            '        TryCast(FormSalesReturnDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
            '        FormSalesReturnDet.GCItemList.RefreshDataSource()
            '        FormSalesReturnDet.GVItemList.RefreshData()
            '        FormSalesReturnDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            '        FormSalesReturnDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnDet.GVItemList, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
            '        FormSalesReturnDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString, FormSalesReturnDet.id_store, GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
            '        FormSalesReturnDet.check_but()
            '        Close()
            '    End If
            'Else 'edit
            '    Dim is_duplicate As Boolean = False
            '    For i As Integer = 0 To (FormSalesReturnDet.GVItemList.RowCount - 1)
            '        Dim id_product_cek As String = 0
            '        Dim id_design_price_cek As String = "0"
            '        Dim design_price_cek As Decimal = 0.0
            '        Try
            '            id_product_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_product").ToString
            '            id_design_price_cek = FormSalesReturnDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
            '            design_price_cek = Decimal.Parse(FormSalesReturnDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
            '        Catch ex As Exception

            '        End Try
            '        If id_product_cek = GVItemList.GetFocusedRowCellValue("id_product").ToString And id_design_price_cek = GVItemList.GetFocusedRowCellValue("id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString) And i <> indeks_edit Then
            '            is_duplicate = True
            '            Exit For
            '        End If
            '    Next

            '    If is_duplicate Then
            '        errorCustom("This product already exist in Delivery Item List !")
            '    Else
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sales_return_det", "0")
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sales_return_order_det", GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "name", GVItemList.GetFocusedRowCellValue("name").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "code", GVItemList.GetFocusedRowCellValue("code").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "size", GVItemList.GetFocusedRowCellValue("size").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_det_qty", GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "qty_from_wh", GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_design_price", GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "design_price", Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price")))
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_det_amount", amount.ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "sales_return_order_det_note", GVItemList.GetFocusedRowCellValue("sales_return_order_det_note").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_design", GVItemList.GetFocusedRowCellValue("id_design").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_product", GVItemList.GetFocusedRowCellValue("id_product").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "id_sample", GVItemList.GetFocusedRowCellValue("id_sample").ToString)
            '        FormSalesReturnDet.GVItemList.SetRowCellValue(FormSalesReturnDet.GVItemList.FocusedRowHandle, "design_price_type", GVItemList.GetFocusedRowCellValue("design_price_type").ToString)
            '        FormSalesReturnDet.GCItemList.RefreshDataSource()
            '        FormSalesReturnDet.GVItemList.RefreshData()
            '        FormSalesReturnDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            '        FormSalesReturnDet.codeAvailableDel(GVItemList.GetFocusedRowCellValue("id_product").ToString)
            '        FormSalesReturnDet.codeAvailableIns(GVItemList.GetFocusedRowCellValue("id_product").ToString, FormSalesReturnDet.id_store, GVItemList.GetFocusedRowCellValue("id_design_price").ToString)
            '        FormSalesReturnDet.check_but()
            '        Close()
            '    End If
            'End If
            ''FormSalesReturnDet.allowScanPage()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
        Dim id_sales_return As String = "0"
        Try
            id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
        Catch ex As Exception
        End Try
        If id_sales_return <> "0" Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        viewListSalesReturnDet(id_sales_return)
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        If id_sales_return <> "-1" Then
            Dim id_sales_return_det As String = "0"
            Try
                id_sales_return_det = GVItemList.GetFocusedRowCellValue("id_sales_return_det").ToString
            Catch ex As Exception

            End Try

            If id_sales_return_det = "0" Then
                BSave.Enabled = False
            Else
                BSave.Enabled = True
            End If
        End If
    End Sub
End Class