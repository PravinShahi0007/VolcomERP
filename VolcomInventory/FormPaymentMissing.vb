﻿Public Class FormPaymentMissing
    Private Sub FormPaymentMissing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormPaymentMissing_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()

    End Sub

    Sub form_print()

    End Sub

    Private Sub FormPaymentMissing_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormPaymentMissing_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class