Public Class FormPopUpFGSalesOrderReff
    Public id_pop_up As String = "-1"
    Private Sub GVSOReff_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSOReff.FocusedRowChanged
        GCDesign.DataSource = Nothing
        check_but()
    End Sub

    Private Sub GVSOReff_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSOReff.ColumnFilterChanged
        GCDesign.DataSource = Nothing
        check_but()
    End Sub

    Sub check_but()
        If GVSOReff.FocusedRowHandle >= 0 And GVSOReff.RowCount > 0 Then
            BtnChoose.Enabled = True
            BtnViewDet.Enabled = True
        Else
            BtnChoose.Enabled = False
            BtnViewDet.Enabled = False
        End If
    End Sub

    Private Sub FormPopUpFGSalesOrderReff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query_c As ClassFGSalesOrderReff = New ClassFGSalesOrderReff()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOReff.DataSource = data
        check_but()
    End Sub


    Private Sub BtnViewDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewDet.Click
        Cursor = Cursors.WaitCursor
        Dim v_ As ClassDesign = New ClassDesign()
        Dim id_season_par As String = "-1"
        Try
            id_season_par = GVSOReff.GetFocusedRowCellValue("id_season").ToString
        Catch ex As Exception
        End Try
        Dim id_fg_so_reff As String = "-1"
        Try
            id_fg_so_reff = GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString
        Catch ex As Exception
        End Try
        v_.loadDS(id_season_par, "3", GCDesign, GVDesign, id_fg_so_reff, "2")
        GVDesign.Columns("SELECT").Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormFGSalesOrderReffDet.id_fg_so_reff_fk = GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString
            FormFGSalesOrderReffDet.ButtonEdit1.Text = GVSOReff.GetFocusedRowCellValue("fg_so_reff_number").ToString
            Close()
        Else
            stopCustom("There is no features which available for this time.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class