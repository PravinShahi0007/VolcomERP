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
        p.id_report_status, stt.report_status, p.rmt_propose, p.propose_note, p.is_confirm, 
        p.recon_created_date, p.recon_created_by, er.employee_name AS `recon_created_by_name`, p.id_report_status_recon, sttrecon.report_status AS `report_status_recon`, p.rmt_recon, p.recon_note, p.is_confirm_recon
        FROM tb_promo_zalora p
        INNER JOIN tb_m_user up ON up.id_user = p.propose_created_by
        INNER JOIN tb_m_employee ep ON ep.id_employee = up.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        LEFT JOIN tb_m_user ur ON ur.id_user = p.recon_created_by
        LEFT JOIN tb_m_employee er ON er.id_employee = ur.id_employee
        LEFT JOIN tb_lookup_report_status sttrecon ON sttrecon.id_report_status = p.id_report_status_recon
        WHERE p.id_promo_zalora>0 "
        query += condition + " "
        query += "ORDER BY p.id_promo_zalora " + order_type
        Return query
    End Function
End Class
