Public Class FormPricePolicyCode
    Private Sub FormPricePolicyCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_code_detail, cd.display_name AS `code`, cd.code_detail_name AS `description`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=1 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=1 THEN p.age_max END) AS DECIMAL(5,0))) AS `normal_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=2 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=2 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_30_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=3 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=3 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_50_view`,
        CONCAT(CAST(MAX(CASE WHEN p.id_disc_type=4 THEN p.age_min END) AS DECIMAL(5,0)),'-',CAST(MAX(CASE WHEN p.id_disc_type=4 THEN p.age_max END) AS DECIMAL(5,0))) AS `mkd_70_view`
        FROM tb_m_design_price_policy p
        INNER JOIN tb_lookup_disc_type dt ON dt.id_disc_type = p.id_disc_type
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = p.id_code_detail
        GROUP BY p.id_code_detail
        ORDER BY cd.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPricePolicyCode_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPricePolicyCode_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class