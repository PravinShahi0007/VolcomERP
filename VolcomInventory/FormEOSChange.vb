Public Class FormEOSChange
    Public is_test As String = "-1"

    Private Sub FormEOSChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
        If is_test = "1" Then
            createNew()
        End If
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cs As New ClassEOSChange()
        Dim query As String = cs.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEOSChange_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEOSChange_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormEOSChangeDet.id = GVData.GetFocusedRowCellValue("id_eos_change").ToString
            FormEOSChangeDet.action = "upd"
            FormEOSChangeDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCData, "Pengajuan Perpanjangan EOS")
        Cursor = Cursors.Default
    End Sub

    Sub createNew()
        Cursor = Cursors.WaitCursor
        Dim qcek As String = "SELECT * FROM tb_eos_change s WHERE s.id_report_status<5 "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            stopCustom("Please complete all pending transaction first")
        Else
            FormEOSChangeDet.action = "ins"
            FormEOSChangeDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub
End Class