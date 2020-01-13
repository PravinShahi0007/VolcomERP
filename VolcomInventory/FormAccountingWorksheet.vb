Public Class FormAccountingWorksheet
    Private Sub FormAccountingWorksheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormAccountingWorksheet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingWorksheet_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingWorksheet_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Sub print_form()

    End Sub
End Class