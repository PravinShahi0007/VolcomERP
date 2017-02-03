Public Class FormEmpAttnAssignDet
    Public id_emp_assign_sch As String = "-1"
    Public date_from As Date = Now
    Public date_until As Date = Now
    Private Sub FormEmpAttnAssignDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_emp_assign_sch = "-1" Then 'new
            Dim query As String = "SELECT emp.employee_name,emp.employee_code,dep.departement FROM tb_m_employee emp
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    WHERE id_employee='" & id_employee_user & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEEmpCode.Text = data.Rows(0)("employee_code").ToString
            TEEmpName.Text = data.Rows(0)("employee_name").ToString
            TEDepartement.Text = data.Rows(0)("departement").ToString

            DEDate.EditValue = Now
            TENumber.Text = header_number_emp("4")

            '
            FormEmpScheduleTableSet.opt = "2"
            FormEmpScheduleTableSet.ShowDialog()
        Else

        End If
    End Sub

    Private Sub FormEmpAttnAssignDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BViewShift_Click(sender As Object, e As EventArgs) Handles BViewShift.Click
        FormEmpAttnAssignShift.ShowDialog()
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        Cursor = Cursors.WaitCursor
        If id_emp_assign_sch = "-1" Then 'new
            Dim query As String = ""
            Dim date_fromp As String = Date.Parse(date_from.ToString).ToString("yyyy-MM-dd")
            Dim date_untilp As String = Date.Parse(date_until.ToString).ToString("yyyy-MM-dd")
            'add header
            query = "INSERT INTO tb_emp_assign_sch(assign_sch_number,assign_sch_date,id_departement,date_from,date_until,id_user_propose,id_report_status,note) 
                    VALUES('" & header_number_emp("4") & "',NOW(),'" & id_departement_user & "','" & date_fromp & "','" & date_untilp & "','" & id_user & "',1,'" & MENote.Text & "'); SELECT LAST_INSERT_ID(); "
            id_emp_assign_sch = execute_query(query, 0, True, "", "", "", "")
            increase_inc_emp("4")
            'detail
            query = ""
            'detail before
            For i As Integer = 0 To GVScheduleBefore.RowCount - 1
                For j As Integer = 0 To GVScheduleBefore.Columns.Count - 1
                    If Not (GVScheduleBefore.Columns(j).FieldName = "id_employee" Or GVScheduleBefore.Columns(j).FieldName = "employee_code" Or GVScheduleBefore.Columns(j).FieldName = "employee_name") Then
                        Dim shift_code As String = GVScheduleBefore.GetRowCellValue(i, GVScheduleBefore.Columns(j).FieldName.ToString).ToString
                        If Not shift_code = "" Then
                            query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code)
                                    SELECT '" & id_emp_assign_sch & "' AS id_emp_assign_sch,'1' AS `type`,'" & GVScheduleBefore.GetRowCellValue(i, "id_employee").ToString & "' AS id_employee,'" & GVScheduleBefore.Columns(j).FieldName.ToString & "' AS `date`
                                    ,s.start_work AS `in`,s.end_work AS `out`,s.late_start_tolerance AS `in_tolerance`
                                    ,s.start_break AS break_out,s.end_break AS break_in
                                    ,s.minutes_work,IF('" & shift_code & "'='OFF',2,1) AS id_schedule_type,s.shift_name AS note,s.shift_code
                                    FROM tb_emp_shift s WHERE s.shift_code='" & shift_code & "' LIMIT 1;"
                        End If
                    End If
                Next
            Next
            'detail after
            For i As Integer = 0 To GVScheduleAfter.RowCount - 1
                For j As Integer = 0 To GVScheduleAfter.Columns.Count - 1
                    If Not (GVScheduleAfter.Columns(j).FieldName = "id_employee" Or GVScheduleAfter.Columns(j).FieldName = "employee_code" Or GVScheduleAfter.Columns(j).FieldName = "employee_name") Then
                        Dim shift_code As String = GVScheduleAfter.GetRowCellValue(i, GVScheduleAfter.Columns(j).FieldName.ToString).ToString
                        If shift_code = "" Then
                            shift_code = "OFF"
                        End If
                        query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code)
                                    SELECT '" & id_emp_assign_sch & "' AS id_emp_assign_sch,'2' AS `type`,'" & GVScheduleAfter.GetRowCellValue(i, "id_employee").ToString & "' AS id_employee,'" & GVScheduleAfter.Columns(j).FieldName.ToString & "' AS `date`
                                    ,s.start_work AS `in`,s.end_work AS `out`,s.late_start_tolerance AS `in_tolerance`
                                    ,s.start_break AS break_out,s.end_break AS break_in
                                    ,s.minutes_work,IF('" & shift_code & "'='OFF',2,1) AS id_schedule_type,s.shift_name AS note,s.shift_code
                                    FROM tb_emp_shift s WHERE s.shift_code='" & shift_code & "' LIMIT 1;"
                    End If
                Next
            Next
            execute_non_query(query, True, "", "", "", "")
            submit_who_prepared("100", id_emp_assign_sch, id_user)
            infoCustom("Change schedule proposed. Waiting approval.")
            Close()
        End If
    End Sub
End Class