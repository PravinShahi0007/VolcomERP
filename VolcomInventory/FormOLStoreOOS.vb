Public Class FormOLStoreOOS
    Private Sub FormOLStoreOOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormOLStoreOOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData
    End Sub

    Sub viewData()

    End Sub
End Class