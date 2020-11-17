Public Class ReportReturnNote
    Public Shared dt As DataTable

    Private Sub ReportReturnNote_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt
    End Sub
End Class