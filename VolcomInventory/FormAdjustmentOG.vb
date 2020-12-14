Public Class FormAdjustmentOG
    Private Sub FormAdjustmentOG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormAdjustmentOG_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAdjustmentOG_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAdjustmentOG_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()

    End Sub
End Class