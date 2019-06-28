﻿Public Class FormEmpPayrollAdjustment
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_adjustment()
    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT pya.id_payroll_adj,IF(adj.use_days = 2, '-', pya.total_days) AS total_days,pya.value,pya.increase,pya.note,emp.`employee_name`,emp.`employee_code`,emp.`employee_position`,dep.`departement`,adj.`salary_adjustment`,adjc.salary_adjustment_cat,lvl.`employee_status` FROM tb_emp_payroll_adj pya
                                INNER JOIN tb_m_employee emp ON pya.id_employee=emp.`id_employee`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=emp.`id_departement`
                                INNER JOIN `tb_lookup_employee_status` lvl ON lvl.`id_employee_status`=emp.`id_employee_status`
                                INNER JOIN `tb_lookup_salary_adjustment` adj ON adj.`id_salary_adjustment`=pya.`id_salary_adj`
                                INNER JOIN tb_lookup_salary_adjustment_cat adjc ON adjc.id_salary_adjustment_cat = adj.id_salary_adjustment_cat
                                WHERE pya.`id_payroll`='" & id_payroll & "'
                                ORDER BY emp.id_employee_status ASC, emp.`employee_code` ASC, adj.id_salary_adjustment_cat ASC, adj.`id_salary_adjustment` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            BAdd.Enabled = True
            'BEdit.Enabled = True
            BDel.Enabled = True
        Else
            BAdd.Enabled = False
            'BEdit.Enabled = False
            BDel.Enabled = False
        End If

        If id_report_status = "6" Then
            SBPrint.Enabled = True
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

    'Private Sub BEdit_Click(sender As Object, e As EventArgs)
    '    If GVDeduction.RowCount > 0 Then
    '        FormEmpPayrollAdjustmentDet.id_payroll_adj = GVDeduction.GetFocusedRowCellValue("id_payroll_adj").ToString
    '        FormEmpPayrollAdjustmentDet.ShowDialog()
    '    End If
    'End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVDeduction.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_emp_payroll_adj WHERE id_payroll_adj='" & GVDeduction.GetFocusedRowCellValue("id_payroll_adj") & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                load_adjustment()
            End If
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        'print office
        Dim report1 As ReportEmpPayrollDeduction = New ReportEmpPayrollDeduction

        report1.PrintingSystem.ContinuousPageNumbering = False

        report1.type = "adjustment"
        report1.id_payroll = id_payroll
        report1.is_office_payroll = "1"
        report1.id_pre = If(id_report_status = "6", "-1", "1")

        report1.XLTitle.Text = "Bonus / Adjustment"
        report1.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report1.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report1.XLLocation.Text = "Office"

        report1.CreateDocument()

        'print store
        Dim report2 As ReportEmpPayrollDeduction = New ReportEmpPayrollDeduction

        report2.type = "adjustment"
        report2.id_payroll = id_payroll
        report2.is_office_payroll = "2"
        report2.id_pre = If(id_report_status = "6", "-1", "1")

        report2.XLTitle.Text = "Bonus / Adjustment"
        report2.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report2.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report2.XLLocation.Text = "Store"

        report2.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        'report1
        For i = 0 To report1.Pages.Count - 1
            list.Add(report1.Pages(i))
        Next

        'report2
        For i = 0 To report2.Pages.Count - 1
            list.Add(report2.Pages(i))
        Next

        report1.Pages.AddRange(list)

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report1)

        tool.ShowPreview()
    End Sub
End Class