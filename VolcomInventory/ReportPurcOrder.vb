Public Class ReportPurcOrder
    Public Shared id_po As String
    Public id_pre As String
    Public Shared dt As DataTable
    Public rmt As String = "-1"

    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz(rmt, id_po, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(rmt, id_po, "2", "2", XrTable1)
        End If
    End Sub
End Class