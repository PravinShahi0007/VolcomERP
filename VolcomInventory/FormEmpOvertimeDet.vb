Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
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
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")

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

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Dim include As String = ""

            If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
                For i = 0 To FormEmpOvertime.GVProposeEmployee.RowCount - 1
                    If FormEmpOvertime.GVProposeEmployee.IsValidRowHandle(i) Then
                        include += FormEmpOvertime.GVProposeEmployee.GetRowCellValue(i, "id_ot_det").ToString + ", "
                    End If
                Next

                If Not include = "" Then
                    Dim id_ot_det As String = FormEmpOvertime.GVProposeEmployee.GetFocusedRowCellValue("id_ot_det").ToString

                    include = include.Substring(0, include.Length - 2)

                    FormEmpOvertime.load_overtime("id_det" + include)

                    FormEmpOvertime.GVProposeEmployee.FocusedRowHandle = find_row(FormEmpOvertime.GVProposeEmployee, "id_ot_det", id_ot_det)
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
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")

        'overtime
        Dim ReportOvertime As New ReportEmpOvertime()

        ReportOvertime.id = id
        ReportOvertime.data = GCEmployee.DataSource
        ReportOvertime.id_pre = If(id_report_status = "6", "-1", "1")

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
        Dim ot_date As String = If(date_include.Count = 0, "", date_include(0) + " - " + date_include.Last)
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
        ReportMemo.id_pre = If(id_report_status = "6", "-1", "1")

        ReportMemo.XLTo.Text = data_employee.Rows(0)("employee_name").ToString
        ReportMemo.XLToPosition.Text = "- " + data_employee.Rows(0)("employee_position").ToString
        ReportMemo.XLCC1.Text = data_employee.Rows(1)("employee_name").ToString
        ReportMemo.XLCC1Position.Text = "- " + data_employee.Rows(1)("employee_position").ToString
        ReportMemo.XLCC2.Text = data_employee.Rows(2)("employee_name").ToString
        ReportMemo.XLCC2Position.Text = "- " + data_employee.Rows(2)("employee_position").ToString
        ReportMemo.XLFrom.Text = data_employee.Rows(3)("employee_name").ToString
        ReportMemo.XLFromPosition.Text = "- " + data_employee.Rows(3)("employee_position").ToString
        ReportMemo.XLHal.Text = "Budget Konsumsi Lembur " + StrConv(TEDepartement.EditValue.ToString, VbStrConv.ProperCase) + " " + ot_date

        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[departement]", StrConv(TEDepartement.EditValue.ToString, VbStrConv.ProperCase))
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
                If view.GetFocusedRowCellValue("is_day_off").ToString = "1" Then
                    clone.RowFilter = "[to_salary] = 2"
                Else
                    clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                End If
            End If

            edit.Properties.DataSource = clone
        End If
    End Sub

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