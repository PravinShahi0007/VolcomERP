Public Class FormSOHSum 
    Public date_from_monthly_selected As String = "0000-01-01"
    Public date_until_monthly_selected As String = "0000-01-01"
    Public label_from_monthly_selected As String = ""
    Public label_until_monthly_selected As String = ""
    Public dt_monthly As DataTable
    Public retail_list As New List(Of String)
    Public rev_bef_list As New List(Of String)

    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BtnViewMonthlySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewMonthlySales.Click
        Cursor = Cursors.WaitCursor
        'retail_list.Clear()
        'rev_bef_list.Clear()

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
            Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand("Detail")

            'excecute query
            Dim query As String = "CALL view_soh_sum_ex('" + date_from_monthly_selected + "', '" + date_until_monthly_selected + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To data.Columns.Count - 1
                If data.Columns(i).ColumnName.ToString = "id_comp" _
                Or data.Columns(i).ColumnName.ToString = "STORE NAME" _
                Or data.Columns(i).ColumnName.ToString = "CODE" _
                Or data.Columns(i).ColumnName.ToString = "GROUP" _
                Or data.Columns(i).ColumnName.ToString = "id_comp_group" _
                Or data.Columns(i).ColumnName.ToString = "id_status_soh" _
                Or data.Columns(i).ColumnName.ToString = "STATUS" _
                Then
                    band_desc.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                    If data.Columns(i).ColumnName.ToString = "STORE NAME" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_comp"
                    ElseIf data.Columns(i).ColumnName.ToString = "CODE" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_comp"
                    ElseIf data.Columns(i).ColumnName.ToString = "GROUP" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_comp_group"
                    ElseIf data.Columns(i).ColumnName.ToString = "STATUS" Then
                        BGVSalesPOSMonthly.Columns(data.Columns(i).ColumnName.ToString).FieldNameSortGroup = "id_status_soh"
                    End If
                Else
                    Dim index As Integer = data.Columns(i).ColumnName.ToString.IndexOf("~")
                    Dim index_2 As Integer = data.Columns(i).ColumnName.ToString.IndexOf("#") - index - 1
                    Dim index_3 As Integer = data.Columns(i).ColumnName.ToString.IndexOf("#")
                    Dim jum As Integer = data.Columns(i).ColumnName.ToString.Length - index - index_2 - 1
                    Dim found_band As Boolean = False


                    For Each gb As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BGVSalesPOSMonthly.Bands
                        'cek setiap band
                        If gb.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(0, index) Then
                            found_band = True
                            Dim found_band_2 As Boolean = False
                            'cek volc qty, store qty, diff qty, unid_qty
                            For Each gbc As DevExpress.XtraGrid.Views.BandedGrid.GridBand In gb.Children

                                If gbc.Caption.ToString = data.Columns(i).ColumnName.ToString.Substring(index + 1, index_2) Then
                                    found_band_2 = True
                                    gbc.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(index_3 + 1, jum - 1)))
                                    Exit For
                                End If
                            Next

                            If Not found_band_2 Then
                                Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = gb.Children.AddBand(data.Columns(i).ColumnName.ToString.Substring(index + 1, index_2))
                                bandc_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)
                                bandc_new.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(index_3 + 1, jum - 1)))
                            End If

                            Exit For
                        End If
                    Next gb

                    If Not found_band Then
                        Dim band_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVSalesPOSMonthly.Bands.AddBand(data.Columns(i).ColumnName.ToString.Substring(0, index))
                        band_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)

                        Dim bandc_new As DevExpress.XtraGrid.Views.BandedGrid.GridBand = band_new.Children.AddBand(data.Columns(i).ColumnName.ToString.Substring(index + 1, index_2))
                        bandc_new.AppearanceHeader.Font = New Font(BGVSalesPOSMonthly.Appearance.Row.Font.FontFamily, BGVSalesPOSMonthly.Appearance.Row.Font.Size, FontStyle.Bold)
                        bandc_new.Columns.Add(BGVSalesPOSMonthly.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(index_3 + 1, jum - 1)))
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
            GCSumSOH.DataSource = data
            GroupControlMonthlySales.Enabled = True
            BGVSalesPOSMonthly.BestFitColumns()
            'hide column
            BGVSalesPOSMonthly.Columns("id_comp").Visible = False
            BGVSalesPOSMonthly.Columns("id_comp_group").Visible = False
            BGVSalesPOSMonthly.Columns("id_status_soh").Visible = False
            'CheckShowRetail.Checked = "True"
            'CheckShowRevBefTax.Checked = "True"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSOHSum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewFilterMonth()
        viewFilterYear()
    End Sub

    Private Sub FormSOHSum_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSOHSum_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

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
End Class