Imports System.Net.Mail

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
        mail.Body = email_body("Arif", "Cuti", "Cuti0001", "Catur")
        client.Send(mail)
    End Sub
    Function email_body(ByVal employee As String, ByVal mark_type As String, ByVal mark_number As String, ByVal mark_sender As String)
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

	            #yiv0832847839  #yiv0832847839  CLIENT-SPECIFIC STYLES  
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