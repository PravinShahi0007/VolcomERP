Public Class FormSetupBudgetOPEX
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

    Private Sub FormPurcReq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReq_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcReq_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_budget()
    End Sub

    Private Sub FormSampleBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStartCard.EditValue = Now
        DEUntilCard.EditValue = Now
        '
        'load_budget_card()
        'load_budget_cat_card()
        '
        'SLEBudget.EditValue = Nothing
    End Sub

    Sub load_budget()
        Dim query As String = "SELECT ic.id_item_cat,ic.item_cat,'" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AS `year`,IFNULL(bo.value_expense,0) AS value_expense
FROM tb_item_cat ic
LEFT JOIN `tb_b_expense_opex` bo ON bo.id_item_cat=ic.id_item_cat AND bo.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND bo.is_active='1'
WHERE ic.id_expense_type='1'
ORDER BY ic.item_cat"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetList.DataSource = data
        GVBudgetList.BestFitColumns()
    End Sub

    Private Sub BRevision_Click(sender As Object, e As EventArgs) Handles BRevision.Click
        load_budget()
        '
        Dim query As String = "SELECT COUNT(*) FROM `tb_b_opex_pps_det` ppd
INNER JOIN tb_b_opex_pps pps ON pps.`id_b_opex_pps`=ppd.`id_b_opex_pps`
WHERE ppd.year='" & DEYearBudget.Text & "' AND pps.`id_report_status` != 5 AND pps.`id_report_status` !=6"
        Dim jml As String = execute_query(query, 0, True, "", "", "", "").ToString

        If Not jml = "0" Then
            stopCustom("There is ongoing proposal, please cancel it first")
        ElseIf GVBudgetList.RowCount = 0 Then
            stopCustom("Nothing to revise")
        Else
            FormSetupBudgetOPEXDet.is_rev = "1"
            FormSetupBudgetOPEXDet.ShowDialog()
        End If
        '
    End Sub
End Class