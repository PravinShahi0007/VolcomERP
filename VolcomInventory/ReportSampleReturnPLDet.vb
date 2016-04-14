Public Class ReportSampleReturnPLDet
    Public Shared dt As New DataTable
    Public Shared id_sample_pl As String = "-1"
    Public Shared id_pre As String = "-1"

    Private Sub ReportSamplePLToWH_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("89", id_sample_pl, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("89", id_sample_pl, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class