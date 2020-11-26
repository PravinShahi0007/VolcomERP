Public Class FormOLStoreOOS
    Private Sub FormOLStoreOOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
    End Sub

    Private Sub FormOLStoreOOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim ooslist As New ClassOLStore()
        Dim id_type As String = LEType.EditValue.ToString
        Dim cond As String = ""
        If id_type <> "1" Then
            cond = "AND status='" + LEType.Text + "'"
        Else
            cond = ""
        End If
        Dim data As DataTable = ooslist.viewListOOS(cond)
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 1 AS `id_type`,'all' AS `type`
        UNION ALL
        SELECT 2 AS `id_type`,'waiting for restock' AS `type`
        UNION ALL 
        SELECT 3 AS `id_type`,'waiting for confirmation' AS `type`
        UNION ALL
        SELECT 4 AS `id_type`,'closed' AS `type` "
        viewLookupQuery(LEType, query, 0, "type", "id_type")
        Cursor = Cursors.Default
    End Sub
End Class