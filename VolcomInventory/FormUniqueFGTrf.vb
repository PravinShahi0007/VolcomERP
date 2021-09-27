Public Class FormUniqueFGTrf
    Public id_fg_trf As String = "-1"
    Public fg_trf_number As String = "-1"

    Private Sub FormUniqueFGTrf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT 1 AS `#`, CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `To`, s.fg_trf_number AS `Transfer`, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS `Unique Code`, 
            dcd.class AS `Class`,c.product_name AS `Description`, dcd.sht AS `Silhouette`, dcd.color AS `Color`, cd.code_detail_name AS `Size`
            FROM tb_fg_trf_det_counting a 
            INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det 
            INNER JOIN tb_fg_trf s ON b.id_fg_trf = s.id_fg_trf
            INNER JOIN tb_m_product c ON c.id_product = b.id_product 
            INNER JOIN tb_m_design d ON d.id_design = c.id_design
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
		        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		        FROM tb_m_design_code dc
		        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		        AND cd.id_code IN (32,30,14, 43)
		        GROUP BY dc.id_design
	        ) dcd ON dcd.id_design = d.id_design
            INNER JOIN tb_m_product_code pc ON pc.id_product = c.id_product 
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail 
            INNER JOIN tb_m_comp_contact cf ON cf.id_comp_contact = s.id_comp_contact_from
            INNER JOIN tb_m_comp cmf ON cmf.id_comp = cf.id_comp
            INNER JOIN tb_m_comp_contact ct ON ct.id_comp_contact = s.id_comp_contact_to
            INNER JOIN tb_m_comp cmt ON cmt.id_comp = ct.id_comp
            WHERE b.id_fg_trf = '" + id_fg_trf + "'
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns.ColumnByFieldName("#").MaxWidth = 30
        GVData.Columns.ColumnByFieldName("From").MaxWidth = 325
        GVData.Columns.ColumnByFieldName("To").MaxWidth = 325
        GVData.Columns.ColumnByFieldName("Size").MaxWidth = 50

        'number
        For i = 0 To GVData.RowCount - 1
            GVData.SetRowCellValue(i, "#", i + 1)
        Next

        print(GCData, fg_trf_number)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueFGTrf_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class