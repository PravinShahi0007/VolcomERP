Public Class FormSalesReturnOptionView
    Private Sub FormSalesReturnOptionView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        FormViewSalesReturn.openCombine()
        Close()
    End Sub

    Private Sub FormSalesReturnOptionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleButton1.Text = SimpleButton1.Text + " " + FormViewSalesReturn.TxtSalesReturnNumber.Text
        SimpleButton2.Text = SimpleButton2.Text + " " + FormViewSalesReturn.TxtCombineNumber.Text
    End Sub
End Class