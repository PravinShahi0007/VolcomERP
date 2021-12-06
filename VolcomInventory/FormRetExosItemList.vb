Public Class FormRetExosItemList
    Public id_comp As String = "-1"


    Private Sub FormRetExosItemList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_fg_barcode_size(DATE(NOW()), " + id_comp + ", 0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim dv As DataView = New DataView(data)
        Dim ftr As String = "id_extended_eos = '1' AND qty_avl>0 "
        For d As Integer = 0 To FormRetExosDet.GVItemList.RowCount - 1
            ftr += "AND NOT id_product='" + FormRetExosDet.GVItemList.GetRowCellValue(d, "id_product").ToString + "' "
        Next
        dv.RowFilter = ftr
        data = dv.ToTable
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRetExosItemList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[qty_input]>0 "
        If GVData.RowCount <= 0 Then
            stopCustom("No item selected")
        Else
            For i As Integer = 0 To GVData.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormRetExosDet.GCItemList.DataSource, DataTable)).NewRow()
                newRow("id_ret_exos_det") = "0"
                newRow("name") = GVData.GetRowCellValue(i, "name").ToString
                newRow("code") = GVData.GetRowCellValue(i, "code").ToString
                newRow("size") = GVData.GetRowCellValue(i, "size").ToString
                newRow("class") = GVData.GetRowCellValue(i, "class").ToString
                newRow("color") = GVData.GetRowCellValue(i, "color").ToString
                newRow("sht") = GVData.GetRowCellValue(i, "sht").ToString
                newRow("qty") = GVData.GetRowCellValue(i, "qty_input")
                'newRow("qty_avail") = GVData.GetRowCellValue(i, "qty_all_product")design_price_type
                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString
                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                TryCast(FormRetExosDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                FormRetExosDet.GCItemList.RefreshDataSource()
                FormRetExosDet.GVItemList.RefreshData()
            Next
            viewData()
        End If
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        'aktifkan jika dipakai (ada pembatasan berdasarkan limit)
        Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        Dim qty_rec As Decimal = SpQty.EditValue
        Dim qty_limit As Decimal = GVData.GetFocusedRowCellValue("qty_avl")
        If qty_rec > qty_limit Then
            stopCustom("Qty cannot exceed " + qty_limit.ToString + "")
            GVData.SetFocusedRowCellValue("qty_input", 0)
        End If
    End Sub
End Class