Public Class FormPriceChecker
    Private Sub FormPriceChecker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPriceChecker_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            startScan()
        End If
    End Sub

    Sub startScan()

    End Sub

    Private Sub BtnStartScan_Click(sender As Object, e As EventArgs) Handles BtnStartScan.Click
        startScan()
    End Sub

    Sub defaultInput()
        LabelDesc.Text = "-"
        LabelPrice.Text = "Rp. 0"
        LabelPriceType.Text = "-"
    End Sub
End Class