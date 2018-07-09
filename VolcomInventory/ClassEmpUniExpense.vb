Public Class ClassEmpUniExpense
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT e.id_emp_uni_ex, e.id_comp_contact, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, 
        e.id_pl_sales_order_del, del.pl_sales_order_del_number, 
        e.emp_uni_ex_number, e.emp_uni_ex_date, e.emp_uni_ex_note, e.id_report_status , rs.report_status
        FROM tb_emp_uni_ex e
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = e.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = e.id_report_status
        LEFT JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = e.id_pl_sales_order_del
        WHERE e.id_emp_uni_ex>0 "
        query += condition + " "
        query += "ORDER BY e.id_emp_uni_ex " + order_type
        Return query
    End Function


    Public Sub reservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_emp_uni_ex = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'cancelled reserved stock
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_sales_pos = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completedStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'completedReservedStock 
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status)
        SELECT getCompByContact(p.id_store_contact_from, 4), 1, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 2
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_sales_pos = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 
        UNION ALL
        SELECT getCompByContact(p.id_store_contact_from, 4), 2, pd.id_product, IFNULL(pd.design_cop,0), " + report_mark_type_param + ", " + id_report_param + ", pd.qty, NOW(), '', 1
        FROM tb_emp_uni_ex p
        INNER JOIN tb_emp_uni_ex_det pd ON pd.id_sales_pos = p.id_emp_uni_ex
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE p.id_emp_uni_ex=" + id_report_param + " AND pd.qty>0 "
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
