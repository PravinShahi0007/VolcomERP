Public Class FormEmpPerAppraisal
    Public is_dephead As String = "-1"

    Sub load_employee()

    End Sub

    Private Sub FormEmpPerAppraisal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()
    End Sub

    Private Sub FormEmpPerAppraisal_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormEmpPerAppraisal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class