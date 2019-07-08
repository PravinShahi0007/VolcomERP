Public Class FormEmpPayrollReportBPJSTK
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportBPJSTK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '== all ==
        Dim query_all As String = "
            SELECT 0 AS `no`, dep.departement, '=' AS equal, SUM(salary.employee_salary * 0.424) AS company_contribution_1, SUM(IF(ded.id_salary_deduction = 2, ded.deduction * 2, 0)) AS company_contribution_2, SUM(IF(ded.id_salary_deduction = 2, ded.deduction, 0)) AS employee_contribution_1, SUM(IF(ded.id_salary_deduction = 3, ded.deduction, 0)) AS employee_contribution_2
            FROM tb_emp_payroll_deduction AS ded
            LEFT JOIN tb_emp_payroll_det AS pay_det ON ded.id_employee = pay_det.id_employee AND pay_det.id_payroll = " + id_payroll + "
            LEFT JOIN  (
                SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans) AS employee_salary
                FROM tb_m_employee_salary
            ) AS salary ON pay_det.id_salary = salary.id_employee_salary
            LEFT JOIN tb_lookup_salary_deduction AS ded_lookup ON ded.id_salary_deduction = ded_lookup.id_salary_deduction
            LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
            WHERE ded.id_payroll = " + id_payroll + " AND ded_lookup.id_salary_deduction_cat = 1
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
        GCEmployeeSalary.Caption = "Upah " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")

        Dim query As String = "
            SELECT 0 AS `no`, dep.departement, emp.employee_bpjs_tk, emp.employee_name, IF(emp.id_sex = 1, 'L', 'P') AS employee_sex, DATE_FORMAT(emp.employee_dob, '%d/%c/%Y') AS employee_dob, '' AS kep_prog, salary.employee_salary, SUM(salary.employee_salary * 0.424) AS company_contribution_1, SUM(IF(ded.id_salary_deduction = 2, ded.deduction * 2, 0)) AS company_contribution_2, SUM(IF(ded.id_salary_deduction = 2, ded.deduction, 0)) AS employee_contribution_1, SUM(IF(ded.id_salary_deduction = 3, ded.deduction, 0)) AS employee_contribution_2, '' AS keterangan
            FROM tb_emp_payroll_deduction AS ded
            LEFT JOIN tb_emp_payroll_det AS pay_det ON ded.id_employee = pay_det.id_employee AND pay_det.id_payroll = " + id_payroll + "
            LEFT JOIN  (
            SELECT id_employee_salary, (basic_salary + allow_job + allow_meal + allow_trans) AS employee_salary
            FROM tb_m_employee_salary
            ) AS salary ON pay_det.id_salary = salary.id_employee_salary
            LEFT JOIN tb_lookup_salary_deduction AS ded_lookup ON ded.id_salary_deduction = ded_lookup.id_salary_deduction
            LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
            WHERE ded.id_payroll = " + id_payroll + " AND ded_lookup.id_salary_deduction_cat = 1
            GROUP BY emp.id_employee
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

    Private Sub FormEmpPayrollReportBPJSTK_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        'all
        Dim report As ReportEmpPayrollReportBPJSTK = New ReportEmpPayrollReportBPJSTK

        report.PrintingSystem.ContinuousPageNumbering = False

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.id_payroll = id_payroll
        report.data = GCAllDepartements.DataSource

        report.CreateDocument()

        'detail
        Dim report_detail As ReportEmpPayrollReportBPJSTKDetail = New ReportEmpPayrollReportBPJSTKDetail

        report_detail.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

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