Public Class FormQCReport1
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormQCReport1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub load_qc_report1()

    End Sub

    Sub check_menu()
        If GVQCReport.RowCount = 0 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"

            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"

            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormQCReport1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormQCReport1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class