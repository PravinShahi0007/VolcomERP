Public Class FormItemExpenseSNI
    Public id_pps As String = "-1"
    Private Sub FormItemExpenseSNI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormItemExpenseSNI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateReff.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='1'", 0, True, "", "", "", "")

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
        Dim q As String = "SELECT 'no' AS is_check,id_sni_pps_budget,b.id_sni_pps,IFNULL(r.amo,0) AS `amo_exp`,budget_desc,budget_value,budget_qty,budget_value*budget_qty AS budget_amount,0.00 AS r_price,0 AS r_qty
FROM `tb_sni_pps_budget` b
LEFT JOIN
(
    SELECT id.id_report_det,SUM(amount) AS amo,SUM(id.qty) AS tot_qty
    FROM tb_item_expense_det id
    INNER JOIN tb_item_expense i ON i.`id_item_expense`=id.`id_item_expense` AND i.`id_report_status`!=5
    WHERE id.report_mark_type='319'
    GROUP BY id.`id_report_det`
)r ON r.id_report_det=b.id_sni_pps_budget
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

    Private Sub DEDateReff_EditValueChanged(sender As Object, e As EventArgs) Handles DEDateReff.EditValueChanged
        Try
            load_budget()
        Catch ex As Exception

        End Try
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
End Class