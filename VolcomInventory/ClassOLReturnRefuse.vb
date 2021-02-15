Public Class ClassOLReturnRefuse
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

        Dim query As String = "SELECT r.id_return_refuse, r.id_refuse_type, rt.refuse_type, r.`number`,  r.created_date, r.created_by, emp.employee_name AS `created_by_name`,
        r.id_store_contact, c.id_comp, c.comp_number, c.comp_name, cg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`, 
        r.id_sales_order, so.sales_order_number, so.sales_order_ol_shop_number,so.sales_order_date, so.sales_order_ol_shop_date, so.customer_name, so.shipping_address,
        r.note, r.id_report_status, stt.report_status
        FROM tb_ol_store_return_refuse r
        INNER JOIN tb_lookup_refuse_type rt ON rt.id_refuse_type = r.id_refuse_type
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = r.id_store_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_sales_order so ON so.id_sales_order = r.id_sales_order
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        INNER JOIN tb_m_user us ON us.id_user = r.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = us.id_employee
        WHERE r.id_return_refuse>0 "
        query += condition + " "
        query += "ORDER BY r.id_return_refuse " + order_type
        Return query
    End Function
End Class
