Public Class FormSalesInv
    Private Sub FormSalesInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormSalesInv_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesInv_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class