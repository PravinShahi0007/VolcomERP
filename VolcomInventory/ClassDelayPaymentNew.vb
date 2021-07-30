Public Class ClassDelayPaymentNew
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

        Dim query As String = "SELECT dp.id_delay_payment, dp.id_comp_group, cg.description AS `group`, dp.`number`, 
dp.created_date, dp.created_by, ec.employee_name AS `created_by_name`,
dp.due_date, dp.note, dp.id_report_status, rs.report_status, dp.is_submit 
FROM tb_delay_payment dp
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = dp.id_comp_group
INNER JOIN tb_m_user uc ON uc.id_user = dp.created_by
INNER JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = dp.id_report_status
WHERE dp.id_delay_payment>0 "
        query += condition + " "
        query += "ORDER BY dp.id_delay_payment " + order_type
        Return query
    End Function

End Class
