Public Class FormSOPIndexSchedule
    Private Sub FormSOPIndexSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT id_departement, departement FROM tb_m_departement"

        viewSearchLookupQuery(SLUEDepartment, query, "id_departement", "departement", "id_departement")

        Dim date_now As String = execute_query("SELECT NOW()", 0, True, "", "", "", "")

        DEDate.EditValue = date_now.Substring(0, 10)
        DETimeStart.EditValue = "09:00"
        DETimeEnd.EditValue = "11:00"
    End Sub

    Private Sub FormSOPIndexSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim id_departement As String = SLUEDepartment.EditValue.ToString
        Dim date_sch As String = Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim time_start As String = DETimeStart.Text + ":00"
        Dim time_end As String = DETimeEnd.Text + ":00"

        Dim total_insert As String = execute_query("SELECT COUNT(*) FROM tb_sop_schedule WHERE `date` = '" + date_sch + "' AND (('" + time_start + "' > time_start AND '" + time_start + "' < time_end) OR ('" + time_end + "' > time_start AND '" + time_end + "' < time_end) OR ('" + time_start + "' <= time_start AND '" + time_end + "' >= time_end))", 0, True, "", "", "", "")

        If total_insert = "0" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_store As String = "INSERT INTO tb_sop_schedule (id_departement, `date`, time_start, time_end) VALUE ('" + id_departement + "', '" + date_sch + "', '" + time_start + "', '" + time_end + "')"

                execute_non_query(query_store, True, "", "", "", "")

                infoCustom("Schedule saved.")

                FormSOPIndex.view_sop_schedule_admin()

                Close()
            End If
        Else
            infoCustom("Please choose another date or time.")
        End If
    End Sub
End Class