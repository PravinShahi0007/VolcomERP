Public Class FormOLStoreOOSManualEmail
    Public id_ol_store_oos As String = "-1"
    Public id_order As String = "-1"
    Public id_comp_group As String = "-1"

    Private Sub FormOLStoreOOSManualEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormOLStoreOOSManualEmail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSendEmail_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        Cursor = Cursors.WaitCursor
        If MEReason.Text = "" Then
            warningCustom("Please fill reason.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim ord As New ClassSalesOrder()
                Cursor = Cursors.WaitCursor
                Try
                    Dim oos As New ClassOLStore()
                    oos.sendEmailOOS(id_order, id_comp_group)
                    ord.insertLogWebOrder(id_order, "Send Email OOS success", id_comp_group)
                    execute_non_query("UPDATE tb_ol_store_oos SET is_sent_email=1, manual_send_email_reason='" + addSlashes(MEReason.Text) + "', sent_email_date=NOW() WHERE id_ol_store_oos='" + id_ol_store_oos + "'", True, "", "", "", "")
                    Close()
                Catch ex As Exception
                    ord.insertLogWebOrder(id_order, "Send Email OOS failed. " + ex.ToString, id_comp_group)
                    stopCustom("Send email failed")
                End Try
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class