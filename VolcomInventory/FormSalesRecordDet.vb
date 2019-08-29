Public Class FormSalesRecordDet
    Public id As String = "-1"

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormSalesRecordDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesRecordDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pcd.id_pos_combine_det, pcd.id_pos_combine, pcd.id_pos_det, pcd.id_pos, pcd.id_item, 
        pcd.id_product, p.product_display_name AS `name`, pcd.item_code, p.product_full_code AS `code`, cd.code_detail_name AS `size`,
        pcd.id_comp_sup, CONCAT(c.comp_number, ' - ',  c.comp_name) AS `supplier`, pcd.comm, pcd.qty, pcd.price, pcd.sync_time 
        FROM tb_pos_combine_det pcd
        INNER JOIN tb_m_product p ON p.id_product = pcd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_comp c ON c.id_comp = pcd.id_comp_sup
        WHERE pcd.id_pos_combine=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub
End Class