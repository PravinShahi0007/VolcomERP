Public Class FormEmpLeaveDet
    Public id_emp_leave As String = "-1"
    Public id_employee As String = "-1"
    Private Sub FormEmpLeaveDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TERemainingLeave.EditValue = 0
        TETotLeave.EditValue = 0
        TERemainingLeaveAfter.EditValue = 0

        load_emp_leave()
        load_but_calc()
        load_emp_leave_usage()
        '
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
                Dim total_leave As Integer = TETotLeave.EditValue
                '
                clear_grid()
                '
                For i As Integer = 0 To GVLeaveRemaining.RowCount - 1
                    Dim leave_remaining As Integer = 0
                    leave_remaining = GVLeaveRemaining.GetRowCellValue(i, "qty")
                    If total_leave - leave_remaining > 0 Then
                        'use row qty = leave_remaining
                        Dim newRow As DataRow = (TryCast(GCLeaveUsage.DataSource, DataTable)).NewRow()
                        newRow("type") = GVLeaveRemaining.GetRowCellValue(i, "type").ToString
                        newRow("type_ket") = GVLeaveRemaining.GetRowCellValue(i, "type_ket").ToString
                        newRow("date_expired") = GVLeaveRemaining.GetRowCellValue(i, "date_expired")
                        newRow("qty") = GVLeaveRemaining.GetRowCellValue(i, "qty")

                        TryCast(GCLeaveUsage.DataSource, DataTable).Rows.Add(newRow)
                        GCLeaveUsage.RefreshDataSource()
                        '
                        total_leave = total_leave - leave_remaining
                    Else
                        'use row with qty = total leave
                        Dim newRow As DataRow = (TryCast(GCLeaveUsage.DataSource, DataTable)).NewRow()
                        newRow("type") = GVLeaveRemaining.GetRowCellValue(i, "type").ToString
                        newRow("type_ket") = GVLeaveRemaining.GetRowCellValue(i, "type_ket").ToString
                        newRow("date_expired") = GVLeaveRemaining.GetRowCellValue(i, "date_expired")
                        newRow("qty") = total_leave

                        TryCast(GCLeaveUsage.DataSource, DataTable).Rows.Add(newRow)
                        GCLeaveUsage.RefreshDataSource()
                        '
                        total_leave = 0
                        Exit For
                    End If
                Next
            End If
        Else
            TETotLeave.EditValue = 0
            TERemainingLeaveAfter.EditValue = TERemainingLeave.EditValue
        End If
    End Sub

    Sub clear_grid()
        For i As Integer = GVLeaveUsage.RowCount - 1 To 0 Step -1
            GVLeaveUsage.DeleteRow(i)
        Next
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
                '
                If Not XTCDet.SelectedTabPageIndex = 1 Then
                    XTCDet.SelectedTabPageIndex = 1
                Else
                    XTCDet.SelectedTabPageIndex = 0
                    BAddLeave.Focus()
                End If
            End If
        End If
    End Sub

    Sub load_emp_leave()
        Dim query As String = "SELECT id_emp_leave_det,id_schedule,datetime_start,datetime_until,IF(is_full_day=1,'yes','no') as is_full_day,minutes_total,(minutes_total/60) as hours_total FROM tb_emp_leave_det where id_emp_leave='" + id_emp_leave + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveDet.DataSource = data
    End Sub

    Sub load_emp_leave_usage()
        Dim query As String = "SELECT id_emp_leave_usage,type,IF(`type`=1,'Leave','DP') as type_ket,date_expired,(qty/60) as qty FROM tb_emp_leave_usage where id_emp_leave='" + id_emp_leave + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLeaveUsage.DataSource = data
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

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BRecalculate_Click(sender As Object, e As EventArgs) Handles BRecalculate.Click
        load_but_calc()
    End Sub

    Private Sub FormEmpLeaveDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TEEmployeeCode.Focus()
    End Sub
End Class