Public Class FormAssetPODet
    Public id_po As String = "-1"
    Private Sub FormAssetPODet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVat.EditValue = 10
        '
        DEPODate.EditValue = Now
        DEEstRecDate.EditValue = Now
        '
        load_cat()
        load_dept()
        '
        load_list()
    End Sub

    Sub load_list()
        Dim query As String = "SELECT *,0 as 'total' FROM tb_a_asset_po_det WHERE id_asset_po='" & id_po & "'"
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
        newRow("value") = 0.0
        newRow("disc") = 0.0
        newRow("total") = 0.00
        newRow("note") = ""
        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
        'CType(GCItemList.DataSource, DataTable).AcceptChanges()
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub
    Sub deleteRow()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        If GVItemList.RowCount <= 0 Then
            stopCustom("Not found")
        Else
            GVItemList.DeleteSelectedRows()
            makeSafeGV(GVItemList)
        End If
        GVItemList.RefreshData()
        Cursor = Cursors.Default
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_po = "-1" Then 'new
            Dim date_po As String = Date.Parse(DEPODate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_est_rec As String = Date.Parse(DEEstRecDate.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_a_asset_po(id_term_payment,asset_po_no,asset_po_date,est_rec_date,comp_name,comp_attn,comp_address,comp_phone,comp_fax,note)"
        Else 'edit

        End If
    End Sub

    Private Sub FormAssetPODet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            'TAMBAH
            addMyRow()
        ElseIf e.KeyCode = Keys.F2 Then
            'DELETE
            deleteRow()
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        GVItemList.DeleteSelectedRows()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged
        Try
            GVItemList.SetRowCellValue(e.RowHandle, "total", ((GVItemList.GetRowCellValue(e.RowHandle, "value") - GVItemList.GetRowCellValue(e.RowHandle, "disc")) * GVItemList.GetRowCellValue(e.RowHandle, "qty")))
        Catch ex As Exception

        End Try
        calculate()
    End Sub

    Sub calculate()
        Try
            TETotal.EditValue = GVItemList.Columns("total").SummaryItem.SummaryValue
            TEVATAmount.EditValue = (TETotal.EditValue * TEVat.EditValue) / 100
            TEGrandTotal.EditValue = TETotal.EditValue + TEVATAmount.EditValue
        Catch ex As Exception

        End Try
    End Sub
End Class