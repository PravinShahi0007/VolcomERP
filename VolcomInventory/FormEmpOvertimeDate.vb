Public Class FormEmpOvertimeDate
    Public is_hrd As String = "-1"

    Private Sub FormEmpOvertimeDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Pick"
        Else
            Text = "Overtime Management Pick"
        End If

        Dim ot_min_days As Decimal = get_opt_emp_field("ot_min_days")

        Dim min_date As DateTime = Now.AddDays(ot_min_days)

        'permission
        If is_hrd = "-1" Then
            DEOvertimeDate.Properties.MinValue = New DateTime(min_date.Year, min_date.Month, min_date.Day)
        End If

        'default
        DEOvertimeDate.EditValue = min_date
        TEOvertimeStart.EditValue = New DateTime(min_date.Year, min_date.Month, min_date.Day, 8, 30, 0)
        TEOvertimeEnd.EditValue = New DateTime(min_date.Year, min_date.Month, min_date.Day, 17, 30, 0)
        TEOvertimeBreak.EditValue = 1.0
    End Sub

    Sub calculateTotalHours()
        Dim ot_start As DateTime = TEOvertimeStart.EditValue
        Dim ot_end As DateTime = TEOvertimeEnd.EditValue

        Dim diff As TimeSpan = ot_end.Subtract(ot_start)

        Dim total As Decimal = 0.0

        total = Math.Round(Math.Round(diff.TotalHours, 1) - TEOvertimeBreak.EditValue, 1)

        TETotalHours.EditValue = total
    End Sub

    Private Sub FormEmpOvertimeDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEOvertimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEOvertimeDate.EditValueChanged
        If Not DEOvertimeDate.EditValue Is Nothing Then
            'time
            Dim ot_date As DateTime = DEOvertimeDate.EditValue

            Dim ot_start As DateTime = TEOvertimeStart.EditValue
            Dim ot_end As DateTime = TEOvertimeEnd.EditValue

            Dim plus_days As Integer = ot_end.Subtract(ot_start).TotalDays

            'disable time
            TEOvertimeStart.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)
            TEOvertimeStart.Properties.MaxValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 23, 59, 59)

            TEOvertimeEnd.Properties.MinValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 0, 0, 0)
            TEOvertimeEnd.Properties.MaxValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, 23, 59, 59).AddDays(1)

            'change time date
            TEOvertimeStart.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_start.Hour, ot_start.Minute, ot_start.Second)
            TEOvertimeEnd.EditValue = New DateTime(ot_date.Year, ot_date.Month, ot_date.Day, ot_end.Hour, ot_end.Minute, ot_end.Second).AddDays(plus_days)
        End If
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeBreak.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim ot_min_staff As Decimal = get_opt_emp_field("ot_min_staff")

        If TETotalHours.EditValue < ot_min_staff Then
            errorCustom("Overtime at least " + ot_min_staff.ToString + " Hours")
        Else
            FormEmpOvertimePick.is_hrd = is_hrd
            FormEmpOvertimePick.overtime_date = DEOvertimeDate.EditValue
            FormEmpOvertimePick.overtime_start_time = TEOvertimeStart.EditValue
            FormEmpOvertimePick.overtime_end_time = TEOvertimeEnd.EditValue
            FormEmpOvertimePick.overtime_break = TEOvertimeBreak.EditValue

            FormEmpOvertimePick.ShowDialog()

            Close()
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class