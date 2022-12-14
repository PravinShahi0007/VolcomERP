Public Class FormSOPIndexSchedule
    Private Sub FormSOPIndexSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT id_departement, departement FROM tb_m_departement"

        viewSearchLookupQuery(SLUEDepartment, query, "id_departement", "departement", "id_departement")

        Dim date_now As String = execute_query("SELECT NOW()", 0, True, "", "", "", "")

        DEDate.EditValue = date_now.Substring(0, 10)
        DETimeStart.EditValue = "09:00"
        DETimeEnd.EditValue = "11:00"

        load_clock()
    End Sub

    Sub load_clock()
        Dim q As String = "SELECT * FROM(
SELECT NOW() AS dt,NOW() AS `from`,NOW() AS `until`
)tb
WHERE ISNULL(tb.dt)"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCSchedule.DataSource = dt
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub FormSOPIndexSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        'Dim id_departement As String = SLUEDepartment.EditValue.ToString
        'Dim date_sch As String = Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")
        'Dim time_start As String = DETimeStart.Text + ":00"
        'Dim time_end As String = DETimeEnd.Text + ":00"

        'Dim total_insert As String = execute_query("SELECT COUNT(*) FROM tb_sop_schedule WHERE `date` = '" + date_sch + "' AND (('" + time_start + "' > time_start AND '" + time_start + "' < time_end) OR ('" + time_end + "' > time_start AND '" + time_end + "' < time_end) OR ('" + time_start + "' <= time_start AND '" + time_end + "' >= time_end))", 0, True, "", "", "", "")

        'If total_insert = "0" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim query_store As String = "INSERT INTO tb_sop_schedule (id_departement, `date`, time_start, time_end) VALUE ('" + id_departement + "', '" + date_sch + "', '" + time_start + "', '" + time_end + "')"

        '        execute_non_query(query_store, True, "", "", "", "")

        '        infoCustom("Schedule saved.")

        '        FormSOPIndex.view_sop_schedule_admin()

        '        Close()
        '    End If
        'Else
        '    infoCustom("Please choose another date or time.")
        'End If
        Dim is_ok As Boolean = True
        If GVSchedule.RowCount > 0 Then
            For i = 0 To GVSchedule.RowCount - 1
                Dim id_departement As String = SLUEDepartment.EditValue.ToString
                Dim date_sch As String = Date.Parse(GVSchedule.GetRowCellValue(i, "dt").ToString).ToString("yyyy-MM-dd")
                Dim time_start As String = Date.Parse(GVSchedule.GetRowCellValue(i, "from").ToString).ToString("H:mm:ss")
                Dim time_end As String = Date.Parse(GVSchedule.GetRowCellValue(i, "until").ToString).ToString("H:mm:ss")
                Dim total_insert As String = execute_query("SELECT COUNT(*) FROM tb_sop_schedule WHERE `date` = '" + date_sch + "' AND (('" + time_start + "' > time_start AND '" + time_start + "' < time_end) OR ('" + time_end + "' > time_start AND '" + time_end + "' < time_end) OR ('" + time_start + "' <= time_start AND '" + time_end + "' >= time_end))", 0, True, "", "", "", "")

                If Not total_insert = "0" Then
                    is_ok = False
                    infoCustom("Please choose another date or time for " & Date.Parse(GVSchedule.GetRowCellValue(i, "dt").ToString).ToString("dd MMMM yyyy") & " " & Date.Parse(GVSchedule.GetRowCellValue(i, "from").ToString).ToString("H:mm:ss") & " - " & Date.Parse(GVSchedule.GetRowCellValue(i, "until").ToString).ToString("H:mm:ss") & ".")
                End If
            Next
        Else
            is_ok = False
            warningCustom("Please input schedule.")
        End If
        If is_ok Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                For i = 0 To GVSchedule.RowCount - 1
                    Dim id_departement As String = SLUEDepartment.EditValue.ToString
                    Dim date_sch As String = Date.Parse(GVSchedule.GetRowCellValue(i, "dt").ToString).ToString("yyyy-MM-dd")
                    Dim time_start As String = Date.Parse(GVSchedule.GetRowCellValue(i, "from").ToString).ToString("H:mm:ss")
                    Dim time_end As String = Date.Parse(GVSchedule.GetRowCellValue(i, "until").ToString).ToString("H:mm:ss")

                    Dim query_store As String = "INSERT INTO tb_sop_schedule (id_departement, `date`, time_start, time_end) VALUE ('" + id_departement + "', '" + date_sch + "', '" + time_start + "', '" + time_end + "')"
                    execute_non_query(query_store, True, "", "", "", "")
                Next

                Dim qbody As String = "SELECT DATE_FORMAT(sch.date,'%d %M %Y') AS dt, DATE_FORMAT(sch.time_start,'%H:%i') AS time_start,DATE_FORMAT(sch.time_end,'%H:%i') AS time_end
FROM `tb_sop_schedule` sch
WHERE sch.id_departement='" & SLUEDepartment.EditValue.ToString & "'
AND sch.date>=DATE(NOW())
ORDER BY sch.date ASC,sch.time_start ASC"
                Dim dtbody As DataTable = execute_query(qbody, -1, True, "", "", "", "")
                If dtbody.Rows.Count > 0 Then
                    'email notifikasi
                    Dim mail As ClassSendEmail = New ClassSendEmail()
                    mail.report_mark_type = "378"
                    mail.par1 = SLUEDepartment.EditValue.ToString
                    mail.par2 = SLUEDepartment.Text.ToString
                    mail.send_email()
                End If

                infoCustom("Schedule saved.")
                FormSOPIndex.view_sop_schedule_admin()

                Close()
            End If
        End If
    End Sub

    Private Sub DETimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles DETimeStart.EditValueChanged
        Dim start_time As DateTime = DETimeStart.EditValue

        DETimeEnd.EditValue = start_time.AddHours(2)
    End Sub

    Private Sub DeleteModulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteModulToolStripMenuItem.Click
        If GVSchedule.RowCount > 0 Then
            GVSchedule.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Cursor = Cursors.WaitCursor
        GVSchedule.AddNewRow()
        GVSchedule.FocusedRowHandle = GVSchedule.RowCount - 1
        '
        GVSchedule.SetRowCellValue(GVSchedule.RowCount - 1, "dt", DEDate.EditValue)
        GVSchedule.SetRowCellValue(GVSchedule.RowCount - 1, "from", DETimeStart.EditValue)
        GVSchedule.SetRowCellValue(GVSchedule.RowCount - 1, "until", DETimeEnd.EditValue)
        '
        GVSchedule.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class