Public Class FormPurcOrder
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    '
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

    Private Sub FormPurcOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        '
        load_dep()
        load_item_cat()
        load_item()
        load_req_type()
        load_match()
        '
        check_menu()
    End Sub

    Sub load_req_type()
        Dim query As String = "SELECT id_purc_req_type,purc_req_type FROM tb_lookup_purc_req_type WHERE is_active='1'"
        viewSearchLookupQuery(SLERequestType, query, "id_purc_req_type", "purc_req_type", "id_purc_req_type")
    End Sub

    Sub load_match()
        Dim query As String = "SELECT '0' AS `id_match`,'All' AS `match`
                                UNION
                                SELECT '1' AS `id_match`,'Match' AS `match`
                                UNION
                                SELECT '2' AS `id_match`,'Not match' AS `match`"
        viewSearchLookupQuery(SLELastPrice, query, "id_match", "match", "id_match")
    End Sub

    Sub load_po()
        Dim where_string As String = ""

        If SLEVendor.EditValue.ToString = "0" Then
            where_string = ""
        Else
            where_string = " WHERE c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name as emp_created,po.last_update,emp_upd.employee_name AS emp_updated FROM tb_purc_order po
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
" & where_string
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 AS id_departement,'All Departement' AS departement 
                                UNION
                                SELECT id_departement,departement FROM tb_m_departement"
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

    Sub load_req()
        GVPurcReq.ActiveFilterString = ""
        Dim query_where As String = ""
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then 'departement
            query_where += " AND dep.id_departement='" & SLEDepartement.EditValue.ToString & "' "
        End If
        '
        If Not SLEItemCat.EditValue.ToString = "0" Then 'category
            query_where += " AND cat.id_item_cat='" & SLEItemCat.EditValue.ToString & "' "
        End If
        '
        If Not SLEItem.EditValue.ToString = "0" Then 'item
            query_where += " AND itm.id_item='" & SLEItem.EditValue.ToString & "' "
        End If
        '
        If Not SLERequestType.EditValue.ToString = "0" Then 'request
            query_where += " AND req.id_purc_req_type='" & SLERequestType.EditValue.ToString & "' "
        End If
        '
        If Not SLELastPrice.EditValue.ToString = "0" Then 'match
            If SLELastPrice.EditValue.ToString = "1" Then
                query_where += " AND itm.latest_price=rd.`value` "
            Else
                query_where += " AND itm.latest_price!=rd.`value` "
            End If
        End If
        '
        Dim query As String = "SELECT '-' AS status_val,req.date_created AS pr_created,dep.`departement`,rd.`id_purc_req_det`,req.`id_purc_req`,req.`purc_req_number`,cat.`item_cat`,itm.`item_desc`,rd.`value` AS val_pr,rd.`qty` AS qty_pr,'no' AS is_check 
                                ,IFNULL(po.qty,0) AS qty_po_created,IFNULL(rec.qty,0.00) AS qty_rec,0.00 AS qty_po,uom.uom,rd.id_item,req.id_purc_req_type,req.id_report_status,typ.purc_req_type,itm.latest_price
                                FROM tb_purc_req_det rd 
                                INNER JOIN tb_purc_req req ON req.id_purc_req=rd.id_purc_req
                                INNER JOIN tb_lookup_purc_req_type typ ON typ.id_purc_req_type=req.id_purc_req_type
                                INNER JOIN tb_item itm ON itm.`id_item`=rd.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                LEFT JOIN 
                                (
	                                SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,pod.`qty` FROM tb_purc_order_det pod
	                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	                                WHERE po.`id_report_status`!='5'
                                )po ON po.id_purc_req_det=rd.`id_purc_req_det`
                                LEFT JOIN 
                                (
	                                SELECT precd.id_purc_order_det,precd.`id_purc_rec_det`,precd.`qty` FROM tb_purc_rec_det precd
	                                INNER JOIN tb_purc_rec prec ON prec.`id_purc_rec`= precd.`id_purc_rec` AND prec.`id_report_status`!='5'
	                                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=precd.`id_purc_order_det`
	                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
                                )rec ON rec.id_purc_order_det=po.`id_purc_order_det`
                                WHERE req.`id_report_status`='6' AND rd.`is_close`='2' " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_po()
    End Sub

    Private Sub SLEItemCat_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItemCat.EditValueChanged
        load_item()
    End Sub

    Private Sub BViewReqList_Click(sender As Object, e As EventArgs) Handles BViewReqList.Click
        load_req()
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        'check first
        Dim is_already_created, is_zero, is_pr_not_match As Boolean

        is_already_created = False
        is_zero = False
        is_pr_not_match = False

        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        If GVPurcReq.RowCount > 0 Then
            'fill Qty
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                GVPurcReq.SetRowCellValue(i, "qty_po", GVPurcReq.GetRowCellValue(i, "qty_pr"))
            Next
            '
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If (GVPurcReq.GetRowCellValue(i, "qty_po_created") > 0) Then
                    'qty PO already not 0
                    is_already_created = True
                    GVPurcReq.SetRowCellValue(i, "status_val", "")
                ElseIf (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "") OrElse (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "0") Then
                    is_zero = True
                ElseIf Not GVPurcReq.GetRowCellValue(i, "val_pr") = GVPurcReq.GetRowCellValue(i, "latest_price") Then
                    is_pr_not_match = True
                End If
            Next
            '
            If is_zero = True Then
                stopCustom("Please make sure qty not zero.")
            ElseIf is_already_created = True Then
                stopCustom("PO already created.")
            ElseIf is_pr_not_match = True Then
                stopCustom("Requested price not updated.")
            Else
                FormPurcOrderDet.is_pick = "1"
                FormPurcOrderDet.ShowDialog()
            End If
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

    Private Sub BFillQty_Click(sender As Object, e As EventArgs) Handles BFillQty.Click
        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        If GVPurcReq.RowCount > 0 Then
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "qty_pr") - GVPurcReq.GetRowCellValue(i, "qty_po_created") > 0 Then
                    GVPurcReq.SetRowCellValue(i, "qty_po", (GVPurcReq.GetRowCellValue(i, "qty_pr") - GVPurcReq.GetRowCellValue(i, "qty_po_created")))
                Else
                    GVPurcReq.SetRowCellValue(i, "is_check", "no")
                End If
                GVPurcReq.ActiveFilterString = ""
                GVPurcReq.ActiveFilterString = "[is_check]='yes'"
            Next
        Else
            warningCustom("Please select item first.")
            GVPurcReq.ActiveFilterString = ""
        End If
    End Sub
End Class