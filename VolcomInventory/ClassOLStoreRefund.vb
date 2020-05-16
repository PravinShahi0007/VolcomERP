Public Class ClassOLStoreRefund
    Sub createCN()
        Dim report_mark_type As String = "118"
        Dim qcn As String = "SELECT spd.id_sales_pos, so.sales_order_ol_shop_number AS `order_number`,
        sp.id_store_contact_from, sp.sales_pos_discount, sp.sales_pos_vat, sp.id_acc_ar, sp.id_acc_sales, sp.id_acc_sales_return
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
        WHERE l.id_ol_store_ret_stt=6
        GROUP BY spd.id_sales_pos,so.sales_order_ol_shop_number "
        Dim dcn As DataTable = execute_query(qcn, -1, True, "", "", "", "")
        If dcn.Rows.Count > 0 Then
            For c As Integer = 0 To dcn.Rows.Count - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Create credit note : " + (c + 1).ToString + " of " + dcn.Rows.Count.ToString)
                'main
                Dim id_so_type As String = "0"
                Dim id_inv_type As String = "0"
                Dim id_memo_type As String = "2"
                Dim qm As String = "INSERT INTO tb_sales_pos(id_store_contact_from, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_potongan, sales_pos_vat, id_memo_type, id_inv_type, id_sales_pos_ref, report_mark_type, id_acc_ar, id_acc_sales, id_acc_sales_return) 
                VALUES('" + dcn.Rows(c)("id_store_contact_from").ToString + "', NOW(), '', 1, '" + id_so_type + "',0, NOW(), NOW(), NOW(), '" + decimalSQL(dcn.Rows(c)("sales_pos_discount").ToString) + "', 0, '" + dcn.Rows(c)("sales_pos_vat").ToString + "', '" + id_memo_type + "', '" + id_inv_type + "', '" + dcn.Rows(c)("id_sales_pos").ToString + "', '118', '" + dcn.Rows(c)("id_acc_ar").ToString + "', '" + dcn.Rows(c)("id_acc_sales").ToString + "', '" + dcn.Rows(c)("id_acc_sales_return").ToString + "'); SELECT LAST_INSERT_ID(); "
                Dim id_cn As String = execute_query(qm, 0, True, "", "", "", "")
                'gen number
                execute_non_query("CALL gen_number(" + id_cn + ", " + report_mark_type + ");", True, "", "", "", "")
                'detail
                Dim qd As String = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail, note, id_sales_pos_det_ref, id_ol_store_ret_list) 
                SELECT '" + id_cn + "', p.id_product, id.id_design_price, id.design_price, id.sales_pos_det_qty*-1 AS sales_pos_det_qty,
                id.id_design_price_retail, id.design_price_retail, 'OK' AS `note`, id.id_sales_pos_det AS `id_sales_pos_det_ref`, l.id_ol_store_ret_list
                FROM tb_ol_store_ret_list l
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
                INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
                INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
                INNER JOIN tb_m_product p ON p.id_product = id.id_product
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                INNER JOIN tb_m_design_price prc ON prc.id_design_price = id.id_design_price_retail
                INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
                WHERE l.id_ol_store_ret_stt=6 AND  r.sales_order_ol_shop_number='" + dcn.Rows(c)("order_number").ToString + "' AND i.id_sales_pos=" + dcn.Rows(c)("id_sales_pos").ToString + " ;
                -- update total qty
                UPDATE tb_sales_pos main
                INNER JOIN (
                    SELECT pd.id_sales_pos,ABS(SUM(pd.sales_pos_det_qty)) AS `total`, ABS(SUM(pd.sales_pos_det_qty * pd.design_price_retail)) AS `total_amount`
                    FROM tb_sales_pos_det pd
                    WHERE pd.id_sales_pos=" + id_cn + "
                    GROUP BY pd.id_sales_pos
                ) src ON src.id_sales_pos = main.id_sales_pos
                SET main.sales_pos_total_qty = src.total, main.sales_pos_total=src.total_amount; "
                execute_non_query(qd, True, "", "", "", "")
                'submit prepared
                Dim id_user_prepared_inv As String = get_opt_acc_field("invoice_prepared_by")
                submit_who_prepared(report_mark_type, id_cn, id_user_prepared_inv)
                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_cn)
                execute_non_query(queryrm, True, "", "", "", "")
                'journal draft
                Dim acc As New ClassAccounting()
                acc.generateJournalSalesDraftWithMapping(id_cn, report_mark_type)
                'complete
                Dim stc_in As ClassSalesInv = New ClassSalesInv()
                stc_in.completeInStock(id_cn, report_mark_type)
                'update status
                Dim qu As String = "-- update status di return center
                UPDATE tb_ol_store_ret_list main
                INNER JOIN (
	                SELECT d.id_ol_store_ret_list 
	                FROM tb_sales_pos_det d
	                WHERE d.id_sales_pos=" + id_cn + "
	                GROUP BY d.id_ol_store_ret_list
                ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                SET main.id_ol_store_ret_stt=7;
                INSERT INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                FROM tb_sales_pos_det d
                INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=7
                WHERE d.id_sales_pos=" + id_cn + "
                GROUP BY rd.id_sales_order_det;
                -- update sttatus trans
                UPDATE tb_sales_pos SET id_report_status=6 WHERE id_sales_pos=" + id_cn + ";"
                execute_non_query(qu, True, "", "", "", "")
            Next
        End If
    End Sub

    Sub createROR()
        Dim query As String = "SELECT so.id_sales_order,so.sales_order_ol_shop_number AS `order_number`, so.customer_name, 
        c.comp_number, c.comp_name, c.id_comp, IF(c.id_store_type=3, 2, c.id_store_type) AS `id_store_type`
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_lookup_store_type t ON t.id_store_type = c.id_store_type
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order 
        LEFT JOIN (
	        SELECT spd.id_ol_store_ret_list 
            FROM tb_sales_return_order_det spd
	        INNER JOIN tb_sales_return_order sp ON sp.id_sales_return_order = spd.id_sales_return_order
	        WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_ol_store_ret_list)
	        GROUP BY spd.id_ol_store_ret_list
        ) e ON e.id_ol_store_ret_list = l.id_ol_store_ret_list 
        WHERE l.id_ol_store_ret_stt=7 AND ISNULL(e.id_ol_store_ret_list)
        GROUP BY c.id_comp, so.id_sales_order "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            For i As Integer = 0 To data.Rows.Count - 1

            Next
        End If
    End Sub
End Class
