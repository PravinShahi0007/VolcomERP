Public Class ReportSNISerahTerima
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportSNISerahTerima_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCList.DataSource = dt
        pre_load_mark_horz("321", id, "2", "2", XrTable1)
    End Sub
End Class