Public Class FormProductionAssemblyComp
    Private Sub FormProductionAssemblyComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
    End Sub

    Sub viewDesign()
        Dim query As String = "SELECT po.id_prod_order, pdd.id_design, d.design_code AS `code`, d.design_display_name AS `name`
        FROM tb_prod_order po 
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        WHERE po.id_report_status=3 OR po.id_report_status=4 
        ORDER BY po.id_prod_order ASC "
        viewSearchLookupQuery(SLEDesignStockStore, query, "id_prod_order", "name", "id_prod_order")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_prod_rec(" + SLEDesignStockStore.EditValue.ToString + ", 0, 0, 0, 0, 0, 0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProductionAssemblyComp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub
End Class