Public Class FormEmpLeaveDet
    Public id_emp_leave As String = "-1"
    Public id_employee As String = "-1"
    Private Sub FormEmpLeaveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TERemainingLeave.EditValue = 0
        TETotLeave.EditValue = 0
        TERemainingLeaveAfter.EditValue = 0

        load_emp_leave()
        load_but_calc()
    End Sub

    Sub load_remaining()
        Dim query As String = "SELECT id_emp,SUM(IF(plus_minus=1,qty,-qty))/60 AS qty,`type`,IF(`type`=1,'Leave','DP') as type_ket,date_expired FROM tb_emp_stock_leave
                                WHERE id_emp='" & id_employee & "'
                                GROUP BY id_emp,date_expired,`type`
                                HAVING SUM(IF(plus_minus=1,qty,-qty)) > 0"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLeaveRemaining.DataSource = data
        If data.Rows.Count > 0 Then
            TERemainingLeave.EditValue = GVLeaveRemaining.Columns("qty").SummaryItem.SummaryValue
        End If
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "1"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Sub load_but_calc()
        If GVLeaveDet.RowCount > 0 Then
            BDelLeave.Visible = True
        Else
            BDelLeave.Visible = False
        End If
        'calc
        If GVLeaveDet.RowCount > 0 Then
            TETotLeave.EditValue = GVLeaveDet.Columns("hours_total").SummaryItem.SummaryValue
            TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue - TETotLeave.EditValue
            'calculate fifo new only
            If id_emp_leave = "-1" And TERemainingLeaveAfter.EditValue > 0 And GVLeaveDet.RowCount > 0 And GVLeaveRemaining.RowCount > 0 Then
                Dim j As Integer = 0
                Dim jum_leave As Integer = GVLeaveDet.RowCount
                '
                For i As Integer = 0 To GVLeaveRemaining.RowCount - 1
                    Dim leave_remaining As Integer = 0
                    leave_remaining = GVLeaveRemaining.GetRowCellValue(i, "qty")
                    While leave_remaining > 0

                    End While
                Next
            End If
        Else
            TETotLeave.EditValue = 0
            TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue
        End If
    End Sub

    Private Sub BAddLeave_Click(sender As Object, e As EventArgs) Handles BAddLeave.Click
        If id_employee = "-1" Then
            stopCustom("Please choose employee first.")
        Else
            FormEmpLeavePick.id_schedule = "-1"
            FormEmpLeavePick.id_employee = id_employee
            FormEmpLeavePick.ShowDialog()
        End If
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
                TEDept.Text = data.Rows(0)("departement").ToString
                TEPosition.Text = data.Rows(0)("employee_position").ToString
                id_employee = data.Rows(0)("id_employee").ToString
                DEJoinDate.EditValue = data.Rows(0)("employee_join_date")
                load_remaining()
                load_emp_leave()
                load_but_calc()
            End If
        End If
    End Sub

    Sub load_emp_leave()
        Dim query As String = "SELECT id_emp_leave_det,id_schedule,datetime_start,datetime_until,IF(is_full_day=1,'yes','no') as is_full_day,minutes_total,(minutes_total/60) as hours_total FROM tb_emp_leave_det where id_emp_leave='" + id_emp_leave + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveDet.DataSource = data
    End Sub

    Private Sub BDelLeave_Click(sender As Object, e As EventArgs) Handles BDelLeave.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            GVLeaveDet.DeleteSelectedRows()
            load_but_calc()
        End If
    End Sub

    Private Sub FormEmpLeaveDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim query As String = ""

        If id_employee = "-1" Or TETotLeave.EditValue <= 0 Then
            stopCustom("Please check your input !")
        ElseIf TERemainingLeaveAfter.EditValue < 0
            stopCustom("Remaining Leave not sufficient.")
        Else

        End If
    End Sub
End Class