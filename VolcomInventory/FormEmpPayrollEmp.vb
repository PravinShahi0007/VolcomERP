Public Class FormEmpPayrollEmp
    Private Sub FormEmpPayrollEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT 'no' AS is_check,emp.id_employee,dep.is_store,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active,salx.*
                                FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                LEFT JOIN (	
	                                SELECT sal.* FROM (
		                                SELECT * FROM tb_m_employee_salary sal
		                                WHERE is_cancel='2'
		                                ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                                ) sal GROUP BY id_employee
                                ) salx ON salx.id_employee = emp.`id_employee`
                                WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll='" & FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString & "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
        '
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormPopUpEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        pick()
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 Then
            pick()
        End If
    End Sub

    Private Sub FormPopUpEmployee_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GVEmployee.ShowFindPanel()
        GVEmployee.ShowFindPanel()
    End Sub

    Sub pick()

    End Sub
End Class