Public Class FormEmpUniExpenseSetQty
    Public id_del_det As String = "-1"
    Dim limit_qty As Integer = 0
    Private Sub FormEmpUniExpenseSetQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pl_sales_order_del_det_qty AS `limit_qty` FROM tb_pl_sales_order_del_det WHERE id_pl_sales_order_del_det='" + id_del_det + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        limit_qty = data.Rows(0)("limit_qty")
        TxtQty.EditValue = limit_qty
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpUniExpenseSetQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSetQty_Click(sender As Object, e As EventArgs) Handles BtnSetQty.Click
        If TxtQty.EditValue > limit_qty Then
            errorCustom("Can't exceed " + limit_qty.ToString)
        Else
            FormEmpUniExpenseDet.GVData.SetFocusedRowCellValue("qty", TxtQty.EditValue)
            FormEmpUniExpenseDet.GCData.RefreshDataSource()
            FormEmpUniExpenseDet.GVData.RefreshData()
            FormEmpUniExpenseDet.calculate()
            Close()
        End If
    End Sub
End Class