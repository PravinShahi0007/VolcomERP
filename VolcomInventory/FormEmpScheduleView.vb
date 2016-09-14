Public Class FormEmpScheduleView
    Public id_employee As String = "-1"

    Private Sub FormEmpScheduleView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormEmpScheduleView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

End Class