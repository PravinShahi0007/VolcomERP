Public Class ClassZaloraApi
    Public api_key As String = get_setup_field("zalora_api_key")
    Public user_id As String = get_setup_field("zalora_user_id")
    Dim id_store_group As String = get_setup_field("zalora_comp_group")

    Function get_signature(ByVal parameter As DataTable) As String
        Dim url As String = ""

        For i = 0 To parameter.Rows.Count - 1
            url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
        Next

        url = url.Substring(0, url.Length - 1)

        Dim encoding As New System.Text.UTF8Encoding

        Dim key() As Byte = encoding.GetBytes(api_key)
        Dim text() As Byte = encoding.GetBytes(url)

        Dim sha265 As New Security.Cryptography.HMACSHA256(key)
        Dim hash_code As Byte() = sha265.ComputeHash(text)
        Dim hash As String = Replace(BitConverter.ToString(hash_code), "-", "")

        Return hash.ToLower
    End Function

    Function download_shipping_label(ByVal order_item_id As String, ByVal type As String) As String
        Dim out As String = ""

        Dim parameter As DataTable = New DataTable

        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))

        parameter.Rows.Add("Action", "GetDocument")
        parameter.Rows.Add("DocumentType", type)
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("OrderItemIds", Uri.EscapeDataString("[" + order_item_id + "]"))
        parameter.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter.Rows.Add("UserID", Uri.EscapeDataString(user_id))
        parameter.Rows.Add("Version", "1.0")

        Dim signature As String = get_signature(parameter)

        parameter.Rows.Add("Signature", signature)

        Dim url As String = "https://sellercenter-api.zalora.co.id?"

        For i = 0 To parameter.Rows.Count - 1
            url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
        Next

        url = url.Substring(0, url.Length - 1)

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(url)

        request.Method = "GET"

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            out = json("SuccessResponse")("Body")("Documents")("Document")("File")
        End Using

        response.Close()

        Return out
    End Function

    Sub getOrder2020()
        Dim url As String = "https://sellercenter-api.zalora.co.id?Action=GetOrders&CreatedAfter=2019-12-31T00%3A00%3A00&Format=JSON&Timestamp=2020-10-09T15%3A04%3A40%2B07%3A00&UserID=catur%40volcom.co.id&Version=1.0&Signature=7a8a4e84e2fdd4237d7d725e242453f49dd563e3078828c8cddb50355c938567"
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(url)

        request.Method = "GET"

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("SuccessResponse")("Body")("Orders")("Order").Count > 0 Then
                Console.WriteLine(json("SuccessResponse")("Body")("Orders")("Order").Count.ToString)
            End If
        End Using

        response.Close()
    End Sub

    Function get_page_order() As Integer
        Dim parameter As DataTable = New DataTable

        parameter.Columns.Add("key", GetType(String))
        parameter.Columns.Add("value", GetType(String))

        parameter.Rows.Add("Action", "GetOrders")
        parameter.Rows.Add("Format", "JSON")
        parameter.Rows.Add("Limit", "1")
        parameter.Rows.Add("Offset", "0")
        parameter.Rows.Add("Status", "pending")
        parameter.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter.Rows.Add("UserID", Uri.EscapeDataString(user_id))
        parameter.Rows.Add("Version", "1.0")


        Dim signature As String = get_signature(parameter)

        parameter.Rows.Add("Signature", signature)

        Dim url As String = "https://sellercenter-api.zalora.co.id?"

        For i = 0 To parameter.Rows.Count - 1
            url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
        Next

        url = url.Substring(0, url.Length - 1)

        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(url)
        'Console.WriteLine(url)

        request.Method = "GET"

        Dim response As Net.HttpWebResponse = request.GetResponse()

        Dim page As Decimal = 0
        Using dataStream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("SuccessResponse")("Head").Count > 0 Then
                page = Math.Ceiling(Decimal.Parse(json("SuccessResponse")("Head")("TotalCount").ToString) / 1000)
            End If
        End Using

        response.Close()

        Return page
    End Function

    Sub get_order_list()
        Dim page As Integer = get_page_order()
        For p As Integer = 0 To page - 1
            Dim parameter As DataTable = New DataTable

            parameter.Columns.Add("key", GetType(String))
            parameter.Columns.Add("value", GetType(String))

            parameter.Rows.Add("Action", "GetOrders")
            parameter.Rows.Add("Format", "JSON")
            parameter.Rows.Add("Limit", "1000")
            parameter.Rows.Add("Offset", p.ToString)
            parameter.Rows.Add("Status", "pending")
            parameter.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
            parameter.Rows.Add("UserID", Uri.EscapeDataString(user_id))
            parameter.Rows.Add("Version", "1.0")

            Dim signature As String = get_signature(parameter)

            parameter.Rows.Add("Signature", signature)

            Dim url As String = "https://sellercenter-api.zalora.co.id?"

            For i = 0 To parameter.Rows.Count - 1
                url += parameter.Rows(i)("key").ToString + "=" + parameter.Rows(i)("value").ToString + "&"
            Next

            url = url.Substring(0, url.Length - 1)

            Dim request As Net.HttpWebRequest = Net.WebRequest.Create(url)

            request.Method = "GET"

            Dim response As Net.HttpWebResponse = request.GetResponse()
            Using dataStream As IO.Stream = response.GetResponseStream()
                Dim reader As IO.StreamReader = New IO.StreamReader(dataStream)

                Dim responseFromServer As String = reader.ReadToEnd()

                Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

                If json("SuccessResponse")("Body")("Orders")("Order").Count > 0 Then
                    For Each row In json("SuccessResponse")("Body")("Orders")("Order").ToList
                        'check first
                        Dim q_check As String = "SELECT * FROM tb_ol_store_order WHERE id='" & row("OrderId").ToString & "' AND id_comp_group='" + id_store_group + "' "
                        Dim dt_check As DataTable = execute_query(q_check, -1, True, "", "", "", "")
                        If Not dt_check.Rows.Count > 0 Then
                            get_order_detail(row("OrderId").ToString)
                        End If
                    Next
                End If
            End Using

            response.Close()
        Next
    End Sub

    Sub get_order_detail(ByVal order_par As String)

    End Sub
End Class
