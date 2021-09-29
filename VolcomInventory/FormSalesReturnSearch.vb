﻿Public Class FormSalesReturnSearch
    Public dt As DataTable
    Public id_pop_up As String = "-1"

    Private Sub FormSalesReturnSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.FocusedRowHandle = 0
        ActiveControl = GCData
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            If id_pop_up = "-1" Then
                FormSalesReturnDetProblem.TxtSearch.Text = ""
                FormSalesReturnDetProblem.TxtCode.Text = GVData.GetFocusedRowCellValue("design_code").ToString
                FormSalesReturnDetProblem.TxtBarcode.Text = GVData.GetFocusedRowCellValue("product_code").ToString
                FormSalesReturnDetProblem.TxtSize.Text = GVData.GetFocusedRowCellValue("size").ToString
                FormSalesReturnDetProblem.TxtClass.Text = GVData.GetFocusedRowCellValue("class").ToString
                FormSalesReturnDetProblem.TxtColor.Text = GVData.GetFocusedRowCellValue("color").ToString
                FormSalesReturnDetProblem.TxtDesign.Text = GVData.GetFocusedRowCellValue("name").ToString
                FormSalesReturnDetProblem.id_product = GVData.GetFocusedRowCellValue("id_product").ToString
                FormSalesReturnDetProblem.is_old_design = GVData.GetFocusedRowCellValue("is_old_design").ToString
                Close()
            ElseIf id_pop_up = "1" Then
                FormFGCodeReplaceStoreAdd.TxtDesignCode.Text = GVData.GetFocusedRowCellValue("product_code").ToString
                FormFGCodeReplaceStoreAdd.TxtDesignName.Text = GVData.GetFocusedRowCellValue("name").ToString
                FormFGCodeReplaceStoreAdd.TxtSize.Text = GVData.GetFocusedRowCellValue("size").ToString
                FormFGCodeReplaceStoreAdd.id_product = GVData.GetFocusedRowCellValue("id_product").ToString
                FormFGCodeReplaceStoreAdd.id_design = GVData.GetFocusedRowCellValue("id_design").ToString
                Close()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormSalesReturnSearch_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub

    Private Sub GVData_KeyDown(sender As Object, e As KeyEventArgs) Handles GVData.KeyDown
        If e.KeyCode = Keys.Enter Then
            choose()
        End If
    End Sub
End Class