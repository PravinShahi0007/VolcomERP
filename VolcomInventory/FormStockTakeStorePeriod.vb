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
            (SELECT 0 AS `no`, p.full_code, p.name, p.size, s.qty AS qty_volcom, IFNULL(t.qty, 0) AS qty_store, (s.qty - IFNULL(t.qty, 0)) AS diff, '' AS note, t.comp_name, t.is_auto, 'no' AS is_select, s.id_product
            FROM tb_st_store_soh AS s
            LEFT JOIN (
                SELECT s.id_product, SUM(s.qty) AS qty, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, s.is_auto
                FROM tb_st_store AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + "
                GROUP BY s.id_product
            ) AS t ON s.id_product = t.id_product
            LEFT JOIN tb_m_product_store AS p ON s.id_product = p.id_product
            WHERE s.id_st_store_period = " + id_period + ")
        
            UNION ALL

            (SELECT 0 AS `no`, p.full_code, p.name, p.size, 0 AS qty_volcom, q.qty AS qty_store, -q.qty AS diff, '' AS note, q.comp_name, q.is_auto, 'no' AS is_select, p.id_product
            FROM tb_m_product_store AS p
            INNER JOIN (
                SELECT s.id_product, SUM(s.qty) AS qty, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, s.is_auto
                FROM tb_st_store AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + " AND s.id_product NOT IN (SELECT id_product FROM tb_st_store_soh WHERE id_st_store_period = " + id_period + ")
                GROUP BY s.id_product
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

                'update account
                execute_non_query("
                    UPDATE tb_st_store AS s INNER JOIN (
	                    SELECT s.id_product, f.id_comp
	                    FROM tb_st_store AS s
	                    LEFT JOIN (
		                    SELECT id_product, COUNT(DISTINCT(id_comp)) AS count_comp, id_comp
		                    FROM tb_st_store_soh
		                    WHERE id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "
		                    GROUP BY id_product
	                    ) AS f ON s.id_product = f.id_product
	                    WHERE f.count_comp = 1 AND id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "
	                    GROUP BY id_product
                    ) AS f ON s.id_product = f.id_product
                    SET s.id_comp = f.id_comp, s.is_auto = 1
                ", True, "", "", "", "")
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

    Private Sub SBSelectAccount_Click(sender As Object, e As EventArgs) Handles SBSelectAccount.Click
        BGVCompare.ClearColumnsFilter()
        BGVCompare.ActiveFilterString = "[is_select] = 'yes'"

        If BGVCompare.RowCount > 0 Then
            Dim cnt As Boolean = True

            For i = 0 To BGVCompare.RowCount - 1
                If BGVCompare.IsValidRowHandle(i) Then
                    If BGVCompare.GetRowCellValue(i, "is_auto").ToString = "1" Then
                        cnt = False
                    End If
                End If
            Next

            If cnt Then
                FormStockTakeStorePeriodAccount.ShowDialog()
            Else
                stopCustom("Some product already have an account.")
            End If
        Else
            stopCustom("No product selected.")
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemCheckEdit.EditValueChanging
        If BGVCompare.GetFocusedRowCellValue("qty_store").ToString = "0" Or BGVCompare.GetFocusedRowCellValue("is_auto").ToString = "1" Then
            e.Cancel = True
        End If
    End Sub
End Class