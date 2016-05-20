Public Class FormFGDesignList
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "0"
    Dim bdupe_active As String = "1"
    Public id_pop_up As String = "-1"

    Private Sub FormFGDesignList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewType()
    End Sub

    'view season
    Sub viewSeason(ByVal type As String)
        Dim query As String = ""
        'query += "Select (-1) As id_season, ('All Season') AS season,  (-1) AS id_range, (0) AS `range` "
        'query += "UNION ALL "
        query += "Select a.id_season, a.season, b.id_range, b.`range`  "
        query += "From tb_season a "
        query += "INNER Join tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.is_md='" + type + "' "
        query += "ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_line_list_type a ORDER BY a.id_line_list_type ASC "
        viewSearchLookupQuery(SLEType, query, "id_line_list_type", "line_list_type", "id_line_list_type")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Dim id_ss As String = SLESeason.EditValue.ToString
        Dim cond As String = ""
        If id_ss = "-1" Then
            cond = "-1"
        Else
            cond = "And f1.id_season=" + id_ss + " "
        End If
        Dim query As String = "CALL view_all_design_param('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data

        If id_pop_up = "1" Then
            GVDesign.ActiveFilterString = "[status_sample]='Not Found' "
        End If

        check_menu()
    End Sub

    Private Sub FormFGDesignList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGDesignList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVDesign.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            bdupe_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Else
            noManipulating()
        End If
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
                'show all
                'If id_pop_up = "1" Then 'design dept - input sample for line list
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                bdupe_active = "1"
                'End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            button_main_ext("3", bdupe_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVDesign_DoubleClick(sender As Object, e As EventArgs) Handles GVDesign.DoubleClick
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        Dim type_par As String = "-1"
        Try
            type_par = SLEType.EditValue.ToString
        Catch ex As Exception
        End Try
        viewSeason(type_par)
    End Sub
End Class