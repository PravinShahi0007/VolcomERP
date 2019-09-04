Public Class FormSetupBudgetCAPEX
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim report_desc As String = ""
    Dim report_year As String = ""

    Dim is_admin As String = "-1"

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
        Dim q_dep As String = ""
        If Not is_admin = "1" Then
            q_dep = "WHERE dep.id_departement = '" & id_departement_user & "'"
        End If
        Dim query As String = "SELECT * FROM 
(
	SELECT 0 AS id_departement, 'All departement' AS departement UNION 
	(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC)
) dep " & q_dep
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Sub load_budget()
        Dim dep As String = ""

        If Not LEDeptSum.EditValue.ToString = "0" Then
            dep = "AND bo.id_departement='" & LEDeptSum.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT ic.id_item_cat_main,ic.item_cat_main,'" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AS `year`,IFNULL(bo.id_b_expense,'') AS id_b_expense,IFNULL(bo.value_expense,0) AS value_expense
FROM tb_item_cat_main ic
LEFT JOIN `tb_b_expense` bo ON bo.id_item_cat_main=ic.id_item_cat_main AND bo.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND bo.is_active='1' " & dep & "
WHERE ic.id_expense_type='2'
ORDER BY ic.id_item_cat_main"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetList.DataSource = data
        GVBudgetList.BestFitColumns()
    End Sub

    Private Sub BRevision_Click(sender As Object, e As EventArgs) Handles BRevision.Click
        load_budget()
        '
        Dim query As String = "SELECT COUNT(*) FROM `tb_b_expense_propose_year` ppd
INNER JOIN tb_b_expense_propose pps ON pps.`id_b_expense_propose`=ppd.`id_b_expense_propose`
WHERE ppd.year='" & DEYearBudget.Text & "' AND pps.`id_report_status` != 5 AND pps.`id_report_status` !=6"
        Dim jml As String = execute_query(query, 0, True, "", "", "", "").ToString

        If Not jml = "0" Then
            stopCustom("There is ongoing proposal, please cancel it first")
        ElseIf GVBudgetList.RowCount = 0 Or LEDeptSum.EditValue.ToString = "0" Then
            stopCustom("Please choose departement first")
        Else
            FormSetupBudgetCAPEXDet.is_rev = "1"
            FormSetupBudgetCAPEXDet.ShowDialog()
        End If
    End Sub

    Sub load_propose()
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_b_expense_propose` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.id_created_user
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
WHERE DATE(pps.date_created) <='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(pps.date_created) >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY pps.id_b_expense_propose DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BShowList_Click(sender As Object, e As EventArgs) Handles BShowList.Click
        load_propose()
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_b_expense_propose` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.id_created_user
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_b_expense_propose DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormSetupBudgetCAPEXDet.id_pps = GVProposeList.GetFocusedRowCellValue("id_b_expense_propose").ToString
        FormSetupBudgetCAPEXDet.ShowDialog()
    End Sub
End Class