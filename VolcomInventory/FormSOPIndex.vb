Public Class FormSOPIndex
    Public is_super_admin As String = "2"

    Private Sub FormSOPIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not is_super_admin = "1" Then
            BNewSOP.Visible = False
        Else
            BNewSOP.Visible = True
        End If
    End Sub

    Private Sub FormSOPIndex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BNewSOP_Click(sender As Object, e As EventArgs) Handles BNewSOP.Click
        FormSOPNew.ShowDialog()
    End Sub
End Class