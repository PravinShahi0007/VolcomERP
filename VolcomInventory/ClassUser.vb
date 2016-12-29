Public Class ClassUser
    Sub logLogin(ByVal type As String)
        If id_user > "0" And id_user <> "" Then
            Dim query As String = "INSERT INTO tb_log_login(id_user, time,type) 
            VALUES('" + id_user + "', NOW(), '" + type + "') "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

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
        query += "SELECT l.id_user, e.id_employee, e.employee_code, e.employee_name, e.employee_position, l.`time`, 
        l.`type`, IF(l.`type`=1,'Login', 'Logout') AS `type_display`
        FROM tb_log_login l
        INNER JOIN tb_m_user u ON l.id_user = u.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee "
        query += "WHERE 5>1 "
        query += condition + " "
        query += "ORDER BY l.time " + order_type
        Return query
    End Function

End Class
