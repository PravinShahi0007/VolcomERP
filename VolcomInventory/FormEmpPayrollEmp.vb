Public Class FormEmpPayrollEmp
    Dim id_payroll As String = "-1"
    Dim id_payroll_type As String = "-1"

    Private Sub FormEmpPayrollEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        id_payroll_type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        If id_payroll_type = "1" Then
            query = "
                SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3
            "
        ElseIf id_payroll_type = "2" Then 'thr
            query = "
                SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "3" Then 'bonus
            query = "
                SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "4" Then 'dw
            query = "
                SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status = 3
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"

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

    Sub pick()
        GVEmployee.ApplyFindFilter("")

        If GVEmployee.SelectedRowsCount > 0 Then
            Dim query As String = "INSERT INTO tb_emp_payroll_det(id_payroll, id_employee,id_salary, workdays, actual_workdays) VALUES "

            Dim selected_rows As Integer() = GVEmployee.GetSelectedRows()

            For i = 0 To selected_rows.Length - 1
                Dim selected_row As Integer = selected_rows(i)

                If selected_row >= 0 Then
                    Dim id_employee As String = GVEmployee.GetRowCellValue(selected_row, "id_employee").ToString
                    Dim id_salary As String = GVEmployee.GetRowCellValue(selected_row, "id_employee_salary").ToString
                    Dim workdays As String = GVEmployee.GetRowCellValue(selected_row, "total_workdays").ToString
                    Dim actual_workdays As String = GVEmployee.GetRowCellValue(selected_row, "actual_workdays").ToString

                    query += "('" & id_payroll & "', '" & id_employee & "', '" & id_salary & "', '" & workdays & "', '" & actual_workdays & "'), "
                End If
            Next

            query = query.Substring(0, query.Length - 2)

            execute_non_query(query, True, "", "", "", "")
        Else
            errorCustom("No employee selected.")

            GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"
        End If

        FormEmpPayroll.load_payroll_detail()

        Close()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        If id_payroll_type = "1" Then
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3
            "
        ElseIf id_payroll_type = "2" Then 'thr
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "3" Then 'bonus
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "4" Then 'dw
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_start + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status = 3
            "
        End If

        execute_non_query(query, True, "", "", "", "")

        FormEmpPayroll.load_payroll_detail()

        Close()
    End Sub
End Class