Public Class FormEmpPayrollReportPajak
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportPajak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_payroll_pajak('" + id_payroll + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("is_thr").ToString = "1" Then
            GBSalary.Visible = False
            gridBand3.Visible = False
            gridBand2.Visible = False
            GBBonus.Visible = False

            BandedGridColumnTHR.Caption = "Total" + Environment.NewLine + "THR " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
        ElseIf data.Rows(0)("is_bonus").ToString = "1" Then
            GBSalary.Visible = False
            gridBand3.Visible = False
            gridBand2.Visible = False
            GBTHR.Visible = False

            BandedGridColumnBonus.Caption = "Total" + Environment.NewLine + "Bonus " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
        Else
            GBTHR.Visible = False
            GBBonus.Visible = False

            BandedGridColumnTotal1.Caption = "Total I Gaji" + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM") + Environment.NewLine + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
        End If

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

        If data.Rows(0)("is_thr").ToString = "1" Then
            Report.XLPeriod.Text = data.Rows(0)("payroll_type").ToString.ToUpper + " " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy").ToUpper
        ElseIf data.Rows(0)("is_bonus").ToString = "1" Then
            Report.XLPeriod.Text = data.Rows(0)("payroll_type").ToString.ToUpper + " " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy").ToUpper
        Else
            Report.XLPeriod.Text = "GAJI BULAN " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy").ToUpper
        End If

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVPajak.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVPajak.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BBrowse_Click(sender As Object, e As EventArgs) Handles BBrowse.Click
        Cursor = Cursors.WaitCursor

        Dim dialog As FolderBrowserDialog = New FolderBrowserDialog()

        Cursor = Cursors.Default

        If dialog.ShowDialog() = DialogResult.OK Then
            Dim type As String = If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "DW ", "")
            Dim month_date As String = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")

            If FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString = "1" Then
                type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString + " "
                month_date = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
            End If

            TBFileAddress.Text = dialog.SelectedPath & "\Report Pajak " + type + month_date + ".xls"
        End If

        dialog.Dispose()
    End Sub

    Private Sub BExcel_Click(sender As Object, e As EventArgs) Handles BExcel.Click
        If TBFileAddress.EditValue.ToString = "" Then
            stopCustom("Please close your excel file first then try again later")
        Else
            Dim query As String = ""
            Dim data As DataTable = New DataTable

            Dim op As DevExpress.XtraPrinting.XlsExportOptionsEx = New DevExpress.XtraPrinting.XlsExportOptionsEx
            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            Dim id_payroll_type As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

            Dim id_payroll_other As String = execute_query("SELECT IFNULL((SELECT id_payroll FROM tb_emp_payroll WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND id_payroll_type = " + If(id_payroll_type = "1", "4", "1") + "), 0) AS id_payroll", 0, True, "", "", "", "")

            GVPajak.ExportToXls(TBFileAddress.EditValue.ToString, op)

            If Not id_payroll_other = "0" Then
                query = "CALL view_payroll_pajak('" + id_payroll_other + "')"

                data = execute_query(query, -1, True, "", "", "", "")

                GCPajak.DataSource = data

                GVPajak.ExportToXls(If(id_payroll_type = "1", TBFileAddress.EditValue.ToString.Replace("Report Pajak", "Report Pajak DW"), TBFileAddress.EditValue.ToString.Replace("Report Pajak DW", "Report Pajak")), op)
            End If

            'reload
            query = "CALL view_payroll_pajak('" + id_payroll + "')"

            data = execute_query(query, -1, True, "", "", "", "")

            GCPajak.DataSource = data

            GVPajak.BestFitColumns()

            infoCustom("File saved.")
        End If
    End Sub
End Class