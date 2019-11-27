Public Class FormMailManage
    Public id_menu As String = "1"
    Public already_open_invoice As Boolean = False
    Public already_open_invoice_unpaid As Boolean = False

    '1=for accounting

    Private Sub FormMailManage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        '-- invoice list
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'Select Group' AS comp_group, 'Select Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        viewSearchLookupQuery(SLEStoreGroupUnpaid, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPending_Click(sender As Object, e As EventArgs) Handles BtnPending.Click
        loadInvoice("AND sp.is_pending_mail=1 ")
    End Sub

    Sub loadInvoice(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString

        If id_comp_group = "0" Then
            stopCustom("Please select store group first")
        Else
            Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`, sp.`sales_pos_start_period`, sp.`sales_pos_end_period`
            ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`, sp.sales_pos_total_qty,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
            ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(sp.`sales_pos_due_date`,NOW()) AS due_days
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.`id_report_status`='6' AND c.id_comp_group='" + id_comp_group + "' 
            " + cond + "
            GROUP BY sp.`id_sales_pos` 
            ORDER BY id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCInvoiceList.DataSource = data
            GVInvoiceList.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub loadUnpaidInvoice(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString

        If id_comp_group = "0" Then
            stopCustom("Please select store group first")
        Else
            Dim query As String = "SELECT 'no' AS is_check,sp.is_close_rec_payment,sp.`id_sales_pos`,sp.sales_pos_note,sp.`sales_pos_number`,sp.`id_memo_type`,typ.`memo_type`,typ.`is_receive_payment`,sp.`sales_pos_date`,sp.`id_store_contact_from`, c.id_comp,c.comp_number,c.`comp_name`, cg.comp_group,sp.`sales_pos_due_date`, sp.`sales_pos_start_period`, sp.`sales_pos_end_period`
            ,sp.`sales_pos_total`,sp.`sales_pos_discount`,sp.`sales_pos_vat`,sp.`sales_pos_potongan`, sp.sales_pos_total_qty, IFNULL(pyd.`value`,0.00) AS total_rec, 
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS total_due,
            CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
            ,sp.report_mark_type,rmt.report_mark_type_name
            ,DATEDIFF(NOW(),sp.`sales_pos_due_date`) AS due_days
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND c.id_comp_group='" + id_comp_group + "' 
            " + cond + "
            GROUP BY sp.`id_sales_pos` 
            ORDER BY id_sales_pos ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCUnpaid.DataSource = data
            GVUnpaid.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAlreadyProcessed_Click(sender As Object, e As EventArgs) Handles BtnAlreadyProcessed.Click
        loadInvoice("AND sp.is_pending_mail=2 ")
    End Sub

    Private Sub CESelectAllInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllInvoice.CheckedChanged
        Dim val As String = ""
        If CESelectAllInvoice.EditValue = True Then
            val = "yes"
        Else
            val = "no"
        End If

        For i As Integer = 0 To GVInvoiceList.RowCount - 1
            GVInvoiceList.SetRowCellValue(i, "is_check", val)
        Next
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
        If id_comp_group <> "0" Then
            Cursor = Cursors.WaitCursor
            '--- check email group
            Dim qcg As String = "-- cari to untuk group toko
            SELECT cc.email AS `email_group`
            FROM tb_mail_manage_mapping m
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            WHERE m.id_comp_group=" + id_comp_group + " AND m.report_mark_type=225 AND m.id_mail_member_type=2 AND cc.email!='' "
            Dim dcg As DataTable = execute_query(qcg, -1, True, "", "", "", "")
            If dcg.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                stopCustom("Email store group not found. Please mapping email first.")
                Exit Sub
            End If

            '-- check email from (internal)
            Dim qci As String = "-- cari internal from
            SELECT e.email_external
            FROM tb_mail_manage_mapping_intern i
            INNER JOIN tb_m_user u ON u.id_user = i.id_user
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE i.report_mark_type=225 AND i.id_mail_member_type=1 AND e.email_external!='' "
            Dim dci As DataTable = execute_query(qci, -1, True, "", "", "", "")
            If dci.Rows.Count <= 0 Then
                Cursor = Cursors.Default
                stopCustom("Email from not found. Please mapping email first.")
                Exit Sub
            End If


            '---filter check
            makeSafeGV(GVInvoiceList)
            GVInvoiceList.ActiveFilterString = "[is_check]='yes'"
            'load detil form
            FormMailManageDet.rmt = "225"
            FormMailManageDet.action = "ins"
            FormMailManageDet.ShowDialog()


            GVInvoiceList.ActiveFilterString = ""
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        GCInvoiceList.DataSource = Nothing
    End Sub

    Sub viewMailManage()
        Cursor = Cursors.WaitCursor

        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim mm As New ClassMailManage()
        Dim query As String = mm.queryMain("AND (DATE(m.created_date)>='" + date_from_selected + "' AND DATE(m.created_date)<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        viewMailManage()
    End Sub

    Private Sub XTCMailManage_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMailManage.SelectedPageChanged
        check_menu()
        If XTCMailManage.SelectedTabPageIndex = 0 Then

        ElseIf XTCMailManage.SelectedTabPageIndex = 1 Then
            If Not already_open_invoice Then
                'load pending invoice
                FormMailManagePendingInvoice.show_direct = True
                viewPendingMailGroup()
            End If
        ElseIf XTCMailManage.SelectedTabPageIndex = 2 Then
        End If
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormMailManage_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormMailManage_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVInvoiceList.RowCount > 0 And GVInvoiceList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = GVInvoiceList.GetFocusedRowCellValue("report_mark_type").ToString
            m.id_report = GVInvoiceList.GetFocusedRowCellValue("id_sales_pos").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPendingGroup_Click(sender As Object, e As EventArgs) Handles BtnPendingGroup.Click
        viewPendingMailGroup()
    End Sub

    Sub viewPendingMailGroup()
        Cursor = Cursors.WaitCursor
        FormMailManagePendingInvoice.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelectAllUnpaidInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAllUnpaidInvoice.CheckedChanged
        Dim val As String = ""
        If CESelectAllUnpaidInvoice.EditValue = True Then
            val = "yes"
        Else
            val = "no"
        End If

        For i As Integer = 0 To GVUnpaid.RowCount - 1
            GVUnpaid.SetRowCellValue(i, "is_check", val)
        Next
    End Sub

    Private Sub BtnAllInvoiceOpen_Click(sender As Object, e As EventArgs) Handles BtnAllInvoiceOpen.Click
        loadUnpaidInvoice("")
    End Sub

    Private Sub BtnMinThreeOverdue_Click(sender As Object, e As EventArgs) Handles BtnMinThreeOverdue.Click
        loadUnpaidInvoice("AND (DATEDIFF(NOW(),sp.`sales_pos_due_date`)>=-5 AND DATEDIFF(NOW(),sp.`sales_pos_due_date`)<0) ")
    End Sub

    Private Sub BtnOverdue_Click(sender As Object, e As EventArgs) Handles BtnOverdue.Click
        loadUnpaidInvoice("AND (DATEDIFF(NOW(),sp.`sales_pos_due_date`)>=0) ")
    End Sub
End Class