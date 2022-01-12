Public Class ReportDeviden
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared is_pre As Boolean = False

    Private Sub ReportDeviden_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCHistory.DataSource = dt
        If is_pre Then
            pre_load_mark_horz("384", id, "2", "2", XrTable1)
        Else
            load_mark_horz("384", id, "2", "2", XrTable1)
        End If
    End Sub
End Class