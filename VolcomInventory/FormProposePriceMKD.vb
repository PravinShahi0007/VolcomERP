Public Class FormProposePriceMKD
    Public id_mkd As String = "-1"
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
        If XTCData.SelectedTabPageIndex = 0 Then
            XTPDetail.PageEnabled = False
        Else
            XTPDetail.PageEnabled = True
        End If
    End Sub
End Class