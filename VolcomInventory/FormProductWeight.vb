Public Class FormProductWeight
    Public id_trans As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormProductWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProductWeight_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub load_pil()
        Dim q As String = ""
    End Sub
End Class