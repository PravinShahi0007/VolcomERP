﻿Public Class FormInvoiceTracking
    Dim tgl_sekarang As Date

    Private Sub FormInvoiceTracking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
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

    Sub load_store()
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


        Dim query As String = "SELECT 0 AS id_comp,'All' as comp_name
        UNION
        SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
        FROM tb_m_comp c
        WHERE c.id_comp_cat='6' " + cond_group + " "
        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        resetViewData()
        load_store()
    End Sub

    Private Sub FormInvoiceTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        load_status_payment()

        'tgl sekarang
        tgl_sekarang = getTimeDB()
    End Sub

    Sub load_status_payment()
        Dim query As String = "SELECT 1 AS id_status_payment,'All Status' AS status_payment
        UNION
        SELECT 2 AS id_status_payment,'Unpaid' AS status_payment
        UNION
        SELECT 3 AS id_status_payment,'Overdue' AS status_payment
        UNION
        SELECT 4 AS id_status_payment,'Paid' AS status_payment "
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewData()
    End Sub

    Sub viewData()
        'filter grup
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
        Dim cond_group As String = ""
        If id_comp_group <> "0" Then
            cond_group = "AND c.id_comp_group='" + id_comp_group + "' "
        End If

        'filter store
        Dim id_comp As String = SLEStoreInvoice.EditValue.ToString
        Dim cond_store As String = ""
        If id_comp <> "0" Then
            cond_store = "AND c.id_comp='" + id_comp + "' "
        End If

        'filter status
        Dim id_status As String = SLEStatusInvoice.EditValue.ToString
        Dim cond_status As String = ""
        Dim cond_status2 As String = ""
        Dim cond_having As String = ""
        If id_status = "1" Then 'a''
            cond_status = ""
            cond_status2 = ""
        ElseIf id_status = "2" Then 'open=unpaid
            cond_status = "AND sp.is_close_rec_payment=2 "
            cond_status2 = "AND sp.is_close_rec=2 "
        ElseIf id_status = "3" Then 'overdue
            cond_status = "AND sp.is_close_rec_payment=2 "
            cond_status2 = "AND sp.is_close_rec=2 "
            cond_having += "AND due_days>0 "
        ElseIf id_status = "4" Then 'close = paid
            cond_status = "AND sp.is_close_rec_payment=1 "
            cond_status2 = "AND sp.is_close_rec=1 "
        End If

        'filter promo
        Dim cond_promo As String = ""
        If CEPromo.EditValue = True Then
            cond_promo = ""
        Else
            cond_promo = "AND sp.sales_pos_total>0 "
        End If

        'filter sales period
        Dim cond_period As String = ""
        Dim cond_period2 As String = ""
        If CEPeriod.EditValue = False Then
            Dim date_from_selected As String = "0000-01-01"
            Dim date_until_selected As String = "9999-01-01"
            Try
                date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Try
                date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            cond_period = "AND (sp.sales_pos_end_period>='" + date_from_selected + "' AND sp.sales_pos_end_period<='" + date_until_selected + "') "
            cond_period2 = "AND (sp.end_period>='" + date_from_selected + "' AND sp.end_period<='" + date_until_selected + "') "
        End If

        'filter BBM
        Dim cond_period_bbm As String = ""
        Dim cond_having_period_bbm As String = ""
        Dim cond_where_period_bbm As String = ""
        If CEBBM.EditValue = False Then
            Dim date_from_selected_bbm As String = "0000-01-01"
            Dim date_end_selected_bbm As String = "9999-01-01"
            Try
                date_from_selected_bbm = DateTime.Parse(DEStartBBM.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Try
                date_end_selected_bbm = DateTime.Parse(DEEndBBM.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            cond_period_bbm = "AND (py.date_received>='" + date_from_selected_bbm + "' AND py.date_received<='" + date_end_selected_bbm + "') "
            cond_having_period_bbm = "AND total_rec!=0 "
            cond_where_period_bbm = "AND IFNULL(pyd.value,0)!=0 "
        End If

        Dim rmt_inv As String = execute_query("SELECT GROUP_CONCAT(DISTINCT report_mark_type ORDER BY report_mark_type ASC) FROM tb_sales_pos WHERE id_report_status=6 ", 0, True, "", "", "", "")
        If XTCInvTrack.SelectedTabPageIndex = 0 Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`, sp.`sales_pos_start_period`, sp.`sales_pos_end_period`
            ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`, sp.sales_pos_total_qty, IFNULL(pyd.`value`,0.00) AS total_rec, 
            IFNULL(pyd.`value`,0.00) - CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2)) AS total_due,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2)) AS amount
            ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(IF(sp.is_close_rec_payment=2,NOW(), IF(ISNULL(bbm.bbm_received_date),NOW(),bbm.bbm_received_date)),sp.sales_pos_due_date) AS due_days,
            id_mail_warning_no,mail_warning_no, mail_warning_date, mail_warning_status,
            id_mail_notice_no,mail_notice_no, mail_notice_date, mail_notice_status,
            id_mail_invoice, mail_invoice_no, mail_invoice_date, mail_invoice_status,
            bbm.`id_bbm`,bbm.`bbm_number`, bbm.`bbm_value`, bbm.`bbm_created_date`, bbm.`bbm_received_date`, IFNULL(pyd_op.total_pending, 0) AS `bbm_on_process`,
            IFNULL(bbk.`id_bbk`,0) AS `id_bbk`, bbk.`bbk_number`, bbk.`bbk_created_date`, bbk.`bbk_payment_date`, bbk.`bbk_value`, bbk.`bbk_status`,
            IFNULL(sp.id_propose_delay_payment,0) AS `id_propose_delay_payment`, mem.number AS `memo_number`, sp.propose_delay_payment_due_date,
            del.id_pl_sales_order_del, del.pl_sales_order_del_number,so.sales_order_ol_shop_number AS `ol_store_order`, SUM(dsg.design_cop * spd.sales_pos_det_qty) AS `amount_cost`
            FROM tb_sales_pos sp 
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
            INNER JOIN tb_m_product prod ON prod.id_product = spd.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
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
	            WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (" + rmt_inv + ")
                " + cond_period_bbm + "
	            GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            LEFT JOIN (
                SELECT pyd.id_report, pyd.report_mark_type, 
	            COUNT(py.id_rec_payment) AS `total_pending`,
	            SUM(pyd.value) AS  `value`
	            FROM tb_rec_payment_det pyd
	            INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
	            WHERE py.`id_report_status`<5 AND pyd.report_mark_type IN (" + rmt_inv + ")
	            GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd_op ON pyd_op.id_report = sp.id_sales_pos AND pyd_op.report_mark_type = sp.report_mark_type
            LEFT JOIN (
                SELECT * FROM (
	                SELECT m.id_mail_manage AS `id_mail_warning_no`, m.number AS `mail_warning_no`, 
	                m.updated_date AS `mail_warning_date`,md.id_report, stt.mail_status AS `mail_warning_status`
	                FROM tb_mail_manage_det md
	                INNER JOIN tb_mail_manage m ON m.id_mail_manage = md.id_mail_manage
	                INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = m.id_mail_status
                    INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = md.id_report
                    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	                WHERE m.report_mark_type=227 AND c.id_comp_group = m.mail_parameter
	                ORDER BY m.id_mail_manage DESC
                ) w 
                GROUP BY w.id_report
            ) w ON w.id_report = sp.id_sales_pos
            LEFT JOIN (
                SELECT * FROM (
	                SELECT m.id_mail_manage AS `id_mail_notice_no`, m.number AS `mail_notice_no`, 
	                m.updated_date AS `mail_notice_date`,md.id_report, stt.mail_status AS `mail_notice_status`
	                FROM tb_mail_manage_det md
	                INNER JOIN tb_mail_manage m ON m.id_mail_manage = md.id_mail_manage
	                INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = m.id_mail_status
	                WHERE m.report_mark_type=226
	                ORDER BY m.id_mail_manage DESC
                ) n 
                GROUP BY n.id_report
            ) n ON n.id_report = sp.id_sales_pos
            LEFT JOIN (
                SELECT * FROM (
	                SELECT m.id_mail_manage AS `id_mail_invoice`, m.number AS `mail_invoice_no`, 
	                m.updated_date AS `mail_invoice_date`,md.id_report, stt.mail_status AS `mail_invoice_status`
	                FROM tb_mail_manage_det md
	                INNER JOIN tb_mail_manage m ON m.id_mail_manage = md.id_mail_manage
	                INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = m.id_mail_status
	                WHERE m.report_mark_type=225
	                ORDER BY m.id_mail_manage DESC
                ) n 
                GROUP BY n.id_report
            ) i ON i.id_report = sp.id_sales_pos
            LEFT JOIN (
	            SELECT * FROM  (
		            SELECT r.id_rec_payment AS `id_bbm`, rd.id_report, r.number AS `bbm_number`, r.value AS `bbm_value`,
		            r.date_created AS `bbm_created_date`,
		            r.date_received AS `bbm_received_date`
		            FROM tb_rec_payment_det rd
		            INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
		            WHERE rd.report_mark_type IN (" + rmt_inv + ") AND r.id_report_status=6
		            ORDER BY r.id_rec_payment DESC
	            ) rm
	            GROUP BY rm.id_report
            ) bbm ON bbm.id_report = sp.id_sales_pos
            LEFT JOIN (
                SELECT bbk.id_report, bbk.id_pn AS `id_bbk`, bbk.number AS `bbk_number`, 
                bbk.date_created AS `bbk_created_date`, bbk.date_payment AS `bbk_payment_date`, bbk.value AS `bbk_value`, bbk.report_status AS `bbk_status`
                FROM (
	                SELECT bkd.id_report, bk.id_pn, bk.number, bk.date_created, bk.date_payment, bk.value, stt.report_status
	                FROM tb_pn bk
	                INNER JOIN tb_pn_det bkd ON bkd.id_pn = bk.id_pn
	                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = bkd.id_report
	                INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
	                INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos_det = spd.id_sales_pos_det_ref
	                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
	                INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = bk.id_report_status
	                WHERE bkd.report_mark_type=118 AND bk.id_report_status=6
	                ORDER BY bk.id_pn DESC
                ) bbk
                GROUP BY bbk.id_report
            ) bbk ON bbk.id_report = sp.id_sales_pos
            LEFT JOIN tb_propose_delay_payment mem ON mem.id_propose_delay_payment = sp.id_propose_delay_payment
            LEFT JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = sp.id_pl_sales_order_del
            LEFT JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
            WHERE sp.`id_report_status`='6' 
            " + cond_group + " 
            " + cond_store + "
            " + cond_status + "
            " + cond_promo + "
            " + cond_period + "
            GROUP BY sp.`id_sales_pos` 
            HAVING 1=1 " + cond_having + "
            " + cond_having_period_bbm + "
            UNION
            SELECT 'no' AS is_check,sp.is_close_rec AS `is_close_rec_payment`,sp.id_invoice_ship AS id_sales_pos,'' AS sales_pos_note,sp.number AS sales_pos_number,
            0 AS id_memo_type,'' AS `memo_type`,2 AS `is_receive_payment`,sp.created_date AS `sales_pos_date`,sp.id_comp_contact AS `id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,
            sp.due_date AS `sales_pos_due_date`, sp.start_period AS `sales_pos_start_period`, sp.end_period AS `sales_pos_end_period`
            ,sp.value AS `sales_pos_total`,0 AS `sales_pos_discount`,0 AS `sales_pos_vat`,0 AS `sales_pos_potongan`, 0 AS sales_pos_total_qty, IFNULL(pyd.`value`,0.00) AS total_rec, 
            IFNULL(pyd.`value`,0.00) - (sp.value) AS total_due, sp.value AS  amount ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(IF(sp.is_close_rec=2,NOW(), IF(ISNULL(bbm.bbm_received_date),NOW(),bbm.bbm_received_date)),sp.due_date) AS due_days,
            0 AS id_mail_warning_no,'' AS mail_warning_no, NULL AS mail_warning_date, '' AS mail_warning_status,
            0 AS id_mail_notice_no,'' AS mail_notice_no, NULL AS mail_notice_date, '' AS mail_notice_status,
            0 AS id_mail_invoice, '' AS mail_invoice_no, NULL AS mail_invoice_date, '' AS mail_invoice_status,
            bbm.`id_bbm`,bbm.`bbm_number`, bbm.`bbm_value`, bbm.`bbm_created_date`, bbm.`bbm_received_date`, IFNULL(pyd_op.total_pending, 0) AS `bbm_on_process`,
            0 AS `id_bbk`,'' AS `bbk_number`, NULL AS `bbk_created_date`, NULL AS `bbk_payment_date`, 0 AS `bbk_value`, '' AS `bbk_status`,
            0 AS `id_propose_delay_payment`, '' AS `memo_number`, NULL AS propose_delay_payment_due_date, 0 AS `id_pl_sales_order_del`, '' AS `pl_sales_order_del_number`, od.ol_store_order, 0 AS `amount_cost`
            FROM tb_invoice_ship sp
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            LEFT JOIN (
               SELECT pyd.id_report, pyd.report_mark_type, 
               COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
               SUM(pyd.value) AS  `value`
               FROM tb_rec_payment_det pyd
               INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
               WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (249)
               " + cond_period_bbm + "
               GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_invoice_ship AND pyd.report_mark_type = sp.report_mark_type
            LEFT JOIN (
                SELECT pyd.id_report, pyd.report_mark_type, 
               COUNT(py.id_rec_payment) AS `total_pending`,
               SUM(pyd.value) AS  `value`
               FROM tb_rec_payment_det pyd
               INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
               WHERE py.`id_report_status`<5 AND pyd.report_mark_type IN (249)
               GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd_op ON pyd_op.id_report = sp.id_invoice_ship AND pyd_op.report_mark_type = sp.report_mark_type
            LEFT JOIN (
               SELECT * FROM  (
                  SELECT r.id_rec_payment AS `id_bbm`, rd.id_report, r.number AS `bbm_number`, r.value AS `bbm_value`,
                  r.date_created AS `bbm_created_date`,
                  r.date_received AS `bbm_received_date`
                  FROM tb_rec_payment_det rd
                  INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
                  WHERE rd.report_mark_type IN (249) AND r.id_report_status=6
                  ORDER BY r.id_rec_payment DESC
               ) rm
               GROUP BY rm.id_report
            ) bbm ON bbm.id_report = sp.id_invoice_ship
            LEFT JOIN (
               SELECT od.id, od.sales_order_ol_shop_number AS `ol_store_order` FROM tb_ol_store_order od
               GROUP BY od.id
            ) od ON od.id = sp.id_report
            WHERE sp.`id_report_status`='6' 
            " + cond_group + " 
            " + cond_store + "
            " + cond_status2 + "
            " + cond_period2 + "
            GROUP BY sp.id_invoice_ship
            HAVING 1=1 " + cond_having + "
            " + cond_having_period_bbm + "
            ORDER BY id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCUnpaid.DataSource = data
            Cursor = Cursors.Default
        Else
            Cursor = Cursors.WaitCursor

            'overdue
            Dim cond_ovd As String = ""
            Dim cond_ovd2 As String = ""
            If id_status = "3" Then
                cond_ovd = "AND DATEDIFF(NOW(),sp.sales_pos_due_date)>0 "
                cond_ovd2 = "AND DATEDIFF(NOW(),sp.due_date)>0 "
            End If

            Dim query As String = "
            SELECT is_close_rec_payment, id_comp_group, comp_group, comp_group_desc, 
            SUM(sales_pos_total) AS `sales_pos_total`, SUM(total_rec) AS `total_rec`, SUM(total_due) AS `total_due`, SUM(amount) AS `amount`,
            SUM(amount_cost) AS `amount_cost`
            FROM
            (SELECT sp.is_close_rec_payment, cg.id_comp_group,cg.comp_group, cg.description AS `comp_group_desc`,
            (sp.`sales_pos_total`) AS `sales_pos_total`, (IFNULL(pyd.`value`,0.00)) AS total_rec, 
            (IFNULL(pyd.`value`,0.00)) - (CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2))) AS total_due,
            (CAST(IF(typ.`is_receive_payment`=2,-1,1) * sp.netto AS DECIMAL(15,2))) AS amount,
            SUM(dsg.design_cop * spd.sales_pos_det_qty) AS amount_cost
            FROM tb_sales_pos sp 
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
            INNER JOIN tb_m_product prod ON prod.id_product = spd.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            LEFT JOIN (
	            SELECT c.id_comp_group, SUM(pyd.value) AS  `value`, sp.id_sales_pos
	            FROM tb_rec_payment_det pyd
	            INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = pyd.id_report AND sp.report_mark_type = pyd.report_mark_type
                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
	            WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (" + rmt_inv + ")
                " + cond_group + " 
                " + cond_store + "
                " + cond_status + "
                " + cond_promo + "
                " + cond_period + "
                " + cond_ovd + "
                " + cond_period_bbm + "
	            GROUP BY sp.id_sales_pos
            ) pyd ON pyd.id_sales_pos = sp.id_sales_pos
            WHERE sp.`id_report_status`='6' 
            " + cond_group + " 
            " + cond_store + "
            " + cond_status + "
            " + cond_promo + "
            " + cond_period + "
            " + cond_ovd + "
            " + cond_where_period_bbm + "
            GROUP BY sp.id_sales_pos
            UNION ALL
            SELECT sp.is_close_rec AS is_close_rec_payment, cg.id_comp_group,cg.comp_group, cg.description AS `comp_group_desc`,
            (sp.value) AS `sales_pos_total`, (IFNULL(pyd.`value`,0.00)) AS total_rec, 
            (IFNULL(pyd.`value`,0.00)) - (sp.value) AS total_due,
            (sp.value) AS amount, 0 AS `amount_cost`
            FROM tb_invoice_ship sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            LEFT JOIN (
	            SELECT c.id_comp_group, SUM(pyd.value) AS  `value`, sp.id_invoice_ship
	            FROM tb_rec_payment_det pyd
	            INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                INNER JOIN tb_invoice_ship sp ON sp.id_invoice_ship = pyd.id_report AND sp.report_mark_type = pyd.report_mark_type
                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= sp.id_comp_contact
                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
	            WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (249)
                " + cond_group + " 
                " + cond_store + "
                " + cond_status2 + "
                " + cond_period2 + "
                " + cond_ovd2 + "
                " + cond_period_bbm + "
	            GROUP BY sp.id_invoice_ship
            ) pyd ON pyd.id_invoice_ship = sp.id_invoice_ship
            WHERE sp.`id_report_status`='6' 
            " + cond_group + " 
            " + cond_store + "
            " + cond_status2 + "
            " + cond_period2 + "
            " + cond_ovd2 + "
            " + cond_where_period_bbm + ") a
            GROUP BY id_comp_group
            HAVING 1=1
            ORDER BY comp_group_desc ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSummary.DataSource = data
            GVSummary.BestFitColumns()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnMoreBBM_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnMoreBBM.ButtonClick
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormInvoiceTrackingBBM.Text = FormInvoiceTrackingBBM.Text + " " + GVUnpaid.GetFocusedRowCellValue("sales_pos_number").ToString
            FormInvoiceTrackingBBM.rmt = GVUnpaid.GetFocusedRowCellValue("report_mark_type").ToString
            FormInvoiceTrackingBBM.id_report = GVUnpaid.GetFocusedRowCellValue("id_sales_pos").ToString
            FormInvoiceTrackingBBM.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVUnpaid.RowStyle, AddressOf custom_cell
        GCUnpaid.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True And e.RowHandle >= 0 Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim aging As Integer = 0
            Try
                aging = currview.GetRowCellValue(e.RowHandle, "due_days")
            Catch ex As Exception
                aging = 0
            End Try

            If aging >= -5 And aging < 0 Then
                e.Appearance.BackColor = Color.Yellow
            ElseIf aging = 0 Then
                e.Appearance.BackColor = Color.OrangeRed
            ElseIf aging > 0 Then
                e.Appearance.BackColor = Color.Crimson
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim inv As New ClassShowPopUp()
            inv.id_report = GVUnpaid.GetFocusedRowCellValue("id_sales_pos").ToString
            inv.report_mark_type = GVUnpaid.GetFocusedRowCellValue("report_mark_type").ToString
            inv.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkBBM_Click(sender As Object, e As EventArgs) Handles RepoLinkBBM.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim bbm As New ClassShowPopUp()
            bbm.id_report = GVUnpaid.GetFocusedRowCellValue("id_bbm").ToString
            bbm.report_mark_type = "162"
            bbm.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkEMailNotice_Click(sender As Object, e As EventArgs) Handles RepoLinkEMailNotice.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMailManageDet.action = "upd"
            FormMailManageDet.id = GVUnpaid.GetFocusedRowCellValue("id_mail_notice_no").ToString
            FormMailManageDet.rmt = "226"
            FormMailManageDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkEmailWarning_Click(sender As Object, e As EventArgs) Handles RepoLinkEmailWarning.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMailManageDet.action = "upd"
            FormMailManageDet.id = GVUnpaid.GetFocusedRowCellValue("id_mail_warning_no").ToString
            FormMailManageDet.rmt = "227"
            FormMailManageDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkEmailInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkEmailInvoice.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMailManageDet.action = "upd"
            FormMailManageDet.id = GVUnpaid.GetFocusedRowCellValue("id_mail_invoice").ToString
            FormMailManageDet.rmt = "225"
            FormMailManageDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormInvoiceTracking_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormInvoiceTracking_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnExportToXLSTrf_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSTrf.Click
        If XTCInvTrack.SelectedTabPageIndex = 0 Then
            If GVUnpaid.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "sal_inv_tracking.xlsx"
                exportToXLS(path, "inv", GCUnpaid)
                Cursor = Cursors.Default
            End If
        Else
            If GVSummary.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "sal_inv_tracking_summary.xlsx"
                exportToXLS(path, "inv", GCSummary)
                Cursor = Cursors.Default
            End If
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

    Private Sub RepoLinkMemoPenangguhan_Click(sender As Object, e As EventArgs) Handles RepoLinkMemoPenangguhan.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_memo As String = GVUnpaid.GetFocusedRowCellValue("id_propose_delay_payment").ToString
            If id_memo <> "0" Then
                Dim inv As New ClassShowPopUp()
                inv.id_report = id_memo
                inv.report_mark_type = "233"
                inv.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub resetViewData()
        Cursor = Cursors.WaitCursor
        GCUnpaid.DataSource = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreInvoice_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreInvoice.EditValueChanged
        resetViewData()
    End Sub

    Private Sub SLEStatusInvoice_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStatusInvoice.EditValueChanged
        resetViewData()
    End Sub

    Private Sub CEPromo_EditValueChanged(sender As Object, e As EventArgs) Handles CEPromo.EditValueChanged
        resetViewData()
    End Sub

    Private Sub CEShowHighlight_EditValueChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.EditValueChanged

    End Sub

    Private Sub CEPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CEPeriod.EditValueChanged
        If CEPeriod.EditValue = True Then
            DEFrom.EditValue = Nothing
            DEUntil.EditValue = Nothing
            DEFrom.Enabled = False
            DEUntil.Enabled = False
        Else
            DEFrom.EditValue = tgl_sekarang
            DEUntil.EditValue = tgl_sekarang
            DEFrom.Enabled = True
            DEUntil.Enabled = True
            DEFrom.Focus()
        End If
    End Sub

    Private Sub BtnExpanseCollapse_Click(sender As Object, e As EventArgs)

    End Sub

    Sub print()
        Dim report As ReportFormInvoiceTracking = New ReportFormInvoiceTracking

        report.data = GCUnpaid.DataSource
        report.fs = GVUnpaid.ActiveFilterString

        report.XLStoreGroup.Text = SLEStoreGroup.Text
        report.XLStore.Text = SLEStoreInvoice.Text
        report.XLStatus.Text = SLEStatusInvoice.Text
        report.XLPeriod.Text = If(CEPeriod.Checked, "All Period", DEFrom.Text + " - " + DEUntil.Text)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Sub summary_print()
        Dim report As ReportFormInvoiceTrackingSummary = New ReportFormInvoiceTrackingSummary

        report.data = GCSummary.DataSource

        report.XLStoreGroup.Text = SLEStoreGroup.Text
        report.XLStore.Text = SLEStoreInvoice.Text
        report.XLStatus.Text = SLEStatusInvoice.Text
        report.XLPeriod.Text = If(CEPeriod.Checked, "All Period", DEFrom.Text + " - " + DEUntil.Text)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub RepoLinkBBK_Click(sender As Object, e As EventArgs) Handles RepoLinkBBK.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_bbk As String = GVUnpaid.GetFocusedRowCellValue("id_bbk").ToString
            If id_bbk <> "0" Then
                Dim inv As New ClassShowPopUp()
                inv.id_report = id_bbk
                inv.report_mark_type = "159"
                inv.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnMoreBBK_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnMoreBBK.ButtonClick
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormInvoiceTrackingBBK.Text = FormInvoiceTrackingBBK.Text + " " + GVUnpaid.GetFocusedRowCellValue("sales_pos_number").ToString
            FormInvoiceTrackingBBK.rmt = GVUnpaid.GetFocusedRowCellValue("report_mark_type").ToString
            FormInvoiceTrackingBBK.id_report = GVUnpaid.GetFocusedRowCellValue("id_sales_pos").ToString
            FormInvoiceTrackingBBK.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CEBBM_EditValueChanged(sender As Object, e As EventArgs) Handles CEBBM.EditValueChanged
        If CEBBM.EditValue = True Then
            DEStartBBM.EditValue = Nothing
            DEEndBBM.EditValue = Nothing
            DEStartBBM.Enabled = False
            DEEndBBM.Enabled = False
        Else
            DEStartBBM.EditValue = tgl_sekarang
            DEEndBBM.EditValue = tgl_sekarang
            DEStartBBM.Enabled = True
            DEEndBBM.Enabled = True
            DEStartBBM.Focus()
        End If
    End Sub

    Private Sub RepoLinkDel_Click(sender As Object, e As EventArgs) Handles RepoLinkDel.Click
        If GVUnpaid.RowCount > 0 And GVUnpaid.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_del As String = GVUnpaid.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            If id_del <> "0" Then
                Dim del As New ClassShowPopUp()
                del.id_report = id_del
                del.report_mark_type = "43"
                del.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class