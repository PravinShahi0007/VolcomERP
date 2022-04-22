Public Class FormPopUpProdRec
    Public id_po As String = "-1"
    Private Sub FormPopUpProdRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPO()
        If Not id_po = "-1" Then
            SLEFGPO.EditValue = id_po
            load_rec()
        End If
    End Sub

    Sub viewPO()
        Dim q As String = "
SELECT 0 AS id_prod_order,'ALL' AS prod_order_number,'ALL' AS design_display_name,'ALL' AS design_code
UNION ALL
SELECT po.id_prod_order,po.prod_order_number,dsg.design_display_name,dsg.design_code 
FROM tb_prod_order po
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design 
WHERE po.id_report_status='6'"
        viewSearchLookupQuery(SLEFGPO, q, "id_prod_order", "prod_order_number", "id_prod_order")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_rec()
    End Sub

    Sub load_rec()
        Dim query_where As String = ""
        If Not SLEFGPO.EditValue.ToString = "0" Then
            query_where = " WHERE a.id_prod_order='" & SLEFGPO.EditValue.ToString & "' "
        End If
        Dim query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code AS `code`,(dsg.design_display_name) AS name, SUM(ad.prod_order_rec_det_qty) AS `qty`, po_type.po_type "
        query += ",DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY) AS est_qc_date
,DATEDIFF(DATE_ADD(IFNULL(wo.prod_order_wo_del_date,b.prod_order_date), INTERVAL IF(ISNULL(ko.lead_time_prod),IFNULL(wo.prod_order_wo_lead_time,0),ko.lead_time_prod) DAY), a.arrive_date) AS diff_day "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order_rec_det ad ON ad.id_prod_order_rec = a.id_prod_order_rec "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += "LEFT JOIN 
( 
    SELECT id_prod_order,prod_order_wo_lead_time,prod_order_wo_del_date
    FROM tb_prod_order_wo
    WHERE id_report_status=6 AND is_main_vendor=1
) wo ON wo.id_prod_order=b.id_prod_order "
        query += "LEFT JOIN (
                    SELECT kod.* FROM tb_prod_order_ko_det kod
                    INNER JOIN
                    (
	                    SELECT kod.id_prod_order,MAX(kod.id_prod_order_ko_det) AS id_prod_order_ko_det FROM tb_prod_order_ko_det kod
	                    INNER JOIN tb_prod_order_ko ko ON ko.id_prod_order_ko=kod.id_prod_order_ko AND ko.is_void=2
	                    GROUP BY kod.id_prod_order
                    ) ko ON ko.id_prod_order=kod.id_prod_order AND kod.id_prod_order_ko_det=ko.id_prod_order_ko_det
                ) ko ON ko.id_prod_order=a.id_prod_order "
        query += query_where
        query += "GROUP BY a.id_prod_order_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
        End If
        GVProdRec.BestFitColumns()
        GVProdRec.ExpandAllGroups()
    End Sub
End Class