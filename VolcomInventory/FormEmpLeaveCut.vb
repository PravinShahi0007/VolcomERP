Public Class FormEmpLeaveCut
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Private Sub FormEmpLeaveCut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_leave_cut()
    End Sub

    Private Sub FormEmpLeaveCut_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        check_but()
    End Sub

    Private Sub FormEmpLeaveCut_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpLeaveCut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_but()
        If GVPayrollPeriode.RowCount > 0 Then
            bnew_active = 1
            bedit_active = 1
            bdel_active = 1
        Else
            bnew_active = 1
            bedit_active = 0
            bdel_active = 0
        End If
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_leave_cut()
        Dim query As String = "SELECT emp.`employee_name`,rs.`report_status`,DATE_FORMAT(py.`periode_end`,'%M %Y') AS periode,py.periode_start,py.`periode_end`,lc.* FROM tb_emp_leave_cut lc
                                INNER JOIN tb_lookup_report_status rs ON rs.`id_report_status`=lc.`id_report_status`
                                INNER JOIN tb_emp_payroll py ON py.`id_payroll`=lc.`id_payroll`
                                INNER JOIN tb_m_user usr ON usr.`id_user`=lc.`id_user_last_upd`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPayrollPeriode.DataSource = data
        GVPayrollPeriode.BestFitColumns()
    End Sub
End Class