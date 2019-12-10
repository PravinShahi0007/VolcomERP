Public Class ReportEmpOvertimeVerification
    Public id As String = ""
    Public data1 As DataTable = New DataTable
    Public data2 As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertimeVerification_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewSearchLookupRepositoryQuery(RISLUEType2, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")

        'propse
        GCEmployee.DataSource = data1

        GCConversionType.Caption = GCConversionType.Caption.Replace(" ", Environment.NewLine)
        GCBreakHours.Caption = GCBreakHours.Caption.Replace(" ", Environment.NewLine)
        GCTotalHours.Caption = GCTotalHours.Caption.Replace(" ", Environment.NewLine)
        GCStartWork.Caption = GCStartWork.Caption.Replace(" ", Environment.NewLine)
        GCEndWork.Caption = GCEndWork.Caption.Replace(" ", Environment.NewLine)
        GCNote.Caption = GCNote.Caption.Replace(" ", Environment.NewLine)

        GVEmployee.ActiveFilterString = "[ot_date] = '" + Date.Parse(FormEmpOvertimeVerification.DESearch.EditValue.ToString).ToString("dd MMMM yyyy") + "'"

        'relization
        GCAttendance.DataSource = data2

        BGCConversionType.Caption = BGCConversionType.Caption.Replace(" ", Environment.NewLine)
        BGCBreakHours.Caption = BGCBreakHours.Caption.Replace(" ", Environment.NewLine)
        BGCTotalHours.Caption = BGCTotalHours.Caption.Replace(" ", Environment.NewLine)
        BGCStartWorkOt.Caption = BGCStartWorkOt.Caption.Replace(" ", Environment.NewLine)
        BGCEndWorkOt.Caption = BGCEndWorkOt.Caption.Replace(" ", Environment.NewLine)
        BGCNote.Caption = BGCNote.Caption.Replace(" ", Environment.NewLine)

        GVAttendance.ActiveFilterString = "[is_valid] = 'yes' Or [total_hours] <= 0.0"

        If Not FormEmpOvertimeVerification.is_hrd = "1" Then
            BGCActualHours.Visible = False
            BGCPointOt.Visible = False
        End If

        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_ot_verification WHERE id_ot_verification = " + id, 0, True, "", "", "", "")

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVAttendance_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVAttendance.RowCellStyle
        If GVAttendance.GetRowCellValue(e.RowHandle, "total_hours") <= 0 Then
            e.Appearance.BackColor = Color.FromArgb(243, 217, 217)
        Else
            Dim is_proposed As Boolean = False

            For i = 0 To GVEmployee.RowCount - 1
                If GVEmployee.IsValidRowHandle(i) Then
                    If GVEmployee.GetRowCellValue(i, "id_employee").ToString = GVAttendance.GetRowCellValue(e.RowHandle, "id_employee").ToString Then
                        is_proposed = True
                    End If
                End If
            Next

            If Not is_proposed Then
                e.Appearance.BackColor = Color.FromArgb(217, 217, 243)
            End If
        End If
    End Sub
End Class