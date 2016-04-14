Public Class SplashScreen1
    Sub New
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub PictureEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles PictureEdit2.EditValueChanged

    End Sub
End Class
