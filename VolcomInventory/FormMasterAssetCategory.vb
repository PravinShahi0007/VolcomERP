Public Class FormMasterAssetCategory
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Private Sub FormMasterAssetCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
    End Sub

    Sub load_cat()
        Dim query As String = "SELECT * FROM tb_a_asset_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCAssetCat.DataSource = data
        check_but()
    End Sub

    Sub check_but()
        If GVAssetCat.RowCount > 0 Then
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

    Private Sub FormMasterAssetCategory_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_but()
    End Sub

    Private Sub FormMasterAssetCategory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterAssetCategory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class