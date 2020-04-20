Public Class ClassShopifyApi
    Public username As String = get_setup_field("shopify_api_username")
    Public password As String = get_setup_field("shopify_api_password")
    Public shop As String = get_setup_field("shopify_api_shop")

    Function get_location_id() As String
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/locations.json")

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

        data.Columns.Add("sku", GetType(String))
        data.Columns.Add("inventory_item_id", GetType(String))

        Dim url As String = "https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/products.json"

        Dim since_id As String = ""

        For i = 0 To 1000
            Dim url_since_id As String = url + (If(Not since_id = "", "?since_id=" + since_id, ""))

            Dim request As Net.WebRequest = Net.WebRequest.Create(url_since_id)

            request.Method = "GET"

            request.Credentials = New Net.NetworkCredential(username, password)

            Dim response As Net.WebResponse = request.GetResponse()

            Using dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

                Dim responseFromServer As String = reader.ReadToEnd()

                Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

                If json("products").Count > 0 Then
                    For Each row In json("products").ToList
                        since_id = row("id")

                        For Each row2 In row("variants").ToList
                            data.Rows.Add(row2("sku"), row2("inventory_item_id"))
                        Next
                    Next
                Else
                    Exit For
                End If
            End Using

            response.Close()
        Next

        Return data
    End Function

    Sub add_product(location_id As String, inventory_item_id As String, available_adjustment As String)
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/inventory_levels/adjust.json")

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

    Sub sync_sku()
        Dim product As DataTable = get_product()

        For i = 0 To product.Rows.Count - 1
            Dim query As String = "INSERT IGNORE INTO tb_m_product_shopify (sku, inventory_item_id) VALUES ('" + product.Rows(i)("sku").ToString + "', " + product.Rows(i)("inventory_item_id").ToString + ")"

            execute_non_query(query, True, "", "", "", "")
        Next
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

    Sub upd_price(ByVal design_code As String, ByVal price As String) 'kode 9digit, bukan variant id
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
	WHERE sku LIKE '" & design_code & "___'
	ORDER BY variant_id DESC
) p 
GROUP BY p.sku"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")

        For i = 0 To dt.Rows.Count - 1
            Dim data = Text.Encoding.UTF8.GetBytes("{
  ""variant"": {
    ""id"": " & dt.Rows(i)("variant_id").ToString & ",
    ""price"": """ & price & """
  }
}")
            Dim result_post As String = SendRequest("https://" & username & ":" & password & "@" & shop & "/admin/api/2020-04/variants/" & dt.Rows(i)("variant_id").ToString & ".json", data, "application/json", "PUT", username, password)
            'Console.WriteLine(result_post.ToString)
        Next
    End Sub
End Class
