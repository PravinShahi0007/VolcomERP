Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public is_check As String = "-1"
    Public id As String = "0"

    Private is_point_ho As String = "0"

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Detail"
        Else
            Text = "Overtime Management Detail"
        End If

        form_load()
    End Sub

    Sub form_load()
        ' default
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary FROM tb_lookup_ot_conversion", 0, "type", "id_type")

        TEDepartement.EditValue = get_departement_x(id_departement_user, "1")

        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMM yyyy HH:mm:ss")

        load_default()

        'load database
        If Not id = "0" Then
            Dim query_ot As String = "
                SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, ot.id_departement, departement.departement, ot.number, ot.ot_note, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE ot.id_ot = " + id + "
            "

            Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

            TENumber.EditValue = data_ot.Rows(0)("number").ToString
            LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)
            TEDepartement.EditValue = data_ot.Rows(0)("departement").ToString
            TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
            TECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString
            MEOvertimeNote.EditValue = data_ot.Rows(0)("ot_note").ToString
            TEReportStatus.EditValue = data_ot.Rows(0)("report_status").ToString

            ' load employee
            ' column
            Dim query_ot_det As String = "
                SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, ot_det.conversion_type, ot_det.is_day_off, DATE_FORMAT(ot_det.ot_start_time, '%d %M %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%d %M %Y %H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
                WHERE ot_det.id_ot = " + id + "
                ORDER BY ot_det.ot_date ASC, departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC
            "

            Dim data_ot_det As DataTable = execute_query(query_ot_det, -1, True, "", "", "", "")

            GCEmployee.DataSource = data_ot_det

            GVEmployee.BestFitColumns()
        End If

        ' permission
        If Not id = "0" Then
            LUEOvertimeType.ReadOnly = True
            MEOvertimeNote.ReadOnly = True

            RISLUEType.ReadOnly = True

            SBEmpDelete.Enabled = False
            SBEmpAdd.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSave.Enabled = False
        End If
    End Sub

    Sub load_default()
        Dim data As DataTable = New DataTable

        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("id_departement_sub", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("ot_date", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("id_employee_status", GetType(String))
        data.Columns.Add("employee_status", GetType(String))
        data.Columns.Add("to_salary", GetType(String))
        data.Columns.Add("conversion_type", GetType(String))
        data.Columns.Add("is_day_off", GetType(String))
        data.Columns.Add("ot_start_time", GetType(DateTime))
        data.Columns.Add("ot_end_time", GetType(DateTime))
        data.Columns.Add("ot_break", GetType(Decimal))
        data.Columns.Add("ot_total_hours", GetType(Decimal))

        GCEmployee.DataSource = data
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

        'force calculate point head office
        Dim data As DataTable = LUEOvertimeType.Properties.DataSource

        If is_point_ho = "0" Then
            is_point_ho = execute_query("SELECT is_point_ho FROM tb_lookup_ot_type WHERE id_ot_type = " + LUEOvertimeType.EditValue.ToString, 0, True, "", "", "", "")
        End If

        If is_point_ho = "1" Then
            is_store = "2"
        End If

        GVEmployee.SetRowCellValue(i, "point", calc_point(overtime_hour, is_day_off, is_store))

        If GVEmployee.GetRowCellValue(i, "only_dp").ToString = "yes" Then
            GVEmployee.SetRowCellValue(i, "point", overtime_hour)
        End If

        GVEmployee.RefreshData()
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Dim include As String = ""

            If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
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
        FormEmpOvertimeDate.is_hrd = is_hrd

        FormEmpOvertimeDate.ShowDialog()
    End Sub

    Private Sub SBEmpDelete_Click(sender As Object, e As EventArgs) Handles SBEmpDelete.Click
        GVEmployee.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        MEOvertimeNote_Validating(MEOvertimeNote, New System.ComponentModel.CancelEventArgs)

        If GVEmployee.RowCount <= 0 Then
            errorCustom("No employee selected.")
        ElseIf Not formIsValidInPanel(ErrorProvider, PanelControl4) Then
            errorCustom("Please check your input.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                query = "INSERT INTO tb_ot (id_ot_type, id_departement, ot_note, id_report_status, created_by, created_at) VALUES (" + LUEOvertimeType.EditValue.ToString + ", " + id_departement_user + ", '" + addSlashes(MEOvertimeNote.Text.ToString) + "', 1, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

                id = execute_query(query, 0, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                        Dim id_departement As String = GVEmployee.GetRowCellValue(i, "id_departement").ToString
                        Dim id_departement_sub As String = GVEmployee.GetRowCellValue(i, "id_departement_sub").ToString
                        Dim employee_position As String = GVEmployee.GetRowCellValue(i, "employee_position").ToString
                        Dim id_employee_status As String = GVEmployee.GetRowCellValue(i, "id_employee_status").ToString
                        Dim to_salary As String = GVEmployee.GetRowCellValue(i, "to_salary").ToString
                        Dim conversion_type As String = GVEmployee.GetRowCellValue(i, "conversion_type").ToString
                        Dim is_day_off As String = GVEmployee.GetRowCellValue(i, "is_day_off").ToString
                        Dim ot_date As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_date").ToString).ToString("yyyy-MM-dd")
                        Dim ot_start_time As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_start_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim ot_end_time As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_end_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim ot_break As String = GVEmployee.GetRowCellValue(i, "ot_break").ToString

                        query = "INSERT INTO tb_ot_det (id_ot, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, to_salary, conversion_type, is_day_off, ot_date, ot_start_time, ot_end_time, ot_break) VALUES (" + id + ", " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", " + to_salary + ", " + conversion_type + ", " + is_day_off + ", '" + ot_date + "', '" + ot_start_time + "', '" + ot_end_time + "', " + decimalSQL(ot_break) + ")"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                execute_non_query("CALL gen_number(" + id + ", '184')", True, "", "", "", "")

                submit_who_prepared("184", id, id_user)

                ' load overtime
                FormEmpOvertime.DEStart.EditValue = Now
                FormEmpOvertime.DEUntil.EditValue = Now

                FormEmpOvertime.load_overtime("created_at")

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

        FormReportMark.report_mark_type = "184"
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        'overtime
        Dim ReportOvertime As New ReportEmpOvertime()

        ReportOvertime.id = id
        ReportOvertime.data = GCEmployee.DataSource

        ReportOvertime.XLNumber.Text = TENumber.Text.ToString
        ReportOvertime.XLOTtype.Text = LUEOvertimeType.Text.ToString
        ReportOvertime.XLCreatedAt.Text = TECreatedBy.Text.ToString
        ReportOvertime.XLCreatedBy.Text = TECreatedAt.Text.ToString
        ReportOvertime.XLOTNote.Text = MEOvertimeNote.Text.ToString

        ReportOvertime.GVEmployee.BestFitColumns()

        ReportOvertime.CreateDocument()

        'memo
        Dim hours As Integer = get_opt_emp_field("ot_memo_employee")
        Dim ot_consumption As Decimal = get_opt_emp_field("ot_consumption")

        Dim data As DataTable = GCEmployee.DataSource

        Dim employee As DataTable = data.Clone

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("ot_total_hours") >= hours Then
                employee.ImportRow(data.Rows(i))
            End If
        Next

        'date
        Dim date_include As List(Of String) = New List(Of String)

        For i = 0 To employee.Rows.Count - 1
            If Not date_include.Contains(employee.Rows(i)("ot_date").ToString) Then
                date_include.Add(employee.Rows(i)("ot_date").ToString)
            End If
        Next

        'departement
        Dim departement_include As List(Of String) = New List(Of String)

        For i = 0 To employee.Rows.Count - 1
            If Not departement_include.Contains(employee.Rows(i)("departement").ToString) Then
                departement_include.Add(employee.Rows(i)("departement").ToString)
            End If
        Next

        Dim departement As String = String.Join(", ", departement_include)
        Dim ot_date As String = String.Join(", ", date_include)
        Dim total_consumption As Decimal = ot_consumption * employee.Rows.Count()

        'employee
        Dim data_employee As DataTable = execute_query("
            SELECT employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_to FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_cc1 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_cc2 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_from FROM tb_opt_emp LIMIT 1)
        ", -1, True, "", "", "", "")

        Dim ReportMemo As New ReportEmpOvertimeMemo()

        ReportMemo.id = id

        ReportMemo.XLTo.Text = data_employee.Rows(0)("employee_name").ToString
        ReportMemo.XLToPosition.Text = "- " + data_employee.Rows(0)("employee_position").ToString
        ReportMemo.XLCC1.Text = data_employee.Rows(1)("employee_name").ToString
        ReportMemo.XLCC1Position.Text = "- " + data_employee.Rows(1)("employee_position").ToString
        ReportMemo.XLCC2.Text = data_employee.Rows(2)("employee_name").ToString
        ReportMemo.XLCC2Position.Text = "- " + data_employee.Rows(2)("employee_position").ToString
        ReportMemo.XLFrom.Text = data_employee.Rows(3)("employee_name").ToString
        ReportMemo.XLFromPosition.Text = "- " + data_employee.Rows(3)("employee_position").ToString

        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[departement]", TEDepartement.EditValue.ToString)
        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[ot_date]", ot_date)
        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[total_consumption]", Format(total_consumption, "##,##0"))

        ReportMemo.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To ReportOvertime.Pages.Count - 1
            list.Add(ReportOvertime.Pages(i))
        Next

        If employee.Rows.Count > 0 Then
            For i = 0 To ReportMemo.Pages.Count - 1
                list.Add(ReportMemo.Pages(i))
            Next
        End If

        ReportOvertime.Pages.AddRange(list)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(ReportOvertime)
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

            If view.GetFocusedRowCellValue("to_salary").ToString = "1" Then
                clone.RowFilter = ""
            Else
                clone.RowFilter = "[to_salary] = 2"
            End If

            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs)
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
                'Dim query As String = "
                '    UPDATE tb_ot SET id_payroll = '" + SLUEPayrollPeriod.EditValue.ToString + "', id_check_status = 1, hrd_check = 1 WHERE id_ot = " + id + "
                '"

                'execute_non_query(query, True, "", "", "", "")

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

                        'query = "UPDATE tb_ot_det SET only_dp = '" + GVEmployee.GetRowCellValue(i, "only_dp").ToString + "', conversion_type = '" + conversion_type + "', is_day_off = '" + is_day_off + "', start_work = " + start_work + ", end_work = " + end_work + ", break_hours = " + decimalSQL(break_hours) + ", overtime_hours = " + decimalSQL(overtime_hours) + ", is_valid = " + is_valid + " WHERE id_ot = " + id + " AND id_employee = " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ""

                        'execute_non_query(query, True, "", "", "", "")
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
            SELECT ot_det.conversion_type, departement.is_store, ot_det.id_payroll, payroll.periode_end, ot_det.id_employee, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp, ot.id_ot_type, ot_type.is_point_ho, ot_det.ot_date, ot_det.start_work AS ot_start, ot_det.end_work AS ot_end, ot_det.break_hours AS total_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.start_work, ot_det.end_work) / 60) - ot_det.break_hours, 1) AS total_hour, IFNULL(ot_det.overtime_hours, 0.0) AS overtime_hours, 0 AS total_point, IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1))) AS is_day_off, ot_type.ot_point_wages AS wages_per_point, ot.ot_note AS note, ot_det.id_ot_det
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN (
                SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                FROM tb_m_employee
            ) AS salary ON ot_det.id_employee = salary.id_employee
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_emp_payroll AS payroll ON ot_det.id_payroll = payroll.id_payroll
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

            'force calculate point head office
            If data.Rows(i)("is_point_ho").ToString = "1" Then
                is_store = "2"
            End If

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

    Private Sub LUEOvertimeType_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles LUEOvertimeType.EditValueChanging
        If Not GVEmployee.RowCount = 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Change overtime type will reset employee list, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                load_default()
            Else
                e.Cancel = True
            End If
        End If
    End Sub
End Class