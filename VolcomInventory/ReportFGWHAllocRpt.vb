Public Class ReportFGWHAllocRpt
    Public Shared dt As New DataTable
    Public Shared id_fg_wh_alloc As String = "-1"
    Public Shared id_pre As String = "-1"

    Private Sub ReportFGWHAllocRpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSum2.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("87", id_fg_wh_alloc, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("87", id_fg_wh_alloc, "2", "2", XrTable1)
        End If
    End Sub
End Class