Public Class FormAccountingDraftJournalSingle
    Public id_acc As String = "-1"
    Public id_comp As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormAccountingDraftJournalSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtDebit.EditValue = 0.00
        TxtCredit.EditValue = 0.00
        ActiveControl = TxtAccountAcc
    End Sub
End Class