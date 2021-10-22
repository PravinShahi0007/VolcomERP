Public Class FormDesignInfo
    Public id_design As String = "-1"
    Dim dir_def As String = get_setup_field("pic_path_design")
    Dim dir As String = get_setup_field("cloud_image_url")

    Private Sub FormDesignInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewWH()
        viewGroupType()
        DEUntilAcc.EditValue = Now
        setCaptionSize(GVSOHCode)

        Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name, cls.class_display, cls.class, 
        col.color_display, col.color, ss.season, IFNULL(prc.design_price,0) AS `design_price`, 
        prc.design_price_type, prc.`price_effective_date`
        FROM tb_m_design d
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `class_display`, cd.code_detail_name AS `class`
	        FROM tb_m_design d 
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=30
	        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
	        GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, cd.display_name AS `color_display`, cd.code_detail_name AS `color`
	        FROM tb_m_design d
	        INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code=14
	        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT d.id_design, prc.design_price, pt.design_price_type, 
	        DATE_FORMAT(prc.design_price_start_date, '%d %M %Y') AS `price_effective_date`
	        FROM tb_m_design_price prc
	        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
	        INNER JOIN tb_m_design d ON d.id_design = prc.id_design
	        WHERE prc.design_price_start_date<=DATE(NOW()) AND d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2
	        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        LIMIT 1
        ) prc ON prc.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        WHERE d.id_design='" + id_design + "' AND d.id_lookup_status_order!=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            LabelDesc.Text = data.Rows(0)("design_display_name").ToString
            LabelPrice.Text = "Rp. " + Decimal.Parse(data.Rows(0)("design_price").ToString).ToString("N0")
            LabelPriceType.Text = data.Rows(0)("design_price_type").ToString.ToUpper + " PRICE"
            LabelEffectiveDate.Text = data.Rows(0)("price_effective_date").ToString
            LabelCode.Text = data.Rows(0)("design_code").ToString
            LabelClass.Text = data.Rows(0)("class").ToString + " (" + data.Rows(0)("class_display").ToString + ")"
            LabelColor.Text = data.Rows(0)("color").ToString + " (" + data.Rows(0)("color_display").ToString + ")"
            LabelSeason.Text = data.Rows(0)("season").ToString

            'image
            Dim qimg As String = "SELECT * FROM tb_design_images WHERE id_design='" + data.Rows(0)("id_design").ToString + "' AND store='TH' LIMIT 1"
            Dim dimg As DataTable = execute_query(qimg, -1, True, "", "", "", "")
            If dimg.Rows.Count > 0 Then
                Try
                    PictureEdit1.LoadAsync(dir + "/" + dimg.Rows(0)("file_name").ToString)
                Catch ex As Exception
                    warningCustom("Failed load image : " + ex.ToString)
                End Try
            Else
                Try
                    PictureEdit1.LoadAsync(dir_def + "\" + "default.jpg")
                Catch ex As Exception
                    warningCustom("Failed load image : " + ex.ToString)
                End Try
            End If
        Else
            stopCustom("Product not found")
            Close()
        End If
    End Sub

    Private Sub FormDesignInfo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        If XTCStockOnHandNew.SelectedTabPageIndex = 0 Then
            viewSOHSizeBarcode()
        ElseIf XTCStockOnHandNew.SelectedTabPageIndex = 1 Then
            viewSOHCode()
        End If
    End Sub

    Sub viewSOHSizeBarcode()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        'Prepare paramater date
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'other
        Dim id_comp As String = SLEAccount.EditValue.ToString

        'design
        If id_design = "-1" Then
            id_design = "0"
        End If

        'excecute
        Dim query As String = ""
        If LEGroupBy.EditValue.ToString = "1" Then
            query = "CALL view_stock_fg_barcode_size('" + date_until_selected + "', '" + id_comp + "', '" + id_design + "') "
        Else
            query = "CALL view_stock_fg_barcode_size_by_product('" + date_until_selected + "', '" + id_comp + "', '" + id_design + "') "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewSOHCode()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()

        'Prepare paramater date
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'other
        Dim id_comp As String = SLEAccount.EditValue.ToString

        'design
        If id_design = "-1" Then
            id_design = "0"
        End If

        'excecute
        Dim query As String = ""
        If LEGroupBy.EditValue.ToString = "1" Then
            query = "CALL view_stock_fg_code('" + date_until_selected + "', '" + id_comp + "', '" + id_design + "') "
        Else
            query = "CALL view_stock_fg_code_by_product('" + date_until_selected + "', '" + id_comp + "', '" + id_design + "') "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOHCode.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewWH()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('All') AS comp_number, ('All Store') AS comp_name, ('All Store') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub viewGroupType()
        Dim query As String = "SELECT '1' AS `id_group_type`, 'Product & Account' AS `group_type`
        UNION
        SELECT '2' AS `id_group_type`, 'Product' AS `group_type` "
        viewLookupQuery(LEGroupBy, query, 0, "group_type", "id_group_type")
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub LEGroupBy_EditValueChanged(sender As Object, e As EventArgs) Handles LEGroupBy.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetViewSOH()
    End Sub

    Sub resetViewSOH()
        GCSOH.DataSource = Nothing
        GCSOHCode.DataSource = Nothing
    End Sub

    Private Sub BtnExportToXLSAcc_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSAcc.Click
        If XTCStockOnHandNew.SelectedTabPageIndex = 0 Then
            If GVSOH.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "stock_soh_by_barcode.xlsx"
                exportToXLS(path, "soh", GCSOH)
                Cursor = Cursors.Default
            End If
        ElseIf XTCStockOnHandNew.SelectedTabPageIndex = 1 Then
            If GVSOHCode.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'column option creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                GVSOHCode.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                For i As Integer = 0 To GVSOHCode.Columns.Count - 1
                    Try
                        If Not GVSOHCode.Columns(i).OwnerBand.Caption = "" Then
                            GVSOHCode.Columns(i).Caption = GVSOHCode.Columns(i).OwnerBand.Caption + " / " + GVSOHCode.Columns(i).Caption
                        End If
                    Catch ex As Exception
                    End Try
                Next

                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "stock_soh_by_code.xlsx"
                exportToXLS(path, "soh", GCSOHCode)

                'restore column opt
                GVSOHCode.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Cursor = Cursors.Default
            End If
        End If
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

    Private Sub GVSOHCode_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSOHCode.RowCellStyle
        If GVSOHCode.RowCount > 0 Then
            If GVSOHCode.GetRowCellValue(e.RowHandle, "id_design_type").ToString = "2" Then
                e.Appearance.BackColor = Color.SkyBlue
            End If
        End If
    End Sub

    Sub setCaptionSize(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        'avl
        gv.Columns("avl_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("avl_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("avl_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("avl_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("avl_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("avl_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("avl_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("avl_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("avl_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("avl_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'rsv
        gv.Columns("rsv_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("rsv_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("rsv_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("rsv_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("rsv_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("rsv_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("rsv_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("rsv_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("rsv_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("rsv_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'ttl
        gv.Columns("ttl_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        gv.Columns("ttl_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        gv.Columns("ttl_qty3").Caption = "3" + System.Environment.NewLine + "S"
        gv.Columns("ttl_qty4").Caption = "4" + System.Environment.NewLine + "M"
        gv.Columns("ttl_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        gv.Columns("ttl_qty6").Caption = "6" + System.Environment.NewLine + "L"
        gv.Columns("ttl_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        gv.Columns("ttl_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        gv.Columns("ttl_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        gv.Columns("ttl_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As ReportDesignInfo = New ReportDesignInfo

        report.XLDesc.Text = LabelDesc.Text
        report.XLCode.Text = LabelCode.Text
        report.XLSeason.Text = LabelSeason.Text
        report.XLColor.Text = LabelColor.Text
        report.XLClass.Text = LabelClass.Text
        report.XLPrice.Text = LabelPrice.Text
        report.XLPriceType.Text = LabelPriceType.Text
        report.XLEffectiveDate.Text = LabelEffectiveDate.Text

        report.GCSOHCode.DataSource = GCSOHCode.DataSource
        report.GCSOH.DataSource = GCSOH.DataSource

        If XTCStockOnHandNew.SelectedTabPageIndex = 0 Then
            report.DetailReportCode.Visible = False
            report.DetailReportSize.Visible = True
        Else
            report.DetailReportCode.Visible = True
            report.DetailReportSize.Visible = False
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class