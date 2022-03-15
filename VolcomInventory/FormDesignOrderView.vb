Public Class FormDesignOrderView
    Private Sub FormDesignOrderView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewComp()
    End Sub

    Private Sub FormDesignOrderView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Sub viewSeason()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ss.id_season, rg.`range`, ss.season 
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

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim where_string As String = ""
        Dim id_season As String = SLESeason.EditValue.ToString
        If id_season <> "0" Then
            where_string += "AND dp.id_season=" + id_season + " "
        End If
        Dim id_comp As String = SLEComp.EditValue.ToString
        If id_comp <> "0" Then
            where_string += "AND dp.id_comp=" + id_comp + " "
        End If

        'generate column
        Dim qs As String = "SELECT c.id_comp, CONCAT(c.comp_number,' (', c.comp_name,')') AS `comp` 
        FROM tb_display_pps dp 
        INNER JOIN tb_m_comp c ON c.id_comp = dp.id_comp
        WHERE dp.id_report_status!=5 "
        If id_season <> "0" Then
            qs += "AND  dp.id_season=" + id_season + " "
        End If
        If id_comp <> "0" Then
            qs += "AND dp.id_comp=" + id_comp + " "
        End If
        qs += "GROUP BY dp.id_comp
        ORDER BY c.comp_number ASC "
        Dim ds As DataTable = execute_query(qs, -1, True, "", "", "", "")
        Dim col_comp As String = ""
        If ds.Rows.Count > 0 Then
            For s As Integer = 0 To ds.Rows.Count - 1
                If s > 0 Then
                    col_comp += ","
                End If
                col_comp += "IFNULL(COUNT(CASE WHEN dp.id_comp='" + ds.Rows(s)("id_comp").ToString + "' THEN dpd.id_design END),0) AS `" + ds.Rows(s)("comp").ToString + "` "
            Next
        Else
            Cursor = Cursors.Default
            stopCustom("Order is not available for this option")
            Exit Sub
        End If

        Dim query As String = "SELECT d.id_design, d.design_code AS `Code`, cd.class AS `Class`, d.design_display_name AS `Description`, 
        cd.color AS `Color`, cd.sht AS `Silhouette`, ss.season AS `Season`, sd.delivery AS `Del`,
        " + col_comp + ",
        IFNULL(COUNT(dpd.id_design),0) AS `Total Qty`
        FROM tb_display_pps_det dpd
        INNER JOIN tb_display_pps dp ON dp.id_display_pps = dpd.id_display_pps
        INNER JOIN tb_m_design d ON d.id_design = dpd.id_design
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
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        WHERE dp.id_report_status!=5 AND dpd.is_selected=1 
        " + where_string + "
        GROUP BY dpd.id_design
        ORDER BY `Class` ASC, `Description` ASC, `Del` ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        For c As Integer = 0 To data.Columns.Count - 1
            Dim col As String = data.Columns(c).Caption
            Console.WriteLine(col)
            If col.Contains("(") Or col = "Total Qty" Then
                'display format
                GVData.Columns(col).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns(col).DisplayFormat.FormatString = "{0:n0}"

                'summary
                GVData.Columns(col).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVData.Columns(col).SummaryItem.DisplayFormat = "{0:n0}"


                'group summary
                Dim summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem
                summary.DisplayFormat = "{0:N0}"
                summary.FieldName = col
                summary.ShowInGroupColumnFooter = GVData.Columns(col)
                summary.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVData.GroupSummary.Add(summary)
            End If
        Next
        GVData.Columns("id_design").Visible = False
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
        GVData.Columns.Clear()
    End Sub

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        resetView()
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'path = path + "del_" + dt_from + "_" + dt_until + ".xlsx"
            path = path + "order" + SLESeason.Text.Trim + ".xlsx"
            exportToXLS(path, "order" + SLESeason.Text.Trim, GCData)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormDesignOrderView_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDesignOrderView_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class