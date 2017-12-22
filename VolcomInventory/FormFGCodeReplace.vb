Public Class FormFGCodeReplace
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public form_type As String = "1"

    Private Sub FormCodeReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCodeReplaceStore()
        viewCodeReplaceWH()
    End Sub

    Private Sub FormCodeReplace_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCodeReplace_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewCodeReplaceStore()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = ""
        If form_type = "2" Or form_type = "3" Then
            query = query_c.queryMainStore("AND rep.id_report_status=6 ", "2")
        Else
            query = query_c.queryMainStore("-1", "2")
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceStore.DataSource = data
        check_menu()
    End Sub

    Sub viewCodeReplaceWH()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryMainWH("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceWH.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVFGCodeReplaceStore.RowCount < 1 Then
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
        ElseIf XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
            'based on receive
            If GVFGCodeReplaceWH.RowCount < 1 Then
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
        End If
    End Sub

    Sub noManipulating()
        Try
            If XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVFGCodeReplaceStore.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVFGCodeReplaceWH.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCFGCodeReplace_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCFGCodeReplace.SelectedPageChanged
        check_menu()
    End Sub
End Class