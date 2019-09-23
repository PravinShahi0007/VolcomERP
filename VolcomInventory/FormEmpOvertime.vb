Public Class FormEmpOvertime
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()

        If is_hrd = "-1" Then
            Text = "Propose Overtime"

            GCEValid.Visible = False
            GBEActual.Visible = False
            GCECheckStatus.Visible = False

            GCIsDayOff.Visible = False
        Else
            Text = "Overtime Management"
        End If
    End Sub

    Sub form_load()
        DEStart.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-1")
        DEUntil.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-" + Date.DaysInMonth(Now.Year, Now.Month))

        view_departement()
        view_employee()
    End Sub

    Sub load_overtime(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot.ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type.Contains("id_det") Then
            where_date = "AND ot_det.id_ot_det IN (" + type.Replace("id_det", "") + ")"
        ElseIf type.Contains("id_ot") Then
            where_date = "AND ot.id_ot IN (" + type.Replace("id_ot", "") + ")"
        End If

        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot_det.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try


            Dim where_employee As String = ""

            Try
                If Not SLUEEmployee.EditValue.ToString = "0" Then
                    where_employee = "AND ot_det.id_employee = " + SLUEEmployee.EditValue.ToString
                End If
            Catch ex As Exception
            End Try


            Dim query As String = "
                SELECT ot.id_ot, ot_det.id_ot_det, ot_det.id_departement, departement.departement, departement.is_store, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp, IF(ot_det.conversion_type = 1, 'Salary', 'DP') AS conversion_type, IF(ot_det.is_valid = 1, 'Yes', IF(ot_det.is_valid = 2, 'No', '-')) AS valid, ot.number, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot_type.is_point_ho, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%d %M %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%d %M %Y %H:%i:%s') AS ot_end_time, ot.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot.ot_start_time, ot.ot_end_time) / 60) - ot.ot_break, 1) AS total_hours, DATE_FORMAT(ot_det.start_work, '%d %M %Y %H:%i:%s') AS ot_det_start_time, DATE_FORMAT(ot_det.end_work, '%d %M %Y %H:%i:%s') AS ot_det_end_time, ot_det.break_hours AS ot_det_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.start_work, ot_det.end_work) / 60) - ot_det.break_hours, 1) AS ot_det_total_hours, ot_det.overtime_hours AS ot_det_overtime_hours, IF((IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1)))) = 1, 'Yes', 'No') AS is_day_off, NULL AS point, ot.ot_note, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, emp.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                LEFT JOIN (
                    SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                    FROM tb_m_employee
                ) AS salary ON ot_det.id_employee = salary.id_employee
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS emp ON ot.created_by = emp.id_employee
                WHERE 1 " + where_date + " " + where_departement + " " + where_employee + "
                ORDER BY ot_det.id_departement DESC, employee.employee_name ASC, ot.ot_date DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCEmployee.DataSource = data

            calculatePoint()

            GVEmployee.BestFitColumns()
        Else
            Dim whereDept As String = If(is_hrd = "-1", "AND ot.id_departement = " + id_departement_user, "")

            Dim query As String = "
                SELECT ot.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot.id_departement, departement.departement, CONCAT('- ', GROUP_CONCAT(DISTINCT DATE_FORMAT(ot_det.ot_date, '%d %M %Y') SEPARATOR '\n- ')) AS ot_date, ot.number, ot.ot_note, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE 1 " + whereDept + " 
                GROUP BY ot.id_ot
                ORDER BY ot.number DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCOvertime.DataSource = data

            GVOvertime.BestFitColumns()
        End If
    End Sub

    Sub load_verification(ByVal type As String)
        Dim whereDept As String = If(is_hrd = "-1", "AND ot_verification.id_departement = " + id_departement_user, "")

        Dim query As String = "
            SELECT ot_verification.id_ot_verification, ot_verification.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot_verification.id_departement, departement.departement, DATE_FORMAT(ot_verification.ot_date, '%d %M %Y') AS ot_date, ot.number, ot.ot_note, ot_verification.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_ot_verification AS ot_verification
            LEFT JOIN tb_ot AS ot ON ot_verification.id_ot = ot.id_ot
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot_verification.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_report_status AS report_status ON ot_verification.id_report_status = report_status.id_report_status
            LEFT JOIN tb_m_employee AS employee ON ot_verification.created_by = employee.id_employee
            WHERE 1 " + whereDept + " 
            ORDER BY ot.number DESC, ot_verification.ot_date ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCVerification.DataSource = data

        GVVerification.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertime_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormEmpOvertime_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBViewCA_Click(sender As Object, e As EventArgs) Handles SBViewCA.Click
        load_overtime("created_at")
        load_verification("created_at")
    End Sub

    Private Sub SBViewOD_Click(sender As Object, e As EventArgs) Handles SBViewOD.Click
        load_overtime("ot_date")
        load_verification("ot_date")
    End Sub

    Sub view_departement()
        Dim query As String = ""

        If is_hrd = "-1" Then
            query = "SELECT id_departement, departement FROM tb_m_departement a WHERE a.id_departement = " + id_departement_user + ""
        Else
            query = "SELECT 0 AS id_departement, 'All departement' AS departement UNION (SELECT id_departement, departement FROM tb_m_departement a ORDER BY a.departement ASC)"
        End If

        viewSearchLookupQuery(SLUEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_employee()
        Dim where_department As String = ""

        Try
            If Not SLUEDepartement.EditValue.ToString = "0" Then
                where_department = "AND e.id_departement = " + SLUEDepartement.EditValue.ToString
            End If
        Catch ex As Exception
        End Try


        Dim query As String = "SELECT 0 AS id_employee, '' AS employee_code, 'All employee' AS employee_name UNION (SELECT id_employee, employee_code, employee_name FROM tb_m_employee e WHERE 1 " + where_department + " ORDER BY e.departement ASC, e.id_employee_level ASC)"

        viewSearchLookupQuery(SLUEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub SLUEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDepartement.EditValueChanged
        view_employee()
    End Sub

    Private Sub XtraTabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl.SelectedPageChanged
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            PCEmployee.Visible = True
        Else
            PCEmployee.Visible = False
        End If
    End Sub

    Private Sub GVOvertime_DoubleClick(sender As Object, e As EventArgs) Handles GVOvertime.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_hrd = is_hrd

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_hrd = is_hrd

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs)
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Try
                If GVEmployee.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                    FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_hrd = is_hrd

                    FormEmpOvertimeDet.ShowDialog()
                Else
                    errorCustom("Overtime must be approved first.")
                End If
            Catch ex As Exception
            End Try
        Else
            Try
                If GVOvertime.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                    FormEmpOvertimeDet.id = GVOvertime.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_hrd = is_hrd

                    FormEmpOvertimeDet.ShowDialog()
                Else
                    errorCustom("Overtime must be approved first.")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FormEmpOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculatePoint()
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                Dim overtime_hours As String = GVEmployee.GetRowCellValue(i, "ot_det_overtime_hours").ToString

                If Not overtime_hours = "" Then
                    Dim is_day_off As String = If(GVEmployee.GetRowCellValue(i, "is_day_off").ToString = "Yes", "1", "2")
                    Dim is_store As String = GVEmployee.GetRowCellValue(i, "is_store").ToString

                    If GVEmployee.GetRowCellValue(i, "is_point_ho").ToString = "1" Then
                        is_store = "2"
                    End If

                    GVEmployee.SetRowCellValue(i, "point", FormEmpOvertimeDet.calc_point(Decimal.Parse(overtime_hours), is_day_off, is_store))
                Else
                    GVEmployee.SetRowCellValue(i, "point", "")
                End If

                Dim only_dp As String = GVEmployee.GetRowCellValue(i, "only_dp").ToString

                If only_dp = "yes" Then
                    GVEmployee.SetRowCellValue(i, "point", overtime_hours)
                End If
            End If
        Next
    End Sub

    Private Sub SBVerification_Click(sender As Object, e As EventArgs) Handles SBVerification.Click
        Try
            FormEmpOvertimeVerification.id_ot = GVOvertime.GetFocusedRowCellValue("id_ot").ToString

            FormEmpOvertimeVerification.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVVerification_DoubleClick(sender As Object, e As EventArgs) Handles GVVerification.DoubleClick
        Try
            FormEmpOvertimeVerification.id = GVVerification.GetFocusedRowCellValue("id_ot_verification").ToString
            FormEmpOvertimeVerification.id_ot = GVVerification.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeVerification.is_view = "1"

            FormEmpOvertimeVerification.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class