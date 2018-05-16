Public Class FormFGLineListAddPrice
    Private Sub FormFGLineListAddPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT default_add_price FROM tb_opt"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtPrice.EditValue = data.Rows(0)("default_add_price")
    End Sub

    Private Sub FormFGLineListAddPrice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim query As String = "UPDATE tb_opt SET default_add_price='" + decimalSQL(TxtPrice.EditValue) + "' "
        execute_non_query(query, True, "", "", "", "")
        Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class