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
End Class
