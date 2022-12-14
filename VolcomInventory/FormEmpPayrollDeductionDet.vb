Public Class FormEmpPayrollDeductionDet
    '1 Deduction, 2 Adjustment
    Public id As String = "-1"
    Public id_popup As String = "1"
    Public id_payroll As String = "-1"

    Private payroll_type As DataTable = New DataTable

    Sub load_deduction()
        Dim column As String = "deduction"

        If id_popup = "1" Then
            column = "deduction"
        ElseIf id_popup = "2" Then
            column = "adjustment"
        End If

        Dim query_where_typ As String = ""
        Dim query_where_cat As String = ""

        If payroll_type.Rows(0)("is_dw").ToString = "1" Then
            query_where_typ = "WHERE id_salary_" + column + "_cat IN (SELECT id_salary_" + column + "_cat FROM tb_lookup_salary_" + column + " WHERE use_dw = 1)"
            query_where_cat = "WHERE use_dw = 1"
        End If

        If payroll_type.Rows(0)("is_thr").ToString = "1" Then
            query_where_typ = "WHERE id_salary_" + column + "_cat IN (SELECT id_salary_" + column + "_cat FROM tb_lookup_salary_" + column + " WHERE use_thr = 1)"
            query_where_cat = "WHERE use_thr = 1"
        End If

        Dim query_type As String = "SELECT id_salary_" + column + "_cat AS id_salary_deduction_cat, salary_" + column + "_cat AS salary_deduction_cat FROM tb_lookup_salary_" + column + "_cat" + " " + query_where_typ
        viewSearchLookupQuery(SLUEType, query_type, "id_salary_deduction_cat", "salary_deduction_cat", "id_salary_deduction_cat")

        Dim query_category As String = "SELECT id_salary_" + column + " AS id_salary_deduction, id_salary_" + column + "_cat AS id_salary_deduction_cat, salary_" + column + " AS salary_deduction, use_days FROM tb_lookup_salary_" + column + " " + query_where_cat
        viewSearchLookupQuery(SLUECategory, query_category, "id_salary_deduction", "salary_deduction", "id_salary_deduction")

        SLUECategory.EditValue = Nothing

        Dim query_option As String = "SELECT 'total_days' AS `option` UNION ALL SELECT 'value' AS `option`"
        viewSearchLookupQuery(SLUEApplyOption, query_option, "option", "option", "option")
    End Sub

    Private Sub FormEmpPayrollDeductionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_popup = "1" Then
            Text = "Deduction Detail"
        ElseIf id_popup = "2" Then
            Text = "Bonus / Adjustment Detail"
        End If

        'type
        payroll_type = execute_query("SELECT is_dw, is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, -1, True, "", "", "", "")

        If payroll_type.Rows(0)("is_thr").ToString = "1" Then
            GCWorkingDays.Caption = "Working Years"
            GCTotalDays.Caption = "Total Years"
            GCActualWorkingDays.Caption = "Actual Working Years"
        Else
            GCWorkingDays.Caption = "Working Days"
            GCTotalDays.Caption = "Total Days"
            GCActualWorkingDays.Caption = "Actual Working Days"
        End If

        load_deduction()

        Dim data As DataTable = New DataTable()

        data.Columns.Add("id_employee", GetType(Integer))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("employee_status", GetType(String))
        data.Columns.Add("workdays", GetType(Decimal))
        data.Columns.Add("actual_workdays", GetType(Decimal))
        data.Columns.Add("total_salary", GetType(Integer))
        data.Columns.Add("total_days", GetType(Decimal))
        data.Columns.Add("value", GetType(Integer))

        GCDeduction.DataSource = data

        'edit
        If Not id = "-1" Then
            SBInsert.Enabled = False
            SBRemove.Enabled = False

            Dim query As String = ""

            If id_popup = "1" Then
                query = "
                    SELECT emp.id_employee, dep.departement, emp.employee_code, emp.employee_name, emp.employee_position, sts.employee_status, pyl.workdays, pyl.actual_workdays, IF(COALESCE(ded.increase, 0) = 0, (IF(emp.id_employee_status = 3, (sal.total_salary * dep.total_workdays), sal.total_salary)), ded.increase) AS total_salary, ded.total_days, ded.deduction AS value, ded.id_salary_deduction AS id_salary_adj, ldedc.id_salary_deduction_cat AS id_salary_adj_cat, ded.note
                    FROM tb_emp_payroll_deduction AS ded
                    LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
                    LEFT JOIN tb_lookup_employee_level AS lv ON emp.id_employee_level = lv.id_employee_level
                    LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                    LEFT JOIN tb_lookup_employee_active AS act ON emp.id_employee_active = act.id_employee_active
                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                    LEFT JOIN tb_emp_payroll_det AS pyl ON emp.id_employee = pyl.id_employee AND pyl.id_payroll = " + id_payroll + "
                    LEFT JOIN (
                        SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS total_salary
                        FROM tb_m_employee_salary
                    ) AS sal ON sal.id_employee_salary = pyl.id_salary
                    LEFT JOIN tb_lookup_salary_deduction AS lded ON lded.id_salary_deduction = ded.id_salary_deduction
                    LEFT JOIN tb_lookup_salary_deduction_cat AS ldedc ON ldedc.id_salary_deduction_cat = lded.id_salary_deduction_cat
                    WHERE id_payroll_deduction = " + id + "
                "
            ElseIf id_popup = "2" Then
                query = "
                    SELECT emp.id_employee, dep.departement, emp.employee_code, emp.employee_name, emp.employee_position, sts.employee_status, pyl.workdays, pyl.actual_workdays, IF(COALESCE(adj.increase, 0) = 0, (IF(emp.id_employee_status = 3, (sal.total_salary * dep.total_workdays), sal.total_salary)), adj.increase) AS total_salary, adj.total_days, adj.value, adj.id_salary_adj, ladjc.id_salary_adjustment_cat AS id_salary_adj_cat, adj.note
                    FROM tb_emp_payroll_adj AS adj
                    LEFT JOIN tb_m_employee AS emp ON adj.id_employee = emp.id_employee
                    LEFT JOIN tb_lookup_employee_level AS lv ON emp.id_employee_level = lv.id_employee_level
                    LEFT JOIN tb_lookup_employee_status AS sts ON emp.id_employee_status = sts.id_employee_status
                    LEFT JOIN tb_lookup_employee_active AS act ON emp.id_employee_active = act.id_employee_active
                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                    LEFT JOIN tb_emp_payroll_det AS pyl ON emp.id_employee = pyl.id_employee AND pyl.id_payroll = " + id_payroll + "
                    LEFT JOIN (
                        SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS total_salary
                        FROM tb_m_employee_salary
                    ) AS sal ON sal.id_employee_salary = pyl.id_salary
                    LEFT JOIN tb_lookup_salary_adjustment AS ladj ON ladj.id_salary_adjustment = adj.id_salary_adj
                    LEFT JOIN tb_lookup_salary_adjustment_cat AS ladjc ON ladjc.id_salary_adjustment_cat = ladj.id_salary_adjustment_cat
                    WHERE id_payroll_adj = " + id + "
                "
            End If

            data = execute_query(query, -1, True, "", "", "", "")

            SLUEType.EditValue = data.Rows(0)("id_salary_adj_cat")
            SLUECategory.EditValue = data.Rows(0)("id_salary_adj")
            MENote.EditValue = data.Rows(0)("note")

            SLUECategory_EditValueChanged(SLUECategory, New EventArgs)

            GCDeduction.DataSource = data
        End If
    End Sub

    Private Sub FormEmpPayrollDeductionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        EP_SLE_cant_blank(ErrorProvider, SLUECategory)

        If formIsValidInPanel(ErrorProvider, PanelControl1) Then
            If id_popup = "1" And SLUECategory.EditValue.ToString = "1" Then
                'disable bpjs kesehatan
                errorCustom(SLUECategory.Text + " cannot be added.")
            Else
                If GVDeduction.RowCount > 0 Then
                    Dim id_salary_dadj As String = SLUECategory.EditValue.ToString
                    Dim note As String = MENote.Text.ToString

                    Dim row As Integer = SLUECategory.Properties.GetIndexByKeyValue(SLUECategory.EditValue)

                    Dim data As DataTable = SLUECategory.Properties.DataSource

                    For i = 0 To GVDeduction.RowCount - 1
                        If GVDeduction.IsValidRowHandle(i) Then
                            Dim id_employee As String = GVDeduction.GetRowCellValue(i, "id_employee").ToString
                            Dim value As String = GVDeduction.GetRowCellValue(i, "value").ToString
                            Dim total_days As String = If(data.Rows(row)("use_days").ToString = "1", GVDeduction.GetRowCellValue(i, "total_days").ToString, "")
                            Dim increase As String = If(data.Rows(row)("use_days").ToString = "1", GVDeduction.GetRowCellValue(i, "total_salary").ToString, "0")

                            Dim query As String = ""

                            If id = "-1" Then
                                If id_popup = "1" Then
                                    query = "
                                    INSERT INTO tb_emp_payroll_deduction (id_payroll, id_salary_deduction, id_employee, total_days, increase, deduction, note) VALUES (" + id_payroll + ", " + id_salary_dadj + ", " + id_employee + ", " + If(total_days = "", "NULL", decimalSQL(total_days)) + ", " + decimalSQL(increase) + ", " + decimalSQL(value) + ", '" + addSlashes(note) + "')
                                "
                                ElseIf id_popup = "2" Then
                                    query = "
                                    INSERT INTO tb_emp_payroll_adj (id_payroll, id_salary_adj, id_employee, total_days, increase, value, note) VALUES (" + id_payroll + ", " + id_salary_dadj + ", " + id_employee + ", " + If(total_days = "", "NULL", decimalSQL(total_days)) + ", " + decimalSQL(increase) + ", " + decimalSQL(value) + ", '" + addSlashes(note) + "')
                                "
                                End If
                            Else
                                If id_popup = "1" Then
                                    query = "UPDATE tb_emp_payroll_deduction SET id_salary_deduction = " + id_salary_dadj + ", total_days = " + If(total_days = "", "NULL", decimalSQL(total_days)) + ", increase = " + decimalSQL(increase) + ", deduction = " + decimalSQL(value) + ", note = '" + addSlashes(note) + "' WHERE id_payroll_deduction = " + id
                                ElseIf id_popup = "2" Then
                                    query = "UPDATE tb_emp_payroll_adj SET id_salary_adj = " + id_salary_dadj + ", total_days = " + If(total_days = "", "NULL", decimalSQL(total_days)) + ", increase = " + decimalSQL(increase) + ", value = " + decimalSQL(value) + ", note = '" + addSlashes(note) + "' WHERE id_payroll_adj = " + id
                                End If
                            End If

                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next

                    If id_popup = "1" Then
                        FormEmpPayrollDeduction.load_deduction()
                    ElseIf id_popup = "2" Then
                        FormEmpPayrollAdjustment.load_adjustment()
                    End If

                    Close()
                Else
                    errorCustom("No employee inserted.")
                End If
            End If
        Else
            errorCustom("Please check your input.")
        End If
    End Sub

    Private Sub SBInsert_Click(sender As Object, e As EventArgs) Handles SBInsert.Click
        FormEmpPayrollADPick.id_payroll = id_payroll

        FormEmpPayrollADPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVDeduction.DeleteSelectedRows()
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        SLUECategory.EditValue = Nothing
    End Sub

    Private Sub SLUECategory_Click(sender As Object, e As EventArgs) Handles SLUECategory.Click
        SLUECategory.Properties.View.ActiveFilterString = "id_salary_deduction_cat = " + SLUEType.EditValue.ToString
    End Sub

    Private Sub SLUECategory_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUECategory.Validating
        If SLUECategory.EditValue = Nothing Then
            ErrorProvider.SetError(SLUECategory, "Don't leave it blank.")
        Else
            ErrorProvider.SetError(SLUECategory, String.Empty)
        End If
    End Sub

    Private Sub SLUECategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLUECategory.EditValueChanged
        Dim row As Integer = SLUECategory.Properties.GetIndexByKeyValue(SLUECategory.EditValue)

        Dim data As DataTable = SLUECategory.Properties.DataSource

        If row < 0 Then
            GCNIP.VisibleIndex = 0
            GCEmployee.VisibleIndex = 1
            GCEmployeePosition.VisibleIndex = 2
            GCEmployeeStatus.VisibleIndex = 3
            GCValue.VisibleIndex = 4
            GCWorkingDays.VisibleIndex = -1
            GCActualWorkingDays.VisibleIndex = -1
            GCTotalSalary.VisibleIndex = -1
            GCTotalDays.VisibleIndex = -1
        Else
            Try
                If data.Rows(row)("use_days").ToString = "1" Then
                    GCTotalDays.OptionsColumn.AllowEdit = True

                    GCNIP.VisibleIndex = 0
                    GCEmployee.VisibleIndex = 1
                    GCEmployeePosition.VisibleIndex = 2
                    GCEmployeeStatus.VisibleIndex = 3
                    GCWorkingDays.VisibleIndex = 4
                    GCActualWorkingDays.VisibleIndex = 5
                    GCTotalSalary.VisibleIndex = 6
                    GCTotalDays.VisibleIndex = 7
                    GCValue.VisibleIndex = 8
                Else
                    GCTotalDays.OptionsColumn.AllowEdit = False

                    GCNIP.VisibleIndex = 0
                    GCEmployee.VisibleIndex = 1
                    GCEmployeePosition.VisibleIndex = 2
                    GCEmployeeStatus.VisibleIndex = 3
                    GCValue.VisibleIndex = 4
                    GCWorkingDays.VisibleIndex = -1
                    GCActualWorkingDays.VisibleIndex = -1
                    GCTotalSalary.VisibleIndex = -1
                    GCTotalDays.VisibleIndex = -1
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GVDeduction_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDeduction.CellValueChanged
        If e.Column.FieldName.ToString = "total_days" Or e.Column.FieldName.ToString = "total_salary" Then
            Dim value As Integer = 0

            Try
                If payroll_type.Rows(0)("is_thr").ToString = "1" Then
                    Dim total_days As Decimal = GVDeduction.GetRowCellValue(e.RowHandle, "total_days")
                    Dim workdays As Decimal = GVDeduction.GetRowCellValue(e.RowHandle, "workdays")
                    Dim total_salary As Integer = GVDeduction.GetRowCellValue(e.RowHandle, "total_salary")

                    value = total_days * total_salary
                Else
                    Dim total_days As Decimal = GVDeduction.GetRowCellValue(e.RowHandle, "total_days")
                    Dim workdays As Decimal = GVDeduction.GetRowCellValue(e.RowHandle, "workdays")
                    Dim total_salary As Integer = GVDeduction.GetRowCellValue(e.RowHandle, "total_salary")

                    value = (total_days / workdays) * total_salary
                End If
            Catch ex As Exception
            End Try

            GVDeduction.SetRowCellValue(e.RowHandle, "value", value)
        End If

        GVDeduction.BestFitColumns()
    End Sub

    Private Sub GVDeduction_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVDeduction.RowCellClick
        If e.Button = MouseButtons.Right And e.Column.FieldName = "total_salary" Then
            PMSalary.ClearLinks()

            Dim query As String = "CALL view_payroll_salary(" + GVDeduction.GetFocusedRowCellValue("id_employee").ToString + ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            For i = 0 To data.Rows.Count - 1
                Dim item As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                item.Caption = Format(data.Rows(i)("salary"), "##,##0") + " (" + data.Rows(i)("effective_date").ToString + ")"

                AddHandler item.ItemClick, AddressOf itemClick

                PMSalary.AddItem(item)
            Next

            PMSalary.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Sub itemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim salary As String = System.Text.RegularExpressions.Regex.Replace(e.Item.Caption.ToString, "\((.*)\)", "").ToString()

        salary = salary.Replace(".", "").Replace(" ", "")

        GVDeduction.SetFocusedRowCellValue("total_salary", Decimal.Parse(salary))
    End Sub

    Private Sub SBApply_Click(sender As Object, e As EventArgs) Handles SBApply.Click
        Dim con As Boolean = True

        'check use day
        If SLUEApplyOption.EditValue.ToString = "total_days" Then
            If GCTotalDays.VisibleIndex = -1 Then
                con = False
            End If
        End If

        If con Then
            For i = 0 To GVDeduction.RowCount - 1
                If GVDeduction.IsValidRowHandle(i) Then
                    GVDeduction.SetRowCellValue(i, SLUEApplyOption.EditValue.ToString, SLUEApplyText.EditValue)
                End If
            Next
        End If
    End Sub
End Class