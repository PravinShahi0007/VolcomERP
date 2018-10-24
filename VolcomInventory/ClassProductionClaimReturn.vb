Public Class ClassProductionClaimReturn
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

        Dim query As String = "SELECT cr.id_prod_claim_return, cr.id_comp_contact, c.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        cr.id_prod_order, po.prod_order_number, cr.`number`, cr.created_date, cr.note, cr.id_report_status 
        FROM tb_prod_claim_return cr
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = cr.id_comp_contact
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_prod_order po ON po.id_prod_order = cr.id_prod_order
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = cr.id_report_status
        WHERE cr.id_prod_claim_return>0 "
        query += condition + " "
        query += "ORDER BY cr.id_prod_claim_return " + order_type
        Return query
    End Function
End Class
