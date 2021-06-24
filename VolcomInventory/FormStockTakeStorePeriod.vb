Public Class FormStockTakeStorePeriod
    Private Sub FormStockTakeStorePeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub FormStockTakeStorePeriod_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormStockTakeStorePeriod_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStockTakeStorePeriod_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT p.id_st_store_period, DATE_FORMAT(p.soh_date, '%d %M %Y') AS soh_date, s.store_name, DATE_FORMAT(p.schedule_start, '%d %M %Y / %H:%i') AS schedule_start, DATE_FORMAT(p.schedule_end, '%d %M %Y / %H:%i') AS schedule_end
            FROM tb_st_store_period AS p
            LEFT JOIN tb_m_store AS s ON p.id_store = s.id_store
            ORDER BY p.id_st_store_period DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCPeriod.DataSource = data

        GVPeriod.BestFitColumns()
    End Sub

    Sub view_compare()
        Dim id_period As String = GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString

        Dim query As String = "
            (SELECT 0 AS `no`, p.full_code, p.name, p.size, s.qty AS qty_volcom, IFNULL(t.qty, 0) AS qty_store, (s.qty - IFNULL(t.qty, 0)) AS diff, '' AS note
            FROM tb_st_store_soh AS s
            LEFT JOIN (
                SELECT id_product, SUM(qty) AS qty
                FROM tb_st_store
                WHERE id_st_store_period = " + id_period + "
                GROUP BY id_product
            ) AS t ON s.id_product = t.id_product
            LEFT JOIN tb_m_product_store AS p ON s.id_product = p.id_product
            WHERE s.id_st_store_period = " + id_period + ")
        
            UNION ALL

            (SELECT 0 AS `no`, p.full_code, p.name, p.size, 0 AS qty_volcom, q.qty AS qty_store, -q.qty AS diff, '' AS note
            FROM tb_m_product_store AS p
            INNER JOIN (
                SELECT id_product, SUM(qty) AS qty
                FROM tb_st_store
                WHERE id_st_store_period = " + id_period + " AND id_product NOT IN (SELECT id_product FROM tb_st_store_soh WHERE id_st_store_period = " + id_period + ")
                GROUP BY id_product
            ) AS q ON q.id_product = p.id_product)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            data.Rows(i)("no") = i + 1

            Dim note As String = ""

            If data.Rows(i)("diff") < 0 Then
                note = "Over fisik"
            End If

            If data.Rows(i)("diff") > 0 Then
                note = "Selisih"
            End If

            data.Rows(i)("note") = note
        Next

        GCCompare.DataSource = data

        BGVCompare.BestFitColumns()
    End Sub

    Private Sub GVPeriod_DoubleClick(sender As Object, e As EventArgs) Handles GVPeriod.DoubleClick
        XtraTabControl.SelectedTabPageIndex = 1
    End Sub

    Private Sub SBSync_Click(sender As Object, e As EventArgs) Handles SBSync.Click
        FormMain.SplashScreenManager1.ShowWaitForm()

        Dim accessToken As String = FormStockTakeStorePeriodDet.getAccessToken()

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Authorization", accessToken)

        Dim volcomClientHost As String = get_setup_field("volcom_client_host")

        Dim url As String = volcomClientHost + "/api/sync/stocktake/out"

        Dim param As Specialized.NameValueCollection = New Specialized.NameValueCollection

        param.Add("id_period", GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString)

        Dim responseArray As Byte() = wc.UploadValues(url, "POST", param)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        Dim query As String = "INSERT IGNORE INTO tb_st_store (id_st_store, id_st_store_period, id_product, created_date, scanned_code, qty, note) VALUES "

        If json("status") = "success" Then
            Dim insert As Boolean = False

            For Each row In json("content").ToList
                Dim id_st_store As String = row("id_st_store").ToString
                Dim id_st_store_period As String = row("id_st_store_period").ToString
                Dim id_product As String = row("id_product").ToString
                Dim created_date As String = row("created_date").ToString
                Dim scanned_code As String = row("scanned_code").ToString
                Dim qty As String = row("qty").ToString
                Dim note As String = row("note").ToString

                query += "(" + id_st_store + ", " + id_st_store_period + ", " + id_product + ", '" + created_date + "', '" + scanned_code + "', " + qty + ", '" + addSlashes(note) + "'), "

                insert = True
            Next

            If insert Then
                query = query.Substring(0, query.Length - 2)

                execute_non_query(query, True, "", "", "", "")
            End If

            FormMain.SplashScreenManager1.CloseWaitForm()

            infoCustom("Sync Completed.")
        Else
            FormMain.SplashScreenManager1.CloseWaitForm()

            errorCustom("Sync Error.")
        End If

        view_compare()
    End Sub

    Private Sub XtraTabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl.SelectedPageChanged
        view_compare()
    End Sub
End Class