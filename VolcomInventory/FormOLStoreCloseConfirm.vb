Public Class FormOLStoreCloseConfirm
    Private Sub FormOLStoreCloseConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormOLStoreCloseConfirm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBConfirm_Click(sender As Object, e As EventArgs) Handles SBConfirm.Click
        If MemoEditReason.Text = "" Then
            errorCustom("Reason can't be blank.")
        Else
            Dim in_order As String = ""

            For i = 0 To FormOLStore.GVVolcom.RowCount - 1
                in_order += FormOLStore.GVVolcom.GetRowCellValue(0, "id").ToString + ", "
            Next

            Dim query As String = "
                SELECT COUNT(*)
                FROM tb_ol_store_order
                WHERE id IN (" + in_order.Substring(0, in_order.Length - 2) + ") AND is_process = 1
            "

            Dim ct As String = execute_query(query, 0, True, "", "", "", "")

            If ct = "0" Then
                For i = 0 To FormOLStore.GVVolcom.RowCount - 1
                    Dim q_update As String = "UPDATE tb_ol_store_order SET is_process = 1, fail_reason = '" + addSlashes(MemoEditReason.Text) + "' WHERE id = " + FormOLStore.GVVolcom.GetRowCellValue(i, "id").ToString

                    execute_non_query(q_update, True, "", "", "", "")
                Next

                FormOLStore.viewVolcomOrder("")

                Close()
            Else
                errorCustom("Some order changed, please refresh and reselect again.")
            End If
        End If
    End Sub
End Class