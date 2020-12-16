Public Class FormSalesPOSCompare
    Public dt As DataTable
    Private Sub FormSalesPOSCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSalesPOSCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class