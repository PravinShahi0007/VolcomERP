Public Class ClassStoreDisplay
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

        Dim query As String = "SELECT p.id_display_pps, IFNULL(p.id_display_pps_ref,0) AS `id_display_pps_ref`, p.number, 
        p.created_date, p.created_by, ce.employee_name AS `created_by_name`,
        p.updated_date, p.updated_by, ue.employee_name AS `updated_by_name`,
        p.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`, 
        p.id_season, ss.season, p.id_report_status, stt.report_status, p.note, p.is_confirm, p.in_store_date
        FROM tb_display_pps p
        INNER JOIN tb_m_user cu ON cu.id_user = p.created_by
        INNER JOIN tb_m_employee ce ON ce.id_employee = cu.id_employee
        INNER JOIN tb_m_user uu ON uu.id_user = p.updated_by
        INNER JOIN tb_m_employee ue ON ue.id_employee = uu.id_employee
        INNER JOIN tb_m_comp c ON c.id_comp = p.id_comp
        INNER JOIN tb_season ss ON ss.id_season = p.id_season
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = p.id_report_status
        WHERE p.id_display_pps>0 "
        query += condition + " "
        query += "ORDER BY p.id_display_pps " + order_type
        Return query
    End Function

    Function queryStockByClassGroup(ByVal date_par As String, ByVal cond_par As String) As String
        Dim query As String = "SELECT ds.id_class_group, SUM(ds.qty) AS `qty`
        FROM (
	        SELECT ds.id_class_group,ds.id_design,ds.qty 
	        FROM tb_display_stock ds
            INNER JOIN (
                SELECT MAX(ds.id_display_stock) AS `id_display_stock`, ds.id_design
                FROM tb_display_stock ds
                WHERE ds.is_active=1 AND ds.effective_date<='" + date_par + "'
                GROUP BY ds.id_design
            ) da ON da.id_display_stock = ds.id_display_stock
	        WHERE ds.is_active=1 AND ds.in_store_date<='" + date_par + "' " + cond_par + "
	        UNION ALL
	        SELECT ds.id_class_group,ds.id_design,(ds.qty*-1)
	        FROM tb_display_stock ds
            INNER JOIN (
                SELECT MAX(ds.id_display_stock) AS `id_display_stock`, ds.id_design
                FROM tb_display_stock ds
                WHERE ds.is_active=1 AND ds.effective_date<='" + date_par + "'
                GROUP BY ds.id_design
            ) da ON da.id_display_stock = ds.id_display_stock
	        WHERE ds.is_active=1 AND ds.return_date<='" + date_par + "' " + cond_par + "
        ) ds
        GROUP BY ds.id_class_group "
        Return query
    End Function

    Function queryBasicDisplay(ByVal date_par As String, ByVal id_store_par As String) As String
        Dim query As String = "SELECT ds.id_class_group, ds.id_season, ds.id_delivery,ds.id_design,ds.qty 
        FROM tb_display_stock ds
        INNER JOIN (
            SELECT MAX(ds.id_display_stock) AS `id_display_stock`, ds.id_design
            FROM tb_display_stock ds
            WHERE ds.is_active=1 AND ds.effective_date<='" + date_par + "'
            GROUP BY ds.id_design
        ) da ON da.id_display_stock = ds.id_display_stock
        WHERE ds.is_active=1 AND ds.in_store_date<='" + date_par + "' AND ds.id_comp=" + id_store_par + "
        UNION ALL
        SELECT ds.id_class_group, ds.id_season, ds.id_delivery,ds.id_design,(ds.qty*-1)
        FROM tb_display_stock ds
        INNER JOIN (
            SELECT MAX(ds.id_display_stock) AS `id_display_stock`, ds.id_design
            FROM tb_display_stock ds
            WHERE ds.is_active=1 AND ds.effective_date<='" + date_par + "'
            GROUP BY ds.id_design
        ) da ON da.id_display_stock = ds.id_display_stock
        WHERE ds.is_active=1 AND ds.return_date<='" + date_par + "' AND ds.id_comp=" + id_store_par + " "
        Return query
    End Function

    Sub completeProposeDisplay(ByVal rmt_par As String, ByVal id_report_par As String)
        Dim query As String = "DELETE FROM tb_display_stock WHERE report_mark_type=" + rmt_par + " AND id_report=" + id_report_par + ";
        INSERT INTO tb_display_stock(id_season, id_delivery,id_class_group,id_design,id_comp,in_store_date,return_date,effective_date,qty,report_mark_type, id_report, report_number, is_active, input_date)
        -- existing
        SELECT d.id_season, d.id_delivery, dpr.id_class_group, dpr.id_design, dp.id_comp,sd.delivery_date, rc.ret_date, dp.in_store_date AS `effective_date`, dph.qty_hanger, 353, dp.id_display_pps, dp.`number`, 1, NOW()
        FROM tb_display_pps_res dpr
        INNER JOIN tb_display_pps dp ON dp.id_display_pps = dpr.id_display_pps
        INNER JOIN tb_m_design d ON d.id_design = dpr.id_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        LEFT JOIN tb_display_pps_season dps ON dps.id_delivery = d.id_delivery  AND dps.id_display_pps=" + id_report_par + "
        JOIN tb_display_pps_season ex ON ex.id_display_pps=" + id_report_par + " AND ex.is_extra_sku=1
        INNER JOIN tb_display_pps_hanger dph ON dph.id_display_pps_season = IFNULL(dps.id_display_pps_season, ex.id_display_pps_season) AND dph.id_class_group = dpr.id_class_group AND dph.id_display_pps=" + id_report_par + "
        WHERE dpr.id_display_pps=" + id_report_par + " AND d.id_lookup_status_order!=2 
        -- current season 
        UNION ALL
        SELECT d.id_season, d.id_delivery, dpr.id_class_group, dpr.id_design, dp.id_comp,sd.delivery_date, rc.ret_date, dp.in_store_date AS `effective_date`, dph.qty_hanger, 353, dp.id_display_pps, dp.`number`, 1, NOW()
        FROM tb_display_pps_det dpr
        INNER JOIN tb_display_pps dp ON dp.id_display_pps = dpr.id_display_pps
        INNER JOIN tb_m_design d ON d.id_design = dpr.id_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        LEFT JOIN tb_display_pps_season dps ON dps.id_delivery = d.id_delivery  AND dps.id_display_pps=" + id_report_par + "
        JOIN tb_display_pps_season ex ON ex.id_display_pps=" + id_report_par + " AND ex.is_extra_sku=1
        INNER JOIN tb_display_pps_hanger dph ON dph.id_display_pps_season = IFNULL(dps.id_display_pps_season, ex.id_display_pps_season) AND dph.id_class_group = dpr.id_class_group AND dph.id_display_pps=" + id_report_par + "
        WHERE dpr.id_display_pps=" + id_report_par + " AND d.id_lookup_status_order!=2 
        -- plan season (sementara belum masuk) "
        execute_non_query(query, -1, True, "", "", "")
    End Sub
End Class
