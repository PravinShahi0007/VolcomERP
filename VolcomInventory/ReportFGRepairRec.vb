Public Class ReportFGRepairRec
    Public Shared id_pre As String = "-1"
    Public Shared id_fg_repair_rec As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable


    Private Sub ReportFGRepairRec_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCScanSum.DataSource = dt
        If id_type = "-1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("92", id_fg_repair_rec, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("92", id_fg_repair_rec, "2", "2", XrTable1)
            End If
        ElseIf id_type = "1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("92", id_fg_repair_rec, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("92", id_fg_repair_rec, "2", "2", XrTable1)
            End If

        End If
    End Sub

    Private Sub GVScanSum_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVScanSum.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class