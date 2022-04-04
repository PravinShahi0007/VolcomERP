Public Class ReportSampleDevTarget
    Public Shared id_pps As String
    Public Shared dt As DataTable
    Public rmt As String = "403"

    Private Sub ReportSampleDevTarget_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPps.DataSource = dt
        load_mark_horz("403", id_pps, LVendor.Text, "2", XrTable8)
    End Sub
End Class