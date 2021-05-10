Public Class FormFGProposePriceCOPList
    Private Sub FormFGProposePriceCOPList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        view_division_fg()
        view_source_fg()
    End Sub

    Private Sub FormFGProposePriceCOPList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division_fg()
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name 
        FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEDivision, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub view_source_fg()
        Dim id_code As String = get_setup_field("id_code_fg_source")
        Dim query As String = "SELECT (id_code_detail) AS id_source, (code_detail_name) AS source, display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' HAVING source<>'-' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LESource, query, 0, "display_name", "id_source")
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
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
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_division=" + LEDivision.EditValue.ToString + " AND pd.id_report_status=6
        WHERE d.id_season=" + SLESeason.EditValue.ToString + " AND (d.id_lookup_status_order=1 OR d.id_lookup_status_order=3) AND src.id_src=" + LESource.EditValue.ToString + " "
        query += "ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewData()
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub LESource_EditValueChanged(sender As Object, e As EventArgs) Handles LESource.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub LEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles LEDivision.EditValueChanged
        GCData.DataSource = Nothing
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class