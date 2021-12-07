Public Class FormRetExos
    Public is_test As String = "-1"

    Private Sub FormRetExos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
        If is_test = "1" Then
            createNew()
        End If
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassRetExos()
        Dim query As String = r.queryMain("", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRetExos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormRetExos_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormRetExosDet.id = GVData.GetFocusedRowCellValue("id_ret_exos").ToString
            FormRetExosDet.action = "upd"
            FormRetExosDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCData, "Propose Return Extended EOS")
        Cursor = Cursors.Default
    End Sub

    Sub createNew()
        Cursor = Cursors.WaitCursor
        FormRetExosDet.action = "ins"
        FormRetExosDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub
End Class