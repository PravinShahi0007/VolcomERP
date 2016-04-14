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
    Public date_from_weekly_selected As String = "0000-01-01"
    Public date_until_weekly_selected As String = "9999-12-01"
    Public dt_weekly As DataTable
    Public id_day_weekly_selected As String
    Public day_weekly_selected As String
    Dim first_load_weekly As Boolean = False
    Public retail_list_ws As New List(Of String)
    Public rev_bef_list_ws As New List(Of String)

    'selected-Tab 3
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

        'tab daily
        viewStore()
        viewOption()

        'Tab Weekly
        viewDay()

        'Tab Monthly
        viewFilterMonth()
        viewFilterYear()
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
            If Not first_load_weekly Then
                LEDayWeekly.ItemIndex = LEDayWeekly.Properties.GetDataSourceRowIndex("id_day", "1")
            End If
        ElseIf XTCPOS.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            LEFromMonth.ItemIndex = LEFromMonth.Properties.GetDataSourceRowIndex("code_month", "01")
            LEUntilMonth.ItemIndex = LEUntilMonth.Properties.GetDataSourceRowIndex("code_month", "01")

            LEFromYear.ItemIndex = LEFromYear.Properties.GetDataSourceRowIndex("label_year", current_year)
            LEUntilYear.ItemIndex = LEUntilYear.Properties.GetDataSourceRowIndex("label_year", current_year)
        End If
    End Sub

    '=======================TAB DAILY TRANSACTION=========================
    Sub viewSalesPOS()
        Try
            Dim data As DataTable = CreateData()
            GCSalesPOS.DataSource = data
            dt = data
            check_menu()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Function CreateData() As DataTable
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMainReport("AND a.id_report_status=''6'' AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "1")
        
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
        Dim query As String = getQueryStore()
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

        'selected store
        If id_store_selected = "0" Then
            id_store_selected = "%%"
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

            'excecute query
            Dim query As String = "CALL view_sales_weekly('" + date_from_weekly_selected + "', '" + date_until_weekly_selected + "', '" + id_day_weekly_selected + "')"
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
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    BGVSalesPOSWeekly.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                    Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                    item.FieldName = data.Columns(i).ColumnName.ToString
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = "{0:n2}"
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

        Dim id_memo_type As String = "-1"
        Try
            id_memo_type = GVSalesPOS.GetFocusedRowCellValue("id_memo_type").ToString
        Catch ex As Exception
        End Try

        If id_memo_type = "1" Then
            FormViewSalesPOS.id_sales_pos = id_sales_pos
            FormViewSalesPOS.ShowDialog()
        ElseIf id_memo_type = "2" Then
            FormViewSalesCreditNote.id_sales_pos = id_sales_pos
            FormViewSalesCreditNote.ShowDialog()
        End If

        Cursor = Cursors.Default
    End Sub
End Class