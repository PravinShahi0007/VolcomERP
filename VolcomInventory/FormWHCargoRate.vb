Public Class FormWHCargoRate
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub BAddComp_Click(sender As Object, e As EventArgs) Handles BAddComp.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = FormMain
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
            FormMasterCompany.Visible = True
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormWHCargoRate_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormWHCargoRate_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormWHCargoRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cargo_rate()
        load_cargo_rate_in()
    End Sub

    Sub load_cargo_rate()
        Dim query As String = "CALL view_store_cargo_rate(1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            GVCompany.ApplyFindFilter("")
            GVCompany.ColumnPanelRowHeight = 40
            GVCompany.Columns.Clear()
            GVCompany.GroupSummary.Clear()
            GVCompany.Bands.Clear()
            GVCompany.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '
            Dim band_store As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompany.Bands.AddBand("STORE")
            band_store.AppearanceHeader.Font = New Font(GVCompany.Appearance.Row.Font.FontFamily, GVCompany.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_rate As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompany.Bands.AddBand("RATE/KG")
            band_rate.AppearanceHeader.Font = New Font(GVCompany.Appearance.Row.Font.FontFamily, GVCompany.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_lead_time As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompany.Bands.AddBand("LEAD TIME")
            band_lead_time.AppearanceHeader.Font = New Font(GVCompany.Appearance.Row.Font.FontFamily, GVCompany.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_min_weight As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompany.Bands.AddBand("MINIMUM WEIGHT")
            band_min_weight.AppearanceHeader.Font = New Font(GVCompany.Appearance.Row.Font.FontFamily, GVCompany.Appearance.Row.Font.Size, FontStyle.Bold)

            GVCompany.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If Not data.Columns(i).ColumnName.ToString.Contains("#") Then
                    band_store.Columns.Add(GVCompany.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_rate.Columns.Add(GVCompany.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_lead_time.Columns.Add(GVCompany.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_min_weight.Columns.Add(GVCompany.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompany.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVCompany.EndUpdate()
            GCCompany.DataSource = data

            GVCompany.Columns("id_store").Visible = False
            GVCompany.Columns("id").Visible = False

            GVCompany.BestFitColumns()
        End If
    End Sub

    Sub load_cargo_rate_in()
        Dim query As String = "CALL view_store_cargo_rate(2)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            GVCompanyIn.ApplyFindFilter("")
            GVCompanyIn.ColumnPanelRowHeight = 40
            GVCompanyIn.Columns.Clear()
            GVCompanyIn.GroupSummary.Clear()
            GVCompanyIn.Bands.Clear()
            GVCompanyIn.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '
            Dim band_storeIn As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompanyIn.Bands.AddBand("STORE")
            band_storeIn.AppearanceHeader.Font = New Font(GVCompanyIn.Appearance.Row.Font.FontFamily, GVCompanyIn.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_rateIn As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompanyIn.Bands.AddBand("RATE/KG")
            band_rateIn.AppearanceHeader.Font = New Font(GVCompanyIn.Appearance.Row.Font.FontFamily, GVCompanyIn.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_lead_timeIn As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompanyIn.Bands.AddBand("LEAD TIME")
            band_lead_timeIn.AppearanceHeader.Font = New Font(GVCompanyIn.Appearance.Row.Font.FontFamily, GVCompanyIn.Appearance.Row.Font.Size, FontStyle.Bold)
            Dim band_min_weightIn As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVCompanyIn.Bands.AddBand("MINIMUM WEIGHT")
            band_min_weightIn.AppearanceHeader.Font = New Font(GVCompanyIn.Appearance.Row.Font.FontFamily, GVCompanyIn.Appearance.Row.Font.Size, FontStyle.Bold)

            GVCompanyIn.BeginUpdate()

            For i As Integer = 0 To data.Columns.Count - 1
                If Not data.Columns(i).ColumnName.ToString.Contains("#") Then
                    band_storeIn.Columns.Add(GVCompanyIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_rate#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_rateIn.Columns.Add(GVCompanyIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_lead_time#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_lead_timeIn.Columns.Add(GVCompanyIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("cargo_min_weight#") Then
                    Dim str_arr As String() = data.Columns(i).ColumnName.ToString.Split("#"c)
                    band_min_weightIn.Columns.Add(GVCompanyIn.Columns.AddVisible(data.Columns(i).ColumnName.ToString, str_arr(2).ToString))

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    GVCompanyIn.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"
                End If
            Next

            GVCompanyIn.EndUpdate()
            GCCompanyIn.DataSource = data

            GVCompanyIn.Columns("id_store").Visible = False
            GVCompanyIn.Columns("id").Visible = False

            GVCompanyIn.BestFitColumns()
        End If
    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If Not GVCompany.FocusedColumn.FieldName.ToString.Contains("#") Then
            Cursor = Cursors.WaitCursor
            Try
                FormMasterCompany.MdiParent = FormMain
                FormMasterCompany.Show()
                FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", GVCompany.GetFocusedRowCellValue("id_store").ToString)
                FormMasterCompany.WindowState = FormWindowState.Maximized
                FormMasterCompany.Focus()
                FormMasterCompany.Visible = True
            Catch ex As Exception
            End Try
            Cursor = Cursors.Default
        Else
            Dim str_arr As String() = GVCompany.FocusedColumn.FieldName.ToString.Split("#"c)

            FormWHCargoRateDet.id_store = GVCompany.GetFocusedRowCellValue("id_store").ToString
            FormWHCargoRateDet.id_rate_type = "1"
            FormWHCargoRateDet.id_cargo = str_arr(1).ToString
            '
            FormWHCargoRateDet.TECompCode.Text = GVCompany.GetFocusedRowCellValue("Account").ToString
            FormWHCargoRateDet.TECompName.Text = GVCompany.GetFocusedRowCellValue("Account Name").ToString
            FormWHCargoRateDet.TECargoName.Text = str_arr(2).ToString

            FormWHCargoRateDet.TERate.Text = GVCompany.GetFocusedRowCellValue("cargo_rate#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            FormWHCargoRateDet.TELeadTime.Text = GVCompany.GetFocusedRowCellValue("cargo_lead_time#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            FormWHCargoRateDet.TEMinWeight.Text = GVCompany.GetFocusedRowCellValue("cargo_min_weight#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            '
            FormWHCargoRateDet.ShowDialog()
        End If
    End Sub

    Private Sub BEditIn_Click(sender As Object, e As EventArgs) Handles BEditIn.Click
        If Not GVCompanyIn.FocusedColumn.FieldName.ToString.Contains("#") Then
            Cursor = Cursors.WaitCursor
            Try
                FormMasterCompany.MdiParent = FormMain
                FormMasterCompany.Show()
                FormMasterCompany.GVCompany.FocusedRowHandle = find_row(FormMasterCompany.GVCompany, "id_comp", GVCompanyIn.GetFocusedRowCellValue("id_store").ToString)
                FormMasterCompany.WindowState = FormWindowState.Maximized
                FormMasterCompany.Focus()
                FormMasterCompany.Visible = True
            Catch ex As Exception
            End Try
            Cursor = Cursors.Default
        Else
            Dim str_arr As String() = GVCompanyIn.FocusedColumn.FieldName.ToString.Split("#"c)

            FormWHCargoRateDet.id_store = GVCompanyIn.GetFocusedRowCellValue("id_store").ToString
            FormWHCargoRateDet.id_rate_type = "2"
            FormWHCargoRateDet.id_cargo = str_arr(1).ToString
            '
            FormWHCargoRateDet.TECompCode.Text = GVCompanyIn.GetFocusedRowCellValue("Account").ToString
            FormWHCargoRateDet.TECompName.Text = GVCompanyIn.GetFocusedRowCellValue("Account Name").ToString
            FormWHCargoRateDet.TECargoName.Text = str_arr(2).ToString

            FormWHCargoRateDet.TERate.Text = GVCompanyIn.GetFocusedRowCellValue("cargo_rate#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            FormWHCargoRateDet.TELeadTime.Text = GVCompanyIn.GetFocusedRowCellValue("cargo_lead_time#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            FormWHCargoRateDet.TEMinWeight.Text = GVCompanyIn.GetFocusedRowCellValue("cargo_min_weight#" + str_arr(1).ToString + "#" + str_arr(2).ToString).ToString
            '
            FormWHCargoRateDet.ShowDialog()
        End If
    End Sub
End Class