﻿Public Class FormItemExpenseDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Public id_coa_tag As String = "1"

    Public id_awb_inv_sum As String = "-1"

    Public id_sni_pps As String = "-1"

    Private Sub FormItemExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEDateReff.EditValue = Now()
        '
        load_unit()
        '
        viewReportStatus()
        viewCCRepo()
        viewCOAPPH()
        viewCOA()
        viewCOARepo()
        viewPaymentMethod()
        load_currency()
        '
        view_repo_cat()
        view_repo_type()
        '
        actionLoad()
        '
        GridColumnPPH.UnboundExpression = "Iif([id_acc_pph] = " & get_opt_acc_field("id_acc_skbp") & ", 0, floor([pph_percent] / 100 * [amount]))"
        CEPayLater.Checked = True
        CEPayLater.Enabled = False

        If Not id_awb_inv_sum = "-1" Then
            'generate
            Dim qh As String = ""
            Dim qg As String = ""
            '
            qh = "SELECT id_type,inv_number,id_comp FROM tb_awb_inv_sum WHERE id_awb_inv_sum='" & id_awb_inv_sum & "'"
            Dim dth As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dth.Rows.Count > 0 Then
                TEInvNo.Text = dth.Rows(0)("inv_number").ToString
                id_comp = dth.Rows(0)("id_comp").ToString
                TxtCompNumber.Text = get_company_x(dth.Rows(0)("id_comp").ToString, "2")
                TxtCompName.Text = get_company_x(dth.Rows(0)("id_comp").ToString, "1")

                If dth.Rows(0)("id_type").ToString = "1" Then 'outbound
                    qg = "
SELECT coa.id_acc,det.id_store,SUM(det.amount_final) AS amount_final
FROM (
(SELECT '' AS no,d.`id_del_manifest`,'' AS id_inbound_awb,dis.sub_district,d.id_comp,IF(d.`is_ol_shop`=1,cg.id_cc,store.id_comp) AS id_store,IF(d.`is_ol_shop`=1,cg.comp_group,store.comp_number) AS comp_number,IF(d.`is_ol_shop`=1,cg.description,store.comp_name) AS comp_name
,d.`awbill_inv_no`,id.awb_no AS `awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
,d.`cargo_rate`
,odm.created_date AS pickup_date
,COUNT(dd.`id_del_manifest_det`) AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
INNER JOIN tb_del_manifest_det dd ON id.id_del_manifest=dd.id_del_manifest
INNER JOIN `tb_del_manifest` d ON dd.`id_del_manifest`=d.`id_del_manifest`
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district AND d.`id_report_status`=6
INNER JOIN tb_m_comp store ON store.id_comp=id_store_offline 
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=d.id_comp_group
INNER JOIN tb_odm_sc_det odmd ON odmd.id_del_manifest=d.`id_del_manifest`
INNER JOIN tb_odm_sc odm ON odm.id_odm_sc=odmd.id_odm_sc
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "' AND NOT ISNULL(id.id_del_manifest)
GROUP BY d.`id_del_manifest`)
UNION ALL
(SELECT '' AS no,'' AS `id_del_manifest`,'' AS id_inbound_awb,'' AS sub_district,'' AS id_comp,id.id_comp AS id_store,'' AS comp_number,'' AS comp_name
,'' AS `awbill_inv_no`,id.awb_no AS `awbill_no`,'' AS `rec_by_store_date`,'' AS `rec_by_store_person`
,0 AS `cargo_rate`
,'' AS pickup_date
,1 AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "' AND ISNULL(id.id_del_manifest) AND ISNULL(id.id_inbound_awb))
)det
INNER JOIN `tb_coa_map_departement` coa ON coa.`type`=8 AND coa.`id_departement`=6
GROUP BY det.id_store"
                ElseIf dth.Rows(0)("id_type").ToString = "2" Then 'inbound
                    qg = "
SELECT coa.id_acc,det.id_store,SUM(det.amount_final) AS amount_final
FROM (
(SELECT '' AS `no`,'' AS `id_del_manifest`,dd.id_inbound_awb,dis.sub_district,d.id_comp,store.id_comp AS id_store,store.comp_number AS comp_number,store.comp_name AS comp_name
,d.`awb_inv_number` AS awbill_inv_no,id.awb_no AS `awbill_no`,d.`created_date` AS rec_by_store_date,emp.employee_name AS `rec_by_store_person`
,rate.`cargo_rate`
,rn.date_return_note AS pickup_date
,COUNT(dd.`id_inbound_koli`) AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
INNER JOIN tb_inbound_koli dd ON dd.`id_inbound_awb`=id.`id_inbound_awb`
INNER JOIN `tb_inbound_awb` d ON dd.`id_inbound_awb`=d.`id_inbound_awb`
INNER JOIN tb_3pl_rate rate ON rate.id_3pl_rate=d.id_3pl_rate
INNER JOIN tb_m_sub_district dis ON dis.id_sub_district=rate.id_sub_district
INNER JOIN tb_m_user usr ON usr.id_user=d.`created_by`
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN 
(
	SELECT st.id_inbound_awb,st.id_comp,c.`comp_number`,c.`comp_name`
	FROM `tb_inbound_store` st
	INNER JOIN tb_m_comp c ON c.id_comp=st.`id_comp`
	GROUP BY id_inbound_awb
)store ON store.id_inbound_awb=d.id_inbound_awb 
INNER JOIN
(
	SELECT rn.`id_inbound_awb`,rn.`date_return_note`
	FROM tb_return_note rn 
	GROUP BY rn.`id_inbound_awb`
)rn ON rn.`id_inbound_awb`=d.id_inbound_awb 
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "'
GROUP BY d.`id_inbound_awb`)
UNION ALL
(SELECT '' AS no,'' AS `id_del_manifest`,'' AS id_inbound_awb,'' AS sub_district,'' AS id_comp,id.id_comp AS id_store,'' AS comp_number,'' AS comp_name
,'' AS `awbill_inv_no`,id.awb_no AS `awbill_no`,'' AS `rec_by_store_date`,'' AS `rec_by_store_person`
,0 AS `cargo_rate`
,'' AS pickup_date
,1 AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "' AND ISNULL(id.id_del_manifest) AND ISNULL(id.id_inbound_awb))
)det
INNER JOIN `tb_coa_map_departement` coa ON coa.`type`=8 AND coa.`id_departement`=6
GROUP BY det.id_store"
                ElseIf dth.Rows(0)("id_type").ToString = "4" Then 'return online store
                    qg = "SELECT coa.id_acc,det.id_store,SUM(det.amount_final) AS amount_final
FROM (
(SELECT '' AS `no`,'' AS `id_del_manifest`,'' AS id_inbound_awb,d.id_awbill,dis.sub_district,d.id_cargo AS id_comp,IF(store.`id_commerce_type`=2,cg.comp_group,store.comp_number) AS comp_number,IF(store.`id_commerce_type`=2,cg.description,store.comp_name) AS comp_name,ncc.id_comp AS id_store
,d.`awbill_inv_no`,id.awb_no AS `awbill_no`,d.`rec_by_store_date`,d.`rec_by_store_person`
,d.`cargo_rate`
,d.awbill_date AS pickup_date
,1 AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
INNER JOIN `tb_wh_awbill` d ON id.`id_awbill`=d.`id_awbill`
LEFT JOIN tb_m_sub_district dis ON dis.id_sub_district=d.id_sub_district 
INNER JOIN tb_m_comp store ON store.id_comp=d.id_store 
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=store.id_comp_group
INNER JOIN tb_m_comp_contact ncc ON ncc.id_comp_contact=cg.id_store_contact_normal 
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "' AND NOT ISNULL(id.id_awbill)
GROUP BY d.`id_awbill`)
UNION ALL
(SELECT '' AS no,'' AS `id_del_manifest`,'' AS id_inbound_awb,'' AS id_awbill,'' AS sub_district,'' AS id_comp,id.id_comp AS id_store,'' AS comp_number,'' AS comp_name
,'' AS `awbill_inv_no`,id.awb_no AS `awbill_no`,'' AS `rec_by_store_date`,'' AS `rec_by_store_person`
,0 AS `cargo_rate`
,'' AS pickup_date
,1 AS collie
,id.`berat_wh` AS `c_weight`,id.`amount_wh` AS `c_tot_price`,id.`berat_cargo` AS `a_weight`,id.`amount_cargo` AS `a_tot_price`
,id.note_wh,id.berat_final,id.amount_final
FROM tb_awb_inv_sum_det id
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "' AND ISNULL(id.id_del_manifest) AND ISNULL(id.id_inbound_awb) AND ISNULL(id.id_awbill))
)det
INNER JOIN `tb_coa_map_departement` coa ON coa.`type`=8 AND coa.`id_departement`=6
GROUP BY det.id_store"
                Else 'office
                    qg = "SELECT id.id_departement,coa.`id_acc`,1 AS id_store,SUM(id.amount_final) AS amount_final
FROM tb_awb_inv_sum_other id
INNER JOIN `tb_coa_map_departement` coa ON coa.`type`=8 AND coa.`id_departement`=id.`id_departement`
WHERE id.id_awb_inv_sum='" & id_awb_inv_sum & "'
GROUP BY id.`id_departement`"
                End If
                '
                Dim dtg As DataTable = execute_query(qg, -1, True, "", "", "", "")

                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If

                FormMain.SplashScreenManager1.SetWaitFormDescription("Generating from invoice..")

                DEDateReff.EditValue = FormItemExpensePop.DEDateReff.EditValue

                For i = 0 To dtg.Rows.Count - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing expense " & i + 1 & " of " & (dtg.Rows.Count) & "  ")

                    'insert 1 by 1
                    GVData.AddNewRow()
                    GVData.FocusedRowHandle = GVData.RowCount - 1

                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc", dtg.Rows(i)("id_acc").ToString)

                    'If dth.Rows(0)("id_type").ToString = "2" Then
                    '    '2246 acc WH id_acc
                    '    GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc", "2246")
                    'Else

                    'End If

                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_b_expense", FormItemExpensePop.SLEBudget.EditValue.ToString)
                    GVData.SetRowCellValue(GVData.RowCount - 1, "cc", dtg.Rows(i)("id_store").ToString)
                    '
                    GVData.SetRowCellValue(GVData.RowCount - 1, "description", FormItemExpensePop.TEDesc3PLInv.Text)
                    GVData.SetRowCellValue(GVData.RowCount - 1, "amount", dtg.Rows(i)("amount_final"))
                    GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", FormItemExpensePop.TEPPN3PLInv.EditValue)
                    '
                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc_pph", FormItemExpensePop.SLEPPH3PLInv.EditValue.ToString)
                    GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", FormItemExpensePop.TEPPH3PLInv.EditValue)
                    '
                    GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", dtg.Rows(i)("amount_final"))
                    GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)
                    GVData.SetRowCellValue(GVData.RowCount - 1, "is_lock", "yes")
                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_report", "")
                    GVData.SetRowCellValue(GVData.RowCount - 1, "id_report_det", "")
                    GVData.SetRowCellValue(GVData.RowCount - 1, "report_mark_type", "")
                    GVData.SetRowCellValue(GVData.RowCount - 1, "qty", 0.00)
                    '
                Next
                FormMain.SplashScreenManager1.CloseWaitForm()
                GVData.BestFitColumns()
            End If
        End If
        '
        If Not id_sni_pps = "-1" Then
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If

            DEDateReff.EditValue = FormItemExpenseSNI.DEDateReff.EditValue

            FormMain.SplashScreenManager1.SetWaitFormDescription("Generating from invoice..")
            For i = 0 To FormItemExpenseSNI.BGVBudget.RowCount - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Processing expense " & i + 1 & " of " & (FormItemExpenseSNI.BGVBudget.RowCount) & "  ")

                GVData.AddNewRow()
                GVData.FocusedRowHandle = GVData.RowCount - 1

                GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc", "2225")

                GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_b_expense", FormItemExpenseSNI.SLEBudget.EditValue.ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "cc", "1")
                '
                GVData.SetRowCellValue(GVData.RowCount - 1, "description", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "budget_desc").ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "amount", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "r_sub_amount"))
                GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", FormItemExpenseSNI.TEPPN3PLInv.EditValue)
                '
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_acc_pph", FormItemExpenseSNI.SLEPPH3PLInv.EditValue.ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", FormItemExpenseSNI.TEPPH3PLInv.EditValue)
                '
                GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "r_sub_amount"))
                GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)
                GVData.SetRowCellValue(GVData.RowCount - 1, "is_lock", "yes")
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_report", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "id_sni_pps").ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "id_report_det", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "id_sni_pps_budget").ToString)
                GVData.SetRowCellValue(GVData.RowCount - 1, "report_mark_type", "319")
                GVData.SetRowCellValue(GVData.RowCount - 1, "qty", FormItemExpenseSNI.BGVBudget.GetRowCellValue(i, "r_qty"))
                '
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()
            GVData.BestFitColumns()
        End If
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT id_coa_tag,tag_code,tag_description FROM `tb_coa_tag`"
        'query = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
        'UNION ALL
        'SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
        'INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
        'GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
        SLEUnit.EditValue = "1"
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, q, 0, "currency", "id_currency")
    End Sub

    Sub view_repo_type()
        Dim q As String = "SELECT id_expense_type,expense_type FROM tb_lookup_expense_type"
        viewSearchLookupRepositoryQuery(RISLEType, q, 0, "expense_type", "id_expense_type")
    End Sub

    Sub viewCCRepo()
        Dim q As String = "SELECT id_comp,comp_number,comp_name FROM tb_m_comp"
        viewSearchLookupRepositoryQuery(RISLECC, q, 0, "comp_number", "id_comp")
    End Sub

    Sub view_repo_cat()
        Dim q As String = "SELECT bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
FROM tb_b_expense_opex bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'
UNION ALL
SELECT bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
FROM tb_b_expense bo
INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
WHERE bo.`year`=YEAR('" & Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") & "') AND bo.is_active='1'"
        viewSearchLookupRepositoryQuery(RISLECatExpense, q, 0, "item_cat_main", "id_b_expense")
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewCOARepo()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If

        If Not action = "ins" Then
            'update
            If check_edit_report_status(id_report_status, "157", id) And Not is_view = "1" Then
                'msh bisa edit
                query += " AND (id_acc_cat='4' OR a.id_acc IN (SELECT id_acc FROM tb_item_expense_acc)) "
            Else
                'tidak bisa edit
            End If
        Else
            query += " AND (id_acc_cat='4' OR a.id_acc IN (SELECT id_acc FROM tb_item_expense_acc)) "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
    End Sub

    Sub viewCOAPPH()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a 
INNER JOIN `tb_lookup_tax_report` tr ON tr.id_tax_report=a.id_tax_report AND tr.id_type=1
WHERE a.id_status=1 AND a.id_is_det=2 "
        If id_coa_tag = "1" Then
            query += " AND a.id_coa_type='1' "
        Else
            query += " AND a.id_coa_type='2' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RISLECOAPPH.DataSource = Nothing
        RISLECOAPPH.DataSource = data
        RISLECOAPPH.DisplayMember = "acc_description"
        RISLECOAPPH.ValueMember = "id_acc"
    End Sub

    Sub viewPaymentMethod()
        Dim query As String = "SELECT * FROM tb_lookup_payment_purchasing p
        ORDER BY p.id_payment_purchasing ASC "
        viewLookupQuery(LEPaymentMethod, query, 0, "payment_purchasing", "id_payment_purchasing")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        TxtSubTotal.EditValue = 0.00
        TxtVAT.EditValue = 0.00
        TxtTotal.EditValue = 0.00
        If action = "ins" Then
            Dim err_coa As String = ""

            'cek coa persediaan dan hutang
            Dim cond_coa As Boolean = True
            Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_vat_in 
            WHERE !ISNULL(k.id_acc) "
            Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
            If dcoa.Rows.Count <= 0 Then
                err_coa += "- COA : Vat In " + System.Environment.NewLine
                cond_coa = False
            End If

            If Not cond_coa Then
                warningCustom("Please contact Accounting Department to setup these COA : " + System.Environment.NewLine + err_coa)
                Close()
            End If

            'date
            DEDueDate.EditValue = getTimeDB()

            TEInvNo.Enabled = True

            'purc order detail
            GVData.OptionsCustomization.AllowSort = False
            SLEPayFrom.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            '
            DEDateReff.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='" & SLEUnit.EditValue.ToString & "'", 0, True, "", "", "", "")
            '
            viewDetail()
        Else
            GVData.OptionsCustomization.AllowSort = True

            Dim e As New ClassItemExpense()
            Dim query As String = e.queryMain("AND e.id_item_expense ='" + id + "' ", "1", False)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_coa_tag = data.Rows(0)("id_coa_tag").ToString
            SLEUnit.EditValue = id_coa_tag

            SLEPayFrom.EditValue = data.Rows(0)("id_acc_from").ToString
            Dim is_pay_later As String = data.Rows(0)("is_pay_later").ToString
            If is_pay_later = "1" Then
                id_comp = data.Rows(0)("id_comp").ToString
                TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
                TxtCompName.Text = data.Rows(0)("comp_name").ToString
                DEDueDate.EditValue = data.Rows(0)("due_date")
                DEDateReff.EditValue = data.Rows(0)("date_reff")
                CEPayLater.EditValue = True
            Else
                CEPayLater.EditValue = False
            End If

            TEInvNo.Text = data.Rows(0)("inv_number").ToString
            LEPaymentMethod.EditValue = data.Rows(0)("id_payment_purchasing").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            TxtSubTotal.EditValue = data.Rows(0)("sub_total")
            TxtVAT.EditValue = data.Rows(0)("vat_total")
            TxtTotal.EditValue = data.Rows(0)("total")
            TxtPaymentStatus.Text = data.Rows(0)("paid_status").ToString

            viewDetail()
            calculate()
            allow_status()
        End If
    End Sub

    Private Sub CEPayLater_CheckedChanged(sender As Object, e As EventArgs) Handles CEPayLater.CheckedChanged
        If CEPayLater.EditValue = True Then
            SLEPayFrom.Enabled = False
            BtnBrowse.Enabled = True
            DEDueDate.Enabled = True
        Else
            SLEPayFrom.Enabled = True
            id_comp = "-1"
            TxtCompName.Text = ""
            TxtCompNumber.Text = ""
            BtnBrowse.Enabled = False
            DEDueDate.Enabled = False
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim q_year As String = ""
        Dim query As String = "SELECT 'no' AS is_lock,ed.id_report,ed.id_report_det,ed.report_mark_type,ed.qty,ed.id_currency,cur.currency,ed.amount_before,ed.kurs,ed.id_item_expense_det,ed.cc,c.comp_number AS cc_desc, ed.id_item_expense,ed.id_expense_type,ed.id_b_expense,bex.item_cat_main,typ.expense_type,
        ed.id_acc,pphacc.acc_description AS coa_desc_pph,a.id_acc_cat, a.acc_description AS `coa_desc`, ed.description,a.acc_name,ed.id_acc_pph,ed.pph_percent,ed.pph, "

        If action = "ins" Then
            query += "0.00 AS tax_percent,0.00 AS `amount` "
        ElseIf action = "upd" Then
            query += "ed.tax_percent,ed.amount "
        End If

        If action = "ins" Then
            q_year = " WHERE bo.`year`=YEAR(NOW()) AND bo.is_active='1' "
        End If

        query += "FROM tb_item_expense_det ed
        INNER JOIN tb_item_expense e ON e.id_item_expense=ed.id_item_expense
        LEFT JOIN tb_a_acc pphacc ON pphacc.id_acc = ed.id_acc_pph
        INNER JOIN tb_a_acc a ON a.id_acc = ed.id_acc
        INNER JOIN tb_lookup_expense_type typ ON typ.id_expense_type=ed.id_expense_type
        LEFT JOIN tb_m_comp c ON ed.cc=c.id_comp
        INNER JOIN tb_lookup_currency cur ON cur.id_currency=ed.id_currency
        INNER JOIN 
        (
	        SELECT bo.`year`,bo.`id_b_expense_opex` AS id_b_expense,icm.`id_item_cat_main`,icm.`item_cat_main`,icm.`id_expense_type`
	        FROM tb_b_expense_opex bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        " & q_year & "
	        UNION ALL
	        SELECT bo.`year`,bo.`id_b_expense` AS id_b_expense,icm.`id_item_cat_main`,CONCAT('[',dep.departement,']',icm.`item_cat_main`) AS item_cat_main,icm.`id_expense_type`
	        FROM tb_b_expense bo
	        INNER JOIN tb_item_cat_main icm ON icm.`id_item_cat_main`=bo.`id_item_cat_main`
	        INNER JOIN tb_m_departement dep ON dep.id_departement=bo.id_departement
	        " & q_year & "
        ) bex ON bex.id_b_expense=ed.id_b_expense AND ed.id_expense_type=bex.id_expense_type AND bex.year=YEAR(e.date_reff)
        WHERE ed.id_item_expense=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data

        GridColumnNo.MaxWidth = 0
        GridColumnCurrView.MaxWidth = 0
        GridColumnBefKurs.MaxWidth = 0
        GridColumnKurs.MaxWidth = 0
        GridColumnAmount.MaxWidth = 0
        GridColumnTaxPercent.MaxWidth = 0
        GridColumnTaxValue.MaxWidth = 0
        GridColumnPPHPercent.MaxWidth = 0
        GridColumnPPH.MaxWidth = 0

        GVData.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True 'pindah permintaan bu mariati
        '
        If check_edit_report_status(id_report_status, "157", id) And Not is_view = "1" Then
            'msh bisa edit
            GridColumnAccountDescription.Visible = False
            GridColumnaccount.VisibleIndex = 1
            '
            GridColumnPPHDesc.Visible = False
            GridColumnPPHCOA.VisibleIndex = 12
            '
            GridColumnCurrView.Visible = False
            GridColumnCurr.VisibleIndex = 6
            '
            GridColumnBudgetTypeDesc.Visible = False
            GridColumnBudgetType.VisibleIndex = 2
            '
            GCCCDesc.Visible = False
            GCCC.VisibleIndex = 2
            '
            GridColumnBudgetDesc.Visible = False
            GridColumnBudget.VisibleIndex = 3
        Else
            'tidak bisa edit
            GVData.OptionsBehavior.Editable = False
            '
            SLEUnit.Enabled = False
            DEDateReff.Enabled = False
            '
            SLEPayFrom.Enabled = False
            LEPaymentMethod.Enabled = False
            CEPayLater.Enabled = False
            BtnBrowse.Enabled = False
            DEDueDate.Enabled = False
            BtnSave.Visible = False
            MENote.Enabled = False
            GCData.ContextMenuStrip = Nothing
            PanelControlNav.Visible = False
            '
            GridColumnaccount.Visible = False
            GridColumnAccountDescription.VisibleIndex = 1
            '
            GridColumnPPHCOA.Visible = False
            GridColumnPPHDesc.VisibleIndex = 12
            '
            GridColumnCurr.Visible = False
            GridColumnCurrView.VisibleIndex = 6
            '
            GridColumnBudgetType.Visible = False
            GridColumnBudgetTypeDesc.VisibleIndex = 2
            '
            GCCC.Visible = False
            GCCCDesc.VisibleIndex = 2
            '
            GridColumnBudget.Visible = False
            GridColumnBudgetDesc.VisibleIndex = 3
        End If
        '
        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormItemExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_item_expense SET id_report_status=5 WHERE id_item_expense='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 157, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemExpense.viewData()
            'FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        'If id_report_status = "6" Then

        If id_report_status = "6" Then
            ReportItemExpense.is_pre = False
        Else
            ReportItemExpense.is_pre = True
        End If

        ReportItemExpense.id = id
        ReportItemExpense.dt = GCData.DataSource
        Dim Report As New ReportItemExpense()
        '
        GridColumnaccount.Visible = False
        GridColumnAccountDescription.VisibleIndex = -1
        '
        GridColumnCurr.Visible = False
        GridColumnCurrView.VisibleIndex = 6
        '
        GridColumnBudgetType.Visible = False
        GridColumnBudgetTypeDesc.VisibleIndex = -1
        '
        GCCC.Visible = False
        GCCCDesc.VisibleIndex = -1
        '
        GridColumnBudget.Visible = False
        GridColumnBudgetDesc.VisibleIndex = 2
        '
        GridColumnPPHCOA.Visible = False
        GridColumnPPHDesc.VisibleIndex = 12
        GridColumnPPHPercent.VisibleIndex = 13
        GridColumnPPH.VisibleIndex = 14
        '
        GVData.BestFitColumns()
        '
        GridColumnBudgetDesc.MinWidth = 100
        GridColumnNo.MaxWidth = 30
        GridColumnCurrView.MaxWidth = 30
        GridColumnBefKurs.MaxWidth = 70
        GridColumnKurs.MaxWidth = 50
        GridColumnAmount.MaxWidth = 80
        GridColumnTaxPercent.MaxWidth = 30
        GridColumnTaxValue.MaxWidth = 70
        GridColumnPPHPercent.MaxWidth = 30
        GridColumnPPH.MaxWidth = 70

        'creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        ReportStyleGridview(Report.GVData)
        Report.GVData.OptionsPrint.AllowMultilineHeaders = True
        ''============== END OF first table
        'GridColumnCurrView.VisibleIndex = -1
        'GridColumnBudgetDesc.VisibleIndex = -1
        'GridColumnBefKurs.VisibleIndex = -1
        'GridColumnKurs.VisibleIndex = -1
        'GridColumnAmount.VisibleIndex = -1
        'GridColumnTaxPercent.VisibleIndex = -1
        'GridColumnTaxValue.VisibleIndex = -1
        'GridColumnPPHDesc.VisibleIndex = 2
        'GridColumnPPHPercent.VisibleIndex = 3
        'GridColumnPPH.VisibleIndex = 4

        'GVData.BestFitColumns()

        ''creating and saving the view's layout to a new memory stream 
        'Dim str2 As System.IO.Stream
        'str2 = New System.IO.MemoryStream()
        'GVData.SaveLayoutToStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str2.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVPPH.RestoreLayoutFromStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str2.Seek(0, System.IO.SeekOrigin.Begin)
        ''Grid Detail
        'ReportStyleGridview(Report.GVPPH)

        ''============== END OF second table

        GridColumnAccountDescription.VisibleIndex = 1
        GCCCDesc.VisibleIndex = 2
        GridColumnBudgetTypeDesc.VisibleIndex = 3
        GridColumnBudgetDesc.VisibleIndex = 4
        GridColumnDescription.VisibleIndex = 5
        GridColumnCurrView.VisibleIndex = 6
        GridColumnBefKurs.VisibleIndex = 7
        GridColumnKurs.VisibleIndex = 8
        GridColumnAmount.VisibleIndex = 9
        GridColumnTaxPercent.VisibleIndex = 10
        GridColumnTaxValue.VisibleIndex = 11
        GridColumnPPHDesc.VisibleIndex = 12
        GridColumnPPHPercent.VisibleIndex = 13
        GridColumnPPH.VisibleIndex = 14

        GridColumnNo.MaxWidth = 0
        GridColumnCurrView.MaxWidth = 0
        GridColumnBefKurs.MaxWidth = 0
        GridColumnKurs.MaxWidth = 0
        GridColumnAmount.MaxWidth = 0
        GridColumnTaxPercent.MaxWidth = 0
        GridColumnTaxValue.MaxWidth = 0
        GridColumnPPHPercent.MaxWidth = 0
        GridColumnPPH.MaxWidth = 0

        GVData.BestFitColumns()

        'Parse val
        Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString
        Report.LNote.Text = MENote.Text.ToString
        Report.LabelPaymentMethod.Text = LEPaymentMethod.Text
        Report.LabelPaymentStatus.Text = TxtPaymentStatus.Text
        Report.LUnit.Text = SLEUnit.Text

        If CEPayLater.EditValue = True Then
            Report.LabelBeneficiary.Text = TxtCompName.Text
            Report.LabelDUelDate.Text = DEDueDate.Text
            '
            Report.LPayFrom.Visible = False
            Report.LpayFromTitle.Visible = False
            Report.LpayFromMark.Visible = False
        Else
            Report.LabelBeneficiary.Visible = False
            Report.LabelTitleBeneficiary.Visible = False
            Report.LabelDotBeneficiary.Visible = False
            Report.LabelDUelDate.Visible = False
            Report.LabelTitleDueDate.Visible = False
            Report.LabelDotDueDate.Visible = False
            '
            Report.LPayFrom.Visible = True
            Report.LpayFromTitle.Visible = True
            Report.LpayFromMark.Visible = True
        End If

        Report.LInvNo.Text = TEInvNo.Text
        Report.LPayFrom.Text = SLEPayFrom.Text
        Report.LabelTotalPayment.Text = TxtTotal.Text
        Report.LSay.Text = ConvertCurrencyToIndonesian(Decimal.Parse(TxtTotal.EditValue.ToString))

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        'Else
        '    print_raw_no_export(GCData)
        'End If
        '
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "157"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "157", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor

        'warning system
        Dim is_not_expense As Boolean = False
        For i As Integer = 0 To GVData.RowCount - 1
            If Not GVData.GetRowCellValue(i, "id_acc_cat").ToString = "4" Then
                is_not_expense = True
            End If
        Next

        If is_not_expense Then
            warningCustom("Warning : This expense contain COA that not expense.")
        End If

        FormReportMark.report_mark_type = "157"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        actionLoad()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVData.RefreshData()
        makeSafeGV(GVData)
        calculate()

        Dim multiple_curr As Boolean = False

        'cek empty
        Dim cond_empty As Boolean = False
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
        If GVData.RowCount > 0 Then
            cond_empty = True
        End If
        makeSafeGV(GVData)

        'cek multiple currency
        For i As Integer = 0 To GVData.RowCount - 1
            If Not GVData.GetRowCellValue(i, "id_currency").ToString = GVData.GetRowCellValue(0, "id_currency").ToString Or Not Decimal.Parse(GVData.GetRowCellValue(i, "kurs").ToString) = Decimal.Parse(GVData.GetRowCellValue(0, "kurs").ToString) Then
                multiple_curr = True
                Exit For
            End If
        Next

        If SLEPayFrom.EditValue = Nothing Then
            warningCustom("Please select pay from account")
        ElseIf cond_empty Then
            warningCustom("Please complete all detail data")
        ElseIf CEPayLater.EditValue = True And id_comp = "-1" Then
            warningCustom("Please select vendor")
        ElseIf GVData.RowCount <= 0 Then
            warningCustom("Please input detail expense")
        ElseIf TEInvNo.Text = "" Then
            warningCustom("Please input invoice number")
        ElseIf multiple_curr Then
            warningCustom("Please use only same currency with same kurs")
        ElseIf MENote.Text = "" Then
            warningCustom("Please put some note")
        ElseIf DEDateReff.Text = "" Then
            warningCustom("Please put refference date")
        Else
            GVData.ActiveFilterString = ""
            'check invoice duplicate
            Dim inv_no As String = addSlashes(TEInvNo.Text)
            Dim qc As String = "SELECT * FROM tb_item_expense WHERE id_comp='" & id_comp & "' AND inv_number='" & inv_no & "' AND id_item_expense !='" & id & "' AND id_report_status!=5"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")

            If dtc.Rows.Count > 0 Then
                warningCustom("Invoice number duplicate")
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'query main
                    If action = "ins" Then
                        Dim id_acc_from As String = SLEPayFrom.EditValue.ToString
                        Dim id_payment_purchasing As String = LEPaymentMethod.EditValue.ToString
                        Dim note As String = addSlashes(MENote.Text)
                        Dim is_pay_later As String = ""
                        Dim due_date As String = ""
                        Dim date_reff As String = ""
                        Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                        Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                        Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                        Dim is_open As String = ""
                        If CEPayLater.EditValue = True Then
                            is_pay_later = "1"
                            due_date = "'" + Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                            date_reff = "" + Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") + ""
                            is_open = "1"
                        Else
                            is_pay_later = "2"
                            id_comp = "NULL"
                            due_date = "NULL"
                            is_open = "2"
                        End If
                        Dim qm As String = "INSERT INTO tb_item_expense(id_comp,inv_number, created_date, due_date, created_by, id_acc_from, id_payment_purchasing, id_report_status, note, sub_total, vat_total, total, is_pay_later, is_open, date_reff, id_coa_tag) VALUES 
                (" + id_comp + ",'" + inv_no + "', NOW()," + due_date + ", '" + id_user + "', '" + id_acc_from + "', '" + id_payment_purchasing + "', 1, '" + note + "','" + sub_total + "', '" + vat_total + "', '" + total + "', '" + is_pay_later + "', '" + is_open + "', '" + date_reff + "','" & SLEUnit.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                        id = execute_query(qm, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id + ",157); ", True, "", "", "", "")

                        'query det
                        Dim qd As String = "INSERT INTO tb_item_expense_det(id_item_expense, id_acc,cc, description, tax_percent, tax_value, id_currency,kurs,amount_before, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph, id_report, id_report_det, report_mark_type,qty) VALUES "
                        For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                            Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                            Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                            Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                            Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                            Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                            Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                            '
                            Dim id_currency As String = GVData.GetRowCellValue(d, "id_currency").ToString
                            Dim kurs As String = decimalSQL(GVData.GetRowCellValue(d, "kurs").ToString)
                            Dim amount_before As String = decimalSQL(GVData.GetRowCellValue(d, "amount_before").ToString)
                            '
                            Dim id_acc_pph As String = "NULL"
                            Dim pph_percent As String = "0"
                            Dim pph As String = "0"
                            '
                            If GVData.GetRowCellValue(d, "pph_percent") > 0 Then
                                id_acc_pph = "'" & GVData.GetRowCellValue(d, "id_acc_pph").ToString & "'"
                                pph_percent = decimalSQL(GVData.GetRowCellValue(d, "pph_percent").ToString)
                                pph = decimalSQL(GVData.GetRowCellValue(d, "pph_value").ToString)

                            End If
                            '
                            Dim id_report_det As String = GVData.GetRowCellValue(d, "id_report_det").ToString
                            Dim id_report As String = GVData.GetRowCellValue(d, "id_report").ToString
                            Dim rmt As String = GVData.GetRowCellValue(d, "report_mark_type").ToString
                            Dim qty As String = "0"
                            qty = decimalSQL(GVData.GetRowCellValue(d, "qty").ToString)
                            '
                            If d > 0 Then
                                qd += ", "
                            End If
                            qd += "('" + id + "','" + id_acc + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + id_currency + "', '" + kurs + "', '" + amount_before + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "','" & id_report & "','" & id_report_det & "','" & rmt & "','" & qty & "') "
                        Next
                        '
                        If GVData.RowCount > 0 Then
                            execute_non_query(qd, True, "", "", "", "")
                        End If

                        'submit
                        submit_who_prepared(157, id, id_user)

                        'refresh
                        action = "upd"
                        actionLoad()
                        FormItemExpense.viewData()
                        FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
                        infoCustom("Expense : " + TxtNumber.Text.ToString + " was created successfully. Waiting for approval")
                    ElseIf action = "upd" Then
                        Dim id_acc_from As String = SLEPayFrom.EditValue.ToString
                        Dim id_payment_purchasing As String = LEPaymentMethod.EditValue.ToString
                        Dim note As String = addSlashes(MENote.Text)
                        Dim is_pay_later As String = ""
                        Dim due_date As String = ""
                        Dim date_reff As String = ""
                        Dim sub_total As String = decimalSQL(TxtSubTotal.EditValue.ToString)
                        Dim vat_total As String = decimalSQL(TxtVAT.EditValue.ToString)
                        Dim total As String = decimalSQL(TxtTotal.EditValue.ToString)
                        Dim is_open As String = ""
                        If CEPayLater.EditValue = True Then
                            is_pay_later = "1"
                            due_date = "'" + Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                            date_reff = "" + Date.Parse(DEDateReff.EditValue.ToString).ToString("yyyy-MM-dd") + ""
                            is_open = "1"
                        Else
                            is_pay_later = "2"
                            id_comp = "NULL"
                            due_date = "NULL"
                            is_open = "2"
                        End If

                        Dim qm As String = "UPDATE tb_item_expense SET id_comp=" + id_comp + ",inv_number='" + inv_no + "', created_date=NOW(), due_date=" + due_date + ", created_by='" + id_user + "', id_acc_from= '" + id_acc_from + "', id_payment_purchasing='" + id_payment_purchasing + "', note='" + note + "', sub_total='" + sub_total + "', vat_total='" + vat_total + "', total='" + total + "', is_pay_later='" + is_pay_later + "', is_open='" + is_open + "', date_reff='" + date_reff + "',id_coa_tag='" & SLEUnit.EditValue.ToString & "' WHERE id_item_expense='" & id & "' ; "
                        execute_non_query(qm, True, "", "", "", "")

                        'query det
                        Dim qd As String = ""
                        'delete first
                        qd = "DELETE FROM tb_item_expense_det WHERE id_item_expense='" & id & "'"
                        execute_non_query(qd, True, "", "", "", "")
                        'input details
                        qd = "INSERT INTO tb_item_expense_det(id_item_expense, id_acc,cc, description, tax_percent, tax_value, id_currency,kurs,amount_before, amount, id_expense_type, id_b_expense, id_acc_pph, pph_percent, pph, id_report, id_report_det, report_mark_type ,qty) VALUES "
                        For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_acc As String = GVData.GetRowCellValue(d, "id_acc").ToString
                            Dim cc As String = GVData.GetRowCellValue(d, "cc").ToString
                            Dim description As String = addSlashes(GVData.GetRowCellValue(d, "description").ToString)
                            Dim tax_percent As String = decimalSQL(GVData.GetRowCellValue(d, "tax_percent").ToString)
                            Dim tax_value As String = decimalSQL(GVData.GetRowCellValue(d, "tax_value").ToString)
                            Dim amount As String = decimalSQL(GVData.GetRowCellValue(d, "amount").ToString)
                            Dim id_expense_type As String = GVData.GetRowCellValue(d, "id_expense_type").ToString
                            Dim id_b_expense As String = GVData.GetRowCellValue(d, "id_b_expense").ToString
                            '
                            Dim id_currency As String = GVData.GetRowCellValue(d, "id_currency").ToString
                            Dim kurs As String = decimalSQL(GVData.GetRowCellValue(d, "kurs").ToString)
                            Dim amount_before As String = decimalSQL(GVData.GetRowCellValue(d, "amount_before").ToString)
                            '
                            Dim id_acc_pph As String = "NULL"
                            Dim pph_percent As String = "0"
                            Dim pph As String = "0"

                            '
                            If GVData.GetRowCellValue(d, "pph_percent") > 0 Then
                                id_acc_pph = "'" & GVData.GetRowCellValue(d, "id_acc_pph").ToString & "'"
                                pph_percent = decimalSQL(GVData.GetRowCellValue(d, "pph_percent").ToString)
                                pph = decimalSQL(GVData.GetRowCellValue(d, "pph_value").ToString)
                            End If
                            '
                            Dim id_report_det As String = GVData.GetRowCellValue(d, "id_report_det").ToString
                            Dim id_report As String = GVData.GetRowCellValue(d, "id_report").ToString
                            Dim rmt As String = GVData.GetRowCellValue(d, "report_mark_type").ToString
                            Dim qty As String = "0"
                            qty = decimalSQL(GVData.GetRowCellValue(d, "qty").ToString)
                            '
                            If d > 0 Then
                                qd += ", "
                            End If
                            qd += "('" + id + "','" + id_acc + "','" + cc + "', '" + description + "', '" + tax_percent + "', '" + tax_value + "', '" + id_currency + "', '" + kurs + "', '" + amount_before + "', '" + amount + "', '" + id_expense_type + "', '" + id_b_expense + "'," + id_acc_pph + ",'" + pph_percent + "','" + pph + "','" & id_report & "','" & id_report_det & "','" & rmt & "','" & qty & "') "
                        Next
                        '
                        If GVData.RowCount > 0 Then
                            execute_non_query(qd, True, "", "", "", "")
                        End If

                        'submit
                        'submit_who_prepared(157, id, id_user)

                        'refresh
                        action = "upd"
                        actionLoad()
                        FormItemExpense.viewData()
                        FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
                        infoCustom("Expense : " + TxtNumber.Text.ToString + " was updated successfully. Waiting for approval")
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=157 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        GVData.AddNewRow()
        GVData.FocusedRowHandle = GVData.RowCount - 1
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_expense_type", "1")
        GVData.SetRowCellValue(GVData.RowCount - 1, "cc", "1")
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "tax_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "pph_percent", 0)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "amount_before", 0)
        GVData.SetRowCellValue(GVData.RowCount - 1, "kurs", 1)
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_currency", 1)
        '
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_report", "")
        GVData.SetRowCellValue(GVData.RowCount - 1, "id_report_det", "")
        GVData.SetRowCellValue(GVData.RowCount - 1, "report_mark_type", "")
        GVData.SetRowCellValue(GVData.RowCount - 1, "qty", 0.00)
        '
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        del()
    End Sub

    Sub del()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            If GVData.GetFocusedRowCellValue("is_lock").ToString = "yes" Then
                stopCustom("Data locked")
            Else
                GVData.DeleteSelectedRows()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                calculate()
            End If
        End If
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle

        If e.Column.FieldName = "id_currency" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "amount_before" Then
            'calculate amount in RP
            'For i = 0 To GVData.RowCount - 1
            '    Try
            '        GVData.SetRowCellValue(i, "amount", If(GVData.GetRowCellValue(i, "id_currency").ToString = "1", GVData.GetRowCellValue(i, "amount_before"), GVData.GetRowCellValue(i, "amount_before") * GVData.GetRowCellValue(i, "kurs")))
            '    Catch ex As Exception
            '        Console.WriteLine(ex.ToString)
            '    End Try
            'Next

            Try
                GVData.SetRowCellValue(e.RowHandle, "amount", If(GVData.GetRowCellValue(e.RowHandle, "id_currency").ToString = "1", GVData.GetRowCellValue(e.RowHandle, "amount_before"), GVData.GetRowCellValue(e.RowHandle, "amount_before") * GVData.GetRowCellValue(e.RowHandle, "kurs")))
            Catch ex As Exception
                'Console.WriteLine(ex.ToString)
            End Try

        End If

        If e.Column.FieldName = "amount" Or e.Column.FieldName = "tax_percent" Or e.Column.FieldName = "pph_percent" Or e.Column.FieldName = "id_currency" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "amount_before" Then
            GCData.RefreshDataSource()
            GVData.RefreshData()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub calculate()
        Cursor = Cursors.WaitCursor

        Dim sub_total As Decimal = 0.00
        Try
            sub_total = GVData.Columns("amount").SummaryItem.SummaryValue
        Catch ex As Exception
            sub_total = 0.00
        End Try
        TxtSubTotal.EditValue = sub_total

        Dim vat As Decimal = 0.00
        Try
            vat = GVData.Columns("tax_value").SummaryItem.SummaryValue
        Catch ex As Exception
            vat = 0.00
        End Try
        TxtVAT.EditValue = vat

        Dim pph As Decimal = 0.00
        Try
            pph = GVData.Columns("pph_value").SummaryItem.SummaryValue
        Catch ex As Exception
            pph = 0.00
        End Try
        TEPPH.EditValue = pph

        TxtTotal.EditValue = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        del()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "90"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RISLECatExpense_Popup(sender As Object, e As EventArgs) Handles RISLECatExpense.Popup
        Dim editor As DevExpress.XtraEditors.SearchLookUpEdit = TryCast(GVData.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
        editor.Properties.View.ActiveFilterString = "[id_expense_type] ='" + GVData.GetFocusedRowCellValue("id_expense_type").ToString + "'"
    End Sub

    Private Sub XTPDraftJournal_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTPDraftJournal.SelectedPageChanged
        If XTPDraftJournal.SelectedTabPageIndex = 1 Then
            GVData.RefreshData()
            load_blank_draft()
            viewDraftJournal()
        End If
    End Sub

    Sub load_blank_draft()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVData.RowCount > 0 Then
            makeSafeGV(GVData)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT acc.acc_name,acc.acc_description
FROM tb_m_comp c 
INNER JOIN tb_a_acc acc ON acc.id_acc=" & If(id_coa_tag = "1", "c.id_acc_ap", "c.id_acc_cabang_ap") & "
WHERE c.id_comp='" + id_comp + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dh.Rows.Count > 0 Then
                'total
                If TxtSubTotal.EditValue > 0 Then
                    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowh("no") = jum_row
                    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
                    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
                    newRowh("cc") = "000"
                    newRowh("report_number") = ""
                    newRowh("note") = MENote.Text
                    newRowh("debit") = 0
                    newRowh("credit") = TxtSubTotal.EditValue + TxtVAT.EditValue - TEPPH.EditValue
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                End If

                'detil
                For i As Integer = 0 To GVData.RowCount - 1
                    'Dim found As Boolean = False
                    'Dim row_found As Integer = 0
                    'For j As Integer = 0 To GVDraft.RowCount - 1
                    '    row_found = j
                    'Next

                    'If found Then
                    '    GVDraft.SetRowCellValue(row_found, "debit", GVDraft.GetRowCellValue(row_found, "debit") + Math.Abs(GVData.GetRowCellValue(i, "valuex")))
                    'Else
                    '    jum_row += 1
                    '    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    '    newRow("no") = jum_row
                    '    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString
                    '    newRow("acc_description") = GVData.GetRowCellDisplayText(i, "id_acc").ToString
                    '    newRow("cc") = "000"
                    '    newRow("report_number") = GVData.GetRowCellValue(i, "report_number").ToString
                    '    newRow("note") = GVData.GetRowCellValue(i, "info_design").ToString
                    '    If GVData.GetRowCellValue(i, "valuex") < 0 Then
                    '        newRow("debit") = 0
                    '        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '    Else
                    '        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "valuex"))
                    '        newRow("credit") = 0
                    '    End If
                    '    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    '    GCDraft.RefreshDataSource()
                    '    GVDraft.RefreshData()
                    'End If
                    jum_row += 1
                    Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRow("no") = jum_row
                    newRow("id_acc") = GVData.GetRowCellValue(i, "id_acc").ToString

                    If id = "-1" Then
                        Try
                            newRow("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "1")
                            newRow("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc").ToString, "2")
                            newRow("cc") = GVData.GetRowCellValue(i, "cc_desc").ToString
                        Catch ex As Exception
                        End Try
                    Else
                        newRow("acc_name") = GVData.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = GVData.GetRowCellValue(i, "coa_desc").ToString
                        newRow("cc") = GVData.GetRowCellDisplayText(i, "cc").ToString
                    End If

                    newRow("report_number") = ""
                    newRow("note") = GVData.GetRowCellValue(i, "description").ToString
                    If GVData.GetRowCellValue(i, "amount") < 0 Then
                        newRow("debit") = 0
                        newRow("credit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                    Else
                        newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "amount"))
                        newRow("credit") = 0
                    End If
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                    'pph
                    If GVData.GetRowCellValue(i, "id_acc_pph").ToString = get_opt_acc_field("id_acc_skbp") And GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        'SKBP
                        'debit
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        newRowvat("credit") = 0
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)

                        'credit
                        jum_row += 1
                        newRowvat = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = (GVData.GetRowCellValue(i, "pph_percent") / 100) * GVData.GetRowCellValue(i, "amount")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    ElseIf GVData.GetRowCellValue(i, "pph_percent") > 0 Then
                        jum_row += 1
                        Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRowvat("no") = jum_row
                        Try
                            newRowvat("acc_name") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "1")
                            newRowvat("acc_description") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2")
                            newRowvat("note") = get_acc(GVData.GetRowCellValue(i, "id_acc_pph").ToString, "2") & " (PPH " & GVData.GetRowCellValue(i, "pph_percent").ToString & " %)"
                        Catch ex As Exception
                        End Try
                        newRowvat("cc") = "000"
                        newRowvat("report_number") = ""
                        newRowvat("debit") = 0
                        newRowvat("credit") = GVData.GetRowCellValue(i, "pph_value")
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    End If
                Next
                'vat
                If TxtVAT.EditValue > 0 Then
                    jum_row += 1
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = jum_row
                    If id_coa_tag = "1" Then
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in"), "2")
                    Else
                        newRowvat("acc_name") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "1")
                        newRowvat("acc_description") = get_acc(get_opt_purchasing_field("acc_coa_vat_in_cabang"), "2")
                    End If
                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("note") = MENote.Text
                    newRowvat("debit") = TxtVAT.EditValue
                    newRowvat("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                    jum_row += 1
                End If
                '
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()

                GVDraft.BestFitColumns()
            Else
                MsgBox("DP/AP account is not set")
                XTPDraftJournal.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GVData.ActiveFilterString = "[amount] Is Null OR [amount]=0 OR IsNullOrEmpty([id_acc]) OR ([pph_percent]>0 AND IsNullOrEmpty([id_acc_pph]))"
    End Sub

    Private Sub GrossUpPPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrossUpPPHToolStripMenuItem.Click
        If GVData.RowCount > 0 Then
            Try
                Dim dpp As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("amount").ToString)
                Dim pph As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("pph_percent").ToString)
                '
                Dim kurs As Decimal = Decimal.Parse(GVData.GetFocusedRowCellValue("kurs").ToString)
                '
                Dim grossup_val As Decimal = 0.00
                grossup_val = (100 / (100 - pph)) * dpp
                GVData.SetFocusedRowCellValue("amount_before", grossup_val / kurs)
                GVData.SetFocusedRowCellValue("amount", grossup_val)
                calculate()
            Catch ex As Exception
                warningCustom("Please check your input")
            End Try
        End If
    End Sub


    Private Sub RISLECurrency_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RISLECurrency.EditValueChanging
        GCData.RefreshDataSource()
        GVData.RefreshData()
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        id_coa_tag = SLEUnit.EditValue.ToString
        '
        id_comp = "-1"
        TxtCompNumber.Text = ""
        TxtCompName.Text = ""
        '
        Try
            execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='" & SLEUnit.EditValue.ToString & "'", 0, True, "", "", "", "")
        Catch ex As Exception
        End Try
        '
        viewCOA()
        viewCOARepo()
        viewCOAPPH()
    End Sub

    Private Sub DEDateReff_EditValueChanged(sender As Object, e As EventArgs) Handles DEDateReff.EditValueChanged
        Try
            view_repo_cat()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVData_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVData.RowCellClick

    End Sub

    Private Sub GVData_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles GVData.ShowingEditor
        If GVData.GetFocusedRowCellValue("is_lock").ToString = "yes" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
End Class