Public Class FormEmpPayroll
    Private Sub FormEmpPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll()
    End Sub

    Sub load_payroll()
        Dim query As String = "SELECT pr.*,emp.`employee_name` FROM tb_emp_payroll pr
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
    End Sub
End Class