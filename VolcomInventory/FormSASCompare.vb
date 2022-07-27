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

        'get rmt sal
        FormMain.SplashScreenManager1.SetWaitFormDescription("Check report type sales")
        Dim rmt_sal As String = execute_query("SELECT GROUP_CONCAT(DISTINCT sp.report_mark_type) FROM tb_sales_pos sp WHERE sp.id_report_status=6", 0, True, "", "", "", "")


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

        Dim col_est_sal_order_qty As String = ""
        Dim col_est_sal_order_qty_select As String = ""
        Dim col_est_sal_order_qty_total As String = ""
        Dim sum_est_sal_order_qty As String = "0"
        Dim col_est_sal_order_price_raw As String = ""
        Dim col_est_sal_order_price_select As String = ""
        Dim col_est_sal_order_price_total As String = ""

        Dim col_est_sal_rec_qty As String = ""
        Dim col_est_sal_rec_qty_select As String = ""
        Dim col_est_sal_rec_qty_total As String = ""
        Dim sum_est_sal_rec_qty As String = "0"
        Dim col_est_sal_rec_price_raw As String = ""
        Dim col_est_sal_rec_price_select As String = ""
        Dim col_est_sal_rec_price_total As String = ""

        Dim col_sal1 As String = ""
        Dim col_sal2 As String = ""
        Dim col_sal2_raw As String = ""
        Dim col_sal2_total As String = ""
        Dim col_sal_value As String = ""
        Dim col_sal_value_raw As String = ""
        Dim col_sal_value_total As String = ""
        Dim l As Integer = 0
        While date_loop <= date_end
            Dim date_db As String = Date.Parse(date_loop).ToString("yyyy") + "-" + Date.Parse(date_loop).ToString("MM") + "-" + Date.Parse(date_loop).ToString("dd")

            If l > 0 Then
                sum_est_sal_order_qty += "+" + col_est_sal_order_qty
                sum_est_sal_rec_qty += "+" + col_est_sal_rec_qty
                col_est_sal_order_qty_total += "+"
                col_est_sal_rec_qty_total += "+"
                col_sal2_total += "+"
                col_est_sal_order_price_total += "+"
                col_est_sal_rec_price_total += "+"
                col_sal_value_total += "+"
            End If

            'col sas
            col_sas_target1 += "MAX(CASE WHEN sas.sas_period='" + date_db + "' THEN sas.sas_value END) AS `" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,"
            col_sas_target2 += "CONCAT(ROUND(IFNULL(tg_sas.`" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,0),0),'%') AS `Target SAS (%)|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "

            'est sale (order)
            col_est_sal_order_qty = "ROUND(((pd.`total_qty_core`-(" + sum_est_sal_order_qty + "))*(tg_sas.`" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`/100)),0)"
            col_est_sal_order_qty_select += col_est_sal_order_qty + " AS `Est Sal. Qty (Order)|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_est_sal_order_qty_total += col_est_sal_order_qty
            col_est_sal_order_price_raw = "(" + col_est_sal_order_qty + " * pd.pd_price) "
            col_est_sal_order_price_select += col_est_sal_order_price_raw + " AS `Est Sal. Value (Order)|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_est_sal_order_price_total += col_est_sal_order_price_raw



            'est sale (rec)
            col_est_sal_rec_qty = "ROUND(((IFNULL(rec.qty_rec,0)-(" + sum_est_sal_rec_qty + "))*(tg_sas.`" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`/100)),0)"
            col_est_sal_rec_qty_select += col_est_sal_rec_qty + " AS `Est Sal. Qty (Receiving)|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_est_sal_rec_qty_total += col_est_sal_rec_qty
            col_est_sal_rec_price_raw = "(" + col_est_sal_rec_qty + "*IFNULL(normal_prc.design_price,0)) "
            col_est_sal_rec_price_select += col_est_sal_rec_price_raw + " AS `Est Sal. Value (Receiving)|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_est_sal_rec_price_total += col_est_sal_rec_price_raw

            'sale
            col_sal1 += "(SUM(CASE WHEN s.soh_date='" + date_db + "' THEN s.qty END)*-1) AS `Actual Sales Qty|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_sal2_raw = "IFNULL(sal.`Actual Sales Qty|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,0) "
            col_sal2 += col_sal2_raw + " AS `Actual Sales Qty|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_sal2_total += col_sal2_raw
            col_sal_value_raw = "(" + "IFNULL(sal.`Actual Sales Qty|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`,0) * IFNULL(normal_prc.design_price,0)) "
            col_sal_value += col_sal_value_raw + " AS `Actual Sales Value|" + Date.Parse(date_loop).ToString("MMM") + " " + Date.Parse(date_loop).ToString("yyyy") + "`, "
            col_sal_value_total += col_sal_value_raw

            'loop
            date_loop = DateAdd(DateInterval.Month, 1, date_loop)
            l += 1
        End While

        'eksekusi 
        Dim query As String = "SELECT d.id_design AS `Product Info|id_design`, d.design_code AS `Product Info|Code`,lso.lookup_status_order AS `Product Info|Move Status`, sspd.season AS `Product Info|Season Order`, dpd.delivery AS `Product Info|Del. Order`, ss.season AS `Product Info|Indo Season`, sd.delivery AS `Product Info|Del`,
        cd.class AS `Product Info|Class`, d.design_display_name AS `Product Info|Description`, cd.sht AS `Product Info|Silhouette`, cd.color AS `Product Info|Color`, cd.color_desc AS `Product Info|Color Descr.`,
        pd.`prod_demand_number` AS `Prod. Demand|Number`,
        pd.`total_qty_mkt` AS `Prod. Demand|MKT`,
        pd.`total_qty_buff` AS `Prod. Demand|BUFF`,
        pd.`total_qty_dev` AS `Prod. Demand|DEV`,
        pd.`total_qty_core` AS `Prod. Demand|CORE`,
        pd.`total_qty_act_order_sales` AS `Prod. Demand|ACT. ORDER SAL.`,
        pd.`total_qty` AS `Prod. Demand|Total Qty`, pd.pd_price AS `Prod. Demand|Est. Price`, (pd.`total_qty_core`*pd.pd_price) AS  `Prod. Demand|TTL Amount Core`,
        IFNULL(normal_prc.design_price,0) AS `PP|NORMAL PRICE`,
        IFNULL(rec.qty_rec,0) AS `RECEIVED IN WH|QTY REC.`,
        " + col_sas_target2 + "
        " + col_est_sal_order_qty_select + "
        (" + col_est_sal_order_qty_total + ") AS `Est Sal. Qty (Order)|Total`,
         " + col_est_sal_rec_qty_select + "
        (" + col_est_sal_rec_qty_total + ") AS `Est Sal. Qty (Receiving)|Total`,
        " + col_sal2 + "
        (" + col_sal2_total + ") AS `Actual Sales Qty|Total`,
        " + col_est_sal_order_price_select + "
        (" + col_est_sal_order_price_total + ") AS `Est Sal. Value (Order)|Total`,
        " + col_est_sal_rec_price_select + "
        (" + col_est_sal_rec_price_total + ") AS `Est Sal. Value (Receiving)|Total`,
        " + col_sal_value + "
        (" + col_sal_value_total + ") AS `Actual Sales Value|Total`,
        '' AS `*|*`
        FROM tb_m_design d
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_lookup_status_order lso ON lso.id_lookup_status_order = d.id_lookup_status_order
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
        INNER JOIN (
	        SELECT d.id_design, MAX(pd.prod_demand_number) AS `prod_demand_number`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=1 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_mkt`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=4 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_buff`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=8 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_dev`,
	        IFNULL(SUM(CASE WHEN pda.id_pd_alloc=7 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_core`,
	        IFNULL(SUM(CASE WHEN alloc.is_include_so=1 THEN pda.prod_demand_alloc_qty END),0) AS `total_qty_act_order_sales`,
	        SUM(pda.prod_demand_alloc_qty) AS `total_qty`,
	        MAX(pdd.prod_demand_design_propose_price) AS `pd_price`,
            MAX(pd.id_season) AS `id_season_pd`, MAX(pdd.id_delivery) AS `id_delivery_pd`
	        FROM tb_prod_demand pd
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand = pd.id_prod_demand AND pdd.is_void=2
	        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design 
	        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_design = pdd.id_prod_demand_design
	        INNER JOIN tb_prod_demand_alloc pda ON pda.id_prod_demand_product = pdp.id_prod_demand_product
	        INNER JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = pda.id_pd_alloc
	        WHERE pd.id_report_status=6 AND pd.is_pd=1 AND (d.id_season IN(" + CCBESeason.EditValue.ToString + ") OR pd.id_season IN (" + CCBESeason.EditValue.ToString + "))
	        GROUP BY d.id_design
        ) pd ON pd.id_design = d.id_design
        INNER JOIN tb_season sspd ON sspd.id_season = pd.id_season_pd
        INNER JOIN tb_season_delivery dpd ON dpd.id_delivery = pd.id_delivery_pd
        LEFT JOIN (
            SELECT d.id_design, SUM(rd.pl_prod_order_rec_det_qty) AS `qty_rec`
            FROM tb_pl_prod_order_rec r
            INNER JOIN tb_pl_prod_order_rec_det rd ON rd.id_pl_prod_order_rec = r.id_pl_prod_order_rec
            INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = r.id_pl_prod_order
            INNER JOIN tb_prod_order po ON po.id_prod_order = pl.id_prod_order
            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.id_report_status=6 AND pd.is_pd=1
            INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
            WHERE r.id_report_status=6 AND pl.id_pl_category=1 AND (d.id_season IN(" + CCBESeason.EditValue.ToString + ") OR pd.id_season IN (" + CCBESeason.EditValue.ToString + "))
            GROUP BY d.id_design
        ) rec ON rec.id_design = d.id_design
        LEFT JOIN (
		    SELECT price.id_design, price.id_design_price, price.design_price, cat.id_design_cat,cat.design_cat, price_type.design_price_type
		    FROM tb_m_design_price price 
		    INNER JOIN (
			    SELECT MAX(price.id_design) AS `id_design`, MAX(price.id_design_price) AS  `id_design_price`
			    FROM tb_m_design_price price
			    INNER JOIN (
				    Select MAX(price.id_design) AS `id_design`, MAX(price.design_price_start_date) AS `design_price_start_date`
				    From tb_m_design_price price 
				    WHERE price.is_active_wh=1 AND price.design_price_start_date <= NOW() AND price.id_design_price_type=1
				    GROUP BY price.id_design
			    ) maxdate ON maxdate.id_design = price.id_design AND maxdate.design_price_start_date = price.design_price_start_date
			    WHERE price.is_active_wh=1 AND price.design_price_start_date <= NOW() AND price.id_design_price_type=1
			    GROUP BY price.id_design
		    ) pricemax ON pricemax.id_design_price = price.id_design_price
		    INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
		    INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	    ) normal_prc ON normal_prc.id_design = d.id_design
        LEFT JOIN (
            SELECT s.id_design, 
            " + col_sal1 + "
            1 AS `flag`
            FROM tb_soh_sal_period s
            INNER JOIN tb_m_comp c ON c.id_comp = s.id_comp AND c.id_store_type=1
            WHERE (s.soh_date>='2022-01-01' AND s.soh_date<='2022-12-01') AND s.report_mark_type IN (48,66,54,67,118,117,183,116,292,344,399)
            GROUP BY s.id_design
        ) sal ON sal.id_design = d.id_design
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

                        If coluName <> "Est. Price" Then
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
                    End If

                    If bandName.Contains("Est Sal. Qty (Order)") Or bandName.Contains("Est Sal. Value (Order)") Or bandName.Contains("Est Sal. Qty (Receiving)") Or bandName.Contains("Est Sal. Value (Receiving)") Or bandName.Contains("RECEIVED IN WH") Or bandName.Contains("Actual Sales Qty") Or bandName.Contains("Actual Sales Value") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

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

                    If bandName.Contains("PP") Then
                        'RECEIVED IN WH
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"
                    End If

                    If bandName.Contains("Target SAS (%)") Then
                        col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    End If
                End If
            Next
        Next

        'hide
        GVData.Columns("Product Info|id_design").Visible = False
        GVData.Columns("Prod. Demand|Number").Visible = False
        GVData.Columns("Product Info|Color Descr.").Visible = False
        GVData.Columns("Product Info|Silhouette").Visible = False

        GCData.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        ''column option creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'For i As Integer = 0 To GVData.Columns.Count - 1
        '    Try
        '        GVData.Columns(i).Caption = GVData.Columns(i).OwnerBand.ToString + "|" + GVData.Columns(i).Caption.ToString
        '    Catch ex As Exception
        '    End Try
        'Next

        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try

        ''restore column opt
        'GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
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
            path = path + "estimate_actual_sales.xlsx"
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