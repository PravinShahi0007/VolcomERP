Public Class ClassEts
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

        Dim query As String = "SELECT e.id_ets, e.number, e.created_date, e.effective_date, e.id_report_status, stt.report_status, e.note, e.is_confirm
        FROM tb_ets e
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = e.id_report_status "
        query += "WHERE e.id_ets>0 "
        query += condition + " "
        query += "ORDER BY e.id_ets " + order_type
        Return query
    End Function
End Class
