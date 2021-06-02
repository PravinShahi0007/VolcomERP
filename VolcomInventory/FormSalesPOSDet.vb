﻿Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.XtraReports.UI
Imports Microsoft.Office.Interop

Public Class FormSalesPOSDet
    Public action As String
    Public id_sales_pos As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_comp_contact_bill As String = "-1"
    Public id_report_status As String
    Public id_sales_pos_det_list As New List(Of String)
    Public id_comp As String = "-1"
    Public id_comp_bill_to As String = "-1"
    Dim total_amount As Decimal = 0.0
    Dim currency As String = "-1"
    Dim id_comp_cat_store As String = "-1"
    Dim now_date As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"
    '
    Public id_del_ins As String = "-1"
    '
    'updqated 13 januari 2015
    Public dt_stock_store As New DataTable
    Dim last_end_period_select As String = "9999-12-01"
    '
    Public id_do As String = "-1"
    Public id_memo_type As String = "-1"
    Dim report_mark_type As String = "-1"

    'menu : 1=invoice 2=credit note
    Public id_menu As String = "1"
    Public id_sales_pos_ref As String = "-1"
    Public ol_store_order_cn As String = ""
    Dim vat_def As Decimal = 0
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_inv")
    Public is_block_no_stock As String = get_setup_field("is_block_no_stock")
    Public is_block_same_invoice As String = get_setup_field("is_block_same_invoice")
    Public is_use_unique_code As String = "2"
    Dim print_title As String = ""
    Public is_use_return_centre As String = get_setup_field("is_use_return_centre")

    'accounting coa
    Public cond_coa As Boolean = True
    Public id_acc_sales As String = "-1"
    Public id_acc_sales_return As String = "-1"
    Public id_acc_ar As String = "-1"
    Dim is_use_inv_mapping As String = get_setup_field("is_use_inv_mapping")
    Dim is_for_gwp As String = "2"
    Public discard_transaction As Boolean = False
    Public comp_number As String = ""
    Public order_number As String = ""
    Public cust_name As String = ""
    Public is_from_prob_list As Boolean = False
    Public is_from_prob_list_no_stock As Boolean = False
    Public id_store_type As String = "-1"
    Public id_return_refuse As String = "-1"
    Public is_from_cancel_cn As Boolean = False


    Private Sub FormSalesPOSDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub viewPrintOpt()
        Dim query As String = "SELECT '1' AS id , '" + print_title + "' AS `opt`
        UNION 
        SELECT '2' AS id , 'DELIVERY SLIP' AS `opt` "
        viewLookupQuery(LEPrintOpt, query, 0, "opt", "id")
    End Sub

    Sub actionLoad()
        'load from bof
        If bof_column = "1" And action = "ins" Then
            BtnLoadFromBOF.Visible = True
        Else
            BtnLoadFromBOF.Visible = False
        End If

        'get currency default
        Dim query_currency As String = "SELECT b.id_currency FROM tb_opt a INNER JOIN tb_lookup_currency b ON a.id_currency_default = b.id_currency "
        currency = execute_query(query_currency, 0, True, "", "", "", "")

        'get default store category for pick company
        id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")

        'view data
        viewReportStatus()
        viewSoType()
        viewInvType()

        'setting menu
        If id_menu = "1" Then
            Text = "Invoice"
            LEInvType.Focus()
            print_title = "INVOICE SLIP"
        ElseIf id_menu = "2" Then
            Text = "Credit Note"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Text = "Credit Note Missing"
            TxtCodeCompFrom.Focus()
            print_title = "CREDIT NOTE SLIP"
            PanelCN.Visible = True
            SBBrowseInvoice.Enabled = True
            BtnListProduct.Visible = True
            BtnImport.Visible = False
            BtnImportOLStore.Visible = False
            BtnLoadFromBOF.Visible = False
            BtnSelectDiscount.Enabled = False
            QtyToolStripMenuItem.Enabled = False
            PriceToolStripMenuItem.Enabled = False
        ElseIf id_menu = "3" Then
            Text = "Invoice Missing Promo"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            TxtCodeCompFrom.Focus()
            print_title = "INVOICE SLIP"

            If action = "ins" Then
                PriceToolStripMenuItem.Visible = True
                DeleteToolStripMenuItem.Visible = True
                QtyToolStripMenuItem.Visible = True
            End If
        ElseIf id_menu = "4" Then
            Text = "Invoice Different Margin"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = True
            TxtCodeCompFrom.Focus()
            LabelBillTo.Visible = True
            TxtCodeBillTo.Visible = True
            TxtNameBillTo.Visible = True
            BtnBrowseBillTo.Visible = True
            print_title = "INVOICE SLIP"
        ElseIf id_menu = "5" Then
            Text = "Credit Note Online Store"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            PanelCN.Visible = True
            BtnListProduct.Visible = True
            BtnImport.Visible = False
            BtnImportOLStore.Visible = False
            TxtCodeCompFrom.Focus()
            TxtOLStoreNumber.Properties.ReadOnly = False
            GridColumnOrder.Visible = False
            GridColumnDel.Visible = False
            print_title = "CREDIT NOTE SLIP"
            BtnLoadFromReturnCentre.Visible = True
            BtnImport.Visible = False
            BtnImportOLStore.Visible = False
            BtnImportOLStoreNew.Visible = False
            BtnLoadPOS.Visible = False
            BtnLoadFromBOF.Visible = False
        ElseIf id_menu = "6" Then
            Text = "Cancellation CN"
            LEInvType.Enabled = False
            TEDO.Enabled = False
            CheckEditInvType.Visible = False
            print_title = "CANCELLATION CN"
        End If

        'print opt
        viewPrintOpt()

        If action = "ins" Then
            TxtDiscount.EditValue = 0.0
            TxtNetto.EditValue = 0.0
            TxtVatTot.EditValue = 0.0
            TxtTaxBase.EditValue = 0.0
            TxtPotPenjualan.EditValue = 0.0
            TEKurs.EditValue = 0.00


            'get vat default
            Dim dtv As DataTable = execute_query("SELECT vat_inv_default FROM tb_opt ", -1, True, "", "", "", "")
            vat_def = dtv.Rows(0)("vat_inv_default")
            SPVat.EditValue = vat_def

            'TxtVirtualPosNumber.Text = header_number_sales("6")
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BtnDraftJournal.Enabled = False
            BtnViewJournal.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            GCItemList.DataSource = Nothing

            'discount disable
            If is_use_inv_mapping = "1" Then
                SPDiscount.Enabled = False
            End If

            'minimum date
            Dim query_closing As String = "SELECT DATE_ADD(l.date_until,INTERVAL 1 DAY) AS `first_date` FROM tb_closing_log l WHERE l.note='Closing End' ORDER BY l.id DESC LIMIT 1 "
            Dim data_closing As DataTable = execute_query(query_closing, -1, True, "", "", "", "")
            DEStart.Properties.MinValue = data_closing(0)("first_date")
            DEEnd.Properties.MinValue = data_closing(0)("first_date")
            'maximum date
            Dim tgl_sekarang As DateTime = getTimeDB()
            DEStart.Properties.MaxValue = tgl_sekarang
            DEEnd.Properties.MaxValue = tgl_sekarang
            DEStocktake.Properties.MaxValue = tgl_sekarang
            DEStocktake.EditValue = Nothing

            'credit note ol store base on return centre
            If id_menu = "5" And is_use_return_centre = "1" Then
                If comp_number <> "" And order_number <> "" Then
                    Cursor = Cursors.WaitCursor
                    BtnListProduct.Visible = False
                    TxtOLStoreNumber.Properties.ReadOnly = True
                    TxtCodeCompFrom.Text = comp_number
                    actionCompFrom()
                    TxtOLStoreNumber.Text = order_number
                    TXTName.Text = cust_name
                    'view inv
                    Dim qinv As String = "SELECT i.id_sales_pos, i.sales_pos_number, r.sales_order_ol_shop_number, i.sales_pos_discount, i.sales_pos_vat
                    FROM tb_ol_store_ret_list l
                    INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
                    INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
                    INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
                    INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
                    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
                    INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                    INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                    INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
                    WHERE l.id_ol_store_ret_stt=6 AND c.id_comp=" + id_comp + " AND  r.sales_order_ol_shop_number='" + order_number + "' AND i.report_mark_type=48
                    GROUP BY i.id_sales_pos "
                    Dim dinv As DataTable = execute_query(qinv, -1, True, "", "", "", "")
                    If dinv.Rows.Count = "1" Then
                        id_sales_pos_ref = dinv.Rows(0)("id_sales_pos").ToString
                        TxtInvoice.Text = dinv.Rows(0)("sales_pos_number").ToString
                        TxtOLStoreNumber.Text = dinv.Rows(0)("sales_order_ol_shop_number").ToString
                        SPDiscount.EditValue = dinv.Rows(0)("sales_pos_discount")
                        SPVat.EditValue = dinv.Rows(0)("sales_pos_vat")
                        calculate()
                        viewDetail()
                        viewProb()
                        viewDetailCode()
                        BtnLoadFromReturnCentre.Focus()
                    ElseIf dinv.Rows.Count > 1 Then
                        Dim cond As String = ""
                        For i As Integer = 0 To dinv.Rows.Count - 1
                            If i > 0 Then
                                cond += "OR "
                            ElseIf i = 0 Then
                                cond += "AND ( "
                            End If
                            cond += "i.id_sales_pos=" + dinv.Rows(i)("id_sales_pos").ToString + " "
                        Next
                        If cond <> "" Then
                            cond += ") "
                        End If
                        FormSalesCreditNotePopInv.cond = cond
                        showInv()
                    Else
                        stopCustom("Invoice order not found.")
                        id_sales_pos_ref = "-1"
                        TxtInvoice.Text = ""
                        TxtOLStoreNumber.Text = ""
                        SPDiscount.EditValue = 0
                        SPVat.EditValue = vat_def
                        calculate()
                        viewDetail()
                        viewProb()
                        viewDetailCode()
                    End If
                    Cursor = Cursors.Default
                Else
                    stopCustom("Order number not found")
                    Close()
                End If
            End If

            'problem list price
            If (id_menu = "1" Or id_menu = "4") And is_from_prob_list Then
                Dim typ As String = FormSalesPOS.LETypeProb.EditValue.ToString
                'get comp
                Dim id_comp_prob As String = FormSalesPOS.SLEStoreProb.EditValue.ToString
                Dim comp_prob As String = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + id_comp_prob + "' ", 0, True, "", "", "", "")
                TxtCodeCompFrom.Text = comp_prob
                TxtCodeCompFrom.Enabled = False
                actionCompFrom()
                BtnImport.Visible = False
                BtnLoadFromProbList.Visible = True

                'default due date, start, end peiod
                If typ = "1" Then
                    'from price recon
                    DEDueDate.EditValue = FormSalesPOS.GVProbList.GetFocusedRowCellValue("sales_pos_due_date")
                    DEStart.EditValue = FormSalesPOS.GVProbList.GetFocusedRowCellValue("sales_pos_start_period")
                    DEEnd.EditValue = FormSalesPOS.GVProbList.GetFocusedRowCellValue("sales_pos_end_period")
                End If
                DeleteToolStripMenuItem.Visible = False
            End If

            'problem list no stock
            If (id_menu = "1" Or id_menu = "4") And is_from_prob_list_no_stock Then
                Dim id_comp_prob As String = FormSalesPOS.SLEStoreNewItem.EditValue.ToString
                Dim comp_prob As String = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + id_comp_prob + "' ", 0, True, "", "", "", "")
                TxtCodeCompFrom.Text = comp_prob
                TxtCodeCompFrom.Enabled = False
                actionCompFrom()
                BtnImport.Visible = False
                BtnLoadFromProbList.Visible = True
                DeleteToolStripMenuItem.Visible = False
            End If

            'cancellation cn
            If id_menu = "6" Then
                'get comp
                Dim id_comp_ref As String = FormSalesPOS.SLEStoreRefuseReturn.EditValue.ToString
                Dim comp_ref As String = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + id_comp_ref + "' ", 0, True, "", "", "", "")
                TxtCodeCompFrom.Text = comp_ref
                TxtCodeCompFrom.Enabled = False
                BtnBrowseContactFrom.Enabled = False
                actionCompFrom()
                BtnImport.Visible = False
                BtnLoadFromProbList.Visible = True
                DeleteToolStripMenuItem.Visible = False
            End If
        ElseIf action = "upd" Then
            GroupControlList.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseContactFrom.Enabled = False
            '
            BtnAttachment.Enabled = True
            BtnDraftJournal.Enabled = True
            BtnViewJournal.Enabled = True
            BMark.Enabled = True
            GridColumnNote.Visible = False
            BtnGetKurs.Enabled = False
            SBBrowseInvoice.Enabled = False

            'query view based on edit id's
            Dim query As String = ""
            query += "SELECT a.is_use_unique_code,pld.pl_sales_order_del_number,a.id_pl_sales_order_del,a.id_so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
            query += "a.sales_pos_number, a.bof_number, a.bof_date, (c.comp_name) AS store_name_from,c.npwp, "
            query += "a.id_store_contact_from, (c.comp_number) AS store_number_from, (c.address_primary) AS store_address_from,
            IFNULL(a.id_comp_contact_bill,'-1') AS `id_comp_contact_bill`,(cb.comp_number) AS `comp_number_bill`, (cb.comp_name) AS `comp_name_bill`,
            d.report_status, DATE_FORMAT(a.sales_pos_date,'%Y-%m-%d') AS sales_pos_datex, c.id_comp, "
            query += "a.sales_pos_due_date, a.sales_pos_start_period, a.sales_pos_end_period, a.sales_pos_st_date, a.sales_pos_discount, a.sales_pos_potongan, a.sales_pos_vat, a.id_memo_type, a.id_inv_type, so.sales_order_ol_shop_number,so.customer_name,a.kurs_trans, a.report_mark_type, IFNULL(a.id_return_refuse,0) AS `id_return_refuse` "
            If id_menu = "5" Then
                query += ", IFNULL(sor.sales_pos_number,'-') AS `sales_pos_number_ref`, sor.sales_order_ol_shop_number AS `sales_order_ol_shop_number_ref`, sor.customer_name AS `customer_name_ref` "
            End If
            If id_menu = "2" Then
                query += ", IFNULL(sor.sales_pos_number,'-') AS `sales_pos_number_ref` "
            End If
            query += "FROM tb_sales_pos a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
            query += "LEFT JOIN tb_m_comp_contact bb ON a.id_comp_contact_bill = bb.id_comp_contact
            LEFT JOIN tb_m_comp cb ON cb.id_comp = bb.id_comp "
            query += "LEFT JOIN tb_pl_sales_order_del pld ON pld.id_pl_sales_order_del=a.id_pl_sales_order_del "
            query += "LEFT JOIN tb_sales_order so ON so.id_sales_order = pld.id_sales_order "
            query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
            If id_menu = "5" Then
                query += "LEFT JOIN (
                    SELECT pd.id_sales_pos, pr.sales_pos_number, so.sales_order_ol_shop_number, so.customer_name 
                    FROM tb_sales_pos_det pd
                    INNER JOIN tb_sales_pos_det pdr ON pdr.id_sales_pos_det = pd.id_sales_pos_det_ref
                    INNER JOIN tb_sales_pos pr ON pr.id_sales_pos = pdr.id_sales_pos
                    INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = pdr.id_pl_sales_order_del_det
                    INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = deld.id_sales_order_det
                    INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                    WHERE pd.id_sales_pos=" + id_sales_pos + "
                    GROUP BY pd.id_sales_pos
                ) sor ON sor.id_sales_pos = a.id_sales_pos "
            End If
            If id_menu = "2" Then
                query += "LEFT JOIN (
                    SELECT pd.id_sales_pos, pr.sales_pos_number 
                    FROM tb_sales_pos_det pd
                    INNER JOIN tb_sales_pos_det pdr ON pdr.id_sales_pos_det = pd.id_sales_pos_det_ref
                    INNER JOIN tb_sales_pos pr ON pr.id_sales_pos = pdr.id_sales_pos
                    WHERE pd.id_sales_pos=" + id_sales_pos + "
                    GROUP BY pd.id_sales_pos
                ) sor ON sor.id_sales_pos = a.id_sales_pos "
            End If
            query += "WHERE a.id_sales_pos = '" + id_sales_pos + "' "
            query += "ORDER BY a.id_sales_pos ASC "

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
            MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString
            TENPWP.Text = data.Rows(0)("npwp").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_pos_datex").ToString, 0)
            TxtVirtualPosNumber.Text = data.Rows(0)("sales_pos_number").ToString
            TxtBOF.Text = data.Rows(0)("bof_number").ToString
            If data.Rows(0)("bof_date").ToString = "" Then
                DEBOF.EditValue = Nothing
            Else
                DEBOF.EditValue = data.Rows(0)("bof_date")
            End If

            If id_menu = "5" Then
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number_ref").ToString
                TxtInvoice.Text = data.Rows(0)("sales_pos_number_ref").ToString
                TXTName.Text = data.Rows(0)("customer_name_ref").ToString
            ElseIf id_menu = "2" Then
                TxtInvoice.Text = data.Rows(0)("sales_pos_number_ref").ToString
            Else
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                TXTName.Text = data.Rows(0)("customer_name").ToString
            End If
            MENote.Text = data.Rows(0)("sales_pos_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            id_comp = data.Rows(0)("id_comp").ToString

            ''updated 8 october 2014
            DEDueDate.EditValue = data.Rows(0)("sales_pos_due_date")
            DEStart.EditValue = data.Rows(0)("sales_pos_start_period")
            DEEnd.EditValue = data.Rows(0)("sales_pos_end_period")
            SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
            TxtPotPenjualan.EditValue = data.Rows(0)("sales_pos_potongan")
            SPVat.EditValue = data.Rows(0)("sales_pos_vat")

            'update feb 2019-deteksi laporarn jual unuik
            is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString

            'updated 04 ocktobertr 2017
            id_memo_type = data.Rows(0)("id_memo_type").ToString
            report_mark_type = data.Rows(0)("report_mark_type").ToString
            'If id_memo_type = "1" Then 'sales invoice
            '    report_mark_type = "48"
            'ElseIf id_memo_type = "2" Then 'sales cn
            '    If id_menu = "2" Then
            '        report_mark_type = "66"
            '    ElseIf id_menu = "5" Then
            '        report_mark_type = "118"
            '    End If
            'ElseIf id_memo_type = "3" Then 'missing invoice
            '    report_mark_type = "54"
            'ElseIf id_memo_type = "4" Then 'missing cn
            '    report_mark_type = "67"
            'ElseIf id_memo_type = "5" Then 'missing promo
            '    report_mark_type = "116"
            'ElseIf id_memo_type = "8" Then ' missing different margin
            '    report_mark_type = "117"
            'ElseIf id_memo_type = "9" Then ' invoice different margin
            '    report_mark_type = "183"
            'End If
            LEInvType.ItemIndex = LEInvType.Properties.GetDataSourceRowIndex("id_inv_type", data.Rows(0)("id_inv_type").ToString)
            TEDO.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            If id_memo_type = "1" Or id_memo_type = "2" Or id_memo_type = "5" Or id_memo_type = "9" Then
                CheckEditInvType.EditValue = False
            ElseIf id_memo_type = "3" Or id_memo_type = "4" Or id_memo_type = "8" Then
                CheckEditInvType.EditValue = True
            End If

            id_comp_contact_bill = data.Rows(0)("id_comp_contact_bill").ToString
            TxtCodeBillTo.Text = data.Rows(0)("comp_number_bill").ToString
            TxtNameBillTo.Text = data.Rows(0)("comp_name_bill").ToString
            TEKurs.EditValue = data.Rows(0)("kurs_trans")
            If Not IsDBNull(data.Rows(0)("sales_pos_st_date")) Then
                DEStocktake.EditValue = data.Rows(0)("sales_pos_st_date")
            End If

            ''detail2
            viewDetail()
            viewProb()
            viewDetailCode()
            'viewStockStore()
            check_but()
            calculate()
            allow_status()
        End If

        'if volcom online store
        Dim is_volcom_online As String = execute_query("SELECT COUNT(*) AS total FROM tb_m_comp_volcom_ol WHERE id_store = " + id_comp, 0, True, "", "", "", "")

        If Not is_volcom_online = "0" Then
            LabelName.Visible = True
            TXTName.Visible = True

            If Not LabelBillTo.Visible Then
                LabelName.Location = New Point(6, 143)
                TXTName.Location = New Point(78, 140)
            End If
        Else
            LabelName.Visible = False
            TXTName.Visible = False
        End If
    End Sub

    Sub viewInvType()
        Dim query As String = "SELECT * FROM tb_lookup_inv_type i ORDER BY i.id_inv_type ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEInvType, query, 0, "inv_type_display", "id_inv_type")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_pos_less('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_pos_det_list.Add(data.Rows(i)("id_sales_pos_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Sub viewProb()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_sales_pos_prob, p.is_invalid_price, p.is_no_stock, 
        p.id_product, prod.product_full_code AS `code`, prod.product_name AS `name`, cd.display_name AS `size`,
        p.id_design_price_retail, p.design_price_retail, p.design_price_store, p.id_design_price_valid, p.design_price_valid,
        p.store_qty, p.invoice_qty, p.no_stock_qty,(p.invoice_qty+p.no_stock_qty) AS `total_qty`,
        IF(p.is_invalid_price=1,'Not Valid', 'OK') AS `note_price`
        FROM tb_sales_pos_prob p
        INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        WHERE p.id_sales_pos='" + id_sales_pos + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProbList.DataSource = data
        GVProbList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailCode()
        Dim query As String = "SELECT c.id_sales_pos_det_counting, c.id_sales_pos, c.id_product, c.id_pl_prod_order_rec_det_unique, c.counting_code, 
        c.full_code, prod.product_full_code AS `code`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`, c.id_design_price, c.design_price
        FROM tb_sales_pos_det_counting c
        INNER JOIN tb_m_product prod ON prod.id_product = c.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE c.id_sales_pos=" + id_sales_pos + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCode.DataSource = data
        GVCode.BestFitColumns()
    End Sub

    Sub viewCheckCOA(ByVal label As String)
        If is_use_inv_mapping = "1" Then
            If id_acc_ar = "0" Or id_acc_sales = "0" Or id_acc_sales_return = "0" Then
                stopCustom("Can't process invoice to " + label + ". Please mapping COA AR/Sales for this store first.")
                cond_coa = False
                Try
                    FormPopUpContact.Close()
                Catch ex As Exception
                End Try
                Close()
            Else
                cond_coa = True
            End If
        End If
    End Sub

    Sub viewStockStore()
        If id_menu = "1" Or id_menu = "4" Then
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If
            FormMain.SplashScreenManager1.SetWaitFormDescription("Get stock")
            dt_stock_store.Clear()

            Dim end_period As String = "9999-12-01"
            Try
                end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Dim query As String = "CALL view_stock_fg_for_invoice('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', NOW()) "
            dt_stock_store = execute_query(query, -1, True, "", "", "", "")
            FormMain.SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'Make sure valid data
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        calculate()

        'cek bof
        If is_load_from_bof = True Then
            Dim bof_number As String = addSlashes(TxtBOF.Text)
            Dim qcek As String = "SELECT p.id_sales_pos FROM tb_sales_pos p WHERE p.bof_number='" + bof_number + "' AND p.id_report_status!=5 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                stopCustom("This invoice already input on ERP.")
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        'cek periode
        Dim start_period_cek As String = "0000-01-01"
        Dim end_period_cek As String = "9999-12-01"
        Dim due_date_cek As String = "-1"
        Dim st_date_cek As String = "-1"
        Try
            start_period_cek = DEStart.EditValue.ToString
        Catch ex As Exception
        End Try
        Try
            end_period_cek = DEEnd.EditValue.ToString
        Catch ex As Exception
        End Try
        Try
            due_date_cek = DEDueDate.EditValue.ToString
        Catch ex As Exception
        End Try
        Try
            st_date_cek = DEStocktake.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim cond_valid_stock_take_date As Boolean = True
        If CheckEditInvType.EditValue = True Then
            If st_date_cek <> "-1" Then
                cond_valid_stock_take_date = True
            Else
                cond_valid_stock_take_date = False
            End If
        End If

        Dim do_q As String = ""
        If id_do = "-1" Then
            do_q = "NULL"
        Else
            do_q = "'" + id_do + "'"
        End If

        'cek coa
        If id_acc_ar = "0" Then
            id_acc_ar = "NULL"
        End If
        If id_acc_sales = "0" Then
            id_acc_sales = "NULL"
        End If
        If id_acc_sales_return = "0" Then
            id_acc_sales_return = "NULL"
        End If

        'cek bill
        Dim cond_bill_to As Boolean = True
        If id_menu = "4" And id_comp_contact_bill = "-1" Then
            cond_bill_to = False
        End If

        'refuse


        'cek no stok
        makeSafeGV(GVItemList)
        Dim cond_no_stock As Boolean = False
        GVItemList.ActiveFilterString = "[note]<>'OK'"
        If GVItemList.RowCount > 0 And is_block_no_stock = "1" And (id_menu = 1 Or id_menu = "4") Then
            cond_no_stock = True
        End If
        GVItemList.ActiveFilterString = ""
        makeSafeGV(GVItemList)

        'isi harga utk kode unik 
        If is_use_unique_code = "1" Then
            makeSafeGV(GVCode)
            For u As Integer = 0 To GVCode.RowCount - 1
                Dim id_product_cek As String = GVCode.GetRowCellValue(u, "id_product").ToString
                makeSafeGV(GVItemList)
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_cek + "' "
                GVCode.SetRowCellValue(u, "id_design_price", GVItemList.GetFocusedRowCellValue("id_design_price_retail").ToString)
                GVCode.SetRowCellValue(u, "design_price", GVItemList.GetFocusedRowCellValue("design_price_retail"))
            Next
            makeSafeGV(GVCode)
            makeSafeGV(GVItemList)
        End If

        ValidateChildren()
        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount <= 0 And GVProbList.RowCount <= 0 Then
            stopCustom("Item list can't blank ")
        ElseIf start_period_cek = "0000-01-01" Or end_period_cek = "9999-12-01" Or due_date_cek = "-1" Then
            stopCustom("Please fill period and due date!")
            'check stock
            'ElseIf Not valid_stock Then
            'stopCustom(err_str.ToString)
        ElseIf Not cond_valid_stock_take_date Then
            stopCustom("Please fill stock take date!")
        ElseIf Not cond_bill_to Then
            stopCustom("Bill to can't blank")
        ElseIf cond_no_stock Then
            stopCustom("Some items have problems. Please see note and check these items.")
        ElseIf id_acc_ar = "-1" Or id_acc_sales = "-1" Or id_acc_sales_return = "-1" Then
            stopCustom("Please mapping COA AR/Sales for this store first.")
        ElseIf TEKurs.EditValue = 0.00 Then
            stopCustom("Kurs can't blank")
        Else
            Dim bof_number As String = addSlashes(TxtBOF.Text)
            Dim bof_date As String = ""
            If DEBOF.Text = "" Then
                bof_date = "NULL"
            Else
                bof_date = "'" + DateTime.Parse(DEBOF.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            End If
            Dim sales_pos_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_so_type As String = LETypeSO.EditValue
            Dim sales_pos_due_date As String = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim sales_pos_discount As String = decimalSQL(SPDiscount.EditValue.ToString)
            Dim sales_pos_potongan As String = decimalSQL(TxtPotPenjualan.EditValue.ToString)
            Dim sales_pos_vat As String = decimalSQL(SPVat.EditValue.ToString)
            total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
            Dim kurs_trans As String = decimalSQL(TEKurs.EditValue.ToString)
            Dim sales_pos_st_date As String = ""
            If CheckEditInvType.EditValue = True Then
                sales_pos_st_date = "'" + DateTime.Parse(DEStocktake.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Else
                sales_pos_st_date = "NULL"
            End If
            Dim id_memo_type As String = ""
            Dim sales_pos_number As String = ""
            If id_menu = "1" Then
                'sales invoice
                If CheckEditInvType.EditValue = True Then
                    report_mark_type = "54"
                    id_memo_type = "3"
                    'sales_pos_number = header_number_sales("6")
                    sales_pos_number = ""
                Else
                    report_mark_type = "48"
                    id_memo_type = "1"
                    'sales_pos_number = header_number_sales("6")
                    sales_pos_number = ""
                End If
            ElseIf id_menu = "2" Then
                'credit note
                If CheckEditInvType.EditValue = True Then
                    report_mark_type = "67"
                    id_memo_type = "4"
                    'sales_pos_number = header_number_sales("17")
                    sales_pos_number = ""
                Else
                    report_mark_type = "66"
                    id_memo_type = "2"
                    'sales_pos_number = header_number_sales("17")
                    sales_pos_number = ""
                End If
            ElseIf id_menu = "3" Then
                'invoice missing promo
                report_mark_type = "116"
                id_memo_type = "5"
                'sales_pos_number = header_number_sales("33")
                sales_pos_number = ""
            ElseIf id_menu = "4" Then
                'invoice diff margin
                If CheckEditInvType.EditValue = True Then
                    report_mark_type = "117"
                    id_memo_type = "8"
                    'sales_pos_number = header_number_sales("6")
                    sales_pos_number = ""
                Else
                    report_mark_type = "183"
                    id_memo_type = "9"
                    'sales_pos_number = header_number_sales("6")
                    sales_pos_number = ""
                End If
            ElseIf id_menu = "5" Then
                report_mark_type = "118"
                id_memo_type = "2"
                'sales_pos_number = header_number_sales("17")
                sales_pos_number = ""
            ElseIf id_menu = "6" Then
                report_mark_type = "292"
                id_memo_type = "10"
                sales_pos_number = ""
            End If
            Dim id_inv_type As String = LEInvType.EditValue.ToString
            If id_comp_contact_bill = "-1" Then
                id_comp_contact_bill = "NULL "
            End If
            If id_sales_pos_ref = "-1" Then
                id_sales_pos_ref = "NULL "
            End If
            If id_return_refuse = "-1" Then
                id_return_refuse = "NULL"
            End If

            'cek same invoice
            If is_block_same_invoice = 1 And (id_menu = "1" Or id_menu = "4") And GVItemList.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim qry As String = ""
                For f As Integer = 0 To GVItemList.RowCount - 1
                    If f > 0 Then
                        qry += "UNION ALL "
                    End If
                    qry += "SELECT " + id_store_contact_from + " AS `id_store_contact_from`," + id_comp_contact_bill + " AS `id_comp_contact_bill`," + GVItemList.GetRowCellValue(f, "id_product").ToString + " AS `id_product`," + decimalSQL(GVItemList.GetRowCellValue(f, "sales_pos_det_qty").ToString) + " AS `qty`, " + decimalSQL(GVItemList.GetRowCellValue(f, "design_price_retail").ToString) + " AS `design_price_retail`, '" + sales_pos_start_period + "' AS `sales_pos_start_period`, '" + sales_pos_end_period + "' AS `sales_pos_end_period`, " + id_memo_type + " AS `id_memo_type` "
                Next

                Dim qsi As String = "SELECT ga.`id_store_contact_from`,ga.`id_comp_contact_bill`,ga.`id_product`,ga.`qty`, ga.`design_price_retail`,
                IFNULL(b.id_sales_pos,0) AS `id_sales_pos`,b.sales_pos_number, b.report_mark_type
                FROM (
	                SELECT a.`id_store_contact_from`,a.`id_comp_contact_bill`,a.`id_product`,SUM(a.`qty`) AS `qty`, a.`design_price_retail`, a.`sales_pos_start_period`, a.`sales_pos_end_period`, a.`id_memo_type`
	                FROM (
		                " + qry + "
                    ) a
	                GROUP BY a.id_product, a.design_price_retail
                ) ga
                LEFT JOIN (
	                SELECT sp.id_sales_pos, sp.id_store_contact_from, sp.id_comp_contact_bill, sp.sales_pos_number, sp.report_mark_type, spd.id_product, SUM(spd.sales_pos_det_qty) AS `qty`, spd.design_price_retail
	                FROM tb_sales_pos_det spd
	                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	                WHERE sp.id_report_status!=5 AND sp.id_store_contact_from=" + id_store_contact_from + " 
	                AND sp.sales_pos_start_period='" + sales_pos_start_period + "' AND sp.sales_pos_end_period='" + sales_pos_end_period + "' 
	                AND sp.id_memo_type=" + id_memo_type + "
	                GROUP BY sp.id_sales_pos, spd.id_product, spd.design_price_retail
                ) b ON IFNULL(b.id_comp_contact_bill,0) = IFNULL(ga.id_comp_contact_bill,0) AND  b.id_product = ga.id_product AND b.design_price_retail = ga.design_price_retail "
                Dim dsi As DataTable = execute_query(qsi, -1, True, "", "", "", "")
                Dim dsi_filter As DataRow() = dsi.Select("[id_sales_pos]=0 ")
                If dsi_filter.Length = 0 Then
                    Cursor = Cursors.WaitCursor
                    discard_transaction = False
                    FormCustomDialog.LabelContent.Text = "This invoice is the same as transaction number : " + dsi.Rows(0)("sales_pos_number").ToString
                    FormCustomDialog.id_report = dsi.Rows(0)("id_sales_pos").ToString
                    FormCustomDialog.rmt = dsi.Rows(0)("report_mark_type").ToString
                    FormCustomDialog.BtnOK.Text = "Continue"
                    FormCustomDialog.BtnAction.Text = "View " + dsi.Rows(0)("sales_pos_number").ToString
                    FormCustomDialog.ShowDialog()
                    Cursor = Cursors.Default

                    If discard_transaction Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.Default
            End If


            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'cek duplicat number
                    'Dim qnum As String = "SELECT * FROM tb_sales_pos WHERE sales_pos_number='" + sales_pos_number + "' AND id_report_status!=5 "
                    'Dim dnum As DataTable = execute_query(qnum, -1, True, "", "", "", "")
                    'If dnum.Rows.Count > 0 Then
                    '    'jika nomer sudah ada
                    '    Cursor = Cursors.Default
                    '    stopCustom("Invoice number : " + sales_pos_number + " already exist. Please save again to get new register number")
                    '    Exit Sub
                    'End If

                    'cek stok
                    If (id_menu = "1" Or id_menu = "4") And is_block_no_stock = "1" And cond_no_stock = False Then
                        If GVItemList.RowCount > 0 Then
                            Dim qs As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; 
                            INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES "
                            Dim id_prod As String = ""
                            For s As Integer = 0 To GVItemList.RowCount - 1
                                If s > 0 Then
                                    qs += ","
                                    id_prod += ","
                                End If
                                qs += "('" + id_user + "','" + GVItemList.GetRowCellValue(s, "code").ToString + "','" + addSlashes(GVItemList.GetRowCellValue(s, "name").ToString) + "', '" + GVItemList.GetRowCellValue(s, "size").ToString + "', '" + GVItemList.GetRowCellValue(s, "id_product").ToString + "', '" + decimalSQL(GVItemList.GetRowCellValue(s, "sales_pos_det_qty").ToString) + "') "
                                id_prod += GVItemList.GetRowCellValue(s, "id_product").ToString
                            Next
                            qs += "; CALL view_validate_stock(" + id_user + ", " + id_comp + ", '" + id_prod + "',1); "
                            Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
                            If dts.Rows.Count > 0 Then
                                Cursor = Cursors.Default
                                stopCustom("No stock available for some items.")
                                FormValidateStock.dt = dts
                                FormValidateStock.ShowDialog()
                                Exit Sub
                            End If
                        End If
                    End If

                    'Main tbale
                    BtnSave.Enabled = False
                    Dim query As String = "INSERT INTO tb_sales_pos(id_store_contact_from,id_comp_contact_bill , sales_pos_number, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_potongan, sales_pos_vat, id_pl_sales_order_del,id_memo_type,id_inv_type, id_sales_pos_ref, report_mark_type, is_use_unique_code, id_acc_ar, id_acc_sales, id_acc_sales_return, bof_number, bof_date, kurs_trans, sales_pos_st_date,id_return_refuse) "
                    query += "VALUES('" + id_store_contact_from + "'," + id_comp_contact_bill + ", '" + sales_pos_number + "', NOW(), '" + sales_pos_note + "', '" + id_report_status + "', '" + id_so_type + "', '" + decimalSQL(total_amount.ToString) + "', '" + sales_pos_due_date + "', '" + sales_pos_start_period + "', '" + sales_pos_end_period + "', '" + sales_pos_discount + "', '" + sales_pos_potongan + "', '" + sales_pos_vat + "'," + do_q + "," + id_memo_type + "," + id_inv_type + "," + id_sales_pos_ref + ", '" + report_mark_type + "', '" + is_use_unique_code + "', " + id_acc_ar + ", " + id_acc_sales + ", " + id_acc_sales_return + ", '" + bof_number + "'," + bof_date + ", '" + kurs_trans + "'," + sales_pos_st_date + ", " + id_return_refuse + "); SELECT LAST_INSERT_ID(); "
                    id_sales_pos = execute_query(query, 0, True, "", "", "", "")
                    'gen number
                    execute_non_query("CALL gen_number(" + id_sales_pos + ", " + report_mark_type + ");", True, "", "", "", "")

                    'disable increase inc sales
                    'If report_mark_type = "48" Or report_mark_type = "54" Or report_mark_type = "117" Or report_mark_type = "183" Then
                    '    'invoice
                    '    increase_inc_sales("6")
                    'ElseIf report_mark_type = "66" Or report_mark_type = "67" Or report_mark_type = "118" Then
                    '    'credit note
                    '    increase_inc_sales("17")
                    'ElseIf report_mark_type = "116" Then
                    '    'invoice missing promo
                    '    increase_inc_sales("33")
                    'End If

                    'insert who prepared
                    insert_who_prepared(report_mark_type, id_sales_pos, id_user)

                    'Detail 
                    Dim jum_ins_i As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail, note, id_sales_pos_det_ref, id_pl_sales_order_del_det, id_pos_combine_summary, id_ol_store_ret_list, id_sales_pos_prob, id_sales_pos_prob_price,id_sales_pos_oos_recon_det, id_cn_det, id_return_refuse_det) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                        Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                        Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                        Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                        If id_menu = "2" Or id_menu = "5" Then
                            sales_pos_det_qty = sales_pos_det_qty * -1
                        End If
                        Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                        Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                        Dim note As String = GVItemList.GetRowCellValue(i, "note").ToString
                        Dim id_sales_pos_det_ref As String = "NULL "
                        Try
                            id_sales_pos_det_ref = GVItemList.GetRowCellValue(i, "id_sales_pos_det_ref").ToString
                            If id_sales_pos_det_ref = "0" Or id_sales_pos_det_ref = "" Then
                                id_sales_pos_det_ref = "NULL "
                            End If
                        Catch ex As Exception
                        End Try
                        Dim id_pl_sales_order_del_det As String = "NULL "
                        Try
                            id_pl_sales_order_del_det = GVItemList.GetRowCellValue(i, "id_pl_sales_order_del_det").ToString
                            If id_pl_sales_order_del_det = "0" Or id_pl_sales_order_del_det = "" Then
                                id_pl_sales_order_del_det = "NULL "
                            End If
                        Catch ex As Exception
                        End Try
                        Dim id_pos_combine_summary As String = "NULL "
                        Try
                            id_pos_combine_summary = GVItemList.GetRowCellValue(i, "id_pos_combine_summary").ToString
                            If id_pos_combine_summary = "0" Or id_pos_combine_summary = "" Then
                                id_pos_combine_summary = "NULL "
                            End If
                        Catch ex As Exception
                        End Try
                        Dim id_ol_store_ret_list As String = "NULL"
                        Try
                            id_ol_store_ret_list = GVItemList.GetRowCellValue(i, "id_ol_store_ret_list").ToString
                            If id_ol_store_ret_list = "0" Or id_ol_store_ret_list = "" Then
                                id_ol_store_ret_list = "NULL "
                            End If
                        Catch ex As Exception
                        End Try
                        Dim id_sales_pos_prob As String = GVItemList.GetRowCellValue(i, "id_sales_pos_prob").ToString
                        If id_sales_pos_prob = "0" Then
                            id_sales_pos_prob = "NULL"
                        End If
                        Dim id_sales_pos_prob_price As String = GVItemList.GetRowCellValue(i, "id_sales_pos_prob_price").ToString
                        If id_sales_pos_prob_price = "0" Then
                            id_sales_pos_prob_price = "NULL"
                        End If
                        Dim id_sales_pos_oos_recon_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_oos_recon_det").ToString
                        If id_sales_pos_oos_recon_det = "0" Then
                            id_sales_pos_oos_recon_det = "NULL"
                        End If
                        Dim id_cn_det As String = GVItemList.GetRowCellValue(i, "id_cn_det").ToString
                        If id_cn_det = "0" Or id_cn_det = "" Then
                            id_cn_det = "NULL"
                        End If
                        Dim id_return_refuse_det As String = GVItemList.GetRowCellValue(i, "id_return_refuse_det").ToString
                        If id_return_refuse_det = "0" Or id_return_refuse_det = "" Then
                            id_return_refuse_det = "NULL"
                        End If

                        If jum_ins_i > 0 Then
                            query_detail += ", "
                        End If
                        query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "','" + note + "'," + id_sales_pos_det_ref + "," + id_pl_sales_order_del_det + ", " + id_pos_combine_summary + ", " + id_ol_store_ret_list + "," + id_sales_pos_prob + "," + id_sales_pos_prob_price + "," + id_sales_pos_oos_recon_det + ", " + id_cn_det + "," + id_return_refuse_det + ") "
                        jum_ins_i = jum_ins_i + 1
                    Next
                    If jum_ins_i > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'update total qty
                    Dim queryt As String = "UPDATE tb_sales_pos main
                    INNER JOIN (
                        SELECT pd.id_sales_pos,ABS(SUM(pd.sales_pos_det_qty)) AS `total`
                        FROM tb_sales_pos_det pd
                        WHERE pd.id_sales_pos=" + id_sales_pos + "
                        GROUP BY pd.id_sales_pos
                    ) src ON src.id_sales_pos = main.id_sales_pos
                    SET main.sales_pos_total_qty = src.total "
                    execute_non_query(queryt, True, "", "", "", "")

                    'unique code
                    If is_use_unique_code = "1" Then
                        Dim id_type_unik As String = ""
                        Dim qty_unik As String = ""
                        Dim col_unik As String = ""

                        If report_mark_type = "48" Or report_mark_type = "54" Or report_mark_type = "116" Or report_mark_type = "117" Or report_mark_type = "183" Then
                            id_type_unik = "2"
                            qty_unik = "-1"
                            col_unik = "id_sales_pos_det_counting"
                        ElseIf report_mark_type = "66" Or report_mark_type = "67" Or report_mark_type = "118" Then
                            id_type_unik = "3"
                            qty_unik = "1"
                            col_unik = "id_sales_pos_det_counting_cn"
                        End If


                        'detail pos
                        makeSafeGV(GVCode)
                        Dim query_code As String = "INSERT INTO tb_sales_pos_det_counting(id_sales_pos, id_product, id_pl_prod_order_rec_det_unique, counting_code, full_code, id_design_price, design_price) VALUES "
                        For s As Integer = 0 To GVCode.RowCount - 1
                            Dim id_product As String = GVCode.GetRowCellValue(s, "id_product").ToString
                            Dim id_pl_prod_order_rec_det_unique As String = GVCode.GetRowCellValue(s, "id_pl_prod_order_rec_det_unique").ToString
                            Dim counting_code As String = GVCode.GetRowCellValue(s, "counting_code").ToString
                            Dim full_code As String = GVCode.GetRowCellValue(s, "full_code").ToString
                            Dim id_design_price As String = GVCode.GetRowCellValue(s, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVCode.GetRowCellValue(s, "design_price").ToString)

                            If s > 0 Then
                                query_code += ", "
                            End If

                            query_code += "('" + id_sales_pos + "', '" + id_product + "', '" + id_pl_prod_order_rec_det_unique + "', '" + counting_code + "', '" + full_code + "', '" + id_design_price + "', '" + design_price + "') "
                        Next
                        If GVCode.RowCount > 0 Then
                            execute_non_query(query_code, True, "", "", "", "")
                        End If

                        'insert di tb unique hanya invoice
                        If report_mark_type = "48" Or report_mark_type = "54" Or report_mark_type = "116" Or report_mark_type = "117" Or report_mark_type = "183" Then
                            Dim un As New ClassSalesInv()
                            un.insertUnique(id_sales_pos, report_mark_type)
                        End If
                    End If

                    If id_menu = "1" Or id_menu = "4" Or id_menu = "6" Then
                        'reserved stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.reservedStock(id_sales_pos, report_mark_type)

                        'problem list
                        makeSafeGV(GVProbList)
                        Dim query_prob As String = "INSERT INTO tb_sales_pos_prob(id_sales_pos, is_invalid_price, is_no_stock, id_product, id_design_price_retail, design_price_retail, design_price_store, id_design_price_valid, design_price_valid, store_qty, invoice_qty, no_stock_qty) VALUES "
                        For b As Integer = 0 To GVProbList.RowCount - 1
                            Dim is_invalid_price As String = GVProbList.GetRowCellValue(b, "is_invalid_price").ToString
                            Dim is_no_stock As String = GVProbList.GetRowCellValue(b, "is_no_stock").ToString
                            Dim id_product As String = GVProbList.GetRowCellValue(b, "id_product").ToString
                            If id_product = "0" Then
                                id_product = "NULL"
                            End If
                            Dim id_design_price_retail As String = GVProbList.GetRowCellValue(b, "id_design_price_retail").ToString
                            Dim design_price_retail As String = decimalSQL(GVProbList.GetRowCellValue(b, "design_price_retail").ToString)
                            Dim design_price_store As String = decimalSQL(GVProbList.GetRowCellValue(b, "design_price_store").ToString)
                            Dim id_design_price_valid As String = GVProbList.GetRowCellValue(b, "id_design_price_valid").ToString
                            If id_design_price_valid = "0" Then
                                id_design_price_valid = "NULL"
                            End If
                            Dim design_price_valid As String = decimalSQL(GVProbList.GetRowCellValue(b, "design_price_valid").ToString)
                            Dim store_qty As String = decimalSQL(GVProbList.GetRowCellValue(b, "store_qty").ToString)
                            Dim invoice_qty As String = decimalSQL(GVProbList.GetRowCellValue(b, "invoice_qty").ToString)
                            Dim no_stock_qty As String = decimalSQL(GVProbList.GetRowCellValue(b, "no_stock_qty").ToString)

                            If b > 0 Then
                                query_prob += ","
                            End If
                            query_prob += "('" + id_sales_pos + "', '" + is_invalid_price + "', '" + is_no_stock + "', " + id_product + ", '" + id_design_price_retail + "', '" + design_price_retail + "', '" + design_price_store + "', " + id_design_price_valid + ", '" + design_price_valid + "', '" + store_qty + "', '" + invoice_qty + "', '" + no_stock_qty + "') "
                        Next
                        If GVProbList.RowCount > 0 Then
                            execute_non_query(query_prob, True, "", "", "", "")
                        End If
                    End If

                    'draft journal
                    Dim acc As New ClassAccounting()
                    If id_menu = "1" Or id_menu = "2" Or id_menu = "3" Or id_menu = "4" Or id_menu = "5" Or id_menu = "6" Then
                        Try
                            If is_use_inv_mapping = "1" Then
                                acc.generateJournalSalesDraftWithMapping(id_sales_pos, report_mark_type)
                            Else
                                acc.generateJournalSalesDraft(id_sales_pos, report_mark_type)
                            End If
                        Catch ex As Exception
                            stopCustom("Automatic journal failed. Please contact administrator. " + System.Environment.NewLine + ex.ToString)
                        End Try
                    End If

                    'auto submit
                    submit_who_prepared(report_mark_type, id_sales_pos, id_user)

                    FormSalesPOS.viewSalesPOS()
                    FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_sales_pos)
                    'custom refresh
                    If id_menu = "5" And is_use_return_centre = "1" Then
                        FormSalesPOS.viewPendingCNOLStore()
                    End If
                    If is_from_prob_list Then
                        FormSalesPOS.viewProbList()
                    End If
                    If is_from_prob_list_no_stock Then
                        FormSalesPOS.viewNewItem()
                    End If
                    action = "upd"
                    actionLoad()
                    'exportToBOF(False)

                    If id_menu = "1" Then
                        infoCustom("Invoice " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "2" Or id_menu = "5" Then
                        infoCustom("Credit Note " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "3" Then
                        infoCustom("Invoice Missing Promo " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "4" Then
                        infoCustom("Invoice Different Margin " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    ElseIf id_menu = "6" Then
                        infoCustom("Cancellation CN " + TxtVirtualPosNumber.Text + " created succesfully")
                        viewDraft()
                    End If

                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim query As String = "UPDATE tb_sales_pos SET id_store_contact_from ='" + id_store_contact_from + "', sales_pos_number = '" + sales_pos_number + "', sales_pos_note='" + sales_pos_note + "', id_so_type = '" + id_so_type + "', sales_pos_total = '" + decimalSQL(total_amount.ToString) + "', sales_pos_due_date='" + sales_pos_due_date + "', sales_pos_start_period='" + sales_pos_start_period + "', sales_pos_end_period = '" + sales_pos_end_period + "', sales_pos_discount='" + sales_pos_discount + "', sales_pos_vat='" + sales_pos_vat + "' WHERE id_sales_pos ='" + id_sales_pos + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_i As Integer = 0
                        Dim query_detail As String = ""
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail) VALUES "
                        End If
                        For i As Integer = 0 To (GVItemList.RowCount - 1)
                            Try
                                Dim id_sales_pos_det As String = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                                Dim sales_pos_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_pos_det_qty").ToString)
                                'Dim sales_pos_det_note As String = GVItemList.GetRowCellValue(i, "sales_pos_det_note").ToString
                                Dim id_design_price_retail As String = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                                Dim design_price_retail As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)

                                If id_sales_pos_det = "0" Then
                                    If jum_ins_i > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_sales_pos + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_pos_det_qty + "', '" + id_design_price_retail + "', '" + design_price_retail + "') "
                                    jum_ins_i = jum_ins_i + 1
                                Else
                                    Dim query_edit As String = "UPDATE tb_sales_pos_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_pos_det_qty = '" + sales_pos_det_qty + "', id_design_price_retail = '" + id_design_price_retail + "', design_price_retail = '" + design_price_retail + "'  WHERE id_sales_pos_det = '" + id_sales_pos_det + "' "
                                    execute_non_query(query_edit, True, "", "", "", "")
                                    id_sales_pos_det_list.Remove(id_sales_pos_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_i > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_sales_pos_det_list.Count - 1)
                            Try
                                Dim querydel As String = "DELETE FROM tb_sales_pos_det WHERE id_sales_pos_det = '" + id_sales_pos_det_list(k) + "' "
                                execute_non_query(querydel, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        FormSalesPOS.viewSalesPOS()
                        FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", id_sales_pos)
                        infoCustom("Data updated")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        GVItemList.OptionsBehavior.Editable = False
        PanelControlNav.Enabled = False
        MENote.Properties.ReadOnly = True
        LETypeSO.Enabled = False

        'update 8 oktocer 2014
        DEDueDate.Properties.ReadOnly = True
        SPDiscount.Properties.ReadOnly = True
        TxtPotPenjualan.Properties.ReadOnly = True
        SPVat.Properties.ReadOnly = True
        DEStart.Properties.ReadOnly = True
        DEEnd.Properties.ReadOnly = True
        DEStocktake.Properties.ReadOnly = True
        BtnSave.Enabled = False

        'update 04 oktober 2017
        LEInvType.Enabled = False
        TEDO.Properties.ReadOnly = True
        TxtCodeCompFrom.Enabled = False
        TxtNameCompFrom.Enabled = False
        BtnBrowseContactFrom.Enabled = False
        CheckEditInvType.Enabled = False
        TxtOLStoreNumber.Properties.ReadOnly = True

        TxtCodeBillTo.Enabled = False
        TxtNameBillTo.Enabled = False
        BtnBrowseBillTo.Enabled = False

        'upddate februari 2019
        BtnNoStock.Visible = False
        GridColumnIsSelect.Visible = False
        BtnSelectDiscount.Visible = False

        BtnPrint.Enabled = True

        If check_attach_report_status(id_report_status, report_mark_type, id_sales_pos) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If



        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        If id_report_status = "5" Then
            BtnPrint.Enabled = False
        End If
        TxtVirtualPosNumber.Focus()
    End Sub

    Sub getNetto()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim pot_penjualan As Double = TxtPotPenjualan.EditValue


        Dim netto As Double = gross_total - Decimal.Parse(TxtDiscount.EditValue.ToString) - pot_penjualan
        TxtNetto.EditValue = netto
        METotSay.Text = ConvertCurrencyToEnglish(netto, currency)
    End Sub

    Sub getVat()
        Dim netto As Double = 0
        Try
            netto = Double.Parse(TxtNetto.EditValue.ToString)
        Catch ex As Exception
        End Try
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim vat_total As Double = (vat / (100 + vat)) * netto
        TxtVatTot.EditValue = vat_total
    End Sub

    Sub getDiscount()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        Dim discount As Double = (Decimal.Parse(SPDiscount.EditValue.ToString) / 100) * gross_total
        TxtDiscount.EditValue = discount
    End Sub

    Sub getTaxBase()
        Dim netto As Double = 0
        Try
            netto = Double.Parse(TxtNetto.EditValue.ToString)
        Catch ex As Exception
        End Try
        Dim vat As Double = Double.Parse(SPVat.EditValue.ToString)
        Dim tax_base_total As Double = (100 / (100 + vat)) * netto
        TxtTaxBase.EditValue = tax_base_total
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "42"

        'FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesPOSDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        'MsgBox(id_comp)
        FormSalesPOSSingle.action_pop = "ins"
        FormSalesPOSSingle.id_product = "0"
        FormSalesPOSSingle.id_sales_pos = id_sales_pos
        FormSalesPOSSingle.id_comp = id_comp
        FormSalesPOSSingle.id_wh_locator = id_wh_locator
        FormSalesPOSSingle.id_wh_rack = id_wh_rack
        FormSalesPOSSingle.id_wh_drawer = id_wh_drawer
        Dim end_period As String = "9999-01-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        FormSalesPOSSingle.date_param = end_period
        FormSalesPOSSingle.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormSalesPOSSingle.action_pop = "upd"
        FormSalesPOSSingle.id_product = "0"
        Try
            FormSalesPOSSingle.id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesPOSSingle.id_comp = id_comp
        FormSalesPOSSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesPOSSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormSalesPOSSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSalesPOSSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormSalesPOSSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_pos_det_qty")
        FormSalesPOSSingle.id_sales_pos = id_sales_pos
        FormSalesPOSSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        del()
    End Sub

    Sub del()
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                calculate()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click

    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sales_pos
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        CType(GCItemList.DataSource, DataTable).AcceptChanges()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If LEPrintOpt.EditValue = "1" Then
            ReportSalesInvoiceNew.id_sales_pos = id_sales_pos
            ReportSalesInvoiceNew.id_report_status = id_report_status
            ReportSalesInvoiceNew.rmt = report_mark_type
            Dim Report As New ReportSalesInvoiceNew()
            Report.LabelTitle.Text = print_title
            Report.XLOLStoreNumber3.Text = TxtOLStoreNumber.Text
            Report.XLName3.Text = TXTName.Text

            'if volcom online store
            Dim is_volcom_online As String = execute_query("SELECT COUNT(*) AS total FROM tb_m_comp_volcom_ol WHERE id_store = " + id_comp, 0, True, "", "", "", "")

            If Not is_volcom_online = "0" Then
                Report.XLName1.Visible = True
                Report.XLName2.Visible = True
                Report.XLName3.Visible = True
                Report.XLOLStoreNumber1.Visible = True
                Report.XLOLStoreNumber2.Visible = True
                Report.XLOLStoreNumber3.Visible = True
            Else
                Report.XLName1.Visible = False
                Report.XLName2.Visible = False
                Report.XLName3.Visible = False
                Report.XLOLStoreNumber1.Visible = False
                Report.XLOLStoreNumber2.Visible = False
                Report.XLOLStoreNumber3.Visible = False
            End If


            If CEPrintPreview.EditValue = True Then
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            Else
                Dim instance As New Printing.PrinterSettings
                Dim DefaultPrinter As String = instance.PrinterName

                ' THIS IS TO PRINT THE REPORT
                Report.PrinterName = DefaultPrinter
                Report.CreateDocument()
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.Print()
            End If
        Else
            ReportSalesInvoceDelSlip.id_sales_pos = id_sales_pos
            ReportSalesInvoceDelSlip.id_report_status = id_report_status
            ReportSalesInvoceDelSlip.rmt = report_mark_type
            Dim Report As New ReportSalesInvoceDelSlip()
            Report.LabelTitle.Text = "DELIVERY SLIP"

            If CEPrintPreview.EditValue = True Then
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
            Else
                Dim instance As New Printing.PrinterSettings
                Dim DefaultPrinter As String = instance.PrinterName

                ' THIS IS TO PRINT THE REPORT
                Report.PrinterName = DefaultPrinter
                Report.CreateDocument()
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.Print()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVItemList.Columns("sales_pos_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, currency)
    End Sub

    Private Sub DEDueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DEDueDate.Validating
        EP_DE_cant_blank(EPForm, DEDueDate)
    End Sub

    Private Sub SPDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPDiscount.EditValueChanged
        calculate()
    End Sub

    Private Sub SPVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPVat.EditValueChanged
        getVat()
        getTaxBase()
    End Sub

    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        DEEnd.Properties.MinValue = DEStart.EditValue
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_pos
        FormDocumentUpload.report_mark_type = report_mark_type
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImport.Click
        proceed_data()
    End Sub

    Sub proceed_data()
        Cursor = Cursors.WaitCursor
        is_load_from_bof = False
        TxtBOF.Text = ""
        Dim start_period As String = "1945-01-01"
        Try
            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If start_period = "1945-01-01" Or end_period = "9999-12-01" Then
            stopCustom("Please fill start & end period !")
        Else
            'check stock take det
            If CheckEditInvType.EditValue = True And DEStocktake.EditValue = Nothing Then
                stopCustom("Please fill stock take date")
                Cursor = Cursors.Default
                Exit Sub
            End If

            viewStockStore()
            If is_use_unique_code = "2" Then
                If Not is_from_prob_list And Not is_from_prob_list_no_stock Then
                    load_excel_data()
                Else
                    load_prob_list()
                End If
            Else
                load_excel_data_unique()
            End If

            calculate()
            'join

            'FormImportExcel.id_pop_up = "6"
            'FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_excel_data()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        Try
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,[F4] AS price from [" & bof_xls_ws & "] WHERE [F3]>0 AND NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2],[F4]", oledbconn)
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,'' AS price from [" & bof_xls_ws & "] WHERE [F3]>0 AND NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2]", oledbconn)
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        End Try

        checkSOH(data_temp)
    End Sub

    Sub checkSOH(ByVal data_temp As DataTable)
        Cursor = Cursors.WaitCursor
        'Try
        'get price master
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Get active price")
        Dim dt_prc As DataTable
        If CheckEditInvType.EditValue = True Then
            'missing
            Dim price_per_date As String = ""
            If id_store_type = "1" Then
                'normal acc
                Dim query_price As String = "call view_product_price_normal('AND d.id_active = 1') "
                dt_prc = execute_query(query_price, -1, True, "", "", "", "")
            Else
                'sale acc
                price_per_date = DateTime.Parse(DEStocktake.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim query_price As String = "call view_product_price('AND d.id_active = 1', '" + price_per_date + "') "
                dt_prc = execute_query(query_price, -1, True, "", "", "", "")
            End If
        Else
            'sales
            Dim price_per_date As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim query_price As String = "call view_product_price('AND d.id_active = 1', '" + price_per_date + "') "
            dt_prc = execute_query(query_price, -1, True, "", "", "", "")
        End If


        FormMain.SplashScreenManager1.CloseWaitForm()

        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dt_stock_store
        Dim tb3 = dt_prc.AsEnumerable()

        If id_menu = "1" Or id_menu = "4" Then
            FormSalesPOSCompare.dt_xls = data_temp
            FormSalesPOSCompare.dt_stock = dt_stock_store
            FormSalesPOSCompare.dt_prc = dt_prc
            FormSalesPOSCompare.ShowDialog()
        ElseIf id_menu = "2" Or id_menu = "3" Then
            Dim query = From table1 In tb1
                        Join rp In tb3
                        On table1("code").ToString Equals rp("product_full_code").ToString
                        Select New With
                        {
                            .code = table1("code").ToString,
                            .name = If(rp Is Nothing, "", rp("design_display_name").ToString),
                            .size = If(rp Is Nothing, "", rp("size").ToString),
                            .sales_pos_det_qty = table1("qty"),
                            .id_design_price = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price = If(rp Is Nothing, 0, rp("design_price")),
                            .design_price_type = If(rp Is Nothing, "", rp("design_price_type").ToString),
                            .id_design_price_retail = If(rp Is Nothing, "0", rp("id_design_price").ToString),
                            .design_price_retail = If(table1("price").ToString = "", If(rp Is Nothing, 0, rp("design_price")), table1("price")),
                            .id_design = If(rp Is Nothing, "0", rp("id_design").ToString),
                            .id_product = If(rp Is Nothing, "0", rp("id_product").ToString),
                            .is_select = "No",
                            .note = If(rp Is Nothing, "Product not found", "OK"),
                            .id_sales_pos_det = "0",
                            .id_sales_pos_prob = "0",
                            .id_sales_pos_prob_price = "0",
                            .id_sales_pos_oos_recon_det = "0",
                            .id_cn_det = "0",
                            .id_return_refuse_det = "0"
                        }

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = query.ToList()
            GCItemList.RefreshDataSource()
        End If


        'Catch ex As Exception
        'stopCustom("Input must be in accordance with the format specified !")
        'Exit Sub
        'End Try
        Cursor = Cursors.Default
    End Sub

    Public data_temp_unique As New DataTable
    Sub load_excel_data_unique()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        data_temp_unique.Clear()
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        Try
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,[F4] AS price from [" & bof_xls_ws & "] WHERE [F3]>0 AND NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2],[F4]", oledbconn)
            MyCommand.Fill(data_temp_unique)
            MyCommand.Dispose()
        Catch ex As Exception
            MyCommand = New OleDbDataAdapter("select [F2] as code,SUM([F3]) as qty,'' AS price from [" & bof_xls_ws & "] WHERE [F3]>0 AND NOT [F2] IS NULL AND NOT [F3]  IS NULL GROUP BY [F2]", oledbconn)
            MyCommand.Fill(data_temp_unique)
            MyCommand.Dispose()
        End Try

        'show form cek koleksi code
        FormSalesPOSDetCheckCollectionCode.ShowDialog()
    End Sub

    Sub load_data_pos()
        Cursor = Cursors.WaitCursor
        Dim start_period As String = "1945-01-01"
        Try
            start_period = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim end_period As String = "9999-12-01"
        Try
            end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        If id_comp = "-1" Or start_period = "1945-01-01" Or end_period = "9999-12-01" Then
            stopCustom("Please complete data store & sales period")
        Else
            FormSalesPOSCheck.id_store = id_comp
            FormSalesPOSCheck.start_period = start_period
            FormSalesPOSCheck.end_period = end_period
            FormSalesPOSCheck.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Public is_continue_load As Boolean = True
    Sub load_excel_ol_store()
        is_continue_load = True
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_order_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_order_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_order_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter("select [F1] as ol_store_order from [" & bof_xls_ws & "] WHERE NOT [F1] IS NULL GROUP BY [F1]", oledbconn)


        MyCommand.Fill(data_temp)
        MyCommand.Dispose()

        Cursor = Cursors.WaitCursor
        'check order - temp table
        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
        Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
        connection.Open()
        Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
        Dim qry As String = "DROP TABLE IF EXISTS tb_ol_order_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ol_order_temp AS ( SELECT * FROM ("
        Dim qry_det As String = ""
        For d As Integer = 0 To data_temp.Rows.Count - 1
            If qry_det <> "" Then
                qry_det += "UNION ALL "
            End If
            qry_det += "SELECT '" + data_temp.Rows(d)("ol_store_order").ToString + "' AS `order` "
        Next
        qry += qry_det + ") a ) ; ALTER TABLE tb_ol_order_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
        'Console.WriteLine(qry)
        command.CommandText = qry
        command.ExecuteNonQuery()
        command.Dispose()
        'check order
        Dim data As New DataTable
        Dim query_check_order As String = "SELECT o.`order`, so.id_sales_order,so.sales_order_number, so.sales_order_ol_shop_number, del.id_pl_sales_order_del,(del.pl_sales_order_del_number) AS `del_number`, sal.sales_pos_number, ro.sales_return_order_number,
        IFNULL(deld.pl_sales_order_del_det_qty,0) AS `qty`, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        CONCAT(IF(ISNULL(so.id_sales_order),'ERP order not found; ',''), IF(ISNULL(del.id_pl_sales_order_del),'Delivery not found;',''), IF(!ISNULL(sal.id_sales_pos),'Invoice already created;',''), IF(!ISNULL(ro.id_sales_return_order),'Return Order already created;',''), IF(!ISNULL(rl.id_ol_store_ret_list),'On process in return centre; ','')) AS `status`
        FROM tb_ol_order_temp o
        LEFT JOIN (
            SELECT so.id_sales_order, so.sales_order_ol_shop_number , so.sales_order_number
            FROM tb_sales_order so
            INNER JOIN tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order
            WHERE so.id_report_status=6 AND del.id_report_status=6 AND so.sales_order_ol_shop_number!='' AND so.id_store_contact_to='" + id_store_contact_from + "' AND (so.id_so_status!=15)
            GROUP BY so.id_sales_order
        ) so ON so.sales_order_ol_shop_number = o.`order`
        LEFT JOIN tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order AND del.id_report_status=6
        LEFT JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
        LEFT JOIN tb_sales_pos_det sald ON sald.id_pl_sales_order_del_det = deld.id_pl_sales_order_del_det
        LEFT JOIN tb_sales_pos sal ON sal.id_sales_pos = sald.id_sales_pos AND sal.id_report_status!=5
        LEFT JOIN tb_m_product p ON p.id_product = deld.id_product
        LEFT JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        LEFT JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        LEFT JOIN tb_sales_return_order_det rod ON rod.id_sales_order_det = deld.id_sales_order_det
        LEFT JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order AND ro.id_report_status!=5
        LEFT JOIN (
            SELECT l.id_ol_store_ret_list, rd.id_sales_order_det
            FROM tb_ol_store_ret_list l
            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        ) rl ON rl.id_sales_order_det = deld.id_sales_order_det
        WHERE ISNULL(so.id_sales_order) OR ISNULL(del.id_pl_sales_order_del) OR !ISNULL(sal.id_sales_pos) OR !ISNULL(ro.id_sales_return_order) OR !ISNULL(rl.id_ol_store_ret_list) "
        'Console.WriteLine(query_check_order)
        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(query_check_order, connection)
        adapter.SelectCommand.CommandTimeout = 300
        adapter.Fill(data)
        adapter.Dispose()
        connection.Close()
        connection.Dispose()
        'result check order
        If data.Rows.Count > 0 Then
            FormSalesPOSCheckXLS.dt = data
            FormSalesPOSCheckXLS.ShowDialog()
        End If
        data.Dispose()
        Cursor = Cursors.Default
        'continue or not
        If Not is_continue_load Then
            Exit Sub
        End If


        'get del
        Dim query_del As String = "SELECT dd.id_pl_sales_order_del_det, d.pl_sales_order_del_number AS `del`, so.sales_order_ol_shop_number AS `ol_store_order`,p.id_product, p.id_design, p.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,
        dd.pl_sales_order_del_det_qty AS `sales_pos_det_qty`, dd.id_design_price, dd.design_price, dd.id_design_price AS `id_design_price_retail`, dd.design_price AS `design_price_retail`, prct.design_price_type, 'OK' AS `note`,'0' AS `id_sales_pos_det`
        FROM tb_pl_sales_order_del_det dd
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order AND so.id_so_status!=15
        LEFT JOIN (
	        SELECT ind.id_sales_pos_det, ind.id_pl_sales_order_del_det
	        FROM tb_sales_pos_det ind 
	        INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
	        WHERE inv.id_report_status!=5
        ) ind ON ind.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        LEFT JOIN (
            SELECT rod.id_sales_return_order_det, rod.id_sales_order_det
            FROM tb_sales_return_order_det rod
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order
            WHERE ro.id_report_status!=5
        ) rod ON rod.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT l.id_ol_store_ret_list, rd.id_sales_order_det
            FROM tb_ol_store_ret_list l
            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        ) ret_list ON ret_list.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product 
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail AND cd.id_code=33
        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type prct ON prct.id_design_price_type = prc.id_design_price_type
        WHERE d.id_store_contact_to='" + id_store_contact_from + "' AND d.id_report_status=6 AND !ISNULL(so.sales_order_ol_shop_number) AND so.sales_order_ol_shop_number!='' AND ISNULL(ind.id_sales_pos_det) AND ISNULL(rod.id_sales_return_order_det) AND ISNULL(ret_list.id_ol_store_ret_list) "
        If LEInvType.EditValue.ToString = "4" Then
            query_del += "HAVING design_price_retail=0 "
        Else
            query_del += "HAVING design_price_retail>0 "
        End If
        Dim dtd As DataTable = execute_query(query_del, -1, True, "", "", "", "")


        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dtd.AsEnumerable()

        Try
            Dim dtr As DataTable = (From table1 In tb1
                                    Join rd In tb2
                                    On Trim(table1("ol_store_order").ToString) Equals Trim(rd("ol_store_order").ToString)
                                    Select rd).CopyToDataTable

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = dtr
            GCItemList.RefreshDataSource()
        Catch ex As Exception
            stopCustom("Order not found or invoice/return order is already created".ToUpper + System.Environment.NewLine + "Error Detail : " + ex.ToString)
        End Try
    End Sub


    Public is_continue_load_det As Boolean = True
    Sub load_excel_ol_store_det()
        is_continue_load_det = True
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_order_path")
        Dim bof_xls_temp_path As String = get_setup_field("bof_xls_bill_order_temp_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_order_path_worksheet")

        File.Copy(bof_xls_path, bof_xls_temp_path, True)

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_temp_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter("select [F1] as ol_store_order ,[F2] AS item_id, [F3] AS ol_store_id from [" & bof_xls_ws & "] WHERE NOT [F1] IS NULL GROUP BY [F1],[F2],[F3]", oledbconn)

        MyCommand.Fill(data_temp)
        MyCommand.Dispose()

        Cursor = Cursors.WaitCursor
        'check order - temp table
        Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
        Dim connection As New MySql.Data.MySqlClient.MySqlConnection(connection_string)
        connection.Open()
        Dim command As MySql.Data.MySqlClient.MySqlCommand = connection.CreateCommand()
        Dim qry As String = "DROP TABLE IF EXISTS tb_ol_order_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ol_order_temp AS ( SELECT * FROM ("
        Dim qry_det As String = ""
        For d As Integer = 0 To data_temp.Rows.Count - 1
            If qry_det <> "" Then
                qry_det += "UNION ALL "
            End If
            qry_det += "SELECT '" + data_temp.Rows(d)("ol_store_order").ToString + "' AS `order` ,'" + data_temp.Rows(d)("item_id").ToString + "' AS `item_id`,  '" + data_temp.Rows(d)("ol_store_id").ToString + "' AS `ol_store_id` "
        Next
        qry += qry_det + ") a ) ; ALTER TABLE tb_ol_order_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
        'Console.WriteLine(qry)
        command.CommandText = qry
        command.ExecuteNonQuery()
        command.Dispose()
        'check order
        Dim data As New DataTable
        Dim query_check_order As String = "SELECT o.`order`, o.item_id, o.ol_store_id, so.id_sales_order,so.sales_order_number, so.sales_order_ol_shop_number, del.id_pl_sales_order_del,(del.pl_sales_order_del_number) AS `del_number`, sal.sales_pos_number, ro.sales_return_order_number,
        IFNULL(deld.pl_sales_order_del_det_qty,0) AS `qty`, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`, c.id_comp,c.comp_number, c.comp_name, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp`,
        CONCAT(IF(ISNULL(so.id_sales_order),'ERP order not found; ',''), IF(ISNULL(del.id_pl_sales_order_del),'Delivery not found;',''), IF(!ISNULL(sal.id_sales_pos),'Invoice already created;',''),IF(!ISNULL(ro.id_sales_return_order),'Return order already created;',''),IF(c.id_comp!='" + id_comp + "','Account not valid;','')) AS `status`
        FROM tb_ol_order_temp o
        LEFT JOIN tb_sales_order so ON so.sales_order_ol_shop_number = o.`order` AND so.id_report_status=6
        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order AND sod.item_id = o.item_id AND sod.ol_store_id = o.ol_store_id
        LEFT JOIN tb_pl_sales_order_del_det deld ON deld.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del AND del.id_report_status=6
        LEFT JOIN tb_sales_pos_det sald ON sald.id_pl_sales_order_del_det = deld.id_pl_sales_order_del_det
        LEFT JOIN tb_sales_pos sal ON sal.id_sales_pos = sald.id_sales_pos AND sal.id_report_status!=5
        LEFT JOIN tb_sales_return_order_det rod ON rod.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order AND ro.id_report_status!=5
        LEFT JOIN tb_m_product p ON p.id_product = sod.id_product
        LEFT JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        LEFT JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
        LEFT JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        WHERE ISNULL(so.id_sales_order) OR ISNULL(del.id_pl_sales_order_del) OR !ISNULL(sal.id_sales_pos) OR !ISNULL(ro.id_sales_return_order) OR c.id_comp!='" + id_comp + "' "
        Dim adapter As New MySql.Data.MySqlClient.MySqlDataAdapter(query_check_order, connection)
        adapter.SelectCommand.CommandTimeout = 300
        adapter.Fill(data)
        adapter.Dispose()
        connection.Close()
        connection.Dispose()
        'result check order
        If data.Rows.Count > 0 Then
            FormSalesPOSCheckXLS.id_pop_up = "1"
            FormSalesPOSCheckXLS.dt = data
            FormSalesPOSCheckXLS.ShowDialog()
        End If
        data.Dispose()
        Cursor = Cursors.Default
        'continue or not
        If Not is_continue_load_det Then
            Exit Sub
        End If

        'get del
        Dim query_del As String = "SELECT dd.id_pl_sales_order_del_det, d.pl_sales_order_del_number AS `del`, 
        so.sales_order_ol_shop_number AS `ol_store_order`, sod.item_id, sod.ol_store_id,
        p.id_product, p.id_design, p.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,
        dd.pl_sales_order_del_det_qty AS `sales_pos_det_qty`, dd.id_design_price, dd.design_price, dd.id_design_price AS `id_design_price_retail`, dd.design_price AS `design_price_retail`, prct.design_price_type, '' AS `note`,'0' AS `id_sales_pos_det`
        FROM tb_pl_sales_order_del_det dd
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        LEFT JOIN (
	        SELECT ind.id_sales_pos_det, ind.id_pl_sales_order_del_det
	        FROM tb_sales_pos_det ind 
	        INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
	        WHERE inv.id_report_status!=5
            GROUP BY ind.id_pl_sales_order_del_det
        ) ind ON ind.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        LEFT JOIN (
            SELECT rod.id_sales_order_det
            FROM tb_sales_return_order_det rod 
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order
            WHERE ro.id_report_status!=5
            GROUP BY rod.id_sales_order_det
        ) rod ON rod.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product 
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail AND cd.id_code=33
        INNER JOIN tb_m_design dsg ON dsg.id_design = p.id_design
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type prct ON prct.id_design_price_type = prc.id_design_price_type
        WHERE d.id_store_contact_to='" + id_store_contact_from + "' AND d.id_report_status=6 AND !ISNULL(so.sales_order_ol_shop_number) AND so.sales_order_ol_shop_number!='' AND ISNULL(ind.id_sales_pos_det) AND ISNULL(rod.id_sales_order_det) "
        If LEInvType.EditValue.ToString = "4" Then
            query_del += "HAVING design_price_retail=0 "
        Else
            query_del += "HAVING design_price_retail>0 "
        End If
        Dim dtd As DataTable = execute_query(query_del, -1, True, "", "", "", "")

        Dim tb1 = data_temp.AsEnumerable()
        Dim tb2 = dtd.AsEnumerable()

        Try
            Dim dtr As DataTable = (From table1 In tb1
                                    Join rd In tb2
                                    On Trim(table1("ol_store_order").ToString) Equals Trim(rd("ol_store_order").ToString) And Trim(table1("item_id").ToString) Equals Trim(rd("item_id").ToString) And Trim(table1("ol_store_id").ToString) Equals Trim(rd("ol_store_id").ToString)
                                    Select rd).CopyToDataTable

            GCItemList.DataSource = Nothing
            GCItemList.DataSource = dtr
            GCItemList.RefreshDataSource()
        Catch ex As Exception
            stopCustom("Order not found or invoice is already created".ToUpper + System.Environment.NewLine + "Error Detail : " + ex.ToString)
        End Try
    End Sub

    Private Sub DEEnd_EditValueChanging(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles DEEnd.EditValueChanging
        'If end_load Then
        '    Cursor = Cursors.WaitCursor
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Changing end period will reset the list, are you sure To Continue??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        viewDetail()
        '    Else
        '        e.Cancel = True
        '    End If
        '    Cursor = Cursors.Default
        'End If
    End Sub

    Dim is_valid_from As Boolean = True
    Sub actionCompFrom()
        is_valid_from = True
        Dim cond_cat As String = ""
        If id_menu <> "4" Then
            cond_cat = "And c.id_comp_cat='6' "
        Else
            cond_cat = "And (c.id_comp_cat='5' OR c.id_comp_cat=6) "
        End If
        Dim query As String = "Select dr.id_wh_drawer, rack.id_wh_rack, Loc.id_wh_locator, cc.id_comp_contact, cc.id_comp, c.npwp, c.comp_number, c.comp_name, c.comp_commission, c.address_primary, c.id_so_type, c.is_use_unique_code, IFNULL(c.id_acc_sales,0) AS `id_acc_sales`, IFNULL(c.id_acc_sales_return,0) AS `id_acc_sales_return`, IFNULL(c.id_acc_ar,0) AS `id_acc_ar`,
        IF(c.id_comp_cat=5, c.id_wh_type,IF(c.id_comp_cat=6,c.id_store_type,0)) AS `id_account_type` "
        query += " From tb_m_comp_contact cc "
        query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
        query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
        query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
        query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
        query += " where cc.is_default=1 " + cond_cat + " AND c.is_active=1 AND c.is_only_for_alloc=2 AND c.comp_number='" + addSlashes(TxtCodeCompFrom.Text) + "'"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        If data.Rows.Count <= 0 Then
            stopCustom("Store not found.")
            defaultReset()
            TxtCodeCompFrom.Focus()
            is_valid_from = False
        ElseIf data.Rows.Count > 1 Then
            FormPopUpContact.id_pop_up = "42"
            'FormPopUpContact.id_cat = id_comp_cat_store
            FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeCompFrom.Text) + "'"
            FormPopUpContact.ShowDialog()
        Else
            'If check_acc(data.Rows(0)("id_comp").ToString) Then

            If id_menu <> "4" Then
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
            End If
            id_comp = data.Rows(0)("id_comp").ToString
            id_store_type = data.Rows(0)("id_account_type").ToString
            id_store_contact_from = data.Rows(0)("id_comp_contact").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
            MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
            TENPWP.Text = data.Rows(0)("npwp").ToString
            '
            id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
            id_wh_locator = data.Rows(0)("id_wh_locator").ToString
            id_wh_rack = data.Rows(0)("id_wh_rack").ToString
            is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString
            If is_use_unique_code = "1" Then
                QtyToolStripMenuItem.Visible = False
            End If
            '
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)

            'isi coa
            If id_menu <> "3" And id_menu <> "4" Then
                id_acc_sales = data.Rows(0)("id_acc_sales").ToString
                id_acc_sales_return = data.Rows(0)("id_acc_sales_return").ToString
                id_acc_ar = data.Rows(0)("id_acc_ar").ToString

                'prm
                If LEInvType.EditValue.ToString = "4" Then
                    If id_acc_ar = "0" Then
                        id_acc_ar = "52"
                    End If
                    If id_acc_sales_return = "0" Then
                        id_acc_sales_return = "1554"
                    End If
                End If

                viewCheckCOA(data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString)
                If cond_coa = False Then
                    Cursor = Cursors.Default
                    is_valid_from = False
                    Exit Sub
                End If
            ElseIf id_menu = "3" Then
                Dim qgwp As String = "SELECT IFNULL(e.id_acc_ar,0) AS `id_acc_ar`, e.comp_commission FROM tb_m_comp_comm_extra e WHERE e.is_for_gwp=1 AND e.id_comp=" + id_comp + ""
                Dim dgwp As DataTable = execute_query(qgwp, -1, True, "", "", "", "")
                If dgwp.Rows.Count > 0 Then
                    id_acc_ar = dgwp.Rows(0)("id_acc_ar").ToString
                    SPDiscount.EditValue = dgwp.Rows(0)("comp_commission")
                    BtnSelectDiscount.Enabled = False
                Else
                    id_acc_ar = "0"
                End If
                id_acc_sales = data.Rows(0)("id_acc_sales").ToString
                id_acc_sales_return = data.Rows(0)("id_acc_sales_return").ToString
                viewCheckCOA(data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString)
                If cond_coa = False Then
                    Cursor = Cursors.Default
                    is_valid_from = False
                    Exit Sub
                End If
            End If


            viewDetail()
            viewProb()
            viewDetailCode()
            check_but()
            GroupControlList.Enabled = True
            calculate()
            check_do()
            '
            If id_menu = "4" Then
                TxtCodeBillTo.Focus()
            Else
                DEDueDate.Focus()
            End If
            'Else
            '    stopCustom("Store not registered for auto posting journal.")
            'End If
        End If
    End Sub

    Private Sub TxtCodeCompFrom_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If action = "ins" Then
            If e.KeyCode = Keys.Enter Then
                actionCompFrom()
            Else
                defaultReset()
            End If
        End If
    End Sub




    Function check_acc(ByVal id_cc As String)
        Dim query As String = ""
        query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
        query += " FROM tb_m_comp_coa comp_coa "
        query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
        query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
        query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
        query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
        Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TEDO_KeyDown(sender As Object, e As KeyEventArgs) Handles TEDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim so_cat As String = ""
            Dim typ As String = LEInvType.EditValue.ToString
            If typ = "4" Then
                so_cat = "AND so.id_so_status=3 "
            Else
                'And so.id_so_status!=3 
                so_cat = "AND so.id_so_status!=7 AND so.id_so_status!=9 "
            End If

            Dim query As String = "SELECT pldel.id_pl_sales_order_del, so.sales_order_ol_shop_number, pldel.id_store_contact_to, comp.id_comp, comp.comp_name, comp.comp_number, comp.address_primary, comp.npwp, comp.id_drawer_def, comp.comp_commission, rck.id_wh_rack, loc.id_wh_locator, sp.id_sales_pos,
            IFNULL(comp.id_acc_sales,0) AS `id_acc_sales`, IFNULL(comp.id_acc_sales_return,0) AS `id_acc_sales_return`, IFNULL(comp.id_acc_ar,0) AS `id_acc_ar`
            FROM tb_pl_sales_order_del pldel 
            INNER JOIN tb_sales_order so ON so.id_sales_order = pldel.id_sales_order "
            query += " INNER JOIN tb_m_comp_contact cc On cc.id_comp_contact=pldel.id_store_contact_to"
            query += " INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
            INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = comp.id_drawer_def 
            INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack 
            INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
            query += " LEFT JOIN tb_sales_pos sp ON sp.id_pl_sales_order_del=pldel.id_pl_sales_order_del AND sp.id_report_status !=5 "
            query += " WHERE pldel.id_report_status='6' AND pldel.pl_sales_order_del_number='" + addSlashes(TEDO.Text) + "' " + so_cat + " "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Delivery order is not found for this store.")
                TxtOLStoreNumber.Text = ""
                defaultReset()
                TEDO.Focus()
            ElseIf Not data.Rows(0)("id_sales_pos").ToString = "" Then
                stopCustom("Invoice is already created.")
                TxtOLStoreNumber.Text = ""
                defaultReset()
                TEDO.Focus()
            Else
                'id DO
                id_do = data.Rows(0)("id_pl_sales_order_del").ToString
                id_store_contact_from = data.Rows(0)("id_store_contact_to").ToString
                id_comp = data.Rows(0)("id_comp").ToString
                id_wh_locator = data.Rows(0)("id_wh_locator").ToString
                id_wh_rack = data.Rows(0)("id_wh_rack").ToString
                id_wh_drawer = data.Rows(0)("id_drawer_def").ToString
                TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompFrom.Text = data.Rows(0)("address_primary").ToString
                TENPWP.Text = data.Rows(0)("npwp").ToString
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
                PanelControlNav.Visible = False

                'isi coa
                If id_menu <> "3" And id_menu <> "4" Then
                    id_acc_sales = data.Rows(0)("id_acc_sales").ToString
                    id_acc_sales_return = data.Rows(0)("id_acc_sales_return").ToString
                    id_acc_ar = data.Rows(0)("id_acc_ar").ToString

                    'prm
                    If typ = "4" Then
                        If id_acc_ar = "0" Then
                            id_acc_ar = "52"
                        End If
                        If id_acc_sales_return = "0" Then
                            id_acc_sales_return = "1554"
                        End If
                    End If

                    viewCheckCOA(data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString)
                    If cond_coa = False Then
                        Cursor = Cursors.Default
                        is_valid_from = False
                        Exit Sub
                    End If
                End If

                ' fill GV
                view_do()
                '
                calculate()
                '
                DEDueDate.Focus()
            End If
        Else
            TxtCodeCompFrom.Text = ""
            defaultReset()
        End If
    End Sub
    Sub view_do()
        Dim query_det As String = "CALL view_pl_sales_order_del_inv('" + id_do + "', '" + LEInvType.EditValue.ToString + "')"
        Dim data_det As DataTable = execute_query(query_det, "-1", True, "", "", "", "")
        GCItemList.DataSource = data_det
    End Sub
    Sub check_do()
        id_do = "-1"
        'TEDO.Text = ""
        'If LETypeSO.EditValue.ToString = "2" Then
        '    TEDO.Visible = True
        '    BDO.Visible = True
        '    '
        '    PanelControlNav.Visible = False
        'Else
        '    TEDO.Visible = False
        '    BDO.Visible = False
        '    '
        '    PanelControlNav.Visible = True
        'End If
    End Sub

    Sub next_control_enter(e As KeyEventArgs)
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            SelectNextControl(ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub LETypeSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LETypeSO.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub DEEnd_KeyDown(sender As Object, e As KeyEventArgs) Handles DEEnd.KeyDown
        If action = "ins" Then
            If e.KeyCode = Keys.Enter Then
                If id_menu = "5" Then
                    TxtOLStoreNumber.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub DEDueDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DEDueDate.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub LEReportStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles LEReportStatus.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub SPDiscount_KeyDown(sender As Object, e As KeyEventArgs) Handles SPDiscount.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub SPVat_KeyDown(sender As Object, e As KeyEventArgs) Handles SPVat.KeyDown
        next_control_enter(e)
    End Sub

    Private Sub GCItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GCItemList.KeyDown
        If (e.KeyData = Keys.Enter) Then
            e.SuppressKeyPress = True
            BtnSave.Focus()
        End If
    End Sub

    Private Sub BDO_Click(sender As Object, e As EventArgs) Handles BDO.Click
        FormPopUpSalesDel.ShowDialog()
    End Sub

    Sub calculate()
        getDiscount()
        getNetto()
        getVat()
        getTaxBase()
    End Sub

    Private Sub DEEnd_EditValueChanged(sender As Object, e As EventArgs) Handles DEEnd.EditValueChanged
        'viewDetail()
        If action = "ins" Then
            load_kurs()

            If id_do = "-1" Then
                viewDetail()
                viewProb()
                viewDetailCode()
            End If

            'prob list
            If is_from_prob_list Then
                Dim typ As String = FormSalesPOS.LETypeProb.EditValue.ToString
                If typ = "1" Then
                    load_prob_list()
                End If
            End If
            If is_from_prob_list_no_stock Then
                load_prob_list()
            End If
            'cancel CN
            If is_from_cancel_cn Then
                loadCancelCN()
            End If
        End If
    End Sub


    Private Sub LEInvType_KeyDown(sender As Object, e As KeyEventArgs) Handles LEInvType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If LEInvType.EditValue.ToString = "0" Then
                TxtCodeCompFrom.Focus()
            Else
                TEDO.Focus()
            End If
        End If
    End Sub

    Private Sub LEInvType_EditValueChanged(sender As Object, e As EventArgs) Handles LEInvType.EditValueChanged
        If action = "ins" Then
            TEDO.Text = ""
            TxtOLStoreNumber.Text = ""
            TxtCodeCompFrom.Text = ""
            defaultReset()

            If LEInvType.EditValue.ToString = "0" Then
                TEDO.Enabled = True
                TxtCodeCompFrom.Enabled = True
                BtnBrowseContactFrom.Enabled = True
                PanelControlNav.Visible = True
            Else
                TEDO.Enabled = True
                TxtCodeCompFrom.Enabled = True
                BtnBrowseContactFrom.Enabled = True
                PanelControlNav.Visible = True
            End If
        End If
    End Sub

    Sub defaultReset()
        id_comp = "-1"
        id_store_type = "-1"
        id_wh_locator = "-1"
        id_wh_rack = "-1"
        id_wh_drawer = "-1"
        is_use_unique_code = "2"
        TxtNameCompFrom.Text = ""
        MEAdrressCompFrom.Text = ""
        TENPWP.Text = ""
        GCItemList.DataSource = Nothing
    End Sub

    Sub defaultResetBillTo()
        id_comp_bill_to = "-1"
        id_comp_contact_bill = "-1"
        TxtNameBillTo.Text = ""
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditInvType.CheckedChanged
        If action = "ins" Then
            viewDetail()
            viewProb()
            viewDetailCode()
            'activate stock take det
            If CheckEditInvType.EditValue = True Then
                DEStocktake.Enabled = True
                Dim dnow As DateTime = getTimeDB()
                DEStocktake.EditValue = dnow
            Else
                DEStocktake.Enabled = False
                DEStocktake.EditValue = Nothing
            End If
        End If
    End Sub

    Private Sub BtnBrowseBillTo_Click(sender As Object, e As EventArgs) Handles BtnBrowseBillTo.Click
        FormPopUpContact.id_pop_up = "80"
        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TxtCodeBillTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeBillTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "SELECT dr.id_wh_drawer,rack.id_wh_rack,loc.id_wh_locator,cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type, IFNULL(c.id_acc_sales,0) AS `id_acc_sales`, IFNULL(c.id_acc_sales_return,0) AS `id_acc_sales_return`, IFNULL(c.id_acc_ar,0) AS `id_acc_ar` "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeBillTo.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                defaultResetBillTo()
                TxtCodeBillTo.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "80"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeBillTo.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                'If check_acc(data.Rows(0)("id_comp").ToString) Then
                id_comp_bill_to = data.Rows(0)("id_comp").ToString
                SPDiscount.EditValue = data.Rows(0)("comp_commission")
                id_comp_contact_bill = data.Rows(0)("id_comp_contact").ToString
                TxtNameBillTo.Text = data.Rows(0)("comp_name").ToString
                TxtCodeBillTo.Text = data.Rows(0)("comp_number").ToString

                'isi COA
                If id_menu = "4" Then
                    id_acc_sales = data.Rows(0)("id_acc_sales").ToString
                    id_acc_sales_return = data.Rows(0)("id_acc_sales_return").ToString
                    id_acc_ar = data.Rows(0)("id_acc_ar").ToString
                    viewCheckCOA(data.Rows(0)("comp_number").ToString + " - " + data.Rows(0)("comp_name").ToString)
                End If

                calculate()
                check_do()
                '
                DEDueDate.Focus()
                'Else
                '    stopCustom("Store not registered for auto posting journal.")
                'End If
            End If
        Else
            defaultResetBillTo()
        End If
    End Sub

    Private Sub BtnBrowseInvoice_Click(sender As Object, e As EventArgs)
        showInv()
    End Sub

    Sub showInv()
        Cursor = Cursors.WaitCursor
        FormSalesCreditNotePopInv.id_pop_up = "4"
        FormSalesCreditNotePopInv.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnListProduct_Click(sender As Object, e As EventArgs) Handles BtnListProduct.Click
        Cursor = Cursors.WaitCursor
        FormSalesCreditNoteSingle.id_sales_pos_ref = id_sales_pos_ref
        FormSalesCreditNoteSingle.action_pop = "ins"
        FormSalesCreditNoteSingle.id_pop_up = "3"
        FormSalesCreditNoteSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportOLStore_Click(sender As Object, e As EventArgs) Handles BtnImportOLStore.Click
        Cursor = Cursors.WaitCursor
        is_load_from_bof = False
        TxtBOF.Text = ""
        If id_store_contact_from = "-1" Then
            stopCustom("Store can't blank")
        Else
            load_excel_ol_store()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtOLStoreNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOLStoreNumber.KeyDown
        If action = "ins" Then
            If e.KeyCode = Keys.Enter Then
                Dim query As String = "SELECT inv.id_sales_pos, inv.sales_pos_number, so.sales_order_ol_shop_number, inv.sales_pos_discount, inv.sales_pos_vat
                FROM tb_sales_pos_det ind
                INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ind.id_sales_pos
                INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = ind.id_pl_sales_order_del_det
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = deld.id_sales_order_det
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                WHERE so.sales_order_ol_shop_number='" + addSlashes(TxtOLStoreNumber.Text) + "' AND inv.id_report_status=6 AND inv.id_store_contact_from='" + id_store_contact_from + "'
                GROUP BY inv.id_sales_pos "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count = 1 Then
                    id_sales_pos_ref = data.Rows(0)("id_sales_pos").ToString
                    TxtInvoice.Text = data.Rows(0)("sales_pos_number").ToString
                    TxtOLStoreNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                    SPDiscount.EditValue = data.Rows(0)("sales_pos_discount")
                    SPVat.EditValue = data.Rows(0)("sales_pos_vat")
                    calculate()
                    viewDetail()
                    viewProb()
                    viewDetailCode()
                    BtnListProduct.Focus()
                ElseIf data.Rows.Count > 1 Then
                    Dim cond As String = ""
                    For i As Integer = 0 To data.Rows.Count - 1
                        If i > 0 Then
                            cond += "OR "
                        ElseIf i = 0 Then
                            cond += "AND ( "
                        End If
                        cond += "a.id_sales_pos=" + data.Rows(i)("id_sales_pos").ToString + " "
                    Next
                    If cond <> "" Then
                        cond += ") "
                    End If
                    FormSalesCreditNotePopInv.cond = cond
                    showInv()
                Else
                    stopCustom("Invoice order not found.")
                    id_sales_pos_ref = "-1"
                    TxtInvoice.Text = ""
                    TxtOLStoreNumber.Text = ""
                    SPDiscount.EditValue = 0
                    SPVat.EditValue = vat_def
                    calculate()
                    viewDetail()
                    viewProb()
                    viewDetailCode()
                End If
            Else
                id_sales_pos_ref = "-1"
                TxtInvoice.Text = ""
                SPDiscount.EditValue = 0
                SPVat.EditValue = vat_def
                calculate()
                viewDetail()
                viewProb()
                viewDetailCode()
            End If
        End If
    End Sub

    Private Sub BtnDraftJournal_Click(sender As Object, e As EventArgs) Handles BtnDraftJournal.Click
        viewDraft()
    End Sub

    Sub viewDraft()
        Cursor = Cursors.WaitCursor
        If id_report_status <> "1" Then
            FormAccountingDraftJournal.is_view = "1"
        End If
        FormAccountingDraftJournal.id_report = id_sales_pos
        FormAccountingDraftJournal.report_number = TxtVirtualPosNumber.Text
        FormAccountingDraftJournal.report_mark_type = report_mark_type
        FormAccountingDraftJournal.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 And action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                calculate()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If action = "ins" Then
            'PriceToolStripMenuItem.Visible = False
            'DeleteToolStripMenuItem.Visible = False
            'QtyToolStripMenuItem.Visible = False
        Else
            PriceToolStripMenuItem.Visible = False
            DeleteToolStripMenuItem.Visible = False
            QtyToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub PriceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceToolStripMenuItem.Click
        'If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 And action = "ins" Then
        '    FormSalesPosPrice.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
        '    FormSalesPosPrice.ShowDialog()
        '    GCItemList.RefreshDataSource()
        '    GVItemList.RefreshData()
        '    calculate()
        'End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnNoStock.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        GVItemList.ActiveFilterString = "[is_select]='Yes'"
        If GVItemList.RowCount <= 0 Then
            warningCustom("Nothing item selected")
        Else
            FormSalesPOSNoStockDet.action = "ins"
            FormSalesPOSNoStockDet.is_from_inv = "1"
            FormSalesPOSNoStockDet.ShowDialog()
        End If
        GVItemList.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtPotPenjualan_EditValueChanged(sender As Object, e As EventArgs) Handles TxtPotPenjualan.EditValueChanged
        calculate()
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        Cursor = Cursors.WaitCursor
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'copy stream column
            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnDesignPriceRetail.VisibleIndex = 2
            GridColumnNumber.VisibleIndex = 3
            GridColumnAcc.VisibleIndex = 4
            GridColumnStart.VisibleIndex = 5
            GridColumnEnd.VisibleIndex = 6
            GridColumnDueDate.VisibleIndex = 7
            GridColumnType.VisibleIndex = 8
            DEStart.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
            DEEnd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
            DEDueDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
            GVItemList.OptionsPrint.PrintFooter = False
            GVItemList.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_so + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVItemList, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try


            'show column
            GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            DEStart.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
            DEEnd.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
            DEDueDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_pos_det_qty")
                ElseIf j = 2 Then 'harga
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "design_price_retail")
                ElseIf j = 3 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtVirtualPosNumber.Text
                ElseIf j = 4 Then 'account toko
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCodeCompFrom.Text
                ElseIf j = 5 Then 'period from
                    wSheet.Cells(rowIndex + 1, colIndex) = DEStart.EditValue
                ElseIf j = 6 Then 'period end
                    wSheet.Cells(rowIndex + 1, colIndex) = DEEnd.EditValue
                ElseIf j = 7 Then 'due date
                    wSheet.Cells(rowIndex + 1, colIndex) = DEDueDate.EditValue
                ElseIf j = 8 Then 'type
                    If CheckEditInvType.EditValue = False Then
                        wSheet.Cells(rowIndex + 1, colIndex) = "1"
                    Else
                        wSheet.Cells(rowIndex + 1, colIndex) = "2"
                    End If
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Private Sub QtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QtyToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        FormSalesPOSQty.action = "upd"
        FormSalesPOSQty.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub Btn_Click(sender As Object, e As EventArgs) Handles BtnImportOLStoreNew.Click
        Cursor = Cursors.WaitCursor
        is_load_from_bof = False
        TxtBOF.Text = ""
        If id_store_contact_from = "-1" Then
            stopCustom("Store can't blank")
        Else
            load_excel_ol_store_det()
            calculate()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVCode_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVCode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnExportToReport_Click(sender As Object, e As EventArgs) Handles BtnExportToReport.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCItemList, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLoadPOS_Click(sender As Object, e As EventArgs) Handles BtnLoadPOS.Click
        Cursor = Cursors.WaitCursor
        is_load_from_bof = False
        TxtBOF.Text = ""
        load_data_pos()
        calculate()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSelectDiscount_Click(sender As Object, e As EventArgs) Handles BtnSelectDiscount.Click
        Cursor = Cursors.WaitCursor
        If id_menu = "4" Then
            FormSalesPOSDiscount.id_comp = id_comp_bill_to
        Else
            FormSalesPOSDiscount.id_comp = id_comp
        End If
        FormSalesPOSDiscount.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Dim is_load_from_bof As Boolean = False
    Dim data_bof_main As New DataTable
    Private Sub BtnLoadFromBOF_Click(sender As Object, e As EventArgs) Handles BtnLoadFromBOF.Click
        Cursor = Cursors.WaitCursor
        is_load_from_bof = True

        'reset
        Try
            data_bof_main.Clear()
        Catch ex As Exception
        End Try

        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim bof_xls_path As String = get_setup_field("bof_xls_bill_bof_path")
        Dim bof_xls_ws As String = get_setup_field("bof_xls_bill_bof_worksheet")

        'find store
        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & bof_xls_path & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter
        MyCommand = New OleDbDataAdapter("select top 1 * from [" & bof_xls_ws & "] ", oledbconn)
        MyCommand.Fill(data_bof_main)
        MyCommand.Dispose()
        TxtCodeCompFrom.Text = data_bof_main.Rows(0)(4).ToString
        actionCompFrom()
        If is_valid_from = False Then
            'jika gak valid codenya
            Cursor = Cursors.Default
            Exit Sub
        End If

        'fill date & type & number
        DEDueDate.EditValue = data_bof_main.Rows(0)(7)
        DEStart.EditValue = data_bof_main.Rows(0)(5)
        DEEnd.EditValue = data_bof_main.Rows(0)(6)
        If data_bof_main.Rows(0)(8).ToString = "2" Then
            CheckEditInvType.EditValue = True
        End If
        TxtBOF.Text = data_bof_main.Rows(0)(3).ToString
        If data_bof_main.Rows(0)(10).ToString = "" Then
            DEBOF.EditValue = Nothing
        Else
            DEBOF.EditValue = data_bof_main.Rows(0)(10)
        End If

        'detail
        viewStockStore()
        Dim data_temp As New DataTable
        MyCommand = New OleDbDataAdapter("select kode as code,SUM(qty) as qty,'' AS price from [" & bof_xls_ws & "] WHERE qty>0 AND NOT kode IS NULL AND NOT qty  IS NULL GROUP BY kode", oledbconn)
        MyCommand.Fill(data_temp)
        MyCommand.Dispose()
        checkSOH(data_temp)
        calculate()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLoadFromReturnCentre_Click(sender As Object, e As EventArgs) Handles BtnLoadFromReturnCentre.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_product,p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        '' AS `color`, 1 AS `sales_pos_det_qty`, id.id_design_price_retail, pt.design_price_type, id.design_price_retail,
        id.id_design_price, id.design_price, p.id_design, 0 AS `id_sample`, id.id_sales_pos_det AS `id_sales_pos_det_ref`, l. id_ol_store_ret_list, 'OK' AS `note`
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
        INNER JOIN tb_m_product p ON p.id_product = id.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = id.id_design_price_retail
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        WHERE l.id_ol_store_ret_stt=6 AND c.id_comp=" + id_comp + " AND  r.sales_order_ol_shop_number='" + order_number + "' AND i.id_sales_pos=" + id_sales_pos_ref + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        calculate()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=" + report_mark_type + " AND ad.id_report=" + id_sales_pos + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            FormViewJournal.show_trans_number = True
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub load_kurs()
        If action = "ins" Then
            Cursor = Cursors.WaitCursor
            'check kurs first
            Dim end_period As String = "1991-01-01"
            Try
                end_period = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Dim query_kurs As String = "SELECT * FROM tb_kurs_trans a WHERE DATE(a.created_date) <= '" + end_period + "' ORDER BY a.created_date DESC LIMIT 1"
            Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

            If Not data_kurs.Rows.Count > 0 Then
                warningCustom("Get kurs error.")
                TEKurs.EditValue = 0.00
            Else
                TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnGetKurs_Click(sender As Object, e As EventArgs) Handles BtnGetKurs.Click
        load_kurs()
    End Sub

    Private Sub SBBrowseInvoice_Click(sender As Object, e As EventArgs) Handles SBBrowseInvoice.Click
        If Not id_comp = "-1" Then
            FormSalesPOSBrowseInvoice.ShowDialog()
        Else
            stopCustom("Please select store.")
        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub GVProbList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVProbList.RowCellStyle
        If e.Column.FieldName = "note_price" Then
            Dim note As String = ""
            Try
                note = GVProbList.GetRowCellValue(e.RowHandle, "note_price").ToString
            Catch ex As Exception
            End Try
            If note <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        ElseIf e.Column.FieldName = "no_stock_qty" Then
            Dim oos As String = ""
            Try
                oos = GVProbList.GetRowCellValue(e.RowHandle, "no_stock_qty")
            Catch ex As Exception
            End Try
            If oos > 0 Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            End If
        End If
    End Sub

    Sub load_prob_list()
        If is_from_prob_list Then
            viewDetail()

            Dim id_type_prob As String = FormSalesPOS.LETypeProb.EditValue.ToString
            If id_type_prob = "1" Then
                'price recon
                For i As Integer = 0 To FormSalesPOS.GVProbList.RowCount - 1
                    Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                    newRow("code") = FormSalesPOS.GVProbList.GetRowCellValue(i, "code").ToString
                    newRow("name") = FormSalesPOS.GVProbList.GetRowCellValue(i, "name").ToString
                    newRow("size") = FormSalesPOS.GVProbList.GetRowCellValue(i, "size").ToString
                    newRow("sales_pos_det_qty") = FormSalesPOS.GVProbList.GetRowCellValue(i, "invoice_qty")
                    newRow("sales_pos_det_amount") = FormSalesPOS.GVProbList.GetRowCellValue(i, "invoice_qty") * FormSalesPOS.GVProbList.GetRowCellValue(i, "design_price_valid")
                    newRow("limit_qty") = FormSalesPOS.GVProbList.GetRowCellValue(i, "invoice_qty")
                    newRow("id_design_price") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_design_price_valid").ToString
                    newRow("design_price") = FormSalesPOS.GVProbList.GetRowCellValue(i, "design_price_valid")
                    newRow("design_price_type") = FormSalesPOS.GVProbList.GetRowCellValue(i, "design_price_type_valid").ToString
                    newRow("id_design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_design_price_valid").ToString
                    newRow("design_price_retail") = FormSalesPOS.GVProbList.GetRowCellValue(i, "design_price_valid")
                    newRow("id_design") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_design").ToString
                    newRow("id_product") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_product").ToString
                    newRow("is_select") = "No"
                    newRow("note") = "OK"
                    newRow("id_sales_pos_det") = "0"
                    newRow("id_sales_pos_prob") = "0"
                    newRow("id_sales_pos_prob_price") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_sales_pos_prob").ToString
                    newRow("id_sales_pos_oos_recon_det") = "0"
                    TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                    calculate()
                Next
            ElseIf id_type_prob = "2" Then
                'check stock take det
                If CheckEditInvType.EditValue = True And DEStocktake.EditValue = Nothing Then
                    stopCustom("Please fill stock take date")
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                'no stock
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                For i As Integer = 0 To FormSalesPOS.GVProbList.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Checking item price " + (i + 1).ToString + "/" + FormSalesPOS.GVProbList.RowCount.ToString)
                    Dim id_design As String = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_design").ToString
                    Dim dt_prc As DataTable
                    If CheckEditInvType.EditValue = True Then
                        'missing
                        Dim price_per_date As String = ""
                        If id_store_type = "1" Then
                            'normal acc
                            Dim query_price As String = "call view_product_price_normal('AND d.id_active=1 AND d.id_design=" + id_design + " ') "
                            dt_prc = execute_query(query_price, -1, True, "", "", "", "")
                        Else
                            'sale acc
                            price_per_date = DateTime.Parse(DEStocktake.EditValue.ToString).ToString("yyyy-MM-dd")
                            Dim query_price As String = "call view_product_price('AND d.id_active = 1  AND d.id_design=" + id_design + "', '" + price_per_date + "') "
                            dt_prc = execute_query(query_price, -1, True, "", "", "", "")
                        End If
                    Else
                        'sales
                        Dim price_per_date As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                        Dim query_price As String = "call view_product_price('AND d.id_active = 1 AND d.id_design=" + id_design + "', '" + price_per_date + "') "
                        dt_prc = execute_query(query_price, -1, True, "", "", "", "")
                    End If

                    Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                    newRow("code") = FormSalesPOS.GVProbList.GetRowCellValue(i, "code").ToString
                    newRow("name") = FormSalesPOS.GVProbList.GetRowCellValue(i, "name").ToString
                    newRow("size") = FormSalesPOS.GVProbList.GetRowCellValue(i, "size").ToString
                    newRow("sales_pos_det_qty") = FormSalesPOS.GVProbList.GetRowCellValue(i, "qty_new")
                    newRow("sales_pos_det_amount") = FormSalesPOS.GVProbList.GetRowCellValue(i, "qty_new") * dt_prc.Rows(0)("design_price")
                    newRow("limit_qty") = FormSalesPOS.GVProbList.GetRowCellValue(i, "qty_new")
                    newRow("id_design_price") = dt_prc.Rows(0)("id_design_price").ToString
                    newRow("design_price") = dt_prc.Rows(0)("design_price")
                    newRow("design_price_type") = dt_prc.Rows(0)("design_price_type").ToString
                    newRow("id_design_price_retail") = dt_prc.Rows(0)("id_design_price").ToString
                    newRow("design_price_retail") = dt_prc.Rows(0)("design_price")
                    newRow("id_design") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_design").ToString
                    newRow("id_product") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_product").ToString
                    newRow("is_select") = "No"
                    newRow("note") = "OK"
                    newRow("id_sales_pos_det") = "0"
                    newRow("id_sales_pos_prob") = FormSalesPOS.GVProbList.GetRowCellValue(i, "id_sales_pos_prob").ToString
                    newRow("id_sales_pos_prob_price") = "0"
                    newRow("id_sales_pos_oos_recon_det") = "0"
                    TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                    calculate()
                Next
                FormMain.SplashScreenManager1.CloseWaitForm()
            End If
        End If

        If is_from_prob_list_no_stock Then
            ' new item from no stock
            viewDetail()
            For i As Integer = 0 To FormSalesPOS.GVNewItem.RowCount - 1
                Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                newRow("code") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "code_valid").ToString
                newRow("name") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "name_valid").ToString
                newRow("size") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "size_valid").ToString
                newRow("sales_pos_det_qty") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "qty_valid")
                newRow("sales_pos_det_amount") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "qty_valid") * FormSalesPOS.GVNewItem.GetRowCellValue(i, "design_price_valid")
                newRow("limit_qty") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "qty_valid")
                newRow("id_design_price") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "id_design_price_valid").ToString
                newRow("design_price") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "design_price_valid")
                newRow("design_price_type") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "design_price_type_valid").ToString
                newRow("id_design_price_retail") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "id_design_price_valid").ToString
                newRow("design_price_retail") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "design_price_valid")
                newRow("id_design") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "id_design_valid").ToString
                newRow("id_product") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "id_product_valid").ToString
                newRow("is_select") = "No"
                newRow("note") = "OK"
                newRow("id_sales_pos_det") = "0"
                newRow("id_sales_pos_prob") = "0"
                newRow("id_sales_pos_prob_price") = "0"
                newRow("id_sales_pos_oos_recon_det") = FormSalesPOS.GVNewItem.GetRowCellValue(i, "id_sales_pos_oos_recon_det").ToString
                TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                calculate()
            Next
        End If
    End Sub

    Private Sub BtnLoadFromProbList_Click(sender As Object, e As EventArgs) Handles BtnLoadFromProbList.Click
        If is_from_prob_list Or is_from_prob_list_no_stock Then
            load_prob_list()
        End If
        If is_from_cancel_cn Then
            loadCancelCN()
        End If
    End Sub

    Private Sub ViewPriceReconcileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewPriceReconcileToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim id_sales_pos_prob_price As String = "-1"
        Try
            id_sales_pos_prob_price = GVItemList.GetFocusedRowCellValue("id_sales_pos_prob_price")
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT IFNULL(r.id_sales_pos_recon,0) AS `id_sales_pos_recon`
FROM tb_sales_pos_recon_det rd
INNER JOIN tb_sales_pos_recon r ON r.id_sales_pos_recon = rd.id_sales_pos_recon
WHERE rd.id_sales_pos_prob=" + id_sales_pos_prob_price + " AND r.id_report_status=6
GROUP BY r.id_sales_pos_recon "
        Try
            Dim id_report As String = execute_query(query, 0, True, "", "", "", "")
            Dim m As New ClassShowPopUp()
            m.id_report = id_report
            m.report_mark_type = "281"
            m.show()
        Catch ex As Exception
            stopCustom("Price recon not found.")
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrintPL_Click(sender As Object, e As EventArgs) Handles SBPrintPL.Click
        ReportSalesInvoiceProblemList.id_sales_pos = id_sales_pos
        ReportSalesInvoiceProblemList.id_report_status = id_report_status
        ReportSalesInvoiceProblemList.rmt = report_mark_type
        ReportSalesInvoiceProblemList.data = GCProbList.DataSource
        Dim Report As New ReportSalesInvoiceProblemList()
        'Report.LabelTitle.Text = print_title
        Report.XLOLStoreNumber3.Text = TxtOLStoreNumber.Text
        Report.XLName3.Text = TXTName.Text

        'if volcom online store
        Dim is_volcom_online As String = execute_query("SELECT COUNT(*) AS total FROM tb_m_comp_volcom_ol WHERE id_store = " + id_comp, 0, True, "", "", "", "")

        If Not is_volcom_online = "0" Then
            Report.XLName1.Visible = True
            Report.XLName2.Visible = True
            Report.XLName3.Visible = True
            Report.XLOLStoreNumber1.Visible = True
            Report.XLOLStoreNumber2.Visible = True
            Report.XLOLStoreNumber3.Visible = True
        Else
            Report.XLName1.Visible = False
            Report.XLName2.Visible = False
            Report.XLName3.Visible = False
            Report.XLOLStoreNumber1.Visible = False
            Report.XLOLStoreNumber2.Visible = False
            Report.XLOLStoreNumber3.Visible = False
        End If

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub GVProbList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProbList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ViewClosingNoStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewClosingNoStockToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim id_sales_pos_oos_recon_det As String = "-1"
        Try
            id_sales_pos_oos_recon_det = GVItemList.GetFocusedRowCellValue("id_sales_pos_oos_recon_det").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT IFNULL(r.id_sales_pos_oos_recon,0) AS `id_sales_pos_oos_recon`
        FROM tb_sales_pos_oos_recon_det rd
        INNER JOIN tb_sales_pos_oos_recon r ON r.id_sales_pos_oos_recon = rd.id_sales_pos_oos_recon
        WHERE rd.id_sales_pos_oos_recon_det=" + id_sales_pos_oos_recon_det + " AND r.id_report_status=6
        GROUP BY r.id_sales_pos_oos_recon "
        Try
            Dim id_report As String = execute_query(query, 0, True, "", "", "", "")
            Dim m As New ClassShowPopUp()
            m.id_report = id_report
            m.report_mark_type = "283"
            m.show()
        Catch ex As Exception
            stopCustom("Closing no stock not found.")
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub loadCancelCN()
        If is_from_cancel_cn Then
            viewDetail()
            Dim query As String = "SELECT p.id_product, p.id_design,p.product_full_code AS `code`, p.product_display_name AS `name`, cd.display_name AS `size`, d.qty,
            d.id_design_price, d.design_price, pt.design_price_type,d.id_sales_pos_det_cn, d.id_return_refuse_det
            FROM tb_ol_store_return_refuse_det d
            INNER JOIN tb_m_product p ON p.id_product = d.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design_price prc ON prc.id_design_price = d.id_design_price
            INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
            WHERE d.id_return_refuse='" + id_return_refuse + "' AND !ISNULL(d.id_sales_pos_det_cn) "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            For i As Integer = 0 To data.Rows.Count - 1
                Dim qty As Integer = data.Rows(i)("qty")
                Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                newRow("code") = data.Rows(i)("code").ToString
                newRow("name") = data.Rows(i)("name").ToString
                newRow("size") = data.Rows(i)("size").ToString
                newRow("sales_pos_det_qty") = qty
                newRow("sales_pos_det_amount") = qty * data.Rows(i)("design_price")
                newRow("limit_qty") = qty
                newRow("id_design_price") = data.Rows(i)("id_design_price").ToString
                newRow("design_price") = data.Rows(i)("design_price")
                newRow("design_price_type") = data.Rows(i)("design_price_type").ToString
                newRow("id_design_price_retail") = data.Rows(i)("id_design_price").ToString
                newRow("design_price_retail") = data.Rows(i)("design_price")
                newRow("id_design") = data.Rows(i)("id_design").ToString
                newRow("id_product") = data.Rows(i)("id_product").ToString
                newRow("is_select") = "No"
                newRow("note") = "OK"
                newRow("id_sales_pos_det") = "0"
                newRow("id_sales_pos_prob") = "0"
                newRow("id_sales_pos_prob_price") = "0"
                newRow("id_sales_pos_oos_recon_det") = "0"
                newRow("id_cn_det") = data.Rows(i)("id_sales_pos_det_cn").ToString
                newRow("id_return_refuse_det") = data.Rows(i)("id_return_refuse_det").ToString
                TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                calculate()
            Next
        End If
    End Sub
End Class