﻿Public Class FormEmpPayrollReportPajak
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportPajak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_payroll_pajak('" + id_payroll + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        BandedGridColumnTotal1.Caption = "Total I Gaji" + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM") + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")

        GCPajak.DataSource = data

        GVPajak.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportPajak_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        Dim data As DataTable = CType(GCPajak.DataSource, DataTable).Copy

        'naming
        Dim alphabet As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        Dim iAlphabet As Integer = 0
        Dim iInterger As Integer = 1

        Dim last_group As String = ""
        Dim last_departement As String = ""

        For i = 0 To data.Rows.Count - 1
            If GVPajak.IsValidRowHandle(i) Then
                Dim curr_group As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("group_report").ToString, "\(([A-Z])\)", "").ToString()
                Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("departement").ToString, "\(([A-Z])\)", "").ToString()

                If i = 0 Then
                    last_group = curr_group
                    last_departement = curr_departement
                End If

                If Not last_group = curr_group Then
                    iAlphabet += 1
                    iInterger = 0
                End If

                If Not last_departement = curr_departement Then
                    iInterger += 1
                End If

                data.Rows(i)("group_report") = curr_group + " (" + alphabet(iAlphabet) + ")"
                data.Rows(i)("departement") = curr_departement + " (" + alphabet(iAlphabet) + iInterger.ToString + ")"

                last_group = curr_group
                last_departement = curr_departement
            End If
        Next

        Dim Report As New ReportEmpPayrollReportPajak()

        Report.data = data
        Report.id_pre = If(id_report_status = "6", "-1", "1")
        Report.id_payroll = id_payroll

        Report.XLPeriod.Text = "GAJI BULAN " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVPajak.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVPajak.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class