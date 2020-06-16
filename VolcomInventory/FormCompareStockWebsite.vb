Public Class FormCompareStockWebsite
    Private Sub FormCompareStockWebsite_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim qry As String = "SELECT s.date AS `last_sync` FROM tb_m_stock_shopify s ORDER BY s.date DESC LIMIT 1 "
        Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
        LabelLast.Text = DateTime.Parse(dt.Rows(0)("last_sync").ToString).ToString("dd MMMM yyyy ")
        Cursor = Cursors.Default
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
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        FormMain.SplashScreenManager1.SetWaitFormDescription("Get stock from website")
        Dim cls As ClassShopifyApi = New ClassShopifyApi

        cls.sync_stock()

        FormMain.SplashScreenManager1.SetWaitFormDescription("Compare stock with ERP")
        viewCompare()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewCompare()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_compare_erp_shopify()"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlStock.DataSource = data
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
        viewCompare()
    End Sub
End Class