Public Class FormSalesPOSNoStockAdd
    Private Sub FormSalesPOSNoStockAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCode.Focus()
    End Sub

    Sub add()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        add()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormSalesPOSNoStockAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class