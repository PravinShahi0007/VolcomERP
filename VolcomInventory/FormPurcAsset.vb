Public Class FormPurcAsset
    Private Sub FormPurcAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPending()
    End Sub

    Sub viewPending()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.is_record=2", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPending.DataSource = data
        GVPending.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcAsset_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPurcAsset_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcAsset_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If XTCAsset.SelectedTabPageIndex = 0 Then
            RecordToolStripMenuItem.Visible = True
        Else
            RecordToolStripMenuItem.Visible = False
        End If
    End Sub
End Class