Public Class FormReportBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click

    End Sub

    Private Sub FormReportBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
End Class