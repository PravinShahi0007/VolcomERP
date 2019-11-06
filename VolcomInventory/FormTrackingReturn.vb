Public Class FormTrackingReturn
    Private Sub FormTrackingReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormTrackingReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub FormTrackingReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTrackingReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_form()

    End Sub
End Class