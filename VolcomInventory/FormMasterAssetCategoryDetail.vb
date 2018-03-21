Public Class FormMasterAssetCategoryDetail
    Public id_asset_cat As String = "-1"

    Private Sub FormMasterAssetCategoryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_asset_cat = "-1" Then
            Dim query_view As String = "SELECT * FROM tb_a_asset_cat WHERE id_asset_cat='" & id_asset_cat & "'"
            Dim data_view As DataTable = execute_query(query_view, -1, True, "", "", "", "")
            '
            TECatCode.Text = data_view.Rows(0)("asset_cat_code").ToString
            TECat.Text = data_view.Rows(0)("asset_cat").ToString
        End If
    End Sub

    Private Sub FormMasterAssetCategoryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_asset_cat = "-1" Then 'new
            Dim query_ins As String = "INSERT INTO tb_a_asset_cat(asset_cat_code,asset_cat) VALUES('" & TECatCode.Text & "','" & TECat.Text & "')"
            execute_non_query(query_ins, True, "", "", "", "")
            infoCustom("Category added.")
            FormMasterAssetCategory.load_cat()
            Close()
        Else 'edit
            Dim query_upd As String = "UPDATE tb_a_asset_cat SET asset_cat_code='" & TECatCode.Text & "',asset_cat='" & TECat.Text & "' WHERE id_asset_cat='" & id_asset_cat & "'"
            execute_non_query(query_upd, True, "", "", "", "")
            infoCustom("Category updated.")
            FormMasterAssetCategory.load_cat()
            Close()
        End If
    End Sub
End Class