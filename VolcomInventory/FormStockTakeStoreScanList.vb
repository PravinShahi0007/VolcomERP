Public Class FormStockTakeStoreScanList
    Public id_period As String = "-1"
    Public id_product As String = "-1"
    Private Sub FormStockTakeStoreScanList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT s.id_product,s.scanned_code, p.product_name  AS `name`, cd.code_detail_name AS `size`,s.qty, s.created_date,
        IF(s.is_unique_not_found=1,'Yes', 'No') AS `is_unique_not_found_view`, IF(s.is_no_tag=1,'Yes', 'No') AS `is_no_tag_view`, image
        FROM tb_st_store s
        INNER JOIN tb_m_product p ON p.id_product = s.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE s.id_st_store_period='" + id_period + "'
        ORDER BY s.created_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("image").ToString = "" Then
                data.Rows(i)("image") = get_setup_field("volcom_client_host") + "/stocktake/getImage?image=" + data.Rows(i)("image").ToString.Replace("[""", "").Replace("]", "").Replace("\", "").Replace("""", "")
            End If
        Next

        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStockTakeStoreScanList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Scanned List")
        Cursor = Cursors.Default
    End Sub
End Class