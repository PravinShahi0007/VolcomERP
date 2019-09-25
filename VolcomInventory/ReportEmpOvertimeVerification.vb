Public Class ReportEmpOvertimeVerification
    Public id As String = ""
    Public data1 As DataTable = New DataTable
    Public data2 As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertimeVerification_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = data1
        GCAttendance.DataSource = data2

        If id_pre = "-1" Then
            load_mark_horz("187", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("187", id, "2", "2", XrTable1)
        End If
    End Sub
End Class