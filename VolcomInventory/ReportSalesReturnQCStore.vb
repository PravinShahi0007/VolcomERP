﻿Public Class ReportSalesReturnQCStore
    Public Shared id_pre As String = "-1"
    Public Shared id_sales_return_qc As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"

    Private Sub ReportSalesReturnQCStore_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'sorting
        Dim dt2 As System.Data.DataView = dt.DefaultView

        dt2.Sort = "class ASC, name ASC, code ASC"

        dt = dt2.ToTable()

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow


        For i = 0 To dt.Rows.Count - 1

            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 0
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'code
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = dt.Rows(i)("code").ToString
            code.BorderWidth = 0
            code.Font = New Font(code.Font.FontFamily, code.Font.Size, FontStyle.Regular)

            'class
            Dim pclass As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            pclass.Text = dt.Rows(i)("class").ToString
            pclass.BorderWidth = 0
            pclass.Font = New Font(code.Font.FontFamily, code.Font.Size, FontStyle.Regular)

            'name
            Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            name.Text = dt.Rows(i)("name").ToString
            name.BorderWidth = 0
            name.Font = New Font(name.Font.FontFamily, name.Font.Size, FontStyle.Regular)

            'color
            Dim pcolor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            pcolor.Text = dt.Rows(i)("color").ToString
            pcolor.BorderWidth = 0
            pcolor.Font = New Font(code.Font.FontFamily, code.Font.Size, FontStyle.Regular)

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            size.Text = dt.Rows(i)("size").ToString
            size.BorderWidth = 0
            size.Font = New Font(size.Font.FontFamily, size.Font.Size, FontStyle.Regular)

            'sales_return_qc_det_qty 
            Dim remark As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            remark.Text = dt.Rows(i)("reject_type").ToString
            remark.BorderWidth = 0
            remark.Font = New Font(remark.Font.FontFamily, remark.Font.Size, FontStyle.Regular)
        Next

        XrRowTotal.HeightF = 25


        'custom mark
        Dim query As String = "
            SELECT report_status_display, employee_name, `role`, date_time
            FROM (
                (SELECT IF(b.id_report_status = 1, 1, 4) AS `order`, b.report_status_display, d.employee_name, d.employee_position AS `role`, DATE_FORMAT(a.report_mark_datetime, '%d-%m-%Y %H:%i') AS date_time
                FROM tb_report_mark a
                INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status
                LEFT JOIN tb_m_employee d ON d.id_employee = a.id_employee
                WHERE a.report_mark_type='" & rmt & "' AND a.id_report='" & id_sales_return_qc & "' " + If(id_pre = "-1", "AND a.is_use = 1 AND a.id_mark = 2", "AND (a.level IS NULL OR a.level = 1)") + " AND a.id_report_status = 1
                ORDER BY a.id_report_status, a.id_mark_asg)
                UNION
                (SELECT 4 AS `order`, 'Approved By,' AS report_status_display, '' AS employee_name, 'WH Team Leader' AS role, '' AS date_time)
                UNION
                (SELECT 5 AS `order`, 'Completed By,' AS report_status_display, '' AS employee_name, 'Dept. Head' AS role, '' AS date_time)
            ) AS tb
            ORDER BY `order`
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'head
        Dim row_head As New DevExpress.XtraReports.UI.XRTableRow()

        row_head.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size + 1, FontStyle.Bold)
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

        XrTable1.Rows.Add(row_head)

        'blank
        For i As Integer = 0 To 1
            Dim row_blank As New DevExpress.XtraReports.UI.XRTableRow()

            row_blank.HeightF = 10.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell_blank As New DevExpress.XtraReports.UI.XRTableCell()

                cell_blank.Text = " "

                row_blank.Cells.Add(cell_blank)
            Next j

            XrTable1.Rows.Add(row_blank)
        Next

        'name
        Dim row_name As New DevExpress.XtraReports.UI.XRTableRow()

        row_name.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("employee_name").ToString

            row_name.Cells.Add(cell)
        Next j

        XrTable1.Rows.Add(row_name)

        'role
        Dim row_role As New DevExpress.XtraReports.UI.XRTableRow()

        row_role.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("role").ToString

            row_role.Cells.Add(cell)
        Next j

        XrTable1.Rows.Add(row_role)

        If id_pre = "-1" Then 'time included
            Dim row_time As New DevExpress.XtraReports.UI.XRTableRow()

            row_time.HeightF = 25.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size - 1, FontStyle.Italic)
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                cell.Text = data.Rows(j)("date_time").ToString

                row_time.Cells.Add(cell)
            Next j

            XrTable1.Rows.Add(row_time)
        End If

        XRCompany.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
        Dim qp As String = "
            SELECT e.employee_nick_name AS `printed_by`, DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i') AS `printed_date`
            FROM tb_m_user u
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE u.id_user=" + id_user + " 
        "
        Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
        LabelPrintedDate.Text = dp.Rows(0)("printed_date").ToString
        LabelPrintedBy.Text = dp.Rows(0)("printed_by").ToString
    End Sub
End Class