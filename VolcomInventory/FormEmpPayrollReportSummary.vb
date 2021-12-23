﻿Public Class FormEmpPayrollReportSummary
    Public id_payroll As String = ""

    Private data_payroll As DataTable = New DataTable

    Private Sub FormEmpPayrollReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_payroll = "" Then
            id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        End If

        data_payroll = execute_query("
            SELECT 'no' AS is_check, pr.*,emp.`employee_name`,type.payroll_type as payroll_type_name,DATE_FORMAT(pr.periode_end,'%M %Y') AS payroll_name, IFNULL((SELECT report_status FROM tb_lookup_report_status WHERE id_report_status = pr.id_report_status), 'Not Submitted') AS report_status, type.is_thr, type.is_dw FROM tb_emp_payroll pr
            INNER JOIn tb_emp_payroll_type type ON type.id_payroll_type=pr.id_payroll_type
            INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
            WHERE pr.id_payroll = '" + id_payroll + "'
        ", -1, True, "", "", "", "")

        load_sum()

        'number
        Dim num As Integer = 0

        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.IsValidRowHandle(i) Then
                If GVSummary.GetRowCellValue(i, "id_departement").ToString = "17" Then
                    If GVSummary.GetRowCellValue(i, "id_departement_sub").ToString = "" Then
                        num = num + 1

                        GVSummary.SetRowCellValue(i, "no", num)
                    End If
                Else
                    num = num + 1

                    GVSummary.SetRowCellValue(i, "no", num)
                End If
            End If
        Next

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If

        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + data_payroll.Rows(0)("id_payroll_type").ToString, 0, True, "", "", "", "")
        Dim is_bonus As String = execute_query("SELECT is_bonus FROM tb_emp_payroll_type WHERE id_payroll_type = " + data_payroll.Rows(0)("id_payroll_type").ToString, 0, True, "", "", "", "")

        If is_thr = "1" Or is_bonus = "1" Then
            GVSummary.Columns("salary").Visible = False
            GVSummary.Columns("event_overtime").Visible = False
            GVSummary.Columns("d_cooperative_loan").Visible = False
            GVSummary.Columns("d_bpjskes").Visible = False
            GVSummary.Columns("d_jaminan_pensiun").Visible = False
            GVSummary.Columns("d_bpjstk").Visible = False
            GVSummary.Columns("d_cooperative_contribution").Visible = False
            GVSummary.Columns("d_missing").Visible = False
            GVSummary.Columns("d_meditation_cash").Visible = False
            GVSummary.Columns("d_other").Visible = False

            GVSummary.Columns("balance").Caption = "Total THR"

            If is_bonus = "1" Then
                GVSummary.Columns("balance").Caption = "Total Bonus"
            End If
        End If
    End Sub

    Sub load_sum()
        Dim query As String = "CALL view_payroll_sum('" & id_payroll & "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSummary.DataSource = data

        'separate sogo
        Dim index As Integer = 0

        Dim salary As Decimal = 0
        Dim event_overtime As Decimal = 0
        Dim d_cooperative_loan As Decimal = 0
        Dim d_bpjskes As Decimal = 0
        Dim d_jaminan_pensiun As Decimal = 0
        Dim d_bpjstk As Decimal = 0
        Dim d_cooperative_contributtion As Decimal = 0
        Dim d_missing As Decimal = 0
        Dim d_meditation_cash As Decimal = 0
        Dim d_other As Decimal = 0
        Dim total_cash As Decimal = 0

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("departement").ToString().Contains("SOGO") Then
                If index = 0 Then
                    index = i
                End If

                data.Rows(i)("departement") = "     " + data.Rows(i)("departement_sub").ToString()

                salary += data.Rows(i)("salary")
                event_overtime += data.Rows(i)("event_overtime")
                d_cooperative_loan += data.Rows(i)("d_cooperative_loan")
                d_bpjskes += data.Rows(i)("d_bpjskes")
                d_jaminan_pensiun += data.Rows(i)("d_jaminan_pensiun")
                d_bpjstk += data.Rows(i)("d_bpjstk")
                d_cooperative_contributtion += data.Rows(i)("d_cooperative_contribution")
                d_missing += data.Rows(i)("d_missing")
                d_meditation_cash += data.Rows(i)("d_meditation_cash")
                d_other += data.Rows(i)("d_other")
                total_cash += data.Rows(i)("total_cash")
            End If
        Next

        If Not salary = 0 Then
            Dim row As DataRow = data.NewRow()

            row("group_report") = "STORE"
            row("is_office_payroll") = 2
            row("no") = 0
            row("id_departement") = 17
            row("departement") = "VOLCOM SOGO"
            row("departement_sub") = "VOLCOM SOGO"
            row("salary") = salary
            row("event_overtime") = event_overtime
            row("d_cooperative_loan") = d_cooperative_loan
            row("d_bpjskes") = d_bpjskes
            row("d_jaminan_pensiun") = d_jaminan_pensiun
            row("d_bpjstk") = d_bpjstk
            row("d_cooperative_contribution") = d_cooperative_contributtion
            row("d_missing") = d_missing
            row("d_meditation_cash") = d_meditation_cash
            row("d_other") = d_other
            row("total_cash") = total_cash

            data.Rows.InsertAt(row, index)
        End If

        GVSummary.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim data As DataTable = GCSummary.DataSource

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + data_payroll.Rows(0)("id_payroll").ToString, 0, True, "", "", "", "")

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

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_2.ImportRow(data.Rows(j))
            End If
        Next

        no = 0

        For i = 0 To data_payroll_2.Rows.Count - 1
            If Not data_payroll_2.Rows(i)("no").ToString = "" Then
                data_payroll_2.Rows(i)("no") = no + 1

                no += 1
            End If
        Next

        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + data_payroll.Rows(0)("id_payroll_type").ToString, 0, True, "", "", "", "")
        Dim is_bonus As String = execute_query("SELECT is_bonus FROM tb_emp_payroll_type WHERE id_payroll_type = " + data_payroll.Rows(0)("id_payroll_type").ToString, 0, True, "", "", "", "")

        Dim report As ReportEmpPayrollReportAllDepartement = New ReportEmpPayrollReportAllDepartement

        'If is_thr = "1" Then
        '    report.Landscape = False
        '    report.XrLine1.SizeF = New SizeF(733, 20)
        '    report.XLTitle.SizeF = New SizeF(275, 41.15)
        '    report.XLTitle.LocationF = New PointF(220, 23)
        '    report.XLPeriod.SizeF = New SizeF(205, 23)
        '    report.XLPeriod.LocationF = New PointF(525, 11)
        '    report.XLType.SizeF = New SizeF(150, 23)
        '    report.XrLabel1.LocationF = New PointF(525, 34)
        '    report.XrLabel3.LocationF = New PointF(565, 34)
        '    report.XLType.LocationF = New PointF(580, 34)
        '    report.XrTable1.SizeF = New SizeF(733, 25)
        'End If

        report.id_payroll = data_payroll.Rows(0)("id_payroll").ToString
        report.data = total_all(data)
        report.data_office = data_payroll_1
        report.data_store = data_payroll_2
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.type = data_payroll.Rows(0)("id_payroll_type").ToString

        report.XLPeriod.Text = Date.Parse(data_payroll.Rows(0)("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = data_payroll.Rows(0)("payroll_type_name").ToString

        If is_thr = "1" Then
            report.XLTitle.Text = "Summary THR"
            report.XLPeriod.Text = "Period " + Date.Parse(data_payroll.Rows(0)("periode_end").ToString).ToString("yyyy")
        End If

        If is_bonus = "1" Then
            report.XLTitle.Text = "Summary Bonus"
            report.XLPeriod.Text = "Period " + Date.Parse(data_payroll.Rows(0)("periode_end").ToString).ToString("yyyy")
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Function total_all(data_ori As DataTable) As DataTable
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + data_payroll.Rows(0)("id_payroll_type").ToString, 0, True, "", "", "", "")

        Dim data As DataTable = New DataTable

        data.Columns.Add("information", GetType(String))
        data.Columns.Add("volcom_indonesia", GetType(Decimal))
        data.Columns.Add("volcom_sogo", GetType(Decimal))
        data.Columns.Add("bemo_corner", GetType(Decimal))
        data.Columns.Add("kuta_square", GetType(Decimal))
        data.Columns.Add("seminyak", GetType(Decimal))

        data.Rows.Add("TRANSFER BCA EFEKTIF " + Date.Parse(data_payroll.Rows(0)("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0, 0)
        data.Rows.Add("CASH EFEKTIF " + Date.Parse(data_payroll.Rows(0)("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0, 0)
        If is_thr = "2" Then
            data.Rows.Add("Cooperative ", 0, 0, 0, 0, 0)
        End If

        Dim transfer As Decimal = 0.00
        Dim cash As Decimal = 0.00
        Dim cooperative As Decimal = 0.00

        For i = 0 To data_ori.Rows.Count - 1
            If Not data_ori.Rows(i)("no").ToString = "" Then
                transfer = data_ori.Rows(i)("salary") + data_ori.Rows(i)("event_overtime") - data_ori.Rows(i)("d_cooperative_loan") - data_ori.Rows(i)("d_bpjskes") - data_ori.Rows(i)("d_jaminan_pensiun") - data_ori.Rows(i)("d_bpjstk") - data_ori.Rows(i)("d_cooperative_contribution") - data_ori.Rows(i)("d_missing") - data_ori.Rows(i)("d_meditation_cash") - data_ori.Rows(i)("d_other") - data_ori.Rows(i)("total_cash")
                cash = data_ori.Rows(i)("total_cash")
                cooperative = data_ori.Rows(i)("d_cooperative_contribution") + data_ori.Rows(i)("d_cooperative_loan")

                If data_ori.Rows(i)("id_departement").ToString = "16" Then
                    'bemo corner
                    data.Rows(0)("bemo_corner") += transfer
                    data.Rows(1)("bemo_corner") += cash
                    If is_thr = "2" Then
                        data.Rows(2)("bemo_corner") += cooperative
                    End If
                ElseIf data_ori.Rows(i)("id_departement").ToString = "15" Then
                    'kuta square
                    data.Rows(0)("kuta_square") += transfer
                    data.Rows(1)("kuta_square") += cash
                    If is_thr = "2" Then
                        data.Rows(2)("kuta_square") += cooperative
                    End If
                ElseIf data_ori.Rows(i)("id_departement").ToString = "23" Then
                    'seminyak
                    data.Rows(0)("seminyak") += transfer
                    data.Rows(1)("seminyak") += cash
                    If is_thr = "2" Then
                        data.Rows(2)("seminyak") += cooperative
                    End If
                ElseIf data_ori.Rows(i)("id_departement").ToString = "17" Then
                    'sogo
                    data.Rows(0)("volcom_sogo") += transfer
                    data.Rows(1)("volcom_sogo") += cash
                    If is_thr = "2" Then
                        data.Rows(2)("volcom_sogo") += cooperative
                    End If
                Else
                    data.Rows(0)("volcom_indonesia") += transfer
                    data.Rows(1)("volcom_indonesia") += cash
                    If is_thr = "2" Then
                        data.Rows(2)("volcom_indonesia") += cooperative
                    End If
                End If
            End If
        Next

        Return data
    End Function

    Dim tot_salary As Decimal = 0
    Dim tot_event_overtime As Decimal = 0
    Dim tot_d_cooperative_loan As Decimal = 0
    Dim tot_d_bpjskes As Decimal = 0
    Dim tot_d_jaminan_pensiun As Decimal = 0
    Dim tot_d_bpjstk As Decimal = 0
    Dim tot_d_cooperative_contributtion As Decimal = 0
    Dim tot_d_missing As Decimal = 0
    Dim tot_d_meditation_cash As Decimal = 0
    Dim tot_d_other As Decimal = 0
    Dim tot_total_cash As Decimal = 0
    Dim tot_balance As Decimal = 0

    Private Sub GVSummary_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSummary.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "salary" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_salary = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_salary += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_salary, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "event_overtime" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_event_overtime = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_event_overtime += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_event_overtime, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_cooperative_loan" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_cooperative_loan = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_cooperative_loan += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_cooperative_loan, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_bpjskes" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_bpjskes = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_bpjskes += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_bpjskes, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_jaminan_pensiun" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_jaminan_pensiun = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_jaminan_pensiun += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_jaminan_pensiun, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_bpjstk" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_bpjstk = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_bpjstk += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_bpjstk, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_cooperative_contribution" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_cooperative_contributtion = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_cooperative_contributtion += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_cooperative_contributtion, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_missing" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_missing = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_missing += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_missing, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_meditation_cash" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_meditation_cash = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_meditation_cash += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_meditation_cash, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_other" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_other = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_other += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_other, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "total_cash" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_total_cash = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_total_cash += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_total_cash, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "balance" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_balance = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_balance += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_balance, "##,##0")
            End Select
        End If
    End Sub
End Class