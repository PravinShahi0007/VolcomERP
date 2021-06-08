﻿Public Class FormBankWithdrawalAttachement
    Public id_purc_order As String = "-1"
    Public is_lock As String = "2"
    Dim id_coa_tag As String = "1"

    Private Sub FormBankWithdrawalAttachement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
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
        '
        load_blank_draft()

        If TEPPH.EditValue > 0 Then
            'Jurnal PPH
            If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
                'credit pph
                Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRowvat("no") = "1"
                Try
                    newRowvat("acc_name") = get_acc(SLEPPHAccount.EditValue.ToString, "1")
                    newRowvat("acc_description") = get_acc(SLEPPHAccount.EditValue.ToString, "2")
                    newRowvat("note") = get_acc(SLEPPHAccount.EditValue.ToString, "2")
                Catch ex As Exception
                End Try

                newRowvat("cc") = "000"
                newRowvat("report_number") = ""
                newRowvat("debit") = 0
                newRowvat("credit") = TEPPH.EditValue
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                '
                Dim newRowvat2 As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRowvat2("no") = "2"
                Try
                    newRowvat2("acc_name") = get_acc(SLEPPHAccount.EditValue.ToString, "1")
                    newRowvat2("acc_description") = get_acc(SLEPPHAccount.EditValue.ToString, "2")
                    newRowvat2("note") = get_acc(SLEPPHAccount.EditValue.ToString, "2")
                Catch ex As Exception
                End Try

                newRowvat2("cc") = "000"
                newRowvat2("report_number") = ""
                newRowvat2("debit") = TEPPH.EditValue
                newRowvat2("credit") = 0
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat2)
            Else
                'save first
                If is_lock = "2" Then
                    save("draft")
                End If

                Dim query As String = "SELECT o.id_coa_out AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
" & decimalSQL(GVPurcReq.Columns("gross_up_value").SummaryItem.SummaryValue.ToString) & " AS `debit`,
0 AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_item_coa o ON o.id_item_cat=i.id_item_cat AND o.id_departement=req.id_departement
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph grossup
SELECT  po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
" & decimalSQL(GVPurcReq.Columns("gross_up_value").SummaryItem.SummaryValue.ToString) & " AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- hutang non grossup
SELECT IF(po.id_coa_tag=1,comp.id_acc_ap,comp.id_acc_cabang_ap) AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
" & decimalSQL(GVPurcReq.Columns("pph").SummaryItem.SummaryValue.ToString) & " AS `debit`,
0 AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph non grossup
SELECT  po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
" & decimalSQL(GVPurcReq.Columns("pph").SummaryItem.SummaryValue.ToString) & " AS `credit`,
i.item_desc AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp"
                Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
                For i = 0 To dt.Rows.Count - 1
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = i + 1
                    Try
                        newRowvat("acc_name") = get_acc(dt.Rows(i)("id_acc").ToString, "1")
                        newRowvat("acc_description") = get_acc(dt.Rows(i)("id_acc").ToString, "2")
                        newRowvat("note") = get_acc(dt.Rows(i)("id_acc").ToString, "2")
                    Catch ex As Exception
                    End Try

                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("debit") = dt.Rows(i)("debit")
                    newRowvat("credit") = dt.Rows(i)("credit")
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                Next
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_pph()
        'load pph account
        Dim q_where As String = ""

        If id_coa_tag = "1" Then
            q_where = " AND id_coa_type=1 "
        Else
            q_where = " AND id_coa_type=2 "
        End If

        Dim query_pph As String = "(SELECT 0 AS id_acc, '' AS acc_name, '' AS acc_description, '' AS acc) UNION (SELECT id_acc, acc_name, acc_description, CONCAT(acc_name, ' - ', acc_description) as acc FROM tb_a_acc WHERE id_status = 1 AND id_is_det = 2 " & q_where & ")"
        viewSearchLookupQuery(SLEPPHAccount, query_pph, "id_acc", "acc", "id_acc")

        SLEPPHAccount.EditValue = "0"
    End Sub

    Sub load_form()
        Dim query As String = "
            SELECT po.is_active_payment,po.id_coa_tag,po.purc_order_number,po.is_active_payment,po.pph_account,po.inv_number, c.comp_number, c.comp_name
,IFNULL(po.due_date, DATE(NOW())) AS due_date, po.vat_percent
,ROUND((SUM(pod.`value` * recd.qty)-IF(po.is_disc_percent=2,po.disc_value,(po.disc_percent * SUM(pod.`value` * recd.qty))))*(po.dpp_percent/100)*(po.vat_percent/100),2) AS vat_value
, po.is_disc_percent ,po.disc_percent, po.disc_value , IFNULL(po.pph_reff_date, DATE(NOW())) AS pph_reff_date
FROM tb_purc_rec_det recd
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`=6
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=recd.`id_purc_order_det`
INNER JOIN tb_purc_order po ON po.id_purc_order=pod.`id_purc_order` 
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
WHERE po.id_purc_order = " & id_purc_order & "
GROUP BY pod.`id_purc_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_coa_tag = data.Rows(0)("id_coa_tag").ToString

        load_pph()

        If data.Rows(0)("is_active_payment").ToString = "1" Then
            is_lock = "1"
        Else
            is_lock = "2"
        End If

        TextEditVendor.EditValue = data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString
        TextEditPONumber.EditValue = data.Rows(0)("purc_order_number").ToString
        TEInvNumber.Text = data.Rows(0)("inv_number").ToString

        If Not data.Rows(0)("pph_account").ToString = "" Then
            SLEPPHAccount.EditValue = data.Rows(0)("pph_account").ToString
        End If

        DateEditDueDate.EditValue = data.Rows(0)("due_date")
        DEReffDate.EditValue = data.Rows(0)("pph_reff_date")

        DEReffDate.Properties.MinValue = execute_query("SELECT DATE_ADD(MAX(date_until),INTERVAL 1 DAY) FROM `tb_closing_log` WHERE id_coa_tag='" & id_coa_tag & "'", 0, True, "", "", "", "")

        'item
        Dim query_item As String = "SELECT pod.`id_purc_order_det`, item.`item_desc`,itt.id_item_type,itt.item_type, SUM(recd.`qty`) AS qty_po, pod.`value` AS val_po, pod.pph_percent, pod.gross_up_value , IFNULL(pod.discount_for_pph,0.00) AS discount_for_pph
FROM tb_purc_rec_det recd 
INNER JOIN tb_purc_order_det pod ON recd.`id_purc_order_det`=pod.`id_purc_order_det`
INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.id_report_status=6
INNER JOIN tb_purc_req_det prd ON prd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req`
INNER JOIN `tb_item` item ON item.`id_item`=pod.`id_item`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=item.`id_uom`
INNER JOIN tb_lookup_purc_item_type itt ON itt.id_item_type=item.id_item_type
WHERE pod.`id_purc_order`=" + id_purc_order + "
GROUP BY pod.id_purc_order_det"

        Dim data_item As DataTable = execute_query(query_item, -1, True, "", "", "", "")

        GCPurcReq.DataSource = data_item

        GVPurcReq.BestFitColumns()

        'summary
        TETotal.EditValue = GVPurcReq.Columns("amount").SummaryItem.SummaryValue

        If data.Rows(0)("is_disc_percent").ToString = "1" Then
            TEDiscPercent.EditValue = data.Rows(0)("disc_percent")
            TEDiscTotal.EditValue = data.Rows(0)("disc_value")
        Else
            TEDiscPercent.EditValue = 0.00
            TEDiscTotal.EditValue = data.Rows(0)("disc_value")
        End If

        TEVATPercent.EditValue = data.Rows(0)("vat_percent")
        TEVATValue.EditValue = data.Rows(0)("vat_value")

        TEPPH.EditValue = 0.00

        TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
        '
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.GetRowCellValue(i, "discount_for_pph") = 0 And TEDiscTotal.EditValue > 0 Then
                GVPurcReq.SetRowCellValue(i, "discount_for_pph", TEDiscTotal.EditValue * (GVPurcReq.GetRowCellValue(i, "amount") / TETotal.EditValue))
            End If
        Next
        '
        If is_lock = "1" Then
            BSaveLock.Visible = False
            BSave.Visible = False
        End If
        '

        calculate()
        load_blank_draft()
    End Sub

    Private Sub SimpleButtonAttachment_Click(sender As Object, e As EventArgs) Handles SimpleButtonAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = "-1"
        FormDocumentUpload.is_view = "-1"
        FormDocumentUpload.id_report = id_purc_order
        FormDocumentUpload.report_mark_type = "235"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButtonSet_Click(sender As Object, e As EventArgs) Handles BSave.Click
        save("1")
    End Sub

    Sub save(ByVal opt As String)
        If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "gross_up_value") > 0 Then
                    warningCustom("SKBP cannot use grossup")
                    Exit Sub
                End If
            Next
        End If

        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 235 AND id_report = " + id_purc_order

        Dim cek_attachment As String = If(execute_query(query_attachment, 0, True, "", "", "", "") = "0", "Please add attachment", "")

        'check pph
        Dim cek_pph As String = ""

        If TEPPH.EditValue > 0 Then
            If SLEPPHAccount.EditValue.ToString = "0" Then
                cek_pph = "Please select PPH Account"
            End If
        End If

        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.GetRowCellValue(i, "id_item_type").ToString = "2" And GVPurcReq.GetRowCellValue(i, "pph_percent") = 0 Then
                cek_pph = "Please add PPH for Jasa"
            End If
        Next

        If Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        ElseIf Not cek_pph = "" Then
            errorCustom(cek_pph)
        ElseIf TEInvNumber.Text = "" Then
            warningCustom("Please input invoice number")
        Else
            For i = 0 To GVPurcReq.RowCount - 1
                execute_non_query("UPDATE tb_purc_order_det SET pph_percent='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph_percent").ToString) & "',pph='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph").ToString) & "',discount_for_pph='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "discount_for_pph").ToString) & "',gross_up_value='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "gross_up_value").ToString) & "' WHERE id_purc_order_det='" & GVPurcReq.GetRowCellValue(i, "id_purc_order_det").ToString & "'", True, "", "", "", "")
            Next

            Dim query As String = "UPDATE tb_purc_order SET pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ",due_date = '" + Date.Parse(DateEditDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "',pph_reff_Date = '" + Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") + "',pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ", pph_account = " + If(SLEPPHAccount.EditValue.ToString = "0", "NULL", SLEPPHAccount.EditValue.ToString) + ",inv_number='" & addSlashes(TEInvNumber.Text) & "' WHERE id_purc_order = " + id_purc_order
            execute_non_query(query, True, "", "", "", "")

            If opt = "1" Then
                infoCustom("Detail updated")
            End If
            load_form()
        End If
    End Sub

    Private Sub FormBankWithdrawalAttachement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPurcReq_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPurcReq.CellValueChanged
        calculate()
    End Sub

    Sub calculate()
        Dim pph As Decimal = 0.00

        For i = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.IsValidRowHandle(i) Then
                pph += Math.Floor(GVPurcReq.GetRowCellValue(i, "pph_percent") * (GVPurcReq.GetRowCellValue(i, "amount") + GVPurcReq.GetRowCellValue(i, "gross_up_value") - GVPurcReq.GetRowCellValue(i, "discount_for_pph")) / 100)
            End If
        Next

        TEPPH.EditValue = pph

        TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
    End Sub

    Private Sub TEPPH_EditValueChanged(sender As Object, e As EventArgs) Handles TEPPH.EditValueChanged
        Try
            TEGrandTotal.EditValue = TETotal.EditValue - TEDiscTotal.EditValue + TEVATValue.EditValue - TEPPH.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GrossUpPPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrossUpPPHToolStripMenuItem.Click
        If GVPurcReq.RowCount > 0 Then
            Try
                Dim dpp As Decimal = Decimal.Parse(GVPurcReq.GetFocusedRowCellValue("amount").ToString) - Decimal.Parse(GVPurcReq.GetFocusedRowCellValue("discount_for_pph").ToString)
                Dim pph As Decimal = Decimal.Parse(GVPurcReq.GetFocusedRowCellValue("pph_percent").ToString)
                '
                Dim grossup_val As Decimal = 0.00
                grossup_val = Math.Floor(((100 / (100 - pph)) * dpp) - dpp)
                GVPurcReq.SetFocusedRowCellValue("gross_up_value", grossup_val)
                calculate()
            Catch ex As Exception
                warningCustom("Please check your input")
            End Try
        End If
    End Sub

    Private Sub BSaveLock_Click(sender As Object, e As EventArgs) Handles BSaveLock.Click
        If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If GVPurcReq.GetRowCellValue(i, "gross_up_value") > 0 Then
                    warningCustom("SKBP cannot use grossup")
                    Exit Sub
                End If
            Next
        End If

        'check attachment
        Dim query_attachment As String = "SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 235 AND id_report = " + id_purc_order

        Dim cek_attachment As String = If(execute_query(query_attachment, 0, True, "", "", "", "") = "0", "Please add attachment", "")

        'check pph
        Dim cek_pph As String = ""

        If TEPPH.EditValue > 0 Then
            If SLEPPHAccount.EditValue.ToString = "0" Then
                cek_pph = "Please select PPH Account"
            End If
        End If

        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If GVPurcReq.GetRowCellValue(i, "id_item_type").ToString = "2" And GVPurcReq.GetRowCellValue(i, "pph_percent") = 0 Then
                cek_pph = "Please add PPH for Jasa"
            End If
        Next

        If Not cek_attachment = "" Then
            errorCustom(cek_attachment)
        ElseIf Not cek_pph = "" Then
            errorCustom(cek_pph)
        ElseIf TEInvNumber.Text = "" Then
            warningCustom("Please input invoice number")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to set ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                For i = 0 To GVPurcReq.RowCount - 1
                    execute_non_query("UPDATE tb_purc_order_det SET pph_percent='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph_percent").ToString) & "',pph='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "pph").ToString) & "',gross_up_value='" & decimalSQL(GVPurcReq.GetRowCellValue(i, "gross_up_value").ToString) & "' WHERE id_purc_order_det='" & GVPurcReq.GetRowCellValue(i, "id_purc_order_det").ToString & "'", True, "", "", "", "")
                Next

                Dim query As String = "UPDATE tb_purc_order SET pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ",due_date = '" + Date.Parse(DateEditDueDate.EditValue.ToString).ToString("yyyy-MM-dd") + "',pph_reff_date = '" + Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', is_active_payment = 1, pph_total = " + decimalSQL(TEPPH.EditValue.ToString) + ", pph_account = " + If(SLEPPHAccount.EditValue.ToString = "0", "NULL", SLEPPHAccount.EditValue.ToString) + ",inv_number='" & addSlashes(TEInvNumber.Text) & "' WHERE id_purc_order = " + id_purc_order
                execute_non_query(query, True, "", "", "", "")

                If TEPPH.EditValue > 0 Then
                    'Jurnal PPH
                    'main journal
                    Dim id_acc_trans As String = ""
                    Dim qjm As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status)
                    VALUES ('','" + addSlashes(TextEditPONumber.Text) + "','24','" + id_user + "', NOW(),'" + Date.Parse(DEReffDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "
                    id_acc_trans = execute_query(qjm, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_acc_trans + ",36)", True, "", "", "", "")

                    If SLEPPHAccount.EditValue.ToString = get_opt_acc_field("id_acc_skbp") Then 'skbp
                        query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref,id_coa_tag ,id_vendor)
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.pph) AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.pph) AS `debit`,
0 AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp"
                        execute_non_query(query, True, "", "", "", "")
                    Else
                        query = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, report_mark_type_ref, id_report_ref, report_number_ref, id_coa_tag, id_vendor)
-- biaya
SELECT " + id_acc_trans + " AS id_acc_trans, o.id_coa_out AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.`gross_up_value`) AS `debit`,
0 AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_item_coa o ON o.id_item_cat=i.id_item_cat AND o.id_departement=req.id_departement
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph grossup
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.`gross_up_value`) AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value>0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- hutang non grossup
SELECT " + id_acc_trans + " AS id_acc_trans, comp.id_acc_ap AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
SUM(pod.pph) AS `debit`,
0 AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp
UNION ALL
-- pph non grossup
SELECT " + id_acc_trans + " AS id_acc_trans, po.`pph_account` AS `id_acc`, dep.id_main_comp, SUM(rd.qty) AS `qty`,
0 AS `debit`,
SUM(pod.pph) AS `credit`,
CONCAT(i.item_desc,' - ',acc_pph.acc_description) AS `note`, 148, rd.id_purc_rec, r.purc_rec_number, IF(po.id_expense_type=1,139,202) AS rmt_reff,  po.id_purc_order, po.purc_order_number, po.id_coa_tag, cont.id_comp
FROM tb_purc_rec_det rd
INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
INNER JOIN tb_purc_order po ON po.id_purc_order = r.id_purc_order
INNER JOIN tb_a_acc acc_pph ON acc_pph.id_acc=po.pph_account
INNER JOIN tb_m_comp_contact cont ON cont.id_comp_contact = po.id_comp_contact
INNER JOIN tb_m_comp comp ON comp.id_comp = cont.id_comp
INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
INNER JOIN tb_purc_req_det reqd ON pod.id_purc_req_det=reqd.id_purc_req_det
INNER JOIN tb_item i ON i.id_item = rd.id_item
INNER JOIN tb_purc_req req ON req.id_purc_req=reqd.id_purc_req
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
WHERE po.id_purc_order=" & id_purc_order & " AND po.`is_close_rec`=1 AND pod.gross_up_value<=0
GROUP BY po.id_purc_order,dep.id_main_comp"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If

                Close()
            End If
            FormBankWithdrawal.view_po_og()
        End If
    End Sub

    Private Sub XTCPPH_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPPH.SelectedPageChanged
        If XTCPPH.SelectedTabPageIndex = 1 Then
            viewDraftJournal()
        ElseIf XTCPPH.SelectedTabPageIndex = 2 Then
            Dim q As String = "SELECT a.`id_acc_trans`,a.`date_created`,a.`acc_trans_number`,SUM(ad.`debit`) AS debit, SUM(ad.`credit`) AS credit FROM tb_a_acc_trans_det ad
INNER JOIN tb_a_acc_trans a ON a.`id_acc_trans`=ad.`id_acc_trans`
WHERE (ad.report_mark_type_ref='139' OR ad.report_mark_type_ref='202') AND ad.id_report_ref='" & id_purc_order & "'
GROUP BY a.id_acc_trans"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt
            GVList.BestFitColumns()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 Then
            FormViewJournal.id_trans = GVList.GetFocusedRowCellValue("id_acc_trans").ToString
            FormViewJournal.ShowDialog()
        End If
    End Sub
End Class