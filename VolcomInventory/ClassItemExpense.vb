Public Class ClassItemExpense
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

        Dim query As String = "SELECT e.id_item_expense, e.id_ref, e.`number`, e.created_date, e.due_date, e.created_by, emp.employee_name AS `created_by_name`, e.id_acc_from, e.id_payment_purchasing, e.id_report_status, stt.report_status, IF(e.id_report_status!=6, '-', IF(e.is_pay_later=2,'Paid', '?')) AS `paid_status`, e.note, e.is_pay_later,
        e.total, (e.total-IFNULL(er.total,0)) AS `balance`
        FROM tb_item_expense e
        INNER JOIN tb_m_user u ON u.id_user = e.created_by
        INNER JOIN tb_m_employee emp ON emp.id_employee = u.id_employee
        INNER JOIN tb_a_acc pfr ON pfr.id_acc = e.id_acc_from
        INNER JOIN tb_lookup_payment_purchasing pp ON pp.id_payment_purchasing = e.id_payment_purchasing
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = e.id_report_status
        LEFT JOIN (
	        SELECT er.id_ref, SUM(er.total) AS `total` 
	        FROM tb_item_expense er
	        WHERE er.id_report_status!=5
	        GROUP BY er.id_ref
        ) er ON er.id_ref = e.id_item_expense
        WHERE e.id_item_expense>0 "
        query += condition + " "
        query += "ORDER BY e.id_item_expense " + order_type
        Return query
    End Function
End Class
