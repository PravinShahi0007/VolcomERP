Public Class ReportFGWoffList
    Public Shared dt As DataTable

    Private Sub ReportFGWoffList_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
    End Sub
End Class