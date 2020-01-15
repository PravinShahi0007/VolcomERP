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

        'Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        'For i = 0 To data_group.Rows.Count - 1
        '    row = XrTable.InsertRowBelow(row)

        '    row.HeightF = 20

        '    If data_group.Rows(i)("type").ToString = "group" Then
        '        If row.Cells.Count = 10 Then
        '            row.Cells.Remove(row.Cells.Item(9))
        '            row.Cells.Remove(row.Cells.Item(8))
        '            row.Cells.Remove(row.Cells.Item(7))
        '            row.Cells.Remove(row.Cells.Item(6))
        '            row.Cells.Remove(row.Cells.Item(5))
        '            row.Cells.Remove(row.Cells.Item(4))
        '            row.Cells.Remove(row.Cells.Item(3))
        '            row.Cells.Remove(row.Cells.Item(2))
        '            row.Cells.Remove(row.Cells.Item(1))
        '        End If
        '    End If

        '    Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
        '    number.Text = data_group.Rows(i)("number").ToString
        '    number.WidthF = XrTableCellNo.WidthF

        '    If data_group.Rows(i)("type").ToString = "detail" Then
        '        If row.Cells.Count = 1 Then
        '            Dim report_number As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            report_number.Text = data_group.Rows(i)("report_number").ToString
        '            report_number.WidthF = XrTableCellReportNumber.WidthF
        '            row.InsertCell(report_number, 1)

        '            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            comp_number.Text = data_group.Rows(i)("comp_number").ToString
        '            comp_number.WidthF = XrTableCellCompany.WidthF
        '            row.InsertCell(comp_number, 2)

        '            Dim date_created As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            date_created.Text = data_group.Rows(i)("date_created").ToString
        '            date_created.WidthF = XrTableCellJournalDate.WidthF
        '            row.InsertCell(date_created, 3)

        '            Dim report_number_ref As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            report_number_ref.Text = data_group.Rows(i)("report_number_ref").ToString
        '            report_number_ref.WidthF = XrTableCellReff.WidthF
        '            row.InsertCell(report_number_ref, 4)

        '            Dim acc_trans_note As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            acc_trans_note.Text = data_group.Rows(i)("acc_trans_note").ToString
        '            acc_trans_note.WidthF = XrTableCellDescription.WidthF
        '            row.InsertCell(acc_trans_note, 5)

        '            Dim qty As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            qty.Text = data_group.Rows(i)("qty").ToString
        '            qty.WidthF = XrTableCellQty.WidthF
        '            row.InsertCell(qty, 6)

        '            Dim debit As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            debit.Text = data_group.Rows(i)("debit").ToString
        '            debit.WidthF = XrTableCellDebit.WidthF
        '            row.InsertCell(debit, 7)

        '            Dim credit As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            credit.Text = data_group.Rows(i)("credit").ToString
        '            credit.WidthF = XrTableCellCredit.WidthF
        '            row.InsertCell(credit, 8)

        '            Dim balance As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        '            balance.Text = data_group.Rows(i)("balance").ToString
        '            balance.WidthF = XrTableCellBalance.WidthF
        '            row.InsertCell(balance, 9)
        '        End If
        '    End If
        'Next
    End Sub
End Class