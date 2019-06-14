Public Class FormEmpPayrollDeduction
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_deduction()
    End Sub

    Sub load_deduction()
        Dim query As String = "SELECT pyd.id_payroll_deduction,IF(sald.use_days = 2, '-', pyd.total_days) AS total_days,emp.`id_employee`,dep.`departement`,emp.`employee_code`,emp.`employee_name`,emp.`employee_position`,lvl.`employee_level`,pyd.`deduction`,sald.`salary_deduction`,saldc.salary_deduction_cat,pyd.note FROM tb_emp_payroll_deduction pyd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
                                INNER jOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                INNER JOIN `tb_lookup_salary_deduction` sald ON sald.`id_salary_deduction` = pyd.`id_salary_deduction`
                                INNER JOIN tb_lookup_salary_deduction_cat saldc ON saldc.id_salary_deduction_cat = sald.id_salary_deduction_cat
                                WHERE pyd.`id_payroll`='" & id_payroll & "'
                                ORDER BY emp.`id_employee_level` ASC, emp.`employee_code` ASC, sald.`id_salary_deduction_cat` ASC, sald.`id_salary_deduction` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            BAdd.Enabled = True
            'BEdit.Enabled = True
            BDel.Enabled = True

            BtnDropQuickMenu.Enabled = True
            DropDownButton1.Enabled = True
        Else
            BAdd.Enabled = False
            'BEdit.Enabled = False
            BDel.Enabled = False

            BtnDropQuickMenu.Enabled = False
            DropDownButton1.Enabled = False
        End If

        If id_report_status = "6" Then
            SBPrint.Enabled = True
        End If
    End Sub

    Private Sub BBJamsostek_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBJamsostek.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all BPJSTK & BPJS Kesehatan ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_jamsostek(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BBKoperasi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBKoperasi.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all Cooperative Contribution ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_koperasi(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_emp_payroll_deduction WHERE id_payroll_deduction='" & GVDeduction.GetFocusedRowCellValue("id_payroll_deduction") & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    'Private Sub BEdit_Click(sender As Object, e As EventArgs)
    '   FormEmpPayrollDeductionDet.id_payroll = id_payroll
    '   FormEmpPayrollDeductionDet.id_payroll_deduction = GVDeduction.GetFocusedRowCellValue("id_payroll_deduction").ToString
    '   FormEmpPayrollDeductionDet.id_employee = GVDeduction.GetFocusedRowCellValue("id_employee").ToString

    '   FormEmpPayrollDeductionDet.ShowDialog()
    'End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormEmpPayrollDeductionDet.id_popup = "1"
        FormEmpPayrollDeductionDet.id_payroll = id_payroll

        FormEmpPayrollDeductionDet.ShowDialog()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        FormImportExcel.id_pop_up = "36"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub FormEmpPayrollDeduction_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormEmpPayroll.load_payroll_detail()

        Dispose()
    End Sub

    Function find_datatable(data As DataTable, column As String, value As String) As Integer
        Dim out As Integer = 0

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)(column).ToString = value Then
                out = i
            End If
        Next

        Return out
    End Function

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        'get column
        Dim query_column As String = "
            (
                SELECT tb.id_salary_deduction_cat, tb.id_salary_deduction, tb.salary_deduction_cat, tb.salary_deduction, MAX(tb.total) AS total
                FROM (
                    SELECT sald.id_salary_deduction_cat, sald.id_salary_deduction, saldc.salary_deduction_cat, sald.salary_deduction, COUNT(sald.id_salary_deduction) AS total
                    FROM tb_emp_payroll_deduction pyd
                    INNER JOIN tb_lookup_salary_deduction sald ON sald.id_salary_deduction=pyd.id_salary_deduction
                    INNER JOIN tb_lookup_salary_deduction_cat saldc ON saldc.id_salary_deduction_cat=sald.id_salary_deduction_cat
                    WHERE pyd.id_payroll='" + id_payroll + "'
                    GROUP BY pyd.id_employee, sald.id_salary_deduction
                    ORDER BY sald.id_salary_deduction_cat ASC, sald.id_salary_deduction ASC
                ) AS tb
                GROUP BY tb.salary_deduction
                ORDER BY tb.id_salary_deduction_cat ASC, tb.id_salary_deduction ASC
            )
            UNION
            (
                SELECT 99 AS id_salary_deduction_cat, 99 AS id_salary_deduction, 'Total' AS salary_deduction_cat, 'Total' AS salary_deduction, 1 AS total
            ) 
            ORDER BY id_salary_deduction_cat ASC, id_salary_deduction ASC
        "

        Dim data_column As DataTable = execute_query(query_column, -1, True, "", "", "", "")

        'employee
        Dim query_employee As String = "
            SELECT dep.departement,emp.employee_code,emp.employee_name,emp.employee_position,lvl.employee_level,
                GROUP_CONCAT(sald.salary_deduction ORDER BY sald.id_salary_deduction_cat ASC, sald.id_salary_deduction ASC) AS salary_deduction_c,
	            GROUP_CONCAT(ROUND(pyd.deduction, 0) ORDER BY sald.id_salary_deduction_cat ASC, sald.id_salary_deduction ASC) AS salary_deduction_v
            FROM tb_emp_payroll_deduction AS pyd
            INNER JOIN tb_m_employee emp ON emp.id_employee=pyd.id_employee
            INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
            INNER JOIN tb_lookup_salary_deduction sald ON sald.id_salary_deduction=pyd.id_salary_deduction
            INNER JOIN tb_lookup_salary_deduction_cat saldc ON saldc.id_salary_deduction_cat=sald.id_salary_deduction_cat
            WHERE pyd.id_payroll='" + id_payroll + "'
            GROUP BY pyd.id_employee
            ORDER BY emp.id_employee_level ASC, emp.employee_code ASC        
        "

        Dim data_employee As DataTable = execute_query(query_employee, -1, True, "", "", "", "")

        'data
        Dim data As DataTable = New DataTable()

        data.Columns.Add("Departement", GetType(String))
        data.Columns.Add("NIP", GetType(String))
        data.Columns.Add("Employee", GetType(String))
        data.Columns.Add("Employee Position", GetType(String))
        data.Columns.Add("Employee Level", GetType(String))

        For i = 0 To data_column.Rows.Count - 1
            Dim salary_deduction As String = data_column.Rows(i)("salary_deduction").ToString

            For j = 1 To data_column.Rows(i)("total")
                Dim column As DataColumn = New DataColumn()

                column.ColumnName = salary_deduction + " " + j.ToString
                column.DataType = GetType(Integer)
                column.DefaultValue = 0

                data.Columns.Add(column)
            Next
        Next

        'insert to data
        For i = 0 To data_employee.Rows.Count - 1
            Dim row As DataRow = data.NewRow

            row("Departement") = data_employee.Rows(i)("departement").ToString
            row("NIP") = data_employee.Rows(i)("employee_code").ToString
            row("Employee") = data_employee.Rows(i)("employee_name").ToString
            row("Employee Position") = data_employee.Rows(i)("employee_position").ToString
            row("Employee Level") = data_employee.Rows(i)("employee_level").ToString

            Dim column As String() = Split(data_employee.Rows(i)("salary_deduction_c").ToString, ",")
            Dim value As String() = Split(data_employee.Rows(i)("salary_deduction_v").ToString, ",")

            Dim first_column As String = ""

            Dim k As Integer = 1

            Dim total As Integer = 0

            For j = 0 To column.Count - 1
                If first_column = column(j).ToString Then
                    k = k + 1
                Else
                    k = 1
                End If

                Dim row_column As String = column(j).ToString + " " + k.ToString

                'add to row
                row(row_column) = Convert.ToDecimal(value(j))

                'calculate total
                total = total + Convert.ToDecimal(value(j))

                first_column = column(j).ToString
            Next

            'add total
            row("Total 1") = total

            data.Rows.Add(row)
        Next

        'print report
        Dim report As ReportEmpPayrollDeduction = New ReportEmpPayrollDeduction()

        'add column to grid
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        Dim last_cat As String = ""

        For i = 0 To data_column.Rows.Count - 1
            Dim salary_deduction_cat As String = data_column.Rows(i)("salary_deduction_cat").ToString
            Dim salary_deduction As String = data_column.Rows(i)("salary_deduction").ToString

            For j = 1 To data_column.Rows(i)("total")
                'band
                If Not last_cat = salary_deduction_cat Then
                    band = report.GVDeduction.Bands.AddBand(salary_deduction_cat)
                End If

                last_cat = salary_deduction_cat

                'column
                Dim column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()

                column.FieldName = salary_deduction + " " + j.ToString
                column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                column.Caption = salary_deduction.Replace(" ", Environment.NewLine)
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                column.DisplayFormat.FormatString = "N0"
                column.Visible = True
                column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                column.SummaryItem.DisplayFormat = "{0:N0}"

                band.Columns.Add(column)

                'grup summary
                Dim group_summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()

                group_summary.DisplayFormat = "{0:N0}"
                group_summary.FieldName = salary_deduction + " " + j.ToString
                group_summary.ShowInGroupColumnFooter = column
                group_summary.SummaryType = DevExpress.Data.SummaryItemType.Sum

                report.GVDeduction.GroupSummary.Add(group_summary)
            Next
        Next

        report.data = data

        report.GVDeduction.BestFitColumns()

        report.XLTitle.Text = "Deduction"
        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub
End Class