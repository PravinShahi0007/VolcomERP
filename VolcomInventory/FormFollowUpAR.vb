Public Class FormFollowUpAR
    Private Sub FormFollowUpAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_group_store()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEStoreGroup.EditValue.ToString <> "0" Then
            cond = "AND f.id_comp_group='" + SLEStoreGroup.EditValue.ToString + "'"
        End If
        Dim f As New ClassFollowUpAR()
        Dim query As String = f.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewActive()

    End Sub

    Private Sub BView_Click_1(sender As Object, e As EventArgs) Handles BView.Click
        If XTCAR.SelectedTabPageIndex = 0 Then
            viewList()
        ElseIf XTCAR.SelectedTabPageIndex = 1 Then
            viewActive()
        End If
    End Sub

    Private Sub FormFollowUpAR_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    Private Sub XTCAR_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCAR.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub FormFollowUpAR_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormMain.but_edit()
    End Sub
End Class