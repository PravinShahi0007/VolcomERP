Public Class ReportSampleStockOpname
    Public Shared dt As DataTable
    Public Shared id_sample_so As String
    Private Sub ReportSampleDel_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewDetail()
        'mark
        load_mark_horz("64", id_sample_so, "2", "1", XrTable1)
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewDetail()
        GridControl1.DataSource = dt
    End Sub
End Class