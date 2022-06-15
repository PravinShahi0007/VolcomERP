Public Class FormTargetSAS
    Private Sub BtnImportFromXLS_Click(sender As Object, e As EventArgs) Handles BtnImportFromXLS.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "69"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormTargetSAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormTargetSAS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormTargetSAS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormTargetSAS_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class