Public Class FormSalesWeekly 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim current_year As String

    'selected - Tab1
    Public id_store_selected As String = "-1"
    Public label_store_selected As String = "-1"
    Public date_from_selected As String = "0000-01-01"
    Public date_until_selected As String = "9999-12-01"
    Public label_type_selected As String = "1"
    Public dt As DataTable

    'selected-Tab2
    Public date_from_weekdate_selected As String = "0000-01-01"
    Public date_until_weekdate_selected As String = "9999-12-01"
    Public dt_weekly_by_date As DataTable
    Public year_selected As String = ""
    Public week_selected As String = ""

    'selected-Tab 3
    Public date_from_weekly_selected As String = "0000-01-01"
    Public date_until_weekly_selected As String = "9999-12-01"
    Public dt_weekly As DataTable
    Public id_day_weekly_selected As String
    Public day_weekly_selected As String
    Dim first_load_weekly As Boolean = False
    Public retail_list_ws As New List(Of String)
    Public rev_bef_list_ws As New List(Of String)

    Public date_from_monthly_selected As String = "0000-01-01"
    Public date_until_monthly_selected As String = "0000-01-01"
    Public label_from_monthly_selected As String = ""
    Public label_until_monthly_selected As String = ""
    Public dt_monthly As DataTable
    Public retail_list As New List(Of String)
    Public rev_bef_list As New List(Of String)

    Private Sub FormSalesWeekly_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesWeekly_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSalesWeekly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'General
        Dim query_curr_year As String = "SELECT YEAR(NOW())"
        current_year = execute_query(query_curr_year, 0, True, "", "", "", "")
        Dim tgl As DateTime = getTimeDB()

        'tab daily
        load_group_store()
        viewOption()
        DEFrom.EditValue = tgl
        DEUntil.EditValue = tgl
        DEFromWeekly.EditValue = tgl
        DEEndWeekly.EditValue = tgl

        Dim cur_month As DataTable = execute_query("SELECT CAST(CONCAT(SUBSTRING(CURDATE(), 1, 8), '01') AS DATE) AS first_date, LAST_DAY(NOW()) AS last_date", -1, True, "", "", "", "")

        DEInvoiceFrom.EditValue = cur_month(0)("first_date")
        DEInvoiceTo.EditValue = cur_month(0)("last_date")

        'Tab Weekly
        TxtYear.Text = current_year
        TxtWeek.Text = "1"

        'Tab Monthly
        viewDay()
        viewFilterMonth()
        viewFilterYear()

        'Tab USA Sales
        view_month()
    End Sub

    Sub load_group_store()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS id_comp_group, 'All' AS comp_group, 'All Group' AS description 
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg "
        viewSearchLookupQuery(SLEStoreGroup, query, "id_comp_group", "comp_group", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If XTCPOS.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPOS.SelectedTabPageIndex = 1 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPOS.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            If XTCMonthlySales.SelectedTabPageIndex = 0 Then
                If Not first_load_weekly Then
                    LEDayWeekly.ItemIndex = LEDayWeekly.Properties.GetDataSourceRowIndex("id_day", "2")
                End If
            Else
                LEFromMonth.ItemIndex = LEFromMonth.Properties.GetDataSourceRowIndex("code_month", "01")
                LEUntilMonth.ItemIndex = LEUntilMonth.Properties.GetDataSourceRowIndex("code_month", "01")

                LEFromYear.ItemIndex = LEFromYear.Properties.GetDataSourceRowIndex("label_year", current_year)
                LEUntilYear.ItemIndex = LEUntilYear.Properties.GetDataSourceRowIndex("label_year", current_year)
            End If
        End If
    End Sub

    '=======================TAB DAILY TRANSACTION=========================
    Sub viewSalesPOS()
        'Prepare paramater
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
            id_store_selected = SLEStore.EditValue.ToString
        Catch ex As Exception
        End Try

        'modify value
        If id_store_selected = "0" Then
            label_store_selected = "All Store"
        Else
            label_store_selected = SLEStore.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        'filter grup
        Dim id_comp_group As String = SLEStoreGroup.EditValue.ToString
        Dim cond_group As String = ""
        If id_comp_group <> "0" Then
            cond_group = "AND c.id_comp_group=" + id_comp_group + " "
        End If

        'selected store
        Dim cond_store As String = ""
        If id_store_selected <> "0" Then
            cond_store = "AND c.id_comp=''" + id_store_selected + "'' "
        End If

        'filter promo
        Dim cond_promo As String = ""
        Dim cond_promo_trans As String = ""
        If CEPromo.EditValue = True Then
            cond_promo = ""
            cond_promo_trans = ""
        Else
            cond_promo = "AND a.sales_pos_total>0 "
            cond_promo_trans = "AND a.report_mark_type!=116"
        End If

        'all unit include volcom shop 100%
        Dim is_all_unit_param As String = ""
        If CEAllUnit.EditValue = True Then
            is_all_unit_param = "1"
        Else
            is_all_unit_param = "2"
        End If

        'include uniform/promo
        Dim is_promo_uni As String = ""
        If CEIncludePrmUni.EditValue = True Then
            is_promo_uni = "1"
        Else
            is_promo_uni = "2"
        End If

        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMainReport("AND a.id_report_status=6 " + cond_group + " " + cond_store + " " + cond_promo + " " + cond_promo_trans + " AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "1", is_all_unit_param, is_promo_uni)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesPOS.DataSource = data
        dt = data
        check_menu()
    End Sub

    Private Function CreateData() As DataTable
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMainReport("AND a.id_report_status=''6'' AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "1", "2", "2")

        Dim dtm As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim date_from_selectedx As String = "0001-01-01"
        If date_from_selected = "0000-01-01" Then
            date_from_selectedx = "0001-01-01"
        Else
            date_from_selectedx = date_from_selected
        End If

        If label_type_selected = "1" Then
            Dim query_c_det As ClassSalesInv = New ClassSalesInv()
            Dim query_det As String = query_c_det.queryDetailReport("0")
            Dim dtd_temp As DataTable = execute_query(query_det, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_comp LIKE '" + id_store_selected + "' AND (sales_pos_end_period >=#" + date_from_selectedx + "# AND sales_pos_end_period <=#" + date_until_selected + "#) AND id_report_status='6' "
            Dim dtd As DataTable = dtd_temp.DefaultView.ToTable
            Dim ds As New DataSet()
            ds.Tables.AddRange(New DataTable() {dtm, dtd})
            ds.Relations.Add("Detail Transaction", dtm.Columns("id_sales_pos"), dtd.Columns("id_sales_pos"))
        End If
        Return dtm
    End Function

    Sub viewStore()
        Dim id_group As String = "-1"
        Try
            id_group = SLEStoreGroup.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim cond_group As String = ""
        If id_group <> "0" Then
            cond_group = "AND a.id_comp_group='" + id_group + "' "
        End If

        Dim query As String = ""
        Dim id_comp_cat_store As String = "6"
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name, ('ALL Store') AS comp_name_label UNION ALL "
        query += "SELECT a.id_comp, a.comp_number, a.comp_name, CONCAT_WS(' - ', a.comp_number, a.comp_name) AS comp_name_label FROM tb_m_comp a WHERE a.id_comp_cat='" + id_comp_cat_store + "' " + cond_group + " "
        query += "ORDER BY comp_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_store_selected = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEStore.Properties.DataSource = Nothing
        SLEStore.Properties.DataSource = data
        SLEStore.Properties.DisplayMember = "comp_name_label"
        SLEStore.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEStore.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor

        'hide/show expand
        label_type_selected = LEOptionView.EditValue.ToString
        If label_type_selected = "1" Then
            BExpand.Visible = True
            BHide.Visible = True
        Else
            BExpand.Visible = False
            BHide.Visible = False
        End If

        viewSalesPOS()
        Cursor = Cursors.Default
    End Sub

    Sub viewOption()
        Dim query As String = getOptionView()
        viewLookupQuery(LEOptionView, query, 0, "option_view", "id_option_view")
    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Public Sub HideAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, False)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub BExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExpand.Click
        ExpandAllRows(GVSalesPOS)
    End Sub

    Private Sub BHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHide.Click
        HideAllRows(GVSalesPOS)
    End Sub

    Private Sub GVSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesPOSDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOSDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '========================TAB Weekly Transaction========================
    Sub viewDay()
        Dim query As String = "SELECT * FROM tb_lookup_day a ORDER BY a.id_day ASC "
        viewLookupQuery(LEDayWeekly, query, 0, "day", "id_day")
    End Sub

    Private Sub XTCPOS_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPOS.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub BtnViewWeeklySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewWeeklySales.Click
        Cursor = Cursors.WaitCursor
        retail_list_ws.Clear()
        rev_bef_list_ws.Clear()

        'Prepare paramater
        date_from_weekly_selected = "0000-01-01"
        date_until_weekly_selected = "9999-01-01"
        Try
            date_from_weekly_selected = DateTime.Parse(DEFromWeekly.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_weekly_selected = DateTime.Parse(DEEndWeekly.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        id_day_weekly_selected = LEDayWeekly.EditValue.ToString
        day_weekly_selected = LEDayWeekly.Properties.GetDisplayText(LEDayWeekly.EditValue)

        If date_from_weekly_selected = "0000-01-01" Or date_until_weekly_selected = "9999-01-01" Then
            stopCustom("Please fill period !")
        Else
            'Prepare Baded
            BGVSalesPOSWeekly.Columns.Clear()
            BGVSalesPOSWeekly.Bands.Clear()
            BGVSalesPOSWeekly.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ' Make the group footers always visible.
            BGVSalesPOSWeekly.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

            Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSWeekly.Bands.AddBand("DESCRIPTION")
            band_desc.AppearanceHeader.Font = New Font(BGVSalesPOSWeekly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)

            'cond gwp
            Dim include_promo As String = ""
            If CEPromoWeekly.EditValue = True Then
                include_promo = "1"
            Else
                include_promo = "2"
            End If

            'cond promo/uniform
            Dim include_unif As String = ""
            If CEIncPromoUni.EditValue = True Then
                include_unif = "1"
            Else
                include_unif = "2"
            End If

            'excecute query
            Dim query As String = "CALL view_sales_weekly_v2('" + date_from_weekly_selected + "', '" + date_until_weekly_selected + "', '" + id_day_weekly_selected + "', " + include_promo + ", " + include_unif + ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString = "id_store_contact_from" Or data.Columns(i).ColumnName.ToString = "id_store" _
                Or data.Columns(i).ColumnName.ToString = "Store Acc" Or data.Columns(i).ColumnName.ToString = "Store" _
                Or data.Columns(i).ColumnName.ToString = "Store Group" Or data.Columns(i).ColumnName.ToString = "Store Group Desc" _
                Or data.Columns(i).ColumnName.ToString = "Area" Or data.Columns(i).ColumnName.ToString = "Country" _
                Or data.Columns(i).ColumnName.ToString = "Region" Or data.Columns(i).ColumnName.ToString = "State" Or data.Columns(i).ColumnName.ToString = "City" _
                Or data.Columns(i).ColumnName.ToString = "Store Type" Or data.Columns(i).ColumnName.ToString = "PIC" _
                Or data.Columns(i).ColumnName.ToString = "id_area" Or data.Columns(i).ColumnName.ToString = "id_country" _
                Or data.Columns(i).ColumnName.ToString = "id_region" Or data.Columns(i).ColumnName.ToString = "id_store_type" _
                Or data.Columns(i).ColumnName.ToString = "id_state" Or data.Columns(i).ColumnName.ToString = "id_city" _
                Then
                    band_desc.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    If data.Columns(i).ColumnName.ToString = "Store" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store"
                    ElseIf data.Columns(i).ColumnName.ToString = "Area" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_area"
                    ElseIf data.Columns(i).ColumnName.ToString = "Country" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_country"
                    ElseIf data.Columns(i).ColumnName.ToString = "Region" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_region"
                    ElseIf data.Columns(i).ColumnName.ToString = "State" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_state"
                    ElseIf data.Columns(i).ColumnName.ToString = "City" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_city"
                    ElseIf data.Columns(i).ColumnName.ToString = "Store Type" Then
                        BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store_type"
                    End If
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Sales") Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 6
                    retail_list_ws.Add(data.Columns(i).ColumnName.ToString)

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSWeekly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSWeekly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSWeekly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                    End If

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSWeekly.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue_Bef") Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 12
                    rev_bef_list_ws.Add(data.Columns(i).ColumnName.ToString)

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSWeekly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSWeekly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSWeekly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                    End If

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSWeekly.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue") Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 8

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSWeekly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSWeekly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSWeekly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                    End If

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSWeekly.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Qty") Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 4

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSWeekly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Qty"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSWeekly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSWeekly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSWeekly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Qty"))
                    End If

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n0}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSWeekly.GroupSummary.Add(item)
                End If
            Next
            dt_weekly = data
            GCSalesPOSWeekly.DataSource = data


            'hide column
            BGVSalesPOSWeekly.Columns("id_store").Visible = False
            BGVSalesPOSWeekly.Columns("id_store_contact_from").Visible = False
            BGVSalesPOSWeekly.Columns("id_area").Visible = False
            BGVSalesPOSWeekly.Columns("id_country").Visible = False
            BGVSalesPOSWeekly.Columns("id_region").Visible = False
            BGVSalesPOSWeekly.Columns("id_state").Visible = False
            BGVSalesPOSWeekly.Columns("id_city").Visible = False
            BGVSalesPOSWeekly.Columns("id_store_type").Visible = False

            GroupControlWeeklySales.Enabled = True
            CheckShowRetailWS.Checked = "True"
            CheckShowRevBefTaxWS.Checked = "True"
        End If
        first_load_weekly = True
        Cursor = Cursors.Default
    End Sub

    '===============TAB SALES MONTHLY================================
    Sub viewFilterMonth()
        Dim query As String = "CALL view_master_month()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEFromMonth.Properties.DataSource = Nothing
        LEFromMonth.Properties.DataSource = data
        LEFromMonth.Properties.DisplayMember = "label_month"
        LEFromMonth.Properties.ValueMember = "code_month"
        LEFromMonth.ItemIndex = 0

        LEUntilMonth.Properties.DataSource = Nothing
        LEUntilMonth.Properties.DataSource = data
        LEUntilMonth.Properties.DisplayMember = "label_month"
        LEUntilMonth.Properties.ValueMember = "code_month"
        LEUntilMonth.ItemIndex = 0
    End Sub

    Sub viewFilterYear()
        Dim query As String = "CALL view_master_year()"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEFromYear.Properties.DataSource = Nothing
        LEFromYear.Properties.DataSource = data
        LEFromYear.Properties.DisplayMember = "label_year"
        LEFromYear.Properties.ValueMember = "label_year"
        LEFromYear.ItemIndex = 0

        LEUntilYear.Properties.DataSource = Nothing
        LEUntilYear.Properties.DataSource = data
        LEUntilYear.Properties.DisplayMember = "label_year"
        LEUntilYear.Properties.ValueMember = "label_year"
        LEUntilYear.ItemIndex = 0
    End Sub

    Private Sub BtnViewMonthlySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewMonthlySales.Click
        Cursor = Cursors.WaitCursor
        retail_list.Clear()
        rev_bef_list.Clear()

        date_from_monthly_selected = LEFromYear.EditValue.ToString + "-" + LEFromMonth.EditValue.ToString + "-" + "01"
        date_until_monthly_selected = LEUntilYear.EditValue.ToString + "-" + LEUntilMonth.EditValue.ToString + "-" + "01"
        label_from_monthly_selected = LEFromMonth.Properties.GetDisplayText(LEFromMonth.EditValue) + " " + LEFromYear.Properties.GetDisplayText(LEFromYear.EditValue)
        label_until_monthly_selected = LEUntilMonth.Properties.GetDisplayText(LEUntilMonth.EditValue) + " " + LEUntilYear.Properties.GetDisplayText(LEUntilYear.EditValue)

        If date_until_monthly_selected < date_from_monthly_selected Then
            stopCustom("Period until not allowed smaller than period from")
        Else
            'Prepare Baded
            BGVSalesPOSMonthly.Columns.Clear()
            BGVSalesPOSMonthly.Bands.Clear()
            BGVSalesPOSMonthly.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ' Make the group footers always visible.
            BGVSalesPOSMonthly.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

            Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand("DESCRIPTION")
            Dim band_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_desc
            band_desc.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_total_created = False

            'excecute query
            Dim query As String = "CALL view_sales_monthly('" + date_from_monthly_selected + "', '" + date_until_monthly_selected + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString = "id_store_contact_from" Or data.Columns(i).ColumnName.ToString = "id_store" _
                Or data.Columns(i).ColumnName.ToString = "Store" Or data.Columns(i).ColumnName.ToString = "Area" Or data.Columns(i).ColumnName.ToString = "Country" _
                Or data.Columns(i).ColumnName.ToString = "Region" Or data.Columns(i).ColumnName.ToString = "State" Or data.Columns(i).ColumnName.ToString = "City" _
                Or data.Columns(i).ColumnName.ToString = "Store Type" Or data.Columns(i).ColumnName.ToString = "PIC" _
                Or data.Columns(i).ColumnName.ToString = "id_area" Or data.Columns(i).ColumnName.ToString = "id_country" _
                Or data.Columns(i).ColumnName.ToString = "id_region" Or data.Columns(i).ColumnName.ToString = "id_store_type" _
                Or data.Columns(i).ColumnName.ToString = "id_state" Or data.Columns(i).ColumnName.ToString = "id_city" _
                Then
                    band_desc.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    If data.Columns(i).ColumnName.ToString = "Store" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store"
                    ElseIf data.Columns(i).ColumnName.ToString = "Area" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_area"
                    ElseIf data.Columns(i).ColumnName.ToString = "Country" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_country"
                    ElseIf data.Columns(i).ColumnName.ToString = "Region" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_region"
                    ElseIf data.Columns(i).ColumnName.ToString = "State" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_state"
                    ElseIf data.Columns(i).ColumnName.ToString = "City" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_city"
                    ElseIf data.Columns(i).ColumnName.ToString = "Store Type" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store_type"
                    End If
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Sales") And data.Columns(i).ColumnName.ToString <> "Total_Sales" And data.Columns(i).ColumnName.ToString <> "Total_Revenue_Bef" And data.Columns(i).ColumnName.ToString <> "Total_Revenue" Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 6
                    retail_list.Add(data.Columns(i).ColumnName.ToString)

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSMonthly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                    End If

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSMonthly.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue_Bef") And data.Columns(i).ColumnName.ToString <> "Total_Sales" And data.Columns(i).ColumnName.ToString <> "Total_Revenue_Bef" And data.Columns(i).ColumnName.ToString <> "Total_Revenue" Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 12
                    rev_bef_list.Add(data.Columns(i).ColumnName.ToString)

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSMonthly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                    End If

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSMonthly.GroupSummary.Add(item)
                ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue") And data.Columns(i).ColumnName.ToString <> "Total_Sales" And data.Columns(i).ColumnName.ToString <> "Total_Revenue_Bef" And data.Columns(i).ColumnName.ToString <> "Total_Revenue" Then
                    Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 8

                    Dim found_band As Boolean = False
                    For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSMonthly.Bands
                        If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                            found_band = True
                            group.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                            Exit For
                        End If
                    Next group

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_new.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                    End If

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSMonthly.GroupSummary.Add(item)
                Else
                    If Not band_total_created Then
                        band_total = BGVSalesPOSMonthly.Bands.AddBand("TOTAL")
                        band_total.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSWeekly.Appearance.Row.Font.Size, FontStyle.Bold)
                        band_total_created = True
                    End If
                    If data.Columns(i).ColumnName.ToString = "Total_Sales" Then
                        band_total.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                    ElseIf data.Columns(i).ColumnName.ToString = "Total_Revenue_Bef" Then
                        band_total.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev Before Tax"))
                    ElseIf data.Columns(i).ColumnName.ToString = "Total_Revenue" Then
                        band_total.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev After Tax"))
                    End If

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
                    item.ShowInGroupColumnFooter = BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString)
                    BGVSalesPOSMonthly.GroupSummary.Add(item)
                End If
            Next
            dt_monthly = data
            GCSalesPOSMonthly.DataSource = data


            'hide column
            BGVSalesPOSMonthly.Columns("id_store").Visible = False
            BGVSalesPOSMonthly.Columns("id_store_contact_from").Visible = False
            BGVSalesPOSMonthly.Columns("id_area").Visible = False
            BGVSalesPOSMonthly.Columns("id_country").Visible = False
            BGVSalesPOSMonthly.Columns("id_region").Visible = False
            BGVSalesPOSMonthly.Columns("id_state").Visible = False
            BGVSalesPOSMonthly.Columns("id_city").Visible = False
            BGVSalesPOSMonthly.Columns("id_store_type").Visible = False
            GroupControlMonthlySales.Enabled = True

            CheckShowRetail.Checked = "True"
            CheckShowRevBefTax.Checked = "True"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckShowRetail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckShowRetail.CheckedChanged
        If CheckShowRetail.EditValue.ToString = "False" Then
            For i As Integer = 0 To (retail_list.Count - 1)
                BGVSalesPOSMonthly.Columns(retail_list(i)).Visible = False
            Next
            BGVSalesPOSMonthly.Columns("Total_Sales").Visible = False
        Else
            For i As Integer = 0 To (retail_list.Count - 1)
                BGVSalesPOSMonthly.Columns(retail_list(i)).Visible = True
            Next
            BGVSalesPOSMonthly.Columns("Total_Sales").Visible = True
        End If
    End Sub

    Private Sub CheckShowRevBefTax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckShowRevBefTax.CheckedChanged
        If CheckShowRevBefTax.EditValue.ToString = "False" Then
            For i As Integer = 0 To (rev_bef_list.Count - 1)
                BGVSalesPOSMonthly.Columns(rev_bef_list(i)).Visible = False
            Next
            BGVSalesPOSMonthly.Columns("Total_Revenue_Bef").Visible = False
        Else
            For i As Integer = 0 To (rev_bef_list.Count - 1)
                BGVSalesPOSMonthly.Columns(rev_bef_list(i)).Visible = True
            Next
            BGVSalesPOSMonthly.Columns("Total_Revenue_Bef").Visible = True
        End If
    End Sub

    Private Sub CheckShowRetailWS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckShowRetailWS.CheckedChanged
        If CheckShowRetailWS.EditValue.ToString = "False" Then
            For i As Integer = 0 To (retail_list_ws.Count - 1)
                BGVSalesPOSWeekly.Columns(retail_list_ws(i)).Visible = False
            Next
            BGVSalesPOSWeekly.Columns("Total_Sales").Visible = False
        Else
            For i As Integer = 0 To (retail_list_ws.Count - 1)
                BGVSalesPOSWeekly.Columns(retail_list_ws(i)).Visible = True
            Next
            BGVSalesPOSWeekly.Columns("Total_Sales").Visible = True
        End If
    End Sub

    Private Sub CheckShowRevBefTaxWS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckShowRevBefTaxWS.CheckedChanged
        If CheckShowRevBefTaxWS.EditValue.ToString = "False" Then
            For i As Integer = 0 To (rev_bef_list_ws.Count - 1)
                BGVSalesPOSWeekly.Columns(rev_bef_list_ws(i)).Visible = False
            Next
            BGVSalesPOSWeekly.Columns("Total_Revenue_Bef").Visible = False
        Else
            For i As Integer = 0 To (rev_bef_list_ws.Count - 1)
                BGVSalesPOSWeekly.Columns(rev_bef_list_ws(i)).Visible = True
            Next
            BGVSalesPOSWeekly.Columns("Total_Revenue_Bef").Visible = True
        End If
    End Sub

    Private Sub ToolTipControllerNew_GetActiveObjectInfo(ByVal sender As System.Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipControllerNew.GetActiveObjectInfo
        If Not e.SelectedControl Is GCSalesPOS Then Return

        Dim info As DevExpress.Utils.ToolTipControlInfo = Nothing
        'Get the view at the current mouse position
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = GCSalesPOS.GetViewAt(e.ControlMousePosition)
        If view Is Nothing Then Return
        'Get the view's element information that resides at the current position
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)
        'Display a hint for row indicator cells

        Dim o As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
        Dim text As String = "Double click to see detail document."
        info = New DevExpress.Utils.ToolTipControlInfo(o, text)

        'Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
        If Not info Is Nothing Then e.Info = info
    End Sub

    Private Sub GVSalesPOS_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesPOS.DoubleClick
        Cursor = Cursors.WaitCursor
        Dim id_sales_pos As String = "-1"
        Try
            id_sales_pos = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try
        Dim rmt As String = "-1"
        Try
            rmt = GVSalesPOS.GetFocusedRowCellValue("report_mark_type").ToString
        Catch ex As Exception
        End Try
        Dim sm As New ClassShowPopUp()
        sm.report_mark_type = rmt
        sm.id_report = id_sales_pos
        sm.show()
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
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.True
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.True
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

    Private Sub BtnExportToXLSDaily_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSDaily.Click
        If GVSalesPOS.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sr_daily.xlsx"
            exportToXLS(path, "daily sales", GCSalesPOS)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CESearchByWeek_CheckedChanged(sender As Object, e As EventArgs)
        'If CESearchByWeek.EditValue = True Then
        '    TxtYear.Enabled = True
        '    TxtWeek.Enabled = True
        '    TxtYear.Text = current_year
        '    TxtWeek.Text = "1"
        '    DEFromWeekly.Enabled = False
        '    DEEndWeekly.Enabled = False
        '    LEDayWeekly.ItemIndex = LEDayWeekly.Properties.GetDataSourceRowIndex("id_day", "2")
        '    LEDayWeekly.Enabled = False
        '    TxtYear.Focus()
        'Else
        '    TxtYear.Enabled = False
        '    TxtWeek.Enabled = False
        '    TxtYear.Text = ""
        '    TxtWeek.Text = ""
        '    DEFromWeekly.Enabled = True
        '    DEEndWeekly.Enabled = True
        '    LEDayWeekly.ItemIndex = LEDayWeekly.Properties.GetDataSourceRowIndex("id_day", "2")
        '    LEDayWeekly.Enabled = True
        '    DEFromWeekly.Focus()
        'End If
    End Sub

    Private Sub TxtYear_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TxtWeek_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Sub fillWeeklyPeriod()
        Cursor = Cursors.WaitCursor
        Dim week As String = "1"
        Try
            week = TxtWeek.Text
        Catch ex As Exception
        End Try
        If week = "" Then
            week = "1"
        End If
        Dim query As String = "CALL view_range_date_by_week_number('" + TxtYear.Text + "', " + week + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DEFromWeek.EditValue = data.Rows(0)("FirstDayOfWeek")
        DEEndWeek.EditValue = data.Rows(0)("LastDayOfWeek")
        Cursor = Cursors.Default
    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub BtnExportToXLSWeekly_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSWeekly.Click
        If BGVSalesPOSWeekly.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            BGVSalesPOSWeekly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To BGVSalesPOSWeekly.Columns.Count - 1
                If BGVSalesPOSWeekly.Columns(i).OwnerBand.ToString <> "DESCRIPTION" Then
                    BGVSalesPOSWeekly.Columns(i).Caption = BGVSalesPOSWeekly.Columns(i).OwnerBand.ToString + " " + BGVSalesPOSWeekly.Columns(i).Caption
                End If
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sr_monthly_by_week.xlsx"
            exportToXLS(path, "monthly sales by week", GCSalesPOSWeekly)

            'restore column opt
            BGVSalesPOSWeekly.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TxtYear_EditValueChanged(sender As Object, e As EventArgs) Handles TxtYear.EditValueChanged
        fillWeeklyPeriod()
    End Sub

    Private Sub TxtWeek_EditValueChanged(sender As Object, e As EventArgs) Handles TxtWeek.EditValueChanged
        fillWeeklyPeriod()
    End Sub

    Private Sub TxtYear_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TxtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtWeek.Focus()
        End If
    End Sub

    Private Sub TxtWeek_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TxtWeek.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewDateWeekly.Focus()
        End If
    End Sub

    Private Sub BtnExportToXLSDateWeekly_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSDateWeekly.Click
        If BGVSalesWeeklyByDate.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            BGVSalesWeeklyByDate.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To BGVSalesWeeklyByDate.Columns.Count - 1
                If BGVSalesWeeklyByDate.Columns(i).OwnerBand.ToString <> "DESCRIPTION" Then
                    BGVSalesWeeklyByDate.Columns(i).Caption = BGVSalesWeeklyByDate.Columns(i).OwnerBand.ToString + " " + BGVSalesWeeklyByDate.Columns(i).Caption
                End If
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "sr_weekly.xlsx"
            exportToXLS(path, "weekly sales", GCSalesWeeklyByDate)

            'restore column opt
            BGVSalesWeeklyByDate.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewDateWeekly_Click(sender As Object, e As EventArgs) Handles BtnViewDateWeekly.Click
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        date_from_weekdate_selected = "0000-01-01"
        date_until_weekdate_selected = "9999-01-01"
        Try
            date_from_weekdate_selected = DateTime.Parse(DEFromWeek.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_weekdate_selected = DateTime.Parse(DEEndWeek.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        year_selected = TxtYear.Text
        week_selected = TxtWeek.Text

        'Prepare Baded
        BGVSalesWeeklyByDate.Columns.Clear()
        BGVSalesWeeklyByDate.Bands.Clear()
        BGVSalesWeeklyByDate.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        ' Make the group footers always visible.
        BGVSalesWeeklyByDate.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'set band
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesWeeklyByDate.Bands.AddBand("DESCRIPTION")
        band_desc.AppearanceHeader.Font = New Font(BGVSalesWeeklyByDate.Appearance.Row.Font.FontFamily, BGVSalesWeeklyByDate.Appearance.Row.Font.Size, FontStyle.Bold)

        'cond gwp
        Dim include_promo As String = ""
        If CEPromoWeeklyByDate.EditValue = True Then
            include_promo = "1"
        Else
            include_promo = "2"
        End If

        'cond promo/uni
        Dim include_uni As String = ""
        If CEIncludePrmUniWeekly.EditValue = True Then
            include_uni = "1"
        Else
            include_uni = "2"
        End If

        'excecute query
        Dim query As String = "CALL view_sales_weekly_by_date_v2('" + date_from_weekdate_selected + "', '" + date_until_weekdate_selected + "', " + include_promo + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString.Contains("_Qty") Then
                Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 4

                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesWeeklyByDate.Bands
                    If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                        found_band = True
                        group.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Qty"))
                        Exit For
                    End If
                Next group

                If Not found_band Then
                    Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesWeeklyByDate.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                    band_new.AppearanceHeader.Font = New Font(BGVSalesWeeklyByDate.Appearance.Row.Font.FontFamily, BGVSalesWeeklyByDate.Appearance.Row.Font.Size, FontStyle.Bold)
                    band_new.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Qty"))
                End If

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString)
                BGVSalesWeeklyByDate.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Sales") Then
                Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 6

                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesWeeklyByDate.Bands
                    If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                        found_band = True
                        group.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                        Exit For
                    End If
                Next group

                If Not found_band Then
                    Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesWeeklyByDate.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                    band_new.AppearanceHeader.Font = New Font(BGVSalesWeeklyByDate.Appearance.Row.Font.FontFamily, BGVSalesWeeklyByDate.Appearance.Row.Font.Size, FontStyle.Bold)
                    band_new.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Retail"))
                End If

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString)
                BGVSalesWeeklyByDate.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue_Bef") Then
                Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 12
                rev_bef_list_ws.Add(data.Columns(i).ColumnName.ToString)

                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesWeeklyByDate.Bands
                    If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                        found_band = True
                        group.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                        Exit For
                    End If
                Next group

                If Not found_band Then
                    Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesWeeklyByDate.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                    band_new.AppearanceHeader.Font = New Font(BGVSalesWeeklyByDate.Appearance.Row.Font.FontFamily, BGVSalesWeeklyByDate.Appearance.Row.Font.Size, FontStyle.Bold)
                    band_new.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. Before Tax"))
                End If

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString)
                BGVSalesWeeklyByDate.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("_Revenue") Then
                Dim st_caption As Integer = data.Columns(i).ColumnName.ToString.Length - 8

                Dim found_band As Boolean = False
                For Each group As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesWeeklyByDate.Bands
                    If group.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, st_caption) Then
                        found_band = True
                        group.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                        Exit For
                    End If
                Next group

                If Not found_band Then
                    Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesWeeklyByDate.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, st_caption))
                    band_new.AppearanceHeader.Font = New Font(BGVSalesWeeklyByDate.Appearance.Row.Font.FontFamily, BGVSalesWeeklyByDate.Appearance.Row.Font.Size, FontStyle.Bold)
                    band_new.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Rev. After Tax"))
                End If

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString)
                BGVSalesWeeklyByDate.GroupSummary.Add(item)
            Else
                band_desc.Columns.Add(BGVSalesWeeklyByDate.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                If data.Columns(i).ColumnName.ToString = "Store" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store"
                ElseIf data.Columns(i).ColumnName.ToString = "Area" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_area"
                ElseIf data.Columns(i).ColumnName.ToString = "Country" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_country"
                ElseIf data.Columns(i).ColumnName.ToString = "Region" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_region"
                ElseIf data.Columns(i).ColumnName.ToString = "State" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_state"
                ElseIf data.Columns(i).ColumnName.ToString = "City" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_city"
                ElseIf data.Columns(i).ColumnName.ToString = "Store Type" Then
                    BGVSalesWeeklyByDate.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_store_type"
                End If
            End If
        Next
        GCSalesWeeklyByDate.DataSource = data
        dt_weekly_by_date = data

        'hide column
        BGVSalesWeeklyByDate.Columns("id_store").Visible = False
        BGVSalesWeeklyByDate.Columns("id_area").Visible = False
        BGVSalesWeeklyByDate.Columns("id_country").Visible = False
        BGVSalesWeeklyByDate.Columns("id_region").Visible = False
        BGVSalesWeeklyByDate.Columns("id_state").Visible = False
        BGVSalesWeeklyByDate.Columns("id_city").Visible = False
        BGVSalesWeeklyByDate.Columns("id_store_type").Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreGroup.EditValueChanged
        viewStore()
    End Sub

    Sub view_invoice_week()
        GVInvoiceWeek.Columns.Clear()
        GVInvoiceWeek.Bands.Clear()

        Dim s_data As DataTable = execute_query("CALL view_inv_week('" + Date.Parse(DEInvoiceFrom.EditValue.ToString()).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEInvoiceTo.EditValue.ToString()).ToString("yyyy-MM-dd") + "')", -1, True, "", "", "", "")

        Dim list_month As List(Of String) = New List(Of String)
        Dim list_week As List(Of List(Of String)) = New List(Of List(Of String))
        Dim list_detail As List(Of String) = New List(Of String)

        Dim temp_week_list As List(Of String) = New List(Of String)

        For i = 0 To s_data.Columns.Count - 1
            If s_data.Columns(i).ColumnName.Contains("s/d") Then
                Dim a_date() As String = s_data.Columns(i).ColumnName.Split("/")

                a_date(0) = a_date(0).Replace(" ", "").Replace("s", "")
                a_date(1) = a_date(1).Replace(" ", "").Replace("d", "")

                Dim start_date As Date = Date.Parse(a_date(0))
                Dim end_date As Date = Date.Parse(a_date(1))

                If list_month.Count = 0 Then
                    list_month.Add(start_date.ToString("MMMM yyyy"))

                    'detail week
                    temp_week_list = New List(Of String)

                    list_week.Add(temp_week_list)
                Else
                    If Not list_month(list_month.Count - 1) = start_date.ToString("MMMM yyyy") Then
                        list_month.Add(start_date.ToString("MMMM yyyy"))

                        'detail week
                        temp_week_list = New List(Of String)

                        list_week.Add(temp_week_list)
                    End If
                End If

                temp_week_list.Add(start_date.ToString("dd") + " - " + end_date.ToString("dd"))

                list_detail.Add(s_data.Columns(i).ColumnName)
            End If
        Next

        'add band
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

        band_desc.Caption = "Description"

        GVInvoiceWeek.Bands.Add(band_desc)

        Dim list_fieldname As List(Of String) = New List(Of String)
        Dim list_caption As List(Of String) = New List(Of String)

        list_fieldname.Add("comp_group")
        list_fieldname.Add("comp_group_desc")
        list_fieldname.Add("comp_number")
        list_fieldname.Add("comp_name")
        list_fieldname.Add("total_qty")
        list_fieldname.Add("sales_pos_total_retail")
        list_fieldname.Add("sales_pos_discount_value")
        list_fieldname.Add("sales_pos_potongan_value")
        list_fieldname.Add("sales_pos_netto")
        list_fieldname.Add("sales_pos_revenue")

        list_caption.Add("Store Group")
        list_caption.Add("Store Group Desc")
        list_caption.Add("Store Acc")
        list_caption.Add("Store")
        list_caption.Add("Qty")
        list_caption.Add("Retail")
        list_caption.Add("Discount")
        list_caption.Add("Potongan")
        list_caption.Add("Netto")
        list_caption.Add("Revenue")

        For i = 0 To list_fieldname.Count - 1
            Dim column_desc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

            column_desc.Caption = list_caption(i)
            column_desc.FieldName = list_fieldname(i)
            column_desc.VisibleIndex = i
            column_desc.OptionsColumn.AllowEdit = False

            If list_fieldname(i) = "total_qty" Or
                list_fieldname(i) = "sales_pos_total_retail" Or
                list_fieldname(i) = "sales_pos_discount_value" Or
                list_fieldname(i) = "sales_pos_potongan_value" Or
                list_fieldname(i) = "sales_pos_netto" Or
                list_fieldname(i) = "sales_pos_revenue" Then
                column_desc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                column_desc.DisplayFormat.FormatString = "N2"
                column_desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                column_desc.Summary.Add(DevExpress.Data.SummaryItemType.Sum, list_fieldname(i), "{0:N2}")
            End If

            band_desc.Columns.Add(column_desc)
        Next

        Dim l As Integer = 0

        For i = 0 To list_month.Count - 1
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand

            band.Caption = list_month(i)

            GVInvoiceWeek.Bands.Add(band)

            For j = 0 To list_week(i).Count - 1
                Dim column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn

                column.Caption = list_week(i)(j)
                column.FieldName = list_detail(l)
                column.VisibleIndex = j + list_fieldname.Count
                column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                column.ColumnEdit = RepositoryItemHyperLinkEdit

                band.Columns.Add(column)

                l = l + 1
            Next
        Next

        GCInvoiceWeek.DataSource = s_data
        GVInvoiceWeek.BestFitColumns()
    End Sub

    Private Sub SBInvoiceTo_Click(sender As Object, e As EventArgs) Handles SBInvoiceTo.Click
        view_invoice_week()
    End Sub

    Private Sub SBInvoiceExportExcel_Click(sender As Object, e As EventArgs) Handles SBInvoiceExportExcel.Click
        If GVInvoiceWeek.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            path = path + "in_weekly.xlsx"

            Dim op As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVInvoiceWeek.ExportToXlsx(path, op)

            Process.Start(path)

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVInvoiceWeek_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVInvoiceWeek.RowStyle
        If GVInvoiceWeek.GetRowCellValue(e.RowHandle, "total_qty") = 0 Then
            e.Appearance.BackColor = Color.LightPink
        End If
    End Sub

    Sub view_month()
        Dim d_start As Date = Date.Parse("2020-01-01")
        Dim d_before As Date = Date.Parse(Date.Now.Year.ToString() + "-" + Date.Now.Month.ToString() + "-01")

        Dim cnt As Boolean = True

        Dim data As DataTable = New DataTable

        data.Columns.Add("month", GetType(String))
        data.Columns.Add("text", GetType(String))

        While cnt
            data.Rows.Add(d_start.ToString("yyyy-MM-dd"), d_start.ToString("MMMM yyyy"))

            d_start = d_start.AddMonths(1)

            If d_start = d_before Then
                data.Rows.Add(d_start.ToString("yyyy-MM-dd"), d_start.ToString("MMMM yyyy"))

                cnt = False
            End If
        End While

        SLUEUSASales.Properties.DataSource = data
        SLUEUSASales.Properties.DisplayMember = "text"
        SLUEUSASales.Properties.ValueMember = "month"
        SLUEUSASales.EditValue = data.Rows(data.Rows.Count - 1)("month")
    End Sub

    Sub view_usa_sales()
        Dim royalty As String = execute_query("SELECT usa_sales_royalty FROM tb_opt_sales LIMIT 1", 0, True, "", "", "", "")

        Dim last_day As Integer = Date.DaysInMonth(Date.Parse(SLUEUSASales.EditValue.ToString).Year, Date.Parse(SLUEUSASales.EditValue.ToString).Month)

        Dim date_from As String = SLUEUSASales.EditValue.ToString
        Dim date_to As String = SLUEUSASales.EditValue.ToString.Substring(0, 8) + last_day.ToString

        Dim query_c As ClassSalesInv = New ClassSalesInv()

        Dim query As String = query_c.queryMainReport("AND a.id_report_status=6 AND (a.sales_pos_end_period >= ''" + date_from + "'' AND a.sales_pos_end_period <= ''" + date_to + "'') AND a.sales_pos_total > 0 AND a.report_mark_type != 116 ", "1", "2", "2")

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim store As DataTable = execute_query("SELECT id_sal_usa_store, store_name, 0.00 AS total_sales FROM tb_lookup_sal_usa_store", -1, True, "", "", "", "")
        Dim store_detail As DataTable = execute_query("
            SELECT u.id_sal_usa_store, c.comp_number, u.ppn_ptc, 0.00 AS total_sales
            FROM tb_lookup_sal_usa_store_detail AS u
            LEFT JOIN tb_m_comp AS c ON u.id_comp = c.id_comp
        ", -1, True, "", "", "", "")

        Dim royalty_volcom As Decimal = 0.00

        For i = 0 To data.Rows.Count - 1
            royalty_volcom += data.Rows(i)("sales_pos_revenue")

            For j = 0 To store_detail.Rows.Count - 1
                If data.Rows(i)("store_number").ToString = store_detail.Rows(j)("comp_number").ToString Then
                    store_detail.Rows(j)("total_sales") += data.Rows(i)("sales_pos_netto")
                End If
            Next
        Next

        For i = 0 To store_detail.Rows.Count - 1
            store_detail.Rows(i)("total_sales") = (store_detail.Rows(i)("total_sales") * store_detail.Rows(i)("ppn_ptc")) / (100 - store_detail.Rows(i)("ppn_ptc"))

            store_detail.Rows(i)("total_sales") = store_detail.Rows(i)("total_sales") * 100 / 110
        Next

        For i = 0 To store.Rows.Count - 1
            For j = 0 To store_detail.Rows.Count - 1
                If store.Rows(i)("id_sal_usa_store").ToString = store_detail.Rows(j)("id_sal_usa_store").ToString Then
                    store.Rows(i)("total_sales") += store_detail.Rows(j)("total_sales")
                End If
            Next
        Next

        'data 1
        Dim data1 As DataTable = execute_query("SELECT 1 AS `no`, '01 - " + date_to.Substring(8, 2) + " " + SLUEUSASales.Text + "' AS `date`, 0.00 AS amount", -1, True, "", "", "", "")

        For i = 0 To store.Rows.Count - 1
            data1.Rows(0)("amount") += store.Rows(i)("total_sales")
        Next

        data1.Rows(0)("amount") += royalty_volcom

        GCUSASales.DataSource = data1

        'data 2
        Dim data2 As DataTable = execute_query("SELECT id_sal_usa_store, CONCAT('Sales Volcom ', store_name, ' for Royalty') AS `text`, 0.00 AS amount FROM tb_lookup_sal_usa_store UNION ALL SELECT 0 AS id_sal_usa_store, 'Sales Volcom for Royalty' AS `text`, 0.00 AS amount", -1, True, "", "", "", "")

        For i = 0 To store.Rows.Count - 1
            For j = 0 To data2.Rows.Count - 1
                If store.Rows(i)("id_sal_usa_store").ToString = data2.Rows(j)("id_sal_usa_store").ToString Then
                    data2.Rows(j)("amount") += store.Rows(i)("total_sales")
                End If

                If data2.Rows(j)("id_sal_usa_store").ToString = "0" Then
                    data2.Rows(j)("amount") = royalty_volcom
                End If
            Next
        Next

        GCDetailSales.DataSource = data2

        'data 3
        Dim data3 As DataTable = execute_query("SELECT 0 AS id_sal_usa_store, '1: Total Sales for Royalty' AS `group`, 'Royalty = " + royalty + "%' AS `text`, '" + SLUEUSASales.Text + "' AS `date`, 0.00 AS amount UNION ALL SELECT id_sal_usa_store, CONCAT((id_sal_usa_store + 1), ': Total Sales ', store_name, ' for Royalty') AS `group`, 'Royalty = " + royalty + "%' AS `text`, '" + SLUEUSASales.Text + "' AS `date`, 0.00 AS amount FROM tb_lookup_sal_usa_store", -1, True, "", "", "", "")

        For i = 0 To data2.Rows.Count - 1
            For j = 0 To data3.Rows.Count - 1
                If data2.Rows(i)("id_sal_usa_store").ToString = data3.Rows(j)("id_sal_usa_store").ToString Then
                    data3.Rows(j)("amount") = data2.Rows(i)("amount") * (Integer.Parse(royalty) / 100)
                End If
            Next
        Next

        GCDetailRoyalty.DataSource = data3
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        view_usa_sales()
    End Sub

    Private Sub RepositoryItemHyperLinkEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit.Click
        If Not GVInvoiceWeek.GetFocusedRowCellValue("id_sales_pos").ToString = "0" Then
            FormViewSalesPOS.id_sales_pos = GVInvoiceWeek.GetFocusedRowCellValue("id_sales_pos").ToString
            FormViewSalesPOS.ShowDialog()
        Else
            stopCustom("No invoice selected.")
        End If
    End Sub
End Class