Public Class FormScanReturnBAPProduct
    Public id_product As String = "-1"

    Private Sub FormScanReturnBAPProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormScanReturnBAPProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class