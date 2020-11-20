Public Class FormPayoutZaloraDet
    Public id As String = "-1"
    Dim is_confirm As String = "-1"

    Private Sub FormPayoutZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim pz As New ClassPayoutZalora()
        Dim query As String = pz.queryMain("AND z.id_payout_zalora='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtStatementNumber.Text = data.Rows(0)("statement_number").ToString
        DECreatedAt.EditValue = data.Rows(0)("zalora_created_at")
        DESyncDate.EditValue = data.Rows(0)("sync_date")
        TxtCommision.EditValue = data.Rows(0)("default_comm")
        MENote.Text = data.Rows(0)("note").ToString
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutZaloraDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCommisionUpd_Click(sender As Object, e As EventArgs) Handles BtnCommisionUpd.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_payout_zalora SET default_comm='" + decimalSQL(TxtCommision.EditValue.ToString) + "' WHERE id_payout_zalora='" + id + "' "
        execute_non_query(query, True, "", "", "", "")
        validate_payout()
        infoCustom("Commision updated")
        Cursor = Cursors.Default
    End Sub

    Sub validate_payout()

    End Sub

    Private Sub Btnrecalculate_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        validate_payout()
    End Sub

    Private Sub BtnImportXls_Click(sender As Object, e As EventArgs) Handles BtnImportXls.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "55"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class