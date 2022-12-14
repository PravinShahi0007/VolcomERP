Public Class FormDebitNote
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormDebitNote_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormDebitNote_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormDebitNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewVendor()
    End Sub

    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label 
UNION ALL
SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_form()
    End Sub

    Sub load_form()
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            load_debit_note()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            load_claim_reject()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            load_claim_late()
        End If
    End Sub

    Sub load_debit_note()
        Dim q_where As String = ""
        '
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " WHERE dn.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT dn.id_debit_note,dn.number,dnt.`dn_type`,dn.`created_date`,sts.`report_status`,emp.`employee_name`,comp.`comp_name`,SUM((dnd.claim_percent/100)*dnd.unit_price*dnd.qty) AS amount 
FROM tb_debit_note_det dnd
INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` 
INNER JOIN tb_lookup_dn_type dnt ON dnt.`id_dn_type`=dn.`id_dn_type`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=dn.`id_report_status`
INNER JOIN tb_m_user usr ON usr.`id_user`=dn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp comp ON comp.`id_comp`=dn.`id_comp`
" & q_where & "
GROUP BY dnd.`id_debit_note`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDebitNote.DataSource = data
        GVDebitNote.BestFitColumns()
    End Sub

    Sub load_claim_late()
        Dim q_where As String = ""
        '
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = ""
        '        query = "SELECT 'no' AS is_check,'28' AS report_mark_type,r.`id_prod_order_rec`,s.`season`,rd.`prod_order_rec_det_qty`,r.`id_prod_order`,po.prod_order_number,rec.rec_qty,pod.po_qty
        ',dsg.design_display_name,dsg.design_code,SUBSTRING(dsg.`design_display_name`,1,CHAR_LENGTH(dsg.`design_display_name`) - 4) AS dsg_name,RIGHT(dsg.`design_display_name`,3) AS color 
        ',DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY) AS est_rec_date_ko
        ',DATE_ADD(wo.prod_order_wo_del_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date
        ',r.`arrive_date`
        ',ld.`claim_percent`
        ',wod.prod_order_wo_det_price
        ',(ld.`claim_percent`/100) * wod.prod_order_wo_det_price AS claim_pc
        ',SUM(rd.prod_order_rec_det_qty) AS rec_qty_trx
        ',SUM(rd.prod_order_rec_det_qty) * ((ld.`claim_percent`/100) * wod.prod_order_wo_det_price) AS claim_amo
        ',r.prod_order_rec_number
        ',DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY)) AS late_day
        ',c.comp_name
        ',r.id_prod_order
        ',wo.prod_order_wo_kurs
        ',cur.currency,cur.id_currency
        'FROM tb_prod_order_rec_det rd
        'INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`='6' AND r.is_claimed_late=2
        'INNER JOIN tb_prod_order po ON po.`id_prod_order`=r.`id_prod_order`
        'LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor='1' 
        'LEFT JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
        'LEFT JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
        'LEFT JOIN tb_m_ovh_price prc ON prc.id_ovh_price=wo.id_ovh_price
        'LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=prc.id_comp_contact
        'LEFT JOIN tb_m_comp c ON c.id_comp=cc.id_comp
        'INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
        'INNER JOIN `tb_season_delivery` sd ON sd.`id_delivery`=pdd.`id_delivery`
        'INNER JOIN `tb_season` s ON s.`id_season`=sd.`id_season`
        'INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
        'LEFT JOIN  
        '( 
        '    SELECT rec.id_prod_order,SUM(recd.prod_order_rec_det_qty) AS rec_qty
        '    FROM 
        '    tb_prod_order_rec_det recd 
        '    INNER JOIN tb_prod_order_rec rec ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
        '    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order`
        '    INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
        '    GROUP BY rec.id_prod_order
        ') rec ON rec.id_prod_order=po.id_prod_order 
        'LEFT JOIN
        '(
        '    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
        '    FROM tb_prod_order_det pod
        '    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order`
        '    INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
        '    GROUP BY pod.`id_prod_order`
        ') pod ON pod.id_prod_order=r.`id_prod_order`
        'LEFT JOIN (
        '    SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
        '	    SELECT kod.* FROM tb_prod_order_ko_det kod
        '	    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=kod.`id_prod_order`
        '        INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
        '	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.`is_void`!=1
        '        INNER JOIN 
        '	    (
        '		    SELECT MAX(id_prod_order_ko) AS id_prod_order_ko
        '		    FROM tb_prod_order_ko
        '		    WHERE `is_void`!=1
        '		    GROUP BY id_prod_order_ko_reff
        '	    )komax ON komax.id_prod_order_ko=ko.id_prod_order_ko
        '    )ko GROUP BY ko.id_prod_order
        ') ko ON ko.id_prod_order=po.id_prod_order
        'LEFT JOIN (
        '    SELECT id_report FROM tb_debit_note_det dnd
        '    INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=28 AND dn.`id_report_status`!=5
        '    GROUP BY dnd.id_report
        ') dn ON dn.id_report=r.id_prod_order_rec
        'INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
        'WHERE ld.`claim_percent` > 0  AND ISNULL(dn.id_report) " & q_where & " GROUP BY rd.`id_prod_order_rec`"

        query = "SELECT 'no' AS is_check,'28' AS report_mark_type,r.`id_prod_order_rec`,s.`season`,SUM(rd.`prod_order_rec_det_qty`) AS prod_order_rec_det_qty,r.`id_prod_order`,po.prod_order_number,rec.rec_qty,pod.po_qty
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
,r.id_prod_order
,wo.prod_order_wo_kurs
,cur.currency,cur.id_currency
,IF(ISNULL(clos.id_prod_order),'Need Closing','Ready') AS sts_close
,IF(r.is_over_tol=1,'127','28') AS rmt
FROM tb_prod_order_rec_det rd
INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`='6' AND r.is_claimed_late=2
INNER JOIN tb_prod_order po ON po.`id_prod_order`=r.`id_prod_order`
LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor='1' 
LEFT JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
LEFT JOIN (
	SELECT wod.id_prod_order_wo,wod.prod_order_wo_det_price FROM
	tb_prod_order_wo_det wod 
	GROUP BY wod.id_prod_order_wo
)wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
LEFT JOIN tb_m_ovh_price prc ON prc.id_ovh_price=wo.id_ovh_price
LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=prc.id_comp_contact
LEFT JOIN tb_m_comp c ON c.id_comp=cc.id_comp
LEFT JOIN
(
	SELECT id_prod_order
	FROM `tb_prod_order_close_det` cd 
	INNER JOIN `tb_prod_order_close` c ON c.id_prod_order_close=cd.id_prod_order_close
	WHERE c.id_report_status=6
)clos ON clos.id_prod_order=po.id_prod_order
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
    GROUP BY rec.id_prod_order
) rec ON rec.id_prod_order=po.id_prod_order 
LEFT JOIN
(
    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
    FROM tb_prod_order_det pod
    GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=r.`id_prod_order`
INNER JOIN (
	SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
		SELECT kod.* 
		FROM tb_prod_order_ko_det kod
		INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.`is_void`!=1
		INNER JOIN 
		(
		    SELECT MAX(id_prod_order_ko) AS id_prod_order_ko
		    FROM tb_prod_order_ko
		    WHERE `is_void`!=1 AND is_locked=1 AND id_report_status!=5
		    GROUP BY id_prod_order_ko_reff
		)komax ON komax.id_prod_order_ko=ko.id_prod_order_ko
	)ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=po.id_prod_order
LEFT JOIN (
    SELECT id_report FROM tb_debit_note_det dnd
    INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=28 AND dn.`id_report_status`!=5
    GROUP BY dnd.id_report
) dn ON dn.id_report=r.id_prod_order_rec
INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
WHERE ld.`claim_percent` > 0  AND ISNULL(dn.id_report) 
" & q_where & "
GROUP BY rd.`id_prod_order_rec`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClaimLate.DataSource = data
        GVClaimLate.BestFitColumns()
        If SLEVendor.EditValue.ToString = "0" Then
            BCreateDNLate.Visible = False
        Else
            BCreateDNLate.Visible = True
        End If
    End Sub

    Sub load_claim_reject()
        'check AR first
        Dim is_no_ar As Boolean = False

        If Not SLEVendor.EditValue.ToString = "0" Then
            Dim query_check As String = "SELECT IFNULL(id_acc_ar,0) AS id_acc_ar FROM tb_m_comp c
WHERE c.id_comp='" & SLEVendor.EditValue.ToString & "'"
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")

            If data_check.Rows(0)("id_acc_ar").ToString = "0" Then
                is_no_ar = True
            End If
        End If

        If is_no_ar Then
            warningCustom("Please check AR mapping !")
        Else
            Dim q_where As String = ""
            '
            If Not SLEVendor.EditValue.ToString = "0" Then
                q_where = " AND wo_price.id_comp='" & SLEVendor.EditValue.ToString & "'"
            End If

            Dim query As String = ""
            'AQL 14 June 2022, all international
            query = "SET collation_connection = 'latin1_swedish_ci';
SELECT dn.is_check,dn.id_prod_fc_sum,dn.report_mark_type,dn.prod_fc_number,dn.id_prod_order,dn.design_code,dn.design_name,dn.prod_order_number,dn.pl_category_sub,dn.id_prod_fc_det,dn.id_prod_fc,dn.id_prod_order_det,dn.id_product,dn.prod_fc_det_qty,dn.prod_fc_det_note
,dn.qc_normal,dn.p_normal
,dn.qc_normal_minor,IF(ISNULL(rv.id_aql),dn.p_normal_minor,IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0)) AS p_normal_minor
,dn.qc_minor,IF(ISNULL(rv.id_aql),dn.p_minor,IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0)) AS p_minor
,dn.qc_minor_major,IF(ISNULL(rv.id_aql),dn.p_minor_major,IF(dn.tot_major>rv.max_major,rv.claim_major,0)) AS p_minor_major
,dn.qc_major,IF(ISNULL(rv.id_aql),dn.p_major,IF(dn.tot_major>rv.max_major,rv.claim_major,0)) AS p_major
,dn.qc_afkir,dn.p_afkir
,dn.unit_price
,dn.rec_discount
,IF(ISNULL(rv.id_aql),dn.amo_claim_minor,ROUND((((IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0))-dn.rec_discount)/100)*dn.qc_normal_minor*dn.unit_price)+ROUND((((IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0))-dn.rec_discount)/100)*dn.qc_minor*dn.unit_price)) AS amo_claim_minor
,IF(ISNULL(rv.id_aql),dn.amo_claim_major,ROUND((((IF(dn.tot_major>rv.max_major,rv.claim_major,0))-dn.rec_discount)/100)*dn.qc_minor_major*dn.unit_price)+ROUND((((IF(dn.tot_major>rv.max_major,rv.claim_major,0))-dn.rec_discount)/100)*dn.qc_major*dn.unit_price)) AS amo_claim_major
,IF(ISNULL(rv.id_aql),dn.special_note,rv.special_note) AS special_note
,dn.amo_claim_afkir
,dn.qty_rec,dn.qty_order
,dn.comp_name,dn.design_display_name
,dn.prod_order_wo_det_price -- real price rec
,dn.prod_order_rec_number
,dn.rec_pl_category
,dn.rec_amount_disc
,dn.id_reff,dn.sum_number
,dn.id_currency,dn.currency,dn.prod_order_wo_kurs
,dn.tot_minor,dn.tot_minor_perc,dn.tot_major,dn.tot_major_perc,dn.total_rec
,dn.po_type,dn.dsg_cat
FROM
(
    SELECT 'no' AS is_check,fcs.id_prod_fc_sum,'22' AS report_mark_type,fc.`prod_fc_number`,po.`id_prod_order`,dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.id_prod_fc_det,fcd.id_prod_fc,fcd.id_prod_order_det,fcd.id_product,fcd.prod_fc_det_qty,fcd.prod_fc_det_note,
    SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
    get_claim_reject_percent_new(100,ko.`id_claim_reject`,1) AS p_normal,
    SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
    get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2) AS p_normal_minor,
    SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
    get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3) AS p_minor,
    SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
    get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4) AS p_minor_major,
    SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
    get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5) AS p_major,
    SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
    get_claim_reject_percent_new(100,ko.`id_claim_reject`,6) AS p_afkir,
    wo_price.prod_order_wo_det_price AS unit_price,
    ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_minor,
    ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_major,
    ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_afkir
    -- ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_minor,
    -- ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_major,
    -- ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_afkir
    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)/100)))) AS amo_claim_minor,
    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)/100)))) AS amo_claim_major,
    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)/100))) AS amo_claim_afkir
    ,IFNULL(recfc.qty_rec,rec.qty_rec) AS qty_rec,wo_price.qty_order AS qty_order
    ,wo_price.comp_name
    ,wo_price.id_comp
    ,dsg.design_display_name
    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS prod_order_wo_det_price -- real price rec
    ,recfc.prod_order_rec_number,IFNULL(recfc.claim_percent,0) AS rec_discount
    ,IFNULL(pl_rec.pl_category,'Normal') AS rec_pl_category
    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS rec_amount_disc
    ,fc.id_prod_fc AS id_reff,fcs.number AS sum_number
    ,wo_price.id_currency,wo_price.currency,wo_price.prod_order_wo_kurs
    ,tot_rej.qty_minor AS tot_minor,tot_rej.perc_minor  AS tot_minor_perc,tot_rej.qty_major AS tot_major,tot_rej.perc_major  AS tot_major_perc,tot_rej.qty_rec AS total_rec
    ,ko.po_type,ko.dsg_cat
    ,crn.description AS special_note
    FROM tb_prod_fc_sum_det fcsd
    INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=fcsd.`id_prod_fc_sum` AND fcs.`id_report_status`='6'
    INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcsd.`id_prod_fc` AND fc.id_report_status=6
    LEFT JOIN (
        SELECT rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,rec.claim_percent,rec.prod_order_rec_number,rec.id_pl_category
        FROM tb_prod_order_rec_det recd
        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
        GROUP BY rec.`id_prod_order_rec`
    ) recfc ON recfc.`id_prod_order_rec`=fc.`id_prod_order_rec`
    LEFT JOIN tb_lookup_pl_category pl_rec ON pl_rec.`id_pl_category`=recfc.`id_pl_category`
    INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
    INNER JOIN tb_prod_order po ON po.`id_prod_order`=fc.`id_prod_order` AND po.is_claimed_reject=2
    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
    INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
    LEFT JOIN
    (
	    SELECT fc.`id_prod_order`,SUM(IF(s.`id_claim_group`=2,fcd.prod_fc_det_qty,0)) AS qty_minor, SUM(IF(s.`id_claim_group`=3,fcd.prod_fc_det_qty,0)) AS qty_major,rec.qty AS qty_rec
        ,ROUND((SUM(IF(s.`id_claim_group`=2,fcd.prod_fc_det_qty,0))/rec.qty)*100,2) AS perc_minor,ROUND((SUM(IF(s.`id_claim_group`=3,fcd.prod_fc_det_qty,0))/rec.qty)*100,2) AS perc_major
        FROM `tb_prod_fc_sum_det` sd
        INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=sd.`id_prod_fc_sum` AND fcs.`id_report_status`=6
        INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=sd.`id_prod_fc`
        INNER JOIN tb_lookup_pl_category_sub s ON s.`id_pl_category_sub`=fc.`id_pl_category_sub`
        INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc`
        INNER JOIN
        (
	        SELECT rec.`id_prod_order`,po.id_po_type,co.id_country,SUM(recd.`prod_order_rec_det_qty`) AS qty 
	        FROM tb_prod_order_rec_det recd 
	        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
		INNER JOIN tb_prod_order po ON rec.id_prod_order=po.id_prod_order
	        INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
		INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
		INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
		INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
		INNER JOIN tb_m_city ct ON ct.`id_city`=comp.`id_city`
		INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
		INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
		INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country` 
	        GROUP BY rec.`id_prod_order`
        )rec ON rec.id_prod_order=fc.`id_prod_order` AND IF(rec.id_po_type=2 OR rec.id_country!=5,fcs.id_metode_qc=2,TRUE)
        GROUP BY fc.`id_prod_order`
    )tot_rej ON tot_rej.id_prod_order=po.id_prod_order
    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
    INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
    LEFT JOIN (
        SELECT ko.`id_prod_order`,ko.`id_claim_reject`,ko.po_type,ko.code_detail_name AS dsg_cat
        FROM (
	    (SELECT kod.`id_prod_order`,ko.`id_claim_reject`,'Domestic' AS po_type,cd.`code_detail_name` FROM tb_prod_order_ko_det kod
	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_void='2' AND is_locked='1'
	    INNER JOIN tb_prod_order po  ON po.`id_prod_order`=kod.`id_prod_order`
	    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
	    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
	    INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
	    INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
	    INNER JOIN
	    (
		    SELECT kod.id_prod_order,MAX(kod.id_prod_order_ko_det) AS id_prod_order_ko_det
		    FROM tb_prod_order_ko_det kod
		    INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
		    GROUP BY kod.id_prod_order
	    )koh ON koh.id_prod_order_ko_det=kod.id_prod_order_ko_det)
	    UNION ALL
	    (SELECT po.id_prod_order,IF(cd.id_code_detail=3822,4,3) AS id_claim_reject,'International' AS po_type,cd.`code_detail_name`
	    FROM tb_prod_order po 
	    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
	    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
	    INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
	    INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
	    WHERE po.id_po_type=2 AND po.id_report_status=6)
	    UNION ALL
	    (SELECT po.id_prod_order,IF(cd.id_code_detail=3822,4,3) AS id_claim_reject,'International' AS po_type,cd.`code_detail_name`
	    FROM tb_prod_order po 
	    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
	    INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
	    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
	    INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	    INNER JOIN tb_m_city ct ON ct.`id_city`=comp.`id_city`
	    INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
	    INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
	    INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country` AND co.`id_country`!=5
	    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
	    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
	    INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
	    INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
	    WHERE po.id_po_type=3 AND po.id_report_status=6)
        )ko GROUP BY ko.id_prod_order
    ) ko ON ko.id_prod_order=po.id_prod_order 
    INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=ko.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
    INNER JOIN tb_m_claim_reject crn ON crn.`id_claim_reject`=crd.`id_claim_reject`
    LEFT JOIN (
	SELECT comp.id_comp, comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price, cur.id_currency, cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, IFNULL(wo_old.old_kurs,wo.`prod_order_wo_kurs`) AS prod_order_wo_kurs, SUM(pod.prod_order_qty) AS qty_order
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
	LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
	LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	LEFT JOIN
	(
	    SELECT id_wo,old_kurs FROM `tb_prod_order_wo_log`
	    WHERE id_wo_log IN (
		    SELECT MIN(id_wo_log)
		    FROM tb_prod_order_wo_log logx
		    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=logx.id_wo 
		    GROUP BY wo.`id_prod_order_wo`
	    )
	)wo_old ON wo_old.id_wo=wo.id_prod_order_wo
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
    ) wo_price ON wo_price.id_prod_order=po.id_prod_order
    LEFT JOIN (
	SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
	FROM tb_prod_order_rec rec
	INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
	GROUP BY rec.id_prod_order
    ) rec ON rec.`id_prod_order`=fc.`id_prod_order`
    LEFT JOIN (
        SELECT id_reff FROM tb_debit_note_det dnd
        INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=22 AND dn.`id_report_status`!=5
        GROUP BY dnd.id_reff
    ) dn ON dn.id_reff=fc.id_prod_fc
    WHERE IF(ko.po_type='International',fcs.id_metode_qc=2 OR fcs.is_before_aql=1,TRUE) AND fc.id_report_status = '6' AND fc.is_not_claim=2 AND ISNULL(dn.id_reff) " & q_where & "
    GROUP BY fc.`id_prod_fc`
    HAVING (amo_claim_minor + amo_claim_major + amo_claim_afkir) > 0
)dn
LEFT JOIN
(
	SELECT r.`id_aql`,r.`max_qty_order`,r.`min_qty_order`,r.`max_major`,r.`max_minor`,r.claim_minor,r.claim_major
	,CONCAT('AQL, Minor ',r.`claim_minor`,'% Major ',r.`claim_major`,'%, Order Qty(',r.`min_qty_order`,'-',IF(r.`max_qty_order`=100000,' ',r.`max_qty_order`),'),Max Minor ',r.`max_minor`,' pcs,Max Major ',r.`max_major`,' pcs') AS special_note
	FROM `tb_import_aql` r
)rv ON dn.`po_type`='International' AND dn.qty_order>=rv.min_qty_order AND dn.qty_order<=rv.max_qty_order
HAVING (amo_claim_minor + amo_claim_major + amo_claim_afkir) > 0"
            'old before AQL 14 June 2022
            '            query = "
            'SELECT dn.is_check,dn.id_prod_fc_sum,dn.report_mark_type,dn.prod_fc_number,dn.id_prod_order,dn.design_code,dn.design_name,dn.prod_order_number,dn.pl_category_sub,dn.id_prod_fc_det,dn.id_prod_fc,dn.id_prod_order_det,dn.id_product,dn.prod_fc_det_qty,dn.prod_fc_det_note
            ',dn.qc_normal,dn.p_normal
            ',dn.qc_normal_minor,IF(ISNULL(rv.id_import_rule),dn.p_normal_minor,IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0)) AS p_normal_minor
            ',dn.qc_minor,IF(ISNULL(rv.id_import_rule),dn.p_minor,IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0)) AS p_minor
            ',dn.qc_minor_major,IF(ISNULL(rv.id_import_rule),dn.p_minor_major,IF(dn.tot_major>rv.max_major,rv.claim_major,0)) AS p_minor_major
            ',dn.qc_major,IF(ISNULL(rv.id_import_rule),dn.p_major,IF(dn.tot_major>rv.max_major,rv.claim_major,0)) AS p_major
            ',dn.qc_afkir,dn.p_afkir
            ',dn.unit_price
            ',dn.rec_discount
            ',IF(ISNULL(rv.id_import_rule),dn.amo_claim_minor,ROUND((((IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0))-dn.rec_discount)/100)*dn.qc_normal_minor*dn.unit_price)+ROUND((((IF(dn.tot_minor>rv.max_minor,rv.claim_minor,0))-dn.rec_discount)/100)*dn.qc_minor*dn.unit_price)) AS amo_claim_minor
            ',IF(ISNULL(rv.id_import_rule),dn.amo_claim_major,ROUND((((IF(dn.tot_major>rv.max_major,rv.claim_major,0))-dn.rec_discount)/100)*dn.qc_minor_major*dn.unit_price)+ROUND((((IF(dn.tot_major>rv.max_major,rv.claim_major,0))-dn.rec_discount)/100)*dn.qc_major*dn.unit_price)) AS amo_claim_major
            ',IF(ISNULL(rv.id_import_rule),dn.special_note,rv.special_note) AS special_note
            ',dn.amo_claim_afkir
            ',dn.qty_rec,dn.qty_order
            ',dn.comp_name,dn.design_display_name
            ',dn.prod_order_wo_det_price -- real price rec
            ',dn.prod_order_rec_number
            ',dn.rec_pl_category
            ',dn.rec_amount_disc
            ',dn.id_reff,dn.sum_number
            ',dn.id_currency,dn.currency,dn.prod_order_wo_kurs
            ',dn.tot_minor,dn.tot_minor_perc,dn.tot_major,dn.tot_major_perc,dn.total_rec
            ',dn.po_type,dn.dsg_cat
            'FROM
            '(
            '    SELECT 'no' AS is_check,fcs.id_prod_fc_sum,'22' AS report_mark_type,fc.`prod_fc_number`,po.`id_prod_order`,dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.id_prod_fc_det,fcd.id_prod_fc,fcd.id_prod_order_det,fcd.id_product,fcd.prod_fc_det_qty,fcd.prod_fc_det_note,
            '    SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
            '    get_claim_reject_percent_new(100,ko.`id_claim_reject`,1) AS p_normal,
            '    SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
            '    get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2) AS p_normal_minor,
            '    SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
            '    get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3) AS p_minor,
            '    SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
            '    get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4) AS p_minor_major,
            '    SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
            '    get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5) AS p_major,
            '    SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
            '    get_claim_reject_percent_new(100,ko.`id_claim_reject`,6) AS p_afkir,
            '    wo_price.prod_order_wo_det_price AS unit_price,
            '    ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_minor,
            '    ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_major,
            '    ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_afkir
            '    -- ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_minor,
            '    -- ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_major,
            '    -- ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_afkir
            '    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_minor,ko.`id_claim_reject`,3)/100)))) AS amo_claim_minor,
            '    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(tot_rej.perc_major,ko.`id_claim_reject`,5)/100)))) AS amo_claim_major,
            '    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent_new(100,ko.`id_claim_reject`,6)/100))) AS amo_claim_afkir
            '    ,IFNULL(recfc.qty_rec,rec.qty_rec) AS qty_rec,wo_price.qty_order AS qty_order
            '    ,wo_price.comp_name
            '    ,wo_price.id_comp
            '    ,dsg.design_display_name
            '    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS prod_order_wo_det_price -- real price rec
            '    ,recfc.prod_order_rec_number,IFNULL(recfc.claim_percent,0) AS rec_discount
            '    ,IFNULL(pl_rec.pl_category,'Normal') AS rec_pl_category
            '    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS rec_amount_disc
            '    ,fc.id_prod_fc AS id_reff,fcs.number AS sum_number
            '    ,wo_price.id_currency,wo_price.currency,wo_price.prod_order_wo_kurs
            '    ,tot_rej.qty_minor AS tot_minor,tot_rej.perc_minor  AS tot_minor_perc,tot_rej.qty_major AS tot_major,tot_rej.perc_major  AS tot_major_perc,tot_rej.qty_rec AS total_rec
            '    ,ko.po_type,ko.dsg_cat
            '    ,crn.description AS special_note
            '    FROM tb_prod_fc_sum_det fcsd
            '    INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=fcsd.`id_prod_fc_sum` AND fcs.`id_report_status`='6'
            '    INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcsd.`id_prod_fc` AND fc.id_report_status=6
            '    LEFT JOIN (
            '        SELECT rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,rec.claim_percent,rec.prod_order_rec_number,rec.id_pl_category
            '        FROM tb_prod_order_rec_det recd
            '        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
            '        GROUP BY rec.`id_prod_order_rec`
            '    ) recfc ON recfc.`id_prod_order_rec`=fc.`id_prod_order_rec`
            '    LEFT JOIN tb_lookup_pl_category pl_rec ON pl_rec.`id_pl_category`=recfc.`id_pl_category`
            '    INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
            '    INNER JOIN tb_prod_order po ON po.`id_prod_order`=fc.`id_prod_order` AND po.is_claimed_reject=2
            '    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
            '    INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
            '    LEFT JOIN
            '    (
            '	    SELECT fc.`id_prod_order`,SUM(IF(s.`id_claim_group`=2,fcd.prod_fc_det_qty,0)) AS qty_minor, SUM(IF(s.`id_claim_group`=3,fcd.prod_fc_det_qty,0)) AS qty_major,rec.qty AS qty_rec
            '        ,ROUND((SUM(IF(s.`id_claim_group`=2,fcd.prod_fc_det_qty,0))/rec.qty)*100,2) AS perc_minor,ROUND((SUM(IF(s.`id_claim_group`=3,fcd.prod_fc_det_qty,0))/rec.qty)*100,2) AS perc_major
            '        FROM `tb_prod_fc_sum_det` sd
            '        INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=sd.`id_prod_fc_sum` AND fcs.`id_report_status`=6
            '        INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=sd.`id_prod_fc`
            '        INNER JOIN tb_lookup_pl_category_sub s ON s.`id_pl_category_sub`=fc.`id_pl_category_sub`
            '        INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc`
            '        INNER JOIN
            '        (
            '	        SELECT rec.`id_prod_order`,SUM(recd.`prod_order_rec_det_qty`) AS qty 
            '	        FROM tb_prod_order_rec_det recd 
            '	        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
            '	        GROUP BY rec.`id_prod_order`
            '        )rec ON rec.id_prod_order=fc.`id_prod_order`
            '        GROUP BY fc.`id_prod_order`
            '    )tot_rej ON tot_rej.id_prod_order=po.id_prod_order
            '    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            '    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            '    INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
            '    LEFT JOIN (
            '        SELECT ko.`id_prod_order`,ko.`id_claim_reject`,ko.po_type,ko.code_detail_name AS dsg_cat
            '        FROM (
            '		    (SELECT kod.`id_prod_order`,ko.`id_claim_reject`,'Domestic' AS po_type,cd.`code_detail_name` FROM tb_prod_order_ko_det kod
            '            INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_void='2' AND is_locked='1'
            '            INNER JOIN tb_prod_order po  ON po.`id_prod_order`=kod.`id_prod_order`
            '            INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            '            INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            '            INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
            '            INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
            '            INNER JOIN
            '            (
            '	            SELECT kod.id_prod_order,MAX(kod.id_prod_order_ko_det) AS id_prod_order_ko_det
            '	            FROM tb_prod_order_ko_det kod
            '	            INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order)
            '	            GROUP BY kod.id_prod_order
            '            )koh ON koh.id_prod_order_ko_det=kod.id_prod_order_ko_det)
            '		    UNION ALL
            '		    (SELECT po.id_prod_order,IF(cd.id_code_detail=3822,4,3) AS id_claim_reject,'International' AS po_type,cd.`code_detail_name`
            '		    FROM tb_prod_order po 
            '		    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            '		    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            '		    INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
            '		    INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
            '		    WHERE po.id_po_type=2 AND po.id_report_status=6)
            '		    UNION ALL
            '		    (SELECT po.id_prod_order,IF(cd.id_code_detail=3822,4,3) AS id_claim_reject,'International' AS po_type,cd.`code_detail_name`
            '		    FROM tb_prod_order po 
            '		    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
            '		    INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
            '		    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
            '		    INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            '		    INNER JOIN tb_m_city ct ON ct.`id_city`=comp.`id_city`
            '		    INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
            '		    INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
            '		    INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country` AND co.`id_country`!=5
            '		    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            '		    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            '		    INNER JOIN tb_m_design_code dc ON dc.id_design=dsg.`id_design`
            '		    INNER JOIN tb_m_code_detail cd ON dc.id_code_detail=cd.id_code_detail AND cd.id_code='31'
            '		    WHERE po.id_po_type=3 AND po.id_report_status=6)
            '        )ko GROUP BY ko.id_prod_order
            '    ) ko ON ko.id_prod_order=po.id_prod_order 
            '    INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=ko.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
            '    INNER JOIN tb_m_claim_reject crn ON crn.`id_claim_reject`=crd.`id_claim_reject`
            '    LEFT JOIN (
            '	    SELECT comp.id_comp, comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price, cur.id_currency, cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, IFNULL(wo_old.old_kurs,wo.`prod_order_wo_kurs`) AS prod_order_wo_kurs, SUM(pod.prod_order_qty) AS qty_order
            '	    FROM tb_prod_order_wo wo
            '	    INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
            '	    INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
            '	    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
            '	    LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
            '	    LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
            '	    LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            '        LEFT JOIN
            '	    (
            '		    SELECT id_wo,old_kurs FROM `tb_prod_order_wo_log`
            '		    WHERE id_wo_log IN (
            '			    SELECT MIN(id_wo_log)
            '			    FROM tb_prod_order_wo_log logx
            '			    INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=logx.id_wo 
            '			    GROUP BY wo.`id_prod_order_wo`
            '		    )
            '	    )wo_old ON wo_old.id_wo=wo.id_prod_order_wo
            '	    WHERE wo.is_main_vendor=1 
            '	    GROUP BY wo.id_prod_order_wo
            '    ) wo_price ON wo_price.id_prod_order=po.id_prod_order
            '    LEFT JOIN (
            '	    SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
            '	    FROM tb_prod_order_rec rec
            '	    INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
            '	    GROUP BY rec.id_prod_order
            '    ) rec ON rec.`id_prod_order`=fc.`id_prod_order`
            '    LEFT JOIN (
            '        SELECT id_reff FROM tb_debit_note_det dnd
            '        INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=22 AND dn.`id_report_status`!=5
            '        GROUP BY dnd.id_reff
            '    ) dn ON dn.id_reff=fc.id_prod_fc
            '    WHERE fc.id_report_status = '6' AND fc.is_not_claim=2 AND ISNULL(dn.id_reff) " & q_where & "
            '    GROUP BY fc.`id_prod_fc`
            '    HAVING (amo_claim_minor + amo_claim_major + amo_claim_afkir) >= 0
            ')dn
            'LEFT JOIN
            '(
            '	SELECT r.`id_import_rule`,r.import_rule,rv.id_comp,rd.`max_qty_order`,rd.`min_qty_order`,rd.`max_major`,rd.`max_minor`,r.claim_minor,r.claim_major
            '	,CONCAT(r.`import_rule`,', Minor ',r.`claim_minor`,'% Major ',r.`claim_major`,'%, Rec Qty(',rd.`min_qty_order`,'-',IF(rd.`max_qty_order`=100000,' ',rd.`max_qty_order`),'),Max Minor ',rd.`max_minor`,' pcs,Max Major ',rd.`max_major`,' pcs') AS special_note
            '	FROM `tb_import_rule_vendor` rv
            '	INNER JOIN tb_import_rule r ON r.`id_import_rule`=rv.`id_import_rule` AND r.`is_active`=1
            '	INNER JOIN tb_import_rule_det rd ON rd.`id_import_rule`=r.`id_import_rule`
            ')rv ON 
            'dn.`id_comp`=rv.id_comp AND
            'dn.total_rec>=rv.min_qty_order AND dn.total_rec<=rv.max_qty_order
            '"

            'query = "SELECT 'no' AS is_check,fcs.id_prod_fc_sum,'22' AS report_mark_type,fc.`id_prod_fc`,fc.`prod_fc_number`,po.`id_prod_order`,dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.*,
            '                    SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
            '                    get_claim_reject_percent(ko.`id_claim_reject`,1) AS p_normal,
            '                    SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
            '                    get_claim_reject_percent(ko.`id_claim_reject`,2) AS p_normal_minor,
            '                    SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
            '                    get_claim_reject_percent(ko.`id_claim_reject`,3) AS p_minor,
            '                    SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
            '                    get_claim_reject_percent(ko.`id_claim_reject`,4) AS p_minor_major,
            '                    SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
            '                    get_claim_reject_percent(ko.`id_claim_reject`,5) AS p_major,
            '                    SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
            '                    get_claim_reject_percent(ko.`id_claim_reject`,6) AS p_afkir,
            '                    wo_price.prod_order_wo_det_price AS unit_price,
            '                    ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_minor,
            '                    ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_major,
            '                    ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price,2) AS amo_claim_afkir
            '                    -- ROUND((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,2)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,3)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_minor,
            '                    -- ROUND((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,4)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price)+ROUND((SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,5)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_major,
            '                    -- ROUND((SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(IF((get_claim_reject_percent(ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0)))<0,0,(get_claim_reject_percent(ko.`id_claim_reject`,6)-(IFNULL(recfc.claim_percent,0))))/100))*wo_price.prod_order_wo_det_price) AS amo_claim_afkir
            '                    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,3)/100)))) AS amo_claim_minor,
            '                    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,5)/100)))) AS amo_claim_major,
            '                    -- ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,6)/100))) AS amo_claim_afkir
            '                    ,IFNULL(recfc.qty_rec,rec.qty_rec) AS qty_rec,wo_price.qty_order AS qty_order
            '                    ,wo_price.comp_name
            '                    ,dsg.design_display_name
            '                    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS prod_order_wo_det_price -- real price rec
            '                    ,recfc.prod_order_rec_number,IFNULL(recfc.claim_percent,0) AS rec_discount
            '                    ,IFNULL(pl_rec.pl_category,'Normal') AS rec_pl_category
            '                    ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS rec_amount_disc
            '                    ,fc.id_prod_fc AS id_reff,fcs.number AS sum_number
            '                    ,wo_price.id_currency,wo_price.currency,wo_price.prod_order_wo_kurs
            '                    FROM tb_prod_fc_sum_det fcsd
            '                    INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=fcsd.`id_prod_fc_sum` AND fcs.`id_report_status`='6'
            '                    INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcsd.`id_prod_fc` 
            '                    LEFT JOIN (
            '                        SELECT rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,rec.claim_percent,rec.prod_order_rec_number,rec.id_pl_category
            '                        FROM tb_prod_order_rec_det recd
            '                        INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
            '                        GROUP BY rec.`id_prod_order_rec`
            '                    ) recfc ON recfc.`id_prod_order_rec`=fc.`id_prod_order_rec`
            '                    LEFT JOIN tb_lookup_pl_category pl_rec ON pl_rec.`id_pl_category`=recfc.`id_pl_category`
            '                    INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
            '                    INNER JOIN tb_prod_order po ON po.`id_prod_order`=fc.`id_prod_order` AND po.is_claimed_reject=2
            '                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            '                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            '                    INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
            '                    LEFT JOIN (
            '                        SELECT ko.`id_prod_order`,ko.`id_claim_reject` 
            '                        FROM (
            '                         (SELECT kod.`id_prod_order`,ko.`id_claim_reject` FROM tb_prod_order_ko_det kod
            '                         INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_void='2'AND is_locked='1'
            '                         ORDER BY kod.id_prod_order_ko_det DESC)
            '                         UNION ALL
            '                         (SELECT po.id_prod_order,3 AS id_claim_reject
            '                         FROM tb_prod_order po WHERE po.id_po_type=2 AND po.id_report_status=6)
            '                            UNION ALL
            '                         (SELECT po.id_prod_order,3 AS id_claim_reject
            '                      FROM tb_prod_order po 
            '                      INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.`id_prod_order` AND wo.`is_main_vendor`=1
            '                      INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
            '                      INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
            '                      INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            '                      INNER JOIN tb_m_city ct ON ct.`id_city`=comp.`id_city`
            '                      INNER JOIN tb_m_state st ON st.`id_state`=ct.`id_state`
            '                      INNER JOIN tb_m_region reg ON reg.`id_region`=st.`id_region`
            '                      INNER JOIN tb_m_country co ON co.`id_country`=reg.`id_country` AND co.`id_country`!=5
            '                      WHERE po.id_po_type=3 AND po.id_report_status=6)
            '                        )ko GROUP BY ko.id_prod_order
            '                    ) ko ON ko.id_prod_order=po.id_prod_order 
            '                    INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=ko.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
            '                    LEFT JOIN (
            '                     SELECT comp.id_comp, comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price, cur.id_currency, cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, IFNULL(wo_old.old_kurs,wo.`prod_order_wo_kurs`) AS prod_order_wo_kurs, SUM(pod.prod_order_qty) AS qty_order
            '                     FROM tb_prod_order_wo wo
            '                     INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
            '                     INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
            '                     INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
            '                     LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
            '                     LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
            '                     LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            '                        LEFT JOIN
            '                     (
            '                      SELECT id_wo,old_kurs FROM `tb_prod_order_wo_log`
            '                      WHERE id_wo_log IN (
            '                       SELECT MIN(id_wo_log)
            '                       FROM tb_prod_order_wo_log logx
            '                       INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=logx.id_wo 
            '                       GROUP BY wo.`id_prod_order_wo`
            '                      )
            '                     )wo_old ON wo_old.id_wo=wo.id_prod_order_wo
            '                     WHERE wo.is_main_vendor=1 
            '                     GROUP BY wo.id_prod_order_wo
            '                    ) wo_price ON wo_price.id_prod_order=po.id_prod_order
            '                    LEFT JOIN (
            '                     SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
            '                     FROM tb_prod_order_rec rec
            '                     INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
            '                     GROUP BY rec.id_prod_order
            '                    ) rec ON rec.`id_prod_order`=fc.`id_prod_order`
            '                    LEFT JOIN (
            '                        SELECT id_reff FROM tb_debit_note_det dnd
            '                        INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=22 AND dn.`id_report_status`!=5
            '                        GROUP BY dnd.id_reff
            '                    ) dn ON dn.id_reff=fc.id_prod_fc
            '                    WHERE fc.id_report_status = '6' AND ISNULL(dn.id_reff) " & q_where & "
            '                    GROUP BY fc.`id_prod_fc`
            '                    HAVING (amo_claim_minor + amo_claim_major + amo_claim_afkir) >= 0"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSumClaimReject.DataSource = data
            GVSumClaimReject.BestFitColumns()
            If SLEVendor.EditValue.ToString = "0" Then
                PCDebitNote.Visible = False
            Else
                PCDebitNote.Visible = True
            End If
        End If
    End Sub

    Private Sub BCreateDNReject_Click(sender As Object, e As EventArgs) Handles BCreateDNReject.Click
        Cursor = Cursors.WaitCursor
        GVSumClaimReject.ActiveFilterString = "[is_check] = 'yes'"
        If GVSumClaimReject.RowCount > 0 Then
            'check if USD
            Dim is_usd As Boolean = False
            For i As Integer = 0 To GVSumClaimReject.RowCount - 1
                If Not GVSumClaimReject.GetRowCellValue(i, "id_currency").ToString = "1" Then
                    is_usd = True
                    Exit For
                End If
            Next

            If is_usd Then
                FormDebitNoteDet.id_dn_type = "4"
            Else
                FormDebitNoteDet.id_dn_type = "1"
            End If
            FormDebitNoteDet.ShowDialog()
        Else
            warningCustom("Please select FGPO")
        End If
        GVSumClaimReject.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreateDNLate_Click(sender As Object, e As EventArgs) Handles BCreateDNLate.Click
        Cursor = Cursors.WaitCursor
        GVClaimLate.ActiveFilterString = "[is_check] = 'yes'"
        If GVClaimLate.RowCount > 0 Then
            FormDebitNoteDet.id_dn_type = "2"
            FormDebitNoteDet.ShowDialog()
        Else
            warningCustom("Make sure FGPO selected and ready to claim")
        End If
        GVClaimLate.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDebitNote_DoubleClick(sender As Object, e As EventArgs) Handles GVDebitNote.DoubleClick
        If GVDebitNote.RowCount > 0 Then
            FormDebitNoteDet.id_dn = GVDebitNote.GetFocusedRowCellValue("id_debit_note").ToString
            FormDebitNoteDet.ShowDialog()
        End If
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVSumClaimReject.RowCount > 0 Then
            Dim cek As String = CESelectAll.EditValue.ToString
            For i As Integer = 0 To ((GVSumClaimReject.RowCount - 1) - GetGroupRowCount(GVSumClaimReject))
                If cek Then
                    GVSumClaimReject.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVSumClaimReject.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub ViewQCSummaryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewQCSummaryReportToolStripMenuItem.Click
        Dim qcp As New ClassShowPopUp
        qcp.id_report = GVSumClaimReject.GetFocusedRowCellValue("id_prod_fc_sum").ToString
        qcp.report_mark_type = "222"
        qcp.show()
    End Sub

    Private Sub GVClaimLate_DoubleClick(sender As Object, e As EventArgs) Handles GVClaimLate.DoubleClick
        If GVClaimLate.RowCount > 0 Then
            Dim c As ClassShowPopUp = New ClassShowPopUp
            c.id_report = GVClaimLate.GetFocusedRowCellValue("id_prod_order_rec").ToString
            c.report_mark_type = GVClaimLate.GetFocusedRowCellValue("rmt").ToString
            c.show()
        End If
    End Sub
End Class