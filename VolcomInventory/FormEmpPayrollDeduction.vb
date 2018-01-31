Public Class FormEmpPayrollDeduction
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_deduction()
    End Sub

    Sub load_deduction()
        Dim query As String = "SELECT emp.`id_employee`,emp.`employee_code`,emp.`employee_name`,lvl.`id_employee_level`,pyd.`deduction`,sald.`description` FROM tb_emp_payroll_deduction pyd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                INNER JOIN `tb_lookup_salary_deduction` sald ON sald.`id_salary_deduction`=pyd.`id_salary_deduction`
                                WHERE pyd.`id_payroll`='" & id_payroll & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()
    End Sub

    Private Sub BBJamsostek_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBJamsostek.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all jamsostek deduction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_jamsostek(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BBKoperasi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBKoperasi.ItemClick

    End Sub
End Class