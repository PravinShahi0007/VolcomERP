Public Class ClassFunctionEmail
    Sub send_email(email_from As String(), email_to As List(Of String()), email_cc As List(Of String()), email_subject As String, email_body As String)
        Dim is_ssl As String = get_setup_field("system_email_is_ssl").ToString

        Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient()

        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

        'from
        Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(email_from(0), email_from(1))
        mail.From = from_mail

        'to
        For i = 0 To email_to.Count - 1
            Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(email_to(i)(0), email_to(i)(1))
            mail.To.Add(to_mail)
        Next

        'cc
        For i = 0 To email_cc.Count - 1
            Dim cc_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(email_cc(i)(0), email_cc(i)(1))
            mail.CC.Add(cc_mail)
        Next

        mail.Subject = email_subject

        mail.IsBodyHtml = True

        mail.Body = email_body

        client.Send(mail)
    End Sub
End Class
