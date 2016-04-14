Public Class FormFGDistSchemeDet 

    Private Sub FormFGDistSchemeDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String = ""
        query += "SELECT 'Barang A S' AS  description, 0 AS `15`,20 AS `16`, 10 AS `23` "
        query += "UNION "
        query += "SELECT 'Barang A M' AS  description, 10 AS `15`,40 AS `16`, 15 AS `23` "
        query += "UNION "
        query += "SELECT 'Barang A L' AS  description, 20 AS `15`,0 AS `16`, 10 AS `23` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataGridView1.DataSource = data
        GCDistScheme.DataSource = data
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        MsgBox(GVDistScheme.VisibleColumns.Count.ToString)
        For i As Integer = 0 To GVDistScheme.RowCount - 1
            For j As Integer = 0 To GVDistScheme.VisibleColumns.Count - 1
                Dim a As String = GVDistScheme.Columns(j).FieldName.ToString
                Dim b As String = GVDistScheme.GetRowCellValue(i, "description").ToString
                Dim c As String = GVDistScheme.GetRowCellValue(i, GVDistScheme.Columns(j).FieldName.ToString)
                MsgBox(a + "-" + b + "-" + c)
            Next
        Next
    End Sub
End Class