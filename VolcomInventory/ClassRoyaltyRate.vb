Public Class ClassRoyaltyRate
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

        Dim query As String = "SELECT r.id_royalty_rate, r.created_date, r.created_by, e.employee_name AS `created_by_name`, 
        r.royalty_rate, r.year_start, r.year_end, r.note, r.id_report_status, stt.report_status
        FROM tb_royalty_rate r
        INNER JOIN tb_m_user u ON u.id_user = r.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_royalty_rate
        WHERE r.id_royalty_rate>0 "
        query += condition + " "
        query += "ORDER BY r.id_royalty_rate " + order_type
        Return query
    End Function
End Class