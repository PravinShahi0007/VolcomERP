Public Class FormEmpSchedule
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub

    Sub load_emp()
        Dim query As String = "SELECT emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormEmpSchedule_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpSchedule_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        If GVEmployee.RowCount > 0 Then
            FormEmpScheduleView.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpScheduleView.TEName.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpScheduleView.TECode.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpScheduleView.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpScheduleView.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpScheduleView.ShowDialog()
        End If
    End Sub

    Private Sub BSetSchedule_Click(sender As Object, e As EventArgs) Handles BSetSchedule.Click
        FormEmpScheduleBulkSet.ShowDialog()
    End Sub

    Private Sub BTableInsert_Click(sender As Object, e As EventArgs) Handles BTableInsert.Click
        FormEmpScheduleTable.ShowDialog()
    End Sub
End Class