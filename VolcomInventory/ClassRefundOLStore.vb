Public Class ClassRefundOLStore
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

        Dim query As String = "SELECT r.id_ol_store_refund, r.id_comp_group, cg.description AS `comp_group_name`,
        r.id_wh_normal, CONCAT(whn.comp_number, ' - ', whn.comp_name) AS `wh_normal`, 
        r.id_wh_sale, CONCAT(whs.comp_number, ' - ', whs.comp_name) AS `wh_sale`, 
        r.sales_order_ol_shop_number, r.`number`, r.created_date, 
        r.created_by, e.employee_name AS `created_by_name`, r.note, 
        r.id_report_status,  stt.report_status 
        FROM tb_ol_store_refund r
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = r.id_comp_group
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_comp whn ON whn.id_comp = r.id_wh_normal
        INNER JOIN tb_m_comp whs ON whs.id_comp = r.id_wh_sale
        WHERE r.id_ol_store_refund>0 "
        query += condition + " "
        query += "ORDER BY r.id_ol_store_refund " + order_type
        Return query
    End Function
End Class
