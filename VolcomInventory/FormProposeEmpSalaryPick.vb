Public Class FormProposeEmpSalaryPick
    Public id_sal_pps_type As String = "1"
    Public not_included As String = ""

    Private Sub FormProposeEmpSalaryPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim where_type As String = ""

        If id_sal_pps_type = "1" Then
            where_type = "AND emp.id_employee_status IN (1, 2)"
        ElseIf id_sal_pps_type = "2" Then
            where_type = "AND emp.id_employee_status IN (3)"
        End If

        Dim where_not_include As String = ""

        If Not not_included = "" Then
            where_not_include = "AND emp.id_employee NOT IN (" + not_included + ")"
        End If

        Dim query As String = "
            SELECT emp.id_employee, emp.employee_code, emp.employee_name, emp.id_departement, dp.departement, dp.total_workdays, emp.employee_position, IFNULL(emp.id_employee_level, 0) AS id_employee_level, lv.employee_level, IFNULL(emp.id_employee_active, 0) AS id_employee_active, act.employee_active, IFNULL(emp.id_employee_status, 0) AS id_employee_status, sts.employee_status, IFNULL(sal.id_employee_salary, 0) AS id_employee_salary, ROUND(IFNULL(sal.basic_salary, 0)) AS basic_salary_current, ROUND(IFNULL(sal.allow_job, 0)) AS allow_job_current, ROUND(IFNULL(sal.allow_meal, 0)) AS allow_meal_current, ROUND(IFNULL(sal.allow_trans, 0)) AS allow_trans_current, ROUND(IFNULL(sal.allow_house, 0)) AS allow_house_current, ROUND(IFNULL(sal.allow_car, 0)) AS allow_car_current
            FROM tb_m_employee AS emp
            LEFT JOIN tb_m_departement AS dp ON emp.id_departement = dp.id_departement
            LEFT JOIN tb_lookup_employee_level AS lv ON emp.id_employee_level = lv.id_employee_level
            LEFT JOIN tb_lookup_employee_active AS act ON emp.id_employee_active = act.id_employee_active
            LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
            LEFT JOIN (
                SELECT *
                FROM (
                    SELECT *
                    FROM tb_m_employee_salary
                    ORDER BY id_employee_salary DESC
                ) AS tb
                GROUP BY id_employee
            ) AS sal ON emp.id_employee = sal.id_employee
            WHERE 1 = 1 " + where_not_include + " " + where_type + "
            ORDER BY emp.id_employee_level ASC, emp.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.BestFitColumns()

        'filter employee_active
        GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"
    End Sub

    Private Sub FormProposeEmpSalaryPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBInsert_Click(sender As Object, e As EventArgs) Handles SBInsert.Click
        GVEmployee.ApplyFindFilter("")

        If GVEmployee.SelectedRowsCount > 0 Then
            Dim data As DataTable = FormProposeEmpSalaryDet.GCEmployee.DataSource

            Dim selected_rows As Integer() = GVEmployee.GetSelectedRows()

            For i = 0 To selected_rows.Length - 1
                Dim selected_row As Integer = selected_rows(i)

                If selected_row >= 0 Then
                    Dim id_employee As String = GVEmployee.GetRowCellValue(selected_row, "id_employee").ToString
                    Dim employee_code As String = GVEmployee.GetRowCellValue(selected_row, "employee_code").ToString
                    Dim employee_name As String = GVEmployee.GetRowCellValue(selected_row, "employee_name").ToString
                    Dim id_departement As String = GVEmployee.GetRowCellValue(selected_row, "id_departement").ToString
                    Dim departement As String = GVEmployee.GetRowCellValue(selected_row, "departement").ToString
                    Dim total_workdays As Decimal = GVEmployee.GetRowCellValue(selected_row, "total_workdays")
                    Dim employee_position As String = GVEmployee.GetRowCellValue(selected_row, "employee_position").ToString
                    Dim id_employee_level As String = GVEmployee.GetRowCellValue(selected_row, "id_employee_level").ToString
                    Dim employee_level As String = GVEmployee.GetRowCellValue(selected_row, "employee_level").ToString
                    Dim id_employee_status As String = GVEmployee.GetRowCellValue(selected_row, "id_employee_status").ToString
                    Dim employee_status As String = GVEmployee.GetRowCellValue(selected_row, "employee_status").ToString
                    Dim id_employee_salary As String = GVEmployee.GetRowCellValue(selected_row, "id_employee_salary").ToString
                    Dim basic_salary_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "basic_salary_current")
                    Dim allow_job_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "allow_job_current")
                    Dim allow_meal_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "allow_meal_current")
                    Dim allow_trans_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "allow_trans_current")
                    Dim allow_house_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "allow_house_current")
                    Dim allow_car_current As Decimal = GVEmployee.GetRowCellValue(selected_row, "allow_car_current")
                    Dim total_salary_current As Decimal = basic_salary_current + allow_job_current + allow_meal_current + allow_trans_current + allow_house_current + allow_car_current

                    data.Rows.Add(id_employee, employee_code, employee_name, id_departement, departement, total_workdays, employee_position, id_employee_level, employee_level, id_employee_status, employee_status, id_employee_salary, basic_salary_current, allow_job_current, allow_meal_current, allow_trans_current, allow_house_current, allow_car_current, total_salary_current, 0, 0, 0, 0, 0, 0, If(id_employee_salary = "0", "0.00%", "-100.00%"), "50.00%", "50.00%", 0)
                End If
            Next

            FormProposeEmpSalaryDet.GVEmployee.BestFitColumns()

            FormProposeEmpSalaryDet.load_contract()

            Close()
        Else
            errorCustom("No employee selected.")

            GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"
        End If
    End Sub
End Class