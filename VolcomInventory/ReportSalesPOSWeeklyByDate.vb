Public Class ReportSalesPOSWeeklyByDate
    Public Shared dt As DataTable
    Public Shared ds As DataSet

    Private Sub ReportSalesPOSWeeklyByDate_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSalesWeeklyByDate.DataSource = dt
    End Sub
End Class