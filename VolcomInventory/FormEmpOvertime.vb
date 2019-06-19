Public Class FormEmpOvertime
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()

        If is_hrd = "-1" Then
            Text = "Propose Overtime"

            PanelControlCheck.Visible = False

            GCCheckStatus.Visible = False

            GCEValid.Visible = False
            GBEActual.Visible = False
            GCECheckStatus.Visible = False
        Else
            Text = "Overtime Management"
        End If
    End Sub

    Sub form_load()
        DEStart.EditValue = Now
        DEUntil.EditValue = Now

        view_departement()
        view_employee()
    End Sub

    Sub load_overtime(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot.ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Dim where_departement As String = ""

            If Not SLUEDepartement.EditValue.ToString = "0" Then
                where_departement = "AND ot_det.id_departement = " + SLUEDepartement.EditValue.ToString
            End If

            Dim where_employee As String = ""

            If Not SLUEEmployee.EditValue.ToString = "0" Then
                where_employee = "AND ot_det.id_employee = " + SLUEEmployee.EditValue.ToString
            End If

            Dim query As String = "
                SELECT ot.id_ot, ot_det.id_departement, departement.departement, departement.is_store, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, IF(ot_det.conversion_type = 1, 'Salary', 'DP') AS conversion_type, IF(ot_det.is_valid = 1, 'Yes', IF(ot_det.is_valid = 2, 'No', '-')) AS valid, ot.number, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot.ot_date, '%d %b %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%d %b %Y %l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%d %b %Y %l:%i:%s %p') AS ot_end_time, ot.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot.ot_start_time, ot.ot_end_time) / 60) - ot.ot_break, 1) AS total_hours, DATE_FORMAT(ot_det.start_work, '%d %b %Y %l:%i:%s %p') AS ot_det_start_time, DATE_FORMAT(ot_det.end_work, '%d %b %Y %l:%i:%s %p') AS ot_det_end_time, ot_det.break_hours AS ot_det_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.start_work, ot_det.end_work) / 60) - ot_det.break_hours, 1) AS ot_det_total_hours, (IF((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot.ot_date) = 1, 2, 1)) AS is_day_off, NULL AS point, ot.ot_note, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, emp.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %b %Y %l:%i:%s %p') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
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
            Dim whereDept As String = If(is_hrd = "-1", "AND (SELECT COUNT(id_employee) FROM tb_ot_det WHERE id_ot = ot.id_ot AND id_departement = " + id_departement_user + ") > 0", "")

            Dim query As String = "
                SELECT ot.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot.ot_date, '%d %b %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%d %b %Y %l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%d %b %Y %l:%i:%s %p') AS ot_end_time, ot.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot.ot_start_time, ot.ot_end_time) / 60) - ot.ot_break, 1) AS total_hours, ot.ot_note, ot.id_payroll, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, ot.number, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %b %Y %l:%i:%s %p') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE 1 " + whereDept + " " + where_date + "
                ORDER BY ot.number DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCOvertime.DataSource = data

            GVOvertime.BestFitColumns()
        End If
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
    End Sub

    Private Sub SBViewOD_Click(sender As Object, e As EventArgs) Handles SBViewOD.Click
        load_overtime("ot_date")
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

        If Not SLUEDepartement.EditValue.ToString = "0" Then
            where_department = "AND e.id_departement = " + SLUEDepartement.EditValue.ToString
        End If

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
            FormEmpOvertimeDet.is_check = "-1"

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_hrd = is_hrd
            FormEmpOvertimeDet.is_check = "-1"

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs) Handles SBCheck.Click
        If XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
            Try
                If GVEmployee.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                    FormEmpOvertimeDet.id = GVEmployee.GetFocusedRowCellValue("id_ot")
                    FormEmpOvertimeDet.is_hrd = is_hrd
                    FormEmpOvertimeDet.is_check = "1"

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
                    FormEmpOvertimeDet.is_check = "1"

                    FormEmpOvertimeDet.ShowDialog()
                Else
                    errorCustom("Overtime must be approved first.")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        If DEStart.EditValue > DEUntil.EditValue Then
            DEUntil.EditValue = DEStart.EditValue
        End If
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        If DEStart.EditValue > DEUntil.EditValue Then
            DEStart.EditValue = DEUntil.EditValue
        End If
    End Sub

    Private Sub FormEmpOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculatePoint()
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                Dim ot_det_start_time As String = GVEmployee.GetRowCellValue(i, "ot_det_start_time").ToString
                Dim ot_det_end_time As String = GVEmployee.GetRowCellValue(i, "ot_det_end_time").ToString

                If Not ot_det_start_time = "" And Not ot_det_end_time = "" Then
                    Dim total_hours As Decimal = GVEmployee.GetRowCellValue(i, "ot_det_total_hours")
                    Dim is_day_off As String = GVEmployee.GetRowCellValue(i, "is_day_off").ToString
                    Dim is_store As String = GVEmployee.GetRowCellValue(i, "is_day_off").ToString

                    GVEmployee.SetRowCellValue(i, "point", FormEmpOvertimeDet.calc_point(total_hours, is_day_off, is_store))
                Else
                    GVEmployee.SetRowCellValue(i, "point", "")
                End If

                Dim conversion_type As String = GVEmployee.GetRowCellValue(i, "conversion_type").ToString

                If conversion_type = "2" Then
                    GVEmployee.SetRowCellValue(i, "point", "")
                End If
            End If
        Next
    End Sub
End Class