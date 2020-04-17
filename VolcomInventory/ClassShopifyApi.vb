﻿Public Class ClassShopifyApi
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

        Dim request As Net.WebRequest = Net.WebRequest.Create("https://" + username + ":" + password + "@" + shop + "/admin/api/2020-04/products.json")

        request.Method = "GET"

        request.Credentials = New Net.NetworkCredential(username, password)

        Dim data As DataTable = New DataTable

        data.Columns.Add("sku", GetType(String))
        data.Columns.Add("inventory_item_id", GetType(String))

        Dim response As Net.WebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            For Each row In json("products").ToList
                For Each row2 In row("variants").ToList
                    data.Rows.Add(row2("sku"), row2("inventory_item_id"))
                Next
            Next
        End Using

        response.Close()

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
End Class
