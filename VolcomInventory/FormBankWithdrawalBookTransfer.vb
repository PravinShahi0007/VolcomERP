Public Class FormBankWithdrawalBookTransfer
    Private Sub FormBankWithdrawalBookTransfer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankWithdrawalBookTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pay_from()
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLETrfTo, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        Close()
    End Sub
End Class