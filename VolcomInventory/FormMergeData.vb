Public Class FormMergeData 

    Private Sub FormMergeData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'read_database_configuration()
        'check_connection(True, "", "", "", "")

        'Dim query As String = "SELECT * FROM tb_prod_order_det a WHERE a.id_prod_order = '11' "
        ' Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'Dim data2 As DataTable = execute_query(query, -1, True, "", "", "", "")
        'data.Merge(data2)
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        dt.Columns(0).AutoIncrement = True
        For i As Integer = 0 To 100
            Dim R As DataRow = dt.NewRow
            R("Name") = "Catur" + i.ToString
            dt.Rows.Add(R)
        Next
        GridControl1.DataSource = dt
    End Sub
End Class