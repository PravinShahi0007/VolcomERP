Public Class FormSalesPOSCheck
    Public id_store As String = "-1"
    Public start_period As String = ""
    Public end_period As String = ""

    Private Sub FormSalesPOSCheck_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesPOSCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewMaster()
    End Sub

    Private Function queryMasterMain(ByVal show_ok_only As Boolean, ByVal show_price As Boolean) As String
        Dim query As String = "SELECT pd.id_pos_combine_summary, pd.id_product, pd.item_code,  prod.product_full_code, prod.product_display_name AS `name`, cd.code_detail_name AS `size`, 
        (pd.qty-IFNULL(crt.qty,0)) AS `qty`,coll.is_unique_report,IF(ISNULL(coll.full_code),'Not found','OK') AS `status` "
        If show_price Then
            query += ",prc.id_design_price, prc.design_price "
        End If
        query += "From tb_pos_combine_summary pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
        INNER JOIN tb_pos_combine p ON p.id_pos_combine = pd.id_pos_combine
        LEFT JOIN (
	        SELECT d.id_pos_combine_summary,SUM(d.sales_pos_det_qty) AS `qty`
	        FROM tb_sales_pos_det d
	        INNER JOIN tb_sales_pos m ON m.id_sales_pos = d.id_sales_pos
	        WHERE m.id_report_status!=5
	        GROUP BY d.id_pos_combine_summary
        ) crt ON crt.id_pos_combine_summary = pd.id_pos_combine_summary
        LEFT JOIN (
	        SELECT a.id_product, a.`id_pl_prod_order_rec_det_unique`, a.`full_code`, a.`code`, a.counting, a.`name`, cd.code_detail_name AS `size`, a.`is_old_design`, a.is_unique_report
	        FROM (
		        SELECT u.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, 1 AS `qty`, u.is_unique_report
		        FROM tb_m_unique_code u
		        INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
		        WHERE u.id_comp=" + id_store + " AND u.is_unique_report=2
		        GROUP BY u.id_product
		        UNION ALL
		        SELECT u.id_product, c.id_pl_prod_order_rec_det_unique,u.unique_code AS `full_code`, prod.product_full_code AS `code`, RIGHT(u.unique_code,4) AS `counting`, prod.product_display_name AS `name`, 2 AS `is_old_design`, IFNULL(SUM(u.qty),0) AS `qty`, u.is_unique_report
		        FROM tb_m_unique_code u
		        INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
		        INNER JOIN tb_pl_prod_order_rec_det_counting c ON c.id_product = u.id_product AND c.pl_prod_order_rec_det_counting = RIGHT(u.unique_code,4)
		        WHERE u.id_comp=" + id_store + " AND u.is_unique_report=1
		        GROUP BY u.unique_code
		        HAVING qty=1
		        UNION ALL
		        SELECT deld.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
		        INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
		        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
		        WHERE del.id_report_status=6 AND cc.id_comp=" + id_store + " AND dsg.is_old_design=1
		        GROUP BY deld.id_product
		        UNION
		        SELECT prod.id_product, NULL AS `id_pl_prod_order_rec_det_unique`, prod.product_full_code AS `full_code`, prod.product_full_code AS `code`, '' AS `counting`, prod.product_display_name AS `name`, dsg.is_old_design, 1 AS `qty`, 2 AS `is_unique_report`
		        FROM tb_m_product prod 
		        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
		        WHERE dsg.is_old_design=1 
		        GROUP BY prod.id_product
	        ) a
	        INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = a.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodcode.id_code_detail
        ) coll ON coll.full_code = pd.item_code "
        If show_price Then
            query += "LEFT JOIN( 
	          Select * FROM ( 
	          Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	          price.id_design_price_type, price_type.design_price_type,
	          cat.id_design_cat, cat.design_cat
	          From tb_m_design_price price 
	          INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
	          INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	          WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
	          ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
	          GROUP BY a.id_design 
	        ) prc ON prc.id_design = prod.id_design "
        End If
        query += "WHERE pd.id_comp_sup=" + id_store + " AND (p.pos_date>='" + start_period + "' AND p.pos_date<='" + end_period + "') "
        If show_ok_only Then
            query += "AND !ISNULL(coll.full_code) "
        End If
        query += "HAVING qty>0  "
        Return query
    End Function

    Sub viewMaster()
        Cursor = Cursors.WaitCursor
        Dim query As String = queryMasterMain(False, True)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewStock()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_product, a.item_code, a.product_full_code, a.`name`, a.size, IFNULL(stc.available_qty,0) AS `available_qty`,SUM(qty) AS `qty`,
        IF(SUM(qty)<=IFNULL(stc.available_qty,0),'OK', CONCAT('Cant exceed ',IFNULL(stc.available_qty,0))) AS `status`
        FROM ( " + queryMasterMain(True, False) + ") a  
        LEFT JOIN (
	        SELECT f.id_wh_drawer, f.id_product,SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS `available_qty`
	        FROM tb_storage_fg f
	        INNER JOIN tb_m_comp c ON c.id_drawer_def = f.id_wh_drawer
	        WHERE c.id_comp=" + id_store + "
	        GROUP BY f.id_product
	        HAVING available_qty>0
        ) stc ON stc.id_product = a.id_product
        GROUP BY a.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCStock.DataSource = data
        GVStock.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnProceed_Click(sender As Object, e As EventArgs) Handles BtnProceed.Click

    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 1 Then
            viewStock()
        End If
    End Sub
End Class