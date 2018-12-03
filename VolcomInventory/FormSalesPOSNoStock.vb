Public Class FormSalesPOSNoStock
    Private Sub FormSalesPOSNoStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ns As New ClassSalesPOS()
        Dim query As String = ns.queryMainNoStock("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesPOSNoStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            'detail
            Cursor = Cursors.WaitCursor
            FormSalesPOSNoStockDet.action = "upd"
            FormSalesPOSNoStockDet.id = GVData.GetFocusedRowCellValue("id_sales_pos_no_stock").ToString
            FormSalesPOSNoStockDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesPOSNoStockDet.action = "ins"
        FormSalesPOSNoStockDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class