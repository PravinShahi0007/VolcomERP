Public Class FormStockTakeStorePeriodDet
    Public id_design As List(Of String) = New List(Of String)
    Public id_store As List(Of String) = New List(Of String)

    Private Sub FormStockTakeStorePeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nowDate As String = execute_query("SELECT DATE_SUB(CURDATE(), INTERVAL 0 DAY);", 0, True, "", "", "", "")

        DEStart.Properties.MinValue = nowDate
        DESOHDate.Properties.MaxValue = nowDate
        DESOHDate.EditValue = nowDate
        DEStart.EditValue = nowDate
        DEEnd.EditValue = DateTime.Parse(nowDate).AddMinutes(1439)

        CEAll.EditValue = True

        SEGenerateUser.EditValue = 2
    End Sub

    Private Sub FormStockTakeStorePeriodDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormStockTakeStorePeriod.load_form()

        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not CEAll.EditValue And id_design.Count = 0 Then
            stopCustom("No product selected.")

            Exit Sub
        End If

        If id_store.Count = 0 Then
            stopCustom("Please select store.")

            Exit Sub
        End If

        If GVExternalUser.RowCount = 0 Then
            stopCustom("Please generate user.")

            Exit Sub
        End If

        FormMain.SplashScreenManager1.ShowWaitForm()

        FormMain.SplashScreenManager1.SetWaitFormDescription("Save data...")

        Dim is_all_design As String = ""

        If CEAll.EditValue Then
            is_all_design = "1"
        Else
            is_all_design = "2"
        End If

        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        For x = 0 To id_store.Count - 1
            Dim query_sales_date As String = "
                SELECT MAX(DATE_FORMAT(sp.sales_pos_end_period, '%Y-%m-%d')) AS sales_date
                FROM tb_sales_pos AS sp
                LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = IF(sp.id_memo_type = 8 OR sp.id_memo_type = 9, sp.id_comp_contact_bill, sp.id_store_contact_from)
                WHERE id_report_status = 6 AND sales_pos_end_period <= '" + Date.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND cc.id_comp IN (SELECT id_comp FROM tb_m_comp WHERE id_store IN (" + id_store(x) + "))
            "

            Dim data_sales_date As String = ""

            Try
                data_sales_date = execute_query(query_sales_date, 0, True, "", "", "", "")
            Catch ex As Exception
            End Try

            If data_sales_date = "" Then
                data_sales_date = "NULL"
            Else
                data_sales_date = "'" + data_sales_date + "'"
            End If

            Dim query As String = "INSERT INTO tb_st_store_period (soh_date, id_store, is_active, schedule_start, schedule_end, sales_date, is_all_design) VALUES ('" + DateTime.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', " + id_store(x) + ", 1, '" + DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', " + data_sales_date + ", " + is_all_design + "); SELECT LAST_INSERT_ID();"

            Dim id_st_store_period As String = execute_query(query, 0, True, "", "", "", "")

            If is_all_design = "2" Then
                Dim in_id_design As String = "0"

                For i = 0 To id_design.Count - 1
                    in_id_design += ", " + id_design(i)
                Next

                Dim query_product As String = "
                    INSERT INTO tb_st_store_product (id_st_store_period, id_product)
                    SELECT " + id_st_store_period + " AS id_st_store_period, id_product
                    FROM tb_m_product
                    WHERE id_design IN (" + in_id_design + ")
                "

                execute_non_query(query_product, True, "", "", "", "")
            End If

            FormMain.SplashScreenManager1.SetWaitFormDescription("Generate table...")

            execute_non_query_long_time("CALL generate_st_store('" + id_st_store_period + "')", True, "", "", "", "")
            execute_non_query_long_time("CALL generate_st_unique_store('" + id_st_store_period + "')", True, "", "", "", "")

            'create json file
            FormMain.SplashScreenManager1.SetWaitFormDescription("Generate file...")

            Dim pathRoot As String = Application.StartupPath + "\download\"

            If Not IO.Directory.Exists(pathRoot) Then
                System.IO.Directory.CreateDirectory(pathRoot)
            End If

            Dim fileName As String = "sync-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json"
            Dim file As String = IO.Path.Combine(pathRoot, fileName)

            execute_non_query_long_time("CALL generate_product_store()", True, "", "", "", "")

            Dim j_m_store As String = tableToJson("tb_m_store", "SELECT id_store, store_name FROM tb_m_store WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")")
            Dim j_st_store_period As String = tableToJson("tb_st_store_period", "SELECT id_st_store_period, soh_date, id_store, schedule_start, schedule_end, sales_date, is_all_design, is_active FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_m_comp_cat As String = tableToJson("tb_m_comp_cat", "SELECT id_comp_cat, comp_cat_name, description FROM tb_m_comp_cat WHERE id_comp_cat IN (SELECT id_comp_cat FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_m_comp_group As String = tableToJson("tb_m_comp_group", "SELECT id_comp_group, comp_group, description FROM tb_m_comp_group WHERE id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_m_comp As String = tableToJson("tb_m_comp", "SELECT id_comp, id_comp_cat, id_comp_group, id_store, id_store_type, comp_number, comp_name, comp_display_name, address_primary FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")")
            Dim j_m_employee As String = tableToJson("tb_m_employee", "SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee IN (SELECT id_employee FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")))")
            Dim j_m_permission As String = tableToJson("tb_m_permission", "SELECT id_permission, permission FROM tb_m_permission")
            Dim j_m_product_store As String = tableToJson("tb_m_product_store", "SELECT id_product, id_design, full_code, `code`, `name`, size, class, color, unit_cost, is_old_design FROM tb_m_product_store")
            Dim j_m_role As String = tableToJson("tb_m_role", "SELECT id_role, role FROM tb_m_role WHERE id_role IN (SELECT id_role FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")))")
            Dim j_m_user As String = tableToJson("tb_m_user", "SELECT id_user, id_role, id_employee, id_store, username, password, is_change, name_external, position_external, email_external, is_external_user FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_permission_role As String = tableToJson("tb_permission_role", "SELECT id_permission, id_role FROM tb_permission_role")
            Dim j_st_store_soh As String = tableToJson("tb_st_store_soh", "SELECT id_st_store_soh, id_st_store_period, id_comp, id_wh_drawer, id_product, qty, id_design_price_normal, design_price_normal, id_design_price, id_design_price_type, design_price FROM tb_st_store_soh WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_st_store_unique As String = tableToJson("tb_st_store_unique", "SELECT id_st_store_unique, id_st_store_period, id_product, id_comp, unique_code FROM tb_st_store_unique WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_st_store_product As String = tableToJson("tb_st_store_product", "SELECT id_st_store_product, id_st_store_period, id_product FROM tb_st_store_product WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_tb_m_design_price As String = tableToJson("tb_m_design_price", "SELECT id_design_price, id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print FROM tb_m_design_price")

            Dim out As String = "{" + j_m_store + "," + j_st_store_period + "," + j_m_comp_cat + "," + j_m_comp_group + "," + j_m_comp + "," + j_m_employee + "," + j_m_permission + "," + j_m_product_store + "," + j_m_role + "," + j_m_user + "," + j_permission_role + "," + j_st_store_soh + "," + j_st_store_unique + "," + j_st_store_product + "," + j_tb_m_design_price + "}"

            Dim fs As IO.FileStream = System.IO.File.Create(file)

            Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(out)

            fs.Write(info, 0, info.Length)

            fs.Close()

            'upload file
            FormMain.SplashScreenManager1.SetWaitFormDescription("Upload file...")

            Dim volcomClientHost As String = get_setup_field("volcom_client_host")
            Dim volcomClientUsername As String = get_setup_field("volcom_client_username")
            Dim volcomClientPassword As String = get_setup_field("volcom_client_password")

            Dim accessToken As String = getAccessToken()

            Dim url As String = volcomClientHost + "/api/sync/stocktake/in"

            Dim wc As Net.WebClient = New Net.WebClient()

            wc.Headers.Add("Authorization", accessToken)

            Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

            Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)
        Next

        FormMain.SplashScreenManager1.CloseWaitForm()

        infoCustom("Save Completed.")

        Close()
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs)
        view_user()

        Dim schedule_end As String = execute_query("SELECT IFNULL(DATE_ADD(MAX(DATE(schedule_end)), INTERVAL 1 DAY), DATE_SUB(CURDATE(), INTERVAL 0 DAY)) AS schedule_end FROM tb_st_store_period WHERE id_store = ", 0, True, "", "", "", "")

        DEStart.Properties.MinValue = schedule_end
    End Sub

    Sub view_user()
        Dim in_id_store As String = "0"

        For i = 0 To id_store.Count - 1
            in_id_store += ", " + id_store(i)
        Next

        Dim data As DataTable = execute_query("
            SELECT u.id_user, u.name_external, u.position_external, u.username, s.store_name
            FROM tb_m_user AS u
            LEFT JOIN tb_m_store AS s ON u.id_store = s.id_store
            WHERE u.is_external_user = 1 AND u.id_store IN (" + in_id_store + ")
        ", -1, True, "", "", "", "")

        GCExternalUser.DataSource = data

        GVExternalUser.BestFitColumns()
    End Sub

    Private Sub SBAddUser_Click(sender As Object, e As EventArgs) Handles SBAddUser.Click
        Dim in_store As String = "0"

        For i = 0 To id_store.Count - 1
            in_store += ", " + id_store(i)
        Next

        If in_store = "0" Then
            stopCustom("Please select store first.")
        Else
            FormExternalUserDet.id_store = in_store

            FormExternalUserDet.ShowDialog()
        End If

        view_user()
    End Sub

    Private Sub SBEditUser_Click(sender As Object, e As EventArgs) Handles SBEditUser.Click
        Try
            Dim in_store As String = "0"

            For i = 0 To id_store.Count - 1
                in_store += ", " + id_store(i)
            Next

            If in_store = "0" Then
                stopCustom("Please select store first.")
            Else
                FormExternalUserDet.id_store = in_store
                FormExternalUserDet.id_user = GVExternalUser.GetFocusedRowCellValue("id_user").ToString

                FormExternalUserDet.ShowDialog()
            End If

            view_user()
        Catch ex As Exception
        End Try
    End Sub

    Function tableToJson(table As String, query As String) As String
        Dim out As String = """" + table + """:"

        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")

        out += Newtonsoft.Json.JsonConvert.SerializeObject(data)

        Return out
    End Function

    Function getAccessToken() As String
        Dim volcomClientHost As String = get_setup_field("volcom_client_host")
        Dim volcomClientUsername As String = get_setup_field("volcom_client_username")
        Dim volcomClientPassword As String = get_setup_field("volcom_client_password")

        'get access token
        Dim request As Net.WebRequest = Net.WebRequest.Create(volcomClientHost + "/api/getAccessToken")

        request.Method = "POST"

        Dim postData As String = "username=" + volcomClientUsername + "&password=" + volcomClientPassword

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

            access_token = json("content")("token_type").ToString + " " + json("content")("access_token").ToString
        End Using

        response.Close()

        Return access_token
    End Function

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEEnd.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub SBSOH_Click(sender As Object, e As EventArgs) Handles SBSOH.Click
        FormStockTakePeriodSOH.ShowDialog()
    End Sub

    Private Sub CEAll_CheckedChanged(sender As Object, e As EventArgs) Handles CEAll.CheckedChanged
        If CEAll.EditValue Then
            SBSOH.Enabled = False

            id_design.Clear()
        Else
            SBSOH.Enabled = True
        End If
    End Sub

    Private Sub SBSelectStore_Click(sender As Object, e As EventArgs) Handles SBSelectStore.Click
        FormStockTakeStorePeriodStore.ShowDialog()
    End Sub

    Sub min_start_date()
        Dim in_store As String = "0"

        For i = 0 To id_store.Count - 1
            in_store += ", " + id_store(i)
        Next

        Dim schedule_end As String = execute_query("SELECT IFNULL(DATE_ADD(MAX(DATE(schedule_end)), INTERVAL 1 DAY), DATE_SUB(CURDATE(), INTERVAL 0 DAY)) AS schedule_end FROM tb_st_store_period WHERE id_store IN (" + in_store + ")", 0, True, "", "", "", "")

        DEStart.Properties.MinValue = schedule_end
    End Sub

    Private Sub SBGenerateUser_Click(sender As Object, e As EventArgs) Handles SBGenerateUser.Click
        If id_store.Count = 0 Then
            stopCustom("Please select store.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate user ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                For i = 0 To id_store.Count - 1
                    For j = 1 To SEGenerateUser.EditValue
                        Dim store_name As String = execute_query("SELECT LOWER(REPLACE(store_name, ' ', '')) FROM tb_m_store WHERE id_store = " + id_store(i), 0, True, "", "", "", "")
                        Dim x As String = execute_query("SELECT LPAD(IFNULL((SELECT COUNT(*) + 1 FROM tb_m_user WHERE id_store = " + id_store(i) + " GROUP BY id_store), 1), 3, '0')", 0, True, "", "", "", "")

                        Dim id_role As String = "119"
                        Dim username As String = store_name + x.ToString
                        Dim password As String = store_name + x.ToString
                        Dim name_external As String = ""
                        Dim position_external As String = ""
                        Dim is_external_user As String = "1"
                        Dim is_change As String = "1"

                        Dim query As String = "INSERT INTO tb_m_user (id_role, username, password, name_external, position_external, is_external_user, id_store, is_change) VALUES (" + id_role + ", '" + addSlashes(username) + "', MD5('" + addSlashes(password) + "'), '" + addSlashes(name_external) + "', '" + addSlashes(position_external) + "', " + is_external_user + ", '" + id_store(i) + "', '" + is_change + "'); SELECT LAST_INSERT_ID();"

                        Dim id_user As String = execute_query(query, 0, True, "", "", "", "")

                        execute_non_query("INSERT INTO tb_st_user (id_user, role) VALUES ('" + id_user + "', '5')", True, "", "", "", "")
                    Next
                Next

                view_user()

                infoCustom("User created.")
            End If
        End If
    End Sub
End Class