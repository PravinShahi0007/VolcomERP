Public Class FormMasterComputer
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterComputer_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormMasterComputer_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVComputer.RowCount < 1 Then
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
        Try
            Dim indeks As Integer = GVComputer.FocusedRowHandle
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

    Private Sub FormMasterComputer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewComputer()
    End Sub

    Sub viewComputer()
        Dim query As String = "SELECT * FROM tb_m_computer ORDER BY id_computer ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComputer.DataSource = data
        check_menu()
    End Sub

    Private Sub GVComputer_DoubleClick(sender As Object, e As EventArgs) Handles GVComputer.DoubleClick
        If GVComputer.RowCount > 0 And GVComputer.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class