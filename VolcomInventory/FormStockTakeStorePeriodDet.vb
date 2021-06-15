Public Class FormStockTakeStorePeriodDet
    Public id_product As List(Of String) = New List(Of String)

    Private Sub FormStockTakeStorePeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_store()

        Dim lastDate As String = execute_query("SELECT DATE_SUB(CURDATE(), INTERVAL 1 DAY);", 0, True, "", "", "", "")

        DESOHDate.Properties.MaxValue = lastDate
        DESOHDate.EditValue = lastDate
        DEStart.EditValue = lastDate
        DEEnd.EditValue = lastDate
    End Sub

    Private Sub FormStockTakeStorePeriodDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormStockTakeStorePeriod.load_form()

        Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not id_product.Count = 0 Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            FormMain.SplashScreenManager1.SetWaitFormDescription("Save data...")

            Dim query As String = "INSERT INTO tb_st_store_period (soh_date, id_store, is_active, schedule_start, schedule_end) VALUES ('" + Date.Parse(DESOHDate.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', " + SLUEStore.EditValue.ToString + ", 1, '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "', '" + Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss") + "'); SELECT LAST_INSERT_ID();"

            Dim id_st_store_period As String = execute_query(query, 0, True, "", "", "", "")

            Dim query_product As String = "INSERT INTO tb_st_store_product (id_st_store_period, id_product) VALUES "

            For i = 0 To id_product.Count - 1
                query_product += "(" + id_st_store_period + ", " + id_product(i) + "), "
            Next

            query_product = query_product.Substring(0, query_product.Length - 2)

            execute_non_query(query_product, True, "", "", "", "")

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
            Dim j_st_store_period As String = tableToJson("tb_st_store_period", "SELECT id_st_store_period, soh_date, id_store, schedule_start, schedule_end, is_active FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_m_comp_cat As String = tableToJson("tb_m_comp_cat", "SELECT id_comp_cat, comp_cat_name, description FROM tb_m_comp_cat WHERE id_comp_cat IN (SELECT id_comp_cat FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_m_comp_group As String = tableToJson("tb_m_comp_group", "SELECT id_comp_group, comp_group, description FROM tb_m_comp_group WHERE id_comp_group IN (SELECT id_comp_group FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_m_comp As String = tableToJson("tb_m_comp", "SELECT id_comp, id_comp_cat, id_comp_group, id_store, id_store_type, comp_number, comp_name, comp_display_name FROM tb_m_comp WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")")
            Dim j_m_employee As String = tableToJson("tb_m_employee", "SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee IN (SELECT id_employee FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")))")
            Dim j_m_permission As String = tableToJson("tb_m_permission", "SELECT id_permission, permission FROM tb_m_permission")
            Dim j_m_product_store As String = tableToJson("tb_m_product_store", "SELECT id_product, full_code, `code`, `name`, size, class, color, unit_cost FROM tb_m_product_store")
            Dim j_m_role As String = tableToJson("tb_m_role", "SELECT id_role, role FROM tb_m_role WHERE id_role IN (SELECT id_role FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + ")))")
            Dim j_m_user As String = tableToJson("tb_m_user", "SELECT id_user, id_role, id_employee, id_store, username, password, name_external, position_external, is_external_user FROM tb_m_user WHERE id_user IN (SELECT value_id FROM tb_opt_include_st_store WHERE table_name = 'tb_m_user') OR id_user IN (SELECT id_user FROM tb_m_user WHERE id_store = (SELECT id_store FROM tb_st_store_period WHERE id_st_store_period = " + id_st_store_period + "))")
            Dim j_permission_role As String = tableToJson("tb_permission_role", "SELECT id_permission, id_role FROM tb_permission_role")
            Dim j_st_store_soh As String = tableToJson("tb_st_store_soh", "SELECT id_st_store_soh, id_st_store_period, id_comp, id_wh_drawer, id_product, qty, id_design_price_normal, design_price_normal, id_design_price, id_design_price_type, design_price FROM tb_st_store_soh WHERE id_st_store_period = " + id_st_store_period + "")
            Dim j_st_store_unique As String = tableToJson("tb_st_store_unique", "SELECT id_st_store_unique, id_st_store_period, id_product, id_comp, unique_code FROM tb_st_store_unique WHERE id_st_store_period = " + id_st_store_period + "")

            Dim out As String = "{" + j_m_store + "," + j_st_store_period + "," + j_m_comp_cat + "," + j_m_comp_group + "," + j_m_comp + "," + j_m_employee + "," + j_m_permission + "," + j_m_product_store + "," + j_m_role + "," + j_m_user + "," + j_permission_role + "," + j_st_store_soh + "," + j_st_store_unique + "}"

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

            Dim url As String = volcomClientHost + "/api/sync/stocktake"

            Dim wc As Net.WebClient = New Net.WebClient()

            wc.Headers.Add("Authorization", accessToken)

            Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

            Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

            FormMain.SplashScreenManager1.CloseWaitForm()

            If json("status") = "success" Then
                infoCustom("Save Completed.")
            End If

            Close()
        Else
            stopCustom("No SOH selected.")
        End If
    End Sub

    Sub view_store()
        Dim query As String = "SELECT id_store, store_name FROM tb_m_store"

        viewSearchLookupQuery(SLUEStore, query, "id_store", "store_name", "id_store")
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStore.EditValueChanged
        id_product.Clear()

        view_user()
    End Sub

    Sub view_user()
        Dim data As DataTable = execute_query("
            SELECT u.id_user, u.name_external, u.position_external, u.username, s.store_name
            FROM tb_m_user AS u
            LEFT JOIN tb_m_store AS s ON u.id_store = s.id_store
            WHERE u.is_external_user = 1 AND u.id_store = " + SLUEStore.EditValue.ToString + "
        ", -1, True, "", "", "", "")

        GCExternalUser.DataSource = data

        GVExternalUser.BestFitColumns()
    End Sub

    Private Sub SBAddUser_Click(sender As Object, e As EventArgs) Handles SBAddUser.Click
        FormExternalUserDet.id_store = SLUEStore.EditValue.ToString

        FormExternalUserDet.ShowDialog()

        view_user()
    End Sub

    Private Sub SBEditUser_Click(sender As Object, e As EventArgs) Handles SBEditUser.Click
        Try
            FormExternalUserDet.id_store = SLUEStore.EditValue.ToString
            FormExternalUserDet.id_user = GVExternalUser.GetFocusedRowCellValue("id_user").ToString

            FormExternalUserDet.ShowDialog()

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
End Class