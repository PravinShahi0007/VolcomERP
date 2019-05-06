Public Class ReportSampleExpense
    Public data As DataTable = New DataTable()
    Public id_pre As String = "-1"
    Public id_purc As String = "-1"

    Private Sub ReportSampleExpense_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCAfter.DataSource = data

        If id_pre = "-1" Then
            load_mark_horz("179", id_purc, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("179", id_purc, "2", "2", XrTable1)
        End If
    End Sub
End Class