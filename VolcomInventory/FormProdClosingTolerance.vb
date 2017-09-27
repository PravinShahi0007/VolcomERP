Public Class FormProdClosingTolerance
    Public cond As String = ""

    Private Sub FormProdClosingTolerance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTolOver.EditValue = 0
        TxtTolMinus.EditValue = 0
        TxtTolDiscount.EditValue = 0
    End Sub

    Private Sub FormProdClosingTolerance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this FG PO?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim tolerance_over As Decimal = decimalSQL(TxtTolOver.EditValue.ToString)
            Dim tolerance_minus As Decimal = decimalSQL(TxtTolMinus.EditValue.ToString)
            Dim claim_discount As Decimal = decimalSQL(TxtTolDiscount.EditValue.ToString)
            Dim query As String = "UPDATE tb_prod_order SET tolerance_over='" + tolerance_over + "', 
            tolerance_minus='" + tolerance_minus + "', claim_discount='" + claim_discount + "' 
            WHERE 1=1 " + cond
            execute_non_query(query, True, "", "", "", "")
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
End Class