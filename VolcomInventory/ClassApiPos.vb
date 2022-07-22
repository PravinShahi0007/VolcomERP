Public Class ClassApiPos
    Dim host As String = get_setup_field("volcom_api_pos_host")
    Dim email As String = get_setup_field("volcom_api_pos_email")
    Dim password As String = get_setup_field("volcom_api_pos_password")

    Function getAccessToken() As String
        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")

        Dim value As Specialized.NameValueCollection = New Specialized.NameValueCollection

        value.Add("email", email)
        value.Add("password", password)

        Dim response As Byte() = wc.UploadValues(host + "/api/login", "POST", value)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(System.Text.Encoding.ASCII.GetString(response))

        Return json("results")("type").ToString + " " + json("results")("access_token").ToString
    End Function

    Sub removeAccessToken(accessToken As String)
        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        wc.OpenRead(host + "/api/logout")
    End Sub

    Sub syncMaster()
        Dim j_tb_m_country As String = tableToJson("tb_m_country", "SELECT id_country, country, country_display_name FROM tb_m_country WHERE id_country IN (SELECT id_country FROM tb_m_region WHERE id_region IN (SELECT id_region FROM tb_m_state WHERE id_state IN (SELECT id_state FROM tb_m_city WHERE id_city IN (SELECT id_city FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> ''))))")
        Dim j_tb_m_region As String = tableToJson("tb_m_region", "SELECT id_region, id_country, region FROM tb_m_region WHERE id_region IN (SELECT id_region FROM tb_m_state WHERE id_state IN (SELECT id_state FROM tb_m_city WHERE id_city IN (SELECT id_city FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')))")
        Dim j_tb_m_state As String = tableToJson("tb_m_state", "SELECT id_state, id_region, state FROM tb_m_state WHERE id_state IN (SELECT id_state FROM tb_m_city WHERE id_city IN (SELECT id_city FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> ''))")
        Dim j_tb_m_comp_cat As String = tableToJson("tb_m_comp_cat", "SELECT id_comp_cat, comp_cat_name, description FROM tb_m_comp_cat WHERE id_comp_cat IN (SELECT id_comp_cat FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')")
        Dim j_tb_lookup_tax As String = tableToJson("tb_lookup_tax", "SELECT id_tax, tax FROM tb_lookup_tax WHERE id_tax IN (SELECT id_tax FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')")
        Dim j_tb_m_area As String = tableToJson("tb_m_area", "SELECT id_area, area FROM tb_m_area WHERE id_area IN (SELECT id_area FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')")
        Dim j_tb_m_comp_group As String = tableToJson("tb_m_comp_group", "SELECT id_comp_group, comp_group FROM tb_m_comp_group WHERE id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')")
        Dim j_tb_m_city As String = tableToJson("tb_m_city", "SELECT id_city, id_state, city FROM tb_m_city WHERE id_city IN (SELECT id_city FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> '')")
        Dim j_tb_outlet As String = tableToJson("tb_outlet", "SELECT id_outlet, outlet_name FROM tb_outlet")
        Dim j_tb_m_comp As String = tableToJson("tb_m_comp", "SELECT id_comp, id_comp_cat, comp_number, id_city, comp_name, comp_display_name, address_primary, address_other, fax, postal_code, email, website, id_tax, npwp, is_active, comp_commission, id_area, id_comp_group, id_outlet FROM tb_m_comp WHERE id_outlet IS NOT NULL AND id_outlet <> ''")
        Dim j_tb_pos_card_type As String = tableToJson("tb_pos_card_type", "SELECT id_card, card_name, discount FROM tb_pos_card_type")

        Dim out As String = "{" + j_tb_m_country + "," + j_tb_m_region + "," + j_tb_m_state + "," + j_tb_m_comp_cat + "," + j_tb_lookup_tax + "," + j_tb_m_area + "," + j_tb_m_comp_group + "," + j_tb_m_city + "," + j_tb_outlet + "," + j_tb_m_comp + "," + j_tb_pos_card_type + "}"

        Dim pathRoot As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(pathRoot) Then
            System.IO.Directory.CreateDirectory(pathRoot)
        End If

        Dim fileName As String = "sync-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json"
        Dim file As String = IO.Path.Combine(pathRoot, fileName)

        Dim fs As IO.FileStream = System.IO.File.Create(file)

        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(out)

        fs.Write(info, 0, info.Length)

        fs.Close()

        Dim accessToken As String = getAccessToken()

        Dim url As String = host + "/api/sync/master"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If json("success") Then
            infoCustom("Sync master completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncDeliverySlip(id_list As List(Of String))
        Dim in_id As String = ""

        For i = 0 To id_list.Count - 1
            in_id += id_list(i) + ", "
        Next

        in_id = in_id.Substring(0, in_id.Length - 2)

        Dim query As String = "
            SELECT d.id_pl_sales_order_del, a.pl_sales_order_del_number AS number, c_from.id_comp AS id_wh, c_to.id_comp AS id_store, a.pl_sales_order_del_date AS created_date, a.last_update AS approved_date, d.id_product, p.id_design, d_count.id_pl_prod_order_rec_det_unique, class.id_class, class.class, class.class_display, color.id_color, color.color, color.color_display, p_code.id_code_detail AS id_size, p_detail.display_name AS size, sub_category.id_sub_category, sub_category.sub_category, p.product_full_code AS item_code, p.product_full_code AS item_code_group, CONCAT(IF(r.is_md = 2, 'PRM ', ''), class.class_display, ' ', g.design_name, ' ', color.color_display) AS item_name, 1 AS qty, p_type.id_design_cat, d.id_design_price, d.design_price AS price, d_price.design_price_start_date AS design_price_date, pn.id_design_price AS id_normal_price, pn.design_price AS normal_price, a.is_combine, a.id_combine, 2 AS is_unique_code, IF(r.is_md = 2, 1, 2) AS is_free_promo
            FROM tb_pl_sales_order_del_det AS d
            LEFT JOIN tb_pl_sales_order_del AS a ON d.id_pl_sales_order_del = a.id_pl_sales_order_del
            LEFT JOIN tb_m_comp_contact AS c_from ON a.id_comp_contact_from = c_from.id_comp_contact
            LEFT JOIN tb_m_comp_contact AS c_to ON a.id_store_contact_to = c_to.id_comp_contact
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_m_design AS g ON p.id_design = g.id_design
            LEFT JOIN tb_season AS e ON g.id_season = e.id_season
            LEFT JOIN tb_range AS r ON e.id_range = r.id_range
            LEFT JOIN tb_pl_sales_order_del_det_counting AS d_count ON d.id_pl_sales_order_del_det = d_count.id_pl_sales_order_del_det
            LEFT JOIN (
                SELECT dc.id_design, dc.id_code_detail AS id_class, cd.display_name AS class_display, cd.code_detail_name AS class
                FROM tb_m_design_code AS dc
                LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
                WHERE cd.id_code = 30
                GROUP BY dc.id_design
            ) AS class ON class.id_design = p.id_design
            LEFT JOIN (
                SELECT dc.id_design, dc.id_code_detail AS id_color, cd.display_name AS color_display, cd.code_detail_name AS color
                FROM tb_m_design_code AS dc
                LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
                WHERE cd.id_code = 14
                GROUP BY dc.id_design
            ) color ON color.id_design = p.id_design
            LEFT JOIN (
                SELECT dc.id_design, dc.id_code_detail AS id_sub_category, cd.code AS sub_category
                FROM tb_m_design_code AS dc
                LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
                WHERE cd.id_code = 31
                GROUP BY dc.id_design
            ) sub_category ON sub_category.id_design = p.id_design
            LEFT JOIN (
                SELECT id_design, id_design_price, ROUND(design_price) AS design_price
                FROM tb_m_design_price
                WHERE id_design_price IN (
                    SELECT MAX(id_design_price) AS id_design_price
                    FROM tb_m_design_price
                    WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                    GROUP BY id_design
                )
            ) AS pn ON p.id_design = pn.id_design
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

        Dim url As String = host + "/api/sync/delivery-slip"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync delivery slip completed.")
        End If

        removeAccessToken(accessToken)

        syncCombineDeliverySlip(id_list)
    End Sub

    Sub syncCombineDeliverySlip(id_list As List(Of String))
        Dim in_id As String = ""

        For i = 0 To id_list.Count - 1
            in_id += id_list(i) + ", "
        Next

        in_id = in_id.Substring(0, in_id.Length - 2)

        Dim query As String = "
            SELECT c.id_combine, c.combine_number AS number, c_from.id_comp AS id_wh, c_to.id_comp AS id_store, c.combine_date AS created_date, c.last_update AS approved_date
            FROM tb_pl_sales_order_del_combine AS c
            LEFT JOIN tb_m_comp_contact AS c_from ON c.id_comp_contact_from = c_from.id_comp_contact
            LEFT JOIN tb_m_comp_contact AS c_to ON c.id_store_contact_to = c_to.id_comp_contact
            WHERE c.id_combine IN (SELECT id_combine FROM tb_pl_sales_order_del WHERE is_combine = 1 AND id_pl_sales_order_del IN (" + in_id + "))
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
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

            Dim url As String = host + "/api/sync/combine-delivery-slip"

            Dim wc As Net.WebClient = New Net.WebClient()

            wc.Headers.Add("Accept", "application/json")
            wc.Headers.Add("Authorization", accessToken)

            Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

            Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

            Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

            If jsonRes("success") Then
                'infoCustom("Sync combine delivery slip completed.")
            End If

            removeAccessToken(accessToken)
        End If
    End Sub

    Sub syncReturnOrder(id_list As List(Of String))
        Dim in_id As String = ""

        For i = 0 To id_list.Count - 1
            in_id += id_list(i) + ", "
        Next

        in_id = in_id.Substring(0, in_id.Length - 2)

        Dim query As String = "
            SELECT d.id_sales_return_order, s.sales_return_order_number AS `number`, t.id_comp AS id_store, s.sales_return_order_date AS created_date, s.final_date AS approve_date, d.id_product, p.id_design, l.id_class, c.id_color, o.id_code_detail AS id_size, p.product_full_code AS item_code, p.product_full_code AS item_code_group, CONCAT(IF(r.is_md = 2, 'PRM ', ''), s.class_display, ' ', g.design_name, ' ', c.color_display) AS item_name, d.sales_return_order_det_qty AS qty, l.id_design_cat, d.id_design_price, d.design_price AS price, 2 AS is_combine, 2 AS is_unique_code
            FROM tb_sales_return_order_det AS d
            LEFT JOIN tb_sales_return_order AS s ON d.id_sales_return_order = s.id_sales_return_order
            LEFT JOIN tb_m_comp_contact AS t ON s.id_store_contact_to = t.id_comp_contact
            LEFT JOIN tb_m_product AS p ON d.id_product = p.id_product
            LEFT JOIN tb_m_design AS g ON p.id_design = g.id_design
            LEFT JOIN tb_season AS e ON g.id_season = e.id_season
            LEFT JOIN tb_range AS r ON e.id_range = r.id_range
            LEFT JOIN tb_m_product_code AS o ON d.id_product = o.id_product
            LEFT JOIN (
                SELECT d.id_design, d.id_code_detail AS id_color, c.display_name AS color_display
                FROM tb_m_design_code AS d
                LEFT JOIN tb_m_code_detail AS c ON c.id_code_detail = d.id_code_detail 
                WHERE c.id_code = 14
                GROUP BY d.id_design
            ) c ON c.id_design = p.id_design
            LEFT JOIN (
                SELECT d.id_design, d.id_code_detail AS id_class
                FROM tb_m_design_code AS d
                LEFT JOIN tb_m_code_detail AS c ON c.id_code_detail = d.id_code_detail 
                WHERE c.id_code = 30
                GROUP BY d.id_design
            ) l ON l.id_design = p.id_design
            LEFT JOIN (
                SELECT dc.id_design, dc.id_code_detail AS id_class, cd.display_name AS class_display
                FROM tb_m_design_code AS dc
                LEFT JOIN tb_m_code_detail AS cd ON cd.id_code_detail = dc.id_code_detail 
                WHERE cd.id_code = 30
                GROUP BY dc.id_design
            ) AS s ON s.id_design = p.id_design
            LEFT JOIN tb_m_design_price AS i ON i.id_design_price = d.id_design_price
            LEFT JOIN tb_lookup_design_price_type AS l ON l.id_design_price_type = i.id_design_price_type
            WHERE d.id_sales_return_order IN (" + in_id + ")
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

        Dim url As String = host + "/api/sync/return-order"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync return order completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncDesignPrice(id_list As List(Of String), effective_date As String)
        Dim in_id As String = ""

        For i = 0 To id_list.Count - 1
            in_id += id_list(i) + ", "
        Next

        in_id = in_id.Substring(0, in_id.Length - 2)

        Dim query As String = "
            SELECT id_design_price, id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, is_active_wh, id_user, id_fg_propose_price, is_design_cost
            FROM tb_m_design_price
            WHERE id_design IN (" + in_id + ") AND design_price_start_date = '" + effective_date + "'
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

        Dim url As String = host + "/api/sync/design-price"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync design price completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncEmployeeUser()
        Dim j_tb_pos_role As String = tableToJson("tb_pos_role", "SELECT id_pos_role, role FROM tb_pos_role")
        Dim j_tb_m_employee As String = tableToJson("tb_m_employee", "
            SELECT e.id_employee, e.id_sex, e.id_departement, e.id_departement_sub, e.id_blood_type, e.id_religion, e.id_country, e.id_education, e.id_employee_status, e.start_period, e.end_period, e.id_employee_active, e.employee_code, e.employee_name, e.employee_nick_name, e.employee_initial_name, e.employee_pob, e.employee_dob, e.employee_ethnic, e.employee_join_date, e.employee_last_date, e.employee_position, e.id_employee_level, e.email_lokal, e.email_lokal_pass, e.email_external, e.email_external_pass, e.email_other, e.email_other_pass, e.phone, e.phone_mobile, e.phone_ext, e.employee_ktp, e.employee_ktp_period, e.employee_passport, e.employee_passport_period, e.employee_bpjs_tk, e.employee_bpjs_tk_date, e.employee_bpjs_kesehatan, e.employee_bpjs_kesehatan_date, e.employee_npwp, e.address_primary, e.address_additional, e.id_marriage_status, e.husband, e.wife, e.child1, e.child2, e.child3, NULL AS basic_salary, NULL AS allow_job, NULL AS allow_meal, NULL AS allow_trans, NULL AS allow_house, NULL AS allow_car, d.id_outlet
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement_sub AS d ON e.id_departement_sub = d.id_departement_sub
            WHERE (d.id_outlet <> '' OR d.id_outlet IS NOT NULL) AND e.id_employee_active = 1 OR e.id_employee IN (169, 168, 506)

        ")
        Dim j_tb_pos_user As String = tableToJson("tb_pos_user", "SELECT id_pos_user, id_employee, id_pos_role, username, password, is_change FROM tb_pos_user")

        Dim out As String = "{" + j_tb_pos_role + "," + j_tb_m_employee + "," + j_tb_pos_user + "}"

        Dim pathRoot As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(pathRoot) Then
            System.IO.Directory.CreateDirectory(pathRoot)
        End If

        Dim fileName As String = "sync-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json"
        Dim file As String = IO.Path.Combine(pathRoot, fileName)

        Dim fs As IO.FileStream = System.IO.File.Create(file)

        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(out)

        fs.Write(info, 0, info.Length)

        fs.Close()

        Dim accessToken As String = getAccessToken()

        Dim url As String = host + "/api/sync/user"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If json("success") Then
            infoCustom("Sync user completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Function tableToJson(table As String, query As String) As String
        Dim out As String = """" + table + """:"

        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")

        out += Newtonsoft.Json.JsonConvert.SerializeObject(data)

        Return out
    End Function

    Sub syncSale(sale_date As String)
        Dim accessToken As String = getAccessToken()

        Dim url As String = host + "/api/sync/sale/" + sale_date

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseString As String = wc.DownloadString(url)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        For Each head In json("results")
            Dim query_head As String = "
                INSERT INTO tb_pos_sale (id_pos, id_outlet, id_pos_ref, pos_number, pos_date, pos_closed_date, id_shift, shift_type, id_user_employee, id_user_employee_cancel, id_pos_status, id_pos_cat, note, subtotal, discount, tax, total, id_voucher, voucher_number, voucher, `point`, cash, `card`, id_card_type, card_number, card_name, `change`, total_qty, id_sales, id_nation, is_payment_ok, is_closed, closed_date, closed_by, is_get_promo) VALUES ('" + head("id_pos").ToString() + "', '" + head("id_outlet").ToString() + "', " + If(head("id_pos_ref").ToString() = "", "NULL", "'" + head("id_pos_ref").ToString() + "'") + ", '" + head("pos_number").ToString() + "', '" + head("pos_date").ToString() + "', '" + head("pos_closed_date").ToString() + "', '" + head("id_shift").ToString() + "', '" + head("shift_type").ToString() + "', '" + head("id_user_employee").ToString() + "', " + If(head("id_user_employee_cancel").ToString() = "", "NULL", "'" + head("id_user_employee_cancel").ToString() + "'") + ", '" + head("id_pos_status").ToString() + "', '" + head("id_pos_cat").ToString() + "', '" + head("note").ToString() + "', '" + head("subtotal").ToString() + "', '" + head("discount").ToString() + "', '" + head("tax").ToString() + "', '" + head("total").ToString() + "', " + If(head("id_voucher").ToString() = "", "NULL", "'" + head("id_voucher").ToString() + "'") + ", '" + head("voucher_number").ToString() + "', '" + head("voucher").ToString() + "', '" + head("point").ToString() + "', '" + head("cash").ToString() + "', '" + head("card").ToString() + "', '" + head("id_card_type").ToString() + "', '" + head("card_number").ToString() + "', '" + head("card_name").ToString() + "', '" + head("change").ToString() + "', '" + head("total_qty").ToString() + "', '" + head("id_sales").ToString() + "', '" + head("id_nation").ToString() + "', '" + head("is_payment_ok").ToString() + "', '" + head("is_closed").ToString() + "', " + If(head("closed_date").ToString() = "", "NULL", "'" + head("closed_date").ToString() + "'") + ", " + If(head("closed_by").ToString() = "", "NULL", "'" + head("closed_by").ToString() + "'") + ", '" + head("is_get_promo").ToString() + "'); SELECT LAST_INSERT_ID();
            "

            Dim id_pos_sale As String = execute_query(query_head, 0, True, "", "", "", "")

            For Each detail In head("details")
                Dim query_detail As String = "
                    INSERT INTO tb_pos_sale_det (id_pos_sale, id_pos_det, id_pos, id_item, item_code, id_product, id_comp_sup, comm, qty, price, id_design_cat, is_free_promo, revise_reason, id_user_revise) VALUES ('" + id_pos_sale + "', '" + detail("id_pos_det").ToString() + "', '" + detail("id_pos").ToString() + "', '" + detail("id_item").ToString() + "', '" + detail("item_code").ToString() + "', '" + detail("id_product").ToString() + "', '" + detail("id_comp_sup").ToString() + "', '" + detail("comm").ToString() + "', '" + detail("qty").ToString() + "', '" + detail("price").ToString() + "', '" + detail("id_design_cat").ToString() + "', '" + detail("is_free_promo").ToString() + "', '" + detail("revise_reason").ToString() + "', " + If(detail("id_user_revise").ToString() = "", "NULL", "'" + detail("id_user_revise").ToString() + "'") + ")
                "

                execute_non_query(query_detail, True, "", "", "", "")
            Next
        Next
    End Sub

    Sub syncVoucher(id_voucher As String)
        Dim query As String = "
            SELECT id_voucher_pps, voucher_number, voucher_value, voucher_name, voucher_address, period_start, period_end, id_outlet AS outlet_id
            FROM tb_pos_voucher_pps_det
            WHERE id_voucher_pps = " + id_voucher + " AND is_active = 1
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

        Dim url As String = host + "/api/sync/voucher"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync voucher completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncGWP(id_rules As String)
        Dim query As String = "
            SELECT r.id_rules, r.id_design_price_type, r.report_number, r.limit_value, r.id_product, r.product_code, r.product_name, r.period_start, r.period_end, d.id_outlet AS outlet_id
            FROM tb_promo_rules_det AS d
            LEFT JOIN tb_promo_rules AS r ON d.id_rules = r.id_rules
            WHERE d.id_rules = " + id_rules + "
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

        Dim url As String = host + "/api/sync/rule"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync gwp completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncCard()
        Dim query As String = "
            SELECT id_card, card_name, discount
            FROM tb_pos_card_type
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

        Dim url As String = host + "/api/sync/card"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync card completed.")
        End If

        removeAccessToken(accessToken)
    End Sub

    Sub syncCloseGWP(id_close_promo_rules As String)
        Dim query As String = "
            SELECT r.id_rules, d.id_outlet AS outlet_id
            FROM tb_close_promo_rules_det AS d
            LEFT JOIN tb_close_promo_rules AS r ON d.id_close_promo_rules = r.id_close_promo_rules
            WHERE d.id_close_promo_rules = " + id_close_promo_rules + "
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

        Dim url As String = host + "/api/sync/close-rule"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Accept", "application/json")
        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim jsonRes As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        If jsonRes("success") Then
            'infoCustom("Sync close gwp completed.")
        End If

        removeAccessToken(accessToken)
    End Sub
End Class
