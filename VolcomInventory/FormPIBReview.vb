﻿Public Class FormPIBReview
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPIBReview_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        view_list_pib()
    End Sub

    Sub view_list_pib()
        Dim q As String = "SELECT pir.`id_pib_review`,pir.`id_pre_cal_fgpo_list`,pir.`id_pre_cal_fgpo`,prec.`number` AS isb_number,po.`prod_order_number`,d.`design_code`,d.`design_name`,IFNULL(cd.color,'-') AS color,IFNULL(cd.class,'-') AS class
,pir.`pib_no`,pir.`pib_date`,pir.`pib_tax_amo`,DATE_ADD(pir.pib_date,INTERVAL 1 YEAR) AS second_date_limit
,rec.qty_rec,pir.`qty_sales`,pir.`last_upd_qty_sales`
,IFNULL(pir.`qty_sales`/rec.qty_rec,0)*100 AS sales_thru
FROM tb_pib_review pir
INNER JOIN tb_pre_cal_fgpo prec ON prec.`id_pre_cal_fgpo`=pir.`id_pre_cal_fgpo`
INNER JOIN tb_prod_order po ON pir.`id_prod_order`=po.`id_prod_order`
INNER JOIN tb_m_design d ON d.`id_design`=pir.`id_design`
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
	MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	FROM tb_m_design_code dc
	INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	AND cd.id_code IN (32,30,14, 43)
	GROUP BY dc.id_design
) cd ON cd.id_design = d.id_design
LEFT JOIN
(
	SELECT pir.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec
	FROM tb_prod_order_rec_det recd
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
	INNER JOIN tb_pib_review pir ON rec.`id_prod_order`=pir.`id_prod_order`
	WHERE pir.`is_active`=1 AND pir.`is_notified`=2
	GROUP BY pir.`id_prod_order`
) rec ON rec.id_prod_order=pir.`id_prod_order`
WHERE pir.`is_active`=1 AND pir.`is_notified`=2"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSummary.DataSource = dt
        GVSummary.BestFitColumns()
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick

    End Sub
End Class