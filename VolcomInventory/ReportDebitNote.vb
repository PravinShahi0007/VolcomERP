Public Class ReportDebitNote
    Public Shared id_report As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportDebitNote_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        '
        load_mark_horz("221", id_report, "2", "1", XrTable1)
    End Sub
End Class