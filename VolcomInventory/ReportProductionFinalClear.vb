Public Class ReportProductionFinalClear
    Public Shared id_prod_fc As String = "-1"
    Public Shared id_comp_from As String = "-1"
    Public Shared id_comp_to As String = "-1"
    Public Shared dt As DataTable
    Public Shared is_pre_print As String = "-1"

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportProductionFinalClear_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        If is_pre_print = "1" Then
            pre_load_mark_horz("105", id_prod_fc, "2", "2", XrTable1)
        Else
            load_mark_horz("105", id_prod_fc, "2", "1", XrTable1)
        End If
    End Sub

End Class