Public Class FormStoreDisplay
    Public is_load_new As Boolean = False

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
        Cursor = Cursors.Default
    End Sub

    Private Sub FormStoreDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewComp()
        viewCompSpesific()

        'date
        DEDisplayDate.EditValue = getTimeDB()
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
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading display")

        'date & comp
        Dim id_store As String = SLEStoreView.EditValue.ToString
        Dim date_par As String = DateTime.Parse(DEDisplayDate.EditValue.ToString).ToString("yyyy-MM-dd")


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
        (" + col_tot_capacity + ") AS `TOTAL DISPLAY|AVAILABLE`
        FROM tb_display_master dps
        INNER JOIN tb_display_alloc da ON da.id_display_type = dps.id_display_type AND da.id_class_group = dps.id_class_group
        INNER JOIN tb_class_group cg ON cg.id_class_group = dps.id_class_group
        INNER JOIN tb_class_cat cc ON cc.id_class_cat = cg.id_class_cat
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = cg.id_division
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
                        GVDisplay.GroupSummary.Add(summary)
                    End If
                End If
            Next
        Next
        GVDisplay.Columns("GROUP INFO|id_class_group").Visible = False
        GVDisplay.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub
End Class