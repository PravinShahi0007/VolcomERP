Public Class FormAccountingLedger
    Private Sub FormAccountingLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormAccountingLedger_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormAccountingLedger_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormAccountingLedger_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_form()

    End Sub

    Sub print_form()

    End Sub
End Class