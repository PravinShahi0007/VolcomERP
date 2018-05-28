Public Class ReportPayrollAll2
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

        Dim before_gb_column_number As Integer = 0
        'adjustment gv
        before_gb_column_number = no_column
        '
        fix_column("a_bonus", no_column)
        fix_column("a_adjustment", no_column)
        fix_column("a_rapel", no_column)
        fix_column("a_cuti", no_column)
        If no_column = before_gb_column_number Then
            gridBandBonusAdj.Visible = False
        End If
        'deduction gv
        before_gb_column_number = no_column
        '
        fix_column("d_jamsostek", no_column)
        fix_column("d_iuran_koperasi", no_column)
        fix_column("d_pinjaman_koperasi", no_column)
        fix_column("d_uniform", no_column)
        fix_column("d_wh_sale", no_column)
        fix_column("d_kasbon", no_column)
        fix_column("d_reiki", no_column)
        fix_column("d_spt", no_column)
        fix_column("d_tab_missing", no_column)
        fix_column("d_pot_lain", no_column)
        fix_column("total_deduction", no_column)

        If no_column = before_gb_column_number Then
            gridBandDeduction.Visible = False
        End If
        'grand total
        fix_column("grand_total", no_column)
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