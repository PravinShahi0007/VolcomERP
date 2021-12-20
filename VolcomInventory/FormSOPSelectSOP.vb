Public Class FormSOPSelectSOP
    Private Sub FormSOPSelectSOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT id_sop, 'no' AS is_checked, sop_number, sop_name
            FROM tb_sop
            WHERE id_departement = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_departement").ToString + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSOP.DataSource = data

        GVSOP.BestFitColumns()
    End Sub

    Private Sub FormSOPSelectSOP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPick_Click(sender As Object, e As EventArgs) Handles SBPick.Click
        GVSOP.ClearColumnsFilter()
        GVSOP.FindFilterText = ""

        GVSOP.ActiveFilterString = "[is_checked] = 'yes'"

        If GVSOP.RowCount > 0 Then
            execute_non_query("DELETE FROM tb_sop_schedule_sop WHERE id_sop_schedule = '" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString + "'", True, "", "", "", "")

            For i = 0 To GVSOP.RowCount - 1
                If GVSOP.IsValidRowHandle(i) Then
                    execute_non_query("INSERT INTO tb_sop_schedule_sop (id_sop_schedule, id_sop) VALUES ('" + FormSOPIndex.GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString + "', '" + GVSOP.GetRowCellValue(i, "id_sop").ToString + "')", True, "", "", "", "")
                End If
            Next

            FormSOPIndex.view_sop_schedule_admin()

            Close()
        Else
            stopCustom("No SOP Selected.")
        End If
    End Sub
End Class