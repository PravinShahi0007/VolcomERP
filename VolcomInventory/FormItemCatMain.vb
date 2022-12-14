Public Class FormItemCatMain
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemCatPropose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCCat.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCCat.SelectedTabPageIndex = 1 Then
            If GVData.RowCount < 1 Then
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
            Dim indeks As Integer = GVData.FocusedRowHandle
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

    Private Sub FormItemCatPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_cat()
        view_propose()
    End Sub

    Sub view_cat()
        Cursor = Cursors.WaitCursor
        Dim qm As String = "SELECT cm.id_item_cat_main,cm.item_cat_main,et.expense_type,IF(cm.is_fixed_asset=1,'yes','no') AS is_fixed_asset
FROM tb_item_cat_main cm
INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=cm.id_expense_type"
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        GCItemCat.DataSource = dm
        Cursor = Cursors.Default
    End Sub

    Sub view_propose()
        Cursor = Cursors.WaitCursor
        Dim qm As String = "SELECT ip.id_item_cat_main_pps, ip.number, ip.created_date, ip.note, ip.id_report_status, stt.report_status, ip.is_confirm
        FROM tb_item_cat_main_pps ip
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ip.id_report_status
        WHERE ip.id_item_cat_main_pps>0 ORDER BY ip.id_item_cat_main_pps"
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        GCData.DataSource = dm
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemCatPropose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCCat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCat.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class