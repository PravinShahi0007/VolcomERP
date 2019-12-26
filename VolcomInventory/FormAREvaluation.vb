Public Class FormAREvaluation
    Public eval_date As String = ""

    Private Sub FormAREvaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get last evaluation
        Dim query As String = "SELECT DATE_FORMAT(MAX(a.eval_date),'%Y-%m-%d %H:%i:%s') AS `last_eval_date`,
        DATE_FORMAT(MAX(a.eval_date),'%d %M %Y %H:%i:%s') AS `last_eval_date_label`
        FROM tb_ar_eval a "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        eval_date = data.Rows(0)("last_eval_date").ToString
        BtnBrowseEval.Text = data.Rows(0)("last_eval_date_label").ToString
    End Sub

    Private Sub FormAREvaluation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewData_Click(sender As Object, e As EventArgs) Handles BtnViewData.Click
        If XTCData.SelectedTabPageIndex = 1 Then
            viewInvoiceDetail()
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            viewCompGroup()
        End If
    End Sub

    Sub viewInvoiceDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description AS `group_store`, 
        e.id_sales_pos AS `id_inv`, e.report_number AS `inv_number`, e.report_mark_type AS `inv_rmt`,
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS `inv_amount`,
        IF(e.is_paid=1,'Paid', 'Not Paid') AS `paid_status`, 
        IFNULL(m.id_propose_delay_payment,0) AS `id_propose_delay_payment`, m.number as `memo_number`,
        e.release_date, e.note, IF(e.is_active=1,'Active', 'Not Active') AS `active_status`
        FROM tb_ar_eval e 
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN tb_rec_payment bbm ON bbm.id_rec_payment = e.id_rec_payment
        LEFT JOIN tb_propose_delay_payment_det md ON md.id_propose_delay_payment_det = e.id_propose_delay_payment_det
        LEFT JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment  = md.id_propose_delay_payment
        WHERE e.eval_date='" + eval_date + "'
        ORDER BY e.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceDetail.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description AS `group_store`, 
        COUNT(e.id_sales_pos) AS `inv`,
        COUNT(sp.id_sales_pos), IFNULL(p.paid,0) AS `paid`
        FROM tb_ar_eval e 
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
	        SELECT e.id_comp_group, COUNT(e.id_sales_pos) AS `paid` FROM tb_ar_eval e 
	        WHERE e.eval_date='" + eval_date + "' AND e.is_paid=1
	        GROUP BY e.id_comp_group 
        ) p ON e.id_comp_group = p.id_comp_group
        WHERE e.eval_date='" + eval_date + "'
        GROUP BY e.id_comp_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGroup.DataSource = data
        GVGroup.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowseEval_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BtnBrowseEval.ButtonClick
        Cursor = Cursors.WaitCursor
        FormAREvaluationPickDate.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim inv As New ClassShowPopUp()
            inv.id_report = GVInvoiceDetail.GetFocusedRowCellValue("id_inv").ToString
            inv.report_mark_type = GVInvoiceDetail.GetFocusedRowCellValue("inv_rmt").ToString
            inv.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnBBM_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnBBM.ButtonClick
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormInvoiceTrackingBBM.Text = FormInvoiceTrackingBBM.Text + " " + GVInvoiceDetail.GetFocusedRowCellValue("inv_number").ToString
            FormInvoiceTrackingBBM.rmt = GVInvoiceDetail.GetFocusedRowCellValue("inv_rmt").ToString
            FormInvoiceTrackingBBM.id_report = GVInvoiceDetail.GetFocusedRowCellValue("id_inv").ToString
            FormInvoiceTrackingBBM.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnEvaluation_Click(sender As Object, e As EventArgs) 
        Dim tgl As String = execute_query("SELECT DATE_FORMAT(NOW(),'%Y-%m-%d %H:%i:%s') AS `eval_date`", 0, True, "", "", "", "")
        Try
            Dim query As String = "CALL getEvaluationAR('" + tgl + "');"
            execute_non_query(query, True, "", "", "", "")
            execute_non_query("INSERT tb_ar_eval_log(eval_date, log_time, log) VALUES('" + tgl + "',NOW(), 'Evaluation Success');", True, "", "", "", "")
            infoCustom("Evaluation Success")
        Catch ex As Exception
            execute_non_query("INSERT tb_ar_eval_log(eval_date, log_time, log) VALUES('" + tgl + "',NOW(), '" + addSlashes(ex.ToString) + "');", True, "", "", "", "")
        End Try
    End Sub

    Private Sub RepoLinkMemo_Click(sender As Object, e As EventArgs) Handles RepoLinkMemo.Click
        If GVInvoiceDetail.RowCount > 0 And GVInvoiceDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_memo As String = GVInvoiceDetail.GetFocusedRowCellValue("id_propose_delay_payment").ToString
            If id_memo <> "0" Then
                Dim inv As New ClassShowPopUp()
                inv.id_report = id_memo
                inv.report_mark_type = "233"
                inv.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 0 Then
            PanelNav.Visible = False
            PanelControlCreateEval.Visible = True
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            PanelNav.Visible = True
            PanelControlCreateEval.Visible = False
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            PanelNav.Visible = True
            PanelControlCreateEval.Visible = False
        End If
    End Sub

    Sub viewOverdue()
        Cursor = Cursors.WaitCursor
        discardMemo()

        'invoice list
        Dim query As String = "SELECT sp.id_sales_pos, sp.sales_pos_number, cg.description AS `group`,CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, sp.sales_pos_date, sp.sales_pos_due_date,
        IFNULL(sp.id_propose_delay_payment,0) AS `id_propose_delay_payment`, m.number AS `memo_number`, sp.propose_delay_payment_due_date, 
        DATEDIFF(NOW(), IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date)) AS `due_days`,
        CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`
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
	         INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = pyd.id_report AND sp.is_close_rec_payment=2
	         WHERE py.`id_report_status`=6
	         GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        LEFT JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment = sp.id_propose_delay_payment
        WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND sp.sales_pos_total>0
        AND (DATEDIFF(NOW(),IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date))>0)
        GROUP BY sp.id_sales_pos
        ORDER BY c.id_comp_group ASC, sp.id_sales_pos ASC; "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActiveList.DataSource = data
        GVActiveList.BestFitColumns()
        If GVActiveList.RowCount > 0 Then
            BtnCreateEvaluation.Visible = True
            BtnActivateMemoPenangguhan.Visible = True
        Else
            BtnCreateEvaluation.Visible = False
            BtnActivateMemoPenangguhan.Visible = False
        End If

        'store group
        Dim query_group As String = "SELECT cg.id_comp_group, cg.description AS `group`
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND sp.sales_pos_total>0
        AND (DATEDIFF(NOW(),IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date))>0)
        GROUP BY cg.id_comp_group
        ORDER BY c.id_comp_group ASC "
        Dim data_group As DataTable = execute_query(query_group, -1, True, "", "", "", "")
        GCGroupStoreList.DataSource = data_group
        GVGroupStoreList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub resetViewOverdue()
        Cursor = Cursors.WaitCursor
        GCActiveList.DataSource = Nothing
        GCGroupStoreList.DataSource = Nothing
        BtnCreateEvaluation.Visible = False
        BtnActivateMemoPenangguhan.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAREvaluation_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAREvaluation_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
        resetViewOverdue()
    End Sub

    Private Sub BtnViewOverdue_Click(sender As Object, e As EventArgs) Handles BtnViewOverdue.Click
        viewOverdue()
    End Sub

    Private Sub BtnCreateMemo_Click(sender As Object, e As EventArgs) Handles BtnCreateMemo.Click

    End Sub

    Private Sub BtnDiscardMemo_Click(sender As Object, e As EventArgs) Handles BtnDiscardMemo.Click
        discardMemo()
    End Sub

    Sub discardMemo()
        BtnCreateMemo.Visible = False
        BtnDiscardMemo.Visible = False
        BtnCreateEvaluation.Visible = True
        BtnActivateMemoPenangguhan.Visible = True
        GridColumnis_select.Visible = False
    End Sub

    Private Sub BtnActivateMemoPenangguhan_Click(sender As Object, e As EventArgs) Handles BtnActivateMemoPenangguhan.Click
        BtnCreateEvaluation.Visible = False
        BtnActivateMemoPenangguhan.Visible = False
        BtnDiscardMemo.Visible = True
        BtnCreateMemo.Visible = True
        GridColumnis_select.Visible = True
    End Sub

    Private Sub BtnCreateEvaluation_Click(sender As Object, e As EventArgs) Handles BtnCreateEvaluation.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to hold delivery ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()
            FormMain.SplashScreenManager1.SetWaitFormDescription("Processing hold delivery")
            FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email hold delivery")
            FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email peringatan")

            FormMain.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub
End Class