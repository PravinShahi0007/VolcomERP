Public Class ClassEmpUni
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

        Dim query As String = "SELECT u.id_emp_uni_period, u.period_name, u.selection_date_start, u.selection_date_start, u.selection_date_end, u.created_date, u.distribution_date 
        FROM tb_emp_uni_period u
        WHERE u.id_emp_uni_period>0 "
        query += condition + " "
        query += "GROUP BY u.id_emp_uni_period  "
        query += "ORDER BY u.id_emp_uni_period " + order_type
        Return query
    End Function
End Class
