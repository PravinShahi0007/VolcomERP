Public Class FormPayoutZaloraDet
    Public id As String = "-1"
    Dim is_confirm As String = "-1"
    Dim id_comp_group As String = get_setup_field("zalora_comp_group")

    Private Sub FormPayoutZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim pz As New ClassPayoutZalora()
        Dim query As String = pz.queryMain("AND z.id_payout_zalora='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtStatementNumber.Text = data.Rows(0)("statement_number").ToString
        DECreatedAt.EditValue = data.Rows(0)("zalora_created_at")
        DESyncDate.EditValue = data.Rows(0)("sync_date")
        TxtCommision.EditValue = data.Rows(0)("default_comm")
        TxtShippingFee.EditValue = data.Rows(0)("default_shipping")
        MENote.Text = data.Rows(0)("note").ToString
        viewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutZaloraDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCommisionUpd_Click(sender As Object, e As EventArgs) Handles BtnCommisionUpd.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_payout_zalora SET default_comm='" + decimalSQL(TxtCommision.EditValue.ToString) + "', default_shipping='" + decimalSQL(TxtShippingFee.EditValue.ToString) + "' WHERE id_payout_zalora='" + id + "' "
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
        viewDetail()
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
SET d.erp_amount = (m.default_shipping * -1)
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

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_payout_zalora_det, d.id_payout_zalora, d.transaction_date, d.transaction_type,
d.amount, d.vat_in_amount, d.wht_amount, d.order_number, d.item_id, d.ol_store_id, d.order_status, d.`comment`,d.erp_status,d.erp_amount,
IFNULL(d.id_sales_order_det,0) AS `id_sales_order_det`, 
IFNULL(d.id_sales_pos_det, 0) AS `id_sales_pos_det`, sp.sales_pos_number AS `invoice_number`,
od.fail_reason AS `note_unfulfilled`, oos.number AS `oos_number`
FROM tb_payout_zalora_det d
LEFT JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
LEFT JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
LEFT JOIN tb_ol_store_oos oos ON oos.id_ol_store_oos = d.id_ol_store_oos
WHERE d.id_payout_zalora=" + id + " "
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
        viewDetail()
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
        If amo <> erp_amo Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            e.Appearance.BackColor = Color.Empty
            e.Appearance.BackColor2 = Color.Empty
        End If
    End Sub
End Class