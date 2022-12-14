Public Class ReportFGRepairDet
    Public Shared id_pre As String = "-1"
    Public Shared id_fg_repair As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable

    Private Sub GVScan_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScan.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TopMargin_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles TopMargin.BeforePrint

    End Sub

    Private Sub ReportFGRepairDet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCScan.DataSource = dt
        If id_type = "-1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("91", id_fg_repair, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("91", id_fg_repair, "2", "2", XrTable1)
            End If
        ElseIf id_type = "1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("91", id_fg_repair, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("91", id_fg_repair, "2", "2", XrTable1)
            End If

        End If
    End Sub
End Class