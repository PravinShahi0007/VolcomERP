Public Class ClassProductionPLToWHRec
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

        Dim query As String = "SELECT CONCAT(vend_c.comp_number, ' - ', vend_c.comp_name) AS vendor, i.prod_order_number,dsg.id_design, (dsg.design_display_name) AS `design_name`, dsg.design_code AS `code`, k.pl_category, i.prod_order_number, a0.id_pl_prod_order_rec , a0.id_comp_contact_from , a0.id_comp_contact_to, a0.pl_prod_order_rec_note, a0.pl_prod_order_rec_number, a.pl_prod_order_number, "
        query += "CONCAT(d.comp_number,' - ',d.comp_name) AS comp_name_from, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_name_to, h.report_status, a0.id_report_status, "
        query += "a0.pl_prod_order_rec_date, ss.id_season, ss.season, IFNULL(det.total_qty,0) AS `total_qty`, "
        query += "a0.last_update, getUserEmp(a0.last_update_by, '1') AS last_user, ('No') AS is_select,IFNULL(pb.prepared_by,'-') AS `prepared_by`, pb.report_mark_datetime AS `prepared_date`, cd.class, cd.color, cd.sht, pc.final_comment "
        query += "FROM tb_pl_prod_order_rec a0 "
        query += "INNER JOIN tb_pl_prod_order a ON a.id_pl_prod_order = a0.id_pl_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON a0.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a0.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a0.id_report_status "
        query += "INNER JOIN tb_prod_order i ON a.id_prod_order = i.id_prod_order "
        query += "LEFT JOIN tb_prod_order_wo vend_wo ON vend_wo.id_prod_order = i.id_prod_order AND vend_wo.is_main_vendor='1' "
        query += "LEFT JOIN tb_m_ovh_price vend_ovh ON vend_ovh.id_ovh_price = vend_wo.id_ovh_price "
        query += "LEFT JOIN tb_m_comp_contact vend_cc On vend_cc.id_comp_contact = vend_ovh.id_comp_contact "
        query += "LEFT JOIN tb_m_comp vend_c ON vend_c.id_comp = vend_cc.id_comp "
        query += "INNER JOIN tb_pl_prod_order_det j On a.id_pl_prod_order = j.id_pl_prod_order "
        query += "INNER JOIN tb_lookup_pl_category k On k.id_pl_category = a.id_pl_category "
        query += "INNER JOIN tb_season_delivery del On del.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season ss On ss.id_season = del.id_season "
        query += "INNER JOIN tb_prod_demand_design pd_dsg On pd_dsg.id_prod_demand_design = i.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg On dsg.id_design = pd_dsg.id_design 
        LEFT JOIN (
            SELECT dc.id_design, 
            MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
            MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
            MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
            MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
            MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
            MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
            MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
            MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
            MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
            FROM tb_m_design_code dc
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
            AND cd.id_code IN (32,30,14, 43)
            GROUP BY dc.id_design
        ) cd ON cd.id_design = dsg.id_design "
        query += "LEFT JOIN ( "
        query += "Select det.id_pl_prod_order_rec, SUM(det.pl_prod_order_rec_det_qty) As `total_qty` "
        query += "FROM tb_pl_prod_order_rec_det det "
        query += "GROUP BY det.id_pl_prod_order_rec "
        query += ") det On det.id_pl_prod_order_rec = a0.id_pl_prod_order_rec 
        LEFT JOIN (
            SELECT rm.id_report, e.employee_name AS `prepared_by`, rm.report_mark_datetime
            FROM tb_report_mark rm
            INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
            WHERE rm.report_mark_type=37 AND rm.id_report_status=1
            GROUP BY rm.id_report
        ) pb ON pb.id_report = a0.id_pl_prod_order_rec "
        query += "
        LEFT JOIN (
          SELECT id_report, final_comment
          FROM tb_report_mark_final_comment
          WHERE report_mark_type = 37
          GROUP BY id_report
        ) pc ON pc.id_report = a0.id_pl_prod_order_rec "
        query += "WHERE a0.id_pl_prod_order_rec>0 "
        query += condition
        query += "GROUP BY a0.id_pl_prod_order_rec "
        query += "ORDER BY a0.id_pl_prod_order_rec " + order_type
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String, ByVal by_barcode As Boolean) As DataTable
        Dim query As String = ""
        If by_barcode Then
            query = "CALL view_pl_prod_rec_main(""" + condition + """, " + order_type + ")"
        Else
            query = "CALL view_pl_prod_rec_main_code(""" + condition + """, " + order_type + ")"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            'insert stock
            Dim query_stc As String = "DELETE FROM tb_storage_fg WHERE report_mark_type=37 AND id_report=" + id_report_par + "; "
            query_stc += "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
            query_stc += "SELECT pl.id_wh_drawer, '1', pd_prod.id_product, dsg.design_cop , '37' , '" + id_report_par + "', pl_det.pl_prod_order_rec_det_qty, "
            query_stc += "NOW(), CONCAT('Completed, Receiving Warehouse : ', pl.pl_prod_order_rec_number), '1'   "
            query_stc += "FROM tb_pl_prod_order_rec_det pl_det "
            query_stc += "INNER JOIN tb_pl_prod_order_rec pl ON pl.id_pl_prod_order_rec = pl_det.id_pl_prod_order_rec "
            query_stc += "INNER JOIN tb_pl_prod_order_det pl_qc_det ON pl_qc_det.id_pl_prod_order_det = pl_det.id_pl_prod_order_det "
            query_stc += "INNER JOIN tb_prod_order_det po_det ON po_det.id_prod_order_det = pl_qc_det.id_prod_order_det "
            query_stc += "INNER JOIN tb_prod_demand_product pd_prod ON pd_prod.id_prod_demand_product = po_det.id_prod_demand_product "
            query_stc += "INNER JOIN tb_m_product prod ON prod.id_product = pd_prod.id_product "
            query_stc += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_stc += "WHERE pl_det.id_pl_prod_order_rec = '" + id_report_par + "' AND pl_det.pl_prod_order_rec_det_qty>0 "
            execute_non_query(query_stc, True, "", "", "", "")

            'first receiving
            Dim id_designx As String = execute_query("SELECT dsg.id_design FROM tb_pl_prod_order_rec rec INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = rec.id_pl_prod_order INNER JOIN tb_prod_order pdo ON pdo.id_prod_order = pl.id_prod_order INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = pdo.id_prod_demand_design INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design WHERE rec.id_pl_prod_order_rec =" + id_report_par + "", 0, True, "", "", "", "")
            Dim design_first_rec_whx As String = execute_query("SELECT IF(ISNULL(design_first_rec_wh), '0', design_first_rec_wh) AS cek_date FROM tb_m_design WHERE id_design = '" + id_designx + "' ", 0, True, "", "", "", "")
            If design_first_rec_whx = "0" Then
                Dim query_aging As String = "UPDATE tb_m_design SET design_first_rec_wh = NOW() WHERE id_design = '" + id_designx + "' "
                execute_non_query(query_aging, True, "", "", "", "")
            End If

            'insertUniqueCode
            Dim qun As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_report_par + " AND report_mark_type=37 AND id_report_status=6;
            INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`,`id_pl_prod_order_rec_det_unique`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`,`id_report`, `report_mark_type`, `id_report_status`) 
            SELECT cc.id_comp, r.id_wh_drawer, rc.id_product,  rc.id_pl_prod_order_rec_det_unique, '6', CONCAT(p.product_full_code,rc.pl_prod_order_rec_det_counting),
            prc.id_design_price, prc.design_price, 1, 1, NOW(), rd.id_pl_prod_order_rec, 37,6
            FROM tb_pl_prod_order_rec_det rd
            INNER JOIN tb_pl_prod_order_rec r ON r.id_pl_prod_order_rec = rd.id_pl_prod_order_rec
            INNER JOIN tb_pl_prod_order_rec_det_counting rc ON rc.id_pl_prod_order_rec_det = rd.id_pl_prod_order_rec_det
            INNER JOIN tb_m_product p ON p.id_product = rc.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  r.id_comp_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN( 
                SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                price.id_design_price_type, price_type.design_price_type,
                cat.id_design_cat, cat.design_cat 
                FROM tb_m_design_price price 
                INNER JOIN (
	                SELECT MAX(price.id_design) AS `id_design`, MAX(price.id_design_price) AS  `id_design_price`
	                FROM tb_m_design_price price
	                INNER JOIN (
		                Select MAX(price.id_design) AS `id_design`, MAX(price.design_price_start_date) AS `design_price_start_date`
		                From tb_m_design_price price 
		                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
		                GROUP BY price.id_design
	                ) maxdate ON maxdate.id_design = price.id_design AND maxdate.design_price_start_date = price.design_price_start_date
	                WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
	                GROUP BY price.id_design
                ) pricemax ON pricemax.id_design_price = price.id_design_price
                INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
            ) prc ON prc.id_design = d.id_design 
            WHERE rd.id_pl_prod_order_rec=" + id_report_par + " AND d.is_old_design=2 AND r.is_use_unique_code=1 "
            execute_non_query_long(qun, True, "", "", "", "")

            'log perubahan line list
            Dim cd As New ClassDesign()
            cd.insertLogLineList("37", id_report_par, True, "", "", "", "", "", "")
        End If

        Dim query As String = String.Format("UPDATE tb_pl_prod_order_rec SET id_report_status='{0}', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_prod_order_rec ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
