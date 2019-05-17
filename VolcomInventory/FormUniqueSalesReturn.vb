Public Class FormUniqueSalesReturn
    Public id_sales_return As String = "-1"

    Private Sub FormUniqueSalesReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `To`, s.sales_return_number AS `Sales Return`, CONCAT(c.product_full_code, a.sales_return_det_counting) AS `Unique Code`, c.product_name AS `Description`, cd.code_detail_name AS `Size`
            FROM tb_sales_return_det_counting a 
            INNER JOIN tb_sales_return_det b ON a.id_sales_return_det = b.id_sales_return_det 
            INNER JOIN tb_sales_return s ON b.id_sales_return = s.id_sales_return
            INNER JOIN tb_m_product c ON c.id_product = b.id_product 
            INNER JOIN tb_m_product_code pc ON pc.id_product = c.id_product 
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail 
            INNER JOIN tb_m_comp_contact cf ON cf.id_comp_contact = s.id_store_contact_from
            INNER JOIN tb_m_comp cmf ON cmf.id_comp = cf.id_comp
            INNER JOIN tb_m_comp_contact ct ON ct.id_comp_contact = s.id_comp_contact_to
            INNER JOIN tb_m_comp cmt ON cmt.id_comp = ct.id_comp
            LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique 
            WHERE b.id_sales_return = '" + id_sales_return + "'
            ORDER BY c.product_full_code ASC, a.sales_return_det_counting ASC
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns.ColumnByFieldName("From").MaxWidth = 300
        GVData.Columns.ColumnByFieldName("To").MaxWidth = 300
        GVData.Columns.ColumnByFieldName("Size").MaxWidth = 50
        print(GCData, GVData.GetFocusedRowCellValue("Sales Return").ToString)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueSalesReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class