Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public id As String = "0"

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        ' default
        DEOvertimeDate.EditValue = Now
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMM yyyy h:mm:ss tt")
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT 1 AS id_type, 'Salary' AS type UNION SELECT 2 AS id_type, 'DP' AS type", 0, "type", "id_type")
        viewLookupQuery(LUEPayrollPeriod, "SELECT id_payroll, periode_start, periode_end, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1", 0, "periode", "id_payroll")

        Dim data As DataTable = New DataTable

        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("only_dp", GetType(String))
        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("id_employee_level", GetType(String))
        data.Columns.Add("employee_level", GetType(String))
        data.Columns.Add("conversion_type", GetType(String))

        GCEmployee.DataSource = data

        'load database
        If Not id = "0" Then
            Dim query_ot As String = "
                SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%l:%i:%s %p') AS ot_end_time, TIMESTAMPDIFF(HOUR, ot.ot_start_time, ot.ot_end_time) AS total_hours, ot.ot_note, ot.id_payroll, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, ot.number, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %l:%i:%s %p') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
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
            MEOvertimeNote.EditValue = data_ot.Rows(0)("ot_note").ToString
            LUEPayrollPeriod.ItemIndex = LUEPayrollPeriod.Properties.GetDataSourceRowIndex("id_payroll", data_ot.Rows(0)("id_payroll").ToString)
            TEReportStatus.EditValue = data_ot.Rows(0)("report_status").ToString

            ' load employee
            Dim query_ot_det As String = "
                SELECT ot_det.id_employee, 'no' AS only_dp, ot_det.id_departement, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, ot_det.conversion_type
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                WHERE ot_det.id_ot = " + id + "
            "

            Dim data_ot_det As DataTable = execute_query(query_ot_det, -1, True, "", "", "", "")

            GCEmployee.DataSource = data_ot_det

            GVEmployee.BestFitColumns()
        End If

        calculateTotalHours()

        ' permission
        If Not id = "0" Then
            LUEOvertimeType.ReadOnly = True
            DEOvertimeDate.ReadOnly = True
            TEOvertimeStart.ReadOnly = True
            TEOvertimeEnd.ReadOnly = True
            MEOvertimeNote.ReadOnly = True
            LUEPayrollPeriod.ReadOnly = True

            RISLUEType.ReadOnly = True

            SBEmpDelete.Enabled = False
            SBEmpAdd.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSave.Enabled = False
        End If
    End Sub

    Sub calculateTotalHours()
        TEOvertimeStart.EditValue = Date.Parse(Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd") + " " + Date.Parse(TEOvertimeStart.EditValue.ToString).ToString("HH:mm:ss"))
        TEOvertimeEnd.EditValue = Date.Parse(Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd") + " " + Date.Parse(TEOvertimeEnd.EditValue.ToString).ToString("HH:mm:ss"))

        If TEOvertimeStart.EditValue < TEOvertimeEnd.EditValue Then
            Dim diff As TimeSpan = TEOvertimeEnd.EditValue - TEOvertimeStart.EditValue

            TETotalHours.EditValue = Math.Floor(diff.TotalHours).ToString + " Hours"
        Else
            TETotalHours.EditValue = "0 Hours"
        End If
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
        ElseIf GVEmployee.RowCount <= 0 Then
            errorCustom("No employee selected.")
        ElseIf Not formIsValidInGroup(ErrorProvider, GroupControl3) Then
            errorCustom("Please check your input.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit overtime ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                Dim ot_date As String = Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim ot_start_time As String = Date.Parse(TEOvertimeStart.EditValue.ToString).ToString("HH:mm:ss")
                Dim ot_end_time As String = Date.Parse(TEOvertimeEnd.EditValue.ToString).ToString("HH:mm:ss")

                query = "INSERT INTO tb_ot (id_ot_type, ot_date, ot_start_time, ot_end_time, ot_note, id_payroll, id_report_status, number, created_by, created_at) VALUES (" + LUEOvertimeType.EditValue.ToString + ", '" + ot_date + "', '" + ot_start_time + "', '" + ot_end_time + "', '" + addSlashes(MEOvertimeNote.Text.ToString) + "', " + LUEPayrollPeriod.EditValue.ToString + ", 1, '0', " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

                id = execute_query(query, 0, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        query = "INSERT INTO tb_ot_det (id_ot, id_employee, id_departement, employee_position, id_employee_level, conversion_type) VALUES (" + id + ", " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", " + GVEmployee.GetRowCellValue(i, "id_departement").ToString + ", '" + addSlashes(GVEmployee.GetRowCellValue(i, "employee_position").ToString) + "', " + GVEmployee.GetRowCellValue(i, "id_employee_level").ToString + ", " + GVEmployee.GetRowCellValue(i, "conversion_type").ToString + ")"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                submit_who_prepared("184", id, id_user)

                execute_non_query("CALL gen_number(" + id + ", '184')", True, "", "", "", "")

                FormEmpOvertime.DEStart.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)
                FormEmpOvertime.DEUntil.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)

                FormEmpOvertime.load_overtime("ot_date")

                Close()
            End If
        End If
    End Sub

    Private Sub RISLUEType_Click(sender As Object, e As EventArgs) Handles RISLUEType.Click
        If GVEmployee.GetFocusedRowCellValue("only_dp").ToString = "yes" Then
            RISLUETypeView.ActiveFilterString = "[id_type] = '2'"
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
        Dim Report As New ReportEmpOvertime()

        Report.id = id
        Report.data = GCEmployee.DataSource

        Report.XLNumber.Text = TENumber.Text.ToString
        Report.XLOTtype.Text = LUEOvertimeType.Text.ToString
        Report.XLOTDate.Text = DEOvertimeDate.Text.ToString
        Report.XLOTTime.Text = TEOvertimeStart.Text.ToString + " - " + TEOvertimeEnd.Text.ToString + " (" + TETotalHours.Text.ToString + ")"
        Report.XLPayrollPeriod.Text = LUEPayrollPeriod.Text.ToString
        Report.XLCreatedAt.Text = TECreatedBy.Text.ToString
        Report.XLCreatedBy.Text = TECreatedAt.Text.ToString
        Report.XLOTNote.Text = MEOvertimeNote.Text.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub
End Class