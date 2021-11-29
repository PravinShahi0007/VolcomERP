Public Class FormPIBPPSDet
    Private Sub FormPIBPPSDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPIBPPSDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEPIB.EditValue = Now
        TEPIBTaxAmount.EditValue = 0
        load_propose()
    End Sub

    Sub load_propose()
        Dim q As String = "SELECT f.id_pre_cal_fgpo,GROUP_CONCAT(CONCAT(po.prod_order_number,' - ',cd.class,' ',dsg.design_name,' ',cd.color) SEPARATOR '\n') AS list_fgpo,pr.pib_no,pr.pib_date,pr.pib_tax_amo
FROM tb_pre_cal_fgpo_list fl
INNER JOIN tb_pre_cal_fgpo f ON f.id_pre_cal_fgpo=fl.id_pre_cal_fgpo
INNER JOIN tb_pib_review pr ON pr.id_pre_cal_fgpo=fl.id_pre_cal_fgpo AND fl.id_prod_order=pr.id_prod_order AND is_active=1
INNER JOIN tb_prod_order po ON po.id_prod_order=fl.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
LEFT JOIN (
	SELECT dc.id_design, 
	MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14,43)
	GROUP BY dc.id_design
) cd ON cd.id_design = dsg.id_design
WHERE po.id_report_status=6
GROUP BY f.id_pre_cal_fgpo"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        GCSummary.DataSource = dt
        GVSummary.BestFitColumns()
    End Sub
End Class