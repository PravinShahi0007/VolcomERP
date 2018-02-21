Public Class FormEmpLeaveCutEmp
    Dim id_leave_cut As String = "-1"
    Private Sub FormEmpPayrollEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_leave_cut = FormEmpLeaveCut.GVPayrollPeriode.GetFocusedRowCellValue("id_leave_cut").ToString()
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT 'no' AS is_check,emp.id_employee,dep.total_workdays,dep.is_store,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active,salx.*
                                FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                INNER JOIN (	
	                                SELECT sal.* FROM (
		                                SELECT * FROM tb_m_employee_salary sal
		                                WHERE is_cancel='2'
		                                ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                                ) sal GROUP BY id_employee
                                ) salx ON salx.id_employee = emp.`id_employee`
                                WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_leave_cut_det WHERE id_leave_cut='" & id_leave_cut & "')"

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
        Dim query As String = ""

        Cursor = Cursors.WaitCursor
        GVEmployee.ActiveFilterString = ""
        GVEmployee.ActiveFilterString = "[is_check]='yes'"
        If GVEmployee.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVEmployee.ActiveFilterString = ""
        Else
            query = "INSERT INTO tb_emp_leave_cut_det(id_leave_cut,id_employee) VALUES"
            For i As Integer = 0 To ((GVEmployee.RowCount - 1) - GetGroupRowCount(GVEmployee))
                Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                If Not i = 0 Then
                    query += ","
                End If
                query += "('" & id_leave_cut & "','" & id_employee & "')"
            Next
            execute_non_query(query, True, "", "", "", "")
        End If
        GVEmployee.ActiveFilterString = ""
        Cursor = Cursors.Default
        FormEmpLeaveCutDet.load_det()
        infoCustom("Employee listed.")
        Close()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        Dim query As String = "INSERT INTO tb_emp_leav_cut_det(id_payroll,id_employee,id_salary,workdays)
                                SELECT '" & id_leave_cut & "' as id_leave_cut,emp.id_employee
                                FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll='" & id_leave_cut & "')"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Employee listed.")
        FormEmpLeaveCutDet.load_det()
        Close()
    End Sub
End Class