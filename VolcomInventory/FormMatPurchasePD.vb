Public Class FormMatPurchasePD
    Private Sub FormMatPurchasePD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
        load_mat()

    End Sub

    Sub load_head()
        TEConsumption.EditValue = 0.00
        TEToleransi.EditValue = 0.00
        TEToleransiAmount.EditValue = 0.00
        TETotal.EditValue = 0.00
        TETotalAmount.EditValue = 0.00
    End Sub

    Sub load_mat()
        Dim query As String = "SELECT md.`id_mat_det`,md.`id_mat`,md.`mat_det_code`,md.`mat_det_display_name` ,uom.`uom`
FROM tb_m_mat_det md
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`"
        viewSearchLookupQuery(SLEMaterial, query, "id_mat_det", "mat_det_display_name", "id_mat_det")
        SLEMaterial.EditValue = Nothing
    End Sub

    Sub load_pd()
        Dim query As String = "SELECT pdd.id_prod_demand_design,pdd.id_design,pdd.qty,dsg.design_display_name,dsg.design_code,pdd.prod_demand_number,pdd.qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty) AS qty_order FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2
	GROUP BY pd_dsg.id_prod_demand_design
	ORDER BY pd_dsg.id_prod_demand_design DESC
) pdd
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
GROUP BY pdd.id_design
ORDER BY pdd.id_prod_demand_design DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
    End Sub

    Private Sub FormMatPurchasePD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSetConsumption_Click(sender As Object, e As EventArgs) Handles BSetConsumption.Click
        If TEConsumption.EditValue <= 0 Then
            warningCustom("Please input consumption quantity.")
        Else
            load_pd()
        End If
    End Sub

    Private Sub BCalculate_Click(sender As Object, e As EventArgs) Handles BCalculate.Click

    End Sub
End Class