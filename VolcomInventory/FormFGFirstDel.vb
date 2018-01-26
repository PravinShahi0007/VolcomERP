Public Class FormFGFirstDel
    Private Sub FormFGFirstDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormFGFirstDel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormFGFirstDel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class