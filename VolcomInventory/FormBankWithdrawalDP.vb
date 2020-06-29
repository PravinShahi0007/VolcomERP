Public Class FormBankWithdrawalDP
    Public id_popup As String = "-1"
    Dim id_report As String = "-1"

    Private Sub FormBankWithdrawalDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormBankWithdrawalDP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class