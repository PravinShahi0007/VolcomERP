Public Class ReportFollowUpAR
    Public id_follow_up_recap As String = "0"

    Private Sub ReportFollowUpAR_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "
            SELECT rd.group, rd.amount, DATE_FORMAT(rd.due_date, '%d %M %Y') AS due_date, DATE_FORMAT(rd.follow_up_date, '%d %M %Y') AS follow_up_date, rd.follow_up, rd.follow_up_result
            FROM tb_follow_up_recap_det AS rd
            LEFT JOIN tb_follow_up_recap AS r ON rd.id_follow_up_recap = r.id_follow_up_recap
            WHERE r.id_follow_up_recap = " + id_follow_up_recap + "
            ORDER BY rd.id_comp_group, rd.due_date, rd.follow_up_date
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim i_no As Integer = 1

        Dim i_group As Integer = 2
        Dim c_group As Integer = 1
        Dim last_group As String = data.Rows(0)("group").ToString

        Dim i_amount As Integer = 2
        Dim c_amount As Integer = 1
        Dim last_amount As String = data.Rows(0)("amount").ToString

        Dim i_due_date As Integer = 2
        Dim c_due_date As Integer = 1
        Dim last_due_date As String = data.Rows(0)("due_date").ToString

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        For i = 0 To data.Rows.Count - 1
            row = XrTable.InsertRowBelow(row)

            row.Font = New Font(XrTableRow.Font.FontFamily, XrTableRow.Font.Size, FontStyle.Regular)

            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = i + 1
            no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim group As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            group.Text = data.Rows(i)("group").ToString
            group.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            group.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            group.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim amount As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            amount.Text = Format(data.Rows(i)("amount"), "##,##0")
            amount.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim due_date As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            due_date.Text = data.Rows(i)("due_date").ToString
            due_date.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            due_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            due_date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim follow_up_date As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            follow_up_date.Text = data.Rows(i)("follow_up_date").ToString
            follow_up_date.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            follow_up_date.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            follow_up_date.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim follow_up As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            follow_up.Text = data.Rows(i)("follow_up").ToString
            follow_up.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top
            follow_up.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            Dim follow_up_result As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            follow_up_result.Text = data.Rows(i)("follow_up_result").ToString
            follow_up_result.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right
            follow_up_result.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)

            'row span
            If Not last_group = data.Rows(i)("group").ToString Then
                XrTable.Rows.Item(i_group).Cells.Item(0).RowSpan = c_group
                XrTable.Rows.Item(i_group).Cells.Item(1).RowSpan = c_group

                XrTable.Rows.Item(i_group).Cells.Item(0).Text = i_no

                'amount
                XrTable.Rows.Item(i_amount).Cells.Item(2).RowSpan = c_amount
                i_amount = i + 2
                c_amount = 1

                'due date
                XrTable.Rows.Item(i_due_date).Cells.Item(3).RowSpan = c_due_date
                i_due_date = i + 2
                c_due_date = 1

                i_no = i_no + 1
            End If

            If Not last_amount = data.Rows(i)("amount").ToString Then
                XrTable.Rows.Item(i_amount).Cells.Item(2).RowSpan = c_amount
            End If

            If Not last_due_date = data.Rows(i)("due_date").ToString Then
                XrTable.Rows.Item(i_due_date).Cells.Item(3).RowSpan = c_due_date
            End If

            'first row group
            If Not last_group = data.Rows(i)("group").ToString Then
                i_group = i + 2
                c_group = 1
            End If

            If Not last_amount = data.Rows(i)("amount").ToString Then
                i_amount = i + 2
                c_amount = 1
            End If

            If Not last_due_date = data.Rows(i)("due_date").ToString Then
                i_due_date = i + 2
                c_due_date = 1
            End If

            c_group = c_group + 1
            c_amount = c_amount + 1
            c_due_date = c_due_date + 1

            last_group = data.Rows(i)("group").ToString
            last_amount = data.Rows(i)("amount").ToString
            last_due_date = data.Rows(i)("due_date").ToString

            'add border bottom
            If i = data.Rows.Count - 1 Then
                no.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                group.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                amount.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                due_date.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                follow_up_date.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                follow_up.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
                follow_up_result.Borders = no.Borders Or DevExpress.XtraPrinting.BorderSide.Bottom
            End If

            'last loop
            If i = data.Rows.Count - 1 Then
                XrTable.Rows.Item(i_group).Cells.Item(0).RowSpan = c_group
                XrTable.Rows.Item(i_group).Cells.Item(1).RowSpan = c_group
                XrTable.Rows.Item(i_amount).Cells.Item(2).RowSpan = c_amount
                XrTable.Rows.Item(i_due_date).Cells.Item(3).RowSpan = c_due_date

                XrTable.Rows.Item(i_group).Cells.Item(0).Text = i_no
            End If
        Next
    End Sub
End Class