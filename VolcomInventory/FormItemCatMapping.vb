Public Class FormItemCatMapping
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemCatMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewCat()
        viewPropose()
    End Sub

    Sub viewMapping()
        Cursor = Cursors.WaitCursor
        'dept
        Dim dept As String = ""
        Try
            dept = "AND m.id_departement='" + LEDeptSum.EditValue.ToString + "' "
        Catch ex As Exception
            dept = ""
        End Try

        'cat
        Dim cat As String = ""
        Try
            cat = "AND m.id_item_cat='" + LECat.EditValue.ToString + "' "
        Catch ex As Exception
            cat = ""
        End Try

        Dim map As New ClassItemCat()
        Dim query As String = map.queryMapping("AND 1=1 " + dept + cat, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaping.DataSource = data
        GVMapping.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewPropose()

    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemCatMapping_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCMapping.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCMapping.SelectedTabPageIndex = 1 Then
            If GVPropose.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVPropose.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub FormItemCatMapping_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCMapping_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMapping.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVPropose_DoubleClick(sender As Object, e As EventArgs) Handles GVPropose.DoubleClick
        If GVPropose.RowCount > 0 And GVPropose.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewMapping()
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        GCMaping.DataSource = Nothing
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        GCMaping.DataSource = Nothing
    End Sub
End Class