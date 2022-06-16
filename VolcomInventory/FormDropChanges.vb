Public Class FormDropChanges
    Public is_test As String = "-1"
    Public is_load_new As Boolean = False

    Private Sub FormDropChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
        If is_test = "1" Then
            createNew()
        End If
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim dc As New ClassDropChanges()
        Dim query As String = dc.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDropChanges_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDropChanges_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewDetail()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDropChangesDet.id = GVData.GetFocusedRowCellValue("id_drop_changes").ToString
            FormDropChangesDet.action = "upd"
            FormDropChangesDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCData, "Propose Drop & Changes")
        Cursor = Cursors.Default
    End Sub

    Sub createNew()
        Cursor = Cursors.WaitCursor
        FormDropChangesDet.action = "ins"
        FormDropChangesDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        viewDetail()
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetail()
        End If
    End Sub
End Class