Public Class FormEmloyeePps
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Public is_hrd As String = "-1"

    Private Sub FormEmployeePps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewEmployee()
    End Sub

    Sub load_pps()

    End Sub

    Sub viewDept()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Sub viewEmployee()
        Dim query As String = "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name, 0 AS id_departement, 0 AS id_employee_active UNION (SELECT e.id_employee, e.employee_code, e.employee_name, e.id_departement, e.id_employee_active FROM tb_m_employee e LEFT JOIN tb_m_departement d ON e.id_departement = d.id_departement ORDER BY e.employee_name)"
        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub FormEmployeePps_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmployeePps_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpLeave_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SLUEEmployee_Click(sender As Object, e As EventArgs) Handles SLUEEmployee.Click
        SearchLookUpEditEmp.ActiveFilterString = ""

        If LEDeptSum.EditValue.ToString <> "0" Then
            SearchLookUpEditEmp.ActiveFilterString += "[id_departement] = " + LEDeptSum.EditValue.ToString
        End If

        If SearchLookUpEditEmp.ActiveFilterString <> "" Then
            SearchLookUpEditEmp.ActiveFilterString += "OR [id_employee] = 0"
        End If
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        SLUEEmployee.EditValue = 0
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_pps()
    End Sub
End Class