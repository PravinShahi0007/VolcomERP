Public Class ReportProductionKO
    Public Shared dt As DataTable
    Private Sub ReportProductionKO_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt
    End Sub
End Class