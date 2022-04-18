Public Class FormProductionKOApp
    Public id_ko As String = "-1"
    Public id_pps As String = "-1"

    Private Sub FormProductionKOApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ko()
    End Sub

    Sub load_ko()
        Try
            FormProductionKO.Dispose()
        Catch ex As Exception
        End Try
        PCKO.Controls.Clear()
        FormProductionKO.TopLevel = False
        PCKO.Controls.Add(FormProductionKO)
        FormProductionKO.id_ko = id_ko
        FormProductionKO.is_view = "1"
        FormProductionKO.Show()
        FormProductionKO.ControlBox = False
        FormProductionKO.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        FormProductionKO.Focus()
        FormProductionKO.Dock = DockStyle.Fill
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "405"
        FormReportMark.ShowDialog()
    End Sub
End Class