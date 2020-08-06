Public Class FormVAHistory
    Private Sub FormVAHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormVAHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT a.id_virtual_acc_trans,a.id_virtual_acc, va.bank, a.transaction_date, a.generate_date, SUM(d.amount) AS `amount`
        FROM tb_virtual_acc_trans a 
        INNER JOIN tb_virtual_acc va ON va.id_virtual_acc = a.id_virtual_acc
        INNER JOIN tb_virtual_acc_trans_det d ON d.id_virtual_acc_trans = a.id_virtual_acc_trans
        GROUP BY a.id_virtual_acc_trans "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCVA.DataSource = data
        GVVA.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCVA, "Imported List")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPayout_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub GVVA_DoubleClick(sender As Object, e As EventArgs) Handles GVVA.DoubleClick
        If GVVA.RowCount > 0 And GVVA.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormVAHistoryDetail.id = GVVA.GetFocusedRowCellValue("id_virtual_acc_trans").ToString
            FormVAHistoryDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class