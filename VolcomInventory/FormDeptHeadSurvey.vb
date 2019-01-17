Public Class FormDeptHeadSurvey
    Public is_hrd As String = "-1"

    Sub load_employee()

    End Sub

    Private Sub FormDeptHeadSurvey_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormDeptHeadSurvey_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class