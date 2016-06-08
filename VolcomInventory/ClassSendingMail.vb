Imports System.Net.Mail

Imports System.Text
Imports DevExpress.XtraRichEdit
Imports DevExpress.Utils
Imports DevExpress.Office.Services
Imports System.Net.Mime
Imports System.IO
Imports DevExpress.XtraRichEdit.Export
Imports DevExpress.Office.Utils

Public Class ClassSendingMail
    Sub send_mail(ByVal email_to As String, ByVal subject As String, ByVal body As String)
        Dim mail As MailMessage = New MailMessage("septian@volcom.mail", email_to)
        Dim client As SmtpClient = New SmtpClient()
        client.Port = 25
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.UseDefaultCredentials = False
        client.Host = "192.168.1.4"
        client.Credentials = New System.Net.NetworkCredential("septian@volcom.mail", "septian")
        mail.Subject = subject
        mail.Body = body
        client.Send(mail)
    End Sub
    Sub send_email_html(ByVal email_to As String, ByVal subject As String, ByVal body As String)
        Dim mail As MailMessage = New MailMessage("septian@volcom.mail", email_to)
        Dim client As SmtpClient = New SmtpClient()
        client.Port = 25
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.UseDefaultCredentials = False
        client.Host = "192.168.1.4"
        client.Credentials = New System.Net.NetworkCredential("septian@volcom.mail", "septian")
        mail.Subject = subject
        mail.IsBodyHtml = True
        mail.Body = body
        client.Send(mail)
    End Sub
End Class
