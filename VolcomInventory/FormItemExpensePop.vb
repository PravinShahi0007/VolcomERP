Public Class FormItemExpensePop
    Public id_awb_inv_sum As String = "-1"
    Private Sub FormItemExpensePop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        FormItemExpenseDet.action = "ins"
        FormItemExpenseDet.id_awb_inv_sum = id_awb_inv_sum
        FormItemExpenseDet.ShowDialog()
        Close()
    End Sub

    Private Sub FormItemExpensePop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPPH3PLInv.EditValue = 0.00
        TEPPN3PLInv.EditValue = 0.00
        '
        load_pph_account()
    End Sub

    Sub load_pph_account()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a 
INNER JOIN `tb_lookup_tax_report` tr ON tr.id_tax_report=a.id_tax_report AND tr.id_type=1
WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1'"
        viewSearchLookupQuery(SLEPPH3PLInv, query, "id_acc", "acc_description", "id_acc")
    End Sub
End Class