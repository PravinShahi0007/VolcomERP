Public Class FormPopUpEmployee
    Public id_popup As String = "-1"
    Private Sub FormPopUpEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        If FormEmpLeave.is_propose = "1" Then
            query += " WHERE dep.id_user_head='" & id_user & "'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormPopUpEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If id_popup = "1" Then
            FormEmpLeaveDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpLeaveDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpLeaveDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpLeaveDet.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpLeaveDet.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpLeaveDet.DEJoinDate.EditValue = GVEmployee.GetFocusedRowCellValue("employee_join_date")
            Close()
        ElseIf id_popup = "2" Then
            FormEmpLeaveDet.id_employee_change = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpLeaveDet.TEEMployeeChange.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpLeaveDet.TEEmployeeChangeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            Close()
        End If
    End Sub
End Class