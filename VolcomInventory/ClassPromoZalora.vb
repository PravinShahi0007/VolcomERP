Public Class ClassPromoZalora
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

        Dim query As String = "SELECT p.id_promo_zalora, p.`number`, p.promo_name, p.discount_code, p.discount_value, p.volcom_pros, 
        p.start_period, p.end_period,p.propose_created_date, p.propose_created_by, ep.employee_name AS `propose_created_by_name`, 
        p.id_report_status, stt.report_status, p.rmt_propose, p.propose_note, p.is_confirm
        FROM tb_promo_zalora p
        INNER JOIN tb_m_user up ON up.id_user = p.propose_created_by
        INNER JOIN tb_m_employee ep ON ep.id_employee = up.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        WHERE p.id_promo_zalora>0 "
        query += condition + " "
        query += "ORDER BY p.id_promo_zalora " + order_type
        Return query
    End Function
End Class
