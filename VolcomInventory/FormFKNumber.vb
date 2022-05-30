Public Class FormFKNumber

    Private Sub FormFKNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        If Txtno2.Text = "" Or Txtno3.Text = "" Then
            warningCustom("Please complete all data")
        Else
            Cursor = Cursors.WaitCursor
            FormImportExcel.id_pop_up = "68"
            FormImportExcel.ShowDialog()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormFKNumber_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class