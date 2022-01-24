Public Class FormSalesPOSBrowseInvoice
    Private Sub FormSalesPOSBrowseInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSalesPOSBrowseInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        If GVInvoice.RowCount > 0 Then
            FormSalesPOSDet.id_sales_pos_ref = GVInvoice.GetFocusedRowCellValue("id_sales_pos").ToString
            FormSalesPOSDet.TxtInvoice.Text = GVInvoice.GetFocusedRowCellValue("sales_pos_number").ToString
            FormSalesPOSDet.SPDiscount.EditValue = GVInvoice.GetFocusedRowCellValue("sales_pos_discount").ToString
            FormSalesPOSDet.TxtPotPenjualan.EditValue = GVInvoice.GetFocusedRowCellValue("sales_pos_potongan")
            FormSalesPOSDet.TxtPotPenjualan.Enabled = False
            FormSalesPOSDet.SPVat.EditValue = GVInvoice.GetFocusedRowCellValue("sales_pos_vat").ToString
            FormSalesPOSDet.calculate()
            FormSalesPOSDet.viewDetail()
            FormSalesPOSDet.viewDetailCode()
            FormSalesPOSDet.BtnListProduct.Focus()

            Close()
        End If
    End Sub

    Private Sub ToolStripMenuItemViewDetail_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemViewDetail.Click
        Dim popup As ClassShowPopUp = New ClassShowPopUp

        popup.report_mark_type = GVInvoice.GetFocusedRowCellValue("report_mark_type").ToString
        popup.id_report = GVInvoice.GetFocusedRowCellValue("id_sales_pos").ToString

        popup.show()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view(TEProductCode.EditValue.ToString)
    End Sub

    Private Sub SBViewAll_Click(sender As Object, e As EventArgs) Handles SBViewAll.Click
        view("all")
    End Sub

    Sub view(product_code As String)
        Dim query_product As String = ""

        If Not product_code = "all" Then
            query_product = " AND p.product_full_code = '" + addSlashes(product_code) + "'"
        End If

        Dim query As String = "
            SELECT inv.id_sales_pos, inv.sales_pos_number, CONCAT(DATE_FORMAT(inv.sales_pos_start_period, '%d %M %Y'), ' - ', DATE_FORMAT(inv.sales_pos_end_period, '%d %M %Y')) AS sales_pos_period, SUM(ind.sales_pos_det_qty) AS sales_pos_det_qty, inv.sales_pos_discount, inv.sales_pos_vat, inv.sales_pos_total, (inv.sales_pos_total - (inv.sales_pos_total * (inv.sales_pos_discount / 100))) AS rev_before, ((100 / (100 + inv.sales_pos_vat)) * (SELECT rev_before)) AS rev_after, inv.report_mark_type,
            inv.sales_pos_potongan
            FROM tb_sales_pos_det ind
            INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
            INNER JOIN tb_lookup_memo_type AS mt ON inv.id_memo_type = mt.id_memo_type
            INNER JOIN tb_m_comp_contact AS cc ON inv.id_store_contact_from = cc.id_comp_contact
            INNER JOIN tb_m_product AS p ON ind.id_product = p.id_product
            WHERE mt.is_receive_payment = 1 AND inv.id_report_status = 6 AND cc.id_comp = " + FormSalesPOSDet.id_comp + " " + query_product + "
            GROUP BY inv.id_sales_pos
            ORDER BY inv.sales_pos_number DESC
        "

        GCInvoice.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVInvoice.BestFitColumns()
    End Sub
End Class