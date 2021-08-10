Public Class ReportStockTakeStoreBAPHasil
    Public id As String = "-1"

    Private Sub ReportStockTakeStoreBAPHasil_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pre_load_mark_horz("324", id, "2", "2", XrTable1)
    End Sub
End Class