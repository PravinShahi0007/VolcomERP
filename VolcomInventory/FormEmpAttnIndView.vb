Public Class FormEmpAttnIndView
    Public id_employee As String = "-1"

    Private Sub FormEmpAttnIndView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Sub load_report()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = ""
        query = "SELECT sch.id_employee,sch.date,"
        query += " sch.in,sch.in_tolerance,at_in.datetime AS `start_work`,sch.in_tolerance,"
        query += " sch.out,at_out.datetime,at_out.datetime As `end_work`,"
        query += " sch.break_out,at_brin.datetime AS start_break,"
        query += " sch.break_in,at_brout.datetime As end_break"
        query += " ,scht.schedule_type,sch.note"
        query += " FROM tb_emp_schedule sch"
        query += " INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type"
        query += " LEFT JOIN tb_emp_attn at_in On at_in.id_employee=sch.id_employee And Date(at_in.datetime) = sch.Date And at_in.type_log = 1"
        query += " LEFT JOIN tb_emp_attn at_out ON at_out.id_employee=sch.id_employee AND DATE(at_out.datetime) = sch.date AND at_out.type_log = 2"
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 3"
        query += " LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee=sch.id_employee AND DATE(at_brout.datetime) = sch.date AND at_brout.type_log = 4"
        query += " WHERE sch.id_employee='" & id_employee & "'"
        query += " AND sch.date >='" & date_start & "'"
        query += " AND sch.date <='" & date_until & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_report()
    End Sub

    Private Sub FormEmpAttnIndView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        load_report()
    End Sub
End Class