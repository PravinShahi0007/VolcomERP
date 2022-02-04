Public Class FormVMStock
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormVMStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DESOHUntil.EditValue = Now()
        DEFromSC.EditValue = Now()
        DEUntilSC.EditValue = Now()
        '
        load_store()
        load_item()
    End Sub

    Sub load_item()
        Dim q As String = "SELECT i.`id_item`,i.`item_desc`,0 AS qty,uom.`uom`
FROM tb_item i 
INNER JOIN tb_m_uom uom ON uom.`id_uom`=i.`id_uom`
WHERE i.is_active=1"
        viewSearchLookupQuery(SLEItem, q, "id_item", "item_desc", "id_item")
        SLEItem.EditValue = Nothing
    End Sub

    Sub load_store()
        Dim q As String = "SELECT 'ALL' AS id_comp,'ALL' AS comp_name,'ALL' AS comp_number,'-' AS sts
UNION ALL
SELECT 'office' AS id_comp,'Office' AS comp_name,'Office' AS comp_number,'-' AS sts
UNION ALL
SELECT id_comp,comp_name,comp_number,IF(is_active=1,'Active','Not Active') AS sts
FROM tb_m_comp WHERE id_comp_cat='6'"
        viewSearchLookupQuery(SLEToko, q, "id_comp", "comp_name", "id_comp")
        viewSearchLookupQuery(SLECardToko, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Dim qw As String = ""

        If SLEToko.EditValue.ToString = "office" Then
            qw = " AND id_comp='0' "
        ElseIf SLEToko.EditValue.ToString = "ALL" Then
            qw = ""
        Else
            qw = " AND id_comp='" & SLEToko.EditValue.ToString & "' "
        End If

        Dim q As String = "(SELECT st.`id_comp`,c.`comp_number`,c.`comp_name`,IF(st.id_comp=0,'Office',CONCAT(c.comp_number,' - ',c.comp_name)) AS location,i.`id_item`,i.`item_desc`,SUM(st.qty) AS qty,uom.uom
FROM `tb_stock_vm` st
LEFT JOIN tb_m_comp c ON c.`id_comp`=st.`id_comp`
INNER JOIN tb_item i ON i.`id_item`=st.`id_item`
INNER JOIN tb_m_uom uom ON uom.id_uom=i.id_uom
WHERE DATE(st.stock_date)<=DATE('" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "')
GROUP BY st.`id_comp`,st.`id_item`
HAVING qty>0 " & qw & ")
UNION ALL
(SELECT '0' AS `id_comp`,'Office (Storage)' AS `comp_number`,'Office (Storage)' AS `comp_name`,'Office (Storage)' AS location,im.`id_item`,im.`item_desc`,
SUM(IF(i.id_storage_category=2, CONCAT('-', i.storage_item_qty), i.storage_item_qty)) AS `qty`,uom.uom
FROM tb_storage_item i
INNER JOIN tb_item im ON im.id_item = i.id_item
INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
WHERE DATE(i.storage_item_datetime)<=DATE('" & Date.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND i.id_departement='18'
GROUP BY i.id_departement,i.id_item
HAVING qty>0 " & qw & ")"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCStock.DataSource = dt
        GVStock.BestFitColumns()
    End Sub

    Private Sub BMoveAsset_Click(sender As Object, e As EventArgs) Handles BMoveAsset.Click
        FormVMMove.ShowDialog()
    End Sub

    Private Sub GVMoveList_DoubleClick(sender As Object, e As EventArgs) Handles GVMoveList.DoubleClick
        FormVMMove.id = GVMoveList.GetFocusedRowCellValue("id_vm_item_move").ToString
        FormVMMove.ShowDialog()
    End Sub

    Private Sub BRefreshMove_Click(sender As Object, e As EventArgs) Handles BRefreshMove.Click
        Dim q As String = "SELECT IF(h.id_type=1,'Transfer',IF(h.id_type=2,'Add Asset','Remove Asset')) AS type,IF(h.id_comp_from=0,'Office',IFNULL(cf.comp_name,'-')) AS comp_from,IF(h.id_comp_to=0,'Office',IFNULL(ct.comp_name,'-')) AS comp_to,h.id_vm_item_move,h.number,h.note,h.created_date,sts.report_status,emp.employee_name,h.id_report_status,h.id_comp_from,h.id_comp_to,h.id_type FROM tb_vm_item_move h
INNER JOIN tb_m_user usr ON usr.id_user=h.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=h.id_report_status
LEFT JOIN tb_m_comp cf ON cf.id_comp=h.id_comp_from
LEFT JOIN tb_m_comp ct ON ct.id_comp=h.id_comp_to
ORDER BY h.id_vm_item_move DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCMoveList.DataSource = dt
        GVMoveList.BestFitColumns()
    End Sub

    Private Sub BSearchCard_Click(sender As Object, e As EventArgs) Handles BSearchCard.Click
        Dim qw As String = ""

        If SLECardToko.EditValue.ToString = "office" Then
            qw = " HAVING id_comp='0' "
        ElseIf SLECardToko.EditValue.ToString = "ALL" Then
            qw = ""
        Else
            qw = " HAVING id_comp='" & SLECardToko.EditValue.ToString & "' "
        End If

        Dim q As String = "SELECT a.*, CAST(@bal:=@bal+a.qty AS DECIMAL(15,2)) AS `bal_qty`
FROM (
	SELECT 'beg' AS id_comp,'Begining' AS comp_name,beg.`id_item`,beg.`item_desc`,beg.stock_date,'Begining' AS `report_mark_type`,'Begining' AS `report_mark_type_name`
		,'' AS report_number
		,SUM(beg.`qty`) AS qty,SUM(beg.`qty`) AS qty_v,'Begining' AS movement,beg.uom
	FROM
	(
		SELECT 0 AS id_comp,'Office (storage)' AS comp_name,im.`id_item`,im.`item_desc`,i.`storage_item_datetime` AS stock_date,i.`report_mark_type`,rmt.`report_mark_type_name`
		,IF(i.report_mark_type='148',r.`purc_rec_number`,IF(i.report_mark_type='154' OR i.report_mark_type='163',req.`number`,del.`number`)) AS report_number
		,IF(i.id_storage_category=2, -i.storage_item_qty, i.storage_item_qty) AS `qty`,i.`storage_item_qty` AS qty_v,IF(i.id_storage_category=2,'Out','In') AS movement,uom.uom
		FROM tb_storage_item i
		INNER JOIN tb_item im ON im.id_item = i.id_item
		INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
		INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=i.`report_mark_type`
		LEFT JOIN tb_purc_rec r ON r.`id_purc_rec`=i.`id_report` AND i.`report_mark_type`='148'
		LEFT JOIN tb_item_req req ON req.`id_item_req`=i.`id_report` AND (i.`report_mark_type`='154' OR i.`report_mark_type`='163')
		LEFT JOIN tb_item_del del ON del.`id_item_del`=i.`id_report` AND (i.`report_mark_type`='156' OR i.`report_mark_type`='166')
		WHERE i.id_departement='18' AND DATE(i.`storage_item_datetime`)<'" & Date.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd") & "' 
		AND i.id_item='396'
		UNION ALL
		SELECT s.id_comp,IF(s.id_comp=0,'Office',CONCAT(c.comp_number,' - ',c.comp_name)) AS comp_name,im.`id_item`,im.`item_desc`,s.stock_date,s.report_mark_type,rmt.report_mark_type_name
		,IF(s.report_mark_type='389',m.`number`,d.`number`) AS report_number
		,s.`qty`,IF(s.`qty`<0,-1*s.`qty`,s.`qty`) AS qty_v,IF(s.`qty`<0,'Out','In') AS movement,uom.`uom`
		FROM tb_stock_vm s
		LEFT JOIN tb_m_comp c ON c.id_comp=s.id_comp
		INNER JOIN tb_item im ON im.id_item = s.id_item
		INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
		INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=s.`report_mark_type`
		LEFT JOIN `tb_vm_item_move` m ON m.`id_vm_item_move`=s.`id_report` AND s.`report_mark_type`='389'
		LEFT JOIN tb_item_del d ON d.`id_item_del`=s.`id_report` AND s.`report_mark_type`='166'
		WHERE s.id_item='396' AND DATE(s.`stock_date`)<'" & Date.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd") & "'
		" & qw & "
	)beg 
	GROUP BY beg.id_item
	UNION ALL
	SELECT 0 AS id_comp,'Office (storage)' AS comp_name,im.`id_item`,im.`item_desc`,i.`storage_item_datetime` AS stock_date,i.`report_mark_type`,rmt.`report_mark_type_name`
	,IF(i.report_mark_type='148',r.`purc_rec_number`,IF(i.report_mark_type='154' OR i.report_mark_type='163',req.`number`,del.`number`)) AS report_number
	,IF(i.id_storage_category=2, -i.storage_item_qty, i.storage_item_qty) AS `qty`,i.`storage_item_qty` AS qty_v,IF(i.id_storage_category=2,'Out','In') AS movement,uom.uom
	FROM tb_storage_item i
	INNER JOIN tb_item im ON im.id_item = i.id_item
	INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
	INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=i.`report_mark_type`
	LEFT JOIN tb_purc_rec r ON r.`id_purc_rec`=i.`id_report` AND i.`report_mark_type`='148'
	LEFT JOIN tb_item_req req ON req.`id_item_req`=i.`id_report` AND (i.`report_mark_type`='154' OR i.`report_mark_type`='163')
	LEFT JOIN tb_item_del del ON del.`id_item_del`=i.`id_report` AND (i.`report_mark_type`='156' OR i.`report_mark_type`='166')
	WHERE i.id_departement='18' AND DATE(i.`storage_item_datetime`)>='" & Date.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(i.`storage_item_datetime`)<='" & Date.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd") & "'
	AND i.id_item='396'
	UNION ALL
	SELECT s.id_comp,IF(s.id_comp=0,'Office',CONCAT(c.comp_number,' - ',c.comp_name)) AS comp_name,im.`id_item`,im.`item_desc`,s.stock_date,s.report_mark_type,rmt.report_mark_type_name
	,IF(s.report_mark_type='389',m.`number`,d.`number`) AS report_number
	,s.`qty`,IF(s.`qty`<0,-1*s.`qty`,s.`qty`) AS qty_v,IF(s.`qty`<0,'Out','In') AS movement,uom.`uom`
	FROM tb_stock_vm s
	LEFT JOIN tb_m_comp c ON c.id_comp=s.id_comp
	INNER JOIN tb_item im ON im.id_item = s.id_item
	INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom
	INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=s.`report_mark_type`
	LEFT JOIN `tb_vm_item_move` m ON m.`id_vm_item_move`=s.`id_report` AND s.`report_mark_type`='389'
	LEFT JOIN tb_item_del d ON d.`id_item_del`=s.`id_report` AND s.`report_mark_type`='166'
	WHERE s.id_item='396' AND DATE(s.`stock_date`)>='" & Date.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(s.`stock_date`)<='" & Date.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd") & "'
	" & qw & "
) a
JOIN (SELECT @bal:=0.00) b
WHERE a.qty_v>0
ORDER BY a.stock_date ASC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSC.DataSource = dt
        GVSC.BestFitColumns()
    End Sub

    Private Sub BRefreshPPS_Click(sender As Object, e As EventArgs) Handles BRefreshPPS.Click
        load_pps()
    End Sub

    Sub load_pps()
        Dim q As String = "SELECT id_item_pps,item.`number`,uom_stock.uom AS uom_stock,catd.item_cat_detail,CONCAT('1:',item.stock_convertion) AS stock_convertion,item.item_desc,type.expense_type,cat.`item_cat`,uom.uom,empc.`employee_name` AS emp_created,item_type.`item_type`
,item.`created_date` , dt.display_type, sts.`report_status`
FROM tb_item_pps item
INNER JOIN `tb_item_cat_detail` catd ON catd.`id_item_cat_detail`=item.`id_item_cat_detail`
INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=item.`id_item_cat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
INNER JOIN tb_m_user usrc ON usrc.`id_user`=item.`created_by`
INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
INNER JOIN tb_lookup_expense_type `type` ON type.id_expense_type=cat.id_expense_type
INNER JOIN tb_lookup_purc_item_type item_type ON item_type.`id_item_type`=item.`id_item_type`
INNER JOIN tb_display_type dt ON dt.id_display_type = item.id_display_type
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=item.`id_report_status`
LEFT JOIN tb_m_uom uom_stock ON uom_stock.`id_uom`=item.`id_uom_stock`
ORDER BY item.id_item_pps DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCItemPPs.DataSource = dt
        GVItemPps.BestFitColumns()
    End Sub

    Private Sub BNewPPS_Click(sender As Object, e As EventArgs) Handles BNewPPS.Click
        FormItemPps.id_pps = "-1"
        FormItemPps.is_vm_item = "1"
        FormItemPps.ShowDialog()
    End Sub
End Class