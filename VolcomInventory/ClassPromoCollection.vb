﻿Public Class ClassPromoCollection
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

        Dim query As String = "SELECT p.id_ol_promo_collection, cg.id_comp_group, cg.comp_group, cg.id_api_type, p.id_promo, prm.promo, p.promo_name, p.discount_title, p.`number`, p.created_date, 
        p.created_by, e.employee_name AS `created_by_name`, p.tag,
        p.start_period, p.end_period, p.id_report_status, stt.report_status, p.note, p.is_confirm, p.is_use_discount_code, IF(p.is_use_discount_code=1,'Active', 'Not Active') AS `use_discount_code`, p.price_rule_id, p.report_mark_type,
        p.is_all_collection, IF(p.is_all_collection=1,'Yes', 'No') AS `is_all_collection_view`
        FROM tb_ol_promo_collection p
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = p.id_comp_group
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        INNER JOIN tb_promo prm ON prm.id_promo = p.id_promo
        LEFT JOIN tb_m_user u ON u.id_user = p.created_by
        LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE p.id_ol_promo_collection>0 "
        query += condition + " "
        query += "ORDER BY p.id_ol_promo_collection " + order_type
        Return query
    End Function
End Class
