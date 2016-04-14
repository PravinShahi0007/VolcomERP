Public Class FormSalesInvoiceSingle 
    Public action_pop As String
    Public indeks_edit As Integer = 0
    Public id_sales_pos_det_edit As String = "-1"
    Public id_store_contact_to_param As String = "-1"
    Public start_period_param As String = "-1"
    Public end_period_param As String = "-1"
    Public id_so_type_param As String = "-1"
    Public id_sales_invoice_param As String = "0"

    Private Sub FormSalesInvoiceSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDetail()
        If action_pop = "upd" Then
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_sales_pos_det", id_sales_pos_det_edit)
            'GVProduct.ApplyFindFilter("")
            'GVProduct.ActiveFilterString = "[code] = '" + toDoubleQuote(product_code.ToString) + "' "
            ''GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product_edit.ToString)
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_sales_pos_available('" + id_store_contact_to_param + "','" + start_period_param + "', '" + end_period_param + "', '" + id_so_type_param + "', '" + id_sales_invoice_param + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesInvoiceSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Dim id_sales_pos_det As String = "0"
        Dim id_designx As String = "0"

        Try
            id_sales_pos_det = GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        pre_viewImages("2", PictureEdit1, id_designx, False)

        If id_sales_pos_det <= "0" Then
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
        If action_pop = "ins" Then
            'cek duplikat
            Dim is_duplicate As Boolean = False
            For i As Integer = 0 To (FormSalesInvoiceDet.GVItemList.RowCount - 1)
                Dim id_sales_pos_det_cek As String = 0
                Try
                    id_sales_pos_det_cek = FormSalesInvoiceDet.GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                Catch ex As Exception
                End Try

                If id_sales_pos_det_cek = GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString Then
                    is_duplicate = True
                    Exit For
                End If
            Next

            If is_duplicate Then
                errorCustom("This item already exist in List !")
            Else
                Dim newRow As DataRow = (TryCast(FormSalesInvoiceDet.GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_sales_invoice_det") = "0"
                newRow("sales_pos_number") = GVProduct.GetFocusedRowCellValue("sales_pos_number").ToString
                newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                newRow("color") = GVProduct.GetFocusedRowCellValue("color").ToString
                newRow("sales_invoice_det_qty") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("sales_invoice_det_qty").ToString)
                newRow("design_price_type") = GVProduct.GetFocusedRowCellValue("design_price_type").ToString
                newRow("id_design_price") = GVProduct.GetFocusedRowCellValue("id_design_price").ToString
                newRow("design_price_retail") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price_retail").ToString)
                newRow("id_design_price_retail") = GVProduct.GetFocusedRowCellValue("id_design_price_retail").ToString
                newRow("design_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString)
                newRow("sales_invoice_det_amount") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("sales_invoice_det_amount").ToString)
                newRow("id_sales_pos_det") = GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString
                newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                newRow("id_design") = GVProduct.GetFocusedRowCellValue("id_design").ToString
                TryCast(FormSalesInvoiceDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                FormSalesInvoiceDet.GCItemList.RefreshDataSource()
                FormSalesInvoiceDet.GVItemList.RefreshData()
                FormSalesInvoiceDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                FormSalesInvoiceDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_sales_pos_det", GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString)
                FormSalesInvoiceDet.getDiscount()
                FormSalesInvoiceDet.getNetto()
                FormSalesInvoiceDet.getVat()
                FormSalesInvoiceDet.getTaxBase()
                'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                Close()
            End If
        ElseIf action_pop = "upd" Then
            'cek duplikat
            Dim is_duplicate As Boolean = False
            For i As Integer = 0 To (FormSalesInvoiceDet.GVItemList.RowCount - 1)
                Dim id_sales_pos_det_cek As String = 0
                Try
                    id_sales_pos_det_cek = FormSalesInvoiceDet.GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                Catch ex As Exception
                End Try

                If id_sales_pos_det_cek = GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString And indeks_edit <> i Then
                    is_duplicate = True
                    Exit For
                End If
            Next

            If is_duplicate Then
                errorCustom("This item already exist in List !")
            Else
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("sales_pos_number", GVProduct.GetFocusedRowCellValue("sales_pos_number").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("color", GVProduct.GetFocusedRowCellValue("color").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("sales_invoice_det_qty", Decimal.Parse(GVProduct.GetFocusedRowCellValue("sales_invoice_det_qty").ToString))
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("id_design_price", GVProduct.GetFocusedRowCellValue("id_design_price").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("id_design_price", GVProduct.GetFocusedRowCellValue("id_design_price_retail").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("design_price_type", GVProduct.GetFocusedRowCellValue("design_price_type").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("design_price", Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString))
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("design_price_retail", Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price_retail").ToString))
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("sales_invoice_det_amount ", Decimal.Parse(GVProduct.GetFocusedRowCellValue("sales_invoice_det_amount").ToString))
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("id_design", GVProduct.GetFocusedRowCellValue("id_design").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                FormSalesInvoiceDet.GVItemList.SetFocusedRowCellValue("id_sales_pos_det ", GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString)
                FormSalesInvoiceDet.GCItemList.RefreshDataSource()
                FormSalesInvoiceDet.GVItemList.RefreshData()
                FormSalesInvoiceDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                FormSalesInvoiceDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_sales_pos_det", GVProduct.GetFocusedRowCellValue("id_sales_pos_det").ToString)
                FormSalesInvoiceDet.getDiscount()
                FormSalesInvoiceDet.getNetto()
                FormSalesInvoiceDet.getVat()
                FormSalesInvoiceDet.getTaxBase()
                'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                Close()
            End If
        End If
    End Sub
End Class