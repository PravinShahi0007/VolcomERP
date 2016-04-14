Public Class FormPopUpDesignPD 
    Public id_pop_up As String = "-1"

    Private Sub FormPopUpDesignPD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.queryDesignLastPD()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        If GVItemList.RowCount > 0 Then
            BtnSave.Enabled = True
            GVItemList.FocusedRowHandle = True

            'auto filter
            If id_pop_up = "1" Or id_pop_up = "2" Then
                GVItemList.ActiveFilterString = "[season] = '" + FormFGProposePriceDet.SLESeason.Text.ToString + "' AND [division]='" + FormFGProposePriceDet.LESampleDivision.Text.ToString + "' AND [source]='" + FormFGProposePriceDet.LESource.Text.ToString + "' "
            End If
        Else
            BtnSave.Enabled = False
        End If
    End Sub

    Sub checkId()
        Cursor = Cursors.WaitCursor
        Dim id_design_par As String = "-1"
        Try
            id_design_par = GVItemList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try

        If id_design_par = "-1" Or id_design_par = "" Then
            BtnSave.Enabled = False
        Else
            BtnSave.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        checkId()
    End Sub

    Private Sub GVItemList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemList.ColumnFilterChanged
        checkId()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CheckEditProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditProduct.CheckedChanged
        Cursor = Cursors.WaitCursor
        GVItemList.ExpandAllGroups()
        Dim cek As String = CheckEditProduct.EditValue.ToString
        For i As Integer = 0 To (GVItemList.RowCount - 1)
            Try
                If cek Then
                    GVItemList.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVItemList.SetRowCellValue(i, "is_select", "No")
                End If
            Catch ex As Exception
            End Try
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = False
        Dim alert_check As String = ""
        Dim jum_select As Integer = 0

        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim is_select As String = GVItemList.GetRowCellValue(i, "is_select").ToString
            If is_select = "Yes" Then
                jum_select = jum_select + 1
            End If
            cond_general = True
        Next

        If jum_select < 1 Then
            cond_general = False
        End If

        If cond_general Then
            If id_pop_up = "1" Then
                'PROPOSE PRICE
                For j As Integer = 0 To ((FormFGProposePriceDet.GVItemListImport.RowCount - 1) - GetGroupRowCount(FormFGProposePriceDet.GVItemListImport))
                    Dim id_design_cek As String = FormFGProposePriceDet.GVItemListImport.GetRowCellValue(j, "id_design").ToString

                    For j_sub As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        If id_design_cek = GVItemList.GetRowCellValue(j_sub, "id_design").ToString And GVItemList.GetRowCellValue(j_sub, "is_select").ToString = "Yes" Then
                            alert_check = GVItemList.GetRowCellValue(j_sub, "design_display_name").ToString + ", already selected !"
                            cond_check = False
                            Exit For
                        End If
                    Next
                Next

                If Not cond_check Then
                    stopCustom(alert_check.ToString)
                Else
                    PBC.Visible = True
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVItemList.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    For ls As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        If GVItemList.GetRowCellValue(ls, "is_select").ToString = "Yes" Then
                            Dim newRow As DataRow = (TryCast(FormFGProposePriceDet.GCItemListImport.DataSource, DataTable)).NewRow()
                            TryCast(FormFGProposePriceDet.GCItemListImport.DataSource, DataTable).Rows.Add(newRow)
                            newRow("id_fg_propose_price_det") = 0
                            newRow("prod_order_number") = GVItemList.GetRowCellValue(ls, "prod_order_number").ToString
                            newRow("id_prod_order") = GVItemList.GetRowCellValue(ls, "id_prod_order").ToString
                            newRow("prod_demand_number") = GVItemList.GetRowCellValue(ls, "prod_demand_number").ToString
                            newRow("id_prod_demand") = GVItemList.GetRowCellValue(ls, "id_prod_demand").ToString
                            newRow("design_code_import") = GVItemList.GetRowCellValue(ls, "design_code_import").ToString
                            newRow("design_code") = GVItemList.GetRowCellValue(ls, "design_code").ToString
                            newRow("season_orign_display") = GVItemList.GetRowCellValue(ls, "season_orign_display").ToString
                            newRow("id_season_orign") = GVItemList.GetRowCellValue(ls, "id_season_orign").ToString
                            newRow("country_display_name") = GVItemList.GetRowCellValue(ls, "country_display_name").ToString
                            newRow("source") = GVItemList.GetRowCellValue(ls, "source").ToString
                            newRow("class") = GVItemList.GetRowCellValue(ls, "class").ToString
                            newRow("division") = GVItemList.GetRowCellValue(ls, "division").ToString
                            newRow("delivery") = GVItemList.GetRowCellValue(ls, "delivery").ToString
                            newRow("id_delivery") = GVItemList.GetRowCellValue(ls, "id_delivery").ToString
                            newRow("design_display_name") = GVItemList.GetRowCellValue(ls, "design_display_name").ToString
                            newRow("id_design") = GVItemList.GetRowCellValue(ls, "id_design").ToString
                            newRow("color") = GVItemList.GetRowCellValue(ls, "color").ToString
                            newRow("fg_propose_price_det_qty") = GVItemList.GetRowCellValue(ls, "qty")
                            newRow("design_eos") = GVItemList.GetRowCellValue(ls, "design_eos").ToString
                            newRow("lifetime") = GVItemList.GetRowCellValue(ls, "lifetime").ToString
                            newRow("design_ret") = GVItemList.GetRowCellValue(ls, "design_ret").ToString
                            newRow("ret_code") = GVItemList.GetRowCellValue(ls, "ret_code").ToString
                            newRow("rate_bom") = 0.0
                            newRow("organic_cost_bom") = 0.0
                            newRow("rate_management") = 0.0
                            newRow("organic_cost_management") = 0.0
                            newRow("msrp") = GVItemList.GetRowCellValue(ls, "msrp")
                            newRow("msrp_rp") = 0.0
                            newRow("usa_inc") = 0.0
                            newRow("price_pd") = GVItemList.GetRowCellValue(ls, "price_pd")
                            newRow("price_target") = 0.0
                            newRow("price_final") = 0.0
                            newRow("royalty_usa_pros") = 0.0
                            newRow("royalty_one_usd") = 0.0
                            newRow("id_royalty_category") = 0
                            newRow("royalty_total") = 0.0
                            newRow("royalty_tax_pros") = 0.0
                            newRow("royalty_tax_amount") = 0.0
                            newRow("import_duty_pros") = 0.0
                            newRow("import_duty_amount") = 0.0
                            newRow("cop_pd") = GVItemList.GetRowCellValue(ls, "cop_pd")
                            newRow("cop_final_rate_bom") = 0.0
                            newRow("cop_final_rate_management") = 0.0

                            Dim m_pd As Decimal = 0.0
                            Try
                                m_pd = GVItemList.GetRowCellValue(ls, "price_pd") / GVItemList.GetRowCellValue(ls, "cop_pd")
                            Catch ex As Exception
                            End Try
                            newRow("markup_pd") = m_pd
                            newRow("markup_pd_rate_bom") = 0.0
                            newRow("markup_pd_rate_management") = 0.0
                            newRow("markup_rate_actual") = 0.0
                            newRow("markup_rate_management") = 0.0
                            newRow("usa_vs_target_pros") = 0.0
                            newRow("fg_propose_price_det_note") = ""

                            'REFRESH
                            FormFGProposePriceDet.GCItemListImport.RefreshDataSource()
                            FormFGProposePriceDet.GVItemListImport.RefreshData()
                        End If

                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    FormFGProposePriceDet.check_but_imp()
                    FormFGProposePriceDet.loadRoyCatImp()
                    Close()
                End If
            ElseIf id_pop_up = "2" Then
                'PROPOSE PRICE
                For j As Integer = 0 To ((FormFGProposePriceDet.GVItemListLocal.RowCount - 1) - GetGroupRowCount(FormFGProposePriceDet.GVItemListLocal))
                    Dim id_design_cek As String = FormFGProposePriceDet.GVItemListLocal.GetRowCellValue(j, "id_design").ToString

                    For j_sub As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        If id_design_cek = GVItemList.GetRowCellValue(j_sub, "id_design").ToString And GVItemList.GetRowCellValue(j_sub, "is_select").ToString = "Yes" Then
                            alert_check = GVItemList.GetRowCellValue(j_sub, "design_display_name").ToString + ", already selected !"
                            cond_check = False
                            Exit For
                        End If
                    Next
                Next

                If Not cond_check Then
                    stopCustom(alert_check.ToString)
                Else
                    PBC.Visible = True
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVItemList.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    For ls As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        If GVItemList.GetRowCellValue(ls, "is_select").ToString = "Yes" Then
                            Dim newRow As DataRow = (TryCast(FormFGProposePriceDet.GCItemListLocal.DataSource, DataTable)).NewRow()
                            TryCast(FormFGProposePriceDet.GCItemListLocal.DataSource, DataTable).Rows.Add(newRow)
                            newRow("id_fg_propose_price_det") = 0
                            newRow("prod_order_number") = GVItemList.GetRowCellValue(ls, "prod_order_number").ToString
                            newRow("id_prod_order") = GVItemList.GetRowCellValue(ls, "id_prod_order").ToString
                            newRow("prod_demand_number") = GVItemList.GetRowCellValue(ls, "prod_demand_number").ToString
                            newRow("id_prod_demand") = GVItemList.GetRowCellValue(ls, "id_prod_demand").ToString
                            newRow("design_code_import") = GVItemList.GetRowCellValue(ls, "design_code_import").ToString
                            newRow("design_code") = GVItemList.GetRowCellValue(ls, "design_code").ToString
                            newRow("season_orign_display") = GVItemList.GetRowCellValue(ls, "season_orign_display").ToString
                            newRow("id_season_orign") = GVItemList.GetRowCellValue(ls, "id_season_orign").ToString
                            newRow("country_display_name") = GVItemList.GetRowCellValue(ls, "country_display_name").ToString
                            newRow("source") = GVItemList.GetRowCellValue(ls, "source").ToString
                            newRow("class") = GVItemList.GetRowCellValue(ls, "class").ToString
                            newRow("division") = GVItemList.GetRowCellValue(ls, "division").ToString
                            newRow("delivery") = GVItemList.GetRowCellValue(ls, "delivery").ToString
                            newRow("id_delivery") = GVItemList.GetRowCellValue(ls, "id_delivery").ToString
                            newRow("design_display_name") = GVItemList.GetRowCellValue(ls, "design_display_name").ToString
                            newRow("id_design") = GVItemList.GetRowCellValue(ls, "id_design").ToString
                            newRow("color") = GVItemList.GetRowCellValue(ls, "color").ToString
                            newRow("fg_propose_price_det_qty") = GVItemList.GetRowCellValue(ls, "qty")
                            newRow("design_eos") = GVItemList.GetRowCellValue(ls, "design_eos").ToString
                            newRow("lifetime") = GVItemList.GetRowCellValue(ls, "lifetime").ToString
                            newRow("design_ret") = GVItemList.GetRowCellValue(ls, "design_ret").ToString
                            newRow("ret_code") = GVItemList.GetRowCellValue(ls, "ret_code").ToString
                            newRow("rate_bom") = 0.0
                            newRow("organic_cost_bom") = 0.0
                            newRow("rate_management") = 0.0
                            newRow("organic_cost_management") = 0.0
                            newRow("msrp") = GVItemList.GetRowCellValue(ls, "msrp")
                            newRow("msrp_rp") = 0.0
                            newRow("usa_inc") = 0.0
                            newRow("price_pd") = GVItemList.GetRowCellValue(ls, "price_pd")
                            newRow("price_target") = 0.0
                            newRow("price_final") = 0.0
                            newRow("royalty_usa_pros") = 0.0
                            newRow("royalty_one_usd") = 0.0
                            newRow("id_royalty_category") = 207
                            newRow("royalty_total") = 0.0
                            newRow("royalty_tax_pros") = 0.0
                            newRow("royalty_tax_amount") = 0.0
                            newRow("import_duty_pros") = 0.0
                            newRow("import_duty_amount") = 0.0
                            newRow("cop_pd") = GVItemList.GetRowCellValue(ls, "cop_pd")
                            newRow("cop_final_rate_bom") = 0.0
                            newRow("cop_final_rate_management") = 0.0

                            Dim m_pd As Decimal = 0.0
                            Try
                                m_pd = GVItemList.GetRowCellValue(ls, "price_pd") / GVItemList.GetRowCellValue(ls, "cop_pd")
                            Catch ex As Exception
                            End Try
                            newRow("markup_pd") = m_pd
                            newRow("markup_pd_rate_bom") = 0.0
                            newRow("markup_pd_rate_management") = 0.0
                            newRow("markup_rate_actual") = 0.0
                            newRow("markup_rate_management") = 0.0
                            newRow("usa_vs_target_pros") = 0.0
                            newRow("fg_propose_price_det_note") = ""

                            'REFRESH
                            FormFGProposePriceDet.GCItemListLocal.RefreshDataSource()
                            FormFGProposePriceDet.GVItemListLocal.RefreshData()
                        End If

                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    FormFGProposePriceDet.check_but_loc()
                    Close()
                End If
            End If
        Else
            stopCustom("No item selected")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub FormPopUpDesignPD_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class