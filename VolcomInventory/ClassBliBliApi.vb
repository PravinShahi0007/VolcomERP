Public Class ClassBliBliApi
    Dim api_seller_key As String = get_setup_field("blibli_api_seller_key")
    Dim username As String = get_setup_field("blibli_api_username")
    Dim password As String = get_setup_field("blibli_api_password")
    Dim request_id As String = get_setup_field("blibli_api_request_id")
    Dim channel_id As String = get_setup_field("blibli_channel_id")
    Dim business_partner As String = get_setup_field("blibli_business_partner")
    Dim store_id As String = get_setup_field("blibli_store_id")
    Dim id_store_group As String = get_setup_field("blibli_comp_group")


    Function download_shipping_label(ByVal order_item_id As String) As String
        Dim out As String = ""

        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/downloadShippingLabel?channelId=VOLCOM&requestId=" + request_id + "&storeId=10001&orderItemId=" + order_item_id)

        request.Method = "GET"

        request.Accept = "application/json"
        request.ContentType = "application/json"

        request.Headers.Add("Authorization", "Basic " + auth)
        request.Headers.Add("API-Seller-Key", api_seller_key)

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            Try
                out = json("value")("document")
            Catch ex As Exception
            End Try
        End Using

        response.Close()

        Return out
    End Function

    Sub get_order_list()
        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderList?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "")
        request.Method = "GET"

        request.Accept = "application/json"
        request.ContentType = "application/json"

        request.Headers.Add("Authorization", "Basic " + auth)
        request.Headers.Add("API-Seller-Key", api_seller_key)

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
            If json("success").ToString = True And json("content").Count > 0 Then
                For Each row In json("content").ToList
                    'check first
                    Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE ol_store_id='" & row("orderItemNo").ToString & "'"
                    Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                    If Not dt_check.Rows.Count > 0 Then

                    End If
                Next
            End If
        End Using
        response.Close()
    End Sub
End Class
