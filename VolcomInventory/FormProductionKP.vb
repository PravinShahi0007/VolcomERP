Public Class FormProductionKP
    Public id_kp As String = "-1"
    Public is_locked As String = "2"
    Public is_purc_mat As String = "2"

    Private Sub FormProductionkp_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionkp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        action_load()
    End Sub
    '
    Sub action_load()
        load_revision()

        load_head()
    End Sub

    Sub load_revision()
        Dim query As String = "SELECT id_prod_order_kp,LPAD(revision,2,'0') as revision,id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp_reff=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1) ORDER BY id_prod_order_kp DESC"
        viewSearchLookupQuery(SLERevision, query, "id_prod_order_kp", "revision", "id_prod_order_kp")
    End Sub

    Sub load_head()
        'view yang revisi terakhir
        Dim query As String = "SELECT kp.is_locked,kp.is_purc_mat,c.phone,c.fax,kp.number,cc.`contact_person`,c.`comp_number`,c.`comp_name`,c.`address_primary`,kp.`date_created`,LPAD(kp.`revision`,2,'0') AS revision
FROM tb_prod_order_kp kp
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=kp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE id_prod_order_kp='" & id_kp & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_purc_mat = data.Rows(0)("is_purc_mat").ToString
            '
            TEkpNumber.Text = data.Rows(0)("number").ToString
            TECompCode.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
            MECompAddress.Text = data.Rows(0)("address_primary").ToString
            TECompAttn.Text = data.Rows(0)("contact_person").ToString
            '
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            '
            TETelp.EditValue = data.Rows(0)("phone")
            TEFax.EditValue = data.Rows(0)("fax")

            is_locked = data.Rows(0)("is_locked").ToString
            'load_det
            load_det()
            '
        End If

        If is_locked = "1" Then
            'locked
            BLock.Visible = False
            BUpdate.Visible = False
            BRevise.Visible = True
            PCDel.Visible = False
        Else
            BLock.Visible = True
            BUpdate.Visible = True
            BRevise.Visible = False
            PCDel.Visible = True
        End If
        'prevent edit lead time
        If SLERevision.Text = "00" Or is_locked = "1" Then
            GridColumnLeadTime.OptionsColumn.ReadOnly = True
        Else
            GridColumnLeadTime.OptionsColumn.ReadOnly = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = ""

        If is_purc_mat = "1" Then
            query = "SELECT kpd.sample_proto_2,kpd.revision,kpd.id_prod_order_kp_det,'' AS `no`,po.`mat_purc_number` AS prod_order_number,md.mat_det_display_name AS class_dsg,cd.`display_name` AS color
,SUM(pod.mat_purc_det_qty) AS qty_order,pod.mat_purc_det_price AS bom_unit,SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty) AS po_amount_rp
,kpd.lead_time_prod AS lead_time,po.mat_purc_date AS prod_order_wo_del_date,DATE_ADD(po.mat_purc_date,INTERVAL kpd.lead_time_prod DAY) AS esti_del_date
,IFNULL(revtimes.revision_times,0) AS revision_times
FROM `tb_prod_order_kp_det` kpd
INNER JOIN tb_mat_purc po ON po.id_mat_purc=kpd.id_purc_order
INNER JOIN  tb_mat_purc_det pod ON po.id_mat_purc=pod.id_mat_purc
INNER JOIN tb_m_mat_det_price mdp ON mdp.`id_mat_det_price`=pod.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=mdp.`id_mat_det`
INNER JOIN `tb_m_mat_det_code` mdc ON mdc.id_mat_det = md.id_mat_det
INNER JOIN `tb_m_code_detail` cd ON cd.id_code_detail=mdc.id_code_detail AND cd.id_code='1'
LEFT JOIN(
    SELECT revtimes.id_purc_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kpd.id_purc_order,kpd.revision FROM tb_prod_order_kp_det kpd
	    INNER JOIN tb_prod_order_kp kp ON kp.`id_prod_order_kp`=kpd.`id_prod_order_kp`
	    WHERE kpd.revision!=0 AND kpd.id_prod_order_kp<='" & id_kp & "' AND kp.`id_prod_order_kp_reff`=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1)
	    GROUP BY kpd.id_purc_order,kpd.revision
    ) revtimes GROUP BY revtimes.id_purc_order
)revtimes ON revtimes.id_purc_order=po.id_mat_purc
WHERE kpd.id_prod_order_kp='" & id_kp & "'
GROUP BY po.id_mat_purc
ORDER BY po.`id_mat_purc` ASC"
        Else
            query = "SELECT kpd.sample_proto_2,kpd.revision,kpd.id_prod_order_kp_det,'' AS `no`,po.`prod_order_number`,LEFT(dsg.design_display_name,LENGTH(dsg.design_display_name)-3) AS class_dsg,RIGHT(dsg.design_display_name,3) AS color
,wo_price.qty_po AS qty_order,wo_price.prod_order_wo_det_price AS bom_unit,wo_price.price_amount AS po_amount_rp
,kpd.lead_time_prod AS lead_time,wo_price.prod_order_wo_del_date,DATE_ADD(wo_price.prod_order_wo_del_date,INTERVAL kpd.lead_time_prod DAY) AS esti_del_date
,IFNULL(revtimes.revision_times,0) AS revision_times
FROM `tb_prod_order_kp_det` kpd
INNER JOIN tb_prod_order po ON po.id_prod_order=kpd.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON po.`id_prod_demand_design`=pdd.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN (
	SELECT wo.id_prod_order, wo.id_ovh_price, wo.prod_order_wo_kurs, cur.currency,wo.prod_order_wo_vat,wod.prod_order_wo_det_price
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs * (100 + wo.prod_order_wo_vat)/100) AS `wo_price`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * (100 + wo.prod_order_wo_vat)/100) AS `wo_price_no_kurs`
	,(SUM(wod.prod_order_wo_det_price * pod.prod_order_qty) * wo.prod_order_wo_kurs) AS `price_amount`
	,SUM(pod.prod_order_qty) AS qty_po
    ,wo.prod_order_wo_del_date,wo.prod_order_wo_lead_time
	FROM tb_prod_order_wo wo
	INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.is_main_vendor=1 
	GROUP BY wo.id_prod_order_wo
) wo_price ON wo_price.id_prod_order= po.id_prod_order
LEFT JOIN(
    SELECT revtimes.id_prod_order,COUNT(DISTINCT revtimes.revision) AS revision_times FROM
    (
	    SELECT kpd.id_prod_order,kpd.revision FROM tb_prod_order_kp_det kpd
	    INNER JOIN tb_prod_order_kp kp ON kp.`id_prod_order_kp`=kpd.`id_prod_order_kp`
	    WHERE kpd.revision!=0 AND kpd.id_prod_order_kp<='3' AND kp.`id_prod_order_kp_reff`=(SELECT id_prod_order_kp_reff FROM tb_prod_order_kp WHERE id_prod_order_kp='" & id_kp & "' LIMIT 1)
	    GROUP BY kpd.id_prod_order,kpd.revision
    ) revtimes GROUP BY revtimes.id_prod_order
)revtimes ON revtimes.id_prod_order=po.id_prod_order
WHERE kpd.id_prod_order_kp='" & id_kp & "'
ORDER BY po.`id_prod_order` ASC"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "'")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub
End Class