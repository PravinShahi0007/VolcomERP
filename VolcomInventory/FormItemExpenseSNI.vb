Public Class FormItemExpenseSNI
    Public id_pps As String = "-1"
    Private Sub FormItemExpenseSNI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpenseSNI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPPH3PLInv.EditValue = 0.00
        TEPPN3PLInv.EditValue = 0.00
        '
        load_head()
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

    Sub load_head()
        Dim q As String = "SELECT 'no' AS is_check,id_sni_pps_budget,b.id_sni_pps,budget_desc,budget_value,budget_qty,budget_value*budget_qty AS budget_amount,0.00 AS r_price,0 AS r_qty
FROM `tb_sni_pps_budget` b
WHERE b.id_sni_pps='" & id_pps & "' AND ISNULL(b.id_design)"
        'tambahin exp yg sudah
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBudget.DataSource = dt
        BGVBudget.BestFitColumns()
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        If BGVBudget.Columns("r_sub_amount").SummaryItem.SummaryValue > 0 Then
            BGVBudget.ActiveFilterString = "[r_sub_amount]>0"

            FormItemExpenseDet.action = "ins"
            FormItemExpenseDet.id_sni_pps = id_pps
            FormItemExpenseDet.ShowDialog()

            BGVBudget.ActiveFilterString = ""

            Close()
        Else
            warningCustom("Please input data first.")
        End If
    End Sub
End Class