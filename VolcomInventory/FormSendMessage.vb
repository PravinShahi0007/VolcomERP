Public Class FormSendMessage
    Private Sub BSendMessage_Click(sender As Object, e As EventArgs) Handles BSendMessage.Click
        Dim mail As ClassSendingMail = New ClassSendingMail()
        'MsgBox(MEBody.Text)
        mail.send_email_html("Contoh", TEEmailTo.Text, TESubject.Text, TESubject.Text, MEBody.Text)
    End Sub
End Class