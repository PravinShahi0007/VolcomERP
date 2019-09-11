Public Class FormARAging
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormARAging_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormARAging_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_status_payment()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT 0 AS id_status_payment,'All' AS status_payment
        UNION
        SELECT 1 AS id_status_payment,'Open' AS status_payment
        UNION
        SELECT 2 AS id_status_payment,'Close' AS status_payment "
        viewSearchLookupQuery(SLEStatusInvoice, query, "id_status_payment", "status_payment", "id_status_payment")
        Cursor = Cursors.Default
    End Sub

    Sub load_vendor()
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
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='6' " + cond_group + " "
        viewSearchLookupQuery(SLEStoreInvoice, query, "id_comp", "comp_name", "id_comp")
        Cursor = Cursors.Default
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

    Private Sub FormARAging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
        load_status_payment()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        loadData()
    End Sub

    Sub loadData()
        Cursor = Cursors.WaitCursor
        'cond group
        Dim cond_group As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond_group = "AND c.id_comp_group=" + SLEStoreGroup.EditValue.ToString + " "
        End If
        'cond store
        Dim cond_vendor As String = ""
        If SLEStoreInvoice.EditValue.ToString <> "0" Then
            cond_vendor = "AND cc.id_comp=" + SLEStoreInvoice.EditValue.ToString + " "
        End If
        'cond status
        Dim cond As String = ""
        If SLEStatusInvoice.EditValue.ToString = "1" Then 'All open
            cond = " AND p.is_close_rec_payment='2'"
            gridBandAgingAR.Visible = True
            gridBandPaid.Visible = False
            GridBandInvoice.VisibleIndex = 0
            gridBandAgingAR.VisibleIndex = 1
            gridBandStatus.VisibleIndex = 2
        ElseIf SLEStatusInvoice.EditValue.ToString = "2" Then 'closed
            cond = " AND p.is_close_rec_payment='1'"
            gridBandAgingAR.Visible = False
            gridBandPaid.Visible = True
            GridBandInvoice.VisibleIndex = 0
            gridBandPaid.VisibleIndex = 1
            gridBandStatus.VisibleIndex = 2
        Else 'all
            gridBandAgingAR.Visible = True
            gridBandPaid.Visible = True
            GridBandInvoice.VisibleIndex = 0
            gridBandAgingAR.VisibleIndex = 1
            gridBandPaid.VisibleIndex = 2
            gridBandStatus.VisibleIndex = 3
        End If



        Dim query As String = "SELECT p.id_sales_pos, p.id_comp_contact, p.id_comp, CONCAT(p.comp_number,' - ', p.comp_name) AS `comp`,
        p.sales_pos_date, p.sales_pos_due_date, p.sales_pos_number, p.sales_pos_note, 
        p.sales_pos_total, p.sales_pos_discount, p.sales_pos_potongan,
        IF(typ.`is_receive_payment`=2,-1,1) * ((p.`sales_pos_total`*((100-p.sales_pos_discount)/100))-p.`sales_pos_potongan`) AS `amount`,
        IF(DATEDIFF(NOW(), p.sales_pos_due_date)<=0, DATEDIFF(NOW(), p.sales_pos_due_date),CONCAT('+', DATEDIFF(NOW(), p.sales_pos_due_date))) AS sales_pos_age,
        IF(typ.`is_receive_payment`=2,-1,1) * ((p.`sales_pos_total`*((100-p.sales_pos_discount)/100))-p.`sales_pos_potongan`)-IFNULL(pyd.`value`,0) AS `balance`,
        IF((SELECT balance)=0,NULL, (SELECT balance)) AS `balance_view`,
        IF(DATE(NOW()) <= DATE_ADD(p.sales_pos_due_date,INTERVAL 30 DAY),(SELECT balance_view) ,NULL) AS `30`,
        IF(DATE(NOW()) > DATE_ADD(p.sales_pos_due_date,INTERVAL 30 DAY) AND DATE(NOW()) <=DATE_ADD(p.sales_pos_due_date,INTERVAL 60 DAY),(SELECT balance_view) ,NULL) AS `60`,
        IF(DATE(NOW()) > DATE_ADD(p.sales_pos_due_date,INTERVAL 60 DAY) AND DATE(NOW()) <=DATE_ADD(p.sales_pos_due_date,INTERVAL 90 DAY),(SELECT balance_view) ,NULL) AS `90`,
        IF(DATE(NOW()) > DATE_ADD(p.sales_pos_due_date,INTERVAL 90 DAY),(SELECT balance_view) ,NULL) AS `90_up`,
        pyd.`number` AS `paid_number`, IFNULL(pyd.`value`,0) AS `paid`, pyd.date_created AS `paid_date`, IFNULL(pyd.total_on_process,0) AS `on_process`,
        IF(p.is_close_rec_payment=1,'Close','Open') AS `rec_payment_status`
        FROM (	
	        SELECT p.id_sales_pos, p.id_store_contact_from AS `id_comp_contact`, cc.id_comp, c.comp_number, c.comp_name, p.id_memo_type, p.report_mark_type, p.is_close_rec_payment,
	        p.sales_pos_date, p.sales_pos_due_date, p.sales_pos_number, p.sales_pos_note, 
	        p.sales_pos_total, p.sales_pos_discount, p.sales_pos_potongan
	        FROM tb_sales_pos p
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = p.id_store_contact_from
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        WHERE p.id_report_status=6 AND p.id_memo_type!=9 AND p.sales_pos_total>0 " + cond_group + " " + cond_vendor + "
	        UNION ALL
	        SELECT p.id_sales_pos, p.id_comp_contact_bill AS `id_comp_contact`, cc.id_comp, c.comp_number, c.comp_name, p.id_memo_type, p.report_mark_type, p.is_close_rec_payment,
	        p.sales_pos_date, p.sales_pos_due_date, p.sales_pos_number, p.sales_pos_note, 
	        p.sales_pos_total, p.sales_pos_discount, p.sales_pos_potongan
	        FROM tb_sales_pos p
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = p.id_comp_contact_bill
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        WHERE p.id_report_status=6 AND p.id_memo_type=9 AND p.sales_pos_total>0 " + cond_group + " " + cond_vendor + "
        ) p
        INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type` = p.`id_memo_type`
        LEFT JOIN (
	        SELECT pyd.id_report, pyd.report_mark_type, py.date_created, py.`number`, SUM(pyd.`value`) AS `value`,
	        COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_on_process`
	        FROM tb_rec_payment_det pyd
	        INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment` AND py.`id_report_status`!=5
	        GROUP BY pyd.id_report, pyd.report_mark_type
        ) pyd ON pyd.`id_report`=p.`id_sales_pos` AND pyd.`report_mark_type`=p.`report_mark_type`
        WHERE 1=1 " + cond + "
        ORDER BY p.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        load_vendor()
    End Sub
End Class