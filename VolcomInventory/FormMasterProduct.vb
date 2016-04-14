Public Class FormMasterProduct
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bdupe_active As String = "1"

    Private Sub FormMasterProduct_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
        button_main_ext("3", bdupe_active)
    End Sub

    Private Sub FormMasterProduct_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_design()
    End Sub

    Sub view_design()
        Try
            'Dim query As String = "SELECT a.id_design,a.design_display_name,a.design_code,a.design_name,a.lifetime,b.id_uom,c.season,c.id_season,d.sample_name as orign FROM tb_m_design a "
            'query += "INNER JOIN tb_m_uom b ON a.id_uom = b.id_uom "
            'query += "INNER JOIN tb_season c ON c.id_season = a.id_season "
            'query += "LEFT JOIN tb_m_sample d ON a.id_sample = d.id_sample "
            'query += "ORDER BY c.date_season_start DESC , a.design_code ASC"
            Dim query As String = "CALL view_all_design()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            check_menu()
            If data.Rows.Count > 0 Then
                view_product(GVDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                'XTPProduct.PageVisible = True
                LabelPrintedName.Text = GVDesign.GetFocusedRowCellDisplayText("design_name").ToString
                GVDesign.FocusedRowHandle = 0
            Else
                'XTPProduct.PageVisible = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub view_product(ByVal id_design As String)
        Try
            Dim query As String = "CALL view_product_master('" & id_design & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            check_menu()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVDesign_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDesign.RowClick
        'view_product(GVDesign.GetFocusedRowCellDisplayText("id_design").ToString)
        'LabelPrintedName.Text = GVDesign.GetFocusedRowCellDisplayText("design_name").ToString
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVDesign.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                bdupe_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                bdupe_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVDesign_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDesign.CustomColumnDisplayText
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVDesign.IsGroupRow(rowhandle) Then
                rowhandle = GVDesign.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVDesign.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub XTCProduct_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCProduct.SelectedPageChanged
        check_menu()
    End Sub
    Sub check_menu()
        If XTCProduct.SelectedTabPageIndex = 0 Then
            'design
            If GVDesign.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
                bdupe_active = "0"
                button_main_ext("3", bdupe_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
                bdupe_active = "1"
                button_main_ext("3", bdupe_active)
            End If
        Else
            'product
            If GVProduct.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
                bdupe_active = "0"
                button_main_ext("3", bdupe_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
                bdupe_active = "1"
                button_main_ext("3", bdupe_active)
            End If
        End If
    End Sub

    Private Sub GVDesign_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDesign.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub
End Class