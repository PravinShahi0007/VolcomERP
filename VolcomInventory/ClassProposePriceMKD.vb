Public Class ClassProposePriceMKD
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

        Dim query As String = "SELECT p.id_pp_change, p.`number`, p.created_date, p.effective_date, p.soh_sal_date, 
        p.note, p.id_report_status, rs.report_status,p.id_design_price_type, p.id_design_mkd, pt.design_price_type, p.is_confirm, p.confirm_date, p.plan_end_date
        FROM tb_pp_change p 
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = p.id_report_status
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
        WHERE p.id_pp_change>0 "
        query += condition + " "
        query += "ORDER BY p.id_pp_change " + order_type
        Return query
    End Function
End Class
