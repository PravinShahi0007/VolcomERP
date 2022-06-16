Public Class ClassDropChanges
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

        Dim query As String = "SELECT d.id_drop_changes, d.`number`, d.created_date, d.created_by, e.employee_name AS `created_by_name`,
        d.id_season, ss.season, d.note, d.id_report_status, stt.report_status 
        FROM tb_drop_changes d
        INNER JOIN tb_m_user u ON u.id_user = d.created_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
        WHERE d.id_drop_changes>0 "
        query += condition + " "
        query += "ORDER BY d.id_drop_changes " + order_type
        Return query
    End Function
End Class
