Public Class FormPromoZalora

    Private Sub FormPromoZalora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub newPropose()

    End Sub

    Sub viewData()

    End Sub

    Sub viewDetail()

    End Sub

    Sub printList()

    End Sub

    Private Sub FormPromoZalora_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPromoZalora_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class