Public Class FormMarkAssign

    Private Sub FormMarkAssign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_asg()
    End Sub

    Sub view_asg()
        Dim query As String = "SELECT a.id_mark_asg,a.id_report_status,a.report_mark_type,b.report_mark_type_name,c.report_status "
        query += "FROM tb_mark_asg a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON a.report_mark_type=b.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status=c.id_report_status "
        query += "ORDER BY a.report_mark_type,a.id_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMarkAssign.DataSource = data
        GVMarkAssign.ExpandAllGroups()
    End Sub

    Private Sub FormMarkAssign_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMarkAssign_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVMarkAssign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMarkAssign.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub GVMarkAssign_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMarkAssign.CustomColumnDisplayText
        'If e.Column.FieldName = "report_mark_type" Then
        'Dim rowhandle As Integer = e.ListSourceRowIndex
        'If GVMarkAssign.IsGroupRow(rowhandle) Then
        '     rowhandle = GVMarkAssign.GetDataRowHandleByGroupRowHandle(rowhandle)
        '      e.DisplayText = GVMarkAssign.GetRowCellDisplayText(rowhandle, "report_mark_type_name")
        '   End If
        'End If
        If e.Column.FieldName = "id_report_status" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMarkAssign.IsGroupRow(rowhandle) Then
                rowhandle = GVMarkAssign.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMarkAssign.GetRowCellDisplayText(rowhandle, "report_status")
            End If
        End If
    End Sub

End Class