Public Class FormPurcOrderPenawaranPPS
    Public id_pps As String = "-1"
    Dim id_vendor_type As Integer = 1
    Dim vendor_type As String = "Silver"
    Private Sub FormPurcOrderPenawaranPPS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load
        load_det()

        FormMain.SplashScreenManager1.ShowWaitForm()

        For i = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
            FormMain.SplashScreenManager1.SetWaitFormDescription("Processing request item " & i + 1 & " of " & (FormPurcOrder.GVPurcReq.RowCount) & "  ")

            GVPurcReq.AddNewRow()
            GVPurcReq.FocusedRowHandle = GVPurcReq.RowCount - 1
            '
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "id_purc_req_det", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_purc_req_det"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "departement", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "departement"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "purc_req_number", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "purc_req_number"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "requirement_date", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "requirement_date"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "item_desc", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_desc"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "item_detail", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_detail"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "qty_pr", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_pr"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "uom", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "uom"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "vendor_type", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "vendor_type"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "ship_destination", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "ship_destination"))
            GVPurcReq.SetRowCellValue(GVPurcReq.RowCount - 1, "ship_address", FormPurcOrder.GVPurcReq.GetRowCellValue(i, "ship_address"))
            '
            If FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_vendor_type") > id_vendor_type And FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_vendor_type") <= 4 Then
                id_vendor_type = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_vendor_type")
                vendor_type = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "vendor_type").ToString
            End If
        Next

        GVPurcReq.RefreshData()
        GVPurcReq.BestFitColumns()
        '
        TEVendorType.Text = vendor_type
        load_vendor()

        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub load_vendor()
        Dim q As String = "SELECT id_comp,CONCAT(comp_number,' - ',comp_name) AS comp_name FROM tb_m_comp c
WHERE c.is_active='1' AND c.id_vendor_type>=" & id_vendor_type & " AND c.id_vendor_type<=4
AND c.id_comp_cat IN (1,8,7)"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_det()
        Dim q As String = "SELECT '-' AS status_val,cat.id_expense_type,CONCAT(rd.item_detail,IF(ISNULL(rd.remark) OR rd.remark='','',CONCAT('\r\n',rd.remark))) AS item_detail,rd.id_b_expense,rd.id_b_expense_opex,icd.id_vendor_type,icd.item_cat_detail,vt.vendor_type,req.date_created AS pr_created,dep.`departement`,rd.`id_purc_req_det`,req.`id_purc_req`,req.`purc_req_number`,cat.`item_cat`,itm.`item_desc`,rd.`value` AS val_pr,rd.`qty` AS qty_pr,'no' AS is_check 
,req.note,IFNULL(po.qty,0) AS qty_po_created,req.id_user_created,IFNULL(po.qty_pending,0) AS po_qty_pending,IFNULL(rec.qty,0)-IFNULL(ret.qty,0) AS qty_rec,0.00 AS qty_po,uom.uom,rd.id_item,req.id_item_type,req.id_report_status,typ.item_type,itm.latest_price,rd.ship_destination,rd.ship_address, (IFNULL(po.qty_rec,0) - IFNULL(po.qty,0)) qty_s_rec
,req.requirement_date
FROM tb_purc_offer_pr offpr
INNER JOIN tb_purc_req_det rd ON rd.id_purc_req_det=offpr.id_purc_req_det AND offpr.id_purc_offer='" & id_pps & "'
INNER JOIN tb_purc_req req ON req.id_purc_req=rd.id_purc_req
INNER JOIN tb_lookup_purc_item_type typ ON typ.id_item_type=req.id_item_type
INNER JOIN tb_item itm ON itm.`id_item`=rd.`id_item`
INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
INNER JOIN tb_item_cat_detail icd ON icd.`id_item_cat_detail`=itm.`id_item_cat_detail`
INNER JOIN tb_vendor_type vt ON vt.id_vendor_type=icd.id_vendor_type
LEFT JOIN 
(
	SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,SUM(pod.`qty`) AS qty, SUM(IF(po.is_close_rec=1,0,pod.`qty`)) AS qty_pending, po.is_close_rec, IFNULL(SUM(rec.`qty_rec`),0) AS qty_rec  
	FROM tb_purc_order_det pod
	INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	LEFT JOIN 
	(
		SELECT recd.id_purc_order_det,SUM(recd.qty) AS qty_rec
		FROM `tb_purc_rec_det` recd 
		INNER JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec AND rec.id_report_status!=5
		GROUP BY recd.id_purc_order_det
	) rec ON pod.`id_purc_order_det` = rec.`id_purc_order_det`
	WHERE po.`id_report_status`!='5' AND pod.is_drop='2'
	GROUP BY pod.`id_purc_req_det`
)po ON po.id_purc_req_det=rd.`id_purc_req_det`
LEFT JOIN 
(
	SELECT pod.`id_purc_req_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd
	INNER JOIN tb_purc_order_det pod ON recd.id_purc_order_det=pod.id_purc_order_det
	INNER JOIN tb_purc_rec rec ON recd.`id_purc_rec`=rec.id_purc_rec
	WHERE rec.`id_report_status`!='5'
	GROUP BY pod.`id_purc_req_det`
)rec ON rec.id_purc_req_det=rd.`id_purc_req_det`
LEFT JOIN 
(
    SELECT pod.`id_purc_req_det`,SUM(prd.`qty`) AS qty FROM `tb_purc_return_det` prd
    INNER JOIN `tb_purc_return` pr ON pr.id_purc_return=prd.id_purc_return AND pr.id_report_status!='5'
    INNER JOIN tb_purc_order_det pod ON prd.id_purc_order_det=pod.id_purc_order_det
    INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
    GROUP BY pod.`id_purc_req_det`
)ret ON ret.id_purc_req_det=rd.`id_purc_req_det`
WHERE req.`id_report_status`='6' AND rd.`is_close`='2' AND rd.is_unable_fulfill='2' AND (IFNULL(po.qty,0) = 0 OR (po.is_close_rec = 1 AND po.qty <> po.qty_rec)) "
        GCPurcReq.DataSource = execute_query(q, -1, True, "", "", "", "")
        GVPurcReq.BestFitColumns()
        '
        'load vendor list
        q = "SELECT ov.id_comp,ov.id_purc_offer_vendor,CONCAT(c.comp_number,' - ',c.comp_name) AS comp_name
FROM `tb_purc_offer_vendor` ov
INNER JOIN tb_m_comp c ON c.id_comp=ov.id_comp
WHERE ov.id_purc_offer='" & id_pps & "'"
        GCVendor.DataSource = execute_query(q, -1, True, "", "", "", "")
        GVVendor.BestFitColumns()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSend_Click(sender As Object, e As EventArgs) Handles BSend.Click
        If GVVendor.RowCount > 0 And GVPurcReq.RowCount > 0 Then
            If id_pps = "-1" Then
                Dim q As String = "INSERT INTO `tb_purc_offer`(created_by,created_date,id_vendor_type)
VALUES('" & id_user & "',NOW(),'" & id_vendor_type & "')"
                id_pps = execute_query(q, 0, True, "", "", "", "")
                'item
                q = "INSERT INTO tb_purc_offer_pr(`id_purc_offer`,`id_purc_req_det`) VALUES"
                For i = 0 To GVPurcReq.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
                'vendor
                q = "INSERT INTO tb_purc_offer_vendor(`id_purc_offer`,`id_comp`) VALUES"
                For i = 0 To GVVendor.RowCount - 1
                    If Not i = 0 Then
                        q += ","
                    End If
                    q += "('" & id_pps & "','" & GVVendor.GetRowCellValue(i, "id_comp").ToString & "')"
                Next
                execute_non_query(q, True, "", "", "", "")
            End If
        Else
            warningCustom("Please choose at least 1 vendor")
        End If
    End Sub

    Private Sub BAddVendor_Click(sender As Object, e As EventArgs) Handles BAddVendor.Click
        Dim is_ok As Boolean = True
        For i = 0 To GVVendor.RowCount - 1
            If GVVendor.GetRowCellValue(i, "id_comp").ToString = SLEVendor.EditValue.ToString Then
                warningCustom("Vendor already choosen")
                is_ok = False
                Exit For
            End If
        Next

        If is_ok Then
            GVVendor.AddNewRow()
            GVVendor.FocusedRowHandle = GVPurcReq.RowCount - 1
            '
            GVVendor.SetRowCellValue(GVPurcReq.RowCount - 1, "id_comp", SLEVendor.EditValue.ToString)
            GVVendor.SetRowCellValue(GVPurcReq.RowCount - 1, "comp_name", SLEVendor.Text)
            GVVendor.BestFitColumns()
        End If
    End Sub

    Private Sub DeleteVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteVendorToolStripMenuItem.Click
        If GVVendor.RowCount > 0 Then
            GVVendor.DeleteSelectedRows()
            GVVendor.RefreshData()
        Else
            warningCustom("No vendor selected")
        End If
    End Sub
End Class