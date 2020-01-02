Public Class FormFollowUpAR
    Private Sub FormFollowUpAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim f As New ClassFollowUpAR()
        Dim query As String = f.queryMain("AND (f.follow_up_date>='" + date_from_selected + "' AND f.follow_up_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs)
        viewList()
    End Sub

    Private Sub BView_Click_1(sender As Object, e As EventArgs) Handles BView.Click

    End Sub
End Class