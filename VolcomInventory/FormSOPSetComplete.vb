Public Class FormSOPSetComplete
    Private Sub FormSOPSetComplete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupRepositoryQuery(RISLUEMilestone, "SELECT * FROM tb_lookup_milestone", 0, "milestone", "id_milestone")
        viewSearchLookupRepositoryQuery(RISLUEIsComplete, "SELECT 1 AS id, 'Complete' AS `status` UNION ALL SELECT 0 AS id, 'Not Complete' AS `status`", 0, "status", "id")

        Dim query As String = "
            SELECT s.id_sop_schedule_sop, t.sop_number, t.sop_name, IFNULL(id_milestone, '') AS milestone, '' AS is_complete
            FROM tb_sop_schedule_sop AS s
            LEFT JOIN tb_sop AS t ON s.id_sop = t.id_sop
            WHERE s.id_sop_schedule = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSchedule.DataSource = data

        GVSchedule.BestFitColumns()
    End Sub

    Private Sub FormSOPSetComplete_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        Cursor = Cursors.WaitCursor
        Dim cnt As Boolean = True

        For i = 0 To GVSchedule.RowCount - 1
            If GVSchedule.IsValidRowHandle(i) Then
                If GVSchedule.GetRowCellValue(i, "milestone").ToString = "" Or GVSchedule.GetRowCellValue(i, "is_complete").ToString = "" Then
                    cnt = False
                End If
            End If
        Next

        If cnt Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim not_complete_list As List(Of String) = New List(Of String)
                Dim complete_flowchart As List(Of String) = New List(Of String)

                For i = 0 To GVSchedule.RowCount - 1
                    If GVSchedule.IsValidRowHandle(i) Then
                        If GVSchedule.GetRowCellValue(i, "is_complete").ToString = "0" Then
                            not_complete_list.Add(GVSchedule.GetRowCellValue(i, "id_sop_schedule_sop").ToString)
                        End If

                        If GVSchedule.GetRowCellValue(i, "is_complete").ToString = "1" And GVSchedule.GetRowCellValue(i, "milestone").ToString = "1" Then
                            complete_flowchart.Add(GVSchedule.GetRowCellValue(i, "id_sop_schedule_sop").ToString)
                        End If

                        execute_non_query("UPDATE tb_sop_schedule_sop SET id_milestone = '" + GVSchedule.GetRowCellValue(i, "milestone").ToString + "', is_complete = '" + GVSchedule.GetRowCellValue(i, "is_complete").ToString + "', `datetime` = NOW() WHERE id_sop_schedule_sop = '" + GVSchedule.GetRowCellValue(i, "id_sop_schedule_sop").ToString + "'", True, "", "", "", "")
                    End If
                Next

                'email notif status
                Dim qbody2 As String = "SELECT DATE_FORMAT(ss.date,'%W, %d %M %Y') AS dt, DATE_FORMAT(ss.time_start,'%H:%i') AS time_start,DATE_FORMAT(ss.time_end,'%H:%i') AS time_end,s.`sop_name`,s.`sop_number`,m.`milestone`,IF(is_complete=1,'Complete','Not Complete') AS sts
FROM tb_sop_schedule_sop sop
INNER JOIN tb_sop s ON s.`id_sop`=sop.id_sop
INNER JOIN `tb_sop_schedule` ss ON ss.id_sop_schedule=sop.id_sop_schedule
INNER JOIN tb_lookup_milestone m ON m.`id_milestone`=sop.`id_milestone`
WHERE sop.id_sop_schedule='" & FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString & "'"
                Dim dtbody2 As DataTable = execute_query(qbody2, -1, True, "", "", "", "")
                If dtbody2.Rows.Count > 0 Then
                    'email notifikasi
                    Dim mail As ClassSendEmail = New ClassSendEmail()
                    mail.report_mark_type = "381"
                    mail.id_report = FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString
                    mail.send_email()
                End If

                If not_complete_list.Count > 0 Then
                    Dim id_sop_schedule As String = execute_query("
                        SELECT IFNULL((SELECT IFNULL(id_sop_schedule, 0) AS id_sop_schedule
                        FROM tb_sop_schedule
                        WHERE id_sop_schedule NOT IN (SELECT id_sop_schedule FROM tb_sop_schedule_sop) AND id_departement = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_departement").ToString + "' AND `date` >= '" + Date.Parse(FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("date").ToString).ToString("yyyy-MM-dd") + "'
                        ORDER BY `date` ASC, time_start ASC
                        LIMIT 1), 0)
                    ", 0, True, "", "", "", "")

                    If Not id_sop_schedule = "0" Then
                        execute_non_query("
                            INSERT INTO tb_sop_schedule_sop (id_sop_schedule, id_sop, id_milestone)
                            SELECT '" + id_sop_schedule + "' AS id_sop_schedule, id_sop, id_milestone
                            FROM tb_sop_schedule_sop
                            WHERE id_sop_schedule_sop IN (" + String.Join(",", not_complete_list) + ")
                        ", True, "", "", "", "")
                        'notif jadwal nextnya
                        Dim qbody As String = "SELECT DATE_FORMAT(ss.date,'%W, %d %M %Y') AS dt, DATE_FORMAT(ss.time_start,'%H:%i') AS time_start,DATE_FORMAT(ss.time_end,'%H:%i') AS time_end,s.`sop_name`,s.`sop_number` 
FROM tb_sop_schedule_sop sop
INNER JOIN tb_sop s ON s.`id_sop`=sop.id_sop
INNER JOIN `tb_sop_schedule` ss ON ss.id_sop_schedule=sop.id_sop_schedule
WHERE sop.id_sop_schedule='" & id_sop_schedule & "'"
                        Dim dtbody As DataTable = execute_query(qbody, -1, True, "", "", "", "")
                        If dtbody.Rows.Count > 0 Then
                            'email notifikasi
                            Dim mail As ClassSendEmail = New ClassSendEmail()
                            mail.report_mark_type = "379"
                            mail.id_report = id_sop_schedule
                            mail.send_email()
                        End If
                    End If
                End If

                If complete_flowchart.Count > 0 Then
                    Dim id_sop_schedule As String = execute_query("
                        SELECT IFNULL((SELECT IFNULL(id_sop_schedule, 0) AS id_sop_schedule
                        FROM tb_sop_schedule
                        WHERE id_sop_schedule NOT IN (SELECT id_sop_schedule FROM tb_sop_schedule_sop) AND id_departement = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_departement").ToString + "' AND `date` >= '" + Date.Parse(FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("date").ToString).ToString("yyyy-MM-dd") + "'
                        ORDER BY `date` ASC, time_start ASC
                        LIMIT 1), 0)
                    ", 0, True, "", "", "", "")

                    If Not id_sop_schedule = "0" Then
                        execute_non_query("
                            INSERT INTO tb_sop_schedule_sop (id_sop_schedule, id_sop, id_milestone)
                            SELECT '" + id_sop_schedule + "' AS id_sop_schedule, id_sop, 2
                            FROM tb_sop_schedule_sop
                            WHERE id_sop_schedule_sop IN (" + String.Join(",", complete_flowchart) + ")
                        ", True, "", "", "", "")
                        'notif jadwal nextnya
                        Dim qbody As String = "SELECT DATE_FORMAT(ss.date,'%W, %d %M %Y') AS dt, DATE_FORMAT(ss.time_start,'%H:%i') AS time_start,DATE_FORMAT(ss.time_end,'%H:%i') AS time_end,s.`sop_name`,s.`sop_number` 
FROM tb_sop_schedule_sop sop
INNER JOIN tb_sop s ON s.`id_sop`=sop.id_sop
INNER JOIN `tb_sop_schedule` ss ON ss.id_sop_schedule=sop.id_sop_schedule
WHERE sop.id_sop_schedule='" & id_sop_schedule & "'"
                        Dim dtbody As DataTable = execute_query(qbody, -1, True, "", "", "", "")
                        If dtbody.Rows.Count > 0 Then
                            'email notifikasi
                            Dim mail As ClassSendEmail = New ClassSendEmail()
                            mail.report_mark_type = "379"
                            mail.id_report = id_sop_schedule
                            mail.send_email()
                        End If
                    End If
                End If

                FormSOPIndex.view_sop_schedule_admin()
                Close()
            End If
        Else
            stopCustom("Please fill milestone & status.")
        End If
        Cursor = Cursors.Default
    End Sub
End Class