Public Class FormStoreDisplayDet
    Public id As String = "-1"
    Public action As String = ""
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "353"

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ss.id_season, rg.`range`, ss.season, MIN(sd.delivery_date) AS `in_store_date`
        FROM tb_season ss 
        INNER JOIN tb_range rg ON rg.id_range = ss.id_range
        INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season
        WHERE rg.is_md=1
        GROUP BY ss.id_season
        ORDER BY `range` DESC  "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        Cursor = Cursors.Default
    End Sub

    Sub viewComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        (SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        WHERE c.id_comp_cat=6 
        ORDER BY c.id_comp ASC) "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStoreDisplayDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        viewComp()
        actionLoad()
    End Sub

    Private Sub FormStoreDisplayDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'option
            SLESeason.EditValue = Nothing
            BtnCreateNew.Visible = True
            Width = 790
            Height = 150
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            'FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControlBottom.Visible = False
            PanelControlNo.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If
            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)
        ElseIf action = "upd" Then
            WindowState = FormWindowState.Maximized
            PanelControlTitle.Height = 80

            Dim sd As New ClassStoreDisplay()
            Dim query As String = sd.queryMain("AND  p.id_display_pps='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.EditValue = data.Rows(0)("created_by_name").ToString
            DEUpdated.EditValue = data.Rows(0)("updated_date")
            TxtUpdatedBy.EditValue = data.Rows(0)("updated_by_name").ToString
            SLESeason.EditValue = data.Rows(0)("id_season").ToString
            DEInStoreDate.EditValue = data.Rows(0)("in_store_date")
            SLEComp.EditValue = data.Rows(0)("id_comp").ToString
            MENote.Text = data.Rows(0)("note").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString

            'set title
            BBICurrentSeason.Caption = SLESeason.Text
            XTPCurrSeasonOrder.Text = SLESeason.Text + " Order"

            'detail
            viewDisplayPlanning()
            viewRencanaSKU()
            allow_status()


            'cek update master jika belum confirm
            If is_confirm = "2" Then
                Dim id_max_pps As String = execute_query("SELECT IFNULL(MAX(dps.id_display_master),0) AS `id_max_pps` FROM tb_display_pps_store dps WHERE dps.id_display_pps=" + id + "", 0, True, "", "", "", "")
                Dim id_max_master As String = execute_query("SELECT IFNULL(MAX(dm.id_display_master),0) AS `id_max_master`
                FROM tb_display_master dm WHERE dm.id_comp=" + data.Rows(0)("id_comp").ToString + " AND dm.is_active=1 ", 0, True, "", "", "", "")
                If id_max_master <> id_max_pps Then
                    insDefaultMasterDisplay(data.Rows(0)("id_comp").ToString)
                End If
            End If

            'cek status toko
            Dim store_stt As String = execute_query("SELECT IFNULL(c.is_active,0) AS `is_active` FROM tb_m_comp c WHERE c.id_comp='" + SLEComp.EditValue.ToString + "'", 0, True, "", "", "", "")
            If store_stt <> "1" Then
                warningCustom("Display toko tidak bisa diproses karena status toko tidak aktif")
                Cursor = Cursors.Default
                Close()
            End If

            'view
            If is_view = "1" Then
                XTCDetail.SelectedTabPageIndex = 1
                BtnCancell.Visible = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub checkClassGroup()
        Cursor = Cursors.WaitCursor
        If action = "upd" And is_confirm = "2" Then
            Dim query As String = "SELECT cd.class AS `name`
            FROM tb_m_design d
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
            LEFT JOIN tb_class_group_det cgd ON cgd.id_class = cd.id_class
            WHERE d.id_season=" + SLESeason.EditValue.ToString + " AND d.id_lookup_status_order!=2 AND ISNULL(cgd.id_class_group_det)
            GROUP BY cd.class ORDER BY class ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("There are unidentified class group, please setup first.")
                FormFGLineListPDExist.dt = data
                FormFGLineListPDExist.GridColumn1.Visible = False
                FormFGLineListPDExist.GridColumn2.Visible = False
                FormFGLineListPDExist.LabelControl1.Text = "UNIDENTIFIED CLASS GROUP"
                FormFGLineListPDExist.ShowDialog()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        If SLESeason.EditValue = Nothing Or SLEComp.EditValue = Nothing Or DEInStoreDate.EditValue = Nothing Then
            warningCustom("Please input all data")
            Exit Sub
        End If

        Dim qcek As String = "SELECT * FROM tb_display_pps p WHERE p.id_comp='" + SLEComp.EditValue.ToString + "' AND p.id_season='" + SLESeason.EditValue.ToString + "'  AND p.id_report_status!=5 "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")

        If dcek.Rows.Count > 0 Then
            warningCustom("Please complete all pending propose first")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                saveHead()
            End If
        End If
    End Sub

    Sub saveHead()
        Cursor = Cursors.WaitCursor
        If SLESeason.EditValue = Nothing Then
            Cursor = Cursors.Default
            warningCustom("Please select season first")
            Exit Sub
        End If

        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim id_season As String = SLESeason.EditValue.ToString
        Dim note As String = addSlashes(MENote.Text)
        Dim in_store_date As String = DateTime.Parse(DEInStoreDate.EditValue.ToString).ToString("yyyy-MM-dd")
        If action = "ins" Then
            'get old propose
            Dim qget As String = "SELECT p.id_display_pps 
            FROM tb_display_pps p WHERE p.id_comp=" + id_comp + " AND p.id_season=" + id_season + " AND p.id_report_status=6
            ORDER BY p.id_display_pps DESC LIMIT 1 "
            Dim dget As DataTable = execute_query(qget, -1, True, "", "", "", "")
            Dim id_display_pps_ref As String = ""
            If dget.Rows.Count > 0 Then
                id_display_pps_ref = dget.Rows(0)("id_display_pps").ToString
            Else
                id_display_pps_ref = "NULL"
            End If

            Dim query As String = "INSERT INTO tb_display_pps(number,id_display_pps_ref, created_date, created_by, updated_date, updated_by, id_comp, id_season, id_report_status, is_confirm, in_store_date)
            VALUES (''," + id_display_pps_ref + ", NOW(), '" + id_user + "', NOW(), '" + id_user + "', '" + id_comp + "', '" + id_season + "',1,2, '" + in_store_date + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")

            'default season
            Dim qss As String = "INSERT INTO tb_display_pps_season(id_display_pps, id_season, id_delivery, is_extra_sku, id_display_season_type)
            -- old season
            SELECT " + id + " AS `idx`,NULL AS `id_season`, NULL AS `id_delivery`, 1 AS `is_extra_sku`,1 AS `id_display_season_type`
            UNION ALL
            -- prev season
            SELECT " + id + " AS `idx`,ss.id_season, sd.id_delivery, 2 AS `is_extra_sku`, 1 AS `id_display_season_type`
            FROM (
	            SELECT ss.id_season, ss.season
	            FROM tb_season ss
	            INNER JOIN tb_range rg ON rg.id_range = ss.id_range
	            INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season
                WHERE rg.is_md=1 AND sd.delivery_date<'" + in_store_date + "'
                GROUP BY ss.id_season
	            ORDER BY ss.id_season DESC LIMIT 3
            ) ss
            INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season
            UNION ALL 
            -- current season
            SELECT " + id + " AS `idx`,ss.id_season, sd.id_delivery, 2 AS `is_extra_sku`, 2 AS `id_display_season_type`
            FROM tb_season ss
            INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season
            WHERE ss.id_season=" + id_season + "
            -- plan season  
            UNION ALL          
            SELECT " + id + " AS `idx`,ss.id_season, sd.id_delivery, 2 AS `is_extra_sku`, 3 AS `id_display_season_type`
            FROM (
	            SELECT ss.id_season, ss.season
	            FROM tb_season ss
	            INNER JOIN tb_range rg ON rg.id_range = ss.id_range
	            INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season
                WHERE rg.is_md=1 AND sd.delivery_date>'" + in_store_date + "' AND ss.id_season!=" + id_season + "
                GROUP BY ss.id_season
	            ORDER BY ss.id_season ASC LIMIT 1
            ) ss
            INNER JOIN tb_season_delivery sd ON sd.id_season = ss.id_season "
            execute_non_query(qss, True, "", "", "", "")

            'default master display
            insDefaultMasterDisplay(id_comp)

            'default existing product
            Dim sd As New ClassStoreDisplay()
            Dim qbasic As String = sd.queryBasicDisplay(in_store_date, id_comp)
            Dim qep As String = "INSERT INTO tb_display_pps_res(id_display_pps, id_season, id_delivery, id_class_group, id_design, qty_curr, qty_pps)
            SELECT '" + id + "', ds.id_season, ds.id_delivery, ds.id_class_group, ds.id_design, SUM(ds.qty) AS `qty_curr`, SUM(ds.qty) AS `qty_pps`
            FROM (
              " + qbasic + "
            ) ds
            GROUP BY ds.id_design 
            HAVING qty_curr>0 "
            execute_non_query(qep, True, "", "", "", "")

            'gen number
            execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")

            refreshMainview()
            FormStoreDisplay.is_load_new = True
            Close()
        ElseIf action = "upd" Then
            'head
            Dim query As String = "UPDATE tb_display_pps SET note='" + note + "' WHERE id_display_pps='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub insDefaultMasterDisplay(ByVal id_comp_par As String)
        Cursor = Cursors.WaitCursor
        Dim qmd As String = "DELETE FROM tb_display_pps_store WHERE id_display_pps='" + id + "'; 
        INSERT INTO tb_display_pps_store(id_display_pps, id_display_master, id_class_group, id_display_type, qty, capacity,estimasi_sku)
        SELECT " + id + ", dm.id_display_master, dm.id_class_group, dm.id_display_type, dm.qty, da.capacity, cg.estimasi_sku
        FROM tb_display_master dm 
        INNER JOIN tb_display_alloc da ON da.id_display_type = dm.id_display_type AND da.id_class_group = dm.id_class_group
        INNER JOIN tb_class_group cg ON cg.id_class_group = dm.id_class_group
        WHERE dm.is_active=1 AND dm.id_comp=" + id_comp_par + " AND dm.qty>0 "
        execute_non_query(qmd, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Sub refreshMainview()
        'set season & comp
        FormStoreDisplay.SLESeason.EditValue = SLESeason.EditValue.ToString
        FormStoreDisplay.SLEComp.EditValue = SLEComp.EditValue.ToString

        FormStoreDisplay.viewPps()
        FormStoreDisplay.GVPPS.FocusedRowHandle = find_row(FormStoreDisplay.GVPPS, "id_display_pps", id)
    End Sub

    'Sub viewDetailSeason()
    '    Cursor = Cursors.WaitCursor
    '    Dim query As String = "SELECT ps.id_display_pps_season, IFNULL(ps.id_season,0) AS `id_season`, IFNULL(ps.id_delivery,0) AS `id_delivery`,
    '    'EXTRA SKU' AS `season_desc`, ps.koef_sold_out, ps.is_extra_sku, ps.is_add
    '    FROM tb_display_pps_season ps 
    '    WHERE ps.is_extra_sku=1 AND ps.id_display_pps=" + id + "
    '    UNION ALL
    '    SELECT ps.id_display_pps_season, ps.id_season, ps.id_delivery,
    '    CONCAT(ss.season,' D',sd.delivery) AS `season_desc`, ps.koef_sold_out, ps.is_extra_sku, ps.is_add
    '    FROM tb_display_pps_season ps 
    '    INNER JOIN tb_season ss ON ss.id_season = ps.id_season
    '    INNER JOIN tb_season_delivery sd ON sd.id_delivery = ps.id_delivery
    '    WHERE ps.is_extra_sku=2 AND ps.id_display_pps=" + id + " "
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCSeason.DataSource = data
    '    GVSeason.BestFitColumns()
    '    Cursor = Cursors.Default
    'End Sub

    Sub viewDisplayPlanning()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading display planning")
        Dim qdt As String = "SELECT dt.id_display_type, dt.display_type 
        FROM tb_display_pps_store dps
        INNER JOIN tb_display_type dt ON dt.id_display_type = dps.id_display_type
        WHERE dps.id_display_pps=" + id + "
        GROUP BY dt.id_display_type
        ORDER BY dt.display_type ASC "
        Dim ddt As DataTable = execute_query(qdt, -1, True, "", "", "", "")
        Dim coldt As String = ""
        Dim col_tot_capacity = ""
        For i As Integer = 0 To ddt.Rows.Count - 1
            If i > 0 Then
                coldt += ","
                col_tot_capacity += "+"
            End If
            coldt += "IFNULL(SUM(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.qty END),0)  AS `" + ddt.Rows(i)("display_type").ToString + "|QTY`,
            IFNULL(SUM(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.qty END),0) * IFNULL(MAX(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.capacity END),0) AS `" + ddt.Rows(i)("display_type").ToString + "|CAPACITY` "
            col_tot_capacity += "IFNULL(SUM(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.qty END),0) * IFNULL(MAX(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.capacity END),0) "
        Next
        Dim query As String = "SELECT dps.id_class_group AS `GROUP INFO|id_class_group`, cg.class_group AS `GROUP INFO|CLASS`, dv.display_name AS `GROUP INFO|DIVISION`, cc.class_cat AS `GROUP INFO|CATEGORY`,
        " + coldt + ",
        (" + col_tot_capacity + ") AS `TOTAL|TOTAL DISPLAY`,  ROUND((" + col_tot_capacity + ")/dps.estimasi_sku) AS `TOTAL|ESTIMASI SKU`
        FROM tb_display_pps_store dps
        INNER JOIN tb_class_group cg ON cg.id_class_group = dps.id_class_group
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        WHERE dps.id_display_pps=" + id + "
        GROUP BY dps.id_class_group
        ORDER BY dv.display_name ASC,cc.class_cat, cg.class_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDisplayPlanning.DataSource = data

        'clear band
        GVDisplayPlanning.Bands.Clear()
        GVDisplayPlanning.Columns.Clear()

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

            GVDisplayPlanning.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If data.Columns(j).Caption = "GROUP INFO|DIVISION" Or data.Columns(j).Caption = "GROUP INFO|CATEGORY" Then
                        col.Group()
                    End If

                    If Not bandName.Contains("INFO") Then
                        'display format
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n1}"

                        'summary
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        col.SummaryItem.DisplayFormat = "{0:n1}"


                        'group summary
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.DisplayFormat = "{0:N1}"
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        GVDisplayPlanning.GroupSummary.Add(summary)
                    End If
                End If
            Next
        Next
        GVDisplayPlanning.Columns("GROUP INFO|id_class_group").Visible = False
        GVDisplayPlanning.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewRencanaSKU()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat season/del")
        Dim qs As String = "SELECT dps.id_display_pps_season, 
        IF(ISNULL(ss.id_season), 'EXTRA SKU', CONCAT(ss.season,' D',sd.delivery)) AS `season_del`,
        dps.id_display_season_type, UPPER(dst.display_season_type) AS `display_season_type`, dps.is_extra_sku
        FROM tb_display_pps_season dps 
        LEFT JOIN tb_season ss ON ss.id_season = dps.id_season
        LEFT JOIN tb_season_delivery sd ON sd.id_delivery = dps.id_delivery
        INNER JOIN tb_display_season_type dst ON dst.id_display_season_type = dps.id_display_season_type
        WHERE dps.id_display_pps=" + id + "
        ORDER BY sd.delivery_date "
        Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
        Dim ds_filter As DataRow() = ds.Select("[is_extra_sku]=1")
        Dim id_extra_sku = ds_filter(0)("id_display_pps_season").ToString

        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat rencana SKU")
        Dim query As String = "SELECT cg.class_group AS `GROUP INFO|CLASS`,cg.id_division AS `GROUP INFO|id_division`,dv.code_detail_name AS `GROUP INFO|DIVISION`,cg.id_class_cat AS `GROUP INFO|id_class_cat`, cc.class_cat AS `GROUP INFO|CATEGORY`, "
        For c As Integer = 0 To ds.Rows.Count - 1
            query += "IFNULL(SUM(CASE WHEN a.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN a.total_sku END),0) AS `RENCANA JUMLAH SKU|" + ds.Rows(c)("season_del").ToString + "`, "
        Next
        query += "SUM(total_sku) AS `RENCANA JUMLAH SKU|TOTAL`, "
        For c As Integer = 0 To ds.Rows.Count - 1
            query += "IFNULL(SUM(CASE WHEN a.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN IFNULL(a.total_sku,0) * IFNULL(dph.qty_hanger,0)  END),0) AS `REKAPITULASI JUMLAH DISPLAY/SKU|" + ds.Rows(c)("season_del").ToString + "`, "
        Next
        query += "SUM(IFNULL(total_sku,0) * IFNULL(dph.qty_hanger,0)) AS `REKAPITULASI JUMLAH DISPLAY/SKU|TOTAL`, "
        Dim col_tot_koef As String = ""
        For c As Integer = 0 To ds.Rows.Count - 1
            If c > 0 Then
                col_tot_koef += "+"
            End If
            Dim koef As String = "IFNULL(SUM(CASE WHEN a.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN IFNULL(a.total_sku,0) * IFNULL(dph.qty_hanger,0)  END),0) * IFNULL(SUM(CASE WHEN a.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN (IFNULL(dpk.koef_sold_out,0)/100)  END),0) "
            query += koef + " AS `KOEF. SOLD OUT|" + ds.Rows(c)("season_del").ToString + "`, "
            col_tot_koef += koef
        Next
        query += "(" + col_tot_koef + ") AS `KOEF. SOLD OUT|TOTAL`, "
        query += "IFNULL(dm.qty_avl,0) AS `KALKULASI KAPASITAS DISPLAY|AVAILABLE`,
        (IFNULL(dm.qty_avl,0)-SUM(IFNULL(total_sku,0) * IFNULL(dph.qty_hanger,0))) AS `KALKULASI KAPASITAS DISPLAY|BALANCE`
        FROM (
            -- exist
	        SELECT dpr.id_class_group, dpr.id_season, dpr.id_delivery, COUNT(dpr.id_class_group) AS `total_sku`, IFNULL(dps.id_display_pps_season," + id_extra_sku + ") AS `id_display_pps_season`
	        FROM tb_display_pps_res dpr
	        LEFT JOIN tb_display_pps_season dps ON dps.id_delivery = dpr.id_delivery AND dps.id_display_pps=" + id + "
	        WHERE dpr.id_display_pps=" + id + "
	        GROUP BY dpr.id_class_group, dpr.id_delivery
	        -- current
	        UNION ALL
	        SELECT dpd.id_class_group, dp.id_season, dpd.id_delivery, COUNT(dpd.id_class_group) AS `total_sku`, dps.id_display_pps_season
	        FROM tb_display_pps_det dpd
	        INNER JOIN tb_display_pps dp ON dp.id_display_pps = dpd.id_display_pps
	        INNER JOIN tb_display_pps_season dps ON dps.id_delivery = dpd.id_delivery AND dps.id_display_pps=" + id + "
	        WHERE dpd.id_display_pps=" + id + " AND dpd.is_selected=1
	        GROUP BY dpd.id_class_group, dpd.id_delivery
	        -- plan
	        UNION ALL
	        SELECT dpp.id_class_group, dpp.id_season, dpp.id_delivery, dpp.qty_sku AS `total_sku`, dps.id_display_pps_season
	        FROM tb_display_pps_plan dpp
	        INNER JOIN tb_display_pps_season dps ON dps.id_delivery = dpp.id_delivery AND dps.id_display_pps=" + id + "
	        WHERE dpp.id_display_pps=" + id + "
        ) a
        INNER JOIN tb_class_group cg ON cg.id_class_group = a.id_class_group
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        LEFT JOIN tb_display_pps_hanger dph ON dph.id_class_group = a.id_class_group AND dph.id_display_pps_season = a.id_display_pps_season AND dph.id_display_pps=" + id + "
        LEFT JOIN tb_display_pps_koef dpk ON dpk.id_class_group = a.id_class_group AND dpk.id_display_pps_season = a.id_display_pps_season AND dpk.id_display_pps=" + id + "
        LEFT JOIN (
            SELECT dps.id_class_group, SUM(dps.qty * dps.capacity) AS `qty_avl` 
            FROM tb_display_pps_store dps
            WHERE dps.id_display_pps=" + id + "
            GROUP BY dps.id_class_group
        ) dm ON dm.id_class_group = cg.id_class_group
        GROUP BY a.id_class_group
        ORDER BY dv.code_detail_name ASC, cc.class_cat ASC,class_group ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRencanaSKU.DataSource = data

        FormMain.SplashScreenManager1.SetWaitFormDescription("Atur kolom")
        'clear band
        GVRencanaSKU.Bands.Clear()
        GVRencanaSKU.Columns.Clear()

        'array kolom
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next

        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            If column(i) = "KALKULASI KAPASITAS DISPLAY" Then
                band.Caption = "BALANCE"
            Else
                band.Caption = column(i)
            End If


            GVRencanaSKU.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If data.Columns(j).Caption = "GROUP INFO|DIVISION" Or data.Columns(j).Caption = "GROUP INFO|CATEGORY" Then
                        col.Group()
                    End If

                    If Not bandName.Contains("INFO") Then
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
                        GVRencanaSKU.GroupSummary.Add(summary)
                    ElseIf coluName = "CATEGORY" Then
                        'summary custom footer
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        col.SummaryItem.Tag = "foot"

                        'group footer
                        Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                        summary.FieldName = data.Columns(j).Caption
                        summary.ShowInGroupColumnFooter = col
                        summary.SummaryType = DevExpress.Data.SummaryItemType.Custom
                        summary.Tag = "footgroup"
                        GVRencanaSKU.GroupSummary.Add(summary)
                    End If
                End If
            Next
        Next
        GVRencanaSKU.Columns("GROUP INFO|id_division").Visible = False
        GVRencanaSKU.Columns("GROUP INFO|id_class_cat").Visible = False
        GVRencanaSKU.BestFitColumns()

        FormMain.SplashScreenManager1.SetWaitFormDescription("Prepare summary by category")
        Dim qsum As String = "SELECT cg.id_division, dv.code_detail_name AS `division`,
        cg.id_class_cat, cc.class_cat, 0 AS `avl_qty`, 0 AS `occ_qty`
        FROM (
	        -- exist
	        SELECT dpr.id_class_group
	        FROM tb_display_pps_res dpr
	        WHERE dpr.id_display_pps=" + id + "
	        GROUP BY dpr.id_class_group
	        -- current
	        UNION ALL
	        SELECT dpd.id_class_group
	        FROM tb_display_pps_det dpd
	        WHERE dpd.id_display_pps=" + id + " AND dpd.is_selected=1
	        GROUP BY dpd.id_class_group
	        -- plan
	        UNION ALL
	        SELECT dpp.id_class_group
	        FROM tb_display_pps_plan dpp
	        WHERE dpp.id_display_pps=" + id + "
        ) a
        INNER JOIN tb_class_group cg ON cg.id_class_group = a.id_class_group
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        GROUP BY cg.id_division, cg.id_class_cat
        ORDER BY dv.code_detail_name ASC, cc.class_cat ASC "
        Dim dsum As DataTable = execute_query(qsum, -1, True, "", "", "", "")
        GCCalculateCategory.DataSource = dsum
        GVCalculateCategory.BestFitColumns()
        For s As Integer = 0 To (GVCalculateCategory.RowCount - 1) - GetGroupRowCount(GVCalculateCategory)
            FormMain.SplashScreenManager1.SetWaitFormDescription("kalkulasi " + (s + 1).ToString + "/" + GVCalculateCategory.RowCount.ToString)
            Dim id_division_selected As String = GVCalculateCategory.GetRowCellValue(s, "id_division").ToString
            Dim id_class_cat_selected As String = GVCalculateCategory.GetRowCellValue(s, "id_class_cat").ToString
            GVRencanaSKU.ActiveFilterString = "[GROUP INFO|id_division]='" + id_division_selected + "' AND [GROUP INFO|id_class_cat]='" + id_class_cat_selected + "' "
            Dim avl As Integer = 0
            Try
                avl = GVRencanaSKU.Columns("KALKULASI KAPASITAS DISPLAY|AVAILABLE").SummaryItem.SummaryValue
            Catch ex As Exception
                avl = 0
            End Try
            Dim occ As Integer = 0
            Try
                occ = GVRencanaSKU.Columns("REKAPITULASI JUMLAH DISPLAY/SKU|TOTAL").SummaryItem.SummaryValue
            Catch ex As Exception
                occ = 0
            End Try
            GVCalculateCategory.SetRowCellValue(s, "avl_qty", avl)
            GVCalculateCategory.SetRowCellValue(s, "occ_qty", occ)
        Next
        GVRencanaSKU.ActiveFilterString = ""
        GCCalculateCategory.RefreshDataSource()
        GVCalculateCategory.RefreshData()

        FormMain.SplashScreenManager1.CloseWaitForm()

        If Not isValidDisplay() Then
            stopCustom("Beberapa kategori produk berstatus over display, cek detailnya pada bagian 'summary by category'")
        End If
        Cursor = Cursors.Default
    End Sub

    Function isValidDisplay() As Boolean
        GVCalculateCategory.ActiveFilterString = "[is_over]=1"
        Dim cond As Boolean
        If GVCalculateCategory.RowCount > 0 Then
            cond = False
        Else
            cond = True
        End If
        GVCalculateCategory.ActiveFilterString = ""
        Return cond
    End Function

    Sub viewSetupHanger()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat hanger per season/del")
        Dim qs As String = "SELECT dps.id_display_pps_season, 
        IF(ISNULL(ss.id_season), 'EXTRA SKU', CONCAT(ss.season,' D',sd.delivery)) AS `season_del`,
        dps.id_display_season_type, UPPER(dst.display_season_type) AS `display_season_type`, dps.is_extra_sku
        FROM tb_display_pps_season dps 
        LEFT JOIN tb_season ss ON ss.id_season = dps.id_season
        LEFT JOIN tb_season_delivery sd ON sd.id_delivery = dps.id_delivery
        INNER JOIN tb_display_season_type dst ON dst.id_display_season_type = dps.id_display_season_type
        WHERE dps.id_display_pps=" + id + "
        ORDER BY sd.delivery_date "
        Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")


        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat pengaturan hanger")
        Dim query As String = "SELECT cg.id_division, cg.id_class_cat,dv.code_detail_name AS `Division`,cc.class_cat AS `Category`, "
        For c As Integer = 0 To ds.Rows.Count - 1
            query += "IFNULL(MAX(CASE WHEN dph.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN dph.qty_hanger END),0) AS `" + ds.Rows(c)("season_del").ToString + "`, "
        Next
        query += "'' AS `note`
        From tb_display_pps_hanger dph
        INNER JOIN tb_class_group cg ON cg.id_class_group = dph.id_class_group
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        WHERE dph.id_display_pps=" + id + "
        GROUP BY cg.id_division, cg.id_class_cat
        ORDER BY Division ASC, Category ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSetupHanger.DataSource = data
        GVSetupHanger.Columns("id_division").Visible = False
        GVSetupHanger.Columns("id_class_cat").Visible = False
        GVSetupHanger.Columns("note").Visible = False
        GVSetupHanger.Columns("Division").GroupIndex = 0
        GVSetupHanger.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewRekapDisplay()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat rekapitulasi jumlah display")
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim is_show_all As String = ""
        If is_confirm = "1" Then
            is_show_all = "2"
        Else
            is_show_all = "1"
        End If
        Dim query As String = "CALL view_display_pps(" + id + ", " + is_show_all + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLESeason.Enabled = False
        SLEComp.Enabled = False
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVDetail.OptionsBehavior.ReadOnly = False
            PanelControlSetupHanger.Visible = True
            BtnConfirmOrder.Visible = True
            BtnAddPlan.Visible = True
            BtnDeletePlan.Visible = True
            BtnAddHanger.Visible = True
            BtnDeleteHanger.Visible = True
            BtnAddKSO.Visible = True
            BtnDeleteKSO.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVDetail.OptionsBehavior.ReadOnly = True
            PanelControlSetupHanger.Visible = False
            BtnConfirmOrder.Visible = False
            BtnAddPlan.Visible = False
            BtnDeletePlan.Visible = False
            BtnAddHanger.Visible = False
            BtnDeleteHanger.Visible = False
            BtnAddKSO.Visible = False
            BtnDeleteKSO.Visible = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVDetail.OptionsBehavior.ReadOnly = True
            PanelControlSetupHanger.Visible = False
            BtnConfirmOrder.Visible = False
            BtnAddPlan.Visible = False
            BtnDeletePlan.Visible = False
            BtnAddHanger.Visible = False
            BtnDeleteHanger.Visible = False
            BtnAddKSO.Visible = False
            BtnDeleteKSO.Visible = False
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVDetail)

        If Not isValidDisplay() Then
            stopCustom("Beberapa kategori produk berstatus over display, cek detailnya pada bagian 'summary by category'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_display_pps SET is_confirm=1 WHERE id_display_pps='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        'head
        saveHead()

        'view
        refreshMainview()
        actionLoad()
        infoCustom("Save success")
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        'reset propose
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=3 
        AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_display_pps SET is_confirm=2,id_report_status=1 WHERE id_display_pps=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                refreshMainview()
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_display_pps SET id_report_status=5 WHERE id_display_pps='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            refreshMainview()
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        'copy stream
        Dim strmain As System.IO.Stream = New System.IO.MemoryStream()
        GVRencanaSKU.SaveLayoutToStream(strmain, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        strmain.Seek(0, System.IO.SeekOrigin.Begin)

        'loop band
        For i As Integer = 0 To GVRencanaSKU.Bands.VisibleBandCount - 1
            Try
                If GVRencanaSKU.Bands.GetVisibleBand(i).Caption.ToString = "KOEF. SOLD OUT" Then
                    GVRencanaSKU.Bands.GetVisibleBand(i).Visible = False
                End If
            Catch ex As Exception

            End Try

        Next i

        GVRencanaSKU.ActiveFilterString = ""
        GVRencanaSKU.BestFitColumns()
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        gv = GVRencanaSKU
        ReportStoreDisplay.dt = GCRencanaSKU.DataSource
        ReportStoreDisplay.id = id
        If id_report_status <> "6" Then
            ReportStoreDisplay.is_pre = "1"
        Else
            ReportStoreDisplay.is_pre = "-1"
        End If
        ReportStoreDisplay.id_report_status = LEReportStatus.EditValue.ToString
        ReportStoreDisplay.rmt = rmt
        Dim Report As New ReportStoreDisplay()

        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVRencanaSKU.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        Report.GVRencanaSKU.OptionsPrint.UsePrintStyles = True
        Report.GVRencanaSKU.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        Report.GVRencanaSKU.AppearancePrint.FilterPanel.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        Report.GVRencanaSKU.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        Report.GVRencanaSKU.AppearancePrint.GroupFooter.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVRencanaSKU.AppearancePrint.GroupRow.BackColor = Color.Transparent
        Report.GVRencanaSKU.AppearancePrint.GroupRow.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVRencanaSKU.AppearancePrint.BandPanel.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.BandPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVRencanaSKU.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        Report.GVRencanaSKU.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        Report.GVRencanaSKU.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        Report.GVRencanaSKU.AppearancePrint.FooterPanel.ForeColor = Color.Black
        Report.GVRencanaSKU.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        Report.GVRencanaSKU.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        Report.GVRencanaSKU.OptionsPrint.ExpandAllDetails = True
        Report.GVRencanaSKU.OptionsPrint.UsePrintStyles = True
        Report.GVRencanaSKU.OptionsPrint.PrintDetails = True
        Report.GVRencanaSKU.OptionsPrint.PrintFooter = True

        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelSeason.Text = SLESeason.Text.ToUpper
        Report.LabelStore.Text = SLEComp.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToUpper
        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        Report.LNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        'paste stream
        GVRencanaSKU.RestoreLayoutFromStream(strmain, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        strmain.Seek(0, System.IO.SeekOrigin.Begin)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub saveDetail()
        If action = "upd" And is_confirm = "2" Then
            'update
            GVDetail.ApplyFindFilter("")
            GVDetail.ActiveFilterString = ""
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            GVDetail.ActiveFilterString = "[id_display_pps_det]>0 AND [is_selected]<>[is_selected_new]  "
            For u As Integer = 0 To (GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Update Detail " + (u + 1).ToString + "/" + GVDetail.RowCount.ToString)
                Dim id_display_pps_det As String = GVDetail.GetRowCellValue(u, "id_display_pps_det").ToString
                Dim is_selected As String = GVDetail.GetRowCellValue(u, "is_selected_new").ToString
                Dim qupd As String = "UPDATE tb_display_pps_det SET is_selected='" + is_selected + "'
                WHERE id_display_pps_det='" + id_display_pps_det + "'"
                execute_non_query_long(qupd, True, "", "", "", "")
                Cursor = Cursors.Default
            Next
            GVDetail.ActiveFilterString = ""
            FormMain.SplashScreenManager1.CloseWaitForm()

            'insert
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            GVDetail.ActiveFilterString = "[id_display_pps_det]=0 AND [is_selected_new]=1 "
            Dim qins As String = "INSERT INTO tb_display_pps_det(id_display_pps, id_design, is_selected, id_display_pps_ref, pps_ref_number, id_class_group, id_delivery) VALUES "
            For i As Integer = 0 To (GVDetail.RowCount - 1) - GetGroupRowCount(GVDetail)
                Cursor = Cursors.WaitCursor
                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing new detail " + (i + 1).ToString + "/" + GVDetail.RowCount.ToString)
                Dim id_design As String = GVDetail.GetRowCellValue(i, "id_design").ToString
                Dim is_selected As String = GVDetail.GetRowCellValue(i, "is_selected_new").ToString
                Dim id_display_pps_ref As String = GVDetail.GetRowCellValue(i, "id_display_pps_ref").ToString
                If id_display_pps_ref = "0" Then
                    id_display_pps_ref = "NULL"
                End If
                Dim pps_ref_number As String = GVDetail.GetRowCellValue(i, "pps_ref_number").ToString
                Dim id_class_group As String = GVDetail.GetRowCellValue(i, "id_class_group").ToString
                Dim id_delivery As String = GVDetail.GetRowCellValue(i, "id_delivery").ToString
                If i > 0 Then
                    qins += ","
                End If
                qins += "('" + id + "', '" + id_design + "', '" + is_selected + "', " + id_display_pps_ref + ", '" + pps_ref_number + "', '" + id_class_group + "', '" + id_delivery + "') "
                Cursor = Cursors.Default
            Next
            If GVDetail.RowCount > 0 Then
                FormMain.SplashScreenManager1.SetWaitFormDescription("Bulk insert")
                execute_non_query_long(qins, True, "", "", "", "")
            End If
            GVDetail.ActiveFilterString = ""
            FormMain.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        If action = "ins" Then
            Try
                DEInStoreDate.EditValue = SLESeason.Properties.View.GetFocusedRowCellValue("in_store_date")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BtnDisplayPlan_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnSummaryRencanaSKU_Click(sender As Object, e As EventArgs) Handles BtnSummaryRencanaSKU.Click
        XTPSummaryRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 0
        XTPPlanlRencanaSKU.PageEnabled = False
        viewRencanaSKU()
    End Sub

    'Sub saveDetailSeason()
    '    If action = "upd" And is_confirm = "2" Then
    '        Cursor = Cursors.WaitCursor
    '        makeSafeGV(GVSeason)
    '        For i As Integer = 0 To GVSeason.RowCount - 1
    '            Dim id_display_pps_season As String = GVSeason.GetRowCellValue(i, "id_display_pps_season").ToString
    '            Dim koef_sold_out As String = decimalSQL(GVSeason.GetRowCellValue(i, "koef_sold_out").ToString)
    '            Dim query As String = "UPDATE tb_display_pps_season SET koef_sold_out='" + koef_sold_out + "' WHERE id_display_pps_season='" + id_display_pps_season + "' "
    '            execute_non_query(query, True, "", "", "", "")
    '        Next
    '        Cursor = Cursors.Default
    '    End If
    'End Sub

    Sub viewPlan()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dpp.id_display_pps_plan, dpp.id_display_pps, dpp.id_season, dpp.id_delivery, CONCAT(ss.season, ' ', 'D',sd.delivery) AS `season_del`, 
        dpp.id_class_group, cg.class_group, dv.display_name AS `division`, ct.class_type, cc.class_cat, dpp.qty_sku 
        FROM tb_display_pps_plan dpp
        INNER JOIN tb_season ss ON ss.id_season = dpp.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = dpp.id_delivery
        INNER JOIN tb_class_group cg ON cg.id_class_group = dpp.id_class_group AND cg.is_active=1
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        INNER JOIN tb_class_type ct ON ct.id_class_type = cg.id_class_type
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        WHERE dpp.id_display_pps=" + id + "
        ORDER BY season ASC, division ASC, class_cat ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPlan.DataSource = data
        GVPlan.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeletePlan_Click(sender As Object, e As EventArgs) Handles BtnDeletePlan.Click
        If GVPlan.RowCount > 0 And GVPlan.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_display_pps_plan As String = GVPlan.GetFocusedRowCellValue("id_display_pps_plan").ToString
                Dim query As String = "DELETE FROM tb_display_pps_plan WHERE id_display_pps_plan='" + id_display_pps_plan + "' "
                execute_non_query(query, True, "", "", "", "")
                viewPlan()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddPlan_Click(sender As Object, e As EventArgs) Handles BtnAddPlan.Click
        Cursor = Cursors.WaitCursor
        FormStoreDisplayAddPlan.id_trans = id
        FormStoreDisplayAddPlan.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCurrSeasonOrder_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnSOBackToSummary_Click(sender As Object, e As EventArgs) Handles BtnSOBackToSummary.Click
        'save changes detail
        If is_confirm = "2" Then
            Dim res As String = isValidDetail()
            If res = "valid" Then
                saveDetail()
            Else
                warningCustom(res)
                Exit Sub
            End If
        End If

        'back to summary
        XTPSummaryRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 0
        XTPCurrSeasonOrder.PageEnabled = False
        viewRencanaSKU()
    End Sub

    Sub viewExisting()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT dpr.id_display_pps_res, dpr.id_display_pps, 
        dpr.id_season, dpr.id_delivery, CONCAT(ss.season,' D',sd.delivery) AS `season_del`,
        dpr.id_class_group, cg.class_group, 
        dpr.id_design, d.design_code AS `code`, cd.class, d.design_display_name AS `name`, cd.sht, cd.color
        FROM tb_display_pps_res dpr
        INNER JOIN tb_season ss ON ss.id_season = dpr.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = dpr.id_delivery
        INNER JOIN tb_class_group cg ON cg.id_class_group = dpr.id_class_group
        INNER JOIN tb_m_design d ON d.id_design = dpr.id_design
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
        WHERE dpr.id_display_pps=" + id + "
        ORDER BY season_del ASC, class ASC, `name` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCExisting.DataSource = data
        GVExisting.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExistingDisplay_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnExistingBackToSummary_Click(sender As Object, e As EventArgs) Handles BtnExistingBackToSummary.Click
        XTPSummaryRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 0
        XTPExisting.PageEnabled = False
        viewRencanaSKU()
    End Sub

    Private Sub BtnConfirmOrder_Click(sender As Object, e As EventArgs) Handles BtnConfirmOrder.Click
        Dim res As String = isValidDetail()
        If res = "valid" Then
            saveDetail()
            viewDetail()
        Else
            warningCustom(res)
        End If
    End Sub

    Function isValidDetail() As String
        'cek drop
        Dim cond_no_drop As Boolean = False
        GVDetail.ActiveFilterString = "[is_selected_view]='Yes' AND [id_lookup_status_order]='2' "
        If GVDetail.RowCount <= 0 Then
            cond_no_drop = True
        Else
            cond_no_drop = False
        End If
        GVDetail.ActiveFilterString = ""

        'cek class group
        Dim cond_no_class_group = False
        GVDetail.ActiveFilterString = "[is_selected_view]='Yes' AND [id_class_group]='0' "
        If GVDetail.RowCount <= 0 Then
            cond_no_class_group = True
        Else
            cond_no_class_group = False
        End If
        GVDetail.ActiveFilterString = ""

        'res
        If cond_no_drop And cond_no_class_group Then
            Return "valid"
        ElseIf Not cond_no_drop Then
            Return "Produk dengan status 'Drop' tidak bisa diproses."
        ElseIf Not cond_no_class_group Then
            Return "Beberapa class tidak ditemukan, pastikan master toko sudah di setup untuk semua class produk yang dipilih."
        Else
            Return "Not valid"
        End If
    End Function

    Private Sub BtnRefreshRencanaSKU_Click(sender As Object, e As EventArgs) Handles BtnRefreshRencanaSKU.Click
        viewRencanaSKU()
    End Sub

    Private Sub BtnAddHanger_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BBICurrentSeason_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBICurrentSeason.ItemClick
        Cursor = Cursors.WaitCursor
        GVDetail.ActiveFilterString = ""
        GVDetail.ApplyFindFilter("")
        XTPCurrSeasonOrder.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 1
        XTPSummaryRencanaSKU.PageEnabled = False
        viewDetail()
        Cursor = Cursors.Default
    End Sub

    Private Sub BBIExisting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIExisting.ItemClick
        Cursor = Cursors.WaitCursor
        GVExisting.ActiveFilterString = ""
        GVExisting.ApplyFindFilter("")
        XTPExisting.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 2
        XTPSummaryRencanaSKU.PageEnabled = False
        viewExisting()
        Cursor = Cursors.Default
    End Sub

    Private Sub BBIPlan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIPlan.ItemClick
        Cursor = Cursors.WaitCursor
        GVPlan.ActiveFilterString = ""
        GVPlan.ApplyFindFilter("")
        XTPPlanlRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 3
        XTPSummaryRencanaSKU.PageEnabled = False
        viewPlan()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSetupHanger_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnDeleteHanger_Click(sender As Object, e As EventArgs) Handles BtnDeleteHanger.Click
        If GVSetupHanger.RowCount > 0 And GVSetupHanger.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this setup hanger ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_division As String = GVSetupHanger.GetFocusedRowCellValue("id_division").ToString
                Dim id_class_cat As String = GVSetupHanger.GetFocusedRowCellValue("id_class_cat").ToString
                Dim query As String = "DELETE FROM tb_display_pps_hanger WHERE id_display_pps='" + id + "' AND id_division='" + id_division + "' AND id_class_cat='" + id_class_cat + "' "
                execute_non_query(query, True, "", "", "", "")
                viewSetupHanger()
                viewRekapDisplay()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddHanger_Click_1(sender As Object, e As EventArgs) Handles BtnAddHanger.Click
        Cursor = Cursors.WaitCursor
        FormStoreDisplayHanger.id_display_pps = id
        FormStoreDisplayHanger.id_comp = SLEComp.EditValue.ToString
        FormStoreDisplayHanger.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSetupHangerSummary_Click(sender As Object, e As EventArgs) Handles BtnSetupHangerSummary.Click
        XTPSummaryRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 0
        XTPSetupHanger.PageEnabled = False
        viewRencanaSKU()
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl3.Paint

    End Sub

    Private Sub BtnSetupHanger_Click_1(sender As Object, e As EventArgs) Handles BtnSetupHanger.Click
        Cursor = Cursors.WaitCursor
        GVSetupHanger.ActiveFilterString = ""
        GVSetupHanger.ApplyFindFilter("")
        XTPSetupHanger.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 4
        XTPSummaryRencanaSKU.PageEnabled = False
        viewSetupHanger()
        Cursor = Cursors.Default
    End Sub

    Dim footgroup_cat As String = ""
    Dim footgroup_div As String = ""
    Private Sub GVRencanaSKU_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVRencanaSKU.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            footgroup_cat = ""
            footgroup_div = ""
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cat As String = View.GetRowCellValue(e.RowHandle, "GROUP INFO|CATEGORY").ToString
            Dim division As String = View.GetRowCellValue(e.RowHandle, "GROUP INFO|DIVISION").ToString
            Select Case summaryID
                Case "footgroup"
                    footgroup_cat = cat
                    footgroup_div = division
            End Select
        End If


        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "foot" 'total summary estimate
                    e.TotalValue = "TOTAL"
                Case "footgroup" 'group summary  cat
                    If e.GroupLevel.ToString = "1" Then
                        e.TotalValue = "SUB TOTAL " + footgroup_div.ToUpper + " " + footgroup_cat.ToUpper
                    Else
                        e.TotalValue = "SUB TOTAL " + footgroup_div.ToUpper
                    End If
            End Select
        End If
    End Sub

    Private Sub BtnAddKSO_Click(sender As Object, e As EventArgs) Handles BtnAddKSO.Click
        Cursor = Cursors.WaitCursor
        FormStoreDisplayKSO.id_display_pps = id
        FormStoreDisplayKSO.id_comp = SLEComp.EditValue.ToString
        FormStoreDisplayKSO.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewSetupKSO()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat koef. sold out per season/del")
        Dim qs As String = "SELECT dps.id_display_pps_season, 
        IF(ISNULL(ss.id_season), 'EXTRA SKU', CONCAT(ss.season,' D',sd.delivery)) AS `season_del`,
        dps.id_display_season_type, UPPER(dst.display_season_type) AS `display_season_type`, dps.is_extra_sku
        FROM tb_display_pps_season dps 
        LEFT JOIN tb_season ss ON ss.id_season = dps.id_season
        LEFT JOIN tb_season_delivery sd ON sd.id_delivery = dps.id_delivery
        INNER JOIN tb_display_season_type dst ON dst.id_display_season_type = dps.id_display_season_type
        WHERE dps.id_display_pps=" + id + "
        ORDER BY sd.delivery_date "
        Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")


        FormMain.SplashScreenManager1.SetWaitFormDescription("Memuat pengaturan koef. sold out")
        Dim query As String = "SELECT cg.id_division, cg.id_class_cat,dv.code_detail_name AS `Division`,cc.class_cat AS `Category`, "
        For c As Integer = 0 To ds.Rows.Count - 1
            query += "IFNULL(MAX(CASE WHEN dph.id_display_pps_season=" + ds.Rows(c)("id_display_pps_season").ToString + " THEN dph.koef_sold_out END),0) AS `" + ds.Rows(c)("season_del").ToString + "`, "
        Next
        query += "'' AS `note`
        From tb_display_pps_koef dph
        INNER JOIN tb_class_group cg ON cg.id_class_group = dph.id_class_group
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        WHERE dph.id_display_pps=" + id + "
        GROUP BY cg.id_division, cg.id_class_cat
        ORDER BY Division ASC, Category ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKoefSoldOut.DataSource = data
        GVKoefSoldOut.Columns("id_division").Visible = False
        GVKoefSoldOut.Columns("id_class_cat").Visible = False
        GVKoefSoldOut.Columns("note").Visible = False
        GVKoefSoldOut.Columns("Division").GroupIndex = 0
        GVKoefSoldOut.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteKSO_Click(sender As Object, e As EventArgs) Handles BtnDeleteKSO.Click
        If GVKoefSoldOut.RowCount > 0 And GVKoefSoldOut.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this setup ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_division As String = GVKoefSoldOut.GetFocusedRowCellValue("id_division").ToString
                Dim id_class_cat As String = GVKoefSoldOut.GetFocusedRowCellValue("id_class_cat").ToString
                Dim query As String = "DELETE FROM tb_display_pps_koef WHERE id_display_pps='" + id + "' AND id_division='" + id_division + "' AND id_class_cat='" + id_class_cat + "' "
                execute_non_query(query, True, "", "", "", "")
                viewSetupKSO()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSetKoef_Click(sender As Object, e As EventArgs) Handles BtnSetKoef.Click
        Cursor = Cursors.WaitCursor
        GVKoefSoldOut.ActiveFilterString = ""
        GVKoefSoldOut.ApplyFindFilter("")
        XTPKoefSoldOut.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 5
        XTPSummaryRencanaSKU.PageEnabled = False
        viewSetupKSO()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnKSOSummary_Click(sender As Object, e As EventArgs) Handles BtnKSOSummary.Click
        XTPSummaryRencanaSKU.PageEnabled = True
        XTCRencanaSKU.SelectedTabPageIndex = 0
        XTPKoefSoldOut.PageEnabled = False
        viewRencanaSKU()
    End Sub

    Private Sub IterateBandColumns(ByVal band As DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        If band.Children.Count > 0 Then 'a parent band  
            For Each childBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In band.Children
                IterateBandColumns(childBand)
            Next childBand
        Else 'the bottommost band with columns  
            For Each column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In band.Columns
                Console.WriteLine(column.Caption)
            Next column
        End If
    End Sub
End Class