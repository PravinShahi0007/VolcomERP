Public Class ReportPurcAssetDisp
    Public id_trans As String = ""
    Public dt As DataTable
    Private Sub ReportPurcAssetDisp_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItem.DataSource = dt

        load_mark_horz("298", id_trans, "2", "1", XrTable1)
    End Sub
End Class