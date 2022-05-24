Public Class FormAPReport
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormARAging_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
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

    Private Sub FormARAging_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAPReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_comp()
        load_status_payment()
    End Sub

    Sub load_status_payment()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT 0 AS id_status_payment,'All' AS status_payment
        UNION
        SELECT 1 AS id_status_payment,'Open' AS status_payment
        UNION
        SELECT 2 AS id_status_payment,'Close' AS status_payment "
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
        Cursor = Cursors.Default
    End Sub

    Sub load_comp()
        Cursor = Cursors.WaitCursor

        Dim query As String = "SELECT 0 AS id_comp,'All' as comp_name
        UNION
        SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c"

        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAPReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        Cursor = Cursors.WaitCursor
        'cond vendor
        Dim cond_vendor As String = ""
        If SLEStoreInvoice.EditValue.ToString <> "0" Then
            cond_vendor = "AND c.id_comp=" + SLEStoreInvoice.EditValue.ToString + " "
        End If
        'cond status
        Dim cond As String = ""
        If SLEStatusInvoice.EditValue.ToString = "1" Then 'All open
            cond = " AND p.is_open='1'"
            gridBandAgingAR.Visible = True
            gridBandPaid.Visible = False
            GridBandInvoice.VisibleIndex = 0
            gridBandAgingAR.VisibleIndex = 1
            gridBandStatus.VisibleIndex = 2
        ElseIf SLEStatusInvoice.EditValue.ToString = "2" Then 'closed
            cond = " AND p.is_open='2'"
            gridBandAgingAR.Visible = False
            gridBandPaid.Visible = True
            GridBandInvoice.VisibleIndex = 0
            gridBandPaid.VisibleIndex = 1
            gridBandStatus.VisibleIndex = 2
        Else 'all
            gridBandAgingAR.Visible = True
            gridBandPaid.Visible = True
            GridBandInvoice.VisibleIndex = 0
            gridBandAgingAR.VisibleIndex = 1
            gridBandPaid.VisibleIndex = 2
            gridBandStatus.VisibleIndex = 3
        End If

        Dim query As String = "SELECT p.inv_number,p.reff,p.id_report,  p.id_comp, CONCAT(p.comp_number,' - ', p.comp_name) AS `comp`, 
p.created_date, p.due_date, p.number, p.note, 
p.amount,
IF(DATEDIFF(NOW(), p.due_date)<=0, DATEDIFF(NOW(), p.due_date),CONCAT('+', DATEDIFF(NOW(), p.due_date))) AS age,
p.amount-IFNULL(pyd.`value`,0) AS `balance`,
IF((SELECT balance)=0,NULL, (SELECT balance)) AS `balance_view`,
IF(DATE(NOW()) <= DATE_ADD(p.due_date,INTERVAL 30 DAY),(SELECT balance_view) ,NULL) AS `30`,
IF(DATE(NOW()) > DATE_ADD(p.due_date,INTERVAL 30 DAY) AND DATE(NOW()) <=DATE_ADD(p.due_date,INTERVAL 60 DAY),(SELECT balance_view) ,NULL) AS `60`,
IF(DATE(NOW()) > DATE_ADD(p.due_date,INTERVAL 60 DAY) AND DATE(NOW()) <=DATE_ADD(p.due_date,INTERVAL 90 DAY),(SELECT balance_view) ,NULL) AS `90`,
IF(DATE(NOW()) > DATE_ADD(p.due_date,INTERVAL 90 DAY),(SELECT balance_view) ,NULL) AS `90_up`,
pyd.`number` AS `paid_number`, IFNULL(pyd.`value`,0) AS `paid`, pyd.date_created AS `paid_date`, IFNULL(pyd.total_on_process,0) AS `on_process`,
IF(p.is_open=1,'Open','Close') AS `payment_status`
FROM (		
	-- pembelian
	SELECT GROUP_CONCAT(DISTINCT(pnd.inv_number)) AS inv_number,GROUP_CONCAT(DISTINCT(fgpo.prod_order_number)) AS reff,pn.id_pn_fgpo AS id_report, c.id_comp, c.comp_number, c.comp_name,'189' AS report_mark_type, pn.is_open,
	        pn.created_date, pn.due_date_inv AS due_date, pn.number, pn.note, 
	        SUM(pnd.value+pnd.vat) AS amount
	FROM `tb_pn_fgpo_det` pnd
	INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo AND pn.id_report_status=6
    LEFT JOIN tb_prod_order fgpo ON fgpo.id_prod_order=pnd.id_prod_order
	INNER JOIN tb_m_comp c ON c.id_comp = pn.id_comp " & cond_vendor & "
	GROUP BY pnd.id_pn_fgpo
	HAVING amount > 0
    UNION ALL 
	-- debit note
	SELECT '-' AS inv_number,GROUP_CONCAT(DISTINCT(dnd.report_number)) AS reff,dn.id_debit_note AS id_report, c.id_comp, c.comp_number, c.comp_name,'221' AS report_mark_type, dn.is_open,
	        dn.created_date,dn.due_date_inv AS due_date, dn.number, dn.note, 
	        CAST(-SUM((dnd.claim_percent/100)*dnd.unit_price*qty) AS DECIMAL(13,2)) AS amount
	FROM `tb_debit_note_det` dnd
	INNER JOIN tb_debit_note dn ON dn.id_debit_note=dnd.id_debit_note AND dn.id_report_status=6
	INNER JOIN tb_m_comp c ON c.id_comp = dn.id_comp " & cond_vendor & "
	GROUP BY dnd.id_debit_note
	HAVING amount != 0
	UNION ALL 
	-- inv pl mat, return mat
	SELECT '-' AS inv_number,GROUP_CONCAT(DISTINCT(fgpo.prod_order_number)) AS reff,dn.id_inv_mat AS id_report, c.id_comp, c.comp_number, c.comp_name,'221' AS report_mark_type, dn.is_open,
	        dn.created_date,dn.due_date AS due_date, dn.number, dn.note, 
	        CAST(IF(id_inv_mat_type=1,1,-1) * SUM(dnd.value) AS DECIMAL(13,2)) AS amount
	FROM `tb_inv_mat_det` dnd
	INNER JOIN tb_inv_mat dn ON dn.id_inv_mat=dnd.id_inv_mat AND dn.id_report_status=6
    LEFT JOIN tb_prod_order fgpo ON fgpo.id_prod_order=dnd.id_prod_order
	INNER JOIN tb_m_comp c ON c.id_comp = dn.id_comp " & cond_vendor & "
	GROUP BY dnd.id_inv_mat
	HAVING amount != 0
    UNION ALL 
    -- PO OG
	SELECT po.inv_number,GROUP_CONCAT(DISTINCT(po.purc_order_number)) AS reff,po.`id_purc_order` AS id_report,c.id_comp,c.`comp_number`,c.`comp_name`,po.report_mark_type, IF(po.is_close_pay=2,1,2) AS is_open,
		MIN(rec.date_created) AS created_date,po.due_date AS due_date, po.purc_order_number AS number, po.note,
		SUM(recd.`qty`*(pod.`value`-pod.`discount`))-po.disc_value AS amount 
	FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
	INNER JOIN tb_purc_order po ON pod.`id_purc_order`=po.`id_purc_order` AND po.is_active_payment='1' AND po.is_cash_purchase='2'
	INNER JOIN tb_m_comp_contact cc ON po.id_comp_contact=cc.id_comp_contact
	INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp " & cond_vendor & "
	GROUP BY po.`id_purc_order`
	UNION ALL
	-- Expense pay later
	SELECT ex.inv_number,'' AS reff,ex.`id_item_expense` AS id_report,c.id_comp,c.`comp_number`,c.`comp_name`,'157' AS report_mark_type, ex.is_open,
		ex.created_date,ex.due_date AS due_date, ex.number AS number, ex.note,
		SUM(exd.`tax_value`+exd.`amount`) AS amount 
	FROM `tb_item_expense_det` exd 
	INNER JOIN `tb_item_expense` ex ON ex.`id_item_expense`=exd.`id_item_expense` AND ex.`id_report_status`='6' AND ex.is_pay_later
	INNER JOIN tb_m_comp c ON c.id_comp = ex.id_comp " & cond_vendor & "
	GROUP BY ex.`id_item_expense`
) p
INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type` = p.`report_mark_type`
LEFT JOIN (
	SELECT pyd.id_report, pyd.report_mark_type, py.date_created, py.`number`, SUM(pyd.`value`) AS `value`,
	COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_pn,NULL)) AS `total_on_process`
	FROM tb_pn_det pyd
	INNER JOIN tb_pn py ON py.`id_pn`=pyd.`id_pn` AND py.`id_report_status`=6
    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=py.id_comp_contact
    INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp " & cond_vendor & "
	GROUP BY pyd.id_report, pyd.report_mark_type
) pyd ON pyd.`id_report`=p.`id_report` AND pyd.`report_mark_type`=p.`report_mark_type`
WHERE 1=1 " & cond & "
ORDER BY p.id_report ASC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class