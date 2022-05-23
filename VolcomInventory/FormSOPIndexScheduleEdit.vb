Public Class FormSOPIndexScheduleEdit
    Public id_sop_schedule As String = "-1"

    Private Sub FormSOPIndexScheduleEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT id_departement, departement FROM tb_m_departement"

        viewSearchLookupQuery(SLUEDepartment, query, "id_departement", "departement", "id_departement")

        Dim load_data As DataTable = execute_query("SELECT id_departement, `date`, time_start, time_end FROM tb_sop_schedule WHERE id_sop_schedule = " + id_sop_schedule, -1, True, "", "", "", "")

        SLUEDepartment.EditValue = load_data.Rows(0)("id_departement")
        DEDate.EditValue = load_data.Rows(0)("date")
        DETimeStart.EditValue = load_data.Rows(0)("time_start")
        DETimeEnd.EditValue = load_data.Rows(0)("time_end")
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim id_departement As String = SLUEDepartment.EditValue.ToString
        Dim date_sch As String = Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim time_start As String = DateTime.Parse(DETimeStart.EditValue.ToString).ToString("HH:mm:ss")
        Dim time_end As String = DateTime.Parse(DETimeEnd.EditValue.ToString).ToString("HH:mm:ss")

        Dim total_insert As DataTable = execute_query("SELECT id_sop_schedule FROM tb_sop_schedule WHERE `date` = '" + date_sch + "' AND (('" + time_start + "' > time_start AND '" + time_start + "' < time_end) OR ('" + time_end + "' > time_start AND '" + time_end + "' < time_end) OR ('" + time_start + "' <= time_start AND '" + time_end + "' >= time_end)) AND id_sop_schedule <> " + id_sop_schedule, -1, True, "", "", "", "")

        If total_insert.Rows.Count > 0 Then
            Dim query As String = "
                SELECT CONCAT(DATE_FORMAT(s.`date`, '%d %M %Y'), ' ', SUBSTR(s.time_start, 1, 5), '-', SUBSTR(s.time_end, 1, 5)) AS `at`, d.departement
                FROM tb_sop_schedule AS s
                LEFT JOIN tb_m_departement AS d ON s.id_departement = d.id_departement
                WHERE s.id_sop_schedule = " + total_insert.Rows(0)("id_sop_schedule").ToString + "
            "

            Dim used As DataTable = execute_query(query, -1, True, "", "", "", "")

            stopCustom("Please choose another date or time, because it's been used (" + used.Rows(0)("departement").ToString + " at " + used.Rows(0)("at").ToString + ")")
        Else
            execute_non_query("UPDATE tb_sop_schedule SET id_departement = " + id_departement + ", `date` = '" + date_sch + "', time_start = '" + time_start + "', time_end = '" + time_end + "' WHERE id_sop_schedule = " + id_sop_schedule, True, "", "", "", "")

            FormSOPIndex.view_sop_schedule_admin()

            FormSOPIndex.GVScheduleAdmin.FocusedRowHandle = find_row(FormSOPIndex.GVScheduleAdmin, "id_sop_schedule", id_sop_schedule)

            infoCustom("Schedule edited.")

            Close()
        End If
    End Sub

    Private Sub FormSOPIndexScheduleEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class