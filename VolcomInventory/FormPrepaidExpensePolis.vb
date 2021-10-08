Public Class FormPrepaidExpensePolis
    Public id_comp As String = "-1"
    Public id_polis_reg As String = "-1"

    Private Sub FormPrepaidExpensePolis_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        FormPrepaidExpenseDet.id_polis_reg = id_polis_reg
        FormPrepaidExpenseDet.ShowDialog()
        Close()
    End Sub

    Private Sub FormItemExpensePop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPPH3PLInv.EditValue = 0.00
        TEPPN3PLInv.EditValue = 0.00
        '
        load_pph_account()
        load_coa_biaya()
    End Sub

    Sub load_pph_account()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a 
INNER JOIN `tb_lookup_tax_report` tr ON tr.id_tax_report=a.id_tax_report AND tr.id_type=1
WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1'"
        viewSearchLookupQuery(SLEPPH3PLInv, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_coa_biaya()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
FROM tb_a_acc a 
WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1'"
        viewSearchLookupQuery(SLECOABiaya, query, "id_acc", "acc_description", "id_acc")
    End Sub
End Class