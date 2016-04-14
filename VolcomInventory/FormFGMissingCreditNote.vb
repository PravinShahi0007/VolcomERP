Public Class FormFGMissingCreditNote 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGMissingCreditNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewFGMissingStoreCN()
    End Sub

    Sub viewFGMissingStoreCN()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type =''4'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGMissingCNStore.DataSource = data
        check_menu()
    End Sub

    Private Sub FormFGMissingCreditNote_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGMissingCreditNote_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCFGMissingCN.SelectedTabPageIndex = 0 Then
            'STORE
            If GVFGMissingCNStore.RowCount < 1 Then
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
        ElseIf XTCFGMissingCN.SelectedTabPageIndex = 1 Then

        End If
    End Sub

    Sub noManipulating()
        If XTCFGMissingCN.SelectedTabPageIndex = 0 Then
            Try
                Dim indeks As Integer = GVFGMissingCNStore.FocusedRowHandle
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
        ElseIf XTCFGMissingCN.SelectedTabPageIndex = 1 Then

        End If
    End Sub
End Class