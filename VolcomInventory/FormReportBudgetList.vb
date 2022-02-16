Public Class FormReportBudgetList
    Public id_cat_main As String = ""
    Public id_departement As String = ""
    Public date_time As String = ""
    Public main_cat As String = "-1"
    Public year As String = ""

    Public opt As String = "1"
    Public qi As String = ""
    Public quntil As String = ""

    Private Sub FormReportBudgetList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
        '
        If opt = "1" Then
            XTPList.PageVisible = False
            XTPRec.PageVisible = False
            XTPDel.PageVisible = False
        ElseIf opt = "2" Then 'PO book
            XTPCard.PageVisible = False
            XTPRec.PageVisible = False
            XTPDel.PageVisible = False
            load_booked_po()
        ElseIf opt = "3" Then 'Receiving
            XTPCard.PageVisible = False
            XTPList.PageVisible = False
            XTPDel.PageVisible = False
            load_rec()
        ElseIf opt = "4" Then 'Delivery
            XTPCard.PageVisible = False
            XTPList.PageVisible = False
            XTPRec.PageVisible = False
            load_del()
        End If
    End Sub

    Sub load_rec()
        Dim q As String = "(SELECT ot.value,it.`item_desc`,rec.purc_rec_number,ot.date_trans,ot.id_report
FROM `tb_b_expense_opex_trans` ot
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=ot.id_report
INNER JOIN tb_item it ON it.`id_item`=ot.id_item
INNER JOIN `tb_b_expense_opex` ex  ON ex.`id_b_expense_opex`=ot.id_b_expense_opex
WHERE ot.is_po=2 " & qi & quntil & " )
UNION ALL
(SELECT ot.value,it.`item_desc`,rec.purc_rec_number,ot.date_trans,ot.id_report
FROM `tb_b_expense_trans` ot
INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=ot.id_report
INNER JOIN tb_item it ON it.`id_item`=ot.id_item
INNER JOIN `tb_b_expense` ex  ON ex.`id_b_expense`=ot.id_b_expense
WHERE ot.is_po=2 " & qi & quntil & " )"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCRec.DataSource = dt
        GVRec.BestFitColumns()
    End Sub

    Sub load_del()
        Dim q As String = "
SELECT acc.`id_acc`,acc.`acc_name`,acc.`acc_description`,SUM(IF(acc.`id_dc`=1,trxd.`debit`-trxd.`credit`,trxd.`credit`-trxd.`debit`)) AS val,acc.`id_coa_type`,trxd.`id_report`,trxd.`report_mark_type`
,del.`number`,trxd.`acc_trans_det_note`,trx.`date_reference`
FROM tb_a_acc_trans_det trxd
INNER JOIN tb_a_acc_trans trx ON trx.`id_acc_trans`=trxd.`id_acc_trans` AND YEAR(trx.`date_reference`)='2022'
INNER JOIN tb_a_acc acc ON acc.`id_acc`=trxd.`id_acc`
INNER JOIN tb_item_del del ON del.`id_item_del`=trxd.`id_report`
INNER JOIN
(
	SELECT acc.`acc_name`,acc.`id_coa_type` FROM
	`tb_b_expense_opex` opex 
	INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=opex.`id_item_cat_main`
	INNER JOIN tb_lookup_expense_type et ON et.`id_expense_type`=icm.`id_expense_type`
	INNER JOIN `tb_b_expense_opex_map` map ON map.`id_b_expense_opex`=opex.`id_b_expense_opex`
	INNER JOIN  tb_a_acc acc ON acc.`id_acc`=map.`id_acc` " & qi & "
)del ON LEFT(del.acc_name,4)=LEFT(acc.`acc_name`,4) AND acc.`id_coa_type`=del.`id_coa_type`
WHERE trx.`id_report_status`=6 " & quntil & "
AND (trxd.`report_mark_type`='156' OR trxd.`report_mark_type`='166')
GROUP BY trxd.`id_report`,trxd.`report_mark_type`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDel.DataSource = dt
        GVDel.BestFitColumns()
    End Sub

    Sub load_booked_po()
        Dim query As String = "SELECT 'no' AS is_check,tag.tag_description,po.est_date_receive,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated ,po.pay_due_date,po.date_created
,SUM(pod.qty) AS qty_po
,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value) AS total_po
,(SUM(pod.qty*(pod.value-pod.discount))) AS total_po_no_vat
,IFNULL(SUM(rec.qty),0) AS qty_rec
,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value)) AS total_rec
,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))) AS total_rec_no_vat
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason,rts.report_status,et.expense_type
,IFNULL(payment.value,0) AS val_pay
,IF(po.is_close_pay=1,'Closed',IF(DATE(NOW())>po.pay_due_date,'Overdue','Open')) as pay_status, po.is_close_rec, po.id_expense_type, po.id_report_status
FROM tb_purc_order po
INNER JOIN tb_coa_tag tag ON tag.id_coa_tag=po.id_coa_tag
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order`=po.`id_purc_order`
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_lookup_report_status rts ON rts.id_report_status=po.id_report_status
INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=po.id_expense_type
LEFT JOIN 
( 
	SELECT recd.`id_purc_order_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	GROUP BY recd.`id_purc_order_det`
) rec ON rec.id_purc_order_det=pod.`id_purc_order_det`
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=5 AND py.report_mark_type='139'
	GROUP BY pyd.id_report
)payment ON payment.id_report=po.id_purc_order
INNER JOIN
(
    " & qi & "
)poj ON poj.id_report=po.id_purc_order AND poj.report_mark_type=po.report_mark_type
GROUP BY po.id_purc_order ORDER BY po.id_purc_order DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
        GVPO.BestFitColumns()

        'details
        query = "SELECT i.item_desc,tag.tag_description,po.est_date_receive,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated ,po.pay_due_date,po.date_created
,SUM(pod.qty) AS qty_po,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value) AS total_po
,(SUM(pod.qty*(pod.value-pod.discount))) AS total_po_no_vat
,IFNULL(SUM(rec.qty),0) AS qty_rec,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value)) AS total_rec
,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))) AS total_rec_no_vat
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason,rts.report_status,et.expense_type
,IFNULL(payment.value,0) AS val_pay
,IF(po.is_close_pay=1,'Closed',IF(DATE(NOW())>po.pay_due_date,'Overdue','Open')) AS pay_status, po.is_close_rec, po.id_expense_type, po.id_report_status
FROM tb_purc_order po
INNER JOIN tb_coa_tag tag ON tag.id_coa_tag=po.id_coa_tag
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order`=po.`id_purc_order`
INNER JOIN tb_item i ON i.id_item=pod.id_item 
INNER JOIN tb_item_cat icat ON icat.id_item_cat=i.id_item_cat
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_lookup_report_status rts ON rts.id_report_status=po.id_report_status
INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=po.id_expense_type
LEFT JOIN 
( 
	SELECT recd.`id_purc_order_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	GROUP BY recd.`id_purc_order_det`
) rec ON rec.id_purc_order_det=pod.`id_purc_order_det`
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=5 AND py.report_mark_type='139'
	GROUP BY pyd.id_report
)payment ON payment.id_report=po.id_purc_order
INNER JOIN
(
    " & qi & "
)poj ON poj.id_report=po.id_purc_order AND poj.report_mark_type=po.report_mark_type AND icat.id_item_cat_main=poj.id_item_cat_main
GROUP BY pod.id_purc_order_det 
ORDER BY pod.id_purc_order_det DESC"
        Dim data_det As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data_det
        GVItemList.BestFitColumns()

    End Sub

    Sub load_list()
        Dim q_dep_opex As String = ""
        Dim q_dep_capex As String = ""

        If Not id_departement = "0" Then
            q_dep_opex = " AND ot.id_departement='" & id_departement & "'"
            q_dep_capex = " AND et.id_departement='" & id_departement & "'"
        End If

        Dim query As String = "SELECT it.item_desc,o.id_b_expense_opex,ot.`value`,ot.is_po,ot.`note`,ot.id_report,ot.report_mark_type,IF(ISNULL(po.purc_order_number),IF(ISNULL(rec.purc_rec_number),'',rec.purc_rec_number),po.purc_order_number) AS report_number
FROM `tb_b_expense_opex_trans` ot
INNER JOIN tb_b_expense_opex o ON ot.`id_b_expense_opex`=o.`id_b_expense_opex` AND o.id_item_cat_main='" & id_cat_main & "' " & q_dep_opex & "
LEFT JOIN tb_purc_order po ON po.id_purc_order=ot.id_report AND (ot.report_mark_type='139' or ot.report_mark_type='202')
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=ot.id_report AND ot.report_mark_type='148'
LEFT JOIN tb_item it ON it.id_item=ot.id_item
WHERE o.`year`='" & year & "' AND DATE(ot.date_trans)<='" & date_time & "'
UNION ALL
SELECT it.item_desc,et.id_b_expense,et.`value` AS val,et.is_po,et.`note`,et.id_report,et.report_mark_type,IF(ISNULL(po.purc_order_number),IF(ISNULL(rec.purc_rec_number),'',rec.purc_rec_number),po.purc_order_number) AS report_number
FROM `tb_b_expense_trans` et
INNER JOIN tb_b_expense e ON e.`id_b_expense`=et.`id_b_expense` AND e.id_item_cat_main='" & id_cat_main & "' " & q_dep_capex & "
LEFT JOIN tb_purc_order po ON po.id_purc_order=et.id_report AND (et.report_mark_type='139' or et.report_mark_type='202')
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=et.id_report AND et.report_mark_type='148'
LEFT JOIN tb_item it ON it.id_item=et.id_item
WHERE e.`year`='" & year & "' AND DATE(et.date_trans)<='" & date_time & "'"
        '
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetCard.DataSource = data
        GVBudgetCard.BestFitColumns()
    End Sub

    Private Sub FormReportBudgetList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = GVBudgetCard.GetFocusedRowCellValue("report_mark_type").ToString
        showpopup.id_report = GVBudgetCard.GetFocusedRowCellValue("id_report").ToString
        showpopup.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVBudgetCard_DoubleClick(sender As Object, e As EventArgs) Handles GVBudgetCard.DoubleClick
        Cursor = Cursors.WaitCursor

        Try
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = GVBudgetCard.GetFocusedRowCellValue("report_mark_type").ToString
            showpopup.id_report = GVBudgetCard.GetFocusedRowCellValue("id_report").ToString
            showpopup.show()
        Catch ex As Exception
            stopCustom("Document Not Found")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub GVPO_DoubleClick(sender As Object, e As EventArgs) Handles GVPO.DoubleClick
        If GVPO.RowCount > 0 Then
            FormPurcOrderDet.id_po = GVPO.GetFocusedRowCellValue("id_purc_order").ToString
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub

    Private Sub GVItemList_DoubleClick(sender As Object, e As EventArgs) Handles GVItemList.DoubleClick
        If GVItemList.RowCount > 0 Then
            FormPurcOrderDet.id_po = GVItemList.GetFocusedRowCellValue("id_purc_order").ToString
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub

    Private Sub GVRec_DoubleClick(sender As Object, e As EventArgs) Handles GVRec.DoubleClick
        FormPurcReceiveDet.action = "upd"
        FormPurcReceiveDet.id = GVRec.GetFocusedRowCellValue("id_report").ToString
        FormPurcReceiveDet.ShowDialog()
    End Sub

    Private Sub GVDel_DoubleClick(sender As Object, e As EventArgs) Handles GVDel.DoubleClick
        FormItemDelDetail.action = "upd"
        FormItemDelDetail.id = GVDel.GetFocusedRowCellValue("id_report").ToString
        FormItemDelDetail.ShowDialog()
    End Sub
End Class