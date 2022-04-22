Public Class FormRoyaltyRate
    Public is_test As String = "-1"
    Public is_load_new As Boolean = False

    Private Sub FormRoyaltyRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassRoyaltyRate()
        Dim query As String = r.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRoyaltyRate_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormRoyaltyRate_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class