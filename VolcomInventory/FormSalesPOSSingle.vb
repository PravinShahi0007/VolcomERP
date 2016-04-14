Public Class FormSalesPOSSingle 
    Public action_pop As String
    Dim price As Decimal = 0.0
    Dim qty As Decimal = 0.0
    Public indeks_edit As Integer = 0
    Public id_product_edit As Integer
    Public id_return_cat_edit As Integer
    Public product_code As String
    Public qty_edit As Decimal
    Public remark_edit As String
    Public id_design_price_edit As Integer
    Public id_design_price_retail_edit As Integer
    Public id_comp As String = "-1"
    Public id_product As String = "-1"
    Dim view_zero As String = "2"
    Public id_sales_pos As String = "0"

    Public date_param As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"

    Private Sub FormSalesPOSSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()
        If action_pop = "upd" Then
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product_edit)
            SPQty.EditValue = qty_edit
        End If
    End Sub

    'VIEW
    Sub viewProduct()
        If action_pop = "ins" Then
            Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + date_param + "') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            If GVProduct.RowCount > 0 Then
                BtnChoose.Enabled = True
                GVProduct.OptionsBehavior.AutoExpandAllGroups = True
            Else
                BtnChoose.Enabled = False
            End If
        End If
    End Sub

    Sub viewRetailPrice(ByVal id_design_price_param As String, ByVal id_design_param As String)
        Dim query As String = "SELECT a.design_price, c.design_price_type, DATE_FORMAT(a.design_price_date, '%d %M %Y') AS design_price_date, a.design_price_name, a.id_currency, b.currency,a.id_design, "
        query += "a.id_design_price, IF(a.is_print='1', 'Yes', 'No') AS is_print "
        query += "FROM tb_m_design_price a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency  "
        query += "INNER JOIN tb_lookup_design_price_type c ON c.id_design_price_type = a.id_design_price_type "
        query += "WHERE a.id_design = '" + id_design_param + "' "
        query += "ORDER BY a.design_price_start_date DESC "
        viewSearchLookupQuery(SLEPrice, query, "id_design_price", "design_price", "id_design_price")
        SLEPrice.EditValue = id_design_price_param
    End Sub

    Sub getAmount()
        price = 0.0
        qty = 0.0

        'get price
        Try
            ' price = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString)
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
        Dim id_design_price_retailx As String = "0"
        Dim currency As String = ""
        Dim design_pricex As Decimal = 0

        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
            id_productx = GVProduct.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
            currency = GVProduct.GetFocusedRowCellValue("currency").ToString
            design_pricex = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString)
            id_design_price_retailx = GVProduct.GetFocusedRowCellValue("id_design_price_retail").ToString
        Catch ex As Exception
        End Try

        'images
        pre_viewImages("2", PictureEdit1, id_designx, False)
        viewRetailPrice(id_design_price_retailx, id_designx)

        'set currency
        TxtCurrencyPrice.Text = currency
        TxtCurrencyAmount.Text = currency
        TxtPrice.EditValue = design_pricex
        getAmount()

        'active/non choose
        If id_productx = "0" Then
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

    Private Sub SPQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQty.EditValueChanged
        getAmount()
    End Sub

    Private Sub FormSalesPOSSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Dim qty_input As Decimal = Decimal.Parse(SPQty.EditValue.ToString)
        If qty_input > 0 Then
            If action_pop = "ins" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesPOSDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Dim id_price_cek As String = 0
                    Dim design_price As Decimal = 0.0
                    Try
                        id_product_cek = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_price_cek = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        design_price = Decimal.Parse(FormSalesPOSDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception
                    End Try

                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_price_cek = GVProduct.GetFocusedRowCellValue("id_design_price").ToString And design_price = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString) Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                'cek qty
                Dim is_higher As Boolean = False
                Dim qty_limit As Decimal = 0.0
                Try
                    qty_limit = Decimal.Parse(GVProduct.GetFocusedRowCellValue("qty_all_product").ToString)
                    If qty_input > qty_limit Then
                        is_higher = True
                    End If
                Catch ex As Exception
                End Try

                If is_duplicate Then
                    errorCustom("This product already exist in Item List !")
                ElseIf is_higher Then
                    errorCustom("Qty cannot exceed  " + qty_limit.ToString + " !")
                Else
                    Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_pos_det") = "0"
                    newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                    newRow("product_name") = GVProduct.GetFocusedRowCellValue("name").ToString
                    newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                    newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                    newRow("color") = GVProduct.GetFocusedRowCellValue("color").ToString
                    newRow("sales_pos_det_qty") = SPQty.EditValue
                    newRow("id_design_price") = GVProduct.GetFocusedRowCellValue("id_design_price").ToString
                    newRow("design_price_type") = GVProduct.GetFocusedRowCellValue("design_price_type").ToString
                    newRow("design_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString)
                    newRow("id_design_price_retail") = SLEPrice.EditValue.ToString
                    newRow("design_price_retail") = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
                    newRow("sales_pos_det_amount") = Decimal.Parse(TxtAmount.EditValue.ToString)
                    newRow("id_design") = GVProduct.GetFocusedRowCellValue("id_design").ToString
                    newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                    newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample").ToString
                    TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesPOSDet.GCItemList.RefreshDataSource()
                    FormSalesPOSDet.GVItemList.RefreshData()
                    'FormSalesPOSDet.sayCurr()
                    FormSalesPOSDet.getDiscount()
                    FormSalesPOSDet.getNetto()
                    FormSalesPOSDet.getVat()
                    FormSalesPOSDet.getTaxBase()
                    FormSalesPOSDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    'FormSalesPOSDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            ElseIf action_pop = "upd" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesPOSDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Dim id_price_cek As String = 0
                    Dim design_price As Decimal = 0.0
                    Try
                        id_product_cek = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_price_cek = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        design_price = Decimal.Parse(FormSalesPOSDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_price_cek = GVProduct.GetFocusedRowCellValue("id_design_price").ToString And design_price = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString) And i <> indeks_edit Then
                        is_duplicate = True
                        Exit For
                    End If
                Next

                'cek qty
                Dim is_higher As Boolean = False
                Dim qty_limit As Decimal = 0.0
                Try
                    qty_limit = Decimal.Parse(GVProduct.GetFocusedRowCellValue("qty_all_product").ToString)
                    If qty_input > qty_limit Then
                        is_higher = True
                    End If
                Catch ex As Exception
                End Try

                If is_duplicate Then
                    errorCustom("This product already exist in Item List !")
                ElseIf is_higher Then
                    errorCustom("Qty cannot exceed  " + qty_limit.ToString + " !")
                Else
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("product_name", GVProduct.GetFocusedRowCellValue("product_name").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("color", GVProduct.GetFocusedRowCellValue("color").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("sales_pos_det_qty", SPQty.EditValue)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("id_design_price", GVProduct.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("design_price_type", GVProduct.GetFocusedRowCellValue("design_price_type").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("design_price", Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString))
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("id_design_price_retail", SLEPrice.EditValue.ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("design_price_retail", Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString))
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("sales_pos_det_amount", Decimal.Parse(TxtAmount.EditValue.ToString))
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("id_design", GVProduct.GetFocusedRowCellValue("id_design").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                    FormSalesPOSDet.GCItemList.RefreshDataSource()
                    FormSalesPOSDet.GVItemList.RefreshData()
                    'FormSalesPOSDet.sayCurr()
                    FormSalesPOSDet.getDiscount()
                    FormSalesPOSDet.getNetto()
                    FormSalesPOSDet.getVat()
                    FormSalesPOSDet.getTaxBase()
                    FormSalesPOSDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            End If
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CheckFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckFilter.CheckedChanged
        If CheckFilter.EditValue.ToString = "True" Then
            view_zero = "1"
        Else
            view_zero = "2"
        End If
        viewProduct()
    End Sub

    Private Sub SLEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEPrice.EditValueChanged
        getAmount()
    End Sub
End Class