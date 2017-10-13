Public Class ClassSalesInv
    Public Function queryMain(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_main('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryMainReport(ByVal condition_param As String, ByVal order_type_param As String) As String
        Dim query As String = "CALL view_sales_inv_report('" + condition_param + "', '" + order_type_param + "') "
        Return query
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos('" + id_report_param + "')"
        Return query
    End Function

    Public Function queryDetailReport(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_sales_pos_report_new('" + id_report_param + "')"
        Return query
    End Function

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completedStockMissingStaff(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 2
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(p.id_comp_contact_bill, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0 
        UNION ALL
        SELECT getCompByContact(p.id_comp_contact_bill, 4), 2, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.sales_pos_det_qty, NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty>0  "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    'Public Sub completeReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
    '    'complete
    '    Dim query_compl As String = "CALL view_sales_pos('" + id_report_param + "') "
    '    Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

    '    Dim stc_remove_rsv As ClassStock = New ClassStock()
    '    Dim stc_compl As ClassStock = New ClassStock()
    '    For s As Integer = 0 To dt_compl.Rows.Count - 1
    '        stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "2")
    '        stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_pos_det_qty").ToString), "", "1")
    '    Next
    '    stc_remove_rsv.insStockFG()
    '    stc_compl.insStockFG()
    'End Sub

    '' ----------------------
    ''for stock in / creedit note
    '' ----------------------
    Public Sub completeInStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completed stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(dsg.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", (pd.sales_pos_det_qty*-1), NOW(), '', 1
        FROM tb_sales_pos p
        INNER JOIN tb_sales_pos_det pd ON pd.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_sales_pos=" + id_report_param + " AND pd.sales_pos_det_qty!=0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

End Class
