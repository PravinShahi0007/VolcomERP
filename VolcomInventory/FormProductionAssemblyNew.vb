Public Class FormProductionAssemblyNew
    Private Sub FormProductionAssemblyNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormProductionAssemblyNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class