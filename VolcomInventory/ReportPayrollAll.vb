Public Class ReportPayrollAll
    Public Shared id_payroll As String = ""
    Public Shared dt As DataTable
    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayroll.DataSource = dt
        '
        GVPayroll.Columns("employee_code").Caption = "NIP" + vbNewLine + "(1)"
        GVPayroll.Columns("employee_name").Caption = "Name" + vbNewLine + "(2)"
        GVPayroll.Columns("departement").Caption = "Departement" + vbNewLine + "(3)"
        GVPayroll.Columns("employee_level").Caption = "Level" + vbNewLine + "(4)"
        GVPayroll.Columns("employee_position").Caption = "Position" + vbNewLine + "(5)"
        GVPayroll.Columns("employee_status").Caption = "Status" + vbNewLine + "(6)"
        GVPayroll.Columns("end_period").Caption = "Contract End" + vbNewLine + "(7)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(8)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(9)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(10)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(11)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(12)"
        GVPayroll.Columns("actual_workdays").Caption = "Actual Workdays" + vbNewLine + "(13)"
    End Sub
End Class