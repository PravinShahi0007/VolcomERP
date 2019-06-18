Public Class FormEmpPayrollAdjustment
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_adjustment()
    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT pya.id_payroll_adj,IF(adj.use_days = 2, '-', pya.total_days) AS total_days,pya.value,pya.increase,pya.note,emp.`employee_name`,emp.`employee_code`,emp.`employee_position`,dep.`departement`,adj.`salary_adjustment`,adjc.salary_adjustment_cat,lvl.`employee_level` FROM tb_emp_payroll_adj pya
                                INNER JOIN tb_m_employee emp ON pya.id_employee=emp.`id_employee`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=emp.`id_departement`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                INNER JOIN `tb_lookup_salary_adjustment` adj ON adj.`id_salary_adjustment`=pya.`id_salary_adj`
                                INNER JOIN tb_lookup_salary_adjustment_cat adjc ON adjc.id_salary_adjustment_cat = adj.id_salary_adjustment_cat
                                WHERE pya.`id_payroll`='" & id_payroll & "'
                                ORDER BY emp.id_employee_level ASC, emp.`employee_code` ASC, adj.id_salary_adjustment_cat ASC, adj.`id_salary_adjustment` ASC"
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
        'get column
        Dim query_column As String = "
            (
                SELECT tb.id_salary_adjustment_cat, tb.id_salary_adjustment, tb.salary_adjustment_cat, tb.salary_adjustment, MAX(tb.total) AS total
                FROM (
                    SELECT sald.id_salary_adjustment_cat, sald.id_salary_adjustment, saldc.salary_adjustment_cat, sald.salary_adjustment, COUNT(sald.id_salary_adjustment) AS total
                    FROM tb_emp_payroll_adj pyd
                    INNER JOIN tb_lookup_salary_adjustment sald ON sald.id_salary_adjustment=pyd.id_salary_adj
                    INNER JOIN tb_lookup_salary_adjustment_cat saldc ON saldc.id_salary_adjustment_cat=sald.id_salary_adjustment_cat
                    WHERE pyd.id_payroll='" + id_payroll + "'
                    GROUP BY pyd.id_employee, sald.id_salary_adjustment
                    ORDER BY sald.id_salary_adjustment_cat ASC, sald.id_salary_adjustment ASC
                ) AS tb
                GROUP BY tb.salary_adjustment
                ORDER BY tb.id_salary_adjustment_cat ASC, tb.id_salary_adjustment ASC
            )
            UNION
            (
                SELECT 99 AS id_salary_adjustment_cat, 99 AS id_salary_adjustment, '' AS salary_adjustment_cat, 'Total' AS salary_adjustment, 1 AS total
            ) 
            ORDER BY id_salary_adjustment_cat ASC, id_salary_adjustment ASC
        "

        Dim data_column As DataTable = execute_query(query_column, -1, True, "", "", "", "")

        'employee
        Dim query_employee As String = "
            SELECT dep.departement,emp.employee_code,emp.employee_name,emp.employee_position,lvl.employee_level,
                GROUP_CONCAT(sald.salary_adjustment ORDER BY sald.id_salary_adjustment_cat ASC, sald.id_salary_adjustment ASC) AS salary_adjustment_c,
                GROUP_CONCAT(ROUND(pyd.value, 0) ORDER BY sald.id_salary_adjustment_cat ASC, sald.id_salary_adjustment ASC) AS salary_adjustment_v
            FROM tb_emp_payroll_adj AS pyd
            INNER JOIN tb_m_employee emp ON emp.id_employee=pyd.id_employee
            INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
            INNER JOIN tb_lookup_salary_adjustment sald ON sald.id_salary_adjustment=pyd.id_salary_adj
            INNER JOIN tb_lookup_salary_adjustment_cat saldc ON saldc.id_salary_adjustment_cat=sald.id_salary_adjustment_cat
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
            Dim salary_adjustment As String = data_column.Rows(i)("salary_adjustment").ToString

            For j = 1 To data_column.Rows(i)("total")
                Dim column As DataColumn = New DataColumn()

                column.ColumnName = salary_adjustment + " " + j.ToString
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

            Dim column As String() = Split(data_employee.Rows(i)("salary_adjustment_c").ToString, ",")
            Dim value As String() = Split(data_employee.Rows(i)("salary_adjustment_v").ToString, ",")

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
            Dim salary_adjustment_cat As String = data_column.Rows(i)("salary_adjustment_cat").ToString
            Dim salary_adjustment As String = data_column.Rows(i)("salary_adjustment").ToString

            For j = 1 To data_column.Rows(i)("total")
                'band
                If Not last_cat = salary_adjustment_cat Then
                    band = report.GVDeduction.Bands.AddBand(salary_adjustment_cat)
                End If

                last_cat = salary_adjustment_cat

                'column
                Dim column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()

                column.FieldName = salary_adjustment + " " + j.ToString
                column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                column.Caption = salary_adjustment.Replace(" ", Environment.NewLine)
                column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                column.DisplayFormat.FormatString = "N0"
                column.Visible = True
                column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                column.SummaryItem.DisplayFormat = "{0:N0}"

                band.Columns.Add(column)

                'grup summary
                Dim group_summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()

                group_summary.DisplayFormat = "{0:N0}"
                group_summary.FieldName = salary_adjustment + " " + j.ToString
                group_summary.ShowInGroupColumnFooter = column
                group_summary.SummaryType = DevExpress.Data.SummaryItemType.Sum

                report.GVDeduction.GroupSummary.Add(group_summary)
            Next
        Next

        report.data = data

        report.GVDeduction.BestFitColumns()

        report.XLTitle.Text = "Bonus / Adjustment"
        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub
End Class