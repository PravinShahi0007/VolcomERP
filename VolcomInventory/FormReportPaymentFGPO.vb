Public Class FormReportPaymentFGPO
    Public id_fgpo As String = "-1"
    Private Sub FormReportPaymentFGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_po()
        '
        If Not id_fgpo = "-1" Then
            SLEFGPO.EditValue = id_fgpo
            load_header()
        End If
    End Sub

    Sub load_po()
        Dim query As String = "SELECT po.`id_prod_order`,dsg.`design_display_name`,dsg.`design_code`,po.`prod_order_number`,c.`comp_name`,c.`comp_number` FROM tb_prod_order po
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order`=po.`id_prod_order` AND wo.`is_main_vendor`='1'
INNER JOIN tb_m_ovh_price prc ON prc.`id_ovh_price`=wo.`id_ovh_price`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=prc.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE po.id_report_status='6'"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "prod_order_number", "id_prod_order")
    End Sub

    Sub load_header()
        Dim query As String = "SELECT dsg.design_display_name,dsg.design_code,dsg.design_code_import,po.*,IF(ISNULL(ko.lead_time_prod),(wo.prod_order_wo_lead_time),(ko.lead_time_prod)) AS lead_time_prod,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IF(ISNULL(ko.lead_time_prod),(wo.prod_order_wo_lead_time),(ko.lead_time_prod)) DAY) AS est_rec_date,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IF(ISNULL(ko.lead_time_prod),(wo.prod_order_wo_lead_time+wo.prod_order_wo_top),(ko.lead_time_prod+ko.lead_time_payment)) DAY) AS payment_due_date,comp.`comp_name`,comp.`comp_number`,po.reff_number 
                                ,rec.prod_order_rec_det_qty as rec_qty,IF(rec.prod_order_rec_det_qty<=ROUND(SUM(pod.prod_order_qty)*(po.tolerance_over/100))
                                FROM tb_prod_order po
                                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=po.id_prod_order
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                LEFT JOIN tb_prod_order_wo wo ON wo.`id_prod_order`=po.`id_prod_order` AND wo.`is_main_vendor`='1'
                                LEFT JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
                                LEFT JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
                                LEFT JOIN tb_m_comp comp ON comp.`id_comp`=cc.`id_comp` 
                                LEFT JOIN (
	                                SELECT kod.* FROM 
                                    tb_prod_order_ko_det kod 
                                    INNER JOIN(
	                                    SELECT kod.id_prod_order,MAX(kod.id_prod_order_ko_det) AS id_prod_order_ko_det
	                                    FROM tb_prod_order_ko_det kod
	                                    INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_locked=1 AND ko.is_void=2 AND NOT ISNULL(kod.id_prod_order) AND kod.id_prod_order='" & id_fgpo & "'
	                                    GROUP BY kod.id_prod_order
                                    )ko ON ko.id_prod_order_ko_det=kod.id_prod_order_ko_det
                                ) ko ON ko.id_prod_order=po.id_prod_order
                                LEFT JOIN  
                                ( 
	                                SELECT rec.prod_order_rec_date,recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty 
	                                FROM 
	                                tb_prod_order_rec rec 
	                                LEFT JOIN tb_prod_order_rec_det recd ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status != 5 
	                                WHERE rec.id_prod_order='" & id_fgpo & "'
	                                GROUP BY recd.id_prod_order_det 
                                ) rec ON rec.id_prod_order_det=pod.id_prod_order_det 
                                WHERE po.id_prod_order='" & id_fgpo & "'
                                GROUP BY po.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TEReff.Text = data.Rows(0)("reff_number").ToString

        TEVendorName.Text = data.Rows(0)("comp_number").ToString & " - " & data.Rows(0)("comp_name").ToString
        TEDesign.Text = data.Rows(0)("design_display_name").ToString
        TEDesignCode.Text = data.Rows(0)("design_code").ToString

        TEUSCOde.Text = data.Rows(0)("design_code_import").ToString

        LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()
        LECategory.EditValue = data.Rows(0)("id_term_production").ToString()
        TELeadTime.EditValue = data.Rows(0)("lead_time_prod")
        DERecDate.EditValue = data.Rows(0)("est_rec_date")
        DEPayDueDate.EditValue = data.Rows(0)("payment_due_date")
    End Sub
End Class