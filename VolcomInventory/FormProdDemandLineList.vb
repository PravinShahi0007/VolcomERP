Public Class FormProdDemandLineList 
    Public id_pop_up As String = "-1"
    Public id_season_par As String = "-1"
    Public data_band_break_par As DataTable = Nothing
    Public data_band_break_plan_par As DataTable = Nothing
    Public data_band_alloc_par As DataTable = Nothing
    Public data_band_alloc_plan_par As DataTable = Nothing
    '-1 = PD
    '1 = Propose Price Local
    '2 = Propose Price Import

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        If id_season_par <> "-1" Then
            query += "WHERE a.id_season='" + id_season_par + "' "
        End If
        query += "ORDER BY b.range DESC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type "
        If id_pop_up = "1" Or id_pop_up = "2" Then 'propose price
            query += "WHERE id_pd_type = '3' "
        ElseIf id_pop_up = "-1" Then 'PD
            query += "WHERE id_pd_type = '1' or id_pd_type='2' "
        End If
        query += "ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Private Sub FormProdDemandLineList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        viewLineType()

        'inital datatable
        Dim query_c As ClassDesign = New ClassDesign()
        data_band_break_par = query_c.getBreakTotalLineList("1")
        data_band_break_plan_par = query_c.getBreakTotalLineList("3")
        data_band_alloc_par = query_c.getBreakAllocLineList("1")
        data_band_alloc_plan_par = query_c.getBreakAllocLineList("2")

        'Load options
        If id_pop_up = "1" Or id_pop_up = "2" Then
            SLESeason.EditValue = FormFGProposePriceDet.SLESeason.EditValue.ToString
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewLineList()
        Cursor = Cursors.Default
    End Sub

    Sub viewLineList()
        Dim id_season_par As String = "0"
        Try
            id_season_par = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_type As String = "-1"
        Try
            id_type = SLETypeLineList.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query_c As ClassDesign = New ClassDesign()
        If id_pop_up = "-1" Then
            query_c.viewLineList(id_season_par, id_type, BGVLineList, GCLineList, data_band_break_par, data_band_alloc_par, False)
        ElseIf id_pop_up = "1" Or id_pop_up = "2" Then
            query_c.viewLineListFinal(id_season_par, id_type, BGVLineList, GCLineList, data_band_break_par, data_band_break_plan_par, data_band_alloc_par, data_band_alloc_plan_par, False)
        End If

        If BGVLineList.RowCount > 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If

        '[LAST PD] = '-' AND 
        If id_pop_up = "-1" Then
            BGVLineList.ActiveFilterString = "[DIVISION] = '" + FormProdDemandSingle.LESampleDivision.Text + "' AND [MOVE/DROP]= '-' "
        ElseIf id_pop_up = "1" Then 'Local
            BGVLineList.ActiveFilterString = "[id_report_status] = '0'  AND [id_cop_status_Prc]= '1' AND [DIVISION]='" + FormFGProposePriceDet.LESampleDivision.Text.ToString.ToUpper + "' AND [PRODUCT ORIGIN]='" + FormFGProposePriceDet.LESource.Text.ToString.ToUpper + "' "

            BGVLineList.Columns("CURRENCY ORIGIN_Prc").Visible = False
            BGVLineList.Columns("RATE IN RP_Prc").Visible = False
            BGVLineList.Columns("MSRP_Prc").Visible = False
            BGVLineList.Columns("MSRP IN RP_Prc").Visible = False
            BGVLineList.Columns("TARGET PRICE BASE ON MARKUP_Prc").Visible = False
            BGVLineList.Columns("COST_Prc").Visible = False
            BGVLineList.Columns("TOTAL COST_Prc").Visible = False
            BGVLineList.Columns("PROPOSE PRICE_Prc").Visible = False
            BGVLineList.Columns("TOTAL AMO_Prc").Visible = False
            BGVLineList.Columns("MARK UP_Prc").Visible = False
            Dim query_alloc As String = "SELECT * FROM tb_lookup_pd_alloc"
            Dim data As DataTable = execute_query(query_alloc, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                BGVLineList.Columns(data.Rows(i)("pd_alloc").ToString.ToUpper + " AMO_Prc").Visible = False
            Next
            BGVLineList.Columns("ACT ORDER SALES AMO_Prc").Visible = False
            BGVLineList.Columns("RATE BOM_Prc").Visible = False
            BGVLineList.Columns("RATE MANAGEMENT_Prc").Visible = False
            BGVLineList.Columns("RATE PD_Prc").Visible = False
            BGVLineList.Columns("ORGANIC COST RATE MANAGEMENT_Prc").Visible = False
            BGVLineList.Columns("ORGANIC COST RATE PD_Prc").Visible = False
            BGVLineList.Columns("ORGANIC COST RATE BOM_Prc").Visible = True
            BGVLineList.Columns("ORGANIC COST RATE BOM_Prc").Caption = "COP"
            BGVLineList.Columns("COP STATUS_Prc").Visible = True
        ElseIf id_pop_up = "2" Then 'import
            BGVLineList.ActiveFilterString = "[id_report_status] = '0' AND [id_cop_status_Prc]= '1' AND [DIVISION]='" + FormFGProposePriceDet.LESampleDivision.Text.ToString.ToUpper + "' AND [PRODUCT ORIGIN]='" + FormFGProposePriceDet.LESource.Text.ToString.ToUpper + "' "

            BGVLineList.Columns("CURRENCY ORIGIN_Prc").Visible = False
            BGVLineList.Columns("RATE IN RP_Prc").Visible = False
            BGVLineList.Columns("MSRP_Prc").Visible = False
            BGVLineList.Columns("MSRP IN RP_Prc").Visible = False
            BGVLineList.Columns("TARGET PRICE BASE ON MARKUP_Prc").Visible = False
            BGVLineList.Columns("COST_Prc").Visible = False
            BGVLineList.Columns("TOTAL COST_Prc").Visible = False
            BGVLineList.Columns("PROPOSE PRICE_Prc").Visible = False
            BGVLineList.Columns("TOTAL AMO_Prc").Visible = False
            BGVLineList.Columns("MARK UP_Prc").Visible = False
            Dim query_alloc As String = "SELECT * FROM tb_lookup_pd_alloc"
            Dim data As DataTable = execute_query(query_alloc, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                BGVLineList.Columns(data.Rows(i)("pd_alloc").ToString.ToUpper + " AMO_Prc").Visible = False
            Next
            BGVLineList.Columns("ACT ORDER SALES AMO_Prc").Visible = False
            BGVLineList.Columns("RATE BOM_Prc").Visible = True
            BGVLineList.Columns("ORGANIC COST RATE BOM_Prc").Visible = True
            BGVLineList.Columns("RATE MANAGEMENT_Prc").Visible = True
            BGVLineList.Columns("ORGANIC COST RATE MANAGEMENT_Prc").Visible = True
            BGVLineList.Columns("RATE PD_Prc").Visible = True
            BGVLineList.Columns("ORGANIC COST RATE PD_Prc").Visible = True
            BGVLineList.Columns("COP STATUS_Prc").Visible = True
        End If
    End Sub

    Sub nothingLineList()
        GCLineList.Visible = True
        GCLineList.DataSource = Nothing
        CheckEditSelAll.Checked = False
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        Cursor = Cursors.WaitCursor
        nothingLineList()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLETypeLineList_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLETypeLineList.EditValueChanged
        Cursor = Cursors.WaitCursor
        nothingLineList()
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVLineList.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal

    Dim tot_cost_act As Decimal
    Dim tot_prc_act As Decimal
    Dim tot_cost_grp_act As Decimal
    Dim tot_prc_grp_act As Decimal
    Private Sub BGVLineList_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVLineList.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If SLETypeLineList.EditValue.ToString = "3" Then
            '-------------ACTUAL
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0

                tot_cost_act = 0.0
                tot_prc_act = 0.0
                tot_cost_grp_act = 0.0
                tot_prc_grp_act = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc_Plan").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc_Plan"), "0.00"))
                Dim cost_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc").ToString, "0.00"))
                Dim prc_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                    Case 48
                        tot_cost_act += cost_act
                        tot_prc_act += prc_act
                    Case 49
                        tot_cost_grp_act += cost_act
                        tot_prc_grp_act += prc_act
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 48 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_act / tot_cost_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 49 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp_act / tot_cost_grp_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        Else
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "-1" Then
            Dim jum_tot As Integer = 0
            Dim cond_same As Boolean = False
            Dim string_same As String = "-1"
            Dim id_design_same As String = "-1"
            Dim idx_same As Integer = 0
            For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                If BGVLineList.GetRowCellValue(i, "Select_sct") = "Yes" Then
                    jum_tot += 1
                    If FormProdDemandSingle.id_design_list.Contains(BGVLineList.GetRowCellValue(i, "id_design").ToString) Then
                        string_same = "Design : " + BGVLineList.GetRowCellValue(i, "CODE").ToString + "/" + BGVLineList.GetRowCellValue(i, "DESCRIPTION").ToString + ", already exist."
                        idx_same = i
                        cond_same = True
                        Exit For
                    End If
                    If cond_same Then
                        Exit For
                    End If
                End If
            Next

            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            If jum_tot > 0 Then
                If cond_same Then
                    stopCustom(string_same)
                    BGVLineList.FocusedRowHandle = idx_same
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose designs list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                            If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                                If jum_str > 0 Then
                                    id_str += ";"
                                End If
                                id_str += BGVLineList.GetRowCellValue(l, "id_design").ToString
                                jum_str += 1
                                FormProdDemandSingle.id_design_list.Add(BGVLineList.GetRowCellValue(l, "id_design").ToString)
                            End If
                        Next
                        Dim query As String = "CALL generate_pd_line_list('" + FormProdDemandSingle.id_prod_demand + "', '" + SLETypeLineList.EditValue.ToString + "', '" + id_str + "')"
                        execute_non_query(query, True, "", "", "", "")
                        FormProdDemandSingle.viewDesignDemand()
                        Close()
                        Cursor = Cursors.Default
                    End If
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        ElseIf id_pop_up = "1" Then 'LOCAL
            Dim jum_tot As Integer = 0
            Dim cond_same As Boolean = False
            Dim string_same As String = "-1"
            Dim id_design_same As String = "-1"
            Dim idx_same As Integer = 0
            For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                If BGVLineList.GetRowCellValue(i, "Select_sct") = "Yes" Then
                    jum_tot += 1
                    For c As Integer = 0 To ((FormFGProposePriceDet.GVItemListLocal.RowCount - 1) - GetGroupRowCount(FormFGProposePriceDet.GVItemListLocal))
                        If FormFGProposePriceDet.GVItemListLocal.GetRowCellValue(c, "id_design").ToString = BGVLineList.GetRowCellValue(i, "id_design").ToString Then
                            string_same = "Design : " + BGVLineList.GetRowCellValue(i, "CODE").ToString + "/" + BGVLineList.GetRowCellValue(i, "DESCRIPTION").ToString + ", already exist."
                            idx_same = i
                            cond_same = True
                            Exit For
                        End If
                    Next
                    If cond_same Then
                        Exit For
                    End If
                End If
            Next

            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            If jum_tot > 0 Then
                If cond_same Then
                    stopCustom(string_same)
                    BGVLineList.FocusedRowHandle = idx_same
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose designs list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For ls As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                            If BGVLineList.GetRowCellValue(ls, "Select_sct").ToString = "Yes" Then
                                Dim newRow As DataRow = (TryCast(FormFGProposePriceDet.GCItemListLocal.DataSource, DataTable)).NewRow()
                                TryCast(FormFGProposePriceDet.GCItemListLocal.DataSource, DataTable).Rows.Add(newRow)
                                Dim rh As Integer = FormFGProposePriceDet.GVItemListLocal.RowCount - 1
                                newRow("id_fg_propose_price_det") = 0
                                newRow("prod_demand_number") = BGVLineList.GetRowCellValue(ls, "LAST PD").ToString
                                newRow("id_prod_demand") = BGVLineList.GetRowCellValue(ls, "id_prod_demand_last").ToString
                                newRow("design_code_import") = BGVLineList.GetRowCellValue(ls, "CODE IMPORT").ToString
                                newRow("design_code") = BGVLineList.GetRowCellValue(ls, "CODE").ToString
                                newRow("season_orign_display") = BGVLineList.GetRowCellValue(ls, "SEASON ORIGN").ToString
                                newRow("id_season_orign") = BGVLineList.GetRowCellValue(ls, "id_season_orign").ToString
                                newRow("country_display_name") = BGVLineList.GetRowCellValue(ls, "STYLE COUNTRY").ToString
                                newRow("source") = BGVLineList.GetRowCellValue(ls, "PRODUCT ORIGIN").ToString
                                newRow("class") = BGVLineList.GetRowCellValue(ls, "CLASS").ToString
                                newRow("division") = BGVLineList.GetRowCellValue(ls, "DIVISION").ToString
                                newRow("delivery") = BGVLineList.GetRowCellValue(ls, "DEL").ToString
                                newRow("id_delivery") = BGVLineList.GetRowCellValue(ls, "id_delivery").ToString
                                newRow("design_display_name") = BGVLineList.GetRowCellValue(ls, "DESCRIPTION").ToString
                                newRow("id_design") = BGVLineList.GetRowCellValue(ls, "id_design").ToString
                                newRow("color") = BGVLineList.GetRowCellValue(ls, "COLOR").ToString
                                newRow("fg_propose_price_det_qty") = BGVLineList.GetRowCellValue(ls, "TOTAL QTY_Breakdown_Plan")
                                newRow("design_eos") = BGVLineList.GetRowCellValue(ls, "EOS")
                                newRow("lifetime") = BGVLineList.GetRowCellValue(ls, "AGE").ToString
                                newRow("delivery_date") = BGVLineList.GetRowCellValue(ls, "IN STORE DATE")
                                newRow("design_ret") = BGVLineList.GetRowCellValue(ls, "RET DATE")
                                newRow("ret_code") = BGVLineList.GetRowCellValue(ls, "CODE RET").ToString
                                newRow("rate_bom") = BGVLineList.GetRowCellValue(ls, "RATE BOM_Prc")
                                newRow("organic_cost_bom") = BGVLineList.GetRowCellValue(ls, "ORGANIC COST RATE BOM_Prc")
                                newRow("rate_management") = BGVLineList.GetRowCellValue(ls, "RATE MANAGEMENT_Prc")
                                newRow("organic_cost_management") = BGVLineList.GetRowCellValue(ls, "ORGANIC COST RATE MANAGEMENT_Prc")
                                newRow("msrp") = BGVLineList.GetRowCellValue(ls, "MSRP_Prc")
                                newRow("msrp_rp") = BGVLineList.GetRowCellValue(ls, "MSRP IN RP_Prc")
                                newRow("usa_inc") = 0.0
                                newRow("price_pd") = BGVLineList.GetRowCellValue(ls, "PRICE PD")
                                newRow("price_target") = 0.0
                                newRow("price_final") = BGVLineList.GetRowCellValue(ls, "PRICE PD")
                                newRow("royalty_usa_pros") = 0.0
                                newRow("royalty_one_usd") = 0.0
                                newRow("id_royalty_category") = 207
                                newRow("royalty_total") = 0.0
                                newRow("royalty_tax_pros") = 0.0
                                newRow("royalty_tax_amount") = 0.0
                                newRow("import_duty_pros") = 0.0
                                newRow("import_duty_amount") = 0.0
                                newRow("cop_pd") = BGVLineList.GetRowCellValue(ls, "COP PD")
                                newRow("cop_final_rate_bom") = BGVLineList.GetRowCellValue(ls, "ORGANIC COST RATE BOM_Prc")
                                newRow("cop_final_rate_management") = 0.0
                                newRow("cop_status") = BGVLineList.GetRowCellValue(ls, "COP STATUS_Prc").ToString

                                Dim m_pd As Decimal = 0.0
                                Try
                                    m_pd = BGVLineList.GetRowCellValue(ls, "PRICE PD") / BGVLineList.GetRowCellValue(ls, "COP PD")
                                Catch ex As Exception
                                End Try
                                newRow("markup_pd") = m_pd
                                newRow("markup_pd_rate_bom") = 0.0
                                newRow("markup_pd_rate_management") = 0.0
                                newRow("markup_rate_actual") = 0.0
                                newRow("markup_rate_management") = 0.0
                                newRow("usa_vs_target_pros") = 0.0
                                newRow("fg_propose_price_det_note") = ""
                                FormFGProposePriceDet.getMarkUpActRateLoc(rh)

                                'REFRESH
                                FormFGProposePriceDet.GCItemListLocal.RefreshDataSource()
                                FormFGProposePriceDet.GVItemListLocal.RefreshData()
                            End If
                        Next
                        'For a As Integer = 0 To ((FormFGProposePriceDet.GVItemListLocal.RowCount - 1) - GetGroupRowCount(FormFGProposePriceDet.GVItemListLocal))
                        '    FormFGProposePriceDet.getMarkUpActRateLoc(a)
                        'Next
                        FormFGProposePriceDet.check_but_loc()
                        Close()
                        Cursor = Cursors.Default
                    End If
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        ElseIf id_pop_up = "2" Then 'IMPORT
            Dim jum_tot As Integer = 0
            Dim cond_same As Boolean = False
            Dim string_same As String = "-1"
            Dim id_design_same As String = "-1"
            Dim idx_same As Integer = 0
            For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                If BGVLineList.GetRowCellValue(i, "Select_sct") = "Yes" Then
                    jum_tot += 1
                    For c As Integer = 0 To ((FormFGProposePriceDet.GVItemListImport.RowCount - 1) - GetGroupRowCount(FormFGProposePriceDet.GVItemListImport))
                        If FormFGProposePriceDet.GVItemListImport.GetRowCellValue(c, "id_design").ToString = BGVLineList.GetRowCellValue(i, "id_design").ToString Then
                            string_same = "Design : " + BGVLineList.GetRowCellValue(i, "CODE").ToString + "/" + BGVLineList.GetRowCellValue(i, "DESCRIPTION").ToString + ", already exist."
                            idx_same = i
                            cond_same = True
                            Exit For
                        End If
                    Next
                    If cond_same Then
                        Exit For
                    End If
                End If
            Next

            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            If jum_tot > 0 Then
                If cond_same Then
                    stopCustom(string_same)
                    BGVLineList.FocusedRowHandle = idx_same
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose designs list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        For ls As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                            If BGVLineList.GetRowCellValue(ls, "Select_sct").ToString = "Yes" Then
                                Dim newRow As DataRow = (TryCast(FormFGProposePriceDet.GCItemListImport.DataSource, DataTable)).NewRow()
                                TryCast(FormFGProposePriceDet.GCItemListImport.DataSource, DataTable).Rows.Add(newRow)
                                Dim rh As Integer = FormFGProposePriceDet.GVItemListImport.RowCount - 1
                                FormFGProposePriceDet.loadRoyCatImp()

                                newRow("id_fg_propose_price_det") = 0
                                newRow("prod_demand_number") = BGVLineList.GetRowCellValue(ls, "LAST PD").ToString
                                newRow("id_prod_demand") = BGVLineList.GetRowCellValue(ls, "id_prod_demand_last").ToString
                                newRow("design_code_import") = BGVLineList.GetRowCellValue(ls, "CODE IMPORT").ToString
                                newRow("design_code") = BGVLineList.GetRowCellValue(ls, "CODE").ToString
                                newRow("season_orign_display") = BGVLineList.GetRowCellValue(ls, "SEASON ORIGN").ToString
                                newRow("id_season_orign") = BGVLineList.GetRowCellValue(ls, "id_season_orign").ToString
                                newRow("country_display_name") = BGVLineList.GetRowCellValue(ls, "STYLE COUNTRY").ToString
                                newRow("source") = BGVLineList.GetRowCellValue(ls, "PRODUCT ORIGIN").ToString
                                newRow("class") = BGVLineList.GetRowCellValue(ls, "CLASS").ToString
                                newRow("division") = BGVLineList.GetRowCellValue(ls, "DIVISION").ToString
                                newRow("delivery") = BGVLineList.GetRowCellValue(ls, "DEL").ToString
                                newRow("id_delivery") = BGVLineList.GetRowCellValue(ls, "id_delivery").ToString
                                newRow("design_display_name") = BGVLineList.GetRowCellValue(ls, "DESCRIPTION").ToString
                                newRow("id_design") = BGVLineList.GetRowCellValue(ls, "id_design").ToString
                                newRow("color") = BGVLineList.GetRowCellValue(ls, "COLOR").ToString
                                newRow("fg_propose_price_det_qty") = BGVLineList.GetRowCellValue(ls, "TOTAL QTY_Breakdown_Plan")
                                newRow("design_eos") = BGVLineList.GetRowCellValue(ls, "EOS")
                                newRow("lifetime") = BGVLineList.GetRowCellValue(ls, "AGE").ToString
                                newRow("delivery_date") = BGVLineList.GetRowCellValue(ls, "IN STORE DATE")
                                newRow("design_ret") = BGVLineList.GetRowCellValue(ls, "RET DATE")
                                newRow("ret_code") = BGVLineList.GetRowCellValue(ls, "CODE RET").ToString
                                newRow("rate_bom") = BGVLineList.GetRowCellValue(ls, "RATE BOM_Prc")
                                newRow("organic_cost_bom") = BGVLineList.GetRowCellValue(ls, "ORGANIC COST RATE BOM_Prc")
                                newRow("rate_management") = BGVLineList.GetRowCellValue(ls, "RATE MANAGEMENT_Prc")
                                newRow("organic_cost_management") = BGVLineList.GetRowCellValue(ls, "ORGANIC COST RATE MANAGEMENT_Prc")
                                newRow("msrp") = BGVLineList.GetRowCellValue(ls, "MSRP PD")
                                newRow("msrp_rp") = BGVLineList.GetRowCellValue(ls, "MSRP RP PD")
                                newRow("usa_inc") = 0.0
                                newRow("price_pd") = BGVLineList.GetRowCellValue(ls, "PRICE PD")
                                newRow("price_target") = 0.0
                                newRow("price_final") = BGVLineList.GetRowCellValue(ls, "PRICE PD")
                                newRow("royalty_usa_pros") = 0.0
                                newRow("royalty_one_usd") = BGVLineList.GetRowCellValue(ls, "RATE MANAGEMENT_Prc")
                                newRow("id_royalty_category") = 0
                                newRow("royalty_total") = 0.0
                                newRow("royalty_tax_pros") = 0.0
                                newRow("royalty_tax_amount") = 0.0
                                newRow("import_duty_pros") = 0.0
                                newRow("import_duty_amount") = 0.0
                                newRow("cop_pd") = BGVLineList.GetRowCellValue(ls, "COP PD")
                                newRow("cop_final_rate_bom") = 0.0
                                newRow("cop_final_rate_management") = 0.0
                                newRow("cop_status") = BGVLineList.GetRowCellValue(ls, "COP STATUS_Prc").ToString

                                Dim m_pd As Decimal = 0.0
                                Try
                                    m_pd = BGVLineList.GetRowCellValue(ls, "PRICE PD") / BGVLineList.GetRowCellValue(ls, "COP PD")
                                Catch ex As Exception
                                End Try
                                newRow("markup_pd") = m_pd
                                newRow("markup_pd_rate_bom") = 0.0
                                newRow("markup_pd_rate_management") = 0.0
                                newRow("markup_rate_actual") = 0.0
                                newRow("markup_rate_management") = 0.0
                                newRow("usa_vs_target_pros") = 0.0
                                newRow("fg_propose_price_det_note") = ""

                                'auto 
                                FormFGProposePriceDet.getFinalCOPActRate(rh)
                                FormFGProposePriceDet.getMsrpRp(rh)
                                FormFGProposePriceDet.getUsaVsTarget(rh)
                                FormFGProposePriceDet.getFinalCOPRateApp(rh)
                                FormFGProposePriceDet.getMsrpRp(rh)
                                FormFGProposePriceDet.getUsaVsTarget(rh)
                                FormFGProposePriceDet.getMarkUpPD(rh)
                                FormFGProposePriceDet.getMarkUpPDActRate(rh)
                                FormFGProposePriceDet.getMarkUpPDRateApp(rh)
                                FormFGProposePriceDet.getRoyaltyTot(rh)
                                FormFGProposePriceDet.getRoyaltyTax(rh)
                                FormFGProposePriceDet.getMarkUpActRate(rh)
                                FormFGProposePriceDet.getMarkUpRateApp(rh)
                                FormFGProposePriceDet.getUsaVsTarget(rh)
                                FormFGProposePriceDet.getRoyaltyTot(rh)
                                FormFGProposePriceDet.getMarkUpPD(rh)

                                'REFRESH
                                FormFGProposePriceDet.GCItemListImport.RefreshDataSource()
                                FormFGProposePriceDet.GVItemListImport.RefreshData()
                            End If
                        Next
                        FormFGProposePriceDet.check_but_imp()
                        Close()
                        Cursor = Cursors.Default
                    End If
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        If BGVLineList.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            Dim line_act As String = "-1"
            For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                'And BGVLineList.GetRowCellValue(i, "id_prod_demand_last").ToString = "0"
                If id_pop_up = "-1" Then
                    line_act = "1"

                    If cek And line_act = "1" Then
                        BGVLineList.SetRowCellValue(i, "Select_sct", "Yes")
                    Else
                        BGVLineList.SetRowCellValue(i, "Select_sct", "No")
                    End If
                ElseIf id_pop_up = "1" Or id_pop_up = "2" Then
                    line_act = "1"

                    If cek And line_act = "1" And BGVLineList.GetRowCellValue(i, "id_report_status").ToString = "0" And BGVLineList.GetRowCellValue(i, "id_cop_status_Prc").ToString = "1" And BGVLineList.GetRowCellValue(i, "PRODUCT ORIGIN").ToString = FormFGProposePriceDet.LESource.Text.ToUpper Then
                        BGVLineList.SetRowCellValue(i, "Select_sct", "Yes")
                    Else
                        BGVLineList.SetRowCellValue(i, "Select_sct", "No")
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FormProdDemandLineList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub noEdit()
        If BGVLineList.FocusedRowHandle >= 0 And (id_pop_up = "1" Or id_pop_up = "2") Then ' for propose price  list
            Dim query_c As ClassDesign = New ClassDesign()
            Dim line_act As String = query_c.getLineActFocus(SLETypeLineList.EditValue.ToString, BGVLineList)
            Dim rep_status As String = BGVLineList.GetFocusedRowCellValue("id_report_status").ToString
            Dim id_cop_status As String = BGVLineList.GetFocusedRowCellValue("id_cop_status_Prc").ToString
            Dim source As String = BGVLineList.GetFocusedRowCellValue("PRODUCT ORIGIN").ToString
            If line_act = "1" And rep_status = "0" And id_cop_status = "1" And source = FormFGProposePriceDet.LESource.Text.ToUpper Then 'opened
                BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = True
            Else
                BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = False
            End If
        ElseIf BGVLineList.FocusedRowHandle >= 0 And id_pop_up = "-1" Then
            Dim query_c As ClassDesign = New ClassDesign()
            Dim line_act As String = query_c.getLineActFocus(SLETypeLineList.EditValue.ToString, BGVLineList)
            If line_act = "1" Then 'opened
                BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = True
            Else
                BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub

    Private Sub BGVLineList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles BGVLineList.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        noEdit()
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGVLineList.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        noEdit()
        Cursor = Cursors.Default
    End Sub

End Class