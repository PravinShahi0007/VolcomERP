Public Class FormEmpPayrollReportSummary
    Public id_payroll As String = ""
    Private Sub FormEmpPayrollReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_sum()

        'number
        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.IsValidRowHandle(i) Then
                GVSummary.SetRowCellValue(i, "no", i + 1)
            End If
        Next
    End Sub
    Sub load_sum()
        Dim query As String = "CALL view_payroll_sum('" & id_payroll & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim data As DataTable = GCSummary.DataSource

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

        Dim no As Integer = 0

        'office
        Dim data_payroll_1 As DataTable = data.Clone

        no = 0

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_1.ImportRow(data.Rows(j))

                data_payroll_1.Rows(no)("no") = no + 1

                no += 1
            End If
        Next

        'store
        Dim data_payroll_2 As DataTable = data.Clone

        no = 0

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_2.ImportRow(data.Rows(j))

                data_payroll_2.Rows(no)("no") = no + 1

                no += 1
            End If
        Next

        Dim report As ReportEmpPayrollReportAllDepartement = New ReportEmpPayrollReportAllDepartement

        report.id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        report.data = total_all(data)
        report.data_office = data_payroll_1
        report.data_store = data_payroll_2
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Function total_all(data_ori As DataTable) As DataTable
        Dim data As DataTable = New DataTable

        data.Columns.Add("information", GetType(String))
        data.Columns.Add("volcom_indonesia", GetType(Decimal))
        data.Columns.Add("bemo_corner", GetType(Decimal))
        data.Columns.Add("kuta_square", GetType(Decimal))
        data.Columns.Add("seminyak", GetType(Decimal))

        data.Rows.Add("TRANSFER BCA EFEKTIF " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0)
        data.Rows.Add("CASH EFEKTIF " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0)
        data.Rows.Add("Cooperative Contribution", 0, 0, 0, 0)

        Dim transfer As Decimal = 0.00
        Dim cash As Decimal = 0.00
        Dim cooperative As Decimal = 0.00

        For i = 0 To data_ori.Rows.Count - 1
            transfer = data_ori.Rows(i)("salary") + data_ori.Rows(i)("event_overtime") - data_ori.Rows(i)("d_cooperative_loan") - data_ori.Rows(i)("d_bpjskes") - data_ori.Rows(i)("d_jaminan_pensiun") - data_ori.Rows(i)("d_bpjstk") - data_ori.Rows(i)("d_cooperative_contribution") - data_ori.Rows(i)("d_missing") - data_ori.Rows(i)("d_meditation_cash") - data_ori.Rows(i)("d_other") - data_ori.Rows(i)("total_cash")
            cash = data_ori.Rows(i)("total_cash")
            cooperative = data_ori.Rows(i)("d_cooperative_contribution")

            If data_ori.Rows(i)("id_departement").ToString = "16" Then
                'bemo corner
                data.Rows(0)("bemo_corner") += transfer
                data.Rows(1)("bemo_corner") += cash
                data.Rows(2)("bemo_corner") += cooperative
            ElseIf data_ori.Rows(i)("id_departement").ToString = "15" Then
                'kuta square
                data.Rows(0)("kuta_square") += transfer
                data.Rows(1)("kuta_square") += cash
                data.Rows(2)("kuta_square") += cooperative
            ElseIf data_ori.Rows(i)("id_departement").ToString = "23" Then
                'seminyak
                data.Rows(0)("seminyak") += transfer
                data.Rows(1)("seminyak") += cash
                data.Rows(2)("seminyak") += cooperative
            Else
                data.Rows(0)("volcom_indonesia") += transfer
                data.Rows(1)("volcom_indonesia") += cash
                data.Rows(2)("volcom_indonesia") += cooperative
            End If
        Next

        Return data
    End Function
End Class