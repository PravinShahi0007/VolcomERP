Public Class FormMasterRawMaterialCat
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public Sub view_master_item_category()
        Dim query As String = "SELECT * FROM tb_m_mat_cat a ORDER BY mat_cat ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GridControlMasterItemCategory.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormMasterItemCategory_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
    End Sub
    Private Sub FormMasterItemCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_master_item_category()
    End Sub

    Private Sub GridViewMasterItemCategory_InitNewRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewMasterItemCategory.InitNewRow
        'GridViewMasterItemCategory.SetRowCellValue(e.RowHandle, "no", GridViewMasterItemCategory.RowCount)
    End Sub

    Private Sub FormMasterItemCategory_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterItemCategory_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class