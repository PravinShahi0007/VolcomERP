Public Class FormAWBManifest
    Public id_del_manifest As String = "-1"

    Private Sub FormAWBManifest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAWBManifest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
    End Sub

    Sub load_det()
        Dim q As String = "SELECT sp.sales_pos_total,rec.value,IF(sp.sales_pos_total>0,IF(IFNULL(rec.value,0)=0,1,0),0) AS not_paid,m.`id_del_manifest`, c.comp_name,m.awbill_no,CONCAT(store.comp_number,' - ',store.comp_name) AS store,m.`number`,pl.pl_sales_order_del_number AS do_number,sp.`sales_pos_number` AS inv_number,GROUP_CONCAT(DISTINCT IFNULL(rec.number,'Invoice 0') SEPARATOR ', ') AS bbm_number
	FROM tb_del_manifest_det md 
	INNER JOIN tb_del_manifest m ON m.id_del_manifest=md.`id_del_manifest` AND m.`id_del_type`=6 
	INNER JOIN tb_m_comp store ON store.id_comp=m.id_store_offline
	INNER JOIN tb_wh_awbill_det awbd ON  md.`id_wh_awb_det`=awbd.`id_wh_awb_det`
	INNER JOIN tb_pl_sales_order_del pl ON awbd.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del` AND pl.id_report_status=6
	INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=pl.`id_store_contact_to`
	INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
	INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	LEFT JOIN 
	(
		SELECT sp.id_sales_pos,sp.report_mark_type,sp.sales_pos_number,sp.id_pl_sales_order_del,sp.`sales_pos_total`
		FROM tb_sales_pos sp
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from` AND sp.`id_report_status`=6 
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)sp ON sp.`id_pl_sales_order_del`=pl.`id_pl_sales_order_del`
	LEFT JOIN
	(
		SELECT r.`number`,r.`id_rec_payment`,rd.`id_report`,rd.`report_mark_type`,pl.`id_sales_order`,rd.`value`
		FROM tb_rec_payment_det rd 
		INNER JOIN tb_rec_payment r ON r.`id_rec_payment`=rd.`id_rec_payment` AND r.`id_report_status`=6
		INNER JOIN tb_sales_pos sp ON sp.`id_sales_pos`=rd.`id_report` AND rd.`report_mark_type`=sp.`report_mark_type`
		INNER JOIN tb_pl_sales_order_del pl ON pl.`id_pl_sales_order_del`=sp.`id_pl_sales_order_del` AND pl.id_report_status=6
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=sp.`id_store_contact_from`
		INNER JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
		INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=c.`id_comp_group` AND cg.is_wholesale=1
	)rec ON rec.`id_report`=sp.`id_sales_pos` AND sp.`report_mark_type`=rec.report_mark_type
	LEFT JOIN
	(
		SELECT scd.`id_del_manifest`,sc.`number` AS scan_manifest,p.`number` AS print_manifest
		FROM tb_odm_sc_det scd 
		INNER JOIN tb_odm_sc sc ON sc.`id_odm_sc`=scd.`id_odm_sc` 
		LEFT JOIN tb_odm_print_det pd ON pd.`id_odm_sc`=sc.`id_odm_sc`
		LEFT JOIN tb_odm_print p ON p.`id_odm_print`=pd.`id_odm_print`
		GROUP BY scd.`id_del_manifest`
	)odm ON odm.id_del_manifest=m.id_del_manifest
	WHERE m.`id_del_manifest`='" & id_del_manifest & "'
	GROUP BY pl.`id_pl_sales_order_del`"
        GCInputAWBManifest.DataSource = execute_query(q, -1, True, "", "", "", "")
        GVInputAWBManifest.BestFitColumns()
    End Sub

    Private Sub BCompleteWholesale_Click(sender As Object, e As EventArgs) Handles BCompleteWholesale.Click
        If TEAwb.Text = "" Then
            warningCustom("Please input AWB")
        Else
            'check awb
            Dim qc As String = "SELECT awbill_no FROM tb_wh_awbill WHERE awbill_no='" & addSlashes(TEAwb.Text) & "' AND id_report_status!=5
AND id_awbill NOT IN (SELECT id_awbill FROM tb_del_manifest_det WHERE id_del_manifest='" & id_del_manifest & "')
UNION ALL
SELECT awbill_no FROM tb_del_manifest WHERE awbill_no='" & addSlashes(TEAwb.Text) & "' AND id_report_status!=5 AND id_del_manifest!='" & id_del_manifest & "'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            If dtc.Rows.Count > 0 Then
                stopCustom("AWB number already used.")
            Else
                Dim qu As String = ""
                qu = "UPDATE tb_del_manifest SET awbill_no='" & addSlashes(TEAwb.Text) & "' WHERE id_del_manifest='" & id_del_manifest & "'"
                execute_non_query(qu, True, "", "", "", "")

                'Update AWB
                qu = "UPDATE tb_wh_awbill awb 
INNER JOIN tb_wh_awbill_det awbd ON awbd.`id_awbill`=awb.`id_awbill`
INNER JOIN `tb_del_manifest_det` dmd ON dmd.`id_wh_awb_det`=awbd.`id_wh_awb_det`
INNER JOIN tb_del_manifest dm ON dm.id_del_manifest=dmd.`id_del_manifest`
SET awb.`awbill_no`=dm.`awbill_no`
WHERE dmd.`id_del_manifest`='" & id_del_manifest & "'"
                execute_non_query(qu, True, "", "", "", "")

                Close()
            End If
        End If
    End Sub
End Class