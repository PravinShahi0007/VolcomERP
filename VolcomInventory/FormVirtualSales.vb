Public Class FormVirtualSales
    Public is_load_new As New Boolean
    Public id_design_selected As String = "0"
    Public id_design_sc As String = "0"

    Private Sub FormVirtualSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSalesList()
        viewStore()
        viewStoreSC()

        'caption size sal
        GVSOHSal.Columns("sal_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVSOHSal.Columns("sal_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVSOHSal.Columns("sal_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVSOHSal.Columns("sal_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVSOHSal.Columns("sal_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVSOHSal.Columns("sal_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVSOHSal.Columns("sal_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVSOHSal.Columns("sal_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVSOHSal.Columns("sal_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVSOHSal.Columns("sal_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'caption soh sal
        GVSOHSal.Columns("soh_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVSOHSal.Columns("soh_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVSOHSal.Columns("soh_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVSOHSal.Columns("soh_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVSOHSal.Columns("soh_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVSOHSal.Columns("soh_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVSOHSal.Columns("soh_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVSOHSal.Columns("soh_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVSOHSal.Columns("soh_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVSOHSal.Columns("soh_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Private Sub FormVirtualSales_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_comp`, 'All Store' AS `comp_number`, 'All Store' AS `comp_name_label`
        UNION ALL
        SELECT c.id_comp, c.comp_number , c.comp_name AS `comp_name_label` 
        FROM tb_m_comp c WHERE c.id_comp_cat=6 "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub viewStoreSC()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT c.id_comp, c.comp_number , c.comp_name AS `comp_name_label` 
        FROM tb_m_comp c WHERE c.id_comp_cat=6 "
        viewSearchLookupQuery(SLEAccountSC, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub


    Sub viewSalesList()
        Cursor = Cursors.WaitCursor
        Dim vs As New ClassVirtualSales()
        Dim query As String = vs.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        GVSales.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Cursor = Cursors.WaitCursor
        FormVirtualSalesDet.action = "ins"
        FormVirtualSalesDet.ShowDialog()
        loadNewDetail()
        Cursor = Cursors.Default
    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        If GVSales.RowCount > 0 And GVSales.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormVirtualSalesDet.action = "upd"
            FormVirtualSalesDet.id = GVSales.GetFocusedRowCellValue("id_virtual_sales").ToString
            FormVirtualSalesDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSales_DoubleClick(sender As Object, e As EventArgs) Handles GVSales.DoubleClick
        viewDetail()
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewSalInv()
    End Sub

    Sub resetViewSalInv()
        GCSOHSal.DataSource = Nothing
        DEBeg.EditValue = Nothing
        TxtSalPeriod.Text = ""
    End Sub

    Private Sub TxtProduct_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProduct.EditValueChanged
        ' resetViewSalInv()
    End Sub

    Private Sub CEFindAllProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        id_design_selected = "0"
        TxtProduct.Text = ""
        resetViewSalInv()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "7"
        FormSearchDesign.ShowDialog()
        resetViewSalInv()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        If CEFindAllProduct.EditValue = False And id_design_selected = "0" Then
            warningCustom("Please input product code first")
            Exit Sub
        End If

        viewSalSOH()
    End Sub

    Sub viewSalSOH()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        Dim id_comp As String = SLEAccount.EditValue.ToString


        Dim query As String = "CALL view_sal_inv_virtual(" + id_comp + "," + id_design_selected + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOHSal.DataSource = data
        DEBeg.EditValue = data.Rows(0)("beg_stock_date")
        TxtSalPeriod.Text = data.Rows(0)("sal_period_date").ToString

        If Not id_comp = 0 Then
            FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit all column")
            GVSOHSal.BestFitColumns()
        End If

        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSAcc_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSAcc.Click
        If GVSOHSal.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVSOHSal.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GVSOHSal.Columns.Count - 1
                Try
                    If Not GVSOHSal.Columns(i).OwnerBand.Caption = "" Then
                        GVSOHSal.Columns(i).Caption = GVSOHSal.Columns(i).OwnerBand.Caption + " / " + GVSOHSal.Columns(i).Caption
                    End If
                Catch ex As Exception
                End Try
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "virtual_sales_inv.xlsx"
            exportToXLS(path, "soh", GCSOHSal, False)

            'restore column opt
            GVSOHSal.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl, is_allow_group As Boolean)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        If is_allow_group Then
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.True
        Else
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        End If
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

    Private Sub BandedGridViewFGStockCard_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedGridViewFGStockCard.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("enter") Or e.Column.FieldName = "TTL" Or e.Column.FieldName.Contains("Bal")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        End If
    End Sub

    Sub resetViewSC()
        GCFGStockCard.DataSource = Nothing
        DEBegSC.EditValue = Nothing
        DEStartSC.EditValue = Nothing
        DEUntilSC.EditValue = Nothing
    End Sub

    Private Sub SLEAccountSC_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccountSC.EditValueChanged
        resetViewSC()
    End Sub

    Private Sub BtnBrowseProductSC_Click(sender As Object, e As EventArgs) Handles BtnBrowseProductSC.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "8"
        FormSearchDesign.ShowDialog()
        resetViewSC()
        Cursor = Cursors.Default
    End Sub

    Sub viewStockCard()
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        BandedGridViewFGStockCard.Columns.Clear()
        BandedGridViewFGStockCard.Bands.Clear()
        'BandedGridViewFGStockCard.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BandedGridViewFGStockCard.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Dim id_wh_selected As String = "0"

        Try
            id_wh_selected = SLEAccountSC.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim band_ref As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("REFF")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("QUANTITY")
        Dim band_bal As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("BALANCE")
        Dim band_stat As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("")
        band_stat.AutoFillDown = True


        'data
        Dim data As DataTable
        Dim qz As String = "SELECT SUBSTRING(p.product_full_code, 10, 1) AS `size_type`
        FROM tb_m_design d 
        INNER JOIN tb_m_product p ON p.id_design = d.id_design
        WHERE d.id_design='" + id_design_sc + "'
        GROUP BY SUBSTRING(p.product_full_code, 10, 1) "
        Dim dz As DataTable = execute_query(qz, -1, True, "", "", "", "")
        Dim data_stock As New DataTable
        For z As Integer = 0 To dz.Rows.Count - 1
            Dim query_sc As String = "CALL view_stock_card_virtual('" + id_design_sc + "', '" + id_wh_selected + "','" + dz.Rows(z)("size_type").ToString + "') "
            Dim dsc As DataTable = execute_query(query_sc, -1, True, "", "", "", "")
            If dsc.Rows.Count > 0 Then
                If data_stock.Rows.Count = 0 Then
                    data_stock = dsc
                Else
                    data_stock.Merge(dsc)
                End If
            End If
        Next
        data = data_stock



        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_comp" Or data.Columns(i).ColumnName.ToString = "id_report" Or data.Columns(i).ColumnName.ToString = "report_mark_type" Or data.Columns(i).ColumnName.ToString = "id_storage_category" Or data.Columns(i).ColumnName.ToString = "Time" Or data.Columns(i).ColumnName.ToString = "Transaction" Or data.Columns(i).ColumnName.ToString = "Transaction Type" Or data.Columns(i).ColumnName.ToString = "Size Type" Or data.Columns(i).ColumnName.ToString = "Account" Or data.Columns(i).ColumnName.ToString = "Trasaction Created Date" Then
                band_ref.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                If data.Columns(i).ColumnName.ToString = "Time" Then
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMM yyyy HH:mm:ss"
                End If

                If data.Columns(i).ColumnName.ToString = "Trasaction Created Date" Then
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMM yyyy"
                End If
            ElseIf data.Columns(i).ColumnName.ToString = "Status" Then
                band_stat.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Status"))
            ElseIf data.Columns(i).ColumnName.ToString.Contains(" Bal") Then
                If data.Columns(i).ColumnName.ToString.Contains("enter") Then
                    Dim col_foc_str As String() = Split(data.Columns(i).ColumnName.ToString, "enter")
                    Dim cap_col As String = col_foc_str(0).ToString + System.Environment.NewLine + col_foc_str(1).ToString
                    Dim st_caption As String = cap_col.Length - 4
                    band_bal.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, cap_col.Substring(0, st_caption)))
                Else
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                    band_bal.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                End If
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
            Else
                If data.Columns(i).ColumnName.ToString.Contains("enter") Then
                    Dim col_foc_str As String() = Split(data.Columns(i).ColumnName.ToString, "enter")
                    Dim cap_col As String = col_foc_str(0).ToString + System.Environment.NewLine + col_foc_str(1).ToString
                    band_qty.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, cap_col))
                Else
                    band_qty.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
            End If
            progres_bar_update(i, data.Columns.Count - 1)
        Next


        GCFGStockCard.DataSource = data

        If data.Rows.Count > 0 Then
            'hide column
            BandedGridViewFGStockCard.Columns("id_comp").Visible = False
            BandedGridViewFGStockCard.Columns("id_report").Visible = False
            BandedGridViewFGStockCard.Columns("report_mark_type").Visible = False
            BandedGridViewFGStockCard.Columns("id_storage_category").Visible = False
            BandedGridViewFGStockCard.Columns("beg_date").Visible = False
            BandedGridViewFGStockCard.Columns("from_date").Visible = False
            BandedGridViewFGStockCard.Columns("until_date").Visible = False
            'enable group
            BandedGridViewFGStockCard.Columns("Size Type").GroupIndex = 0
            BandedGridViewFGStockCard.ExpandAllGroups()
            'info
            DEBegSC.EditValue = data.Rows(0)("beg_date")
            DEStartSC.EditValue = data.Rows(0)("from_date")
            DEUntilSC.EditValue = data.Rows(0)("until_date")
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Best fit column")
        BandedGridViewFGStockCard.BestFitColumns()

        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewAccSC_Click(sender As Object, e As EventArgs) Handles BtnViewAccSC.Click
        If id_design_sc <> "0" Then
            viewStockCard()
        Else
            warningCustom("Please complete all data")
        End If
    End Sub

    Private Sub ViewDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDocumentToolStripMenuItem.Click
        If BandedGridViewFGStockCard.RowCount > 0 And BandedGridViewFGStockCard.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp()
            m.report_mark_type = BandedGridViewFGStockCard.GetFocusedRowCellValue("report_mark_type").ToString
            m.id_report = BandedGridViewFGStockCard.GetFocusedRowCellValue("id_report").ToString
            m.show()
        End If
    End Sub

    Private Sub BtnExportToXLSAccSC_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSAccSC.Click
        If BandedGridViewFGStockCard.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "stock_card.xlsx"
            exportToXLS(path, "stock_card", GCFGStockCard, True)
            Cursor = Cursors.Default
        End If
    End Sub
End Class