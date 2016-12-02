Public Class FormEmpDP
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_propose As String = "-1"

    Private Sub FormEmpDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date()
        load_dp()
    End Sub
    Sub load_dp()
        Dim query As String = "SELECT emp.employee_name,emp.employee_position,dep.departement,rpt.report_status,emp.employee_code,dp.* FROM tb_emp_dp dp
                                INNER JOIN tb_m_employee emp ON emp.id_employee=dp.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_report_status rpt ON rpt.id_report_status=dp.id_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLeave.DataSource = data
    End Sub
    Sub load_date()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub FormEmpDP_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpDP_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class