Public Class FormFGPOPaymentTracking
    Private Sub FormFGPOPaymentTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_fgpo()
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`,CONCAT(po.`prod_order_number`,' - ',dsg.`design_display_name`) AS view_po
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "view_po", "id_prod_order")
    End Sub

    Private Sub FormFGPOPaymentTracking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        Dim query As String = ""
        query = "SET @id_po = '" & SLEFGPO.EditValue.ToString & "';
        SELECT po.id_prod_order,'F.G.PO' AS type,pod.qty AS qty_po,po.prod_order_number AS number,dsg.design_code,dsg.design_display_name,NULL AS created_date
        ,IFNULL(rec_normal.qty,0) AS qty_rec,IFNULL(rec_extra.qty,0) AS qty_rec_extra,IFNULL(rec_grade.qty,0) AS qty_rec_grade,IFNULL(rec_over.qty,0) AS qty_rec_over
        ,IFNULL(rec_normal.qty*prc.prod_order_wo_det_price*prc.prod_order_wo_kurs,0) AS amount_rec
        ,IFNULL(rec_extra.var*(prc.prod_order_wo_det_price)*prc.prod_order_wo_kurs,0) AS amount_rec_extra
        ,IFNULL(rec_grade.var*(prc.prod_order_wo_det_price)*prc.prod_order_wo_kurs,0) AS amount_rec_grade
        ,IFNULL(rec_over.var*prc.prod_order_wo_det_price*prc.prod_order_wo_kurs,0) AS amount_rec_over
        ,'' AS bbk_number,'' AS bbk_pay_date,'' AS id_bbk
        FROM tb_prod_order po
        INNER JOIN
        (
        	SELECT wo.id_prod_order,wod.prod_order_wo_det_price,wo.`prod_order_wo_kurs`
            FROM `tb_prod_order_wo_det` wod
        	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo` AND wo.`is_main_vendor`='1' AND wo.`id_report_status`='6' AND wo.`id_prod_order`=@id_po
                LIMIT 1
        )prc ON prc.id_prod_order=po.id_prod_order
        INNER JOIN 
        (
        	SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty FROM tb_prod_order_det pod 
            WHERE pod.`id_prod_order`=@id_po
        )pod ON pod.id_prod_order=po.`id_prod_order`
        LEFT JOIN
        (
        	SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty 
            FROM tb_prod_order_rec_det recd
        	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
        	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='2' AND rec.id_pl_category='1'
        )rec_normal ON rec_normal.id_prod_order=po.id_prod_order
        LEFT JOIN
        (
        	SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty ,rec.claim_percent,SUM(recd.`prod_order_rec_det_qty`*((100-rec.claim_percent)/100)) AS var
            FROM tb_prod_order_rec_det recd
        	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
        	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='2' AND rec.id_pl_category='5'
        )rec_extra ON rec_extra.id_prod_order=po.id_prod_order
        LEFT JOIN
        (
        	SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty ,rec.claim_percent,SUM(recd.`prod_order_rec_det_qty`*((100-rec.claim_percent)/100)) AS var
            FROM tb_prod_order_rec_det recd
        	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
        	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='2' AND (rec.id_pl_category='2' OR rec.id_pl_category='3' OR rec.id_pl_category='4')
        )rec_grade ON rec_grade.id_prod_order=po.id_prod_order
        LEFT JOIN
        (
        	SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty ,rec.claim_percent,SUM(recd.`prod_order_rec_det_qty`*((100-rec.claim_percent)/100)) AS var
            FROM tb_prod_order_rec_det recd
        	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
        	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='1' AND rec.id_pl_category='6'
        )rec_over ON rec_over.id_prod_order=po.id_prod_order
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
        INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
        WHERE po.id_prod_order =@id_po
        UNION ALL
        SELECT pnd.`id_prod_order`,pnt.pn_type AS type,'' AS qty_po,pn.number AS number,'' AS design_code,'' AS design_display_name,pn.created_date
        ,-SUM(IF(pn.`type`=2 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec,-SUM(IF(pn.`type`=3 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec_extra,-SUM(IF(pn.`type`=5 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec_grade,-SUM(IF(pn.`type`=4 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec_over
        ,-SUM(IF(pn.`type`=2 OR pn.`type`=1,pnd.`value`,0)) AS amount_rec,-SUM(IF(pn.`type`=3,pnd.`value`,0)) AS amount_rec_extra,-SUM(IF(pn.`type`=5,pnd.`value`,0)) AS amount_rec_grade,-SUM(IF(pn.`type`=4,pnd.`value`,0)) AS amount_rec_over
        ,pn_list.bbk_number,pn_list.bbk_pay_date,pn_list.id_bbk
        FROM tb_pn_fgpo_det pnd
        INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`id_report_status`!=5
        INNER JOIN tb_pn_type pnt ON pnt.id_type=pn.type
        LEFT JOIN (
            SELECT pnd.`id_report`,GROUP_CONCAT(pn.number) AS bbk_number,GROUP_CONCAT(DATE_FORMAT(pn.`date_payment`,'%d %M %Y')) AS bbk_pay_date ,GROUP_CONCAT(pn.id_pn) AS id_bbk
            FROM tb_pn_det pnd
            INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn`
            WHERE pnd.`report_mark_type`='189' AND pn.`id_report_status`!=5
            GROUP BY pnd.`id_report`
        )pn_list ON pn_list.id_report=pn.id_pn_fgpo
        WHERE pnd.`id_prod_order`=@id_po
        GROUP BY pnd.id_pn_fgpo"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRec.DataSource = data
        BGVRec.BestFitColumns()
    End Sub
End Class