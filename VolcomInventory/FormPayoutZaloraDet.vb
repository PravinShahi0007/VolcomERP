Public Class FormPayoutZaloraDet
    Public id As String = "-1"
    Dim is_confirm As String = "-1"
    Dim id_comp_group As String = get_setup_field("zalora_comp_group")

    Private Sub FormPayoutZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewCat()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description,CONCAT(a.acc_name,' - ', a.acc_description) AS `acc`, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOAFee, query, "id_acc", "acc", "id_acc")
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_payout_zalora_cat, 'All' AS payout_zalora_cat 
UNION ALL
SELECT c.id_payout_zalora_cat, c.payout_zalora_cat 
FROM tb_payout_zalora_cat c"
        viewSearchLookupQuery(SLECat, query, "id_payout_zalora_cat", "payout_zalora_cat", "id_payout_zalora_cat")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim pz As New ClassPayoutZalora()
        Dim query As String = pz.queryMain("AND z.id_payout_zalora='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtStatementNumber.Text = data.Rows(0)("statement_number").ToString
        DECreatedAt.EditValue = data.Rows(0)("zalora_created_at")
        DESyncDate.EditValue = data.Rows(0)("sync_date")
        SLECOAFee.EditValue = data.Rows(0)("id_acc_default_fee")
        TxtCommision.EditValue = data.Rows(0)("default_comm")
        TxtShippingFee.EditValue = data.Rows(0)("default_shipping")
        MENote.Text = data.Rows(0)("note").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        SLECat.EditValue = "0"
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutZaloraDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCommisionUpd_Click(sender As Object, e As EventArgs) Handles BtnCommisionUpd.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_payout_zalora 
        SET default_comm='" + decimalSQL(TxtCommision.EditValue.ToString) + "', default_shipping='" + decimalSQL(TxtShippingFee.EditValue.ToString) + "',
        id_acc_default_fee='" + SLECOAFee.EditValue.ToString + "'
        WHERE id_payout_zalora='" + id + "' "
        execute_non_query(query, True, "", "", "", "")
        infoCustom("Default value updated")
        validate_payout(True)
        Cursor = Cursors.Default
    End Sub

    Sub validate_payout(ByVal is_update_all As Boolean)
        Cursor = Cursors.WaitCursor


        'check order number based on invoice
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking order number")
        Dim qon As String = "UPDATE tb_payout_zalora_det main
        INNER JOIN (
            SELECT sod.id_sales_order_det, spd.id_sales_pos_det,so.sales_order_ol_shop_number AS `order_number`, sod.item_id, sod.ol_store_id
            FROM tb_sales_pos_det spd
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = spd.id_pl_sales_order_del_det
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            WHERE sp.id_report_status=6 AND s.id_comp_group=" + id_comp_group + " 
            AND !ISNULL(sod.item_id) AND !ISNULL(sod.ol_store_id)
            -- AND sp.is_close_rec_payment=2
            GROUP BY spd.id_sales_pos_det
        ) src ON src.order_number = main.order_number 
        SET main.id_sales_order_det = src.id_sales_order_det,
        main.id_sales_pos_det = src.id_sales_pos_det "
        execute_non_query_long(qon, True, "", "", "", "")
        FormMain.SplashScreenManager1.CloseWaitForm()

        'updateStatus
        updateStatusOrder()

        'check order tidak terpenuhi
        checkUnfulfilledOrder()

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim qtyp As String = "SELECT t.id_type, t.transaction_type, t.id_payout_zalora_cat 
        FROM tb_payout_zalora_type t 
        ORDER BY t.id_type ASC "
        Dim dtyp As DataTable = execute_query(qtyp, -1, True, "", "", "", "")
        Dim ord As New ClassSalesOrder()
        For i As Integer = 0 To dtyp.Rows.Count - 1
            Dim typ As String = dtyp.Rows(i)("id_type").ToString
            FormMain.SplashScreenManager1.SetWaitFormDescription("Checking " + dtyp.Rows(i)("transaction_type").ToString)
            validate_payout_by_type(typ, is_update_all)
        Next
        viewDetailAll()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub validate_payout_by_type(ByVal typ_par As String, ByVal is_update_all As Boolean)
        If typ_par = "1" Then
            'Item Price Credit
        ElseIf typ_par = "2" Then
            'Commission
        ElseIf typ_par = "3" Then
            'Dropshipping Item Delivery Fee
            Dim query As String = "UPDATE tb_payout_zalora_det d 
INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
SET d.erp_amount = (m.default_shipping * -1), d.id_acc = m.id_acc_default_fee
WHERE d.id_payout_zalora=" + id + " AND t.id_type=3 AND (!ISNULL(d.id_sales_pos_det) OR !ISNULL(d.id_ol_store_order))  "
            If Not is_update_all Then
                query += "AND d.amount!=d.erp_amount "
            End If
            execute_non_query_long(query, True, "", "", "", "")
        End If
    End Sub

    Sub updateStatusOrder()
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Get order status")
        Dim query As String = "UPDATE tb_payout_zalora_det main 
        INNER JOIN (
            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
            FROM tb_sales_order_det_status stt
            INNER JOIN (
	            SELECT stt.id_sales_order_det, MAX(stt.status_date) AS `status_date`
	            FROM tb_sales_order_det_status stt
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = stt.id_sales_order_det
	            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
	            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	            WHERE so.id_report_status=6 AND c.id_comp_group=" + id_comp_group + " 
	            GROUP BY stt.id_sales_order_det
            ) max_stt ON max_stt.id_sales_order_det = stt.id_sales_order_det AND max_stt.status_date = stt.status_date
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = stt.id_sales_order_det
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            WHERE so.id_report_status=6 AND c.id_comp_group=" + id_comp_group + "
            GROUP BY stt.id_sales_order_det
        ) src ON src.id_sales_order_det = main.id_sales_order_det
        SET main.`erp_status`= src.`status` "
        execute_non_query_long(query, True, "", "", "", "")
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Sub checkUnfulfilledOrder()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Check unfulfilled order")
        Dim query As String = "UPDATE tb_payout_zalora_det d
INNER JOIN tb_ol_store_order od ON od.sales_order_ol_shop_number = d.order_number AND od.item_id = d.item_id AND od.ol_store_id = d.ol_store_id
SET d.id_ol_store_order = od.id_ol_store_order, d.id_ol_store_oos = od.id_ol_store_oos
WHERE ISNULL(d.id_sales_pos_det) AND od.sales_order_det_qty=0 "
        execute_non_query_long(query, True, "", "", "", "")
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailAll()
        SLECat.EditValue = "0"
        viewDetail("0")
    End Sub

    Sub viewDetail(ByVal id_cat As String)
        Cursor = Cursors.WaitCursor
        'cat
        Dim cond_cat As String = ""
        If id_cat <> "0" Then
            cond_cat = "AND typ.id_payout_zalora_cat='" + id_cat + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,d.id_payout_zalora_det, d.id_payout_zalora, d.transaction_date, d.transaction_type, typ.id_payout_zalora_cat,
d.amount, d.vat_in_amount, d.wht_amount, d.order_number, d.item_id, d.ol_store_id, d.order_status, d.`comment`,d.erp_status,d.erp_amount,
IFNULL(d.id_sales_order_det,0) AS `id_sales_order_det`, 
IFNULL(d.id_sales_pos_det, 0) AS `id_sales_pos_det`, sp.sales_pos_number AS `invoice_number`,
od.fail_reason AS `note_unfulfilled`, oos.number AS `oos_number`,
d.is_manual_recon,IF(d.is_manual_recon=1,'Manual','Auto') AS `recon_type`, d.manual_recon_reason,
d.id_acc, coa.acc_name, coa.acc_description
FROM tb_payout_zalora_det d
INNER JOIN tb_payout_zalora_type typ ON typ.transaction_type = d.transaction_type
LEFT JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
LEFT JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
LEFT JOIN tb_ol_store_oos oos ON oos.id_ol_store_oos = d.id_ol_store_oos
LEFT JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
WHERE d.id_payout_zalora=" + id + " " + cond_cat
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GCData.RefreshDataSource()
        GVData.RefreshData()
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub Btnrecalculate_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        validate_payout(False)
    End Sub

    Private Sub BtnImportXls_Click(sender As Object, e As EventArgs) Handles BtnImportXls.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "55"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnUpdateStatus_Click(sender As Object, e As EventArgs) Handles BtnUpdateStatus.Click
        Cursor = Cursors.WaitCursor
        updateStatusOrder()
        viewDetailAll()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVData.RowStyle
        Dim amo As String = 0.00
        Try
            amo = GVData.GetRowCellValue(e.RowHandle, "amount")
        Catch ex As Exception
        End Try
        Dim erp_amo As String = 0.00
        Try
            erp_amo = GVData.GetRowCellValue(e.RowHandle, "erp_amount")
        Catch ex As Exception
        End Try
        Dim is_manual_recon As String = "0"
        Try
            is_manual_recon = GVData.GetRowCellValue(e.RowHandle, "is_manual_recon").ToString
        Catch ex As Exception
        End Try
        If amo <> erp_amo Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            If is_manual_recon = "1" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
                e.Appearance.BackColor2 = Color.Empty
            End If
        End If
    End Sub

    Private Sub ManualReconToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualReconToolStripMenuItem.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then

        End If
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 0 Then
            PanelControlDetail.Visible = False
            If SLECat.EditValue.ToString <> "0" Then
                viewDetailAll()
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            If is_confirm = "2" Then
                PanelControlDetail.Visible = True
            Else
                PanelControlDetail.Visible = False
            End If
        End If
    End Sub

    Private Sub SLECat_EditValueChanged(sender As Object, e As EventArgs) Handles SLECat.EditValueChanged
        Dim id_cat As String = "-1"
        Try
            id_cat = SLECat.EditValue.ToString
        Catch ex As Exception
        End Try
        viewDetail(id_cat)
    End Sub

    Private Sub BtnManualRecon_Click(sender As Object, e As EventArgs) Handles BtnManualRecon.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount <= 0 Then
            warningCustom("Please select item")
        Else
            Cursor = Cursors.WaitCursor
            FormPayoutZaloraManualRecon.id_payout_zalora_cat = SLECat.EditValue.ToString
            FormPayoutZaloraManualRecon.id = id
            FormPayoutZaloraManualRecon.ShowDialog()
            Cursor = Cursors.Default
        End If
        makeSafeGV(GVData)
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i As Integer = 0 To GVData.RowCount - 1
            If CESelectAll.EditValue = True Then
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub
End Class