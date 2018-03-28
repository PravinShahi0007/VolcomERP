Public Class FormAssetPODet
    Public id_po As String = "-1"
    Private Sub FormAssetPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cat()
        load_dept()
        '
        load_list()
    End Sub

    Sub load_list()
        Dim query As String = "SELECT * FROM tb_a_asset_po_det WHERE id_asset_po='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEDepartement, query, 0, "departement", "id_departement")
    End Sub
    Sub addMyRow()
        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
        newRow("id_asset_po_det") = "0"
        newRow("id_asset_cat") = 1
        newRow("id_departement") = 1
        newRow("vendor_sku") = ""
        newRow("desc") = ""
        newRow("qty") = 0
        newRow("value") = 0.00
        newRow("disc") = 0.00
        newRow("total") = 0.00
        newRow("note") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        'CType(GCItemList.DataSource, DataTable).AcceptChanges()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub
    Sub load_cat()
        Dim query As String = "SELECT id_asset_cat,asset_cat FROM tb_a_asset_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupRepositoryQuery(RILEAssetCat, query, 0, "asset_cat", "id_asset_cat")
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        addMyRow()
        GVItemList.BestFitColumns()
    End Sub
End Class