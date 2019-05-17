Public Class FormEmployeePpsProgress
    Private Sub FormEmployeePpsProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBarControl.EditValue = 0
    End Sub

    Private Sub FormEmployeePpsProgress_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class