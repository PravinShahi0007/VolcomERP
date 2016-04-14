Public Class FormFGWHAlloc
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGWHAlloc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewFGWHAlloc()
    End Sub

    Sub viewFGWHAlloc()
        Dim query_c As ClassFGWHAlloc = New ClassFGWHAlloc()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGWHAlloc.DataSource = data
        check_menu()
    End Sub

    Private Sub FormFGWHAlloc_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVFGWHAlloc.FocusedRowHandle
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
        Catch ex As Exception
        End Try
    End Sub

    Sub check_menu()
        If GVFGWHAlloc.RowCount < 1 Then
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

    Private Sub GVFGWHAlloc_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGWHAlloc.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFGWHAlloc_DoubleClick(sender As Object, e As EventArgs) Handles GVFGWHAlloc.DoubleClick
        If GVFGWHAlloc.RowCount > 0 And GVFGWHAlloc.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class