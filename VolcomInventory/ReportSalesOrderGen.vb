Public Class ReportSalesOrderGen
    Public Shared dt As New DataTable
    Public Shared id_sales_order_gen As String = "-1"
    Public Shared id_pre As String = "-1"

    Private Sub ReportSamplePLToWH_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCNewPrepare.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("88", id_sales_order_gen, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("88", id_sales_order_gen, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class