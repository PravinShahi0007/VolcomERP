Public Class FormSetupBudgetCAPEX
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim report_desc As String = ""
    Dim report_year As String = ""

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSetupBudgetCAPEX_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_budget()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStartCard.EditValue = Now
        DEUntilCard.EditValue = Now
    End Sub
End Class