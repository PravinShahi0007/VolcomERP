Public Class ReportSetupBudgetOPEX
    Public Shared dt As DataTable
    Public Shared id_report As String = "-1"
    Public Shared is_pre As String = "-1"
    '
    Public report_mark_type As String = "-1"
    '
    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCBudgetPropose.DataSource = dt
        '
        '
        If is_pre = "1" Then
            load_mark_horz(report_mark_type, id_report, "2", "2", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id_report, "2", "2", XrTable1)
        End If
    End Sub
End Class