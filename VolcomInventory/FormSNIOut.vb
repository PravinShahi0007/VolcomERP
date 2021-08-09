Public Class FormSNIOut
    Public id As String = "-1"
    Private Sub FormSNIOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSNIOut_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_det()
        Dim q As String = ""
    End Sub

    Private Sub BAddProduct_Click(sender As Object, e As EventArgs) Handles BAddProduct.Click
        FormPopUpRecQC.id_pop_up = "5"
        FormPopUpRecQC.ShowDialog()
    End Sub

    Private Sub BDeleteProduct_Click(sender As Object, e As EventArgs) Handles BDeleteProduct.Click

    End Sub
End Class