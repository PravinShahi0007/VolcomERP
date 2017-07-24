Public Class FormEmpUniOrderSingle
    Private Sub FormEmpUniOrderSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpUniOrderSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub closeForm()
        Close()
    End Sub

    Sub searchDesign()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpUniOrderSingle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            closeForm()
        ElseIf e.KeyCode = Keys.Control AndAlso Keys.S
            searchDesign()
        End If
    End Sub


End Class