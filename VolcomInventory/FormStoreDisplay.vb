Public Class FormStoreDisplay
    Public is_load_new As Boolean = False
    Dim is_view_detail_art As Boolean = False

    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_season`, 999 as `range`, 'All Season' AS `season`
        UNION ALL
        SELECT ss.id_season, rg.`range`, ss.season 
        FROM tb_season ss 
        INNER JOIN tb_range rg ON rg.id_range = ss.id_range
        WHERE rg.is_md=1
        ORDER BY `range` DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        Cursor = Cursors.Default
    End Sub

    Sub viewComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT 0 AS `id_comp`, '- All Store -' AS `comp`) 
        UNION ALL
        (SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        WHERE c.id_comp_cat=6 
        ORDER BY c.comp_number ASC) "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub viewCompSpesific()
        Cursor = Cursors.WaitCursor
        Dim query As String = "(SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        WHERE c.id_comp_cat=6 
        ORDER BY c.comp_number ASC) "
        viewSearchLookupQuery(SLEStoreView, query, "id_comp", "comp", "id_comp")
        viewSearchLookupQuery(SLEStoreArt, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStoreDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewComp()
        viewCompSpesific()

        'date
        Dim dtnow As DateTime = getTimeDB()
        DEDisplayDate.EditValue = dtnow
        DEDateArt.EditValue = dtnow
    End Sub

    Private Sub FormStoreDisplay_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormStoreDisplay_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormStoreDisplay_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPps()
    End Sub

    Sub viewPps()
        Cursor = Cursors.WaitCursor

        'cond
        Dim cond As String = ""
        Dim id_season As String = SLESeason.EditValue.ToString
        If id_season <> "0" Then
            cond += "AND p.id_season='" + id_season + "' "
        End If
        Dim id_comp As String = SLEComp.EditValue.ToString
        If id_comp <> "0" Then
            cond += "AND p.id_comp='" + id_comp + "' "
        End If

        Dim sd As New ClassStoreDisplay()
        Dim query As String = sd.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPPS.DataSource = data
        GVPPS.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCPPS, "Propose List : Store Display")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        FormStoreDisplayDet.action = "ins"
        FormStoreDisplayDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailPps()
        If GVPPS.RowCount > 0 And GVPPS.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormStoreDisplayDet.action = "upd"
            FormStoreDisplayDet.id = GVPPS.GetFocusedRowCellValue("id_display_pps").ToString
            FormStoreDisplayDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVPPS.DoubleClick
        If GVPPS.RowCount > 0 And GVPPS.FocusedRowHandle >= 0 Then
            viewDetailPps()
        End If
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetailPps()
        End If
    End Sub

    Private Sub BtnDisplayCapacity_Click(sender As Object, e As EventArgs) Handles BtnDisplayCapacity.Click
        Cursor = Cursors.WaitCursor
        FormDisplayAlloc.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewStoreDisplay_Click(sender As Object, e As EventArgs) Handles BtnViewStoreDisplay.Click
        viewStoreDisplay()
    End Sub

    Sub viewStoreDisplay()
        Cursor = Cursors.WaitCursor

        'option
        Dim id_store As String = SLEStoreView.EditValue.ToString
        Dim date_par As String = DateTime.Parse(DEDisplayDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim is_show_season As String = ""
        If CEBreakdownSeason.EditValue = True Then
            is_show_season = "1"
        Else
            is_show_season = "2"
        End If
        Dim csd As New ClassStoreDisplay()

        'cek master
        Dim qcm As String = "SELECT * FROM tb_display_master dps WHERE dps.id_comp='" + id_store + "' AND dps.is_active=1 "
        Dim dcm As DataTable = execute_query(qcm, -1, True, "", "", "", "")
        If dcm.Rows.Count <= 0 Then
            Cursor = Cursors.Default
            stopCustom("Master display not available for this store : " + SLEStoreView.Text)
            Exit Sub
        End If

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading display")



        'build query show season
        FormMain.SplashScreenManager1.SetWaitFormDescription("Build query")
        Dim col_ss1 As String = ""
        Dim col_ss2 As String = ""
        Dim col_sku_ss1 As String = ""
        Dim col_sku_ss2 As String = ""
        If is_show_season = "1" Then
            Dim qs As String = "SELECT oc.id_delivery, CONCAT(ss.season,' D',sd.delivery) AS `season_del`
            FROM (
                SELECT ds.id_class_group, ds.id_design, ds.id_delivery, SUM(ds.qty) AS `qty`
                FROM (
                  " + csd.queryBasicDisplay(date_par, id_store) + "
                ) ds
                GROUP BY ds.id_design
                HAVING qty>0 
            ) oc
            INNER JOIN tb_season_delivery sd ON sd.id_delivery = oc.id_delivery
            INNER JOIN tb_season ss ON ss.id_season = sd.id_season
            GROUP BY oc.id_delivery 
            ORDER BY sd.delivery_date ASC "
            Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
            For s As Integer = 0 To ds.Rows.Count - 1
                If s > 0 Then
                    col_ss1 += ","
                    col_ss2 += ","
                    col_sku_ss1 += ","
                    col_sku_ss2 += ","
                End If
                col_ss1 += "SUM(CASE WHEN oc.id_delivery=" + ds.Rows(s)("id_delivery").ToString + " THEN oc.qty END) AS `qty" + ds.Rows(s)("id_delivery").ToString + "` "
                col_ss2 += "IFNULL(oc.qty" + ds.Rows(s)("id_delivery").ToString + ",0) AS `TOTAL OCCUPIED DISPLAY - SEASON DETAIL|" + ds.Rows(s)("season_del").ToString + "` "
                col_sku_ss1 += "COUNT(CASE WHEN oc.id_delivery=" + ds.Rows(s)("id_delivery").ToString + " THEN oc.id_class_group END) AS `jum_sku" + ds.Rows(s)("id_delivery").ToString + "` "
                col_sku_ss2 += "IFNULL(oc.jum_sku" + ds.Rows(s)("id_delivery").ToString + ",0) AS `TOTAL OCCUPIED SKU - SEASON DETAIL|" + ds.Rows(s)("season_del").ToString + "` "
            Next
        End If
        If col_ss1 <> "" Then
            col_ss1 = ", " + col_ss1
        End If
        If col_ss2 <> "" Then
            col_ss2 = ", " + col_ss2
        End If
        If col_sku_ss1 <> "" Then
            col_sku_ss1 = ", " + col_sku_ss1
        End If
        If col_sku_ss2 <> "" Then
            col_sku_ss2 = ", " + col_sku_ss2
        End If

        'build query for display type
        Dim qdt As String = "SELECT dt.id_display_type, dt.display_type 
        FROM tb_display_master dps
        INNER JOIN tb_display_type dt ON dt.id_display_type = dps.id_display_type
        WHERE dps.id_comp=" + id_store + "
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
            IFNULL(SUM(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.qty END),0) * IFNULL(MAX(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN da.capacity END),0) AS `" + ddt.Rows(i)("display_type").ToString + "|CAPACITY` "
            col_tot_capacity += "IFNULL(SUM(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN dps.qty END),0) * IFNULL(MAX(CASE WHEN dps.id_display_type=" + ddt.Rows(i)("id_display_type").ToString + " THEN da.capacity END),0) "
        Next

        Dim cond_par As String = "AND ds.id_comp='" + id_store + "' "
        Dim query As String = "SELECT dps.id_class_group AS `GROUP INFO|id_class_group`, cg.class_group AS `GROUP INFO|CLASS`, dv.display_name AS `GROUP INFO|DIVISION`, cc.class_cat AS `GROUP INFO|CATEGORY`,
        " + coldt + ",
        (" + col_tot_capacity + ") AS `TOTAL|AVAILABLE DISPLAY`, IFNULL(oc.qty,0.00) AS `TOTAL|OCCUPIED DISPLAY`, (" + col_tot_capacity + ")-IFNULL(oc.qty,0.00) AS `TOTAL|BALANCE DISPLAY`, IFNULL(oc.jum_sku,0) AS `TOTAL|OCCUPIED SKU`
         " + col_ss2 + "
        " + col_sku_ss2 + "
        FROM tb_display_master dps
        INNER JOIN tb_display_alloc da ON da.id_display_type = dps.id_display_type AND da.id_class_group = dps.id_class_group
        INNER JOIN tb_class_group cg ON cg.id_class_group = dps.id_class_group
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
        LEFT JOIN (
            SELECT oc.id_class_group, COUNT(oc.id_class_group) AS `jum_sku`, SUM(oc.qty) AS `qty` 
            " + col_ss1 + "
            " + col_sku_ss1 + "
            FROM (
                SELECT ds.id_class_group, ds.id_design, ds.id_delivery, SUM(ds.qty) AS `qty`
                FROM (
                  " + csd.queryBasicDisplay(date_par, id_store) + "
                ) ds
                GROUP BY ds.id_design
                HAVING qty>0 
            ) oc
            GROUP BY oc.id_class_group
        ) oc ON oc.id_class_group = dps.id_class_group
        WHERE dps.id_comp=" + id_store + " AND dps.is_active=1
        GROUP BY dps.id_class_group
        ORDER BY dv.display_name ASC,cc.class_cat, cg.class_group "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDisplay.DataSource = data

        'clear band
        GVDisplay.Bands.Clear()
        GVDisplay.Columns.Clear()

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

            GVDisplay.Bands.Add(band)

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


                    If Not bandName.Contains("INFO") And Not bandName.Contains("ACTION") Then
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
                        GVDisplay.GroupSummary.Add(summary)
                    End If
                End If
            Next
        Next
        'col visible
        GVDisplay.Columns("GROUP INFO|id_class_group").Visible = False
        GVDisplay.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreView_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreView.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCDisplay.DataSource = Nothing
    End Sub

    Private Sub DEDisplayDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEDisplayDate.EditValueChanged
        resetView()
    End Sub

    Private Sub CEBreakdownSeason_EditValueChanged(sender As Object, e As EventArgs) Handles CEBreakdownSeason.EditValueChanged
        resetView()
    End Sub

    Private Sub GVDisplay_Click(sender As Object, e As EventArgs) Handles GVDisplay.Click

    End Sub

    Private Sub ViewOccupiedSKUDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewOccupiedSKUDetailToolStripMenuItem.Click
        If GVDisplay.RowCount > 0 And GVDisplay.FocusedRowHandle >= 0 Then
            is_view_detail_art = True
            SLEStoreArt.EditValue = SLEStoreView.EditValue
            DEDateArt.EditValue = DEDisplayDate.EditValue
            viewArt()
            XTCView.SelectedTabPageIndex = 1
            XTPClassGroup.PageEnabled = False
        End If
    End Sub

    Private Sub BtnPrintStoreDisplay_Click(sender As Object, e As EventArgs) Handles BtnPrintStoreDisplay.Click
        print_raw(GCDisplay, "")
    End Sub

    Private Sub BtnViewArt_Click(sender As Object, e As EventArgs) Handles BtnViewArt.Click
        If is_view_detail_art Then
            XTPClassGroup.PageEnabled = True
            XTCView.SelectedTabPageIndex = 0
            is_view_detail_art = False
        Else
            viewArt()
        End If
    End Sub

    Private Sub XTCView_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCView.SelectedPageChanged
        If XTCView.SelectedTabPageIndex = 1 Then
            If is_view_detail_art Then
                BtnViewArt.Text = "Summary"
                PanelControlArt.Enabled = False
            Else
                GCArt.DataSource = Nothing
                BtnViewArt.Text = "View"
                PanelControlArt.Enabled = True
            End If
        End If
    End Sub

    Sub viewArt()
        Cursor = Cursors.WaitCursor
        'option
        Dim id_store As String = SLEStoreArt.EditValue.ToString
        Dim date_par As String = DateTime.Parse(DEDateArt.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim csd As New ClassStoreDisplay()
        Dim query As String = "SELECT ds.id_class_group, ds.id_design, d.design_code AS `code`, cd.class, d.design_display_name AS `name`, cd.color,
        ds.id_season,ds.id_delivery, CONCAT(ss.season,' D',sd.delivery) AS `season_del`, SUM(ds.qty) AS `qty`
        FROM (
            " + csd.queryBasicDisplay(date_par, id_store) + "
        ) ds
        INNER JOIN tb_m_design d ON d.id_design = ds.id_design
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
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = ds.id_delivery
        INNER JOIN tb_season ss ON ss.id_season = ds.id_season
        WHERE 1=1 "
        If is_view_detail_art Then
            query += "AND ds.id_class_group='" + GVDisplay.GetFocusedRowCellValue("GROUP INFO|id_class_group").ToString + "' "
        End If
        query += "GROUP BY ds.id_design
        HAVING qty>0 
        ORDER BY `season_del` ASC, `class` ASC, `name` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCArt.DataSource = data
        GVArt.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVArt_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVArt.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrintArt_Click(sender As Object, e As EventArgs) Handles BtnPrintArt.Click
        print_raw(GCArt, "")
    End Sub
End Class