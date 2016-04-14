Public Class ReportMatStockSum
    Public Shared dt As DataTable
    Public Shared str_param As System.IO.Stream
    Private Sub ReportFGStockSum_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub
End Class