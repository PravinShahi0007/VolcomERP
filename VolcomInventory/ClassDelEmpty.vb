Public Class ClassDelEmpty
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

        Dim query As String = "SELECT del.id_wh_del_empty, del.wh_del_empty_number, 
        del.id_store_contact_from, cc.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `store`, c.address_primary, 
        COUNT(deld.id_wh_del_empty_det) AS `total`,
        del.wh_del_empty_date, del.wh_del_empty_note, del.id_report_status, rs.report_status, del.is_fix, del.last_update, emp.employee_name as `last_user`
        FROM tb_wh_del_empty del
        LEFT JOIN tb_wh_del_empty_det deld ON deld.id_wh_del_empty = del.id_wh_del_empty
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_user u ON u.id_user = del.last_update_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status rs ON del.id_report_status = rs.id_report_status
        WHERE del.id_wh_del_empty>0 "
        query += condition + " "
        query += "GROUP BY del.id_wh_del_empty  "
        query += "ORDER BY del.id_wh_del_empty " + order_type
        Return query
    End Function
End Class
