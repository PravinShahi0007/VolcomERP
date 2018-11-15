Public Class FormItemDelReqDet
    Public id As String = "-1"

    Private Sub FormItemDelReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim req As New ClassItemRequest()
        Dim query As String = req.queryMain("rd.id_item_req=" + id + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormItemDelReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class