Public Class ReportOlStoreRetCust
    Public Shared id_ret As String
    Public id_pre As String
    Public Shared dt As DataTable
    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("245", id_ret, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("245", id_ret, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class