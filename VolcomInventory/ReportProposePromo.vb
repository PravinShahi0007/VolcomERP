Public Class ReportProposePromo
    Public id_propose_promo As String = "0"

    Private Sub ReportProposePromo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GVProduct.BestFitColumns()
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_propose_promo WHERE id_propose_promo = '" + id_propose_promo + "'", 0, True, "", "", "", "")

        pre_load_mark_horz(report_mark_type, id_propose_promo, "2", "2", XrTable1)
    End Sub
End Class