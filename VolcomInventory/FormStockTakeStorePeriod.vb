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
            (SELECT 0 AS `no`, p.full_code, p.name, p.size, s.qty AS qty_volcom, IFNULL(t.qty, 0) AS qty_store, (s.qty - IFNULL(t.qty, 0)) AS diff, '' AS note, IFNULL(t.id_comp, s.id_comp) AS id_comp, IFNULL(t.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name)) AS comp_name, t.is_auto, 'no' AS is_select, s.id_product,
            IF(IFNULL(t.id_store_type,c.id_store_type)=1,s.id_design_price_normal, s.id_design_price) AS `id_price`,
            IF(IFNULL(t.id_store_type,c.id_store_type)=1,s.design_price_normal, s.design_price) AS `unit_price`, n.note AS store_note, h.design_price_type
            FROM tb_st_store_soh AS s
            LEFT JOIN (
                SELECT s.id_product, SUM(s.qty) AS qty, s.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, s.is_auto, c.id_store_type
                FROM tb_st_store AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + "
                GROUP BY s.id_product
            ) AS t ON s.id_product = t.id_product
            LEFT JOIN tb_m_product_store AS p ON s.id_product = p.id_product
            LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
            LEFT JOIN tb_st_store_note AS n ON s.id_product = n.id_product AND n.id_st_store_period = " + id_period + "
            LEFT JOIN tb_lookup_design_price_type AS h ON s.id_design_price_type = h.id_design_price_type
            WHERE s.id_st_store_period = " + id_period + ")
        
            UNION ALL

            (SELECT 0 AS `no`, p.full_code, p.name, p.size, 0 AS qty_volcom, q.qty AS qty_store, -q.qty AS diff, '' AS note, q.id_comp, q.comp_name, q.is_auto, 'no' AS is_select, p.id_product,
            IF(IFNULL(q.id_store_type,0)=1,prn.id_design_price, prc.id_design_price) AS id_price,
            IF(IFNULL(q.id_store_type,0)=1,prn.design_price, prc.design_price) AS `unit_price`, n.note AS store_note, IFNULL(prc.design_price_type, prn.design_price_type) AS design_price_type
            FROM tb_m_product_store AS p
            INNER JOIN (
                SELECT s.id_product, SUM(s.qty) AS qty, c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, s.is_auto, c.id_store_type
                FROM tb_st_store AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + " AND s.id_product NOT IN (SELECT id_product FROM tb_st_store_soh WHERE id_st_store_period = " + id_period + ")
                GROUP BY s.id_product
            ) AS q ON q.id_product = p.id_product
            INNER JOIN tb_m_product op ON op.id_product = p.id_product
            LEFT JOIN tb_st_store_note AS n ON p.id_product = n.id_product AND n.id_st_store_period = " + id_period + "
            LEFT JOIN (
                SELECT c.id_design, c.id_design_price, ROUND(c.design_price) AS design_price, c.id_design_price_type, h.design_price_type
                FROM tb_m_design_price AS c
                LEFT JOIN tb_lookup_design_price_type AS h ON c.id_design_price_type = h.id_design_price_type
                WHERE c.id_design_price IN (
                    SELECT MAX(id_design_price) AS id_design_price
                    FROM tb_m_design_price
                    WHERE design_price_start_date <= DATE((SELECT soh_date FROM tb_st_store_period WHERE id_st_store_period = " + id_period + ")) AND is_active_wh = 1 AND is_design_cost = 0
                    GROUP BY id_design
                )
            ) AS prc ON op.id_design = prc.id_design
            LEFT JOIN (
                SELECT c.id_design, c.id_design_price, ROUND(c.design_price) AS design_price, h.design_price_type
                FROM tb_m_design_price AS c
                LEFT JOIN tb_lookup_design_price_type AS h ON c.id_design_price_type = h.id_design_price_type
                WHERE c.id_design_price IN (
                    SELECT MAX(id_design_price) AS id_design_price
                    FROM tb_m_design_price
                    WHERE design_price_start_date <= DATE((SELECT soh_date FROM tb_st_store_period WHERE id_st_store_period = " + id_period + ")) AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                    GROUP BY id_design
                )
            ) AS prn ON op.id_design = prn.id_design)
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

        'bap pelaksanaan
        Dim view_bap As String = execute_query("
            SELECT COUNT(*) 
            FROM tb_st_store_period
            WHERE (schedule_end < DATE(NOW()) OR (is_stop_scan = 1 AND stop_scan_date <= NOW())) AND id_st_store_period = " + id_period + "
        ", 0, True, "", "", "", "")

        If view_bap = "0" Then
            DDBBAPPelaksanaan.Visible = False
            SBStopScan.Visible = True
            SBVerification.Visible = False
        Else
            DDBBAPPelaksanaan.Visible = True
            SBStopScan.Visible = False
            SBVerification.Visible = True
        End If

        PopupMenu.ClearLinks()

        Dim comp_in As DataTable = execute_query("
            SELECT t.id_comp, t.comp_name
            FROM (
                (SELECT s.id_st_store_period, s.id_comp, c.comp_name
                FROM tb_st_store_soh AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + ")
                UNION ALL
                (SELECT s.id_st_store_period, s.id_comp, c.comp_name
                FROM tb_st_store AS s
                LEFT JOIN tb_m_comp AS c ON s.id_comp = c.id_comp
                WHERE s.id_st_store_period = " + id_period + ")
            ) AS t
            GROUP BY t.id_comp, t.comp_name
        ", -1, True, "", "", "", "")

        Dim volcomClientHost As String = get_setup_field("volcom_client_host")

        Dim url As String = volcomClientHost + "/stocktake/getBAPPelakasanaan/"

        For i = 0 To comp_in.Rows.Count - 1
            Dim itm As DevExpress.XtraBars.BarItem = New DevExpress.XtraBars.BarButtonItem

            itm.Tag = url + id_period + "/" + comp_in.Rows(i)("id_comp").ToString
            itm.Caption = comp_in.Rows(i)("comp_name").ToString

            AddHandler itm.ItemClick, AddressOf itemClick

            PopupMenu.AddItem(itm)
        Next
    End Sub

    Sub itemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Process.Start(e.Item.Tag)
    End Sub

    Private Sub GVPeriod_DoubleClick(sender As Object, e As EventArgs) Handles GVPeriod.DoubleClick
        XtraTabControl.SelectedTabPageIndex = 1
    End Sub

    Private Sub SBSync_Click(sender As Object, e As EventArgs) Handles SBSync.Click
        FormMain.SplashScreenManager1.ShowWaitForm()

        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

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

        execute_non_query("DELETE FROM tb_st_store WHERE id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "", True, "", "", "", "")
        execute_non_query("DELETE FROM tb_st_store_note WHERE id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "", True, "", "", "", "")

        Dim query As String = "INSERT IGNORE INTO tb_st_store (id_st_store, id_st_store_period, id_product, created_date, scanned_code, qty, note, is_unique_not_found, is_no_tag, image, id_comp) VALUES "
        Dim query_note As String = "INSERT IGNORE INTO tb_st_store_note (id_st_store_note, id_st_store_period, id_product, note, updated_at, updated_by) VALUES "

        If json("status") = "success" Then
            Dim insert As Boolean = False
            Dim insert_note As Boolean = False

            Try
                For Each row In json("content")("scan").ToList
                    Dim id_st_store As String = row("id_st_store").ToString
                    Dim id_st_store_period As String = row("id_st_store_period").ToString
                    Dim id_product As String = row("id_product").ToString
                    Dim created_date As String = row("created_date").ToString
                    Dim scanned_code As String = row("scanned_code").ToString
                    Dim qty As String = row("qty").ToString
                    Dim note As String = row("note").ToString
                    Dim is_unique_not_found As String = row("is_unique_not_found").ToString
                    Dim is_no_tag As String = row("is_no_tag").ToString
                    Dim image As String = row("image").ToString
                    Dim id_comp As String = row("id_comp").ToString

                    query += "(" + id_st_store + ", " + id_st_store_period + ", " + id_product + ", '" + created_date + "', '" + scanned_code + "', " + qty + ", '" + addSlashes(note) + "', " + is_unique_not_found + ", " + is_no_tag + ", '" + addSlashes(image) + "', " + id_comp + "), "

                    insert = True
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row In json("content")("note").ToList
                    Dim id_st_store_note As String = row("id_st_store_note").ToString
                    Dim id_st_store_period As String = row("id_st_store_period").ToString
                    Dim id_product As String = row("id_product").ToString
                    Dim note As String = row("note").ToString
                    Dim updated_at As String = row("updated_at").ToString
                    Dim updated_by As String = row("updated_by").ToString

                    query_note += "(" + id_st_store_note + ", " + id_st_store_period + ", " + id_product + ", '" + addSlashes(note) + "', '" + updated_at + "', " + updated_by + "), "

                    insert_note = True
                Next
            Catch ex As Exception
            End Try

            Try
                For Each row In json("content")("period").ToList
                    Dim is_stop_scan As String = row("is_stop_scan").ToString
                    Dim stop_scan_date As String = If(row("stop_scan_date").ToString = "", "NULL", "'" + row("stop_scan_date").ToString + "'")

                    Dim query_period As String = "UPDATE tb_st_store_period SET is_stop_scan = " + is_stop_scan + ", stop_scan_date = " + stop_scan_date + " WHERE id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString

                    execute_non_query(query_period, True, "", "", "", "")
                Next
            Catch ex As Exception
            End Try

            If insert Then
                query = query.Substring(0, query.Length - 2)

                execute_non_query(query, True, "", "", "", "")
            End If

            If insert_note Then
                query_note = query_note.Substring(0, query_note.Length - 2)

                execute_non_query(query_note, True, "", "", "", "")
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

    Private Sub BtnScanList_Click(sender As Object, e As EventArgs) Handles BtnScanList.Click
        Cursor = Cursors.WaitCursor
        FormStockTakeStoreScanList.id_period = GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString
        FormStockTakeStoreScanList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            BGVCompare.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SBVerification_Click(sender As Object, e As EventArgs) Handles SBVerification.Click
        FormStockTakeStoreVer.ShowDialog()
    End Sub

    Private Sub SBStopScan_Click(sender As Object, e As EventArgs) Handles SBStopScan.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to stop scan ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Net.ServicePointManager.Expect100Continue = True
            Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

            Dim accessToken As String = FormStockTakeStorePeriodDet.getAccessToken()

            Dim wc As Net.WebClient = New Net.WebClient()

            wc.Headers.Add("Authorization", accessToken)

            Dim volcomClientHost As String = get_setup_field("volcom_client_host")

            Dim url As String = volcomClientHost + "/api/stocktake/stop"

            Dim param As Specialized.NameValueCollection = New Specialized.NameValueCollection

            param.Add("id_period", GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString)

            Dim responseArray As Byte() = wc.UploadValues(url, "POST", param)

            Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

            Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

            If json("status") = "success" Then
                execute_non_query("
                UPDATE tb_st_store_period SET is_stop_scan = 1, stop_scan_date = NOW() WHERE id_st_store_period = " + GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString,
                True, "", "", "", "")

                FormMain.SplashScreenManager1.CloseWaitForm()

                infoCustom("Stop Scan Completed.")
            Else
                FormMain.SplashScreenManager1.CloseWaitForm()

                errorCustom("Stop Scan Error.")
            End If

            view_compare()
        End If
    End Sub
End Class