Public Class ReportProposePromo
    Public id_propose_promo As String = "0"

    Private Sub ReportProposePromo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pre_load_mark_horz("358", id_propose_promo, "2", "2", XrTable1)
    End Sub
End Class