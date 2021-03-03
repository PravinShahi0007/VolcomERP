Public Class ReportWeightPPS
    Public Shared id_pps As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"

    Private Sub ReportWeightPPS_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItem.DataSource = dt
        pre_load_mark_horz(rmt, id_pps, "2", "2", XrTable1)
    End Sub
End Class