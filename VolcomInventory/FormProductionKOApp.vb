Public Class FormProductionKOApp
    Public id_ko As String = "-1"
    Public id_pps As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormProductionKOApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_ko()
    End Sub

    Sub load_ko()
        Dim s As String = "SELECT id_prod_order_ko FROM tb_prod_order_ko_app WHERE id_prod_order_ko_app='" & id_pps & "'"
        Dim dt As DataTable = execute_query(s, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            id_ko = dt.Rows(0)("id_prod_order_ko").ToString

            Try
                FormProductionKO.Dispose()
            Catch ex As Exception
            End Try

            XTPKO.Controls.Clear()
            FormProductionKO.TopLevel = False
            XTPKO.Controls.Add(FormProductionKO)
            FormProductionKO.id_ko = id_ko
            FormProductionKO.is_view = "1"
            FormProductionKO.is_popup = True
            FormProductionKO.Show()
            FormProductionKO.ControlBox = False
            FormProductionKO.FormBorderStyle = FormBorderStyle.None
            FormProductionKO.Focus()
            FormProductionKO.Dock = DockStyle.Fill
        Else
            warningCustom("KO not found")
            Close()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pps
        FormReportMark.is_view = is_view
        FormReportMark.report_mark_type = "405"
        FormReportMark.ShowDialog()
    End Sub
End Class