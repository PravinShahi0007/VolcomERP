Public Class FormFGProposePriceDet 
    Public id_fg_propose_price As String = "-1"
    Public action As String = "-1"
    Public id_source As String = "-1"
    Dim id_code_fg_source_local As String = "-1"
    Dim id_code_fg_source_import As String = "-1"
    Public id_report_status As String = "-1"
    Public id_fg_propose_price_det_list As New List(Of String)
    Dim vmenu As New System.Windows.Forms.ContextMenuStrip

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
        query += "WHERE b.is_md='1' "
        query += "ORDER BY b.range DESC"
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
                GCItemListImport.DataSource = data_imp
            ElseIf LESource.EditValue.ToString = id_code_fg_source_local Then 'loc
                For i As Integer = 0 To (data_loc.Rows.Count - 1)
                    id_fg_propose_price_det_list.Add(data_loc.Rows(i)("id_fg_propose_price_det").ToString)
                Next
                GCItemListLocal.DataSource = data_loc
            End If
        Else
            GCItemListImport.DataSource = data_imp
            GCItemListLocal.DataSource = data_loc
        End If
    End Sub

    'enable/disable Edit/Delete Detail
    Sub check_but_imp()
        Dim id_cek As String = "-1"
        Try
            id_cek = GVItemListImport.GetFocusedRowCellValue("id_fg_propose_price_det").ToString
        Catch ex As Exception
        End Try

        If GVItemListImport.RowCount > 0 And id_cek <> "-1" Then
            BtnDeleteImp.Enabled = True
        Else
            BtnDeleteImp.Enabled = False
        End If
    End Sub

    Sub check_but_loc()
        Dim id_cek As String = "-1"
        Try
            id_cek = GVItemListLocal.GetFocusedRowCellValue("id_fg_propose_price_det").ToString
        Catch ex As Exception
        End Try

        If GVItemListLocal.RowCount > 0 And id_cek <> "-1" Then
            BtnDeleteLocal.Enabled = True
        Else
            BtnDeleteLocal.Enabled = False
        End If
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
        If action = "ins" Then
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            BtnPrint.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail()
            check_but_imp()
            check_but_loc()
        ElseIf action = "upd" Then
            BtnSave.Text = "Save Changes"
            BMark.Enabled = True
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
            loadRoyCatImp()
            allow_status()
            check_but_imp()
            check_but_loc()
        End If
    End Sub

    Sub allow_status()
        'Based on report status
        If check_edit_report_status(id_report_status, "70", id_fg_propose_price) Then
            'MsgBox("Masih Boleh")
            PanelControlNavLokal.Enabled = True
            PanelControlNavImport.Enabled = True
            BtnSave.Enabled = True
            BtnAddImp.Enabled = True
            BtnDeleteImp.Enabled = True
            BtnAddLocal.Enabled = True
            BtnDeleteImp.Enabled = True
            LESampleDivision.Enabled = False
            LESource.Enabled = False
            SLESeason.Enabled = False
            MENote.Enabled = True
            GVItemListImport.OptionsBehavior.ReadOnly = False
            GVItemListLocal.OptionsBehavior.ReadOnly = False
        Else
            'MsgBox("Nggak Boleh")
            PanelControlNavLokal.Enabled = False
            PanelControlNavImport.Enabled = False
            BtnSave.Enabled = False
            BtnAddImp.Enabled = False
            BtnDeleteImp.Enabled = False
            BtnAddLocal.Enabled = False
            BtnDeleteImp.Enabled = False
            LESampleDivision.Enabled = False
            LESource.Enabled = False
            SLESeason.Enabled = False
            MENote.Enabled = False
            GVItemListImport.OptionsBehavior.ReadOnly = True
            GVItemListLocal.OptionsBehavior.ReadOnly = True
        End If

        If check_attach_report_status(id_report_status, "70", id_fg_propose_price) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub


    Private Sub LESource_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESource.EditValueChanged
        Cursor = Cursors.WaitCursor
        'menu design info
        Dim val As String = LESource.EditValue.ToString
        If val = id_code_fg_source_local Then
            Dim vmenu_prop As ClassOwnMenu = New ClassOwnMenu()
            vmenu_prop.removeAllMenu(vmenu)
            XTPLocal.PageVisible = True
            XTCFGProposePrice.SelectedTabPageIndex = 0
            XTPImport.PageVisible = False
            GCItemListLocal.Visible = True
            GCItemListImport.Visible = False
            vmenu_prop.createDesignInfo(vmenu, GVItemListLocal)
        Else
            Dim vmenu_prop As ClassOwnMenu = New ClassOwnMenu()
            vmenu_prop.removeAllMenu(vmenu)
            XTPLocal.PageVisible = False
            XTCFGProposePrice.SelectedTabPageIndex = 1
            XTPImport.PageVisible = True
            GCItemListLocal.Visible = False
            GCItemListImport.Visible = True
            vmenu_prop.createDesignInfo(vmenu, GVItemListImport)
        End If
        If action = "ins" Then
            viewDetail()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGProposePriceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAddImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddImp.Click
        Cursor = Cursors.WaitCursor
        'FormProdDemandLineList.id_season_par = SLESeason.EditValue.ToString
        FormProdDemandLineList.SLETypeLineList.Enabled = False
        FormProdDemandLineList.id_pop_up = "2"
        FormProdDemandLineList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListImport_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemListImport.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnDeleteImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteImp.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            If action = "ins" Then
                Try
                    GVItemListImport.DeleteSelectedRows()
                    GCItemListImport.RefreshDataSource()
                    GVItemListImport.RefreshData()
                    check_but_imp()
                Catch ex As Exception
                    errorDelete()
                End Try
            ElseIf action = "upd" Then
                Dim id_ As String = GVItemListImport.GetFocusedRowCellValue("id_fg_propose_price_det").ToString
                Dim query_del_upd As String = "DELETE FROM tb_fg_propose_price_det WHERE id_fg_propose_price_det = '" + id_ + "' "
                Try
                    execute_non_query(query_del_upd, True, "", "", "", "")
                    id_fg_propose_price_det_list.Clear()
                    viewDetail()
                    check_but_imp()
                Catch ex As Exception
                    errorDelete()
                    Close()
                End Try
            End If
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
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
            Dim qty As Decimal = 0.0
            Try
                qty = View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty")
            Catch ex As Exception
            End Try
            Dim prc As Decimal = 0.0
            Try
                prc = View.GetRowCellValue(e.RowHandle, "price_final")
            Catch ex As Exception
            End Try
            Dim cop_pd As Decimal = 0.0
            Try
                cop_pd = View.GetRowCellValue(e.RowHandle, "cop_pd")
            Catch ex As Exception
            End Try
            Dim cop_act_rate As Decimal = 0.0
            Try
                cop_act_rate = View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom")
            Catch ex As Exception
            End Try
            Dim cop_rate_app As Decimal = 0.0
            Try
                cop_rate_app = View.GetRowCellValue(e.RowHandle, "cop_final_rate_management")
            Catch ex As Exception
            End Try
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

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemListImport)
        makeSafeGV(GVItemListLocal)

        Dim cond_check As Boolean = False
        If LESource.EditValue.ToString = id_code_fg_source_import Then 'import
            If GVItemListImport.RowCount <= 0 Then
                cond_check = False
            Else
                cond_check = True
            End If
        ElseIf LESource.EditValue.ToString = id_code_fg_source_local Then 'local
            If GVItemListLocal.RowCount <= 0 Then
                cond_check = False
            Else
                cond_check = True
            End If
        End If

        Dim cond_dt As Boolean = True


        If Not cond_check Then
            stopCustom("List can't blank !")
        ElseIf Not cond_dt Then
            stopCustom("Effective date can't blank !")
        Else
            Dim id_season As String = SLESeason.EditValue.ToString
            Dim fg_propose_price_number As String = TxtNumber.Text 'generate after save
            Dim fg_propose_price_note As String = MENote.Text.ToString
            Dim id_report_status As String = LEReportStatus.EditValue.ToString
            Dim id_source As String = LESource.EditValue.ToString
            Dim id_division As String = LESampleDivision.EditValue.ToString
            Dim GV As DevExpress.XtraGrid.Views.Grid.GridView
            If id_source = id_code_fg_source_import Then 'import
                GV = GVItemListImport
            Else
                GV = GVItemListLocal
            End If


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    'get PP number 
                    fg_propose_price_number = execute_query("SELECT gen_pp_number('" + id_season + "', '" + id_division + "')", 0, True, "", "", "", "")

                    'insert new
                    Dim query As String = "INSERT INTO tb_fg_propose_price(id_season, fg_propose_price_number, fg_propose_price_date, fg_propose_price_note, id_report_status, id_source, id_division) VALUES "
                    query += "('" + id_season + "', '" + fg_propose_price_number + "', NOW(),'" + fg_propose_price_note + "', '" + id_report_status + "', '" + id_source + "', '" + id_division + "'); SELECT LAST_INSERT_ID(); "
                    id_fg_propose_price = execute_query(query, 0, True, "", "", "", "")

                    'insert who prepared
                    insert_who_prepared("70", id_fg_propose_price, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GV.RowCount > 0 Then
                        query_detail += "INSERT INTO tb_fg_propose_price_det( "
                        query_detail += "id_fg_propose_price,fg_propose_price_det_qty, rate_bom, organic_cost_bom, rate_management, "
                        query_detail += "organic_cost_management, rate_pd, msrp, msrp_rp, usa_inc, price_pd, price_target, "
                        query_detail += "price_final, royalty_usa_pros, royalty_one_usd, royalty_total, royalty_tax_pros, royalty_tax_amount, "
                        query_detail += "import_duty_pros, import_duty_amount, cop_pd, cop_final_rate_bom, cop_final_rate_management, "
                        query_detail += "id_design, id_prod_demand, id_royalty_category, markup_pd, markup_pd_rate_bom , markup_pd_rate_management, markup_rate_actual, markup_rate_management, usa_vs_target_pros, fg_propose_price_det_note, effective_date) "
                        query_detail += "VALUES "
                    End If
                    For j As Integer = 0 To ((GV.RowCount - 1) - GetGroupRowCount(GV))
                        Dim id_design As String = myCoalesce(GV.GetRowCellValue(j, "id_design").ToString, "0")
                        Dim id_prod_demand As String = myCoalesce(GV.GetRowCellValue(j, "id_prod_demand").ToString, "0")
                        Dim fg_propose_price_det_qty As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "fg_propose_price_det_qty").ToString, "0"))
                        Dim rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_bom").ToString, "0"))
                        Dim organic_cost_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "organic_cost_bom").ToString, "0"))
                        Dim rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_management").ToString, "0"))
                        Dim organic_cost_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "organic_cost_management").ToString, "0"))
                        Dim rate_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_pd").ToString, "0"))
                        Dim msrp As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "msrp").ToString, "0"))
                        Dim msrp_rp As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "msrp_rp").ToString, "0"))
                        Dim usa_inc As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "usa_inc").ToString, "0"))
                        Dim price_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_pd").ToString, ")"))
                        Dim price_target As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_target").ToString, "0"))
                        Dim price_final As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_final").ToString, "0"))
                        Dim royalty_usa_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_usa_pros").ToString, "0"))
                        Dim royalty_one_usd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_one_usd").ToString, "0"))
                        Dim id_royalty_category As String = myCoalesce(GV.GetRowCellValue(j, "id_royalty_category").ToString, "0")
                        Dim royalty_total As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_total").ToString, "0"))
                        Dim royalty_tax_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_tax_pros"), "0"))
                        Dim royalty_tax_amount As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_tax_amount").ToString, "0"))
                        Dim import_duty_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "import_duty_pros").ToString, "0"))
                        Dim import_duty_amount As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "import_duty_amount").ToString, "0"))
                        Dim cop_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_pd").ToString, "0"))
                        Dim cop_final_rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_final_rate_bom"), "0"))
                        Dim cop_final_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_final_rate_management"), "0"))
                        Dim markup_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd").ToString, "0.00"))
                        Dim markup_pd_rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd_rate_bom").ToString, "0"))
                        Dim markup_pd_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd_rate_management").ToString, "0"))
                        Dim markup_rate_actual As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_rate_actual").ToString, "0"))
                        Dim markup_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_rate_management").ToString, "0"))
                        Dim usa_vs_target_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "usa_vs_target_pros").ToString, "0"))
                        Dim fg_propose_price_det_note As String = myCoalesce(GV.GetRowCellValue(j, "fg_propose_price_det_note").ToString, "")
                        Dim effective_date As String = "NULL"

                        If jum_ins_j > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "("
                        query_detail += "'" + id_fg_propose_price + "','" + fg_propose_price_det_qty + "', '" + rate_bom + "', '" + organic_cost_bom + "', '" + rate_management + "', "
                        query_detail += "'" + organic_cost_management + "', '" + rate_pd + "', '" + msrp + "', '" + msrp_rp + "', '" + usa_inc + "', '" + price_pd + "', '" + price_target + "', "
                        query_detail += "'" + price_final + "', '" + royalty_usa_pros + "', '" + royalty_one_usd + "', '" + royalty_total + "', '" + royalty_tax_pros + "', '" + royalty_tax_amount + "', "
                        query_detail += "'" + import_duty_pros + "', '" + import_duty_amount + "', '" + cop_pd + "', '" + cop_final_rate_bom + "', '" + cop_final_rate_management + "', "
                        query_detail += "'" + id_design + "', "
                        If id_prod_demand > "0" Then
                            query_detail += "'" + id_prod_demand + "', "
                        Else
                            query_detail += "NULL, "
                        End If
                        If id_royalty_category > "0" Then
                            query_detail += "'" + id_royalty_category + "', "
                        Else
                            query_detail += "NULL, "
                        End If
                        query_detail += "'" + markup_pd + "', '" + markup_pd_rate_bom + "' , '" + markup_pd_rate_management + "', '" + markup_rate_actual + "', '" + markup_rate_management + "', '" + usa_vs_target_pros + "', '" + fg_propose_price_det_note + "', " + effective_date + " "
                        query_detail += ")"
                        jum_ins_j = jum_ins_j + 1
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'END PROCESS
                    infoCustom("Propose Price No: " + fg_propose_price_number + " has been sucessfully created.")
                    BtnSave.Text = "Save Changes"
                    action = "upd"
                    actionLoad()
                    FormFGProposePrice.viewPropose()
                    FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id_fg_propose_price)
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    'main query
                    Dim query As String = ""
                    query += "UPDATE tb_fg_propose_price SET id_season='" + id_season + "', fg_propose_price_number='" + fg_propose_price_number + "', "
                    query += "fg_propose_price_note='" + fg_propose_price_note + "', id_report_status='" + id_report_status + "', id_source='" + id_source + "', id_division='" + id_division + "' "
                    query += "WHERE id_fg_propose_price='" + id_fg_propose_price + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail query
                    Dim jum_ins_j As Integer = 0
                    Dim query_edit As String = ""
                    Dim jum_edit_j As Integer = 0
                    Dim query_detail As String = ""
                    If GV.RowCount > 0 Then
                        query_detail += "INSERT INTO tb_fg_propose_price_det( "
                        query_detail += "id_fg_propose_price,fg_propose_price_det_qty, rate_bom, organic_cost_bom, rate_management, "
                        query_detail += "organic_cost_management, rate_pd, msrp, msrp_rp, usa_inc, price_pd, price_target, "
                        query_detail += "price_final, royalty_usa_pros, royalty_one_usd, royalty_total, royalty_tax_pros, royalty_tax_amount, "
                        query_detail += "import_duty_pros, import_duty_amount, cop_pd, cop_final_rate_bom, cop_final_rate_management, "
                        query_detail += "id_design, id_prod_demand, id_royalty_category, markup_pd, markup_pd_rate_bom , markup_pd_rate_management, markup_rate_actual, markup_rate_management, usa_vs_target_pros, fg_propose_price_det_note, effective_date) "
                        query_detail += "VALUES "
                    End If
                    For j As Integer = 0 To ((GV.RowCount - 1) - GetGroupRowCount(GV))
                        Dim id_fg_propose_price_det As String = GV.GetRowCellValue(j, "id_fg_propose_price_det").ToString
                        Dim id_design As String = myCoalesce(GV.GetRowCellValue(j, "id_design").ToString, "0")
                        Dim id_prod_demand As String = myCoalesce(GV.GetRowCellValue(j, "id_prod_demand").ToString, "0")
                        Dim fg_propose_price_det_qty As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "fg_propose_price_det_qty").ToString, "0"))
                        Dim rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_bom").ToString, "0"))
                        Dim organic_cost_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "organic_cost_bom").ToString, "0"))
                        Dim rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_management").ToString, "0"))
                        Dim organic_cost_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "organic_cost_management").ToString, "0"))
                        Dim rate_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "rate_pd").ToString, "0"))
                        Dim msrp As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "msrp").ToString, "0"))
                        Dim msrp_rp As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "msrp_rp").ToString, "0"))
                        Dim usa_inc As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "usa_inc").ToString, "0"))
                        Dim price_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_pd").ToString, ")"))
                        Dim price_target As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_target").ToString, "0"))
                        Dim price_final As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "price_final").ToString, "0"))
                        Dim royalty_usa_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_usa_pros").ToString, "0"))
                        Dim royalty_one_usd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_one_usd").ToString, "0"))
                        Dim id_royalty_category As String = myCoalesce(GV.GetRowCellValue(j, "id_royalty_category").ToString, "0")
                        Dim royalty_total As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_total").ToString, "0"))
                        Dim royalty_tax_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_tax_pros"), "0"))
                        Dim royalty_tax_amount As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "royalty_tax_amount").ToString, "0"))
                        Dim import_duty_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "import_duty_pros").ToString, "0"))
                        Dim import_duty_amount As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "import_duty_amount").ToString, "0"))
                        Dim cop_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_pd").ToString, "0"))
                        Dim cop_final_rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_final_rate_bom"), "0"))
                        Dim cop_final_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "cop_final_rate_management"), "0"))
                        Dim markup_pd As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd").ToString, "0.00"))
                        Dim markup_pd_rate_bom As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd_rate_bom").ToString, "0"))
                        Dim markup_pd_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_pd_rate_management").ToString, "0"))
                        Dim markup_rate_actual As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_rate_actual").ToString, "0"))
                        Dim markup_rate_management As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "markup_rate_management").ToString, "0"))
                        Dim usa_vs_target_pros As String = decimalSQL(myCoalesce(GV.GetRowCellValue(j, "usa_vs_target_pros").ToString, "0"))
                        Dim fg_propose_price_det_note As String = myCoalesce(GV.GetRowCellValue(j, "fg_propose_price_det_note").ToString, "")
                        Dim effective_date As String = "NULL"

                        If id_fg_propose_price_det = "0" Then 'new
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "("
                            query_detail += "'" + id_fg_propose_price + "','" + fg_propose_price_det_qty + "', '" + rate_bom + "', '" + organic_cost_bom + "', '" + rate_management + "', "
                            query_detail += "'" + organic_cost_management + "', '" + rate_pd + "', '" + msrp + "', '" + msrp_rp + "', '" + usa_inc + "', '" + price_pd + "', '" + price_target + "', "
                            query_detail += "'" + price_final + "', '" + royalty_usa_pros + "', '" + royalty_one_usd + "', '" + royalty_total + "', '" + royalty_tax_pros + "', '" + royalty_tax_amount + "', "
                            query_detail += "'" + import_duty_pros + "', '" + import_duty_amount + "', '" + cop_pd + "', '" + cop_final_rate_bom + "', '" + cop_final_rate_management + "', "
                            query_detail += "'" + id_design + "', "
                            If id_prod_demand > "0" Then
                                query_detail += "'" + id_prod_demand + "', "
                            Else
                                query_detail += "NULL, "
                            End If
                            If id_royalty_category > "0" Then
                                query_detail += "'" + id_royalty_category + "', "
                            Else
                                query_detail += "NULL, "
                            End If
                            query_detail += "'" + markup_pd + "', '" + markup_pd_rate_bom + "' , '" + markup_pd_rate_management + "', '" + markup_rate_actual + "', '" + markup_rate_management + "', '" + usa_vs_target_pros + "', '" + fg_propose_price_det_note + "', " + effective_date + " "
                            query_detail += ")"
                            jum_ins_j = jum_ins_j + 1
                        Else 'update
                            If jum_edit_j > 0 Then
                                query_edit += "; "
                            End If

                            query_edit += "UPDATE tb_fg_propose_price_det SET "
                            query_edit += "id_fg_propose_price = '" + id_fg_propose_price + "',fg_propose_price_det_qty='" + fg_propose_price_det_qty + "', "
                            query_edit += "rate_bom='" + rate_bom + "', organic_cost_bom='" + organic_cost_bom + "', rate_management='" + rate_management + "', "
                            query_edit += "organic_cost_management='" + rate_bom + "', rate_pd='" + rate_pd + "', msrp='" + msrp + "', msrp_rp='" + msrp_rp + "', usa_inc='" + usa_inc + "', "
                            query_edit += "price_pd='" + price_pd + "', price_target='" + price_target + "', "
                            query_edit += "price_final='" + price_final + "', royalty_usa_pros='" + royalty_usa_pros + "', royalty_one_usd='" + royalty_one_usd + "', "
                            query_edit += "royalty_total='" + royalty_total + "', royalty_tax_pros='" + royalty_tax_pros + "', royalty_tax_amount='" + royalty_tax_amount + "', "
                            query_edit += "import_duty_pros='" + import_duty_pros + "', import_duty_amount='" + import_duty_amount + "', cop_pd='" + cop_pd + "', "
                            query_edit += "cop_final_rate_bom='" + cop_final_rate_bom + "', cop_final_rate_management='" + cop_final_rate_management + "', id_design='" + id_design + "', "
                            If id_prod_demand > "0" Then
                                query_edit += "id_prod_demand='" + id_prod_demand + "', "
                            Else
                                query_edit += "id_prod_demand = NULL, "
                            End If
                            If id_royalty_category > "0" Then
                                query_edit += "id_royalty_category='" + id_royalty_category + "', "
                            Else
                                query_edit += "id_royalty_category=NULL, "
                            End If
                            query_edit += "markup_pd='" + markup_pd + "', markup_pd_rate_bom='" + markup_pd_rate_bom + "' , markup_pd_rate_management='" + markup_pd_rate_management + "', markup_rate_actual='" + markup_rate_actual + "', markup_rate_management='" + markup_rate_management + "', usa_vs_target_pros='" + usa_vs_target_pros + "', fg_propose_price_det_note='" + fg_propose_price_det_note + "', effective_date=" + effective_date + " "
                            query_edit += "WHERE id_fg_propose_price_det = '" + id_fg_propose_price_det + "' "
                            jum_edit_j += 1
                            id_fg_propose_price_det_list.Remove(id_fg_propose_price_det)
                        End If
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If
                    If jum_edit_j > 0 Then
                        execute_non_query(query_edit, True, "", "", "", "")
                    End If

                    'delete sisa
                    Dim jum_del_d As Integer = 0
                    Dim query_del As String = ""
                    For d As Integer = 0 To (id_fg_propose_price_det_list.Count - 1)
                        Try
                            If jum_del_d > 0 Then
                                query_del += "; "
                            End If
                            query_del += "DELETE FROM tb_fg_propose_price_det WHERE id_fg_propose_price_det='" + id_fg_propose_price_det_list(d) + "' "
                            jum_del_d += 1
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    Next
                    If jum_del_d > 0 Then
                        execute_non_query(query_del, True, "", "", "", "")
                    End If

                    infoCustom("Propose Price No: " + fg_propose_price_number + " has been sucessfully updated.")
                    action = "upd"
                    id_fg_propose_price_det_list.Clear()
                    actionLoad()
                    FormFGProposePrice.viewPropose()
                    FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id_fg_propose_price)
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click




    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_fg_propose_price
        FormReportMark.report_mark_type = "70"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_fg_propose_price
        FormDocumentUpload.report_mark_type = "70"
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

    Private Sub BtnAddLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddLocal.Click
        Cursor = Cursors.WaitCursor
        'FormProdDemandLineList.id_season_par = SLESeason.EditValue.ToString
        FormProdDemandLineList.id_pop_up = "1"
        FormProdDemandLineList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteLocal.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            If action = "ins" Then
                Try
                    GVItemListLocal.DeleteSelectedRows()
                    GCItemListLocal.RefreshDataSource()
                    GVItemListLocal.RefreshData()
                    check_but_loc()
                Catch ex As Exception
                    errorDelete()
                End Try
            ElseIf action = "upd" Then
                Dim id_ As String = GVItemListLocal.GetFocusedRowCellValue("id_fg_propose_price_det").ToString
                Dim query_del_upd As String = "DELETE FROM tb_fg_propose_price_det WHERE id_fg_propose_price_det = '" + id_ + "' "
                Try
                    execute_non_query(query_del_upd, True, "", "", "", "")
                    id_fg_propose_price_det_list.Clear()
                    viewDetail()
                    check_but_loc()
                Catch ex As Exception
                    errorDelete()
                    Close()
                End Try
            End If
            Cursor = Cursors.Default
        End If
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

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If LESource.EditValue.ToString = id_code_fg_source_import Then
            Cursor = Cursors.WaitCursor
            ReportFGProposePrice.id_fg_propose_price = id_fg_propose_price
            ReportFGProposePrice.dt = GCItemListImport.DataSource
            ReportFGProposePrice.is_import = True
            Dim Report As New ReportFGProposePrice()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemListImport.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GridView1)

            'Parse val
            Report.LabelCreated.Text = DEForm.Text
            Report.LabelDivision.Text = LESampleDivision.Text
            Report.LabelNote.Text = MENote.Text
            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelSeason.Text = SLESeason.Text
            Report.LabelSource.Text = LESource.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        ElseIf LESource.EditValue.ToString = id_code_fg_source_local Then
            Cursor = Cursors.WaitCursor
            ReportFGProposePrice.id_fg_propose_price = id_fg_propose_price
            ReportFGProposePrice.dt = GCItemListLocal.DataSource
            ReportFGProposePrice.is_import = False
            Dim Report As New ReportFGProposePrice()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemListLocal.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GridView1)

            'Parse val
            Report.LabelCreated.Text = DEForm.Text
            Report.LabelDivision.Text = LESampleDivision.Text
            Report.LabelNote.Text = MENote.Text
            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelSeason.Text = SLESeason.Text
            Report.LabelSource.Text = LESource.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            viewDetail()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LESampleDivision_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESampleDivision.EditValueChanged
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            viewDetail()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListLocal_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVItemListLocal.PopupMenuShowing
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 And LESource.EditValue.ToString = id_code_fg_source_local Then
            view.FocusedRowHandle = hitInfo.RowHandle
            vmenu.Show(view.GridControl, e.Point)
        End If
    End Sub

    Private Sub GVItemListImport_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVItemListImport.PopupMenuShowing
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 And LESource.EditValue.ToString = id_code_fg_source_import Then
            view.FocusedRowHandle = hitInfo.RowHandle
            vmenu.Show(view.GridControl, e.Point)
        End If
    End Sub
End Class