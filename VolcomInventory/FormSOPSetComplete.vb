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

                If not_complete_list.Count > 0 Then
                    Dim id_sop_schedule As String = execute_query("
                        SELECT IFNULL((SELECT IFNULL(id_sop_schedule, 0) AS id_sop_schedule
                        FROM tb_sop_schedule
                        WHERE id_sop_schedule NOT IN (SELECT id_sop_schedule FROM tb_sop_schedule_sop) AND id_departement = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_departement").ToString + "'
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
                    End If
                End If

                If complete_flowchart.Count > 0 Then
                    Dim id_sop_schedule As String = execute_query("
                        SELECT IFNULL((SELECT IFNULL(id_sop_schedule, 0) AS id_sop_schedule
                        FROM tb_sop_schedule
                        WHERE id_sop_schedule NOT IN (SELECT id_sop_schedule FROM tb_sop_schedule_sop) AND id_departement = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_departement").ToString + "'
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
                    End If
                End If

                FormSOPIndex.view_sop_schedule_admin()

                Close()
            End If
        Else
                stopCustom("Please fill milestone & status.")
        End If
    End Sub
End Class