Public Class FormGuide
    Private Sub FormGuide_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormGuide_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormGuide_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormGuide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Url = New Uri(get_setup_field("guide_address"))
    End Sub
End Class