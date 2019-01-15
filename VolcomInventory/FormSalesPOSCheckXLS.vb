Public Class FormSalesPOSCheckXLS
    Public dt As DataTable

    Private Sub FormSalesPOSCheckXLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        GCData.DataSource = dt
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesPOSCheckXLS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        FormSalesPOSDet.is_continue_load = False
        Close()
    End Sub

    Private Sub BtnSkip_Click(sender As Object, e As EventArgs) Handles BtnSkip.Click
        Close()
    End Sub
End Class