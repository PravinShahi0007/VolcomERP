Public Class FormEmpOvertime
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()

        If is_hrd = "-1" Then
            Text = "Propose Overtime"
        Else
            Text = "Overtime Management"
        End If
    End Sub

    Sub form_load()
        DEStart.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-1")
        DEUntil.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-" + Date.DaysInMonth(Now.Year, Now.Month).ToString)

        view_departement()
        view_employee()
        view_conversion_type()
    End Sub

    Sub load_overtime(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot.id_ot IN (SELECT id_ot FROM tb_ot_det WHERE ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "')"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
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
                SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, ot_det.conversion_type, ot.id_ot, ot.number, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, ot_det.is_day_off, DATE_FORMAT(ot_det.ot_start_time, '%d %M %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%d %M %Y %H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours, ot.ot_note, ot.id_report_status, report_status.report_status, created_by.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS created_by ON ot.created_by = created_by.id_employee
                WHERE 1 " + where_date + " " + where_departement + " " + where_employee + "
                ORDER BY departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC, ot.number DESC, ot_det.ot_date ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCProposeEmployee.DataSource = data

            GVProposeEmployee.BestFitColumns()
        Else
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT ot.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot.id_departement, departement.departement, CONCAT('- ', GROUP_CONCAT(DISTINCT DATE_FORMAT(ot_det.ot_date, '%d %M %Y') SEPARATOR '\n- ')) AS ot_date, ot.number, ot.ot_note, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE 1 " + where_date + " " + where_departement + " 
                GROUP BY ot.id_ot
                ORDER BY ot.number DESC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCOvertime.DataSource = data

            GVOvertime.BestFitColumns()
        End If
    End Sub

    Sub load_verification(ByVal type As String)
        Dim where_date As String = ""

        If type = "ot_date" Then
            where_date = "AND ot_verification.ot_date BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        ElseIf type = "created_at" Then
            where_date = "AND DATE(ot_verification.created_at) BETWEEN '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        End If

        If XTCVerification.SelectedTabPage.Name = "XTPByEmployeeVerification" Then
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND employee.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim where_employee As String = ""

            Try
                If Not SLUEEmployee.EditValue.ToString = "0" Then
                    where_employee = "AND ot_verification_det.id_employee = " + SLUEEmployee.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT ot_verification_det.id_employee, ot_verification_det.id_departement, ot_verification_det.id_departement_sub, departement.departement, employee.employee_code, employee.employee_name, ot_verification_det.employee_position, ot_verification_det.id_employee_status, employee_status.employee_status, ot_verification_det.to_salary, ot_verification_det.conversion_type, ot_verification.id_ot_verification, ot.number, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, DATE_FORMAT(ot_verification.ot_date, '%d %M %Y') AS ot_date, ot_verification_det.is_day_off, DATE_FORMAT(ot_verification_det.start_work_ot, '%d %M %Y %H:%i:%s') AS start_work_ot, DATE_FORMAT(ot_verification_det.end_work_ot, '%d %M %Y %H:%i:%s') AS end_work_ot, ot_verification_det.break_hours, ot_verification_det.total_hours, ot.ot_note, ot_verification.id_report_status, report_status.report_status, created_by.employee_name AS created_by, DATE_FORMAT(ot_verification.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_verification_det AS ot_verification_det
                LEFT JOIN tb_ot_verification AS ot_verification ON ot_verification_det.id_ot_verification = ot_verification.id_ot_verification
                LEFT JOIN tb_ot AS ot ON ot_verification.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_employee AS employee ON ot_verification_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_verification_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_verification_det.id_employee_status = employee_status.id_employee_status
                LEFT JOIN tb_lookup_report_status AS report_status ON ot_verification.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS created_by ON ot_verification.created_by = created_by.id_employee
                WHERE 1 " + where_date + " " + where_departement + " " + where_employee + "
                ORDER BY departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC, ot.number DESC, ot_verification.ot_date ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCVerification.DataSource = data

            GVVerification.BestFitColumns()
        Else
            Dim where_departement As String = ""

            Try
                If Not SLUEDepartement.EditValue.ToString = "0" Then
                    where_departement = "AND ot_verification.id_departement = " + SLUEDepartement.EditValue.ToString
                End If
            Catch ex As Exception
            End Try

            Dim query As String = "
                SELECT ot_verification.id_ot_verification, ot_verification.id_ot, ot.id_ot_type, CONCAT(IF(ot_type.is_event = 1, 'Event ', ''), ot_type.ot_type) AS ot_type, ot_verification.id_departement, departement.departement, DATE_FORMAT(ot_verification.ot_date, '%d %M %Y') AS ot_date, ot.number, ot.ot_note, ot_verification.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot_verification AS ot_verification
                LEFT JOIN tb_ot AS ot ON ot_verification.id_ot = ot.id_ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot_verification.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot_verification.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot_verification.created_by = employee.id_employee
                WHERE 1 " + where_date + " " + where_departement + " 
                ORDER BY ot.number DESC, ot_verification.ot_date ASC
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCVerification.DataSource = data

            GVVerification.BestFitColumns()
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
        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            load_overtime("created_at")
        Else
            load_verification("created_at")
        End If
    End Sub

    Private Sub SBViewOD_Click(sender As Object, e As EventArgs) Handles SBViewOD.Click
        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            load_overtime("ot_date")
        Else
            load_verification("ot_date")
        End If
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

    Sub view_conversion_type()
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary FROM tb_lookup_ot_conversion", 0, "type", "id_type")
    End Sub

    Private Sub SLUEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDepartement.EditValueChanged
        view_employee()
    End Sub

    Private Sub XTCPropose_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPropose.SelectedPageChanged
        If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
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

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVProposeEmployee.DoubleClick
        Try
            FormEmpOvertimeDet.id = GVProposeEmployee.GetFocusedRowCellValue("id_ot")
            FormEmpOvertimeDet.is_hrd = is_hrd

            FormEmpOvertimeDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormEmpOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculatePoint()
        For i = 0 To GVProposeEmployee.RowCount - 1
            If GVProposeEmployee.IsValidRowHandle(i) Then
                Dim overtime_hours As String = GVProposeEmployee.GetRowCellValue(i, "ot_det_overtime_hours").ToString

                If Not overtime_hours = "" Then
                    Dim is_day_off As String = If(GVProposeEmployee.GetRowCellValue(i, "is_day_off").ToString = "Yes", "1", "2")
                    Dim is_store As String = GVProposeEmployee.GetRowCellValue(i, "is_store").ToString

                    If GVProposeEmployee.GetRowCellValue(i, "is_point_ho").ToString = "1" Then
                        is_store = "2"
                    End If

                    GVProposeEmployee.SetRowCellValue(i, "point", FormEmpOvertimeVerification.calc_point(Decimal.Parse(overtime_hours), is_day_off, is_store))
                Else
                    GVProposeEmployee.SetRowCellValue(i, "point", "")
                End If

                Dim only_dp As String = GVProposeEmployee.GetRowCellValue(i, "only_dp").ToString

                If only_dp = "yes" Then
                    GVProposeEmployee.SetRowCellValue(i, "point", overtime_hours)
                End If
            End If
        Next
    End Sub

    Private Sub SBVerification_Click(sender As Object, e As EventArgs) Handles SBVerification.Click
        Try
            FormEmpOvertimeVerification.id = "0"
            FormEmpOvertimeVerification.id_ot = GVOvertime.GetFocusedRowCellValue("id_ot").ToString
            FormEmpOvertimeVerification.is_view = "0"

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

    Private Sub XTCType_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCType.SelectedPageChanged
        If XTCType.SelectedTabPage.Name = "XTPPropose" Then
            If XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
                PCEmployee.Visible = True
            Else
                PCEmployee.Visible = False
            End If
        Else
            PCEmployee.Visible = False
        End If
    End Sub
End Class