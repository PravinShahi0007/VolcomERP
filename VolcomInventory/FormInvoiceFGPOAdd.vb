Public Class FormInvoiceFGPOAdd
    Public is_dp As Boolean = False

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPOAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        'check sudah ada atau belum
        Dim sudah As Boolean = False
        For i = 0 To FormInvoiceFGPODP.GVList.RowCount - 1
            If FormInvoiceFGPODP.GVList.GetRowCellValue(i, "id_report").ToString = SLEReport.EditValue.ToString And FormInvoiceFGPODP.GVList.GetRowCellValue(i, "report_mark_type").ToString = SLEReportType.EditValue.ToString Then
                sudah = True
                Exit For
            End If
        Next

        If sudah Then
            warningCustom("Dokumen ini sudah dipilih pada form")
        Else
            'Try
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            '
            If SLEReportType.EditValue.ToString = "22" Then
                newRow("id_prod_order") = SLEReport.EditValue.ToString
            Else
                newRow("id_prod_order") = SLEReport.Properties.View.GetFocusedRowCellValue("id_prod_order").ToString
            End If
            newRow("id_report") = SLEReport.EditValue.ToString

            newRow("report_mark_type") = SLEReportType.EditValue.ToString
            newRow("report_number") = SLEReport.Text
            newRow("info_design") = TEInfoDesign.Text
            '
            newRow("qty") = TEQty.EditValue
            newRow("id_currency") = LECurrency.EditValue.ToString
            newRow("kurs") = Decimal.Parse(TEKurs.EditValue.ToString)
            newRow("value_bef_kurs") = TEBeforeKurs.EditValue
            '
            newRow("pph_percent") = 0
            newRow("vat") = TEVat.EditValue
            newRow("inv_number") = ""
            newRow("note") = ""

            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormInvoiceFGPODP.calculate()
            'Catch ex As Exception
            '    MsgBox(ex.ToString)
            'End Try

            Close()
        End If
    End Sub

    Sub load_kurs()
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Get kurs error.")
            TEKurs.EditValue = 0.00
        Else
            If LECurrency.EditValue.ToString = "2" Then
                TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
            Else
                TEKurs.EditValue = 1
            End If
        End If
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable_bpl='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub FormInvoiceFGPOAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVATPercent.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEQty.EditValue = 1
        '
        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            TEKurs.EditValue = FormInvoiceFGPODP.GVList.GetRowCellValue(0, "kurs")
        Else
            TEKurs.EditValue = 0.00
        End If

        TEBeforeKurs.EditValue = 0.00
        TEAfterKurs.EditValue = 0.00

        load_report_type()

        view_currency()
        view_po()

        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormInvoiceFGPODP.GVList.GetRowCellValue(0, "id_currency").ToString)
        End If
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Sub view_po()
        Dim query As String = ""

        If SLEReportType.EditValue.ToString = "22" Then 'fgpo
            query = "SELECT po.`id_prod_order` AS id_report,po.`prod_order_number` AS report_number,dsg.`design_display_name` AS description,dsg.`design_code` AS info
FROM tb_prod_order po 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        ElseIf SLEReportType.EditValue.ToString = "13" Then 'material dibulatkan ke atas (Alit 11 Januari 2021)
            If is_dp Then
                query = "SELECT po.`id_mat_purc` AS id_report,0 AS id_prod_order,po.`mat_purc_number` AS report_number
,CONCAT('DP PO nomor ',po.`mat_purc_number`,',Total item=',COUNT(pod.id_mat_det_price),',Qty=',IFNULL(SUM(pod.mat_purc_det_qty),0)) AS description
,c.comp_name AS info
,po.id_currency,po.mat_purc_kurs AS kurs,po.mat_purc_vat AS vat,CEIL((py.dp_amount/100)*SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty)*100)/100 AS po_val,SUM(pod.mat_purc_det_qty) AS qty, (py.dp_amount/100) AS dp_percent
FROM tb_mat_purc_det pod 
INNER JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det_price=pod.id_mat_det_price
INNER JOIN tb_m_mat_det md ON md.id_mat_det=mdp.id_mat_det
INNER JOIN tb_mat_purc po ON pod.id_mat_purc=po.id_mat_purc 
INNER JOIN tb_lookup_payment py ON py.id_payment=po.id_payment
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp AND c.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=13 AND pn.type=1
)pn ON pn.id_report=po.id_mat_purc
WHERE po.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo) AND py.dp_amount>0
GROUP BY pod.id_mat_purc"
                '--,GROUP_CONCAT(TRIM(md.mat_det_name) SEPARATOR '\n') AS description
            Else
                '                query = "SELECT po.`id_mat_purc` AS id_report,0 AS id_prod_order,po.`mat_purc_number` AS report_number,GROUP_CONCAT(TRIM(md.mat_det_name) SEPARATOR '\n') AS description,c.comp_name AS info
                ',po.id_currency,po.mat_purc_kurs AS kurs,po.mat_purc_vat AS vat,CEIL(SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty)*100)/100 AS po_val,SUM(pod.mat_purc_det_qty) AS qty
                'FROM tb_mat_purc_det pod 
                'INNER JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det_price=pod.id_mat_det_price
                'INNER JOIN tb_m_mat_det md ON md.id_mat_det=mdp.id_mat_det
                'INNER JOIN tb_mat_purc po ON pod.id_mat_purc=po.id_mat_purc 
                'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact_to
                'INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp AND c.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
                'LEFT JOIN 
                '(
                '    SELECT pn.id_pn_fgpo,pnd.id_report
                '    FROM `tb_pn_fgpo_det` pnd 
                '    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
                '    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=13 AND pn.type=2
                ')pn ON pn.id_report=po.id_mat_purc
                'WHERE po.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo)
                'GROUP BY pod.id_mat_purc"
                query = "SELECT po.`id_mat_purc` AS id_report,0 AS id_prod_order,po.`mat_purc_number` AS report_number
,CONCAT('Pelunasan PO nomor ',po.`mat_purc_number`,',Total item=',COUNT(pod.id_mat_det_price),',Qty=',IFNULL(SUM(rec.qty_rec_no_foc),0)) AS description
,c.comp_name AS info
,po.id_currency,po.mat_purc_kurs AS kurs,po.mat_purc_vat AS vat,CEIL(SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty)*100)/100 AS po_val,SUM(pod.mat_purc_det_qty) AS qty
,SUM(rec.qty_rec) AS qty_rec,SUM(rec.qty_rec_no_foc) AS qty_rec_no_foc,CEIL(SUM(pod.mat_purc_det_price*rec.qty_rec_no_foc)*100)/100 AS rec_val
FROM tb_mat_purc_det pod 
INNER JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det_price=pod.id_mat_det_price
INNER JOIN tb_m_mat_det md ON md.id_mat_det=mdp.id_mat_det
INNER JOIN tb_mat_purc po ON pod.id_mat_purc=po.id_mat_purc 
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp AND c.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=13 AND pn.type=2
)pn ON pn.id_report=po.id_mat_purc
LEFT JOIN
(
	SELECT id_mat_purc_det,SUM(rd.mat_purc_rec_det_qty) AS qty_rec,SUM(IF(r.is_foc=1,0,rd.mat_purc_rec_det_qty)) AS qty_rec_no_foc
	FROM tb_mat_purc_rec_det rd
	INNER JOIN tb_mat_purc_rec r ON r.id_mat_purc_rec=rd.id_mat_purc_rec AND r.id_report_status=6
	GROUP BY rd.id_mat_purc_det
)rec ON rec.id_mat_purc_det=pod.id_mat_purc_det
WHERE po.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo)
GROUP BY pod.id_mat_purc
HAVING qty_rec >= qty"
                ',GROUP_CONCAT(TRIM(md.mat_det_name) SEPARATOR '\n') AS description
            End If
        ElseIf SLEReportType.EditValue.ToString = "23" Then 'FG WO
            '            query = "SELECT wo.`id_prod_order_wo` AS id_report,wo.`id_prod_order_wo` AS id_prod_order,wo.`prod_order_wo_number` AS report_number,CONCAT(ovh.`overhead`,' - ',dsg.`design_display_name`) AS description,dsg.`design_code` AS info
            ',wo.id_currency,wo.prod_order_wo_kurs AS kurs,wo.prod_order_wo_vat AS vat,SUM(wod.prod_order_wo_det_price*wod.prod_order_wo_det_qty) AS wo_val,SUM(wod.prod_order_wo_det_qty) AS qty
            'FROM tb_prod_order_wo_det wod 
            'INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo_det`
            'INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
            'INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh`
            'INNER JOIN tb_prod_order po ON po.`id_prod_order`=wo.id_prod_Order
            'INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
            'INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
            'WHERE po.`id_report_status`='6'
            'GROUP BY wo.`id_prod_order_wo`"
            If is_dp Then
                query = "SELECT wo.`id_prod_order_wo` AS id_report,wo.`id_prod_order_wo` AS id_prod_order,wo.`prod_order_wo_number` AS report_number,CONCAT(ovh.`overhead`,' - ',dsg.`design_display_name`) AS description,dsg.`design_code` AS info
,IFNULL(oldest_price.old_curr,wo.`id_currency`) AS id_currency,IFNULL(oldest_price.old_kurs,wo.prod_order_wo_kurs) AS kurs,wo.prod_order_wo_vat AS vat
,IF(wo.is_manual_add=1,(ret.qty_ret*IFNULL(oldest_price.old_price,wod.`prod_order_wo_det_price`)),SUM(IFNULL(oldest_price.old_price,wod.`prod_order_wo_det_price`)*wod.prod_order_wo_det_qty)) AS wo_val
,IF(wo.is_manual_add=1,ret.qty_ret,SUM(wod.prod_order_wo_det_qty)) AS qty
FROM tb_prod_order_wo_det wod 
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo` AND wo.is_main_vendor=2
INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh`  AND (wo.is_manual_add=1 OR ovh.id_ovh=13)
INNER JOIN tb_prod_order po ON po.`id_prod_order`=wo.id_prod_Order
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN
(
	SELECT id_wo,old_kurs,old_price,old_curr FROM `tb_prod_order_wo_log`
	WHERE id_wo_log IN (
		SELECT MIN(id_wo_log)
		FROM tb_prod_order_wo_log logx
		INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=logx.id_wo 
		GROUP BY wo.`id_prod_order_wo`
	)
)oldest_price ON oldest_price.id_wo=wo.`id_prod_order_wo`
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=23 AND pn.type=1
    GROUP BY pnd.report_mark_type=23 AND pnd.id_report
)pn ON pn.id_report=wo.id_prod_order_wo
LEFT JOIN
(
    SELECT reto.id_prod_order_wo,SUM(retd.prod_order_ret_in_det_qty) AS qty_ret
    FROM tb_prod_order_ret_in_det retd
    INNER JOIN tb_prod_order_ret_in ret ON ret.id_prod_order_ret_in=retd.id_prod_order_ret_in AND ret.id_report_status=6
    INNER JOIN tb_prod_order_ret_out reto ON reto.id_prod_order_ret_out=ret.id_prod_order_ret_out
    WHERE NOT ISNULL(reto.id_prod_order_wo)
    GROUP BY reto.id_prod_order_wo
)ret ON ret.id_prod_order_wo=wo.id_prod_order_wo
WHERE po.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo) 
GROUP BY wo.`id_prod_order_wo`"
            Else
                query = "SELECT wo.`id_prod_order_wo` AS id_report,wo.`id_prod_order_wo` AS id_prod_order,wo.`prod_order_wo_number` AS report_number,CONCAT(ovh.`overhead`,' - ',dsg.`design_display_name`) AS description,dsg.`design_code` AS info
,IFNULL(oldest_price.old_curr,wo.`id_currency`) AS id_currency,IFNULL(oldest_price.old_kurs,wo.prod_order_wo_kurs) AS kurs,wo.prod_order_wo_vat AS vat
,IF(wo.is_manual_add=1,(ret.qty_ret*IFNULL(oldest_price.old_price,wod.`prod_order_wo_det_price`)),SUM(IFNULL(oldest_price.old_price,wod.`prod_order_wo_det_price`)*wod.prod_order_wo_det_qty)) AS wo_val
,IF(wo.is_manual_add=1,ret.qty_ret,SUM(wod.prod_order_wo_det_qty)) AS qty
FROM tb_prod_order_wo_det wod 
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo` AND wo.is_main_vendor=2 
INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh` AND (wo.is_manual_add=1 OR ovh.id_ovh=13)
INNER JOIN tb_prod_order po ON po.`id_prod_order`=wo.id_prod_Order
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN
(
	SELECT id_wo,old_kurs,old_price,old_curr FROM `tb_prod_order_wo_log`
	WHERE id_wo_log IN (
		SELECT MIN(id_wo_log)
		FROM tb_prod_order_wo_log logx
		INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=logx.id_wo 
		GROUP BY wo.`id_prod_order_wo`
	)
)oldest_price ON oldest_price.id_wo=wo.`id_prod_order_wo`
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=23 AND pn.type=2
    GROUP BY pnd.report_mark_type=23 AND pnd.id_report
)pn ON pn.id_report=wo.id_prod_order_wo
LEFT JOIN
(
    SELECT reto.id_prod_order_wo,SUM(retd.prod_order_ret_in_det_qty) AS qty_ret
    FROM tb_prod_order_ret_in_det retd
    INNER JOIN tb_prod_order_ret_in ret ON ret.id_prod_order_ret_in=retd.id_prod_order_ret_in AND ret.id_report_status=6
    INNER JOIN tb_prod_order_ret_out reto ON reto.id_prod_order_ret_out=ret.id_prod_order_ret_out
    WHERE NOT ISNULL(reto.id_prod_order_wo)
    GROUP BY reto.id_prod_order_wo
)ret ON ret.id_prod_order_wo=wo.id_prod_order_wo
WHERE po.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo) 
GROUP BY wo.`id_prod_order_wo`"
            End If
        ElseIf SLEReportType.EditValue.ToString = "1" Then 'purchase sample
            If is_dp Then
                query = "SELECT sp.`id_sample_purc` AS id_report,0 AS id_prod_order,sp.`sample_purc_number` AS report_number,'Purchase Sample' AS description,c.comp_name AS info
,sp.id_currency,sp.sample_purc_kurs AS kurs,sp.sample_purc_vat AS vat,SUM(spd.sample_purc_det_price*spd.sample_purc_det_qty) AS po_val,SUM(spd.sample_purc_det_qty) AS po_qty,(py.`dp_amount`/100)*SUM(spd.sample_purc_det_price*spd.sample_purc_det_qty) AS amount_rec,SUM(spd.sample_purc_det_qty) AS qty_rec
FROM `tb_sample_purc` sp
INNER JOIN tb_sample_purc_det spd ON spd.`id_sample_purc`=sp.`id_sample_purc`
INNER JOIN tb_lookup_payment py ON py.id_payment=sp.id_payment AND py.`dp_amount`>0
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=sp.`id_comp_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` AND c.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report,SUM(pnd.value_bef_kurs) AS dp_amount
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=1 AND pn.type=1
    GROUP BY pnd.id_report,pnd.report_mark_type
)pn ON pn.id_report=sp.id_sample_purc
WHERE sp.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo)
GROUP BY sp.`id_sample_purc`"
            Else
                query = "SELECT sp.`id_sample_purc` AS id_report,0 AS id_prod_order,sp.`sample_purc_number` AS report_number,'Purchase Sample' AS description,c.comp_name AS info
,sp.id_currency,sp.sample_purc_kurs AS kurs,sp.sample_purc_vat AS vat,SUM(spd.sample_purc_det_price*spd.sample_purc_det_qty) AS po_val,SUM(spd.sample_purc_det_qty) AS po_qty,IFNULL(rec.amount_rec,0) AS amount_rec,IFNULL(rec.qty_rec,0) AS qty_rec
,IFNULL(SUM(cls.qty_close),0) AS qty_close
FROM `tb_sample_purc` sp
INNER JOIN tb_sample_purc_det spd ON spd.`id_sample_purc`=sp.`id_sample_purc`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=sp.`id_comp_contact_to`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` AND c.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
LEFT JOIN (
	SELECT pod.id_sample_purc,pod.`id_sample_purc_det`,SUM(recd.sample_purc_rec_det_qty*recd.fob_price_update) AS amount_rec,SUM(recd.sample_purc_rec_det_qty) AS qty_rec
    FROM `tb_sample_purc_rec_det` recd
    INNER JOIN tb_sample_purc_det pod ON pod.id_sample_purc_det=recd.id_sample_purc_det
    INNER JOIN tb_sample_purc_rec rec ON rec.id_sample_purc_rec=recd.id_sample_purc_rec AND rec.id_report_status=6
    GROUP BY pod.id_sample_purc
)rec ON rec.id_sample_purc=sp.`id_sample_purc`
LEFT JOIN (
    SELECT pod.id_sample_purc_det,SUM(recd.qty) AS qty_close
    FROM `tb_sample_purc_close_det` recd
    INNER JOIN tb_sample_purc_det pod ON pod.id_sample_purc_det=recd.id_sample_purc_det
    INNER JOIN `tb_sample_purc_close` rec ON rec.id_sample_purc_close=recd.id_sample_purc_close 
    AND rec.id_report_status=6
    GROUP BY pod.id_sample_purc_det
)cls ON cls.id_sample_purc_det=spd.`id_sample_purc_det`
LEFT JOIN 
(
    SELECT pn.id_pn_fgpo,pnd.id_report
    FROM `tb_pn_fgpo_det` pnd 
    INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
    WHERE pn.id_report_status!=5 AND pnd.report_mark_type=1 AND pn.type=2
)pn ON pn.id_report=sp.id_sample_purc
WHERE sp.`id_report_status`='6' AND ISNULL(pn.id_pn_fgpo) 
GROUP BY sp.`id_sample_purc`
HAVING (qty_rec+qty_close>=po_qty)"
            End If
        End If

        viewSearchLookupQuery(SLEReport, query, "id_report", "report_number", "id_report")
        Try
            SLEReport.EditValue = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SLEFGPO_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReport.EditValueChanged
        Try
            If SLEReportType.EditValue.ToString = "13" Then
                If is_dp Then
                    Dim aft_kurs As Decimal = 0.00

                    LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                    TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("po_val")
                    TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                    TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty")
                    TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                    aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                    TEAfterKurs.EditValue = aft_kurs
                    disable_input()
                Else
                    Dim aft_kurs As Decimal = 0.00

                    LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                    TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("rec_val")
                    TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                    TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty_rec_no_foc")
                    TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                    aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                    TEAfterKurs.EditValue = aft_kurs
                    disable_input()
                End If
            ElseIf SLEReportType.EditValue.ToString = "23" Then
                Dim aft_kurs As Decimal = 0.00

                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("wo_val")
                TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty")
                TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                TEAfterKurs.EditValue = aft_kurs
                disable_input()
            ElseIf SLEReportType.EditValue.ToString = "1" Then 'sample
                If is_dp Then
                    Dim aft_kurs As Decimal = 0.00

                    LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                    TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("amount_rec")
                    TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                    TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty_rec")
                    TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                    aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                    TEAfterKurs.EditValue = aft_kurs
                    disable_input()
                Else
                    Dim aft_kurs As Decimal = 0.00

                    LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                    TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("amount_rec")
                    TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                    TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty_rec")
                    TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                    aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                    TEAfterKurs.EditValue = aft_kurs
                    disable_input()
                End If
            Else
                enable_input()
            End If


        Catch ex As Exception
        End Try
        '
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Sub disable_input()
        TEInfoDesign.ReadOnly = True
        LECurrency.ReadOnly = True
        TEBeforeKurs.ReadOnly = True
        TEKurs.ReadOnly = True
        TEVATPercent.ReadOnly = True
        TEVat.ReadOnly = True
        TEQty.ReadOnly = True
    End Sub

    Sub enable_input()
        TEInfoDesign.ReadOnly = False
        LECurrency.ReadOnly = False
        TEBeforeKurs.ReadOnly = False
        TEKurs.ReadOnly = False
        TEVATPercent.ReadOnly = False
        TEVat.ReadOnly = False
        TEQty.ReadOnly = False
    End Sub

    Sub calculate_fgpo(ByVal is_vatp As Boolean)
        Dim bef_kurs As Decimal = 0.00
        Dim aft_kurs As Decimal = 0.00
        Dim kurs As Decimal = 0.00
        '
        Dim vat_perc As Decimal = 0.00
        Dim vat As Decimal = 0.00
        '
        Try
            TEInfoDesign.Text = SLEReport.Properties.View.GetFocusedRowCellValue("description").ToString

            bef_kurs = TEBeforeKurs.EditValue
            kurs = TEKurs.EditValue
            aft_kurs = bef_kurs * kurs
            TEAfterKurs.EditValue = aft_kurs
            '
            If is_vatp Then
                vat_perc = TEVATPercent.EditValue
                vat = aft_kurs * (vat_perc / 100)
                TEVat.EditValue = vat
                TEAfterVAT.EditValue = aft_kurs + vat
            Else
                vat = TEVat.EditValue
                TEAfterVAT.EditValue = aft_kurs + vat
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub TEVATPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVATPercent.EditValueChanged
        calculate_fgpo(True)
    End Sub

    Private Sub TEVat_EditValueChanged(sender As Object, e As EventArgs) Handles TEVat.EditValueChanged
        calculate_fgpo(False)
    End Sub

    Private Sub TEBeforeKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEBeforeKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    'Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
    '    load_kurs()
    'End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Private Sub SLEReportType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReportType.EditValueChanged
        view_po()
    End Sub
End Class