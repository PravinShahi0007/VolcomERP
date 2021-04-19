﻿Public Class ClassSalesReturnQC
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
        query += "SELECT a.id_comp_contact_to, a.id_report_status, a.id_sales_return_qc, a.id_sales_return, DATE_FORMAT(a.sales_return_qc_date, '%d %M %Y') AS sales_return_qc_date, "
        query += "a.sales_return_qc_note, a.sales_return_qc_number,IF(a.status_check_fisik=1,'Not Checked',IF(a.status_check_fisik=2,'Not Balance','Done')) AS sts_cek_fisik, "
        query += "CONCAT(c.comp_number,' - ',c.comp_name) AS store_name_from, (c.comp_number) AS store_number_from, "
        query += "CONCAT(e.comp_number,' - ',e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, get_custom_rmk(e.id_wh_type,49) AS `rmk`, "
        query += "f.sales_return_number, g.report_status, h.pl_category, det.`total`, "
        query += "a.last_update, getUserEmp(a.last_update_by, 1) AS last_user, ('No') AS is_select, IFNULL(pb.prepared_by,'-') AS `prepared_by`, pb.report_mark_datetime AS `prepared_date`  "
        query += "FROM tb_sales_return_qc a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return f ON f.id_sales_return = a.id_sales_return "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category h ON h.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN (
        SELECT d.id_sales_return_qc, SUM(d.sales_return_qc_det_qty) AS `total` 
        FROM tb_sales_return_qc_det d
        GROUP BY d.id_sales_return_qc
        ) det ON det.id_sales_return_qc = a.id_sales_return_qc 
        LEFT JOIN (
            SELECT rm.id_report, e.employee_name AS `prepared_by`,rm.report_mark_datetime
            FROM tb_report_mark rm
            INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
            WHERE (rm.report_mark_type=49 OR rm.report_mark_type=106) AND rm.id_report_status=1
            GROUP BY rm.id_report
        ) pb ON pb.id_report = a.id_sales_return_qc "
        query += "WHERE a.id_sales_return_qc>0 "
        query += condition + " "
        query += "ORDER BY a.id_sales_return_qc " + order_type
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String) As DataTable
        Dim query As String = "CALL view_sales_return_qc_main(""" + condition + """, " + order_type + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            'clean storage related report
            Dim query_clean As String = "DELETE FROM tb_storage_fg WHERE report_mark_type=49 AND id_report=" + id_report_par + " "
            execute_non_query(query_clean, True, "", "", "", "")

            ' jika complete
            Dim query_del_zero As String = ""
            Dim query_save_out As String = ""
            Dim query_save_st As String = ""
            Dim query_upd_drw As String = ""
            Dim jum_ins_c As Integer = 0

            'next update save in storage
            jum_ins_c = 0
            Dim query_ret As String = ""
            query_ret += "SELECT qc.sales_return_qc_number, (ret.id_wh_drawer) AS id_wh_drawer_origin,qc.id_wh_drawer, qc_det.design_price, qc_det.id_design_price, qc_det.id_product, "
            query_ret += "qc_det.id_sales_return_det, qc_det.id_sales_return_qc, qc_det.sales_return_qc_det_qty, dsg.design_cop "
            query_ret += "FROM tb_sales_return_qc_det qc_det "
            query_ret += "INNER JOIN tb_sales_return_qc qc ON qc.id_sales_return_qc = qc_det.id_sales_return_qc "
            query_ret += "INNER JOIN tb_m_product prod ON prod.id_product = qc_det.id_product "
            query_ret += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_ret += "INNER JOIN tb_sales_return ret ON ret.id_sales_return = qc.id_sales_return "
            query_ret += "WHERE qc.id_sales_return_qc = '" + id_report_par + "' "
            Dim data_ret As DataTable = execute_query(query_ret, -1, True, "", "", "", "")

            If data_ret.Rows.Count > 0 Then
                query_save_out = "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) VALUES "
                query_save_st = "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) VALUES "
            End If
            For i As Integer = 0 To (data_ret.Rows.Count - 1)
                If data_ret.Rows(i)("sales_return_qc_det_qty") > 0.0 Then
                    If jum_ins_c > 0 Then
                        query_save_out += ", "
                        query_save_st += ", "
                    End If
                    query_save_out += "('" & data_ret.Rows(i)("id_wh_drawer_origin").ToString & "','2','" & data_ret.Rows(i)("id_product").ToString & "','" & decimalSQL(data_ret.Rows(i)("design_cop").ToString) & "','49','" & id_report_par & "','" & decimalSQL(data_ret.Rows(i)("sales_return_qc_det_qty").ToString) & "',NOW(),'Out for Return QC Process : " & data_ret.Rows(i)("sales_return_qc_number").ToString & "','1') "
                    query_save_st += "('" & data_ret.Rows(i)("id_wh_drawer").ToString & "','1','" & data_ret.Rows(i)("id_product").ToString & "','" & decimalSQL(data_ret.Rows(i)("design_cop").ToString) & "','49','" & id_report_par & "','" & decimalSQL(data_ret.Rows(i)("sales_return_qc_det_qty").ToString) & "',NOW(),'Completed, Return QC : " & data_ret.Rows(i)("sales_return_qc_number").ToString & "','1') "
                    jum_ins_c = jum_ins_c + 1
                End If
            Next
            If jum_ins_c > 0 Then
                execute_non_query(query_save_out, True, "", "", "", "")
                execute_non_query(query_save_st, True, "", "", "", "")
            End If

            'completed unique
            Dim quniq As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_report_par + " AND report_mark_type=49 AND id_report_status=6;
            INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_sales_return_qc_det_counting`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`,`id_report`, `report_mark_type`, `id_report_status`) 
            SELECT cc.id_comp, t.id_wh_drawer, td.id_product, tcr.id_pl_prod_order_rec_det_unique,tc.id_sales_return_qc_det_counting, '13', 
            CONCAT(p.product_full_code,tc.sales_return_qc_det_counting), td.id_design_price, td.design_price, 1, 1, NOW(),
            td.id_sales_return_qc, 49, 6
            FROM tb_sales_return_qc_det td
            INNER JOIN tb_sales_return_qc t ON t.id_sales_return_qc = td.id_sales_return_qc
            INNER JOIN tb_sales_return_qc_det_counting tc ON tc.id_sales_return_qc_det = td.id_sales_return_qc_det
            INNER JOIN tb_sales_return_det_counting tcr ON tcr.id_sales_return_det_counting = tc.id_sales_return_det_counting
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE t.id_sales_return_qc=" + id_report_par + "
            AND d.is_old_design=2 
            AND t.is_use_unique_code=1 "
            execute_non_query_long(quniq, True, "", "", "", "")
        ElseIf id_status_reportx_par = "5" Then
            Dim quniq As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_report_par + " AND report_mark_type=49 AND id_report_status=5;
            INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_sales_return_qc_det_counting`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`,`id_report`, `report_mark_type`, `id_report_status`) 
            SELECT cc.id_comp, tr.id_wh_drawer, td.id_product, tcr.id_pl_prod_order_rec_det_unique,tc.id_sales_return_qc_det_counting, '13', 
            CONCAT(p.product_full_code,tc.sales_return_qc_det_counting), td.id_design_price, td.design_price, 1, 1, NOW(),
            td.id_sales_return_qc, 49, 5
            FROM tb_sales_return_qc_det td
            INNER JOIN tb_sales_return_qc t ON t.id_sales_return_qc = td.id_sales_return_qc
            INNER JOIN tb_sales_return tr ON tr.id_sales_return = t.id_sales_return
            INNER JOIN tb_sales_return_qc_det_counting tc ON tc.id_sales_return_qc_det = td.id_sales_return_qc_det
            INNER JOIN tb_sales_return_det_counting tcr ON tcr.id_sales_return_det_counting = tc.id_sales_return_det_counting
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  tr.id_comp_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE t.id_sales_return_qc=" + id_report_par + "
            AND d.is_old_design=2 
            AND t.is_use_unique_code=1 "
            execute_non_query_long(quniq, True, "", "", "", "")
        End If

        Dim query As String = String.Format("UPDATE tb_sales_return_qc SET id_report_status='{0}', last_update = NOW(), last_update_by=" + id_user + " WHERE id_sales_return_qc ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

End Class
