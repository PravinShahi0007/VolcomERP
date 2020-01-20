Public Class ReportAccountingLedger
    Public data As DataTable = New DataTable
    Public id_is_det As String = "1"

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data_group As DataTable = New DataTable
        Dim count_group As Integer = Integer.Parse(data.Columns.Item(data.Columns.Count - 1).ColumnName.Replace("parent_group_", ""))
        Dim last_group As List(Of String) = New List(Of String)

        For i = 0 To count_group
            last_group.Add("")
        Next

        last_group.Add("")

        data_group.Columns.Add("number")
        data_group.Columns.Add("report_number")
        data_group.Columns.Add("comp_number")
        data_group.Columns.Add("date_created")
        data_group.Columns.Add("report_number_ref")
        data_group.Columns.Add("acc_trans_note")
        data_group.Columns.Add("qty")
        data_group.Columns.Add("debit")
        data_group.Columns.Add("credit")
        data_group.Columns.Add("balance")
        data_group.Columns.Add("type")

        Dim no As Integer = 1

        For i = 0 To data.Rows.Count - 1
            'header
            For j = count_group To 0 Step -1
                Dim group_j As String = "group_" + j.ToString

                If Not last_group(j) = data.Rows(i)(group_j).ToString Then
                    data_group.Rows.Add(
                        data.Rows(i)(group_j).ToString,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "group"
                    )
                End If

                last_group(j) = data.Rows(i)(group_j).ToString
            Next

            If Not last_group(count_group + 1) = data.Rows(i)("acc_name").ToString Then
                data_group.Rows.Add(
                    data.Rows(i)("acc_name").ToString,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "group"
                )

                last_group(count_group + 1) = data.Rows(i)("acc_name").ToString

                no = 1
            End If

            data_group.Rows.Add(
                no.ToString,
                data.Rows(i)("report_number").ToString,
                data.Rows(i)("comp_number").ToString,
                data.Rows(i)("date_created").ToString,
                data.Rows(i)("report_number_ref").ToString,
                data.Rows(i)("acc_trans_note").ToString,
                data.Rows(i)("qty").ToString,
                data.Rows(i)("debit").ToString,
                data.Rows(i)("credit").ToString,
                data.Rows(i)("balance").ToString,
                "detail"
            )

            no = no + 1
        Next

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        For i = 0 To data_group.Rows.Count - 1
            row = XrTable.InsertRowBelow(row)

            row.Font = New Font(XrTableRow.Font.FontFamily, 7.75, If(data_group.Rows(i)("type").ToString = "detail", FontStyle.Regular, FontStyle.Bold))
            row.HeightF = 20
            row.Tag = data_group.Rows(i)("type").ToString

            Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            number.Text = data_group.Rows(i)("number").ToString + If(data_group.Rows(i)("type").ToString = "detail", ".", "")
            number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim report_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            report_number.Text = data_group.Rows(i)("report_number").ToString
            report_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            report_number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            comp_number.Text = data_group.Rows(i)("comp_number").ToString
            comp_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            comp_number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim date_created As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            date_created.Text = If(data_group.Rows(i)("date_created").ToString = "", "", Date.Parse(data_group.Rows(i)("date_created").ToString).ToString("dd MMM yyyy"))
            date_created.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            date_created.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim report_number_ref As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            report_number_ref.Text = data_group.Rows(i)("report_number_ref").ToString
            report_number_ref.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            report_number_ref.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim acc_trans_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            acc_trans_note.Text = data_group.Rows(i)("acc_trans_note").ToString
            acc_trans_note.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            acc_trans_note.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            qty.Text = If(data_group.Rows(i)("qty").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("qty").ToString), "##,##0"))
            qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim debit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            debit.Text = If(data_group.Rows(i)("debit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("debit").ToString), "##,##0"))
            debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            debit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim credit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
            credit.Text = If(data_group.Rows(i)("credit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("credit").ToString), "##,##0"))
            credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            credit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim balance As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
            balance.Text = If(data_group.Rows(i)("balance").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("balance").ToString), "##,##0"))
            balance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            balance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            balance.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
        Next

        'rowspan
        For i = 0 To XrTable.Rows.Count - 1
            If XrTable.Rows.Item(i).Tag = "group" Then
                XrTable.Rows.Item(i).Cells.RemoveAt(9)
                XrTable.Rows.Item(i).Cells.RemoveAt(8)
                XrTable.Rows.Item(i).Cells.RemoveAt(7)
                XrTable.Rows.Item(i).Cells.RemoveAt(6)
                XrTable.Rows.Item(i).Cells.RemoveAt(5)
                XrTable.Rows.Item(i).Cells.RemoveAt(4)
                XrTable.Rows.Item(i).Cells.RemoveAt(3)
                XrTable.Rows.Item(i).Cells.RemoveAt(2)
                XrTable.Rows.Item(i).Cells.RemoveAt(1)
            End If
        Next
    End Sub
End Class