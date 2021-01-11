Public Class FormCompareStockWebHistory
    Private Sub FormCompareStockWebHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT s.id_log_compare_shopify, s.sync_date, s.sync_by, emp.employee_name
FROM tb_log_compare_shopify s
INNER JOIN tb_m_user us ON us.id_user = s.sync_by
INNER JOIN tb_m_employee emp ON emp.id_employee  = us.id_employee
ORDER BY s.sync_date DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormCompareStockWebHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormCompareStockWebsite.viewCompare(GVData.GetFocusedRowCellValue("id_log_compare_shopify").ToString)
            Close()
        End If
    End Sub
End Class