Public Class ReportSalesPOSWeekly
    Public Shared dt As DataTable
    Public Shared ds As DataSet

    Private Sub ReportSalesPOSWeekly_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub
End Class