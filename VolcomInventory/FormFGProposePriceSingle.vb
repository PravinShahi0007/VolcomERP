Public Class FormFGProposePriceSingle
    Private Sub FormFGProposePriceSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_design, pdd.id_prod_demand_design,d.design_code AS `code`, cls.id_class,cls.`class`, d.design_display_name AS `name`, 
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.id_cop_status,0),IF(d.final_is_approve=1,d.id_cop_status,0)) AS `id_cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,'Pre Final','-'),IF(d.final_is_approve=1,'Final','-')) AS `cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.prod_order_cop_mng_addcost,0),IF(d.final_is_approve=1,d.design_cop_addcost,0)) AS `additional_cost`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,IF(d.pp_cop_rate_cat=1,'BOM','Payment'),'-'),IF(d.final_is_approve=1,IF(d.final_cop_rate_cat=1,'BOM','Payment'),'-')) AS `cop_rate_cat`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_kurs,0),IF(d.final_is_approve=1,d.final_cop_kurs,0)) AS `cop_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_value,0),IF(d.final_is_approve=1,d.final_cop_value,0)) AS `cop_value`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_kurs,0),IF(d.final_is_approve=1,d.final_cop_mng_kurs,0)) AS `cop_mng_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_value,0),IF(d.final_is_approve=1,d.final_cop_mng_value,0)) AS `cop_mng_value`,
        'No' AS `is_select`
        FROM tb_m_design d 
        LEFT JOIN (
	        SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
	        FROM tb_m_design d
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
	        GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
	        FROM tb_m_design d
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
	        GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_design = d.id_design AND pdd.is_void=2
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_division=" + FormFGProposePriceDetail.id_division + " AND pd.id_report_status=6
        INNER JOIN tb_prod_order po ON  po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status!=5
        LEFT JOIN tb_fg_propose_price_detail ppd ON ppd.id_design = d.id_design
        WHERE d.id_season=" + FormFGProposePriceDetail.SLESeason.EditValue.ToString + " AND d.id_lookup_status_order=1 AND src.id_src=" + FormFGProposePriceDetail.id_source + "  AND ISNULL(ppd.id_fg_propose_price_detail)
        HAVING id_cop_status>0
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        close
    End Sub

    Private Sub FormFGProposePriceSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Dim res As String = ""
        If CESelAll.EditValue = True Then
            res = "Yes"
        Else
            res = "No"
        End If

        For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
            GVData.SetRowCellValue(i, "is_select", res)
        Next
    End Sub
End Class