Public Class FormEmpPayrollADPick
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollADPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim not_included As String = ""

        For i = 0 To FormEmpPayrollDeductionDet.GVDeduction.RowCount - 1
            If FormEmpPayrollDeductionDet.GVDeduction.IsValidRowHandle(i) Then
                not_included += FormEmpPayrollDeductionDet.GVDeduction.GetRowCellValue(i, "id_employee").ToString + ", "
            End If
        Next

        Dim where_not_included As String = ""

        If Not not_included = "" Then
            not_included = not_included.Substring(0, not_included.Length - 2)

            where_not_included = "AND emp.id_employee NOT IN (" + not_included + ")"
        End If

        Dim query As String = "
            SELECT emp.id_employee, employee_code, emp.employee_name, emp.id_departement, dp.departement, emp.employee_position, IFNULL(emp.id_employee_status, 0) AS id_employee_status, sts.employee_status, IFNULL(emp.id_employee_active, 0) AS id_employee_active, act.employee_active, ROUND(prl.workdays, 0) AS workdays, ROUND(prl.actual_workdays, 0) AS actual_workdays, ROUND(sal.total_salary, 0) AS total_salary
            FROM tb_emp_payroll_det AS prl
            LEFT JOIN tb_m_employee AS emp ON prl.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dp ON emp.id_departement = dp.id_departement
            LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS act ON emp.id_employee_active = act.id_employee_active
            LEFT JOIN (
                SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS total_salary
                FROM tb_m_employee_salary
            ) AS sal ON sal.id_employee_salary = prl.id_salary
            WHERE prl.id_payroll = " + id_payroll + " " + where_not_included + "
            ORDER BY emp.id_employee_status ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBInsert_Click(sender As Object, e As EventArgs) Handles SBInsert.Click
        GVEmployee.ApplyFindFilter("")

        If GVEmployee.SelectedRowsCount > 0 Then
            Dim data As DataTable = FormEmpPayrollDeductionDet.GCDeduction.DataSource

            Dim selected_rows As Integer() = GVEmployee.GetSelectedRows()

            For i = 0 To selected_rows.Length - 1
                Dim selected_row As Integer = selected_rows(i)

                If selected_row >= 0 Then
                    Dim id_employee As String = GVEmployee.GetRowCellValue(selected_row, "id_employee").ToString
                    Dim departement As String = GVEmployee.GetRowCellValue(selected_row, "departement").ToString
                    Dim employee_code As String = GVEmployee.GetRowCellValue(selected_row, "employee_code").ToString
                    Dim employee_name As String = GVEmployee.GetRowCellValue(selected_row, "employee_name").ToString
                    Dim employee_position As String = GVEmployee.GetRowCellValue(selected_row, "employee_position").ToString
                    Dim employee_status As String = GVEmployee.GetRowCellValue(selected_row, "employee_status").ToString
                    Dim workdays As Integer = GVEmployee.GetRowCellValue(selected_row, "workdays")
                    Dim actual_workdays As Integer = GVEmployee.GetRowCellValue(selected_row, "actual_workdays")
                    Dim total_salary As Integer = GVEmployee.GetRowCellValue(selected_row, "total_salary")
                    Dim total_days As Integer = 0
                    Dim value As Integer = 0

                    data.Rows.Add(id_employee, departement, employee_code, employee_name, employee_position, employee_status, workdays, actual_workdays, total_salary, total_days, value)
                End If
            Next

            FormEmpPayrollDeductionDet.GVDeduction.BestFitColumns()

            Close()
        Else
            errorCustom("No employee selected.")
        End If
    End Sub

    Private Sub FormEmpPayrollADPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class