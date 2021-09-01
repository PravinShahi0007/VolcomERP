﻿Public Class FormFGStock
    '------------------------------------
    'VARIABLE STOCK CARD
    '------------------------------------
    'Def var -Tab Stock Card
    Dim id_sample_image As String = "0"
    Dim id_comp_def As String = "0"
    Dim comp_def As String = ""
    Dim id_design_def As String = "0"
    Dim label_design_def As String = "0"
    Dim color_def As String = "-1"
    Dim division_def As String = "-1"
    Dim branding_def As String = "-1"
    Dim source_def As String = "-1"
    Dim class_def As String = "-1"
    Dim id_sample_def As String = "-1"

    'selected view  -Tab Stock Card
    Public id_design_selected As String = "-1"
    Public label_design_selected As String = "-1"
    Public id_wh_selected As String = "-1"
    Public comp_name_label_selected As String = ""
    Public date_from_selected As String = "-1"
    Public date_until_selected As String = "-1"

    'Datatalbe-Tab Stock Card
    Public dt As DataTable

    '------------------------------------
    'VARIABLE STOCK WH
    '------------------------------------
    'Def var -Tab Stock Sum
    Dim id_comp_def_stock_sum As String = "0"
    Dim comp_def_stock_sum As String = ""
    Dim label_design_stock_sum_def As String

    'Selected view - Tab Stock Sum
    Public id_wh_param_selected As String = "-1"
    Public id_locator_param_selected As String = "-1"
    Public id_rack_param_selected As String = "-1"
    Public id_drawer_param_selected As String = "-1"
    Public id_design_selected_stock_sum As String = "-1"
    Public id_product_selected_stock_sum As String = "-1"
    Public label_design_selected_stock_sum As String = "-1"
    Public label_wh_selected_stock_sum As String = "-1"
    Public label_locator_selected_stock_sum As String = "-1"
    Public label_rack_selected_stock_sum As String = "-1"
    Public label_drawer_selected_stock_sum As String = "-1"
    Public date_from_selected_stock_sum As String = "-1"
    Public date_until_selected_stock_sum As String = "-1"
    Dim special_code_list As New List(Of String)

    'Datatalbe-Tab Stock Sum
    Public dt_sum As DataTable

    '------------------------------------
    'VARIABLE STOCK STORE
    '------------------------------------
    'Def var -Tab Stock Store
    Dim id_store_def_stock_store As String = "0"
    Dim store_def_stock_store As String = ""
    Dim label_design_stock_store_def As String

    'selected View - Tab Stock Store
    Public id_store_param_selected As String = "-1"
    Public id_design_selected_stock_store As String = "-1"
    Public label_design_selected_stock_store As String = "-1"
    Public label_store_selected_stock_store As String = "-1"
    Public date_from_selected_stock_store As String = "-1"
    Public date_until_selected_stock_store As String = "-1"

    'Datatalbe-Tab Stock Store
    Public dt_store As DataTable

    '-------------------------------------
    'VARIABLE STOCK QC
    '-------------------------------------
    'Def var -Tab Stock Store
    Dim label_design_stock_qc_def As String

    'selected View - Tab Stock Store
    Public id_design_selected_stock_qc As String = "-1"
    Public label_design_selected_stock_qc As String = "-1"
    Public date_from_selected_stock_qc As String = "-1"
    Public date_until_selected_stock_qc As String = "-1"

    '-----------------------------
    'RESERVED STOCK LIST
    '-----------------------------
    Public id_design_rsv As String = "-1"
    Public id_drw_rsv As String = "-1"

    'Datatalbe-Tab Stock Store
    Public dt_qc As DataTable

    Public id_pop_up As String = "-1"
    Dim first_load_sum As Boolean = True
    Dim first_load_card As Boolean = True
    Public show_cost As Boolean = False
    Public id_design_soh As String = "-1"
    Public id_design_soh_va As String = "-1"
    Dim id_super_admin As String = get_setup_field("id_role_super_admin")

    Private Sub FormFGStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCFGStock.TabPages
            XTCFGStock.SelectedTabPage = t
        Next t
        XTCFGStock.SelectedTabPage = XTCFGStock.TabPages(0)
        If id_pop_up = "-1" Then
            'viewWHStockCard()
            viewWHStockSum()
            viewWH()
            viewVAAccount()
            viewPriceType()
            XTPFGStockQC.PageVisible = False
            setCaptionSize(GVSOHCode)
            viewGroupType()
        Else
            viewProductStockQC()
            XTPFGStockCardWH.PageVisible = False
            XTPFGStockStore.PageVisible = False
            XTPFGStockWHSum.PageVisible = False
            XTPFGStockQC.PageVisible = True
        End If
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEUntilStockFG.EditValue = data_dt.Rows(0)("dt")
        DEUntilStockQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
        DEUntilAccVA.EditValue = data_dt.Rows(0)("dt")
        ActiveControl = TxtDesignCode

        If id_role_login <> id_super_admin Then
            XTPFGStockWHSum.PageEnabled = False
        End If
    End Sub

    Sub viewGroupType()
        Dim query As String = "SELECT '1' AS `id_group_type`, 'Product & Account' AS `group_type`
        UNION
        SELECT '2' AS `id_group_type`, 'Product' AS `group_type` "
        viewLookupQuery(LEGroupBy, query, 0, "group_type", "id_group_type")
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

    '=============== TAB STOCK CARD FG=================================
    Sub viewWHStockCard()
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                comp_def = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEWH.Properties.DataSource = Nothing
        SLEWH.Properties.DataSource = data
        SLEWH.Properties.DisplayMember = "comp_name_label"
        SLEWH.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWH.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWH.EditValue = Nothing
        End If
    End Sub

    Sub viewPriceType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 1 AS `id_price_type`, 'Update' AS `price_type`
        UNION ALL
        SELECT 2 AS `id_price_type`, 'Normal' AS `price_type` "
        viewLookupQuery(LEPriceType, query, 0, "price_type", "id_price_type")
        Cursor = Cursors.Default
    End Sub


    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        If SLEWH.EditValue = Nothing Then
            SLEWH.EditValue = "0"
        Else
            id_comp_def = SLEWH.EditValue.ToString
        End If
    End Sub

    Private Sub BtnTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTracking.Click
        viewStockCard(False)
    End Sub

    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        pre_viewImages("2", PictureEdit1, id_design_selected, True)
    End Sub

    Private Sub BandedGridViewFGStockCard_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridViewFGStockCard.PopupMenuShowing
        If BandedGridViewFGStockCard.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub SMViewDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewDel.Click
        Cursor = Cursors.WaitCursor
        If XTCFGStock.SelectedTabPageIndex = 1 Then
            If BandedGridViewFGStockCard.RowCount > 0 Then
                Dim id_trans As String = "-1"
                Dim report_mark_type As String = "-1"
                Try
                    id_trans = BandedGridViewFGStockCard.GetFocusedRowCellValue("id_report").ToString
                    report_mark_type = BandedGridViewFGStockCard.GetFocusedRowCellValue("report_mark_type").ToString
                Catch ex As Exception
                End Try

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_trans
                showpopup.show()
            End If
        ElseIf XTCFGStock.SelectedTabPageIndex = 4 Then
            If GVRsv.RowCount > 0 And GVRsv.FocusedRowHandle >= 0 Then
                Dim id_trans As String = "-1"
                Dim report_mark_type As String = "-1"
                Try
                    id_trans = GVRsv.GetFocusedRowCellValue("id_report").ToString
                    report_mark_type = GVRsv.GetFocusedRowCellValue("report_mark_type").ToString
                Catch ex As Exception
                End Try

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_trans
                showpopup.show()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGStock_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGStock_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    '===================== TAB STOCK SUMMARY=========================================
    Sub viewWHStockSum()
        Dim query As String = ""
        query += "SELECT ('-1') AS id_comp, ('-') AS comp_number, ('Normal Warehouse') AS comp_name, ('Normal Warehouse') AS comp_name_label UNION ALL "
        query += "SELECT ('-2') AS id_comp, ('-') AS comp_number, ('Sale Warehouse') AS comp_name, ('Sale Warehouse') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                comp_def_stock_sum = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEWHStockSum.Properties.DataSource = Nothing
        SLEWHStockSum.Properties.DataSource = data
        SLEWHStockSum.Properties.DisplayMember = "comp_name_label"
        SLEWHStockSum.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWHStockSum.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWHStockSum.EditValue = Nothing
        End If
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

    Sub viewVAAccount()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label
        FROM tb_m_comp e WHERE e.id_comp IN (SELECT c.id_wh_group FROM tb_m_comp c GROUP BY c.id_wh_group) "
        viewSearchLookupQuery(SLEAccountVA, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEWHStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWHStockSum.EditValueChanged
        If SLEWHStockSum.EditValue = Nothing Then
            SLEWHStockSum.EditValue = "0"
        Else
            id_comp_def_stock_sum = SLEWHStockSum.EditValue.ToString
            viewLocatorStockSum()
        End If
    End Sub

    Sub viewLocatorStockSum()
        Dim id_comp As String = "-1"
        Try
            id_comp = SLEWHStockSum.EditValue.ToString()
        Catch ex As Exception
        End Try
        Dim query As String = getQueryLocator(id_comp)
        viewSearchLookupQuery(SLELocatorStockSum, query, "id_wh_locator", "locator_label", "id_wh_locator")
    End Sub

    Private Sub SLELocatorStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocatorStockSum.EditValueChanged
        viewRackStockSum()
    End Sub

    Sub viewRackStockSum()
        Dim id_locator As String = "-1"
        Try
            id_locator = SLELocatorStockSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = getRack(id_locator)
        viewSearchLookupQuery(SLERackStockSum, query, "id_wh_rack", "rack_label", "id_wh_rack")
    End Sub

    Private Sub SLERackStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERackStockSum.EditValueChanged
        viewDrawerStockSum()
    End Sub

    Sub viewDrawerStockSum()
        Dim id_rack As String = "-1"
        Try
            id_rack = SLERackStockSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = getDrawer(id_rack)
        viewSearchLookupQuery(SLEDrawerStockSum, query, "id_wh_drawer", "drawer_label", "id_wh_drawer")
    End Sub

    Private Sub SLEDrawerStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawerStockSum.EditValueChanged
        If SLEDrawerStockSum.EditValue Is Nothing Then
            BtnViewStockSum.Enabled = False
        Else
            BtnViewStockSum.Enabled = True
        End If
    End Sub

    Private Sub BtnViewStockSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockSum.Click
        Cursor = Cursors.WaitCursor

        'Clear List code
        special_code_list.Clear()

        'Prepare paramater
        date_until_selected_stock_sum = "9999-01-01"
        Try
            date_until_selected_stock_sum = DateTime.Parse(DEUntilStockFG.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            id_wh_param_selected = SLEWHStockSum.EditValue.ToString
            id_locator_param_selected = SLELocatorStockSum.EditValue.ToString
            id_rack_param_selected = SLERackStockSum.EditValue.ToString
            id_drawer_param_selected = SLEDrawerStockSum.EditValue.ToString
        Catch ex As Exception
        End Try

        'set selected
        If id_design_selected_stock_sum = "0" Then
            label_design_selected_stock_sum = "All Design"
        Else
            label_design_selected_stock_sum = TxtDesignCode.Text
        End If

        If id_wh_param_selected = "0" Then
            label_wh_selected_stock_sum = "All WH"
        Else
            label_wh_selected_stock_sum = SLEWHStockSum.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        If id_locator_param_selected = "0" Then
            label_locator_selected_stock_sum = "All Locator"
        Else
            label_locator_selected_stock_sum = SLELocatorStockSum.Properties.View.GetFocusedRowCellValue("locator_label").ToString
        End If

        If id_rack_param_selected = "0" Then
            label_rack_selected_stock_sum = "All Rack"
        Else
            label_rack_selected_stock_sum = SLERackStockSum.Properties.View.GetFocusedRowCellValue("rack_label").ToString
        End If

        If id_drawer_param_selected = "0" Then
            label_drawer_selected_stock_sum = "All Drawer"
        Else
            label_drawer_selected_stock_sum = SLEDrawerStockSum.Properties.View.GetFocusedRowCellValue("drawer_label").ToString
        End If

        If XTCSOH.SelectedTabPageIndex = 0 Then
            'Prepare Baded
            BGVFGStock.Columns.Clear()
            BGVFGStock.Bands.Clear()
            BGVFGStock.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ' Make the group footers always visible.
            BGVFGStock.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

            Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("DESCRIPTION")
            Dim band_aging As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("AGING (MONTH)")
            Dim band_qty_free As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("AVAILABLE QTY")
            Dim band_qty_res As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("RESERVED QTY")
            Dim band_qty_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("TOTAL QTY")
            'band_qty_total.AppearanceHeader.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)

            Dim query As String = "CALL view_stock_fg_sum('" + id_wh_param_selected + "', '" + id_locator_param_selected + "', '" + id_rack_param_selected + "', '" + id_drawer_param_selected + "', '" + id_design_selected_stock_sum + "', '" + date_until_selected_stock_sum + "') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString = "id_sample" Or data.Columns(i).ColumnName.ToString = "Code" Or data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "Design" Or data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "uom" Or data.Columns(i).ColumnName.ToString = "id_design_stock" Or data.Columns(i).ColumnName.ToString = "Unit Cost" Or data.Columns(i).ColumnName.ToString = "Product Division" Or data.Columns(i).ColumnName.ToString = "Product Source" Or data.Columns(i).ColumnName.ToString = "Product Branding" Or data.Columns(i).ColumnName.ToString = "Range" Or data.Columns(i).ColumnName.ToString = "Product Counting" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "Status" Or data.Columns(i).ColumnName.ToString = "Price Type" Or data.Columns(i).ColumnName.ToString = "Price" Or data.Columns(i).ColumnName.ToString = "Sizetype" Or data.Columns(i).ColumnName.ToString = "Account" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    If data.Columns(i).ColumnName.ToString = "Price" Or data.Columns(i).ColumnName.ToString = "Unit Cost" Then
                        BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
                    End If
                ElseIf data.Columns(i).ColumnName.ToString.Contains(" Free") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 5
                    band_qty_free.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                    BGVFGStock.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains(" Reserved") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 9
                    band_qty_res.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                    BGVFGStock.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains(" Aging") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
                    band_aging.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains(" Total") Then
                    Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
                    band_qty_total.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    'BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)
                    'BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                    BGVFGStock.GroupSummary.Add(item)
                End If
                progres_bar_update(i, data.Columns.Count - 1)
            Next
            GCFGStock.DataSource = data
            dt_sum = data

            'hide column
            BGVFGStock.Columns("id_sample").Visible = False
            BGVFGStock.Columns("id_design").Visible = False
            BGVFGStock.Columns("design_display_name").Visible = False
            BGVFGStock.Columns("uom").Visible = False
            BGVFGStock.Columns("id_design_stock").Visible = False
            BGVFGStock.Columns("Product Counting").Visible = False
            BGVFGStock.Columns("Range").Visible = False
            If Not show_cost Then
                BGVFGStock.Columns("Unit Cost").Visible = False
                BGVFGStock.Columns("Unit Cost").OptionsColumn.ShowInCustomizationForm = False
                BGVFGStock.Columns("Amount Cost Total").Visible = False
                BGVFGStock.Columns("Amount Cost Total").OptionsColumn.ShowInCustomizationForm = False
            End If
            For j As Integer = 0 To special_code_list.Count - 1
                BGVFGStock.Columns(special_code_list(j)).Visible = False
            Next

            'Enable Group
            GroupControlStockSum.Enabled = True
        Else
            Dim query As String = "CALL view_stock_fg('" + id_wh_param_selected + "', '" + id_locator_param_selected + "', '" + id_rack_param_selected + "', '" + id_drawer_param_selected + "', '" + id_product_selected_stock_sum + "', 4, '" + date_until_selected_stock_sum + "') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCStockBarcode.DataSource = data
            If Not show_cost Then
                BGVStockBarcode.Columns("design_cop").Visible = False
                BGVStockBarcode.Columns("design_cop").OptionsColumn.ShowInCustomizationForm = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewStockCard(ByVal is_use_sizetype As Boolean)
        Cursor = Cursors.WaitCursor
        BandedGridViewFGStockCard.Columns.Clear()
        BandedGridViewFGStockCard.Bands.Clear()
        'BandedGridViewFGStockCard.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BandedGridViewFGStockCard.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        label_design_selected = ""
        id_wh_selected = "0"
        comp_name_label_selected = ""
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            id_wh_selected = SLEWH.EditValue.ToString
        Catch ex As Exception
        End Try

        id_sample_image = "0"
        Dim band_ref As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("REFF")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("QUANTITY")
        Dim band_bal As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("BALANCE")
        Dim band_stat As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("")
        band_stat.AutoFillDown = True


        'data
        Dim query As String = ""
        Dim data As DataTable
        If Not is_use_sizetype Then
            query = "CALL view_stock_card_fg('" + id_design_selected + "', '" + id_wh_selected + "', '" + date_from_selected + "', '" + date_until_selected + "') "
            data = execute_query(query, -1, True, "", "", "", "")
        Else
            Dim qz As String = "SELECT SUBSTRING(p.product_full_code, 10, 1) AS `size_type`
            FROM tb_m_design d 
            INNER JOIN tb_m_product p ON p.id_design = d.id_design
            WHERE d.id_design='" + id_design_selected + "'
            GROUP BY SUBSTRING(p.product_full_code, 10, 1) "
            Dim dz As DataTable = execute_query(qz, -1, True, "", "", "", "")
            Dim data_stock As New DataTable
            For z As Integer = 0 To dz.Rows.Count - 1
                Dim query_sc As String = "CALL view_stock_card_fg_sizetype('" + id_design_selected + "', '" + id_wh_selected + "', '" + date_from_selected + "', '" + date_until_selected + "','" + dz.Rows(z)("size_type").ToString + "') "
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
        End If



        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_comp" Or data.Columns(i).ColumnName.ToString = "id_report" Or data.Columns(i).ColumnName.ToString = "report_mark_type" Or data.Columns(i).ColumnName.ToString = "id_storage_category" Or data.Columns(i).ColumnName.ToString = "Time" Or data.Columns(i).ColumnName.ToString = "Transaction" Or data.Columns(i).ColumnName.ToString = "Transaction Type" Or data.Columns(i).ColumnName.ToString = "Size Type" Or data.Columns(i).ColumnName.ToString = "Account" Then
                band_ref.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                If data.Columns(i).ColumnName.ToString = "Time" Then
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss"
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
        dt = data

        If data.Rows.Count > 0 Then
            'hide column
            BandedGridViewFGStockCard.Columns("id_comp").Visible = False
            BandedGridViewFGStockCard.Columns("id_report").Visible = False
            BandedGridViewFGStockCard.Columns("report_mark_type").Visible = False
            BandedGridViewFGStockCard.Columns("id_storage_category").Visible = False
            'enable group
            BandedGridViewFGStockCard.Columns("Size Type").GroupIndex = 0
            BandedGridViewFGStockCard.ExpandAllGroups()
        End If

        GroupControlInfo.Enabled = True
        GroupControlTraccking.Enabled = True
        Cursor = Cursors.Default
    End Sub

    '===========================TAB STOCK STORE======================================
    Sub viewStoreStockStore()
        'Dim query As String = getQueryStore()
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To data.Rows.Count - 1
        '    If i = 0 Then
        '        store_def_stock_store = data.Rows(i)("comp_name_label").ToString
        '        Exit For
        '    End If
        'Next
        'SLEStockStore.Properties.DataSource = Nothing
        'SLEStockStore.Properties.DataSource = data
        'SLEStockStore.Properties.DisplayMember = "comp_name_label"
        'SLEStockStore.Properties.ValueMember = "id_comp"
        'If data.Rows.Count.ToString >= 1 Then
        '    SLEStockStore.EditValue = data.Rows(0)("id_comp").ToString
        'Else
        '    SLEStockStore.EditValue = Nothing
        'End If
    End Sub

    Sub viewProductStockStore()
        'Dim query As String = ""
        'query += "CALL view_design_wh(TRUE) "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To data.Rows.Count - 1
        '    If i = 0 Then
        '        label_design_stock_store_def = data.Rows(i)("label_design").ToString
        '        Exit For
        '    End If
        'Next
        'SLEDesignStockStore.Properties.DataSource = Nothing
        'SLEDesignStockStore.Properties.DataSource = data
        'SLEDesignStockStore.Properties.DisplayMember = "label_design"
        'SLEDesignStockStore.Properties.ValueMember = "id_design"
        'If data.Rows.Count.ToString >= 1 Then
        '    SLEDesignStockStore.EditValue = data.Rows(0)("id_design").ToString
        'Else
        '    SLEDesignStockStore.EditValue = Nothing
        'End If
    End Sub

    Private Sub BtnViewStockStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockStore.Click
        Cursor = Cursors.WaitCursor

        'Prepare paramater
        date_from_selected_stock_store = "0000-01-01"
        date_until_selected_stock_store = "9999-01-01"
        Try
            date_from_selected_stock_store = DateTime.Parse(DEFromStockStore.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected_stock_store = DateTime.Parse(DEUntilStockStore.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            id_design_selected_stock_store = SLEDesignStockStore.EditValue.ToString
            id_store_param_selected = SLEStockStore.EditValue.ToString
        Catch ex As Exception
        End Try

        'set selected
        If id_design_selected_stock_store = "0" Then
            label_design_selected_stock_store = "All Design"
        Else
            label_design_selected_stock_sum = SLEDesignStockStore.Properties.View.GetFocusedRowCellValue("label_design").ToString
        End If

        If id_store_param_selected = "0" Then
            label_store_selected_stock_store = "All Store"
        Else
            label_store_selected_stock_store = SLEStockStore.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If


        'Prepare Baded
        BGVFGStockStore.Columns.Clear()
        BGVFGStockStore.Bands.Clear()
        BGVFGStockStore.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockStore.Bands.AddBand("DESCRIPTION")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockStore.Bands.AddBand("QTY")

        ' Make the group footers always visible.
        BGVFGStockStore.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        Dim queryx As String = ""
        queryx = "CALL view_stock_fg_store_detail('" + id_design_selected_stock_store + "', '"+id_store_param_selected+"','" + date_from_selected_stock_store + "', '" + date_until_selected_stock_store + "') "
        Dim data As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        For i As Integer = 0 To Data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "Store" Or data.Columns(i).ColumnName.ToString = "id_sample" Or data.Columns(i).ColumnName.ToString = "Code" Or data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "Design" Or data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "uom" Or data.Columns(i).ColumnName.ToString = "Receiving WH Aging" Or data.Columns(i).ColumnName.ToString = "id_design_stock" Or data.Columns(i).ColumnName.ToString = "Age (Day)" Or data.Columns(i).ColumnName.ToString = "id_comp" Or data.Columns(i).ColumnName.ToString = "Product Division" Or data.Columns(i).ColumnName.ToString = "Product Source" Or data.Columns(i).ColumnName.ToString = "Product Branding" Or data.Columns(i).ColumnName.ToString = "Range" Or data.Columns(i).ColumnName.ToString = "Product Counting" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "id_design_price" Or data.Columns(i).ColumnName.ToString = "Price Type" Or data.Columns(i).ColumnName.ToString = "Price Name" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "Price" Then
                band_desc.Columns.Add(BGVFGStockStore.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
            Else
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
                band_qty.Columns.Add(BGVFGStockStore.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVFGStockStore.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockStore.GroupSummary.Add(item)
            End If
        Next
        GCFGStockStore.DataSource = data
        dt_store = data

        ''hide column
        BGVFGStockStore.Columns("id_sample").Visible = False
        BGVFGStockStore.Columns("id_design").Visible = False
        BGVFGStockStore.Columns("design_display_name").Visible = False
        BGVFGStockStore.Columns("uom").Visible = False
        BGVFGStockStore.Columns("id_design_stock").Visible = False
        BGVFGStockStore.Columns("id_design_price").Visible = False
        BGVFGStockStore.Columns("Product Counting").Visible = False
        BGVFGStockStore.Columns("Range").Visible = False
        BGVFGStockStore.Columns("id_comp").Visible = False

        'Enable Group
        GroupControlStockStore.Enabled = True
        Cursor = Cursors.Default
    End Sub

    '===========================TAB STOCK QC======================================
    Sub viewProductStockQC()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_design_stock_qc_def = data.Rows(i)("label_design").ToString
                Exit For
            End If
        Next
        SLEDesignStockQC.Properties.DataSource = Nothing
        SLEDesignStockQC.Properties.DataSource = data

        SLEDesignStockQC.Properties.DisplayMember = "label_design"
        SLEDesignStockQC.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockQC.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockQC.EditValue = Nothing
        End If
        If data.Rows.Count > 0 Then
            GVDesignQC.BestFitColumns()
        End If
    End Sub

    Private Sub BtnViewStockQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockQC.Click
        Cursor = Cursors.WaitCursor

        'Prepare paramater
        date_until_selected_stock_qc = "9999-01-01"

        Try
            date_until_selected_stock_qc = "9999-01-01"
        Catch ex As Exception
        End Try

        Try
            id_design_selected_stock_qc = SLEDesignStockQC.EditValue.ToString
            date_until_selected_stock_qc = DateTime.Parse(DEUntilStockQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'set selected
        If id_design_selected_stock_qc = "0" Then
            label_design_selected_stock_qc = "All Design"
        Else
            label_design_selected_stock_qc = SLEDesignStockQC.Properties.View.GetFocusedRowCellValue("label_design").ToString
        End If

        'Prepare Baded
        BGVFGStockQC.Columns.Clear()
        BGVFGStockQC.Bands.Clear()
        BGVFGStockQC.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("DESCRIPTION")
        Dim band_rec As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("RECEIVE QC")
        Dim band_ret_out As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("RETURN OUT")
        Dim band_ret_in As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("RETURN IN")
        Dim band_pl As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("PACKING LIST TO WH")
        'update 18 Agustus 2015
        Dim band_adj_in As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("ADJUSTMENT IN QC")
        Dim band_adj_out As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("ADJUSTMENT OUT QC")
        '
        Dim band_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStockQC.Bands.AddBand("TOTAL IN QC")
        band_desc.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        band_rec.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        band_ret_out.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        band_ret_in.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        'update 18 Agustus 2015
        band_adj_in.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        band_adj_out.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        '
        band_pl.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)
        band_total.AppearanceHeader.Font = New Font(BGVFGStockQC.Appearance.Row.Font.FontFamily, BGVFGStockQC.Appearance.Row.Font.Size, FontStyle.Bold)

        ' Make the group footers always visible.
        BGVFGStockQC.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        Dim queryx As String = ""
        queryx = "CALL view_stock_prod_rec_report('" + id_design_selected_stock_qc + "', '" + date_until_selected_stock_qc + "')"
        Dim data As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_sample" _
            Or data.Columns(i).ColumnName.ToString = "Code" _
            Or data.Columns(i).ColumnName.ToString = "id_design_master" _
            Or data.Columns(i).ColumnName.ToString = "Design" _
            Or data.Columns(i).ColumnName.ToString = "design_display_name" _
            Or data.Columns(i).ColumnName.ToString = "uom" _
            Or data.Columns(i).ColumnName.ToString = "Receiving WH Aging" _
            Or data.Columns(i).ColumnName.ToString = "Product Division" _
            Or data.Columns(i).ColumnName.ToString = "Product Source" _
            Or data.Columns(i).ColumnName.ToString = "Product Branding" _
            Or data.Columns(i).ColumnName.ToString = "Range" _
            Or data.Columns(i).ColumnName.ToString = "Product Counting" _
            Or data.Columns(i).ColumnName.ToString = "Color" _
            Or data.Columns(i).ColumnName.ToString = "id_season" _
            Or data.Columns(i).ColumnName.ToString = "Season" _
            Or data.Columns(i).ColumnName.ToString = "Delivery" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_order" _
            Or data.Columns(i).ColumnName.ToString = "id_prod_order_det" _
            Or data.Columns(i).ColumnName.ToString = "id_design" _
            Or data.Columns(i).ColumnName.ToString = "id_product" _
            Or data.Columns(i).ColumnName.ToString = "Product Category" _
            Or data.Columns(i).ColumnName.ToString = "Product Class" _
            Or data.Columns(i).ColumnName.ToString = "Product Subcategory" _
            Or data.Columns(i).ColumnName.ToString = "Product Type" _
            Or data.Columns(i).ColumnName.ToString = "Order Number" _
            Or data.Columns(i).ColumnName.ToString = "Color" Then
                band_desc.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                If data.Columns(i).ColumnName.ToString = "Design" Then
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_design"
                ElseIf data.Columns(i).ColumnName.ToString = "Season" Then
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_season"
                ElseIf data.Columns(i).ColumnName.ToString = "Delivery" Then
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_delivery"
                ElseIf data.Columns(i).ColumnName.ToString = "Order Number" Then
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_prod_order"
                End If
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_rec") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_rec.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_ret_out") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 8
                band_ret_out.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_ret_in") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 7
                band_ret_in.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_pl") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 3
                band_pl.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_adj_in") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 7
                band_adj_in.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_adj_out") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 8
                band_adj_out.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStockQC.GroupSummary.Add(item)
            Else
                If data.Columns(i).ColumnName.ToString = "Unit Cost" Or data.Columns(i).ColumnName.ToString = "Amount" Then
                    band_total.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                    BGVFGStockQC.GroupSummary.Add(item)
                Else
                    band_total.Columns.Add(BGVFGStockQC.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVFGStockQC.Columns(data.Columns(i).ColumnName.ToString)
                    BGVFGStockQC.GroupSummary.Add(item)
                End If
            End If
            progres_bar_update(i, data.Columns.Count - 1)
        Next

        GCFGStockQC.DataSource = data
        dt_qc = data

        ''hide column
        BGVFGStockQC.Columns("id_sample").Visible = False
        BGVFGStockQC.Columns("id_design_master").Visible = False
        BGVFGStockQC.Columns("design_display_name").Visible = False
        BGVFGStockQC.Columns("uom").Visible = False
        BGVFGStockQC.Columns("Receiving WH Aging").Visible = False
        BGVFGStockQC.Columns("Product Division").Visible = False
        BGVFGStockQC.Columns("Product Source").Visible = False
        BGVFGStockQC.Columns("Product Branding").Visible = False
        BGVFGStockQC.Columns("Range").Visible = False
        BGVFGStockQC.Columns("Product Counting").Visible = False
        BGVFGStockQC.Columns("id_season").Visible = False
        BGVFGStockQC.Columns("id_prod_order").Visible = False
        BGVFGStockQC.Columns("id_prod_order_det").Visible = False
        BGVFGStockQC.Columns("id_design").Visible = False
        BGVFGStockQC.Columns("id_product").Visible = False
        BGVFGStockQC.Columns("id_delivery").Visible = False
        BGVFGStockQC.Columns("design_cop").Visible = False

        'Enable Group
        GroupControlStockQC.Enabled = True
        If data.Rows.Count > 0 Then
            BGVFGStockQC.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub
    Sub resetViewStockCard()
        id_design_selected = "-1"
        LabelControl5.Text = "-"
        LabelColor.Text = "-"
        LabelBranding.Text = "-"
        LabelSource.Text = "-"
        LabelCurrentPrice.Text = "-"
        LabelPriceType.Text = "-"
        pre_viewImages("2", PictureEdit1, id_design_selected, False)
        GroupControlInfo.Enabled = False
        GroupControlTraccking.Enabled = False
    End Sub

    Private Sub TxtCodeDsgSC_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeDsgSC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT d.id_design, d.design_code, d.design_display_name, col.`color`, cls.product_class, cls.product_class_display,
            GROUP_CONCAT(DISTINCT sz.display_name ORDER BY sz.id_code_detail ASC) AS `size_chart`, 
            IFNULL(prc.design_price,0) AS `design_price`, prc.design_price_type
            FROM tb_m_design d
            JOIN tb_opt o
            LEFT JOIN (
	            SELECT d.id_design, cd.code_detail_name AS `color` 
	            FROM tb_m_design d
	            JOIN tb_opt o
	            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code = o.id_code_fg_color
	            WHERE d.id_lookup_status_order!=2
            ) col ON col.id_design = d.id_design
            LEFT JOIN (
	            SELECT d.id_design, cd.code_detail_name AS `product_class`,cd.display_name AS `product_class_display` 
	            FROM tb_m_design d
	            JOIN tb_opt o
	            INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
	            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code = o.id_code_fg_class
	            WHERE d.id_lookup_status_order!=2
            ) cls ON cls.id_design = d.id_design
            INNER JOIN tb_m_product p ON p.id_design = d.id_design
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = pc.id_code_detail
            LEFT JOIN (
	            SELECT prc.id_design,  prc.design_price, prc.id_design_price_type, pt.design_price_type
	            FROM tb_m_design_price prc
	            INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
	            WHERE id_design_price IN (
	                SELECT MAX(id_design_price) AS id_design_price
	                FROM tb_m_design_price
	                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
	                GROUP BY id_design
	            )
            ) prc ON prc.id_design = d.id_design
            WHERE d.id_lookup_status_order!=2 AND d.design_code='" + addSlashes(TxtCodeDsgSC.Text) + "'
            GROUP BY p.id_design "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Then
                stopCustom("Design not found !")
                resetViewStockCard()
                TxtCodeDsgSC.Focus()
            Else
                id_design_selected = data.Rows(0)("id_design").ToString.ToUpper
                LabelControl5.Text = data.Rows(0)("design_display_name").ToString.ToUpper
                LabelColor.Text = data.Rows(0)("color").ToString.ToUpper
                LabelBranding.Text = data.Rows(0)("product_class").ToString.ToUpper + " (" + data.Rows(0)("product_class_display").ToString.ToUpper + ")"
                LabelSource.Text = data.Rows(0)("size_chart").ToString.ToUpper
                LabelCurrentPrice.Text = data.Rows(0)("design_price").ToString.ToUpper
                LabelPriceType.Text = data.Rows(0)("design_price_type").ToString.ToUpper
                pre_viewImages("2", PictureEdit1, id_design_selected, False)
                GroupControlInfo.Enabled = True
                GroupControlTraccking.Enabled = True
                SLEWH.Focus()
                SLEWH.ShowPopup()
            End If
            GCFGStockCard.DataSource = Nothing
            Cursor = Cursors.Default
        Else
            resetViewStockCard()
            GCFGStockCard.DataSource = Nothing
        End If
    End Sub

    Private Sub XTCFGStock_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCFGStock.SelectedPageChanged
        If XTCFGStock.SelectedTabPageIndex = 0 Then
            TxtDesignCode.Focus()
        ElseIf XTCFGStock.SelectedTabPageIndex = 1 Then
            If first_load_card Then
                Cursor = Cursors.WaitCursor
                viewWHStockCard()
                first_load_card = False
                Cursor = Cursors.Default
            End If
            TxtCodeDsgSC.Focus()
        ElseIf XTCFGStock.SelectedTabPageIndex = 4 Then
            TxtCodeDsgRsv.Focus()
        End If
    End Sub

    Private Sub SLEWH_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEWH.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            DEFrom.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            DEUntil.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            'BtnTracking.Focus()
            BtnViewStockCard.Focus()
        End If
    End Sub

    Private Sub SLEWH_Closed(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs) Handles SLEWH.Closed
        DEFrom.Focus()
    End Sub

    Private Sub BtnBrowseDesign_Click(sender As Object, e As EventArgs) Handles BtnBrowseDesign.Click
        Cursor = Cursors.WaitCursor
        FormPopUpDesign.id_pop_up = "1"
        FormPopUpDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnViewRsv.Click
        If CheckEditAllDsgRsv.EditValue = True Then
            If id_drw_rsv = "-1" Then
                stopCustom("Account can't blank")
            Else
                viewRsv()
            End If
        Else
            If id_drw_rsv = "-1" Or id_design_rsv = "-1" Then
                stopCustom("Account & design can't blank")
            Else
                viewRsv()
            End If
        End If
    End Sub

    Sub viewRsv()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_fg_rsv(" + id_drw_rsv + ", " + id_design_rsv + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRsv.DataSource = data
        GVRsv.Columns("1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVRsv.Columns("2").Caption = "2" + System.Environment.NewLine + "XS"
        GVRsv.Columns("3").Caption = "3" + System.Environment.NewLine + "S"
        GVRsv.Columns("4").Caption = "4" + System.Environment.NewLine + "M"
        GVRsv.Columns("5").Caption = "5" + System.Environment.NewLine + "ML"
        GVRsv.Columns("6").Caption = "6" + System.Environment.NewLine + "L"
        GVRsv.Columns("7").Caption = "7" + System.Environment.NewLine + "XL"
        GVRsv.Columns("8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVRsv.Columns("9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVRsv.Columns("0").Caption = "0" + System.Environment.NewLine + "SM"
        GVRsv.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodeDsgRsv_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeDsgRsv.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCodeDsgRsv.Text)
            Dim query As String = "CALL view_all_design_param('AND design_code=''" + code + "''')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Or code = "" Then
                stopCustom("Design not found !")
                id_design_rsv = "-1"
                TxtCodeDsgRsv.Text = ""
                TxtNameDsgRsv.Text = ""
                TxtCodeDsgRsv.Focus()
            Else
                id_design_rsv = data.Rows(0)("id_design").ToString.ToUpper
                TxtNameDsgRsv.Text = data.Rows(0)("design_display_name").ToString.ToUpper
                TxtCodeAccRsv.Focus()
            End If
            GCRsv.DataSource = Nothing
            Cursor = Cursors.Default
        Else
            id_design_rsv = "-1"
            TxtNameDsgRsv.Text = ""
            GCRsv.DataSource = Nothing
        End If
    End Sub

    Private Sub TxtCodeAccRsv_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeAccRsv.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtCodeAccRsv.Text)
            Dim data As DataTable = get_company_by_code_no_limit(code, "AND !ISNULL(comp.id_drawer_def) ")
            If data.Rows.Count = 0 Or code = "" Then
                stopCustom("Account not found!")
                id_drw_rsv = "-1"
                TxtNameAccRsv.Text = ""
                TxtCodeAccRsv.Text = ""
                TxtCodeAccRsv.Focus()
            Else
                If data.Rows.Count = 1 Then
                    id_drw_rsv = data.Rows(0)("id_drawer_def").ToString
                    TxtNameAccRsv.Text = data.Rows(0)("comp_name").ToString
                    BtnViewRsv.Focus()
                Else
                    FormMasterCompanyDouble.dt = data
                    FormMasterCompanyDouble.ShowDialog()
                    If id_drw_rsv <> "-1" Then
                        BtnViewRsv.Focus()
                    Else
                        TxtCodeAccRsv.Focus()
                    End If
                End If
            End If
            Cursor = Cursors.Default
        Else
            id_drw_rsv = "-1"
            TxtNameAccRsv.Text = ""
            GCRsv.DataSource = Nothing
        End If
    End Sub

    Private Sub CheckEditAllDsgRsv_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditAllDsgRsv.CheckedChanged
        GCRsv.DataSource = Nothing
        TxtCodeDsgRsv.Text = ""
        TxtNameDsgRsv.Text = ""
        If CheckEditAllDsgRsv.EditValue = True Then
            id_design_rsv = "0"
            TxtCodeDsgRsv.Properties.ReadOnly = True
            TxtCodeAccRsv.Focus()
        Else
            id_design_rsv = "-1"
            TxtCodeDsgRsv.Properties.ReadOnly = False
            TxtCodeDsgRsv.Focus()
        End If
    End Sub
    Sub resetViewStockSum()
        id_design_selected_stock_sum = "-1"
        id_product_selected_stock_sum = "-1"
        TxtDesign.Text = ""
        GCFGStock.DataSource = Nothing
        GCStockBarcode.DataSource=Nothing
    End Sub

    Private Sub TxtDesignCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesignCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim query As String = ""
            If XTCSOH.SelectedTabPageIndex = 0 Then
                query = "CALL view_all_design_param('AND design_code=''" + addSlashes(TxtDesignCode.Text) + "''')"
            Else
                query = "SELECT * FROM tb_m_product p WHERE p.product_full_code='" + addSlashes(TxtDesignCode.Text) + "' "
            End If
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count = 0 Or TxtDesignCode.Text = "" Then
                stopCustom("Product not found !")
                resetViewStockSum()
                TxtDesignCode.Focus()
            Else
                If XTCSOH.SelectedTabPageIndex = 0 Then
                    id_design_selected_stock_sum = data.Rows(0)("id_design").ToString.ToUpper
                    TxtDesign.Text = data.Rows(0)("design_display_name").ToString.ToUpper
                Else
                    id_product_selected_stock_sum = data.Rows(0)("id_product").ToString.ToUpper
                    TxtDesign.Text = data.Rows(0)("product_display_name").ToString.ToUpper
                End If
                SLEWHStockSum.Focus()
                SLEWHStockSum.ShowPopup()
            End If
            If XTCSOH.SelectedTabPageIndex = 0 Then
                GCFGStock.DataSource = Nothing
            Else
                GCStockBarcode.DataSource = Nothing
            End If
            Cursor = Cursors.Default
        Else
            resetViewStockSum()
            If XTCSOH.SelectedTabPageIndex = 0 Then
                GCFGStock.DataSource = Nothing
            Else
                GCStockBarcode.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub SLEWHStockSum_KeyDown(sender As Object, e As KeyEventArgs) Handles SLEWHStockSum.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilStockFG.Focus()
        End If
    End Sub

    Private Sub DEUntilStockFG_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilStockFG.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewStockSum.Focus()
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        GCFGStock.DataSource = Nothing
        TxtDesignCode.Text = ""
        TxtDesign.Text = ""
        If CheckEdit1.EditValue = True Then
            id_design_selected_stock_sum = "0"
            id_product_selected_stock_sum = "0"
            TxtDesignCode.Properties.ReadOnly = True
            SLEWHStockSum.Focus()
            SLEWHStockSum.ShowPopup()
        Else
            id_design_selected_stock_sum = "-1"
            id_product_selected_stock_sum = "-1"
            TxtDesignCode.Properties.ReadOnly = False
            TxtDesignCode.Focus()
        End If
    End Sub

    Private Sub XTCSOH_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSOH.SelectedPageChanged
        TxtDesignCode.Text = ""
        TxtDesign.Text = ""
        TxtDesignCode.Focus()
        If XTCSOH.SelectedTabPageIndex = 0 Then
            LabelSOH.Text = "Code"
        Else
            LabelSOH.Text = "Barcode"
        End If
    End Sub

    Private Sub FormFGStock_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            FormMenuAuth.type = "2"
            FormMenuAuth.ShowDialog()
        ElseIf e.KeyCode = Keys.F8 Then
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVSOH.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'hide all column


            'restore column opt
            GVSOH.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BGVFGStock_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVFGStock.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("Free") Or e.Column.FieldName.Contains("Reserved") Or e.Column.FieldName.Contains("Total")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        End If
    End Sub

    Private Sub BGVStockBarcode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVStockBarcode.CustomColumnDisplayText
        If (e.Column.FieldName = "qty_all_product" Or e.Column.FieldName = "qty_normal" Or e.Column.FieldName = "qty_reserved" Or e.Column.FieldName = "amo_avl" Or e.Column.FieldName = "amo_rsv" Or e.Column.FieldName = "amo_total") Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        End If
    End Sub

    Private Sub BandedGridViewFGStockCard_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedGridViewFGStockCard.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("enter") Or e.Column.FieldName = "TTL" Or e.Column.FieldName.Contains("Bal")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
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

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If XTCSOH.SelectedTabPageIndex = 0 Then
            If BGVFGStock.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "stock_soh.xlsx"
                exportToXLS(path, "soh", GCFGStock)
                Cursor = Cursors.Default
            End If
        Else
            If BGVStockBarcode.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "stock_soh_barcode.xlsx"
                exportToXLS(path, "soh_barcode", GCStockBarcode)
                Cursor = Cursors.Default
            End If
        End If

    End Sub

    Private Sub BtnExportToXLSStockCard_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSStockCard.Click
        If BandedGridViewFGStockCard.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "stock_card.xlsx"
            exportToXLS(path, "stock_card", GCFGStockCard)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSReserved_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSReserved.Click
        If GVRsv.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "stock_reserved.xlsx"
            exportToXLS(path, "stock_reserved", GCRsv)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtProduct_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProduct.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub BtnHideFilterAcc_Click(sender As Object, e As EventArgs) Handles BtnHideFilterAcc.Click
        PanelControlSOH.Visible = False
        BtnShowFilter.Visible = True
    End Sub

    Private Sub BtnShowFilter_Click(sender As Object, e As EventArgs) Handles BtnShowFilter.Click
        PanelControlSOH.Visible = True
        BtnShowFilter.Visible = False
    End Sub

    Private Sub CEFindAllProduct_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        id_design_soh = "-1"
        TxtProduct.Text = ""
        resetViewSOH()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "5"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewAcc_Click(sender As Object, e As EventArgs) Handles BtnViewAcc.Click
        If CEFindAllProduct.EditValue = False And id_design_soh = "-1" Then
            warningCustom("Please input product code first")
            Exit Sub
        End If

        If XTCStockOnHandNew.SelectedTabPageIndex = 0 Then
            viewSOHSizeBarcode()
        ElseIf XTCStockOnHandNew.SelectedTabPageIndex = 1 Then
            viewSOHCode()
        End If
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
        If id_design_soh = "-1" Then
            id_design_soh = "0"
        End If

        'excecute
        Dim query As String = ""
        If LEGroupBy.EditValue.ToString = "1" Then
            query = "CALL view_stock_fg_code('" + date_until_selected + "', '" + id_comp + "', '" + id_design_soh + "') "
        Else
            query = "CALL view_stock_fg_code_by_product('" + date_until_selected + "', '" + id_comp + "', '" + id_design_soh + "') "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOHCode.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
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
        If id_design_soh = "-1" Then
            id_design_soh = "0"
        End If

        'excecute
        Dim query As String = ""
        If LEGroupBy.EditValue.ToString = "1" Then
            query = "CALL view_stock_fg_barcode_size('" + date_until_selected + "', '" + id_comp + "', '" + id_design_soh + "') "
        Else
            query = "CALL view_stock_fg_barcode_size_by_product('" + date_until_selected + "', '" + id_comp + "', '" + id_design_soh + "') "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOH.DataSource = data
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub resetViewSOH()
        GCSOH.DataSource = Nothing
        GCSOHCode.DataSource = Nothing
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub DEUntilAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAcc.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub PanelControl3_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl3.Paint

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

    Private Sub LEGroupBy_EditValueChanged(sender As Object, e As EventArgs) Handles LEGroupBy.EditValueChanged
        resetViewSOH()
    End Sub

    Private Sub BtnViewStockCard_Click(sender As Object, e As EventArgs) Handles BtnViewStockCard.Click
        viewStockCard(True)
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged

    End Sub

    Private Sub GVSOH_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSOH.RowCellStyle
        If GVSOH.RowCount > 0 Then
            If GVSOH.GetRowCellValue(e.RowHandle, "id_design_type").ToString = "2" Then
                e.Appearance.BackColor = Color.SkyBlue
            End If
        End If
    End Sub

    Private Sub GVSOHCode_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSOHCode.RowCellStyle
        If GVSOHCode.RowCount > 0 Then
            If GVSOHCode.GetRowCellValue(e.RowHandle, "id_design_type").ToString = "2" Then
                e.Appearance.BackColor = Color.SkyBlue
            End If
        End If
    End Sub

    Private Sub XTCFGStock_Click(sender As Object, e As EventArgs) Handles XTCFGStock.Click

    End Sub

    Private Sub BtnViewAccVA_Click(sender As Object, e As EventArgs) Handles BtnViewAccVA.Click
        viewSOHVA
    End Sub

    Sub viewSOHVA()
        Cursor = Cursors.WaitCursor
        'get time 
        Dim startd As String = DateTime.Parse(DEUntilAccVA.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim cm_beg_startd As String = ""
        Dim beg_date As String = ""
        Dim beg_year As String = ""
        Dim beg_month As String = ""
        Dim qbeg As String = "SELECT STR_TO_DATE(CONCAT(YEAR('" + startd + "'),'-', MONTH('" + startd + "'),'-', '01'),'%Y-%m-%d') AS `cm_beg_startd`,
	    STR_TO_DATE(DATE_SUB(CONCAT(YEAR('" + startd + "'),'-', MONTH('" + startd + "'),'-', '01'),INTERVAL 1 DAY),'%Y-%m-%d') AS `beg_date`, 
	    YEAR((SELECT beg_date)) AS `beg_year`, MONTH((SELECT beg_date)) AS `beg_month` "
        Dim dbeg As DataTable = execute_query(qbeg, -1, True, "", "", "", "")
        cm_beg_startd = DateTime.Parse(dbeg.Rows(0)("cm_beg_startd").ToString).ToString("yyyy-MM-dd")
        beg_date = dbeg.Rows(0)("beg_date").ToString
        beg_year = dbeg.Rows(0)("beg_year").ToString
        beg_month = dbeg.Rows(0)("beg_month").ToString

        'filter comp 
        Dim id_comp_param As String = SLEAccountVA.EditValue.ToString
        Dim cond_comp As String = ""
        If id_comp_param <> "0" Then
            cond_comp = "AND loc.id_comp=" + id_comp_param + " "
        End If

        'filter desgin
        Dim id_design_param As String = id_design_soh_va
        Dim cond_design As String = ""
        If id_design_param <> "0" And id_design_param <> "-1" Then
            cond_design = "AND d.id_design='" + id_design_param + "' "
        End If

        'comp in
        Dim id_drawer_in As String = execute_query("SELECT GROUP_CONCAT(DISTINCT c.id_drawer_def) FROM tb_m_comp c WHERE c.id_wh_group='" + id_comp_param + "' ", 0, True, "", "", "", "")

        'build query
        Dim qd As String = "SELECT c.comp_number,c.id_drawer_def 
        FROM tb_m_comp c 
        WHERE c.id_drawer_def IN(" + id_drawer_in + ")
        ORDER BY c.comp_number ASC "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        Dim col_draw_beg As String = ""
        Dim col_draw_curr As String = ""
        Dim col_draw_combine As String = ""
        For d As Integer = 0 To dd.Rows.Count - 1
            If d > 0 Then
                col_draw_beg += ","
                col_draw_curr += ","
                col_draw_combine += ","
            End If
            Dim id_drawer As String = dd.Rows(d)("id_drawer_def").ToString
            Dim acc As String = dd.Rows(d)("comp_number").ToString
            col_draw_beg += "SUM(IF(f.id_wh_drawer=" + id_drawer + ",f.qty_avl,0)) AS `" + acc + "|Available Qty`, SUM(IF(f.id_wh_drawer=" + id_drawer + ",f.`qty_rsv`,0)) AS `" + acc + "|Reserved Qty`, SUM(IF(f.id_wh_drawer=" + id_drawer + ",f.`qty_ttl`,0)) AS `" + acc + "|Total Qty` "
            col_draw_curr += "SUM(IF(f.id_storage_category=2 AND f.id_wh_drawer=" + id_drawer + ", CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS `" + acc + "|Available Qty`, 
            SUM(IF(f.id_stock_status=2 AND f.id_wh_drawer=" + id_drawer + ", (IF(f.id_storage_category=1, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `" + acc + "|Reserved Qty` ,
            SUM(IF(f.id_stock_status=1 AND f.id_wh_drawer=" + id_drawer + ", (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `" + acc + "|Total Qty` "
            col_draw_combine += "SUM(f.`" + acc + "|Available Qty`) AS `Account:" + acc + "|Available Qty`, SUM(f.`" + acc + "|Reserved Qty`) AS `Account:" + acc + "|Reserved Qty`, SUM(f.`" + acc + "|Total Qty`) AS `Account:" + acc + "|Total Qty` "
        Next

        'query
        Dim query As String = "SELECT p.product_full_code AS `Product Description|Code`,  d.design_code AS `Product Description|Main Code`,d.design_display_name AS `Product Description|Description`,
        b.code_detail_name AS `Product Description|Size`, cls.class AS `Product Description|Class`, ss.season AS `Product Description|Season`, UPPER(LEFT(prc.design_cat,1)) AS `Product Description|Status`,
	    IFNULL(prc.design_price,0) AS `Price|Unit Price`,
        UPPER(LEFT(prc.design_price_type,1)) AS `Price|Price Type`,
        " + col_draw_combine + ",
        SUM(f.`Total|Available Qty`) AS `Total|Available Qty`, SUM(f.`Total|Reserved Qty`) AS `Total|Reserved Qty`, SUM(f.`Total|Total Qty`) AS `Total|Total Qty`
        FROM (
            SELECT f.id_wh_drawer, f.id_product, 
            " + col_draw_beg + ",
            SUM(f.`qty_avl`) AS `Total|Available Qty`, SUM(f.`qty_rsv`) AS `Total|Reserved Qty`, SUM(f.`qty_ttl`) AS `Total|Total Qty`
            FROM tb_storage_fg_" + beg_year + " f
            WHERE f.month='" + beg_month + "' AND f.id_wh_drawer IN (" + id_drawer_in + ")
            GROUP BY f.id_product
            UNION ALL
            SELECT f.id_wh_drawer, f.id_product, 
            " + col_draw_curr + ", 
            SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS `Total|Available Qty`, 
            SUM(IF(f.id_stock_status=2, (IF(f.id_storage_category=1, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `Total|Reserved Qty` ,
            SUM(IF(f.id_stock_status=1, (IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `Total|Total Qty` 
            FROM tb_storage_fg f
            WHERE f.storage_product_datetime>='" + cm_beg_startd + " 00:00:00'  AND f.storage_product_datetime<='" + startd + " 23:59:59' 
            AND f.id_wh_drawer IN (" + id_drawer_in + ")
            GROUP BY f.id_product 
        ) f
        INNER JOIN tb_m_product p ON p.id_product = f.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design AND d.id_lookup_status_order!=2 " + cond_design + "
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
	    INNER JOIN tb_range rg ON rg.id_range = ss.id_range
	    INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
	    INNER JOIN tb_m_code_detail b ON b.id_code_detail = pc.id_code_detail
	    LEFT JOIN (
	      SELECT dc.id_design, cd.id_code_detail AS `id_class`, cd.display_name AS `class` 
	      FROM tb_m_design_code dc
	      INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
	      GROUP BY dc.id_design
	    ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
		    SELECT prc.id_design, prc.id_design_price, prc.design_price, prc.id_design_cat,prc.design_cat, prc.design_price_type
		    FROM (
			    SELECT prc.id_design, prc.id_design_price, prc.design_price, cat.id_design_cat, cat.design_cat, pt.design_price_type
			    FROM tb_m_design_price prc
			    INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
			    INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = pt.id_design_cat
			    WHERE design_price_start_date<=NOW() AND is_active_wh=1 AND is_design_cost=0
			    ORDER BY design_price_start_date DESC, id_design_price DESC
		    ) prc
		    GROUP BY id_design
	    ) prc ON prc.id_design = d.id_design
        GROUP BY f.id_product 
        HAVING (`Total|Available Qty`!=0 OR `Total|Reserved Qty`!=0 OR `Total|Total Qty`!=0)
        ORDER BY p.product_display_name ASC, b.id_code_detail ASC "
        Dim data As DataTable = execute_query_log_time(query, -1, True, "", "", "", "")

        'setup column
        GVSOHVA.Bands.Clear()
        GVSOHVA.Columns.Clear()
        Dim column As List(Of String) = New List(Of String)
        For i = 0 To data.Columns.Count - 1
            Dim bandName As String = data.Columns(i).Caption.Split("|")(0)

            If Not column.Contains(bandName) Then
                column.Add(bandName)
            End If
        Next
        For i = 0 To column.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = column(i)

            GVSOHVA.Bands.Add(band)

            For j = 0 To data.Columns.Count - 1
                Dim bandName As String = data.Columns(j).Caption.Split("|")(0)
                Dim coluName As String = data.Columns(j).Caption.Split("|")(1)

                If bandName = column(i) Then
                    Dim col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                    col.Caption = coluName
                    col.VisibleIndex = j
                    col.FieldName = data.Columns(j).Caption

                    band.Columns.Add(col)

                    If bandName.Contains("Total") Or bandName.Contains("Account") Then
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
                        GVSOHVA.GroupSummary.Add(summary)
                    ElseIf bandName = "Price" Then
                        col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        col.DisplayFormat.FormatString = "{0:n0}"
                    End If
                End If
            Next
        Next

        'fill data
        GCSOHVA.DataSource = data

        'bestfit
        GVSOHVA.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class