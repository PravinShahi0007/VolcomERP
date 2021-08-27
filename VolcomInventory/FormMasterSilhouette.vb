Public Class FormMasterSilhouette
    Public is_show_master_sht As Boolean = False

    Private Sub FormMasterSilhouette_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewClass()
        If is_show_master_sht Then
            BtnSilhouetteList.Visible = True
        End If
    End Sub

    Sub viewClass()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cls.id_code_detail AS `id_class`, cls.display_name AS `class`, cls.code_detail_name AS `class_desc`, 
        sht.id_code_detail AS `id_sht`, sht.code_detail_name AS `sht_name`
        FROM tb_m_code_detail cls
        LEFT JOIN tb_mapping_sht ms ON ms.id_class = cls.id_code_detail
        LEFT JOIN tb_m_code_detail sht ON sht.id_code_detail = ms.id_sht AND sht.id_code IN (SELECT o.id_code_fg_sht FROM tb_opt o)
        WHERE cls.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
        ORDER BY cls.display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClass.DataSource = data
        GVClass.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterSilhouette_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCClass, "")
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.DataAware

            GVClass.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMapping_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GVClass_DoubleClick(sender As Object, e As EventArgs) Handles GVClass.DoubleClick
        If GVClass.RowCount > 0 And GVClass.FocusedRowHandle >= 0 Then
            Dim id_cls As String = GVClass.GetFocusedRowCellValue("id_class").ToString
            FormMasterSilhouetteDet.id_class = id_cls
            FormMasterSilhouetteDet.TxtClass.Text = GVClass.GetFocusedRowCellValue("class").ToString
            FormMasterSilhouetteDet.TxtClassDesc.Text = GVClass.GetFocusedRowCellValue("class_desc").ToString
            FormMasterSilhouetteDet.ShowDialog()
            viewClass()
            GVClass.FocusedRowHandle = find_row(GVClass, "id_class", id_cls)
        End If
    End Sub

    Private Sub BtnSilhouetteList_Click(sender As Object, e As EventArgs) Handles BtnSilhouetteList.Click
        Cursor = Cursors.WaitCursor
        Dim cms As New ClassMasterSilhouette()
        cms.openSHTList()
        Cursor = Cursors.Default
    End Sub
End Class