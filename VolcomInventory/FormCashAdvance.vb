Public Class FormCashAdvance
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormCashAdvance_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormCashAdvance_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bedit_active = "1"
        bdel_active = "1"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCashAdvance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click

    End Sub
End Class