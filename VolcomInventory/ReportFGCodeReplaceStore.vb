Public Class ReportFGCodeReplaceStore
    Public Shared dt As DataTable
    Public Shared id_report As String = "-1"

    Private Sub ReportFGCodeReplaceStore_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
        'mark
        load_mark_horz("65", id_report, "2", "1", XrTable1)
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class