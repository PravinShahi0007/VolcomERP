Public Class ClassDisableExos
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

        Dim query As String = "SELECT s.id_disable_exos, s.`number`, s.created_date, s.id_report_status, stt.report_status, s.note 
        FROM tb_disable_exos s
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = s.id_report_status "
        query += "WHERE s.id_disable_exos>0 "
        query += condition + " "
        query += "ORDER BY s.id_disable_exos " + order_type
        Return query
    End Function
End Class
