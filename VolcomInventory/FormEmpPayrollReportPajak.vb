Public Class FormEmpPayrollReportPajak
    Public id_payroll As String = "-1"

    Private Sub FormEmpPayrollReportPajak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_payroll_pajak('" + id_payroll + "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCPajak.DataSource = data

        GVPajak.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportPajak_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        ReportEmpPayrollReportPajak.data = GCPajak.DataSource

        Dim Report As New ReportEmpPayrollReportPajak()

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVPajak.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVPajak.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class