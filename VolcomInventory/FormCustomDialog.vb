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
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormCustomDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.Audio.Play(Application.StartupPath + "\error.wav")
        Catch ex As Exception
        End Try
    End Sub
End Class