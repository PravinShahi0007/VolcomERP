Public Class FormMatStockOpnameResultPrice 
    Public id_mat_so As String = "-1"
    Private Sub FormMatStockOpnameResultPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_inventory_mat()
        'ExpandAllRows(GVMatList)
        WindowState = FormWindowState.Maximized
    End Sub
    Sub view_inventory_mat()
        Try
            ' Dim query As String
            '
            'query = "CALL view_stock_mat_so_result('" & id_mat_so & "')"
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatList.DataSource = CreateData()
            '
        Catch ex As Exception
            errorConnection()
        End Try

    End Sub
    Private Sub GVMatList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Function CreateData() As DataTable
        Dim query As String
        '
        query = "CALL view_stock_mat_so_result('" & id_mat_so & "')"
        Dim dtm As DataTable = execute_query(query, -1, True, "", "", "", "")

        query = "SELECT st_m.id_mat_det,st_m.id_mat_det_price,mat_det_price_name,mat_det_price,mat_det_price_date,c.id_currency,c.currency "
        query += " FROM tb_mat_so_sum so_sum"
        query += " INNER JOIN tb_storage_mat st_m ON so_sum.id_mat_det=st_m.id_mat_det"
        query += " INNER JOIN tb_m_mat_det_price m_d_p ON st_m.id_mat_det_price=m_d_p.id_mat_det_price "
        query += " INNER JOIN tb_lookup_currency c ON c.id_currency=m_d_p.id_currency  "
        query += " WHERE id_mat_so='" & id_mat_so & "'"
        query += " GROUP BY st_m.id_mat_det,st_m.id_mat_det_price"
        Dim dtd As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim ds As New DataSet()
        ds.Tables.AddRange(New DataTable() {dtm, dtd})
        ds.Relations.Add("Price List", dtm.Columns("id_mat_det"), dtd.Columns("id_mat_det"))
        Return dtm
    End Function

    Private Sub FormMatStockOpnameResultPrice_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub
    Public Sub HideAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, False)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub
    Private Sub BExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExpand.Click
        ExpandAllRows(GVMatList)
    End Sub

    Private Sub BHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHide.Click
        HideAllRows(GVMatList)
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        print(GCMatList, "List Price")
    End Sub
End Class