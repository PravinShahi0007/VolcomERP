Public Class ClassBliBliApi
    Dim api_seller_key As String = get_setup_field("blibli_api_seller_key")
    Dim username As String = get_setup_field("blibli_api_username")
    Dim password As String = get_setup_field("blibli_api_password")
    Dim request_id As String = get_setup_field("blibli_api_request_id")
    Dim channel_id As String = get_setup_field("blibli_channel_id")
    Dim business_partner As String = get_setup_field("blibli_business_partner")
    Dim store_id As String = get_setup_field("blibli_store_id")
    Dim id_store_group As String = get_setup_field("blibli_comp_group")
    Dim limit_ror As String = get_setup_field("blibli_limit_ror")


    Function download_shipping_label(ByVal order_item_id As String) As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim out As String = ""

        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))

        Dim packageId As String = ""

        'package id
        Dim order_par As String = execute_query("SELECT id FROM tb_ol_store_order WHERE ol_store_id = " + order_item_id, 0, True, "", "", "", "")

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderDetail?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&orderNo=" + order_par + "&orderItemNo=" + order_item_id)

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

            If json("success").ToString = True AndAlso json("value").Count > 0 Then
                packageId = json("value")("packageId").ToString
            End If
        End Using

        response.Close()

        'shipping label
        request = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/seller/v1/orders/" + packageId + "/shippingLabel?username=" + username + "&requestId=" + request_id + "&channelId=" + channel_id + "&storeId=" + store_id + "&storeCode=" + business_partner)

        request.Method = "GET"

        request.Accept = "application/json"
        request.ContentType = "application/json"

        request.Headers.Add("Authorization", "Basic " + auth)
        request.Headers.Add("API-Seller-Key", api_seller_key)

        response = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            Try
                out = json("content")("shippingLabel")
            Catch ex As Exception
            End Try
        End Using

        response.Close()

        Return out
    End Function

    Sub get_order_list()
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)
        'delete is_process =2
        'execute_non_query_long("DELETE FROM tb_ol_store_order WHERE id_comp_group='" + id_store_group + "' AND is_process=2", True, "", "", "", "")

        Dim page As Integer = get_page()
        For i As Integer = 0 To page - 1
            Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
            Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderList?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=FP" + "&page=" + i.ToString)
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
                If json("success").ToString = True AndAlso json("content").Count > 0 Then
                    For Each row In json("content").ToList
                        'awb number
                        Dim packageCreated As String = ""
                        packageCreated = row("packageCreated").ToString

                        If packageCreated = "True" Then
                            'check first
                            Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE ol_store_id='" & row("orderItemNo").ToString & "' AND id_comp_group='" + id_store_group + "' "
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
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

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
            If json("success").ToString = True AndAlso json("value").Count > 0 Then
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
                Dim ol_order_qty As String = ""
                Dim sales_order_det_qty As String = ""
                Dim shipping_price As String = ""
                Dim other_price As String = ""
                Dim grams As String = ""
                Dim total_disc_order As String = ""
                Dim discount_allocations_amo As String = ""
                Dim financial_status As String = ""

                id = json("value")("orderNo").ToString
                id_comp_group = id_store_group
                sales_order_ol_shop_number = json("value")("orderNo").ToString
                sales_order_ol_shop_date = DateTime.Parse(unixMiliSecondsToDatetime(json("value")("orderDate")).ToString).ToString("yyyy-MM-dd HH:mm:ss")
                customer_name = addSlashes(json("value")("custName").ToString)
                shipping_name = addSlashes(json("value")("shippingRecipientName").ToString)
                shipping_address = addSlashes(json("value")("shippingStreetAddress").ToString)
                shipping_address1 = addSlashes(json("value")("shippingStreetAddress").ToString)
                shipping_address2 = addSlashes(json("value")("shippingStreetAddress").ToString)
                shipping_phone = json("value")("shippingMobile").ToString
                shipping_city = addSlashes(json("value")("shippingCity").ToString)
                shipping_post_code = json("value")("shippingZipCode").ToString
                shipping_region = addSlashes(json("value")("shippingProvince").ToString)
                shipping_district = addSlashes(json("value")("shippingDistrict").ToString)
                payment_method = ""
                tracking_code = addSlashes(json("value")("awbNumber").ToString)
                ol_store_sku = json("value")("gdnItemSku").ToString
                ol_store_id = json("value")("orderItemNo").ToString
                checkout_id = ""
                sku = json("value")("merchantSku").ToString
                design_price = decimalSQL(json("value")("finalPrice").ToString)
                ol_order_qty = decimalSQL(json("value")("qty").ToString)
                sales_order_det_qty = decimalSQL(json("value")("qty").ToString)
                shipping_price = "0"
                other_price = "0"
                grams = decimalSQL(Decimal.Parse(json("value")("itemWeightInKg").ToString) * 1000)
                total_disc_order = "0"
                discount_allocations_amo = "0"
                financial_status = ""

                Dim query As String = "INSERT INTO tb_ol_store_order(
                id, 
                id_comp_group, 
                sales_order_ol_shop_number ,
                sales_order_ol_shop_date ,
                customer_name ,
                shipping_name ,
                shipping_address, 
                shipping_address1, 
                shipping_address2 ,
                shipping_phone ,
                shipping_city ,
                shipping_post_code, 
                shipping_region ,
                shipping_district, 
                payment_method ,
                tracking_code ,
                ol_store_sku ,
                ol_store_id ,
                checkout_id ,
                sku ,
                design_price, 
                ol_order_qty,
                sales_order_det_qty, 
                shipping_price ,
                other_price ,
                grams ,
                total_disc_order ,
                discount_allocations_amo ,
                financial_status 
                ) VALUES(
                '" + id + "',
                '" + id_comp_group + "',
                '" + sales_order_ol_shop_number + "',
                '" + sales_order_ol_shop_date + "',
                '" + customer_name + "',
                '" + shipping_name + "',
                '" + shipping_address + "',
                '" + shipping_address1 + "',
                '" + shipping_address2 + "',
                '" + shipping_phone + "',
                '" + shipping_city + "',
                '" + shipping_post_code + "', 
                '" + shipping_region + "',
                '" + shipping_district + "',
                '" + payment_method + "',
                '" + tracking_code + "',
                '" + ol_store_sku + "',
                '" + ol_store_id + "',
                '" + checkout_id + "',
                '" + sku + "',
                '" + design_price + "', 
                '" + ol_order_qty + "',
                '" + sales_order_det_qty + "', 
                '" + shipping_price + "',
                '" + other_price + "',
                '" + grams + "',
                '" + total_disc_order + "', 
                '" + discount_allocations_amo + "', 
                '" + financial_status + "'    
                );"
                execute_non_query_long(query, True, "", "", "", "")
            End If
        End Using
        response.Close()
    End Sub

    Function get_page() As Integer
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

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
            If json("success").ToString = True AndAlso json("pageMetaData").Count > 0 Then
                page = Math.Ceiling(Decimal.Parse(json("pageMetaData")("totalRecords")) / 10)
            End If
        End Using
        response.Close()

        Return page
    End Function

    Function get_status(ByVal order_no_par As String, ByVal ol_store_id_par As String) As DataTable
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("order_status", GetType(String))
        dt.Columns.Add("order_status_date", GetType(DateTime))

        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/orderDetail?storeId=" + store_id + "&requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&orderNo=" + order_no_par + "&orderItemNo=" + ol_store_id_par)
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
            If json("success").ToString = True AndAlso json("value").Count > 0 Then
                For Each row In json("value")("orderHistory").ToList
                    Dim stt As String = ""
                    If row("orderStatus").ToString = "D" Then
                        stt = "delivered"
                    ElseIf row("orderStatus").ToString = "X" Then
                        stt = "cancelled"
                    Else
                        stt = "on_process"
                    End If
                    dt.Rows.Add(stt, unixMiliSecondsToDatetime(row("createdTimestamp")))
                    Exit For
                Next
            Else
                dt = Nothing
            End If
        End Using
        response.Close()
        Return dt
    End Function
    Function get_page_ror() As Integer
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/getReturnedOrderSummary?requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=RMA_PROCESS_FINISHED")
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
            If json("success").ToString = True AndAlso json("pageMetaData").Count > 0 Then
                page = Math.Ceiling(Decimal.Parse(json("pageMetaData")("totalRecords")) / limit_ror)
            End If
        End Using
        response.Close()

        Return page
    End Function

    Sub get_ror_list()
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim page As Integer = get_page_ror()
        For i As Integer = 0 To page - 1
            Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
            Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/getReturnedOrderSummary?requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=RMA_PROCESS_FINISHED" + "&size=" + limit_ror + "&page=" + i.ToString)
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
                If json("success").ToString = True AndAlso json("content").Count > 0 Then
                    For Each row In json("content").ToList
                        Dim id As String = row("returnId").ToString
                        Dim ror_date As String = DateTime.Parse(unixMiliSecondsToDatetime(Decimal.Parse(row("createdDate").ToString))).ToString("yyyy-MM-dd HH:mm:ss")

                        'check first
                        Dim q_check As String = "SELECT * FROM tb_ol_store_ror_bli r WHERE r.id='" + id + "' "
                        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                        If Not dt_check.Rows.Count > 0 Then
                            Dim query As String = "INSERT INTO tb_ol_store_ror_bli(sync_date, ror_date, id, ror_number, order_number, item_id, customer_name, qty, price) 
                            VALUES(NOW(),'" + ror_date + "', '" + id + "', '" + addSlashes(row("returnNo").ToString) + "', '" + addSlashes(row("orderNo").ToString) + "', '" + addSlashes(row("orderItemNo").ToString) + "', '" + addSlashes(row("customerName").ToString) + "', '" + decimalSQL(row("orderQuantity").ToString) + "', '" + decimalSQL(row("productSalePrice").ToString) + "'); "
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If
            End Using
            response.Close()
        Next
    End Sub

    Sub get_ror_list_spesific(ByVal ol_store_id_par As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim page As Integer = get_page_ror()
        For i As Integer = 0 To page - 1
            Dim auth As String = Convert.ToBase64String(Text.Encoding.UTF8.GetBytes(username + ":" + password))
            Dim request As Net.HttpWebRequest = Net.WebRequest.Create("https://api.blibli.com/v2/proxy/mta/api/businesspartner/v1/order/getReturnedOrderSummary?requestId=" + request_id + "&businessPartnerCode=" + business_partner + "&channelId=" + channel_id + "&status=RMA_PROCESS_FINISHED" + "&orderIdOrItemId=" + ol_store_id_par)
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
                If json("success").ToString = True AndAlso json("content").Count > 0 Then
                    For Each row In json("content").ToList
                        Dim id As String = row("returnId").ToString
                        Dim ror_date As String = DateTime.Parse(unixMiliSecondsToDatetime(Decimal.Parse(row("createdDate").ToString))).ToString("yyyy-MM-dd HH:mm:ss")

                        'check first
                        Dim q_check As String = "SELECT * FROM tb_ol_store_ror_bli r WHERE r.id='" + id + "' "
                        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                        If Not dt_check.Rows.Count > 0 Then
                            Dim query As String = "INSERT INTO tb_ol_store_ror_bli(sync_date, ror_date, id, ror_number, order_number, item_id, customer_name, qty, price) 
                            VALUES(NOW(),'" + ror_date + "', '" + id + "', '" + addSlashes(row("returnNo").ToString) + "', '" + addSlashes(row("orderNo").ToString) + "', '" + addSlashes(row("orderItemNo").ToString) + "', '" + addSlashes(row("customerName").ToString) + "', '" + decimalSQL(row("orderQuantity").ToString) + "', '" + decimalSQL(row("productSalePrice").ToString) + "'); "
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If
            End Using
            response.Close()
        Next
    End Sub

    Sub set_to_returned()
        Dim query As String = "SELECT b.id_ol_store_ror_bli, b.sync_date, b.id, b.ror_date, b.ror_number, b.order_number, b.item_id, b.customer_name,
        b.qty, b.price 
        FROM tb_ol_store_ror_bli b
        WHERE b.is_process=2
        ORDER BY b.ror_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            Dim stt_date As String = DateTime.Parse(data.Rows(i)("ror_date").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim qcek As String = "SELECT so.sales_order_ol_shop_number AS `order_no`, sod.id_sales_order, sod.id_sales_order_det, spd.id_sales_pos_det, spd.id_sales_pos,
            sod.ol_store_id, sod.item_id
            FROM  tb_sales_order so
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
            LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del AND d.id_report_status=6
            LEFT JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
            LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos AND sp.id_report_status=6
            WHERE so.id_report_status=6  AND s.id_comp_group='" + id_store_group + "' AND so.sales_order_ol_shop_number='" + data.Rows(i)("order_number").ToString + "' AND sod.ol_store_id='" + data.Rows(i)("item_id").ToString + "'
            ORDER BY sod.id_sales_order_det ASC LIMIT " + data.Rows(i)("qty").ToString + " "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            Dim found_item As Boolean = False
            For j As Integer = 0 To dcek.Rows.Count - 1
                'set status
                Dim cmos As New ClassMOS()
                cmos.insertStatusOrder(dcek.Rows(j)("id_sales_order_det").ToString, "returned", stt_date)
                found_item = True
                If dcek.Rows(j)("id_sales_pos").ToString <> "" Then
                    Dim qib As String = "INSERT INTO tb_ol_store_return_order(id_comp_group, created_date, order_number, ol_store_id, item_id, qty, id_sales_order, id_sales_order_det, id_sales_pos_det, id_sales_pos)
                                            VALUES('" + id_store_group + "', NOW(), '" + dcek.Rows(j)("order_no").ToString + "', '" + dcek.Rows(j)("ol_store_id").ToString + "', '" + dcek.Rows(j)("item_id").ToString + "','1','" + dcek.Rows(j)("id_sales_order").ToString + "', '" + dcek.Rows(j)("id_sales_order_det").ToString + "', '" + dcek.Rows(j)("id_sales_pos_det").ToString + "', '" + dcek.Rows(j)("id_sales_pos").ToString + "'); "
                    execute_non_query(qib, True, "", "", "", "")
                End If
            Next
            If found_item Then
                execute_non_query("UPDATE tb_ol_store_ror_bli SET is_process=1, process_date=NOW() WHERE id_ol_store_ror_bli='" + data.Rows(i)("id_ol_store_ror_bli").ToString + "' ", True, "", "", "", "")
            End If
        Next
    End Sub

    Sub set_to_returned_spesific(ByVal ol_store_id_par As String, ByVal is_manual_sync_par As String)
        Dim query As String = "SELECT b.id_ol_store_ror_bli, b.sync_date, b.id, b.ror_date, b.ror_number, b.order_number, b.item_id, b.customer_name,
        b.qty, b.price 
        FROM tb_ol_store_ror_bli b
        WHERE b.is_process=2 WHERE b.item_id='" + ol_store_id_par + "'
        ORDER BY b.ror_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            Dim stt_date As String = DateTime.Parse(data.Rows(i)("ror_date").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim qcek As String = "SELECT so.sales_order_ol_shop_number AS `order_no`, sod.id_sales_order, sod.id_sales_order_det, spd.id_sales_pos_det, spd.id_sales_pos,
            sod.ol_store_id, sod.item_id
            FROM  tb_sales_order so
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
            LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del AND d.id_report_status=6
            LEFT JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
            LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos AND sp.id_report_status=6
            WHERE so.id_report_status=6  AND s.id_comp_group='" + id_store_group + "' AND so.sales_order_ol_shop_number='" + data.Rows(i)("order_number").ToString + "' AND sod.ol_store_id='" + data.Rows(i)("item_id").ToString + "'
            ORDER BY sod.id_sales_order_det ASC LIMIT " + data.Rows(i)("qty").ToString + " "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            Dim found_item As Boolean = False
            For j As Integer = 0 To dcek.Rows.Count - 1
                'set status
                Dim cmos As New ClassMOS()
                cmos.insertStatusOrder(dcek.Rows(j)("id_sales_order_det").ToString, "returned", stt_date)
                found_item = True
                If dcek.Rows(j)("id_sales_pos").ToString <> "" Then
                    Dim manual_sync_by As String = "NULL"
                    If is_manual_sync_par = "1" Then
                        manual_sync_by = id_user
                    End If
                    Dim qib As String = "INSERT INTO tb_ol_store_return_order(id_comp_group, created_date, order_number, ol_store_id, item_id, qty, id_sales_order, id_sales_order_det, id_sales_pos_det, id_sales_pos,is_manual_sync, manual_sync_by)
                                            VALUES('" + id_store_group + "', NOW(), '" + dcek.Rows(j)("order_no").ToString + "', '" + dcek.Rows(j)("ol_store_id").ToString + "', '" + dcek.Rows(j)("item_id").ToString + "','1','" + dcek.Rows(j)("id_sales_order").ToString + "', '" + dcek.Rows(j)("id_sales_order_det").ToString + "', '" + dcek.Rows(j)("id_sales_pos_det").ToString + "', '" + dcek.Rows(j)("id_sales_pos").ToString + "','" + is_manual_sync_par + "', " + manual_sync_by + "); "
                    execute_non_query(qib, True, "", "", "", "")
                End If
            Next
            If found_item Then
                execute_non_query("UPDATE tb_ol_store_ror_bli SET is_process=1, process_date=NOW() WHERE id_ol_store_ror_bli='" + data.Rows(i)("id_ol_store_ror_bli").ToString + "' ", True, "", "", "", "")
            End If
        Next
    End Sub
End Class
