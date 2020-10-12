Public Class ClassZaloraApi
    Public api_key As String = get_setup_field("zalora_api_key")
    Public user_id As String = get_setup_field("zalora_user_id")
    Dim id_store_group As String = get_setup_field("zalora_comp_group")

    Dim data_size As New DataTable

    Sub New()
        Dim id_code_detail_size As String = get_setup_field("id_code_product_size")
        Dim query As String = "SELECT cd.id_code_detail,cd.code, cd.code_detail_name FROM tb_m_code_detail cd WHERE cd.id_code=" + id_code_detail_size + " "
        data_size = execute_query(query, -1, True, "", "", "", "")
    End Sub

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
                            Dim id As String = ""
                            id = row("OrderId").ToString

                            'detail items

                        End If
                    Next
                End If
            End Using

            response.Close()
        Next
    End Sub

    Function get_order_detail(ByVal id As String) As DataTable
        Dim dt As DataTable
        dt.Columns.Add("ol_store_id", GetType(String))
        dt.Columns.Add("item_id", GetType(String))
        dt.Columns.Add("sku", GetType(String))
        dt.Columns.Add("ol_store_sku", GetType(String))
        dt.Columns.Add("design_price", GetType(Decimal))
        dt.Columns.Add("tracking_code", GetType(String))
        dt.Columns.Add("sales_order_ol_shop_date", GetType(DateTime))

        Dim parameter_det As DataTable = New DataTable

        parameter_det.Columns.Add("key", GetType(String))
        parameter_det.Columns.Add("value", GetType(String))

        parameter_det.Rows.Add("Action", "GetOrderItems")
        parameter_det.Rows.Add("Format", "JSON")
        parameter_det.Rows.Add("OrderId", id)
        parameter_det.Rows.Add("Timestamp", Uri.EscapeDataString(DateTime.Parse(Now().ToUniversalTime().ToString).ToString("yyyy-MM-ddTHH:mm:ss+00:00")))
        parameter_det.Rows.Add("UserID", Uri.EscapeDataString(user_id))
        parameter_det.Rows.Add("Version", "1.0")

        Dim signature_det As String = get_signature(parameter_det)

        parameter_det.Rows.Add("Signature", signature_det)

        Dim url_det As String = "https://sellercenter-api.zalora.co.id?"

        For i = 0 To parameter_det.Rows.Count - 1
            url_det += parameter_det.Rows(i)("key").ToString + "=" + parameter_det.Rows(i)("value").ToString + "&"
        Next

        url_det = url_det.Substring(0, url_det.Length - 1)

        Dim request_det As Net.HttpWebRequest = Net.WebRequest.Create(url_det)

        request_det.Method = "GET"
        Dim response_det As Net.HttpWebResponse = request_det.GetResponse()
        Using dataStreamDet As IO.Stream = response_det.GetResponseStream()
            Dim reader_det As IO.StreamReader = New IO.StreamReader(dataStreamDet)

            Dim responseFromServerDet As String = reader_det.ReadToEnd()

            Dim json_det As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServerDet)
            If json_det("SuccessResponse")("Body")("OrderItems")("OrderItem").Count > 0 Then
                For Each row_det In json_det("SuccessResponse")("Body")("OrderItems")("OrderItem").ToList
                    Dim code9 As String = row_det("Sku").ToString.Substring(0, 9)
                    'dt.Rows.Add(row_det("ShopId").ToString, )
                Next
            End If
        End Using
        response_det.Close()
        Return dt
    End Function
End Class
