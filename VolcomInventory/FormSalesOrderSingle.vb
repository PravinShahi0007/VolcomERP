Public Class FormSalesOrderSingle 
    Public action_pop As String
    Dim price As Decimal = 0.0
    Dim qty As Decimal = 0.0
    Public indeks_edit As Integer = 0
    Public id_product_edit As Integer
    Public product_code As String
    Public qty_edit As Decimal
    Public remark_edit As String
    Public id_design_price_edit As Integer

    Private Sub FormSalesOrderSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()
        If action_pop = "upd" Then
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product_edit)
            SLEPrice.EditValue = id_design_price_edit
            SPQty.EditValue = qty_edit
            MENote.Text = remark_edit
            GVProduct.ApplyFindFilter("")
            GVProduct.ActiveFilterString = "[product_full_code] = '" + toDoubleQuote(product_code.ToString) + "' "
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product_edit.ToString)
        End If
    End Sub

    'VIEW
    Sub viewProduct()
        Dim query As String = "CALL view_product_so()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
    End Sub

    Sub viewRetailPrice(ByVal id_designx As String)
        Dim query As String = "SELECT a.design_price, c.design_price_type, DATE_FORMAT(a.design_price_date, '%d %M %Y') AS design_price_date, a.design_price_name, a.id_currency, b.currency,a.id_design, "
        query += "a.id_design_price, IF(a.is_print='1', 'Yes', 'No') AS is_print "
        query += "FROM tb_m_design_price a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency  "
        query += "INNER JOIN tb_lookup_design_price_type c ON c.id_design_price_type = a.id_design_price_type "
        query += "WHERE a.id_design = '" + id_designx + "' "
        query += "ORDER BY a.is_print "
        viewSearchLookupQuery(SLEPrice, query, "id_design_price", "design_price", "id_design_price")
    End Sub

    Sub viewWH(ByVal id_product As String)
        Dim query As String = ""
        query += "SELECT (e.comp_name) AS wh, a.id_product, "
        query += "SUM(IF(a.id_storage_category='2', CONCAT('-', a.storage_product_qty), a.storage_product_qty)) AS qty_all_product, "
        query += "SUM(IF(a.id_stock_status='1', (IF(a.id_storage_category='2', CONCAT('-', a.storage_product_qty), a.storage_product_qty)),'0')) AS qty_normal, "
        query += "SUM(IF(a.id_stock_status='2', (IF(a.id_storage_category='1', CONCAT('-', a.storage_product_qty), a.storage_product_qty)),'0')) AS qty_reserved "
        query += "FROM tb_storage_fg a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON c.id_wh_rack = b.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON d.id_wh_locator = c.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "WHERE a.id_product ='" + id_product + "' "
        query += "GROUP BY e.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCWH.DataSource = data
    End Sub

    Sub getAmount()
        price = 0.0
        qty = 0.0

        'get price
        Try
            price = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
        Catch ex As Exception

        End Try

        'get qty
        Try
            qty = Decimal.Parse(SPQty.EditValue.ToString)
        Catch ex As Exception

        End Try

        Dim amount As Decimal = price * qty
        TxtAmount.EditValue = amount
    End Sub
    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_productx As String = "0"
        Dim id_samplex As String = "0"
        Dim id_designx As String = "0"
        Dim id_design_pricex As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
            id_productx = GVProduct.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)
        viewRetailPrice(id_designx)

        'get id_price 
        Try
            id_design_pricex = SLEPrice.EditValue.ToString
        Catch ex As Exception

        End Try

        'show wh detail
        viewWH(id_productx)

        'active/non choose
        If id_productx = "0" Or id_design_pricex = "0" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        Dim id_designx As String = "0"
        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception

        End Try
        pre_viewImages("2", PictureEdit1, id_designx, True)
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input As Decimal = Decimal.Parse(SPQty.EditValue.ToString)
        If qty_input > 0 Then
            If action_pop = "ins" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Try
                        id_product_cek = FormSalesOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Item List !")
                Else
                    Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_order_det") = "0"
                    newRow("name") = GVProduct.GetFocusedRowCellValue("design_name").ToString
                    newRow("code") = GVProduct.GetFocusedRowCellValue("product_full_code").ToString
                    newRow("size") = GVProduct.GetFocusedRowCellValue("Size").ToString
                    newRow("sales_order_det_qty") = SPQty.EditValue
                    newRow("id_design_price") = SLEPrice.EditValue.ToString
                    newRow("design_price") = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
                    newRow("amount") = Decimal.Parse(TxtAmount.EditValue.ToString)
                    newRow("sales_order_det_note") = MENote.Text.ToString
                    newRow("id_design") = GVProduct.GetFocusedRowCellValue("id_design").ToString
                    newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                    newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample").ToString
                    TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesOrderDet.GCItemList.RefreshDataSource()
                    FormSalesOrderDet.GVItemList.RefreshData()
                    FormSalesOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesOrderDet.GVItemList.FocusedRowHandle = find_row(FormSalesOrderDet.GVItemList, "id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            ElseIf action_pop = "upd" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Try
                        id_product_cek = FormSalesOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString And i <> indeks_edit Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                If is_duplicate Then
                    errorCustom("This product already exist in Item List !")
                Else
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("design_name").ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("product_full_code").ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("Size").ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("sales_order_det_qty", SPQty.EditValue)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("id_design_price", SLEPrice.EditValue.ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("design_price", Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString))
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("amount", Decimal.Parse(TxtAmount.EditValue.ToString))
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("sales_order_det_note", MENote.Text.ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("id_design", GVProduct.GetFocusedRowCellValue("id_design").ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                    FormSalesOrderDet.GCItemList.RefreshDataSource()
                    FormSalesOrderDet.GVItemList.RefreshData()
                    FormSalesOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            End If
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub

    Private Sub SLEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEPrice.EditValueChanged
        If SLEPrice.EditValue = Nothing Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
        getAmount()
    End Sub

    Private Sub SPQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQty.EditValueChanged
        getAmount()
    End Sub

    Private Sub FormSalesOrderSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class