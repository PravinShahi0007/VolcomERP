Public Class ClassEOSChange
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

        Dim query As String = "SELECT s.id_eos_change, s.id_pp_change, s.`number`, s.created_date, 
        s.pps_date, p.effective_date, p.plan_end_date, p.number AS `mkd_number`,
        s.id_report_status, stt.report_status, s.note 
        FROM tb_eos_change s
        INNER JOIN tb_pp_change p ON p.id_pp_change = s.id_pp_change
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = s.id_report_status "
        query += "WHERE s.id_eos_change>0 "
        query += condition + " "
        query += "ORDER BY s.id_eos_change " + order_type
        Return query
    End Function
End Class
