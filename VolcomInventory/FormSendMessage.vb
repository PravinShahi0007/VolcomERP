Public Class FormSendMessage
    Private Sub BSendMessage_Click(sender As Object, e As EventArgs) Handles BSendMessage.Click
        Dim mail As ClassSendEmail = New ClassSendEmail()
        mail.report_mark_type = "weekly_attn"
        mail.send_email_html("Contoh", TEEmailTo.Text, TESubject.Text, TESubject.Text, MEBody.Text)
    End Sub
End Class