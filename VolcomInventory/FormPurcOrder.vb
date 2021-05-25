﻿Public Class FormPurcOrder
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    Public id_coa_tag As String = "1"

    Private Sub FormPurcOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcOrder_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcOrder_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub
    '
    Sub check_menu()
        If XTCPO.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub load_po_status()
        Dim query As String = "SELECT '1' AS `id_po_status`,'Waiting' AS `po_status`
                                UNION
                                SELECT '2' AS `id_po_status`,'PO Created' AS `po_status`
                                UNION
                                SELECT '3' AS `id_po_status`,'All' AS `po_status`"
        viewSearchLookupQuery(LEPOStatus, query, "id_po_status", "po_status", "id_po_status")
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        '        query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Private Sub FormPurcOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_unit()

        load_vendor()
        load_vendor_list_po()
        load_po_item()

        '
        load_dep()
        load_item_cat()
        load_item()
        load_po_status()
        loadImgPath()
        load_expense_type()
        '
        load_rec_status()
        '
        check_menu()
    End Sub

    Sub load_rec_status()
        Dim query As String = "SELECT '0' AS `id_rec_status`,'All' AS `rec_status`
                                UNION
                                SELECT '1' AS `id_rec_status`,'Open' AS `rec_status`
                                UNION
                                SELECT '2' AS `id_rec_status`,'Closed' AS `rec_status`"
        viewSearchLookupQuery(SLERecStatus, query, "id_rec_status", "rec_status", "id_rec_status")
    End Sub

    Sub load_expense_type()
        Dim query As String = "SELECT id_expense_type,expense_type FROM `tb_lookup_expense_type`"
        viewSearchLookupQuery(SLEExpenseType, query, "id_expense_type", "expense_type", "id_expense_type")
    End Sub

    Sub load_po()
        Dim where_string As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            where_string += " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        If SLERecStatus.EditValue.ToString = "1" Then
            where_string += " AND po.is_close_rec='2'"
        ElseIf SLERecStatus.EditValue.ToString = "2" Then
            where_string += " AND po.is_close_rec='1'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,tag.tag_description,po.est_date_receive,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated ,po.pay_due_date,po.date_created
,SUM(pod.qty) AS qty_po,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value) AS total_po
,IFNULL(SUM(rec.qty),0) AS qty_rec,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value)) AS total_rec
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason,rts.report_status
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
WHERE 1=1 " & where_string & " GROUP BY po.id_purc_order ORDER BY po.id_purc_order DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
        GVPO.BestFitColumns()
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 AS id_departement,'All Departement' AS departement 
                                UNION
                                SELECT id_departement,departement FROM tb_m_departement WHERE id_coa_tag='" & SLEUnit.EditValue.ToString & "'"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_item_cat()
        Dim query As String = "SELECT 0 AS id_item_cat,'All Category' AS item_cat 
                                UNION
                                SELECT id_item_cat,item_cat FROM tb_item_cat itc WHERE itc.is_active='1'"
        viewSearchLookupQuery(SLEItemCat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_item()
        Dim query_where As String = ""
        '
        If Not SLEItemCat.EditValue.ToString = "0" Then
            query_where = "itm.id_item_cat='" & SLEItemCat.EditValue.ToString & "' AND"
        End If
        '
        Dim query As String = "SELECT '0' AS id_item,'All item' AS item_desc,'All item' AS `item_cat`
                                UNION
                                SELECT itm.id_item,itm.item_desc,itc.`item_cat`
                                FROM tb_item itm
                                INNER JOIN `tb_item_cat` itc ON itc.id_item_cat=itm.id_item_cat AND itc.`is_active`='1'
                                WHERE " & query_where & " itm.`is_active`='1'"
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
    End Sub

    Sub load_po_item()
        Dim query As String = "SELECT 0 AS id_purc_order,'ALL' AS `purc_order_number` ,'ALL' AS `comp_name`,'ALL' AS `comp_number`
UNION
SELECT po.id_purc_order,po.`purc_order_number` ,c.`comp_name`,c.`comp_number`
FROM tb_purc_order po 
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE po.id_report_status='6' AND po.is_close_rec='2'"
        viewSearchLookupQuery(SLEPONumber, query, "id_purc_order", "purc_order_number", "id_purc_order")
    End Sub

    Sub load_req()
        GVPurcReq.ActiveFilterString = ""
        Dim query_where As String = ""
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then 'departement
            query_where += " AND dep.id_departement='" & SLEDepartement.EditValue.ToString & "' "
        End If
        '
        query_where += " AND dep.id_coa_tag='" & SLEUnit.EditValue.ToString & "' "
        '
        If Not SLEItemCat.EditValue.ToString = "0" Then 'category
            query_where += " AND cat.id_item_cat='" & SLEItemCat.EditValue.ToString & "' "
        End If
        '
        'If Not SLEItem.EditValue.ToString = "0" Then 'item
        '    query_where += " AND itm.id_item='" & SLEItem.EditValue.ToString & "' "
        'End If
        '
        If Not LEPOStatus.EditValue.ToString = "3" Then 'item
            If LEPOStatus.EditValue.ToString = "1" Then 'Not created PO
                'query_where += " AND (IFNULL(po.qty,0) = 0 OR (po.is_close_rec = 1 AND po.qty <> po.qty_rec))"
                query_where += " AND (IFNULL(po.qty,0) = 0 OR (po.is_close_rec = 1 AND po.qty <> po.qty_rec))"
            Else 'PO created
                query_where += " AND IFNULL(po.qty,0) > 0"
            End If
        End If
        'expense type
        query_where += " AND cat.id_expense_type='" & SLEExpenseType.EditValue.ToString & "' "
        '
        Dim query As String = "SELECT '-' AS status_val,cat.id_expense_type,CONCAT(rd.item_detail,IF(ISNULL(rd.remark) OR rd.remark='','',CONCAT('\r\n',rd.remark))) AS item_detail,rd.id_b_expense,rd.id_b_expense_opex,icd.id_vendor_type,icd.item_cat_detail,vt.vendor_type,req.date_created AS pr_created,dep.`departement`,rd.`id_purc_req_det`,req.`id_purc_req`,req.`purc_req_number`,cat.`item_cat`,itm.`item_desc`,rd.`value` AS val_pr,rd.`qty` AS qty_pr,'no' AS is_check 
                                ,req.note,IFNULL(po.qty,0) AS qty_po_created,IFNULL(rec.qty,0)-IFNULL(ret.qty,0) AS qty_rec,0.00 AS qty_po,uom.uom,rd.id_item,req.id_item_type,req.id_report_status,typ.item_type,itm.latest_price,rd.ship_destination,rd.ship_address, (IFNULL(po.qty_rec,0) - IFNULL(po.qty,0)) qty_s_rec
                                FROM tb_purc_req_det rd 
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
	                                SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,SUM(pod.`qty`) AS qty, po.is_close_rec, SUM(rec.`qty_rec`) AS qty_rec 
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
	                                SELECT pod.`id_purc_req_det`,SUM(recd.`qty`) as qty FROM tb_purc_rec_det recd
                                    INNER JOIN tb_purc_order_det pod ON recd.id_purc_order_det=pod.id_purc_order_det
	                                INNER JOIN tb_purc_rec rec ON recd.`id_purc_rec`=rec.id_purc_rec
	                                WHERE rec.`id_report_status`!='5'
                                    GROUP BY pod.`id_purc_req_det`
                                )rec ON rec.id_purc_req_det=rd.`id_purc_req_det`
                                LEFT JOIN 
                                (
                                    SELECT pod.`id_purc_req_det`,SUM(prd.`qty`) as qty FROM `tb_purc_return_det` prd
                                    INNER JOIN `tb_purc_return` pr ON pr.id_purc_return=prd.id_purc_return AND pr.id_report_status!='5'
                                    INNER JOIN tb_purc_order_det pod ON prd.id_purc_order_det=pod.id_purc_order_det
                                    INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
                                    GROUP BY pod.`id_purc_req_det`
                                )ret ON ret.id_purc_req_det=rd.`id_purc_req_det`
                                WHERE req.`id_report_status`='6' AND rd.`is_close`='2' AND rd.is_unable_fulfill='2' " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
        '
        If Not LEPOStatus.EditValue.ToString = "1" Then
            BCreatePO.Visible = False
            BCantFulfill.Visible = False
        Else
            BCreatePO.Visible = True
            BCantFulfill.Visible = True
        End If
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='8'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_po()
    End Sub

    Private Sub SLEItemCat_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItemCat.EditValueChanged
        load_item()
    End Sub

    Private Sub BViewReqList_Click(sender As Object, e As EventArgs) Handles BViewReqList.Click
        id_coa_tag = SLEUnit.EditValue.ToString
        load_req()
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        'check first
        Dim is_already_created, is_zero, is_pr_not_match, is_not_match_destination As Boolean

        is_already_created = False
        is_zero = False
        is_pr_not_match = False
        is_not_match_destination = False

        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        If GVPurcReq.RowCount > 0 Then
            'check destination
            Dim dest_name As String = GVPurcReq.GetRowCellValue(0, "ship_destination").ToString
            Dim dest_address As String = GVPurcReq.GetRowCellValue(0, "ship_address").ToString
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If Not GVPurcReq.GetRowCellValue(i, "ship_destination").ToString = dest_name Or Not GVPurcReq.GetRowCellValue(i, "ship_address").ToString = dest_address Then
                    is_not_match_destination = True
                End If
            Next

            'fill Qty
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                GVPurcReq.SetRowCellValue(i, "qty_po", GVPurcReq.GetRowCellValue(i, "qty_pr"))
            Next
            '
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If (GVPurcReq.GetRowCellValue(i, "qty_po_created") > 0) And (GVPurcReq.GetRowCellValue(i, "qty_s_rec") >= 0) Then
                    'qty PO already not 0
                    is_already_created = True
                    GVPurcReq.SetRowCellValue(i, "status_val", "Already created PO")
                ElseIf (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "") OrElse (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "0") Then
                    is_zero = True
                    GVPurcReq.SetRowCellValue(i, "status_val", "Zero Qty")
                    'ElseIf GVPurcReq.GetRowCellValue(i, "val_pr") < GVPurcReq.GetRowCellValue(i, "latest_price") Then
                    '    is_pr_not_match = True
                    '    GVPurcReq.SetRowCellValue(i, "status_val", "Requested price below the latest Price")
                Else
                    GVPurcReq.SetRowCellValue(i, "status_val", "Ok")
                End If
            Next
            '
            If is_zero = True Then
                stopCustom("Please make sure qty not zero.")
            ElseIf is_already_created = True Then
                stopCustom("PO already created.")
            ElseIf is_pr_not_match = True Then
                stopCustom("Requested price is below the latest price.")
            Else
                If is_not_match_destination = True Then
                    warningCustom("Please note that destination address is different !")
                End If
                FormPurcOrderDet.is_pick = "1"
                FormPurcOrderDet.ShowDialog()
            End If
            GVPurcReq.BestFitColumns()
        Else
            warningCustom("Please select item first.")
            GVPurcReq.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVPO_DoubleClick(sender As Object, e As EventArgs) Handles GVPO.DoubleClick
        If GVPO.RowCount > 0 Then
            FormPurcOrderDet.id_po = GVPO.GetFocusedRowCellValue("id_purc_order").ToString
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub

    Private Sub BCantFulfill_Click(sender As Object, e As EventArgs) Handles BCantFulfill.Click
        'update status to cannot proceed
        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        FormPurcReqItemUnableFulfill.id_popup = "1"
        FormPurcReqItemUnableFulfill.ShowDialog()
        GVPurcReq.ActiveFilterString = ""
    End Sub

    Private Sub SMClose_Click(sender As Object, e As EventArgs)
        'GVPO.ActiveFilterString = ""
        'GVPO.ActiveFilterString = "[is_check]='yes'"
        'FormPurcReqItemUnableFulfill.id_popup = "2"
        'FormPurcReqItemUnableFulfill.ShowDialog()
        'GVPO.ActiveFilterString = ""
        warningCustom("Please use close form")
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVPOItem.RowCount > 0 Then
            For i As Integer = 0 To ((GVPOItem.RowCount - 1) - GetGroupRowCount(GVPOItem))
                If CheckEditSelAll.Checked = False Then
                    GVPOItem.SetRowCellValue(i, "is_check", "no")
                Else
                    GVPOItem.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Sub load_vendor_list_po()
        Dim query As String = "SELECT 0 AS `id_comp`,'ALL' AS `comp_number`,'ALL' AS `comp_name`
UNION
SELECT c.`id_comp`,c.`comp_number`,c.`comp_name` FROM tb_purc_order po
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
GROUP BY c.id_comp"
        viewSearchLookupQuery(SLEVendorListPO, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_list_item_po()
        Dim query_where As String = ""

        If Not SLEVendorListPO.EditValue.ToString = "0" Then 'id vendor
            query_where += " AND c.id_comp='" & SLEVendorListPO.EditValue.ToString & "' "
        End If

        If Not SLEPONumber.EditValue.ToString = "0" Then 'id po
            query_where += " AND po.id_purc_order='" & SLEPONumber.EditValue.ToString & "' "
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.`id_purc_order`,po.`id_expense_type`,reqd.`id_b_expense`,reqd.`id_b_expense_opex`,pod.qty AS qty_po,SUM(IFNULL(recd.qty,0.00)) AS qty_rec,IF(pod.is_drop='1','Closed',IF(SUM(IFNULL(recd.qty,0.00))=0,'Waiting',IF(SUM(IFNULL(recd.qty,0.00))<pod.qty,'Partial','Complete'))) AS status_rec,po.date_created,cd.item_cat_detail,po.est_date_receive,po.pay_due_date
,pod.`id_purc_order_det`,po.`purc_order_number`,c.`comp_number`,c.`comp_name`,it.id_item,it.`item_desc`,CONCAT(reqd.item_detail,IF(ISNULL(reqd.remark) OR reqd.remark='','',CONCAT('\r\n',reqd.remark))) AS item_detail,pod.`value`,(pod.`qty`*pod.`value`) AS tot_value
FROM tb_purc_order_det pod
INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status` = 6 AND po.`is_close_rec`='2'
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
INNER JOIN tb_item it ON it.`id_item`=reqd.`id_item`
INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=it.`id_item_cat`
INNER JOIN tb_item_cat_detail cd ON cd.id_item_cat_detail=it.id_item_cat_detail
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN tb_purc_rec_det recd ON recd.id_purc_order_det=pod.id_purc_order_det
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec AND rec.id_report_status!=5
WHERE req.`id_report_status` = 6 AND reqd.`is_unable_fulfill` = '2' " & query_where & " 
GROUP BY pod.id_purc_order_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOItem.DataSource = data
        GVPOItem.BestFitColumns()
    End Sub

    Private Sub BViewPOItem_Click(sender As Object, e As EventArgs) Handles BViewPOItem.Click
        load_list_item_po()
    End Sub

    Private Sub BBCloseReceiving_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDropPOItem.ItemClick
        GVPOItem.ActiveFilterString = "[is_check]='yes' AND [status_rec]='Waiting'"
        If GVPOItem.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Apakah anda yakin ingin membatalkan item tersebut?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim id_det As String = ""
                Dim q_opex As String = ""
                Dim q_capex As String = ""

                For i As Integer = 0 To GVPOItem.RowCount - 1
                    If Not id_det = "" Then
                        id_det += ","
                    End If
                    id_det += GVPOItem.GetRowCellValue(i, "id_purc_order_det").ToString

                    If GVPOItem.GetRowCellValue(i, "id_expense_type").ToString = "1" Then
                        'opex
                        If Not q_opex = "" Then
                            q_opex += ","
                        End If
                        q_opex += "('" & GVPOItem.GetRowCellValue(i, "id_b_expense_opex").ToString & "',NOW(),'-" & decimalSQL(GVPOItem.GetRowCellValue(i, "tot_value").ToString) & "','" & GVPOItem.GetRowCellValue(i, "id_purc_order").ToString & "','139','Cancel order item')"
                    Else
                        'capex
                        If Not q_capex = "" Then
                            q_capex += ","
                        End If
                        q_capex += "('" & GVPOItem.GetRowCellValue(i, "id_b_expense").ToString & "',NOW(),'-" & decimalSQL(GVPOItem.GetRowCellValue(i, "tot_value").ToString) & "','" & GVPOItem.GetRowCellValue(i, "id_purc_order").ToString & "','202','Cancel order item')"
                    End If
                Next
                '
                If Not id_det = "" Then
                    Dim query As String = ""
                    'close
                    query = "UPDATE tb_purc_order_det SET is_drop='1' WHERE id_purc_order_det IN (" & id_det & ")"
                    execute_non_query(query, True, "", "", "", "")
                    'budget remove
                    'opex
                    If Not q_opex = "" Then
                        query = "INSERT INTO tb_b_expense_opex_trans(id_b_expense_opex,date_trans,value,id_report,report_mark_type,note) VALUES " & q_opex
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    'capex
                    If Not q_capex = "" Then
                        query = "INSERT INTO tb_b_expense_trans(id_b_expense,date_trans,value,id_report,report_mark_type,note) VALUES " & q_capex
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    load_list_item_po()
                End If
            End If
        Else
            stopCustom("Pilih item terlebih dahulu, hanya status receiving 'Waiting' yang akan diproses.")
        End If
        GVPOItem.ActiveFilterString = ""
    End Sub

    Private Sub CloseReceivingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseReceivingToolStripMenuItem.Click
        Dim selected_id As String = GVPO.GetFocusedRowCellValue("id_purc_order").ToString

        Dim query As String = "SELECT IFNULL(SUM(IF(id_report_status NOT IN (5, 6), 1, 0)), 0) AS report_0, IFNULL(SUM(IF(id_report_status = 6, 1, 0)), 0) AS report_6, IFNULL(SUM(IF(id_report_status = 5, 1, 0)), 0) AS report_5 FROM tb_purc_rec WHERE id_purc_order = " + selected_id

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If Not data.Rows(0)("report_0").ToString = "0" Then
            stopCustom("Please complete all receiving.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close receiving ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_pay As String = If(data.Rows(0)("report_6").ToString = "0", ", is_close_pay = 1", "")

                Dim query_update As String = "UPDATE tb_purc_order SET is_close_rec = 1" + query_pay + " WHERE id_purc_order = " + selected_id

                execute_non_query(query_update, True, "", "", "", "")

                'reverse budget
                Dim query_budget As String = ""

                If GVPO.GetFocusedRowCellValue("id_expense_type").ToString = "1" Then
                    'opex
                    query_budget = "
                        INSERT INTO tb_b_expense_opex_trans (id_b_expense_opex, id_departement, date_trans, `value`, id_item, id_report, report_mark_type, note)
                        SELECT *
                        FROM (
	                        SELECT p_det.id_b_expense_opex, p.id_departement, NOW() AS date_trans, (IFNULL(r.qty, 0) * o_det.value) - (o_det.qty * o_det.value) AS `value`, p_det.id_item, o_det.id_purc_order AS id_report, 202 AS report_mark_type, 'Close Receiving Reverse' AS note
	                        FROM tb_purc_order_det AS o_det
	                        LEFT JOIN tb_purc_req_det AS p_det ON o_det.id_purc_req_det = p_det.id_purc_req_det
	                        LEFT JOIN tb_purc_req AS p ON p_det.id_purc_req = p.id_purc_req
	                        LEFT JOIN (
		                        SELECT r_det.id_purc_order_det, r_det.qty
		                        FROM tb_purc_rec_det AS r_det
		                        LEFT JOIN tb_purc_rec AS r ON r_det.id_purc_rec = r.id_purc_rec
		                        WHERE r.id_report_status = 6
	                        ) AS r ON o_det.id_purc_order_det = r.id_purc_order_det
	                        WHERE o_det.id_purc_order = " + selected_id + "
                        ) AS tb
                        WHERE `value` < 0
                    "
                Else
                    'capex
                    query_budget = "
                        INSERT INTO tb_b_expense_trans (id_b_expense, id_departement, date_trans, `value`, id_item, id_report, report_mark_type, note)
                        SELECT *
                        FROM (
	                        SELECT p_det.id_b_expense, p.id_departement, NOW() AS date_trans, (IFNULL(r.qty, 0) * o_det.value) - (o_det.qty * o_det.value) AS `value`, p_det.id_item, o_det.id_purc_order AS id_report, 139 AS report_mark_type, 'Close Receiving Reverse' AS note
	                        FROM tb_purc_order_det AS o_det
	                        LEFT JOIN tb_purc_req_det AS p_det ON o_det.id_purc_req_det = p_det.id_purc_req_det
	                        LEFT JOIN tb_purc_req AS p ON p_det.id_purc_req = p.id_purc_req
	                        LEFT JOIN (
		                        SELECT r_det.id_purc_order_det, r_det.qty
		                        FROM tb_purc_rec_det AS r_det
		                        LEFT JOIN tb_purc_rec AS r ON r_det.id_purc_rec = r.id_purc_rec
		                        WHERE r.id_report_status = 6
	                        ) AS r ON o_det.id_purc_order_det = r.id_purc_order_det
	                        WHERE o_det.id_purc_order = " + selected_id + "
                        ) AS tb
                        WHERE `value` < 0
                    "
                End If

                execute_non_query(query_budget, True, "", "", "", "")

                load_po()

                GVPO.FocusedRowHandle = find_row(GVPO, "id_purc_order", selected_id)
            End If
        End If
    End Sub

    Private Sub GVPO_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVPO.PopupMenuShowing
        If GVPO.GetFocusedRowCellValue("id_report_status").ToString = "6" And GVPO.GetFocusedRowCellValue("is_close_rec").ToString = "2" Then
            CloseReceivingToolStripMenuItem.Visible = True
        Else
            CloseReceivingToolStripMenuItem.Visible = False
        End If

        CloseReceivingToolStripMenuItem.Visible = False
    End Sub

    Private Sub SBCreateNewClose_Click(sender As Object, e As EventArgs) Handles SBCreateNewClose.Click
        FormPurcOrderCloseReceiving.change_type = "close"
        FormPurcOrderCloseReceiving.id_close_receiving = "0"

        FormPurcOrderCloseReceiving.ShowDialog()
    End Sub

    Sub load_close_receiving()
        GCCloseReceiving.DataSource = execute_query("
            SELECT c.id_close_receiving, c.number, GROUP_CONCAT(p.purc_order_number SEPARATOR ', ') AS purc_order_number, DATE_FORMAT(c.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, l.report_status
            FROM tb_purc_order_close_det AS cd
            LEFT JOIN tb_purc_order AS p ON cd.id_purc_order = p.id_purc_order
            LEFT JOIN tb_purc_order_close AS c ON cd.id_close_receiving = c.id_close_receiving
            LEFT JOIN tb_lookup_report_status AS l ON c.id_report_status = l.id_report_status
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            GROUP BY cd.id_close_receiving
            ORDER BY cd.id_close_receiving DESC
        ", -1, True, "", "", "", "")

        GVCloseReceiving.BestFitColumns()
    End Sub

    Sub load_receive_date()
        GCReceiveDate.DataSource = execute_query("
            SELECT m.id_receive_date, m.number, GROUP_CONCAT(p.purc_order_number SEPARATOR ', ') AS purc_order_number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, e.employee_name AS created_by, l.report_status
            FROM tb_purc_order_move_date_det AS md
            LEFT JOIN tb_purc_order AS p ON md.id_purc_order = p.id_purc_order
            LEFT JOIN tb_purc_order_move_date AS m ON md.id_receive_date = m.id_receive_date
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            LEFT JOIN tb_m_employee AS e ON m.created_by = e.id_employee
            GROUP BY md.id_receive_date
            ORDER BY md.id_receive_date DESC
        ", -1, True, "", "", "", "")

        GVReceiveDate.BestFitColumns()
    End Sub

    Private Sub XTCPO_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPO.SelectedPageChanged
        If XTCPO.SelectedTabPage.Name = "XTPCloseReceiving" Then
            load_close_receiving()
        ElseIf XTCPO.SelectedTabPage.Name = "XTPReceiveDate" Then
            load_receive_date()
        End If
    End Sub

    Private Sub GVCloseReceiving_DoubleClick(sender As Object, e As EventArgs) Handles GVCloseReceiving.DoubleClick
        FormPurcOrderCloseReceiving.change_type = "close"
        FormPurcOrderCloseReceiving.id_close_receiving = GVCloseReceiving.GetFocusedRowCellValue("id_close_receiving").ToString

        FormPurcOrderCloseReceiving.ShowDialog()
    End Sub

    Private Sub GVReceiveDate_DoubleClick(sender As Object, e As EventArgs) Handles GVReceiveDate.DoubleClick
        FormPurcOrderCloseReceiving.change_type = "move"
        FormPurcOrderCloseReceiving.id_receive_date = GVReceiveDate.GetFocusedRowCellValue("id_receive_date").ToString

        FormPurcOrderCloseReceiving.ShowDialog()
    End Sub

    Private Sub SBReceiveDateCreateNew_Click(sender As Object, e As EventArgs) Handles SBReceiveDateCreateNew.Click
        FormPurcOrderCloseReceiving.change_type = "move"
        FormPurcOrderCloseReceiving.id_receive_date = "0"

        FormPurcOrderCloseReceiving.ShowDialog()
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        load_dep()
    End Sub
End Class