Public Class FormSalesOrderCat
    Private Sub FormSalesOrderCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewStatus()
    End Sub

    Sub viewStatus()
        Dim query As String = "SELECT stt.id_so_status, stt.so_status FROM tb_lookup_so_status stt ORDER BY stt.id_so_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GridControl1.DataSource = data
        viewStatusAcc()
    End Sub

    Sub viewStatusAcc()
        Dim id_so_status As String = "-1"
        Try
            id_so_status = GridView1.GetFocusedRowCellValue("id_so_status").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT dept.id_departement, dept.departement, acc.id_so_status, IF(ISNULL(acc.id_so_status),'No', 'Yes') AS `is_select`  "
        query += "FROM tb_m_departement dept "
        query += "LEFT JOIN tb_lookup_so_status_acc acc ON dept.id_departement = acc.id_departement AND acc.id_so_status='" + id_so_status + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GridControl2.DataSource = data
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim id_so_status As String = "-1"
        Try
            id_so_status = GridView1.GetFocusedRowCellValue("id_so_status").ToString
        Catch ex As Exception
        End Try
        Dim query_del As String = "DELETE FROM tb_lookup_so_status_acc WHERE id_so_status='" + id_so_status + "' "
        execute_non_query(query_del, True, "", "", "", "")
        Dim query As String = ""
        Dim n As Integer = 0
        For i As Integer = 0 To GridView2.RowCount - 1
            Dim id_departement As String = GridView2.GetRowCellValue(i, "id_departement").ToString
            Dim is_select As String = GridView2.GetRowCellValue(i, "is_select").ToString
            If is_select = "Yes" Then
                If n > 0 Then
                    query += ", "
                End If
                query += "(" + id_so_status + ", " + id_departement + ") "
                n += 1
            End If
        Next

        If n > 0 Then
            execute_non_query("INSERT INTO tb_lookup_so_status_acc(id_so_status, id_departement) VALUES " + query, True, "", "", "", "")
        End If
        viewStatusAcc()
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        viewStatusAcc()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        Dim cek As String = CheckEditSelAll.EditValue.ToString
        For i As Integer = 0 To ((GridView2.RowCount - 1) - GetGroupRowCount(GridView2))
            If cek Then
                GridView2.SetRowCellValue(i, "is_select", "Yes")
            Else
                GridView2.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub
End Class