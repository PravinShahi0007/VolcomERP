Public Class FormVMStoreDisplayDet
    Public id_store As String = "-1"

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(GCData, TxtStoreCode.Text + " : " + TxtStoreName.Text + " - Display Item List")
    End Sub

    Private Sub FormVMStoreDisplayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormVMStoreDisplayDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ds.id_item, i.item_desc, i.id_display_type,dt.display_type,  SUM(ds.qty) AS `qty`
        FROM tb_display_store ds 
        INNER JOIN tb_item i ON i.id_item = ds.id_item
        INNER JOIN tb_display_type dt ON dt.id_display_type = i.id_display_type
        WHERE ds.id_comp=" + id_store + "
        GROUP BY i.id_item
        ORDER BY i.item_desc ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddItem_Click(sender As Object, e As EventArgs) Handles BtnAddItem.Click
        Cursor = Cursors.WaitCursor
        FormVMStoreDisplayQty.action = "ins"
        FormVMStoreDisplayQty.id_comp = id_store
        FormVMStoreDisplayQty.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim vm As New ClassVMStoreDisplay()
            Dim cek_avail As Boolean = vm.checkAvailItem()

            If cek_avail Then
                Cursor = Cursors.WaitCursor
                FormVMStoreDisplayQty.action = "upd"
                FormVMStoreDisplayQty.id_comp = id_store
                FormVMStoreDisplayQty.id_display_type = GVData.GetFocusedRowCellValue("id_display_type").ToString
                FormVMStoreDisplayQty.id_item = GVData.GetFocusedRowCellValue("id_item").ToString
                FormVMStoreDisplayQty.ShowDialog()
                Cursor = Cursors.Default
            Else
                stopCustom("Can't update, this item is already used.")
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim vm As New ClassVMStoreDisplay()
            Dim cek_avail As Boolean = vm.checkAvailItem()

            If cek_avail Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "DELETE FROM tb_display_store WHERE id_comp='" + id_store + "' AND id_item='" + GVData.GetFocusedRowCellValue("id_item").ToString + "' "
                    execute_non_query(query, True, "", "", "", "")
                    viewData()
                End If
            Else
                stopCustom("Can't update, this item is already used.")
            End If
        End If
    End Sub
End Class