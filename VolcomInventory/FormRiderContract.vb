Public Class FormRiderContract
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormItemExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormRiderContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_contract()
        Dim q As String = ""
    End Sub

    Private Sub BChanges_Click(sender As Object, e As EventArgs) Handles BChanges.Click
        FormRiderContractDet.ShowDialog()
    End Sub

    Private Sub GVPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVPPS.DoubleClick
        If GVPPS.RowCount > 0 Then
            FormRiderContractDet.id_pps = ""
            FormRiderContractDet.ShowDialog()
        End If
    End Sub
End Class