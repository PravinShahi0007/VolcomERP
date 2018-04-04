Public Class FormAssetRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Sub check_but()
        If GVRecList.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click

    End Sub

    Sub load_rec()

    End Sub

    Private Sub FormAssetRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        load_pil()
        load_rec()
    End Sub
    Sub load_pil()
        Dim query As String = "SELECT '1' id_pil,'By Receiving Date' as pil_name
                                UNION
                               SELECT '2' id_pil,'By Created Date' as pil_name
                                UNION
                               SELECT '3' id_pil,'By Last Update Date' as pil_name"
        viewLookupQuery(LEPil, query, 2, "pil_name", "id_pil")
    End Sub

    Private Sub FormAssetRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormAssetRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class