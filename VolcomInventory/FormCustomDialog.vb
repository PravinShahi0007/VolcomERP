Public Class FormCustomDialog
    Public rmt As String = "-1"
    Public id_report As String = "-1"

    Private Sub FormCustomDialog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Close()
    End Sub

    Private Sub BtnAction_Click(sender As Object, e As EventArgs) Handles BtnAction.Click
        Cursor = Cursors.WaitCursor
        If rmt = "39" Then
            Dim so As New ClassShowPopUp()
            so.report_mark_type = rmt
            so.id_report = id_report
            so.show()
        ElseIf rmt = "48" Or rmt = "54" Or rmt = "117" Or rmt = "183" Then
            Dim inv As New ClassShowPopUp()
            inv.report_mark_type = rmt
            inv.id_report = id_report
            inv.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormCustomDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Audio.Play(Application.StartupPath + "\error.wav")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        If rmt = "48" Or rmt = "54" Or rmt = "117" Or rmt = "183" Then
            FormSalesPOSDet.discard_transaction = True
        End If
        Close()
    End Sub
End Class