Public Class FormViewFGProposePrice
    Public id_fg_propose_price As String = "-1"
    Public action As String = "-1"
    Public id_source As String = "-1"
    Dim id_code_fg_source_local As String = "-1"
    Dim id_code_fg_source_import As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_propose_price_det_list As New List(Of String)

    Private Sub FormFGProposePriceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'inisial
        id_code_fg_source_local = get_setup_field("id_code_fg_source_local")
        id_code_fg_source_import = get_setup_field("id_code_fg_source_import")

        viewReportStatus()
        viewSeason()
        _view_source_fg(LESource)
        _view_division_fg(LESampleDivision)
        actionLoad()
    End Sub


    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    'VIEW DETAIL
    Sub viewDetail()
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryDetail(id_fg_propose_price)
        Dim data_imp As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_loc As DataTable = execute_query(query, -1, True, "", "", "", "")
        'action upd
        If action = "upd" Then
            If LESource.EditValue.ToString = id_code_fg_source_import Then 'imp
                For i As Integer = 0 To (data_imp.Rows.Count - 1)
                    id_fg_propose_price_det_list.Add(data_imp.Rows(i)("id_fg_propose_price_det").ToString)
                Next
            ElseIf LESource.EditValue.ToString = id_code_fg_source_local Then 'loc
                For i As Integer = 0 To (data_loc.Rows.Count - 1)
                    id_fg_propose_price_det_list.Add(data_loc.Rows(i)("id_fg_propose_price_det").ToString)
                Next
            End If
        End If

        'import
        GCItemListImport.DataSource = data_imp

        'lokal
        GCItemListLocal.DataSource = data_loc
    End Sub

    'enable/disable Edit/Delete Detail
    Sub check_but_imp()
 
    End Sub

    Sub check_but_loc()
     
    End Sub

    Sub loadRoyCatImp()
        Dim query_cat As String = "SELECT a.id_code_detail, (a.code_detail_name) AS Category FROM tb_m_code_detail a JOIN (SELECT tb_opt.id_code_fg_royalty FROM tb_opt) b WHERE a.id_code = b.id_code_fg_royalty "
        Dim data_cat As DataTable = execute_query(query_cat, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data_cat
        RepositoryItemSearchLookUpEdit1.PopulateViewColumns()
        RepositoryItemSearchLookUpEdit1.NullText = ""
        RepositoryItemSearchLookUpEdit1.View.Columns("id_code_detail").Visible = False
        RepositoryItemSearchLookUpEdit1.DisplayMember = "Category"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_code_detail"
    End Sub

    'load
    Sub actionLoad()
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("AND tb_fg_propose_price.id_fg_propose_price = ''" + id_fg_propose_price + "'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        LESource.ItemIndex = LESource.Properties.GetDataSourceRowIndex("id_source", data.Rows(0)("id_source"))
        LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_division", data.Rows(0)("id_division"))
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        DEForm.Text = view_date_from(data.Rows(0)("fg_propose_price_datex").ToString, 0)
        MENote.Text = data.Rows(0)("fg_propose_price_note").ToString

        viewDetail()
        allow_status()
        check_but_imp()
        check_but_loc()
    End Sub

    Sub allow_status()
        'Based on report status
        'MsgBox("Nggak Boleh")
        LESampleDivision.Enabled = False
        LESource.Enabled = False
        SLESeason.Enabled = False
        MENote.Enabled = False
        GVItemListImport.OptionsBehavior.ReadOnly = True
        GVItemListLocal.OptionsBehavior.ReadOnly = True
        BtnAttachment.Enabled = True
    End Sub


    Private Sub LESource_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESource.EditValueChanged
        Dim val As String = LESource.EditValue.ToString
        If val = id_code_fg_source_local Then
            XTPLocal.PageVisible = True
            XTCFGProposePrice.SelectedTabPageIndex = 0
            XTPImport.PageVisible = False
        Else
            XTPLocal.PageVisible = False
            XTCFGProposePrice.SelectedTabPageIndex = 1
            XTPImport.PageVisible = True
        End If
    End Sub

   
    Private Sub FormFGProposePriceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

  

    Private Sub GVItemListImport_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemListImport.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub



    Private clone As DataView = Nothing
    Private Sub GVItemListImport_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemListImport.ShownEditor

    End Sub

    Private Sub GVItemListImport_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemListImport.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Private Sub GVItemListImport_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemListImport.CellValueChanged
        Dim hd As Integer = e.RowHandle
        If e.Column.FieldName = "organic_cost_bom" Then
            'GET COP FINAL IN ACTUAL RATE
            getFinalCOPActRate(hd)
        ElseIf e.Column.FieldName = "organic_cost_management" Then
            'GET COP FINAL IN RATE APPROVE
            getFinalCOPRateApp(hd)
        ElseIf e.Column.FieldName = "msrp" Then
            'GET MSRP
            getMsrpRp(hd)

            'GET USA VS TARGET
            getUsaVsTarget(hd)
        ElseIf e.Column.FieldName = "usa_inc" Then
            'GET MSRP
            getMsrpRp(hd)
        ElseIf e.Column.FieldName = "price_target" Then
            'GET ROTALTY TAX
            getRoyaltyTax(hd)
        ElseIf e.Column.FieldName = "price_final" Then
            'GET ROYALTY TOT
            getRoyaltyTot(hd)

            'GET ROYALTY TAX
            getRoyaltyTax(hd)

            'GET MARKUP ACT RATE
            getMarkUpActRate(hd)

            'GET MARKUP RATE APP
            getMarkUpRateApp(hd)

            'GET USA VS TARGET
            getUsaVsTarget(hd)
        ElseIf e.Column.FieldName = "price_pd" Then
            'GET MARK UP PD
            getMarkUpPD(hd)

            'GET MARK UP PD ACT RATE
            getMarkUpPDActRate(hd)

            'GET MARK UP PD RATE APP
            getMarkUpPDRateApp(hd)
        ElseIf e.Column.FieldName = "cop_pd" Then
            'GET MARK UP PD
            getMarkUpPD(hd)
        ElseIf e.Column.FieldName = "cop_final_rate_bom" Then
            'GET MARK UP PD ACT RATE
            getMarkUpPDActRate(hd)

            'GET MARKUP ACT RATE
            getMarkUpActRate(hd)
        ElseIf e.Column.FieldName = "cop_final_rate_management" Then
            'GET MARK UP PD RATE APP
            getMarkUpPDRateApp(hd)

            'GET MARKUP RATE APP
            getMarkUpRateApp(hd)
        ElseIf e.Column.FieldName = "royalty_usa_pros" Then
            'GET ROYALTY TOT
            getRoyaltyTot(hd)
        ElseIf e.Column.FieldName = "royalty_one_usd" Then
            'GET ROYALTY TOT
            getRoyaltyTot(hd)
        ElseIf e.Column.FieldName = "royalty_total" Then
            'GET COP ACT RATE
            getFinalCOPActRate(hd)

            'GET COP RATE MANAGEMENT
            getFinalCOPRateApp(hd)
        ElseIf e.Column.FieldName = "royalty_tax_pros" Then
            'GET ROYALTY TAX
            getRoyaltyTax(hd)
        ElseIf e.Column.FieldName = "royalty_tax_amount" Then
            ' GET TOTAL DUTY
            getImportDutyAmount(hd)
        ElseIf e.Column.FieldName = "import_duty_pros" Then
            ' GET TOTAL DUTY
            getImportDutyAmount(hd)
        ElseIf e.Column.FieldName = "import_duty_amount" Then
            'GET COP ACT RATE
            getFinalCOPActRate(hd)

            'GET COP RATE MANAGEMENT
            getFinalCOPRateApp(hd)
        ElseIf e.Column.FieldName = "rate_management" Then
            'GET MSRP
            getMsrpRp(hd)

            'USA VS TARGET
            getUsaVsTarget(hd)
        End If
        GCItemListImport.RefreshDataSource()
        GVItemListImport.RefreshData()
    End Sub

    Sub getAllFormula()
        For i As Integer = 0 To ((GVItemListImport.RowCount - 1) - GetGroupRowCount(GVItemListImport))
            getFinalCOPActRate(i)
            getFinalCOPRateApp(i)
            getMsrpRp(i)
            getUsaVsTarget(i)
            getMarkUpPD(i)
            getMarkUpPDActRate(i)
            getMarkUpPDRateApp(i)
            getRoyaltyTot(i)
            getRoyaltyTax(i)
            getImportDutyAmount(i)
            getMarkUpActRate(i)
            getMarkUpRateApp(i)
        Next
    End Sub

    Sub getFinalCOPActRate(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim oc As Decimal = 0.0
        Try
            oc = GVItemListImport.GetRowCellValue(hd, "organic_cost_bom")
        Catch ex As Exception
        End Try

        Dim duty As Decimal = 0.0
        Try
            duty = GVItemListImport.GetRowCellValue(hd, "import_duty_amount")
        Catch ex As Exception
        End Try

        Dim roy As Decimal = 0.0
        Try
            roy = GVItemListImport.GetRowCellValue(hd, "royalty_total")
        Catch ex As Exception
        End Try

        Try
            res = oc + duty + roy
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "cop_final_rate_bom", res)
    End Sub


    Sub getFinalCOPRateApp(ByVal hd As Integer)

        Dim res As Decimal = 0.0
        Dim oc As Decimal = 0.0
        Try
            oc = GVItemListImport.GetRowCellValue(hd, "organic_cost_management")
        Catch ex As Exception
        End Try

        Dim duty As Decimal = 0.0
        Try
            duty = GVItemListImport.GetRowCellValue(hd, "import_duty_amount")
        Catch ex As Exception
        End Try

        Dim roy As Decimal = 0.0
        Try
            roy = GVItemListImport.GetRowCellValue(hd, "royalty_total")
        Catch ex As Exception
        End Try

        Try
            res = oc + duty + roy
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "cop_final_rate_management", res)
    End Sub

    Sub getMsrpRp(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim msrp As Decimal = 0.0
        Try
            msrp = GVItemListImport.GetRowCellValue(hd, "msrp")
        Catch ex As Exception
        End Try

        Dim inc As Decimal = 0.0
        Try
            inc = GVItemListImport.GetRowCellValue(hd, "usa_inc") / 100
        Catch ex As Exception
        End Try

        Dim rate As Decimal = 0.0
        Try
            rate = GVItemListImport.GetRowCellValue(hd, "rate_management")
        Catch ex As Exception
        End Try

        Try
            res = (msrp + (msrp * (inc))) * rate
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "msrp_rp", res)
    End Sub

    Sub getUsaVsTarget(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim prc As Decimal = 0.0
        Try
            prc = GVItemListImport.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try

        Dim msrp As Decimal = 0.0
        Try
            msrp = GVItemListImport.GetRowCellValue(hd, "msrp")
        Catch ex As Exception
        End Try

        Dim rate As Decimal = 0.0
        Try
            rate = GVItemListImport.GetRowCellValue(hd, "rate_management")
        Catch ex As Exception
        End Try


        Try
            res = ((prc - (msrp * rate)) / (msrp * rate)) * 100
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "usa_vs_target_pros", res)
    End Sub

    Sub getMarkUpPD(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim price As Decimal = 0.0
        Try
            price = GVItemListImport.GetRowCellValue(hd, "price_pd")
        Catch ex As Exception
        End Try

        Dim cop As Decimal = 0.0
        Try
            cop = GVItemListImport.GetRowCellValue(hd, "cop_pd")
        Catch ex As Exception
        End Try

        Try
            res = price / cop
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "markup_pd", res)
    End Sub

    Sub getMarkUpPDActRate(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim price As Decimal = 0.0
        Try
            price = GVItemListImport.GetRowCellValue(hd, "price_pd")
        Catch ex As Exception
        End Try

        Dim cop As Decimal = 0.0
        Try
            cop = GVItemListImport.GetRowCellValue(hd, "cop_final_rate_bom")
        Catch ex As Exception
        End Try

        Try
            res = price / cop
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "markup_pd_rate_bom", res)
    End Sub

    Sub getMarkUpPDRateApp(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim price As Decimal = 0.0
        Try
            price = GVItemListImport.GetRowCellValue(hd, "price_pd")
        Catch ex As Exception
        End Try

        Dim cop As Decimal = 0.0
        Try
            cop = GVItemListImport.GetRowCellValue(hd, "cop_final_rate_management")
        Catch ex As Exception
        End Try

        Try
            res = price / cop
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "markup_pd_rate_management", res)
    End Sub

    Sub getRoyaltyTot(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim roy_one_usd As Decimal = 0.0
        Try
            roy_one_usd = GVItemListImport.GetRowCellValue(hd, "royalty_one_usd")
        Catch ex As Exception
        End Try

        Dim roy_pros As Decimal = 0.0
        Try
            roy_pros = GVItemListImport.GetRowCellValue(hd, "royalty_usa_pros")
        Catch ex As Exception
        End Try

        Dim prc_final As Decimal = 0.0
        Try
            prc_final = GVItemListImport.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try
        If roy_one_usd > 0 Then
            res = roy_one_usd
        Else
            res = (prc_final * 0.5) * (roy_pros / 100)
        End If
        GVItemListImport.SetRowCellValue(hd, "royalty_total", res)
    End Sub

    Sub getRoyaltyTax(ByVal hd As Integer)
        Dim res As Decimal = 0.0

        Dim tax_pros As Decimal = 0.0
        Try
            tax_pros = GVItemListImport.GetRowCellValue(hd, "royalty_tax_pros") / 100
        Catch ex As Exception
        End Try

        Dim price_final As Decimal = 0.0
        Try
            price_final = GVItemListImport.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try

        Dim price_target As Decimal = 0.0
        Try
            price_target = GVItemListImport.GetRowCellValue(hd, "price_target")
        Catch ex As Exception
        End Try

        If price_final > 0 Then
            res = (price_final * 0.75) * tax_pros
        Else
            res = (price_target * 0.75) * tax_pros
        End If

        GVItemListImport.SetRowCellValue(hd, "royalty_tax_amount", res)
    End Sub

    Sub getImportDutyAmount(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim import_duty_pros As Decimal = 0.0
        Try
            import_duty_pros = GVItemListImport.GetRowCellValue(hd, "import_duty_pros") / 100
        Catch ex As Exception
        End Try

        Dim royalty_tax_amount = 0
        Try
            royalty_tax_amount = GVItemListImport.GetRowCellValue(hd, "royalty_tax_amount")
        Catch ex As Exception
        End Try

        res = import_duty_pros * royalty_tax_amount
        GVItemListImport.SetRowCellValue(hd, "import_duty_amount", res)
    End Sub

    Sub getMarkUpActRate(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim price_final As Decimal = 0.0
        Try
            price_final = GVItemListImport.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try

        Dim cop_final_rate_bom As Decimal = 0.0
        Try
            cop_final_rate_bom = GVItemListImport.GetRowCellValue(hd, "cop_final_rate_bom")
        Catch ex As Exception
        End Try

        Try
            res = price_final / cop_final_rate_bom
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "markup_rate_actual", res)
    End Sub

    Sub getMarkUpRateApp(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim price_final As Decimal = 0.0
        Try
            price_final = GVItemListImport.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try

        Dim cop_final_rate_management As Decimal = 0.0
        Try
            cop_final_rate_management = GVItemListImport.GetRowCellValue(hd, "cop_final_rate_management")
        Catch ex As Exception
        End Try

        Try
            res = price_final / cop_final_rate_management
        Catch ex As Exception
        End Try
        GVItemListImport.SetRowCellValue(hd, "markup_rate_management", res)
    End Sub

    'CUSTOM SUMMARY IMPORT
    Dim custom_sum_final_price As Decimal
    Dim custom_sum_cop_pd As Decimal
    Dim custom_sum_cop_act_rate As Decimal
    Dim custom_sum_cop_rate_app As Decimal
    Dim custom_sum_markup_act_rate_prc As Decimal
    Dim custom_sum_markup_act_rate_cop As Decimal
    Dim custom_sum_markup_rate_app_prc As Decimal
    Dim custom_sum_markup_rate_app_cop As Decimal
    Private Sub GVItemListImport_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GVItemListImport.CustomSummaryCalculate
        ' Get the summary ID. 
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            custom_sum_final_price = 0
            custom_sum_cop_pd = 0
            custom_sum_cop_act_rate = 0
            custom_sum_cop_rate_app = 0
            custom_sum_markup_act_rate_prc = 0
            custom_sum_markup_act_rate_cop = 0
            custom_sum_markup_rate_app_prc = 0
            custom_sum_markup_rate_app_cop = 0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
            Dim cop_pd As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_pd"), "0.00"))
            Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
            Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
            Select Case summaryID
                Case 1
                    custom_sum_final_price += prc * qty
                Case 2
                    custom_sum_cop_pd += cop_pd * qty
                Case 3
                    custom_sum_cop_act_rate += cop_act_rate * qty
                Case 4
                    custom_sum_cop_rate_app += cop_rate_app * qty
                Case 5
                    custom_sum_markup_act_rate_prc += prc * qty
                    custom_sum_markup_act_rate_cop += cop_act_rate * qty
                Case 6
                    custom_sum_markup_rate_app_prc = prc * qty
                    custom_sum_markup_rate_app_cop = cop_rate_app * qty
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    e.TotalValue = custom_sum_final_price
                Case 2
                    e.TotalValue = custom_sum_cop_pd
                Case 3
                    e.TotalValue = custom_sum_cop_act_rate
                Case 4
                    e.TotalValue = custom_sum_cop_rate_app
                Case 5
                    Dim res_mk_act = 0.0
                    Try
                        res_mk_act = custom_sum_markup_act_rate_prc / custom_sum_markup_act_rate_cop
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_act
                Case 6
                    Dim res_mk_app = 0.0
                    Try
                        res_mk_app = custom_sum_markup_rate_app_prc / custom_sum_markup_rate_app_cop
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_app
            End Select
        End If

    End Sub



    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_propose_price
        FormReportMark.report_mark_type = "70"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_fg_propose_price
        FormDocumentUpload.report_mark_type = "70"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListLocal_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemListLocal.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but_loc()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListLocal_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemListLocal.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but_loc()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListImport_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemListImport.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but_imp()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListImport_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemListImport.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but_imp()
        Cursor = Cursors.Default
    End Sub

    Sub getMarkUpActRateLoc(ByVal hd As Integer)
        Dim res As Decimal = 0.0
        Dim price_final As Decimal = 0.0
        Try
            price_final = GVItemListLocal.GetRowCellValue(hd, "price_final")
        Catch ex As Exception
        End Try

        Dim cop_final_rate_bom As Decimal = 0.0
        Try
            cop_final_rate_bom = GVItemListLocal.GetRowCellValue(hd, "cop_final_rate_bom")
        Catch ex As Exception
        End Try

        Try
            res = price_final / cop_final_rate_bom
        Catch ex As Exception
        End Try
        GVItemListLocal.SetRowCellValue(hd, "markup_rate_actual", res)
    End Sub

    Private Sub GVItemListLocal_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemListLocal.CellValueChanged
        Dim hd As Integer = e.RowHandle

        If e.Column.FieldName = "cop_final_rate_bom" Then
            getMarkUpActRateLoc(hd)
        ElseIf e.Column.FieldName = "price_final" Then
            getMarkUpActRateLoc(hd)
        End If
        GCItemListLocal.RefreshDataSource()
        GVItemListLocal.RefreshData()
    End Sub

    Private Sub GVItemListLocal_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemListLocal.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    'CUSTOM SUMMARY LOCAL
    Dim custom_sum_final_price_loc As Decimal
    Dim custom_sum_cop_act_rate_loc As Decimal
    Dim custom_sum_markup_act_rate_prc_loc As Decimal
    Dim custom_sum_markup_act_rate_cop_loc As Decimal
    Private Sub GVItemListLocal_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GVItemListLocal.CustomSummaryCalculate
        ' Get the summary ID. 
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            custom_sum_final_price_loc = 0
            custom_sum_cop_act_rate_loc = 0
            custom_sum_markup_act_rate_prc_loc = 0
            custom_sum_markup_act_rate_cop_loc = 0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
            Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
            Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
            Select Case summaryID
                Case 1
                    custom_sum_final_price_loc += prc * qty
                Case 2
                    custom_sum_cop_act_rate_loc += cop_act_rate * qty
                Case 3
                    custom_sum_markup_act_rate_prc_loc += prc * qty
                    custom_sum_markup_act_rate_cop_loc += cop_act_rate * qty
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    e.TotalValue = custom_sum_final_price_loc
                Case 2
                    e.TotalValue = custom_sum_cop_act_rate_loc
                Case 3
                    Dim res_mk_act = 0.0
                    Try
                        res_mk_act = custom_sum_markup_act_rate_prc_loc / custom_sum_markup_act_rate_cop_loc
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_act
            End Select
        End If

    End Sub
End Class