Public Class FormBankWithdrawalAttachement
    Public id_purc_order As String = "-1"

    Private Sub FormBankWithdrawalAttachement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT po.purc_order_number, c.comp_number, c.comp_name, IFNULL(po.due_date, DATE(NOW())) AS due_date
            FROM tb_purc_order AS po
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            WHERE po.id_purc_order = " + id_purc_order + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TextEditVendor.EditValue = data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString
        TextEditPONumber.EditValue = data.Rows(0)("purc_order_number").ToString

        DateEditDueDate.EditValue = data.Rows(0)("due_date")
    End Sub

    Private Sub SimpleButtonAttachment_Click(sender As Object, e As EventArgs) Handles SimpleButtonAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "-1"
        FormDocumentUpload.is_view = "-1"
        FormDocumentUpload.id_report = id_purc_order
        FormDocumentUpload.report_mark_type = "235"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButtonSet_Click(sender As Object, e As EventArgs) Handles SimpleButtonSet.Click
        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 235 AND id_report = " + id_purc_order

        Dim cek_attachment As String = If(execute_query(query_attachment, 0, True, "", "", "", "") = "0", "Please add attachment", "")

        If Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to set ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                Dim query As String = "UPDATE tb_purc_order SET due_date = '" + Date.Parse(DateEditDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', is_active_payment = 1 WHERE id_purc_order = " + id_purc_order

                execute_non_query(query, True, "", "", "", "")

                FormBankWithdrawal.buttonView_click()

                Close()
            End If
        End If
    End Sub
End Class