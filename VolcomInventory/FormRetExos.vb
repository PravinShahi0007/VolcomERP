Public Class FormRetExos
    Private Sub FormRetExos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassRetExos()
        Dim query As String = r.queryMain("", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "", "")
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

    End Sub

    Sub printList()
        Cursor = Cursors.WaitCursor
        print(GCData, "Propose Return Extended EOS")
        Cursor = Cursors.Default
    End Sub
End Class