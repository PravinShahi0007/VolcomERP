Public Class FormFGMissing 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGMissing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewFGMissing()
        viewFGMissingWH()
    End Sub

    Sub viewFGMissing()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type =''3'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGMissing.DataSource = data
        check_menu()
    End Sub

    Sub viewFGMissingWH()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type =''7'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMissingWH.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCFGMissing.SelectedTabPageIndex = 0 Then
            If GVFGMissing.RowCount < 1 Then
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
        ElseIf XTCFGMissing.SelectedTabPageIndex = 1 Then

        End If
    End Sub

    Private Sub FormFGMissing_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGMissing_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        If XTCFGMissing.SelectedTabPageIndex = 0 Then
            Try
                Dim indeks As Integer = GVFGMissing.FocusedRowHandle
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
        ElseIf XTCFGMissing.SelectedTabPageIndex = 1 Then
            Try
                Dim indeks As Integer = GVMissingWH.FocusedRowHandle
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
        End If
    End Sub

    Private Sub GVSOStore_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGMissing.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub XTCFGMissing_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCFGMissing.SelectedPageChanged
        noManipulating()
    End Sub
End Class