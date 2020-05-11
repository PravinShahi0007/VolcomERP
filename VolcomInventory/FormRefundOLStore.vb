Public Class FormRefundOLStore
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormRefundOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim pre As New ClassRefundOLStore()
        Dim query As String = pre.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewOrderList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_comp_group, r.sales_order_ol_shop_number
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
        WHERE l.id_ol_store_ret_stt=2 AND r.id_comp_group=" + SLECompGroup.EditValue.ToString + "
        GROUP BY r.sales_order_ol_shop_number, r.id_comp_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrderList.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRefundOLStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormRefundOLStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCData.SelectedTabPageIndex = 0 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            If GVOrderList.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        If XTCData.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVData.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVOrderList.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        GCOrderList.DataSource = Nothing
    End Sub

    Private Sub BtnViewOrder_Click(sender As Object, e As EventArgs) Handles BtnViewOrder.Click
        viewOrderList()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        check_menu()
    End Sub
End Class