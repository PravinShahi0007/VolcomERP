Public Class ClassEmpUni
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

        Dim query As String = "SELECT u.id_emp_uni_period, u.period_name, u.selection_date_start, u.selection_date_start, u.selection_date_end, u.created_date, u.distribution_date, u.tolerance
        FROM tb_emp_uni_period u
        WHERE u.id_emp_uni_period>0 "
        query += condition + " "
        query += "GROUP BY u.id_emp_uni_period  "
        query += "ORDER BY u.id_emp_uni_period " + order_type
        Return query
    End Function

    Public Function queryMainOrder(ByVal condition As String, ByVal order_type As String, ByVal except_id As String) As String
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

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, so.sales_order_date, so.sales_order_note, SUM(IFNULL(sod.sales_order_det_qty,0)) AS `total_order`, SUM(IFNULL(udd.point,0)) AS `amount`,
        so.id_emp_uni_budget, b.id_emp_uni_period, p.period_name, 100.00 AS `budget`, so.tolerance, so.discount,
        b.id_employee, e.employee_code, e.employee_name, e.employee_position, e.id_employee_level, lvl.employee_level, e.id_departement, d.departement,
        so.id_report_status, rs.report_status, so.sales_order_note, so.sales_order_date, eu.employee_name AS `prepared_by`, c.id_drawer_def
        FROM tb_sales_order so
        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_m_product prod ON prod.id_product = sod.id_product
        LEFT JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        INNER JOIN tb_emp_uni_budget b on b.id_emp_uni_budget = so.id_emp_uni_budget
        INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee
        LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = e.id_employee_level
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        INNER JOIN tb_emp_uni_period p ON p.id_emp_uni_period = b.id_emp_uni_period
        LEFT JOIN tb_emp_uni_design ud ON ud.id_emp_uni_period = p.id_emp_uni_period AND ud.id_report_status=6
        LEFT JOIN tb_emp_uni_design_det udd ON udd.id_emp_uni_design = ud.id_emp_uni_design AND udd.id_design = dsg.id_design
        INNER JOIN tb_m_user u ON u.id_user = so.id_user_created
        INNER JOIN tb_m_employee eu ON eu.id_employee = u.id_employee
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_warehouse_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        WHERE so.id_sales_order>0 "
        query += condition + " "
        query += "GROUP BY so.id_sales_order "
        query += "ORDER BY so.id_sales_order " + order_type
        Return query
    End Function


    Public Function queryMainList(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT d.id_emp_uni_design, d.id_emp_uni_period, pr.period_name, d.id_wh_drawer, d.note, d.created_date, d.id_report_status, rs.report_status
        FROM tb_emp_uni_design d
        INNER JOIN tb_emp_uni_period pr ON pr.id_emp_uni_period = d.id_emp_uni_period
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = d.id_report_status
        WHERE d.id_emp_uni_design>0 "
        query += condition + " "
        query += "GROUP BY d.id_emp_uni_design  "
        query += "ORDER BY d.id_emp_uni_design " + order_type
        Return query
    End Function
End Class
