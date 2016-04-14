Public Class FormSampleOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSampleOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleOrder()
    End Sub

    Sub viewSampleOrder()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleOrder.DataSource = data
        refreshDetail()
        check_menu()
    End Sub

    Sub viewSampleOrderProgress(ByVal id_sample_order_param As String)
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryDetailLimit(id_sample_order_param, "0")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetailSO.DataSource = data
    End Sub

    Private Sub FormSampleOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSampleOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSampleOrder_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVSampleOrder.FocusedRowHandle
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
        If GVSampleOrder.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            noManipulating()
        End If
    End Sub

    Private Sub GVSampleOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleOrder.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noManipulating()

        refreshDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetailSO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetailSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub refreshDetail()
        Dim id_sample_order_param As String = "-1"
        Try
            id_sample_order_param = GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
        Catch ex As Exception
        End Try
        viewSampleOrderProgress(id_sample_order_param)
    End Sub
End Class