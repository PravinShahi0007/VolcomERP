Public Class ReportPurcAssetDep
    Public Shared id_dep As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportPurcAssetDep_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDepreciation.DataSource = dt

        load_mark_horz("287", id_dep, "2", "2", XrTable1)
    End Sub
End Class