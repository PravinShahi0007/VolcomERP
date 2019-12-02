Public Class FormUniqueFGTrf
    Public id_fg_trf As String = "-1"
    Public fg_trf_number As String = "-1"

    Private Sub FormUniqueFGTrf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT 1 AS `#`, CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `To`, s.fg_trf_number AS `Transfer`, CONCAT(c.product_full_code, a.fg_trf_det_counting) AS `Unique Code`, c.product_name AS `Description`, cd.code_detail_name AS `Size`
            FROM tb_fg_trf_det_counting a 
            INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det 
            INNER JOIN tb_fg_trf s ON b.id_fg_trf = s.id_fg_trf
            INNER JOIN tb_m_product c ON c.id_product = b.id_product 
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