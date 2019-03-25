Public Class FormFGProposePriceSingle
    Private Sub FormFGProposePriceSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_design, pdd.id_prod_demand_design,d.design_code AS `code`, cls.id_class,cls.`class`, d.design_display_name AS `name`, 
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.id_cop_status,0),IF(d.final_is_approve=1,d.id_cop_status,0)) AS `id_cop_status`,
        d.`pp_cop_rate_cat`,
        d.`pp_cop_kurs` ,
        d.`pp_cop_value`,
        d.`pp_cop_mng_kurs` ,
        d.`pp_cop_mng_value`,
        d.`pp_is_approve`,
        d.`pp_approve_by`,
        d.`final_cop_rate_cat`,
        d.`final_cop_kurs`,
        d.`final_cop_value`,
        d.`final_cop_mng_kurs`,
        d.`final_cop_mng_value`,
        d.`final_is_approve`,
        d.`final_approve_by`,
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
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_division=3823 AND pd.id_report_status=6
        INNER JOIN tb_prod_order po ON  po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status!=5
        WHERE d.id_season=" + FormFGProposePriceDetail.SLESeason.EditValue.ToString + " AND d.id_lookup_status_order=1 AND src.id_src=" + FormFGProposePriceDetail.id_source + " 
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