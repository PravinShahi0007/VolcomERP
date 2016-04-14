Public Class FormFGBorrowQCReq
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGBorrowQCRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewBorrowReq()
    End Sub

    Private Sub FormFGBorrowQCRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGBorrowQCRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewBorrowReq()
        Dim query_c As ClassFGBorrowQCReq = New ClassFGBorrowQCReq()
        Dim query As String = query_c.queryMainReq("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBorrowReq.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If GVBorrowReq.RowCount < 1 Then
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
            Dim indeks As Integer = GVBorrowReq.FocusedRowHandle
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

    Private Sub GVBorrowReq_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBorrowReq.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVBorrowReq_DoubleClick(sender As Object, e As EventArgs) Handles GVBorrowReq.DoubleClick
        If GVBorrowReq.RowCount > 0 And GVBorrowReq.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class