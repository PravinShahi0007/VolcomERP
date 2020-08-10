Public Class FormPayoutReport
    Private Sub FormPayoutReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT 
        od.sales_order_ol_shop_number AS `order_number`, od.sales_order_ol_shop_date AS `order_date`, od.customer_name,
        d.* 
        FROM (	
	        SELECT sp.sales_pos_number AS `inv_number`, sh.number AS `inv_ship_number`, t.settlement_date AS `trans_date`,t.pay_type, t.bank, 'Payout' AS `type`,t.id, 
	        t.payment, t.trans_fee, (t.payment - t.trans_fee) AS `amount`
	        FROM tb_list_payout t
	        LEFT JOIN (
	          SELECT so.id_sales_order_ol_shop, GROUP_CONCAT(DISTINCT sp.sales_pos_number) AS `sales_pos_number`, so.customer_name
	          FROM tb_list_payout_det t  
	          INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = t.id_sales_pos
	          INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = sp.id_pl_sales_order_del
	          INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
	          GROUP BY so.id_sales_order_ol_shop
	        ) sp ON sp.id_sales_order_ol_shop = t.id
	        LEFT JOIN (
	           SELECT s.id_invoice_ship, s.id_report, s.number, s.value 
	           FROM tb_invoice_ship s 
	           GROUP BY s.id_report
	        ) sh ON sh.id_report = t.id
	        UNION ALL
	        SELECT sp.sales_pos_number AS `inv_number`, sh.number AS `inv_ship_number`, t.transaction_time AS `trans_date`,t.payment_type AS `pay_type`, b.bank, 'Virtual Account' AS s, t.id, t.amount_inv AS `payment`, 0 AS `trans_fee`, t.amount_inv AS `amount`
	        FROM tb_virtual_acc_trans_det t 
	        INNER JOIN tb_virtual_acc_trans m ON m.id_virtual_acc_trans = t.id_virtual_acc_trans
	        INNER JOIN tb_virtual_acc b ON b.id_virtual_acc = m.id_virtual_acc
	        LEFT JOIN (
	         SELECT so.id_sales_order_ol_shop, GROUP_CONCAT(DISTINCT sp.sales_pos_number) AS `sales_pos_number`, so.customer_name
	         FROM tb_virtual_acc_trans_inv t  
	         INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = t.id_sales_pos
	         INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = sp.id_pl_sales_order_del
	         INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
	         GROUP BY so.id_sales_order_ol_shop
	        ) sp ON sp.id_sales_order_ol_shop = t.id
	        LEFT JOIN (
	          SELECT s.id_invoice_ship, s.id_report, s.number, s.value 
	          FROM tb_invoice_ship s 
	          GROUP BY s.id_report
	        ) sh ON sh.id_report = t.id
        ) d
        INNER JOIN tb_ol_store_order od ON od.id = d.id
        WHERE (d.trans_date>='" + date_from_selected + "' AND d.trans_date<='" + date_until_selected + "')
        GROUP BY od.id
        ORDER BY od.sales_order_ol_shop_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutReport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPayoutReport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class