Public Class FormProdDemandAdd
    Private Sub FormProdDemandAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProdDemandAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
End Class