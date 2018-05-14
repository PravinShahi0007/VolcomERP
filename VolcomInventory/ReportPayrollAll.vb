Public Class ReportPayrollAll
    Public Shared id_payroll As String = ""
    Public Shared dt As DataTable
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayroll.DataSource = dt
    End Sub
End Class