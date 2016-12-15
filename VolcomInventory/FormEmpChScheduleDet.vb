Public Class FormEmpChScheduleDet
    Public id_ch_sch As String = "-1"
    Public id_employee As String = "-1"

    Public id_sch_to As String = "-1"
    Public id_sch_from As String = "-1"

    Private Sub FormEmpChScheduleDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_ch_sch = "-1" Then ' new
            TENumber.Text = header_number_emp("3")
            DEDate.EditValue = Now()
            '
            BPickEmployee.Visible = True
            BPickScheduleFrom.Visible = True
            BPickScheduleTo.Visible = True
            '
            BMark.Visible = False
            BPrint.Visible = False
            BSave.Visible = True
        Else 'edit
            Dim query As String = "SELECT * FROM tb_emp_ch_schedule"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TENumber.Text = data.Rows(0)("emp_ch_schedule_number").ToString
            DEDate.EditValue = data.Rows(0)("emp_ch_schedule_date")
            '
            BPickEmployee.Visible = False
            BPickScheduleFrom.Visible = False
            BPickScheduleTo.Visible = False
            '
            BMark.Visible = True
            BPrint.Visible = True
            BSave.Visible = False
        End If
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "4"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Private Sub FormEmpChScheduleDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            BPickScheduleFrom.Focus()
        End If
    End Sub
    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
        If FormEmpLeave.is_propose = "1" Then
            query += " AND dep.id_user_head='" & id_user & "'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            TEDept.Text = data.Rows(0)("departement").ToString
            TEPosition.Text = data.Rows(0)("employee_position").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            '
            id_sch_to = "-1"
            id_sch_from = "-1"
            load_sch("1")
            load_sch("2")
        Else
            stopCustom("No employee found.")
        End If
    End Sub
    Sub load_sch(ByVal opt As String)
        If opt = "1" Then
            If id_sch_from = "-1" Then
                'kosongkan
                TESchFCode.Text = Nothing
                TESchFNote.Text = Nothing
                DESchFDate.EditValue = Nothing
                DESchFIn.EditValue = Nothing
                DESchFOut.EditValue = Nothing
            Else
                Dim query As String = "SELECT * FROM tb_emp_schedule WHERE id_schedule='" & id_sch_from & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                '
                TESchFCode.Text = data.Rows(0)("shift_code").ToString
                TESchFNote.Text = data.Rows(0)("note").ToString
                DESchFDate.EditValue = data.Rows(0)("date")
                DESchFIn.EditValue = data.Rows(0)("in")
                DESchFOut.EditValue = data.Rows(0)("out")
            End If
        ElseIf opt = "2" Then
            If id_sch_to = "-1" Then
                'kosongkan
                TESchTCode.Text = Nothing
                TESchTNote.Text = Nothing
                DESchTDate.EditValue = Nothing
                DESchTIn.EditValue = Nothing
                DESchTOut.EditValue = Nothing
            Else
                Dim query As String = "SELECT * FROM tb_emp_schedule WHERE id_schedule='" & id_sch_to & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                '
                TESchTCode.Text = data.Rows(0)("shift_code").ToString
                TESchTNote.Text = data.Rows(0)("note").ToString
                DESchTDate.EditValue = data.Rows(0)("date")
                DESchTIn.EditValue = data.Rows(0)("in")
                DESchTOut.EditValue = data.Rows(0)("out")
            End If
        End If
    End Sub

    Private Sub BPickScheduleFrom_Click(sender As Object, e As EventArgs) Handles BPickScheduleFrom.Click
        FormEmpLeavePick.opt = "1"
        FormEmpLeavePick.id_employee = id_employee
        FormEmpLeavePick.ShowDialog()
        If Not id_sch_from = "-1" Then
            BPickScheduleTo.Focus()
        End If
    End Sub

    Private Sub BPickScheduleTo_Click(sender As Object, e As EventArgs) Handles BPickScheduleTo.Click
        FormEmpLeavePick.opt = "2"
        FormEmpLeavePick.id_employee = id_employee
        FormEmpLeavePick.ShowDialog()
        If Not id_sch_to = "-1" Then
            MEChNote.Focus()
        End If
    End Sub

    Private Sub FormEmpChScheduleDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TEEmployeeCode.Focus()
    End Sub

    Private Sub MEChNote_KeyDown(sender As Object, e As KeyEventArgs) Handles MEChNote.KeyDown
        If e.KeyCode = Keys.Multiply Or e.KeyCode = Keys.Tab Then
            BSave.Focus()
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_ch_sch = "-1" Then 'new
            If id_employee = "-1" Or id_sch_from = "-1" Or id_sch_to = "-1" Then
                stopCustom("Please check your input.")
            Else
                ' add parent
                Dim query As String = "INSERT INTo tb_emp_ch_schedule(id_employee,emp_ch_schedule_number,emp_ch_schedule_date,id_schedule_from,id_schedule_to,note) VALUES('" & id_employee & "','" & TENumber.Text & "',NOW(),'" & id_sch_from & "','" & id_sch_to & "','" & MEChNote.Text & "'); SELECT LAST_INSERT_ID(); "
                id_ch_sch = execute_query(query, 0, True, "", "", "", "")
                ' add detail
                query = "INSERT INTO tb_emp_ch_schedule_det(id_emp_ch_schedule,from_to,id_schedule,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code)
                            SELECT '" & id_ch_sch & "' AS id_emp_ch_schedule,'1' AS from_to,id_schedule,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code FROM tb_emp_schedule WHERE id_schedule='" & id_sch_from & "'
                            UNION
                            SELECT '" & id_ch_sch & "' AS id_emp_ch_schedule,'2' AS from_to,id_schedule,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code FROM tb_emp_schedule WHERE id_schedule='" & id_sch_to & "'"
                execute_non_query(query, True, "", "", "", "")
                '

                Close()
            End If
        Else

        End If
    End Sub
End Class