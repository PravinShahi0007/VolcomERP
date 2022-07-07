Public Class ReportProposePaymentCardPOS
    Public id As String = "-1"

    Private Sub ReportProposePaymentCardPOS_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewSearchLookupRepositoryQuery(RISLUEAccount, "SELECT id_acc, CONCAT(acc_name, ' - ', acc_description) AS acc FROM tb_a_acc WHERE id_status = 1 AND id_is_det = 2", 0, "acc", "id_acc")

        pre_load_mark_horz("415", id, "2", "2", XrTable1)
    End Sub
End Class