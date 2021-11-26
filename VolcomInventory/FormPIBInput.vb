Public Class FormPIBInput
    Public id_pib_review As String = ""

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormPIBInput_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click

    End Sub

    Private Sub FormPIBInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT "
    End Sub
End Class