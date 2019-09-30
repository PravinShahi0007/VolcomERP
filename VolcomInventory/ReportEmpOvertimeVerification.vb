Public Class ReportEmpOvertimeVerification
    Public id As String = ""
    Public data1 As DataTable = New DataTable
    Public data2 As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertimeVerification_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEType2, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")

        'propse
        'date format
        For i = 0 To data1.Rows.Count - 1
            data1.Rows(i)("ot_start_time") = Date.Parse(data1.Rows(i)("ot_start_time").ToString).ToString("HH:mm")
            data1.Rows(i)("ot_end_time") = Date.Parse(data1.Rows(i)("ot_end_time").ToString).ToString("HH:mm")
        Next

        GCEmployee.DataSource = data1

        GCEmployeePosition.Caption = GCEmployeePosition.Caption.Replace(" ", Environment.NewLine)
        GCEmployeeStatus.Caption = GCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        GCConversionType.Caption = GCConversionType.Caption.Replace(" ", Environment.NewLine)
        GCBreakHours.Caption = GCBreakHours.Caption.Replace(" ", Environment.NewLine)
        GCTotalHours.Caption = GCTotalHours.Caption.Replace(" ", Environment.NewLine)

        GVEmployee.ActiveFilterString = "[ot_date] = '" + Date.Parse(FormEmpOvertimeVerification.DESearch.EditValue.ToString).ToString("dd MMMM yyyy") + "'"

        'relization
        'date format
        For i = 0 To data2.Rows.Count - 1
            data2.Rows(i)("start_work_att") = Date.Parse(data2.Rows(i)("start_work_att").ToString).ToString("HH:mm")
            data2.Rows(i)("end_work_att") = Date.Parse(data2.Rows(i)("end_work_att").ToString).ToString("HH:mm")
            data2.Rows(i)("start_work_ot") = Date.Parse(data2.Rows(i)("start_work_ot").ToString).ToString("HH:mm")
            data2.Rows(i)("end_work_ot") = Date.Parse(data2.Rows(i)("end_work_ot").ToString).ToString("HH:mm")
        Next

        GCAttendance.DataSource = data2

        BGCEmployeePosition.Caption = BGCEmployeePosition.Caption.Replace(" ", Environment.NewLine)
        BGCEmployeeStatus.Caption = BGCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        BGCConversionType.Caption = BGCConversionType.Caption.Replace(" ", Environment.NewLine)
        BGCBreakHours.Caption = BGCBreakHours.Caption.Replace(" ", Environment.NewLine)
        BGCTotalHours.Caption = BGCTotalHours.Caption.Replace(" ", Environment.NewLine)

        If id_pre = "-1" Then
            load_mark_horz("187", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("187", id, "2", "2", XrTable1)
        End If
    End Sub
End Class