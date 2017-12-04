Public Class FormProdDebitNoteDet
    Public id_dn As String = "-1"
    Public id_comp_contact_debit_to As String = "-1"

    Private Sub FormProdDebitNoteDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    Sub action_load()
        Dim date_dn As Date = Now()
        DEForm.Text = date_dn.ToString("dd MMM yyyy")
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProdDebitNoteDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "84"
        FormPopUpContact.ShowDialog()
    End Sub
End Class