Public Class FormDelayPaymentPick
    Public id_pop_up As String = "-1"
    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormDelayPaymentPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        If id_pop_up = "-1" Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT  sp.id_sales_pos, sp.sales_pos_number, 
            c.comp_number, c.comp_name,CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
            sp.sales_pos_date, sp.sales_pos_due_date, DATEDIFF(NOW(),sp.`sales_pos_due_date`) AS `aging`, CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`,
            '' AS `remark`,'no' AS `is_select`
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
               INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = pyd.id_report
               WHERE py.`id_report_status`=6 AND sp.is_close_rec_payment=2
               GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND c.id_comp_group='" + FormDelayPaymentDet.id_comp_group + "' 
            AND sp.id_sales_pos NOT IN (
                SELECT dd.id_sales_pos 
                FROM tb_propose_delay_payment_det dd 
                INNER JOIN tb_propose_delay_payment d ON d.id_propose_delay_payment = dd.id_propose_delay_payment AND d.id_report_status!=5 AND d.id_comp_group='" + FormDelayPaymentDet.id_comp_group + "'
            )
            AND sp.sales_pos_total>0
            ORDER BY sp.id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
            GVData.BestFitColumns()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "1" Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT  sp.id_sales_pos, sp.sales_pos_number, 
            c.comp_number, c.comp_name,CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
            sp.sales_pos_date, sp.sales_pos_due_date, DATEDIFF(NOW(),sp.`sales_pos_due_date`) AS `aging`, CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`,
            '' AS `remark`,'no' AS `is_select`
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
               INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = pyd.id_report
               WHERE py.`id_report_status`=6 AND sp.is_close_rec_payment=2
               GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND c.id_comp_group='" + FormDelayPaymentInvDet.id_comp_group + "' 
            AND sp.id_sales_pos NOT IN (
                SELECT dd.id_sales_pos 
                FROM tb_delay_payment_det dd 
                INNER JOIN tb_delay_payment d ON d.id_delay_payment = dd.id_delay_payment AND d.id_report_status!=5 AND d.id_comp_group='" + FormDelayPaymentInvDet.id_comp_group + "'
            )
            AND sp.sales_pos_total>0 AND sp.sales_pos_due_date>NOW()
            ORDER BY sp.id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data
            GVData.BestFitColumns()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_pop_up = "-1" Then
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVData)
            GVData.ActiveFilterString = "[is_select]='yes'"
            If GVData.RowCount > 0 Then
                Dim query_insert As String = "INSERT INTO tb_propose_delay_payment_det(id_propose_delay_payment, id_sales_pos, comp_number, comp_name, amount, remark) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    If i > 0 Then
                        query_insert += ", "
                    End If
                    query_insert += "('" + FormDelayPaymentDet.id + "', '" + GVData.GetRowCellValue(i, "id_sales_pos").ToString + "', '" + GVData.GetRowCellValue(i, "comp_number").ToString + "', '" + GVData.GetRowCellValue(i, "comp_name").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amount").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "remark").ToString) + "') "
                Next
                execute_non_query(query_insert, True, "", "", "", "")
                FormDelayPaymentDet.viewDetail()
                Close()
            Else
                stopCustom("No data selected")
                GVData.ActiveFilterString = ""
            End If
            Cursor = Cursors.Default
        ElseIf id_pop_up = "1" Then
            Cursor = Cursors.WaitCursor
            makeSafeGV(GVData)
            GVData.ActiveFilterString = "[is_select]='yes'"
            If GVData.RowCount > 0 Then
                Dim query_insert As String = "INSERT INTO tb_delay_payment_det(id_delay_payment, id_sales_pos, comp_number, comp_name, amount, remark) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    If i > 0 Then
                        query_insert += ", "
                    End If
                    query_insert += "('" + FormDelayPaymentInvDet.id + "', '" + GVData.GetRowCellValue(i, "id_sales_pos").ToString + "', '" + GVData.GetRowCellValue(i, "comp_number").ToString + "', '" + GVData.GetRowCellValue(i, "comp_name").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "amount").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "remark").ToString) + "') "
                Next
                execute_non_query(query_insert, True, "", "", "", "")
                FormDelayPaymentInvDet.viewDetail()
                Close()
            Else
                stopCustom("No data selected")
                GVData.ActiveFilterString = ""
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormDelayPaymentPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CESelectAllInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllInvoice.CheckedChanged
        Dim val As String = ""
        If CESelectAllInvoice.EditValue = True Then
            val = "yes"
        Else
            val = "no"
        End If

        For i As Integer = 0 To GVData.RowCount - 1
            GVData.SetRowCellValue(i, "is_select", val)
        Next
    End Sub
End Class