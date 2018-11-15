Public Class FormItemDelReqDet
    Public id As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormItemDelReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim req As New ClassItemRequest()
        Dim query As String = req.queryDetailInfo("AND rd.id_item_req=" + id + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        noEdit()
    End Sub

    Private Sub FormItemDelReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub noEdit()
        If GVData.FocusedRowHandle >= 0 Then
            Dim id_prepare_status As String = GVData.GetFocusedRowCellValue("id_prepare_status").ToString
            If id_prepare_status = "2" Then
                GVData.Columns("is_select").OptionsColumn.AllowEdit = False
            Else
                GVData.Columns("is_select").OptionsColumn.AllowEdit = True
            End If
        End If
    End Sub

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVData_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVData.ColumnFilterChanged
        noEdit()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVData.RowCount > 0 Then
            Dim cek As String = CESelectAll.EditValue.ToString
            For i As Integer = ((GVData.RowCount - 1) - GetGroupRowCount(GVData)) To 0 Step -1
                Dim id_prepare_status As String = GVData.GetRowCellValue(i, "id_prepare_status").ToString
                If cek And id_prepare_status = "1" Then
                    GVData.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVData.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnCloseRequest_Click(sender As Object, e As EventArgs) Handles BtnCloseRequest.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then

        Else
            warningCustom("No item selected")
            makeSafeGV(GVData)
        End If
        Cursor = Cursors.Default
    End Sub
End Class