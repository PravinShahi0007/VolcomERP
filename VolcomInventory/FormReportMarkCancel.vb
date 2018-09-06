Public Class FormReportMarkCancel
    Public id_report_mark_cancel As String = "-1"
    Public id_report_mark_cancel_user As String = "-1"
    '
    Dim id_report As String = "-1"
    Dim report_mark_type As String = "-1"
    '
    Dim is_view As String = "2"
    Private Sub FormReportMarkCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        act_load()
    End Sub

    Sub act_load()
        Dim query As String = "SELECT rmc.*,emp.employee_name FROM tb_report_mark_cancel rmc 
                                            LEFT JOIN tb_m_user usr ON usr.id_user=rmc.created_by
                                            LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                            WHERE rmc.id_report_mark_cancel='" & id_report_mark_cancel & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TECancelBy.Text = data.Rows(0)("employee_name").ToString
            'TENumber.Text = data.Rows(0)("report_number").ToString
            DEDateProposed.EditValue = data.Rows(0)("created_datetime")
            MEReason.Text = data.Rows(0)("reason").ToString
            id_report = data.Rows(0)("id_report").ToString
            report_mark_type = data.Rows(0)("report_mark_type").ToString
            '
            Dim query_user As String = "SELECT * FROM tb_report_mark_cancel_user WHERE id_report_mark_cancel_user='" & id_report_mark_cancel_user & "'"
            Dim data_user As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data_user.Rows(0)("is_approve").ToString = "1" Then
                BApprove.Enabled = False
                BApprove.Text = "Approved"
            Else
                BApprove.Enabled = True
                BApprove.Text = "Approve"
            End If
            '
        End If
    End Sub

    Private Sub FormReportMarkCancel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_report_mark_cancel
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "142"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        If BApprove.Text = "Approve" Then
            'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to approve?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            'If confirm = Windows.Forms.DialogResult.Yes Then
            'End If
            Dim query_upd As String = "UPDATE tb_report_mark_cancel_user SET is_approve='1' WHERE id_report_mark_cancel_user='" & id_report_mark_cancel_user & "'"
            execute_non_query(query_upd, True, "", "", "", "")
            Close()
        End If
    End Sub
End Class