﻿Imports DevExpress.XtraReports.UI

Public Class FormBankWithdrawalDet
    Public report_mark_type As String = "-1"
    Public id_pay_type As String = "-1"
    Public id_payment As String = "-1"
    '
    Public is_view As String = "-1"
    Public is_book_transfer As Boolean = False
    Public is_buy_valas As Boolean = False
    '
    Public id_coa_tag As String = "1"

    Public is_print As String = "2"
    Public is_print_preview As Boolean = True

    Private Sub FormBankWithdrawalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_trf_cost()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2' AND id_acc='2946'"
        viewSearchLookupQuery(SLEACCTrfFee, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_auto_debet()
        Dim query As String = "SELECT 2 AS id,'No' AS auto_debet
UNION
SELECT 1 AS id,'Yes' AS auto_debet"
        viewSearchLookupQuery(SLEAutoDebet, query, "id", "auto_debet", "id")
    End Sub

    Sub form_load()
        '
        TETrfFee.EditValue = 0.0
        TEKurs.EditValue = 1.0
        TETotal.EditValue = 0.00
        DEDateCreated.EditValue = Now
        DEPayment.EditValue = Now
        TEPayNumber.Text = "[Auto generate]"
        TxtTag.EditValue = execute_query("SELECT CONCAT(tag_code, ' - ', tag_description) AS tag FROM tb_coa_tag WHERE id_coa_tag = " & id_coa_tag, 0, True, "", "", "", "")

        view_valas()
        load_pay_from()
        load_trf_cost()
        load_vendor()
        load_trans_type()
        load_report_type()
        load_currency()
        load_auto_debet()
        '
        If id_payment = "-1" Then
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            '
            If is_book_transfer = True Then
                FormBankWithdrawalBookTransfer.id_coa_tag = id_coa_tag
                FormBankWithdrawalBookTransfer.ShowDialog()
            ElseIf report_mark_type = "159" Then 'BBK umum
                'load header
                Try
                    '
                    SLEVendor.EditValue = FormBankWithdrawal.SLEVendorPayment.EditValue
                    SLEPayType.EditValue = "2"
                    '
                    SLEReportType.EditValue = report_mark_type
                    '
                    calculate_amount()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf report_mark_type = "139" Or report_mark_type = "202" Then 'purchasing
                'load header
                Try
                    SLEVendor.EditValue = FormBankWithdrawal.SLEVendor.EditValue
                    SLEPayType.EditValue = id_pay_type
                    TxtTag.EditValue = execute_query("SELECT CONCAT(tag_code, ' - ', tag_description) AS tag FROM tb_coa_tag WHERE id_coa_tag = " + FormBankWithdrawal.GVPOList.GetRowCellValue(0, "po_coa_tag").ToString, 0, True, "", "", "", "")
                    '
                    id_coa_tag = FormBankWithdrawal.GVPOList.GetRowCellValue(0, "po_coa_tag").ToString
                    SLEReportType.EditValue = report_mark_type
                    'load detail
                    For i As Integer = 0 To FormBankWithdrawal.GVPOList.RowCount - 1
                        'due
                        If FormBankWithdrawal.SLEPayType.EditValue.ToString = "1" Then 'DP
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()

                            newRow("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                            newRow("report_mark_type") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("id_acc") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_acc").ToString
                            newRow("acc_name") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_name").ToString
                            newRow("acc_description") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_description").ToString
                            newRow("vendor") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number").ToString
                            newRow("id_dc") = "1"
                            newRow("dc_code") = "D"
                            newRow("id_comp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_comp_default").ToString
                            newRow("comp_number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number_default").ToString
                            newRow("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                            newRow("total_pay") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("kurs") = 1
                            newRow("id_currency") = "1"
                            newRow("currency") = "Rp"
                            newRow("val_bef_kurs") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                            newRow("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                            newRow("value_view") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                            newRow("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due")
                            newRow("note") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "inv_number").ToString
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        Else 'payment
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                            newRow("report_mark_type") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("id_acc") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_acc").ToString
                            newRow("acc_name") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_name").ToString
                            newRow("acc_description") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "acc_description").ToString
                            newRow("vendor") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number").ToString
                            newRow("id_dc") = "1"
                            newRow("dc_code") = "D"
                            newRow("id_comp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_comp_default").ToString
                            newRow("comp_number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number_default").ToString
                            newRow("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                            newRow("total_pay") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("kurs") = 1
                            newRow("id_currency") = "1"
                            newRow("currency") = "Rp"
                            newRow("val_bef_kurs") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_rec") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") + FormBankWithdrawal.GVPOList.GetRowCellValue(i, "gross_up_value") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_rec") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") + FormBankWithdrawal.GVPOList.GetRowCellValue(i, "gross_up_value") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("value_view") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_rec") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") + FormBankWithdrawal.GVPOList.GetRowCellValue(i, "gross_up_value") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_rec") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") + FormBankWithdrawal.GVPOList.GetRowCellValue(i, "gross_up_value") - FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp")
                            newRow("note") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "inv_number").ToString
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If

                        'pindah ke BPL
                        'If FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total") > 0 Then
                        '    'pph
                        '    Dim newRow_pph As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        '    newRow_pph("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                        '    newRow_pph("report_mark_type") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "report_mark_type").ToString
                        '    newRow_pph("id_acc") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_account").ToString
                        '    newRow_pph("acc_name") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_acc_name").ToString
                        '    newRow_pph("acc_description") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_acc_description").ToString
                        '    newRow_pph("vendor") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number").ToString
                        '    newRow_pph("id_dc") = "2"
                        '    newRow_pph("dc_code") = "K"
                        '    newRow_pph("id_comp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_comp_default").ToString
                        '    newRow_pph("comp_number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "comp_number_default").ToString
                        '    newRow_pph("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                        '    newRow_pph("total_pay") = 0
                        '    newRow_pph("kurs") = 1
                        '    newRow_pph("id_currency") = "1"
                        '    newRow_pph("currency") = "Rp"
                        '    newRow_pph("val_bef_kurs") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                        '    newRow_pph("value") = -FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                        '    newRow_pph("value_view") = -FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                        '    newRow_pph("balance_due") = -FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_total")
                        '    newRow_pph("note") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "pph_acc_description").ToString
                        '    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow_pph)
                        'End If
                    Next
                    '
                    calculate_amount()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf report_mark_type = "157" Then 'expense
                'load header
                Dim id_comp As String = FormBankWithdrawal.SLEVendorExpense.EditValue
                Dim id_comp_contact As String = get_company_x(id_comp, 6)
                SLEVendor.EditValue = id_comp_contact
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If

                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVExpense.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_item_expense").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "acc_description").ToString
                    newRow("vendor") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = "1"
                    newRow("dc_code") = "D"
                    newRow("id_comp") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_comp_default").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "comp_number_default").ToString
                    newRow("number") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "total_dp")
                    newRow("kurs") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "kurs")
                    newRow("id_currency") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_currency").ToString
                    newRow("currency") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "currency").ToString
                    newRow("val_bef_kurs") = If(FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_currency").ToString = "1", FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance") / FormBankWithdrawal.GVExpense.GetRowCellValue(i, "kurs"))
                    newRow("value") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("value_view") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("balance_due") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("note") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "inv_number").ToString
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            ElseIf report_mark_type = "189" Then 'BPL
                If FormBankWithdrawal.XTCPO.SelectedTabPage.Name = "XTPFGPO" Then
                    'load header
                    Dim id_comp As String = FormBankWithdrawal.SLEFGPOVendor.EditValue
                    Dim id_comp_contact As String = get_company_x(id_comp, 6)

                    SLEVendor.EditValue = id_comp_contact
                    SLEReportType.EditValue = report_mark_type
                    SLEPayType.EditValue = "2"
                    SLEPayType.Visible = False
                    Dim selisih_kurs As Decimal = 0.00
                    'load detail
                    For i As Integer = 0 To FormBankWithdrawal.GVFGPO.RowCount - 1
                        'id_report, number, total, balance due
                        If FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "report_mark_type").ToString = "189" Then
                            Dim qd As String = "SELECT IF(pn.type='1','DP',IF(pn.type='2','Payment','Extra')) AS `type`,pnd.id_pn_fgpo,1 AS is_dc,'189' AS report_mark_type,GROUP_CONCAT(DISTINCT(po.prod_order_number)) AS po_number,GROUP_CONCAT(DISTINCT(pnd.inv_number)) AS inv_number
,SUM(pnd.`value`+pnd.`vat`-IF(pnd.id_currency=2,0,pnd.`pph`)) AS amount
,SUM(pnd.`vat`) AS vat
,CAST(SUM(IF(pnd.id_currency=2,(pnd.`value_bef_kurs`*pnd.`kurs`)-(pnd.`value_bef_kurs`*" & decimalSQL(FormBankWithdrawal.TEKurs.EditValue.ToString) & "),0)) AS DECIMAL(13,2)) AS amount_selisih_kurs 
,CAST(SUM(IF(pnd.id_currency=2,((pnd.`value_bef_kurs`*" & decimalSQL(FormBankWithdrawal.TEKurs.EditValue.ToString) & ")+pnd.`vat`),(pnd.`value`+pnd.`vat`))-IF(pnd.id_currency=2,0,pnd.`pph`)) AS DECIMAL(13,2)) AS amount_now_kurs 
,cur.`id_currency`,cur.`currency`,pnd.`kurs`
,acc.id_acc,acc.acc_name,acc.acc_description
,c.`comp_number`,pn.number
,0 AS total_paid,cur.currency
,SUM(pnd.`value_bef_kurs`-IF(pnd.id_currency=2,0,pnd.`pph`))-IFNULL(payment.val_bef_kurs,0) AS value_bef_kurs
,SUM(pnd.`value`+pnd.`vat`-IF(pnd.id_currency=2,0,pnd.`pph`))-IFNULL(payment.value,0) AS balance
,cf.id_comp AS `id_comp_default`, cf.comp_number AS `comp_number_default`
FROM tb_pn_fgpo_det pnd
LEFT JOIN tb_prod_order po ON po.id_prod_order=pnd.id_prod_order
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`is_open`='1' AND pn.`id_report_status`=6 AND pn.`id_pn_fgpo`='" & FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_report").ToString & "'
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pnd.`id_currency`
INNER JOIN tb_m_comp c ON c.id_comp=pn.id_comp 
INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_ap
INNER JOIN tb_m_comp cf ON cf.id_comp=1
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value`,SUM(pyd.`val_bef_kurs`) AS `val_bef_kurs` FROM `tb_pn_det` pyd
	INNER JOIN tb_pn py ON py.id_pn=pyd.id_pn AND py.id_report_status!=5 AND pyd.report_mark_type='189' AND py.is_tolakan=2
	GROUP BY pyd.id_report
)payment ON payment.id_report=pn.id_pn_fgpo
GROUP BY pnd.kurs"
                            Dim dtd As DataTable = execute_query(qd, -1, True, "", "", "", "")
                            For k = 0 To dtd.Rows.Count - 1
                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow("id_report") = dtd.Rows(k)("id_pn_fgpo").ToString
                                newRow("report_mark_type") = dtd.Rows(k)("report_mark_type").ToString
                                newRow("id_acc") = dtd.Rows(k)("id_acc").ToString
                                newRow("acc_name") = dtd.Rows(k)("acc_name").ToString
                                newRow("acc_description") = dtd.Rows(k)("acc_description").ToString
                                newRow("vendor") = dtd.Rows(k)("comp_number").ToString
                                newRow("id_dc") = dtd.Rows(k)("is_dc").ToString
                                newRow("dc_code") = If(dtd.Rows(k)("is_dc").ToString = "1", "D", "K")
                                newRow("id_comp") = dtd.Rows(k)("id_comp_default").ToString
                                newRow("comp_number") = dtd.Rows(k)("comp_number_default").ToString
                                newRow("number") = dtd.Rows(k)("number").ToString
                                newRow("total_pay") = dtd.Rows(k)("total_paid")
                                newRow("value") = dtd.Rows(k)("balance")
                                newRow("kurs") = dtd.Rows(k)("kurs")
                                newRow("id_currency") = dtd.Rows(k)("id_currency").ToString
                                newRow("currency") = dtd.Rows(k)("currency").ToString
                                newRow("val_bef_kurs") = If(dtd.Rows(k)("id_currency").ToString = "1", dtd.Rows(k)("balance"), dtd.Rows(k)("value_bef_kurs"))
                                newRow("value_view") = If(dtd.Rows(k)("balance") < 0, -dtd.Rows(k)("balance"), dtd.Rows(k)("balance"))
                                newRow("balance_due") = dtd.Rows(k)("balance")
                                newRow("note") = dtd.Rows(k)("type").ToString & " - " & dtd.Rows(k)("inv_number").ToString
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                            Next
                        ElseIf FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "report_mark_type").ToString = "221" Then 'debit note
                            Dim qd As String = "SELECT 'Debit Note' AS `type`,dnd.id_debit_note,2 AS is_dc,'221' AS report_mark_type,GROUP_CONCAT(DISTINCT(dnd.report_number)) AS po_number,GROUP_CONCAT(DISTINCT(dn.number)) AS inv_number
,-SUM(ROUND(dnd.`unit_price`*((dnd.claim_percent)/100),2)*dnd.`qty`) AS amount 
,0 AS vat
,-IF(dn.id_dn_type=4,SUM(ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) * dnd.`qty`),SUM(ROUND(dnd.`unit_price`*((dnd.claim_percent)/100),2)*dnd.`qty`)) AS value_bef_kurs
,-CAST(SUM(IF(dnd.id_currency=2,(ROUND((dnd.`claim_percent`/100)*dnd.`unit_price`,2) * dnd.`qty`)-((ROUND((dnd.`claim_percent`/100)*dnd.`unit_price_usd`,2) * dnd.`qty`)*" & decimalSQL(FormBankWithdrawal.TEKurs.EditValue.ToString) & "),0)) AS DECIMAL(13,2)) AS amount_selisih_kurs 		
,-CAST(IF(dn.id_dn_type=4,SUM(dnd.`unit_price_usd`*dnd.`qty`*((dnd.claim_percent)/100))*" & decimalSQL(FormBankWithdrawal.TEKurs.EditValue.ToString) & ",SUM(dnd.`unit_price`*dnd.`qty`*((dnd.claim_percent)/100))) AS DECIMAL(13,2)) AS amount_now_kurs
,cur.`id_currency`,cur.`currency`,dnd.`kurs`
,acc.id_acc,acc.acc_name,acc.acc_description
,c.`comp_number`,dn.number
,0 AS total_paid,cur.currency
,-SUM(ROUND(dnd.`unit_price`*((dnd.claim_percent)/100),2)*dnd.`qty`) AS total_pending
,-SUM(ROUND(dnd.`unit_price`*((dnd.claim_percent)/100),2)*dnd.`qty`) AS balance
,cf.id_comp AS `id_comp_default`, cf.comp_number AS `comp_number_default`
FROM tb_debit_note_det dnd
INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dn.`is_open`='1' AND dn.`id_report_status`=6 AND dn.`id_debit_note`='" & FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_report").ToString & "'
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=dnd.`id_currency`
INNER JOIN tb_m_comp c ON c.id_comp=dn.id_comp 
INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_ar
INNER JOIN tb_m_comp cf ON cf.id_comp=1
GROUP BY dnd.id_report"
                            Dim dtd As DataTable = execute_query(qd, -1, True, "", "", "", "")
                            For k = 0 To dtd.Rows.Count - 1
                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow("id_report") = dtd.Rows(k)("id_debit_note").ToString
                                newRow("report_mark_type") = dtd.Rows(k)("report_mark_type").ToString
                                newRow("id_acc") = dtd.Rows(k)("id_acc").ToString
                                newRow("acc_name") = dtd.Rows(k)("acc_name").ToString
                                newRow("acc_description") = dtd.Rows(k)("acc_description").ToString
                                newRow("vendor") = dtd.Rows(k)("comp_number").ToString
                                newRow("id_dc") = dtd.Rows(k)("is_dc").ToString
                                newRow("dc_code") = If(dtd.Rows(k)("is_dc").ToString = "1", "D", "K")
                                newRow("id_comp") = dtd.Rows(k)("id_comp_default").ToString
                                newRow("comp_number") = dtd.Rows(k)("comp_number_default").ToString
                                newRow("number") = dtd.Rows(k)("number").ToString
                                newRow("total_pay") = dtd.Rows(k)("total_paid")
                                newRow("value") = dtd.Rows(k)("balance")
                                newRow("kurs") = dtd.Rows(k)("kurs")
                                newRow("id_currency") = dtd.Rows(k)("id_currency").ToString
                                newRow("currency") = dtd.Rows(k)("currency").ToString
                                newRow("val_bef_kurs") = If(dtd.Rows(k)("id_currency").ToString = "1", dtd.Rows(k)("balance"), dtd.Rows(k)("value_bef_kurs"))
                                newRow("value_view") = dtd.Rows(k)("balance")
                                newRow("balance_due") = dtd.Rows(k)("balance")
                                newRow("note") = dtd.Rows(k)("type").ToString & " - " & dtd.Rows(k)("inv_number").ToString
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                            Next
                        Else
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_report") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_report").ToString
                            newRow("report_mark_type") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "report_mark_type").ToString
                            newRow("id_acc") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_acc").ToString
                            newRow("acc_name") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "acc_name").ToString
                            newRow("acc_description") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "acc_description").ToString
                            newRow("vendor") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "comp_number").ToString
                            newRow("id_dc") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "is_dc").ToString
                            newRow("dc_code") = If(FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "is_dc").ToString = "1", "D", "K")
                            newRow("id_comp") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_comp_default").ToString
                            newRow("comp_number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "comp_number_default").ToString
                            newRow("number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "number").ToString
                            newRow("total_pay") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_paid")
                            newRow("value") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance")
                            newRow("kurs") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "kurs")
                            newRow("id_currency") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_currency").ToString
                            newRow("currency") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "currency").ToString
                            newRow("val_bef_kurs") = If(FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "id_currency").ToString = "1", FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "value_bef_kurs"))
                            'newRow("value_view") = If(FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance") < 0, -FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance"))
                            newRow("value_view") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance")
                            newRow("balance_due") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "balance")
                            newRow("note") = FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "type").ToString & " - " & FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "inv_number").ToString
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If

                        If FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_paid") = 0 Then
                            selisih_kurs += FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total") - FormBankWithdrawal.GVFGPO.GetRowCellValue(i, "total_bpl")
                        End If
                    Next
                    'selisih kurs
                    If Not selisih_kurs = 0 Then
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = 0
                        newRow("report_mark_type") = 0
                        Dim q_acc As String = ""
                        If selisih_kurs > 0 Then
                            'kerugian kurs
                            q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_rugi_kurs FROM tb_opt_accounting LIMIT 1)"
                        Else
                            'keuntungan kurs
                            q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_untung_kurs FROM tb_opt_accounting LIMIT 1)"
                        End If
                        Dim dt_acc As DataTable = execute_query(q_acc, -1, True, "", "", "", "")

                        newRow("id_acc") = dt_acc.Rows(0)("id_acc").ToString
                        newRow("acc_name") = dt_acc.Rows(0)("acc_name").ToString
                        newRow("acc_description") = dt_acc.Rows(0)("acc_description").ToString
                        newRow("note") = dt_acc.Rows(0)("acc_description").ToString

                        newRow("vendor") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "comp_number").ToString

                        newRow("id_comp") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "id_comp_default").ToString
                        newRow("comp_number") = FormBankWithdrawal.GVFGPO.GetRowCellValue(0, "comp_number_default").ToString
                        newRow("total_pay") = 0
                        newRow("kurs") = 1
                        newRow("id_currency") = "1"
                        newRow("currency") = "Rp"
                        newRow("val_bef_kurs") = selisih_kurs
                        newRow("value") = selisih_kurs
                        newRow("value_view") = selisih_kurs
                        If selisih_kurs > 0 Then 'kerugian kurs
                            newRow("id_dc") = 1
                            newRow("dc_code") = "D"
                            newRow("balance_due") = selisih_kurs
                        Else 'keuntungan kurs
                            newRow("id_dc") = 2
                            newRow("dc_code") = "K"
                            newRow("balance_due") = -selisih_kurs
                        End If

                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    End If
                    calculate_amount()
                    TEKurs.EditValue = FormBankWithdrawal.TEKurs.EditValue
                ElseIf FormBankWithdrawal.XTCPO.SelectedTabPage.Name = "XTPDPKhusus" Then
                    'load header
                    Dim id_comp As String = FormBankWithdrawal.SLEDPKhususVendor.EditValue
                    Dim id_comp_contact As String = get_company_x(id_comp, 6)
                    SLEVendor.EditValue = id_comp_contact
                    SLEReportType.EditValue = report_mark_type
                    SLEPayType.Visible = False
                    Dim selisih_kurs As Decimal = 0.00
                    'load detail
                    For i As Integer = 0 To FormBankWithdrawal.GVDPKhusus.RowCount - 1
                        'id_report, number, total, balance due
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "id_report").ToString
                        newRow("report_mark_type") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "report_mark_type").ToString
                        newRow("id_acc") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "id_acc").ToString
                        newRow("acc_name") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "acc_name").ToString
                        newRow("acc_description") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "acc_description").ToString
                        newRow("vendor") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "comp_number").ToString
                        newRow("id_dc") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "is_dc").ToString
                        newRow("dc_code") = If(FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "is_dc").ToString = "1", "D", "K")
                        newRow("id_comp") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "id_comp_default").ToString
                        newRow("comp_number") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "comp_number_default").ToString
                        newRow("number") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "number").ToString
                        newRow("total_pay") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "total_paid")
                        newRow("value") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance")
                        newRow("kurs") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "kurs")
                        newRow("id_currency") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "id_currency").ToString
                        newRow("currency") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "currency").ToString
                        newRow("val_bef_kurs") = If(FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "id_currency").ToString = "1", FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "value_bef_kurs"))
                        newRow("value_view") = If(FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance") < 0, -FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance"), FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance"))
                        newRow("balance_due") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "balance")
                        newRow("note") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "type").ToString
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        If FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "total_paid") = 0 Then
                            selisih_kurs += FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "total") - FormBankWithdrawal.GVDPKhusus.GetRowCellValue(i, "total_bpl")
                        End If
                    Next
                    'selisih kurs
                    If Not selisih_kurs = 0 Then
                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = 0
                        newRow("report_mark_type") = 0
                        Dim q_acc As String = ""
                        If selisih_kurs > 0 Then
                            'kerugian kurs
                            q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_rugi_kurs FROM tb_opt_accounting LIMIT 1)"
                        Else
                            'keuntungan kurs
                            q_acc = "SELECT id_acc,acc_name,acc_description FROM tb_a_acc WHERE id_acc=(SELECT id_acc_untung_kurs FROM tb_opt_accounting LIMIT 1)"
                        End If
                        Dim dt_acc As DataTable = execute_query(q_acc, -1, True, "", "", "", "")

                        newRow("id_acc") = dt_acc.Rows(0)("id_acc").ToString
                        newRow("acc_name") = dt_acc.Rows(0)("acc_name").ToString
                        newRow("acc_description") = dt_acc.Rows(0)("acc_description").ToString
                        newRow("note") = dt_acc.Rows(0)("acc_description").ToString

                        newRow("vendor") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(0, "comp_number").ToString

                        newRow("id_comp") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(0, "id_comp_default").ToString
                        newRow("comp_number") = FormBankWithdrawal.GVDPKhusus.GetRowCellValue(0, "comp_number_default").ToString
                        newRow("total_pay") = 0
                        newRow("kurs") = 1
                        newRow("id_currency") = "1"
                        newRow("currency") = "Rp"
                        newRow("val_bef_kurs") = selisih_kurs
                        newRow("value") = selisih_kurs
                        newRow("value_view") = selisih_kurs
                        If selisih_kurs > 0 Then 'kerugian kurs
                            newRow("id_dc") = 1
                            newRow("dc_code") = "D"
                            newRow("balance_due") = selisih_kurs
                        Else 'keuntungan kurs
                            newRow("id_dc") = 2
                            newRow("dc_code") = "K"
                            newRow("balance_due") = -selisih_kurs
                        End If

                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                    End If
                    calculate_amount()
                    TEKurs.EditValue = FormBankWithdrawal.TEKursDPKhusus.EditValue
                End If
            ElseIf report_mark_type = "223" Then 'BPJS Kesehatan
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type
                'load detail
                Dim data_map As DataTable = execute_query("
                    SELECT map.id_departement, map.id_departement_sub, map.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, map.id_comp, comp.comp_number
                    FROM tb_coa_map_departement AS map
                    LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                    LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                    WHERE type = 3
                ", -1, True, "", "", "", "")

                Dim total_actual As Decimal = 0.00
                Dim total_before As Decimal = 0.00

                For i As Integer = 0 To FormBankWithdrawal.GVBPJSKesehatan.RowCount - 1
                    'id_report,number,total,balance due
                    Dim query As String = "
                        SELECT id_departement, id_departement_sub, is_store, SUM(bpjs_kesehatan_contribution) AS contribution_karyawan, SUM(bpjs_kesehatan_contribution * 100 * 0.04) AS contribution_perusahaan, periode, departement_display, SUM(ROUND(bpjs_kesehatan_contribution + (bpjs_kesehatan_contribution * 100 * 0.04))) AS total_bpjs
	                    FROM (
	                        SELECT id_departement, IF(id_departement = 17, id_departement_sub, id_departement) AS id_departement_sub, (SELECT is_store FROM tb_m_departement WHERE id_departement = tb_pay_bpjs_kesehatan_det.id_departement) AS is_store, bpjs_kesehatan_contribution, (SELECT DATE_FORMAT(periode_end, '%M %Y') FROM tb_emp_payroll WHERE id_payroll = (SELECT id_payroll FROM tb_pay_bpjs_kesehatan WHERE id_pay_bpjs_kesehatan = tb_pay_bpjs_kesehatan_det.id_pay_bpjs_kesehatan)) AS periode, (SELECT departement_display FROM tb_m_departement WHERE id_departement = tb_pay_bpjs_kesehatan_det.id_departement) AS departement_display
	                        FROM tb_pay_bpjs_kesehatan_det
	                        WHERE id_pay_bpjs_kesehatan = " + FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString + "
	                    ) AS tb
                        GROUP BY id_departement_sub
                    "

                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                    Dim total_office As Decimal = 0.00

                    For j = 0 To data.Rows.Count - 1
                        'get id_acc, acc_name, acc_description, vendor, id_comp, comp_number
                        Dim id_acc As Integer = 0
                        Dim acc_name As String = ""
                        Dim acc_description As String = ""
                        Dim vendor As String = ""
                        Dim id_comp As Integer = 0
                        Dim comp_number As String = ""
                        Dim balance As Decimal = 0.00
                        Dim note As String = "BPJS " + data.Rows(j)("periode").ToString + " (dibayar perusahaan)"

                        If data.Rows(j)("is_store").ToString = "2" Or data.Rows(j)("id_departement").ToString = "17" Then
                            total_office = total_office + data.Rows(j)("contribution_karyawan")
                        End If

                        For k = 0 To data_map.Rows.Count - 1
                            'office
                            If data.Rows(j)("is_store").ToString = "2" Then
                                If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                    id_acc = data_map.Rows(k)("id_acc")
                                    acc_name = data_map.Rows(k)("acc_name").ToString
                                    acc_description = data_map.Rows(k)("acc_description").ToString
                                    vendor = data_map.Rows(k)("vendor").ToString
                                    id_comp = data_map.Rows(k)("id_comp")
                                    comp_number = data_map.Rows(k)("comp_number").ToString
                                    balance = data.Rows(j)("contribution_perusahaan")

                                    Exit For
                                End If
                            Else
                                If data.Rows(j)("id_departement").ToString = "17" Then
                                    'store sogo
                                    If data.Rows(j)("id_departement_sub").ToString = data_map.Rows(k)("id_departement_sub").ToString Then
                                        id_acc = data_map.Rows(k)("id_acc")
                                        acc_name = data_map.Rows(k)("acc_name").ToString
                                        acc_description = data_map.Rows(k)("acc_description").ToString
                                        vendor = data_map.Rows(k)("vendor").ToString
                                        id_comp = data_map.Rows(k)("id_comp")
                                        comp_number = data_map.Rows(k)("comp_number").ToString
                                        balance = data.Rows(j)("contribution_perusahaan")

                                        Exit For
                                    End If
                                Else
                                    'store volcom
                                    If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                        id_acc = data_map.Rows(k)("id_acc")
                                        acc_name = data_map.Rows(k)("acc_name").ToString
                                        acc_description = data_map.Rows(k)("acc_description").ToString
                                        vendor = data_map.Rows(k)("vendor").ToString
                                        id_comp = data_map.Rows(k)("id_comp")
                                        comp_number = data_map.Rows(k)("comp_number").ToString
                                        balance = data.Rows(j)("total_bpjs")
                                        note = "BPJS " + data.Rows(j)("periode").ToString + " " + data.Rows(j)("departement_display").ToString

                                        Exit For
                                    End If
                                End If
                            End If
                        Next

                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                        newRow("id_report") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString
                        newRow("report_mark_type") = "223"
                        newRow("id_acc") = id_acc
                        newRow("acc_name") = acc_name
                        newRow("acc_description") = acc_description
                        newRow("vendor") = vendor
                        newRow("id_dc") = "1"
                        newRow("dc_code") = "D"
                        newRow("id_comp") = id_comp
                        newRow("comp_number") = comp_number
                        newRow("number") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "number").ToString
                        newRow("total_pay") = 0
                        newRow("value") = balance
                        newRow("kurs") = 1
                        newRow("id_currency") = "1"
                        newRow("currency") = "Rp"
                        newRow("val_bef_kurs") = balance
                        newRow("value_view") = balance
                        newRow("balance_due") = balance
                        newRow("note") = note
                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                        total_before += balance

                        If j = data.Rows.Count - 1 Then
                            If total_office > 0 Then
                                Dim query_last As String = "
                                    SELECT acc.id_acc, acc.acc_name, acc.acc_description, comp.id_comp, comp.comp_number, comp.comp_name AS vendor
                                    FROM tb_a_acc AS acc
                                    LEFT JOIN tb_m_comp AS comp ON comp.id_comp = 1
                                    WHERE acc.id_acc = 1153
                                "

                                Dim data_last As DataTable = execute_query(query_last, -1, True, "", "", "", "")

                                Dim newRow2 As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow2("id_report") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "id_pay_bpjs_kesehatan").ToString
                                newRow2("report_mark_type") = "223"
                                newRow2("id_acc") = data_last.Rows(0)("id_acc")
                                newRow2("acc_name") = data_last.Rows(0)("acc_name").ToString
                                newRow2("acc_description") = data_last.Rows(0)("acc_description").ToString
                                newRow2("vendor") = data_last.Rows(0)("vendor").ToString
                                newRow2("id_dc") = "1"
                                newRow2("dc_code") = "D"
                                newRow2("id_comp") = data_last.Rows(0)("id_comp")
                                newRow2("comp_number") = data_last.Rows(0)("comp_number").ToString
                                newRow2("number") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(i, "number").ToString
                                newRow2("total_pay") = 0
                                newRow2("value") = total_office
                                newRow2("kurs") = 1
                                newRow2("id_currency") = "1"
                                newRow2("currency") = "Rp"
                                newRow2("val_bef_kurs") = total_office
                                newRow2("value_view") = total_office
                                newRow2("balance_due") = total_office
                                newRow2("note") = "BPJS " + data.Rows(j)("periode").ToString + " (dibayar karyawan)"
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow2)

                                total_before += total_office
                            End If
                        End If

                        total_actual += data.Rows(j)("total_bpjs")
                    Next
                Next

                'selisih kerugian
                'Dim selisih As Decimal = total_actual - total_before

                'If selisih > 0 Then
                '    Dim query_s As String = "
                '        SELECT acc.id_acc, acc.acc_name, acc.acc_description, comp.id_comp, comp.comp_number, comp.comp_name AS vendor
                '        FROM tb_a_acc AS acc
                '        LEFT JOIN tb_m_comp AS comp ON comp.id_comp = 1
                '        WHERE acc.id_acc = 2968
                '    "

                '    Dim data_s As DataTable = execute_query(query_s, -1, True, "", "", "", "")

                '    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                '    newRow("id_report") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(0, "id_pay_bpjs_kesehatan").ToString
                '    newRow("report_mark_type") = "223"
                '    newRow("id_acc") = data_s.Rows(0)("id_acc")
                '    newRow("acc_name") = data_s.Rows(0)("acc_name").ToString
                '    newRow("acc_description") = data_s.Rows(0)("acc_description").ToString
                '    newRow("vendor") = data_s.Rows(0)("vendor").ToString
                '    newRow("id_dc") = "1"
                '    newRow("dc_code") = "D"
                '    newRow("id_comp") = data_s.Rows(0)("id_comp")
                '    newRow("comp_number") = data_s.Rows(0)("comp_number").ToString
                '    newRow("number") = FormBankWithdrawal.GVBPJSKesehatan.GetRowCellValue(0, "number").ToString
                '    newRow("total_pay") = 0
                '    newRow("value") = selisih
                '    newRow("kurs") = 1
                '    newRow("id_currency") = "1"
                '    newRow("currency") = "Rp"
                '    newRow("val_bef_kurs") = selisih
                '    newRow("value_view") = selisih
                '    newRow("balance_due") = selisih
                '    newRow("note") = "Pembulatan"
                '    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                'End If

                calculate_amount()
            ElseIf report_mark_type = "192" Then 'payroll
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                Dim me_note As String = ""

                Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString + ")", 0, True, "", "", "", "")

                Dim query_map As String = "
                    SELECT map.id_departement, map.id_departement_sub, map.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, map.id_comp, comp.comp_number
                    FROM tb_coa_map_departement AS map
                    LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                    LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                    WHERE type = 6
                "

                If FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_coa_tag").ToString <> "1" Then
                    TxtTag.EditValue = execute_query("SELECT CONCAT(tag_code, ' - ', tag_description) AS tag FROM tb_coa_tag WHERE id_coa_tag = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_coa_tag").ToString, 0, True, "", "", "", "")

                    query_map = "
                        SELECT NULL AS id_departement, NULL AS id_departement_sub, acc.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, tag.id_comp, comp.comp_number
                        FROM tb_coa_tag AS tag
                        LEFT JOIN tb_a_acc AS acc ON acc.id_acc = 3680
                        LEFT JOIN tb_m_comp AS comp ON tag.id_comp = comp.id_comp
                        WHERE tag.id_coa_tag = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_coa_tag").ToString + "
                    "
                End If

                Dim data_map As DataTable = execute_query(query_map, -1, True, "", "", "", "")

                Dim id_acc As Integer = data_map.Rows(0)("id_acc")
                Dim acc_name As String = data_map.Rows(0)("acc_name").ToString
                Dim acc_description As String = data_map.Rows(0)("acc_description").ToString
                Dim vendor As String = data_map.Rows(0)("vendor").ToString
                Dim id_comp As Integer = data_map.Rows(0)("id_comp")
                Dim comp_number As String = data_map.Rows(0)("comp_number").ToString
                Dim balance As Decimal = FormBankWithdrawal.GVTHR.Columns("amount").SummaryItem.SummaryValue

                Dim note As String = execute_query("SELECT CONCAT('Gaji " + If(Not FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString = "1", "staff toko ", "") + "', DATE_FORMAT(periode_end, '%M %Y')) AS note FROM tb_emp_payroll WHERE id_payroll = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString, 0, True, "", "", "", "")

                If is_thr = "1" Then
                    note = execute_query("SELECT CONCAT((SELECT payroll_type FROM tb_emp_payroll_type WHERE id_payroll_type = tb_emp_payroll.id_payroll_type), DATE_FORMAT(periode_end, ' %Y')) AS note FROM tb_emp_payroll WHERE id_payroll = " + FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString, 0, True, "", "", "", "")
                End If

                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_payroll").ToString
                newRow("report_mark_type") = "192"
                newRow("id_acc") = id_acc
                newRow("acc_name") = acc_name
                newRow("acc_description") = acc_description
                newRow("vendor") = vendor
                newRow("id_dc") = "1"
                newRow("dc_code") = "D"
                newRow("id_comp") = id_comp
                newRow("comp_number") = comp_number
                newRow("number") = FormBankWithdrawal.GVTHR.GetRowCellValue(0, "report_number").ToString
                newRow("total_pay") = 0
                newRow("value") = balance
                newRow("kurs") = 1
                newRow("id_currency") = "1"
                newRow("currency") = "Rp"
                newRow("val_bef_kurs") = balance
                newRow("value_view") = balance
                newRow("balance_due") = balance
                newRow("note") = note + " - via payroll"
                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                calculate_amount()
            ElseIf report_mark_type = "118" Then 'refund
                'load header
                Dim id_comp As String = FormBankWithdrawal.SLEVendorRefund.EditValue
                Dim id_comp_contact As String = get_company_x(id_comp, 6)
                SLEVendor.EditValue = id_comp_contact
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If
                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVRefund.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "id_sales_pos").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "acc_description").ToString
                    newRow("vendor") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = "1"
                    newRow("dc_code") = "D"
                    newRow("id_comp") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "id_comp").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "comp_number").ToString
                    newRow("number") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "sales_pos_number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "total_paid")
                    newRow("kurs") = 1
                    newRow("id_currency") = "1"
                    newRow("currency") = "Rp"
                    newRow("val_bef_kurs") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "diff")
                    newRow("value") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "diff")
                    newRow("value_view") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "diff")
                    newRow("balance_due") = FormBankWithdrawal.GVRefund.GetRowCellValue(i, "diff")
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            ElseIf report_mark_type = "66" Then 'closing cn
                'load header
                Dim id_comp_contact As String = FormBankWithdrawal.SLEStoreInvoice.EditValue
                Dim id_comp As String = get_company_contact_x(id_comp_contact, "3")
                SLEVendor.EditValue = id_comp_contact
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If

                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVCN.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "id_sales_pos").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "acc_description").ToString
                    newRow("vendor") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = "1"
                    newRow("dc_code") = "D"
                    newRow("id_comp") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "id_comp").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "comp_number").ToString
                    newRow("number") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "sales_pos_number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "total_paid")
                    newRow("kurs") = 1
                    newRow("id_currency") = "1"
                    newRow("currency") = "Rp"
                    newRow("val_bef_kurs") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "diff")
                    newRow("value") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "diff")
                    newRow("value_view") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "diff")
                    newRow("balance_due") = FormBankWithdrawal.GVCN.GetRowCellValue(i, "diff")
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()

            ElseIf report_mark_type = "247" Then 'jamsostek
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                Dim me_note As String = ""

                'load detail
                Dim data_map As DataTable = execute_query("
                    SELECT map.id_departement, map.id_departement_sub, map.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, map.id_comp, comp.comp_number, map.type
                    FROM tb_coa_map_departement AS map
                    LEFT JOIN tb_a_acc AS acc ON map.id_acc = acc.id_acc
                    LEFT JOIN tb_m_comp AS comp ON map.id_comp = comp.id_comp
                    WHERE map.type IN (5, 7)
                ", -1, True, "", "", "", "")

                For i As Integer = 0 To FormBankWithdrawal.GVJamsostek.RowCount - 1
                    Dim query As String = "CALL view_payroll_bpjstk(" + FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString + ")"

                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                    'location
                    Dim location As String = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "bpjstk").ToString

                    'period
                    Dim period As String = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "payroll_periode").ToString

                    me_note = location + " " + period

                    'total
                    Dim total_jhtjkkjkm As Integer = 0
                    Dim total_jp As Integer = 0

                    'jht, jkk, jkm
                    For j = 0 To data.Rows.Count - 1
                        If data.Rows(j)("is_store").ToString = "2" Or data.Rows(j)("id_departement").ToString = "17" Then
                            If location = data.Rows(j)("bpjs_tk_location").ToString Then
                                For k = 0 To data_map.Rows.Count - 1
                                    If data_map.Rows(k)("type").ToString = "5" Then
                                        If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                            If data.Rows(j)("id_departement").ToString = "17" Then
                                                If data.Rows(j)("id_departement_sub").ToString = data_map.Rows(k)("id_departement_sub").ToString Then
                                                    Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                                    Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                                    Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                                    Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                                    Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                                    Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                                    Dim balance As Integer = data.Rows(j)("company_contribution_1")

                                                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                                    newRow("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                                                    newRow("report_mark_type") = "247"
                                                    newRow("id_acc") = id_acc
                                                    newRow("acc_name") = acc_name
                                                    newRow("acc_description") = acc_description
                                                    newRow("vendor") = vendor
                                                    newRow("id_dc") = "1"
                                                    newRow("dc_code") = "D"
                                                    newRow("id_comp") = id_comp
                                                    newRow("comp_number") = comp_number
                                                    newRow("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                                                    newRow("total_pay") = 0
                                                    newRow("value") = balance
                                                    newRow("kurs") = 1
                                                    newRow("id_currency") = "1"
                                                    newRow("currency") = "Rp"
                                                    newRow("val_bef_kurs") = balance
                                                    newRow("value_view") = balance
                                                    newRow("balance_due") = balance
                                                    newRow("note") = "JHT, JKK, JKM " + period + " (dibayar perusahaan)"
                                                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                                    total_jhtjkkjkm += data.Rows(j)("employee_contribution_1")

                                                    Exit For
                                                End If
                                            Else
                                                Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                                Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                                Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                                Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                                Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                                Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                                Dim balance As Integer = data.Rows(j)("company_contribution_1")

                                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                                newRow("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                                                newRow("report_mark_type") = "247"
                                                newRow("id_acc") = id_acc
                                                newRow("acc_name") = acc_name
                                                newRow("acc_description") = acc_description
                                                newRow("vendor") = vendor
                                                newRow("id_dc") = "1"
                                                newRow("dc_code") = "D"
                                                newRow("id_comp") = id_comp
                                                newRow("comp_number") = comp_number
                                                newRow("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                                                newRow("total_pay") = 0
                                                newRow("value") = balance
                                                newRow("kurs") = 1
                                                newRow("id_currency") = "1"
                                                newRow("currency") = "Rp"
                                                newRow("val_bef_kurs") = balance
                                                newRow("value_view") = balance
                                                newRow("balance_due") = balance
                                                newRow("note") = "JHT, JKK, JKM " + period + " (dibayar perusahaan)"
                                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                                total_jhtjkkjkm += data.Rows(j)("employee_contribution_1")

                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next

                    'jp
                    For j = 0 To data.Rows.Count - 1
                        If data.Rows(j)("is_store").ToString = "2" Or data.Rows(j)("id_departement").ToString = "17" Then
                            If location = data.Rows(j)("bpjs_tk_location").ToString Then
                                For k = 0 To data_map.Rows.Count - 1
                                    If data_map.Rows(k)("type").ToString = "7" Then
                                        If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                            If data.Rows(j)("id_departement").ToString = "17" Then
                                                If data.Rows(j)("id_departement_sub").ToString = data_map.Rows(k)("id_departement_sub").ToString Then
                                                    Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                                    Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                                    Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                                    Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                                    Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                                    Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                                    Dim balance As Integer = data.Rows(j)("company_contribution_2")

                                                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                                    newRow("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                                                    newRow("report_mark_type") = "247"
                                                    newRow("id_acc") = id_acc
                                                    newRow("acc_name") = acc_name
                                                    newRow("acc_description") = acc_description
                                                    newRow("vendor") = vendor
                                                    newRow("id_dc") = "1"
                                                    newRow("dc_code") = "D"
                                                    newRow("id_comp") = id_comp
                                                    newRow("comp_number") = comp_number
                                                    newRow("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                                                    newRow("total_pay") = 0
                                                    newRow("value") = balance
                                                    newRow("kurs") = 1
                                                    newRow("id_currency") = "1"
                                                    newRow("currency") = "Rp"
                                                    newRow("val_bef_kurs") = balance
                                                    newRow("value_view") = balance
                                                    newRow("balance_due") = balance
                                                    newRow("note") = "J Pensiun " + period + " (dibayar perusahaan)"
                                                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                                    total_jp += data.Rows(j)("employee_contribution_2")

                                                    Exit For
                                                End If
                                            Else
                                                Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                                Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                                Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                                Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                                Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                                Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                                Dim balance As Integer = data.Rows(j)("company_contribution_2")

                                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                                newRow("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                                                newRow("report_mark_type") = "247"
                                                newRow("id_acc") = id_acc
                                                newRow("acc_name") = acc_name
                                                newRow("acc_description") = acc_description
                                                newRow("vendor") = vendor
                                                newRow("id_dc") = "1"
                                                newRow("dc_code") = "D"
                                                newRow("id_comp") = id_comp
                                                newRow("comp_number") = comp_number
                                                newRow("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                                                newRow("total_pay") = 0
                                                newRow("value") = balance
                                                newRow("kurs") = 1
                                                newRow("id_currency") = "1"
                                                newRow("currency") = "Rp"
                                                newRow("val_bef_kurs") = balance
                                                newRow("value_view") = balance
                                                newRow("balance_due") = balance
                                                newRow("note") = "J Pensiun " + period + " (dibayar perusahaan)"
                                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                                total_jp += data.Rows(j)("employee_contribution_2")

                                                Exit For
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Next

                    'store
                    For j = 0 To data.Rows.Count - 1
                        If data.Rows(j)("is_store").ToString = "1" And Not data.Rows(j)("id_departement").ToString = "17" Then
                            If location = data.Rows(j)("bpjs_tk_location").ToString Then
                                For k = 0 To data_map.Rows.Count - 1
                                    If data.Rows(j)("id_departement").ToString = data_map.Rows(k)("id_departement").ToString Then
                                        Dim id_acc As Integer = data_map.Rows(k)("id_acc")
                                        Dim acc_name As String = data_map.Rows(k)("acc_name").ToString
                                        Dim acc_description As String = data_map.Rows(k)("acc_description").ToString
                                        Dim vendor As String = data_map.Rows(k)("vendor").ToString
                                        Dim id_comp As Integer = data_map.Rows(k)("id_comp")
                                        Dim comp_number As String = data_map.Rows(k)("comp_number").ToString
                                        Dim balance As Integer = data.Rows(j)("total_contribution")

                                        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                        newRow("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                                        newRow("report_mark_type") = "247"
                                        newRow("id_acc") = id_acc
                                        newRow("acc_name") = acc_name
                                        newRow("acc_description") = acc_description
                                        newRow("vendor") = vendor
                                        newRow("id_dc") = "1"
                                        newRow("dc_code") = "D"
                                        newRow("id_comp") = id_comp
                                        newRow("comp_number") = comp_number
                                        newRow("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                                        newRow("total_pay") = 0
                                        newRow("value") = balance
                                        newRow("kurs") = 1
                                        newRow("id_currency") = "1"
                                        newRow("currency") = "Rp"
                                        newRow("val_bef_kurs") = balance
                                        newRow("value_view") = balance
                                        newRow("balance_due") = balance
                                        newRow("note") = "Jamsostek " + period
                                        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Next

                    'total jht, jkk, jkm
                    Dim acc_jp As DataTable = execute_query("Select acc.id_acc, acc.acc_name, acc.acc_description, comp.comp_name As vendor, comp.id_comp, comp.comp_number FROM tb_a_acc As acc, tb_m_comp As comp WHERE acc.id_acc = 1153 And comp.id_comp = 1", -1, True, "", "", "", "")

                    Dim id_acc_t_jk As Integer = acc_jp.Rows(0)("id_acc")
                    Dim acc_name_t_jk As String = acc_jp.Rows(0)("acc_name").ToString
                    Dim acc_description_t_jk As String = acc_jp.Rows(0)("acc_description").ToString
                    Dim vendor_t_jk As String = acc_jp.Rows(0)("vendor").ToString
                    Dim id_comp_t_jk As Integer = acc_jp.Rows(0)("id_comp")
                    Dim comp_number_t_jk As String = acc_jp.Rows(0)("comp_number").ToString
                    Dim balance_t_jk As Integer = total_jhtjkkjkm

                    Dim newRowTJk As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRowTJk("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                    newRowTJk("report_mark_type") = "247"
                    newRowTJk("id_acc") = id_acc_t_jk
                    newRowTJk("acc_name") = acc_name_t_jk
                    newRowTJk("acc_description") = acc_description_t_jk
                    newRowTJk("vendor") = vendor_t_jk
                    newRowTJk("id_dc") = "1"
                    newRowTJk("dc_code") = "D"
                    newRowTJk("id_comp") = id_comp_t_jk
                    newRowTJk("comp_number") = comp_number_t_jk
                    newRowTJk("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                    newRowTJk("total_pay") = 0
                    newRowTJk("value") = balance_t_jk
                    newRowTJk("kurs") = 1
                    newRowTJk("id_currency") = "1"
                    newRowTJk("currency") = "Rp"
                    newRowTJk("val_bef_kurs") = balance_t_jk
                    newRowTJk("value_view") = balance_t_jk
                    newRowTJk("balance_due") = balance_t_jk
                    newRowTJk("note") = "JHT, JKK, JKM " + period + " (dibayar karyawan)"
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRowTJk)

                    'total jp
                    Dim id_acc_t_jp As Integer = acc_jp.Rows(0)("id_acc")
                    Dim acc_name_t_jp As String = acc_jp.Rows(0)("acc_name").ToString
                    Dim acc_description_t_jp As String = acc_jp.Rows(0)("acc_description").ToString
                    Dim vendor_t_jp As String = acc_jp.Rows(0)("vendor").ToString
                    Dim id_comp_t_jp As Integer = acc_jp.Rows(0)("id_comp")
                    Dim comp_number_t_jp As String = acc_jp.Rows(0)("comp_number").ToString
                    Dim balance_t_jp As Integer = total_jp

                    Dim newRowTJp As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRowTJp("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                    newRowTJp("report_mark_type") = "247"
                    newRowTJp("id_acc") = id_acc_t_jp
                    newRowTJp("acc_name") = acc_name_t_jp
                    newRowTJp("acc_description") = acc_description_t_jp
                    newRowTJp("vendor") = vendor_t_jp
                    newRowTJp("id_dc") = "1"
                    newRowTJp("dc_code") = "D"
                    newRowTJp("id_comp") = id_comp_t_jp
                    newRowTJp("comp_number") = comp_number_t_jp
                    newRowTJp("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                    newRowTJp("total_pay") = 0
                    newRowTJp("value") = balance_t_jp
                    newRowTJp("kurs") = 1
                    newRowTJp("id_currency") = "1"
                    newRowTJp("currency") = "Rp"
                    newRowTJp("val_bef_kurs") = balance_t_jp
                    newRowTJp("value_view") = balance_t_jp
                    newRowTJp("balance_due") = balance_t_jp
                    newRowTJp("note") = "J Pensiun " + period + " (dibayar karyawan)"
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRowTJp)

                    'adjustment
                    Dim adjustment As String = execute_query("
                        SELECT IFNULL((SELECT total_adjustment FROM tb_emp_payroll_bpjstk_adj WHERE id_payroll = " + FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString + " AND id_bpjs_location = " + FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_bpjs_location").ToString + " LIMIT 1), 0) AS adjustment
                    ", 0, True, "", "", "", "")

                    If Not adjustment = "0" Then
                        Dim data_adj As DataTable = execute_query("
                            SELECT adj.id_acc, acc.acc_name, acc.acc_description, comp.comp_name AS vendor, adj.id_comp, comp.comp_number, IFNULL(adj.acc_adjustment, 0) AS acc_adjustment, adj.note
                            FROM tb_emp_payroll_bpjstk_adj AS adj
                            LEFT JOIN tb_a_acc AS acc ON adj.id_acc = acc.id_acc
                            LEFT JOIN tb_m_comp AS comp ON adj.id_comp = comp.id_comp
                            WHERE adj.id_payroll = " + FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString + " AND adj.id_bpjs_location = " + FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_bpjs_location").ToString + "
                        ", -1, True, "", "", "", "")

                        For k = 0 To data_adj.Rows.Count - 1
                            Dim id_acc_adj As Integer = data_adj.Rows(k)("id_acc")
                            Dim acc_name_adj As String = data_adj.Rows(k)("acc_name").ToString
                            Dim acc_description_adj As String = data_adj.Rows(k)("acc_description").ToString
                            Dim vendor_adj As String = data_adj.Rows(k)("vendor").ToString
                            Dim id_comp_adj As Integer = data_adj.Rows(k)("id_comp")
                            Dim comp_number_adj As String = data_adj.Rows(k)("comp_number").ToString
                            Dim balance_adj As Integer = data_adj.Rows(k)("acc_adjustment")
                            Dim note As String = data_adj.Rows(k)("note").ToString

                            Dim newRowAdj As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRowAdj("id_report") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "id_payroll").ToString
                            newRowAdj("report_mark_type") = "247"
                            newRowAdj("id_acc") = id_acc_adj
                            newRowAdj("acc_name") = acc_name_adj
                            newRowAdj("acc_description") = acc_description_adj
                            newRowAdj("vendor") = vendor_adj
                            newRowAdj("id_dc") = "2"
                            newRowAdj("dc_code") = If(balance_adj < 0, "K", "D")
                            newRowAdj("id_comp") = id_comp_adj
                            newRowAdj("comp_number") = comp_number_adj
                            newRowAdj("number") = FormBankWithdrawal.GVJamsostek.GetRowCellValue(i, "report_number").ToString
                            newRowAdj("total_pay") = 0
                            newRowAdj("value") = balance_adj
                            newRowAdj("kurs") = 1
                            newRowAdj("id_currency") = "1"
                            newRowAdj("currency") = "Rp"
                            newRowAdj("val_bef_kurs") = balance_adj
                            newRowAdj("value_view") = balance_adj
                            newRowAdj("balance_due") = balance_adj
                            newRowAdj("note") = note
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRowAdj)
                        Next
                    End If
                Next

                MENote.Text = me_note

                calculate_amount()
            ElseIf report_mark_type = "167" Then 'cash advance
                'load header
                SLEVendor.EditValue = 1
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                Dim me_note As String = ""

                Dim acc_jp As DataTable = execute_query("SELECT acc.id_acc, acc.acc_name, acc.acc_description, comp.comp_name As vendor, comp.id_comp, comp.comp_number FROM tb_a_acc As acc, tb_m_comp As comp WHERE acc.id_acc = 11 And comp.id_comp = 1", -1, True, "", "", "", "")

                Dim id_acc_t_jk As Integer = acc_jp.Rows(0)("id_acc")
                Dim acc_name_t_jk As String = acc_jp.Rows(0)("acc_name").ToString
                Dim acc_description_t_jk As String = acc_jp.Rows(0)("acc_description").ToString
                Dim vendor_t_jk As String = acc_jp.Rows(0)("vendor").ToString
                Dim id_comp_t_jk As Integer = acc_jp.Rows(0)("id_comp")
                Dim comp_number_t_jk As String = acc_jp.Rows(0)("comp_number").ToString

                For i = 0 To FormBankWithdrawal.GVCashAdvance.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "id_cash_advance").ToString
                    newRow("report_mark_type") = "167"
                    newRow("id_acc") = id_acc_t_jk
                    newRow("acc_name") = acc_name_t_jk
                    newRow("acc_description") = acc_description_t_jk
                    newRow("vendor") = vendor_t_jk
                    newRow("id_dc") = "1"
                    newRow("dc_code") = "D"
                    newRow("id_comp") = id_comp_t_jk
                    newRow("comp_number") = comp_number_t_jk
                    newRow("number") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "number").ToString
                    newRow("total_pay") = 0
                    newRow("value") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "expense").ToString
                    newRow("kurs") = 1
                    newRow("id_currency") = "1"
                    newRow("currency") = "Rp"
                    newRow("val_bef_kurs") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "expense").ToString
                    newRow("value_view") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "expense").ToString
                    newRow("balance_due") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "expense").ToString
                    newRow("note") = FormBankWithdrawal.GVCashAdvance.GetRowCellValue(i, "note").ToString
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next

                calculate_amount()
            ElseIf report_mark_type = "254" Then
                id_coa_tag = FormBankWithdrawal.SLEUnit.EditValue.ToString
                For i As Integer = 0 To FormBankWithdrawal.GVSales.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "id_sales_branch").ToString
                    newRow("report_mark_type") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("id_acc") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "id_acc").ToString
                    newRow("acc_name") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "acc_name").ToString
                    newRow("acc_description") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "acc_description").ToString
                    newRow("note") = Date.Parse(FormBankWithdrawal.GVSales.GetRowCellValue(i, "transaction_date").ToString).ToString("dd MMMM yyyy") & " - " & FormBankWithdrawal.GVSales.GetRowCellValue(i, "note").ToString
                    newRow("vendor") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "comp_number").ToString
                    newRow("id_dc") = If(FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount") < 0, "2", "1")
                    newRow("dc_code") = If(FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount") < 0, "K", "D")
                    newRow("id_comp") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "id_comp").ToString
                    newRow("comp_number") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "comp_number").ToString
                    newRow("number") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "number").ToString
                    newRow("total_pay") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "total_pay")
                    newRow("kurs") = 1
                    newRow("id_currency") = "1"
                    newRow("currency") = "Rp"
                    newRow("val_bef_kurs") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount")
                    newRow("value") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount")
                    newRow("value_view") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount")
                    newRow("balance_due") = FormBankWithdrawal.GVSales.GetRowCellValue(i, "amount")
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            End If
        Else
            'PCAddDel.Visible = False
            BtnAdd.Visible = False
            BtnDelete.Visible = False
            BPickDP.Visible = False
            BCompen.Visible = False
            '
            SLEACCTrfFee.ReadOnly = True
            TETrfFee.Enabled = False
            '
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEPayFrom.Enabled = False
            MENote.Enabled = False
            '
            Dim query As String = "Select * FROM tb_pn WHERE id_pn='" & id_payment & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                id_coa_tag = data.Rows(0)("id_coa_tag").ToString
                load_pay_from()
                TEPayNumber.Text = data.Rows(0)("number").ToString
                If Not data.Rows(0)("id_valas_bank").ToString = "" Then
                    SLEAkunValas.EditValue = data.Rows(0)("id_valas_bank").ToString
                End If
                TEKurs.EditValue = data.Rows(0)("kurs")
                report_mark_type = data.Rows(0)("report_mark_type").ToString
                '
                If data.Rows(0)("is_buy_valas").ToString = "1" Then
                    is_buy_valas = True
                Else
                    is_buy_valas = False
                End If
                '
                TETrfFee.EditValue = data.Rows(0)("trf_fee").ToString
                SLEACCTrfFee.EditValue = data.Rows(0)("id_acc_trf_fee").ToString
                '
                SLEAutoDebet.EditValue = data.Rows(0)("is_auto_debet").ToString
                SLEVendor.EditValue = data.Rows(0)("id_comp_contact").ToString
                SLEPayType.EditValue = data.Rows(0)("id_pay_type").ToString
                SLEReportType.EditValue = data.Rows(0)("report_mark_type").ToString
                TxtTag.EditValue = execute_query("SELECT CONCAT(tag_code, ' - ', tag_description) AS tag FROM tb_coa_tag WHERE id_coa_tag = " + data.Rows(0)("id_coa_tag").ToString, 0, True, "", "", "", "")
                If data.Rows(0)("is_book_transfer").ToString = "1" Then
                    is_book_transfer = True
                Else
                    is_book_transfer = False
                End If
                '
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                DEPayment.EditValue = data.Rows(0)("date_payment")
                DEPayment.Properties.ReadOnly = True
                SLEAutoDebet.Properties.ReadOnly = True
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_payfrom").ToString
                MENote.EditValue = data.Rows(0)("note").ToString
                '
                If data.Rows(0)("is_tolakan").ToString = "1" Then
                    BViewJurnalBUM.Visible = True
                End If
            End If
            '
            load_det()
            GridColumnPayment.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
        End If
        '
        If is_buy_valas Then
            CEPembelianValas.Visible = True
        End If
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(SLECurrency, q, 0, "currency", "id_currency")
    End Sub

    Private Sub XTCBBM_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBBK.SelectedPageChanged
        If XTCBBK.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVList.RowCount > 0 Then
            makeSafeGV(GVList)
            Dim jum_row As Integer = 0

            'total pay
            jum_row += 1
            Dim qh As String = "SELECT * FROM tb_a_acc WHERE id_acc='" + SLEPayFrom.EditValue.ToString + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowh("no") = jum_row
            newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            newRowh("acc_description") = dh.Rows(0)("acc_description").ToString
            newRowh("cc") = "000"
            newRowh("report_number") = ""
            newRowh("note") = MENote.Text
            newRowh("debit") = 0
            newRowh("credit") = TETotal.EditValue + TETrfFee.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'transfer fee
            If TETrfFee.EditValue > 0 Then
                jum_row += 1
                Dim qfee As String = "SELECT * FROM tb_a_acc WHERE id_acc='" + SLEACCTrfFee.EditValue.ToString + "' "
                Dim dfee As DataTable = execute_query(qfee, -1, True, "", "", "", "")
                Dim newRowfee As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRowfee("no") = jum_row
                newRowfee("acc_name") = dfee.Rows(0)("acc_name").ToString
                newRowfee("acc_description") = dfee.Rows(0)("acc_description").ToString
                newRowfee("cc") = "000"
                newRowfee("report_number") = ""
                newRowfee("note") = MENote.Text
                newRowfee("debit") = TETrfFee.EditValue
                newRowfee("credit") = 0
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowfee)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            End If

            'detil
            For i As Integer = 0 To GVList.RowCount - 1
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVList.GetRowCellValue(i, "acc_name").ToString
                newRow("acc_description") = GVList.GetRowCellValue(i, "acc_description").ToString
                newRow("cc") = GVList.GetRowCellValue(i, "comp_number").ToString
                newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                If GVList.GetRowCellValue(i, "id_dc").ToString = "1" Then
                    newRow("debit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                End If
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
            GVDraft.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormBankWithdrawalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If report_mark_type = "139" Or report_mark_type = "202" Then
            id_coa_tag = FormBankWithdrawal.GVPOList.GetRowCellValue(0, "po_coa_tag").ToString
        ElseIf report_mark_type = "157" Then 'expense
            id_coa_tag = FormBankWithdrawal.GVExpense.GetRowCellValue(0, "id_coa_tag").ToString
        End If

        form_load()
        '
        If is_print = "1" Then
            print(True)
        End If
    End Sub

    Sub view_valas()
        Dim query As String = "
SELECT 0 AS id_valas_bank,'No Valas' AS valas_bank
UNION ALL
SELECT id_valas_bank,valas_bank FROM tb_valas_bank
WHERE is_active=1"
        viewSearchLookupQuery(SLEAkunValas, query, "id_valas_bank", "valas_bank", "id_valas_bank")
    End Sub

    Sub load_det()
        Dim query As String = ""
        'If report_mark_type = "139" Then
        '    query = "SELECT pyd.*,po.purc_order_number as number FROM tb_payment_det pyd INNER JOIN tb_purc_order po ON po.id_purc_order=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        'ElseIf report_mark_type = "157" Then
        '    query = "SELECT pyd.*,e.number AS `number` FROM tb_payment_det pyd INNER JOIN tb_item_expense e ON e.id_item_expense=pyd.id_report WHERE pyd.id_payment='" + id_payment + "'"
        'ElseIf report_mark_type = "189" Then
        '    query = "SELECT pyd.*,po.number as number FROM tb_payment_det pyd INNER JOIN tb_pn_fgpo po ON po.id_pn_fgpo=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        'End If

        query = "SELECT ''AS `no`,pnd.id_pn_det,pnd.id_report,pnd.report_mark_type,comp.comp_number,pnd.number,pnd.vendor
,pnd.id_comp,pnd.id_acc,dc.dc_code,acc.acc_name,acc.acc_description,pnd.id_dc,pnd.total_pay,pnd.value,pnd.value AS value_view,pnd.balance_due,pnd.note
,pnd.id_currency,cur.currency,pnd.val_bef_kurs,pnd.kurs
FROM tb_pn_det pnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
INNER JOIN tb_a_acc acc ON acc.id_acc=pnd.id_acc
INNER JOIN tb_m_comp comp ON comp.id_comp=pnd.id_comp
INNER JOIN tb_lookup_dc dc ON dc.id_dc=pnd.id_dc
WHERE pnd.id_pn='" & id_payment & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        calculate_amount()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        'If report_mark_type = "157" Or report_mark_type = "159" Then 'expense

        'End If
        If id_coa_tag = "1" Then
            query += " AND id_coa_type='1' "
        Else
            query += " AND id_coa_type='2' "
        End If
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print(False)
    End Sub

    Sub print(ByVal is_close As Boolean)
        Cursor = Cursors.WaitCursor
        ReportBankWithdrawal.id_withdrawal = id_payment
        ReportBankWithdrawal.dt = GCList.DataSource
        Dim Report As New ReportBankWithdrawal()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 

        GridColumnCOA.VisibleIndex = -1
        GridColumnCCDesc.VisibleIndex = -1
        GridColumnVendor.VisibleIndex = -1
        GridColumnCurrency.VisibleIndex = -1
        GridColumnCurrencyHide.VisibleIndex = 4

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        'Grid Detail
        ReportStyleGridview(Report.GVList)
        Report.GVList.AppearancePrint.Row.Font = New Font("Segoe UI", 6.5, FontStyle.Regular)
        Report.GVList.BestFitColumns()

        GridColumnCOA.VisibleIndex = 1
        GridColumnCCDesc.VisibleIndex = 2
        GridColumnVendor.VisibleIndex = 4
        GridColumnCurrency.VisibleIndex = 9
        GridColumnCurrencyHide.VisibleIndex = -1

        'Parse val
        Dim query As String = "Select py.number,If(py.is_auto_debet=1,'- Auto Debet','') AS auto_debet,FORMAT(py.`trf_fee`,2,'id_ID') AS trf_fee,FORMAT(py.`kurs`,2,'id_ID') AS kurs,acc.acc_name as acc_payfrom_name,acc.acc_description as acc_payfrom,py.`id_report_status`,sts.report_status,emp.employee_name AS created_by, DATE_FORMAT(py.date_created,'%d %M %Y') as date_created,DATE_FORMAT(py.date_payment,'%d %M %Y') as date_payment, py.`id_pn`,FORMAT(py.`value`,2,'id_ID') as total_amount,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note
,'" & ConvertCurrencyToIndonesian(TETotal.EditValue) & "' AS tot_say, CONCAT(tag.tag_code, ' - ', tag.tag_description) AS tag
,FORMAT(SUM(IF(pyd.id_currency!=1,val_bef_kurs,0)),2,'id_ID') AS total_valas
FROM tb_pn py
INNER JOIN tb_pn_det pyd ON pyd.id_pn=py.id_pn
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_a_acc acc ON acc.id_acc=py.id_acc_payfrom
INNER JOIN tb_coa_tag tag ON py.id_coa_tag = tag.id_coa_tag
WHERE py.`id_pn`='" & id_payment & "'
GROUP BY py.id_pn"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        If Not data.Rows(0)("id_report_status").ToString = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If
        '
        If is_book_transfer Then
            Report.LBookTrf.Visible = True
        Else
            Report.LBookTrf.Visible = False
        End If
        '
        If is_buy_valas Then
            Report.LBookTrf.Visible = True
            Report.LBookTrf.Text = "Pembelian Valuta Asing"
        Else
            Report.LBookTrf.Visible = False
            Report.LBookTrf.Text = "Book Transfer"
        End If
        '
        If TEKurs.EditValue = 1 Then
            Report.LKurs.Visible = False
            Report.LkursLabel.Visible = False
            Report.LKursTitik.Visible = False
            '
            Report.LTotUSD.Visible = False
            Report.LTotUSD2.Visible = False
            Report.LTotUSDVal.Visible = False
        Else
            Report.LKurs.Visible = True
            Report.LkursLabel.Visible = True
            Report.LKursTitik.Visible = True
            '
            Report.LTotUSD.Visible = True
            Report.LTotUSD2.Visible = True
            Report.LTotUSDVal.Visible = True
        End If
        '
        If is_print_preview = True Then
            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If

        Cursor = Cursors.Default

        If is_close Then
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0

        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        TETotal.EditValue = gross_total
        '
        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        ElseIf e.Column.FieldName.ToString = "val_bef_kurs" Or e.Column.FieldName.ToString = "kurs" Then
            Dim rh As Integer = e.RowHandle
            GVList.SetRowCellValue(rh, "value_view", GVList.GetRowCellValue(rh, "kurs") * GVList.GetRowCellValue(rh, "val_bef_kurs"))
        ElseIf e.Column.FieldName.ToString = "value_view" Then
            Dim rh As Integer = e.RowHandle
            Dim val As Decimal = 0
            Dim id_dc As String = GVList.GetRowCellValue(rh, "id_dc").ToString
            If id_dc = "2" Then 'credit
                val = Math.Abs(e.Value) * -1
            Else
                val = e.Value
            End If
            GVList.SetRowCellValue(rh, "value", val)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        calculate_amount()
        'check again, paranoid
        Dim total As Decimal = 0.00
        For i As Integer = 0 To GVList.RowCount - 1
            total += GVList.GetRowCellValue(i, "value")
        Next
        '
        If Decimal.Parse(total).ToString("N2") = Decimal.Parse(TETotal.EditValue).ToString("N2") Then
            If id_payment = "-1" Then
                'cek valas tidak mencantumkan kurs
                Dim kurs_is_blank As Boolean = False
                Dim is_use_valas As Boolean = False
                Dim is_oos_valas As Boolean = False
                Dim oos_message As String = ""

                For i As Integer = 0 To GVList.RowCount - 1
                    If Not GVList.GetRowCellValue(i, "id_currency").ToString = "1" And SLEAkunValas.EditValue.ToString = "0" Then
                        kurs_is_blank = True
                    End If
                    If Not GVList.GetRowCellValue(i, "id_currency").ToString = "1" Then
                        is_use_valas = True
                    End If
                Next


                If is_use_valas And Not kurs_is_blank And Not is_buy_valas = "1" Then
                    'cek ada stok valas tidak
                    Dim id_cur_check As String = ""
                    Dim jml_valas As Decimal = 0.00
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not GVList.GetRowCellValue(i, "id_currency").ToString = "1" Then
                            id_cur_check = GVList.GetRowCellValue(i, "id_currency").ToString
                            '
                            If GVList.GetRowCellValue(i, "id_dc").ToString = "1" Then
                                jml_valas += GVList.GetRowCellValue(i, "val_bef_kurs")
                            Else
                                jml_valas -= GVList.GetRowCellValue(i, "val_bef_kurs")
                            End If
                        End If
                    Next

                    'cek di stock_valas
                    Dim qcv As String = "SELECT balance
FROM `tb_stock_valas`
WHERE id_stock_valas = (SELECT MAX(id_stock_valas) FROM `tb_stock_valas` WHERE id_valas_bank='" & SLEAkunValas.EditValue.ToString & "' AND id_currency='" & id_cur_check & "')"
                    Dim dtcv As DataTable = execute_query(qcv, -1, True, "", "", "", "")
                    If dtcv.Rows.Count > 0 Then
                        Console.WriteLine(dtcv.Rows(0)("balance").ToString & " - " & jml_valas.ToString)
                        If dtcv.Rows(0)("balance") - jml_valas < 0 Then
                            is_oos_valas = True
                            oos_message = "Stok valas hanya tersisa " & Decimal.Parse(dtcv.Rows(0)("balance").ToString).ToString("N2") & " pada " & SLEAkunValas.Text & "."
                        End If
                    Else
                        is_oos_valas = True
                        oos_message = "Stok valas tidak tersedia pada " & SLEAkunValas.Text & "."
                    End If
                End If

                'cek value 0
                Dim value_is_zero As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "value") = 0 Then
                        value_is_zero = True
                    End If
                Next

                'cek debit negatif or kredit positif
                Dim value_is_wrong As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "id_dc").ToString = "1" And GVList.GetRowCellValue(i, "value") < 0 Then 'debit negatif
                        value_is_wrong = True
                    ElseIf GVList.GetRowCellValue(i, "id_dc").ToString = "2" And GVList.GetRowCellValue(i, "value") > 0 Then 'kredit positif
                        value_is_wrong = True
                    End If
                Next

                'cek paid no exceed balance
                Dim paid_more As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "value") < 0 And GVList.GetRowCellValue(i, "balance_due") < 0 Then
                        If Math.Abs(GVList.GetRowCellValue(i, "value")) > Math.Abs(GVList.GetRowCellValue(i, "balance_due")) Then
                            paid_more = True
                        End If
                    Else
                        If GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                            paid_more = True
                        End If
                    End If
                Next

                'description is nothing
                Dim desc_blank As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "note").ToString = "" Then
                        desc_blank = True
                        Exit For
                    End If
                Next

                'cek jika beli valas ada transaksi USD pending
                'bisa overlap per tanggal 14 januari

                '                Dim using_valas_pend As Boolean = False
                '                If is_buy_valas Then
                '                    Dim qusing_valas_pend As String = "SELECT * 
                'FROM tb_pn_det pnd
                'INNER JOIN tb_pn pn ON pn.id_pn=pnd.`id_pn`
                'WHERE pn.id_report_status!=6 AND pn.`id_report_status`!=5 AND pn.`kurs`>1"
                '                    Dim dt As DataTable = execute_query(qusing_valas_pend, -1, True, "", "", "", "")
                '                    If dt.Rows.Count > 0 Then
                '                        using_valas_pend = True
                '                    End If
                '                End If

                '                'cek jika pakai valas ada pembelian USD
                '                Dim buy_valas_pend As Boolean = False
                '                If is_buy_valas Then
                '                    Dim qbuy_valas_pend As String = "SELECT * 
                'FROM tb_pn_det pnd
                'INNER JOIN tb_pn pn ON pn.id_pn=pnd.`id_pn`
                'WHERE pn.id_report_status!=6 AND pn.`id_report_status`!=5 AND pn.is_buy_valas=1"
                '                    Dim dt As DataTable = execute_query(qbuy_valas_pend, -1, True, "", "", "", "")
                '                    If dt.Rows.Count > 0 Then
                '                        buy_valas_pend = True
                '                    End If
                '                End If

                If GVList.RowCount = 0 Then
                    warningCustom("No item listed.")
                ElseIf desc_blank Then
                    warningCustom("Please fill the description.")
                ElseIf kurs_is_blank Then
                    warningCustom("Please select valas.")
                ElseIf value_is_zero = True Then
                    warningCustom("You must fill value.")
                ElseIf paid_more = True Then
                    warningCustom("You pay more than balance due.")
                ElseIf MENote.Text = "" Then
                    warningCustom("Please put some note")
                ElseIf value_is_wrong Then
                    warningCustom("Make sure debit is positive value, credit is negative value")
                    'ElseIf using_valas_pend Then
                    '    warningCustom("Please complete BBK using valas")
                    'ElseIf buy_valas_pend Then
                    '    warningCustom("Please complete BBK buying valas")
                ElseIf is_oos_valas Then
                    warningCustom(oos_message)
                ElseIf TETotal.EditValue < 0 Then
                    warningCustom("Amount paid is negative")
                Else
                    'header
                    Dim is_book_trf As String = "2"

                    If is_book_transfer Then
                        is_book_trf = "1"
                    End If

                    Dim is_buy_valas_param As String = "2"
                    Dim valas_bank_param As String = "NULL"

                    If is_buy_valas Then
                        is_buy_valas_param = "1"
                        valas_bank_param = "'" & SLEAkunValas.EditValue.ToString & "'"
                    ElseIf Not SLEAkunValas.EditValue.ToString = "0" Then
                        valas_bank_param = "'" & SLEAkunValas.EditValue.ToString & "'"
                    End If

                    If report_mark_type = "139" Or report_mark_type = "202" Then
                        id_coa_tag = FormBankWithdrawal.GVPOList.GetRowCellValue(0, "id_coa_tag").ToString
                    ElseIf report_mark_type = "157" Then 'expense
                        id_coa_tag = FormBankWithdrawal.GVExpense.GetRowCellValue(0, "id_coa_tag").ToString
                    ElseIf report_mark_type = "192" Then 'payroll
                        id_coa_tag = FormBankWithdrawal.GVTHR.GetRowCellValue(0, "id_coa_tag").ToString
                    End If

                    Dim query As String = "INSERT INTO tb_pn(report_mark_type,kurs,id_acc_payfrom,id_comp_contact,id_pay_type,id_user_created,date_created,date_payment,value,note,is_book_transfer,id_report_status,id_coa_tag,id_acc_trf_fee,trf_fee,is_auto_debet,is_buy_valas,id_valas_bank) 
VALUES('" & report_mark_type & "','" & decimalSQL(Decimal.Parse(TEKurs.EditValue.ToString).ToString) & "','" & SLEPayFrom.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & SLEPayType.EditValue.ToString & "','" & id_user & "',NOW(),'" & Date.Parse(DEPayment.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','" & is_book_trf & "','1','" + id_coa_tag + "','" & SLEACCTrfFee.EditValue.ToString & "','" & decimalSQL(TETrfFee.EditValue.ToString) & "','" & SLEAutoDebet.EditValue.ToString & "','" & is_buy_valas_param & "'," & valas_bank_param & "); SELECT LAST_INSERT_ID(); "
                    id_payment = execute_query(query, 0, True, "", "", "", "")
                    'detail
                    Dim id_currency, kurs, val_bef_kurs, is_include_total As String
                    id_currency = "1"
                    kurs = "0"
                    val_bef_kurs = "0"
                    is_include_total = "1"

                    query = "INSERT INTO tb_pn_det(id_pn,id_report,report_mark_type,number,vendor,id_comp,id_acc,id_dc,total_pay,value,id_currency,kurs,val_bef_kurs,balance_due,note,is_include_total) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        '
                        If GVList.GetRowCellValue(i, "id_currency").ToString = "" Or GVList.GetRowCellValue(i, "id_currency").ToString = "0" Then
                            id_currency = "1"
                        Else
                            id_currency = GVList.GetRowCellValue(i, "id_currency").ToString
                        End If
                        If GVList.GetRowCellValue(i, "kurs").ToString = "" Or GVList.GetRowCellValue(i, "kurs") = 0 Then
                            kurs = "0"
                        Else
                            kurs = decimalSQL(GVList.GetRowCellValue(i, "kurs").ToString)
                        End If
                        If GVList.GetRowCellValue(i, "val_bef_kurs").ToString = "" Or GVList.GetRowCellValue(i, "val_bef_kurs") = 0 Then
                            val_bef_kurs = "0"
                        Else
                            val_bef_kurs = decimalSQL(GVList.GetRowCellValue(i, "val_bef_kurs").ToString)
                        End If

                        is_include_total = "1"
                        If get_opt_acc_field("id_acc_pend_selisih_kurs").ToString = GVList.GetRowCellValue(i, "id_acc").ToString Or get_opt_acc_field("id_acc_rugi_selisih_kurs").ToString = GVList.GetRowCellValue(i, "id_acc").ToString Then
                            is_include_total = "2"
                        End If

                        query += "('" & id_payment & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & GVList.GetRowCellValue(i, "vendor").ToString & "','" & GVList.GetRowCellValue(i, "id_comp").ToString & "','" & GVList.GetRowCellValue(i, "id_acc").ToString & "','" & GVList.GetRowCellValue(i, "id_dc").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_pay").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & id_currency & "','" & kurs & "','" & val_bef_kurs & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "','" & is_include_total & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    'generate number
                    query = "CALL gen_number('" & id_payment & "','159')"
                    execute_non_query(query, True, "", "", "", "")
                    'add journal + mark
                    submit_who_prepared("159", id_payment, id_user)

                    'done
                    infoCustom("Payment created")
                    If FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 1 Then
                        FormBankWithdrawal.load_po()
                    ElseIf FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 2 Then
                        FormBankWithdrawal.load_expense()
                    End If

                    FormBankWithdrawal.load_payment()
                    FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_pn", id_payment)
                    FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0
                    Close()
                End If
            End If
        Else
            warningCustom("Please check total first")
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans AND a.id_bill_type='22'
            WHERE ad.report_mark_type=159 AND ad.id_report=" + id_payment + "
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

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "159"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_payment
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this detail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVList.DeleteSelectedRows()
                GCList.RefreshDataSource()
                GVList.RefreshData()
                calculate_amount()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_payment = "-1" Then
            FormBankWithdrawalAdd.action = "ins"
            FormBankWithdrawalAdd.ShowDialog()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If id_payment = "-1" And GVList.FocusedRowHandle >= 0 Then
            If GVList.GetFocusedRowCellValue("id_report") = "0" Then
                Cursor = Cursors.WaitCursor
                FormBankWithdrawalAdd.action = "upd"
                FormBankWithdrawalAdd.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BGenerateSelisihKurs_Click(sender As Object, e As EventArgs)
        Dim id_pn As String = ""
        For i As Integer = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "report_mark_type").ToString = "189" Then
                If Not i = 0 Then
                    id_pn = ","
                End If
                id_pn += GVList.GetRowCellValue(i, "id_report").ToString
            End If
        Next

        Dim query As String = ""

        'Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
        'newRow("id_report") = "0"
        'newRow("report_mark_type") = "0"

        'newRow("id_acc") = SLECOA.EditValue.ToString
        'newRow("vendor") = TxtSupplier.Text

        'newRow("id_comp") = "1"
        'newRow("comp_number") = "000"

        'newRow("acc_name") = TxtCOA.Text
        'newRow("acc_description") = SLECOA.Text
        'newRow("number") = addSlashes(TxtReff.Text)
        'newRow("total_pay") = 0

        'If LEDK.EditValue.ToString = "2" Then
        '    newRow("value") = TxtAmount.EditValue * -1
        '    newRow("balance_due") = TxtAmount.EditValue * -1
        'Else
        '    newRow("value") = TxtAmount.EditValue
        '    newRow("balance_due") = TxtAmount.EditValue
        'End If

        'newRow("note") = addSlashes(TxtDescription.Text)
        'newRow("id_dc") = LEDK.EditValue.ToString
        'newRow("dc_code") = LEDK.Text
        'newRow("value_view") = TxtAmount.EditValue
        'TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
        'FormBankWithdrawalDet.GCList.RefreshDataSource()
        'FormBankWithdrawalDet.GVList.RefreshData()
        'FormBankWithdrawalDet.calculate_amount()
        'actionLoad()
    End Sub

    Private Sub BPickDP_Click(sender As Object, e As EventArgs) Handles BPickDP.Click
        FormBankWithdrawalDP.report_mark_type = "139"
        FormBankWithdrawalDP.id_comp_contact = SLEVendor.EditValue.ToString
        FormBankWithdrawalDP.ShowDialog()
    End Sub

    Private Sub BCompen_Click(sender As Object, e As EventArgs) Handles BCompen.Click
        'FormBankWithdrawalCompen.id_comp = SLEVendor.EditValue.ToString
        FormBankWithdrawalCompen.id_comp = "444"
        FormBankWithdrawalCompen.ShowDialog()
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        If GVList.RowCount > 0 Then
            Try
                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.opt = "Buku Besar"
                showpopup.report_mark_type = GVList.GetFocusedRowCellValue("report_mark_type").ToString
                showpopup.id_report = GVList.GetFocusedRowCellValue("id_report").ToString
                showpopup.show()
            Catch ex As Exception
                warningCustom("No details")
            End Try
        End If
    End Sub

    Private Sub SLEAkunValas_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAkunValas.EditValueChanged
        'search kurs rata2
        Try
            If SLEAkunValas.EditValue.ToString = "0" Then
                TEKurs.EditValue = 1
            Else
                Dim q As String = "SELECT * FROM `tb_stock_valas` 
WHERE id_valas_bank=" & SLEAkunValas.EditValue.ToString & " AND id_currency=2
ORDER BY id_stock_valas DESC LIMIT 1"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    TEKurs.EditValue = dt.Rows(0)("kurs_rata_rata")
                Else
                    TEKurs.EditValue = 1
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BMutasiValas_Click(sender As Object, e As EventArgs) Handles BMutasiValas.Click
        FormStockValas.id_valas_bank = SLEAkunValas.EditValue.ToString
        FormStockValas.ShowDialog()
    End Sub

    Private Sub BViewJurnalBUM_Click(sender As Object, e As EventArgs) Handles BViewJurnalBUM.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans=ad.id_acc_trans AND a.id_bill_type='25'
            WHERE ad.report_mark_type=159 AND ad.id_report=" + id_payment + "
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
End Class