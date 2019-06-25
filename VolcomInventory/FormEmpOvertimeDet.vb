Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public is_check As String = "-1"
    Public id As String = "0"

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Detail"

            SBFill.Visible = False
        Else
            Text = "Overtime Management Detail"

            SBFill.Visible = True
        End If

        form_load()
    End Sub

    Sub form_load()
        ' default
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT 1 AS id_type, 'Salary' AS type UNION SELECT 2 AS id_type, 'DP' AS type", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEDayOff, "SELECT 1 AS id_day_off, 'Yes' AS day_off UNION SELECT 2 AS id_day_off, 'No' AS day_off", 0, "day_off", "id_day_off")
        viewSearchLookupQuery(SLUEPayrollPeriod, "SELECT id_payroll, DATE_FORMAT(periode_start, '%d %M %Y') AS periode_start, DATE_FORMAT(periode_end, '%d %M %Y') AS periode_end, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1 ORDER BY periode_end DESC", "id_payroll", "periode", "id_payroll")

        DEOvertimeDate.EditValue = Now
        TEOvertimeStart.EditValue = New DateTime(Now.Year, Now.Month, Now.Day, 8, 30, 0)
        TEOvertimeEnd.EditValue = New DateTime(Now.Year, Now.Month, Now.Day, 17, 30, 0)
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMM yyyy HH:mm:ss")

        Dim data As DataTable = New DataTable

        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("only_dp", GetType(String))
        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("is_store", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("id_employee_level", GetType(String))
        data.Columns.Add("employee_level", GetType(String))
        data.Columns.Add("conversion_type", GetType(String))
        data.Columns.Add("start_work", GetType(DateTime))
        data.Columns.Add("end_work", GetType(DateTime))
        data.Columns.Add("break_hours", GetType(Decimal))
        data.Columns.Add("total_hours", GetType(Decimal))
        data.Columns.Add("overtime_hours", GetType(Decimal))
        data.Columns.Add("is_day_off", GetType(String))
        data.Columns.Add("point", GetType(Decimal))
        data.Columns.Add("valid", GetType(String))

        GCEmployee.DataSource = data

        'load database
        If Not id = "0" Then
            Dim query_ot As String = "
                SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, DATE_FORMAT(ot.ot_date, '%d %b %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%d %b %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%d %b %Y %H:%i:%s') AS ot_end_time, ot.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot.ot_start_time, ot.ot_end_time) / 60) - ot.ot_break, 1) AS total_hours, ot.ot_note, ot.id_payroll, DATE_FORMAT(payroll.periode_end, '%b %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, ot.hrd_check, ot.number, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %b %Y %H:%i:%s') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE ot.id_ot = " + id + "
            "

            Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

            TENumber.EditValue = data_ot.Rows(0)("number").ToString
            DEOvertimeDate.EditValue = data_ot.Rows(0)("ot_date").ToString
            TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
            TECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString
            LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)
            TEOvertimeStart.EditValue = Date.Parse(data_ot.Rows(0)("ot_start_time").ToString)
            TEOvertimeEnd.EditValue = Date.Parse(data_ot.Rows(0)("ot_end_time").ToString)
            TEOvertimeBreak.EditValue = data_ot.Rows(0)("ot_break").ToString
            MEOvertimeNote.EditValue = data_ot.Rows(0)("ot_note").ToString
            SLUEPayrollPeriod.EditValue = data_ot.Rows(0)("id_payroll")
            TEReportStatus.EditValue = data_ot.Rows(0)("report_status").ToString
            TECheckStatus.EditValue = data_ot.Rows(0)("check_status").ToString

            ' load employee
            ' column
            Dim whereCheckColumn As String = "DATE_FORMAT(IF((sch.id_schedule_type = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL), ot.ot_start_time, att_in.datetime), '%d %b %Y %H:%i:%s') AS start_work, DATE_FORMAT(att_out.datetime, '%d %b %Y %H:%i:%s') AS end_work, ot.ot_break AS break_hours, ROUND((TIMESTAMPDIFF(MINUTE, IF(sch.id_schedule_type = 1, ot.ot_start_time, att_in.datetime), att_out.datetime) / 60) - ot.ot_break, 1) AS total_hours, 0.0 AS overtime_hours, IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1))) AS is_day_off, 0.0 AS point"

            If data_ot.Rows(0)("hrd_check").ToString = "1" Then
                whereCheckColumn = "DATE_FORMAT(ot_det.start_work, '%d %b %Y %H:%i:%s') AS start_work, DATE_FORMAT(ot_det.end_work, '%d %b %Y %H:%i:%s') AS end_work, ot_det.break_hours, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.start_work, ot_det.end_work) / 60) - ot_det.break_hours, 1) AS total_hours, IFNULL(ot_det.overtime_hours, 0.0) AS overtime_hours, IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1))) AS is_day_off, 0.0 AS point"
            End If

            ' table join
            Dim whereCheckJoin As String = "
                LEFT JOIN (
                    SELECT id_employee, MIN(`datetime`) AS `datetime` 
                    FROM tb_emp_attn
                    WHERE type_log = 1 AND DATE(`datetime`) BETWEEN '" + Date.Parse(data_ot.Rows(0)("ot_start_time").ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(data_ot.Rows(0)("ot_end_time").ToString).ToString("yyyy-MM-dd") + "'
                    GROUP BY id_employee
                ) att_in ON ot_det.id_employee = att_in.id_employee
                LEFT JOIN (
                    SELECT id_employee, MAX(`datetime`) AS `datetime` 
                    FROM tb_emp_attn
                    WHERE type_log = 2 AND DATE(`datetime`) BETWEEN '" + Date.Parse(data_ot.Rows(0)("ot_start_time").ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(data_ot.Rows(0)("ot_end_time").ToString).ToString("yyyy-MM-dd") + "'
                    GROUP BY id_employee
                ) att_out ON ot_det.id_employee = att_out.id_employee
                LEFT JOIN (
                    SELECT id_employee, id_schedule_type FROM tb_emp_schedule WHERE date = '" + Date.Parse(data_ot.Rows(0)("ot_date").ToString).ToString("yyyy-MM-dd") + "'
                ) sch ON ot_det.id_employee = sch.id_employee
            "

            If data_ot.Rows(0)("hrd_check").ToString = "1" Then
                whereCheckJoin = ""
            End If

            Dim query_ot_det As String = "
                SELECT ot_det.id_employee, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp, ot_det.id_departement, departement.departement, departement.is_store, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, ot_det.conversion_type, " + whereCheckColumn + ", IF(is_valid = 1, 'yes', 'no') AS valid
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                LEFT JOIN (
                    SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                    FROM tb_m_employee
                ) AS salary ON ot_det.id_employee = salary.id_employee
                " + whereCheckJoin + "
                WHERE ot_det.id_ot = " + id + "
            "

            Dim data_ot_det As DataTable = execute_query(query_ot_det, -1, True, "", "", "", "")

            GCEmployee.DataSource = data_ot_det

            For i = 0 To GVEmployee.RowCount - 1
                If GVEmployee.IsValidRowHandle(i) Then
                    If Not data_ot.Rows(0)("hrd_check").ToString = "1" Then
                        calculateTotalHoursList(i)
                    End If

                    calculatePointList(i)
                End If
            Next

            GVEmployee.BestFitColumns()
        End If

        calculateTotalHours()

        'limit start & end time
        Dim start_time As DateTime = TEOvertimeStart.EditValue

        RITEAttendanceStart.MinValue = New DateTime(start_time.Year, start_time.Month, start_time.Day, 0, 0, 0)
        RITEAttendanceStart.MaxValue = New DateTime(start_time.Year, start_time.Month, start_time.Day, 23, 59, 59)

        RITEAttendanceEnd.MinValue = New DateTime(start_time.Year, start_time.Month, start_time.Day, 0, 0, 0)

        ' permission
        If Not id = "0" Then
            LUEOvertimeType.ReadOnly = True
            DEOvertimeDate.ReadOnly = True
            TEOvertimeStart.ReadOnly = True
            TEOvertimeEnd.ReadOnly = True
            TEOvertimeBreak.ReadOnly = True
            MEOvertimeNote.ReadOnly = True
            SLUEPayrollPeriod.ReadOnly = True

            RISLUEType.ReadOnly = True

            SBEmpDelete.Enabled = False
            SBEmpAdd.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSave.Enabled = False
        End If

        If is_check = "-1" Then
            GCIsDayOff.Visible = False
            GCStartWork.Visible = False
            GCEndWork.Visible = False
            GCBreakHours.Visible = False
            GCTotalHours.Visible = False
            GCOvertime.Visible = False
            GCPoint.Visible = False
            GCValid.Visible = False

            SBCheck.Visible = False

            SBSave.Visible = True

            PCCheckStatus.Visible = False
        Else
            Dim query_check As String = "SELECT id_check_status FROM tb_ot WHERE id_ot = " + id + ""

            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")

            If data_check.Rows(0)("id_check_status").ToString = "" Then
                RISLUEType.ReadOnly = False

                SLUEPayrollPeriod.ReadOnly = False

                SBMark.Enabled = False
                SBPrint.Enabled = False
                SBCheck.Enabled = True
            Else
                RISLUEType.ReadOnly = True

                SLUEPayrollPeriod.ReadOnly = True

                SBMark.Enabled = True
                SBPrint.Enabled = True
                SBCheck.Enabled = False

                GCIsDayOff.OptionsColumn.AllowEdit = False
                GCStartWork.OptionsColumn.AllowEdit = False
                GCEndWork.OptionsColumn.AllowEdit = False
                GCBreakHours.OptionsColumn.AllowEdit = False
                GCTotalHours.OptionsColumn.AllowEdit = False
                GCOvertime.OptionsColumn.AllowEdit = False
                GCValid.OptionsColumn.AllowEdit = False
            End If

            GCIsDayOff.Visible = True
            GCStartWork.Visible = True
            GCEndWork.Visible = True
            GCBreakHours.Visible = True
            GCTotalHours.Visible = True
            GCOvertime.Visible = True
            GCPoint.Visible = True
            GCValid.Visible = True

            SBCheck.Visible = True

            SBSave.Visible = False

            PCCheckStatus.Visible = True
        End If
    End Sub

    Sub calculateTotalHours()
        Dim ot_start As DateTime = TEOvertimeStart.EditValue
        Dim ot_end As DateTime = TEOvertimeEnd.EditValue

        Dim diff As TimeSpan = ot_end.Subtract(ot_start)

        Dim total As Decimal = 0.0

        total = Math.Round(Math.Round(diff.TotalHours, 1) - TEOvertimeBreak.EditValue, 1)

        TETotalHours.EditValue = total
    End Sub

    Sub calculateTotalHoursList(ByVal i As Integer)
        GVEmployee.CloseEditor()
        GVEmployee.UpdateCurrentRow()

        If Not GVEmployee.GetRowCellValue(i, "end_work").ToString = "" And Not GVEmployee.GetRowCellValue(i, "start_work").ToString = "" Then
            Dim start_work As DateTime = GVEmployee.GetRowCellValue(i, "start_work")
            Dim end_work As DateTime = GVEmployee.GetRowCellValue(i, "end_work")

            Dim diff As TimeSpan = end_work.Subtract(start_work)

            Dim total_hour As Decimal = 0.0
            Dim overtime_hour As Decimal = 0.0

            total_hour = Math.Round(Math.Round(diff.TotalHours, 1) - GVEmployee.GetRowCellValue(i, "break_hours"), 1)
            overtime_hour = Math.Floor(total_hour / 0.5) * 0.5

            GVEmployee.SetRowCellValue(i, "total_hours", total_hour)
            GVEmployee.SetRowCellValue(i, "overtime_hours", overtime_hour)

            calculatePointList(i)
        Else
            GVEmployee.SetRowCellValue(i, "total_hours", "0.0")
            GVEmployee.SetRowCellValue(i, "overtime_hours", "0.0")

            GVEmployee.SetRowCellValue(i, "point", "0.0")
        End If

        GVEmployee.RefreshData()
    End Sub

    Sub calculatePointList(ByVal i As Integer)
        GVEmployee.CloseEditor()
        GVEmployee.UpdateCurrentRow()

        Dim is_day_off As Decimal = GVEmployee.GetRowCellValue(i, "is_day_off").ToString
        Dim is_store As Decimal = GVEmployee.GetRowCellValue(i, "is_store").ToString
        Dim overtime_hour As Decimal = GVEmployee.GetRowCellValue(i, "overtime_hours")

        GVEmployee.SetRowCellValue(i, "point", calc_point(overtime_hour, is_day_off, is_store))

        If GVEmployee.GetRowCellValue(i, "only_dp").ToString = "yes" Then
            GVEmployee.SetRowCellValue(i, "point", overtime_hour)
        End If

        GVEmployee.RefreshData()
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeBreak.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub RITEAttendanceStart_EditValueChanged(sender As Object, e As EventArgs) Handles RITEAttendanceStart.EditValueChanged
        calculateTotalHoursList(GVEmployee.GetFocusedDataSourceRowIndex)
    End Sub

    Private Sub RITEAttendanceEnd_EditValueChanged(sender As Object, e As EventArgs) Handles RITEAttendanceEnd.EditValueChanged
        calculateTotalHoursList(GVEmployee.GetFocusedDataSourceRowIndex)
    End Sub

    Private Sub RITEBreakHours_EditValueChanged(sender As Object, e As EventArgs) Handles RITEBreakHours.EditValueChanged
        calculateTotalHoursList(GVEmployee.GetFocusedDataSourceRowIndex)
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Dim include As String = ""

            If FormEmpOvertime.XtraTabControl.SelectedTabPage.Name = "XTPByEmployee" Then
                For i = 0 To FormEmpOvertime.GVEmployee.RowCount - 1
                    If FormEmpOvertime.GVEmployee.IsValidRowHandle(i) Then
                        include += FormEmpOvertime.GVEmployee.GetRowCellValue(i, "id_ot_det").ToString + ", "
                    End If
                Next

                If Not include = "" Then
                    Dim id_ot_det As String = FormEmpOvertime.GVEmployee.GetFocusedRowCellValue("id_ot_det").ToString

                    include = include.Substring(0, include.Length - 2)

                    FormEmpOvertime.load_overtime("id_det" + include)

                    FormEmpOvertime.GVEmployee.FocusedRowHandle = find_row(FormEmpOvertime.GVEmployee, "id_ot_det", id_ot_det)
                End If
            Else
                For i = 0 To FormEmpOvertime.GVOvertime.RowCount - 1
                    If FormEmpOvertime.GVOvertime.IsValidRowHandle(i) Then
                        include += FormEmpOvertime.GVOvertime.GetRowCellValue(i, "id_ot").ToString + ", "
                    End If
                Next

                If Not include = "" Then
                    Dim id_ot As String = FormEmpOvertime.GVOvertime.GetFocusedRowCellValue("id_ot").ToString

                    include = include.Substring(0, include.Length - 2)

                    FormEmpOvertime.load_overtime("id_ot" + include)

                    FormEmpOvertime.GVOvertime.FocusedRowHandle = find_row(FormEmpOvertime.GVOvertime, "id_ot", id_ot)
                End If
            End If
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBEmpAdd_Click(sender As Object, e As EventArgs) Handles SBEmpAdd.Click
        FormEmpOvertimePick.is_hrd = is_hrd

        FormEmpOvertimePick.ShowDialog()
    End Sub

    Private Sub SBEmpDelete_Click(sender As Object, e As EventArgs) Handles SBEmpDelete.Click
        GVEmployee.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        MEOvertimeNote_Validating(MEOvertimeNote, New System.ComponentModel.CancelEventArgs)

        If TEOvertimeStart.EditValue > TEOvertimeEnd.EditValue Then
            errorCustom("Start time must be earlier than end time.")
        ElseIf TETotalHours.EditValue < 0 Then
            errorCustom("Break time greater than work time.")
        ElseIf GVEmployee.RowCount <= 0 Then
            errorCustom("No employee selected.")
        ElseIf Not formIsValidInPanel(ErrorProvider, PanelControl4) Then
            errorCustom("Please check your input.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                Dim ot_date As String = Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim ot_start_time As String = Date.Parse(TEOvertimeStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
                Dim ot_end_time As String = Date.Parse(TEOvertimeEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")

                query = "INSERT INTO tb_ot (id_ot_type, ot_date, ot_start_time, ot_end_time, ot_break, ot_note, id_payroll, id_report_status, number, created_by, created_at) VALUES (" + LUEOvertimeType.EditValue.ToString + ", '" + ot_date + "', '" + ot_start_time + "', '" + ot_end_time + "', " + decimalSQL(TEOvertimeBreak.EditValue.ToString) + ", '" + addSlashes(MEOvertimeNote.Text.ToString) + "', " + SLUEPayrollPeriod.EditValue.ToString + ", 1, '0', " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

                id = execute_query(query, 0, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        query = "INSERT INTO tb_ot_det (id_ot, id_employee, id_departement, employee_position, id_employee_level, conversion_type) VALUES (" + id + ", " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", " + GVEmployee.GetRowCellValue(i, "id_departement").ToString + ", '" + addSlashes(GVEmployee.GetRowCellValue(i, "employee_position").ToString) + "', " + GVEmployee.GetRowCellValue(i, "id_employee_level").ToString + ", " + GVEmployee.GetRowCellValue(i, "conversion_type").ToString + ")"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                execute_non_query("CALL gen_number(" + id + ", '184')", True, "", "", "", "")

                submit_who_prepared("184", id, id_user)

                ' load overtime
                FormEmpOvertime.DEStart.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)
                FormEmpOvertime.DEUntil.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)

                FormEmpOvertime.load_overtime("ot_date")

                Close()
            End If
        End If
    End Sub

    Private Sub MEOvertimeNote_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MEOvertimeNote.Validating
        If MEOvertimeNote.Text.ToString = "" Then
            ErrorProvider.SetError(MEOvertimeNote, "Please fill out this field.")
        Else
            ErrorProvider.SetError(MEOvertimeNote, "")
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = If(is_check = "-1", "184", "187")
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        'load data
        Dim query_ot As String = "
            SELECT id_report_status, id_check_status
            FROM tb_ot
            WHERE id_ot = " + id + "
        "

        Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

        Dim Report As New ReportEmpOvertime()

        Report.id = id
        Report.data = GCEmployee.DataSource
        Report.is_check = is_check
        If is_check = "-1" Then
            Report.id_pre = If(data_ot.Rows(0)("id_report_status").ToString = "6", "-1", "1")
        Else
            Report.id_pre = If(data_ot.Rows(0)("id_check_status").ToString = "6", "-1", "1")
        End If

        Report.XLNumber.Text = TENumber.Text.ToString
        Report.XLOTtype.Text = LUEOvertimeType.Text.ToString
        Report.XLOTDate.Text = DEOvertimeDate.Text.ToString
        Report.XLOTTime.Text = TEOvertimeStart.Text.ToString + Environment.NewLine + TEOvertimeEnd.Text.ToString + " (" + TETotalHours.Text.ToString + " Hours)"
        Report.XLPayrollPeriod.Text = SLUEPayrollPeriod.Text.ToString
        Report.XLCreatedAt.Text = TECreatedBy.Text.ToString
        Report.XLCreatedBy.Text = TECreatedAt.Text.ToString
        Report.XLOTNote.Text = MEOvertimeNote.Text.ToString

        Report.GVEmployee.BestFitColumns()

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private clone As DataView = Nothing

    Private Sub GVEmployee_ShownEditor(sender As Object, e As EventArgs) Handles GVEmployee.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName = "conversion_type" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)

            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try

            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)

            If view.GetFocusedRowCellValue("only_dp").ToString = "yes" Then
                clone.RowFilter = "[id_type] = 2"
            Else
                clone.RowFilter = ""
            End If

            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub DEOvertimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEOvertimeDate.EditValueChanged
        If Not DEOvertimeDate.EditValue Is Nothing Then
            'change payroll period
            Dim data As DataTable = execute_query("SELECT id_payroll, DATE_FORMAT(ot_periode_start, '%d %b %Y') AS ot_periode_start, DATE_FORMAT(ot_periode_end, '%d %b %Y') AS ot_periode_end FROM tb_emp_payroll WHERE id_payroll_type = 1", -1, True, "", "", "", "")

            For i = 0 To data.Rows.Count - 1
                If Date.Parse(DEOvertimeDate.Text.ToString + " 12:00 AM") >= Date.Parse(data.Rows(i)("ot_periode_start")) And Date.Parse(DEOvertimeDate.Text.ToString + " 12:00 AM") <= Date.Parse(data.Rows(i)("ot_periode_end")) Then
                    SLUEPayrollPeriod.EditValue = data.Rows(i)("id_payroll")

                    Exit For
                End If
            Next

            'time
            Dim ot_date As DateTime = DEOvertimeDate.EditValue

            Dim ot_start As DateTime = TEOvertimeStart.EditValue
            Dim ot_end As DateTime = TEOvertimeEnd.EditValue

            Dim plus_days As Integer = ot_end.Subtract(ot_start).TotalDays

            'disable time
            TEOvertimeStart.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)
            TEOvertimeStart.Properties.MaxValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 23, 59, 59)

            TEOvertimeEnd.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)

            'change time date
            TEOvertimeStart.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_start.Hour, ot_start.Minute, ot_start.Second)
            TEOvertimeEnd.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_end.Hour, ot_end.Minute, ot_end.Second).AddDays(plus_days)
        End If
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs) Handles SBCheck.Click
        Dim confirm As DialogResult

        ' Validation
        Dim errorTotal As String = ""

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                If GVEmployee.GetRowCellValue(i, "valid").ToString = "yes" Then
                    If GVEmployee.GetRowCellValue(i, "total_hours") <= 0 Then
                        errorTotal = "Make sure if that valid, total (hours) is greater than 0."
                    End If
                End If
            End If
        Next

        If errorTotal = "" Then
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "
                    UPDATE tb_ot SET id_payroll = '" + SLUEPayrollPeriod.EditValue.ToString + "', id_check_status = 1, hrd_check = 1 WHERE id_ot = " + id + "
                "

                execute_non_query(query, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        Dim only_dp As String = GVEmployee.GetRowCellValue(i, "only_dp").ToString
                        Dim conversion_type As String = GVEmployee.GetRowCellValue(i, "conversion_type").ToString
                        Dim is_day_off As String = GVEmployee.GetRowCellValue(i, "is_day_off").ToString
                        Dim start_work As String = "NULL"
                        Dim end_work As String = "NULL"
                        Dim break_hours As String = GVEmployee.GetRowCellValue(i, "break_hours").ToString
                        Dim overtime_hours As String = GVEmployee.GetRowCellValue(i, "overtime_hours").ToString

                        If Not GVEmployee.GetRowCellValue(i, "start_work").ToString = "" Then
                            start_work = "'" + Date.Parse(GVEmployee.GetRowCellValue(i, "start_work").ToString).ToString("yyyy-MM-dd HH:mm:ss") + "'"
                        End If

                        If Not GVEmployee.GetRowCellValue(i, "end_work").ToString = "" Then
                            end_work = "'" + Date.Parse(GVEmployee.GetRowCellValue(i, "end_work").ToString).ToString("yyyy-MM-dd HH:mm:ss") + "'"
                        End If

                        Dim is_valid As String = If(GVEmployee.GetRowCellValue(i, "valid").ToString = "yes", "1", "2")

                        query = "UPDATE tb_ot_det SET only_dp = '" + GVEmployee.GetRowCellValue(i, "only_dp").ToString + "', conversion_type = '" + conversion_type + "', is_day_off = '" + is_day_off + "', start_work = " + start_work + ", end_work = " + end_work + ", break_hours = " + decimalSQL(break_hours) + ", overtime_hours = " + decimalSQL(overtime_hours) + ", is_valid = " + is_valid + " WHERE id_ot = " + id + " AND id_employee = " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ""

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                submit_who_prepared("187", id, id_user)

                Close()
            End If
        Else
            errorCustom(errorTotal)
        End If
    End Sub

    Sub updateChanges()
        Dim query As String = ""

        query = "
            SELECT ot_det.conversion_type, departement.is_store, ot.id_payroll, payroll.periode_end, ot_det.id_employee, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp, ot.id_ot_type, ot.ot_date, ot_det.start_work AS ot_start, ot_det.end_work AS ot_end, ot_det.break_hours AS total_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.start_work, ot_det.end_work) / 60) - ot_det.break_hours, 1) AS total_hour, IFNULL(ot_det.overtime_hours, 0.0) AS overtime_hours, 0 AS total_point, IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1))) AS is_day_off, ot_type.ot_point_wages AS wages_per_point, ot.ot_note AS note, ot_det.id_ot_det
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN (
                SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                FROM tb_m_employee
            ) AS salary ON ot_det.id_employee = salary.id_employee
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
            WHERE ot.id_ot = " + id + " AND ot_det.is_valid = 1
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim conversion_type As String = data.Rows(i)("conversion_type").ToString
            Dim only_dp As String = data.Rows(i)("only_dp").ToString
            Dim is_store As String = data.Rows(i)("is_store").ToString
            Dim id_payroll As String = data.Rows(i)("id_payroll").ToString
            Dim id_employee As String = data.Rows(i)("id_employee").ToString
            Dim id_ot_type As String = data.Rows(i)("id_ot_type").ToString
            Dim ot_start As String = Date.Parse(data.Rows(i)("ot_start").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim ot_end As String = Date.Parse(data.Rows(i)("ot_end").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim total_break As String = data.Rows(i)("total_break").ToString
            Dim overtime_hour As String = data.Rows(i)("overtime_hours").ToString
            Dim is_day_off As String = data.Rows(i)("is_day_off").ToString
            Dim total_point As String = If(only_dp = "yes", overtime_hour.ToString, calc_point(Decimal.Parse(overtime_hour), is_day_off, is_store).ToString)
            Dim wages_per_point As String = data.Rows(i)("wages_per_point").ToString
            Dim note As String = data.Rows(i)("note").ToString
            Dim id_ot_det As String = data.Rows(i)("id_ot_det").ToString
            Dim qty As String = Math.Round((Decimal.Parse(total_point) * 60)).ToString
            Dim date_expired As String = Date.Parse(data.Rows(i)("periode_end").ToString).AddMonths(6).ToString("yyyy-MM-dd")

            If conversion_type = "1" Then
                ' overtime
                query = "INSERT INTO tb_emp_payroll_ot (id_payroll, id_employee, id_ot_type, ot_start, ot_end, total_break, total_hour, total_point, is_day_off, wages_per_point, note, id_ot_det) VALUES (" + id_payroll + ", " + id_employee + ", " + id_ot_type + ", '" + ot_start + "', '" + ot_end + "', " + decimalSQL(total_break) + ", " + decimalSQL(overtime_hour) + ", " + decimalSQL(total_point) + ", " + is_day_off + ", '" + decimalSQL(wages_per_point) + "', '" + note + "', " + id_ot_det + ")"

                execute_non_query(query, True, "", "", "", "")
            Else
                ' dp
                query = "INSERT INTO tb_emp_stock_leave (id_ot_det, id_emp, qty, plus_minus, date_leave, date_expired, is_process_exp, note, type) VALUES (" + id_ot_det + ", " + id_employee + ", " + qty + ", 1, NOW(), '" + date_expired + "', 1, '" + note + "', 2)"

                execute_non_query(query, True, "", "", "", "")
            End If
        Next
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

    Private Sub RITEOvertimeHours_EditValueChanged(sender As Object, e As EventArgs) Handles RITEOvertimeHours.EditValueChanged
        calculatePointList(GVEmployee.GetFocusedDataSourceRowIndex)
    End Sub

    Private Sub SBFill_Click(sender As Object, e As EventArgs) Handles SBFill.Click
        Dim start_work As DateTime = TEOvertimeStart.EditValue
        Dim end_work As DateTime = TEOvertimeEnd.EditValue

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                If GVEmployee.GetRowCellValue(i, "start_work").ToString = "" Then
                    GVEmployee.SetRowCellValue(i, "start_work", start_work)

                    calculateTotalHoursList(i)
                End If

                If GVEmployee.GetRowCellValue(i, "end_work").ToString = "" Then
                    GVEmployee.SetRowCellValue(i, "end_work", end_work)

                    calculateTotalHoursList(i)
                End If
            End If
        Next
    End Sub

    Private Sub RISLUEDayOff_EditValueChanged(sender As Object, e As EventArgs) Handles RISLUEDayOff.EditValueChanged
        calculatePointList(GVEmployee.GetFocusedDataSourceRowIndex)
    End Sub
End Class