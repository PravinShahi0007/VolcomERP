Public Class ReportAccountingWorksheet
    Public data As DataTable = New DataTable

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'new data with group, detail & total
        Dim data_group As DataTable = New DataTable

        data_group.Columns.Add("number", GetType(String))
        data_group.Columns.Add("acc_name", GetType(String))
        data_group.Columns.Add("beginning", GetType(Decimal))
        data_group.Columns.Add("debit", GetType(Decimal))
        data_group.Columns.Add("credit", GetType(Decimal))
        data_group.Columns.Add("ending", GetType(Decimal))
        data_group.Columns.Add("type", GetType(String))

        Dim last_parent_1 As String = ""
        Dim last_parent_2 As String = ""

        Dim b_last_parent_1 As Decimal = 0.00
        Dim d_last_parent_1 As Decimal = 0.00
        Dim c_last_parent_1 As Decimal = 0.00
        Dim e_last_parent_1 As Decimal = 0.00

        Dim b_last_parent_2 As Decimal = 0.00
        Dim d_last_parent_2 As Decimal = 0.00
        Dim c_last_parent_2 As Decimal = 0.00
        Dim e_last_parent_2 As Decimal = 0.00

        Dim total_beginning As Decimal = 0.0
        Dim total_debit As Decimal = 0.0
        Dim total_credit As Decimal = 0.0
        Dim total_ending As Decimal = 0.0

        For i = 0 To data.Rows.Count - 1
            If Not i = 0 Then
                'total
                If Not last_parent_2 = data.Rows(i)("acc_name_2").ToString Then
                    data_group.Rows.Add(
                        "SUB TOTAL: " + data.Rows(i - 1)("acc_name_2").ToString,
                        "",
                        b_last_parent_2,
                        d_last_parent_2,
                        c_last_parent_2,
                        e_last_parent_2,
                        "total"
                    )

                    b_last_parent_2 = 0.00
                    d_last_parent_2 = 0.00
                    c_last_parent_2 = 0.00
                    e_last_parent_2 = 0.00
                End If

                If Not last_parent_1 = data.Rows(i)("acc_name_1").ToString Then
                    data_group.Rows.Add(
                        "SUB TOTAL: " + data.Rows(i - 1)("acc_name_1").ToString,
                        "",
                        b_last_parent_1,
                        d_last_parent_1,
                        c_last_parent_1,
                        e_last_parent_1,
                        "total"
                    )

                    b_last_parent_1 = 0.00
                    d_last_parent_1 = 0.00
                    c_last_parent_1 = 0.00
                    e_last_parent_1 = 0.00
                End If
            End If

            'group
            If Not last_parent_1 = data.Rows(i)("acc_name_1").ToString Then
                data_group.Rows.Add(
                    data.Rows(i)("acc_name_1").ToString,
                    "",
                    0.00,
                    0.00,
                    0.00,
                    0.00,
                    "group"
                )
            End If

            If Not last_parent_2 = data.Rows(i)("acc_name_2").ToString Then
                data_group.Rows.Add(
                    data.Rows(i)("acc_name_2").ToString,
                    "",
                    0.00,
                    0.00,
                    0.00,
                    0.00,
                    "group"
                )
            End If

            If i = 0 Then
                last_parent_1 = data.Rows(i)("acc_name_1").ToString
                last_parent_2 = data.Rows(i)("acc_name_2").ToString
            End If

            'detail
            data_group.Rows.Add(
                data.Rows(i)("number").ToString,
                data.Rows(i)("acc_name").ToString,
                data.Rows(i)("beginning"),
                data.Rows(i)("debit"),
                data.Rows(i)("credit"),
                data.Rows(i)("ending"),
                ""
            )

            b_last_parent_1 = b_last_parent_1 + data.Rows(i)("beginning")
            d_last_parent_1 = d_last_parent_1 + data.Rows(i)("debit")
            c_last_parent_1 = c_last_parent_1 + data.Rows(i)("credit")
            e_last_parent_1 = e_last_parent_1 + data.Rows(i)("ending")

            b_last_parent_2 = b_last_parent_2 + data.Rows(i)("beginning")
            d_last_parent_2 = d_last_parent_2 + data.Rows(i)("debit")
            c_last_parent_2 = c_last_parent_2 + data.Rows(i)("credit")
            e_last_parent_2 = e_last_parent_2 + data.Rows(i)("ending")

            total_beginning += data.Rows(i)("beginning")
            total_debit += data.Rows(i)("debit")
            total_credit += data.Rows(i)("credit")
            total_ending += data.Rows(i)("ending")

            If i = data.Rows.Count - 1 Then
                'total
                data_group.Rows.Add(
                    "SUB TOTAL: " + data.Rows(i)("acc_name_2").ToString,
                    "",
                    b_last_parent_2,
                    d_last_parent_2,
                    c_last_parent_2,
                    e_last_parent_2,
                    "total"
                )

                data_group.Rows.Add(
                    "SUB TOTAL: " + data.Rows(i)("acc_name_1").ToString,
                    "",
                    b_last_parent_1,
                    d_last_parent_1,
                    c_last_parent_1,
                    e_last_parent_1,
                    "total"
                )
            End If

            last_parent_1 = data.Rows(i)("acc_name_1").ToString
            last_parent_2 = data.Rows(i)("acc_name_2").ToString
        Next

        Dim row_unit As DataRow = data_group.NewRow

        row_unit("number") = FormAccountingWorksheet.SLEUnit.Text
        row_unit("acc_name") = ""
        row_unit("beginning") = 0.00
        row_unit("debit") = 0.00
        row_unit("credit") = 0.00
        row_unit("ending") = 0.00
        row_unit("type") = "group"

        data_group.Rows.InsertAt(row_unit, 0)

        data_group.Rows.Add(
            "SUB TOTAL: " + FormAccountingWorksheet.SLEUnit.Text,
            "",
            total_beginning,
            total_debit,
            total_credit,
            total_ending,
            "total"
        )

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
            qty.Text = If(data_group.Rows(i)("beginning").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("beginning").ToString), "##,##0.00"))
            qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim debit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            debit.Text = If(data_group.Rows(i)("debit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("debit").ToString), "##,##0.00"))
            debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            debit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim credit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            credit.Text = If(data_group.Rows(i)("credit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("credit").ToString), "##,##0.00"))
            credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            credit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim balance As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            balance.Text = If(data_group.Rows(i)("ending").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("ending").ToString), "##,##0.00"))
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