Public Class FormSalesOrderBSP
    Private Sub FormSalesOrderBSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim bsp As New ClassBSP()
        Dim query As String = bsp.queryMain("AND b.id_report_status=6 AND DATE(NOW())>=b.start_date AND DATE(NOW())<=b.end_date ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default

        If GVData.RowCount <= 0 Then
            warningCustom("Tidak ada event big sale yang sedang berlangsung")
            Close()
        End If
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Sub choose()
        Cursor = Cursors.WaitCursor
        FormSalesOrderDet.action = "ins"
        FormSalesOrderDet.id_bsp = GVData.GetFocusedRowCellValue("id_bsp").ToString
        FormSalesOrderDet.ShowDialog()
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormSalesOrderBSP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick_1(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            choose()
        End If
    End Sub
End Class