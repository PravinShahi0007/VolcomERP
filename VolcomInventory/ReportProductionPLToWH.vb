Public Class ReportProductionPLToWH
    Public Shared id_pl_prod_order As String = "-1"
    Public Shared dt As DataTable

    Private Sub GVRetDetail_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportProductionPLToWH_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRetDetail.DataSource = dt
        Dim acc_arr As String() = Split(LabelTo.Text.ToString, "-")
        Dim acc As String = acc_arr(1)
        load_mark_horz("33", id_pl_prod_order, acc, "1", XrTable1)
    End Sub


End Class