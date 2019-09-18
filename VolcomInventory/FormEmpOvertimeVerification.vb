Public Class FormEmpOvertimeVerification
    Public id_ot As String = ""

    Private Sub FormEmpOvertimeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEType2, "SELECT id_ot_conversion AS id_type, conversion_type AS type FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupQuery(SLUEPayroll, "SELECT id_payroll, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1 ORDER BY periode_end DESC", "id_payroll", "periode", "id_payroll")

        'overtime
        Dim query_ot As String = "
            SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, ot.id_departement, departement.departement, ot.number, ot.ot_note, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_ot AS ot
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
            LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
            WHERE ot.id_ot = " + id_ot + "
        "

        Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

        TENumber.EditValue = data_ot.Rows(0)("number").ToString
        LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)
        TEDepartement.EditValue = data_ot.Rows(0)("departement").ToString
        TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
        TECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString
        MEOvertimeNote.EditValue = data_ot.Rows(0)("ot_note").ToString

        LUEOvertimeType.ReadOnly = True

        RISLUEType.ReadOnly = True
        RISLUEType2.ReadOnly = True

        'propose
        Dim query_pro As String = "
            SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, ot_det.conversion_type, ot_det.is_day_off, DATE_FORMAT(ot_det.ot_start_time, '%d %M %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%d %M %Y %H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
            WHERE ot_det.id_ot = " + id_ot + "
            ORDER BY ot_det.ot_date ASC, departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC
        "

        Dim data_pro As DataTable = execute_query(query_pro, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_pro

        GVEmployee.BestFitColumns()

        'limit date search
        DESearch.Properties.MinValue = Date.Parse(data_pro.Rows(0)("ot_date"))
        DESearch.Properties.MaxValue = Date.Parse(data_pro.Rows(data_pro.Rows.Count - 1)("ot_date"))
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        change_payroll()

        Dim ot_min_staff As Integer = get_opt_emp_field("ot_min_staff")
        Dim ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

        GVEmployee.ActiveFilterString = "[ot_date] = '" + Date.Parse(DESearch.EditValue.ToString).ToString("dd MMMM yyyy") + "'"

        GVAttendance.ActiveFilterString = ""

        Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim id_departement As String = execute_query("SELECT id_departement FROM tb_ot WHERE id_ot = " + id_ot, 0, True, "", "", "", "")

        'attendance
        Dim query_att As String = "
            SELECT * FROM (
                SELECT sch.id_employee, emp.id_departement, dep_sub.id_departement_sub, dep.departement, sch.date, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_employee_status, sts.employee_status, IF(salary.salary > (dep_sub.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)), '2', '1') AS to_salary, IF((SELECT to_salary) = 1, 1, 2) AS conversion_type, IF((sch.id_schedule_type = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + date_search.ToString + "' AND id_religion IN (0, IF(dep.is_store = 1, 0, emp.id_religion))) IS NULL), 2, 1) AS is_day_off, IF(sch.id_schedule_type = '1', MIN(at_in.datetime), MIN(at_in_hol.datetime)) AS start_work, IF(sch.id_schedule_type = '1', MAX(at_out.datetime), MAX(at_out_hol.datetime)) AS end_work, 0.0 AS break_hours, '' AS start_work_ot, '' AS end_work_ot, 0.0 AS total_hours, 'no' AS is_valid, sch.id_schedule_type, sch.in, sch.out, 2 AS ot_potention
                FROM tb_emp_schedule AS sch
                LEFT JOIN tb_m_employee AS emp ON emp.id_employee = sch.id_employee
                LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement 
                LEFT JOIN tb_m_departement_sub AS dep_sub ON IFNULL(emp.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = emp.id_departement LIMIT 1)) = dep_sub.id_departement_sub
                LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                LEFT JOIN (
                    SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                    FROM tb_m_employee
                ) AS salary ON emp.id_employee = salary.id_employee
                LEFT JOIN tb_emp_attn AS at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 1 DAY) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
                LEFT JOIN tb_emp_attn AS at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                LEFT JOIN tb_emp_attn AS at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.date AND at_in_hol.type_log = 1 
                LEFT JOIN tb_emp_attn AS at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.date AND at_out_hol.type_log = 2
                WHERE sch.date = '" + date_search.ToString + "' AND emp.id_departement = " + id_departement + "
                GROUP BY sch.id_schedule
            ) AS tb
            WHERE tb.start_work IS NOT NULL AND tb.end_work IS NOT NULL
        "

        Dim data_att As DataTable = execute_query(query_att, -1, True, "", "", "", "")

        GCAttendance.DataSource = data_att

        'verification
        For i = 1 To GVAttendance.RowCount - 1
            If GVAttendance.IsValidRowHandle(i) Then
                For j = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(j) Then
                        Dim ot_min As Integer = If(GVAttendance.GetRowCellValue(i, "to_salary").ToString = "1", ot_min_staff, ot_min_spv)

                        Dim after_work As Decimal = 0.0
                        Dim before_work As Decimal = 0.0

                        Dim after_work_ot As Decimal = 0.0
                        Dim before_work_ot As Decimal = 0.0

                        Dim work_hours As Decimal = 0.0

                        Dim overtime_in As DateTime = New DateTime
                        Dim overtime_out As DateTime = New DateTime

                        Dim schedule_in As DateTime = New DateTime
                        Dim schedule_out As DateTime = New DateTime

                        Dim start_work As DateTime = New DateTime
                        Dim end_work As DateTime = New DateTime

                        Try
                            overtime_in = DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_start_time").ToString)
                            overtime_out = DateTime.Parse(GVEmployee.GetRowCellValue(j, "ot_end_time").ToString)
                        Catch ex As Exception
                        End Try

                        Try
                            schedule_in = DateTime.Parse(GVAttendance.GetRowCellValue(i, "in").ToString)
                            schedule_out = DateTime.Parse(GVAttendance.GetRowCellValue(i, "out").ToString)
                        Catch ex As Exception
                        End Try

                        Try
                            start_work = DateTime.Parse(GVAttendance.GetRowCellValue(i, "start_work").ToString)
                            end_work = DateTime.Parse(GVAttendance.GetRowCellValue(i, "end_work").ToString)
                        Catch ex As Exception
                        End Try

                        after_work = (end_work - schedule_out).TotalHours
                        before_work = (schedule_in - start_work).TotalHours

                        after_work_ot = (end_work - overtime_in).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")
                        before_work_ot = (overtime_out - start_work).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                        work_hours = (end_work - start_work).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                        If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                            If GVAttendance.GetRowCellValue(i, "id_schedule_type").ToString = "1" Then
                                If after_work >= ot_min And after_work_ot >= ot_min Then
                                    GVAttendance.SetRowCellValue(i, "is_valid", "yes")

                                    Dim total_hours As Decimal = Math.Floor(after_work_ot / 0.5) * 0.5

                                    GVAttendance.SetRowCellValue(i, "start_work_ot", GVEmployee.GetRowCellValue(j, "ot_start_time"))
                                    GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work"))
                                    GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                    GVAttendance.SetRowCellValue(i, "total_hours", total_hours)
                                ElseIf before_work >= ot_min And before_work_ot >= ot_min Then
                                    GVAttendance.SetRowCellValue(i, "is_valid", "yes")

                                    Dim total_hours As Decimal = Math.Floor(before_work_ot / 0.5) * 0.5

                                    GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work"))
                                    GVAttendance.SetRowCellValue(i, "end_work_ot", GVEmployee.GetRowCellValue(j, "ot_end_time"))
                                    GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                    GVAttendance.SetRowCellValue(i, "total_hours", total_hours)
                                End If
                            Else
                                GVAttendance.SetRowCellValue(i, "is_valid", "yes")

                                Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                                GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work"))
                                GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work"))
                                GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                GVAttendance.SetRowCellValue(i, "total_hours", total_hours)
                            End If
                        End If

                        If after_work >= ot_min And after_work_ot >= ot_min Then
                            GVAttendance.SetRowCellValue(i, "ot_potention", "1")
                        ElseIf before_work >= ot_min And before_work_ot >= ot_min Then
                            GVAttendance.SetRowCellValue(i, "ot_potention", "1")
                        End If
                    End If
                Next
            End If
        Next

        GVAttendance.BestFitColumns()
    End Sub

    Private Sub FormEmpOvertimeVerification_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpOvertimeVerification_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GroupControl1.Width = Convert.ToInt32(Me.Width * 0.5) - 10
        GroupControl2.Width = Convert.ToInt32(Me.Width * 0.5) - 10
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        For i = 0 To GVAttendance.RowCount - 1
            If GVAttendance.IsValidRowHandle(i) Then
                If GVAttendance.GetRowCellValue(i, "is_valid").ToString = "yes" Then
                    Dim id_ot_det As String = "NULL"
                    Dim id_employee As String = GVAttendance.GetRowCellValue(i, "id_employee").ToString
                    Dim id_departement As String = GVAttendance.GetRowCellValue(i, "id_departement").ToString
                    Dim id_departement_sub As String = GVAttendance.GetRowCellValue(i, "id_departement_sub").ToString
                    Dim employee_position As String = GVAttendance.GetRowCellValue(i, "employee_position").ToString
                    Dim id_employee_status As String = GVAttendance.GetRowCellValue(i, "id_employee_status").ToString
                    Dim only_dp As String = GVAttendance.GetRowCellValue(i, "only_dp").ToString
                    Dim conversion_type As String = GVAttendance.GetRowCellValue(i, "conversion_type").ToString
                    Dim is_day_off As String = "NULL"
                    Dim start_work As String = Date.Parse(GVAttendance.GetRowCellValue(i, "start_work_ot").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim end_work As String = Date.Parse(GVAttendance.GetRowCellValue(i, "end_work_ot").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    Dim break_hours As String = GVAttendance.GetRowCellValue(i, "break_hours").ToString
                    Dim overtime_hours As String = GVAttendance.GetRowCellValue(i, "total_hours").ToString

                    Dim query As String = "
                        INSERT INTO tb_ot_det (id_ot_det, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, only_dp, conversion_type, is_day_off, start_work, end_work, break_hours, overtime_hours, id_payroll) VALUES (NULL, " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + employee_position + "', " + id_employee_status + ", " + only_dp + ", " + conversion_type + ", NULL, '" + start_work + "', '" + end_work + "', " + decimalSQL(break_hours) + ", " + decimalSQL(overtime_hours) + ")
                    "
                End If
            End If
        Next
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Dispose()
    End Sub

    Sub change_payroll()
        Dim id_payroll As String = execute_query("SELECT id_payroll FROM tb_emp_payroll WHERE id_payroll_type = 1 AND '" + Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd") + "' BETWEEN ot_periode_start AND ot_periode_end", 0, True, "", "", "", "")

        SLUEPayroll.EditValue = id_payroll
    End Sub
End Class