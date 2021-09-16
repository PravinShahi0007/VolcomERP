Public Class FormCapsule
    Private Sub FormCapsule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormCapsule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnExportXLS_Click(sender As Object, e As EventArgs) Handles BtnExportXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading data")
        Dim soh_date As String = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "CALL view_capsule('" + soh_date + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit columns")
        GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub
End Class