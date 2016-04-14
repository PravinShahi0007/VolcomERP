Public Class FormSampleDelRec 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleDelRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleDel()
        viewSampleDelRec()
    End Sub

    Private Sub FormSampleDelRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Cursor = Cursors.WaitCursor
        FormMain.show_rb(Name)
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSampleDelRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSampleDelRec_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Cursor = Cursors.WaitCursor
        Dispose()
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If XTCSampleDelRec.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSampleDelRec.RowCount < 1 Then
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
        ElseIf XTCSampleDelRec.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVSampleDel.RowCount < 1 Then
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
            If XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVSampleDelRec.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVSampleDel.FocusedRowHandle
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

    Private Sub GVSampleDel_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDel.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        viewSampleDelDet()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSampleDelRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDelRec.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCSampleDelRec_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSampleDelRec.SelectedPageChanged
        Cursor = Cursors.WaitCursor
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSampleDelList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSampleDelList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewSampleDelRec()
        Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelRec.DataSource = data
        check_menu()
    End Sub

    Sub viewSampleDel()
        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryMain
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDel.DataSource = data
        GVSampleDel.ActiveFilterString = "[total_qty_delivered] > [total_qty_received] "
        check_menu()
    End Sub

    Sub viewSampleDelDet()
        Dim id_sample_del As String = "-1"
        Try
            id_sample_del = GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
        Catch ex As Exception
        End Try

        Dim query_c As ClassSampleDel = New ClassSampleDel()
        Dim query As String = query_c.queryDetail(id_sample_del)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelList.DataSource = data
        check_menu()
    End Sub

End Class