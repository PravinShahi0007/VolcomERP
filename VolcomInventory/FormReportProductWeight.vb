Public Class FormReportProductWeight
    Dim d_json As New Newtonsoft.Json.Linq.JObject()

    Sub load_json()
        d_json = volcomErpApiGetJson(volcom_erp_api_host & "api/packaging")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Dim q As String = "SELECT prd.id_product,dsg.design_display_name,prd.product_full_code,dsg.design_code,prd_cd.code_detail_name AS size,cd.class AS class,cd.color AS color,prd.qc_weight,IFNULL(pw.berat_packaging,0.00) AS berat_packaging
,ROUND(1.1*(prd.qc_weight+IFNULL(pw.berat_packaging,0.00))/1000) AS berat_10
FROM tb_m_product prd
INNER JOIN tb_m_design dsg ON prd.id_design=dsg.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
INNER JOIN tb_m_product_code prdc ON prdc.id_product=prd.id_product
INNER JOIN tb_m_code_detail prd_cd ON prd_cd.id_code_detail=prdc.id_code_detail
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
	SELECT cd.id_code_detail AS id_class,ROUND(IF(((panjang*lebar*tinggi)/6)>berat,((panjang*lebar*tinggi)/6),berat),2) AS berat_packaging
	FROM tb_packaging_w pw
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail=pw.id_code_detail
	WHERE pw.is_active=1 AND pw.id_comp_group='" & SLEOnlineShop.EditValue.ToString & "'
	GROUP BY cd.id_code_detail
)pw ON pw.id_class=cd.id_class
WHERE id_lookup_status_order!=2"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCProductWeight.DataSource = dt
        GVProductWeight.BestFitColumns()
    End Sub

    Private Sub FormReportProductWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_json()
        load_online_shop()
    End Sub

    Sub load_online_shop()
        viewSearchLookupQueryO(SLEOnlineShop, volcomErpApiGetDT(d_json, 0), "id_comp_group", "description", "id_comp_group")
    End Sub
End Class