Public Class FormPurcAsset
    Private Sub FormPurcAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPending()
    End Sub

    Sub viewPending()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_report_status=1 AND ISNULL(a.is_active) ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPending.DataSource = data
        GVPending.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()
        Cursor = Cursors.WaitCursor
        Dim a As New ClassPurcAsset()
        Dim query As String = a.queryMain("AND a.id_report_status=6 AND a.is_active=1 ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCActive.DataSource = data
        GVActive.BestFitColumns()
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

    Private Sub RecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordToolStripMenuItem.Click

    End Sub

    Private Sub GVPending_DoubleClick(sender As Object, e As EventArgs) Handles GVPending.DoubleClick
        If GVPending.RowCount > 0 And GVPending.FocusedRowHandle >= 0 Then
            viewDetail(GVPending.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "-1")
        End If
    End Sub

    Sub viewDetail(ByVal id As String, ByVal is_view As String)
        Cursor = Cursors.WaitCursor
        FormPurcAssetDet.is_view = is_view
        FormPurcAssetDet.action = "upd"
        FormPurcAssetDet.id = id
        FormPurcAssetDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCAsset_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAsset.SelectedPageChanged
        If XTCAsset.SelectedTabPageIndex = 0 Then
            viewPending()
        ElseIf XTCAsset.SelectedTabPageIndex = 1 Then
            viewActive()
        End If
    End Sub

    Private Sub GVActive_DoubleClick(sender As Object, e As EventArgs) Handles GVActive.DoubleClick
        If GVActive.RowCount > 0 And GVActive.FocusedRowHandle >= 0 Then
            viewDetail(GVActive.GetFocusedRowCellValue("id_purc_rec_asset").ToString, "1")
        End If
    End Sub
End Class