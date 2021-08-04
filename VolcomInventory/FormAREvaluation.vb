Public Class FormAREvaluation
    Dim eval_number As String = ""
    Public eval_date As String = ""
    Public id_ar_eval_pps As String = ""
    Public id_role_super_admin As String = get_setup_field("id_role_super_admin")

    Private Sub FormAREvaluation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getLastEvaluation()
        If id_role_super_admin = id_role_login Then
            BtnLog.Visible = True
        End If
    End Sub

    Sub getLastEvaluation()
        'get last evaluation
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT DATE_FORMAT(a.eval_date,'%Y-%m-%d %H:%i:%s') AS `last_eval_date`,
        DATE_FORMAT(a.eval_date,'%d %M %Y') AS `last_eval_date_label`, a.number, a.id_ar_eval_pps 
        FROM tb_ar_eval_pps a
        ORDER BY a.id_ar_eval_pps DESC LIMIT 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        eval_date = data.Rows(0)("last_eval_date").ToString
        eval_number = data.Rows(0)("number").ToString
        id_ar_eval_pps = data.Rows(0)("id_ar_eval_pps").ToString
        BtnBrowseEval.Text = data.Rows(0)("last_eval_date_label").ToString
        TxtAREvalNumber.Text = eval_number
        Cursor = Cursors.Default
    End Sub

    Private Sub FormAREvaluation_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewData_Click(sender As Object, e As EventArgs) Handles BtnViewData.Click
        If XTCData.SelectedTabPageIndex = 1 Then
            If XTCEval.SelectedTabPageIndex = 0 Then
                viewInvoiceDetail()
            Else
                viewSummary()
            End If
        ElseIf XTCData.SelectedTabPageIndex = 2 Then
            viewCompGroup()
        End If
    End Sub

    Sub viewInvoiceDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT e.id_comp_group, cg.description AS `group_store`, c.comp_number AS `store_acc`, c.comp_name AS `store`,
        e.id_sales_pos AS `id_inv`, e.report_number AS `inv_number`, e.report_mark_type AS `inv_rmt`,
        sp.`sales_pos_date` AS `inv_date`, sp.`sales_pos_due_date` AS `inv_due_date`, sp.`sales_pos_start_period` AS `start_period`, sp.`sales_pos_end_period` AS `end_period`,
        DATEDIFF(DATE(e.eval_date),sp.sales_pos_due_date) AS due_days,
        CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS `inv_amount`,
        IFNULL(pyd.`value`,0.00) AS total_rec, 
        IFNULL(pyd.`value`,0.00) - CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS total_due,
        IF(e.is_paid=1,'Paid', 'Not Paid') AS `paid_status`, 
        NULL AS `id_propose_delay_payment`, '' as `memo_number`,
        e.release_date, e.note,  IFNULL(eh.jum_hold,0) AS `jum_hold`,IF(e.is_active=1,'Active', 'Not Active') AS `active_status`
        FROM tb_ar_eval e 
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
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
           WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (48, 54,66,67,116, 117, 118, 183,292)
           GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        LEFT JOIN (
	        SELECT e.id_sales_pos, COUNT(e.id_sales_pos) AS `jum_hold`
	        FROM tb_ar_eval e
	        WHERE e.eval_date<='" + eval_date + "'
	        GROUP BY e.id_sales_pos
        ) eh ON eh.id_sales_pos = e.id_sales_pos
        WHERE e.eval_date='" + eval_date + "'
        ORDER BY cg.description ASC,e.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoiceDetail.DataSource = data
        GVInvoiceDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.description AS `store_group`, IF(SUM(CASE WHEN e.is_paid=2 THEN 1 ELSE 0 END)>0,'Hold', 'Release') AS `status`,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) ) AS `inv_amount`,
        SUM(IFNULL(pyd.`value`,0.00)) AS total_rec,
        SUM(IFNULL(pyd.`value`,0.00) - CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))) AS `diff`
        FROM tb_ar_eval e
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = e.id_comp_group
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        LEFT JOIN (
          SELECT pyd.id_report, pyd.report_mark_type, 
          COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
          SUM(pyd.value) AS  `value`
          FROM tb_rec_payment_det pyd
          INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
          WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (48, 54,66,67,116, 117, 118, 183,292)
          GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
        WHERE e.eval_date='" + eval_date + "'
        GROUP BY e.id_comp_group
        ORDER BY `status` ASC, description ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
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
        Dim query As String = "SELECT sp.id_sales_pos, sp.sales_pos_number, IFNULL(c.id_store_company,0) AS `id_store_company`,cg.description AS `group`,CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`, sp.sales_pos_date, sp.sales_pos_due_date,
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
        AND sp.report_mark_type!=66 AND sp.report_mark_type!=67 AND sp.report_mark_type!=118  
        AND (DATEDIFF(NOW(),IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date))>0)
        AND c.id_commerce_type=1
        GROUP BY sp.id_sales_pos
        ORDER BY c.id_comp_group ASC, sp.id_sales_pos ASC; "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActiveList.DataSource = data
        GVActiveList.BestFitColumns()
        If GVActiveList.RowCount > 0 Then
            BtnCreateEvaluation.Visible = True
            BtnActivateMemoPenangguhan.Visible = False
        Else
            BtnCreateEvaluation.Visible = False
            BtnActivateMemoPenangguhan.Visible = False
        End If

        'store group
        Dim query_group As String = "SELECT cg.id_comp_group, cg.description AS `group`, IFNULL(c.id_store_company,0) AS `id_ho`, cho.comp_name AS `ho`, IFNULL(map.email,'') AS `email_ho`
        FROM tb_sales_pos sp
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_m_comp cho ON cho.id_comp = c.id_store_company
        LEFT JOIN (
	        SELECT cgc.id_comp AS `id_store_company`,cgc.email 
	        FROM tb_mail_manage_mapping map
	        INNER JOIN tb_m_comp_contact cgc ON cgc.id_comp_contact = map.id_comp_contact 
	        WHERE map.report_mark_type=227 AND map.id_mail_member_type=2
	        GROUP BY cgc.id_comp
        ) map ON map.id_store_company = c.id_store_company
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
        WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND sp.sales_pos_total>0
        AND sp.report_mark_type!=66 AND sp.report_mark_type!=67 AND sp.report_mark_type!=118  
        AND (DATEDIFF(NOW(),IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date))>0)
        AND c.id_commerce_type=1
        GROUP BY cg.id_comp_group, c.id_store_company
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
        BtnCreateMemo.Visible = False
        BtnDiscardMemo.Visible = False
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
        'cek store company
        Cursor = Cursors.WaitCursor
        GVActiveList.ActiveFilterString = ""
        GVActiveList.ActiveFilterString = "[id_store_company]=0"
        Dim null_store_comp As String = ""
        For g As Integer = 0 To GVActiveList.RowCount - 1
            If GVActiveList.GetRowCellValue(g, "id_store_company").ToString = "0" Then
                null_store_comp += "- " + GVActiveList.GetRowCellValue(g, "group").ToString + System.Environment.NewLine
            End If
        Next
        GVActiveList.ActiveFilterString = ""
        If null_store_comp <> "" Then
            Cursor = Cursors.Default
            stopCustom("Please complete store company data for this group store : " + System.Environment.NewLine + null_store_comp)
            Exit Sub
        End If
        Cursor = Cursors.Default

        'cek email group
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVGroupStoreList)
        GVGroupStoreList.ActiveFilterString = "[email_ho]=''"
        Dim null_comp As String = ""
        For j As Integer = 0 To GVGroupStoreList.RowCount - 1
            If GVGroupStoreList.GetRowCellValue(j, "email_ho").ToString = "" Then
                null_comp += "- " + GVGroupStoreList.GetRowCellValue(j, "group").ToString + System.Environment.NewLine
            End If
        Next
        GVGroupStoreList.ActiveFilterString = ""
        If null_comp <> "" Then
            Cursor = Cursors.Default
            stopCustom("Please complete email address for this group store : " + System.Environment.NewLine + null_comp)
            Exit Sub
        End If
        Cursor = Cursors.Default



        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to hold delivery ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim err As String = ""
            Dim date_now_origin As DateTime = getTimeDB()
            Dim date_now As String = DateTime.Parse(date_now_origin).ToString("yyyy-MM-dd HH:mm:ss")
            Dim date_now_display As String = DateTime.Parse(date_now_origin).ToString("dd MMMM yyyy")
            Dim ev As New ClassAREvaluation()

            'start
            FormMain.SplashScreenManager1.ShowWaitForm()

            'hold delivery
            FormMain.SplashScreenManager1.SetWaitFormDescription("Processing hold delivery")
            Try
                ev.holdDelivery(date_now)
            Catch ex As Exception
                err += "- Failed Hold delivery  : " + ex.ToString + System.Environment.NewLine
            End Try

            'sending mail hold delivery
            FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email hold delivery")
            Try
                ev.sendEmailHoldDelivery(date_now, date_now_display)
            Catch ex As Exception
                err += "- Failed sending email hold delivery : " + ex.ToString + System.Environment.NewLine
            End Try

            'sendiing email peringatan
            makeSafeGV(GVGroupStoreList)
            For g As Integer = 0 To GVGroupStoreList.RowCount - 1
                Dim id_group As String = GVGroupStoreList.GetRowCellValue(g, "id_comp_group").ToString
                Dim id_store_company As String = GVGroupStoreList.GetRowCellValue(g, "id_ho").ToString
                Dim group As String = addSlashes(GVGroupStoreList.GetRowCellValue(g, "group").ToString.ToUpper)
                FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email peringatan for " + group)
                Try
                    ev.sendEmailPeringatan(date_now, id_group, id_store_company, group)
                Catch ex As Exception
                    err += "- Failed sending email peringatan for " + group + " : " + ex.ToString + System.Environment.NewLine
                End Try
            Next


            'end
            FormMain.SplashScreenManager1.CloseWaitForm()

            'final msg
            If err = "" Then
                Dim query_cek As String = "SELECT e.eval_date, e.log_time, e.log, IF(e.is_success=1,'Success', 'Failed') AS `log_status`
                FROM tb_ar_eval_log e WHERE e.eval_date='" + date_now + "' AND e.is_success=2 "
                Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                If data_cek.Rows.Count <= 0 Then
                    infoCustom("Hold delivery success")
                Else
                    warningCustom("Found some problem when execution process.")
                    FormAREvaluationLog.eval_date = date_now
                    FormAREvaluationLog.ShowDialog()
                End If
                getLastEvaluation()
            Else
                stopCustom("Failed excecution : " + System.Environment.NewLine + err)
            End If
            resetViewOverdue()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Cursor = Cursors.WaitCursor
        FormAREvaluationLog.eval_date = eval_date
        FormAREvaluationLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoLinkMemoEval_Click(sender As Object, e As EventArgs) Handles RepoLinkMemoEval.Click
        If GVActiveList.RowCount > 0 And GVActiveList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_memo As String = GVActiveList.GetFocusedRowCellValue("id_propose_delay_payment").ToString
            If id_memo <> "0" Then
                Dim inv As New ClassShowPopUp()
                inv.id_report = id_memo
                inv.report_mark_type = "233"
                inv.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub printDetail()
        Cursor = Cursors.WaitCursor
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
        If XTCEval.SelectedTabPageIndex = 0 Then
            ReportAREval.dt = GCInvoiceDetail.DataSource
            gv = GVInvoiceDetail
        Else
            ReportAREval.dt = GCSummary.DataSource
            gv = GVSummary
        End If
        ReportAREval.eval_date_label = BtnBrowseEval.Text
        ReportAREval.eval_number = eval_number
        Dim Report As New ReportAREval()

        'hide col BBM
        GridColumnbtn_bbm.Visible = False

        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVInvoiceDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        If XTCEval.SelectedTabPageIndex = 0 Then
            'style
            Report.GVInvoiceDetail.OptionsPrint.UsePrintStyles = True
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            Report.GVInvoiceDetail.OptionsPrint.ExpandAllDetails = True
            Report.GVInvoiceDetail.OptionsPrint.UsePrintStyles = True
            Report.GVInvoiceDetail.OptionsPrint.PrintDetails = True
            Report.GVInvoiceDetail.OptionsPrint.PrintFooter = True
        Else
            'style
            Report.GVInvoiceDetail.OptionsPrint.UsePrintStyles = True
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 8, FontStyle.Regular)

            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 8, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.GroupRow.Font = New Font("Tahoma", 8, FontStyle.Bold)


            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVInvoiceDetail.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 8.3, FontStyle.Bold)

            Report.GVInvoiceDetail.AppearancePrint.Row.Font = New Font("Tahoma", 8.3, FontStyle.Regular)

            Report.GVInvoiceDetail.OptionsPrint.ExpandAllDetails = True
            Report.GVInvoiceDetail.OptionsPrint.UsePrintStyles = True
            Report.GVInvoiceDetail.OptionsPrint.PrintDetails = True
            Report.GVInvoiceDetail.OptionsPrint.PrintFooter = True
        End If


        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        'show col BBM
        GridColumnbtn_bbm.Visible = True
        Cursor = Cursors.Default
    End Sub

    Private Sub BBICreateNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBICreateNew.ItemClick
        Cursor = Cursors.WaitCursor
        Dim allow_day As String = get_opt_acc_field("tunda_bayar_day")
        Dim curr_date As DateTime = getTimeDB()
        If Not allow_day = curr_date.DayOfWeek.ToString Then
            warningCustom("This menu only available on " + allow_day)
        Else
            FormDelayPaymentInvDet.action = "ins"
            FormDelayPaymentInvDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BBIHistory_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIHistory.ItemClick
        Cursor = Cursors.WaitCursor
        FormDelayPaymentInv.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class