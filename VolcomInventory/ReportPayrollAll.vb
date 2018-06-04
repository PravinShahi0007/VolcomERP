Public Class ReportPayrollAll
    Public Shared id_payroll As String = ""
    Public Shared dt As DataTable
    Public Shared no_column As Integer = 1
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayroll.DataSource = dt
        '
        LPeriode.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_name").ToString
        '
        GVPayroll.Columns("employee_code").Caption = "NIP" + vbNewLine + "(1)"
        GVPayroll.Columns("employee_name").Caption = "Name" + vbNewLine + "(2)"
        GVPayroll.Columns("departement").Caption = "Departement" + vbNewLine + "(3)"
        GVPayroll.Columns("employee_level").Caption = "Level" + vbNewLine + "(4)"
        GVPayroll.Columns("employee_position").Caption = "Position" + vbNewLine + "(5)"
        GVPayroll.Columns("employee_status").Caption = "Status" + vbNewLine + "(6)"
        GVPayroll.Columns("end_period").Caption = "Contract End" + vbNewLine + "(7)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(8)"
        GVPayroll.Columns("basic_salary").Caption = "Basic Salary" + vbNewLine + "(9)"
        GVPayroll.Columns("allow_job").Caption = "Job Allowance" + vbNewLine + "(10)"
        GVPayroll.Columns("allow_meal").Caption = "Meal Allowance" + vbNewLine + "(11)"
        GVPayroll.Columns("allow_trans").Caption = "Transport Allowance" + vbNewLine + "(12)"
        GVPayroll.Columns("allow_house").Caption = "Housing Allowance" + vbNewLine + "(13)"
        GVPayroll.Columns("allow_car").Caption = "Attendance Allowance" + vbNewLine + "(14)"
        GVPayroll.Columns("tot_thp").Caption = "THP Total" + vbNewLine + "(15)"
        Dim before_gb_column_number As Integer = no_column
        fix_column("reg_total_point", no_column)
        fix_column("reg_total_wages", no_column)
        fix_column("mkt_total_point", no_column)
        fix_column("mkt_total_wages", no_column)
        fix_column("ia_total_point", no_column)
        fix_column("ia_total_wages", no_column)
        fix_column("sales_total_point", no_column)
        fix_column("sales_total_wages", no_column)
        fix_column("prod_total_point", no_column)
        fix_column("prod_total_wages", no_column)
        fix_column("general_total_point", no_column)
        fix_column("general_total_wages", no_column)
        fix_column("total_ot_wages", no_column)
        If before_gb_column_number = no_column Then
            gridBandOT.Visible = False
        End If
        FormEmpPayroll.no_column = no_column
    End Sub

    Sub fix_column(ByVal column_name As String, ByRef column_number As Integer)
        If FormEmpPayroll.GVPayroll.Columns(column_name).SummaryItem.SummaryValue = 0 Then
            GVPayroll.Columns(column_name).Visible = False
        Else
            GVPayroll.Columns(column_name).Caption = GVPayroll.Columns(column_name).Caption + vbNewLine + "(" + column_number.ToString + ")"
            column_number += 1
        End If
    End Sub
End Class