Public Class ReportEmpOvertime
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")

        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")

        GCEmployee.DataSource = data

        GCEmployeePosition.Caption = GCEmployeePosition.Caption.Replace(" ", Environment.NewLine)
        GCEmployeeStatus.Caption = GCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        GCConversionType.Caption = GCConversionType.Caption.Replace(" ", Environment.NewLine)
        GCBreakHours.Caption = GCBreakHours.Caption.Replace(" ", Environment.NewLine)
        GCTotalHours.Caption = GCTotalHours.Caption.Replace(" ", Environment.NewLine)
        GCStartWork.Caption = GCStartWork.Caption.Replace(" ", Environment.NewLine)
        GCEndWork.Caption = GCEndWork.Caption.Replace(" ", Environment.NewLine)
        GCNote.Caption = GCNote.Caption.Replace(" ", Environment.NewLine)

        GVEmployee.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub
End Class