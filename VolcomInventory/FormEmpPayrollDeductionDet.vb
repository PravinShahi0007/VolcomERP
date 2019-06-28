Public Class FormEmpPayrollDeductionDet
    '1 Deduction, 2 Adjustment
    Public id_popup As String = "1"
    Public id_payroll As String = "-1"

    Sub load_deduction()
        Dim column As String = "deduction"

        If id_popup = "1" Then
            column = "deduction"
        ElseIf id_popup = "2" Then
            column = "adjustment"
        End If

        Dim query_type As String = "SELECT id_salary_" + column + "_cat AS id_salary_deduction_cat, salary_" + column + "_cat AS salary_deduction_cat FROM tb_lookup_salary_" + column + "_cat"
        viewSearchLookupQuery(SLUEType, query_type, "id_salary_deduction_cat", "salary_deduction_cat", "id_salary_deduction_cat")

        Dim query_category As String = "SELECT id_salary_" + column + " AS id_salary_deduction, id_salary_" + column + "_cat AS id_salary_deduction_cat, salary_" + column + " AS salary_deduction, use_days FROM tb_lookup_salary_" + column + ""
        viewSearchLookupQuery(SLUECategory, query_category, "id_salary_deduction", "salary_deduction", "id_salary_deduction")

        SLUECategory.EditValue = Nothing
    End Sub

    Private Sub FormEmpPayrollDeductionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_popup = "1" Then
            Text = "Deduction Detail"
        ElseIf id_popup = "2" Then
            Text = "Bonus / Adjustment Detail"
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
            If GVDeduction.RowCount > 0 Then
                Dim id_salary_dadj As String = SLUECategory.EditValue.ToString
                Dim note As String = MENote.Text.ToString

                For i = 0 To GVDeduction.RowCount - 1
                    If GVDeduction.IsValidRowHandle(i) Then
                        Dim id_employee As String = GVDeduction.GetRowCellValue(i, "id_employee").ToString
                        Dim value As String = GVDeduction.GetRowCellValue(i, "value").ToString
                        Dim total_days As String = GVDeduction.GetRowCellValue(i, "total_days").ToString
                        Dim increase As String = GVDeduction.GetRowCellValue(i, "total_salary").ToString

                        Dim query As String = ""

                        If id_popup = "1" Then
                            query = "
                                INSERT INTO tb_emp_payroll_deduction (id_payroll, id_salary_deduction, id_employee, total_days, increase, deduction, note) VALUES (" + id_payroll + ", " + id_salary_dadj + ", " + id_employee + ", " + decimalSQL(total_days) + ", " + decimalSQL(increase) + ", " + decimalSQL(value) + ", '" + addSlashes(note) + "')
                            "
                        ElseIf id_popup = "2" Then
                            query = "
                                INSERT INTO tb_emp_payroll_adj (id_payroll, id_salary_adj, id_employee, total_days, increase, value, note) VALUES (" + id_payroll + ", " + id_salary_dadj + ", " + id_employee + ", " + decimalSQL(total_days) + ", " + decimalSQL(increase) + ", " + decimalSQL(value) + ", '" + addSlashes(note) + "')
                            "
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
                If SLUECategory.Properties.View.GetRowCellValue(row, "use_days").ToString = "1" Then
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

    Sub calculate_value()
        For i = 0 To GVDeduction.RowCount - 1
            If GVDeduction.IsValidRowHandle(i) Then
                Dim value As Integer = 0

                Try
                    Dim total_days As Decimal = GVDeduction.GetRowCellValue(i, "total_days")
                    Dim workdays As Decimal = GVDeduction.GetRowCellValue(i, "workdays")
                    Dim total_salary As Integer = GVDeduction.GetRowCellValue(i, "total_salary")

                    value = (total_days / workdays) * total_salary
                Catch ex As Exception
                End Try

                GVDeduction.SetRowCellValue(i, "value", value)
            End If
        Next
    End Sub

    Private Sub GVDeduction_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDeduction.CellValueChanged
        If e.Column.FieldName.ToString = "total_days" Then
            calculate_value()
        End If

        GVDeduction.BestFitColumns()
    End Sub
End Class