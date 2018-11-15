Public Class FormItemDelReqClosed
    Public where As String = ""

    Private Sub FormItemDelReqClosed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormItemDelReqClosed_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to close these request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim final_reason As String = addSlashes(MENote.Text)

        End If
    End Sub
End Class