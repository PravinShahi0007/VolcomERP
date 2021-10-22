Public Class FormVMStoreDisplayQty
    Public action As String = ""
    Public id_item As String = "-1"
    Public id_comp As String = "-1"

    Private Sub FormVMStoreDisplayQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewItem()
        If action = "ins" Then
            resetInput()
        ElseIf action = "upd" Then
            SLEItem.EditValue = id_item
        End If
    End Sub

    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT i.id_item, i.item_desc, dt.display_type, u.uom
        FROM tb_item i
        INNER JOIN tb_display_type dt ON dt.id_display_type = i.id_display_type
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        ORDER BY i.item_desc ASC "
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
        Cursor = Cursors.Default
    End Sub

    Sub resetInput()
        SLEItem.EditValue = Nothing
        SPQty.EditValue = 1
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormVMStoreDisplayQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If SLEItem.EditValue = Nothing Then
            stopCustom("Please complete all data")
        Else
            Dim id_item_selected As String = SLEItem.EditValue.ToString
            Dim qty As String = decimalSQL(SPQty.EditValue.to)
            Dim query As String = "DELETE FROM tb_display_store WHERE id_comp='" + id_comp + "' AND id_item='" + id_item_selected + "'; 
            INSERT INTO tb_display_store(id_comp, id_item, qty) VALUES('" + id_comp + "', '" + id_item_selected + "', '" + qty + "'); "
            execute_non_query(query, True, "", "", "", "")
            If action = "ins" Then
                'insert

            Else
                'update
            End If
        End If
    End Sub

    Private Sub SLEItem_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItem.EditValueChanged
        If SLEItem.EditValue = Nothing Then
            resetInput()
        Else
            TxtDisplayType.Text = SLEItem.Properties.View.GetFocusedRowCellValue("display_type").ToString
        End If
    End Sub
End Class