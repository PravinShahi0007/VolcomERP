Public Class FormProdClosingTolerance
    Public cond As String = ""

    Private Sub FormProdClosingTolerance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TxtTolOver.EditValue = 0.00
        'TxtTolMinus.EditValue = 0.00
        'TxtTolDiscount.EditValue = 0.00
    End Sub

    Private Sub FormProdClosingTolerance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this FG PO?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim tolerance_over As String = decimalSQL(TxtTolOver.EditValue.ToString)
            Dim tolerance_minus As String = decimalSQL(TxtTolMinus.EditValue.ToString)
            Dim claim_discount As String = decimalSQL(TxtTolDiscount.EditValue.ToString)
            Dim query As String = "UPDATE tb_prod_order SET tolerance_over='" + tolerance_over + "', 
            tolerance_minus='" + tolerance_minus + "', claim_discount='" + claim_discount + "' 
            WHERE 1=1 AND " + cond
            execute_non_query(query, True, "", "", "", "")
            Dim id_prod_order As String = FormProdClosing.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
            FormProdClosing.view_production_order()
            FormProdClosing.GVProd.FocusedRowHandle = find_row(FormProdClosing.GVProd, "id_prod_order", id_prod_order)
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = FormProdClosing.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        FormDocumentUpload.report_mark_type = "115"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class