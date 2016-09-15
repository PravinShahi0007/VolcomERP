Public Class FormRejectType
    Private Sub FormRejectType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewRejectType()
    End Sub

    Sub viewRejectType()
        Dim query As String = "SELECT * FROM tb_m_reject_type a ORDER BY a.id_reject_type DESC "
        viewLookupQuery(LEReject, query, 0, "reject_type", "id_reject_type")
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim id_reject_type As String = LEReject.EditValue.ToString
                Dim query As String = "DELETE FROM tb_m_reject_type WHERE id_reject_type='" + id_reject_type + "' "
                execute_non_query(query, True, "", "", "", "")
                viewRejectType()
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormRejectTypeDet.ShowDialog()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        FormSalesReturnQCDet.id_reject_type = LEReject.EditValue.ToString
        FormSalesReturnQCDet.reject_type = LEReject.Text.ToString
        Close()
    End Sub

    Private Sub FormRejectType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class