Public Class FormSalesReturnOrderSingle 
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
    Public id_comp As String = "-1"
    Public id_product As String = "-1"

    Public date_param As String = "-"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"

    Private Sub FormSalesReturnOrderSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProduct()
        viewReturnCat()
    End Sub

    'VIEW
    Sub viewProduct()
        Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + date_param + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
            GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Sub viewRetailPrice(ByVal id_designx As String, ByVal id_design_price_retailx As String)

    End Sub

    Sub viewReturnCat()
        Dim query As String = "SELECT a.id_return_cat, a.return_cat FROM tb_lookup_return_cat a ORDER BY a.id_return_cat "
        viewSearchLookupQuery(SLEReturnCat, query, "id_return_cat", "return_cat", "id_return_cat")
    End Sub

    Sub getAmount()
        price = 0.0
        qty = 0.0

        'get price
        Try
            'price = Decimal.Parse(SLEPrice.Properties.GetDisplayValueByKeyValue(SLEPrice.EditValue).ToString)
            price = Decimal.Parse(TxtPrice.EditValue)
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
        Dim id_productx As String = "0"
        Dim id_samplex As String = "0"
        Dim id_designx As String = "0"
        Dim id_design_price_retailx As String = "0"
        Dim id_design_pricex As String = "0"
        Dim price As Decimal = 0.0

        Try
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
            id_design_price_retailx = GVProduct.GetFocusedRowCellValue("id_design_price_retail").ToString
            id_productx = GVProduct.GetFocusedRowCellValue("id_product").ToString
            id_samplex = GVProduct.GetFocusedRowCellValue("id_sample").ToString
            price = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price_retail").ToString)
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)
        ' viewRetailPrice(id_designx, id_design_price_retailx)


        'pass design price into TxtPrice
        TxtPrice.EditValue = price
        getAmount()

        'active/non choose
        If id_productx = "0" Or id_design_price_retailx = "0" Then
            BtnChoose.Enabled = False
        Else
            BtnChoose.Enabled = True
        End If
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
                For i As Integer = 0 To (FormSalesReturnOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = 0
                    Dim id_price_cek As String = 0
                    Dim price_cek As Decimal = 0.0
                    Try
                        id_product_cek = FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_price_cek = FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        price_cek = Decimal.Parse(FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception
                    End Try
                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString Then
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
                    Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_return_order_det") = "0"
                    newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                    newRow("product_name") = GVProduct.GetFocusedRowCellValue("name").ToString
                    newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                    newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                    newRow("sales_return_order_det_qty") = SPQty.EditValue
                    newRow("design_price_type") = GVProduct.GetFocusedRowCellValue("design_price_type").ToString
                    newRow("id_design_price") = GVProduct.GetFocusedRowCellValue("id_design_price_retail").ToString
                    newRow("design_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price_retail").ToString)
                    newRow("id_return_cat") = SLEReturnCat.EditValue.ToString
                    newRow("return_cat") = SLEReturnCat.Properties.GetDisplayValueByKeyValue(SLEReturnCat.EditValue).ToString
                    newRow("amount") = Decimal.Parse(TxtAmount.EditValue.ToString)
                    newRow("sales_return_order_det_note") = MENote.Text.ToString
                    newRow("id_design") = GVProduct.GetFocusedRowCellValue("id_design").ToString
                    newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                    newRow("id_sample") = GVProduct.GetFocusedRowCellValue("id_sample").ToString
                    TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                    FormSalesReturnOrderDet.GVItemList.RefreshData()
                    FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesReturnOrderDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesReturnOrderDet.check_but()
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            ElseIf action_pop = "upd" Then
                'cek duplikat
                Dim is_duplicate As Boolean = False
                For i As Integer = 0 To (FormSalesReturnOrderDet.GVItemList.RowCount - 1)
                    Dim id_product_cek As String = "0"
                    Dim id_price_cek As String = "0"
                    Dim price_cek As Decimal = 0.0

                    Try
                        id_product_cek = FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                        id_price_cek = FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        price_cek = Decimal.Parse(FormSalesReturnOrderDet.GVItemList.GetRowCellValue(i, "design_price").ToString)
                    Catch ex As Exception

                    End Try
                    If id_product_cek = GVProduct.GetFocusedRowCellValue("id_product").ToString And id_price_cek = GVProduct.GetFocusedRowCellValue("id_design_price").ToString And price_cek = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString) And i <> indeks_edit Then
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
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("product_name", GVProduct.GetFocusedRowCellValue("product_name").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("sales_return_order_det_qty", SPQty.EditValue)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("id_design_price", GVProduct.GetFocusedRowCellValue("id_design_price").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("design_price_type", GVProduct.GetFocusedRowCellValue("design_price_type").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("design_price", Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString))
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("id_return_cat", SLEReturnCat.EditValue.ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("return_cat", SLEReturnCat.Properties.GetDisplayValueByKeyValue(SLEReturnCat.EditValue).ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("amount", Decimal.Parse(TxtAmount.EditValue.ToString))
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("sales_return_order_det_note", MENote.Text.ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("id_design", GVProduct.GetFocusedRowCellValue("id_design").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    FormSalesReturnOrderDet.GVItemList.SetFocusedRowCellValue("id_sample", GVProduct.GetFocusedRowCellValue("id_sample").ToString)
                    FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                    FormSalesReturnOrderDet.GVItemList.RefreshData()
                    FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                    FormSalesReturnOrderDet.check_but()
                    'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                    Close()
                End If
            End If
        Else
            errorCustom("Qty not allowed zero value ! ")
        End If
    End Sub



    Private Sub SPQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQty.EditValueChanged
        getAmount()
    End Sub

    Private Sub FormSalesReturnOrderSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class