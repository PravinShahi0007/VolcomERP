Public Class ClassVirtualSales
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

        Dim query As String = "SELECT vs.id_virtual_sales, vs.`number`, vs.created_date, vs.created_by, e.employee_name AS `created_by_name`, 
        vs.id_comp, c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_desc`,
        vs.start_period, vs.end_period, vs.id_report_status, stt.report_status, vs.note, IFNULL(SUM(vsd.qty),0) AS `total_qty`
        FROM tb_virtual_sales vs 
        LEFT JOIN tb_virtual_sales_det vsd ON vsd.id_virtual_sales = vs.id_virtual_sales
        INNER JOIN tb_m_comp c ON c.id_comp = vs.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = vs.id_report_status
        INNER JOIN tb_m_user u ON u.id_user = vs.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee "
        query += "WHERE vs.id_virtual_sales>0 "
        query += condition + " "
        query += "ORDER BY vs.id_virtual_sales " + order_type
        Return query
    End Function
End Class
