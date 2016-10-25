Public Class FormEmpLeavePick
    Public id_schedule As String = "-1"
    Public id_employee As String = "-1"
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpLeavePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_schedule()
        GVSchedule.BestFitColumns()
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
        If GVSchedule.RowCount > 0 Then
            DEStartLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
            DEStartLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
            DEStartLeave.EditValue = GVSchedule.GetFocusedRowCellValue("in")

            DEUntilLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
            DEUntilLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
            DEUntilLeave.EditValue = GVSchedule.GetFocusedRowCellValue("out")
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

    End Sub
End Class