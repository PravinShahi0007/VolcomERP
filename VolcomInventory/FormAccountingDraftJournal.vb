Public Class FormAccountingDraftJournal
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"
    Private Sub FormAccountingDraftJournal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub FormAccountingDraftJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class