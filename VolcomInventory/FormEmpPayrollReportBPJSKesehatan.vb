Public Class FormEmpPayrollReportBPJSKesehatan
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportBPJSKesehatan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== all ==
        Dim query_all As String = "
            SELECT 0 AS `no`, dep.departement, SUM(salary.employee_salary * 0.04) AS company_contribution, SUM(salary.employee_salary * 0.01) AS employee_contribution, SUM(salary.employee_salary * 0.05) AS total_contribution
            FROM tb_emp_payroll_deduction AS ded
            LEFT JOIN tb_emp_payroll_det AS pay_det ON ded.id_employee = pay_det.id_employee AND pay_det.id_payroll = " + id_payroll + "
            LEFT JOIN  (
                SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans) AS employee_salary
                FROM tb_m_employee_salary
            ) AS salary ON pay_det.id_salary = salary.id_employee_salary
            LEFT JOIN tb_lookup_salary_deduction AS ded_lookup ON ded.id_salary_deduction = ded_lookup.id_salary_deduction
            LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
            WHERE ded.id_payroll = " + id_payroll + " AND ded_lookup.id_salary_deduction_cat = 2
            GROUP BY emp.id_departement
            ORDER BY dep.departement ASC
        "

        Dim data_all As DataTable = execute_query(query_all, -1, True, "", "", "", "")

        GCAllDepartements.DataSource = data_all

        'number
        For i = 0 To GVAllDepartements.RowCount - 1
            If GVAllDepartements.IsValidRowHandle(i) Then
                GVAllDepartements.SetRowCellValue(i, "no", i + 1)
            End If
        Next

        GVAllDepartements.BestFitColumns()

        '== detail ==
        Dim query As String = "
            SELECT dep.departement, 0 AS no, emp.employee_name, emp.employee_bpjs_kesehatan, DATE_FORMAT(emp.employee_dob, '%d %M %Y') AS employee_dob, salary.employee_salary, salary.employee_salary * 0.04 AS company_contribution, salary.employee_salary * 0.01 AS employee_contribution, salary.employee_salary * 0.05 AS total_contribution, IF(salary.employee_salary > pay.bpjs_max_kelas_2, 'I', 'II') AS class
            FROM tb_emp_payroll_deduction AS ded
            LEFT JOIN tb_emp_payroll AS pay ON ded.id_payroll = pay.id_payroll
            LEFT JOIN tb_emp_payroll_det AS pay_det ON ded.id_employee = pay_det.id_employee AND pay_det.id_payroll = " + id_payroll + "
            LEFT JOIN  (
                SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans) AS employee_salary
                FROM tb_m_employee_salary
            ) AS salary ON pay_det.id_salary = salary.id_employee_salary
            LEFT JOIN tb_lookup_salary_deduction AS ded_lookup ON ded.id_salary_deduction = ded_lookup.id_salary_deduction
            LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
            WHERE ded.id_payroll = " + id_payroll + " AND ded_lookup.id_salary_deduction_cat = 2
            GROUP BY ded.id_employee
            ORDER BY dep.departement ASC, emp.id_employee_level ASC, emp.employee_code
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        'number
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                GVEmployee.SetRowCellValue(i, "no", i + 1)
            End If
        Next

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportBPJSKesehatan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim query As String = "SELECT ump, bpjs_max, bpjs_max_kelas_2 FROM tb_emp_payroll WHERE id_payroll = " + id_payroll

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim query_opt As String = "SELECT bpjs_virtual_acc_1, bpjs_virtual_acc_2 FROM tb_opt"

        Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        'all
        Dim report As ReportEmpPayrollReportBPJSKesehatan = New ReportEmpPayrollReportBPJSKesehatan

        report.PrintingSystem.ContinuousPageNumbering = False

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.id_payroll = id_payroll
        report.data = GCAllDepartements.DataSource

        report.CreateDocument()

        'detail
        Dim report_detail As ReportEmpPayrollReportBPJSKesehatanDetail = New ReportEmpPayrollReportBPJSKesehatanDetail

        report_detail.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper
        report_detail.XLKodeBU.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Substring(data_opt.Rows(0)("bpjs_virtual_acc_1").ToString.Length - 8)
        report_detail.XLVirtualAcc.Text = data_opt.Rows(0)("bpjs_virtual_acc_1").ToString
        report_detail.XLMaxKelas1.Text = Format(data.Rows(0)("bpjs_max"), "##,##0")
        report_detail.XLMaxKelas2.Text = Format(data.Rows(0)("bpjs_max_kelas_2"), "##,##0")
        report_detail.XLUMK.Text = Format(data.Rows(0)("ump"), "##,##0")

        report_detail.id_pre = If(id_report_status = "6", "-1", "1")
        report_detail.id_payroll = id_payroll
        report_detail.data = GCEmployee.DataSource

        report_detail.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To report.Pages.Count - 1
            list.Add(report.Pages(i))
        Next

        For i = 0 To report_detail.Pages.Count - 1
            list.Add(report_detail.Pages(i))
        Next

        report.Pages.AddRange(list)

        Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool_detail.ShowPreview()
    End Sub
End Class