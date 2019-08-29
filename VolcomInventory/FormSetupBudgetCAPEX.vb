Public Class FormSetupBudgetCAPEX
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim report_desc As String = ""
    Dim report_year As String = ""

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSetupBudgetCAPEX_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_budget()
    End Sub

    Private Sub FormSetupBudgetCAPEX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStartCard.EditValue = Now
        DEUntilCard.EditValue = Now
        '
        load_dep()
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Sub load_budget()
        Dim query As String = "SELECT ic.id_item_cat_main,ic.item_cat_main,'" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AS `year`,IFNULL(bo.id_b_expense,'') AS id_b_expense,IFNULL(bo.value_expense,0) AS value_expense
FROM tb_item_cat_main ic
LEFT JOIN `tb_b_expense` bo ON bo.id_item_cat_main=ic.id_item_cat_main AND bo.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND bo.is_active='1'
WHERE ic.id_expense_type='2' AND bo.id_departement='" & LEDeptSum.EditValue.ToString & "'
ORDER BY ic.id_item_cat_main"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetList.DataSource = data
        GVBudgetList.BestFitColumns()
    End Sub
End Class