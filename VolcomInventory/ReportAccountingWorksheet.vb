﻿Public Class ReportAccountingWorksheet
    Public data As DataTable = New DataTable
    Public id_is_det As String = "1"

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data_group As DataTable = New DataTable
        Dim count_group As Integer = If(id_is_det = "1", Integer.Parse(data.Columns.Item(data.Columns.Count - 1).ColumnName.Replace("parent_group_", "")), -1)
        Dim last_group As List(Of String) = New List(Of String)

        For i = 0 To count_group
            last_group.Add("")
        Next

        last_group.Add("")

        'summaries
        Dim summaries_beginning As List(Of Tuple(Of String, Int64)) = New List(Of Tuple(Of String, Int64))
        Dim summaries_debit As List(Of Tuple(Of String, Int64)) = New List(Of Tuple(Of String, Int64))
        Dim summaries_credit As List(Of Tuple(Of String, Int64)) = New List(Of Tuple(Of String, Int64))
        Dim summaries_balance As List(Of Tuple(Of String, Int64)) = New List(Of Tuple(Of String, Int64))

        Dim r As Integer = -1

        While FormAccountingWorksheet.GVAccountingWorksheet.IsValidRowHandle(r)
            Dim g_name As String = FormAccountingWorksheet.GVAccountingWorksheet.GetGroupRowDisplayText(r).Replace("Account: ", "")
            Dim g_beginning As Int64 = FormAccountingWorksheet.GVAccountingWorksheet.GetGroupSummaryValue(r, FormAccountingWorksheet.GVAccountingWorksheet.GroupSummary.Item(3))
            Dim g_debit As Int64 = FormAccountingWorksheet.GVAccountingWorksheet.GetGroupSummaryValue(r, FormAccountingWorksheet.GVAccountingWorksheet.GroupSummary.Item(0))
            Dim g_credit As Int64 = FormAccountingWorksheet.GVAccountingWorksheet.GetGroupSummaryValue(r, FormAccountingWorksheet.GVAccountingWorksheet.GroupSummary.Item(1))
            Dim g_balance As Int64 = FormAccountingWorksheet.GVAccountingWorksheet.GetGroupSummaryValue(r, FormAccountingWorksheet.GVAccountingWorksheet.GroupSummary.Item(4))

            summaries_beginning.Add(Tuple.Create(g_name.Substring(0, g_name.Length - 1), g_beginning))
            summaries_debit.Add(Tuple.Create(g_name.Substring(0, g_name.Length - 1), g_debit))
            summaries_credit.Add(Tuple.Create(g_name.Substring(0, g_name.Length - 1), g_credit))
            summaries_balance.Add(Tuple.Create(g_name.Substring(0, g_name.Length - 1), g_balance))

            r = r - 1
        End While

        'new data with group, detail & total
        data_group.Columns.Add("number")
        data_group.Columns.Add("acc_name")
        data_group.Columns.Add("beginning")
        data_group.Columns.Add("debit")
        data_group.Columns.Add("credit")
        data_group.Columns.Add("ending")
        data_group.Columns.Add("type")

        For i = 0 To data.Rows.Count - 1
            'total
            If Not i = 0 Then
                For j = 0 To count_group
                    Dim group_j As String = "group_" + j.ToString

                    If Not last_group(j) = data.Rows(i)(group_j).ToString Then
                        'match summaries
                        Dim beginning As Int64 = 0
                        Dim debit As Int64 = 0
                        Dim credit As Int64 = 0
                        Dim balance As Int64 = 0

                        For Each value As Tuple(Of String, Int64) In summaries_beginning
                            If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                                beginning = value.Item2
                            End If
                        Next

                        For Each value As Tuple(Of String, Int64) In summaries_debit
                            If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                                debit = value.Item2
                            End If
                        Next

                        For Each value As Tuple(Of String, Int64) In summaries_credit
                            If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                                credit = value.Item2
                            End If
                        Next

                        For Each value As Tuple(Of String, Int64) In summaries_balance
                            If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                                balance = value.Item2
                            End If
                        Next

                        'add total
                        data_group.Rows.Add(
                            "SUB TOTAL: " + data.Rows(i - 1)(group_j).ToString,
                            "",
                            beginning,
                            debit,
                            credit,
                            balance,
                            "total"
                        )
                    End If
                Next
            End If

            'group
            For j = count_group To 0 Step -1
                Dim group_j As String = "group_" + j.ToString

                If Not last_group(j) = data.Rows(i)(group_j).ToString Then
                    'add group
                    data_group.Rows.Add(
                        data.Rows(i)(group_j).ToString,
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

            'add detail
            data_group.Rows.Add(
                data.Rows(i)("number").ToString,
                data.Rows(i)("acc_name").ToString,
                data.Rows(i)("beginning").ToString,
                data.Rows(i)("debit").ToString,
                data.Rows(i)("credit").ToString,
                data.Rows(i)("ending").ToString,
                "detail"
            )

            'last total
            If i = data.Rows.Count - 1 Then
                For j = 0 To count_group
                    Dim group_j As String = "group_" + j.ToString

                    'match summaries
                    Dim beginning As Int64 = 0
                    Dim debit As Int64 = 0
                    Dim credit As Int64 = 0
                    Dim balance As Int64 = 0

                    For Each value As Tuple(Of String, Int64) In summaries_beginning
                        If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                            beginning = value.Item2
                        End If
                    Next

                    For Each value As Tuple(Of String, Int64) In summaries_debit
                        If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                            debit = value.Item2
                        End If
                    Next

                    For Each value As Tuple(Of String, Int64) In summaries_credit
                        If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                            credit = value.Item2
                        End If
                    Next

                    For Each value As Tuple(Of String, Int64) In summaries_balance
                        If data.Rows(i - 1)(group_j).ToString = value.Item1 Then
                            balance = value.Item2
                        End If
                    Next

                    'add total
                    data_group.Rows.Add(
                        "SUB TOTAL: " + data.Rows(i - 1)(group_j).ToString,
                        "",
                        beginning,
                        debit,
                        credit,
                        balance,
                        "total"
                    )
                Next
            End If
        Next

        'add table row
        XrTable.BeginInit()

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        For i = 0 To data_group.Rows.Count - 1
            row = XrTable.InsertRowBelow(row)

            row.Font = New Font(XrTableRow.Font.FontFamily, 7.75, If(data_group.Rows(i)("type").ToString = "group", FontStyle.Bold, FontStyle.Regular))
            row.HeightF = 20
            row.Tag = data_group.Rows(i)("type").ToString

            Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            number.Text = data_group.Rows(i)("number").ToString + If(data_group.Rows(i)("type").ToString = "detail", ".", "")
            number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim acc_trans_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            acc_trans_note.Text = data_group.Rows(i)("acc_name").ToString
            acc_trans_note.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            acc_trans_note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            acc_trans_note.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            qty.Text = If(data_group.Rows(i)("beginning").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("beginning").ToString), "##,##0"))
            qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim debit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            debit.Text = If(data_group.Rows(i)("debit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("debit").ToString), "##,##0"))
            debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            debit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim credit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            credit.Text = If(data_group.Rows(i)("credit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("credit").ToString), "##,##0"))
            credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            credit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim balance As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            balance.Text = If(data_group.Rows(i)("ending").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("ending").ToString), "##,##0"))
            balance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            balance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            balance.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
        Next

        'rowspan
        For i = 0 To XrTable.Rows.Count - 1
            If XrTable.Rows.Item(i).Tag = "group" Then
                XrTable.Rows.Item(i).Cells.RemoveAt(5)
                XrTable.Rows.Item(i).Cells.RemoveAt(4)
                XrTable.Rows.Item(i).Cells.RemoveAt(3)
                XrTable.Rows.Item(i).Cells.RemoveAt(2)
                XrTable.Rows.Item(i).Cells.RemoveAt(1)
            ElseIf XrTable.Rows.Item(i).Tag = "total" Then
                XrTable.Rows.Item(i).Cells.RemoveAt(1)

                XrTable.Rows.Item(i).Cells.Item(0).WidthF = XrTableCellNo.WidthF + XrTableCellAccount.WidthF
            End If
        Next

        XrTable.EndInit()
    End Sub
End Class