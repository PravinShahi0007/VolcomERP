Public Class FormEmpScheduleView
    Public id_employee As String = "-1"

    Private Sub FormEmpScheduleView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_date_edit()
        load_schedule()
        If FormEmpSchedule.is_security = "1" Then
            BTempSchedule.Visible = False
        End If
    End Sub

    Sub load_date_edit()
        Dim query As String = "SELECT MIN(`date`) as min_date,MAX(`date`) as max_date FROM tb_emp_schedule WHERE id_employee='" & id_employee & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim date_start, date_until As Date

        If Not IsDBNull(data.Rows(0)("min_date")) Then
            date_start = data.Rows(0)("min_date")
            date_until = data.Rows(0)("max_date")
        Else
            date_start = Now
            date_until = Now
        End If

        DEStart.EditValue = date_start
        DEUntil.EditValue = date_until
    End Sub

    Private Sub FormEmpScheduleView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub BTempSchedule_Click(sender As Object, e As EventArgs) Handles BTempSchedule.Click
        FormEmpScheduleViewSet.id_employee = id_employee
        FormEmpScheduleViewSet.ShowDialog()
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_schedule()
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

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub
End Class