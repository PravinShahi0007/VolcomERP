Public Class FormAREvaluationPickDate
    Private Sub FormAREvaluationPickDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormAREvaluation.eval_date = GVData.GetFocusedRowCellValue("eval_date").ToString
            FormAREvaluation.BtnBrowseEval.Text = GVData.GetFocusedRowCellValue("eval_date_label").ToString
            FormAREvaluation.id_ar_eval_pps = GVData.GetFocusedRowCellValue("id_ar_eval_pps").ToString
            FormAREvaluation.TxtAREvalNumber.Text = GVData.GetFocusedRowCellValue("number").ToString
            FormAREvaluation.GCInvoiceDetail.DataSource = Nothing
            FormAREvaluation.GCGroup.DataSource = Nothing
            FormAREvaluation.GCSummary.DataSource = Nothing
            Close()
        End If
    End Sub

    Private Sub FormAREvaluationPickDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        '%H:%i:%s
        Dim query As String = "SELECT DATE_FORMAT(a.eval_date, '%d %M %Y') AS `eval_date_label`, DATE_FORMAT(a.eval_date,'%Y-%m-%d %H:%i:%s') AS `eval_date`,
        a.id_ar_eval_pps, a.number
        FROM tb_ar_eval_pps a
        ORDER BY a.id_ar_eval_pps DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class