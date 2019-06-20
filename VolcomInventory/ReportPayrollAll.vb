Public Class ReportPayrollAll
    Public Shared id_payroll As String = ""
    Public Shared dt As DataTable

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayroll.DataSource = dt

        GVPayroll.Columns("actual_workdays").Caption = "Actual" + Environment.NewLine + "Working Days"
        GVPayroll.Columns("employee_position").Caption = "Employee" + Environment.NewLine + "Position"
        GVPayroll.Columns("employee_level").Caption = "Employee" + Environment.NewLine + "Level"
        GVPayroll.Columns("tot_thp").Caption = "Total" + Environment.NewLine + "THP"
        GVPayroll.Columns("total_adjustment").Caption = "Total" + Environment.NewLine + "Bonus / Adjustment"
        GVPayroll.Columns("total_deduction").Caption = "Total" + Environment.NewLine + "Deduction"
        GVPayroll.Columns("total_ot_wages").Caption = "Total" + Environment.NewLine + "Overtime"
        GVPayroll.Columns("grand_total").Caption = "Grand" + Environment.NewLine + "Total"
    End Sub
End Class