Public Class FormVirtualSales
    Public is_load_new As New Boolean

    Private Sub FormVirtualSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSalesList()

        'caption size sal
        GVSOHSal.Columns("sal_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVSOHSal.Columns("sal_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVSOHSal.Columns("sal_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVSOHSal.Columns("sal_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVSOHSal.Columns("sal_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVSOHSal.Columns("sal_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVSOHSal.Columns("sal_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVSOHSal.Columns("sal_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVSOHSal.Columns("sal_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVSOHSal.Columns("sal_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'caption soh sal
        GVSOHSal.Columns("soh_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVSOHSal.Columns("soh_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVSOHSal.Columns("soh_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVSOHSal.Columns("soh_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVSOHSal.Columns("soh_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVSOHSal.Columns("soh_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVSOHSal.Columns("soh_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVSOHSal.Columns("soh_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVSOHSal.Columns("soh_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVSOHSal.Columns("soh_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Private Sub FormVirtualSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSalesList()
        Cursor = Cursors.WaitCursor
        Dim vs As New ClassVirtualSales()
        Dim query As String = vs.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        FormVirtualSalesDet.action = "ins"
        FormVirtualSalesDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        If GVSales.RowCount > 0 And GVSales.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormVirtualSalesDet.action = "upd"
            FormVirtualSalesDet.id = GVSales.GetFocusedRowCellValue("id_virtual_sales").ToString
            FormVirtualSalesDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSales_DoubleClick(sender As Object, e As EventArgs) Handles GVSales.DoubleClick
        viewDetail()
    End Sub
End Class