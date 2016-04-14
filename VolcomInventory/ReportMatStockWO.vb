Public Class ReportMatStockWO
    Public Shared dt As DataTable
    Public Shared str_param As System.IO.Stream
    Private Sub ReportFGStockWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub
End Class