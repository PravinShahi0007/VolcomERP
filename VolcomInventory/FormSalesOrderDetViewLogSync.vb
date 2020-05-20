Public Class FormSalesOrderDetViewLogSync
    Private Sub FormSalesOrderDetViewLogSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT l.*, IFNULL(q.qty,0) AS `qty`
            FROM tb_shopify_api_log l 
            INNER JOIN tb_fg_trf t ON t.id_fg_trf = l.id_report
            INNER JOIN tb_sales_order so ON so.id_sales_order = t.id_sales_order
            INNER JOIN (
                SELECT sod.id_sales_order, p.product_full_code AS `code`, sod.sales_order_det_qty AS `qty`
                FROM tb_sales_order_det sod
                INNER JOIN tb_m_product p ON p.id_product = sod.id_product
                WHERE sod.id_sales_order = " + FormSalesOrderDet.id_sales_order + "
            ) q ON q.id_sales_order = so.id_sales_order AND l.sku = q.`code`
            WHERE so.id_sales_order = " + FormSalesOrderDet.id_sales_order + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLog.DataSource = data

        GVLog.BestFitColumns()
    End Sub

    Private Sub FormSalesOrderDetViewLogSync_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class