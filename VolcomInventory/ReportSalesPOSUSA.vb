Public Class ReportSalesPOSUSA
    Public data1 As DataTable = New DataTable
    Public data2 As DataTable = New DataTable
    Public data3 As DataTable = New DataTable

    Private Sub ReportSalesPOSUSA_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        XLDate.Text = data1.Rows(0)("date").ToString.Substring(8)

        XCDate.Text = data1.Rows(0)("date").ToString
        XCAmount.Text = Format(data1.Rows(0)("amount"), "##,##0.00")

        XCDateTotal.Text = XLDate.Text
        XCAmountTotal.Text = Format(data1.Rows(0)("amount"), "##,##0.00")

        For i = 0 To data2.Rows.Count - 1
            Dim newRow As DevExpress.XtraReports.UI.XRTableRow = XTSales.InsertRowAbove(XTSalesRow)

            newRow.Cells(0).Text = data2.Rows(i)("text").ToString
            newRow.Cells(1).Text = Format(data2.Rows(i)("amount"), "##,##0.00")
        Next

        Dim grandTotal As Decimal = 0.00

        For i = 0 To data3.Rows.Count - 1
            Dim secRow As DevExpress.XtraReports.UI.XRTableRow = XTRoyalty.InsertRowAbove(XTRoyaltyRow)

            secRow.Cells(0).Text = data3.Rows(i)("group").ToString.Substring(3)
            secRow.Cells(0).Font = New Font(secRow.Cells(0).Font.FontFamily, secRow.Cells(0).Font.Size, FontStyle.Bold)

            secRow.DeleteCell(secRow.Cells(1))
            secRow.DeleteCell(secRow.Cells(1))

            Dim newRow As DevExpress.XtraReports.UI.XRTableRow = XTRoyalty.InsertRowAbove(XTRoyaltyRow)

            newRow.Cells(0).Text = data3.Rows(i)("text").ToString
            newRow.Cells(1).Text = data3.Rows(i)("date").ToString
            newRow.Cells(2).Text = Format(data3.Rows(i)("amount"), "##,##0.00")

            grandTotal += Decimal.Parse(Format(data3.Rows(i)("amount"), "##,##0.00"))
        Next

        XCGrandTotal.Text = Format(grandTotal, "##,##0.00")

        Dim query As String = "
            SELECT report_status_display, employee_name, `role`
            FROM (
	            (SELECT 0 AS `order`, 'Prepared By,' AS report_status_display, employee_name, employee_position AS role
	            FROM tb_m_employee
	            WHERE id_employee = " + id_employee_user + ")
	            UNION
	            (SELECT tb_mark_asg.id_mark_asg AS `order`, tb_lookup_report_status.report_status_display, tb_m_employee.employee_name, tb_m_employee.employee_position AS role
	            FROM tb_mark_asg_user
	            LEFT JOIN tb_mark_asg ON tb_mark_asg_user.id_mark_asg = tb_mark_asg.id_mark_asg
	            LEFT JOIN tb_lookup_report_mark_type ON tb_mark_asg.report_mark_type = tb_lookup_report_mark_type.report_mark_type
	            LEFT JOIN tb_m_user ON tb_mark_asg_user.id_user = tb_m_user.id_user
	            LEFT JOIN tb_m_employee ON tb_m_user.id_employee = tb_m_employee.id_employee
	            LEFT JOIN tb_lookup_report_status ON tb_mark_asg.id_report_status = tb_lookup_report_status.id_report_status
	            WHERE tb_mark_asg.report_mark_type = 302)
            ) AS tb
            ORDER BY `order`
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'head
        Dim row_head As New DevExpress.XtraReports.UI.XRTableRow()

        row_head.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable4.Font.FontFamily, XrTable4.Font.Size + 1, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

            'merge or not
            If j > 0 Then
                If data.Rows(j)("report_status_display").ToString = data.Rows(j - 1)("report_status_display").ToString Then
                    cell.Text = ""
                Else
                    cell.Text = data.Rows(j)("report_status_display").ToString
                End If
            Else
                cell.Text = data.Rows(j)("report_status_display").ToString
            End If

            row_head.Cells.Add(cell)
        Next j

        XrTable4.Rows.Add(row_head)

        'blank
        For i As Integer = 0 To 1
            Dim row_blank As New DevExpress.XtraReports.UI.XRTableRow()

            row_blank.HeightF = 10.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell_blank As New DevExpress.XtraReports.UI.XRTableCell()

                cell_blank.Text = " "

                row_blank.Cells.Add(cell_blank)
            Next j

            XrTable4.Rows.Add(row_blank)
        Next

        'name
        Dim row_name As New DevExpress.XtraReports.UI.XRTableRow()

        row_name.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable4.Font.FontFamily, XrTable4.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("employee_name").ToString

            row_name.Cells.Add(cell)
        Next j

        XrTable4.Rows.Add(row_name)

        'role
        Dim row_role As New DevExpress.XtraReports.UI.XRTableRow()

        row_role.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable4.Font.FontFamily, XrTable4.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("role").ToString

            row_role.Cells.Add(cell)
        Next j

        XrTable4.Rows.Add(row_role)
    End Sub
End Class