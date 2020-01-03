Public Class FormFollowUpAR
    Private Sub FormFollowUpAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
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

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond = "AND f.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If
        Dim f As New ClassFollowUpAR()
        Dim query As String = f.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond = "AND c.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If
        Dim query As String = "SELECT far.id_follow_up_ar,cg.description AS `group` , sp.sales_pos_due_date, far.follow_up_date, far.follow_up, far.follow_up_result,
        SUM(CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2)) - IFNULL(pyd.`value`,0.00)) AS `amount`
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
        INNER JOIN tb_follow_up_ar far ON far.id_comp_group = c.id_comp_group AND far.due_date = sp.sales_pos_due_date
        WHERE sp.is_close_rec_payment=2 AND sp.id_report_status=6
        " + cond + "
        GROUP BY c.id_comp_group, sp.sales_pos_due_date, far.id_follow_up_ar
        ORDER BY cg.description ASC, sp.sales_pos_due_date ASC, far.follow_up_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActive.DataSource = data
        GVActive.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BView_Click_1(sender As Object, e As EventArgs) Handles BView.Click
        If XTCAR.SelectedTabPageIndex = 0 Then
            viewList()
        ElseIf XTCAR.SelectedTabPageIndex = 1 Then
            viewActive()
        End If
    End Sub

    Private Sub FormFollowUpAR_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    Private Sub XTCAR_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAR.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub FormFollowUpAR_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormMain.but_edit()
    End Sub

    Private Sub GVActive_DoubleClick(sender As Object, e As EventArgs) Handles GVActive.DoubleClick
        FormMain.but_edit()
    End Sub
End Class