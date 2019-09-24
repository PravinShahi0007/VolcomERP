Public Class FormReportBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim is_purc_dep As String = "1"

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        load_budget()
    End Sub

    Private Sub FormReportBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewMainCategory()
        view_year()
        load_dep()
        DEUntil.EditValue = Now
    End Sub

    Sub load_budget()
        Dim dep As String = "0"
        Dim main_cat As String = "0"
        Dim where_opex As String = ""
        Dim where_capex As String = ""
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then
            where_capex += " AND op.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        End If
        '
        If Not SLEMainCategory.EditValue.ToString = "0" Then
            where_opex += " AND op.id_item_cat_main='" & SLEMainCategory.EditValue.ToString & "'"
            where_capex += " AND op.id_item_cat_main='" & SLEMainCategory.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "(SELECT 'All' AS departement,cm.`id_item_cat_main`,cm.`item_cat_main` AS main_cat,et.`expense_type`
        ,op.`value_expense` AS budget
        ,IFNULL(SUM(IF(trx.is_po=1,trx.`value`,0)),0) AS po_booked
        ,IFNULL(SUM(IF(trx.is_po=2,trx.`value`,0)),0) AS rec
        ,IFNULL(SUM(trx.`value`),0) AS val_used
        ,(op.`value_expense`-IFNULL(SUM(trx.`value`),0)) AS val_remaining
        ,(IFNULL(SUM(trx.`value`),0)/op.value_expense)*100 AS used_percent
        FROM tb_b_expense_opex op
        LEFT JOIN tb_b_expense_opex_trans trx ON op.`id_b_expense_opex`=trx.`id_b_expense_opex` AND DATE(trx.date_trans) <= DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        INNER JOIN tb_item_cat_main cm ON cm.`id_item_cat_main`=op.`id_item_cat_main`
        INNER JOIN tb_lookup_expense_type et ON et.`id_expense_type`=cm.`id_expense_type`
        WHERE op.`year`='" & LEYear.Text.ToString & "' 
        " & where_opex & "
        GROUP BY op.`id_item_cat_main`)
        UNION ALL
        (SELECT dep.departement,cm.`id_item_cat_main`,cm.`item_cat_main` AS main_cat,et.`expense_type`
        ,op.`value_expense` AS budget
        ,IFNULL(SUM(IF(trx.is_po=1,trx.`value`,0)),0) AS po_booked
        ,IFNULL(SUM(IF(trx.is_po=2,trx.`value`,0)),0) AS rec
        ,IFNULL(SUM(trx.`value`),0) AS val_used
        ,IFNULL((op.`value_expense`-SUM(trx.`value`)),0) AS val_remaining
        ,(IFNULL(SUM(trx.`value`),0)/op.value_expense)*100 AS used_percent
        FROM tb_b_expense op
        LEFT JOIN tb_b_expense_trans trx ON op.`id_b_expense`=trx.`id_b_expense` AND DATE(trx.date_trans) <= DATE('" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
        INNER JOIN tb_item_cat_main cm ON cm.`id_item_cat_main`=op.`id_item_cat_main`
        INNER JOIN tb_lookup_expense_type et ON et.`id_expense_type`=cm.`id_expense_type`
        INNER JOIN tb_m_departement dep ON dep.id_departement=op.id_departement
        WHERE op.`year`='" & LEYear.Text.ToString & "'
        " & where_capex & "
        GROUP BY op.`id_item_cat_main`)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemCat.DataSource = data
        GVItemCat.BestFitColumns()
    End Sub

    Sub viewMainCategory()
        Dim query As String = "
SELECT 0 AS id_item_cat_main,'All' AS item_cat_main,'All' AS expense_type
UNION
SELECT t.id_item_cat_main,t.item_cat_main,tt.expense_type 
FROM tb_item_cat_main t
INNER JOIN tb_lookup_expense_type tt ON tt.`id_expense_type`=t.`id_expense_type` "
        viewSearchLookupQuery(SLEMainCategory, query, "id_item_cat_main", "item_cat_main", "id_item_cat_main")
    End Sub

    Sub view_year()
        Dim query As String = "SELECT `year` FROM `tb_b_expense_opex`
UNION
SELECT `year` FROM `tb_b_expense`
GROUP BY `year`"
        viewLookupQuery(LEYear, query, 0, "year", "year")
    End Sub

    Sub load_dep()
        Dim query As String = ""
        If is_purc_dep = "1" Then
            query = "SELECT '0' AS id_departement,'ALL' AS departement 
                               UNION
                               SELECT id_departement,departement FROM tb_m_departement"
        Else
            query = "SELECT id_departement,departement FROM tb_m_departement WHERE id_departement='" & id_departement_user & "'"
        End If

        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub FormReportBudget_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportBudget_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
End Class