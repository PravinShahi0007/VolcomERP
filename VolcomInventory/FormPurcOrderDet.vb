﻿Public Class FormPurcOrderDet
    Public id_po As String = "-1"
    Public id_vendor_contact As String = "-1"
    '
    Public is_pick As String = "2"
    Public is_view As String = "-1"
    '
    Public is_submit As String = "-1"
    Public id_vendor_tax As String = "-1"
    '
    Public is_not_match_destination As Boolean = False
    '
    Private Sub FormPurcOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub load_form()
        load_report_status()
        load_purc_type()
        load_unit()
        '
        DEDueDate.EditValue = Now
        TETotal.EditValue = 0.00
        TEDiscPercent.EditValue = 0.00
        TEDiscTotal.EditValue = 0.00
        TEVATPercent.EditValue = 0.00
        TEVATValue.EditValue = 0.00
        TEDPPPercent.EditValue = 100

        load_payment_term()
        load_order_term()
        load_ship_via()

        If id_po = "-1" Then 'new
            TEPONumber.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            TECreatedBy.Text = get_user_identify(id_user, "1")
            DEEstReceiveDate.EditValue = Now
            '
            load_det()
            Try
                If is_pick = "1" Then
                    SLEUnit.EditValue = FormPurcOrder.id_coa_tag
                    SLEPurcType.EditValue = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "id_expense_type").ToString

                    For i As Integer = 0 To FormPurcOrder.GVPurcReq.RowCount - 1
                        Dim newRow As DataRow = (TryCast(GCPurcReq.DataSource, DataTable)).NewRow()
                        newRow("id_item") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_item").ToString
                        newRow("departement") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "departement").ToString
                        newRow("id_purc_req_det") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString
                        newRow("purc_req_number") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "purc_req_number").ToString
                        newRow("pr_created") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "pr_created")
                        newRow("item_desc") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                        newRow("uom") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "uom")
                        newRow("qty_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_pr")
                        newRow("val_pr") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "val_pr")
                        If FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_s_rec") < 0 Then
                            newRow("qty_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_s_rec") * -1
                        Else
                            newRow("qty_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "qty_po")
                        End If
                        '
                        newRow("item_detail") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "item_detail").ToString
                        newRow("id_expense_type") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_expense_type").ToString
                        newRow("id_b_expense") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_b_expense").ToString
                        newRow("id_b_expense_opex") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString
                        newRow("id_vendor_type") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "id_vendor_type").ToString
                        newRow("vendor_type") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "vendor_type").ToString
                        '
                        newRow("val_po") = FormPurcOrder.GVPurcReq.GetRowCellValue(i, "latest_price")
                        newRow("discount") = 0.00
                        newRow("discount_percent") = 0.00
                        TryCast(GCPurcReq.DataSource, DataTable).Rows.Add(newRow)
                    Next
                    '
                    If is_not_match_destination = True Then
                        TEShipDestination.Text = "Multiple address"
                        MESHipAddress.Text = "Multiple address"
                    Else
                        TEShipDestination.Text = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "ship_destination").ToString
                        MESHipAddress.Text = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "ship_address").ToString
                    End If

                    MENote.Text = FormPurcOrder.GVPurcReq.GetRowCellValue(0, "note").ToString
                    '
                End If
                'create summary
                load_summary()
                check_budget()
            Catch ex As Exception
                infoCustom(ex.ToString)
            End Try
            BtnPrint.Visible = False
            BAttachment.Visible = False
            BMark.Visible = False
        Else 'edit
            'load header
            Dim query As String = "SELECT po.id_coa_tag,c.comp_name,c.id_tax,tax.tax,c.comp_number,c.address_primary,c.fax,c.email,c.comp_number,po.is_cash_purchase,po.pay_due_date,cc.contact_number,cc.contact_person,po.vat_percent,po.vat_value,emp.employee_name,po.id_payment_purchasing,po.purc_order_number,po.id_comp_contact,po.note,po.est_date_receive,po.date_created,po.created_by,po.id_report_status,po.is_disc_percent,po.disc_percent,po.disc_value 
,po.id_order_term,po.id_shipping_method,po.ship_destination,po.ship_address,po.id_expense_type,po.is_submit,po.dpp_percent,po.dpp_value
FROM tb_purc_order po
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON cc.id_comp=c.`id_comp`
INNER JOIN tb_lookup_tax tax ON tax.id_tax=c.id_tax
INNER JOIN tb_m_user usr ON usr.id_user=po.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE po.id_purc_order='" & id_po & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                SLEUnit.EditValue = data.Rows(0)("id_coa_tag").ToString
                is_submit = data.Rows(0)("is_submit").ToString
                SLEPurcType.EditValue = data.Rows(0)("id_expense_type").ToString
                id_vendor_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                TEVendorAttn.Text = data.Rows(0)("contact_person").ToString
                TEVendorEmail.Text = data.Rows(0)("email").ToString
                TEVendorPhone.Text = data.Rows(0)("contact_number").ToString
                TEVendorFax.Text = data.Rows(0)("fax").ToString
                TEVendorCode.Text = data.Rows(0)("comp_number").ToString
                id_vendor_tax = data.Rows(0)("id_tax").ToString
                '
                If id_vendor_tax = "2" Then
                    TEVATPercent.ReadOnly = False
                    TEDPPPercent.ReadOnly = False
                Else
                    TEVATPercent.ReadOnly = True
                    TEDPPPercent.ReadOnly = True
                End If
                TEPKP.Text = data.Rows(0)("tax").ToString
                '
                TEShipDestination.Text = data.Rows(0)("ship_destination").ToString
                MESHipAddress.Text = data.Rows(0)("ship_address").ToString
                '
                If data.Rows(0)("is_cash_purchase").ToString = "1" Then
                    CECashPurchase.Checked = True
                Else
                    CECashPurchase.Checked = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TEPONumber.Text = data.Rows(0)("purc_order_number")
                TECreatedBy.Text = data.Rows(0)("employee_name").ToString
                'LEPaymentTerm.ItemIndex = LEPaymentTerm.Properties.GetDataSourceRowIndex("id_payment_purchasing", data.Rows(0)("id_payment_purchasing").ToString)
                LEPaymentTerm.EditValue = data.Rows(0)("id_payment_purchasing").ToString
                DEEstReceiveDate.EditValue = data.Rows(0)("est_date_receive")
                DEDueDate.EditValue = data.Rows(0)("pay_due_date")
                '
                MENote.Text = data.Rows(0)("note").ToString

                LEOrderTerm.ItemIndex = LEOrderTerm.Properties.GetDataSourceRowIndex("id_order_term", data.Rows(0)("id_order_term").ToString)
                LEShipVia.ItemIndex = LEShipVia.Properties.GetDataSourceRowIndex("id_shipping_method", data.Rows(0)("id_shipping_method").ToString)
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                load_det()
                load_summary()
                check_budget()

                TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue

                TEDPPPercent.EditValue = data.Rows(0)("dpp_percent")
                TEDPP.EditValue = data.Rows(0)("dpp_value")

                TEVATPercent.EditValue = data.Rows(0)("vat_percent")
                TEVATValue.EditValue = data.Rows(0)("vat_value")

                If data.Rows(0)("is_disc_percent").ToString = "1" Then
                    CEPercent.Checked = True
                    TEDiscPercent.EditValue = data.Rows(0)("disc_percent")
                    TEDiscTotal.EditValue = data.Rows(0)("disc_value")
                Else
                    CEPercent.Checked = False
                    TEDiscPercent.EditValue = 0.00
                    TEDiscTotal.EditValue = data.Rows(0)("disc_value")
                End If

            End If
            '
            BAttachment.Visible = True
            If is_submit = "1" Then
                BtnPrint.Visible = True
                BSubmit.Visible = False
                BMark.Visible = True
                BtnPrint.Visible = True
                '
                TEVendorCode.ReadOnly = True
                BPickVendor.Visible = False
                DEEstReceiveDate.Enabled = False
                LEPaymentTerm.Enabled = False
                '
                CEPercent.Enabled = False
                TEDiscPercent.Enabled = False
                TEDiscTotal.Enabled = False
                TEShipDestination.Enabled = False
                MESHipAddress.Enabled = False
                LEOrderTerm.Enabled = False
                LEShipVia.Enabled = False
                '
                TEVATPercent.Enabled = False
                DEDueDate.Enabled = False
                '
                Dim rmt As String = "-1"
                If SLEPurcType.EditValue.ToString = "1" Then
                    rmt = "139"
                Else
                    rmt = "202"
                End If
                '
                If (Not check_edit_report_status(LEReportStatus.EditValue.ToString, rmt, id_po)) Or is_view = "1" Then
                    MENote.Enabled = False
                    BtnSave.Visible = False
                Else
                    MENote.Enabled = True
                    BtnSave.Visible = True
                End If
                GridColumnBudgetStatus.Visible = False
                PCPrice.Visible = False
            Else 'not yet submitted
                BtnPrint.Visible = False
                BMark.Visible = False
                BSubmit.Visible = True
                GridColumnBudgetStatus.Visible = True
                PCPrice.Visible = True
            End If
        End If
    End Sub

    Sub set_price(ByVal id_item As String, ByVal price As Decimal)
        For i = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.GetRowCellValue(i, "id_item").ToString = id_item Then
                GVPurcReq.SetRowCellValue(i, "val_po", price)
            End If
        Next
        load_summary()
        check_budget()
    End Sub

    Sub set_same_detail_price(ByVal price As Decimal)
        If GVPurcReq.RowCount > 0 Then
            Dim id_item As String = GVPurcReq.GetFocusedRowCellValue("id_item").ToString
            Dim item_detail As String = GVPurcReq.GetFocusedRowCellValue("item_detail").ToString
            For i = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "id_item").ToString = id_item And GVPurcReq.GetRowCellValue(i, "item_detail").ToString = item_detail Then
                    GVPurcReq.SetRowCellValue(i, "val_po", price)
                End If
            Next
        End If
        load_summary()
        check_budget()
    End Sub

    Sub check_budget()
        For i = 0 To GVPurcReq.RowCount - 1
            Dim jml As Decimal = 0
            For j = i To 0 Step -1 'add budget yang sudah terpakai sebelumnya
                If GVPurcReq.GetRowCellValue(i, "id_expense_type").ToString = "1" Then 'opex
                    If GVPurcReq.GetRowCellValue(j, "id_b_expense_opex").ToString = GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString And Not GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString = "" Then
                        jml += GVPurcReq.GetRowCellValue(j, "val_po")
                    End If
                Else 'capex
                    If GVPurcReq.GetRowCellValue(j, "id_b_expense").ToString = GVPurcReq.GetRowCellValue(i, "id_b_expense").ToString And Not GVPurcReq.GetRowCellValue(i, "id_b_expense").ToString = "" Then
                        jml += GVPurcReq.GetRowCellValue(j, "val_po")
                    End If
                End If
            Next

            'check budget
            Dim q_budget As String = ""
            If GVPurcReq.GetRowCellValue(i, "id_expense_type").ToString = "1" Then 'opex
                '                q_budget = "SELECT bdg.value_expense-IFNULL(SUM(bdgu.value),0) AS remaining_budget FROM `tb_b_expense_opex` bdg 
                'LEFT JOIN `tb_b_expense_opex_trans` bdgu ON bdgu.`id_b_expense_opex`=bdg.`id_b_expense_opex`

                'WHERE bdg.`id_b_expense_opex`='" & GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString & "'"
                q_budget = "SELECT bdg.value_expense-IFNULL(SUM(bdgu.value),0)-IFNULL(act.val,0) AS remaining_budget ,IFNULL(SUM(bdgu.value),0) AS used, IFNULL(act.val,0) AS act
FROM `tb_b_expense_opex` bdg 
LEFT JOIN `tb_b_expense_opex_trans` bdgu ON bdgu.`id_b_expense_opex`=bdg.`id_b_expense_opex` 
AND (bdgu.is_po=1 OR (bdgu.`is_po`=2 AND bdgu.`report_mark_type`=148))
LEFT JOIN
(
	SELECT opex.`id_b_expense_opex`,IFNULL(SUM(val.val),0) AS val
	FROM `tb_b_expense_opex` opex 
	INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=opex.`id_item_cat_main` AND opex.`id_b_expense_opex`='" & GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString & "'
	INNER JOIN tb_lookup_expense_type et ON et.`id_expense_type`=icm.`id_expense_type`
	INNER JOIN `tb_b_expense_opex_map` map ON map.`id_b_expense_opex`=opex.`id_b_expense_opex`
	INNER JOIN  tb_a_acc acc ON acc.`id_acc`=map.`id_acc`
	LEFT JOIN
	(
		SELECT acc.`id_acc`,acc.`acc_name`,acc.`acc_description`,SUM(IF(acc.`id_dc`=1,trxd.`debit`-trxd.`credit`,trxd.`credit`-trxd.`debit`)) AS val,acc.`id_coa_type`
		,SUM(IF(trxd.`report_mark_type`='156' OR trxd.`report_mark_type`='166',IF(acc.`id_dc`=1,trxd.`debit`-trxd.`credit`,trxd.`credit`-trxd.`debit`),0)) AS val_del
		FROM tb_a_acc_trans_det trxd
		INNER JOIN tb_a_acc_trans trx ON trx.`id_acc_trans`=trxd.`id_acc_trans` AND YEAR(trx.`date_reference`)=(SELECT `year` FROM tb_b_expense_opex WHERE `id_b_expense_opex`='" & GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString & "')
		INNER JOIN tb_a_acc acc ON acc.`id_acc`=trxd.`id_acc`
		WHERE trx.`id_report_status`=6 
		GROUP BY acc.`id_acc`
	)val ON LEFT(val.acc_name,4)=LEFT(acc.`acc_name`,4) AND acc.`id_coa_type`=val.`id_coa_type`
)act ON act.id_b_expense_opex=bdg.id_b_expense_opex
WHERE bdg.`id_b_expense_opex`='" & GVPurcReq.GetRowCellValue(i, "id_b_expense_opex").ToString & "'"
            Else
                q_budget = "SELECT bdg.value_expense-IFNULL(SUM(bdgu.value),0) AS remaining_budget FROM tb_b_expense bdg 
LEFT JOIN `tb_b_expense_trans` bdgu ON bdgu.`id_b_expense`=bdg.`id_b_expense`
WHERE bdg.`id_b_expense`='" & GVPurcReq.GetRowCellValue(i, "id_b_expense").ToString & "'"
            End If
            '
            Dim dt_budget As DataTable = execute_query(q_budget, -1, True, "", "", "", "")
            If dt_budget.Rows.Count > 0 Then
                If dt_budget.Rows(0)("remaining_budget") >= jml Then
                    GVPurcReq.SetRowCellValue(i, "budget_status", "Budget Ok")
                Else
                    'no budget
                    GVPurcReq.SetRowCellValue(i, "budget_status", "No Budget")
                End If
            Else
                'no budget
                GVPurcReq.SetRowCellValue(i, "budget_status", "No Budget")
            End If
        Next
        but_submit()
    End Sub

    Sub load_report_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub load_summary()
        'delete all row
        For j As Integer = GVSummary.RowCount - 1 To 0 Step -1
            GVSummary.DeleteRow(j)
        Next
        'add all row
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            Dim is_found As Boolean = False
            For k As Integer = 0 To GVSummary.RowCount - 1
                If GVSummary.GetRowCellValue(k, "id_item").ToString = GVPurcReq.GetRowCellValue(i, "id_item").ToString And GVSummary.GetRowCellValue(k, "item_detail").ToString = GVPurcReq.GetRowCellValue(i, "item_detail").ToString Then
                    is_found = True
                    'add qty
                    GVSummary.SetRowCellValue(k, "qty_po", (GVSummary.GetRowCellValue(k, "qty_po") + GVPurcReq.GetRowCellValue(i, "qty_po")))
                End If
            Next
            If is_found = False Then 'add new row
                Dim newRow As DataRow = (TryCast(GCSummary.DataSource, DataTable)).NewRow()
                newRow("no") = (GVSummary.RowCount + 1).ToString
                newRow("id_item") = GVPurcReq.GetRowCellValue(i, "id_item").ToString
                newRow("item_desc") = GVPurcReq.GetRowCellValue(i, "item_desc").ToString
                newRow("item_desc_full") = GVPurcReq.GetRowCellValue(i, "item_desc").ToString & vbNewLine & "Note : " & GVPurcReq.GetRowCellValue(i, "item_detail").ToString
                newRow("item_detail") = GVPurcReq.GetRowCellValue(i, "item_detail").ToString
                newRow("item_type") = GVPurcReq.GetRowCellValue(i, "item_type").ToString
                newRow("uom") = GVPurcReq.GetRowCellValue(i, "uom")
                newRow("qty_po") = GVPurcReq.GetRowCellValue(i, "qty_po")
                '
                newRow("val_po") = GVPurcReq.GetRowCellValue(i, "val_po")
                newRow("discount") = GVPurcReq.GetRowCellValue(i, "discount")
                newRow("discount_percent") = GVPurcReq.GetRowCellValue(i, "discount_percent")
                TryCast(GCSummary.DataSource, DataTable).Rows.Add(newRow)
            End If
        Next
        GVSummary.RefreshData()
        TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue
    End Sub

    Sub load_det()
        is_process = "1"
        Dim query As String = "SELECT pod.`id_item`,icd.item_cat_detail,itt.item_type,IF(pod.budget_status=1,'Budget Ok','No Budget') AS budget_status,CONCAT(prd.item_detail,IF(ISNULL(prd.remark) OR prd.remark='','',CONCAT('\r\n',prd.remark))) AS item_detail,ic.id_expense_type,icd.`id_vendor_type`,prd.id_b_expense,prd.id_b_expense_opex,dep.`departement`,icd.id_item_cat_detail,vt.vendor_type,prd.`id_purc_req_det`,pr.`purc_req_number`,pr.`date_created` AS pr_created,item.`item_desc`,uom.`uom`,prd.`qty` AS qty_pr,prd.`value` AS val_pr,pod.`qty` AS qty_po,pod.`value` AS val_po,pod.`discount`,pod.`discount_percent`
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=pr.`id_departement`
                                INNER JOIN `tb_item` item ON item.`id_item`=pod.`id_item`
                                INNER JOIN tb_lookup_purc_item_type itt ON itt.id_item_type=item.id_item_type
                                INNER JOIN `tb_item_cat` ic ON item.`id_item_cat`=ic.`id_item_cat`
                                INNER JOIN tb_item_cat_detail icd ON icd.`id_item_cat_detail`=item.`id_item_cat_detail`
                                INNER JOIN tb_vendor_type vt ON vt.id_vendor_type=icd.id_vendor_type
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
                                WHERE pod.`id_purc_order`='" & id_po & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()

        'summary_query
        Dim query_sum As String = "SELECT '' AS no,'' AS id_item,'' AS item_type,'' AS item_desc,'' AS item_desc_full,'' AS item_detail,0.00 AS qty_po,0.00 AS discount,'' AS uom,0.00 AS val_po,0.00 as discount_percent,0.00 as discount"
        Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
        GCSummary.DataSource = data_sum
        is_process = "2"
    End Sub

    Sub load_payment_term()
        Dim query As String = "SELECT id_payment_purchasing,payment_purchasing,val_day,is_can_cash_purchase,is_only_cash_purchase FROM `tb_lookup_payment_purchasing` WHERE is_active='1'"
        viewSearchLookupQuery(LEPaymentTerm, query, "id_payment_purchasing", "payment_purchasing", "id_payment_purchasing")
        LEPaymentTerm.EditValue = Nothing
    End Sub

    Sub load_order_term()
        Dim query As String = "SELECT id_order_term,order_term FROM `tb_lookup_purc_order_term` WHERE is_active='1'"
        viewLookupQuery(LEOrderTerm, query, 0, "order_term", "id_order_term")
    End Sub

    Sub load_ship_via()
        Dim query As String = "SELECT id_shipping_method,shipping_method FROM `tb_lookup_shipping_method` WHERE is_active='1'"
        viewLookupQuery(LEShipVia, query, 0, "shipping_method", "id_shipping_method")
    End Sub

    Private Sub FormPurcOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_purc_type()
        Dim query As String = "SELECT id_expense_type,expense_type FROM `tb_lookup_expense_type`"
        viewSearchLookupQuery(SLEPurcType, query, "id_expense_type", "expense_type", "id_expense_type")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim rmt As String = "-1"
        Dim is_cash_purchase As String = "1"

        If CECashPurchase.Checked = True Then
            is_cash_purchase = "1"
        Else
            is_cash_purchase = "2"
        End If

        If SLEPurcType.EditValue.ToString = "1" Then
            rmt = "139" 'opex
        Else
            rmt = "202" 'capex
        End If

        If id_po = "-1" Then 'new
            If GVSummary.RowCount = 0 Then
                warningCustom("Please make sure item listed")
            ElseIf LEPaymentTerm.Text = "" Then
                warningCustom("Please put your payment term")
            ElseIf id_vendor_contact = "-1" Then
                warningCustom("Please make sure vendor already selected")
            ElseIf TETotal.EditValue = 0 Then
                warningCustom("Please make sure item price listed")
            ElseIf id_vendor_contact = "-1" Then
                warningCustom("Please input vendor")
            ElseIf TEVATPercent.EditValue = 0 And TEVATPercent.Properties.ReadOnly = False Then
                warningCustom("Please input tax percent")
            ElseIf id_vendor_contact = "1352" And is_cash_purchase = "2" Then
                warningCustom("Cash purchase need to be checked.")
            ElseIf is_cash_purchase = "1" And Not id_vendor_contact = "1352" Then
                warningCustom("Please use vendor cash purchase.")
            Else
                'header
                Dim is_check As String = "1"
                If CEPercent.Checked = True Then
                    is_check = "1"
                Else
                    is_check = "2"
                End If

                Dim query As String = "INSERT INTO `tb_purc_order`(`id_coa_tag`,`id_comp_contact`,is_cash_purchase,id_payment_purchasing,`note`,`date_created`,est_date_receive,pay_due_date,`created_by`,`last_update`,`last_update_by`,`id_report_status`,is_disc_percent,disc_percent,disc_value,dpp_percent,dpp_value,vat_percent,vat_value,ship_destination,ship_address,id_expense_type)
                                    VALUES('" & SLEUnit.EditValue.ToString & "','" & id_vendor_contact & "','" & is_cash_purchase & "','" & LEPaymentTerm.EditValue.ToString & "','" & addSlashes(MENote.Text) & "',NOW(),'" & Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & id_user & "',NOW(),'" & id_user & "','1','" & is_check & "','" & decimalSQL(TEDiscPercent.EditValue.ToString) & "','" & decimalSQL(TEDiscTotal.EditValue.ToString) & "','" & decimalSQL(TEDPPPercent.EditValue.ToString) & "','" & decimalSQL(TEDPP.EditValue.ToString) & "','" & decimalSQL(TEVATPercent.EditValue.ToString) & "','" & decimalSQL(TEVATValue.EditValue.ToString) & "','" & addSlashes(TEShipDestination.Text) & "','" & addSlashes(MESHipAddress.Text) & "','" & SLEPurcType.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                id_po = execute_query(query, 0, True, "", "", "", "")

                'detail
                For i As Integer = 0 To GVPurcReq.RowCount - 1
                    Dim budget_status As String = "2"

                    If GVPurcReq.GetRowCellValue(i, "budget_status").ToString = "Budget Ok" Then
                        budget_status = "1"
                    Else
                        budget_status = "2"
                    End If

                    query = "INSERT INTO `tb_purc_order_det`(`id_purc_order`,`id_item`,`id_purc_req_det`,`qty`,`value`,`discount_percent`,`discount`,budget_status)
                        VALUES('" & id_po & "','" & GVPurcReq.GetRowCellValue(i, "id_item").ToString & "','" & GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "qty_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "val_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount_percent").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount").ToString) & "','" & budget_status & "')"
                    execute_non_query(query, True, "", "", "", "")
                Next
                '
                FormPurcOrder.load_req()
                infoCustom("Order Created")
                load_form()
            End If
        Else 'edit
            If is_submit = "1" Then
                Dim query As String = "UPDATE `tb_purc_order` SET `note`='" & addSlashes(MENote.Text) & "' WHERE id_purc_order='" & id_po & "'"
                execute_non_query(query, True, "", "", "", "")
            Else
                'still draft
                Dim is_check As String = "1"

                If CEPercent.Checked = True Then
                    is_check = "1"
                Else
                    is_check = "2"
                End If

                Dim query As String = "UPDATE `tb_purc_order` SET 
                                        `id_comp_contact`='" & id_vendor_contact & "',
                                        id_payment_purchasing='" & LEPaymentTerm.EditValue.ToString & "',
                                        `note`='" & addSlashes(MENote.Text) & "',
                                        est_date_receive='" & Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',
                                        pay_due_date='" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',
                                        `last_update`=NOW(),
                                        `last_update_by`='" & id_user & "',
                                        is_disc_percent='" & is_check & "',
                                        disc_percent='" & decimalSQL(TEDiscPercent.EditValue.ToString) & "',
                                        disc_value='" & decimalSQL(TEDiscTotal.EditValue.ToString) & "',
                                        dpp_percent='" & decimalSQL(TEDPPPercent.EditValue.ToString) & "',
                                        dpp_value='" & decimalSQL(TEDPP.EditValue.ToString) & "',
                                        vat_percent='" & decimalSQL(TEVATPercent.EditValue.ToString) & "',
                                        vat_value='" & decimalSQL(TEVATValue.EditValue.ToString) & "',
                                        ship_destination='" & addSlashes(TEShipDestination.Text) & "',
                                        ship_address='" & addSlashes(MESHipAddress.Text) & "'
                                        WHERE id_purc_order='" & id_po & "'"
                execute_non_query(query, True, "", "", "", "")

                'delete detail
                query = "DELETE FROM tb_purc_order_det WHERE id_purc_order='" & id_po & "'"
                execute_non_query(query, True, "", "", "", "")

                'detail
                For i As Integer = 0 To GVPurcReq.RowCount - 1
                    Dim budget_status As String = "2"

                    If GVPurcReq.GetRowCellValue(i, "budget_status").ToString = "Budget Ok" Then
                        budget_status = "1"
                    Else
                        budget_status = "2"
                    End If

                    query = "INSERT INTO `tb_purc_order_det`(`id_purc_order`,`id_item`,`id_purc_req_det`,`qty`,`value`,`discount_percent`,`discount`,budget_status)
                        VALUES('" & id_po & "','" & GVPurcReq.GetRowCellValue(i, "id_item").ToString & "','" & GVPurcReq.GetRowCellValue(i, "id_purc_req_det").ToString & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "qty_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "val_po").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount_percent").ToString) & "','" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount").ToString) & "','" & budget_status & "')"
                    execute_non_query(query, True, "", "", "", "")
                Next
            End If

            infoCustom("Order Updated")
            load_form()
        End If
    End Sub

    Private Sub BPickVendor_Click(sender As Object, e As EventArgs) Handles BPickVendor.Click
        FormPopUpContact.id_pop_up = "86"
        FormPopUpContact.id_cat = "1,8,7"
        FormPopUpContact.is_must_active = "1"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If SLEPurcType.EditValue.ToString = "1" Then
            FormReportMark.report_mark_type = "139" 'opex
        Else
            FormReportMark.report_mark_type = "202" 'capex
        End If

        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_po
        FormReportMark.ShowDialog()
    End Sub

    Dim is_process As String = "2"

    Sub calc_total(ByVal rowhandle As Integer, ByVal opt As String)
        is_process = "1"
        'opt
        If opt = "1" Then
            '1 = from percentage
            Dim disc_prcent As Decimal = 0.00
            Dim val As Decimal = 0.00
            Dim disc As Decimal = 0.00
            Dim qty As Decimal = 0.00
            Dim subtot As Decimal = 0.00

            val = GVSummary.GetRowCellValue(rowhandle, "val_po")
            disc_prcent = GVSummary.GetRowCellValue(rowhandle, "discount_percent")
            qty = GVSummary.GetRowCellValue(rowhandle, "qty_po")
            disc = ((val * disc_prcent) / 100)
            subtot = (val - disc) * qty
            '
            GVSummary.SetRowCellValue(rowhandle, "discount", disc)
            GVSummary.SetRowCellValue(rowhandle, "sub_total", subtot)
            GVSummary.RefreshData()
            '
        ElseIf opt = "2" Then
            '2 = from value
            Dim disc_prcent As Decimal = 0.00
            Dim val As Decimal = 0.00
            Dim disc As Decimal = 0.00
            Dim qty As Decimal = 0.00
            Dim subtot As Decimal = 0.00

            val = GVSummary.GetRowCellValue(rowhandle, "val_po")
            qty = GVSummary.GetRowCellValue(rowhandle, "qty_po")
            disc = GVSummary.GetRowCellValue(rowhandle, "discount")
            subtot = (val - disc) * qty
            '
            GVSummary.SetRowCellValue(rowhandle, "discount_percent", 0.00)
            GVSummary.SetRowCellValue(rowhandle, "sub_total", subtot)
            GVSummary.RefreshData()
        End If
        '
        TETotal.EditValue = GVSummary.Columns("sub_total").SummaryItem.SummaryValue
        '
        is_process = "2"
    End Sub

    Sub but_submit()
        Dim is_ok_budget As Boolean = True

        'check first all budget ok
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If Not GVPurcReq.GetRowCellValue(i, "budget_status").ToString = "Budget Ok" Then
                is_ok_budget = False
                Exit For
            End If
        Next

        If is_ok_budget And is_submit = "2" Then
            BSubmit.Visible = True
        Else
            BSubmit.Visible = False
        End If
    End Sub

    Private Sub TEVendorCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendorCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim max_vendor_type As Integer = 1
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "id_vendor_type") > max_vendor_type Then
                    max_vendor_type = GVPurcReq.GetRowCellValue(i, "id_vendor_type")
                End If
            Next

            Dim query As String = "SELECT c.*,cc.*,tax.tax FROM tb_m_comp c
                                    INNER JOIN 
                                    (
	                                    SELECT cc.`id_comp_contact`,cc.`contact_person`,cc.`contact_number`,cc.`id_comp` FROM tb_m_comp_contact cc 
	                                    WHERE cc.`is_default`='1'
	                                    GROUP BY cc.`id_comp`
                                    )cc ON cc.id_comp=c.`id_comp`
                                    INNER JOIN tb_lookup_tax tax ON tax.id_tax=c.id_tax
                                    WHERE (c.id_comp_cat='8' or c.id_comp_cat='1') AND c.is_active='1'
                                    AND c.comp_number='" & TEVendorCode.Text & "' "
            query += " AND c.id_vendor_type >= '" & max_vendor_type.ToString & "' "

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count < 1 Then
                stopCustom("Vendor not found or Vendor not meet minimum requirement (vendor type).")
                TEVendorCode.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "86"
                FormPopUpContact.id_cat = "1"
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TEVendorCode.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_vendor_contact = data.Rows(0)("id_comp_contact").ToString
                id_vendor_tax = data.Rows(0)("id_tax").ToString
                If id_vendor_tax = "2" Then
                    TEVATPercent.ReadOnly = False
                Else
                    TEVATPercent.ReadOnly = True
                End If
                TEPKP.Text = data.Rows(0)("tax").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                '
                TEVendorAttn.Text = data.Rows(0)("contact_person").ToString
                TEVendorEmail.Text = data.Rows(0)("email").ToString
                TEVendorPhone.Text = data.Rows(0)("contact_number").ToString
                TEVendorFax.Text = data.Rows(0)("fax").ToString
            End If
        End If
    End Sub

    Private Sub TEDiscPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEDiscPercent.EditValueChanged
        If CEPercent.Checked = True Then
            TEDiscTotal.EditValue = (TETotal.EditValue * TEDiscPercent.EditValue) / 100
            calculate_grand_total()
        End If
    End Sub

    Private Sub TEDiscTotal_EditValueChanged(sender As Object, e As EventArgs) Handles TEDiscTotal.EditValueChanged
        If CEPercent.Checked = False Then
            TEDiscPercent.EditValue = 0.00
            calculate_grand_total()
        End If
    End Sub

    Sub calculate_percent()
        If CEPercent.Checked = True Then
            TEDiscTotal.EditValue = (TETotal.EditValue * TEDiscPercent.EditValue) / 100
            calculate_grand_total()
        Else
            TEDiscPercent.EditValue = 0.00
            calculate_grand_total()
        End If
    End Sub

    Sub calculate_grand_total()
        Try
            TEDPP.EditValue = (TETotal.EditValue - TEDiscTotal.EditValue) * (TEDPPPercent.EditValue / 100)
            TEVATValue.EditValue = TEDPP.EditValue * (TEVATPercent.EditValue / 100)
            TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue
        Catch ex As Exception
            TEGrandTotal.EditValue = 0.00
        End Try
    End Sub

    Private Sub CEPercent_CheckedChanged(sender As Object, e As EventArgs) Handles CEPercent.CheckedChanged
        If CEPercent.Checked = True Then
            'use percent
            TEDiscPercent.Enabled = True
            TEDiscTotal.Enabled = False
        Else
            'use value
            TEDiscPercent.Enabled = False
            TEDiscTotal.Enabled = True
        End If
    End Sub

    Private Sub TETotal_EditValueChanged(sender As Object, e As EventArgs) Handles TETotal.EditValueChanged
        calculate_percent()
        calculate_grand_total()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim rmt As String = ""
        If SLEPurcType.EditValue.ToString = "1" Then
            rmt = "139" 'opex
        Else
            rmt = "202" 'capex
        End If

        If Not check_allow_print(LEReportStatus.EditValue.ToString, rmt, id_po) Then
            warningCustom("Can't print, please complete internal approval on system first")
        Else
            Cursor = Cursors.WaitCursor
            ReportPurcOrder.id_po = id_po
            ReportPurcOrder.dt = GCSummary.DataSource
            Dim Report As New ReportPurcOrder()
            If SLEPurcType.EditValue.ToString = "1" Then
                Report.rmt = "139" 'opex
            Else
                Report.rmt = "202" 'capex
            End If

            ' ...
            ' creating and saving the view's layout to a new memory stream 
            '
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVSummary.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVSummary.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVSummary)
            '
            Report.GVSummary.BestFitColumns()
            'Parse val
            If CECashPurchase.Checked = True Then
                Report.LCashPurchase.Text = "yes"
            Else
                Report.LCashPurchase.Text = "no"
            End If
            Report.Lunit.Text = SLEUnit.Text
            Report.LPONumber.Text = TEPONumber.Text
            Report.LTOP.Text = LEPaymentTerm.Text.ToUpper
            Report.LDateCreated.Text = Date.Parse(DEDateCreated.EditValue.ToString).ToString("dd MMMM yyyy")
            Report.LEtaDate.Text = Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper
            Report.LTermOrder.Text = LEOrderTerm.Text.ToUpper
            Report.LShipVia.Text = LEShipVia.Text.ToUpper
            Report.LDueDate.Text = Date.Parse(DEDueDate.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper
            Report.LTerbilang.Text = ConvertCurrencyToIndonesian(Decimal.Parse(TEGrandTotal.EditValue.ToString))
            Report.LSpecialInstruction.Text = MENote.Text
            '
            Report.LTotal.Text = TETotal.Text
            Report.LDiscount.Text = TEDiscTotal.Text
            Report.LVat.Text = TEVATValue.Text
            Report.LGrandTotal.Text = TEGrandTotal.Text
            'Report.LNote.Text = MENote.Text
            '
            Report.LabelAttn.Text = TEVendorAttn.Text
            Report.LTo.Text = TEVendorName.Text
            Report.LToAdress.Text = MEAdrressCompTo.Text
            Report.LPhone.Text = TEVendorPhone.Text
            Report.LEmail.Text = TEVendorEmail.Text
            '
            Dim query As String = "SELECT pr.purc_req_number,dep.departement
                                FROM tb_purc_order_det pod
                                INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=pr.`id_departement`
                                INNER JOIN `tb_item` item ON item.`id_item`=pod.`id_item`
                                INNER JOIN `tb_item_cat` ic ON item.`id_item_cat`=ic.`id_item_cat`
                                INNER JOIN tb_item_cat_detail icd ON icd.`id_item_cat_detail`=item.`id_item_cat_detail`
                                INNER JOIN tb_vendor_type vt ON vt.id_vendor_type=icd.id_vendor_type
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
                                WHERE pod.`id_purc_order`='" & id_po & "' GROUP BY pr.id_purc_req"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i = 0 To data.Rows.Count - 1
                If i > 0 Then
                    Report.LPrNo.Text += ", "
                End If
                Report.LPrNo.Text += data.Rows(i)("purc_req_number").ToString & " (" & data.Rows(i)("departement").ToString & ")"
            Next
            '
            Report.LBillTo.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "1")
            Report.LBillAddress.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "3")

            Report.LShipTo.Text = TEShipDestination.Text
            Report.LShipToAddress.Text = MESHipAddress.Text

            If Not LEReportStatus.EditValue = "6" Then
                Report.id_pre = "2"
            Else
                Report.id_pre = "1"
            End If

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TEVATPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVATPercent.EditValueChanged
        Try
            calculate_grand_total()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSetPrice_Click(sender As Object, e As EventArgs) Handles BSetPrice.Click
        If GVPurcReq.RowCount > 0 Then
            FormPurcItemDet.id_item = GVPurcReq.GetFocusedRowCellValue("id_item").ToString
            FormPurcItemDet.is_view = "1"
            FormPurcItemDet.ShowDialog()
        Else
            stopCustom("No item selected")
        End If
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        'insert to expense trans
        Dim rmt As String = "-1"
        Dim is_ok_budget As Boolean = True

        'check first all budget ok
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If Not GVPurcReq.GetRowCellValue(i, "budget_status").ToString = "Budget Ok" Then
                is_ok_budget = False
                Exit For
            End If
        Next

        If is_ok_budget Then
            If SLEPurcType.EditValue.ToString = "1" Then
                rmt = "139" 'opex
            Else
                rmt = "202" 'capex
            End If

            'generate number
            Dim query As String = "CALL gen_number('" & id_po & "','" & rmt & "')"
            execute_non_query(query, True, "", "", "", "")

            Dim query_trans As String = ""
            If rmt = "139" Then 'opex
                query_trans = "INSERT INTO `tb_b_expense_opex_trans`(id_b_expense_opex,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note) 
                                SELECT prd.id_b_expense_opex,pr.id_departement,NOW(),(pod.`value` * pod.qty),prd.id_item,pod.`id_purc_order` AS id_report,'139' AS report_mark_type,'Purchase Order'
                                FROM `tb_purc_order_det` pod
                                INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.id_purc_req=prd.id_purc_req
                                WHERE pod.`id_purc_order`='" & id_po & "'"
            Else 'capex
                query_trans = "INSERT INTO `tb_b_expense_trans`(id_b_expense,id_departement,date_trans,`value`,id_item,id_report,report_mark_type,note) 
                                SELECT prd.id_b_expense,pr.id_departement,NOW(),(pod.`value` * pod.qty),prd.id_item,pod.`id_purc_order` AS id_report,'202' AS report_mark_type,'Purchase Order'
                                FROM `tb_purc_order_det` pod
                                INNER JOIN `tb_purc_req_det` prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
                                INNER JOIN tb_purc_req pr ON pr.id_purc_req=prd.id_purc_req
                                WHERE pod.`id_purc_order`='" & id_po & "'"
            End If
            '
            execute_non_query(query_trans, True, "", "", "", "")
            submit_who_prepared(rmt, id_po, id_user)

            query = "UPDATE tb_purc_order SET is_submit='1',report_mark_type='" & rmt & "' WHERE id_purc_order='" & id_po & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            load_form()
        Else
            warningCustom("Please make sure all budget is Ok")
        End If
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor

        Dim rmt As String = "-1"
        If SLEPurcType.EditValue.ToString = "1" Then
            rmt = "139" 'opex
        Else
            rmt = "202" 'capex
        End If

        FormDocumentUpload.id_report = id_po
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LEPaymentTerm_EditValueChanged(sender As Object, e As EventArgs) Handles LEPaymentTerm.EditValueChanged
        Try
            Dim val_day As Integer = 0
            val_day = LEPaymentTerm.Properties.View.GetFocusedRowCellValue("val_day")
            DEDueDate.EditValue = DateAdd(DateInterval.Day, val_day, Date.Parse(DEDateCreated.EditValue.ToString))
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub TEDPPPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEDPPPercent.EditValueChanged
        Try
            calculate_grand_total()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LEPaymentTerm_Click(sender As Object, e As EventArgs) Handles LEPaymentTerm.Click
        If CECashPurchase.EditValue Then
            LEPaymentTermView.ActiveFilterString = "[is_can_cash_purchase] = '1'"
        Else
            LEPaymentTermView.ActiveFilterString = "[is_only_cash_purchase] = '2'"
        End If
    End Sub

    Private Sub CECashPurchase_EditValueChanged(sender As Object, e As EventArgs) Handles CECashPurchase.EditValueChanged
        Try
            If CECashPurchase.EditValue And LEPaymentTermView.GetFocusedRowCellValue("is_can_cash_purchase").ToString = "2" Then
                LEPaymentTerm.EditValue = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class