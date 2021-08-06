﻿Public Class FormMasterDesignCOPPD
    Public id_comp_contact As String = "-1"
    Public id_comp As String = "-1"
    Public id_design As String = "-1"
    '
    Public is_insert_cool_storage As String = get_opt_prod_field("is_insert_cool_storage_ecop")

    Dim id_season As String = "-1"
    Dim is_sni_enabled As String = get_opt_prod_field("is_enable_sni")

    '
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignCOPPD_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_cool_storage()
        Dim q As String = "SELECT id_cool_storage,cool_storage FROM tb_lookup_cool_storage"
        viewSearchLookupQuery(SLECoolStorage, q, "id_cool_storage", "cool_storage", "id_cool_storage")
    End Sub

    Sub load_coo()
        Dim q As String = "SELECT id_country,country FROM tb_m_country"
        viewSearchLookupQuery(SLECOO, q, "id_country", "country", "id_country")
    End Sub

    Sub load_form()
        load_coo()
        view_currency_grid()
        load_cool_storage()

        If is_insert_cool_storage = "1" Then
            LStorage.Visible = True
            SLECoolStorage.Visible = True
        Else
            LStorage.Visible = False
            SLECoolStorage.Visible = False
        End If

        If is_sni_enabled = "1" Then
            GridColumnAdditional.OptionsColumn.ReadOnly = True
            GridColumnAdditional.OptionsColumn.AllowEdit = False
            GridColumnAdditional.OptionsColumn.AllowFocus = False
        End If

        TEEcop.EditValue = 0.00
        TEKurs.EditValue = 1.0
        TEAdditionalCost.EditValue = 0.00

        view_currency(LECurrency)
        TEVendor.Focus()
        '
        Dim qv As String = "SELECT cc.`id_comp` AS id_comp_pd,cc.`id_comp_contact` AS prod_order_cop_pd_vendor,c.comp_number AS comp_number_pd,c.comp_name AS comp_name_pd,d.prod_order_cop_kurs_pd,d.cop_pd_note,d.coo
,d.prod_order_cop_pd_addcost,d.prod_order_cop_pd,d.is_cold_storage,d.prod_order_cop_pd_curr
FROM tb_m_design d
LEFT JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=d.`aging_design`
LEFT JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE d.id_design='" & id_design & "'"
        Dim dtv As DataTable = execute_query(qv, -1, True, "", "", "", "")
        If dtv.Rows.Count > 0 Then
            id_season = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")

            id_comp = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_comp_pd").ToString
            id_comp_contact = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_vendor").ToString
            TEVendor.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_number_pd").ToString
            TEVendorName.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_name_pd").ToString
            TEKurs.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_kurs_pd")
            MEECOPNote.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("cop_pd_note").ToString
            SLECOO.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("coo").ToString
            '
            TEEcop.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd") - FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")
            TEAdditionalCost.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")
            SLECoolStorage.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("is_cold_storage").ToString
            '
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_curr").ToString)
            LECurrency.Visible = False
        Else
            warningCustom("Design not found")
            Close()
        End If
        '
        'id_season = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")

        'id_comp = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_comp_pd").ToString
        'id_comp_contact = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_vendor").ToString
        'TEVendor.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_number_pd").ToString
        'TEVendorName.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("comp_name_pd").ToString
        'TEKurs.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_kurs_pd")
        'MEECOPNote.Text = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("cop_pd_note").ToString
        'SLECOO.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("coo").ToString
        ''
        'TEEcop.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd") - FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")
        'TEAdditionalCost.EditValue = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("prod_order_cop_pd_addcost")

        load_det_current()

        If TEEcop.EditValue > 0 Then
            BLock.Text = "Reset"
            BUpdateCOP.Visible = False
            '
            GCDraft.Visible = False
            TEEcop.Visible = True
            LECOP.Visible = True
            TEAdditionalCost.Visible = True
            LAdditional.Visible = True
        Else
            BLock.Text = "Lock"
            BUpdateCOP.Visible = True

            'draft
            GCDraft.Visible = True
            TEEcop.Visible = False
            LECOP.Visible = False
            TEAdditionalCost.Visible = False
            LAdditional.Visible = False

            TEDraftECOP.EditValue = GVCOPCurrent.Columns("after_kurs").SummaryItem.SummaryValue
            TEDraftECOPAdditional.EditValue = GVCOPCurrent.Columns("additional").SummaryItem.SummaryValue
        End If
        '
        Dim query As String = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        If data.Rows.Count > 0 Then
            warningCustom("PD already created, COP already locked.")
            '
            BUpdateVendor.Visible = True
            XTPUpdateCOP.PageVisible = False
        Else
            'check if target cost already input
            Dim target_ok As Boolean = True

            If get_use_target_cost() = "1" Then
                Dim query_target As String = "SELECT dsg.id_fg_line_plan,(fg_lp.`target_price`/fg_lp.`mark_up`) AS target_cost
FROM tb_m_design dsg
INNER JOIN tb_fg_line_plan fg_lp ON fg_lp.`id_fg_line_plan`=dsg.`id_fg_line_plan` 
WHERE dsg.id_design='" & id_design & "'"
                Dim plan_dt As DataTable = execute_query(query_target, -1, True, "", "", "", "")
                If plan_dt.Rows.Count > 0 Then
                    If plan_dt.Rows(0)("target_cost") = 0 Then
                        target_ok = False
                    Else
                        TETargetCost.EditValue = plan_dt.Rows(0)("target_cost")
                        target_ok = True
                    End If
                Else
                    target_ok = False
                End If
            End If
            '
            If target_ok = True Then
                BUpdateVendor.Visible = False
                XTPUpdateCOP.PageVisible = True
            Else
                warningCustom("Target cost belum terdaftar, silahkan hubungi merchandise.")
                '
                BUpdateVendor.Visible = False
                XTPUpdateCOP.PageVisible = False
            End If
        End If
    End Sub

    Private Sub FormMasterDesignCOPPD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Function get_use_target_cost()
        'look season if use target cost

        Dim is_use_target_cost As String = "2"
        Dim qst As String = "SELECT is_use_target_cost FROM tb_season WHERE id_season='" & id_season & "'"

        is_use_target_cost = execute_query(qst, 0, True, "", "", "", "")

        Return is_use_target_cost
    End Function

    Sub load_det_current()
        Dim query As String = "SELECT description,id_currency,kurs,before_kurs,additional FROM tb_m_design_cop WHERE is_active='1' AND is_production_dept=1 AND id_design='" & id_design & "'"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCOPCurrent.DataSource = dt
        GVCOPComponent.BestFitColumns()
    End Sub

    Private Sub view_currency_grid()
        Try
            Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency WHERE is_active_cop='1'"
            viewSearchLookupRepositoryQuery(RISLE, query, 0, "currency", "id_currency")
            viewSearchLookupRepositoryQuery(RISLEComp, query, 0, "currency", "id_currency")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TEVendor_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
            query += " where cc.is_default=1 and (c.id_comp_cat='1' OR c.id_comp_cat='8') AND c.comp_number='" + TEVendor.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TEVendor.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "68"
                FormPopUpContact.id_cat = 1
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TEVendor.Text + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_comp_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                TEVendor.Text = data.Rows(0)("comp_number").ToString
                '
                LECurrency.Focus()
            End If
        End If
    End Sub

    Private Sub LECurrency_KeyDown(sender As Object, e As KeyEventArgs) Handles LECurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEKurs.Focus()
        End If
    End Sub

    Private Sub TEKurs_KeyDown(sender As Object, e As KeyEventArgs) Handles TEKurs.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEEcop.Focus()
        End If
    End Sub

    '    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
    '        'If id_comp = "-1" Or id_comp = "" Then
    '        'stopCustom("Please select vendor first")
    '        'Else
    '        Dim id_season As Integer = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_season")
    '        Dim is_more_than_limit As Boolean = False

    '        'check limit
    '        If get_use_target_cost() = "1" Then
    '            Dim limit As Decimal = 0.00
    '            Dim target_cost As Decimal = TETargetCost.EditValue
    '            Dim ecop As Decimal = TEEcop.EditValue
    '            '
    '            limit = Decimal.Parse(get_opt_prod_field("ecop_limit_upper_percent"))

    '            If ecop > (target_cost * ((100 + limit) / 100)) Then
    '                is_more_than_limit = True
    '            End If
    '        End If

    '        If is_more_than_limit = True Then
    '            warningCustom("Estimasti Cost melewati batas target cost. " & vbNewLine & "Untuk melanjutkan, silahkan negosiasi dengan vendor atau koordinasikan dengan Merchandise dan Design")
    '        Else
    '            Dim query As String = ""
    '            'check 
    '            query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
    'INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
    'WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
    '            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '            If data.Rows.Count > 0 Then
    '                warningCustom("PD already created, COP already locked.")
    '            Else
    '                Dim id_c As String = ""
    '                If id_comp = "-1" Or id_comp = "" Then
    '                    id_c = "NULL"
    '                Else
    '                    id_c = "'" & id_comp_contact & "'"
    '                End If
    '                query = String.Format("UPDATE tb_m_design SET prod_order_cop_pd='{1}',prod_order_cop_pd_addcost='{5}',prod_order_cop_kurs_pd='{2}',prod_order_cop_pd_vendor={3},prod_order_cop_pd_curr='{4}' WHERE id_design='{0}'", id_design, decimalSQL((TEEcop.EditValue + TEAdditionalCost.EditValue).ToString), decimalSQL(TEKurs.EditValue.ToString), id_c, LECurrency.EditValue.ToString, decimalSQL(TEAdditionalCost.EditValue.ToString))
    '                execute_non_query(query, True, "", "", "", "")

    '                If is_insert_cool_storage = "1" Then
    '                    query = "UPDATE tb_m_design SET is_cold_storage='" & SLECoolStorage.EditValue.ToString & "' WHERE id_design='" & SLECoolStorage.EditValue.ToString & "'"
    '                    execute_non_query(query, True, "", "", "", "")
    '                End If

    '                infoCustom("ECOP entry success.")

    '                'send email
    '                'Try
    '                '    Dim nm As New ClassSendEmail
    '                '    nm.par1 = id_design
    '                '    nm.report_mark_type = "267"
    '                '    nm.send_email()
    '                'Catch ex As Exception
    '                '    execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send COP PD id_design = " & id_design & "')", -1, True, "", "", "", "")
    '                'End Try

    '                FormMasterDesignCOP.view_design()
    '                FormMasterDesignCOP.BGVDesign.FocusedRowHandle = find_row_as_is(FormMasterDesignCOP.BGVDesign, "id_design", id_design)
    '                Close()
    '            End If
    '        End If
    '        'End If
    '    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "68"
        FormPopUpContact.id_cat = "1,8"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BUpdateVendor_Click(sender As Object, e As EventArgs) Handles BUpdateVendor.Click
        'check cop propose if any
        Dim query_cek As String = "SELECT * FROM `tb_design_cop_propose_det` cpd 
INNER JOIN `tb_design_cop_propose` cp ON cp.id_design_cop_propose=cpd.id_design_cop_propose AND NOT (cp.id_report_status='6' OR cp.id_report_status='5')
WHERE cpd.id_design='" & id_design & "'"
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count > 0 Then
            'ada pengajuan masih blm proses
            warningCustom("Cant update vendor, another COP Propose in process.")
        Else
            If id_comp = "-1" Or id_comp = "" Then
                stopCustom("Please select vendor first")
            Else
                Dim query As String = ""
                query = String.Format("UPDATE tb_m_design SET prod_order_cop_pd_vendor='{1}' WHERE id_design='{0}'", id_design, id_comp_contact)
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Update vendor success.")
                FormMasterDesignCOP.view_design()
                FormMasterDesignCOP.BGVDesign.FocusedRowHandle = find_row_as_is(FormMasterDesignCOP.BGVDesign, "id_design", id_design)
            End If
        End If
    End Sub

    Private Sub BHistoryCOP_Click(sender As Object, e As EventArgs) Handles BHistoryCOP.Click
        FormMasterDesignCOPHistory.id_source = get_id_from_design(id_design, "5")
        FormMasterDesignCOPHistory.id_class = get_id_from_design(id_design, "30")
        FormMasterDesignCOPHistory.ShowDialog()
    End Sub

    Function get_id_from_design(ByVal id_design As String, ByVal id_code As String)
        Dim id As String = "0"
        Dim query As String = "SELECT dsgc.id_code_detail FROM tb_m_design_code dsgc
INNER JOIN tb_m_code_detail cd ON dsgc.`id_code_detail`=cd.`id_code_detail` AND cd.`id_code`='" & id_code & "' AND dsgc.`id_design`='" & id_design & "' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            id = data.Rows(0)("id_code_detail").ToString
        End If
        Return id
    End Function

    Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged

    End Sub

    Private Sub XTCCOPPD_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCOPPD.SelectedPageChanged
        If XTCCOPPD.SelectedTabPageIndex = 1 Then
            'check kurs first
            Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
            Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

            If Not data_kurs.Rows.Count > 0 Then
                warningCustom("Get kurs error.")
                TETodayKurs.EditValue = 0.00
            Else
                TETodayKurs.EditValue = data_kurs.Rows(0)("kurs_trans") + data_kurs.Rows(0)("fixed_floating")
            End If
            '
            load_det_input()
            show_but()
        End If
    End Sub

    Sub add_row()
        Dim newRow As DataRow = (TryCast(GCCOPComponent.DataSource, DataTable)).NewRow()
        newRow("description") = ""
        newRow("id_currency") = 1
        newRow("kurs") = TETodayKurs.EditValue
        newRow("before_kurs") = 0.00
        newRow("additional") = 0.00

        TryCast(GCCOPComponent.DataSource, DataTable).Rows.Add(newRow)
        GCCOPComponent.RefreshDataSource()
        show_but()
    End Sub

    Sub show_but()
        If GVCOPComponent.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
    End Sub

    Sub load_det_input()
        Dim query As String = "SELECT description,id_currency," & decimalSQL(TETodayKurs.EditValue.ToString) & " AS kurs,before_kurs,additional FROM tb_m_design_cop WHERE is_active='1' AND is_production_dept=1 AND id_design='" & id_design & "'"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCOPComponent.DataSource = dt
        GVCOPComponent.BestFitColumns()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        GVCOPComponent.DeleteSelectedRows()
        show_but()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        add_row()
        show_but()
    End Sub

    Private Sub BUpdateCOP_Click(sender As Object, e As EventArgs) Handles BUpdateCOP.Click
        Dim is_more_than_limit As Boolean = False

        'check limit
        If get_use_target_cost() = "1" Then
            Dim limit As Decimal = 0.00
            Dim target_cost As Decimal = TETargetCost.EditValue
            Dim ecop As Decimal = GVCOPComponent.Columns("sub_tot").SummaryItem.SummaryValue
            '
            limit = Decimal.Parse(get_opt_prod_field("ecop_limit_upper_percent"))

            If ecop > (target_cost * ((100 + limit) / 100)) Then
                is_more_than_limit = True
            End If
        End If

        If is_more_than_limit = True Then
            warningCustom("Estimasti Cost melewati batas target cost. " & vbNewLine & "Untuk melanjutkan, silahkan negosiasi dengan vendor atau koordinasikan dengan Merchandise dan Design")
        Else
            Dim query As String = ""
            'check 
            query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                warningCustom("PD already created, COP already locked.")
            ElseIf GVCOPComponent.RowCount <= 0 Then
                warningCustom("Please input COP component.")
            Else
                Dim curr As String = "1"

                For i = 0 To GVCOPComponent.RowCount - 1
                    If GVCOPComponent.GetRowCellValue(i, "id_currency").ToString = "2" Then
                        curr = "2"
                    End If
                Next

                Dim id_c As String = ""
                If id_comp = "-1" Or id_comp = "" Then
                    id_c = "NULL"
                Else
                    id_c = "'" & id_comp_contact & "'"
                End If

                'detail first
                query = "UPDATE tb_m_design_cop SET is_active=2 WHERE id_design='" & id_design & "' AND is_production_dept=1;INSERT INTO tb_m_design_cop(id_design,description,date_created,id_currency,kurs,before_kurs,additional,is_active) VALUES"
                For i As Integer = 0 To GVCOPComponent.RowCount - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_design & "','" & addSlashes(GVCOPComponent.GetRowCellValue(i, "description").ToString) & "',NOW(),'" & GVCOPComponent.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "kurs").ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "before_kurs").ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "additional").ToString) & "',1)"
                Next

                'header
                'query += String.Format(";UPDATE tb_m_design SET prod_order_cop_pd='{1}',prod_order_cop_kurs_pd='{2}',prod_order_cop_pd_vendor={3},prod_order_cop_pd_curr='{4}',prod_order_cop_pd_addcost='{5}' WHERE id_design='{0}'", id_design, decimalSQL((cop_non_additional + additional).ToString), decimalSQL(TETodayKurs.EditValue.ToString), id_c, curr, decimalSQL(additional.ToString))
                'execute_non_query(query, True, "", "", "", "")
                '
                query += String.Format(";UPDATE tb_m_design SET prod_order_cop_kurs_pd='{1}',prod_order_cop_pd_vendor={2},prod_order_cop_pd_curr='{3}',cop_pd_note='{4}',coo='{5}' WHERE id_design='{0}'", id_design, decimalSQL(TETodayKurs.EditValue.ToString), id_c, curr, addSlashes(MEECOPNote.Text), SLECOO.EditValue.ToString)
                execute_non_query(query, True, "", "", "", "")
                '
                If is_insert_cool_storage = "1" Then
                    query = "UPDATE tb_m_design SET is_cold_storage='" & SLECoolStorage.EditValue.ToString & "' WHERE id_design='" & SLECoolStorage.EditValue.ToString & "'"
                    execute_non_query(query, True, "", "", "", "")
                End If

                'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("ECOP updated. You want to send notification mail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                'If confirm = Windows.Forms.DialogResult.Yes Then
                '    'send email
                '    Try
                '        Dim nm As New ClassSendEmail
                '        nm.par1 = id_design
                '        nm.report_mark_type = "267"
                '        nm.send_email()
                '    Catch ex As Exception
                '        execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send COP PD id_design = " & id_design & "')", -1, True, "", "", "", "")
                '    End Try
                'End If

                FormMasterDesignCOP.view_design()
                FormMasterDesignCOP.BGVDesign.FocusedRowHandle = find_row_as_is(FormMasterDesignCOP.BGVDesign, "id_design", id_design)
                Close()
            End If
        End If
    End Sub

    Private Sub BTemplate_Click(sender As Object, e As EventArgs) Handles BTemplate.Click
        Dim q As String = "SELECT id_list_ecop,list_ecop FROM tb_lookup_list_ecop"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        For i = 0 To dt.Rows.Count - 1
            Dim newRow As DataRow = (TryCast(GCCOPComponent.DataSource, DataTable)).NewRow()
            newRow("description") = dt.Rows(i)("list_ecop").ToString
            newRow("id_currency") = 1
            newRow("kurs") = TETodayKurs.EditValue
            newRow("before_kurs") = 1.0
            newRow("additional") = 0.00
            TryCast(GCCOPComponent.DataSource, DataTable).Rows.Add(newRow)
            GCCOPComponent.RefreshDataSource()
        Next

        show_but()
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        If id_user = get_opt_prod_field("id_user_ast_mngr_prod") Or id_role_login = get_opt_prod_field("id_role_prod_manager") Then
            If BLock.Text = "Lock" Then
                If GVCOPComponent.RowCount <= 0 Then
                    warningCustom("Please input COP component.")
                Else
                    Dim cop_non_additional As Decimal = GVCOPComponent.Columns("after_kurs").SummaryItem.SummaryValue
                    Dim additional As Decimal = GVCOPComponent.Columns("additional").SummaryItem.SummaryValue

                    Dim curr As String = "1"

                    For i = 0 To GVCOPComponent.RowCount - 1
                        If GVCOPComponent.GetRowCellValue(i, "id_currency").ToString = "2" Then
                            curr = "2"
                        End If
                    Next

                    Dim id_c As String = ""
                    If id_comp = "-1" Or id_comp = "" Then
                        id_c = "NULL"
                    Else
                        id_c = "'" & id_comp_contact & "'"
                    End If

                    Dim query As String = ""
                    query = String.Format("UPDATE tb_m_design SET prod_order_cop_pd='{1}',prod_order_cop_kurs_pd='{2}',prod_order_cop_pd_vendor={3},prod_order_cop_pd_curr='{4}',prod_order_cop_pd_addcost='{5}' WHERE id_design='{0}'", id_design, decimalSQL((cop_non_additional + additional).ToString), decimalSQL(TETodayKurs.EditValue.ToString), id_c, curr, decimalSQL(additional.ToString))
                    execute_non_query(query, True, "", "", "", "")

                    query = "UPDATE 
tb_m_design dsg
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
SET pdd.prod_demand_design_estimate_price = dsg.prod_order_cop_pd,
pdd.prod_demand_design_total_cost = dsg.prod_order_cop_pd,  
pdd.additional_cost = dsg.prod_order_cop_pd_addcost,
pdd.additional_price = IF(dsg.prod_order_cop_pd_addcost>0,opt.default_add_price,0)
WHERE pd.is_pd=2 AND dsg.id_design='" & id_design & "'"

                    'check if KIDS
                    Dim is_kids As Boolean = False
                    Dim qc As String = "SELECT * FROM 
FROM tb_m_design dsg
INNER JOIN tb_m_design_code cd ON cd.`id_code_detail`=14696 AND cd.`id_design`=dsg.`id_design` AND dsg.id_design='" & id_design & "'"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    If dtc.Rows.Count > 0 Then
                        is_kids = True
                    End If

                    If is_kids And is_sni_enabled = "1" Then
                        warningCustom("ECOP PD Lock complete, waiting for SNI proposal.")
                    Else
                        'send email
                        Try
                            Dim nm As New ClassSendEmail
                            nm.par1 = id_design
                            nm.report_mark_type = "267"
                            nm.send_email()
                        Catch ex As Exception
                            execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send ECOP PD id_design = " & id_design & "')", -1, True, "", "", "", "")
                        End Try

                        warningCustom("ECOP PD Lock complete")
                    End If
                    '
                    load_form()
                End If
            ElseIf BLock.Text = "Reset" Then
                'reset
                Dim query As String = ""
                'check 
                query = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & id_design & "' AND pd.is_pd='1'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    warningCustom("PD already created, COP locked.")
                Else
                    'check udah masuk SNI PPS
                    Dim qc As String = "SELECT * FROM `tb_sni_pps_list` spl
INNER JOIN tb_sni_pps sp ON sp.id_sni_pps=spl.id_sni_pps
WHERE sp.id_report_status!=5 AND spl.id_design='" & id_design & "'"
                    Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    '
                    If dtc.Rows.Count > 0 And is_sni_enabled = "1" Then
                        'udah masuk sni pps
                        warningCustom("SNI proposal already created, COP locked")
                    Else
                        'reset
                        Dim qu As String = "UPDATE 
tb_m_design dsg
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.`id_prod_demand_design_line`
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
SET pdd.prod_demand_design_estimate_price=0,pdd.prod_demand_design_total_cost=0,pdd.additional_cost=0,pdd.additional_price=0
WHERE pd.is_pd=2 AND dsg.id_design='" & id_design & "'"
                        execute_non_query(qu, True, "", "", "", "")
                        '
                        qu = String.Format("UPDATE tb_m_design SET prod_order_cop_pd=0,prod_order_cop_pd_addcost=0 WHERE id_design='{0}'", id_design)
                        execute_non_query(qu, True, "", "", "", "")

                        'reset mail
                        Try
                            Dim nm As New ClassSendEmail
                            nm.par1 = id_design
                            nm.report_mark_type = "291"
                            nm.send_email()
                        Catch ex As Exception
                            execute_query("INSERT INTO tb_error_mail(date,description) VALUES(NOW(),'Failed send reset ECOP PD id_design = " & id_design & "')", -1, True, "", "", "", "")
                        End Try
                        '
                        warningCustom("ECOP PD Reset complete")
                        '
                        load_form()
                    End If
                End If
            End If
        Else
            stopCustom("You have no right to do this.")
        End If
    End Sub
End Class