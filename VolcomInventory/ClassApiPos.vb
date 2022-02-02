Public Class ClassApiPos
    Dim host As String = get_setup_field("volcom_api_pos_host")
    Dim email As String = get_setup_field("volcom_api_pos_email")
    Dim password As String = get_setup_field("volcom_api_pos_password")

    Function getAccessToken() As String
        Dim request As Net.WebRequest = Net.WebRequest.Create(host + "/api/access-token")

        request.Method = "POST"

        Dim postData As String = "email=" + email + "&password=" + password

        Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)

        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length

        Dim dataStream As IO.Stream = request.GetRequestStream()

        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As Net.WebResponse = request.GetResponse()

        Dim access_token As String = ""

        Using stream As IO.Stream = response.GetResponseStream()
            Dim reader As IO.StreamReader = New IO.StreamReader(stream)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseFromServer)

            If json("success") Then
                access_token = json("results")("access_token").ToString
            End If
        End Using

        response.Close()

        Return access_token
    End Function

    Sub syncDeliverySlip(id_list As List(Of String))
        Dim in_id As String = ""

        For i = 0 To id_list.Count - 1
            in_id += id_list(i) + ", "
        Next

        in_id = in_id.Substring(0, in_id.Length - 2)

        Dim query As String = "
            SELECT d.id_pl_sales_order_del, a.pl_sales_order_del_number AS number, c_from.id_comp AS id_wh, c_to.id_comp AS id_store, a.pl_sales_order_del_date AS created_date, a.last_update AS approved_date, d.id_product, p.id_design, d_count.id_pl_prod_order_rec_det_unique, class.id_class, class.class, class.class_display, color.id_color, color.color, color.color_display, p_code.id_code_detail AS id_size, p_detail.display_name AS size, p.product_code AS item_code, p.product_code AS item_code_group, p.product_display_name AS item_name, d.pl_sales_order_del_det_qty AS qty, p_type.id_design_cat, d.id_design_price, d.design_price AS price, 2 AS is_combine, 2 AS is_unique_code
            FROM tb_pl_sales_order_del_det AS d
            LEFT JOIN tb_pl_sales_order_del AS a ON d.id_pl_sales_order_del = a.id_pl_sales_order_del
            LEFT JOIN tb_m_comp_contact AS c_from ON a.id_comp_contact_from = c_from.id_comp_contact
            LEFT JOIN tb_m_comp_contact AS c_to ON a.id_store_contact_to = c_to.id_comp_contact
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_pl_sales_order_del_det_counting AS d_count ON d.id_pl_sales_order_del_det = d_count.id_pl_sales_order_del_det
            LEFT JOIN (
	            SELECT dc.id_design, dc.id_code_detail AS id_class, cd.display_name AS class_display, cd.code_detail_name AS class
	            FROM tb_m_design_code AS dc
	            LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
	            WHERE cd.id_code = 30
	            GROUP BY dc.id_design
            ) AS class ON class.id_design = p.id_design
            INNER JOIN (
	            SELECT dc.id_design, dc.id_code_detail AS id_color, cd.display_name AS color_display, cd.code_detail_name AS color
	            FROM tb_m_design_code AS dc
	            LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
	            WHERE cd.id_code = 14
	            GROUP BY dc.id_design
            ) color ON color.id_design = p.id_design
            LEFT JOIN tb_m_product_code AS p_code ON p.id_product = p_code.id_product
            LEFT JOIN tb_m_code_detail AS p_detail ON p_code.id_code_detail = p_detail.id_code_detail
            LEFT JOIN tb_m_design_price AS d_price ON d.id_design_price = d_price.id_design_price
            LEFT JOIN tb_lookup_design_price_type AS p_type ON d_price.id_design_price_type = p_type.id_design_price_type
            WHERE d.id_pl_sales_order_del IN (" + in_id + ")
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(data)

        Dim pathRoot As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(pathRoot) Then
            System.IO.Directory.CreateDirectory(pathRoot)
        End If

        Dim fileName As String = "sync-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json"
        Dim file As String = IO.Path.Combine(pathRoot, fileName)

        Dim fs As IO.FileStream = System.IO.File.Create(file)

        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(json)

        fs.Write(info, 0, info.Length)

        fs.Close()

        Dim accessToken As String = getAccessToken()

        Dim url As String = host + "/api/delivery-slip"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", "Bearer " + accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)
    End Sub
End Class
