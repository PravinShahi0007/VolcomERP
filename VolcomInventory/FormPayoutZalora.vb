Public Class FormPayoutZalora
    Private Sub FormPayoutZalora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormPayoutZalora_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim p As New ClassPayoutZalora()
        Dim query As String = p.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "Zalora Payout List")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSycn_Click(sender As Object, e As EventArgs) Handles BtnSycn.Click
        syncPayout()
    End Sub

    Sub syncPayout()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Try
            Dim zal As New ClassZaloraApi()
            zal.get_payout()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub
End Class