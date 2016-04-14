Public Class ReportProductionPLToWHRec
    Public Shared id_pl_prod_order_rec As String = "-1"
    Public Shared id_pre As String = "-1"

    Public Shared dt As DataTable
    Private Sub GVRetDetail_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportProductionPLToWH_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRetDetail.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("37", id_pl_prod_order_rec, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("37", id_pl_prod_order_rec, "2", "2", XrTable1)
        End If

    End Sub
End Class