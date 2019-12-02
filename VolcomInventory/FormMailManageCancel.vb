Public Class FormMailManageCancel
    Public rmt As String = "-1"
    Public id_mail_manage As String = "-1"

    Private Sub FormMailManageCancel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormMailManageCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If MemoEdit1.Text = "" Then
            stopCustom("Please input reason cancel")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancel this transaction ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim note As String = addSlashes(MemoEdit1.Text)
                Dim querylog As String = "/*cancel email*/
                UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
                id_mail_status=4, mail_status_note='" + note + "' WHERE id_mail_manage='" + id_mail_manage + "'; 
                /*log mail*/
                " + FormMailManageDet.queryInsertLog("4", note) + "; "
                execute_non_query(querylog, True, "", "", "", "")

                If rmt = "225" Then
                    FormMailManageDet.updateSttInvoice("1")
                End If

                Close()
            End If
        End If
    End Sub
End Class