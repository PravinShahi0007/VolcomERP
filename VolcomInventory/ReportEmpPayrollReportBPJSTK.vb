Public Class ReportEmpPayrollReportBPJSTK
    Public id_pre As String
    Public id_payroll As String
    Public data As DataTable

    Private Sub ReportEmpPayrollReportBPJSTK_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim total_company_contribution_1 As Integer = 0
        Dim total_company_contribution_2 As Integer = 0
        Dim total_employee_contribution_1 As Integer = 0
        Dim total_employee_contribution_2 As Integer = 0
        Dim total As Integer = 0

        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)

                row.HeightF = 16
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = data.Rows(i)("no").ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.White

            'departement
            Dim departement As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            departement.Text = data.Rows(i)("departement").ToString
            departement.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            departement.BackColor = Color.White

            'equal
            Dim equal As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            equal.Text = data.Rows(i)("equal").ToString
            equal.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            equal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            equal.BackColor = Color.White

            'company contribution 1
            Dim company_contribution_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            company_contribution_1.Text = Format(data.Rows(i)("company_contribution_1"), "##,##0")
            company_contribution_1.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            company_contribution_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company_contribution_1.BackColor = Color.White

            'company contribution 2
            Dim company_contribution_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            company_contribution_2.Text = Format(data.Rows(i)("company_contribution_2"), "##,##0")
            company_contribution_2.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            company_contribution_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            company_contribution_2.BackColor = Color.White

            'employee contribution 1
            Dim employee_contribution_1 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            employee_contribution_1.Text = Format(data.Rows(i)("employee_contribution_1"), "##,##0")
            employee_contribution_1.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_contribution_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution_1.BackColor = Color.White

            'employee contribution 2
            Dim employee_contribution_2 As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            employee_contribution_2.Text = Format(data.Rows(i)("employee_contribution_2"), "##,##0")
            employee_contribution_2.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_contribution_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution_2.BackColor = Color.White

            'total contribution
            Dim total_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            total_contribution.Text = Format((data.Rows(i)("company_contribution_1") + data.Rows(i)("company_contribution_2") + data.Rows(i)("employee_contribution_1") + data.Rows(i)("employee_contribution_2")), "##,##0")
            total_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            total_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total_contribution.BackColor = Color.White

            'calculate total
            total_company_contribution_1 += data.Rows(i)("company_contribution_1")
            total_company_contribution_2 += data.Rows(i)("company_contribution_2")
            total_employee_contribution_1 += data.Rows(i)("employee_contribution_1")
            total_employee_contribution_2 += data.Rows(i)("employee_contribution_2")
            total += data.Rows(i)("company_contribution_1") + data.Rows(i)("company_contribution_2") + data.Rows(i)("employee_contribution_1") + data.Rows(i)("employee_contribution_2")
        Next

        XTRowTotal.HeightF = 16

        XTRowTotal.Cells.Item(3).Text = Format(total_company_contribution_1, "##,##0")
        XTRowTotal.Cells.Item(4).Text = Format(total_company_contribution_2, "##,##0")
        XTRowTotal.Cells.Item(5).Text = Format(total_employee_contribution_1, "##,##0")
        XTRowTotal.Cells.Item(6).Text = Format(total_employee_contribution_2, "##,##0")
        XTRowTotal.Cells.Item(7).Text = Format(total, "##,##0")

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub
End Class