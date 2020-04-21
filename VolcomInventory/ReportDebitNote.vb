Public Class ReportDebitNote
    Public Shared id_report As String = "-1"
    Public Shared dt As DataTable
    Public Shared vendor As String = ""

    Private Sub ReportDebitNote_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        '
        pre_load_mark_horz("221", id_report, vendor, "2", XrTable1)
    End Sub
End Class