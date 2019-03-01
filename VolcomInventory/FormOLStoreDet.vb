Public Class FormOLStoreDet
    Private Sub BtnBrowseFile_Click(sender As Object, e As EventArgs) Handles BtnBrowseFile.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "41"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT so.id_sales_order, sod.id_sales_order_det, 
        so.id_warehouse_contact_to, '0' AS `id_wh_drawer`, '' AS `comp`,
        so.id_store_contact_to,  '' AS `store`,
        so.sales_order_number,so.sales_order_ol_shop_number, so.sales_order_date, so.sales_order_ol_shop_date,
        '' AS `code`, '' AS `name`, '' AS `item_id`, '' AS `ol_store_id`, sod.sales_order_det_qty, sod.id_design_price, sod.design_price, 
        so.customer_name, so.shipping_name, so.shipping_address, so.shipping_phone, so.shipping_city, 
        so.shipping_post_code, so.shipping_region, so.payment_method, so.tracking_code, 0 AS `no`, '' AS `status`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        WHERE so.id_sales_order=0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
    End Sub

    Sub viewCompGroup()
        Dim query As String = "SELECT g.id_comp_group, g.description
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
        WHERE c.id_commerce_type=2 AND c.is_active=1
        GROUP BY c.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
    End Sub

    Private Sub FormOLStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        makeSafeGV(GVDetail)
        makeSafeGV(GVProduct)

        'checkstock harus di grup
        Cursor = Cursors.WaitCursor
        Dim cond_stock As Boolean = True
        For i As Integer = 0 To GVProduct.RowCount - 1
            Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
            Dim id_wh_drawer As String = GVProduct.GetRowCellValue(i, "id_wh_drawer").ToString
            Dim query As String = "SELECT f.id_wh_drawer, f.id_product, IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `available_qty` 
            FROM tb_storage_fg f
            WHERE f.id_wh_drawer='" + id_wh_drawer + "' AND f.id_product='" + id_product + "' "
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                If GVProduct.GetRowCellValue(i, "qty") > dt.Rows(0)("available_qty") Then
                    cond_stock = False
                    GVProduct.SetRowCellValue(i, "status", "Qty can't exceed : " + dt.Rows(0)("available_qty").ToString + " ")
                Else
                    GVProduct.SetRowCellValue(i, "status", "OK")
                End If
            Else
                cond_stock = False
                GVProduct.SetRowCellValue(i, "status", "No available qty")
            End If
        Next
        Cursor = Cursors.Default

        If Not cond_stock Then
            stopCustom("Can't procees these order, please make sure available stock ")
            GridColumnProdStatus.VisibleIndex = 100
            XTCOrder.SelectedTabPageIndex = 1
        Else
            infoCustom("OK")
        End If
    End Sub
End Class