Public Class FormBudgetProdDemand
    Private Sub FormBudgetProdDemand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
    End Sub

    Private Sub FormBudgetProdDemand_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBudgetProdDemand_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewAppBudget()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT b.id_b_prod_demand, b.`year`, b.id_season, ss.season, b.`value`, b.is_active 
        FROM tb_b_prod_demand b
        INNER JOIN tb_season ss ON ss.id_season = b.id_season 
        WHERE b.year='" + DEYearBudget.Text + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCApprovedBudget.DataSource = data
        GVApprovedBudget.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewAppBudget()
    End Sub
End Class