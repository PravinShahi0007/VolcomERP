Imports DevExpress.XtraPivotGrid

Public Class Pivot

    Private Sub Pivot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT prod.id_product, prod.id_design, (prod.product_name) AS `DESCRIPTION`, (prod.`Size`) AS `SIZE`, (prod.`Product Class`) AS `CLASS`,"
        query += " ds.fg_ds_qty"
        query += " FROM"
        query += " ("
        query += " SELECT f.id_product, f2.id_sample,  f.product_full_code, f.product_ean_code, f.product_name, f.product_display_name, "
        query += " f1.design_code, f1.id_design, f1.design_name, f1.design_display_name,"
        query += " g.uom, f1.id_season, "
        query += " MAX(IF(c.code_name = 'Size',b.code_detail_name,NULL)) AS 'Size', MAX(IF(c.code_name = 'Size',b.display_name,NULL)) AS 'Size_product_display',MAX(IF(d3.code_name = 'Product Counting',d2.code_detail_name,NULL)) AS 'Product Counting',MAX(IF(d3.code_name = 'Product Category',d2.code_detail_name,NULL)) AS 'Product Category',MAX(IF(d3.code_name = 'Product Source',d2.code_detail_name,NULL)) AS 'Product Source',MAX(IF(d3.code_name = 'Product Branding',d2.code_detail_name,NULL)) AS 'Product Branding',MAX(IF(d3.code_name = 'Range',d2.code_detail_name,NULL)) AS 'Range',MAX(IF(d3.code_name = 'Color',d2.code_detail_name,NULL)) AS 'Color',MAX(IF(d3.code_name = 'Product Subcategory',d2.code_detail_name,NULL)) AS 'Product Subcategory',MAX(IF(d3.code_name = 'Product Division',d2.code_detail_name,NULL)) AS 'Product Division',MAX(IF(d3.code_name = 'Product Class',d2.code_detail_name,NULL)) AS 'Product Class', MAX(IF(d3.code_name = 'Product Counting',d2.code_detail_name,NULL)) AS 'Product Counting_design_display',MAX(IF(d3.code_name = 'Product Category',d2.code_detail_name,NULL)) AS 'Product Category_design_display',MAX(IF(d3.code_name = 'Product Source',d2.code_detail_name,NULL)) AS 'Product Source_design_display',MAX(IF(d3.code_name = 'Product Branding',d2.code_detail_name,NULL)) AS 'Product Branding_design_display',MAX(IF(d3.code_name = 'Range',d2.code_detail_name,NULL)) AS 'Range_design_display',MAX(IF(d3.code_name = 'Color',d2.code_detail_name,NULL)) AS 'Color_design_display',MAX(IF(d3.code_name = 'Product Subcategory',d2.code_detail_name,NULL)) AS 'Product Subcategory_design_display',MAX(IF(d3.code_name = 'Product Division',d2.code_detail_name,NULL)) AS 'Product Division_design_display',MAX(IF(d3.code_name = 'Product Class',d2.code_detail_name,NULL)) AS 'Product Class_design_display'"
        query += " FROM tb_m_product f "
        query += " LEFT JOIN tb_m_product_code a ON a.id_product = f.id_product "
        query += " LEFT JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail "
        query += " LEFT JOIN tb_m_code c ON b.id_code = c.id_code "
        query += " INNER JOIN tb_m_design f1 ON f.id_design = f1.id_design"
        query += " LEFT JOIN tb_m_design_code d1 ON f1.id_design = d1.id_design "
        query += " LEFT JOIN tb_m_code_detail d2 ON d1.id_code_detail = d2.id_code_detail "
        query += " LEFT JOIN tb_m_code d3 ON d2.id_code = d3.id_code "
        query += " INNER JOIN tb_m_sample f2 ON f2.id_sample = f1.id_sample"
        query += " INNER JOIN tb_m_uom g ON g.id_uom = f1.id_uom"
        query += " WHERE f1.id_season = '28'"
        query += " GROUP BY f.id_product"
        query += " ORDER BY f.id_product ASC"
        query += " ) prod"
        query += " LEFT JOIN tb_fg_ds ds ON prod.id_product = ds.id_product AND ds.id_ds_type = '1'"
        query += " LEFT JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store AND ds_store.id_season='28'"
        query += " LEFT JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp"

        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        PGC.DataSource = data

        Dim fieldCategoryName As PivotGridField = New PivotGridField("SIZE", PivotArea.ColumnArea)
        fieldCategoryName.Caption = "Product Size"

        Dim fieldCountry As PivotGridField = New PivotGridField("CLASS", PivotArea.RowArea)

        ' Create a filter Pivot Grid Control field bound to the ProductName datasource field.
        Dim fieldProductName As PivotGridField = New PivotGridField("DESCRIPTION", PivotArea.RowArea)
        fieldProductName.Caption = "Product Description"
        '
        Dim fieldExtendedPrice As PivotGridField = New PivotGridField("fg_ds_qty", PivotArea.DataArea)
        fieldExtendedPrice.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        fieldCountry.AreaIndex = 0
        fieldProductName.AreaIndex = 1
        '
        PGC.Fields.AddRange(New PivotGridField() {fieldCategoryName, fieldProductName, fieldExtendedPrice, fieldCountry})
        PGC.BestFit()
    End Sub

    Private Sub Pivot_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class