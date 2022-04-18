Public Class FormEmpLeavePick
    Public id_schedule As String = "-1"
    Public id_employee As String = "-1"

    Public opt As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpLeavePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim now_date As Date

        Dim q As String = "SELECT NOW() as now_date"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        now_date = dt.Rows(0)("now_date")

        DEStart.EditValue = now_date
        DEUntil.EditValue = now_date
        '
        view_schedule()
        '
        If opt = "1" Or opt = "2" Then 'change schedule
            BPickAll.Visible = False
            LPropose.Visible = False
            CEFullDay.Visible = False
            DEStartLeave.Visible = False
            DEUntilLeave.Visible = False
            Luntil.Visible = False
        Else 'leave
            BPickAll.Visible = True

            'min propose leave 1 week
            If Not FormEmpLeaveDet.is_hrd = "1" And FormEmpLeaveDet.LELeaveType.EditValue.ToString = "1" Then
                Dim leave_min_day As Integer = CType(get_opt_emp_field("leave_min_day"), Integer)

                If leave_min_day > 0 Then
                    DEStart.Properties.MinValue = now_date.Date.AddDays(leave_min_day)
                    DEUntil.Properties.MinValue = now_date.Date.AddDays(leave_min_day)
                End If
            End If
        End If
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        view_schedule()
    End Sub
    Sub view_schedule()
        load_schedule()
        load_total()
        load_date()
        GVSchedule.BestFitColumns()
        GVSchedule.Focus()
    End Sub
    Sub load_schedule()
        Dim query As String = ""
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        query = "SELECT * FROM tb_emp_schedule sch INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type"
        query += " WHERE sch.`date`>='" & date_start & "' AND sch.`date`<='" & date_until & "' AND sch.id_employee='" & id_employee & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub GVSchedule_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSchedule.FocusedRowChanged
        CEFullDay.Checked = True
        load_total()
    End Sub

    Sub load_total()
        Try
            If GVSchedule.RowCount > 0 Then
                DEStartLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                DEStartLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                DEStartLeave.EditValue = GVSchedule.GetFocusedRowCellValue("in")

                DEUntilLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                DEUntilLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                DEUntilLeave.EditValue = GVSchedule.GetFocusedRowCellValue("out")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If DEStartLeave.Text = "" And opt = "-1" Then
            stopCustom("Pilih tanggal pengajuan cuti terlebih dahulu.")
        Else
            If opt = "1" Then ' change schedule from
                FormEmpChScheduleDet.id_sch_from = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                FormEmpChScheduleDet.load_sch("1")
                FormEmpChScheduleDet.BPickScheduleTo.Focus()
                Close()
            ElseIf opt = "2" Then ' change schedule to
                FormEmpChScheduleDet.id_sch_to = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                FormEmpChScheduleDet.load_sch("2")
                FormEmpChScheduleDet.MEChNote.Focus()
                Close()
            Else 'leave
                Dim check As Boolean = True

                For i As Integer = 0 To FormEmpLeaveDet.GVLeaveDet.RowCount - 1
                    If FormEmpLeaveDet.GVLeaveDet.GetRowCellValue(i, "id_schedule").ToString = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString Then
                        check = False
                    End If
                Next

                If check = False Then
                    stopCustom("Tanggal ini sudah diajukan cuti.")
                ElseIf Not GVSchedule.GetFocusedRowCellValue("id_schedule_type").ToString = "1" Then
                    stopCustom("Tidak bisa mengajukan cuti dihari libur.")
                Else
                    Dim total_min As Integer = 0

                    Dim is_full_day As String = "no"
                    Dim minute_total As TimeSpan
                    Dim date_from, date_until As Date

                    date_from = Date.Parse(DEStartLeave.EditValue.ToString)
                    date_until = Date.Parse(DEUntilLeave.EditValue.ToString)

                    If CEFullDay.Checked = False Then
                        is_full_day = "no"
                        minute_total = Date.Parse(date_until.ToString).Subtract(Date.Parse(date_from.ToString))
                        total_min = minute_total.TotalMinutes
                    Else
                        is_full_day = "yes"
                        total_min = GVSchedule.GetFocusedRowCellValue("minutes_work")
                    End If

                    Dim is_ok As Boolean = True

                    Dim qc As String = "SELECT id_coa_tag,is_office_dept FROM tb_m_employee e
INNER JOIN tb_m_departement d ON d.id_departement=e.id_departement
WHERE e.id_employee='" & id_employee & "'"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        If dtc.Rows(0)("id_coa_tag").ToString = "1" And dtc.Rows(0)("is_office_dept").ToString = "1" Then
                            'office
                            If total_min < get_opt_emp_field("min_leave_minutes") And is_no_min_hour(FormEmpLeaveDet.LELeaveType.EditValue.ToString) = "2" Then
                                stopCustom("Hanya dapat mengajukan dengan lama minimal " & (Decimal.Parse(get_opt_emp_field("min_leave_minutes").ToString) / 60).ToString & " jam")
                                is_ok = False
                            End If
                        Else
                            If total_min < get_opt_emp_field("min_leave_minutes_cabang") And is_no_min_hour(FormEmpLeaveDet.LELeaveType.EditValue.ToString) = "2" Then
                                stopCustom("Hanya dapat mengajukan dengan lama minimal " & (Decimal.Parse(get_opt_emp_field("min_leave_minutes_cabang").ToString) / 60).ToString & " jam")
                                is_ok = False
                            End If
                        End If
                    End If

                    If Not is_ok Then
                        'stopCustom("Hanya dapat mengajukan dengan lama minimal 4 jam")
                    Else
                        Dim newRow As DataRow = (TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable)).NewRow()
                        newRow("id_schedule") = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                        newRow("datetime_start") = date_from
                        newRow("datetime_until") = date_until
                        newRow("is_full_day") = is_full_day
                        newRow("hours_total") = total_min / 60
                        newRow("minutes_total") = total_min

                        TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable).Rows.Add(newRow)
                        FormEmpLeaveDet.GCLeaveDet.RefreshDataSource()
                        FormEmpLeaveDet.load_but_calc()
                        FormEmpLeaveDet.GVLeaveDet.FocusedRowHandle = 0
                        '
                        Close()
                    End If
                End If
            End If
        End If
    End Sub

    Function is_no_min_hour(ByVal id_leave_type As String)
        Dim no_min_hour As String = ""

        Dim query As String = "SELECT * FROM tb_lookup_leave_type WHERE id_leave_type='" & id_leave_type & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        no_min_hour = data.Rows(0)("is_no_min_hour").ToString

        Return no_min_hour
    End Function

    Private Sub CEFullDay_CheckedChanged(sender As Object, e As EventArgs) Handles CEFullDay.CheckedChanged
        load_date()
    End Sub

    Sub load_date()
        Try
            If CEFullDay.Checked = True Then
                If GVSchedule.RowCount > 0 Then
                    DEStartLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                    DEStartLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                    DEStartLeave.EditValue = GVSchedule.GetFocusedRowCellValue("in")
                    '
                    DEUntilLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                    DEUntilLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                    DEUntilLeave.EditValue = GVSchedule.GetFocusedRowCellValue("out")
                    '
                    DEStartLeave.Properties.ReadOnly = True
                    DEUntilLeave.Properties.ReadOnly = True
                End If
            Else
                DEStartLeave.Properties.ReadOnly = False
                DEUntilLeave.Properties.ReadOnly = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormEmpLeavePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpLeavePick_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DEStart.Focus()
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BViewSchedule.Focus()
        End If
    End Sub

    Private Sub GVSchedule_KeyDown(sender As Object, e As KeyEventArgs) Handles GVSchedule.KeyDown
        If e.KeyCode = Keys.Enter Then
            If opt = "1" Or opt = "2" Then
                BAdd.Focus()
            Else
                CEFullDay.Focus()
            End If
        End If
    End Sub

    Private Sub CEFullDay_KeyDown(sender As Object, e As KeyEventArgs) Handles CEFullDay.KeyDown
        If e.KeyCode = Keys.NumPad1 Then
            CEFullDay.Checked = True
        ElseIf e.KeyCode = Keys.NumPad0 Then
            CEFullDay.Checked = False
        ElseIf e.KeyCode = Keys.Enter Then
            If CEFullDay.Checked = True Then
                BAdd.Focus()
            Else
                DEStartLeave.Focus()
            End If
        End If
    End Sub

    Private Sub DEStartLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStartLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilLeave.Focus()
        End If
    End Sub

    Private Sub DEUntilLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BAdd.Focus()
        End If
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        If GVSchedule.RowCount > 0 Then
            FormEmpLeaveDet.clear_grid()

            'check already
            Dim check_msg As String = ""

            For i = 0 To FormEmpLeaveDet.GVLeaveDet.RowCount - 1
                For j = 0 To GVSchedule.RowCount - 1
                    If FormEmpLeaveDet.GVLeaveDet.GetRowCellValue(i, "id_schedule").ToString = GVSchedule.GetRowCellValue(j, "id_schedule").ToString Then
                        check_msg += "- " + Date.Parse(GVSchedule.GetRowCellValue(j, "date").ToString).ToString("dd MMM yyyy") + Environment.NewLine
                    End If
                Next
            Next

            If check_msg = "" Then
                For i As Integer = 0 To GVSchedule.RowCount - 1
                    If GVSchedule.GetRowCellValue(i, "id_schedule_type").ToString = "1" Then
                        Dim total_min As Integer = 0

                        Dim is_full_day As String = "no"
                        Dim date_from, date_until As Date

                        date_from = Date.Parse(GVSchedule.GetRowCellValue(i, "in").ToString)
                        date_until = Date.Parse(GVSchedule.GetRowCellValue(i, "out").ToString)

                        is_full_day = "yes"
                        total_min = GVSchedule.GetRowCellValue(i, "minutes_work")

                        Dim newRow As DataRow = (TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable)).NewRow()
                        newRow("id_schedule") = GVSchedule.GetRowCellValue(i, "id_schedule").ToString
                        newRow("datetime_start") = date_from
                        newRow("datetime_until") = date_until
                        newRow("is_full_day") = is_full_day
                        newRow("hours_total") = total_min / 60
                        newRow("minutes_total") = total_min

                        TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable).Rows.Add(newRow)
                        FormEmpLeaveDet.GCLeaveDet.RefreshDataSource()
                        FormEmpLeaveDet.load_but_calc()
                        FormEmpLeaveDet.GVLeaveDet.FocusedRowHandle = 0
                    End If
                Next

                Close()
            Else
                stopCustom("Tanggal berikut ini sudah diajukan cuti." + Environment.NewLine + check_msg)
            End If
        Else
            stopCustom("Schedule anda belum diinput, Harap untuk menghubungi HRD.")
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
            view_schedule()

            If GVSchedule.RowCount <= 0 Then
                stopCustom("Schedule anda belum diinput, Harap untuk menghubungi HRD.")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            view_schedule()
        Catch ex As Exception
        End Try
    End Sub
End Class