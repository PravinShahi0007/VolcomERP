Public Class ReportBiayaSewaBulanan
    Public Shared id_biaya As String = "-1"
    Public Shared dt As DataTable
    Public Shared id_report_status As String = "1"

    Private Sub ReportPurcAssetDep_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDepreciation.DataSource = dt

        If id_report_status = "6" Then
            load_mark_horz("294", id_biaya, "2", "2", XrTable1)
        Else
            pre_load_mark_horz("294", id_biaya, "2", "2", XrTable1)
        End If
    End Sub
End Class