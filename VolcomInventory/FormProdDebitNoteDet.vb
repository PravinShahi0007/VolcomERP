Public Class FormProdDebitNoteDet
    Public id_dn As String = "-1"
    Private Sub FormProdDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    Sub action_load()
        Dim date_dn As Date = Now()
        DEForm.Text = date_dn.ToString("dd MMM yyyy")
    End Sub
End Class