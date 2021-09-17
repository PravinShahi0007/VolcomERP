Public Class ReportStockTakeStoreBAPHasil
    Public id As String = "-1"
    Public report_mark_type As String = "-1"

    Private Sub ReportStockTakeStoreBAPHasil_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If Not report_mark_type = "0" Then
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub
End Class