Public Class FormEmpPayroll
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Private Sub FormEmpPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll()
    End Sub

    Sub load_payroll()
        Dim query As String = "SELECT pr.*,emp.`employee_name` FROM tb_emp_payroll pr
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
                                ORDER BY pr.periode_end DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCPayrollPeriode.DataSource = data
        '
        check_but()
    End Sub

    Sub check_but()
        If XTCPayroll.SelectedTabPageIndex = 0 Then
            If GVPayrollPeriode.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        End If
    End Sub

    Private Sub FormEmpPayroll_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        check_but()
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpPayroll_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpPayroll_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BOvertime_Click(sender As Object, e As EventArgs) Handles BOvertime.Click
        FormEmpPayrollOvertime.id_periode = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        FormEmpPayrollOvertime.ShowDialog()
    End Sub

    Private Sub BGetEmployee_Click(sender As Object, e As EventArgs) Handles BGetEmployee.Click
        FormEmpPayrollEmp.ShowDialog()
    End Sub

    Private Sub GVPayrollPeriode_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPayrollPeriode.FocusedRowChanged
        load_payroll_detail()
    End Sub

    Sub load_payroll_detail()
        If GVPayrollPeriode.RowCount > 0 Then
            Dim query As String = "CALL view_payroll('" & GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCPayroll.DataSource = data
            GVPayroll.BestFitColumns()
        End If
    End Sub

    Private Sub GVPayroll_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        If GVPayroll.RowCount > 0 And GVPayroll.FocusedRowHandle >= 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewPopWorksheet.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub CMDelEmp_Click(sender As Object, e As EventArgs) Handles CMDelEmp.Click
        Dim id_employee As String = GVPayroll.GetFocusedRowCellValue("id_employee").ToString
        Dim id_payroll As String = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        '
        Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_employee='" & id_employee & "' AND id_payroll='" & id_payroll & "'"
        execute_non_query(query, True, "", "", "", "")
        load_payroll_detail()
    End Sub

    Private Sub BDeduction_Click(sender As Object, e As EventArgs) Handles BDeduction.Click
        FormEmpPayrollDeduction.ShowDialog()
    End Sub

    Private Sub BSetting_Click(sender As Object, e As EventArgs) Handles BSetting.Click
        FormEmpPayrollSetup.ShowDialog()
    End Sub

    Private Sub BBonusAdjustment_Click(sender As Object, e As EventArgs) Handles BBonusAdjustment.Click
        FormEmpPayrollAdjustment.ShowDialog()
    End Sub

    Private Sub BRemoveEmployee_Click(sender As Object, e As EventArgs) Handles BRemoveEmployee.Click
        If GVPayroll.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                load_payroll_detail()
            End If
        End If
    End Sub

    Private Sub RICEPending_EditValueChanged(sender As Object, e As EventArgs) Handles RICEPending.EditValueChanged
        Dim cepending As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        If cepending.CheckState = True Then
            'pending
            Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_pending='1' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
            execute_non_query(query_upd, True, "", "", "", "")
        Else
            'not pending
            Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_pending='2' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
            execute_non_query(query_upd, True, "", "", "", "")
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVPayroll.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVPayroll.RowCount - 1) - GetGroupRowCount(GVPayroll))
                If cek = "no" Then
                    GVPayroll.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVPayroll.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub
End Class