Public Class FormSampleOrdered 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleOrdered_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleOrder()
    End Sub

    Sub viewSampleOrder()
        Dim query_c As ClassSampleOrdered = New ClassSampleOrdered()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleOrder.DataSource = data
        check_menu()
    End Sub

    Private Sub FormSampleOrdered_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSampleOrdered_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVSampleOrder.RowCount < 1 Then
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
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            indeks = GVSampleOrder.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVSampleOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSampleOrder.DoubleClick
        If GVSampleOrder.RowCount > 0 And GVSampleOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub
End Class