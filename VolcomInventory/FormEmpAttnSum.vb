Public Class FormEmpAttnSum
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_report()
    End Sub
    Sub load_report()
        Dim date_start, date_until, dept As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        If LEDept.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDept.EditValue.ToString
        End If

        Dim query As String = ""
        query = "SELECT tb.*,(tb.over-tb.late-tb.over_break) AS balance,IF(NOT ISNULL(tb.att_in) AND NOT ISNULL()) as present FROM"
        query += " ("
        query += " SELECT sch.id_employee,emp.employee_name,sch.date,"
        query += " sch.In,sch.in_tolerance,at_in.datetime As `att_in`,"
        query += " sch.out,at_out.datetime AS `att_out`,"
        query += " sch.break_out,at_brout.datetime As start_break,"
        query += " sch.break_in,at_brin.datetime AS end_break,"
        query += " scht.schedule_type,note"
        query += " ,IF(at_in.datetime>sch.in_tolerance,TIMESTAMPDIFF(MINUTE,sch.in_tolerance,at_in.datetime),0) AS late"
        query += " ,If(at_out.datetime>sch.out,TIMESTAMPDIFF(MINUTE,sch.out,at_out.datetime),0) As over"
        query += " ,IF(TIMESTAMPDIFF(MINUTE,at_brout.datetime,at_brin.datetime)>TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),TIMESTAMPDIFF(MINUTE,at_brout.datetime,at_brin.datetime)-TIMESTAMPDIFF(MINUTE,sch.break_out,sch.break_in),0) AS over_break"
        query += " ,TIMESTAMPDIFF(MINUTE,at_in.datetime,at_out.datetime) As actual_work_hour"
        query += " ,TIMESTAMPDIFF(MINUTE,IF(at_in.datetime<sch.in,sch.in,IF(at_in.datetime<sch.in_tolerance,sch.in,at_in.datetime)),IF(at_out.datetime>sch.out,sch.out,at_out.datetime)) AS work_hour"
        query += " FROM tb_emp_schedule sch"
        query += " INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee"
        query += " INNER JOIN tb_lookup_schedule_type scht On scht.id_schedule_type=sch.id_schedule_type"
        query += " LEFT JOIN tb_emp_attn at_in On at_in.id_employee=sch.id_employee And Date(at_in.datetime) = sch.Date And at_in.type_log = 1"
        query += " LEFT JOIN tb_emp_attn at_out On at_out.id_employee=sch.id_employee And Date(at_out.datetime) = sch.Date And at_out.type_log = 2"
        query += " LEFT JOIN tb_emp_attn at_brout On at_brout.id_employee=sch.id_employee And Date(at_brout.datetime) = sch.Date And at_brout.type_log = 3"
        query += " LEFT JOIN tb_emp_attn at_brin On at_brin.id_employee=sch.id_employee And Date(at_brin.datetime) = sch.Date And at_brin.type_log = 4"
        query += " WHERE emp.id_departement LIKE '" & dept & "'"
        query += " AND sch.date >='" & date_start & "'"
        query += " AND sch.date <='" & date_until & "'"
        query += " ) tb"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
        GVSchedule.ExpandAllGroups()
    End Sub

    Private Sub FormEmpAttnSum_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnSum_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
    End Sub

    Sub viewDept()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION (SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
    End Sub
End Class