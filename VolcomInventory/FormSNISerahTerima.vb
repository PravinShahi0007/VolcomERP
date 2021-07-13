Public Class FormSNISerahTerima
    Private Sub FormSNISerahTerima_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_list()

    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_list()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSNISerahTerimaDet.ShowDialog()
    End Sub
End Class