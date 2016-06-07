Imports System.Net.Mail

Public Class ClassSendingMail

    Sub send_mail()
        Dim mail As MailMessage = New MailMessage("septian@volcom.mail", "user@hotmail.com")
        Dim client As SmtpClient = New SmtpClient()
        client.Port = 25
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.UseDefaultCredentials = False
        client.Host = "192.168.1.4"
        client.Credentials = New System.Net.NetworkCredential("septian", "volcom10")
        mail.Subject = "No reply ceritanya"
        mail.Body = "This is my test email  body"
        client.Send(mail)
    End Sub

End Class
