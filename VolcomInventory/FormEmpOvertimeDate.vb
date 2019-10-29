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
            DEOvertimeDateFrom.Properties.MinValue = New DateTime(min_date.Year, min_date.Month, min_date.Day)
        End If

        'default
        DEOvertimeDateFrom.EditValue = min_date
        TEOvertimeStart.EditValue = New DateTime(Now.Year, Now.Month, Now.Day, 8, 30, 0)
        TEOvertimeEnd.EditValue = New DateTime(Now.Year, Now.Month, Now.Day, 17, 30, 0)
        TEOvertimeBreak.EditValue = 1.0
    End Sub

    Sub calculateTotalHours()
        Dim ot_date As DateTime = DEOvertimeDateFrom.EditValue
        Dim ot_start As DateTime = DateTime.Parse(ot_date.ToString("dd MMMM yyyy") + " " + DateTime.Parse(TEOvertimeStart.EditValue.ToString).ToString("HH:mm:ss"))
        Dim ot_end As DateTime = DateTime.Parse(ot_date.ToString("dd MMMM yyyy") + " " + DateTime.Parse(TEOvertimeEnd.EditValue.ToString).ToString("HH:mm:ss"))
        Dim ot_break As Decimal = TEOvertimeBreak.EditValue

        If ot_end < ot_start Then
            ot_end = ot_end.AddDays(1)
        End If

        Dim diff As TimeSpan = ot_end.Subtract(ot_start)

        Dim total As Decimal = 0.0

        total = Math.Round(Math.Round(diff.TotalHours, 1) - ot_break, 1)

        TETotalHours.EditValue = total
    End Sub

    Private Sub FormEmpOvertimeDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub DEOvertimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEOvertimeDateFrom.EditValueChanged
        If Not DEOvertimeDateFrom.EditValue Is Nothing Then
            'time
            Dim ot_date As DateTime = DEOvertimeDateFrom.EditValue

            DEOvertimeDateTo.Properties.MinValue = ot_date
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
        Dim ot_note As String = MEOvertimeNote.EditValue.ToString

        If TETotalHours.EditValue < ot_min_staff Then
            errorCustom("Overtime at least " + ot_min_staff.ToString + " hours")
        ElseIf ot_note = "" Then
            errorCustom("Overtime propose can't be blank")
        Else
            FormEmpOvertimePick.is_hrd = is_hrd
            FormEmpOvertimePick.overtime_date_from = DEOvertimeDateFrom.EditValue
            FormEmpOvertimePick.overtime_date_to = DEOvertimeDateTo.EditValue
            FormEmpOvertimePick.overtime_start_time = TEOvertimeStart.EditValue
            FormEmpOvertimePick.overtime_end_time = TEOvertimeEnd.EditValue
            FormEmpOvertimePick.overtime_break = TEOvertimeBreak.EditValue
            FormEmpOvertimePick.overtime_propose = MEOvertimeNote.EditValue
            FormEmpOvertimePick.total_hours = TETotalHours.EditValue

            FormEmpOvertimePick.ShowDialog()
        End If
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class