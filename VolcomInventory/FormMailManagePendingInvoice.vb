Public Class FormMailManagePendingInvoice
    Public rmt As String = "-1"
    Public show_direct As Boolean = False

    Private Sub FormMailManagePendingInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If rmt = "225" Then
            viewData()

            If show_direct Then
                FormMailManage.already_open_invoice = True
                If GVData.RowCount <= 0 Then
                    Close()
                End If
            End If
            XTPSalesInvoice.PageVisible = True
        ElseIf rmt = "226" Or rmt = "227" Then
            If rmt = "226" Then
                viewDataUnpaid("AND (DATEDIFF(NOW(),sp.`sales_pos_due_date`)>=-5 AND DATEDIFF(NOW(),sp.`sales_pos_due_date`)<0) ")
                LabelControlJT.Text = "H-3 Jatuh Tempo"
            Else
                viewDataUnpaid("AND (DATEDIFF(NOW(),sp.`sales_pos_due_date`)>0) ")
                LabelControlJT.Text = "Jatuh Tempo"
            End If
            XTPInvoiceJatuhTempo.PageVisible = True
        End If
    End Sub

    Private Sub FormMailManagePendingInvoice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group,cg.comp_group AS `group`, cg.description AS `group_description`, c.id_store_company, hc.comp_name AS `comp_group_office`,
        SUM(sp.sales_pos_total_qty) AS `total_qty`, SUM(sp.`sales_pos_total`) AS sales_pos_total,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2))) AS amount
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_m_comp hc ON hc.id_comp = c.id_store_company
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        WHERE sp.`id_report_status`='6' AND sp.is_pending_mail=1 AND sp.sales_pos_total>0
        GROUP BY cg.id_comp_group, c.id_store_company
        ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDataUnpaid(ByVal cond_par As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group,cg.comp_group AS `group`, cg.description AS `group_description`, hc.comp_name AS `comp_group_office`,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00)) AS amount
        FROM tb_sales_pos sp 
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN tb_m_comp hc ON hc.id_comp = cg.id_comp
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
           SELECT pyd.id_report, pyd.report_mark_type, 
           COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
           SUM(pyd.value) AS  `value`
           FROM tb_rec_payment_det pyd
           INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
           WHERE py.`id_report_status`=6
           GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND sp.sales_pos_total>0
        " + cond_par + "
        GROUP BY c.id_comp_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUnpaidData.DataSource = data
        GVUnpaidData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        If rmt = "225" Then
            If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
                Cursor = Cursors.WaitCursor
                FormMailManage.SLEStoreGroup.EditValue = GVData.GetFocusedRowCellValue("id_comp_group").ToString
                FormMailManage.SLEStoreCompany.EditValue = GVData.GetFocusedRowCellValue("id_store_company").ToString
                FormMailManage.viewPendingInvoice()
                Close()
                Cursor = Cursors.Default
            End If
        ElseIf rmt = "226" Or rmt = "227" Then
            If GVUnpaidData.RowCount > 0 And GVUnpaidData.FocusedRowHandle >= 0 Then
                Cursor = Cursors.WaitCursor
                FormMailManage.SLEStoreGroupUnpaid.EditValue = GVUnpaidData.GetFocusedRowCellValue("id_comp_group").ToString
                If rmt = "226" Then
                    FormMailManage.unpaidMinOvedue()
                Else
                    FormMailManage.unpaidOverdue()
                End If
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        viewDetail()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub

    Private Sub GVUnpaidData_DoubleClick(sender As Object, e As EventArgs) Handles GVUnpaidData.DoubleClick
        viewDetail()
    End Sub
End Class