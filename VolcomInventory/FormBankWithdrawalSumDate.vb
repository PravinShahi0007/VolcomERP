Public Class FormBankWithdrawalSumDate
    Public id_pn_sum_det As String = ""
    Private Sub FormBankWithdrawalSumDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        'update
        If Not id_pn_sum_det = "" Then
            Dim q As String = "UPDATE tb_pn_summary_det SET id_pn_summary_type='2',change_date_to='" & Date.Parse(DEReleaseDate.EditValue.ToString) & "' WHERE id_pn_summary_det='" & id_pn_sum_det & "'"
            execute_non_query(q, True, "", "", "", "")
            FormBankWithdrawalSum.load_det()
            Close()
        End If
    End Sub

    Private Sub FormBankWithdrawalSumDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEReleaseDate.EditValue = Now
    End Sub
End Class