Public Class FormSNIRealisasiPop
    Private Sub FormSNIRealisasiPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT d.id_item_del,dd.id_item_del_det,d.number AS item_del_number,i.item_desc,r.`number` AS item_req_number,(dd.`qty`-IFNULL(usd.tot_qty,0)) AS qty,d.`note`,IF(r.is_for_store=1,166,156) AS report_mark_type,st.value,IFNULL(usd.tot_qty,0) AS tot_qty
FROM tb_item_del_det dd
INNER JOIN tb_item_del d ON d.`id_item_del`=dd.`id_item_del` AND d.`id_report_status`=6
INNER JOIN tb_item_req_det rd ON rd.`id_item_req_det`=dd.`id_item_req_det`
INNER JOIN tb_item_req r ON r.id_item_req=rd.id_item_req
INNER JOIN tb_item i ON i.id_item=rd.id_item
INNER JOIN
(
	SELECT * FROM tb_storage_item st
	WHERE st.`id_item` = '752'
)st ON st.id_item=i.`id_item` AND st.report_mark_type=IF(r.is_for_store=1,166,156) AND st.id_report=d.`id_item_del`
LEFT JOIN
(
	SELECT sb.id_sni_realisasi_budget,sb.id_report,sb.id_report_det,sb.report_mark_type,SUM(qty) AS tot_qty
	FROM `tb_sni_realisasi_budget` sb
	INNER JOIN tb_sni_realisasi s ON s.id_sni_realisasi=sb.id_sni_realisasi
	WHERE s.id_report_status!=5 AND (sb.report_mark_type=166 OR sb.report_mark_type=156)
	GROUP BY sb.id_report,sb.id_report_det,sb.report_mark_type
)usd ON usd.id_report=d.`id_item_del` AND usd.id_report_det=dd.`id_item_del_det` AND usd.report_mark_type=IF(r.is_for_store=1,166,156)
WHERE rd.`id_item`='752'
HAVING qty > 0"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDetail.DataSource = dt
        GVDetail.BestFitColumns()
    End Sub

    Private Sub BApprove_Click(sender As Object, e As EventArgs) Handles BApprove.Click
        If GVDetail.RowCount > 0 Then
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("qty", GVDetail.GetFocusedRowCellValue("qty"))
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("id_report", GVDetail.GetFocusedRowCellValue("id_item_del").ToString)
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("id_report_det", GVDetail.GetFocusedRowCellValue("id_item_del_det").ToString)
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("report_mark_type", GVDetail.GetFocusedRowCellValue("report_mark_type").ToString)
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("report_number", GVDetail.GetFocusedRowCellValue("item_del_number").ToString)
            FormSNIRealisasiDet.GVRealisasi.SetFocusedRowCellValue("value", GVDetail.GetFocusedRowCellValue("value").ToString)
            Close()
        End If
    End Sub
End Class