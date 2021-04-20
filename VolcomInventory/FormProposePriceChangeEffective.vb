Public Class FormProposePriceChangeEffective
    Public id As String = "-1"

    Private Sub FormProposePriceChangeEffective_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT effective_date FROM tb_pp_change WHERE id_pp_change='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DEEffectDate.EditValue = data.Rows(0)("effective_date")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProposePriceChangeEffective_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset item list. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim effective_date As String = DateTime.Parse(DEEffectDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim query_upd As String = "CALL gen_pp_change(" + id + ", '" + effective_date + "'); "
            execute_non_query(query_upd, True, "", "", "", "")

            'refresh
            FormProposePriceMKD.viewSummary()
            FormProposePriceMKD.GVSummary.FocusedRowHandle = find_row(FormProposePriceMKD.GVSummary, "id_pp_change", id)
            FormProposePriceMKDDet.actionLoad()
        End If
    End Sub
End Class