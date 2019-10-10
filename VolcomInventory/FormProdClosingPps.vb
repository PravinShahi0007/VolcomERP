Public Class FormProdClosingPps
    Public id_pps As String = "-1"

    Private Sub FormProdClosingPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_header()
        load_det()
    End Sub

    Sub load_header()
        Dim query As String = ""
    End Sub

    Sub load_det()
        Dim query As String = ""
    End Sub

    Private Sub FormProdClosingPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class