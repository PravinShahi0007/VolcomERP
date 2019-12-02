﻿Public Class FormInvoiceTracking
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
        load_store()
    End Sub

    Private Sub FormInvoiceTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        load_status_payment()
    End Sub

    Sub load_status_payment()
        Dim query As String = "SELECT 1 AS id_status_payment,'All Status' AS status_payment
        UNION
        SELECT 2 AS id_status_payment,'Open' AS status_payment
        UNION
        SELECT 3 AS id_status_payment,'Close' AS status_payment "
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
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
        If id_status = "1" Then 'a''
            cond_status = ""
        ElseIf id_status = "2" Then 'open
            cond_status = "AND sp.is_close_rec_payment=2 "
        ElseIf id_status = "3" Then 'close
            cond_status = "AND sp.is_close_rec_payment=1 "
        End If

        'filter promo
        Dim cond_promo As String = ""
        If CEPromo.EditValue = True Then
            cond_promo = ""
        Else
            cond_promo = "AND sp.sales_pos_total>0 "
        End If

        Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`, sp.`sales_pos_start_period`, sp.`sales_pos_end_period`
            ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`, sp.sales_pos_total_qty, IFNULL(pyd.`value`,0.00) AS total_rec, 
            IFNULL(pyd.`value`,0.00) - CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS total_due,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
            ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(IF(sp.is_close_rec_payment=2,NOW(), IF(ISNULL(bbm.bbm_received_date),NOW(),bbm.bbm_received_date)),sp.`sales_pos_due_date`) AS due_days,
            id_mail_warning_no,mail_warning_no, mail_warning_date, mail_warning_status,
            id_mail_notice_no,mail_notice_no, mail_notice_date, mail_notice_status,
            id_mail_invoice, mail_invoice_no, mail_invoice_date, mail_invoice_status,
            bbm.`id_bbm`,bbm.`bbm_number`, bbm.`bbm_value`, bbm.`bbm_created_date`, bbm.`bbm_received_date`
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
	            WHERE py.`id_report_status`=6 AND pyd.report_mark_type IN (48, 54,66,67,116, 117, 118, 183)
	            GROUP BY pyd.id_report, pyd.report_mark_type
            ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
            LEFT JOIN (
                SELECT * FROM (
	                SELECT m.id_mail_manage AS `id_mail_warning_no`, m.number AS `mail_warning_no`, 
	                m.updated_date AS `mail_warning_date`,md.id_report, stt.mail_status AS `mail_warning_status`
	                FROM tb_mail_manage_det md
	                INNER JOIN tb_mail_manage m ON m.id_mail_manage = md.id_mail_manage
	                INNER JOIN tb_lookup_mail_status stt ON stt.id_mail_status = m.id_mail_status
	                WHERE m.report_mark_type=227
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
		            WHERE rd.report_mark_type IN (48, 54,66,67,116, 117, 118, 183) AND r.id_report_status=6
		            ORDER BY r.id_rec_payment DESC
	            ) rm
	            GROUP BY rm.id_report
            ) bbm ON bbm.id_report = sp.id_sales_pos
            WHERE sp.`id_report_status`='6' 
            " + cond_group + " 
            " + cond_store + "
            " + cond_status + "
            " + cond_promo + "
            GROUP BY sp.`id_sales_pos` 
            ORDER BY id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUnpaid.DataSource = data
        Cursor = Cursors.Default
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

        If CEShowHighlight.EditValue = True Then
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
            FormMailManageDet.action="upd"
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
End Class