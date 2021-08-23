Public Class FormStockTakeStoreScanList
    Public id_period As String = "-1"
    Public id_product As String = "-1"
    Private Sub FormStockTakeStoreScanList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading data")
        Dim query As String = "CALL view_st_scanned_list(" + id_period + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("image").ToString = "" Then
                data.Rows(i)("image") = get_setup_field("volcom_client_host") + "/stocktake/getImage?image=" + data.Rows(i)("image").ToString.Replace("[""", "").Replace("]", "").Replace("\", "").Replace("""", "")
            End If
        Next

        GCData.DataSource = data
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
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