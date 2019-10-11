Public Class FormProdClosingPps
    Public id_pps As String = "-1"

    Private Sub FormProdClosingPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_header()
        load_det()
    End Sub

    Sub load_header()
        Dim query As String = ""

    End Sub

    Sub load_claim_reject()
        Dim query As String = "SELECT dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.*,
SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qty_normal,
SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qty_normal_minor,
get_claim_reject_percent(pocd.`id_claim_reject`,2) AS p_normal_minor,
SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qty_minor,
get_claim_reject_percent(pocd.`id_claim_reject`,3) AS p_minor,
SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qty_minor_major,
get_claim_reject_percent(pocd.`id_claim_reject`,4) AS p_minor_major,
SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qty_major,
get_claim_reject_percent(pocd.`id_claim_reject`,5) AS p_major,
SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qty_afkir, 
get_claim_reject_percent(pocd.`id_claim_reject`,6) AS p_afkir
FROM tb_prod_order_close_det pocd
INNER JOIN tb_prod_fc fc ON fc.`id_prod_order`=pocd.`id_prod_order`
INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pocd.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=pocd.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
GROUP BY pocd.`id_prod_order`"
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pocd.`id_prod_order_close_det`,pocd.`id_prod_order`,IFNULL(rec.qty_rec,0)-IFNULL(retcd.qty,0) AS qty_rec,IFNULL(rec.first_rec_qc,0) AS first_rec_qc,SUM(pod.`prod_order_qty`) AS qty_po
                                ,qcr.qty_normal,qcr.qty_normal_minor,qcr.qty_minor,qcr.qty_minor_major,qcr.qty_major,qcr.qty_afkir
                                ,wo_price.currency,wo_price.prod_order_wo_vat,wo_price.prod_order_wo_det_price,wo_price.`prod_order_wo_kurs`
                                ,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY) AS est_rec_date
                                ,IF(DATEDIFF(rec.first_rec_qc,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))<0,0,DATEDIFF(rec.first_rec_qc,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))) AS late
                                FROM tb_prod_order_close_det pocd
                                INNER JOIN tb_prod_order_close poc ON poc.`id_prod_order_close`=pocd.`id_prod_order_close`
                                INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` 
                                LEFT JOIN (
	                                SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
	                                FROM tb_prod_order_rec rec
	                                INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
	                                GROUP BY rec.id_prod_order
                                ) rec ON rec.`id_prod_order`=pocd.`id_prod_order`
                                LEFT JOIN
                                (
	                                SELECT fc.`id_prod_order`,SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qty_normal,
	                                SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qty_normal_minor,
	                                SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qty_minor,
	                                SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qty_minor_major,
	                                SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qty_major,
	                                SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qty_afkir 
	                                FROM tb_prod_fc_det fcd
	                                INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcd.`id_prod_fc` AND fc.`id_report_status`=6
	                                WHERE NOT ISNULL(fc.`id_pl_category_sub`)
	                                GROUP BY fc.`id_prod_order`
                                )qcr ON qcr.id_prod_order=po.`id_prod_order`
                                LEFT JOIN (
	                                SELECT wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`
	                                FROM tb_prod_order_wo wo
	                                INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	                                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	                                WHERE wo.is_main_vendor=1 
	                                GROUP BY wo.id_prod_order_wo
                                ) wo_price ON wo_price.id_prod_order=po.id_prod_order
                                LEFT JOIN (
	                                SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
		                                SELECT * FROM tb_prod_order_ko_det
		                                ORDER BY id_prod_order_ko_det DESC
	                                )ko GROUP BY ko.id_prod_order
                                ) ko ON ko.id_prod_order=po.id_prod_order
                                LEFT JOIN tb_prod_claim_return_det retcd ON retcd.`id_prod_order_det`=pod.`id_prod_order_det`
                                LEFT JOIN tb_prod_claim_return retc ON retc.`id_prod_claim_return`=retcd.`id_prod_claim_return` AND retc.`id_report_status`='6'
                                WHERE pocd.`id_prod_order_close`='" & id_pps & "'
                                GROUP BY pocd.`id_prod_order`"
    End Sub

    Private Sub FormProdClosingPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class