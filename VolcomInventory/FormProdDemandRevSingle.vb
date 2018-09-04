Public Class FormProdDemandRevSingle
    Private Sub FormProdDemandRevSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type WHERE id_pd_type<3 ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Sub actionLoad()
        viewLineType()
        Dim query As String = "SELECT  dp.id_prod_demand_design_rev, pdd.id_prod_demand_design,d.design_code AS `code`, d.design_display_name AS `name`, po.prod_order_number,
        IFNULL(po.ordered,0) AS `ordered`,
        IFNULL(rec.received,0) AS `received`, 'No' AS `is_select`
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, po.prod_order_number, SUM(pod.prod_order_qty) AS `ordered`
	        FROM tb_prod_order po 
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        WHERE po.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, SUM(rd.prod_order_rec_det_qty) AS `received` 
	        FROM tb_prod_order_rec_det rd
	        INNER JOIN tb_prod_order_rec r ON r.id_prod_order_rec = rd.id_prod_order_rec
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = rd.id_prod_order_det
	        INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	        WHERE r.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) rec ON rec.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT rd.id_prod_demand_design, rd.id_prod_demand_design_rev
	        FROM tb_prod_demand_design_rev rd
	        INNER JOIN tb_prod_demand_rev r ON r.id_prod_demand_rev = rd.id_prod_demand_rev
	        WHERE r.id_prod_demand_rev=" + FormProdDemandRevDet.id + "
        ) dp ON dp.id_prod_demand_design = pdd.id_prod_demand_design
        WHERE pdd.id_prod_demand=" + FormProdDemandRevDet.id_prod_demand + " AND ISNULL(dp.id_prod_demand_design_rev) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
    End Sub

    Private Sub FormProdDemandRevSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnRevise_Click(sender As Object, e As EventArgs) Handles BtnRevise.Click

    End Sub

    Private Sub BtnDrop_Click(sender As Object, e As EventArgs) Handles BtnDrop.Click

    End Sub

    Sub ok()
        GVDesign.ActiveFilterString = "[is_select]='Yes'"

        If GVDesign.RowCount <= 0 Then
            stopCustom("Please select article")
        Else
            'cek received
            For i As Integer = 0 To (GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign)
                If GVDesign.GetRowCellValue(i, "received") > 0 Then
                    stopCustom(GVDesign.GetRowCellValue(i, "name").ToString + " already received in QC")
                    GVDesign.ActiveFilterString = ""
                    Exit Sub
                End If
            Next


        End If
    End Sub




End Class