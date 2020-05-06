Public Class FormOlStoreReturnListUpdate
    Private Sub FormOlStoreReturnListUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_status()
        Dim q As String = "SELECT id_ol_store_ret_stt,ol_store_ret_stt
FROM `tb_lookup_ol_store_ret_stt`
WHERE is_only_cs='1'"
        viewSearchLookupQuery(SLEStatus, q, "id_ol_store_ret_stt", "ol_store_ret_stt", "id_ol_store_ret_stt")
    End Sub

    Private Sub FormOlStoreReturnListUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_status()
    End Sub

    Private Sub BSetStatus_Click(sender As Object, e As EventArgs) Handles BSetStatus.Click
        Dim q As String = ""
        For i As Integer = 0 To FormOlStoreReturnList.GVList.RowCount - 1
            q += "UPDATE tb_ol_store_ret_list SET id_ol_store_ret_stt='" & SLEStatus.EditValue.ToString & "' WHERE `id_ol_store_ret_list`='" & FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString & "';"
        Next
        execute_non_query(q, True, "", "", "", "")
        FormOlStoreReturnList.view_list()
        infoCustom("Update status completed")
        Close()
    End Sub
End Class