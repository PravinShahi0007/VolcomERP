Public Class FormSUMockMark
    Private Sub BProcess_Click(sender As Object, e As EventArgs) Handles BProcess.Click
        Dim report_mark_type As String = "-1"
        Dim id_report As String = "-1"

        report_mark_type = TEReportMarkType.Text
        id_report = TEIdReport.Text

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = report_mark_type
        showpopup.id_report = id_report
        showpopup.show()
    End Sub
End Class