Public Class ReportProposeVoucherPOS
    Public id As String = "-1"

    Private Sub ReportProposeVoucherPOS_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pre_load_mark_horz("412", id, "2", "2", XrTable1)
    End Sub
End Class