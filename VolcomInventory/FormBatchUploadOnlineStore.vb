Public Class FormBatchUploadOnlineStore
    Private Sub FormBatchUploadOnlineStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormBatchUploadOnlineStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBatchUploadOnlineStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBatchUploadOnlineStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class