Imports System.IO
Imports System.Net.Mail

Public Class ClassSendEmail
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"

    Sub send_email_html(ByVal send_to As String, ByVal email_to As String, ByVal subject As String, ByVal number As String, ByVal body As String)
        If report_mark_type = "95" Then
            ' Create a new report. 

            ReportEmpLeave.id_report = id_report
            ReportEmpLeave.report_mark_type = report_mark_type

            Dim Report As New ReportEmpLeave()

            ' Create a new memory stream and export the report into it as PDF.
            Dim Mem As New MemoryStream()
            Report.ExportToPdf(Mem)

            ' Create a new attachment and put the PDF report into it.
            Mem.Seek(0, System.IO.SeekOrigin.Begin)
            '
            Dim Att = New Attachment(Mem, "TestReport.pdf", "application/pdf")
            '
            Dim mail As MailMessage = New MailMessage("septian@volcom.mail", email_to)
            mail.Attachments.Add(Att)
            Dim client As SmtpClient = New SmtpClient()
            client.Port = 25
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = "192.168.1.4"
            client.Credentials = New System.Net.NetworkCredential("septian@volcom.mail", "septian")
            mail.Subject = subject
            mail.IsBodyHtml = True
            mail.Body = email_body(send_to, subject, number, "Catur")
            client.Send(mail)
        ElseIf report_mark_type = "weekly_attn" Then
            ' Create a new report. 
            Dim quuery_dept As String = "SELECT dept.id_departement,dept.departement,emp.id_employee,emp.email_lokal,emp.employee_name FROM tb_m_departement dept
                                            INNER JOIN tb_m_user usr ON dept.id_user_head=usr.id_user
                                            INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee"
            Dim data_dept As DataTable = execute_query(quuery_dept, -1, True, "", "", "", "")
            For i As Integer = 0 To data_dept.Rows.Count - 1
                ReportEmpAttn.id_dept = data_dept.Rows(i)("id_departement").ToString
                Dim Report As New ReportEmpAttn()

                ' Create a new memory stream and export the report into it as PDF.
                Dim Mem As New MemoryStream()
                Report.ExportToPdf(Mem)

                ' Create a new attachment and put the PDF report into it.
                Mem.Seek(0, System.IO.SeekOrigin.Begin)
                '
                Dim Att = New Attachment(Mem, "Weekly Attendance Report - " & data_dept.Rows(i)("departement").ToString & ".pdf", "application/pdf")
                '
                Dim mail As MailMessage = New MailMessage("system@volcom.mail", data_dept.Rows(i)("email_lokal").ToString)
                mail.Attachments.Add(Att)
                Dim client As SmtpClient = New SmtpClient()
                client.Port = 25
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.UseDefaultCredentials = False
                client.Host = "192.168.1.4"
                client.Credentials = New System.Net.NetworkCredential("system@volcom.mail", "system123")
                mail.Subject = "Weekly Attendance Report (" & data_dept.Rows(i)("departement").ToString & ")"
                mail.IsBodyHtml = True
                mail.Body = email_temp(data_dept.Rows(i)("employee_name").ToString)
                client.Send(mail)
            Next
        End If
    End Sub
    Function email_temp(ByVal employee_name As String)
        Dim body_temp As String = ""
        body_temp = "<html style='margin: 0;padding: 0;' xmlns='http://www.w3.org/1999/xhtml'><!--<![endif]--><head>
                        <meta http-equiv='Content-Type' content='text/html; charset=utf-8'>
                        <title></title>
                        <!--[if !mso]><!--><meta http-equiv='X-UA-Compatible' content='IE=edge'><!--<![endif]-->
                        <meta name='viewport' content='width=device-width'><style type='text/css'>
                    @media only screen and (min-width: 620px){.wrapper{min-width:600px !important}.wrapper h1{}.wrapper h1{font-size:40px !important;line-height:47px !important}.wrapper h2{}.wrapper h2{font-size:24px !important;line-height:32px !important}.wrapper h3{}.wrapper h3{font-size:20px !important;line-height:28px !important}.column p,.column ol,.column ul{}.wrapper .size-8{font-size:8px !important;line-height:14px !important}.wrapper .size-9{font-size:9px !important;line-height:16px !important}.wrapper .size-10{font-size:10px !important;line-height:18px !important}.wrapper .size-11{font-size:11px !important;line-height:19px !important}.wrapper .size-12{font-size:12px !important;line-height:19px !important}.wrapper .size-13{font-size:13px !important;line-height:21px !important}.wrapper .size-14{font-size:14px !important;line-height:21px !important}.wrapper .size-15{font-size:15px 
                    !important;line-height:23px !important}.wrapper .size-16{font-size:16px !important;line-height:24px !important}.wrapper .size-17{font-size:17px !important;line-height:26px !important}.wrapper .size-18{font-size:18px !important;line-height:26px !important}.wrapper .size-20{font-size:20px !important;line-height:28px !important}.wrapper .size-22{font-size:22px !important;line-height:31px !important}.wrapper .size-24{font-size:24px !important;line-height:32px !important}.wrapper .size-26{font-size:26px !important;line-height:34px !important}.wrapper .size-28{font-size:28px !important;line-height:36px !important}.wrapper .size-30{font-size:30px !important;line-height:38px !important}.wrapper .size-32{font-size:32px !important;line-height:40px !important}.wrapper .size-34{font-size:34px !important;line-height:43px !important}.wrapper .size-36{font-size:36px !important;line-height:43px 
                    !important}.wrapper .size-40{font-size:40px !important;line-height:47px !important}.wrapper .size-44{font-size:44px !important;line-height:50px !important}.wrapper .size-48{font-size:48px !important;line-height:54px !important}.wrapper .size-56{font-size:56px !important;line-height:60px !important}.wrapper .size-64{font-size:64px !important;line-height:63px !important}}
                    </style>
                        <style type='text/css'>
                    body {
                      margin: 0;
                      padding: 0;
                    }
                    table {
                      border-collapse: collapse;
                      table-layout: fixed;
                    }
                    * {
                      line-height: inherit;
                    }
                    [x-apple-data-detectors],
                    [href^='tel'],
                    [href^='sms'] {
                      color: inherit !important;
                      text-decoration: none !important;
                    }
                    .wrapper .footer__share-button a:hover,
                    .wrapper .footer__share-button a:focus {
                      color: #ffffff !important;
                    }
                    .btn a:hover,
                    .btn a:focus,
                    .footer__share-button a:hover,
                    .footer__share-button a:focus,
                    .email-footer__links a:hover,
                    .email-footer__links a:focus {
                      opacity: 0.8;
                    }
                    .preheader,
                    .header,
                    .layout,
                    .column {
                      transition: width 0.25s ease-in-out, max-width 0.25s ease-in-out;
                    }
                    .layout,
                    .header {
                      max-width: 400px !important;
                      -fallback-width: 95% !important;
                      width: calc(100% - 20px) !important;
                    }
                    div.preheader {
                      max-width: 360px !important;
                      -fallback-width: 90% !important;
                      width: calc(100% - 60px) !important;
                    }
                    .snippet,
                    .webversion {
                      Float: none !important;
                    }
                    .column {
                      max-width: 400px !important;
                      width: 100% !important;
                    }
                    .fixed-width.has-border {
                      max-width: 402px !important;
                    }
                    .fixed-width.has-border .layout__inner {
                      box-sizing: border-box;
                    }
                    .snippet,
                    .webversion {
                      width: 50% !important;
                    }
                    .ie .btn {
                      width: 100%;
                    }
                    .ie .column,
                    [owa] .column,
                    .ie .gutter,
                    [owa] .gutter {
                      display: table-cell;
                      float: none !important;
                      vertical-align: top;
                    }
                    .ie div.preheader,
                    [owa] div.preheader,
                    .ie .email-footer,
                    [owa] .email-footer {
                      max-width: 560px !important;
                      width: 560px !important;
                    }
                    .ie .snippet,
                    [owa] .snippet,
                    .ie .webversion,
                    [owa] .webversion {
                      width: 280px !important;
                    }
                    .ie .header,
                    [owa] .header,
                    .ie .layout,
                    [owa] .layout,
                    .ie .one-col .column,
                    [owa] .one-col .column {
                      max-width: 600px !important;
                      width: 600px !important;
                    }
                    .ie .fixed-width.has-border,
                    [owa] .fixed-width.has-border,
                    .ie .has-gutter.has-border,
                    [owa] .has-gutter.has-border {
                      max-width: 602px !important;
                      width: 602px !important;
                    }
                    .ie .two-col .column,
                    [owa] .two-col .column {
                      max-width: 300px !important;
                      width: 300px !important;
                    }
                    .ie .three-col .column,
                    [owa] .three-col .column,
                    .ie .narrow,
                    [owa] .narrow {
                      max-width: 200px !important;
                      width: 200px !important;
                    }
                    .ie .wide,
                    [owa] .wide {
                      width: 400px !important;
                    }
                    .ie .two-col.has-gutter .column,
                    [owa] .two-col.x_has-gutter .column {
                      max-width: 290px !important;
                      width: 290px !important;
                    }
                    .ie .three-col.has-gutter .column,
                    [owa] .three-col.x_has-gutter .column,
                    .ie .has-gutter .narrow,
                    [owa] .has-gutter .narrow {
                      max-width: 188px !important;
                      width: 188px !important;
                    }
                    .ie .has-gutter .wide,
                    [owa] .has-gutter .wide {
                      max-width: 394px !important;
                      width: 394px !important;
                    }
                    .ie .two-col.has-gutter.has-border .column,
                    [owa] .two-col.x_has-gutter.x_has-border .column {
                      max-width: 292px !important;
                      width: 292px !important;
                    }
                    .ie .three-col.has-gutter.has-border .column,
                    [owa] .three-col.x_has-gutter.x_has-border .column,
                    .ie .has-gutter.has-border .narrow,
                    [owa] .has-gutter.x_has-border .narrow {
                      max-width: 190px !important;
                      width: 190px !important;
                    }
                    .ie .has-gutter.has-border .wide,
                    [owa] .has-gutter.x_has-border .wide {
                      max-width: 396px !important;
                      width: 396px !important;
                    }
                    .ie .fixed-width .layout__inner {
                      border-left: 0 none white !important;
                      border-right: 0 none white !important;
                    }
                    .ie .layout__edges {
                      display: none;
                    }
                    .mso .layout__edges {
                      font-size: 0;
                    }
                    .layout-fixed-width,
                    .mso .layout-full-width {
                      background-color: #ffffff;
                    }
                    @media only screen and (min-width: 620px) {
                      .column,
                      .gutter {
                        display: table-cell;
                        Float: none !important;
                        vertical-align: top;
                      }
                      div.preheader,
                      .email-footer {
                        max-width: 560px !important;
                        width: 560px !important;
                      }
                      .snippet,
                      .webversion {
                        width: 280px !important;
                      }
                      .header,
                      .layout,
                      .one-col .column {
                        max-width: 600px !important;
                        width: 600px !important;
                      }
                      .fixed-width.has-border,
                      .fixed-width.ecxhas-border,
                      .has-gutter.has-border,
                      .has-gutter.ecxhas-border {
                        max-width: 602px !important;
                        width: 602px !important;
                      }
                      .two-col .column {
                        max-width: 300px !important;
                        width: 300px !important;
                      }
                      .three-col .column,
                      .column.narrow {
                        max-width: 200px !important;
                        width: 200px !important;
                      }
                      .column.wide {
                        width: 400px !important;
                      }
                      .two-col.has-gutter .column,
                      .two-col.ecxhas-gutter .column {
                        max-width: 290px !important;
                        width: 290px !important;
                      }
                      .three-col.has-gutter .column,
                      .three-col.ecxhas-gutter .column,
                      .has-gutter .narrow {
                        max-width: 188px !important;
                        width: 188px !important;
                      }
                      .has-gutter .wide {
                        max-width: 394px !important;
                        width: 394px !important;
                      }
                      .two-col.has-gutter.has-border .column,
                      .two-col.ecxhas-gutter.ecxhas-border .column {
                        max-width: 292px !important;
                        width: 292px !important;
                      }
                      .three-col.has-gutter.has-border .column,
                      .three-col.ecxhas-gutter.ecxhas-border .column,
                      .has-gutter.has-border .narrow,
                      .has-gutter.ecxhas-border .narrow {
                        max-width: 190px !important;
                        width: 190px !important;
                      }
                      .has-gutter.has-border .wide,
                      .has-gutter.ecxhas-border .wide {
                        max-width: 396px !important;
                        width: 396px !important;
                      }
                    }
                    @media only screen and (-webkit-min-device-pixel-ratio: 2), only screen and (min--moz-device-pixel-ratio: 2), only screen and (-o-min-device-pixel-ratio: 2/1), only screen and (min-device-pixel-ratio: 2), only screen and (min-resolution: 192dpi), only screen and (min-resolution: 2dppx) {
                      .fblike {
                        background-image: url(https://i3.createsend1.com/static/eb/master/13-the-blueprint-3/images/fblike@2x.png) !important;
                      }
                      .tweet {
                        background-image: url(https://i4.createsend1.com/static/eb/master/13-the-blueprint-3/images/tweet@2x.png) !important;
                      }
                      .linkedinshare {
                        background-image: url(https://i6.createsend1.com/static/eb/master/13-the-blueprint-3/images/lishare@2x.png) !important;
                      }
                      .forwardtoafriend {
                        background-image: url(https://i5.createsend1.com/static/eb/master/13-the-blueprint-3/images/forward@2x.png) !important;
                      }
                    }
                    @media (max-width: 321px) {
                      .fixed-width.has-border .layout__inner {
                        border-width: 1px 0 !important;
                      }
                      .layout,
                      .column {
                        min-width: 320px !important;
                        width: 320px !important;
                      }
                      .border {
                        display: none;
                      }
                    }
                    .mso div {
                      border: 0 none white !important;
                    }
                    .mso .w560 .divider {
                      Margin-left: 260px !important;
                      Margin-right: 260px !important;
                    }
                    .mso .w360 .divider {
                      Margin-left: 160px !important;
                      Margin-right: 160px !important;
                    }
                    .mso .w260 .divider {
                      Margin-left: 110px !important;
                      Margin-right: 110px !important;
                    }
                    .mso .w160 .divider {
                      Margin-left: 60px !important;
                      Margin-right: 60px !important;
                    }
                    .mso .w354 .divider {
                      Margin-left: 157px !important;
                      Margin-right: 157px !important;
                    }
                    .mso .w250 .divider {
                      Margin-left: 105px !important;
                      Margin-right: 105px !important;
                    }
                    .mso .w148 .divider {
                      Margin-left: 54px !important;
                      Margin-right: 54px !important;
                    }
                    .mso .font-avenir,
                    .mso .font-cabin,
                    .mso .font-open-sans,
                    .mso .font-ubuntu {
                      font-family: sans-serif !important;
                    }
                    .mso .font-bitter,
                    .mso .font-merriweather,
                    .mso .font-pt-serif {
                      font-family: Georgia, serif !important;
                    }
                    .mso .font-lato,
                    .mso .font-roboto {
                      font-family: Tahoma, sans-serif !important;
                    }
                    .mso .font-pt-sans {
                      font-family: 'Trebuchet MS', sans-serif !important;
                    }
                    .mso .footer__share-button p {
                      margin: 0;
                    }
                    .mso .size-8,
                    .ie .size-8 {
                      font-size: 8px !important;
                      line-height: 14px !important;
                    }
                    .mso .size-9,
                    .ie .size-9 {
                      font-size: 9px !important;
                      line-height: 16px !important;
                    }
                    .mso .size-10,
                    .ie .size-10 {
                      font-size: 10px !important;
                      line-height: 18px !important;
                    }
                    .mso .size-11,
                    .ie .size-11 {
                      font-size: 11px !important;
                      line-height: 19px !important;
                    }
                    .mso .size-12,
                    .ie .size-12 {
                      font-size: 12px !important;
                      line-height: 19px !important;
                    }
                    .mso .size-13,
                    .ie .size-13 {
                      font-size: 13px !important;
                      line-height: 21px !important;
                    }
                    .mso .size-14,
                    .ie .size-14 {
                      font-size: 14px !important;
                      line-height: 21px !important;
                    }
                    .mso .size-15,
                    .ie .size-15 {
                      font-size: 15px !important;
                      line-height: 23px !important;
                    }
                    .mso .size-16,
                    .ie .size-16 {
                      font-size: 16px !important;
                      line-height: 24px !important;
                    }
                    .mso .size-17,
                    .ie .size-17 {
                      font-size: 17px !important;
                      line-height: 26px !important;
                    }
                    .mso .size-18,
                    .ie .size-18 {
                      font-size: 18px !important;
                      line-height: 26px !important;
                    }
                    .mso .size-20,
                    .ie .size-20 {
                      font-size: 20px !important;
                      line-height: 28px !important;
                    }
                    .mso .size-22,
                    .ie .size-22 {
                      font-size: 22px !important;
                      line-height: 31px !important;
                    }
                    .mso .size-24,
                    .ie .size-24 {
                      font-size: 24px !important;
                      line-height: 32px !important;
                    }
                    .mso .size-26,
                    .ie .size-26 {
                      font-size: 26px !important;
                      line-height: 34px !important;
                    }
                    .mso .size-28,
                    .ie .size-28 {
                      font-size: 28px !important;
                      line-height: 36px !important;
                    }
                    .mso .size-30,
                    .ie .size-30 {
                      font-size: 30px !important;
                      line-height: 38px !important;
                    }
                    .mso .size-32,
                    .ie .size-32 {
                      font-size: 32px !important;
                      line-height: 40px !important;
                    }
                    .mso .size-34,
                    .ie .size-34 {
                      font-size: 34px !important;
                      line-height: 43px !important;
                    }
                    .mso .size-36,
                    .ie .size-36 {
                      font-size: 36px !important;
                      line-height: 43px !important;
                    }
                    .mso .size-40,
                    .ie .size-40 {
                      font-size: 40px !important;
                      line-height: 47px !important;
                    }
                    .mso .size-44,
                    .ie .size-44 {
                      font-size: 44px !important;
                      line-height: 50px !important;
                    }
                    .mso .size-48,
                    .ie .size-48 {
                      font-size: 48px !important;
                      line-height: 54px !important;
                    }
                    .mso .size-56,
                    .ie .size-56 {
                      font-size: 56px !important;
                      line-height: 60px !important;
                    }
                    .mso .size-64,
                    .ie .size-64 {
                      font-size: 64px !important;
                      line-height: 63px !important;
                    }
                    .footer__share-button p {
                      margin: 0;
                    }
                    </style>
    
                      <!--[if !mso]><!--><style type='text/css'>
                    @import url(https://fonts.googleapis.com/css?family=Cabin:400,700,400italic,700italic|Open+Sans:400italic,700italic,700,400);
                    </style><link href='https://fonts.googleapis.com/css?family=Cabin:400,700,400italic,700italic|Open+Sans:400italic,700italic,700,400' rel='stylesheet' type='text/css'><!--<![endif]--><style type='text/css'>
                    body{background-color:#f5f7fa}.mso h1{}.mso h1{font-family:sans-serif !important}.mso h2{}.mso h3{}.mso .column,.mso .column__background td{}.mso .column,.mso .column__background td{font-family:sans-serif !important}.mso .btn a{}.mso .btn a{font-family:sans-serif !important}.mso .webversion,.mso .snippet,.mso .layout-email-footer td,.mso .footer__share-button p{}.mso .webversion,.mso .snippet,.mso .layout-email-footer td,.mso .footer__share-button p{font-family:sans-serif !important}.mso .logo{}.mso .logo{font-family:Tahoma,sans-serif !important}.logo a:hover,.logo a:focus{color:#859bb1 !important}.mso .layout-has-border{border-top:1px solid #b1c1d8;border-bottom:1px solid #b1c1d8}.mso .layout-has-bottom-border{border-bottom:1px solid #b1c1d8}.mso .border,.ie .border{background-color:#b1c1d8}.mso h1,.ie h1{}.mso h1,.ie h1{font-size:40px !important;line-height:47px !important}.mso h2,.ie 
                    h2{}.mso h2,.ie h2{font-size:24px !important;line-height:32px !important}.mso h3,.ie h3{}.mso h3,.ie h3{font-size:20px !important;line-height:28px !important}.mso .layout__inner p,.ie .layout__inner p,.mso .layout__inner ol,.ie .layout__inner ol,.mso .layout__inner ul,.ie .layout__inner ul{}
                    </style><meta name='robots' content='noindex,nofollow'>
                    <meta property='og:title' content='My First Campaign'>
                    </head>
                    <!--[if mso]>
                      <body class='mso'>
                    <![endif]-->
                    <!--[if !mso]><!-->
                      <body class='full-padding' style='margin: 0;padding: 0;-webkit-text-size-adjust: 100%;'>
                    <!--<![endif]-->
                        <table class='wrapper' style='border-collapse: collapse;table-layout: fixed;min-width: 320px;width: 100%;background-color: #f5f7fa;' cellpadding='0' cellspacing='0' role='presentation'><tbody><tr><td>
                          <div class='preheader' style='Margin: 0 auto;max-width: 560px;min-width: 280px; width: 280px;width: calc(28000% - 167440px);'>
                            <div style='border-collapse: collapse;display: table;width: 100%;'>
                            <!--[if (mso)|(IE)]><table align='center' class='preheader' cellpadding='0' cellspacing='0' role='presentation'><tr><td style='width: 280px' valign='top'><![endif]-->
                              <div class='snippet' style='display: table-cell;Float: left;font-size: 12px;line-height: 19px;max-width: 280px;min-width: 140px; width: 140px;width: calc(14000% - 78120px);padding: 10px 0 5px 0;color: #b9b9b9;font-family: &quot;Open Sans&quot;,sans-serif;'>
            
                              </div>
                            <!--[if (mso)|(IE)]></td><td style='width: 280px' valign='top'><![endif]-->
                              <div class='webversion' style='display: table-cell;Float: left;font-size: 12px;line-height: 19px;max-width: 280px;min-width: 139px; width: 139px;width: calc(14100% - 78680px);padding: 10px 0 5px 0;text-align: right;color: #b9b9b9;font-family: &quot;Open Sans&quot;,sans-serif;'>
            
                              </div>
                            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
                            </div>
                          </div>
                          <div class='layout one-col fixed-width' style='Margin: 0 auto;max-width: 600px;min-width: 320px; width: 320px;width: calc(28000% - 167400px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;'>
                            <div class='layout__inner' style='border-collapse: collapse;display: table;width: 100%;background-color: #ffffff;' emb-background-style=''>
                            <!--[if (mso)|(IE)]><table align='center' cellpadding='0' cellspacing='0' role='presentation'><tr class='layout-fixed-width' emb-background-style><td style='width: 600px' class='w560'><![endif]-->
                              <div class='column' style='text-align: left;color: #60666d;font-size: 14px;line-height: 21px;font-family: &quot;Open Sans&quot;,sans-serif;max-width: 600px;min-width: 320px; width: 320px;width: calc(28000% - 167400px);'>
        
                                <div style='Margin-left: 20px;Margin-right: 20px;Margin-top: 24px;'>
                          <div style='line-height:10px;font-size:1px'>&nbsp;</div>
                        </div>
        
                                <div style='Margin-left: 20px;Margin-right: 20px;Margin-bottom: 24px;'>
                          <h2 style='Margin-top: 0;Margin-bottom: 0;font-style: normal;font-weight: normal;color: #44a8c7;font-size: 20px;line-height: 28px;text-align: left;'><strong>Dear&nbsp;" & employee_name & " ,</strong></h2><p class='size-16' style='Margin-top: 16px;Margin-bottom: 0;font-size: 16px;line-height: 24px;text-align: left;' lang='x-size-16'>Here's your weekly attendance report for your department. Please see attachment.</p><p class='size-16' style='Margin-top: 20px;Margin-bottom: 0;font-size: 16px;line-height: 24px;text-align: left;' lang='x-size-16'>Thank you.</p>
                        </div>
        
                              </div>
                            <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
                            </div>
                          </div>
  
                          <div>
                            <div class='layout email-footer' style='Margin: 0 auto;max-width: 600px;min-width: 320px; width: 320px;width: calc(28000% - 167400px);overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;'>
                              <div class='layout__inner' style='border-collapse: collapse;display: table;width: 100%;'>
                              <!--[if (mso)|(IE)]><table align='center' cellpadding='0' cellspacing='0' role='presentation'><tr class='layout-email-footer'><td style='width: 400px;' valign='top' class='w360'><![endif]-->
                                <div class='column wide' style='text-align: left;font-size: 12px;line-height: 19px;color: #b9b9b9;font-family: &quot;Open Sans&quot;,sans-serif;Float: left;max-width: 400px;min-width: 320px; width: 320px;width: calc(8000% - 47600px);'>
                                  <div style='Margin-left: 20px;Margin-right: 20px;Margin-top: 10px;Margin-bottom: 10px;'>
                
                                    <div>
                                      <div>Volcom Enterprise Resource Planning (ERP)</div>
                                    </div>
                                    <div style='Margin-top: 18px;'>
                                      <div>This email automatically send from system, do not reply.</div>
                                    </div>
                                  </div>
                                </div>
                              <!--[if (mso)|(IE)]></td><td style='width: 200px;' valign='top' class='w160'><![endif]-->
                                <div class='column narrow' style='text-align: left;font-size: 12px;line-height: 19px;color: #b9b9b9;font-family: &quot;Open Sans&quot;,sans-serif;Float: left;max-width: 320px;min-width: 200px; width: 320px;width: calc(72200px - 12000%);'>
                                  <div style='Margin-left: 20px;Margin-right: 20px;Margin-top: 10px;Margin-bottom: 10px;'>
                
                                  </div>
                                </div>
                              <!--[if (mso)|(IE)]></td></tr></table><![endif]-->
                              </div>
                            </div>
                          </div>
                          <div style='line-height:40px;font-size:40px;'>&nbsp;</div>
                        </td></tr></tbody></table>
                      <img style='overflow: hidden;position: fixed;visibility: hidden !important;display: block !important;height: 1px !important;width: 1px !important;border: 0 !important;margin: 0 !important;padding: 0 !important;' src='https://o.createsend1.com/t/d-o-ddljdik-l/o.gif' width='1' height='1' border='0' alt=''>
                    <script type='text/javascript' src='https://js.createsend1.com/js/jquery-1.7.2.min.js?h=C99A4659ppap'></script><script type='text/javascript'>$(function(){$('area,a').attr('target', '_blank');});</script>
                    </body></html>"
        Return body_temp
    End Function
    Function email_body(ByVal employee As String, ByVal mark_type As String, ByVal mark_number As String, ByVal mark_sender As String)
        If report_mark_type = "95" Then

        End If

        Dim body_template As String = ""
        body_template = "<html><head></head><body>
            <title>Auto notification Volcom ERP</title>
            <style type=""text/css"">
	            #yiv0832847839  #yiv0832847839  RESET STYLES  
	            #yiv0832847839 p{margin:10px 0;padding:0;}
	            #yiv0832847839 table{border-collapse:collapse;}
	            #yiv0832847839 h1, #yiv0832847839 h2, #yiv0832847839 h3, #yiv0832847839 h4, #yiv0832847839 h5, #yiv0832847839 h6{display:block;margin:0;padding:0;}
	            #yiv0832847839 img, #yiv0832847839 a img{border:0;height:auto;outline:none;text-decoration:none;}
	            #yiv0832847839 body, #yiv0832847839 #yiv0832847839bodyTable, #yiv0832847839 #yiv0832847839bodyCell{height:100%;margin:0;padding:0;width:100%;}

	            #yiv0832847839 #yiv0832847839 CLIENT-SPECIFIC STYLES  
	            #yiv0832847839 #yiv0832847839outlook a{padding:0;}#yiv0832847839  
	             _filtered #yiv0832847839 {}#yiv0832847839  
	            #yiv0832847839 img{}#yiv0832847839  
	            #yiv0832847839 table{}#yiv0832847839  
	            #yiv0832847839 .yiv0832847839ReadMsgBody{width:100%;}#yiv0832847839 .yiv0832847839ExternalClass{width:100%;}#yiv0832847839  
	            #yiv0832847839 p, #yiv0832847839 a, #yiv0832847839 li, #yiv0832847839 td, #yiv0832847839 blockquote{}#yiv0832847839  
	            #yiv0832847839 a .filtered99999 , #yiv0832847839 a .filtered99999 {color:inherit;cursor:default;text-decoration:none;}#yiv0832847839  
	            #yiv0832847839 p, #yiv0832847839 a, #yiv0832847839 li, #yiv0832847839 td, #yiv0832847839 body, #yiv0832847839 table, #yiv0832847839 blockquote{}#yiv0832847839  
	            #yiv0832847839 .yiv0832847839ExternalClass, #yiv0832847839 .yiv0832847839ExternalClass p, #yiv0832847839 .yiv0832847839ExternalClass td, #yiv0832847839 .yiv0832847839ExternalClass div, #yiv0832847839 .yiv0832847839ExternalClass span, #yiv0832847839 .yiv0832847839ExternalClass font{line-height:100%;}#yiv0832847839  
	            #yiv0832847839 a .filtered99999 {color:inherit;text-decoration:none;font-size:inherit !important;font-family:inherit !important;font-weight:inherit;line-height:inherit !important;}#yiv0832847839  


	            #yiv0832847839 #yiv0832847839footerContent a{color:#B7B7B7;}

	            #yiv0832847839  #yiv0832847839  MOBILE STYLES  
	            @media screen and (max-width:480px){
	            #yiv0832847839 body{width:100% !important;min-width:100% !important;}
	            #yiv0832847839 h1{font-size:24px !important;}
	            #yiv0832847839 #yiv0832847839templateHeader{padding-right:20px !important;padding-left:20px !important;}
	            #yiv0832847839 #yiv0832847839headerContainer{padding-right:0 !important;padding-left:0 !important;}
	            #yiv0832847839 #yiv0832847839headerTable{}
	            #yiv0832847839 #yiv0832847839headerTable td{padding-top:30px !important;}
	            #yiv0832847839 #yiv0832847839bodyContainer{padding-right:20px !important;padding-left:20px !important;}
	            #yiv0832847839 #yiv0832847839bodyContent{padding-right:0 !important;}
	            #yiv0832847839 #yiv0832847839footerContent p{border-bottom:1px solid #E5E5E5;font-size:14px !important;padding-bottom:40px !important;}
	            #yiv0832847839 .yiv0832847839utilityLink{border-bottom:1px solid #E5E5E5;display:block;font-size:13px !important;padding-top:20px;padding-bottom:20px;text-decoration:none;}
	            #yiv0832847839 .yiv0832847839mobileHide{display:none;visibility:hidden;}
	            }

	            @media {
	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:400;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:700;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:400;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:700;}

	            #yiv0832847839 *, #yiv0832847839 td{font-family:'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif !important;}
	            #yiv0832847839 
            </style>
                <div id=""yui_3_16_0_ym19_1_1465365162626_3230"">
                    <center id=""yui_3_16_0_ym19_1_1465365162626_3229"">
                        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""yiv0832847839bodyTable"">
                            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3228""><tr id=""yui_3_16_0_ym19_1_1465365162626_3227"">
                                <td align=""center"" valign=""top"" id=""yiv0832847839bodyCell"">
						            <span style=""color:#FFFFFF;display:none;font-size:0px;height:0px;visibility:hidden;width:0px;"">You're almost ready to get started!</span>
                        
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3226"">
							            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3225"">
							            <tr>
								            <td align=""center"" bgcolor=""#FFFFFF"" valign=""top"" id=""yiv0832847839headerContainer"" style=""background-color:#FFFFFF;padding-right:30px;padding-left:30px;"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										            <tbody><tr>
											            <td align=""center"" valign=""top"">
												
												            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:640px;"" class=""yiv0832847839emailContainer"">
													            <tbody><tr>
														            <td align=""center"" valign=""top"">
															            <table align=""center"" bgcolor=""#FFFFFF"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yiv0832847839headerTable"" style=""background-color:#FFFFFF;border-collapse:separate;"">
																            <tbody>
																            <tr>
																	            <td align=""left"" valign=""top"" id=""yiv0832847839bodyContent"" style=""padding-bottom:30px;padding-top:40px;"">
																		            <h1 style=""color:#737373;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:30px;font-style:normal;font-weight:600;line-height:42px;letter-spacing:normal;margin:0;padding:0;text-align:center;"">You have 1 new waiting approval, " & employee & ".</h1>
																	            </td>
																            </tr>
															            </tbody></table>
														            </td>
													            </tr>
												            </tbody></table>
												
											            </td>
										            </tr>
									            </tbody></table>
								            </td>
                                        </tr>
							            <tr id=""yui_3_16_0_ym19_1_1465365162626_3224"">
								            <td align=""center"" valign=""top"" id=""yiv0832847839templateBody"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3223"">
										            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3222""><tr id=""yui_3_16_0_ym19_1_1465365162626_3221"">
											            <td align=""center"" valign=""top"" id=""yui_3_16_0_ym19_1_1465365162626_3220"">
												
												            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:700px;"" class=""yiv0832847839emailContainer"" id=""yui_3_16_0_ym19_1_1465365162626_3219"">
													            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3218""><tr id=""yui_3_16_0_ym19_1_1465365162626_3217"">
														            <td align=""right"" valign=""top"" width=""30"" class=""yiv0832847839mobileHide"">
															            <img width=""30"" style=""display:block;"" data-id=""f8de403e-5516-4f60-d47f-d38ec2c53672"">
														            </td>
														            <td valign=""top"" width=""100%"" style=""padding-right:70px;padding-left:40px;"" id=""yiv0832847839bodyContainer"">
															            <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3216"">
																            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3215"">
																            <tr id=""yui_3_16_0_ym19_1_1465365162626_3214"">
																	            <td align=""center"" valign=""top"" style=""padding-bottom:20px;"" id=""yui_3_16_0_ym19_1_1465365162626_3213"">
																			            <table align=""center"" border=""0"" cellpadding=""10"" cellspacing=""0"" width="""" style=""color:#929292;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;font-style:normal;font-weight:400;line-height:21px;letter-spacing:normal;"">
																				            <tbody>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            About
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            " + mark_type + "
																						            </td>
																					            </tr>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            Number
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							             " + mark_number + "
																						            </td>
																					            </tr>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            From
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            " + mark_sender + "
																						            </td>
																					            </tr>
																				            </tbody>
																			            </table>
																	            </td>
																            </tr>
																            <tr>
																	            <td align=""center"" style=""padding-bottom:5px;"" valign=""top"">
																		            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																			            <tbody><tr>
																				            <td align=""center"" valign=""middle"">
																					
																					            <a rel=""nofollow"" target=""_blank"" href="""" style=""background-color:#2FBD47;border-collapse:separate;border-top:20px solid #2FBD47;border-right:20px solid #2FBD47;border-bottom:20px solid #2FBD47;border-left:20px solid #2FBD47;border-radius:3px;color:#FFFFFF;display:inline-block;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:16px;font-weight:600;letter-spacing:.3px;text-decoration:none;"">Accept</a>
																					            &nbsp
																					            <a rel=""nofollow"" target=""_blank"" href="""" style=""background-color:#E11A1A;border-collapse:separate;border-top:20px solid #E11A1A;border-right:20px solid #E11A1A;border-bottom:20px solid #E11A1A;border-left:20px solid #E11A1A;border-radius:3px;color:#FFFFFF;display:inline-block;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:16px;font-weight:600;letter-spacing:.3px;text-decoration:none;"">Decline</a>
																					
																				            </td>
																			            </tr>
																		            </tbody></table>
																	            </td>
																            </tr>
																            <tr id=""yui_3_16_0_ym19_1_1465365162626_3214"">
																	            <td align=""left"" valign=""top"" style=""padding-bottom:40px;"" id=""yui_3_16_0_ym19_1_1465365162626_3213"">
																		            <div style=""color:#929292;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;font-style:normal;font-weight:400;line-height:42px;letter-spacing:normal;margin:0;padding:0;text-align:center;"">(Please click one of button above to continue. Click <a href=""#"">here</a> for confirmation status.)</div>
																	            </td>
																            </tr>
															            </tbody></table>
														            </td>
													            </tr>
												            </tbody></table>
												
											            </td>
										            </tr>
									            </tbody></table>
								            </td>
                                        </tr>
                                        <tr id=""yui_3_16_0_ym19_1_1465365162626_3238"">
								            <td align=""center"" valign=""top"" id=""yiv0832847839templateFooter"" style=""padding-right:30px;padding-left:30px;"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:640px;"" class=""yiv0832847839emailContainer"" id=""yui_3_16_0_ym19_1_1465365162626_3237"">
										            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3236""><tr id=""yui_3_16_0_ym19_1_1465365162626_3235"">
                                			            <td valign=""top"" id=""yiv0832847839footerContent"" style=""border-top:2px solid #F2F2F2;color:#B7B7B7;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:12px;font-weight:400;line-height:24px;padding-top:5px;padding-bottom:20px;text-align:center;"">
												            <div style=""color:#B7B7B7;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:12px;font-weight:400;line-height:24px;padding:0;margin:0;text-align:center;"" id=""yui_3_16_0_ym19_1_1465365162626_3239"">Notification from Volcom Enterprise Resource Planning (ERP)</div>
												            <a rel=""nofollow"" target=""_blank"" href=""http://www.volcom.co.id"" style=""color:#B7B7B7;text-decoration:underline;"" class=""yiv0832847839utilityLink"">Volcom Indonesia</a>
											            </td>
										            </tr>
									            </tbody></table>
									
								            </td>
                                        </tr>
                                    </tbody></table>
                        
                                </td>
                            </tr>
                        </tbody></table>
                    </center>
                <img height=""1"" width=""1"" data-id=""99d3f6c3-f87e-470b-3bb3-0280693bcba3""></div>
            </div><br><br></div>  </div> </div>  </div></div></body></html>"
        Return body_template
    End Function
End Class
