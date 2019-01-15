Public Class ReportListProd
    Public Shared dt As DataTable

    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCProd.DataSource = dt
        pre_load_list_horz("22", 2, 1, XrTable1)
    End Sub
End Class