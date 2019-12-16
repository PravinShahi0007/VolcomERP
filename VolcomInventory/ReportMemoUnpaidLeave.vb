Public Class ReportMemoUnpaidLeave
    Public Shared report_mark_type As String = "-1"
    Public Shared id_report As String = "-1"

    Private Sub ReportMemoUnpaidLeave_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data As DataTable = execute_query("SELECT id_emp, id_report_status FROM tb_emp_leave WHERE id_emp_leave = " + id_report, -1, True, "", "", "", "")

        pre_load_asg_horz(report_mark_type, data.Rows(0)("id_emp").ToString, XrTable1, "1")
    End Sub
End Class