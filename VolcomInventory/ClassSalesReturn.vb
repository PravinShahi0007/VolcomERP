﻿Public Class ClassSalesReturn
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = ""
        query += "SELECT a.id_store_contact_from,a.id_comp_contact_to, a.id_report_status, a.id_sales_return, a.id_sales_return_order, a.sales_return_date, "
        query += "a.sales_return_note, a.combine_number,a.sales_return_number, a.sales_return_store_number,  "
        query += "CONCAT(c.comp_number,' - ',c.comp_name) AS store_name_from, (c.comp_name) AS store_name_to, "
        query += "CONCAT(e.comp_number,' - ',e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, "
        query += "f.sales_return_order_number, g.report_status, a.last_update, getUserEmp(a.last_update_by, '1') AS `last_user`, ('No') AS `is_select`, 
        a.id_ret_type, rty.ret_type, IFNULL(det.`total`,0) AS `total`, IFNULL(nsi.total_nsi,0) AS `total_nsi`, 
        so.sales_order_ol_shop_number, IFNULL(f.id_sales_order,0) AS `id_sales_order`, 
        IF(a.id_ret_type=1,'46',IF(a.id_ret_type=3,113,IF(a.id_ret_type=4,120,111))) AS `rmt`, IFNULL(pb.prepared_by,'-') AS `prepared_by`,pb.report_mark_datetime AS `prepared_date`,
        a.is_non_list, IF(a.is_non_list=1,'Yes', 'No') AS `is_non_list_view`, pc.final_comment "
        query += "FROM tb_sales_return a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return_order f ON f.id_sales_return_order = a.id_sales_return_order 
        LEFT JOIN tb_sales_order so ON so.id_sales_order = f.id_sales_order "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "LEFT JOIN (
        SELECT r.id_sales_return, SUM(rd.sales_return_det_qty) AS `total`
        FROM tb_sales_return r
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return
        GROUP BY r.id_sales_return 
        ) det ON det.id_sales_return = a.id_sales_return 
        LEFT JOIN (
            SELECT p.id_sales_return, COUNT(p.id_sales_return) AS `total_nsi` 
            FROM tb_sales_return_problem p
            GROUP BY p.id_sales_return
        ) nsi ON nsi.id_sales_return = a.id_sales_return 
        LEFT JOIN tb_lookup_ret_type rty ON rty.id_ret_type = a.id_ret_type 
        LEFT JOIN (
            SELECT rm.id_report, e.employee_name AS `prepared_by`, rm.report_mark_datetime
            FROM tb_report_mark rm
            INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
            WHERE (rm.report_mark_type=46 OR rm.report_mark_type=113 OR rm.report_mark_type=120 OR rm.report_mark_type=111) AND rm.id_report_status=1
            GROUP BY rm.id_report
        ) pb ON pb.id_report = a.id_sales_return
        LEFT JOIN (
            SELECT id_report, final_comment
            FROM tb_report_mark_final_comment
            WHERE report_mark_type = 46 OR report_mark_type = 113 OR report_mark_type = 120 OR report_mark_type = 111
            GROUP BY id_report
        ) pc ON pc.id_report = a.id_sales_return "
        query += "WHERE a.id_sales_return>0 "
        query += condition + " "
        query += "ORDER BY a.id_sales_return " + order_type
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String, ByVal is_by_barcode As Boolean) As DataTable
        Dim query As String = ""
        If is_by_barcode Then
            query = "CALL view_sales_return_main(""" + condition + """, " + order_type + ")"
        Else
            query = "CALL view_sales_return_main_code(""" + condition + """, " + order_type + ")"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function transactionListNSI(ByVal condition As String, ByVal order_type As String) As DataTable
        Dim query As String = "CALL view_sales_return_nsi_main(""" + condition + """, " + order_type + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "5" Then
            Dim is_use_unique_code As String = execute_query("SELECT is_use_unique_code FROM tb_sales_return WHERE id_sales_return='" + id_report_par + "' ", 0, True, "", "", "", "")
            If is_use_unique_code = "1" Then
                cancellUnique(id_report_par)
            End If

            'cancel reserved stock store
            Dim stc_cancel As ClassSalesReturn = New ClassSalesReturn()
            stc_cancel.cancelReservedStock(id_report_par)
        ElseIf id_status_reportx_par = "6" Then
            ' jika complete
            Dim stc_compl As ClassSalesReturn = New ClassSalesReturn()
            stc_compl.completeReservedStock(id_report_par)

            'complete unique
            completeUnique(id_report_par)

            'save unreg unique
            execute_non_query("CALL generate_unreg_barcode(" + id_report_par + ",3)", True, "", "", "", "")
        End If

        Dim query As String = String.Format("UPDATE tb_sales_return SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_sales_return ='{1}';
        /*update status sj*/
        CALL update_store_ret_status(" + id_report_par + ");", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub changeStatusOLStore(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            ' jika complete
            Dim id_ro As String = execute_query("SELECT id_sales_return_order FROM tb_sales_return WHERE id_sales_return='" + id_report_par + "' ", 0, True, "", "", "", "")

            Dim query_stc As String = "
            -- delete ro first (strage)
             DELETE FROM tb_storage_fg 
            WHERE report_mark_type=119 AND id_report=" + id_ro + " AND report_mark_type_ref=120 AND id_report_ref=" + id_report_par + " AND id_storage_category=1 AND id_stock_status=2 ;
              -- delete ret first (strage)
            DELETE FROM tb_storage_fg 
            WHERE report_mark_type=120 AND id_report=" + id_report_par + ";
            -- insert storaghe
            INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref) 
            SELECT getCompByContact(ro.id_store_contact_to, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '119', ro.id_sales_return_order, rd.sales_return_det_qty, NOW(), '', '2', 120, " + id_report_par + "
            FROM tb_sales_return r 
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = r.id_sales_return_order
            INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
            INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
            WHERE r.id_sales_return=" + id_report_par + " AND rd.sales_return_det_qty>0 
            UNION ALL 
            SELECT getCompByContact(r.id_store_contact_from, 4), '2', rd.id_product, IFNULL(dsg.design_cop,0), '120', '" + id_report_par + "', rd.sales_return_det_qty, NOW(), '', '1', NULL, NULL
            FROM tb_sales_return r 
            INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
            INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
            WHERE r.id_sales_return=" + id_report_par + " AND rd.sales_return_det_qty>0 
            UNION ALL 
            SELECT getCompByContact(r.id_comp_contact_to, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '120', '" + id_report_par + "', rd.sales_return_det_qty, NOW(), '', '1', NULL, NULL
            FROM tb_sales_return r 
            INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
            INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
            WHERE r.id_sales_return=" + id_report_par + " AND rd.sales_return_det_qty>0; "
            execute_non_query(query_stc, True, "", "", "", "")

            'complete unique
            completeUnique(id_report_par)

            'update stt in return centre
            Try
                Dim qstt As String = "UPDATE tb_ol_store_ret_list main
                        INNER JOIN (
                            SELECT rod.id_ol_store_ret_list 
                            FROM tb_sales_return_det d
                            INNER JOIN tb_sales_return_order_det rod ON rod.id_sales_return_order_det = d.id_sales_return_order_det
                            WHERE d.id_sales_return=" + id_report_par + "
                            GROUP BY rod.id_ol_store_ret_list
                        ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                        SET main.id_ol_store_ret_stt=9;
                        INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                        SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                        FROM tb_sales_return_det retdet  
                        INNER JOIN tb_sales_return_order_det d ON d.id_sales_return_order_det = retdet.id_sales_return_order_det
                        INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                        JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=9
                        WHERE retdet.id_sales_return=" + id_report_par + "
                        GROUP BY rd.id_sales_order_det; "
                execute_non_query(qstt, True, "", "", "", "")
            Catch ex As Exception
                stopCustom("Error updating status in return centre. " + ex.ToString)
            End Try
            'send mail returned to WH
            Try

            Catch ex As Exception

            End Try

            'save unreg unique
            execute_non_query("CALL generate_unreg_barcode(" + id_report_par + ",3)", True, "", "", "", "")
        ElseIf id_status_reportx_par = "5" Then
            Dim is_use_unique_code As String = execute_query("SELECT is_use_unique_code FROM tb_sales_return WHERE id_sales_return='" + id_report_par + "' ", 0, True, "", "", "", "")
            If is_use_unique_code = "1" Then
                cancellUnique(id_report_par)
            End If
        End If
        Dim query As String = String.Format("UPDATE tb_sales_return SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_sales_return ='{1}'; 
        /*update status sj*/
        CALL update_store_ret_status(" + id_report_par + ");", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

    ' ----------------------
    'for stock out
    ' ----------------------
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '2', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'reserved stock old
        'Dim query_res As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_rsv As DataTable = execute_query(query_res, -1, True, "", "", "", "")
        'Dim stc_rsv As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_rsv.Rows.Count - 1
        '    If dt_rsv.Rows(s)("sales_return_det_qty") > 0 Then
        '        stc_rsv.prepInsStockFG(dt_rsv.Rows(s)("id_wh_drawer_store").ToString, "2", dt_rsv.Rows(s)("id_product").ToString, decimalSQL(dt_rsv.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_rsv.Rows(s)("sales_return_det_qty").ToString), "", "2")
        '    End If
        'Next
        'stc_rsv.insStockFG()
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 "
        execute_non_query(query, True, "", "", "", "")

        'cancelled reserved stock old
        'Dim query_compl As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_cancel As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        'Dim stc_remove_rsv As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_cancel.Rows.Count - 1
        '    stc_remove_rsv.prepInsStockFG(dt_cancel.Rows(s)("id_wh_drawer_store").ToString, "1", dt_cancel.Rows(s)("id_product").ToString, decimalSQL(dt_cancel.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_cancel.Rows(s)("sales_return_det_qty").ToString), "", "2")
        'Next
        'stc_remove_rsv.insStockFG()
    End Sub

    Public Sub completeReservedStock(ByVal id_report_param As String)
        Dim query As String = "
        -- delete storage reserved
        DELETE FROM tb_storage_fg WHERE report_mark_type=46 AND id_report=" + id_report_param + " AND id_storage_category=1 AND id_stock_status=2;
        -- delete storage
        DELETE FROM tb_storage_fg WHERE report_mark_type=46 AND id_report=" + id_report_param + " AND id_stock_status=1;
        -- insert storage
        INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT getCompByContact(r.id_store_contact_from, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '2' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(r.id_store_contact_from, 4), '2', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '1' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0 
        UNION ALL 
        SELECT getCompByContact(r.id_comp_contact_to, 4), '1', rd.id_product, IFNULL(dsg.design_cop,0), '46', '" + id_report_param + "', rd.sales_return_det_qty, NOW(), '', '1' 
        FROM tb_sales_return r 
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return 
        INNER JOIN tb_m_product prod ON prod.id_product = rd.id_product
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
        WHERE r.id_sales_return=" + id_report_param + " AND rd.sales_return_det_qty>0; "
        execute_non_query(query, True, "", "", "", "")

        'complete old
        'Dim query_compl As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        'Dim stc_remove_rsv As ClassStock = New ClassStock()
        'Dim stc_compl As ClassStock = New ClassStock()
        'Dim stc_in As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_compl.Rows.Count - 1
        '    stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "2")
        '    stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        '    stc_in.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        'Next
        'stc_remove_rsv.insStockFG()
        'stc_compl.insStockFG()
        'stc_in.insStockFG()
    End Sub

    Public Sub completeProbStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg_prob(id_store,id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
        SELECT c.id_comp,'1', p.id_product , IFNULL(d.design_cop,0), '46', '" + id_report_param + "',  COUNT(rp.id_product) AS `qty`, NOW(),'', '1'
        FROM tb_sales_return_problem rp
        INNER JOIN tb_m_product p ON p.id_product = RP.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        INNER JOIN tb_sales_return r ON r.id_sales_return = rp.id_sales_return
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = r.id_store_contact_from
		INNER JOIN tb_m_comp c ON c.id_comp= cc.id_comp
        WHERE rp.id_sales_return='" + id_report_param + "'
        GROUP BY rp.id_product "
        execute_non_query(query, True, "", "", "", "")

        'complete old
        'Dim query_compl As String = "CALL view_sales_return('" + id_report_param + "') "
        'Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        'Dim stc_remove_rsv As ClassStock = New ClassStock()
        'Dim stc_compl As ClassStock = New ClassStock()
        'Dim stc_in As ClassStock = New ClassStock()
        'For s As Integer = 0 To dt_compl.Rows.Count - 1
        '    stc_remove_rsv.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "2")
        '    stc_compl.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer_store").ToString, "2", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        '    stc_in.prepInsStockFG(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_product").ToString, decimalSQL(dt_compl.Rows(s)("design_cop").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sales_return_det_qty").ToString), "", "1")
        'Next
        'stc_remove_rsv.insStockFG()
        'stc_compl.insStockFG()
        'stc_in.insStockFG()
    End Sub

    Public Sub orderLog(ByVal id_order As String, ByVal log_type As String, ByVal log As String)
        Dim query As String = "INSERT INTO tb_sales_return_order_log (id_sales_return_order, id_user, ret_order_log_type, log, log_time)
        VALUES ('" + id_order + "', '" + id_user + "','" + log_type + "','" + log + "', NOW()) "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub insertUnique(ByVal id_report_par As String)
        Dim query As String = "INSERT INTO tb_m_unique_code(id_comp, id_product, id_sales_return_det_counting, id_type, unique_code, id_design_price, design_price, qty, is_unique_report, input_date)  
        SELECT cc.id_comp, retd.id_product, c.id_sales_return_det_counting, 4, CONCAT(prod.product_full_code, c.sales_return_det_counting), 
        retd.id_design_price, retd.design_price,-1, c.is_unique_report, NOW()
        FROM tb_sales_return_det_counting c
        INNER JOIN tb_sales_return_det retd ON retd.id_sales_return_det = c.id_sales_return_det
        INNER JOIN tb_sales_return ret ON ret.id_sales_return = retd.id_sales_return
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ret.id_store_contact_from
        INNER JOIN tb_m_product prod ON prod.id_product = retd.id_product
        WHERE retd.id_sales_return=" + id_report_par + " "
        execute_non_query_long(query, True, "", "", "", "")
    End Sub

    Public Sub cancellUnique(ByVal id_report_par As String)
        Dim query As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_report_par + " AND report_mark_type=46 AND id_report_status=5;
        INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_sales_return_det_counting`,`id_type`,`unique_code`,
        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`,`id_report`, `report_mark_type`, `id_report_status`) 
        SELECT cc.id_comp, c.id_drawer_def, td.id_product, tc.id_pl_prod_order_rec_det_unique,tc.id_sales_return_det_counting, '4', 
        CONCAT(p.product_full_code,tc.sales_return_det_counting), td.id_design_price, td.design_price, 1, tc.is_unique_report, NOW(),
        td.id_sales_return, 46, 5
        FROM tb_sales_return_det td
        INNER JOIN tb_sales_return t ON t.id_sales_return = td.id_sales_return
        INNER JOIN tb_sales_return_det_counting tc ON tc.id_sales_return_det = td.id_sales_return_det
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_store_contact_from
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_product p ON p.id_product = td.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE t.id_sales_return=" + id_report_par + "
        AND d.is_old_design=2 
        AND t.is_use_unique_code=1 "
        execute_non_query_long(query, True, "", "", "", "")
    End Sub

    Public Sub completeUnique(ByVal id_report_par As String)
        Dim query As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_report_par + " AND report_mark_type=46 AND id_report_status=6;
        INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_sales_return_det_counting`,`id_type`,`unique_code`,
        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`,`id_report`, `report_mark_type`, `id_report_status`) 
        SELECT cc.id_comp, t.id_wh_drawer, td.id_product, tc.id_pl_prod_order_rec_det_unique,tc.id_sales_return_det_counting, '4', 
        CONCAT(p.product_full_code,tc.sales_return_det_counting), td.id_design_price, td.design_price, 1, 1, NOW(),
        td.id_sales_return, 46, 6
        FROM tb_sales_return_det td
        INNER JOIN tb_sales_return t ON t.id_sales_return = td.id_sales_return
        INNER JOIN tb_sales_return_det_counting tc ON tc.id_sales_return_det = td.id_sales_return_det
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_product p ON p.id_product = td.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        WHERE t.id_sales_return=" + id_report_par + "
        AND d.is_old_design=2 
        AND t.is_use_unique_code=1 "
        execute_non_query_long(query, True, "", "", "", "")
    End Sub
End Class
