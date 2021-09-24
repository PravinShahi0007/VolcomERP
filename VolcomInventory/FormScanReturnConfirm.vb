Public Class FormScanReturnConfirm
    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormScanReturnConfirm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormScanReturnConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEQtyScan.EditValue = FormScanReturnDet.GVListProduct.Columns("size").SummaryItem.SummaryValue
        TEQtyRetNote.EditValue = FormScanReturnDet.TEQty.EditValue
        TEQtyDiff.EditValue = FormScanReturnDet.GVListProduct.Columns("size").SummaryItem.SummaryValue - FormScanReturnDet.TEQty.EditValue
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not TEQtyDiff.EditValue = 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Qty Return note vs Qty Scan not match, you only can do one scan per return label. Continue save ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                FormScanReturnDet.is_ok = True
                Close()
            Else
                FormScanReturnDet.is_ok = False
                Close()
            End If
        End If
    End Sub
End Class