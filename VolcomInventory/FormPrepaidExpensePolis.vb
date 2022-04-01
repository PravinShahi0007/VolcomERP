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
        DEDateReff.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='1'", 0, True, "", "", "", "")

        TEPPH3PLInv.EditValue = 0.00
        TEPPN3PLInv.EditValue = 0.00
        '
        DEDateReff.EditValue = Now
        '
        load_pph_account()
        load_coa_biaya()
        load_budget()
    End Sub

    Sub load_budget()
        Dim q As String = "SELECT bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
FROM tb_b_expense_opex bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'
UNION ALL
SELECT bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
FROM tb_b_expense bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'"
        viewSearchLookupQuery(SLEBudget, q, "id_b_expense", "item_cat_main", "id_b_expense")
        SLEBudget.EditValue = Nothing
    End Sub

    Private Sub DEDateReff_EditValueChanged(sender As Object, e As EventArgs) Handles DEDateReff.EditValueChanged
        Try
            load_budget()
        Catch ex As Exception

        End Try
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