Public Class FormReportMarkCancelList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    '
    Private Sub FormReportMarkCancelList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportMarkCancelList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormReportMarkCancelList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If GVListCancel.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormReportMarkCancelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_cancel_form()
        Dim query_cancel As String = ""
        Dim data_cancel As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
    End Sub
End Class