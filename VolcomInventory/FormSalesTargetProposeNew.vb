Public Class FormSalesTargetProposeNew
    Private Sub FormSalesTargetProposeNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesTargetProposeNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class