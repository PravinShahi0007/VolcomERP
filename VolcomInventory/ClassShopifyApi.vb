﻿Public Class ClassShopifyApi
    Public username As String = get_setup_field("shopify_api_username")
    Public password As String = get_setup_field("shopify_api_password")
    Public shop As String = get_setup_field("shopify_api_shop")
    Public id_comp_group As String = get_setup_field("shopify_comp_group")
    Public api_new_version As String = get_setup_field("shopify_api_version")


    Function get_location_id() As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/locations.json")

        request.Method = "GET"

        request.Credentials = New Net.NetworkCredential(username, password)

        Dim location_id As String = ""

        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            For Each row In json("locations").ToList
                location_id = row("id").ToString
            Next
        End Using

        response.Close()

        Return location_id
    End Function

    Function get_product() As DataTable
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim data As DataTable = New DataTable

        data.Columns.Add("variant_id", GetType(String))
        data.Columns.Add("product_id", GetType(String))
        data.Columns.Add("sku", GetType(String))
        data.Columns.Add("inventory_item_id", GetType(String))
        data.Columns.Add("compare_price", GetType(String))
        data.Columns.Add("design_price", GetType(String))
        data.Columns.Add("inventory_quantity", GetType(String))

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/products.json?limit=250"

        Dim page_info As String = ""

        For i = 0 To 1000
            Dim url_page_info As String = url + (If(Not page_info = "", "&page_info=" + page_info, ""))

            Dim request As Net.WebRequest = Net.WebRequest.Create(url_page_info)

            request.Method = "GET"

            request.Credentials = New Net.NetworkCredential(username, password)

            Dim response As Net.WebResponse = request.GetResponse()

            If Not page_info = "" Or i = 0 Then
                Using dataStream As IO.Stream = response.GetResponseStream()
                    Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

                    Dim responseFromServer As String = reader.ReadToEnd()

                    Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

                    For Each row In json("products").ToList
                        For Each row2 In row("variants").ToList
                            data.Rows.Add(row2("id"), row2("product_id"), row2("sku"), row2("inventory_item_id"), row2("compare_at_price"), row2("price"), row2("inventory_quantity"))
                        Next
                    Next
                End Using
            Else
                Exit For
            End If

            'get next page
            Dim link_pos As Integer = 0

            For l = 0 To response.Headers.AllKeys.Count - 1
                If response.Headers.AllKeys(l) = "Link" Then
                    link_pos = l
                End If
            Next

            Dim link As String() = response.Headers.GetValues(link_pos)

            Dim j1 As Integer = link(link.Count - 1).LastIndexOf(">; rel=""next")
            Dim j2 As Integer = link(link.Count - 1).LastIndexOf("o=") + 2

            If j1 > 0 And j2 > 0 Then
                page_info = link(link.Count - 1).Substring(0, j1).Substring(j2)
            Else
                page_info = ""
            End If

            response.Close()
        Next

        Return data
    End Function

    Sub add_product(location_id As String, inventory_item_id As String, available_adjustment As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/inventory_levels/adjust.json")

        request.Method = "POST"

        request.Credentials = New Net.NetworkCredential(username, password)

        Dim body As String = "location_id=" + location_id + "&inventory_item_id=" + inventory_item_id + "&available_adjustment=" + available_adjustment

        Dim body_array As Byte() = System.Text.Encoding.UTF8.GetBytes(body)

        request.ContentType = "application/x-www-form-urlencoded"

        request.ContentLength = body_array.Length

        Dim data_stream As IO.Stream = request.GetRequestStream()

        data_stream.Write(body_array, 0, body_array.Length)

        data_stream.Close()

        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()
        End Using

        response.Close()
    End Sub

    Function sync_sku() As Boolean
        Dim product As DataTable = get_product()

        For i = 0 To product.Rows.Count - 1
            Dim query As String = "INSERT IGNORE INTO tb_m_product_shopify (variant_id, sku, product_id, inventory_item_id, date) VALUES ('" + product.Rows(i)("variant_id").ToString + "', '" + product.Rows(i)("sku").ToString + "', '" + product.Rows(i)("product_id").ToString + "', '" + product.Rows(i)("inventory_item_id").ToString + "', NOW())"

            execute_non_query(query, True, "", "", "", "")

            Dim q_price As String = "INSERT INTO tb_m_price_shopify (sku, compare_price, design_price, date) VALUES ('" + product.Rows(i)("sku").ToString + "', '" + product.Rows(i)("compare_price").ToString + "', '" + product.Rows(i)("design_price").ToString + "', NOW())"

            execute_non_query(q_price, True, "", "", "", "")
        Next

        'check duplicate
        Dim query_d As String = "SELECT sku, COUNT(*) AS total FROM tb_m_product_shopify GROUP BY sku HAVING total > 1"

        Dim data_d As DataTable = execute_query(query_d, -1, True, "", "", "", "")

        Dim sku As String = ""

        Dim sku_copy As String = ""

        For i = 0 To data_d.Rows.Count - 1
            If Not data_d.Rows(i)("sku").ToString = "" Then
                sku += data_d.Rows(i)("sku").ToString + ", "

                sku_copy += data_d.Rows(i)("sku").ToString + Environment.NewLine

                execute_non_query("
                    INSERT INTO tb_m_product_shopify_duplicate (variant_id, sku, product_id, inventory_item_id, `date`)
                    SELECT variant_id, sku, product_id, inventory_item_id, NOW() AS `date` FROM tb_m_product_shopify WHERE sku = '" + data_d.Rows(i)("sku").ToString + "';
                
                    DELETE FROM tb_m_product_shopify WHERE sku = '" + data_d.Rows(i)("sku").ToString + "';
                ", True, "", "", "", "")
            End If
        Next

        If Not sku = "" Then
            warningCustom("Duplicate SKU: " + sku.Substring(0, sku.Length - 2) + ". Please make sure there are no duplicate sku on the website and Sync again.")

            My.Computer.Clipboard.SetText(sku_copy)

            infoCustom("SKU copied to clipboard.")
        End If

        Return If(sku = "", True, False)
    End Function


    Sub get_order_erp()
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        'get url order
        Dim cond_order As String = get_setup_field("url_order")

        'Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/orders.json?since_id=" + since_id + cond_order
        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/orders.json?fulfillment_status=unshipped" + cond_order

        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()

        Dim data_payment_gateway As DataTable = execute_query("SELECT ol_store_pay FROM tb_ol_store_pay", -1, True, "", "", "", "")

        Dim is_allow_check_discount_app As String = get_setup_field("is_allow_check_discount_app")

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("orders").Count > 0 Then
                For Each row In json("orders").ToList
                    'check payment
                    Dim is_valid_payment As Boolean = True
                    For Each row_payment In row("payment_gateway_names").ToList
                        Dim view_payment_gateway As DataView = New DataView(data_payment_gateway)

                        view_payment_gateway.RowFilter = "ol_store_pay = '" + row_payment.ToString + "'"

                        If view_payment_gateway.Count <= 0 Then
                            is_valid_payment = False
                        End If
                    Next

                    If is_valid_payment Then
                        'check first
                        Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE id='" & row("id").ToString & "' AND id_comp_group=" + id_comp_group + " "
                        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                        If Not dt_check.Rows.Count > 0 Then
                            'var data general
                            Dim id As String = ""
                            Dim sales_order_ol_shop_number As String = ""
                            Dim sales_order_ol_shop_date As String = ""
                            Dim payment_method As String = ""
                            Dim checkout_id As String = ""
                            Dim tracking_code As String = ""
                            Dim financial_status As String = ""
                            Dim total_discounts As String = ""

                            id = row("id").ToString
                            sales_order_ol_shop_number = row("order_number").ToString
                            sales_order_ol_shop_date = DateTime.Parse(row("created_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                            payment_method = row("gateway").ToString
                            tracking_code = ""
                            financial_status = row("financial_status").ToString
                            checkout_id = row("checkout_id").ToString
                            total_discounts = decimalSQL(row("total_discounts").ToString)

                            'discount codes
                            Dim discount_code As String = ""
                            If row("discount_codes").Count > 0 Then
                                For Each row_disc_codes In row("discount_codes").ToList
                                    discount_code = row_disc_codes("code").ToString
                                    Exit For
                                Next
                            Else
                                discount_code = ""
                            End If

                            'discount codes app
                            If is_allow_check_discount_app = "1" Then
                                If row("tags").ToString.Contains("giftbox") And discount_code = "" Then
                                    For Each row_app In row("discount_applications").ToList
                                        If row_app("type").ToString = "manual" Then
                                            discount_code = row_app("title").ToString
                                        End If
                                    Next
                                End If
                            End If

                            'data customer
                            Dim customer_name As String = ""
                            customer_name = row("customer")("first_name").ToString + " " + row("customer")("last_name").ToString

                            'data shipping
                            Dim shipping_name As String = ""
                            Dim shipping_address As String = ""
                            Dim shipping_address1 As String = ""
                            Dim shipping_address2 As String = ""
                            Dim shipping_phone As String = ""
                            Dim shipping_city As String = ""
                            Dim shipping_post_code As String = ""
                            Dim shipping_region As String = ""
                            Try
                                shipping_name = If(row("shipping_address")("name") Is Nothing, "", row("shipping_address")("name").ToString)
                            Catch ex As Exception
                                shipping_name = ""
                            End Try
                            Try
                                shipping_address = row("shipping_address")("address1").ToString + " "
                                shipping_address += row("shipping_address")("address2").ToString + " "
                                shipping_address += row("shipping_address")("city").ToString + " "
                                shipping_address += row("shipping_address")("province").ToString + " "
                                shipping_address += row("shipping_address")("zip").ToString + " "
                                shipping_address += row("shipping_address")("country").ToString + " "
                                shipping_address += "Phone : " + row("shipping_address")("phone").ToString
                            Catch ex As Exception
                                shipping_address = ""
                            End Try
                            Try
                                shipping_address1 = If(row("shipping_address")("address1") Is Nothing, "", row("shipping_address")("address1").ToString)
                            Catch ex As Exception
                                shipping_address1 = ""
                            End Try
                            Try
                                shipping_address2 = If(row("shipping_address")("address2") Is Nothing, "", row("shipping_address")("address2").ToString)
                            Catch ex As Exception
                                shipping_address2 = ""
                            End Try
                            Try
                                shipping_phone = If(row("shipping_address")("phone") Is Nothing, "", row("shipping_address")("phone").ToString)
                            Catch ex As Exception
                                shipping_phone = ""
                            End Try
                            Try
                                shipping_city = If(row("shipping_address")("city") Is Nothing, "", row("shipping_address")("city").ToString)
                            Catch ex As Exception
                                shipping_city = ""
                            End Try
                            Try
                                shipping_post_code = If(row("shipping_address")("zip") Is Nothing, "", row("shipping_address")("zip").ToString)
                            Catch ex As Exception
                                shipping_post_code = ""
                            End Try
                            Try
                                shipping_region = If(row("shipping_address")("province") Is Nothing, "", row("shipping_address")("province").ToString)
                            Catch ex As Exception
                                shipping_region = ""
                            End Try

                            'detail shipping
                            Dim shipping_price As String = ""
                            For Each row_ship In row("shipping_lines").ToList
                                shipping_price = decimalSQL(row_ship("price").ToString)
                            Next

                            'detail line item
                            Dim qins As String = "INSERT tb_ol_store_order(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address,shipping_address1,shipping_address2, shipping_phone, 
                    shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code, ol_store_sku, ol_store_id, sku, design_price, ol_order_qty, sales_order_det_qty, grams, financial_status, total_disc_order, discount_allocations_amo,checkout_id, shipping_price, discount_code, id_comp_group) VALUES "
                            Dim ol_store_sku As String = ""
                            Dim ol_store_id As String = ""
                            Dim sku As String = ""
                            Dim design_price As String = ""
                            Dim ol_order_qty As String = ""
                            Dim sales_order_det_qty As String = ""
                            Dim grams As String = ""
                            Dim discount_allocations_amo As String = "0"
                            Dim i As Integer = 0
                            For Each row_item In row("line_items").ToList
                                ol_store_sku = row_item("sku").ToString.Replace("-GWP", "").Trim
                                ol_store_id = row_item("id").ToString
                                sku = row_item("sku").ToString.Replace("-GWP", "").Trim
                                design_price = decimalSQL(row_item("price").ToString)
                                ol_order_qty = decimalSQL(row_item("quantity").ToString)
                                sales_order_det_qty = decimalSQL(row_item("quantity").ToString)
                                grams = decimalSQL(row_item("grams").ToString)

                                'discount allocation
                                If row_item("discount_allocations").Count > 0 Then
                                    For Each row_disc_aloc In row_item("discount_allocations").ToList
                                        discount_allocations_amo = decimalSQL(row_disc_aloc("amount").ToString)
                                        Exit For
                                    Next
                                Else
                                    discount_allocations_amo = "0"
                                End If

                                If i > 0 Then
                                    qins += ","
                                End If
                                qins += "('" + id + "', '" + sales_order_ol_shop_number + "', '" + sales_order_ol_shop_date + "', '" + addSlashes(customer_name) + "', '" + addSlashes(shipping_name) + "', '" + addSlashes(shipping_address) + "','" + addSlashes(shipping_address1) + "','" + addSlashes(shipping_address2) + "', '" + addSlashes(shipping_phone) + "', 
                        '" + addSlashes(shipping_city) + "', '" + addSlashes(shipping_post_code) + "', '" + addSlashes(shipping_region) + "', '" + payment_method + "', '" + tracking_code + "', '" + ol_store_sku + "', '" + ol_store_id + "', '" + sku + "', '" + design_price + "', '" + ol_order_qty + "', '" + sales_order_det_qty + "','" + grams + "', '" + addSlashes(financial_status) + "', '" + total_discounts + "', '" + discount_allocations_amo + "','" + addSlashes(checkout_id) + "', '" + shipping_price + "', '" + discount_code + "', '" + id_comp_group + "') "
                                i += 1
                            Next

                            'insert ortder
                            If i > 0 Then
                                execute_non_query(qins, True, "", "", "", "")
                            End If
                        End If
                    End If
                Next
            End If
        End Using

        response.Close()
    End Sub

    Sub get_order_erp_specific(ByVal specific_id As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        'get url order
        Dim cond_order As String = get_setup_field("url_order")

        'get max id
        Dim since_id As String = execute_query("SELECT IFNULL(MAX(id),0) AS `since_id` FROM tb_ol_store_order ", 0, True, "", "", "", "")

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/orders.json?ids=" + specific_id + cond_order
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("orders").Count > 0 Then
                For Each row In json("orders").ToList
                    'var data general
                    Dim id As String = ""
                    Dim sales_order_ol_shop_number As String = ""
                    Dim sales_order_ol_shop_date As String = ""
                    Dim payment_method As String = ""
                    Dim tracking_code As String = ""
                    Dim financial_status As String = ""

                    'discount codes
                    Dim discount_code As String = ""
                    If row("discount_codes").Count > 0 Then
                        For Each row_disc_codes In row("discount_codes").ToList
                            discount_code = row_disc_codes("code").ToString
                            Exit For
                        Next
                    Else
                        discount_code = ""
                    End If

                    id = row("id").ToString
                    sales_order_ol_shop_number = row("order_number").ToString
                    sales_order_ol_shop_date = DateTime.Parse(row("created_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                    payment_method = row("gateway").ToString
                    tracking_code = ""
                    financial_status = row("financial_status").ToString

                    'data customer
                    Dim customer_name As String = ""
                    customer_name = row("customer")("first_name").ToString + " " + row("customer")("last_name").ToString

                    'data shipping
                    Dim shipping_name As String = ""
                    Dim shipping_address As String = ""
                    Dim shipping_address1 As String = ""
                    Dim shipping_address2 As String = ""
                    Dim shipping_phone As String = ""
                    Dim shipping_city As String = ""
                    Dim shipping_post_code As String = ""
                    Dim shipping_region As String = ""
                    Try
                        shipping_name = If(row("shipping_address")("name") Is Nothing, "", row("shipping_address")("name").ToString)
                    Catch ex As Exception
                        shipping_name = ""
                    End Try
                    Try
                        shipping_address = row("shipping_address")("address1").ToString + " "
                        shipping_address += row("shipping_address")("address2").ToString + " "
                        shipping_address += row("shipping_address")("city").ToString + " "
                        shipping_address += row("shipping_address")("province").ToString + " "
                        shipping_address += row("shipping_address")("zip").ToString + " "
                        shipping_address += row("shipping_address")("country").ToString + " "
                        shipping_address += "Phone : " + row("shipping_address")("phone").ToString
                    Catch ex As Exception
                        shipping_address = ""
                    End Try
                    Try
                        shipping_address1 = If(row("shipping_address")("address1") Is Nothing, "", row("shipping_address")("address1").ToString)
                    Catch ex As Exception
                        shipping_address1 = ""
                    End Try
                    Try
                        shipping_address2 = If(row("shipping_address")("address2") Is Nothing, "", row("shipping_address")("address2").ToString)
                    Catch ex As Exception
                        shipping_address2 = ""
                    End Try
                    Try
                        shipping_phone = If(row("shipping_address")("phone") Is Nothing, "", row("shipping_address")("phone").ToString)
                    Catch ex As Exception
                        shipping_phone = ""
                    End Try
                    Try
                        shipping_city = If(row("shipping_address")("city") Is Nothing, "", row("shipping_address")("city").ToString)
                    Catch ex As Exception
                        shipping_city = ""
                    End Try
                    Try
                        shipping_post_code = If(row("shipping_address")("zip") Is Nothing, "", row("shipping_address")("zip").ToString)
                    Catch ex As Exception
                        shipping_post_code = ""
                    End Try
                    Try
                        shipping_region = If(row("shipping_address")("province") Is Nothing, "", row("shipping_address")("province").ToString)
                    Catch ex As Exception
                        shipping_region = ""
                    End Try

                    'detail shipping
                    Dim shipping_price As String = ""
                    For Each row_ship In row("shipping_lines").ToList
                        shipping_price = decimalSQL(row_ship("price").ToString)
                    Next

                    'detail line item
                    Dim qins As String = "INSERT tb_ol_store_order(id, sales_order_ol_shop_number, sales_order_ol_shop_date, customer_name, shipping_name, shipping_address,shipping_address1,shipping_address2, shipping_phone, 
                    shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code, ol_store_sku, ol_store_id, sku, design_price, sales_order_det_qty, grams, financial_status, shipping_price, discount_code, id_comp_group) VALUES "
                    Dim ol_store_sku As String = ""
                    Dim ol_store_id As String = ""
                    Dim sku As String = ""
                    Dim design_price As String = ""
                    Dim sales_order_det_qty As String = ""
                    Dim grams As String = ""
                    Dim i As Integer = 0
                    For Each row_item In row("line_items").ToList
                        ol_store_sku = row_item("sku").ToString.Replace("-GWP", "").Trim
                        ol_store_id = row_item("id").ToString
                        sku = row_item("sku").ToString.Replace("-GWP", "").Trim
                        design_price = decimalSQL(row_item("price").ToString)
                        sales_order_det_qty = decimalSQL(row_item("quantity").ToString)
                        grams = decimalSQL(row_item("grams").ToString)

                        If i > 0 Then
                            qins += ","
                        End If
                        qins += "('" + id + "', '" + sales_order_ol_shop_number + "', '" + sales_order_ol_shop_date + "', '" + addSlashes(customer_name) + "', '" + addSlashes(shipping_name) + "', '" + addSlashes(shipping_address) + "','" + addSlashes(shipping_address1) + "','" + addSlashes(shipping_address2) + "', '" + shipping_phone + "', 
                        '" + addSlashes(shipping_city) + "', '" + addSlashes(shipping_post_code) + "', '" + addSlashes(shipping_region) + "', '" + payment_method + "', '" + tracking_code + "', '" + ol_store_sku + "', '" + ol_store_id + "', '" + sku + "', '" + design_price + "', '" + sales_order_det_qty + "','" + grams + "', '" + addSlashes(financial_status) + "', '" + shipping_price + "', '" + discount_code + "', '" + id_comp_group + "') "
                        i += 1
                    Next

                    'insert ortder
                    If i > 0 Then
                        execute_non_query(qins, True, "", "", "", "")
                    End If
                Next
            End If
        End Using

        response.Close()
    End Sub

    Private Function SendRequest(str_url As String, jsonDataBytes As Byte(), contentType As String, method As String, ByVal username As String, ByVal pass As String) As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim response As String
        Dim request As Net.WebRequest


        Dim url As Uri = New Uri(str_url)

        request = Net.WebRequest.Create(url)
        request.ContentLength = jsonDataBytes.Length
        request.ContentType = contentType
        request.Method = method
        request.Credentials = New Net.NetworkCredential(username, password)


        Using requestStream = request.GetRequestStream
            requestStream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
            requestStream.Close()

            Using responseStream = request.GetResponse.GetResponseStream
                Using reader As New IO.StreamReader(responseStream)
                    response = reader.ReadToEnd()
                End Using
            End Using
        End Using

        Return response
    End Function

    Sub upd_price(ByVal product_code As String, ByVal normal_price As String, ByVal current_price As String)
        '        Dim data = Text.Encoding.UTF8.GetBytes("{
        '  ""product"": {
        '    ""variants"": [
        '      {
        '        ""id"": 31852294832164,
        '        ""price"": ""1""
        '      }
        '    ]
        '  }
        '}")

        Dim q As String = "SELECT variant_id,sku
FROM 
(
	SELECT * FROM `tb_m_product_shopify` 
	WHERE sku = '" & product_code & "'
	ORDER BY variant_id DESC
) p 
GROUP BY p.sku"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        For i = 0 To dt.Rows.Count - 1
            Dim data = Text.Encoding.UTF8.GetBytes("{
  ""variant"": {
    ""id"": " & dt.Rows(i)("variant_id").ToString & ",
    ""price"": """ & current_price & """,
    ""compare_at_price"": """ & normal_price & """
  }
}")
            Dim result_post As String = SendRequest("https://" & username & ":" & password & "@" & shop & "/admin/api/" + api_new_version + "/variants/" & dt.Rows(i)("variant_id").ToString & ".json", data, "application/json", "PUT", username, password)
            'Console.WriteLine(result_post.ToString)
        Next
    End Sub

    Sub sync_stock(ByVal id_log As String)
        'get sync date
        Dim query As String = "SELECT DATE_FORMAT(l.sync_date, '%Y-%m-%d %H:%i:%s') AS `sync_date_ins`
        FROM tb_log_compare_shopify l WHERE l.id_log_compare_shopify='" + id_log + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim sync_date As String = data.Rows(0)("sync_date_ins").ToString

        Dim product As DataTable = get_product()

        For i = 0 To product.Rows.Count - 1
            Dim q_price As String = "INSERT INTO tb_m_stock_shopify (sku, stock, date,id_log_compare_shopify) VALUES ('" + product.Rows(i)("sku").ToString + "', '" + product.Rows(i)("inventory_quantity").ToString + "', '" + sync_date + "','" + id_log + "')"

            execute_non_query(q_price, True, "", "", "", "")
        Next
    End Sub

    Sub set_fullfill(ByVal id_order As String, ByVal location_id As String, ByVal tracking_number As String, ByVal val As String, ByVal tracking_comp As String, ByVal tracking_url As String)
        Dim data = Text.Encoding.UTF8.GetBytes("{
  ""fulfillment"": {
    ""location_id"": " + location_id + ",
    ""tracking_number"": """ + tracking_number + """,
    ""tracking_company"": """ + tracking_comp + """,
    ""tracking_url"": """ + tracking_url + tracking_number + """,
    ""line_items"": [
      " + val + "
    ]
  }
}")
        'Console.WriteLine(tracking_url + tracking_number)
        Dim result_post As String = SendRequest("https://" & username & ":" & password & "@" & shop & "/admin/api/" + api_new_version + "/orders/" & id_order & "/fulfillments.json", data, "application/json", "POST", username, password)
    End Sub

    Function get_tag(ByVal product_id As String) As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/products/" + product_id + ".json?fields=tags"
        'Console.WriteLine(url)
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()

        Dim tags As String = ""
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()
            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
            tags = json("product")("tags").ToString
            'For Each row In json("product").ToList
            '    tags = row("tags").ToString
            'Next
        End Using

        response.Close()
        Return tags
    End Function

    Sub set_tag(ByVal product_id As String, ByVal new_tag As String)
        Dim data = Text.Encoding.UTF8.GetBytes("{
  ""product"": {
    ""id"": " + product_id + ",
    ""tags"": """ + new_tag + """
  }
}")
        'Console.WriteLine(tracking_url + tracking_number)
        Dim result_post As String = SendRequest("https://" & username & ":" & password & "@" & shop & "/admin/api/2020-04/products/" + product_id + ".json", data, "application/json", "PUT", username, password)
    End Sub

    Sub get_discount_code()
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)
        Dim dnow As Date = getTimeDB()
        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/price_rules.json?ends_at_min=" + DateTime.Parse(dnow.ToString).ToString("yyyy-MM-dd") + "T00:00:00-00:00 "
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
            If json("price_rules").Count > 0 Then
                For Each row In json("price_rules").ToList
                    'check first
                    Dim price_rule_id As String = ""
                    price_rule_id = row("id").ToString
                    Dim q_check As String = "SELECT * FROM tb_ol_promo_collection WHERE price_rule_id='" & price_rule_id & "'"
                    Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                    If Not dt_check.Rows.Count > 0 Then
                        Dim discount_title As String = ""
                        Dim value_type As String = ""
                        Dim value As String = ""
                        Dim once_per_customer As String = ""
                        Dim usage_limit As String = ""
                        Dim start_period As String = ""
                        Dim end_period As String = ""

                        'get discount code
                        Dim url_dc As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/price_rules/" + price_rule_id + "/discount_codes.json?limit=50"
                        Dim page_info As String = ""
                        Dim i As Integer = 0
                        Dim is_loop As Boolean = True
                        While is_loop
                            Dim url_page_info As String = ""
                            url_page_info = url_dc + (If(Not page_info = "", "&page_info=" + page_info, ""))
                            Dim request_dc As Net.WebRequest = Net.WebRequest.Create(url_dc)
                            request_dc.Method = "GET"
                            request_dc.Credentials = New Net.NetworkCredential(username, password)
                            Dim response_dc As Net.WebResponse = request_dc.GetResponse()

                            If Not page_info = "" Or i = 0 Then
                                Using dataStreamDc As IO.Stream = response_dc.GetResponseStream()
                                    Dim reader_dc As IO.StreamReader = New IO.StreamReader(dataStreamDc)
                                    Dim responseFromServerDc As String = reader_dc.ReadToEnd()
                                    Dim json_diskon As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServerDc)
                                    If json_diskon("discount_codes").Count > 0 Then
                                        Dim j As Integer = 0
                                        Dim id_ol_promo_collection As String = ""
                                        For Each row_diskon In json_diskon("discount_codes").ToList
                                            If j = 0 Then
                                                'insert to promo
                                                discount_title = addSlashes(row("title").ToString)
                                                value_type = addSlashes(row("value_type").ToString)
                                                value = decimalSQL(row("value").ToString)
                                                once_per_customer = row("once_per_customer").ToString
                                                If once_per_customer = "true" Then
                                                    once_per_customer = "1"
                                                Else
                                                    once_per_customer = "2"
                                                End If
                                                usage_limit = 0
                                                Try
                                                    usage_limit = decimalSQL(row("usage_limit").ToString)
                                                Catch ex As Exception
                                                End Try
                                                start_period = DateTime.Parse(row("starts_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                                                end_period = DateTime.Parse(row("ends_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                                                Dim query_prm_head As String = "INSERT INTO tb_ol_promo_collection(id_promo, price_rule_id, promo_name, discount_title, value_type, value, once_per_customer,usage_limit,is_use_discount_code, created_date, created_by, start_period, end_period, id_report_status, is_confirm, tag, note) 
                                                VALUES('0', '" + price_rule_id + "', '" + discount_title + "', '" + discount_title + "', '" + value_type + "', '" + value + "', '" + once_per_customer + "', '" + usage_limit + "', '1', NOW(), '" + id_user + "', '" + start_period + "', '" + end_period + "','1','2', '" + discount_title + "', '" + discount_title + "');SELECT LAST_INSERT_ID(); "
                                                id_ol_promo_collection = execute_query(query_prm_head, 0, True, "", "", "", "")
                                                Dim rmt As String = "250"
                                                execute_non_query("CALL gen_number(" + id_ol_promo_collection + ", " + rmt + ")", True, "", "", "", "")
                                            End If

                                            'insert detail diskon kode
                                            Dim disc_code As String = ""
                                            disc_code = row_diskon("code").ToString
                                            Dim query_insert_diskon As String = "INSERT INTO tb_ol_promo_collection_disc_code(id_ol_promo_collection,disc_code, sync_date, sync_by) VALUES('" + id_ol_promo_collection + "','" + disc_code + "',NOW(), '" + id_user + "'); "
                                            execute_non_query(query_insert_diskon, True, "", "", "", "")
                                            j += 1
                                        Next
                                    End If
                                End Using
                                is_loop = True
                            Else
                                is_loop = False
                            End If
                            i += 1

                            'get next page
                            Dim link As String() = response.Headers.GetValues(16)
                            Dim j1 As Integer = link(link.Count - 1).LastIndexOf(">; rel=""next")
                            Dim j2 As Integer = link(link.Count - 1).LastIndexOf("o=") + 2
                            If j1 > 0 And j2 > 0 Then
                                page_info = link(link.Count - 1).Substring(0, j1).Substring(j2)
                            Else
                                page_info = ""
                            End If

                            response_dc.Close()
                        End While
                    End If
                Next
            End If
        End Using
        response.Close()
    End Sub

    Sub get_discount_code_addition(ByVal id_promo As String, ByVal id_price_rule As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)
        Dim url_dc As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/price_rules/" + id_price_rule + "/discount_codes.json?limit=50"
        Dim page_info As String = ""
        Dim i As Integer = 0
        Dim is_loop As Boolean = True
        While is_loop
            Dim url_page_info As String = ""
            url_page_info = url_dc + (If(Not page_info = "", "&page_info=" + page_info, ""))
            Dim request As Net.WebRequest = Net.WebRequest.Create(url_page_info)
            request.Method = "GET"
            request.Credentials = New Net.NetworkCredential(username, password)
            Dim response As Net.WebResponse = request.GetResponse()
            If Not page_info = "" Or i = 0 Then
                Using dataStream As IO.Stream = response.GetResponseStream()
                    Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)
                    Dim responseFromServer As String = reader.ReadToEnd()
                    Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)
                    For Each row In json("discount_codes").ToList
                        Dim disc_code As String = ""
                        disc_code = addSlashes(row("code").ToString)
                        Dim query_cek As String = "SELECT * FROM tb_ol_promo_collection_disc_code c WHERE c.id_ol_promo_collection='" + id_promo + "' AND c.disc_code='" + disc_code + "' "
                        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
                        If data_cek.Rows.Count <= 0 Then
                            'Console.WriteLine(disc_code)
                            Dim query_insert_diskon As String = "INSERT INTO tb_ol_promo_collection_disc_code(id_ol_promo_collection, disc_code, sync_date, sync_by, is_additional) VALUES('" + id_promo + "', '" + disc_code + "', NOW(), '" + id_user + "', '1'); "
                            execute_non_query(query_insert_diskon, True, "", "", "", "")
                        End If
                    Next
                End Using
                is_loop = True
            Else
                is_loop = False
            End If
            i += 1

            'get next page
            Dim link As String() = response.Headers.GetValues(16)
            Dim j1 As Integer = link(link.Count - 1).LastIndexOf(">; rel=""next")
            Dim j2 As Integer = link(link.Count - 1).LastIndexOf("o=") + 2
            If j1 > 0 And j2 > 0 Then
                page_info = link(link.Count - 1).Substring(0, j1).Substring(j2)
            Else
                page_info = ""
            End If

            response.Close()
        End While
    End Sub

    Sub get_open_order(ByVal id_log As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)
        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/orders.json?status=opened&limit=250"
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("orders").Count > 0 Then
                For Each row In json("orders").ToList
                    'cek di ol store order
                    Dim qc As String = "SELECT * FROM tb_ol_store_order od WHERE od.id_comp_group=76 AND od.is_process=1 AND od.sales_order_ol_shop_number='" + row("order_number").ToString + "' "
                    Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dc.Rows.Count <= 0 Then
                        'yang blm trproses masuk sini
                        Dim order_number As String = row("order_number").ToString
                        Dim order_date As String = DateTime.Parse(row("created_at").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim customer_name As String = row("customer")("first_name").ToString + " " + row("customer")("last_name").ToString

                        Dim query_ins As String = "INSERT INTO tb_shopify_open_order(order_number, order_date, customer_name, sku, qty, id_log_compare_shopify) VALUES "
                        Dim i As Integer = 0
                        For Each row_item In row("line_items").ToList
                            Dim sku As String = row_item("sku").ToString.Replace("-GWP", "").Trim
                            Dim qty As String = decimalSQL(row_item("quantity").ToString)

                            If i > 0 Then
                                query_ins += ","
                            End If
                            query_ins += "('" + order_number + "', '" + order_date + "', '" + addSlashes(customer_name) + "', '" + sku + "', '" + qty + "', '" + id_log + "') "
                            i += 1
                        Next
                        'insert ortder
                        If i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                    End If
                Next
            End If
        End Using
        response.Close()
    End Sub

    Function compare_qty_sku(sku() As String) As DataTable
        Dim data_out As DataTable = New DataTable

        data_out.Columns.Add("sku", GetType(String))
        data_out.Columns.Add("qty_shopify", GetType(Integer))
        data_out.Columns.Add("qty_erp", GetType(Integer))

        'product erp
        Dim yr As String = execute_query("SELECT YEAR(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()), '-', '01'), INTERVAL 1 DAY))", 0, True, "", "", "", "")

        Dim q_erp As String = "
            SELECT p.product_full_code, SUM(a.qty_avl) AS qty_avl
            FROM (
                (SELECT f.id_wh_drawer, f.id_product, f.qty_avl
                FROM tb_storage_fg_" + yr + " f
                WHERE f.month = MONTH(DATE_SUB(CONCAT(YEAR(NOW()), '-', MONTH(NOW()), '-', '01'), INTERVAL 1 DAY)))
                UNION ALL
                (SELECT f.id_wh_drawer, f.id_product, SUM(IF(f.id_storage_category = 2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty_avl
                FROM tb_storage_fg f
                WHERE f.storage_product_datetime >= CONCAT(YEAR(NOW()), '-', MONTH(NOW()), '-', '01 00:00:00') AND f.storage_product_datetime <= CONCAT(DATE(NOW()), ' 23:59:59')
                GROUP BY f.id_wh_drawer, f.id_product)
            ) a
            INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer
            INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
            INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator AND loc.id_comp IN (1252, 1256)
            INNER JOIN tb_m_product p ON p.id_product = a.id_product
            WHERE p.product_full_code IN (" + String.Join(",", sku) + ")
            GROUP BY a.id_product
        "

        Dim d_erp As DataTable = execute_query(q_erp, -1, True, "", "", "", "")

        'from product
        Dim product As DataTable = get_product()

        For i = 0 To product.Rows.Count - 1
            If sku.Contains(product.Rows(i)("sku").ToString) Then
                Dim row As DataRow = data_out.NewRow

                row("sku") = product.Rows(i)("sku").ToString
                row("qty_shopify") = CType(product.Rows(i)("inventory_quantity").ToString, Integer)

                For j = 0 To d_erp.Rows.Count - 1
                    If d_erp.Rows(j)("product_full_code").ToString = product.Rows(i)("sku").ToString Then
                        row("qty_erp") = d_erp.Rows(j)("qty_avl")
                    End If
                Next

                data_out.Rows.Add(row)
            End If
        Next

        'from order
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)
        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/" + api_new_version + "/orders.json?status=opened&limit=250"
        Dim request As Net.WebRequest = Net.WebRequest.Create(url)
        request.Method = "GET"
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.WebResponse = request.GetResponse()
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("orders").Count > 0 Then
                For Each row In json("orders").ToList
                    'cek di ol store order
                    Dim qc As String = "SELECT * FROM tb_ol_store_order od WHERE od.id_comp_group=76 AND od.is_process=1 AND od.sales_order_ol_shop_number='" + row("order_number").ToString + "' "
                    Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dc.Rows.Count <= 0 Then
                        'yang blm trproses masuk sini
                        For Each item In row("line_items").ToList
                            If sku.Contains(item("sku").ToString) Then
                                For i = 0 To data_out.Rows.Count - 1
                                    If data_out.Rows(i)("sku").ToString = item("sku").ToString Then
                                        data_out.Rows(i)("qty_shopify") = data_out.Rows(i)("qty_shopify") + item("quantity")
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        End Using
        response.Close()

        Return data_out
    End Function
End Class
