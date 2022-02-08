Public Class ReportPIBPPS
    Public Shared dt As DataTable
    Public Shared id As String = "-1"

    Private Sub ReportPIBPPS_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPIBPPps.DataSource = dt
        GVPIBPps.BestFitColumns()
        '
        pre_load_mark_horz("359", id, "2", "2", XrTable1)
    End Sub
End Class