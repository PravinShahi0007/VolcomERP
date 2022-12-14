Public Class FormQCReport1
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormQCReport1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now
        DEStartSum.EditValue = Now
        DEEndSum.EditValue = Now
    End Sub

    Sub load_qc_report1()
        Dim q As String = "SELECT mtq.metode_qc,qr.id_qc_report1,qr.`number`,qr.id_pl_category,qr.`created_date`,qr.note
,qr.id_report_status,qr.id_prod_order,qr.`id_prod_order_rec`,pdd.`id_design`,d.`design_name`
,ss.`season`,cd.class,cd.color,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',d.design_name,' ',cd.color) AS design_display_name 
,po.prod_order_number,rec.prod_order_rec_number,pl.`pl_category`,SUM(qrd.`qc_report1_det_qty`) AS total,sts.report_status
FROM tb_qc_report1_det qrd 
INNER JOIN `tb_qc_report1` qr ON qrd.`id_qc_report1`=qr.`id_qc_report1`
INNER JOIN tb_metode_qc mtq ON mtq.id_metode_qc=qr.id_metode_qc
INNER JOIN tb_prod_order po ON qr.id_prod_order = po.id_prod_order
INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=qr.id_prod_order_rec
INNER JOIN tb_season_delivery del ON del.id_delivery = po.id_delivery
INNER JOIN tb_season ss ON ss.id_season = del.id_season
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design d ON d.`id_design`=pdd.`id_design`
INNER JOIN tb_season s ON s.id_season=d.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
INNER JOIN tb_lookup_pl_category pl ON pl.`id_pl_category`=qr.`id_pl_category`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=qr.id_report_status
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
	AND cd.id_code IN (32,30,14,43,34)
	GROUP BY dc.id_design
)cd ON cd.id_design = d.id_design
WHERE DATE(qr.created_date)>='" & Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(qr.created_date)<='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'
GROUP BY qrd.`id_qc_report1`
ORDER BY qr.id_qc_report1 DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCQCReport.DataSource = dt
        GVQCReport.BestFitColumns()
    End Sub

    Sub check_menu()
        If GVQCReport.RowCount = 0 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"

            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"

            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormQCReport1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormQCReport1_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        load_qc_report1()
    End Sub

    Private Sub GVQCReport_DoubleClick(sender As Object, e As EventArgs) Handles GVQCReport.DoubleClick
        FormQCReport1Det.id = GVQCReport.GetFocusedRowCellValue("id_qc_report1").ToString
        FormQCReport1Det.ShowDialog()
    End Sub

    Private Sub BViewSummary_Click(sender As Object, e As EventArgs) Handles BViewSummary.Click
        load_summary()
    End Sub

    Sub load_summary()
        Dim q As String = "SELECT qrs.id_qc_report1_sum,mtq.metode_qc,po.prod_order_number,qrs.created_date,qrs.number,CONCAT(IF(r.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',d.design_name,' ',cd.color) AS  design_display_name,sts.`report_status`
,s.season,d.design_code
FROM tb_qc_report1_sum qrs
INNER JOIN tb_metode_qc mtq ON mtq.id_metode_qc=qrs.id_metode_qc
INNER JOIN tb_prod_order po ON po.`id_prod_order`=qrs.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design d ON d.id_design=pdd.id_design
INNER JOIN tb_season s ON s.id_season=d.id_season
INNER JOIN tb_range r ON r.id_range=s.id_range
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=qrs.`id_report_status`
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
) cd ON cd.id_design = d.id_design
WHERE DATE(qrs.created_date)>='" & Date.Parse(DEStartSum.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(qrs.created_date)<='" & Date.Parse(DEEndSum.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY qrs.`id_qc_report1_sum` DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSummary.DataSource = dt
        GVSummary.BestFitColumns()
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        FormQCReport1Sum.id = GVSummary.GetFocusedRowCellValue("id_qc_report1_sum").ToString
        FormQCReport1Sum.ShowDialog()
    End Sub
End Class