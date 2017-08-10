Public Class FormEmpUniOrderSingle
    Public dt As DataTable

    Private Sub FormEmpUniOrderSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpUniOrderSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCDesign.DataSource = dt
        GVDesign.FocusedRowHandle = 0
    End Sub

    Sub closeForm()
        Close()
    End Sub

    Sub choose()
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormEmpUniOrderSingle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            choose()
        End If
    End Sub

    Private Sub GVDesign_DoubleClick(sender As Object, e As EventArgs) Handles GVDesign.DoubleClick
        choose()
    End Sub
End Class