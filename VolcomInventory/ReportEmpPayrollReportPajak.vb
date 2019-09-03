Public Class ReportEmpPayrollReportPajak
    Public Shared data As DataTable

    Private Sub ReportEmpPayrollReportPajak_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPajak.DataSource = data
    End Sub
End Class