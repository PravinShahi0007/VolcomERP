Public Class FormCapsule
    Sub view_season()
        Dim query As String = "
            SELECT a.id_season, a.season
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("season").ToString
            c.Value = data.Rows(i)("id_season").ToString

            CCBESeason.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_division()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEDivision.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_class()
        Dim query As String = "
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 30
            ORDER BY `code` ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("code").ToString
            c.Value = data.Rows(i)("id_code_detail").ToString

            CCBEClass.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_category_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_cat`, 'All' AS `cat`
        UNION ALL 
        SELECT 1 AS `id_cat`, 'Wholesale' AS `cat` 
        UNION ALL
        SELECT 2 AS `id_cat`, 'Consignment' AS `cat`
        UNION ALL
        SELECT 3 AS `id_cat`, 'Online' AS `cat`
        UNION ALL
        SELECT 4 AS `id_cat`, 'B&B Wholesale' AS `cat` "
        viewLookupQuery(LECat, query, 0, "cat", "id_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewArea()
        Dim query As String = "
(SELECT a.id_area, a.`area` FROM tb_m_area a )
ORDER BY area ASC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("area").ToString
            c.Value = data.Rows(i)("id_area").ToString

            CCBEArea.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewProvince()
        Dim where As String = ""

        'If Not SLUEIsland.EditValue = "ALL" Then
        '    where = " AND s.id_state IN (SELECT id_state FROM tb_m_city WHERE island = '" + SLUEIsland.EditValue.ToString + "')"
        'End If

        Dim query As String = "
            (SELECT s.id_state AS id_province, s.state AS province
            FROM tb_m_state AS s
            LEFT JOIN tb_m_region AS r ON s.id_region = r.id_region
            WHERE r.id_country = 5" + where + ")
            ORDER BY province ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("province").ToString
            c.Value = data.Rows(i)("id_province").ToString

            CCBEProvince.Properties.Items.Add(c)
        Next
    End Sub

    Sub view_group_store()
        Dim where As String = ""

        Dim query As String = "
            (SELECT id_comp_group, CONCAT(comp_group, ' - ', description) AS comp_group
            FROM tb_m_comp_group
            WHERE 1 " + where + ")
            ORDER BY comp_group ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim c As DevExpress.XtraEditors.Controls.CheckedListBoxItem = New DevExpress.XtraEditors.Controls.CheckedListBoxItem

            c.Description = data.Rows(i)("comp_group").ToString
            c.Value = data.Rows(i)("id_comp_group").ToString

            CCBEGroupStore.Properties.Items.Add(c)
        Next
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        resetView()

        'filter
        Dim where As String = ""
        Dim id_cat As String = ""
        Try
            id_cat = LECat.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_cat = "1" Then
            'wholesale
            where += "AND c.id_comp_group='59' AND c.id_commerce_type='1 ' "
        ElseIf id_cat = "2" Then
            'consingment
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='1' "
        ElseIf id_cat = "3" Then
            'online
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group<>'7' AND c.id_commerce_type='2' "
        ElseIf id_cat = "4" Then
            'b&b wholesale
            where += "AND c.id_comp_group<>'59' AND c.id_comp_group='7' AND c.id_commerce_type='1' "
        Else
            where += ""
        End If
        Dim id_area As String = ""
        Try
            id_area = CCBEArea.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_area <> "" Then
            where += "AND c.id_area IN(" + id_area + ") "
        End If
        Dim id_province As String = ""
        Try
            id_province = CCBEProvince.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_province <> "" Then
            where += "AND cty.id_state IN(" + id_province + ") "
        End If
        Dim id_group_store As String = ""
        Try
            id_group_store = CCBEGroupStore.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_group_store <> "" Then
            where += "AND c.id_comp_group IN(" + id_group_store + ") "
        End If

        'view
        Dim query As String = "SELECT c.id_comp, c.comp_name, c.comp_number, c.id_commerce_type, IFNULL(olc.id_wh_ol,0) AS `id_wh_ol`, 'No' AS `is_select` 
        FROM tb_m_comp c 
        LEFT JOIN (
            SELECT olc.id_store,GROUP_CONCAT(DISTINCT olc.id_wh) AS `id_wh_ol` 
            FROM tb_ol_store_comp olc
            GROUP BY olc.id_store
        ) olc ON olc.id_store = c.id_comp
        INNER JOIN tb_m_city cty ON cty.id_city = c.id_city
        WHERE c.id_comp_cat=6 " + where + " ORDER BY c.comp_number ASC "
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")
        GCStore.DataSource = data
        GVStore.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormCapsule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_season()
        view_division()
        view_class()
        view_category_store()
        viewArea()
        viewProvince()
        view_group_store()
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormCapsule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnExportXLS_Click(sender As Object, e As EventArgs) Handles BtnExportXLS.Click
        Cursor = Cursors.WaitCursor
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            If CheckImg.EditValue = True Then
                op.ExportType = DevExpress.Export.ExportType.WYSIWYG
            Else
                op.ExportType = DevExpress.Export.ExportType.DataAware
            End If

            GVData.ExportToXlsx(save.FileName, op)

            infoCustom("File saved.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If CESelectedProduct.EditValue = True Then
            GVProd.ActiveFilterString = "[is_select]='Yes'"
            Dim jum_row As Integer = GVProd.RowCount
            GVProd.ActiveFilterString = ""
            If jum_row = 0 Then
                warningCustom("Please select product first")
                Exit Sub
            End If
        End If
        If CESelectedStore.EditValue = True Then
            GVStore.ActiveFilterString = "[is_select]='Yes'"
            Dim jum_row As Integer = GVStore.RowCount
            GVStore.ActiveFilterString = ""
            If jum_row = 0 Then
                warningCustom("Please select store first")
                Exit Sub
            End If
        End If

        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        'filter product
        FormMain.SplashScreenManager1.SetWaitFormDescription("Set product filter")
        Dim where_prod As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_prod += " AND d.id_season IN (" + CCBESeason.EditValue.ToString + ")"
        End If
        If Not CCBEDivision.EditValue.ToString = "" Then
            where_prod += " AND cd.id_division IN (" + CCBEDivision.EditValue.ToString + ")"
        End If
        If Not CCBEClass.EditValue.ToString = "" Then
            where_prod += " AND cd.id_class IN (" + CCBEClass.EditValue.ToString + ")"
        End If
        If CESelectedProduct.EditValue = True Then
            Dim id_design_sel As String = ""
            GVProd.ActiveFilterString = "[is_select]='Yes'"
            For i As Integer = 0 To GVProd.RowCount - 1
                If i > 0 Then
                    id_design_sel += ","
                End If
                id_design_sel += GVProd.GetRowCellValue(i, "id_design").ToString
            Next
            GVProd.ActiveFilterString = ""
            where_prod += " AND d.id_design IN (" + id_design_sel + ")"
        End If

        'filter store
        FormMain.SplashScreenManager1.SetWaitFormDescription("Set store filter")
        Dim where As String = ""
        Dim id_cat As String = ""
        Try
            id_cat = LECat.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_cat = "1" Then
            'wholesale
            where += "AND c.id_comp_group=59 AND c.id_commerce_type=1 "
        ElseIf id_cat = "2" Then
            'consingment
            where += "AND c.id_comp_group<>59 AND c.id_comp_group<>7 AND c.id_commerce_type=1 "
        ElseIf id_cat = "3" Then
            'online
            where += "AND c.id_comp_group<>59 AND c.id_comp_group<>7 AND c.id_commerce_type=2 "
        ElseIf id_cat = "4" Then
            'b&b wholesale
            where += "AND c.id_comp_group<>59 AND c.id_comp_group=7 AND c.id_commerce_type=1 "
        Else
            where += ""
        End If
        Dim id_area As String = ""
        Try
            id_area = CCBEArea.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_area <> "" Then
            where += "AND c.id_area IN(" + id_area + ") "
        End If
        Dim id_province As String = ""
        Try
            id_province = CCBEProvince.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_province <> "" Then
            where += "AND cty.id_state IN(" + id_province + ") "
        End If
        Dim id_group_store As String = ""
        Try
            id_group_store = CCBEGroupStore.EditValue.ToString
        Catch ex As Exception

        End Try
        If id_group_store <> "" Then
            where += "AND c.id_comp_group IN(" + id_group_store + ") "
        End If
        If CESelectedStore.EditValue = True Then
            Dim id_store_sel As String = ""
            GVStore.ActiveFilterString = "[is_select]='Yes'"
            For i As Integer = 0 To GVStore.RowCount - 1
                If i > 0 Then
                    id_store_sel += ","
                End If
                id_store_sel += GVStore.GetRowCellValue(i, "id_comp").ToString
            Next
            GVStore.ActiveFilterString = ""
            where_prod += " AND c.id_comp IN (" + id_store_sel + ")"
        End If


        FormMain.SplashScreenManager1.SetWaitFormDescription("Loading data")
        Dim where_all As String = where + where_prod
        Dim soh_date As String = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim query As String = "CALL view_capsule('" + soh_date + "', '" + where_all + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        If CheckImg.EditValue = True Then
            GVData.RowHeight = 100
        Else
            GVData.RowHeight = 35
        End If
        'FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit columns")
        'GVData.BestFitColumns()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetView()
    End Sub

    Sub resetView()
        GCData.DataSource = Nothing
    End Sub

    Private Sub CESelectedProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectedProduct.EditValueChanged
        If CESelectedProduct.EditValue = True Then
            GCProd.Visible = True
            GroupControl2.Height = 440
            viewProduct()
        Else
            GCProd.Visible = False
            GroupControl2.Height = 150
        End If
        resetView()
    End Sub

    Sub viewProduct()
        Cursor = Cursors.WaitCursor

        'filter product
        Dim where_prod As String = ""
        If Not CCBESeason.EditValue.ToString = "" Then
            where_prod += " AND d.id_season IN (" + CCBESeason.EditValue.ToString + ")"
        End If
        If Not CCBEDivision.EditValue.ToString = "" Then
            where_prod += " AND i.id_division IN (" + CCBEDivision.EditValue.ToString + ")"
        End If
        If Not CCBEClass.EditValue.ToString = "" Then
            where_prod += " AND i.id_class IN (" + CCBEClass.EditValue.ToString + ")"
        End If

        Dim query As String = "SELECT 'No' AS `is_select`, d.id_design,d.design_code AS `code`, d.design_display_name AS `name` 
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
        ) i ON i.id_design = d.id_design
        WHERE d.design_code!='' AND d.id_lookup_status_order!=2 "
        query += where_prod
        query += "ORDER BY name ASC, code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub productList()
        If CESelectedProduct.EditValue = True Then
            viewProduct()
        End If
    End Sub

    Private Sub CCBESeason_EditValueChanged(sender As Object, e As EventArgs) Handles CCBESeason.EditValueChanged
        resetView()
        productList()
    End Sub

    Private Sub CCBEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEDivision.EditValueChanged
        resetView()
        productList()
    End Sub

    Private Sub CCBEClass_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEClass.EditValueChanged
        resetView()
        productList()
    End Sub

    Sub storeList()
        If CESelectedStore.EditValue = True Then
            viewStore()
        End If
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged
        resetView()
        view_group_store()
        storeList()
    End Sub

    Private Sub CCBEArea_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEArea.EditValueChanged
        resetView()
        view_group_store()
        storeList()
    End Sub

    Private Sub CCBEProvince_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEProvince.EditValueChanged
        resetView()
        view_group_store()
        storeList()
    End Sub

    Private Sub CCBEGroupStore_EditValueChanged(sender As Object, e As EventArgs) Handles CCBEGroupStore.EditValueChanged
        resetView()
        storeList()
    End Sub

    Private Sub CESelectedStore_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectedStore.EditValueChanged
        If CESelectedStore.EditValue = True Then
            GCStore.Enabled = True
            viewStore()
        Else
            GCStore.Enabled = False
            GCStore.DataSource = Nothing
        End If
        resetView()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            XtraTabControl1.Width = 355
        Else
            XtraTabControl1.Width = 24
        End If
    End Sub

    Private imageDir As String = product_image_path
    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString
    Private Sub GVData_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVData.CustomUnboundColumnData
        For i = 1 To 2
            If e.Column.FieldName = "th" + i.ToString AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
                Dim images As Hashtable = New Hashtable()

                Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "code"))

                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Dim fileName As String = "/TH_" + id + "_" + i.ToString + ".jpg"

                img = Image.FromFile(imageDir + "\default.jpg")

                resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)

                Try
                    Dim filePath As String = cloud_image_url + fileName

                    Dim t As Net.WebClient = New Net.WebClient

                    img = Image.FromStream(New IO.MemoryStream(t.DownloadData(filePath)))

                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch ex As Exception
                End Try

                images.Add(fileName, resizeImg)

                e.Value = images(fileName)
            End If
        Next
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        resetView()
        If CheckImg.EditValue Then
            GridColumnth2.Visible = True
            GridColumnth2.VisibleIndex = 0
            GridColumnth1.Visible = True
            GridColumnth1.VisibleIndex = 0
        Else
            GridColumnth1.Visible = False
            GridColumnth1.VisibleIndex = -1
            GridColumnth2.Visible = False
            GridColumnth2.VisibleIndex = -1
        End If
    End Sub
End Class