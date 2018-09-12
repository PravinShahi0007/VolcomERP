Public Class FormReportMarkCancelPick
    Private Sub FormReportMarkCancelPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim qb As New ClassShowPopUp()
        qb.report_mark_type = FormReportMarkCancel.LEReportMarkType.EditValue.ToString
        qb.load_detail()
        Console.WriteLine(qb.query_view)
        Dim data As DataTable = execute_query(qb.query_view, -1, True, "", "", "", "")
        GCReportList.DataSource = data
        qb.apply_gv_style(GVReportList)
    End Sub

    Private Sub FormReportMarkCancelPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVReportList.RowCount > 0 Then
            For i As Integer = 0 To ((GVReportList.RowCount - 1) - GetGroupRowCount(GVReportList))
                If CheckEditSelAll.Checked = False Then
                    GVReportList.SetRowCellValue(i, "is_check", "no")
                Else
                    GVReportList.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub
End Class