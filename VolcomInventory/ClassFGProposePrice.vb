Public Class ClassFGProposePrice
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_propose_price_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function dataMainRev(ByVal condition As String, ByVal order_type As String) As DataTable
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

        Dim query As String = "SELECT ppr.id_fg_propose_price_rev, ppr.id_fg_propose_price, pp.fg_propose_price_number,ppr.rev_count,
        pp.id_season, ss.season, pp.id_source, src.code_detail_name AS `source`, pp.id_division, (dv.code_detail_name) AS division,
        ppr.id_report_status, stt.report_status, ppr.created_date, ppr.note, ppr.is_confirm 
        FROM tb_fg_propose_price_rev ppr
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ppr.id_report_status
        INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppr.id_fg_propose_price
        INNER JOIN tb_season ss ON ss.id_season = pp.id_season
        INNER JOIN tb_m_code_detail src ON src.id_code_detail = pp.id_source
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = pp.id_division
        WHERE ppr.id_fg_propose_price_rev>0 "
        query += condition + " "
        query += "ORDER BY ppr.id_fg_propose_price_rev " + order_type
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_propose_price('" + id_report_param + "')"
        Return query
    End Function

    Public Function dataCOPList(ByVal id_ss As String, ByVal source As String, ByVal div As String, ByVal is_for_add_list As Boolean)
        Dim query As String = "SELECT d.id_design, pdd.id_prod_demand_design,d.design_code AS `code`, cls.id_class,cls.`class`, d.design_display_name AS `name`, 
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.id_cop_status,0),IF(d.final_is_approve=1,d.id_cop_status,0)) AS `id_cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,'Pre Final','-'),IF(d.final_is_approve=1,'Final','-')) AS `cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.prod_order_cop_mng_addcost,0),IF(d.final_is_approve=1,d.design_cop_addcost,0)) AS `additional_cost`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_rate_cat,0),IF(d.final_is_approve=1,d.final_cop_rate_cat,0)) AS `cop_rate_cat`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,IF(d.pp_cop_rate_cat=1,'BOM','Payment'),'-'),IF(d.final_is_approve=1,IF(d.final_cop_rate_cat=1,'BOM','Payment'),'-')) AS `cop_rate_cat_display`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_kurs,0),IF(d.final_is_approve=1,d.final_cop_kurs,0)) AS `cop_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_value,0),IF(d.final_is_approve=1,d.final_cop_value,0)) AS `cop_value`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_kurs,0),IF(d.final_is_approve=1,d.final_cop_mng_kurs,0)) AS `cop_mng_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_value,0),IF(d.final_is_approve=1,d.final_cop_mng_value,0)) AS `cop_mng_value`,
        po.id_prod_order,pod.po_qty, rec.rec_qty,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,pod.po_qty,0),IF(d.final_is_approve=1,rec.rec_qty,0))  AS `qty`,
        'No' AS `is_select`
        FROM tb_m_design d 
        INNER JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
          GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        INNER JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
          GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_design = d.id_design AND pdd.is_void=2
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_division=" + div + " AND pd.id_report_status=6
        INNER JOIN tb_prod_order po ON  po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status!=5
        INNER JOIN (
	        SELECT pod.id_prod_order, SUM(pod.prod_order_qty) AS `po_qty` 
	        FROM tb_prod_order_det pod
	        INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
	        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
	        WHERE po.id_report_status!=5 AND d.id_season=" + id_ss + "
	        GROUP BY pod.id_prod_order
        ) pod ON pod.id_prod_order = po.id_prod_order
        LEFT JOIN (
	        SELECT r.id_prod_order, SUM(rd.prod_order_rec_det_qty) AS `rec_qty`
	        FROM tb_prod_order_rec r
	        INNER JOIN tb_prod_order_rec_det rd ON rd.id_prod_order_rec = r.id_prod_order_rec
	        INNER JOIN tb_prod_order po ON po.id_prod_order = r.id_prod_order
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
	        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
	        WHERE r.id_report_status=6 AND d.id_season=" + id_ss + "
	        GROUP BY r.id_prod_order
        ) rec ON rec.id_prod_order = po.id_prod_order
        LEFT JOIN (
	        SELECT pp.id_fg_propose_price,ppd.id_design 
	        FROM tb_fg_propose_price pp
	        INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price = pp.id_fg_propose_price
	        WHERE pp.id_report_status!=5
        ) pp ON pp.id_design = d.id_design
        WHERE d.id_season=" + id_ss + " AND d.id_lookup_status_order=1 AND src.id_src=" + source + " "
        If is_for_add_list Then
            query += " AND ISNULL(pp.id_fg_propose_price) HAVING id_cop_status>0 "
        End If
        query += "ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function
End Class
