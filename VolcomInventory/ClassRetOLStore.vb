Public Class ClassRetOLStore
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

        Dim query As String = "SELECT r.id_ol_store_ret,r.id_ol_store_ret_req, r.id_comp_group, cg.description AS `comp_group_name`, r.sales_order_ol_shop_number, r.ret_req_number, r.rec_date, r.`number`,
        r.created_date, r.created_by, e.employee_name AS `created_by_name`, r.note, r.id_report_status, stt.report_status
        FROM tb_ol_store_ret r
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = r.id_comp_group
        WHERE r.id_ol_store_ret>0 "
        query += condition + " "
        query += "ORDER BY r.id_ol_store_ret " + order_type
        Return query
    End Function
End Class
