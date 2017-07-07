Public Class FormSalesOrderDetEdit

    Private Sub FormSalesOrderDetEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCode.Text = FormSalesOrderDet.GVItemList.GetFocusedRowCellValue("code").ToString
        TxtDesign.Text = FormSalesOrderDet.GVItemList.GetFocusedRowCellValue("name").ToString
        TxtSize.Text = FormSalesOrderDet.GVItemList.GetFocusedRowCellValue("size").ToString
        TxtCurrent.EditValue = FormSalesOrderDet.GVItemList.GetFocusedRowCellValue("sales_order_det_qty")
        TxtAdd.EditValue = 1
        getQty()
        TxtAdd.Focus()
    End Sub

    Private Sub TxtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim qty_limit As Integer = FormSalesOrderDet.GVItemList.GetFocusedRowCellValue("qty_avail")
            Dim qty As Integer = TxtQty.EditValue
            If qty > qty_limit Then
                stopCustom("Can't exceed " + qty_limit.ToString)
                TxtAdd.EditValue = 1
                TxtAdd.Focus()
            Else
                FormSalesOrderDet.GVItemList.SetFocusedRowCellValue("sales_order_det_qty", qty)
                Close()
            End If
        End If
    End Sub

    Private Sub TextEdit5_Properties_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAdd.Properties.KeyUp
        getQty()
    End Sub

    Sub getQty()
        Dim curr As Integer = TxtCurrent.EditValue
        Dim add As Integer = 0
        Try
            add = TxtAdd.EditValue
        Catch ex As Exception
        End Try
        TxtQty.EditValue = curr + add
    End Sub

    Private Sub FormSalesOrderDetEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderDetEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class