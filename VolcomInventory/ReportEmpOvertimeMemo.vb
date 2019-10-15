Public Class ReportEmpOvertimeMemo
    Public id As String = "0"
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertimeMemo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub
End Class