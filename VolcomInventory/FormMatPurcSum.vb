Public Class FormMatPurcSum
    Public dt As DataTable

    Private Sub FormMatPurcSum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LSeason.Text = FormMatPurchase.LESeason.Text
        LPeriod.Text = Date.Parse(FormMatPurchase.DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " - " & Date.Parse(FormMatPurchase.DEStart.EditValue.ToString).ToString("dd MMMM yyyy")
        '
        GCProd.DataSource = dt

        Dim string_awal As String = ""
        string_awal = GVProd.ActiveFilterString

        GVProd.BestFitColumns()
    End Sub

    Private Sub FormProductionPrint_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        '
        GridColumnNo.VisibleIndex = 0
        For i As Integer = 0 To GVProd.RowCount - 1
            GVProd.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        ReportListProd.rmt = "13"
        ReportListProd.dt = GCProd.DataSource
        Dim Report As New ReportListProd()
        Report.LTitle.Text = "Summary PO"
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVProd.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVProd.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVProd)
        Report.GVProd.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)
        Report.GVProd.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)
        Report.GVProd.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Regular)
        '
        'Parse val
        Report.LSeason.Text = LSeason.Text
        Report.LPeriod.Text = LPeriod.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        GridColumnNo.Visible = False
        Cursor = Cursors.Default
    End Sub
End Class