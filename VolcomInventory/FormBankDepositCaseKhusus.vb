Public Class FormBankDepositCaseKhusus
    Private Sub FormBankDepositCaseKhusus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        load_vendor_po()
        load_status_payment()
        viewDK()
        TxtAmount.EditValue = 0.00
    End Sub

    Private Sub FormBankDepositCaseKhusus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If GVInvoiceList.RowCount > 0 And GVInvoiceList.FocusedRowHandle >= 0 And TxtAmount.EditValue > 0 Then
            Cursor = Cursors.WaitCursor
            Dim amo As Decimal = TxtAmount.EditValue

            Dim newRow As DataRow = (TryCast(FormBankDepositDet.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = GVInvoiceList.GetFocusedRowCellValue("id_sales_pos").ToString
            newRow("id_report_det") = "0"
            newRow("report_mark_type") = GVInvoiceList.GetFocusedRowCellValue("report_mark_type").ToString
            newRow("report_mark_type_name") = GVInvoiceList.GetFocusedRowCellValue("report_mark_type_name").ToString
            newRow("number") = GVInvoiceList.GetFocusedRowCellValue("sales_pos_number").ToString
            newRow("id_comp") = GVInvoiceList.GetFocusedRowCellValue("id_comp").ToString
            newRow("vendor") = GVInvoiceList.GetFocusedRowCellValue("comp_number").ToString
            newRow("id_acc") = GVInvoiceList.GetFocusedRowCellValue("id_acc").ToString
            newRow("acc_name") = GVInvoiceList.GetFocusedRowCellValue("acc_name").ToString
            newRow("acc_description") = GVInvoiceList.GetFocusedRowCellValue("acc_description").ToString
            newRow("comp_number") = GVInvoiceList.GetFocusedRowCellValue("comp_number").ToString
            newRow("total_rec") = 0
            If LEDK.EditValue.ToString = "1" Then
                newRow("value") = amo * -1
                newRow("balance_due") = GVInvoiceList.GetFocusedRowCellValue("total_due") * -1
            Else
                newRow("value") = amo
                newRow("balance_due") = GVInvoiceList.GetFocusedRowCellValue("total_due")
            End If
            newRow("note") = addSlashes(GVInvoiceList.GetFocusedRowCellValue("note").ToString)
            newRow("id_dc") = LEDK.EditValue.ToString
            newRow("dc_code") = LEDK.Text
            newRow("value_view") = amo
            newRow("value_bef_kurs") = 0.00
            TryCast(FormBankDepositDet.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormBankDepositDet.GCList.RefreshDataSource()
            FormBankDepositDet.GVList.RefreshData()
            FormBankDepositDet.calculate_amount()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
    Sub viewDK()
        Dim query As String = "SELECT * FROM tb_lookup_dc d WHERE d.id_dc=1 OR d.id_dc=2 "
        viewLookupQuery(LEDK, query, 0, "dc_code", "id_dc")
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub load_vendor_po()
        Cursor = Cursors.WaitCursor
        Dim id_group As String = "-1"
        Try
            id_group = SLEStoreGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim cond_group As String = ""
        If id_group <> "0" Then
            cond_group = "AND c.id_comp_group='" + id_group + "' "
        End If


        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
        UNION
        SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='6' " + cond_group + " "
        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp_contact", "comp_name", "id_comp_contact")
        Cursor = Cursors.Default
    End Sub


    Sub load_status_payment()
        Dim query As String = "SELECT 1 AS id_status_payment,'Open' AS status_payment"
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_invoice()
    End Sub

    Sub load_invoice()
        Dim where_string As String = ""

        If Not SLEStoreGroup.EditValue.ToString = "0" Then
            where_string += " AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If

        If Not SLEStoreInvoice.EditValue.ToString = "0" Then
            where_string += " AND cc.id_comp_contact='" & SLEStoreInvoice.EditValue.ToString & "'"
        End If

        If SLEStatusInvoice.EditValue.ToString = "1" Then 'All open
            where_string += " AND sp.is_close_rec_payment='2'"
        ElseIf SLEStatusInvoice.EditValue.ToString = "2" Then 'closed
            where_string += " AND sp.is_close_rec_payment='1'"
        ElseIf SLEStatusInvoice.EditValue.ToString = "3" Then 'open overdue
            where_string += " AND sp.is_close_rec_payment='2' AND sp.sales_pos_due_date<DATE(NOW())"
        ElseIf SLEStatusInvoice.EditValue.ToString = "3" Then 'open overdue H-7
            where_string += " AND sp.is_close_rec_payment='2' AND DATE_SUB(sp.sales_pos_due_date, INTERVAL 7 DAY)<DATE(NOW())"
        End If

        Dim var_acc As String = "IFNULL(sp.id_acc_ar,0)"
        Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`,CONCAT(DATE_FORMAT(sp.`sales_pos_start_period`,'%d %M %Y'),' - ',DATE_FORMAT(sp.`sales_pos_end_period`,'%d %M %Y')) AS period
        ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`,CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
        ,sp.report_mark_type,rmt.report_mark_type_name,IFNULL(pyd.`value`,0.00) AS total_rec,CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS total_due
        ,IFNULL(pyd.total_pending,0) AS `total_pending`
        ,DATEDIFF(sp.`sales_pos_due_date`,NOW()) AS due_days,
        " + var_acc + " AS `id_acc`, coa.acc_name, coa.acc_description,
        IF(typ.`is_receive_payment`=2,1,2) AS `id_dc`, IF(typ.`is_receive_payment`=2,'D','K') AS `dc_code`,
        CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `note`,
        cf.id_comp AS `id_comp_default`, cf.comp_number as `comp_number_default`
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
	        SELECT pyd.id_report, pyd.report_mark_type, 
	        COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
	        SUM(pyd.value) AS  `value`
	        FROM tb_rec_payment_det pyd
	        INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
	        WHERE py.`id_report_status`!=5
	        GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        LEFT JOIN tb_a_acc coa ON coa.id_acc = " + var_acc + "
        INNER JOIN tb_m_comp cf ON cf.id_comp=1
        WHERE sp.`id_report_status`='6' " & where_string & " 
        GROUP BY sp.`id_sales_pos`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceList.DataSource = data
        GVInvoiceList.BestFitColumns()
    End Sub
End Class