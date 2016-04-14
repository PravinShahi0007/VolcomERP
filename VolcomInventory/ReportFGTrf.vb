Public Class ReportFGTrf
    Public Shared id_pre As String = "-1"
    Public Shared id_fg_trf As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable

 

    Private Sub ReportFGTrf_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        If id_type = "-1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("57", id_fg_trf, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("57", id_fg_trf, "2", "2", XrTable1)
            End If
        ElseIf id_type = "1" Then
            'Mark
            If id_pre = "-1" Then
                load_mark_horz("58", id_fg_trf, "2", "1", XrTable1)
            Else
                pre_load_mark_horz("58", id_fg_trf, "2", "2", XrTable1)
            End If

        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class