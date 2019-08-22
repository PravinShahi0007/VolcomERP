Public Class ReportPayrollAll
    Public id_pre As String
    Public id_payroll As String = ""
    Public type As String = ""
    Public dt As DataTable
    Public last_alphabet As Integer = 0

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        dt.DefaultView.Sort = "departement ASC, departement_sub ASC"
        dt = dt.DefaultView.ToTable

        Dim alphabet As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        Dim iAlphabet As Integer = last_alphabet
        Dim iInterger As Integer = 0

        Dim last_departement As String = ""
        Dim last_departement_sub As String = ""

        For i = 0 To dt.Rows.Count - 1
            Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(dt.Rows(i)("departement").ToString, "\(([A-Z])\)", "").ToString()
            Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(dt.Rows(i)("departement_sub").ToString, "\(([A-Z])\)", "").ToString()

            If i = 0 Then
                last_departement = curr_departement
                last_departement_sub = curr_departement_sub
            End If

            If Not last_departement = curr_departement Then
                iAlphabet += 1
                iInterger = 0
            End If

            If Not last_departement_sub = curr_departement_sub Then
                iInterger += 1
            End If

            dt.Rows(i)("departement") = curr_departement + " (" + alphabet(iAlphabet) + ")"
            dt.Rows(i)("departement_sub") = curr_departement_sub + " (" + alphabet(iAlphabet) + iInterger.ToString + ")"

            last_departement = curr_departement
            last_departement_sub = curr_departement_sub
        Next

        GCPayroll.DataSource = dt

        If type = "1" Then
            GBWorkingDays.Visible = True
            GBSalary.Visible = True

            GBDW.Visible = False

            GCPosition.Caption = "Employee" + Environment.NewLine + "Position"
            GCStatus.Caption = "Employee" + Environment.NewLine + "Status"
            GCActualWorkingDays.Caption = "Actual" + Environment.NewLine + "WD"
            GCOvertimeHours.Caption = "Overtime" + Environment.NewLine + "(Hours)"
            GCTotalTHP.Caption = "Total" + Environment.NewLine + "THP"
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeduction.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertime.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"
        End If

        If type = "4" Then
            GCActualWorkingDaysDW.Caption = "Actual" + Environment.NewLine + "Working Days"
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeduction.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertime.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"

            GBWorkingDays.Visible = False

            GCTotalTHP.Visible = False

            GBDW.Visible = True

            GCStatus.Width = 100
        End If

        GCName.SummaryItem.DisplayFormat = "Grand Total: " + XLLocation.Text.ToUpper

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVPayroll_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayroll.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Dim sum_tot_thp As Double = 0
    Dim sum_tot_adj As Double = 0
    Dim sum_tot_ded As Double = 0
    Dim sum_tot_ot As Double = 0
    Dim sum_tot_dw As Double = 0
    Dim sum_tot As Double = 0

    Private Sub GVPayroll_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayroll.CustomSummaryCalculate

        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "tot_thp" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_thp = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_thp += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_thp
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_thp
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_adjustment" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_adj = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_adj += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_adj
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_adj
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_deduction" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_ded = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_ded += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_ded
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_ded
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_ot_wages" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_ot = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_ot += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_ot
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_ot
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_salary_dw" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_dw = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_dw += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_dw
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_dw
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "grand_total" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "employee_name" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(GVPayroll.GetRowCellValue(e.RowHandle, "departement").ToString, "\(([A-Z])\)", "").ToString()
                    Dim alphabet As String = GVPayroll.GetRowCellValue(e.RowHandle, "departement").ToString.Replace(curr_departement, "")

                    Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString, "\(([A-Z][0-9])\)", "").ToString()
                    Dim alphabet_sub As String = GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Replace(curr_departement_sub, "")

                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If e.GroupLevel = 1 Then
                            e.TotalValue = "Total: " + alphabet_sub.Replace("(", "").Replace(")", "")
                        Else
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    End If
            End Select
        End If
    End Sub
End Class