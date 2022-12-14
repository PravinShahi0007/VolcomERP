Public Class FormEmpPayrollAdjustment
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

        If is_thr = "1" Then
            GridColumnTotDays.Caption = "Total Years"
        Else
            GridColumnTotDays.Caption = "Total Days"
        End If

        load_adjustment()
    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT 0 as no, 'no' AS is_check, pya.id_payroll_adj,IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) AS is_office_payroll,IF(IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) = '2', 'STORE', 'OFFICE') AS group_report,IF(adj.use_days = 2, '-', pya.total_days) AS total_days,pya.value,pya.increase,pya.note,emp.`employee_name`,emp.`employee_code`,IFNULL(emp_pos.employee_position,emp.`employee_position`) AS employee_position,IFNULL(dep.departement, dep_ori.departement) AS departement,IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS departement_sub,adj.`salary_adjustment`,adjc.salary_adjustment_cat,IFNULL(sts.`employee_status`, sts_ori.`employee_status`) AS employee_status FROM tb_emp_payroll_adj pya
            LEFT JOIN tb_m_employee emp ON pya.id_employee=emp.`id_employee`
            LEFT JOIN (
                SELECT * FROM (
                    SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                    FROM tb_m_employee_position
                    WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "')
                    ORDER BY id_employee_position DESC
                ) AS tab
                GROUP BY id_employee
            ) AS emp_pos ON pya.id_employee = emp_pos.id_employee
            LEFT JOIN tb_m_departement dep ON dep.`id_departement`=emp_pos.`id_departement`
            LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
            LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
            LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
            LEFT JOIN (
                SELECT * FROM (
                    SELECT det.*, lookup.employee_status 
                    FROM tb_m_employee_status_det AS det
                    LEFT JOIN tb_lookup_employee_status AS lookup ON det.id_employee_status = lookup.id_employee_status
                    LEFT JOIN tb_m_employee AS emp ON det.id_employee = emp.id_employee
		            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                    WHERE det.start_period <= IF(dep.is_store = 2, (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "'), (SELECT store_periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "'))
                    ORDER BY det.id_employee_status_det DESC
                ) AS tab
                GROUP BY id_employee
            ) AS sts ON pya.id_employee = sts.id_employee
            LEFT JOIN `tb_lookup_employee_status` sts_ori ON sts_ori.`id_employee_status`=emp.`id_employee_status`
            LEFT JOIN `tb_lookup_salary_adjustment` adj ON adj.`id_salary_adjustment`=pya.`id_salary_adj`
            LEFT JOIN tb_lookup_salary_adjustment_cat adjc ON adjc.id_salary_adjustment_cat = adj.id_salary_adjustment_cat
            WHERE pya.`id_payroll`='" & id_payroll & "' AND pya.id_employee IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "')
            ORDER BY emp.id_employee_level ASC, emp.`employee_code` ASC, adj.id_salary_adjustment_cat ASC, adj.`id_salary_adjustment` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            BDel.Enabled = True
            SBPrint.Enabled = False

            BtnDropQuickMenu.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            BDel.Enabled = False
            SBPrint.Enabled = True

            BtnDropQuickMenu.Enabled = False
        End If

        'view
        If FormEmpPayroll.is_view = "1" Then
            BDel.Enabled = False
            BEdit.Enabled = False
            BAdd.Enabled = False
        End If
    End Sub

    Private Sub FormEmpPayrollAdjustment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormEmpPayrollDeductionDet.id_popup = "2"
        FormEmpPayrollDeductionDet.id_payroll = id_payroll

        FormEmpPayrollDeductionDet.ShowDialog()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        GVDeduction.ActiveFilterString = "[is_check]='yes'"

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If GVDeduction.RowCount > 0 Then
            If confirm = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                For i = 0 To GVDeduction.RowCount - 1
                    If GVDeduction.IsValidRowHandle(i) Then
                        Dim query As String = "DELETE FROM tb_emp_payroll_adj WHERE id_payroll_adj='" & GVDeduction.GetRowCellValue(i, "id_payroll_adj").ToString & "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                load_adjustment()

                Cursor = Cursors.Default
            End If
        Else
            stopCustom("Please choose employee first.")
        End If

        GVDeduction.ActiveFilterString = ""
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim data As DataTable = GCDeduction.DataSource

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        'report
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

        Dim report As ReportEmpPayrollDeduction = New ReportEmpPayrollDeduction

        report.type = "adjustment"
        report.id_payroll = id_payroll
        report.id_pre = If(id_report_status = "6", "-1", "1")

        report.XLTitle.Text = If(is_thr = "1", "Adjustment", "Bonus / Adjustment")
        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString

        If is_thr = "1" Then
            report.XLPeriod.Text = "Period " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
        End If

        If Not already_office Then
            report.DetailReportOffice.Visible = False

            report.DetailReportStore.Level = 0
            report.DetailReportStore.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        If Not already_store Then
            report.DetailReportStore.Visible = False

            report.DetailReportOffice.Level = 0
            report.DetailReportOffice.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormEmpPayrollDeductionDet.id = GVDeduction.GetFocusedRowCellValue("id_payroll_adj")
        FormEmpPayrollDeductionDet.id_popup = "2"
        FormEmpPayrollDeductionDet.id_payroll = id_payroll

        FormEmpPayrollDeductionDet.ShowDialog()
    End Sub

    Private Sub GVDeduction_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVDeduction.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        Dim format As StringFormat = e.Appearance.GetStringFormat.Clone

        format.Alignment = StringAlignment.Near

        If GVDeduction.GetGroupRowDisplayText(e.RowHandle).Contains("Group") Then
            e.Graphics.DrawString("Grand Total: " + GVDeduction.GetGroupRowValue(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
        Else
            If GVDeduction.GetGroupRowDisplayText(e.RowHandle).Contains("SOGO") Then
                e.Graphics.DrawString("Total " + GVDeduction.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
            Else
                If Not GVDeduction.GetGroupRowDisplayText(e.RowHandle).Contains("Sub") Then
                    e.Graphics.DrawString("Total " + GVDeduction.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub GVDeduction_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVDeduction.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Sub Departement") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub

    Private Sub GVDeduction_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVDeduction.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.Caption = "Sub Departement" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub GVDeduction_RowCountChanged(sender As Object, e As EventArgs) Handles GVDeduction.RowCountChanged
        Dim j As Integer = 0

        For i = 0 To GVDeduction.RowCount - 1
            If GVDeduction.IsValidRowHandle(i) Then
                j = j + 1

                GVDeduction.SetRowCellValue(i, "no", j)
            End If
        Next
    End Sub

    Private Sub BarButtonItemRemainingLeave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemRemainingLeave.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all Remaining Leave ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_remaining_leave(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_adjustment()
        End If
    End Sub
End Class