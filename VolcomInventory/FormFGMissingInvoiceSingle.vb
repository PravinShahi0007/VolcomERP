Public Class FormFGMissingInvoiceSingle 
    Public action_pop As String
    Public indeks_edit As Integer = 0
    Public id_fg_missing_det_edit As String = "-1"
    Public id_store_contact_to_param As String = "-1"
    Public start_period_param As String = "-1"
    Public end_period_param As String = "-1"
    Public id_fg_missing_invoice_param As String = "0"

    Private Sub FormFGMissingInvoiceSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDetail()
        If action_pop = "upd" Then
            GVProduct.FocusedRowHandle = find_row(GVProduct, "id_fg_missing_det", id_fg_missing_det_edit)
            'GVProduct.ApplyFindFilter("")
            'GVProduct.ActiveFilterString = "[code] = '" + toDoubleQuote(product_code.ToString) + "' "
            ''GVProduct.FocusedRowHandle = find_row(GVProduct, "id_product", id_product_edit.ToString)
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "CALL view_fg_missing_available('" + id_store_contact_to_param + "','" + start_period_param + "', '" + end_period_param + "', '" + id_fg_missing_invoice_param + "') "
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

    Private Sub FormFGMissingInvoiceSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        rowReuquirement()
        Cursor = Cursors.Default
    End Sub

    Sub rowReuquirement()
        Dim id_fg_missing_det As String = "0"
        Dim id_designx As String = "0"
        Try
            id_fg_missing_det = GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString
            id_designx = GVProduct.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        pre_viewImages("2", PictureEdit1, id_designx, False)

        If id_fg_missing_det <= "0" Then
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
            For i As Integer = 0 To (FormFGMissingInvoiceDet.GVItemList.RowCount - 1)
                Dim id_fg_missing_det_cek As String = 0
                Try
                    id_fg_missing_det_cek = FormFGMissingInvoiceDet.GVItemList.GetRowCellValue(i, "id_fg_missing_det").ToString
                Catch ex As Exception
                End Try

                If id_fg_missing_det_cek = GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString Then
                    is_duplicate = True
                    Exit For
                End If
            Next

            If is_duplicate Then
                errorCustom("This item already exist in List !")
            Else
                Dim newRow As DataRow = (TryCast(FormFGMissingInvoiceDet.GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_fg_missing_invoice_det") = "0"
                newRow("fg_missing_number") = GVProduct.GetFocusedRowCellValue("fg_missing_number").ToString
                newRow("name") = GVProduct.GetFocusedRowCellValue("name").ToString
                newRow("code") = GVProduct.GetFocusedRowCellValue("code").ToString
                newRow("size") = GVProduct.GetFocusedRowCellValue("size").ToString
                newRow("color") = GVProduct.GetFocusedRowCellValue("color").ToString
                newRow("fg_missing_invoice_det_qty") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("fg_missing_invoice_det_qty").ToString)
                newRow("design_price_type") = GVProduct.GetFocusedRowCellValue("design_price_type").ToString
                newRow("id_design_price") = GVProduct.GetFocusedRowCellValue("id_design_price").ToString
                newRow("design_price") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString)
                newRow("fg_missing_invoice_det_amount") = Decimal.Parse(GVProduct.GetFocusedRowCellValue("fg_missing_invoice_det_amount").ToString)
                newRow("id_fg_missing_det") = GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString
                newRow("id_product") = GVProduct.GetFocusedRowCellValue("id_product").ToString
                newRow("id_design") = GVProduct.GetFocusedRowCellValue("id_design").ToString
                TryCast(FormFGMissingInvoiceDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                FormFGMissingInvoiceDet.GCItemList.RefreshDataSource()
                FormFGMissingInvoiceDet.GVItemList.RefreshData()
                FormFGMissingInvoiceDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                FormFGMissingInvoiceDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_fg_missing_det", GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString)
                FormFGMissingInvoiceDet.getDiscount()
                FormFGMissingInvoiceDet.getNetto()
                FormFGMissingInvoiceDet.getVat()
                FormFGMissingInvoiceDet.getTaxBase()
                'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                Close()
            End If
        ElseIf action_pop = "upd" Then
            'cek duplikat
            Dim is_duplicate As Boolean = False
            For i As Integer = 0 To (FormFGMissingInvoiceDet.GVItemList.RowCount - 1)
                Dim id_fg_missing_det_cek As String = 0
                Try
                    id_fg_missing_det_cek = FormFGMissingInvoiceDet.GVItemList.GetRowCellValue(i, "id_fg_missing_det").ToString
                Catch ex As Exception
                End Try

                If id_fg_missing_det_cek = GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString And indeks_edit <> i Then
                    is_duplicate = True
                    Exit For
                End If
            Next

            If is_duplicate Then
                errorCustom("This item already exist in List !")
            Else
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("fg_missing_number", GVProduct.GetFocusedRowCellValue("fg_missing_number").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("name", GVProduct.GetFocusedRowCellValue("name").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("code", GVProduct.GetFocusedRowCellValue("code").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("size", GVProduct.GetFocusedRowCellValue("size").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("color", GVProduct.GetFocusedRowCellValue("color").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("fg_missing_invoice_det_qty", Decimal.Parse(GVProduct.GetFocusedRowCellValue("fg_missing_invoice_det_qty").ToString))
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("id_design_price", GVProduct.GetFocusedRowCellValue("id_design_price").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("design_price_type", GVProduct.GetFocusedRowCellValue("design_price_type").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("design_price", Decimal.Parse(GVProduct.GetFocusedRowCellValue("design_price").ToString))
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("fg_missing_invoice_det_amount ", Decimal.Parse(GVProduct.GetFocusedRowCellValue("fg_missing_invoice_det_amount").ToString))
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("id_design", GVProduct.GetFocusedRowCellValue("id_design").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("id_product", GVProduct.GetFocusedRowCellValue("id_product").ToString)
                FormFGMissingInvoiceDet.GVItemList.SetFocusedRowCellValue("id_fg_missing_det ", GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString)
                FormFGMissingInvoiceDet.GCItemList.RefreshDataSource()
                FormFGMissingInvoiceDet.GVItemList.RefreshData()
                FormFGMissingInvoiceDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                FormFGMissingInvoiceDet.GVItemList.FocusedRowHandle = find_row(FormSalesReturnOrderDet.GVItemList, "id_fg_missing_det", GVProduct.GetFocusedRowCellValue("id_fg_missing_det").ToString)
                FormFGMissingInvoiceDet.getDiscount()
                FormFGMissingInvoiceDet.getNetto()
                FormFGMissingInvoiceDet.getVat()
                FormFGMissingInvoiceDet.getTaxBase()
                'MsgBox("pop :" + GVProduct.GetFocusedRowCellValue("id_product").ToString)
                Close()
            End If
        End If
    End Sub
End Class