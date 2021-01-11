Public Class FormCompareStockWebsite
    Public id_last_sync As String = "-1"
    Dim id_log_selected As String = "-1"
    Private Sub FormCompareStockWebsite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        getLastSync()
        Cursor = Cursors.Default
    End Sub

    Sub getLastSync()
        Dim qry As String = "SELECT IFNULL(c.id_log_compare_shopify,0) AS `id_log_compare_shopify`,c.sync_date AS `sync_date`
FROM tb_log_compare_shopify c ORDER BY c.sync_date DESC LIMIT 1 "
        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
        id_last_sync = dt.Rows(0)("id_log_compare_shopify").ToString
        LabelLast.Text = DateTime.Parse(dt.Rows(0)("sync_date").ToString).ToString("dd MMMM yyyy HH:mm:ss")
    End Sub

    Private Sub FormCompareStockWebsite_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormCompareStockWebsite_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormCompareStockWebsite_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBSync_Click(sender As Object, e As EventArgs) Handles SBSync.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Pastikan Anda sudah melakukan sinkronisasi untuk 'Paid Order', agar komparasi data lebih valid. Lanjut komparasi stok ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            FormMain.SplashScreenManager1.ShowWaitForm()

            'save date sync
            Dim query As String = "INSERT INTO tb_log_compare_shopify(sync_date, sync_by) VALUES(NOW(), '" + id_user + "'); SELECT LAST_INSERT_ID(); "
            Dim id_new As String = execute_query(query, 0, True, "", "", "", "")

            FormMain.SplashScreenManager1.SetWaitFormDescription("Get stock from website")
            Dim cls As ClassShopifyApi = New ClassShopifyApi
            cls.sync_stock(id_new)

            FormMain.SplashScreenManager1.SetWaitFormDescription("Get open order")
            cls.get_open_order(id_new)

            FormMain.SplashScreenManager1.SetWaitFormDescription("Compare stock with ERP")
            viewCompare(id_new)
            getLastSync()
            FormMain.SplashScreenManager1.CloseWaitForm()
            Cursor = Cursors.Default
        End If

    End Sub

    Sub viewCompare(ByVal id_log As String)
        Cursor = Cursors.WaitCursor
        id_log_selected = id_log
        Dim query As String = "CALL view_stock_compare_erp_shopify(" + id_log + ")"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlStock.DataSource = data
        GridViewStock.BestFitColumns()
        If data.Rows.Count > 0 Then
            GroupControlView.Text = "Sync Date : " + DateTime.Parse(data.Rows(0)("sync_date")).ToString("dd MMMM yyyy HH:mm:ss")
        Else
            GroupControlView.Text = "Sync Date : -"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SBExport_Click(sender As Object, e As EventArgs) Handles SBExport.Click
        If GridViewStock.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GridViewStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GridViewStock.Columns.Count - 1
                Try
                    If GridViewStock.Columns(i).OwnerBand.Caption = "ERP" Or GridViewStock.Columns(i).OwnerBand.Caption = "SHOPIFY" Then
                        GridViewStock.Columns(i).Caption = GridViewStock.Columns(i).OwnerBand.Caption + " " + GridViewStock.Columns(i).Caption
                    End If
                Catch ex As Exception
                End Try
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "compare_erp_shopify.xlsx"
            exportToXLS(path, "compare", GridControlStock)

            'restore column opt
            GridViewStock.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        viewCompare(id_last_sync)
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        Cursor = Cursors.WaitCursor
        FormCompareStockWebHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewBook_Click(sender As Object, e As EventArgs) Handles BtnViewBook.Click
        Cursor = Cursors.Default
        FormCompareStockWebsiteDetailBook.id_log = id_log_selected
        FormCompareStockWebsiteDetailBook.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        print_compare()
    End Sub

    Sub print_compare()
        Cursor = Cursors.WaitCursor
        print(GridControlStock, "Compare Stock ERP & Shopify - " + GroupControlView.Text)
        Cursor = Cursors.Default
    End Sub
End Class