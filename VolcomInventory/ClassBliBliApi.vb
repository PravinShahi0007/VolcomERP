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
        Dim page As Integer = get_page()
        For i As Integer = 0 To page - 1
            Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
            Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderList?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=FP")
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
                        'awb number
                        Dim packageCreated As String = ""
                        packageCreated = row("packageCreated").ToString

                        If packageCreated = "True" Then
                            'check first
                            Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE ol_store_id='" & row("orderItemNo").ToString & "'"
                            Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                            If Not dt_check.Rows.Count > 0 Then
                                get_order_detail(row("orderNo").ToString, row("orderItemNo").ToString)
                            End If
                        End If
                    Next
                End If
            End Using
            response.Close()
        Next
    End Sub

    Sub get_order_detail(ByVal order_par As String, ByVal order_item_par As String)
        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderDetail?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&orderNo=" + order_par + "&orderItemNo=" + order_item_par)
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
            If json("success").ToString = True And json("value").Count > 0 Then
                For Each row In json("value").ToList
                    Dim id As String = ""
                    Dim id_comp_group As String = ""
                    Dim sales_order_ol_shop_number As String = ""
                    Dim sales_order_ol_shop_date As String = ""
                    Dim customer_name As String = ""
                    Dim shipping_name As String = ""
                    Dim shipping_address As String = ""
                    Dim shipping_address1 As String = ""
                    Dim shipping_address2 As String = ""
                    Dim shipping_phone As String = ""
                    Dim shipping_city As String = ""
                    Dim shipping_post_code As String = ""
                    Dim shipping_region As String = ""
                    Dim shipping_district As String = ""
                    Dim payment_method As String = ""
                    Dim tracking_code As String = ""
                    Dim ol_store_sku As String = ""
                    Dim ol_store_id As String = ""
                    Dim checkout_id As String = ""
                    Dim sku As String = ""
                    Dim design_price As String = ""
                    Dim sales_order_det_qty As String = ""
                    Dim shipping_price As String = ""
                    Dim other_price As String = ""
                    Dim grams As String = ""
                    Dim total_disc_order As String = ""
                    Dim discount_allocations_amo As String = ""
                    Dim financial_status As String = ""

                    id = row("orderNo").ToString
                    id_comp_group = id_store_group
                    sales_order_ol_shop_number = row("orderNo").ToString
                    sales_order_ol_shop_date = DateTime.Parse(unixMiliSecondsToDatetime(row("orderDate")).ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    customer_name = row("").ToString
                    shipping_name = row("").ToString
                    shipping_address = row("").ToString
                    shipping_address1 = row("").ToString
                    shipping_address2 = row("").ToString
                    shipping_phone = row("").ToString
                    shipping_city = row("").ToString
                    shipping_post_code = row("").ToString
                    shipping_region = row("").ToString
                    shipping_district = row("").ToString
                    payment_method = row("").ToString
                    tracking_code = row("").ToString
                    ol_store_sku = row("").ToString
                    ol_store_id = row("orderItemNo").ToString
                    checkout_id = row("").ToString
                    sku = row("").ToString
                    design_price = row("").ToString
                    sales_order_det_qty = row("").ToString
                    shipping_price = row("").ToString
                    other_price = row("").ToString
                    grams = row("").ToString
                    total_disc_order = row("").ToString
                    discount_allocations_amo = row("").ToString
                    financial_status = row("").ToString

                Next
            End If
        End Using
        response.Close()
    End Sub

    Function get_page() As Integer
        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderList?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=FP")
        request.Method = "GET"

        request.Accept = "application/json"
        request.ContentType = "application/json"

        request.Headers.Add("Authorization", "Basic " + auth)
        request.Headers.Add("API-Seller-Key", api_seller_key)

        Dim response As Net.HttpWebResponse = request.GetResponse()
        Dim page As Decimal = 0
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
            If json("success").ToString = True And json("pageMetaData").Count > 0 Then
                page = Math.Ceiling(Decimal.Parse(json("pageMetaData")("totalRecords")) / 10)
            End If
        End Using
        response.Close()

        Return page
    End Function
End Class
