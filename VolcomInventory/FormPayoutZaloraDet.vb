Public Class FormPayoutZaloraDet
    Public id As String = "-1"
    Dim is_confirm As String = "-1"
    Dim id_comp_group As String = get_setup_field("zalora_comp_group")

    Private Sub FormPayoutZaloraDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
        actionLoad(True)
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

    Sub actionLoad(ByVal is_load_all As Boolean)
        Cursor = Cursors.WaitCursor
        Dim pz As New ClassPayoutZalora()
        Dim query As String = pz.queryMain("AND z.id_payout_zalora='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtStatementNumber.Text = data.Rows(0)("statement_number").ToString
        DECreatedAt.EditValue = data.Rows(0)("zalora_created_at")
        DESyncDate.EditValue = data.Rows(0)("sync_date")
        MENote.Text = data.Rows(0)("note").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        If is_load_all Then
            viewSummary()
            viewERPPayout()
            SLECat.EditValue = "0"
        End If
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
        ) src ON src.order_number = main.order_number AND src.item_id = main.item_id AND src.ol_store_id = main.ol_store_id
        SET main.id_sales_order_det = src.id_sales_order_det,
        main.id_sales_pos_det = src.id_sales_pos_det 
        WHERE main.id_payout_zalora=" + id + " "
        execute_non_query_long(qon, True, "", "", "", "")
        FormMain.SplashScreenManager1.CloseWaitForm()

        'check cn
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking credit note")
        Dim qcn As String = "UPDATE tb_payout_zalora_det main
        INNER JOIN (
	        SELECT d.id_payout_zalora_det, cnd.id_sales_pos_det AS `id_sales_pos_cn_det` 
	        FROM tb_payout_zalora_det d
	        INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
	        INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos_det_ref = spd.id_sales_pos_det
	        INNER JOIN tb_sales_pos cn ON cn.id_sales_pos = cnd.id_sales_pos 
	        WHERE d.id_payout_zalora=" + id + " AND !ISNULL(d.id_sales_pos_det) AND cn.id_report_status=6
        ) src ON src.id_payout_zalora_det = main.id_payout_zalora_det
        SET main.id_sales_pos_cn_det = src.id_sales_pos_cn_det
        WHERE main.id_payout_zalora=" + id + " "
        execute_non_query_long(qcn, True, "", "", "", "")
        FormMain.SplashScreenManager1.CloseWaitForm()

        'updateStatus
        updateStatusOrder()

        'check order tidak terpenuhi
        checkUnfulfilledOrder()

        'update komisi
        execute_non_query("UPDATE tb_payout_zalora SET comm=0, comm_tax=0 WHERE id_payout_zalora='" + id + "' ", True, "", "", "", "")

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
        FormMain.SplashScreenManager1.CloseWaitForm()
        viewDetailAll()

        Cursor = Cursors.Default
    End Sub

    Sub validate_payout_by_type(ByVal typ_par As String, ByVal is_update_all As Boolean)
        If typ_par = "1" Then
            'Item Price Credit
            Dim cond As String = ""
            If Not is_update_all Then
                cond += "AND d.amount!=(d.erp_amount+IFNULL(a.erp_amount_add,0.00)) "
            End If
            Dim query As String = "-- get komisi yang ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
            JOIN tb_opt_sales os
            SET d.erp_amount = (spd.design_price_retail - sod.discount), d.id_acc = sp.id_acc_ar
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_sales_pos_det) " + cond + " ;
            -- get komisi yang tidak ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
            JOIN tb_opt_sales os
            SET d.erp_amount = (od.design_price - od.discount_allocations_amo)
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_ol_store_order) " + cond + " ; "
            execute_non_query_long(query, True, "", "", "", "")
        ElseIf typ_par = "2" Then
            'Commission
            Dim cond As String = ""
            If Not is_update_all Then
                cond += "AND d.amount!=(d.erp_amount+IFNULL(a.erp_amount_add,0.00)) "
            End If
            Dim query As String = "-- get komisi yang ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
            JOIN tb_opt_sales os
            SET d.erp_amount = ((spd.design_price_retail - sod.discount) * os.default_comm_zalora * -1), d.id_acc =  os.id_acc_default_fee_zalora
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_sales_pos_det) " + cond + " ;
            -- get komisi yang tidak ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
            JOIN tb_opt_sales os
            SET d.erp_amount = ((od.design_price - od.discount_allocations_amo) * os.default_comm_zalora * -1), d.id_acc =  os.id_acc_default_fee_zalora
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_ol_store_order) " + cond + " ; "
            execute_non_query_long(query, True, "", "", "", "")
        ElseIf typ_par = "3" Then
            'Dropshipping Item Delivery Fee
            Dim query As String = "UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            JOIN tb_opt_sales os
            SET d.erp_amount = (os.default_shipping_zalora * -1), d.id_acc = os.id_acc_default_fee_zalora
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND (!ISNULL(d.id_sales_pos_det) OR !ISNULL(d.id_ol_store_order))  "
            If Not is_update_all Then
                query += "AND d.amount!=(d.erp_amount+IFNULL(a.erp_amount_add,0.00)) "
            End If
            execute_non_query_long(query, True, "", "", "", "")
        ElseIf typ_par = "4" Then
            'Down Payment : manual
        ElseIf typ_par = "5" Then
            'Defective Penalty : Manual
        ElseIf typ_par = "6" Then
            ' item price aka refund
            Dim cond As String = ""
            If Not is_update_all Then
                cond += "AND d.amount!=(d.erp_amount+IFNULL(a.erp_amount_add,0.00)) "
            End If
            Dim query As String = "-- get komisi yang ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_cn_det
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
            JOIN tb_opt_sales os
            SET d.erp_amount = ((spd.design_price_retail*-1) - (sod.discount*-1)), d.id_acc = sp.id_acc_ar
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_sales_pos_det) " + cond + " ;
            -- get komisi yang tidak ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
            JOIN tb_opt_sales os
            SET d.erp_amount = ((od.design_price*-1) - (od.discount_allocations_amo*-1))
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_ol_store_order) " + cond + " ; "
            execute_non_query_long(query, True, "", "", "", "")
        ElseIf typ_par = "7" Then
            'commision credit aka refund komisi
            Dim cond As String = ""
            If Not is_update_all Then
                cond += "AND d.amount!=(d.erp_amount+IFNULL(a.erp_amount_add,0.00)) "
            End If
            Dim query As String = "-- get komisi yang ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_cn_det
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
            JOIN tb_opt_sales os
            SET d.erp_amount = ((spd.design_price_retail - sod.discount) * os.default_comm_zalora), d.id_acc =  os.id_acc_default_fee_zalora
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_sales_pos_det) " + cond + " ;
            -- get komisi yang tidak ada invoice
            UPDATE tb_payout_zalora_det d 
            LEFT JOIN (
                SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
                FROM tb_payout_zalora_det_addition d
                INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
                WHERE pd.id_payout_zalora=" + id + "
                GROUP BY d.id_payout_zalora_det
            ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
            INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
            INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
            INNER JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
            JOIN tb_opt_sales os
            SET d.erp_amount = ((od.design_price - od.discount_allocations_amo) * os.default_comm_zalora), d.id_acc =  os.id_acc_default_fee_zalora
            WHERE d.id_payout_zalora=" + id + " AND t.id_type=" + typ_par + " AND !ISNULL(d.id_ol_store_order) " + cond + " ; "
            execute_non_query_long(query, True, "", "", "", "")
        ElseIf typ_par = "8" Then
            'Down Payment Credit aka adjusment refund : manual
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
        SET main.`erp_status`= src.`status` 
        WHERE main.id_payout_zalora=" + id + " "
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
        SLECat.EditValue = Nothing
        SLECat.EditValue = "0"
        viewSummary()
        viewERPPayout()
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        '---- SUMMARY
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading trans. summary")
        Dim query_sum As String = "SELECT z.id_payout_zalora_cat, c.payout_zalora_cat, z.val, IFNULL(e.erp_amount,0.00) AS `erp_val`, 
(IFNULL(e.erp_amount,0.00)-z.val) AS `diff_val`
FROM (
	SELECT 1 AS `id_payout_zalora_cat`,z.opening_balance AS `val` FROM tb_payout_zalora z WHERE z.id_payout_zalora=" + id + "
	UNION ALL
	SELECT 2 AS `id_payout_zalora_cat`,z.sales_revenue AS `val` FROM tb_payout_zalora z WHERE z.id_payout_zalora=" + id + "
	UNION ALL
	SELECT 3 AS `id_payout_zalora_cat`, z.total_fees AS `val` FROM tb_payout_zalora z WHERE z.id_payout_zalora=" + id + "
	UNION ALL
	SELECT 4 AS `id_payout_zalora_cat`, z.sales_refund AS `val` FROM tb_payout_zalora z WHERE z.id_payout_zalora=" + id + "
	UNION ALL
	SELECT 5 AS `id_payout_zalora_cat`, z.total_refund_fee AS `val` FROM tb_payout_zalora z WHERE z.id_payout_zalora=" + id + "
) z
INNER JOIN tb_payout_zalora_cat c ON c.id_payout_zalora_cat = z.id_payout_zalora_cat
LEFT JOIN (
	SELECT typ.id_payout_zalora_cat, SUM(d.erp_amount + IFNULL(a.erp_amount_add,0.00)) AS `erp_amount`
	FROM tb_payout_zalora_det d
	INNER JOIN tb_payout_zalora_type typ ON typ.transaction_type = d.transaction_type
    LEFT JOIN (
        SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`
        FROM tb_payout_zalora_det_addition d
        INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
        INNER JOIN tb_payout_zalora_type typ ON typ.transaction_type = pd.transaction_type
        WHERE pd.id_payout_zalora=" + id + "
        GROUP BY typ.id_payout_zalora_cat
    ) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
	WHERE d.id_payout_zalora=" + id + " AND d.amount=(d.erp_amount+IFNULL(a.erp_amount_add,0.00))
	GROUP BY typ.id_payout_zalora_cat
) e ON e.id_payout_zalora_cat = z.id_payout_zalora_cat "
        Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")
        GCSummary.DataSource = data_sum
        GVSummary.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewERPPayout()
        Cursor = Cursors.WaitCursor
        '---- SUMMARY
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading ERP Payout")
        Dim query As String = "SELECT a.`name`, a.id_group,a.`group`, a.id_ref, a.`rmt_ref`, a.ref, a.amo,a.id_acc, coa.acc_name, coa.acc_description, a.recon_type
FROM ( 
	-- SALES REVENUE
	(SELECT  CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y'))  AS `name`, 1 AS `id_group`,'Sales Revenue' AS `group`, sp.id_sales_pos AS `id_ref`, sp.report_mark_type AS `rmt_ref`,sp.sales_pos_number AS `ref`, SUM(d.erp_amount) AS `amo`, d.id_acc, 'Auto' AS `recon_type`, d.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM tb_payout_zalora_det d 
	INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
	INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
	WHERE d.id_payout_zalora=" + id + " AND t.id_payout_zalora_cat=2 AND d.is_manual_recon=2
	GROUP BY d.id_acc, sp.id_sales_pos )
	UNION ALL
	(SELECT cd.manual_recon_reason AS `name`, 1 AS `id_group`, 'Sales Revenue' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`,'' AS `ref`, SUM(cd.erp_amount) AS `amo`, cd.id_acc, 'Manual' AS `recon_type`, cd.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM (
		SELECT d.id_payout_zalora_det,d.erp_amount, d.id_acc, d.manual_recon_reason
		FROM tb_payout_zalora_det d 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=2) AND d.is_manual_recon=1
		UNION ALL 
		SELECT a.id_payout_zalora_det,a.erp_amount, a.id_acc, d.manual_recon_reason
		FROM tb_payout_zalora_det_addition a 
		INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=2) AND d.is_manual_recon=1
	) cd
	GROUP BY cd.id_acc, cd.manual_recon_reason)
	UNION ALL
	-- komisi
	(SELECT 'Komisi penjualan Zalora' AS `name`, 2 AS `id_group`, 'Commision' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`, m.comm AS `amo`, d.id_acc, d.recon_type AS `recon_type`, '' AS manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM tb_payout_zalora m
	LEFT JOIN (
		SELECT  d.id_payout_zalora, GROUP_CONCAT(DISTINCT IF(d.is_manual_recon=2,'Auto', 'Manual')) AS `recon_type`, GROUP_CONCAT(DISTINCT d.id_acc) AS `id_acc`
		FROM tb_payout_zalora_det d
		INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5)
		GROUP BY d.id_payout_zalora
	) d ON d.id_payout_zalora = m.id_payout_zalora
	WHERE m.id_payout_zalora=" + id + ")
	UNION ALL
	(SELECT 'Komisi penjualan Zalora' AS `name`, 3 AS `id_group`, 'Commision Tax' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`, m.comm_tax AS `amo`, os.id_acc_default_comm_tax_zalora, 'Manual' AS `recon_type`, '' AS manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM tb_payout_zalora m
	JOIN tb_opt_sales os 
	WHERE m.id_payout_zalora=" + id + ")
	UNION ALL
	-- REFUND
	(SELECT  CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y'))  AS `name`, 4 AS `id_group`, 'Refund' AS `group`, sp.id_sales_pos AS `id_ref`, sp.report_mark_type AS `rmt_ref`, sp.sales_pos_number AS `ref`, SUM(d.erp_amount) AS `amo`, d.id_acc, 'Auto' AS `recon_type`, d.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM tb_payout_zalora_det d 
	INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_cn_det
	INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
	WHERE d.id_payout_zalora=" + id + " AND t.id_payout_zalora_cat=4 AND d.is_manual_recon=2
	GROUP BY d.id_acc, sp.id_sales_pos )
	UNION ALL
	(SELECT cd.manual_recon_reason AS `name`, 4 AS `id_group`, 'Refund' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`, SUM(cd.erp_amount) AS `amo`, cd.id_acc, 'Manual' AS `recon_type`, cd.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`
	FROM (
		SELECT d.id_payout_zalora_det,d.erp_amount, d.id_acc, d.manual_recon_reason
		FROM tb_payout_zalora_det d 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=4) AND d.is_manual_recon=1
		UNION ALL 
		SELECT a.id_payout_zalora_det,a.erp_amount, a.id_acc, d.manual_recon_reason
		FROM tb_payout_zalora_det_addition a 
		INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=4) AND d.is_manual_recon=1
	) cd
	GROUP BY cd.id_acc, cd.manual_recon_reason)
	UNION ALL
	(SELECT a.note AS `name`, 5 AS `id_group`, 'Adjustment' AS `group`, IFNULL(a.id_report,0) AS `id_ref`, IFNULL(a.report_mark_type,0) AS `rmt_ref`, IFNULL(a.report_number,'')  AS `ref`, a.adj_value AS `amo`, a.id_acc, 'Manual' AS `recon_type`, '' AS `manual_recon_reason`, a.id_payout_zalora_det_adj
	FROM tb_payout_zalora_det_adj a
	WHERE a.id_payout_zalora=" + id + " AND a.adj_value>0)
)a
INNER JOIN tb_a_acc coa ON coa.id_acc = a.id_acc
ORDER BY a.id_group ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCERPPay.DataSource = data
        GCERPPay.RefreshDataSource()
        GVERPPay.RefreshData()
        GVERPPay.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub


    Sub viewDetailRecon(ByVal id_cat As String)
        Cursor = Cursors.WaitCursor
        '-----DETAIL
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading trans. detail")

        'cat
        Dim cond_cat As String = ""
        If id_cat <> "0" Then
            cond_cat = "And typ.id_payout_zalora_cat='" + id_cat + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,d.id_payout_zalora_det, d.id_payout_zalora, d.transaction_date, d.transaction_type, typ.id_payout_zalora_cat,
d.amount, d.vat_in_amount, d.wht_amount, d.order_number, d.item_id, d.ol_store_id, d.order_status, d.`comment`,d.erp_status,(d.erp_amount + IFNULL(a.erp_amount_add,0.00)) AS `erp_amount`,
IFNULL(d.id_sales_order_det,0) AS `id_sales_order_det`, 
IFNULL(d.id_sales_pos_det, 0) AS `id_sales_pos_det`, sp.sales_pos_number AS `invoice_number`, sp.id_sales_pos,
IFNULL(d.id_sales_pos_cn_det, 0) AS `id_sales_pos_cn_det`, cn.sales_pos_number AS `cn_number`, cn.id_sales_pos AS `id_cn`,
od.fail_reason AS `note_unfulfilled`, oos.number AS `oos_number`,
d.is_manual_recon,IF(d.is_manual_recon=1,'Manual','Auto') AS `recon_type`, d.manual_recon_reason,
IFNULL(d.id_acc,0) AS `id_acc`, CONCAT(coa.acc_name, IF(ISNULL(a.acc_name),'',CONCAT(',',a.acc_name))) AS `acc_name`, CONCAT(coa.acc_description, IF(ISNULL(a.acc_description),'',CONCAT(',',a.acc_description))) AS `acc_description`
FROM tb_payout_zalora_det d
INNER JOIN tb_payout_zalora_type typ ON typ.transaction_type = d.transaction_type
LEFT JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
LEFT JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos_det = d.id_sales_pos_cn_det
LEFT JOIN tb_sales_pos cn ON cn.id_sales_pos = cnd.id_sales_pos
LEFT JOIN tb_ol_store_order od ON od.id_ol_store_order = d.id_ol_store_order
LEFT JOIN tb_ol_store_oos oos ON oos.id_ol_store_oos = d.id_ol_store_oos
LEFT JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
LEFT JOIN (
    SELECT d.id_payout_zalora_det, SUM(d.erp_amount) AS `erp_amount_add`, 
    GROUP_CONCAT(DISTINCT coa.acc_name) AS `acc_name`, GROUP_CONCAT(DISTINCT coa.acc_description) AS `acc_description`
    FROM tb_payout_zalora_det_addition d
    INNER JOIN tb_payout_zalora_det pd ON pd.id_payout_zalora_det = d.id_payout_zalora_det
    INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
    WHERE pd.id_payout_zalora=" + id + "
    GROUP BY d.id_payout_zalora_det
) a ON a.id_payout_zalora_det = d.id_payout_zalora_det
WHERE d.id_payout_zalora=" + id + " " + cond_cat
        query += "ORDER BY d.order_number ASC, d.item_id ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GCData.RefreshDataSource()
        GVData.RefreshData()
        'BandedGridColumntransaction_type.GroupIndex = 0
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub Btnrecalculate_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("this action will be update the data. Are you sure you want to validate these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            validate_payout(False)
        End If
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
            Cursor = Cursors.WaitCursor
            FormPayoutZaloraManualReconSingle.id_payout_zalora_cat = SLECat.EditValue.ToString
            FormPayoutZaloraManualReconSingle.id_det = GVData.GetFocusedRowCellValue("id_payout_zalora_det").ToString
            FormPayoutZaloraManualReconSingle.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 0 Then
            PanelControlDetail.Visible = False
            makeSafeGV(GVData)
            If SLECat.EditValue.ToString <> "0" Then
                GCData.DataSource = Nothing
                CESelectAll.EditValue = False
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
        viewDetailRecon(id_cat)
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
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        If GVData.RowCount > 0 Then
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            For i As Integer = 0 To GVData.RowCount - 1
                If CESelectAll.EditValue = True Then
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Selected " + i.ToString + " of " + GVData.RowCount.ToString)
                    GVData.SetRowCellValue(i, "is_select", "Yes")
                Else
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Unselected " + i.ToString + " of " + GVData.RowCount.ToString)
                    GVData.SetRowCellValue(i, "is_select", "No")
                End If
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub GVSummary_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVSummary.RowStyle
        Dim diff_val As Decimal = 0.00
        Try
            diff_val = GVSummary.GetRowCellValue(e.RowHandle, "diff_val")
        Catch ex As Exception
        End Try

        If diff_val <> 0.00 Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            e.Appearance.BackColor = Color.Empty
            e.Appearance.BackColor2 = Color.Empty
        End If
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            Dim id_cat As String = GVSummary.GetFocusedRowCellValue("id_payout_zalora_cat").ToString
            SLECat.EditValue = id_cat
            XTCData.SelectedTabPageIndex = 1
        End If
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim inv As New FormViewSalesPOS()
            inv.id_sales_pos = GVData.GetFocusedRowCellValue("id_sales_pos").ToString
            inv.ShowDialog()
        End If
    End Sub

    Private Sub RepoLinkCN_Click(sender As Object, e As EventArgs) Handles RepoLinkCN.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim inv As New FormViewSalesPOS()
            inv.id_sales_pos = GVData.GetFocusedRowCellValue("id_cn").ToString
            inv.ShowDialog()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVERPPay.RowCount > 0 And GVERPPay.FocusedRowHandle >= 0 And is_confirm = 2 Then
            If GVERPPay.GetFocusedRowCellValue("id_group").ToString <> "5" Then
                stopCustom("Can't delete, this item is mandatory")
            Else
                Dim id_payout_zalora_det_adj As String = GVERPPay.GetFocusedRowCellValue("id_payout_zalora_det_adj").ToString
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query As String = "DELETE FROM tb_tb_payout_zalora_det_adj WHERE id_payout_zalora_det_adj='" + id_payout_zalora_det_adj + "' "
                    execute_non_query(query, True, "", "", "", "")
                    viewERPPayout()
                End If
            End If
        End If
    End Sub

    Private Sub GVERPPay_DoubleClick(sender As Object, e As EventArgs) Handles GVERPPay.DoubleClick
        If GVERPPay.RowCount > 0 And GVERPPay.FocusedRowHandle >= 0 And is_confirm = 2 Then
            Dim id_group As String = GVERPPay.GetFocusedRowCellValue("id_group").ToString
            If id_group = "2" Or id_group = "3" Then
                'komisi
                Cursor = Cursors.WaitCursor
                FormPayoutZaloraComm.id = id
                FormPayoutZaloraComm.ShowDialog()
                Cursor = Cursors.Default
            ElseIf id_group = "5" Then
                'adjustment
            Else
                'sales & refund
                Dim id_cat As String = ""
                If id_group = "1" Then
                    'sales
                    id_cat = "2"
                Else
                    'refund
                    id_cat = "4"
                End If
                SLECat.EditValue = id_cat
                XTCData.SelectedTabPageIndex = 1
            End If
        End If
    End Sub
End Class