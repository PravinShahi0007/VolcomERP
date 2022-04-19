Public Class FormSampleDevActual
    Private Sub FormSampleDevActual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_view()
        load_tahapan()
    End Sub

    Sub load_tahapan()
        Dim q As String = ""

    End Sub

    Sub load_view()
        Dim q As String = "SELECT DATE(NOW()) AS cur_date,'no' AS is_check,t.*,CONCAT(c.comp_number,' - ',c.comp_name) AS vendor,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',dsg.design_name,' ',cd.color) AS  design_display_name
FROM `tb_sample_dev_tracking` t
INNER JOIN tb_m_design dsg ON dsg.id_design=t.id_design
INNER JOIN tb_season s ON s.id_season=dsg.id_season AND t.id_comp='" & FormSampleDevTargetPps.SLEVendor.EditValue.ToString & "'
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
INNER JOIN tb_m_comp c ON c.id_comp=t.id_comp"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCTracker.DataSource = dt
        GVTracker.BestFitColumns()
    End Sub
End Class