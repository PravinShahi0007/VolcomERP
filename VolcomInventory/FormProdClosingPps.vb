Public Class FormProdClosingPps
    Public id_pps As String = "-1"
    Public is_view As String = "1"
    '
    Public id_report_status As String = "-1"

    Private Sub FormProdClosingPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        view_claim_reject()
        view_claim_late()

        load_header()
        load_det()
        load_claim_reject()
        load_claim_late()
    End Sub

    Sub load_header()
        Dim query As String = "SELECT poc.`number`,emp.`employee_name`,poc.`created_date`,poc.is_submit,poc.id_report_status FROM tb_prod_order_close poc
INNER JOIN tb_m_user usr ON usr.`id_user`=poc.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=poc.`id_report_status`
WHERE poc.id_prod_order_close='" & id_pps & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            DEDate.EditValue = data.Rows(0)("created_date")
            TEPONumber.Text = data.Rows(0)("number").ToString
            TECreatedBy.Text = data.Rows(0)("employee_name").ToString
            If data.Rows(0)("is_submit").ToString = "1" Then
                BMark.Text = "Mark"
                If data.Rows(0)("id_report_status") = "6" Then
                    BCancelPropose.Visible = False
                End If
            Else
                BMark.Text = "Submit"
            End If

            id_report_status = data.Rows(0)("id_report_status").ToString
        End If
    End Sub

    Sub view_claim_reject()
        Dim query As String = "SELECT id_claim_reject,description FROM `tb_m_claim_reject` cr
WHERE cr.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLERejectClaim, query, 0, "description", "id_claim_reject")
    End Sub

    Sub view_claim_late()
        Dim query As String = "SELECT id_claim_late,description FROM `tb_m_claim_late` cl
WHERE cl.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLEClaimLate, query, 0, "description", "id_claim_late")
    End Sub

    Sub load_claim_late()
        Dim query As String = "SELECT s.`season`,rd.`prod_order_rec_det_qty`,r.`id_prod_order`,po.prod_order_number,rec.rec_qty,pod.po_qty
,dsg.design_display_name,dsg.design_code,SUBSTRING(dsg.`design_display_name`,1,CHAR_LENGTH(dsg.`design_display_name`) - 4) AS dsg_name,RIGHT(dsg.`design_display_name`,3) AS color 
,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY) AS est_rec_date_ko
,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date
,r.`arrive_date`
,ld.`claim_percent`
,wod.prod_order_wo_det_price
,(ld.`claim_percent`/100) * wod.prod_order_wo_det_price AS claim_pc
,SUM(rd.prod_order_rec_det_qty) AS rec_qty_trx
,SUM(rd.prod_order_rec_det_qty) * ((ld.`claim_percent`/100) * wod.prod_order_wo_det_price) AS claim_amo
,r.prod_order_rec_number
,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY)) AS late_day
,c.comp_name
FROM tb_prod_order_rec_det rd
INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`='6'
INNER JOIN `tb_prod_order_close_det` cd ON cd.`id_prod_order`=r.`id_prod_order`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=cd.`id_prod_order`
LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor='1' 
LEFT JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
LEFT JOIN tb_m_ovh_price prc ON prc.id_ovh_price=wo.id_ovh_price
LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=prc.id_comp_contact
LEFT JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN `tb_season_delivery` sd ON sd.`id_delivery`=pdd.`id_delivery`
INNER JOIN `tb_season` s ON s.`id_season`=sd.`id_season`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN  
( 
    SELECT rec.id_prod_order,SUM(recd.prod_order_rec_det_qty) AS rec_qty
    FROM 
    tb_prod_order_rec_det recd 
    INNER JOIN tb_prod_order_rec rec ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY rec.id_prod_order
) rec ON rec.id_prod_order=po.id_prod_order 
LEFT JOIN
(
    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
    FROM tb_prod_order_det pod
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=cd.`id_prod_order`
LEFT JOIN (
    SELECT kod.id_prod_order,kod.lead_time_prod,kod.lead_time_payment
    FROM tb_prod_order_ko_det kod
    INNER JOIN 
    (
	    SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
	    FROM tb_prod_order_ko_det
	    GROUP BY id_prod_order
    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=kod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_locked=1 AND ko.is_void=2
) ko ON ko.id_prod_order=po.id_prod_order
INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
WHERE cd.`id_prod_order_close`='" & id_pps & "' AND  ld.`claim_percent` > 0
GROUP BY rd.`id_prod_order_rec`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClaimLate.DataSource = data
        GVClaimLate.BestFitColumns()
    End Sub

    Sub load_claim_reject()
        Dim query As String = "SELECT dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.*,
                                SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
                                get_claim_reject_percent(pocd.`id_claim_reject`,1) AS p_normal,
                                SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
                                get_claim_reject_percent(pocd.`id_claim_reject`,2) AS p_normal_minor,
                                SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
                                get_claim_reject_percent(pocd.`id_claim_reject`,3) AS p_minor,
                                SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
                                get_claim_reject_percent(pocd.`id_claim_reject`,4) AS p_minor_major,
                                SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
                                get_claim_reject_percent(pocd.`id_claim_reject`,5) AS p_major,
                                SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
                                get_claim_reject_percent(pocd.`id_claim_reject`,6) AS p_afkir,
                                wo_price.prod_order_wo_det_price AS unit_price,
                                ROUND(wo_price.prod_order_wo_det_price * ((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,3)/100)))) AS amo_claim_minor,
                                ROUND(wo_price.prod_order_wo_det_price * ((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,5)/100)))) AS amo_claim_major,
                                ROUND(wo_price.prod_order_wo_det_price * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,6)/100))) AS amo_claim_afkir
                                ,rec.qty_rec AS qty_rec,wo_price.qty_order AS qty_order
                                ,wo_price.comp_name
                                ,dsg.design_display_name
                                ,wo_price.prod_order_wo_det_price
                                FROM tb_prod_order_close_det pocd
                                INNER JOIN tb_prod_fc fc ON fc.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=pocd.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                LEFT JOIN (
	                                SELECT comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`, SUM(pod.prod_order_qty) AS qty_order
	                                FROM tb_prod_order_wo wo
	                                INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
	                                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
                                    LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
                                    LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
                                    LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	                                WHERE wo.is_main_vendor=1 
	                                GROUP BY wo.id_prod_order_wo
                                ) wo_price ON wo_price.id_prod_order=po.id_prod_order
                                LEFT JOIN (
	                                SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
	                                FROM tb_prod_order_rec rec
	                                INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
	                                GROUP BY rec.id_prod_order
                                ) rec ON rec.`id_prod_order`=pocd.`id_prod_order`
                                WHERE pocd.id_prod_order_close = '" & id_pps & "'
                                GROUP BY pocd.`id_prod_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSumClaimReject.DataSource = data
        GVSumClaimReject.BestFitColumns()
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pocd.`id_prod_order_close_det`,pocd.`id_prod_order`
,dsg.`design_code`,dsg.`design_display_name`,po.`prod_order_number`,pocd.`id_claim_late`,pocd.`id_claim_reject`
,wo_price.`comp_name`,rec.rec_qty,pod.po_qty,wo_price.prod_order_wo_det_price AS unit_price
,claim_late.est_rec_date,claim_late.est_rec_date_ko
,ROUND(IFNULL(claim_late.claim_qty,0) * wo_price.prod_order_wo_det_price,2) AS claim_late
,IFNULL(claim_reject.qty_normal,0) AS qty_normal
,IFNULL(claim_reject.qty_minor,0) AS qty_minor
,IFNULL(claim_reject.qty_major,0) AS qty_major
,IFNULL(claim_reject.qty_afkir,0) AS qty_afkir
,IFNULL(sni.qty,0) AS qty_sni
,ROUND(IFNULL(claim_reject.claim_qty,0) * wo_price.prod_order_wo_det_price,2) AS claim_reject
FROM tb_prod_order_close_det pocd
INNER JOIN tb_prod_order_close poc ON poc.`id_prod_order_close`=pocd.`id_prod_order_close`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pocd.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN `tb_season_delivery` sd ON sd.`id_delivery`=pdd.`id_delivery`
INNER JOIN `tb_season` s ON s.`id_season`=sd.`id_season`
LEFT JOIN  
( 
    SELECT rec.id_prod_order,SUM(recd.prod_order_rec_det_qty) AS rec_qty
    FROM 
    tb_prod_order_rec_det recd 
    INNER JOIN tb_prod_order_rec rec ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY rec.id_prod_order
) rec ON rec.id_prod_order=po.id_prod_order 
LEFT JOIN
(
    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
    FROM tb_prod_order_det pod
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=po.`id_prod_order`
LEFT JOIN (
	SELECT comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`, SUM(pod.prod_order_qty) AS qty_order
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
	INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
	LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
	LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order=po.id_prod_order
LEFT JOIN
(
	SELECT rec.id_prod_order,SUM(recd.prod_order_rec_det_qty*(ld.`claim_percent`/100)) AS claim_qty
    ,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY) AS est_rec_date_ko, DATE_ADD(wo.prod_order_wo_del_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date
	FROM tb_prod_order_rec_det recd
	INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=recd.id_prod_order_rec AND rec.id_report_status='6'
	INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
	LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=rec.id_prod_order AND wo.is_main_vendor='1' 
	LEFT JOIN (
	    SELECT kod.id_prod_order,kod.lead_time_prod,kod.lead_time_payment
        FROM tb_prod_order_ko_det kod
        INNER JOIN 
        (
	        SELECT id_prod_order,MAX(id_prod_order_ko_det) AS id_prod_order_ko_det
	        FROM tb_prod_order_ko_det
	        GROUP BY id_prod_order
        )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
        INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=kod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
        INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_locked=1 AND ko.is_void=2
	) ko ON ko.id_prod_order=rec.id_prod_order
	INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(rec.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(rec.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
	GROUP BY rec.id_prod_order
) claim_late ON claim_late.id_prod_order=po.`id_prod_order`
LEFT JOIN
(
	SELECT pocd.`id_prod_order`,
	(SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0))) AS qty_normal,
	(SUM(IF(fc.id_pl_category_sub=2 OR fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))) AS qty_minor,
	(SUM(IF(fc.id_pl_category_sub=4 OR fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))) AS qty_major,
	(SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))) AS qty_afkir,
	(SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,2)/100))
	+ (SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,3)/100))
	+ (SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,4)/100))
	+ (SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,5)/100))
	+ (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,6)/100)) AS claim_qty
	FROM tb_prod_order_close_det pocd
	INNER JOIN tb_prod_fc fc ON fc.`id_prod_order`=pocd.`id_prod_order` AND NOT ISNULL(fc.id_pl_category_sub)
	INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
	INNER JOIN tb_prod_order po ON po.`id_prod_order`=pocd.`id_prod_order`
	INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
	INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
	INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
	INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=pocd.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
	WHERE pocd.id_prod_order_close = '" & id_pps & "'
	GROUP BY pocd.`id_prod_order`
) claim_reject ON claim_reject.id_prod_order=po.`id_prod_order` AND claim_reject.claim_qty > 0
LEFT JOIN
(
    SELECT rec.id_prod_order,IF((SELECT is_enable_sni FROM tb_opt_prod)=1,SUM(io.`qty`)*-1,0) AS qty
    FROM tb_sni_in_out io 
    INNER JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=io.id_prod_order_rec
    GROUP BY rec.`id_prod_order`
) sni ON sni.id_prod_order = po.id_prod_order
WHERE pocd.`id_prod_order_close`='" & id_pps & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub

    Private Sub FormProdClosingPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor

        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            Dim query As String = "SELECT '" & TEPONumber.Text & "' AS prod_close_number,'" & Date.Parse(DEDate.EditValue.ToString).ToString("dd MMM yyyy") & "' AS date_created,'" & Decimal.Parse(GVProd.Columns("po_qty").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS order_qty,'" & Decimal.Parse(GVProd.Columns("rec_qty").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS rec_qty,'" & Decimal.Parse(GVProd.Columns("qty_normal").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_normal,'" & Decimal.Parse(GVProd.Columns("qty_minor").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_minor,'" & Decimal.Parse(GVProd.Columns("qty_major").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_major,'" & Decimal.Parse(GVProd.Columns("claim_reject").SummaryItem.SummaryValue.ToString).ToString("N2") & "' AS amo_claim_reject,'" & Decimal.Parse(GVProd.Columns("claim_late").SummaryItem.SummaryValue.ToString).ToString("N2") & "' AS amo_claim_late,'" & Decimal.Parse(GVProd.Columns("claim_late").SummaryItem.SummaryValue + GVProd.Columns("claim_reject").SummaryItem.SummaryValue).ToString("N2") & "' AS total_claim"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ReportProdClose.dt_det = GCProd.DataSource
            Dim Report As New ReportProdClose()
            Report.DataSource = data
            If Not id_report_status = "6" Then
                Report.id_report = id_pps
                Report.id_pre = "1"
            End If

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            Dim query As String = "SELECT '" & TEPONumber.Text & "' AS prod_close_number,'" & Date.Parse(DEDate.EditValue.ToString).ToString("dd MMM yyyy") & "' AS date_created,'" & Decimal.Parse(GVSumClaimReject.Columns("qty_order").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS order_qty,'" & Decimal.Parse(GVSumClaimReject.Columns("qty_rec").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS rec_qty,'" & Decimal.Parse(GVSumClaimReject.Columns("qc_normal").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_normal,'" & Decimal.Parse(GVSumClaimReject.Columns("qc_minor").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_minor,'" & Decimal.Parse(GVSumClaimReject.Columns("qc_major").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_major,'" & Decimal.Parse(GVSumClaimReject.Columns("qc_afkir").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS qc_afkir,'" & Decimal.Parse(GVSumClaimReject.Columns("total_claim").SummaryItem.SummaryValue.ToString).ToString("N2") & "' AS amo_claim_reject"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ReportProdCloseReject.dt_det = GCSumClaimReject.DataSource
            Dim Report As New ReportProdCloseReject()
            Report.DataSource = data
            If Not id_report_status = "6" Then
                Report.id_report = id_pps
                Report.id_pre = "1"
            End If

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            Dim query As String = "SELECT '" & TEPONumber.Text & "' AS prod_close_number,'" & Date.Parse(DEDate.EditValue.ToString).ToString("dd MMM yyyy") & "' AS date_created,'" & Decimal.Parse(GVClaimLate.Columns("rec_qty_trx").SummaryItem.SummaryValue.ToString).ToString("N0") & "' AS rec_qty_trx,'" & Decimal.Parse(GVClaimLate.Columns("claim_amo").SummaryItem.SummaryValue.ToString).ToString("N2") & "' AS amo_claim_late"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ReportProdCloseLate.dt_det = GCClaimLate.DataSource
            Dim Report As New ReportProdCloseLate()
            Report.DataSource = data
            If Not id_report_status = "6" Then
                Report.id_report = id_pps
                Report.id_pre = "1"
            End If

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_pps
        FormDocumentUpload.report_mark_type = "212"
        FormDocumentUpload.ShowDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If BMark.Text = "Submit" Then
            'update header
            Dim query As String = "UPDATE tb_prod_order_close SET is_submit='1' WHERE id_prod_order_close='" & id_pps & "'"
            execute_non_query(query, True, "", "", "", "")
            'submit
            submit_who_prepared("212", id_pps, id_user)
            infoCustom("Form submitted")
            'load form
            load_form()
        Else
            FormReportMark.id_report = id_pps
            FormReportMark.report_mark_type = "212"
            If is_view = "1" Then
                FormReportMark.is_view = "1"
            End If
            FormReportMark.ShowDialog()
        End If
    End Sub

    Private Sub BCancelPropose_Click(sender As Object, e As EventArgs) Handles BCancelPropose.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to cancel this propose?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'update header
            Dim query As String = "UPDATE tb_prod_order_close SET id_report_status='5' WHERE id_prod_order_close='" & id_pps & "'"
            execute_non_query(query, True, "", "", "", "")
            delete_all_mark_related("212", id_pps)
            load_form()
        End If
    End Sub
End Class