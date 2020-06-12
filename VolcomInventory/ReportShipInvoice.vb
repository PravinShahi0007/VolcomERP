Public Class ReportShipInvoice
    Public id As String = ""
    Public data As DataTable = New DataTable
    Public id_pre As String = ""
    Public report_mark_type As String = ""

    Private Sub ReportShipInvoice_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'detail
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        Dim total As Decimal = 0.00

        For i = 0 To data.Rows.Count - 1
            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 0
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'acc_name
            Dim acc_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            acc_name.Text = data.Rows(i)("acc_name").ToString
            acc_name.BorderWidth = 0
            acc_name.Font = New Font(acc_name.Font.FontFamily, acc_name.Font.Size, FontStyle.Regular)

            'acc_description
            Dim acc_description As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            acc_description.Text = data.Rows(i)("acc_description").ToString
            acc_description.BorderWidth = 0
            acc_description.Font = New Font(acc_description.Font.FontFamily, acc_description.Font.Size, FontStyle.Regular)

            'note
            Dim note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            note.Text = data.Rows(i)("note").ToString
            note.BorderWidth = 0
            note.Font = New Font(note.Font.FontFamily, note.Font.Size, FontStyle.Regular)

            'value
            Dim value As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            value.Text = Format(data.Rows(i)("value"), "##,##0")
            value.BorderWidth = 0
            value.Font = New Font(value.Font.FontFamily, value.Font.Size, FontStyle.Regular)

            total = total + data.Rows(i)("value")
        Next

        XrTableRow2.HeightF = 17

        RowTotalAmount.Text = Format(total, "##,##0")

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If

        LabelTitleOwnComp.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
        LabelOwnCompNPWP.Text = execute_query("SELECT npwp FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
    End Sub
End Class