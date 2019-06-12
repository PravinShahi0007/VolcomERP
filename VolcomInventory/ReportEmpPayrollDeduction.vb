Public Class ReportEmpPayrollDeduction
    Public data As DataTable = New DataTable

    Private Sub ReportEmpPayrollDeduction_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDeduction.DataSource = data
    End Sub
End Class