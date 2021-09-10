Public Class FormStockTakeStoreVer
    Private Sub FormStockTakeStoreVer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormStockTakeStoreVer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBNew_Click(sender As Object, e As EventArgs) Handles SBNew.Click
        FormStockTakeStoreVerCrt.ShowDialog()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT b.id_st_store_bap, b.number, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, b.id_report_status, r.report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON b.id_report_status = r.id_report_status
            WHERE b.id_st_store_period = " + FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString + "
            ORDER BY b.id_st_store_bap DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data

        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        FormStockTakeStoreVerDet.id_st_store_bap = GVData.GetFocusedRowCellValue("id_st_store_bap").ToString
        FormStockTakeStoreVerDet.ShowDialog()
    End Sub

    Private Sub SBSynctoWeb_Click(sender As Object, e As EventArgs) Handles SBSynctoWeb.Click
        Dim data As DataTable = New DataTable

        data.Columns.Add("id_st_store_period", GetType(Integer))
        data.Columns.Add("id_comp", GetType(Integer))
        data.Columns.Add("id_product", GetType(Integer))
        data.Columns.Add("id_price", GetType(Integer))
        data.Columns.Add("price", GetType(Decimal))
        data.Columns.Add("soh_qty", GetType(Integer))
        data.Columns.Add("scan_qty", GetType(Integer))
        data.Columns.Add("wh_qty", GetType(Integer))
        data.Columns.Add("selisih_awal_qty", GetType(Integer))
        data.Columns.Add("verifikasi_qty", GetType(Integer))
        data.Columns.Add("selisih_akhir_qty", GetType(Integer))
        data.Columns.Add("remark", GetType(String))
        data.Columns.Add("note", GetType(String))

        For i = 0 To GVData.RowCount - 1
            If Not GVData.GetRowCellValue(i, "id_report_status").ToString = "5" Then
                FormStockTakeStoreVerDet.WindowState = FormWindowState.Minimized

                FormStockTakeStoreVerDet.id_st_store_bap = GVData.GetRowCellValue(i, "id_st_store_bap").ToString
                FormStockTakeStoreVerDet.Show()

                For j = 0 To FormStockTakeStoreVerDet.BGVData.RowCount - 1
                    If FormStockTakeStoreVerDet.BGVData.IsValidRowHandle(j) Then
                        Dim row As DataRow = data.NewRow

                        row("id_st_store_period") = FormStockTakeStorePeriod.GVPeriod.GetFocusedRowCellValue("id_st_store_period").ToString
                        row("id_comp") = FormStockTakeStoreVerDet.SLUEAccount.EditValue.ToString
                        row("id_product") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "id_product")
                        row("id_price") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "id_price")
                        row("price") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "price")
                        row("soh_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_volcom")
                        row("scan_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_store")
                        row("wh_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_wh")
                        row("selisih_awal_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_awal")
                        row("verifikasi_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_ver")
                        row("selisih_akhir_qty") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "qty_akhir")
                        row("remark") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "report_mark_type_name")
                        row("note") = FormStockTakeStoreVerDet.BGVData.GetRowCellValue(j, "note")

                        data.Rows.Add(row)
                    End If
                Next

                FormStockTakeStoreVerDet.Close()

                FormStockTakeStoreVerDet.WindowState = FormWindowState.Maximized
            End If
        Next

        Dim out As String = Newtonsoft.Json.JsonConvert.SerializeObject(data)

        Dim pathRoot As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(pathRoot) Then
            System.IO.Directory.CreateDirectory(pathRoot)
        End If

        Dim fileName As String = "hasil-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json"

        Dim file As String = IO.Path.Combine(pathRoot, fileName)

        Dim fs As IO.FileStream = System.IO.File.Create(file)

        Dim info As Byte() = New System.Text.UTF8Encoding(True).GetBytes(out)

        fs.Write(info, 0, info.Length)

        fs.Close()

        'upload
        Net.ServicePointManager.Expect100Continue = True
        Net.ServicePointManager.SecurityProtocol = CType(3072, Net.SecurityProtocolType)

        Dim volcomClientHost As String = get_setup_field("volcom_client_host")
        Dim volcomClientUsername As String = get_setup_field("volcom_client_username")
        Dim volcomClientPassword As String = get_setup_field("volcom_client_password")

        Dim accessToken As String = FormStockTakeStorePeriodDet.getAccessToken()

        Dim url As String = volcomClientHost + "/api/sync/stocktake/hasil"

        Dim wc As Net.WebClient = New Net.WebClient()

        wc.Headers.Add("Authorization", accessToken)

        Dim responseArray As Byte() = wc.UploadFile(url, "POST", file)

        Dim responseString As String = System.Text.Encoding.ASCII.GetString(responseArray)

        Dim json As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseString)

        infoCustom("Sync Ok.")
    End Sub
End Class