Public Class FormProdDemandSize
    Public id As String = "-1"

    Private Sub FormProdDemandSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDetail()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.prod_demand_number,p.product_full_code AS `barcode`, d.design_code AS `code`, CONCAT(d.design_code,' - ', d.design_display_name) AS `design`, 
        cd.code_detail_name AS `size`, pdp.prod_demand_product_qty AS `qty`
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
        INNER JOIN tb_m_product p ON p.id_product = pdp.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE pdd.id_prod_demand=" + id + " AND pdp.prod_demand_product_qty>0
        ORDER BY pdd.id_prod_demand_design ASC, cd.id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        LabelTitle.Text = data.Rows(0)("prod_demand_number").ToString
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdDemandSize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class