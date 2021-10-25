Public Class FormVMStoreDisplayQty
    Public action As String = ""
    Public id_display_type As String = "-1"
    Public id_item As String = "-1"
    Public id_comp As String = "-1"

    Private Sub FormVMStoreDisplayQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
        If action = "ins" Then
            resetInput()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT ds.qty FROM tb_display_store ds WHERE ds.id_comp=" + id_comp + " and ds.id_item=" + id_item + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SPQty.EditValue = data.Rows(0)("qty")
        End If
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dt.id_display_type, dt.display_type FROM tb_display_type dt WHERE 1=1 "
        If action = "upd" Then
            query += "AND dt.id_display_type='" + id_display_type + "' "
        End If
        viewSearchLookupQuery(SLEType, query, "id_display_type", "display_type", "id_display_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewItem()
        Cursor = Cursors.WaitCursor
        Dim id_display_type As String = "-1"
        Try
            id_display_type = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT i.id_item, i.item_desc, u.uom
        FROM tb_item i
        INNER JOIN tb_display_type dt ON dt.id_display_type = i.id_display_type
        INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
        LEFT JOIN tb_display_store ds ON ds.id_item = i.id_item AND ds.id_comp='" + id_comp + "'
        WHERE i.id_display_type = '" + id_display_type + "' "
        If action = "ins" Then
            query += "AND ISNULL(ds.id_item) "
        ElseIf action = "upd" Then
            query += "AND i.id_item='" + id_item + "' "
        End If
        query +="ORDER BY i.item_desc ASC "
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
        Cursor = Cursors.Default
    End Sub

    Sub resetInput()
        SPQty.EditValue = 1
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormVMStoreDisplayQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim vm As New ClassVMStoreDisplay()
        Dim cek_avail As Boolean = vm.checkAvailItem()

        If Not cek_avail Then
            stopCustom("Can't update, this item is already used.")
        ElseIf SLEItem.EditValue = Nothing Then
            stopCustom("Please complete all data")
        Else
            Dim id_item_selected As String = SLEItem.EditValue.ToString
            Dim qty As String = decimalSQL(SPQty.EditValue.ToString)
            Dim query As String = "DELETE FROM tb_display_store WHERE id_comp='" + id_comp + "' AND id_item='" + id_item_selected + "'; 
            INSERT INTO tb_display_store(id_comp, id_item, qty) VALUES('" + id_comp + "', '" + id_item_selected + "', '" + qty + "'); "
            execute_non_query(query, True, "", "", "", "")
            If action = "ins" Then
                'insert
                refreshMainView()
                viewItem()
                resetInput()
            Else
                'update
                refreshMainView()
                Close()
            End If
        End If
    End Sub

    Sub refreshMainView()
        FormVMStoreDisplayDet.viewData()
        FormVMStoreDisplayDet.GVData.FocusedRowHandle = find_row(FormVMStoreDisplayDet.GVData, "id_item", SLEItem.EditValue.ToString)
    End Sub

    Private Sub SLEItem_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItem.EditValueChanged

    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        viewItem()
    End Sub
End Class