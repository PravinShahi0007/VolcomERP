Public Class FormFGWoffList
    'Selected view - Tab Stock Sum
    Dim label_design_stock_sum_def As String
    Public id_design_selected_stock_sum As String = "-1"
    Public label_design_selected_stock_sum As String = "-1"
    Public date_from_selected_stock_sum As String = "-1"
    Public date_until_selected_stock_sum As String = "-1"
    Public label_date_until_selected_stock_sum As String = "-1"
    Dim special_code_list As New List(Of String)

    Private Sub FormFGWoffList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProductStockSum()
    End Sub

    Sub viewProductStockSum()
        Dim query As String = ""
        query += "CALL view_design_woff(TRUE) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_design_stock_sum_def = data.Rows(i)("label_design").ToString
                Exit For
            End If
        Next
        SLEDesignStockSum.Properties.DataSource = Nothing
        SLEDesignStockSum.Properties.DataSource = data
        SLEDesignStockSum.Properties.DisplayMember = "label_design"
        SLEDesignStockSum.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockSum.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockSum.EditValue = Nothing
        End If
    End Sub


    Private Sub BtnViewStockSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockSum.Click
        Cursor = Cursors.WaitCursor

        'Clear List code
        special_code_list.Clear()

        'Prepare paramater
        date_until_selected_stock_sum = "9999-01-01"
        label_date_until_selected_stock_sum = "-"
        Try
            date_until_selected_stock_sum = DateTime.Parse(DEUntilStockFG.EditValue.ToString).ToString("yyyy-MM-dd")
            label_date_until_selected_stock_sum = DEUntilStockFG.Text.ToString
        Catch ex As Exception
        End Try

        Try
            id_design_selected_stock_sum = SLEDesignStockSum.EditValue.ToString
        Catch ex As Exception
        End Try

        'set selected
        If id_design_selected_stock_sum = "0" Then
            label_design_selected_stock_sum = "All Design"
        Else
            label_design_selected_stock_sum = SLEDesignStockSum.Properties.View.GetFocusedRowCellValue("label_design").ToString
        End If


        'Prepare Baded
        BGVFGStock.Columns.Clear()
        BGVFGStock.Bands.Clear()
        BGVFGStock.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        ' Make the group footers always visible.
        BGVFGStock.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("DESCRIPTION")
        Dim band_aging As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("AGING (MONTH)")
        Dim band_qty_free As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("QTY FREE")
        Dim band_qty_res As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("QTY RESERVED")
        Dim band_qty_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("TOTAL QTY")
        'band_qty_total.AppearanceHeader.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)

        Dim query As String = "CALL view_stock_fg_woff('" + id_design_selected_stock_sum + "', '" + date_until_selected_stock_sum + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_sample" Or data.Columns(i).ColumnName.ToString = "Code" Or data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "Design" Or data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "uom" Or data.Columns(i).ColumnName.ToString = "id_design_stock" Or data.Columns(i).ColumnName.ToString = "Unit Cost" Or data.Columns(i).ColumnName.ToString = "Product Division" Or data.Columns(i).ColumnName.ToString = "Product Source" Or data.Columns(i).ColumnName.ToString = "Product Branding" Or data.Columns(i).ColumnName.ToString = "Range" Or data.Columns(i).ColumnName.ToString = "Product Counting" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "Price" Then
                band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
            ElseIf data.Columns(i).ColumnName.ToString.Contains(" Free") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 5
                band_qty_free.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            ElseIf data.Columns(i).ColumnName.ToString.Contains(" Reserved") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 9
                band_qty_res.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString.Contains(" Aging") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
                band_aging.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString.Contains(" Total") Then
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
                band_qty_total.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                'BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)
                'BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStock.GroupSummary.Add(item)

            End If
        Next
        GCFGStock.DataSource = data

        'hide column
        BGVFGStock.Columns("id_sample").Visible = False
        BGVFGStock.Columns("id_design").Visible = False
        BGVFGStock.Columns("design_display_name").Visible = False
        BGVFGStock.Columns("uom").Visible = False
        BGVFGStock.Columns("id_design_stock").Visible = False
        BGVFGStock.Columns("Product Counting").Visible = False
        BGVFGStock.Columns("Range").Visible = False
        For j As Integer = 0 To special_code_list.Count - 1
            BGVFGStock.Columns(special_code_list(j)).Visible = False
        Next

        'Enable Group
        GroupControlStockSum.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGWoffList_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGWoffList_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
    End Sub
End Class