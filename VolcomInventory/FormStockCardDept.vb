Public Class FormStockCardDept
    Private Sub BtnViewSC_Click(sender As Object, e As EventArgs) Handles BtnViewSC.Click
        load_stock_card()
    End Sub

    Sub load_stock_card()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "1997-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilSC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim id_dept As String = id_departement_user
        Dim id_item_detail As String = SLEITem.EditValue.ToString

        Dim query As String = "CALL view_stock_card_asset(" + id_dept + ", " + id_item_detail + ", '" + date_from_selected + "', '" + date_until_selected + "','')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSC.DataSource = data
        GVSC.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAddInOut_Click(sender As Object, e As EventArgs) Handles BAddInOut.Click
        FormStockCardDepDet.ShowDialog()
    End Sub

    Private Sub BViewInOut_Click(sender As Object, e As EventArgs) Handles BViewInOut.Click
        load_inout()
    End Sub

    Sub load_inout()
        Dim query As String = "SELECT trx.`id_item_card_trs`,trx.`number`,sts.`report_status`,emp.employee_name,trx.`created_date`,c.`comp_name`,IF(trx.id_type=1,'Delivery','Receiving') AS type
FROM `tb_item_card_trs` trx
INNER JOIN tb_m_departement dep ON dep.id_departement=trx.id_departement
INNER JOIN tb_m_user usr ON usr.`id_user`=trx.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=trx.`id_report_status`
INNER JOIN tb_m_comp c ON c.`id_comp`=trx.`id_store`
WHERE trx.id_departement='" & id_departement_user & "' AND DATE(trx.`created_date`)>='" & Date.Parse(DEFromInout.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(trx.`created_date`) <= '" & Date.Parse(DEUntilInout.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY trx.id_item_card_trs DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInOut.DataSource = data
        GVInOut.BestFitColumns()
    End Sub

    Private Sub GVInOut_DoubleClick(sender As Object, e As EventArgs) Handles GVInOut.DoubleClick
        If GVInOut.RowCount > 0 Then
            FormStockCardDepDet.id_trans = GVInOut.GetFocusedRowCellValue("id_item_card_trs").ToString
            FormStockCardDepDet.ShowDialog()
        End If
    End Sub

    Private Sub FormStockCardDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFromInout.EditValue = Now
        DEUntilInout.EditValue = Now
        '
        DEFromSC.EditValue = Now
        DEUntilSC.EditValue = Now
        '
        DESOHUntil.EditValue = Now
        '
        load_item()
    End Sub

    Sub load_item()
        Dim q As String = "SELECT itd.`id_item_detail`,it.`item_desc`,CONCAT(itd.item_detail,IF(ISNULL(itd.remark) OR itd.remark='','',CONCAT('\r\n',itd.remark))) AS item_detail,IFNULL(its.qty,0.00) AS qty_available
FROM `tb_stock_card_dep_item` itd
INNER JOIN tb_item it ON it.`id_item`=itd.`id_item`
LEFT JOIN (
	SELECT id_item_detail,SUM(qty) AS qty
	FROM `tb_stock_card_dep`
	WHERE id_departement='" & id_departement_user & "'
	GROUP BY id_item_detail
)its ON its.id_item_detail=itd.`id_item_detail`"
        viewSearchLookupQuery(SLEITem, q, "id_item_detail", "item_detail", "id_item_detail")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DESOHUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim dept As String = "AND i.id_departement=" + id_departement_user + ""
        '
        Dim query As String = "
SELECT uom.uom,a.id_item, im.item_desc,a.item_detail,im.id_item_cat, cat.item_cat, SUM(a.qty) AS `qty`
FROM (
	SELECT i.id_item_detail,id.`id_item`,CONCAT(id.item_detail,IF(ISNULL(id.remark) OR id.remark='','',CONCAT('\r\n',id.remark))) AS item_detail,
	SUM(i.qty) AS `qty`
	FROM `tb_stock_card_dep` i
	INNER JOIN `tb_stock_card_dep_item` id ON id.`id_item_detail`=i.`id_item_detail`
	INNER JOIN tb_item im ON im.id_item = id.id_item
	INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
    WHERE DATE(i.storage_item_datetime)<='" + date_until_selected + "' " + dept + " 
	GROUP BY i.id_item_detail
) a 
INNER JOIN tb_item im ON im.id_item = a.id_item
INNER JOIN tb_m_uom uom ON uom.id_uom=im.id_uom_stock
INNER JOIN tb_item_cat cat ON cat.id_item_cat = im.id_item_cat
GROUP BY a.id_item_detail HAVING qty>0"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        GVSOH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BMaster_Click(sender As Object, e As EventArgs) Handles BMaster.Click

    End Sub
End Class