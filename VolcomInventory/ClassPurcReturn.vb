Public Class ClassPurcReturn
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

        Dim query As String = "SELECT ret.id_purc_return, ret.id_purc_order, po.purc_order_number,
        po.id_comp_contact, c.id_comp AS `id_vendor`, c.comp_number AS `vendor_code`, c.comp_name AS `vendor_name`, CONCAT(c.comp_number,' - ', c.comp_name) AS `vendor`,
        ret.`number`, ret.created_date, ret.created_by, ec.employee_name AS `created_by_name`,
        ret.id_report_status, rs.report_status, ret.note
        FROM tb_purc_return ret
        INNER JOIN tb_purc_order po ON po.id_purc_order = ret.id_purc_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = ret.id_report_status
        INNER JOIN tb_m_user uc ON uc.id_user = ret.created_by
        INNER JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        WHERE ret.id_purc_return>0  "
        query += condition + " "
        query += "ORDER BY ret.id_purc_return " + order_type
        Return query
    End Function
End Class
