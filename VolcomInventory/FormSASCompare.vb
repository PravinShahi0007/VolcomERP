Public Class FormSASCompare
    Dim dt_json As New Newtonsoft.Json.Linq.JObject()

    Private Sub FormSASCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt_json = volcomErpApiGetJson(volcom_erp_api_host & "api/salthru-compare")
        DEFrom.EditValue = volcomErpApiGetDT(dt_json, 0).Rows(0)("current_date")
        DEUntil.EditValue = volcomErpApiGetDT(dt_json, 0).Rows(0)("current_date")
        viewSeason()
        viewType()
    End Sub

    Private Sub FormSASCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewSeason()
        Dim data As DataTable = volcomErpApiGetDT(dt_json, 1)

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewType()
        viewSearchLookupQueryO(SLEType, volcomErpApiGetDT(dt_json, 2), "id_salthru_type", "salthru_type", "id_salthru_type")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        'cek closing
        Dim y As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy") + "," + DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy")
        Dim m As String = DateTime.Parse(DEFrom.EditValue.ToString).ToString("MM") + "," + DateTime.Parse(DEUntil.EditValue.ToString).ToString("MM")
        checkClosingSOHSalPeriod(m, y)

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Check condition")
        'cek date
        Dim date_from_selected As String = "0000-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim date_until_selected As String = "0000-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        'type
        Dim id_salthru_type As String = SLEType.EditValue.ToString

        'build query
        FormMain.SplashScreenManager1.SetWaitFormDescription("Build query")
        Dim date_loop As Date = DEFrom.EditValue
        Dim date_end As Date = DEUntil.EditValue
        Dim col_sas_target1 As String = ""
        Dim col_sas_target2 As String = ""
        While date_loop <= date_end
            Console.WriteLine(Date.Parse(date_loop).ToString("dd MMMM yyyy"))
            Dim date_db As String = Date.Parse(date_loop).ToString("yyyy") + "-" + Date.Parse(date_loop).ToString("MM") + "-" + Date.Parse(date_loop).ToString("dd")
            col_sas_target1 += "MAX(CASE WHEN sas.sas_period='" + date_db + "' THEN sas.sas_value END) AS `" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,"
            col_sas_target2 += "IFNULL(tg_sas.`" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,0) AS `Target SAS|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            date_loop = DateAdd(DateInterval.Month, 1, date_loop)
        End While

        'eksekusi 
        Dim query As String = "SELECT d.id_design AS `Product Info|id_design`, d.design_code AS `Product Info|Code`, ss.season AS `Product Info|Season`, sd.delivery AS `Product Info|Del`,
        cd.class AS `Product Info|Class`, d.design_display_name AS `Product Info|Description`, cd.sht AS `Product Info|Silhouette`, cd.color AS `Product Info|Color`, cd.color_desc AS `Product Info|Color Descr.`,
        pd.`prod_demand_number` AS `Prod. Demand|Number`,
        pd.`total_qty_mkt` AS `Prod. Demand|MKT`,
        pd.`total_qty_buff` AS `Prod. Demand|BUFF`,
        pd.`total_qty_dev` AS `Prod. Demand|DEV`,
        pd.`total_qty_core` AS `Prod. Demand|CORE`,
        pd.`total_qty_act_order_sales` AS `Prod. Demand|ACT. ORDER SAL.`,
        pd.`total_qty` AS `Prod. Demand|Total Qty`, pd.pd_price AS `Prod. Demand|Normal Price`, (pd.`total_qty_core`*pd.pd_price) AS  `Prod. Demand|TTL Amount Core`,
        " + col_sas_target2 + "
        99 AS `Flag|End Column`
        FROM tb_m_design d
        INNER JOIN (
	        SELECT d.id_design, MAX(pd.prod_demand_number) AS `prod_demand_number`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=1 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_mkt`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=4 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_buff`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=8 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_dev`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=7 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_core`,
	        IFNULL(SUM(CASE WHEN alloc.is_include_so=1 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_act_order_sales`,
	        SUM(pda.prod_demand_alloc_qty) AS `total_qty`,
	        MAX(pdd.prod_demand_design_propose_price) AS `pd_price`
	        FROM tb_prod_demand pd
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand = pd.id_prod_demand AND pdd.is_void=2
	        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design 
	        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
	        INNER JOIN tb_prod_demand_alloc pda ON pda.id_prod_demand_product = pdp.id_prod_demand_product
	        INNER JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = pda.id_pd_alloc
	        INNER JOIN tb_season ss ON ss.id_season = d.id_season
	        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
	        WHERE pd.id_report_status=6 AND pd.is_pd=1 AND (d.id_season IN(" + CCBESeason.EditValue.ToString + ") OR pd.id_season IN (" + CCBESeason.EditValue.ToString + "))
	        GROUP BY d.id_design
        ) pd ON pd.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = d.id_design
        LEFT JOIN (
	        SELECT 
            " + col_sas_target1 + "
            sas.id_class, sas.id_delivery
	        FROM tb_tg_sas sas
	        WHERE sas.is_active=1 AND sas.sas_period>='" + date_from_selected + "' AND sas.sas_period<='" + date_until_selected + "'
	        GROUP BY sas.id_class, sas.id_delivery
        ) tg_sas ON tg_sas.id_class = cd.id_class AND tg_sas.id_delivery = d.id_delivery
        ORDER BY cd.class ASC, d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'clear column/band
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading column")
        GVData.Bands.Clear()
        GVData.Columns.Clear()

        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next

        'setu band
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVData.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If bandName.Contains("Prod. Demand") And Not coluName.Contains("Number") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"

                        'summary
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        col.SummaryItem.DisplayFormat = "{0:n0}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N0}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVData.GroupSummary.Add(summary)
                    End If

                    If bandName.Contains("Target SAS") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n2}%"
                    End If
                End If
            Next
        Next
        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportXls_Click(sender As Object, e As EventArgs) Handles BtnExportXls.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sth_acc_product.xlsx"
            exportToXLS(path, "list", GCData)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        resetView()
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        resetView()
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        resetView()
    End Sub

    Private Sub CCBESeason_EditValueChanged(sender As Object, e As EventArgs) Handles CCBESeason.EditValueChanged
        resetView()
    End Sub

    Private Sub FormSASCompare_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSASCompare_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class