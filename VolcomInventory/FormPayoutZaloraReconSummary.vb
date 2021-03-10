Public Class FormPayoutZaloraReconSummary
    Public id As String = "-1"
    Dim col_name_val_upd As String = ""
    Dim col_name_note_upd As String = ""
    Private Sub FormPayoutZaloraReconSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCategory.Text = FormPayoutZaloraDet.GVSummary.GetFocusedRowCellValue("payout_zalora_cat").ToString
        TxtAmount.EditValue = FormPayoutZaloraDet.GVSummary.GetFocusedRowCellValue("val")
        MERemark.Text = FormPayoutZaloraDet.GVSummary.GetFocusedRowCellValue("note_manual_recon").ToString
        col_name_val_upd = FormPayoutZaloraDet.GVSummary.GetFocusedRowCellValue("col_name").ToString
        col_name_note_upd = FormPayoutZaloraDet.GVSummary.GetFocusedRowCellValue("col_name").ToString + "_note"
    End Sub

    Private Sub FormPayoutZaloraReconSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If MERemark.Text = "" Then
            stopCustom("Please fill remark")
            Exit Sub
        End If

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be update the data and set this category as manual reconcile. Are you sure you want to confirm these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_payout_zalora SET " + col_name_val_upd + "='" + decimalSQL(TxtAmount.EditValue.ToString) + "' ,
            " + col_name_note_upd + "='" + addSlashes(MERemark.Text.ToString) + "'
            WHERE id_payout_zalora='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormPayoutZaloraDet.viewDetailAll()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class