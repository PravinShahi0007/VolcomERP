Public Class ReportFGWoff
    Public Shared id_fg_woff As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportFGWoff_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
        load_mark_horz("69", id_fg_woff, "2", "1", XrTable1)
    End Sub
End Class