Public Class FormUniqueRevProduct
    Public id_pl_prod_order_rec As String = "-1"

    Private Sub FormUniqueRevProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT 1 AS `#`, CONCAT(vend_c.comp_number, ' - ', vend_c.comp_name) AS `Vendor`, CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `To`, pr.pl_prod_order_rec_number AS `Receive Product`, CONCAT(c.product_full_code, a.pl_prod_order_rec_det_counting) AS `Unique Code`, 
            dcd.class AS `Class`,c.product_name AS `Description`, dcd.sht AS `Silhouette`, dcd.color AS `Color`, cd.code_detail_name AS `Size`
            FROM tb_pl_prod_order_rec_det_counting a 
            INNER JOIN tb_pl_prod_order_rec_det b ON a.id_pl_prod_order_rec_det = b.id_pl_prod_order_rec_det 
            INNER JOIN tb_pl_prod_order_rec pr ON pr.id_pl_prod_order_rec = b.id_pl_prod_order_rec 
            INNER JOIN tb_pl_prod_order p ON p.id_pl_prod_order = pr.id_pl_prod_order
            INNER JOIN tb_prod_order po ON po.id_prod_order = p.id_prod_order
            LEFT JOIN tb_prod_order_wo vend_wo ON vend_wo.id_prod_order = po.id_prod_order AND vend_wo.is_main_vendor='1'
            LEFT JOIN tb_m_ovh_price vend_ovh ON vend_ovh.id_ovh_price = vend_wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact vend_cc On vend_cc.id_comp_contact = vend_ovh.id_comp_contact 
            LEFT JOIN tb_m_comp vend_c ON vend_c.id_comp = vend_cc.id_comp 
            INNER JOIN tb_m_comp_contact cf ON cf.id_comp_contact = pr.id_comp_contact_from
            INNER JOIN tb_m_comp cmf ON cmf.id_comp = cf.id_comp
            INNER JOIN tb_m_comp_contact ct ON ct.id_comp_contact = pr.id_comp_contact_to
            INNER JOIN tb_m_comp cmt ON cmt.id_comp = ct.id_comp
            INNER JOIN tb_m_product c ON a.id_product = c.id_product 
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
            WHERE b.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' AND a.id_counting_type = '1'
            ORDER BY c.product_full_code ASC, a.pl_prod_order_rec_det_counting ASC
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns.ColumnByFieldName("#").MaxWidth = 30
        GVData.Columns.ColumnByFieldName("Vendor").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("From").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("To").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("Size").MaxWidth = 50

        'number
        For i = 0 To GVData.RowCount - 1
            GVData.SetRowCellValue(i, "#", i + 1)
        Next

        print(GCData, GVData.GetFocusedRowCellValue("Receive Product").ToString)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueRevProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class