Public Class FormProductionSummary
    Private Sub FormProductionSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormProductionSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormProductionSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewApprovedPO()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT po.prod_order_number, comp.comp_name, 
        d.design_code AS `code`,d.design_display_name AS `name`, 
        SUM(pod.prod_order_qty) AS `qty`, CAST(SUM(pod.prod_order_qty) * (ovh.ovh_price * wo.prod_order_wo_kurs) AS DECIMAL(15,0)) AS `po_amount`,
        pdd.prod_demand_design_total_cost AS `cop_pd`, d.design_cop AS `cop_po`, pdd.prod_demand_design_propose_price AS `retail_price`, IFNULL(nprc.design_price,0) AS `normal_price`,
        UPPER(src.`product_source`) AS `product_source`, s.season
        FROM tb_prod_order po
        LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order= po.id_prod_order AND wo.is_main_vendor=1
        LEFT JOIN tb_m_ovh_price ovh ON ovh.id_ovh_price = wo.id_ovh_price
        LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovh.id_comp_contact 
        LEFT JOIN tb_m_comp comp ON comp.id_comp = cc.id_comp
        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        LEFT JOIN (
	        SELECT dsg.id_design, cd.code_detail_name AS product_source FROM tb_m_design dsg
	        INNER JOIN tb_m_design_code dc ON dc.id_design = dsg.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=5
	        GROUP BY dsg.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
	        SELECT dp.id_design, dp.design_price 
	        FROM tb_m_design_price dp WHERE dp.id_design_price_type=1
	        GROUP BY dp.id_design
        ) nprc ON nprc.id_design = d.id_design
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
        INNER JOIN tb_season s ON s.id_season = pd.id_season
        WHERE (po.id_report_status=3 OR po.id_report_status=6) 
        AND (po.prod_order_date>='" + date_from_selected + "' AND po.prod_order_date<='" + date_until_selected + "')
        GROUP BY po.id_prod_order "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewApprovedPO()
    End Sub
End Class