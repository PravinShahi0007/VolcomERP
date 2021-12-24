﻿Public Class ClassProductionFinalClear
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

        Dim query As String = "SELECT f.id_prod_fc,f.id_service_type, f.id_prod_order, po.prod_order_number, po.id_delivery, sd.delivery, s.id_season,s.season, rg.id_range, rg.`range`,
        v.comp_number AS `vendor_number`, v.comp_name AS `vendor_name`, CONCAT(v.comp_number, ' - ', v.comp_name) AS `vendor`,
        f.id_comp_from, cf.comp_number AS `comp_from_number`, cf.comp_name AS `comp_from_name`, CONCAT(cf.comp_number, ' - ', cf.comp_name) AS `comp_from`,
        f.id_comp_to, ct.comp_number AS `comp_to_number`, ct.comp_name AS `comp_to_name`, CONCAT(ct.comp_number, ' - ', ct.comp_name) AS `comp_to`,
        f.id_pl_category, c.pl_category,  f.id_pl_category_sub,cs.pl_category_sub,rec.prod_order_rec_number,rec.id_prod_order_rec AS id_prod_order_rec,IFNULL(rec.id_pl_category,1) AS id_pl_category_rec,
        f.prod_fc_number, f.prod_fc_date, DATE_FORMAT(f.prod_fc_date,'%Y-%m-%d') AS prod_fc_datex, d.id_design, d.design_code AS `code`, CONCAT(IF(rg.is_md=1,'',CONCAT(cd.prm,' ')),cd.class,' ',d.design_name,' ',cd.color) AS `name`, f.prod_fc_note, d.`total`, f.id_report_status, r.report_status 
        FROM tb_prod_fc f 
        LEFT JOIN tb_prod_order_rec rec ON rec.id_prod_order_rec=f.id_prod_order_rec
        INNER JOIN tb_m_comp cf ON cf.id_comp = f.id_comp_from 
        INNER JOIN tb_m_comp ct ON ct.id_comp = f.id_comp_to 
        INNER JOIN tb_lookup_pl_category c ON c.id_pl_category = f.id_pl_category
        LEFT JOIN tb_lookup_pl_category_sub cs ON cs.id_pl_category_sub = f.id_pl_category_sub
        INNER JOIN tb_lookup_report_status r ON r.id_report_status = f.id_report_status
        LEFT JOIN(
	        SELECT det.id_prod_fc, SUM(det.prod_fc_det_qty) AS `total`
	        FROM tb_prod_fc_det det
	        GROUP BY det.id_prod_fc
        ) d ON d.id_prod_fc = f.id_prod_fc
        INNER JOIN tb_prod_order po ON po.id_prod_order = f.id_prod_order
        LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
        LEFT JOIN tb_m_ovh_price op ON op.id_ovh_price = wo.id_ovh_price
        LEFT JOIN tb_m_comp_contact vc ON vc.id_comp_contact = op.id_comp_contact
        LEFT JOIN tb_m_comp v ON v.id_comp = vc.id_comp
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
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
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`,
	        MAX(CASE WHEN cd.id_code=34 THEN cd.code_detail_name END) AS `prm`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43, 34)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = po.id_delivery
        INNER JOIN tb_season s ON s.id_season = sd.id_season
        INNER JOIN tb_range rg ON rg.id_range = s.id_range
        WHERE f.id_prod_fc>0 "
        query += condition + " "
        query += "ORDER BY f.id_prod_fc " + order_type
        Return query
    End Function
End Class
