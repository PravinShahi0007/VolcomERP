Public Class FormEmpPayroll
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormEmpPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll()
        '
    End Sub

    Sub load_payroll()
        Dim query As String = "SELECT pr.*,emp.`employee_name` FROM tb_emp_payroll pr
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
                                ORDER BY pr.periode_end DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCPayrollPeriode.DataSource = data
    End Sub

    Private Sub FormEmpPayroll_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpPayroll_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpPayroll_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class