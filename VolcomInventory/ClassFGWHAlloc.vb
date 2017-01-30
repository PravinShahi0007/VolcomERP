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

    Public Function queryAllocReport(ByVal id_report As String) As String
        Dim qs As String = "SELECT d.design_code AS `CODE`, d.design_display_name AS `STYLE`, CONCAT(comp.comp_number,' - ',comp.comp_name) AS `TO`, 
        SUBSTRING(p.product_full_code, 10, 1) AS `SIZETYPE`,
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='1') THEN ad.fg_wh_alloc_det_qty END) AS '1',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='2') THEN ad.fg_wh_alloc_det_qty END) AS '2',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='3') THEN ad.fg_wh_alloc_det_qty END) AS '3',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='4') THEN ad.fg_wh_alloc_det_qty END) AS '4',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='5') THEN ad.fg_wh_alloc_det_qty END) AS '5',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='6') THEN ad.fg_wh_alloc_det_qty END) AS '6',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='7') THEN ad.fg_wh_alloc_det_qty END) AS '7',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='8') THEN ad.fg_wh_alloc_det_qty END) AS '8',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='9') THEN ad.fg_wh_alloc_det_qty END) AS '9',
        SUM(CASE WHEN (SUBSTRING(cd.code,2,1)='0') THEN ad.fg_wh_alloc_det_qty END) AS '0',
        SUM(ad.fg_wh_alloc_det_qty) AS `TTL`
        FROM tb_fg_wh_alloc_det ad
        INNER JOIN tb_m_product p ON p.id_product = ad.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = ad.id_wh_drawer_to
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
        INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp
        WHERE ad.id_fg_wh_alloc=" + id_report + "
        GROUP BY p.id_design, SUBSTRING(p.product_full_code, 10, 1), ad.id_wh_drawer_to "
        Return qs
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
