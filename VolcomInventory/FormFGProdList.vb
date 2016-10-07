Public Class FormFGProdList 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGProdList_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
        'If GVProdList.RowCount < 1 Then
        '    'hide all except new
        '    bnew_active = "1"
        '    bedit_active = "0"
        '    bdel_active = "0"
        '    checkFormAccess(Name)
        '    button_main(bnew_active, bedit_active, bdel_active)
        'Else
        '    'show all
        '    bnew_active = "1"
        '    bedit_active = "1"
        '    bdel_active = "1"
        '    noManipulating()
        'End If
    End Sub

    Sub noManipulating()
        'Dim indeks As Integer = -1
        'Try
        '    indeks = GVProdList.FocusedRowHandle
        'Catch ex As Exception
        'End Try
        'If indeks < 0 Then
        '    bnew_active = "1"
        '    bedit_active = "0"
        '    bdel_active = "0"
        'Else
        '    bnew_active = "1"
        '    bedit_active = "1"
        '    bdel_active = "1"
        'End If
        'checkFormAccess(Name)
        'button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVProdList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdList.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdList.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGProdList_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFGProdList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGProdList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewProd()
        Cursor = Cursors.Default
    End Sub

    Sub viewProd()
        Dim id_season_par As String = "-1"
        Try
            id_season_par = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_product_per_season('" + id_season_par + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdList.DataSource = data
        GVProdList.ExpandAllGroups()
    End Sub

    Private Sub GVProdList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdList.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVProdList.RowCount > 0 Then
            Dim id_dsg As String = "-1"
            Try
                id_dsg = GVProdList.GetFocusedRowCellValue("id_design").ToString
            Catch ex As Exception
            End Try

            If id_dsg <> "-1" And id_dsg <> "" Then
                Cursor = Cursors.WaitCursor
                FormMasterProductDet.form_name = Name
                FormMasterProductDet.id_product = GVProdList.GetFocusedRowCellValue("id_product").ToString
                FormMasterProductDet.id_design = id_dsg
                FormMasterProductDet.ShowDialog()
                Cursor = Cursors.Default
            Else
                'stopCustom("Design not found.")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BUPCImport_Click(sender As Object, e As EventArgs) Handles BUPCImport.Click
        FormImportExcel.id_pop_up = "28"
        FormImportExcel.ShowDialog()
    End Sub
End Class