Public Class ClassFGWHAlloc
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

        Dim query As String = "SELECT allc.id_fg_wh_alloc, allc.fg_wh_alloc_number, "
        query += "allc.fg_wh_alloc_date, DATE_FORMAT(allc.fg_wh_alloc_date,'%Y-%m-%d') AS fg_wh_alloc_datex, "
        query += "allc.fg_wh_alloc_note, allc.id_report_status, stt.report_status, "
        query += "comp.id_comp, loc.id_wh_locator, rck.id_wh_rack, drw.id_wh_drawer, "
        query += "comp.comp_number, comp.comp_name, CONCAT(comp.comp_number, ' - ', comp.comp_name) AS `comp_from`, "
        query += "getUserPrepared(allc.id_fg_wh_alloc, 87, 1) AS prepared_by, allc.is_submit "
        query += "FROM tb_fg_wh_alloc allc "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = allc.id_report_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = allc.id_wh_drawer_from "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
        query += "WHERE allc.id_fg_wh_alloc>0 "
        query += condition + " "
        query += "ORDER BY allc.id_fg_wh_alloc " + order_type
        Return query
    End Function

    '-----------
    'STOCK OUT
    '--------------
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT allc.id_wh_drawer_from, '2', allc_det.id_product, IFNULL(dsg.design_cop,0), '87', '" + id_report_param + "', "
        query += "SUM(allc_det.fg_wh_alloc_det_qty), NOW(), '', '2' "
        query += "FROM tb_fg_wh_alloc_det allc_det "
        query += "INNER JOIN tb_fg_wh_alloc allc ON allc.id_fg_wh_alloc = allc_det.id_fg_wh_alloc "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = allc_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE allc_det.id_fg_wh_alloc='" + id_report_param + "' "
        query += "GROUP BY allc_det.id_product "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT allc.id_wh_drawer_from, '1', allc_det.id_product, IFNULL(dsg.design_cop,0), '87', '" + id_report_param + "', "
        query += "SUM(allc_det.fg_wh_alloc_det_qty), NOW(), '', '2' "
        query += "FROM tb_fg_wh_alloc_det allc_det "
        query += "INNER JOIN tb_fg_wh_alloc allc ON allc.id_fg_wh_alloc = allc_det.id_fg_wh_alloc "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = allc_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE allc_det.id_fg_wh_alloc='" + id_report_param + "' "
        query += "GROUP BY allc_det.id_product "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub completeReservedStock(ByVal id_report_param As String)
        'complete
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT allc.id_wh_drawer_from AS `id_wh_drawer`, '1', allc_det.id_product, IFNULL(dsg.design_cop,0), '87', '" + id_report_param + "', "
        query += "SUM(allc_det.fg_wh_alloc_det_qty) AS `qty`, NOW(), '', '2' "
        query += "FROM tb_fg_wh_alloc_det allc_det "
        query += "INNER JOIN tb_fg_wh_alloc allc ON allc.id_fg_wh_alloc = allc_det.id_fg_wh_alloc "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = allc_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE allc_det.id_fg_wh_alloc='" + id_report_param + "' "
        query += "GROUP BY allc_det.id_product "
        query += "UNION ALL "
        query += "SELECT allc.id_wh_drawer_from AS `id_wh_drawer`, '2', allc_det.id_product, IFNULL(dsg.design_cop,0), '87', '" + id_report_param + "', "
        query += "SUM(allc_det.fg_wh_alloc_det_qty) AS `qty`, NOW(), '', '1' "
        query += "FROM tb_fg_wh_alloc_det allc_det "
        query += "INNER JOIN tb_fg_wh_alloc allc ON allc.id_fg_wh_alloc = allc_det.id_fg_wh_alloc "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = allc_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE allc_det.id_fg_wh_alloc='" + id_report_param + "' "
        query += "GROUP BY allc_det.id_product "
        query += "UNION ALL "
        query += "SELECT allc_det.id_wh_drawer_to AS `id_wh_drawer`, '1', allc_det.id_product, IFNULL(dsg.design_cop,0), '87', '" + id_report_param + "', "
        query += "allc_det.fg_wh_alloc_det_qty AS `qty`, NOW(), '', '1' "
        query += "FROM tb_fg_wh_alloc_det allc_det "
        query += "INNER JOIN tb_fg_wh_alloc allc ON allc.id_fg_wh_alloc = allc_det.id_fg_wh_alloc "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = allc_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE allc_det.id_fg_wh_alloc='" + id_report_param + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

End Class
