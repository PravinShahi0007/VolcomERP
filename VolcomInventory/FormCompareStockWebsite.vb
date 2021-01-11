Public Class FormCompareStockWebsite
    Public id_last_sync As String = "-1"
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

    Sub print()
        print_raw(GridControlStock, "")
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
            FormMain.SplashScreenManager1.CloseWaitForm()
            Cursor = Cursors.Default
        End If

    End Sub

    Sub viewCompare(ByVal id_log As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_compare_erp_shopify(" + id_log + ")"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlStock.DataSource = data
        GridViewStock.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SBExport_Click(sender As Object, e As EventArgs) Handles SBExport.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xls"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsExportOptionsEx = New DevExpress.XtraPrinting.XlsExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GridViewStock.ExportToXls(save.FileName, op)

            infoCustom("File exported.")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        viewCompare(id_last_sync)
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles BtnHistory.Click
        Cursor = Cursors.WaitCursor
        FormCompareStockWebHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class