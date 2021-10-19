Public Class FormOLReturnRefuse
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim comp_not_in As String = ""

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT 0 AS id_comp_group, 'ALL' AS comp_group, 'ALL GROUP' AS description
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2 
        WHERE c.id_comp NOT IN (" + comp_not_in + ") AND cg.is_marketplace=1
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub


    Private Sub FormOLReturnRefuse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim tgl_sekarang As DateTime = getTimeDB()
        DEFrom.EditValue = tgl_sekarang
        DEUntil.EditValue = tgl_sekarang

        'get not in
        comp_not_in = execute_query("SELECT GROUP_CONCAT(DISTINCT o.id_store) FROM tb_m_comp_volcom_ol o", 0, True, "", "", "", "")

        viewCompGroup()
    End Sub

    Private Sub FormOLReturnRefuse_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query_c As ClassOLReturnRefuse = New ClassOLReturnRefuse()
        Dim query As String = query_c.queryMain("AND (DATE(r.created_date)>='" + date_from_selected + "' AND DATE(r.created_date)<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub check_menu()
        If XTCData.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
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
            Dim indeks As Integer = 0
            Try
                indeks = GVData.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVOrder.FocusedRowHandle
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
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormOLReturnRefuse_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormOLReturnRefuse_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub CEFindOrderNo_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindOrderNo.EditValueChanged
        resetViewOrder()
        TxtOrderNumber.Text = ""
        If CEFindOrderNo.EditValue = True Then
            TxtOrderNumber.Enabled = True
        Else
            TxtOrderNumber.Enabled = False
        End If
    End Sub

    Private Sub BtnViewOrderList_Click(sender As Object, e As EventArgs) Handles BtnViewOrderList.Click
        viewOrderList()
    End Sub

    Sub viewOrderList()
        Cursor = Cursors.WaitCursor
        'group
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString
        Dim cond_group As String = ""
        If id_comp_group <> "0" Then
            cond_group = "AND cg.id_comp_group='" + id_comp_group + "' "
        End If

        'order number
        Dim cond_orderno As String = ""
        Dim order_no As String = addSlashes(TxtOrderNumber.Text)
        If order_no <> "" Then
            cond_orderno = "AND so.sales_order_ol_shop_number='" + order_no + "' "
        End If

        'check order no
        If CEFindOrderNo.EditValue = True And order_no = "" Then
            stopCustom("Please input order number")
            Cursor = Cursors.Default
            Exit Sub
        End If

        'view
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`,  c.comp_number, c.comp_name,
        so.id_sales_order, so.sales_order_number, so.sales_order_date, 
        so.sales_order_ol_shop_number, so.sales_order_ol_shop_date, so.customer_name, so.id_store_contact_to
        FROM tb_pl_sales_order_del d
        INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        WHERE d.id_report_status=6 AND c.id_commerce_type=2 AND c.id_comp NOT IN(" + comp_not_in + ") AND cg.is_marketplace=1
        " + cond_group + "
        " + cond_orderno + "
        ORDER BY cg.id_comp_group ASC,so.id_sales_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrder.DataSource = data
        GVOrder.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub resetViewOrder()
        GCOrder.DataSource = Nothing
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        resetViewOrder()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormMain.but_edit()
    End Sub
End Class