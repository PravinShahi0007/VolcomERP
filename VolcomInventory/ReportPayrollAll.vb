Public Class ReportPayrollAll
    Public id_pre As String
    Public id_payroll As String = ""
    Public type As String = ""
    Public dt As DataTable

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
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
            GBWorkingDays.Visible = False

            GCTotalTHP.Visible = False
            GCTotalAdjustment.Visible = False
            GCTotalDeduction.Visible = False

            GBDW.Visible = True

            GCStatus.Width = 150
        End If

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub
End Class