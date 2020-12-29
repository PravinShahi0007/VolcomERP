Public Class ClassPayoutZalora
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

        Dim query As String = ""
        query += "SELECT z.id_payout_zalora, z.statement_number, z.zalora_created_at, z.opening_balance, 
        z.sales_revenue, z.other_revenue, z.total_fees, z.sales_refund, z.total_refund_fee, z.closing_balance, 
        z.closing_balance, z.guarantee_deposit, z.total_payout, z.default_comm, z.default_shipping,z.sync_date, z.note, z.is_confirm, IF(z.is_confirm=1,'Confirmed', 'Not Confirmed') AS `is_confirm_view`, z.id_report_status, rs.report_status
        FROM tb_payout_zalora z 
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = z.id_report_status
        WHERE z.id_payout_zalora>0 "
        query += condition + " "
        query += "ORDER BY z.zalora_created_at DESC "
        Return query
    End Function
End Class