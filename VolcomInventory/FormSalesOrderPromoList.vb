Public Class FormSalesOrderPromoList
    Public id_ol_promo As String = "-1"
    Public data_par As DataTable
    Public data_stock As DataTable

    Private Sub FormSalesOrderPromoList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVProduct)
        Dim query As String = "SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
        prod.id_design, prod.id_product, d.design_code,prod.product_full_code AS `code`, d.design_display_name AS `name`, 
        cd.code_detail_name AS `size`, pd.id_prod_shopify, pd.current_tag, pd.id_design_price,pd.design_price, design_price_type AS `price_type`, pd.qty,
        pd.is_block, IF(pd.is_block=1,'Not Active', 'Active') AS `is_block_view`, 0.00 AS order_qty, dcd.class, dcd.color, dcd.sht
        FROM tb_ol_promo_collection_sku pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        LEFT JOIN (
		    SELECT dc.id_design, 
		    MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		    MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		    MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		    MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		    MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		    FROM tb_m_design_code dc
		    INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		    AND cd.id_code IN (32,30,14, 43)
		    GROUP BY dc.id_design
	    ) dcd ON dcd.id_design = d.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
        WHERE pd.id_ol_promo_collection=" + id_ol_promo + " AND pd.is_block=2
        ORDER BY d.design_display_name ASC, prod.product_full_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data_par.Rows.Count = 0 Then
            GCProduct.DataSource = data
            GVProduct.BestFitColumns()
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_par.AsEnumerable()
            Dim except As DataTable = (From _t1 In t1
                                       Group Join _t2 In t2
                                       On _t1("id_product") Equals _t2("id_product") Into Group
                                       From _t3 In Group.DefaultIfEmpty()
                                       Where _t3 Is Nothing
                                       Select _t1).CopyToDataTable
            Try
                GCProduct.DataSource = except
                GVProduct.BestFitColumns()
            Catch ex As Exception
                GCProduct.DataSource = Nothing
                GVProduct.BestFitColumns()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormSalesOrderPromoList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVProduct)
        GVProduct.ActiveFilterString = "[order_qty]>0"
        If GVProduct.RowCount > 0 Then
            For i As Integer = 0 To GVProduct.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_sales_order_det") = "0"
                newRow("id_ol_promo_collection_sku_replace") = GVProduct.GetRowCellValue(i, "id_ol_promo_collection_sku").ToString
                newRow("name") = GVProduct.GetRowCellValue(i, "name").ToString
                newRow("code") = GVProduct.GetRowCellValue(i, "code").ToString
                newRow("size") = GVProduct.GetRowCellValue(i, "size").ToString
                newRow("class") = GVProduct.GetRowCellValue(i, "class").ToString
                newRow("color") = GVProduct.GetRowCellValue(i, "color").ToString
                newRow("sht") = GVProduct.GetRowCellValue(i, "sht").ToString
                newRow("sales_order_det_qty") = GVProduct.GetRowCellValue(i, "order_qty")
                newRow("id_design_price") = GVProduct.GetRowCellValue(i, "id_design_price").ToString
                newRow("design_price") = GVProduct.GetRowCellValue(i, "design_price")
                newRow("design_price_type") = GVProduct.GetRowCellValue(i, "price_type").ToString
                newRow("amount") = GVProduct.GetRowCellValue(i, "order_qty") * GVProduct.GetRowCellValue(i, "design_price")
                newRow("qty_avail") = 0
                newRow("sales_order_det_note") = ""
                newRow("id_design") = GVProduct.GetRowCellValue(i, "id_design").ToString
                newRow("id_product") = GVProduct.GetRowCellValue(i, "id_product").ToString
                newRow("id_sample") = "0"
                newRow("is_found") = "1"
                newRow("error_status") = ""
                TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                'CType(GCItemList.DataSource, DataTable).AcceptChanges()
                FormSalesOrderDet.GCItemList.RefreshDataSource()
                FormSalesOrderDet.GVItemList.RefreshData()
            Next
            FormSalesOrderDet.BtnImportExcel.Visible = False
            GVProduct.ActiveFilterString = ""
            actionLoad()
        Else
            warningCustom("Please input qty")
            GVProduct.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVProduct_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVProduct.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As String = e.RowHandle.ToString
        Dim old_val As Decimal = GVProduct.ActiveEditor.OldEditValue
        If e.Column.FieldName.ToString.Contains("order_qty") Then
            Dim id_product As String = GVProduct.GetRowCellValue(rh, "id_product").ToString
            Dim dt_filter As DataRow() = data_stock.Select("[id_product]='" + id_product + "'")
            Dim avail_qty As Integer = 0
            If dt_filter.Length > 0 Then
                avail_qty = dt_filter(0)("total_allow")
            Else
                avail_qty = 0
            End If
            If e.Value > avail_qty Then
                stopCustom("Can't exceed " + avail_qty.ToString)
                GVProduct.SetRowCellValue(rh, "order_qty", old_val)
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class