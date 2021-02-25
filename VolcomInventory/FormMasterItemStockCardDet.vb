Public Class FormMasterItemStockCardDet
    Public id_item_detail As String = "-1"
    Private Sub FormMasterItemStockCardDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_item()
    End Sub

    Sub load_item()
        Dim q As String = "SELECT id_item,item_desc,def_desc 
FROM tb_item
WHERE is_active=1"
        viewSearchLookupQuery(SLEItem, q, "id_item", "item_desc", "id_item")
        SLEItem.EditValue = Nothing
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormMasterItemStockCardDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLEItem.EditValue = Nothing Then
            warningCustom("Please select item first")
        Else
            If id_item_detail = "-1" Then
                'new
                'cek dupe
                Dim qc As String = "SELECT * from tb_stock_card_dep_item WHERE id_item='" & SLEItem.EditValue.ToString & "',item_detail='" & addSlashes(MEDefDesc.Text) & "' AND remark='" & addSlashes(TERemark.Text) & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count > 0 Then
                    warningCustom("Same item already registered")
                Else
                    'insert
                    Dim q As String = "INSERT INTO `tb_stock_card_dep_item`(id_item,item_detail,remark)
VALUES('" & SLEItem.EditValue.ToString & "','" & addSlashes(MEDefDesc.Text) & "','" & addSlashes(TERemark.Text) & "')"
                    execute_query(q, -1, True, "", "", "", "")
                    FormMasterItemStockCard.load_item()
                    Close()
                End If
            Else
                'edit
                'cek dupe
                Dim qc As String = "SELECT * from tb_stock_card_dep_item WHERE id_item='" & SLEItem.EditValue.ToString & "',item_detail='" & addSlashes(MEDefDesc.Text) & "' AND remark='" & addSlashes(TERemark.Text) & "' AND id_item_detail!='" & id_item_detail & "'"
                Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                If dtc.Rows.Count > 0 Then
                    warningCustom("Same item already registered")
                Else
                    'cek sudah pernah stok
                    qc = "SELECT * FROM tb_stock_card_dep WHERE id_item_detail='" & id_item_detail & "'"
                    dtc = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        warningCustom("Item already have transaction")
                    Else
                        'update
                        Dim q As String = "UPDATE `tb_stock_card_dep_item` SET id_item='" & SLEItem.EditValue.ToString & "',item_detail='" & addSlashes(MEDefDesc.Text) & "',remark
,,'" & addSlashes(TERemark.Text) & "'"
                        execute_query(q, -1, True, "", "", "", "")
                        FormMasterItemStockCard.load_item()
                        Close()
                    End If
                End If
            End If
        End If
    End Sub
End Class