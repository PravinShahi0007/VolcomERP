Public Class FormProposePriceMKD
    Public is_load_new As Boolean = False
    Private Sub FormProposePriceMKD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSummary()
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim mkd As New ClassProposePriceMKD()
        Dim query As String = mkd.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProposePriceMKD_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProposePriceMKD_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewDetail()

    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged

    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub


End Class