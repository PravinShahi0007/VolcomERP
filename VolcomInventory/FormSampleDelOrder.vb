Public Class FormSampleDelOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleDelOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleDelOrder()
        viewSampleOrder()
    End Sub

    Private Sub FormSampleDelOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Cursor = Cursors.WaitCursor
        FormMain.show_rb(Name)
        check_menu()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormSampleDelOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub


    Private Sub FormSampleDelOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Cursor = Cursors.WaitCursor
        Dispose()
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSampleDelOrder.RowCount < 1 Then
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
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVSampleOrder.RowCount < 1 Then
                'hide all
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
        Try
            If XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVSampleDelOrder.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVSampleOrder.FocusedRowHandle
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
        Catch ex As Exception
        End Try
    End Sub


    Private Sub GVSampleOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleOrder.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        refreshDetailSampleOrder()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVSampleDelOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDelOrder.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub


    Private Sub XTCSampleDelOrder_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSampleDelOrder.SelectedPageChanged
        Cursor = Cursors.WaitCursor
        check_menu()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVListSampleOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewSampleOrder()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryMain("AND so.id_report_status =''3'' OR so.id_report_status =''4'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleOrder.DataSource = data
        refreshDetailSampleOrder()
        check_menu()
    End Sub

    Sub viewSampleOrderDetail(ByVal id_sample_order_param As String)
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryDetailLimit(id_sample_order_param, "0")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSampleOrder.DataSource = data
    End Sub

    Sub refreshDetailSampleOrder()
        Dim id_sample_order_param As String = "-1"
        Try
            id_sample_order_param = GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
        Catch ex As Exception
        End Try
        viewSampleOrderDetail(id_sample_order_param)
    End Sub

    Sub viewSampleDelOrder()
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelOrder.DataSource = data
        check_menu()
    End Sub
End Class