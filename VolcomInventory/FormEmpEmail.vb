Public Class FormEmpEmail
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "0"

    Private Sub FormEmpEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee("-1")
    End Sub

    Sub viewEmployee(ByVal cond_param As String)
        Dim query As String = "CALL view_employee('" + cond_param + "', '2')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmail.DataSource = data
    End Sub

    Private Sub FormEmpEmail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormEmpEmail_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVEmail.RowCount < 1 Then
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
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            indeks = GVEmail.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "0"
            bedit_active = "1"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVEmail_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVEmail.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVEmail_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVEmail.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVEmail_DoubleClick(sender As Object, e As EventArgs) Handles GVEmail.DoubleClick
        If GVEmail.RowCount > 0 And GVEmail.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class