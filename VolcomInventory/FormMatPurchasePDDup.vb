Public Class FormMatPurchasePDDup
    Private Sub FormMatPurchasePDDup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Sub load_head()
        TEConsumption.EditValue = 0.00
    End Sub

    Sub load_mat()
        Dim query As String = "SELECT md.`id_mat_det`,md.`id_mat`,md.`mat_det_code`,md.`mat_det_display_name` ,uom.`uom`
FROM tb_m_mat_det md
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`"
        viewSearchLookupQuery(SLEMaterial, query, "id_mat_det", "mat_det_display_name", "id_mat_det")
        SLEMaterial.EditValue = Nothing
    End Sub

    Private Sub FormMatPurchasePDDup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
        load_mat()
    End Sub

    Private Sub SLEMaterial_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMaterial.EditValueChanged
        Try
            If Not SLEMaterial.EditValue = Nothing Then
                TEUOM.Text = SLEMaterial.Properties.View.GetFocusedRowCellValue("uom").ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If TEConsumption.EditValue <= 0 Then
            warningCustom("Please input consumption quantity.")
        Else
            load_pd_dup()
            FormMatPurchasePD.LNumber.Text = "Number : -"
            FormMatPurchasePD.SLEMaterial.EditValue = SLEMaterial.EditValue
            FormMatPurchasePD.TEConsumption.EditValue = TEConsumption.EditValue
            FormMatPurchasePD.id_list = "-1"
            FormMatPurchasePD.load_view()
            FormMatPurchasePD.BCalculate.Text = "Calculate"
            FormMatPurchasePD.set_calculate()
            infoCustom("Duplicate created")
            Close()
        End If
    End Sub
    Sub load_pd_dup()
        Dim query As String = ""
        If FormMatPurchasePD.SLEBreakDown.EditValue.ToString = "1" Then
            query = "SELECT 'yes' AS is_check,lp.note AS note,lp.id_prod_demand_design,IFNULL(lp.id_prod_demand_product,'') AS id_prod_demand_product,pdd.id_design,lp.total_qty_pd AS qty,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
,lp.allowance,lp.allowance_qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd)+lp.allowance_qty AS allowance_qty_order
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=lp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE lp.id_mat_purc_list='" & FormMatPurchasePD.id_list & "'
UNION
SELECT 'no' AS is_check,pdp.size,'' AS note,pdp.id_prod_demand_design,pdp.id_prod_demand_product,pdp.id_design,pdp.qty,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,dsg.design_code,pdp.prod_demand_number,pdp.qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty) AS qty_order 
,al.allowance ,CEIL((al.allowance/100)*(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty)) AS allowance_qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty)+CEIL((al.allowance/100)*(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdp.qty)) AS allowance_qty_order
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_prd.`id_prod_demand_product`, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp
	,(SUM(pd_prd.prod_demand_product_qty)) AS qty 
	,pc.size,pd_prd.id_product
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	INNER JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design
	INNER JOIN (
		SELECT pd_prd.id_product,MAX(pd_prd.id_prod_demand_product) AS id_prod_demand_product
		FROM  tb_prod_demand_design pd_dsg
		INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
		INNER JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
		WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2 AND pd.is_pd=1
		GROUP BY pd_prd.id_product
	)pdp ON pdp.id_prod_demand_product=pd_prd.id_prod_demand_product
	INNER JOIN 
	(
		SELECT pc.`id_product`,cd.`code_detail_name` AS size FROM tb_m_product_code pc INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
	)pc ON pc.`id_product`=pd_prd.`id_product`
	GROUP BY pd_prd.id_prod_demand_product
) pdp
INNER JOIN 
(
    SELECT pdd.id_design,pdd.qty,al.allowance FROM 
    (
    SELECT pdd.id_design,SUM(pdp.prod_demand_product_qty) AS qty
    FROM tb_prod_demand_product pdp 
    INNER JOIN (
	    SELECT pd_prd.id_product,MAX(pd_prd.id_prod_demand_product) AS id_prod_demand_product
	    FROM  tb_prod_demand_design pd_dsg
	    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	    INNER JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	    WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2 AND pd.is_pd=1
	    GROUP BY pd_prd.id_product
    )pdpm ON pdpm.id_prod_demand_product=pdp.id_prod_demand_product
    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
    GROUP BY pdd.id_design
    ) pdd 
    INNER JOIN tb_mat_pd_allowance al ON pdd.qty<=al.qty_max AND pdd.qty>=al.qty_min
)al ON al.id_design=pdp.id_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdp.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
LEFT JOIN
(
	SELECT id_prod_demand_product FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2 AND pl.id_mat_det='" & SLEMaterial.EditValue.ToString & "'
) pl ON pl.id_prod_demand_product=pdp.id_prod_demand_product
WHERE ISNULL(pl.id_prod_demand_product)
ORDER BY pdp.id_prod_demand_design DESC"
        Else
            query = "SELECT 'yes' AS is_check,lp.note AS note,lp.id_prod_demand_design,IFNULL(lp.id_prod_demand_product,'') AS id_prod_demand_product,pdd.id_design,lp.total_qty_pd AS qty,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,dsg.design_code,pd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd) AS qty_order 
,lp.allowance,lp.allowance_qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*lp.total_qty_pd)+lp.allowance_qty AS allowance_qty_order
FROM tb_mat_purc_list_pd lp
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=lp.id_prod_demand_design
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE lp.id_mat_purc_list='" & FormMatPurchasePD.id_list & "'
UNION
SELECT 'no' AS is_check,'' AS note,pdd.id_prod_demand_design,'' AS id_prod_demand_product,pdd.id_design,pdd.qty,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS design_display_name,dsg.design_code,pdd.prod_demand_number,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty) AS qty_order 
,al.allowance ,CEIL((al.allowance/100)*(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty)) AS allowance_qty,(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty)+CEIL((al.allowance/100)*(" & decimalSQL(TEConsumption.EditValue.ToString) & "*pdd.qty)) AS allowance_qty_order
FROM (
	SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, 
	pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp,
	(SUM(pd_prd.prod_demand_product_qty)) AS qty
	FROM  tb_prod_demand_design pd_dsg
	INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	INNER JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	INNER JOIN 
	(
		SELECT pd_dsg.id_design,MAX(pd_dsg.id_prod_demand_design) AS id_prod_demand_design
		FROM  tb_prod_demand_design pd_dsg
		INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
		WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2 AND pd.is_pd=1
		GROUP BY pd_dsg.id_design
	)pdd ON pdd.id_prod_demand_design=pd_dsg.id_prod_demand_design
	GROUP BY pd_dsg.id_design
) pdd
INNER JOIN 
(
    SELECT pdd.id_design,pdd.qty,al.allowance FROM 
    (
    SELECT pdd.id_design,SUM(pdp.prod_demand_product_qty) AS qty
    FROM tb_prod_demand_product pdp 
    INNER JOIN (
	    SELECT pd_prd.id_product,MAX(pd_prd.id_prod_demand_product) AS id_prod_demand_product
	    FROM  tb_prod_demand_design pd_dsg
	    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand
	    INNER JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design 
	    WHERE pd.id_report_status = '6' AND pd_dsg.is_void=2 AND pd.is_pd=1
	    GROUP BY pd_prd.id_product
    )pdpm ON pdpm.id_prod_demand_product=pdp.id_prod_demand_product
    INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=pdp.id_prod_demand_design
    GROUP BY pdd.id_design
    ) pdd 
    INNER JOIN tb_mat_pd_allowance al ON pdd.qty<=al.qty_max AND pdd.qty>=al.qty_min
)al ON al.id_design=pdd.id_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43, 34)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
LEFT JOIN
(
	SELECT id_prod_demand_design FROM `tb_mat_purc_list_pd` plp
	INNER JOIN tb_mat_purc_list pl ON pl.`id_mat_purc_list`=plp.`id_mat_purc_list` AND pl.`is_cancel`=2
	INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=pl.`id_mat_det` AND md.`id_mat`=(SELECT id_mat FROM tb_m_mat_det WHERE id_mat_det='" & SLEMaterial.EditValue.ToString & "')
) pl ON pl.id_prod_demand_design=pdd.id_prod_demand_design
WHERE ISNULL(pl.id_prod_demand_design)
ORDER BY is_check DESC,id_prod_demand_design DESC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        FormMatPurchasePD.GCPD.DataSource = data
    End Sub
End Class