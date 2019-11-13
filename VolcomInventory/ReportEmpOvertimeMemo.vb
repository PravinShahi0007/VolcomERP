Public Class ReportEmpOvertimeMemo
    Public id As String = "0"
    Public id_pre As String = "-1"
    Public dt As DataTable = New DataTable

    Private Sub ReportEmpOvertimeMemo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        For i = 0 To dt.Rows.Count - 1
            If i = 0 Then
                row = XrTable.InsertRowBelow(XrTableRowHeader)
            Else
                row = XrTable.InsertRowBelow(row)
            End If

            row.Cells.Item(0).Text = dt.Rows(i)("date").ToString
            row.Cells.Item(1).Text = dt.Rows(i)("person_total").ToString
            row.Cells.Item(2).Text = "Rp. " + Format(dt.Rows(i)("consumption_total"), "##,##0")

            row.Cells.Item(1).TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            row.Cells.Item(2).TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Next

        Dim report_mark_type As String = execute_query("SELECT report_mark_type FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub
End Class