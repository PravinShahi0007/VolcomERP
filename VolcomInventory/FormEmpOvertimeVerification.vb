Public Class FormEmpOvertimeVerification
    Public id As String = "0"
    Public id_ot As String = ""
    Public is_view As String = "0"
    Public ot_date As Date = Nothing

    Private Sub FormEmpOvertimeVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type, is_point_ho FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEType2, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
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

        'controls
        SBSave.Enabled = False
        SBPrint.Enabled = False
        SBMark.Enabled = False

        If is_view = "1" Then
            DESearch.ReadOnly = True
            SBView.Enabled = False
        End If

        'load
        If Not ot_date = Nothing Then
            Dim data_vr As DataTable = execute_query("SELECT ot_date FROM tb_ot_verification WHERE id_ot_verification = '" + id + "'", -1, True, "", "", "", "")

            DESearch.EditValue = ot_date

            SBView_Click(SBView, New EventArgs)
        End If
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        id = execute_query("SELECT IFNULL((SELECT id_ot_verification FROM tb_ot_verification WHERE id_ot = " + id_ot + " AND ot_date = '" + Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd") + "'), 0) AS id_ot_verification", 0, True, "", "", "", "")

        GVEmployee.ActiveFilterString = "[ot_date] = '" + Date.Parse(DESearch.EditValue.ToString).ToString("dd MMMM yyyy") + "'"

        GVAttendance.ActiveFilterString = ""

        If id = 0 Then
            change_payroll()

            Dim ot_min_staff As Integer = get_opt_emp_field("ot_min_staff")
            Dim ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

            Dim date_search As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim id_departement As String = execute_query("SELECT id_departement FROM tb_ot WHERE id_ot = " + id_ot, 0, True, "", "", "", "")

            'attendance
            Dim query_att As String = "
                SELECT * FROM (
                    SELECT sch.id_employee, emp.id_departement, dep_sub.id_departement_sub, dep.departement, sch.date, emp.employee_code, emp.employee_name, emp.employee_position, emp.id_employee_status, sts.employee_status, IF(salary.salary > (dep_sub.ump + (SELECT ot_ump_conversion FROM tb_opt_emp LIMIT 1)), '2', '1') AS to_salary, IF((SELECT to_salary) = 1, 1, 2) AS conversion_type, IF(" + LUEOvertimeType.GetColumnValue("is_point_ho").ToString() + " = 1, 2, dep.is_store) AS is_store, IF((sch.id_schedule_type = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = '" + date_search.ToString + "' AND id_religion IN (0, IF(dep.is_store = 1, 0, emp.id_religion))) IS NULL), 2, 1) AS is_day_off, DATE_FORMAT(IF(sch.id_schedule_type = '1', MIN(at_in.datetime), MIN(at_in_hol.datetime)), '%d %M %Y %H:%i:%s') AS start_work_att, DATE_FORMAT(IF(sch.id_schedule_type = '1', MAX(at_out.datetime), MAX(at_out_hol.datetime)), '%d %M %Y %H:%i:%s') AS end_work_att, '' AS start_work_ot, '' AS end_work_ot, 0.0 AS break_hours, 0.0 AS total_hours, 0.0 AS point_ot, 'no' AS is_valid, sch.id_schedule_type, DATE_FORMAT(sch.in, '%d %M %Y %H:%i:%s') AS `in`, DATE_FORMAT(sch.out, '%d %M %Y %H:%i:%s') AS `out`, 2 AS ot_potention
                    FROM tb_emp_schedule AS sch
                    LEFT JOIN tb_m_employee AS emp ON emp.id_employee = sch.id_employee
                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement 
                    LEFT JOIN tb_m_departement_sub AS dep_sub ON IFNULL(emp.id_departement_sub, (SELECT id_departement_sub FROM tb_m_departement_sub WHERE id_departement = emp.id_departement LIMIT 1)) = dep_sub.id_departement_sub
                    LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                    LEFT JOIN (
                        SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                        FROM tb_m_employee
                    ) AS salary ON emp.id_employee = salary.id_employee
                    LEFT JOIN tb_emp_attn AS at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 18 HOUR) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
                    LEFT JOIN tb_emp_attn AS at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 18 HOUR)) AND at_out.type_log = 2 
                    LEFT JOIN tb_emp_attn AS at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.date AND at_in_hol.type_log = 1 
                    LEFT JOIN tb_emp_attn AS at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.date AND at_out_hol.type_log = 2
                    WHERE sch.date = '" + date_search.ToString + "' AND emp.id_departement = " + id_departement + "
                    GROUP BY sch.id_schedule
                ) AS tb
                WHERE tb.start_work_att IS NOT NULL AND tb.end_work_att IS NOT NULL
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

                            Dim start_work_att As DateTime = New DateTime
                            Dim end_work_att As DateTime = New DateTime

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
                                start_work_att = DateTime.Parse(GVAttendance.GetRowCellValue(i, "start_work_att").ToString)
                                end_work_att = DateTime.Parse(GVAttendance.GetRowCellValue(i, "end_work_att").ToString)
                            Catch ex As Exception
                            End Try

                            Dim ot_start_time As DateTime = If(schedule_out > overtime_in, schedule_out, overtime_in)
                            Dim ot_end_time As DateTime = If(schedule_in < overtime_out, overtime_out, schedule_in)

                            'over of schedule
                            after_work = (end_work_att - schedule_out).TotalHours
                            before_work = (schedule_in - start_work_att).TotalHours

                            'over of overtime
                            after_work_ot = (end_work_att - ot_start_time).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")
                            before_work_ot = (ot_end_time - start_work_att).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                            work_hours = (end_work_att - start_work_att).TotalHours - GVEmployee.GetRowCellValue(j, "ot_break")

                            If GVAttendance.GetRowCellValue(i, "id_schedule_type").ToString = "1" Then
                                If after_work >= ot_min And after_work_ot >= ot_min Then
                                    GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                    Dim total_hours As Decimal = Math.Floor(after_work_ot / 0.5) * 0.5

                                    GVAttendance.SetRowCellValue(i, "start_work_ot", Date.Parse(ot_start_time.ToString).ToString("dd MMMM yyyy HH:mm:ss"))
                                    GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work_att"))
                                    GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                    GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                    If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                        GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                    End If
                                ElseIf before_work >= ot_min And before_work_ot >= ot_min Then
                                    GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                    Dim total_hours As Decimal = Math.Floor(before_work_ot / 0.5) * 0.5

                                    GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work_att"))
                                    GVAttendance.SetRowCellValue(i, "end_work_ot", Date.Parse(ot_end_time.ToString).ToString("dd MMMM yyyy HH:mm:ss"))
                                    GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                    GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                    If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                        GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                    End If
                                End If
                            Else
                                GVAttendance.SetRowCellValue(i, "ot_potention", "1")

                                Dim total_hours As Decimal = Math.Floor(work_hours / 0.5) * 0.5

                                GVAttendance.SetRowCellValue(i, "start_work_ot", GVAttendance.GetRowCellValue(i, "start_work_att"))
                                GVAttendance.SetRowCellValue(i, "end_work_ot", GVAttendance.GetRowCellValue(i, "end_work_att"))
                                GVAttendance.SetRowCellValue(i, "break_hours", GVEmployee.GetRowCellValue(j, "ot_break"))
                                GVAttendance.SetRowCellValue(i, "total_hours", total_hours)

                                If GVAttendance.GetRowCellValue(i, "id_employee").ToString = GVEmployee.GetRowCellValue(j, "id_employee").ToString Then
                                    GVAttendance.SetRowCellValue(i, "is_valid", "yes")
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            GVAttendance.ActiveFilterString = "[ot_potention] = '1'"

            TEReportStatus.EditValue = ""

            'controls
            SBSave.Enabled = True
            SBPrint.Enabled = False
            SBMark.Enabled = False
        Else
            Dim query_ver As String = "
                SELECT vr.id_payroll, vr.id_report_status, rs.report_status
                FROM tb_ot_verification AS vr
                LEFT JOIN tb_lookup_report_status AS rs ON vr.id_report_status = rs.id_report_status
                WHERE id_ot_verification = " + id + "
            "

            Dim data_ver As DataTable = execute_query(query_ver, -1, True, "", "", "", "")

            TEReportStatus.EditValue = data_ver.Rows(0)("report_status").ToString
            SLUEPayroll.EditValue = data_ver.Rows(0)("id_payroll").ToString

            'detail
            Dim query_det As String = "
                SELECT vrd.id_employee, vrd.id_departement, vrd.id_departement_sub, d.departement, vr.ot_date AS date, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, sts.employee_status, vrd.to_salary, vrd.conversion_type, IF(" + LUEOvertimeType.GetColumnValue("is_point_ho").ToString() + " = 1, 2, d.is_store) AS is_store, vrd.is_day_off, vrd.start_work_att, vrd.end_work_att, DATE_FORMAT(vrd.start_work_ot, '%d %M %Y %H:%i:%s') AS start_work_ot, DATE_FORMAT(vrd.end_work_ot, '%d %M %Y %H:%i:%s') AS end_work_ot, vrd.break_hours, vrd.total_hours, 0.0 AS point_ot, 'yes' AS is_valid, sch.id_schedule_type, DATE_FORMAT(sch.in, '%d %M %Y %H:%i:%s') AS `in`, DATE_FORMAT(sch.out, '%d %M %Y %H:%i:%s') AS `out`, 1 AS ot_potention
                FROM tb_ot_verification_det AS vrd
                LEFT JOIN tb_ot_verification AS vr ON vrd.id_ot_verification = vr.id_ot_verification
                LEFT JOIN tb_m_employee AS e ON vrd.id_employee = e.id_employee
                LEFT JOIN tb_lookup_employee_status AS sts ON e.id_employee_status = sts.id_employee_status
                LEFT JOIN tb_m_departement AS d ON vrd.id_departement = d.id_departement
                LEFT JOIN tb_emp_schedule AS sch ON vrd.id_employee = sch.id_employee AND sch.date = vr.ot_date
                WHERE vrd.id_ot_verification = " + id + "
            "

            Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")

            GCAttendance.DataSource = data_det

            'controls
            SBSave.Enabled = False
            SBPrint.Enabled = True
            SBMark.Enabled = True
        End If

        'calculate point
        If GVAttendance.RowCount > 0 Then
            For i = 0 To GVAttendance.RowCount - 1
                If GVAttendance.IsValidRowHandle(i) Then
                    Dim to_salary As String = GVAttendance.GetRowCellValue(i, "to_salary").ToString
                    Dim is_day_off As String = GVAttendance.GetRowCellValue(i, "is_day_off").ToString
                    Dim total_hours As String = GVAttendance.GetRowCellValue(i, "total_hours").ToString
                    Dim is_store As String = GVAttendance.GetRowCellValue(i, "is_store").ToString

                    Dim point_ot As String = GVAttendance.GetRowCellValue(i, "point_ot").ToString

                    point_ot = If(to_salary = "1", calc_point(Decimal.Parse(total_hours), is_day_off, is_store), total_hours)

                    GVAttendance.SetRowCellValue(i, "point_ot", point_ot)
                End If
            Next
        End If

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
        GVAttendance.ActiveFilterString = "[ot_potention] = '1' AND [is_valid] = 'yes'"

        If GVAttendance.RowCount > 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                Dim ot_date As String = Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim id_payroll As String = SLUEPayroll.EditValue.ToString

                query = "
                    INSERT INTO tb_ot_verification (id_ot, id_departement, ot_date, id_payroll, id_report_status, created_by, created_at) VALUES (" + id_ot + ", " + id_departement_user + ", '" + ot_date + "', " + id_payroll + ", 1, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();
                "

                Dim id_ot_verification As String = execute_query(query, 0, True, "", "", "", "")

                For i = 0 To GVAttendance.RowCount - 1
                    If GVAttendance.IsValidRowHandle(i) Then
                        If GVAttendance.GetRowCellValue(i, "is_valid").ToString = "yes" Then
                            Dim id_employee As String = GVAttendance.GetRowCellValue(i, "id_employee").ToString
                            Dim id_departement As String = GVAttendance.GetRowCellValue(i, "id_departement").ToString
                            Dim id_departement_sub As String = GVAttendance.GetRowCellValue(i, "id_departement_sub").ToString
                            Dim employee_position As String = GVAttendance.GetRowCellValue(i, "employee_position").ToString
                            Dim id_employee_status As String = GVAttendance.GetRowCellValue(i, "id_employee_status").ToString
                            Dim to_salary As String = GVAttendance.GetRowCellValue(i, "to_salary").ToString
                            Dim conversion_type As String = GVAttendance.GetRowCellValue(i, "conversion_type").ToString
                            Dim is_day_off As String = GVAttendance.GetRowCellValue(i, "is_day_off").ToString
                            Dim start_work_att As String = Date.Parse(GVAttendance.GetRowCellValue(i, "start_work_att").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                            Dim end_work_att As String = Date.Parse(GVAttendance.GetRowCellValue(i, "end_work_att").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                            Dim start_work_ot As String = Date.Parse(GVAttendance.GetRowCellValue(i, "start_work_ot").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                            Dim end_work_ot As String = Date.Parse(GVAttendance.GetRowCellValue(i, "end_work_ot").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                            Dim break_hours As String = GVAttendance.GetRowCellValue(i, "break_hours").ToString
                            Dim total_hours As String = GVAttendance.GetRowCellValue(i, "total_hours").ToString

                            query = "INSERT INTO tb_ot_verification_det (id_ot_verification, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, to_salary, conversion_type, is_day_off, start_work_att, end_work_att, start_work_ot, end_work_ot, break_hours, total_hours) VALUES (" + id_ot_verification + ", " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", " + to_salary + ", " + conversion_type + ", " + is_day_off + ", '" + start_work_att + "', '" + end_work_att + "', '" + start_work_ot + "', '" + end_work_ot + "', " + decimalSQL(break_hours) + ", " + decimalSQL(total_hours) + ")"

                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                Next

                submit_who_prepared("187", id_ot_verification, id_user)

                Close()
            Else
                GVAttendance.ActiveFilterString = "[ot_potention] = '1'"
            End If
        Else
            errorCustom("No valid overtime.")
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Dispose()
    End Sub

    Sub change_payroll()
        Dim id_payroll As String = execute_query("SELECT id_payroll FROM tb_emp_payroll WHERE id_payroll_type = 1 AND '" + Date.Parse(DESearch.EditValue.ToString).ToString("yyyy-MM-dd") + "' BETWEEN ot_periode_start AND ot_periode_end", 0, True, "", "", "", "")

        SLUEPayroll.EditValue = id_payroll
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "187"
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Function calc_point(ByVal tot_hour As Decimal, ByVal is_day_off As String, ByVal is_store As String) As Decimal
        Dim tot_point As Decimal = 0.0

        Try
            If is_day_off = "1" Then
                'hari libur
                If is_store = "1" Then 'toko
                    tot_point = If(tot_hour > 8, ((tot_hour - 8) * 4), 0) + If(tot_hour > 7, ((tot_hour - If(tot_hour > 7, (tot_hour - 8), 0) - 7) * 3), 0) + (tot_hour - If(tot_hour > 7, (tot_hour - 7), 0)) * 2
                Else 'office
                    tot_point = If(tot_hour > 9, ((tot_hour - 9) * 4), 0) + If(tot_hour > 8, ((tot_hour - If(tot_hour > 9, (tot_hour - 9), 0) - 8) * 3), 0) + (tot_hour - If(tot_hour > 8, (tot_hour - 8), 0)) * 2
                End If
            Else
                'hari kerja
                tot_point = If(tot_hour > 1, ((tot_hour - 1) * 2), 0) + ((tot_hour - If(tot_hour > 1, (tot_hour - 1), 0)) * 1.5)
            End If
        Catch ex As Exception
        End Try

        Return tot_point
    End Function

    Sub update_changes()
        Dim query As String = ""

        query = "
            SELECT vr.id_payroll, vrd.id_employee, ot.id_ot_type, vrd.start_work_ot AS ot_start, vrd.end_work_ot AS ot_end, vrd.break_hours AS total_break, vrd.total_hours AS total_hour, 0.0 AS total_point, vrd.is_day_off, ott.ot_point_wages AS wages_per_point, ot.ot_note AS note, vrd.id_ot_verification_det, py.periode_end, vrd.to_salary, vrd.conversion_type, IF(ott.is_point_ho = 1, 2, d.is_store) AS is_store
            FROM tb_ot_verification_det AS vrd
            LEFT JOIN tb_ot_verification AS vr ON vrd.id_ot_verification = vr.id_ot_verification
            LEFT JOIN tb_ot AS ot ON vr.id_ot = ot.id_ot
            LEFT JOIN tb_lookup_ot_type AS ott ON ot.id_ot_type = ott.id_ot_type
            LEFT JOIN tb_emp_payroll AS py ON vr.id_payroll = py.id_payroll
            LEFT JOIN tb_m_departement AS d ON vrd.id_departement = d.id_departement
            WHERE vrd.id_ot_verification = " + id + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim id_payroll As String = data.Rows(i)("id_payroll").ToString
            Dim id_employee As String = data.Rows(i)("id_employee").ToString
            Dim id_ot_type As String = data.Rows(i)("id_ot_type").ToString
            Dim ot_start As String = Date.Parse(data.Rows(i)("ot_start").ToString()).ToString("yyyy-MM-dd HH:mm:ss")
            Dim ot_end As String = Date.Parse(data.Rows(i)("ot_end").ToString()).ToString("yyyy-MM-dd HH:mm:ss")
            Dim total_break As String = data.Rows(i)("total_break").ToString
            Dim total_hour As String = data.Rows(i)("total_hour").ToString
            Dim total_point As String = data.Rows(i)("total_point").ToString
            Dim is_day_off As String = data.Rows(i)("is_day_off").ToString
            Dim wages_per_point As String = data.Rows(i)("wages_per_point").ToString
            Dim note As String = data.Rows(i)("note").ToString
            Dim id_ot_verification_det As String = data.Rows(i)("id_ot_verification_det").ToString
            Dim periode_end As String = data.Rows(i)("periode_end").ToString
            Dim to_salary As String = data.Rows(i)("to_salary").ToString
            Dim conversion_type As String = data.Rows(i)("conversion_type").ToString
            Dim is_store As String = data.Rows(i)("is_store").ToString

            total_point = If(to_salary = "1", calc_point(Decimal.Parse(total_hour), is_day_off, is_store), total_hour)

            Dim qty As String = Math.Round((Decimal.Parse(total_point) * 60)).ToString
            Dim date_expired As String = Date.Parse(periode_end).AddMonths(6).ToString("yyyy-MM-dd")

            If conversion_type = "1" Then
                'overtime
                query = "INSERT INTO tb_emp_payroll_ot (id_payroll, id_employee, id_ot_type, ot_start, ot_end, total_break, total_hour, total_point, is_day_off, wages_per_point, note, id_ot_verification_det) VALUES (" + id_payroll + ", " + id_employee + ", " + id_ot_type + ", '" + ot_start + "', '" + ot_end + "', " + decimalSQL(total_break) + ", " + decimalSQL(total_hour) + ", " + decimalSQL(total_point) + ", " + is_day_off + ", " + decimalSQL(wages_per_point) + ", '" + addSlashes(note) + "', " + id_ot_verification_det + ")"

                execute_non_query(query, True, "", "", "", "")
            ElseIf conversion_type = "2" Then
                'dp
                query = "INSERT INTO tb_emp_stock_leave (id_ot_verification_det, id_emp, qty, plus_minus, date_leave, date_expired, is_process_exp, note, type) VALUES (" + id_ot_verification_det + ", " + id_employee + ", " + qty + ", 1, NOW(), '" + date_expired + "', 1, '" + note + "', 2)"

                execute_non_query(query, True, "", "", "", "")
            End If
        Next
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")

        Dim Report As New ReportEmpOvertimeVerification()

        Report.id = id
        Report.data1 = GCEmployee.DataSource
        Report.data2 = GCAttendance.DataSource
        Report.id_pre = If(Not id_report_status = "6", "1", "-1")

        Report.XLNumber.Text = TENumber.Text.ToString
        Report.XLOTtype.Text = LUEOvertimeType.Text.ToString
        Report.XLDate.Text = DESearch.Text
        Report.XLPayrollPeriod.Text = SLUEPayroll.Text
        Report.XLCreatedAt.Text = TECreatedBy.Text.ToString
        Report.XLCreatedBy.Text = TECreatedAt.Text.ToString
        Report.XLOTNote.Text = MEOvertimeNote.Text.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub
End Class