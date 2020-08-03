Public Class FormPromoReplace
    Private Sub FormPromoReplace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim p As New ClassPromoCollection()
        Dim query As String = p.queryMain("AND p.id_report_status=6 AND NOW()<=p.end_period", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        If data.Rows.Count = 1 Then
            makeSafeGV(GVData)
            createOrder()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Sub createOrder()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderDet.action = "ins"
            FormSalesOrderDet.is_transfer_data = "1"
            FormSalesOrderDet.id_sales_order = "-1"
            FormSalesOrderDet.id_ol_promo = GVData.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            FormSalesOrderDet.ShowDialog()
            Opacity = 0
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        createOrder()
    End Sub

    Private Sub FormPromoReplace_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        createOrder()
    End Sub
End Class