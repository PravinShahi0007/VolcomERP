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
        DEYearBudgetMapping.EditValue = Now
        '
        load_acc_parent()
        'load_budget_card()
        'load_budget_cat_card()
        '
        'SLEBudget.EditValue = Nothing
    End Sub

    Sub load_budget()
        Dim query As String = "SELECT ic.id_item_cat_main,ic.item_cat_main,'" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AS `year`,IFNULL(bo.id_b_expense_opex,'') AS id_b_expense_opex,IFNULL(bo.value_expense,0) AS value_expense
FROM tb_item_cat_main ic
LEFT JOIN `tb_b_expense_opex` bo ON bo.id_item_cat_main=ic.id_item_cat_main AND bo.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND bo.is_active='1'
WHERE ic.id_expense_type='1'
ORDER BY ic.id_item_cat_main"
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
            If GVBudgetList.Columns("value_expense").SummaryItem.SummaryValue > 0 Then
                FormSetupBudgetOPEXDet.is_rev = "1"
            End If
            FormSetupBudgetOPEXDet.ShowDialog()
        End If
        '
    End Sub

    Private Sub BShowList_Click(sender As Object, e As EventArgs) Handles BShowList.Click
        load_propose()
    End Sub

    Sub load_propose()
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_b_opex_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
WHERE DATE(pps.date_created) <='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(pps.date_created) >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY pps.id_b_opex_pps DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        Dim query As String = "SELECT pps.*,emp.employee_name,sts.report_status FROM `tb_b_opex_pps` pps
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_b_opex_pps DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProposeList.DataSource = data
        GVProposeList.BestFitColumns()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormSetupBudgetOPEXDet.id_pps = GVProposeList.GetFocusedRowCellValue("id_b_opex_pps").ToString
        FormSetupBudgetOPEXDet.ShowDialog()
    End Sub

    Private Sub BSearchBudgetCat_Click(sender As Object, e As EventArgs) Handles BSearchBudgetCat.Click

    End Sub

    Private Sub BViewBudgetMapping_Click(sender As Object, e As EventArgs) Handles BViewBudgetMapping.Click
        load_budget_map()
    End Sub

    Sub load_budget_map()
        Dim query As String = "SELECT ic.id_item_cat_main,ic.item_cat_main,'" & Date.Parse(DEYearBudgetMapping.EditValue.ToString).ToString("yyyy") & "' AS `year`,IFNULL(bo.id_b_expense_opex,'') AS id_b_expense_opex,IFNULL(bo.value_expense,0) AS value_expense
FROM tb_item_cat_main ic
LEFT JOIN `tb_b_expense_opex` bo ON bo.id_item_cat_main=ic.id_item_cat_main AND bo.year='" & Date.Parse(DEYearBudgetMapping.EditValue.ToString).ToString("yyyy") & "' AND bo.is_active='1'
WHERE ic.id_expense_type='1'
ORDER BY ic.id_item_cat_main"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetMap.DataSource = data
        GVBudgetMap.BestFitColumns()
    End Sub

    Sub load_acc_parent()
        Dim q As String = "SELECT a.*,'Office' AS typ,CONCAT(a.acc_name,' - ',a.acc_description) AS acc_desc FROM `tb_a_acc` a
WHERE a.id_is_det=1 AND LENGTH(a.acc_name)=4 AND a.id_acc_cat=4 AND a.id_coa_type=1 AND a.id_status=1
UNION ALL
SELECT a.*,'Cabang' AS typ,CONCAT(a.acc_name,' - ',a.acc_description) AS acc_desc FROM `tb_a_acc` a
WHERE a.id_is_det=1 AND LENGTH(a.acc_name)=4 AND a.id_coa_type=2 AND a.id_status=1"
        viewSearchLookupQuery(SLEACCParent, q, "id_acc", "acc_desc", "id_acc")
    End Sub

    Sub load_view_map()
        If GVBudgetMap.RowCount > 0 Then
            Dim q As String = "SELECT a.*,IF(id_coa_type=1,'Office','Cabang') AS typ,CONCAT(a.acc_name,' - ',a.acc_description) AS acc_desc
FROM tb_b_expense_opex_map map
INNER JOIN `tb_a_acc` a ON a.`id_acc`=map.id_acc
WHERE map.id_b_expense_opex='" & GVBudgetMap.GetFocusedRowCellValue("id_b_expense_opex").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCAccMapping.DataSource = dt
            GVAccMapping.BestFitColumns()
        End If
    End Sub

    Private Sub BAddMapping_Click(sender As Object, e As EventArgs) Handles BAddMapping.Click
        If GVBudgetMap.RowCount > 0 And Not SLEACCParent.EditValue = Nothing Then
            'check first
            Dim q As String = "SELECT id_acc FROM tb_b_expense_opex_map WHERE id_b_expense_opex='" & GVBudgetMap.GetFocusedRowCellValue("id_b_expense_opex").ToString & "' AND id_acc='" & SLEACCParent.EditValue.ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                warningCustom("Already on list")
                load_view_map()
            Else
                q = "INSERT INTO tb_b_expense_opex_map(id_b_expense_opex,id_acc) VALUES('" & GVBudgetMap.GetFocusedRowCellValue("id_b_expense_opex").ToString & "','" & SLEACCParent.EditValue.ToString & "')"
                execute_non_query(q, True, "", "", "", "")
                load_view_map()
            End If
        End If
    End Sub

    Private Sub GVBudgetMap_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBudgetMap.FocusedRowChanged
        If GVBudgetMap.RowCount > 0 Then
            load_view_map()
        End If
    End Sub
End Class