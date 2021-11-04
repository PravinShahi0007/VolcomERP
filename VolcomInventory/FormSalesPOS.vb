﻿Public Class FormSalesPOS
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim current_year As String

    'selected-Tab1
    Public id_store_selected As String = "-1"
    Public label_store_selected As String = "-1"
    Public date_from_selected As String = "0000-01-01"
    Public date_until_selected As String = "9999-12-01"
    Public label_type_selected As String = "1"
    Public dt As DataTable
    Dim tgl_sekarang As Date

    'menu : 1=invoice 2=credit note
    Public id_menu As String = "1"

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSalesPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'General
        'Dim query_curr_year As String = "SELECT YEAR(NOW())"
        'current_year = execute_query(query_curr_year, 0, True, "", "", "", "")
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCInvoice.TabPages
            XTCInvoice.SelectedTabPage = t
        Next t
        XTCInvoice.SelectedTabPage = XTCInvoice.TabPages(0)

        'setting menu
        If id_menu = "1" Then
            Text = "Invoice"
        ElseIf id_menu = "2" Then
            Text = "Credit Note"
        ElseIf id_menu = "3" Then
            Text = "Invoice Missing Promo"
        ElseIf id_menu = "4" Then
            Text = "Invoice Different Margin"
        ElseIf id_menu = "5" Then
            Text = "Credit Note Online Store"
        ElseIf id_menu = "6" Then
            Text = "Cancellation CN"
        End If

        'Tab Daily
        viewStore()
        viewOption()
        DEFrom.DateTime = Now
        DEUntil.DateTime = Now
        viewSalesPOS()
        viewTypeProb()
        viewReconStt()
        viewInvoiceStt()
        viewNoStockStt()
        viewReturnRefuseStt()
        viewStoreProb()

        'pending online store return
        If id_menu = "5" Then
            XTPCNOnlineStore.PageVisible = True
            XTPProblemList.PageVisible = False
            XTPOLReturnRefuse.PageVisible = False
            XTPBAP.PageVisible = False
            viewPendingCNOLStore()
        ElseIf id_menu = "1" Or id_menu = "4" Then
            XTPCNOnlineStore.PageVisible = False
            XTPProblemList.PageVisible = True
            XTPOLReturnRefuse.PageVisible = False
            XTPBAP.PageVisible = True
        ElseIf id_menu = "6" Then
            XTPCNOnlineStore.PageVisible = False
            XTPProblemList.PageVisible = False
            XTPOLReturnRefuse.PageVisible = True
            XTPBAP.PageVisible = False
        Else
            XTPCNOnlineStore.PageVisible = False
            XTPProblemList.PageVisible = False
            XTPBAP.PageVisible = False
        End If

        'now time
        tgl_sekarang = getTimeDB()
    End Sub

    Sub viewTypeProb()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_type`, 'Invalid Price' AS `type`
        UNION ALL
        SELECT '2' AS `id_type`, 'No Stock' AS `type` "
        viewLookupQuery(LETypeProb, query, 0, "type", "id_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewReconStt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_recon_stt`, 'All' AS `recon_stt`
        UNION ALL
        SELECT '1' AS `id_recon_stt`, 'Open' AS `recon_stt`
        UNION ALL
        SELECT '2' AS `id_recon_stt`, 'Close' AS `recon_stt` "
        viewLookupQuery(LEReconStatus, query, 0, "recon_stt", "id_recon_stt")
        Cursor = Cursors.Default
    End Sub

    Sub viewInvoiceStt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_inv_stt`, 'All' AS `inv_stt`
        UNION ALL
        SELECT '1' AS `id_inv_stt`, 'Open' AS `inv_stt`
        UNION ALL
        SELECT '2' AS `id_inv_stt`, 'Close' AS `inv_stt` "
        viewLookupQuery(LEInvoiceStt, query, 1, "inv_stt", "id_inv_stt")
        Cursor = Cursors.Default
    End Sub

    Sub viewNoStockStt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_stt`, 'All' AS `stt`
        UNION ALL
        SELECT '1' AS `id_stt`, 'Open' AS `stt`
        UNION ALL
        SELECT '2' AS `id_stt`, 'Close' AS `stt` "
        viewLookupQuery(LENoStockStatus, query, 0, "stt", "id_stt")
        viewLookupQuery(LESttNewItem, query, 0, "stt", "id_stt")
        Cursor = Cursors.Default
    End Sub

    Sub viewReturnRefuseStt()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '0' AS `id_stt`, 'All' AS `stt`
        UNION ALL
        SELECT '1' AS `id_stt`, 'Open' AS `stt`
        UNION ALL
        SELECT '2' AS `id_stt`, 'Close' AS `stt` "
        viewLookupQuery(LEStatusRefuseReturn, query, 1, "stt", "id_stt")
        Cursor = Cursors.Default
    End Sub

    Sub viewStoreProb()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_comp`, 'All' AS `comp`
        UNION ALL 
        SELECT c.id_comp, CONCAT(c.comp_number,' - ',c.comp_name) AS `comp` 
        FROM tb_m_comp c
        WHERE c.id_comp_cat=6 "
        viewSearchLookupQuery(SLEStoreProb, query, "id_comp", "comp", "id_comp")
        viewSearchLookupQuery(SLEStoreNoStock, query, "id_comp", "comp", "id_comp")
        viewSearchLookupQuery(SLEStoreNewItem, query, "id_comp", "comp", "id_comp")
        viewSearchLookupQuery(SLEStoreRefuseReturn, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    '========= TAB DAILY TRANSACTION==========================================
    Sub viewSalesPOS()
        Try
            Dim query_c As ClassSalesInv = New ClassSalesInv()
            Dim query As String = ""
            If id_menu = "1" Then
                query = query_c.queryMain("And (a.id_memo_type=''1'' OR a.id_memo_type=''3'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "2" Then
                query = query_c.queryMain("AND (a.id_memo_type=''2'' OR a.id_memo_type=''4'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "3" Then
                query = query_c.queryMain("AND (a.id_memo_type=''5'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "4" Then
                query = query_c.queryMain("AND (a.id_memo_type=''8'' OR a.id_memo_type=''9'') AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "5" Then
                query = query_c.queryMain("AND a.id_memo_type=''2'' AND !ISNULL(a.id_sales_pos_ref) AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            ElseIf id_menu = "6" Then
                query = query_c.queryMain("And a.id_memo_type=''10'' AND c.id_comp LIKE ''" + id_store_selected + "'' AND (a.sales_pos_end_period >=''" + date_from_selected + "'' AND a.sales_pos_end_period <=''" + date_until_selected + "'') ", "2")
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSalesPOS.DataSource = data
            dt = data
            check_menu()
            GVSalesPOS.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Function CreateData() As DataTable
        Dim query As String = ""
        query += "SELECT f.so_type, a.id_report_status, a.id_sales_pos, a.sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (CONCAT_WS(' - ', c.comp_number, c.comp_name)) AS store_name_from, d.report_status, e.sales_pos_det_qty, a.sales_pos_total, a.sales_pos_discount, "
        query += "a.sales_pos_due_date, a.sales_pos_total, a.sales_pos_vat, "
        query += "CONCAT_WS(' - ', DATE_FORMAT(a.sales_pos_start_period, '%d %M %Y') ,DATE_FORMAT(a.sales_pos_end_period, '%d %M %Y')) AS sales_pos_period, "
        query += "CAST(((a.sales_pos_total - ((a.sales_pos_discount/100) * a.sales_pos_total))) AS DECIMAL(13,2)) AS sales_pos_netto, "
        query += "CAST(((100/(100+a.sales_pos_vat))*(a.sales_pos_total-((a.sales_pos_discount/100)*a.sales_pos_total))) AS DECIMAL(13,2)) AS sales_pos_revenue, "
        query += "(IF(a.id_report_status='5' OR a.id_report_status ='6', '-', IF(DATEDIFF(NOW(), a.sales_pos_due_date)<=0, DATEDIFF(NOW(), a.sales_pos_due_date),CONCAT('+', DATEDIFF(NOW(), a.sales_pos_due_date))))) AS sales_pos_age "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "INNER JOIN ( "
        query += "SELECT pos_det.id_sales_pos, SUM(pos_det.sales_pos_det_qty) AS sales_pos_det_qty FROM tb_sales_pos_det pos_det GROUP BY pos_det.id_sales_pos "
        query += ") e ON e.id_sales_pos = a.id_sales_pos "
        query += "INNER JOIN tb_lookup_so_type f ON f.id_so_type = a.id_so_type "
        query += "WHERE c.id_comp LIKE '" + id_store_selected + "' AND (a.sales_pos_end_period >='" + date_from_selected + "' AND a.sales_pos_end_period <='" + date_until_selected + "') "
        query += "AND a.id_memo_type='1' "
        query += "ORDER BY a.id_sales_pos ASC "
        Dim dtm As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim date_from_selectedx As String = "0001-01-01"
        If date_from_selected = "0000-01-01" Then
            date_from_selectedx = "0001-01-01"
        Else
            date_from_selectedx = date_from_selected
        End If

        'MsgBox(date_from_selected.ToString)
        If label_type_selected = "1" Then
            query = "CALL view_sales_pos('0')"
            Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
            dtd_temp.DefaultView.RowFilter = "id_comp LIKE '" + id_store_selected + "' AND (sales_pos_end_period >=#" + date_from_selectedx + "# AND sales_pos_end_period <=#" + date_until_selected + "#) "
            Dim dtd As DataTable = dtd_temp.DefaultView.ToTable
            Dim ds As New DataSet()
            ds.Tables.AddRange(New DataTable() {dtm, dtd})
            ds.Relations.Add("Detail Transaction", dtm.Columns("id_sales_pos"), dtd.Columns("id_sales_pos"))
        End If
        Return dtm
    End Function

    Sub viewPendingCNOLStore()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT so.sales_order_ol_shop_number AS `order_number`, so.customer_name, c.comp_number, c.comp_name
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order 
        LEFT JOIN (
	        SELECT spd.id_ol_store_ret_list FROM tb_sales_pos_det spd
	        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	        WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_ol_store_ret_list)
	        GROUP BY spd.id_ol_store_ret_list
        ) e ON e.id_ol_store_ret_list = l.id_ol_store_ret_list 
        WHERE l.id_ol_store_ret_stt=6 AND ISNULL(e.id_ol_store_ret_list)
        GROUP BY c.id_comp, so.sales_order_ol_shop_number "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPendingCN.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        If XTCPOS.SelectedTabPageIndex = 0 Then
            If GVSalesPOS.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                'noManipulating()
            End If
        End If
    End Sub

    Sub viewStore()
        Dim query As String = getQueryStore()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_store_selected = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEStore.Properties.DataSource = Nothing
        SLEStore.Properties.DataSource = data
        SLEStore.Properties.DisplayMember = "comp_name_label"
        SLEStore.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEStore.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor

        'hide/show expand
        'label_type_selected = LEOptionView.EditValue.ToString
        'If label_type_selected = "1" Then
        '    BExpand.Visible = True
        '    BHide.Visible = True
        'Else
        '    BExpand.Visible = False
        '    BHide.Visible = False
        'End If

        'Prepare paramater
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            id_store_selected = SLEStore.EditValue.ToString
        Catch ex As Exception
        End Try

        'modify value
        If id_store_selected = "0" Then
            label_store_selected = "All Store"
            id_store_selected = "%%"
        Else
            label_store_selected = SLEStore.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        viewSalesPOS()
        Cursor = Cursors.Default
    End Sub

    Sub viewOption()
        Dim query As String = getOptionView()
        viewLookupQuery(LEOptionView, query, 0, "option_view", "id_option_view")
    End Sub

    Public Sub ExpandAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Public Sub HideAllRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, False)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub BExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BExpand.Click
        ExpandAllRows(GVSalesPOS)
    End Sub

    Private Sub BHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BHide.Click
        HideAllRows(GVSalesPOS)
    End Sub

    Private Sub GVSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesPOSDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesPOSDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnNoStock_Click(sender As Object, e As EventArgs) Handles BtnNoStock.Click
        Cursor = Cursors.WaitCursor
        If id_departement_user = "14" Then 'IA
            FormSalesPOSNoStock.id_menu = "2"
        Else
            FormSalesPOSNoStock.id_menu = "1"
        End If
        FormSalesPOSNoStock.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesPOS_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesPOS.DoubleClick
        If GVSalesPOS.RowCount > 0 And GVSalesPOS.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            If FormMain.BBEdit.Enabled = False Then
                FormViewSalesPOS.id_sales_pos = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormViewSalesPOS.ShowDialog()
            Else
                FormMain.but_edit()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnViewProb.Click
        viewProbList()
    End Sub

    Sub viewProbList()
        Cursor = Cursors.WaitCursor
        'type
        Dim cond_type As String = ""
        If LETypeProb.EditValue.ToString = "1" Then
            cond_type = "AND p.is_invalid_price=1 "
        ElseIf LETypeProb.EditValue.ToString = "2" Then
            cond_type = "AND p.is_no_stock=1 "
        Else
            cond_type = ""
        End If

        'recon status
        Dim cond_recon As String = ""
        If LEReconStatus.EditValue.ToString = "1" Then
            cond_recon = "AND ISNULL(id_design_price_valid) "
        ElseIf LEReconStatus.EditValue.ToString = "2" Then
            cond_recon = "AND !ISNULL(id_design_price_valid) "
        Else
            cond_recon = ""
        End If

        'invoice status
        Dim cond_status As String = ""
        If LEInvoiceStt.EditValue.ToString = "1" Then
            cond_status = "AND p.invoice_qty!=IFNULL(proc_prc.qty_proceed,0) "
        ElseIf LEInvoiceStt.EditValue.ToString = "2" Then
            cond_status = "AND p.invoice_qty=IFNULL(proc_prc.qty_proceed,0) "
        Else
            cond_status = ""
        End If

        'store
        Dim cond_store As String = ""
        If SLEStoreProb.EditValue.ToString <> "0" Then
            cond_store = "AND c.id_comp='" + SLEStoreProb.EditValue.ToString + "' "
        End If

        'period
        Dim cond_period As String = ""
        If CEPeriod.EditValue = False Then
            Dim date_from_selected As String = "0000-01-01"
            Dim date_until_selected As String = "9999-01-01"
            Try
                date_from_selected = DateTime.Parse(DEPeriodFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Try
                date_until_selected = DateTime.Parse(DEPeriodUntil.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            cond_period = "AND (sp.sales_pos_end_period>='" + date_from_selected + "' AND sp.sales_pos_end_period<='" + date_until_selected + "') "
        End If


        Dim query As String = "SELECT p.id_sales_pos_prob, 
        p.id_sales_pos, sp.sales_pos_number, sp.sales_pos_start_period, sp.sales_pos_end_period, sp.sales_pos_due_date, sp.report_mark_type AS `rmt_inv`,
        c.id_comp, cc.id_comp_contact, c.comp_number, c.comp_name, cg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`,
        p.is_invalid_price, p.is_no_stock, 
        p.id_product, prod.id_design, prod.product_full_code AS `code`, prod.product_name AS `name`, cd.display_name AS `size`,
        p.id_design_price_retail, p.design_price_retail, p.design_price_store, 
        IFNULL(p.id_design_price_valid,0) AS `id_design_price_valid`, p.design_price_valid, dpt.design_price_type AS `design_price_type_valid`,
        p.store_qty, 
        p.invoice_qty, IFNULL(proc_prc.qty_on_process,0) AS `qty_on_process_price`, IFNULL(proc_prc.qty_proceed,0) AS `qty_proceed_price`,
        IFNULL(proc_cs.qty_on_process,0) AS `qty_on_process_cancel`, IFNULL(proc_cs.qty_proceed,0) AS `qty_proceed_cancel`,
        p.no_stock_qty, 0 AS `qty_on_process`, 0 AS `qty_proceed`,
        (p.invoice_qty+p.no_stock_qty) AS `total_qty`,
        'No' AS `is_select`, 0 AS `qty_new`,
        IF(p.invoice_qty=IFNULL(proc_prc.qty_proceed,0)+IFNULL(proc_cs.qty_proceed,0),'Close','Open') AS `is_open_invoice_view`
        From tb_sales_pos_prob p
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price dp ON dp.id_design_price = p.id_design_price_valid
        LEFT JOIN tb_lookup_design_price_type dpt ON dpt.id_design_price_type = dp.id_design_price_type
        LEFT JOIN (
            SELECT spd.id_sales_pos_prob_price, 
            SUM(IF(sp.id_report_status<5,spd.sales_pos_det_qty,0)) AS `qty_on_process`,
            SUM(IF(sp.id_report_status=6,spd.sales_pos_det_qty,0)) AS `qty_proceed`
            FROM tb_sales_pos sp
            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
            WHERE !ISNULL(spd.id_sales_pos_prob_price)
            GROUP BY spd.id_sales_pos_prob_price
        ) proc_prc ON proc_prc.id_sales_pos_prob_price = p.id_sales_pos_prob
        LEFT JOIN (
            SELECT spd.id_sales_pos_prob, 
            SUM(IF(sp.id_report_status<5,p.invoice_qty,0)) AS `qty_on_process`,
            SUM(IF(sp.id_report_status=6,p.invoice_qty,0)) AS `qty_proceed`
            FROM tb_sales_pos_recon sp
            INNER JOIN tb_sales_pos_recon_det spd ON spd.id_sales_pos_recon = sp.id_sales_pos_recon
            INNER JOIN tb_sales_pos_prob p ON p.id_sales_pos_prob = spd.id_sales_pos_prob
            WHERE !ISNULL(spd.id_sales_pos_prob) AND sp.is_cancel_sales=1 
            GROUP BY spd.id_sales_pos_prob
        ) proc_cs ON proc_cs.id_sales_pos_prob = p.id_sales_pos_prob
        WHERE 1=1 AND sp.id_report_status=6 " + cond_recon + cond_status + cond_period + cond_type + cond_store
        query += "HAVING 1=1 "
        query += "ORDER BY id_sales_pos ASC,name ASC, code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProbList.DataSource = data
        GVProbList.BestFitColumns()
        GVProbList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCInvoice_Click(sender As Object, e As EventArgs) Handles XTCInvoice.Click

    End Sub

    Private Sub LEInvoiceStt_EditValueChanged(sender As Object, e As EventArgs) Handles LEInvoiceStt.EditValueChanged
        If LEInvoiceStt.EditValue.ToString = "1" Then
            BtnCreateInvoice.Visible = True
        Else
            BtnCreateInvoice.Visible = False
        End If
        resetViewProb()
    End Sub

    Sub resetViewProb()
        Cursor = Cursors.WaitCursor
        GCProbList.DataSource = Nothing
        Cursor = Cursors.Default
    End Sub

    Sub resetViewNoStockList()
        Cursor = Cursors.WaitCursor
        GCNoStock.DataSource = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub LETypeProb_EditValueChanged(sender As Object, e As EventArgs) Handles LETypeProb.EditValueChanged
        If LETypeProb.EditValue.ToString = "2" Then
            gridBandPrice.Visible = False
            gridBandNoStock.Visible = True
        Else
            gridBandPrice.Visible = True
            gridBandNoStock.Visible = False
        End If
        resetViewProb()
    End Sub

    Private Sub BtnPrintProb_Click(sender As Object, e As EventArgs) Handles BtnPrintProb.Click
        Cursor = Cursors.WaitCursor
        print(GCProbList, "Problem List")
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelectAll_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAll.EditValueChanged
        For i As Integer = 0 To GVProbList.RowCount - 1
            If CESelectAll.EditValue = True Then
                GVProbList.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVProbList.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub BtnCreatePriceReconcile_Click(sender As Object, e As EventArgs) Handles BtnCreatePriceReconcile.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVProbList)
        GVProbList.ActiveFilterString = "[is_select]='Yes' "

        If GVProbList.RowCount > 0 Then
            'check valid
            Dim id_prob_in As String = ""
            Dim err_product As String = ""
            For c As Integer = 0 To GVProbList.RowCount - 1
                If c > 0 Then
                    id_prob_in += ","
                End If
                If GVProbList.GetRowCellValue(c, "id_design_price_valid") > 0 Then
                    err_product += GVProbList.GetRowCellValue(c, "code").ToString + " - " + GVProbList.GetRowCellValue(c, "name").ToString + System.Environment.NewLine
                End If
                id_prob_in += GVProbList.GetRowCellValue(c, "id_sales_pos_prob").ToString
            Next

            'cek on process
            Dim err_on_process As String = ""
            Dim qcek As String = "SELECT rd.id_sales_pos_recon_det, p.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`
            FROM tb_sales_pos_recon_det rd
            INNER JOIN tb_sales_pos_recon r ON r.id_sales_pos_recon = rd.id_sales_pos_recon
            INNER JOIN tb_m_product p ON p.id_product = rd.id_product
            WHERE r.id_report_status<5 AND rd.id_sales_pos_prob IN(" + id_prob_in + ") "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            For d As Integer = 0 To dcek.Rows.Count - 1
                err_on_process += dcek.Rows(d)("code").ToString + "- " + dcek.Rows(d)("name").ToString + System.Environment.NewLine
            Next

            If err_product <> "" Then
                stopCustom("These product already reconcile :" + System.Environment.NewLine + err_product)
            ElseIf err_on_process <> "" Then
                stopCustom("These product on process reconcile :" + System.Environment.NewLine + err_on_process)
            Else
                'proses
                FormSalesPosPriceRecon.action = "ins"
                FormSalesPosPriceRecon.ShowDialog()
            End If
        End If

        makeSafeGV(GVProbList)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHistProbList_Click(sender As Object, e As EventArgs) Handles BtnHistProbList.Click
        Cursor = Cursors.WaitCursor
        FormSalesProbTransHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStoreProb_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreProb.EditValueChanged
        Dim id_store As String = "-1"
        Try
            id_store = SLEStoreProb.EditValue.ToString
        Catch ex As Exception
        End Try
        If id_store <> "0" Then
            BandedGridColumnqty_new.OptionsColumn.ReadOnly = False
        Else
            BandedGridColumnqty_new.OptionsColumn.ReadOnly = True
        End If
        resetViewProb()
    End Sub

    Private Sub BtnCreateInvoice_Click(sender As Object, e As EventArgs) Handles BtnCreateInvoice.Click
        If SLEStoreProb.EditValue.ToString = "0" Then
            stopCustom("Please select spesific store")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        makeSafeGV(GVProbList)
        If LETypeProb.EditValue.ToString = "1" Then
            GVProbList.ActiveFilterString = "[is_select]='Yes' "
            If GVProbList.RowCount > 0 Then
                'price
                Dim err As String = ""
                Dim err_price_valid As String = ""
                Dim err_qty As String = ""
                For c As Integer = 0 To GVProbList.RowCount - 1
                    Dim id_sales_pos_prob_cek As String = GVProbList.GetRowCellValue(c, "id_sales_pos_prob").ToString
                    Dim code As String = GVProbList.GetRowCellValue(c, "code").ToString
                    Dim qc As String = "SELECT spd.id_sales_pos_prob_price
                    FROM tb_sales_pos sp
                    INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
                    WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_sales_pos_prob_price) AND spd.id_sales_pos_prob_price='" + id_sales_pos_prob_cek + "' "
                    Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")

                    If dc.Rows.Count > 0 Then
                        err += code + System.Environment.NewLine
                    End If

                    'price valid
                    Dim id_design_price_valid_cek As String = GVProbList.GetRowCellValue(c, "id_design_price_valid").ToString
                    If id_design_price_valid_cek = "0" Then
                        err_price_valid += code + System.Environment.NewLine
                    End If

                    'qty
                    Dim hold_qty As Decimal = GVProbList.GetRowCellValue(c, "invoice_qty")
                    If hold_qty <= 0 Then
                        err_qty += code + System.Environment.NewLine
                    End If
                Next

                If err <> "" Then
                    stopCustom("Already processed : " + System.Environment.NewLine + err)
                ElseIf err_price_valid <> "" Then
                    stopCustom("Please propose 'Price Reconcile' first for these product : " + System.Environment.NewLine + err_price_valid)
                ElseIf err_qty <> "" Then
                    stopCustom("No available qty for these product : " + System.Environment.NewLine + err_qty)
                Else
                    FormSalesPOSDet.is_from_prob_list = True
                    FormSalesPOSDet.action = "ins"
                    FormSalesPOSDet.id_menu = id_menu
                    FormSalesPOSDet.ShowDialog()
                End If
            End If
        ElseIf LETypeProb.EditValue.ToString = "2" Then
            GVProbList.ActiveFilterString = "[qty_new]>0 "
            If GVProbList.RowCount > 0 Then
                'no stock

                'initial check stock
                Dim qs As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; 
                            INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES "
                Dim id_prod As String = ""

                Dim err As String = ""
                Dim err_price_valid As String = ""
                'check valid qty
                For c As Integer = 0 To GVProbList.RowCount - 1
                    Dim id_sales_pos_prob_cek As String = GVProbList.GetRowCellValue(c, "id_sales_pos_prob").ToString
                    Dim qty_input As Decimal = GVProbList.GetRowCellValue(c, "qty_new")
                    Dim qty_no_stock As Decimal = GVProbList.GetRowCellValue(c, "no_stock_qty")
                    Dim code As String = GVProbList.GetRowCellValue(c, "code").ToString
                    Dim qc As String = "SELECT spd.id_sales_pos_prob,  IFNULL(SUM(spd.sales_pos_det_qty),0) AS `total_inv`
                    FROM tb_sales_pos sp
                    INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
                    WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_sales_pos_prob) AND spd.id_sales_pos_prob='" + id_sales_pos_prob_cek + "' "
                    Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
                    Dim qty_limit As Decimal = 0.00
                    Dim qty_inv As Decimal = 0.00
                    If dc.Rows.Count <= 0 Then
                        qty_inv = 0
                    Else
                        qty_inv = dc.Rows(0)("total_inv")
                    End If
                    qty_limit = qty_no_stock - qty_inv
                    If qty_input > qty_limit Then
                        err += code + ", can't exceed " + qty_limit.ToString + System.Environment.NewLine
                    End If

                    'price valid
                    Dim id_design_price_valid_cek As String = GVProbList.GetRowCellValue(c, "id_design_price_valid").ToString
                    If id_design_price_valid_cek = "0" Then
                        err_price_valid += code + System.Environment.NewLine
                    End If

                    'stock
                    If c > 0 Then
                        qs += ","
                        id_prod += ","
                    End If
                    qs += "('" + id_user + "','" + GVProbList.GetRowCellValue(c, "code").ToString + "','" + addSlashes(GVProbList.GetRowCellValue(c, "name").ToString) + "', '" + GVProbList.GetRowCellValue(c, "size").ToString + "', '" + GVProbList.GetRowCellValue(c, "id_product").ToString + "', '" + decimalSQL(GVProbList.GetRowCellValue(c, "qty_new").ToString) + "') "
                    id_prod += GVProbList.GetRowCellValue(c, "id_product").ToString
                Next
                'check stock
                qs += "; CALL view_validate_stock(" + id_user + ", " + SLEStoreProb.EditValue.ToString + ", '" + id_prod + "',1); "
                Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")


                If err <> "" Then
                    stopCustom("Qty not valid : " + System.Environment.NewLine + err)
                ElseIf err_price_valid <> "" Then
                    stopCustom("Please propose 'Price Reconcile' first for these product : " + System.Environment.NewLine + err_price_valid)
                ElseIf dts.Rows.Count > 0 Then
                    stopCustom("No stock available for some items.")
                    FormValidateStock.dt = dts
                    FormValidateStock.ShowDialog()
                Else
                    FormSalesPOSDet.is_from_prob_list = True
                    FormSalesPOSDet.action = "ins"
                    FormSalesPOSDet.id_menu = id_menu
                    FormSalesPOSDet.ShowDialog()
                End If
            End If
        End If
        makeSafeGV(GVProbList)
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemTextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTextEdit1.EditValueChanged

    End Sub

    Private Sub SPQty_EditValueChanged(sender As Object, e As EventArgs) Handles SPQty.EditValueChanged
        If GVProbList.RowCount > 0 Then
            Dim qty_limit As Decimal = GVProbList.GetFocusedRowCellValue("no_stock_qty") - (GVProbList.GetFocusedRowCellValue("qty_on_process") + GVProbList.GetFocusedRowCellValue("qty_proceed"))
            Dim RepoQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_input As Decimal = RepoQty.EditValue
            If qty_input > qty_limit Then
                stopCustom("Can't exceed " + qty_limit.ToString)
                GVProbList.SetFocusedRowCellValue("qty_new", 0)
            End If
        End If
    End Sub

    Private Sub RepoBtnTransHist_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnTransHist.ButtonClick
        If GVProbList.RowCount > 0 And GVProbList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesProbTransHistory.id_sales_pos_prob = GVProbList.GetFocusedRowCellValue("id_sales_pos_prob").ToString
            FormSalesProbTransHistory.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkInvoice_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoice.Click
        If GVProbList.RowCount > 0 And GVProbList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.id_report = GVProbList.GetFocusedRowCellValue("id_sales_pos").ToString
            m.report_mark_type = GVProbList.GetFocusedRowCellValue("rmt_inv").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CEPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CEPeriod.EditValueChanged
        If CEPeriod.EditValue = True Then
            DEPeriodFrom.EditValue = Nothing
            DEPeriodUntil.EditValue = Nothing
            DEPeriodFrom.Enabled = False
            DEPeriodUntil.Enabled = False
        Else
            DEPeriodFrom.EditValue = tgl_sekarang
            DEPeriodUntil.EditValue = tgl_sekarang
            DEPeriodFrom.Enabled = True
            DEPeriodUntil.Enabled = True
            DEPeriodFrom.Focus()
        End If
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles BtnPrintNoStock.Click
        Cursor = Cursors.WaitCursor
        print(GCNoStock, "No Stock List")
        Cursor = Cursors.Default
    End Sub

    Private Sub CEAllPeriodNoStock_EditValueChanged(sender As Object, e As EventArgs) Handles CEAllPeriodNoStock.EditValueChanged
        If CEAllPeriodNoStock.EditValue = True Then
            DEFromNoStock.EditValue = Nothing
            DEUntilNoStock.EditValue = Nothing
            DEFromNoStock.Enabled = False
            DEUntilNoStock.Enabled = False
        Else
            DEFromNoStock.EditValue = tgl_sekarang
            DEUntilNoStock.EditValue = tgl_sekarang
            DEFromNoStock.Enabled = True
            DEUntilNoStock.Enabled = True
            DEFromNoStock.Focus()
        End If
    End Sub

    Private Sub LEReconStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LEReconStatus.EditValueChanged
        If LEReconStatus.EditValue.ToString = "1" Then
            BtnCreatePriceReconcile.Visible = True
        Else
            BtnCreatePriceReconcile.Visible = False
        End If
        resetViewProb()
    End Sub

    Private Sub XTCInvoice_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCInvoice.SelectedPageChanged
        view_bap()
    End Sub

    Private Sub XTCProblemList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCProblemList.SelectedPageChanged
        If XTCProblemList.SelectedTabPageIndex = 1 Then
            LENoStockStatus.ItemIndex = LENoStockStatus.Properties.GetDataSourceRowIndex("id_stt", "1")
        End If
    End Sub

    Private Sub LENoStockStatus_EditValueChanged(sender As Object, e As EventArgs) Handles LENoStockStatus.EditValueChanged
        If LENoStockStatus.EditValue = "1" Then
            PanelControlClosingNoStock.Visible = True
        Else
            PanelControlClosingNoStock.Visible = False
        End If
        resetViewNoStockList()
    End Sub

    Private Sub SLEStoreNoStock_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreNoStock.EditValueChanged
        resetViewNoStockList()
    End Sub

    Private Sub DEFromNoStock_EditValueChanged(sender As Object, e As EventArgs) Handles DEFromNoStock.EditValueChanged
        resetViewNoStockList()
    End Sub

    Private Sub DEUntilNoStock_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilNoStock.EditValueChanged
        resetViewNoStockList()
    End Sub

    Private Sub BtnViewNoStock_Click(sender As Object, e As EventArgs) Handles BtnViewNoStock.Click
        viewNoStockList
    End Sub

    Sub viewNoStockList()
        Cursor = Cursors.WaitCursor
        'status
        Dim cond_status As String = ""
        If LENoStockStatus.EditValue.ToString = "1" Then
            cond_status = "AND (p.no_stock_qty<>IFNULL(rcn.qty_proceed,0)) "
        ElseIf LENoStockStatus.EditValue.ToString = "2" Then
            cond_status = "AND (p.no_stock_qty=IFNULL(rcn.qty_proceed,0)) "
        End If
        'store
        Dim cond_store As String = ""
        If SLEStoreNoStock.EditValue.ToString <> "0" Then
            cond_store = "AND c.id_comp='" + SLEStoreNoStock.EditValue.ToString + "' "
        End If
        'period
        Dim cond_period As String = ""
        If CEAllPeriodNoStock.EditValue = False Then
            Dim date_from_selected As String = "0000-01-01"
            Dim date_until_selected As String = "9999-01-01"
            Try
                date_from_selected = DateTime.Parse(DEFromNoStock.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Try
                date_until_selected = DateTime.Parse(DEUntilNoStock.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            cond_period = "AND (sp.sales_pos_end_period>='" + date_from_selected + "' AND sp.sales_pos_end_period<='" + date_until_selected + "') "
        End If

        Dim query As String = "SELECT p.id_sales_pos_prob, 
        p.id_sales_pos, sp.sales_pos_number, sp.sales_pos_start_period, sp.sales_pos_end_period, sp.sales_pos_due_date, sp.report_mark_type AS `rmt_inv`,
        c.id_comp, cc.id_comp_contact, c.comp_number, c.comp_name, cg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`,
        p.is_invalid_price, p.is_no_stock, 
        p.id_product, prod.id_design, prod.product_full_code AS `code`, prod.product_name AS `name`, cd.display_name AS `size`,
        p.id_design_price_retail, p.design_price_retail, p.design_price_store, 
        IFNULL(p.id_design_price_valid,0) AS `id_design_price_valid`, p.design_price_valid, dpt.design_price_type AS `design_price_type_valid`,
        p.no_stock_qty, IFNULL(rcn.qty_on_process,0) AS `qty_recon_on_process`,
        IFNULL(rcn.qty_proceed,0) AS `qty_recon_proceed`, IFNULL(rcn.qty_proceed_cancel,0) AS `qty_proceed_cancel`, IFNULL(rcn.qty_proceed_changes,0) AS `qty_proceed_changes`,
        'No' AS `is_select`,
        (p.no_stock_qty-IFNULL(rcn.qty_proceed,0)) AS `diff_qty`,IF(p.no_stock_qty=IFNULL(rcn.qty_proceed,0),'Close','Open') AS `recon_status`
        From tb_sales_pos_prob p
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = p.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price dp ON dp.id_design_price = p.id_design_price_valid
        LEFT JOIN tb_lookup_design_price_type dpt ON dpt.id_design_price_type = dp.id_design_price_type
        LEFT JOIN (
	        SELECT rd.id_sales_pos_prob, 
	        SUM(IF(r.id_report_status<5,rd.qty_valid,0)) AS `qty_on_process`,
	        SUM(IF(r.id_report_status=6,rd.qty_valid,0)) AS `qty_proceed`,
            SUM(IF(r.id_report_status=6 AND rd.id_oos_final_cat=1,rd.qty_valid,0)) AS `qty_proceed_cancel`,
            SUM(IF(r.id_report_status=6 AND rd.id_oos_final_cat=2,rd.qty_valid,0)) AS `qty_proceed_changes`
	        FROM tb_sales_pos_oos_recon_det rd
	        INNER JOIN tb_sales_pos_oos_recon r ON r.id_sales_pos_oos_recon = rd.id_sales_pos_oos_recon
	        WHERE r.id_report_status!=5
	        GROUP BY rd.id_sales_pos_prob
        ) rcn ON rcn.id_sales_pos_prob = p.id_sales_pos_prob
        WHERE 1=1 AND sp.id_report_status=6 AND p.is_no_stock=1 " + cond_status + cond_store + cond_period
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNoStock.DataSource = data
        GVNoStock.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnReconNoStock.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVNoStock)
        GVNoStock.ActiveFilterString = "[is_select]='Yes' "

        If GVNoStock.RowCount > 0 Then
            'check valid
            Dim id_prob_in As String = ""
            Dim err_product As String = ""
            For c As Integer = 0 To GVNoStock.RowCount - 1
                If c > 0 Then
                    id_prob_in += ","
                End If
                If GVNoStock.GetRowCellValue(c, "id_design_price_valid") <= 0 Then
                    err_product += GVNoStock.GetRowCellValue(c, "code").ToString + " - " + GVNoStock.GetRowCellValue(c, "name").ToString + System.Environment.NewLine
                End If
                id_prob_in += GVNoStock.GetRowCellValue(c, "id_sales_pos_prob").ToString
            Next

            'cek on process
            Dim err_on_process As String = ""
            Dim qcek As String = "SELECT p.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`
            FROM tb_sales_pos_oos_recon_prob rd
            INNER JOIN tb_sales_pos_prob prob ON prob.id_sales_pos_prob = rd.id_sales_pos_prob
            INNER JOIN tb_sales_pos_oos_recon r ON r.id_sales_pos_oos_recon = rd.id_sales_pos_oos_recon
            INNER JOIN tb_m_product p ON p.id_product = prob.id_product
            WHERE r.id_report_status<5 AND rd.id_sales_pos_prob IN(" + id_prob_in + ") "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            For d As Integer = 0 To dcek.Rows.Count - 1
                err_on_process += dcek.Rows(d)("code").ToString + "- " + dcek.Rows(d)("name").ToString + System.Environment.NewLine
            Next

            If err_product <> "" Then
                stopCustom("Invalid price for these products :" + System.Environment.NewLine + err_product)
            ElseIf err_on_process <> "" Then
                stopCustom("These product on process reconcile :" + System.Environment.NewLine + err_on_process)
            Else
                'proses
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this no stock item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    'head
                    Dim note As String = ""
                    Dim query As String = "INSERT INTO tb_sales_pos_oos_recon(created_date, note, id_report_status) 
                    VALUES(NOW(), '" + note + "',1); SELECT LAST_INSERT_ID(); "
                    Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_new + ", 283);", True, "", "", "", "")
                    'detail
                    Dim qd As String = "INSERT INTO tb_sales_pos_oos_recon_prob(id_sales_pos_oos_recon,id_sales_pos_prob) VALUES "
                    For i As Integer = 0 To GVNoStock.RowCount - 1
                        Dim id_sales_pos_prob As String = GVNoStock.GetRowCellValue(i, "id_sales_pos_prob").ToString
                        If i > 0 Then
                            qd += ","
                        End If
                        qd += "('" + id_new + "', '" + id_sales_pos_prob + "') "
                    Next
                    execute_non_query(qd, True, "", "", "", "")
                    'open
                    FormSalesPOSClosingNoStock.id = id_new
                    FormSalesPOSClosingNoStock.ShowDialog()
                    Cursor = Cursors.Default
                End If
            End If
        End If

        makeSafeGV(GVNoStock)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHistoryNoStock_Click(sender As Object, e As EventArgs) Handles BtnHistoryNoStock.Click
        Cursor = Cursors.WaitCursor
        FormSalesProbTransHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelectAllNoStock_EditValueChanged(sender As Object, e As EventArgs) Handles CESelectAllNoStock.EditValueChanged
        For i As Integer = 0 To GVNoStock.RowCount - 1
            If CESelectAllNoStock.EditValue = True Then
                GVNoStock.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVNoStock.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub BtnViewNewItem_Click(sender As Object, e As EventArgs) Handles BtnViewNewItem.Click
        viewNewItem()
    End Sub

    Sub viewNewItem()
        Cursor = Cursors.WaitCursor
        'status
        Dim cond_status As String = ""
        If LESttNewItem.EditValue.ToString = "1" Then
            cond_status = "AND (nd.qty_valid<>IFNULL(proc.qty_proceed,0)) "
        ElseIf LESttNewItem.EditValue.ToString = "2" Then
            cond_status = "AND (nd.qty_valid=IFNULL(proc.qty_proceed,0)) "
        End If
        'store
        Dim cond_store As String = ""
        If SLEStoreNewItem.EditValue.ToString <> "0" Then
            cond_store = "AND c.id_comp='" + SLEStoreNewItem.EditValue.ToString + "' "
        End If
        'period
        Dim cond_period As String = ""
        If CEPeriodNewItem.EditValue = False Then
            Dim date_from_selected As String = "0000-01-01"
            Dim date_until_selected As String = "9999-01-01"
            Try
                date_from_selected = DateTime.Parse(DEFromNewItem.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            Try
                date_until_selected = DateTime.Parse(DEUntilNewitem.EditValue.ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try
            cond_period = "AND (sp.sales_pos_end_period>='" + date_from_selected + "' AND sp.sales_pos_end_period<='" + date_until_selected + "') "
        End If
        Dim query As String = "SELECT 'No' AS `is_select`,nd.id_sales_pos_oos_recon_det, nd.id_sales_pos_oos_recon, n.number AS `closing_number`, n.created_date AS `closing_date`,
        prod.id_design AS `id_design_valid`,nd.id_product_valid , prod.product_full_code AS `code_valid`,prod.product_name AS `name_valid`, cd.code_detail_name AS `size_valid`, nd.qty_valid,
        nd.id_design_price_valid, nd.design_price_valid, pt.design_price_type AS `design_price_type_valid`,
        nd.id_sales_pos, sp.sales_pos_number, sp.sales_pos_start_period, sp.sales_pos_end_period, c.comp_number, c.comp_name, cg.id_comp_group, cg.comp_group, cg.description AS `comp_group_desc`,
        nd.id_product, oos_prod.product_full_code AS `code`,oos_prod.product_name AS `name`, oos_cd.code_detail_name AS `size`, nd.qty AS `no_stock_qty`, IFNULL(proc.qty_on_process,0) AS `qty_on_process`,  IFNULL(proc.qty_proceed,0) AS `qty_proceed`,
        proc.id_sales_pos AS `id_sales_pos_proc`, proc.sales_pos_number AS `sales_pos_number_proc`
        FROM tb_sales_pos_oos_recon_det nd
        INNER JOIN tb_sales_pos_oos_recon n ON n.id_sales_pos_oos_recon = nd.id_sales_pos_oos_recon
        INNER JOIN tb_m_product prod ON prod.id_product = nd.id_product_valid
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = nd.id_design_price_valid
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_m_product oos_prod ON oos_prod.id_product = nd.id_product
        INNER JOIN tb_m_product_code oos_prod_code ON oos_prod_code.id_product = oos_prod.id_product
        INNER JOIN tb_m_code_detail oos_cd ON oos_cd.id_code_detail = oos_prod_code.id_code_detail
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = nd.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN (
	        SELECT spd.id_sales_pos_oos_recon_det,
	        SUM(IF(sp.id_report_status<5,spd.sales_pos_det_qty,0)) AS `qty_on_process`,
	        SUM(IF(sp.id_report_status=6,spd.sales_pos_det_qty,0)) AS `qty_proceed`,
            sp.id_sales_pos, sp.sales_pos_number 
	        FROM tb_sales_pos_det spd
	        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	        WHERE !ISNULL(spd.id_sales_pos_oos_recon_det) AND sp.id_report_status!=5
	        GROUP BY spd.id_sales_pos_oos_recon_det
        ) proc ON proc.id_sales_pos_oos_recon_det = nd.id_sales_pos_oos_recon_det
        WHERE n.id_report_status=6 AND nd.id_oos_final_cat=2 " + cond_status + " " + cond_store + " " + cond_period + "
        ORDER BY nd.id_sales_pos_oos_recon_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNewItem.DataSource = data
        GVNewItem.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub CEPeriodNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles CEPeriodNewItem.EditValueChanged
        If CEPeriodNewItem.EditValue = True Then
            DEFromNewItem.EditValue = Nothing
            DEUntilNewitem.EditValue = Nothing
            DEFromNewItem.Enabled = False
            DEUntilNewitem.Enabled = False
        Else
            DEFromNewItem.EditValue = tgl_sekarang
            DEUntilNewitem.EditValue = tgl_sekarang
            DEFromNewItem.Enabled = True
            DEUntilNewitem.Enabled = True
            DEFromNewItem.Focus()
        End If
    End Sub

    Private Sub BtnPrintNewItem_Click(sender As Object, e As EventArgs) Handles BtnPrintNewItem.Click
        Cursor = Cursors.WaitCursor
        print(GCNewItem, LESttNewItem.Text + " Invoice List (Changes Item)")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHistNewItem_Click(sender As Object, e As EventArgs) Handles BtnHistNewItem.Click
        Cursor = Cursors.WaitCursor
        FormSalesProbTransHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub resetViewNewItem()
        Cursor = Cursors.WaitCursor
        GCNewItem.DataSource = Nothing
        Cursor = Cursors.Default
    End Sub

    Private Sub LENoStockStatus_DragOver(sender As Object, e As DragEventArgs) Handles LENoStockStatus.DragOver

    End Sub

    Sub showCreateInvNewItem()
        If LESttNewItem.EditValue = "1" And SLEStoreNewItem.EditValue <> "0" Then
            PanelControlNewItem.Visible = True
        Else
            PanelControlNewItem.Visible = False
        End If
    End Sub

    Private Sub LESttNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles LESttNewItem.EditValueChanged
        showCreateInvNewItem()
        resetViewNewItem()
    End Sub

    Private Sub SLEStoreNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreNewItem.EditValueChanged
        showCreateInvNewItem()
        resetViewNewItem()
    End Sub

    Private Sub DEFromNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles DEFromNewItem.EditValueChanged
        resetViewNewItem()
    End Sub

    Private Sub DEUntilNewitem_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilNewitem.EditValueChanged
        resetViewNewItem()
    End Sub

    Private Sub XTCNoStock_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCNoStock.SelectedPageChanged
        If XTCNoStock.SelectedTabPageIndex = 1 Then
            If LESttNewItem.EditValue = Nothing Then
                LESttNewItem.ItemIndex = LESttNewItem.Properties.GetDataSourceRowIndex("id_stt", "1")
            End If
        End If
    End Sub

    Private Sub CESelAllNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles CESelAllNewItem.EditValueChanged
        For i As Integer = 0 To GVNewItem.RowCount - 1
            If CESelAllNewItem.EditValue = True Then
                GVNewItem.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVNewItem.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub BtnInvoiceNewitem_Click(sender As Object, e As EventArgs) Handles BtnInvoiceNewitem.Click
        makeSafeGV(GVNewItem)
        GVNewItem.ActiveFilterString = "[is_select] = 'Yes'"

        If GVNewItem.RowCount > 0 Then
            'initial check stock
            Dim qs As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; 
            INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES "
            Dim id_prod As String = ""

            Dim err_op As String = ""
            For c As Integer = 0 To GVNewItem.RowCount - 1
                Dim id_sales_pos_oos_recon_det_cek As String = GVNewItem.GetRowCellValue(c, "id_sales_pos_oos_recon_det").ToString
                Dim qty_valid_cek As Decimal = GVNewItem.GetRowCellValue(c, "qty_valid")
                Dim code As String = GVNewItem.GetRowCellValue(c, "code_valid").ToString

                'cek on process
                Dim qop As String = "SELECT spd.id_sales_pos_oos_recon_det
                FROM tb_sales_pos_det spd
                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
                WHERE sp.id_report_status<5 AND spd.id_sales_pos_oos_recon_det='" + id_sales_pos_oos_recon_det_cek + "' "
                Dim dop As DataTable = execute_query(qop, -1, True, "", "", "", "")
                If dop.Rows.Count > 0 Then
                    err_op += code + System.Environment.NewLine
                End If

                'stock
                If c > 0 Then
                    qs += ","
                    id_prod += ","
                End If
                qs += "('" + id_user + "','" + GVNewItem.GetRowCellValue(c, "code_valid").ToString + "','" + addSlashes(GVNewItem.GetRowCellValue(c, "name_valid").ToString) + "', '" + GVNewItem.GetRowCellValue(c, "size_valid").ToString + "', '" + GVNewItem.GetRowCellValue(c, "id_product_valid").ToString + "', '" + decimalSQL(GVNewItem.GetRowCellValue(c, "qty_valid").ToString) + "') "
                id_prod += GVNewItem.GetRowCellValue(c, "id_product_valid").ToString
            Next
            'check stock
            qs += "; CALL view_validate_stock(" + id_user + ", " + SLEStoreNewItem.EditValue.ToString + ", '" + id_prod + "',1); "
            Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")

            If err_op <> "" Then
                stopCustom("On process invoice for these product : " + System.Environment.NewLine + err_op)
            ElseIf dts.Rows.Count > 0 Then
                stopCustom("No stock available for some items.")
                FormValidateStock.dt = dts
                FormValidateStock.ShowDialog()
            Else
                Cursor = Cursors.WaitCursor
                FormSalesPOSDet.is_from_prob_list_no_stock = True
                FormSalesPOSDet.action = "ins"
                FormSalesPOSDet.id_menu = id_menu
                FormSalesPOSDet.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If

        GVNewItem.ActiveFilterString = ""
        makeSafeGV(GVNewItem)
    End Sub

    Private Sub RepoBtnHistNoStockProb_Click(sender As Object, e As EventArgs) Handles RepoBtnHistNoStockProb.Click
        If GVNoStock.RowCount > 0 And GVNoStock.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesProbTransHistory.id_sales_pos_prob = GVNoStock.GetFocusedRowCellValue("id_sales_pos_prob").ToString
            FormSalesProbTransHistory.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkInvoiceNewItem_Click(sender As Object, e As EventArgs) Handles RepoLinkInvoiceNewItem.Click
        If GVNewItem.RowCount > 0 And GVNewItem.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim inv As New FormViewSalesPOS()
            inv.id_sales_pos = GVNewItem.GetFocusedRowCellValue("id_sales_pos_proc")
            inv.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLEStoreRefuseReturn_EditValueChanged(sender As Object, e As EventArgs) Handles SLEStoreRefuseReturn.EditValueChanged
        resetViewRefuseReturn()
    End Sub

    Sub resetViewRefuseReturn()
        GCData.DataSource = Nothing
        If SLEStoreRefuseReturn.EditValue.ToString <> "0" And LEStatusRefuseReturn.EditValue.ToString = "1" Then
            BtnCreateCancelCN.Visible = True
        Else
            BtnCreateCancelCN.Visible = False
        End If
    End Sub

    Private Sub LEStatusRefuseReturn_EditValueChanged(sender As Object, e As EventArgs) Handles LEStatusRefuseReturn.EditValueChanged
        resetViewRefuseReturn()
    End Sub

    Private Sub BtnViewListRefuseReturn_Click(sender As Object, e As EventArgs) Handles BtnViewListRefuseReturn.Click
        viewRefuseReturnList()
    End Sub

    Sub viewRefuseReturnList()
        Cursor = Cursors.WaitCursor
        'cond store
        Dim id_store As String = SLEStoreRefuseReturn.EditValue.ToString
        Dim cond_store As String = ""
        If id_store <> "0" Then
            cond_store = "AND s.id_comp='" + id_store + "' "
        End If

        'cond status
        Dim id_stt As String = LEStatusRefuseReturn.EditValue.ToString
        Dim cond_stt As String = ""
        If id_stt <> "0" Then
            cond_stt = "AND id_status_ccn='" + id_stt + "'"
        End If

        Dim query As String = "SELECT rf.id_return_refuse, rf.id_refuse_type, rt.refuse_type, rf.`number`, rf.note,
        s.id_comp, s.comp_number, s.comp_name, so.sales_order_ol_shop_number, so.customer_name, 
        IF(ISNULL(cd.id_return_refuse_det),'1','2') AS `id_status_ccn`,
        IF(ISNULL(cd.id_return_refuse_det),'Open','Close') AS `status_ccn`
        FROM tb_ol_store_return_refuse rf
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = rf.id_store_contact
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_lookup_refuse_type rt ON rt.id_refuse_type = rf.id_refuse_type
        INNER JOIN tb_ol_store_return_refuse_det rfd ON rfd.id_return_refuse = rf.id_return_refuse
        INNER JOIN tb_sales_order so ON so.id_sales_order = rf.id_sales_order
        LEFT JOIN (
	        SELECT cd.id_return_refuse_det 
	        FROM tb_sales_pos_det cd
	        INNER JOIN tb_sales_pos c ON c.id_sales_pos = cd.id_sales_pos
	        WHERE c.id_report_status=6 AND !ISNULL(cd.id_return_refuse_det)
	        GROUP BY cd.id_return_refuse_det
        ) cd ON cd.id_return_refuse_det = rfd.id_return_refuse_det
        WHERE rf.id_report_status=6 
        AND !ISNULL(rfd.id_sales_pos_det_cn)
        " + cond_store + "
        GROUP BY rf.id_return_refuse
        HAVING 1=1 
         " + cond_stt + "
        ORDER BY id_return_refuse ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateCancelCN_Click(sender As Object, e As EventArgs) Handles BtnCreateCancelCN.Click
        Cursor = Cursors.WaitCursor
        'cek on process
        Dim id_return_refuse As String = GVData.GetFocusedRowCellValue("id_return_refuse").ToString
        Dim qcek As String = "SELECT sp.id_sales_pos FROM tb_sales_pos sp 
        WHERE sp.id_report_status!=5 AND sp.id_return_refuse='" + id_return_refuse + "' "
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            stopCustom("Already process")
            Cursor = Cursors.Default
            Exit Sub
        End If

        'show
        FormSalesPOSDet.id_menu = "6"
        FormSalesPOSDet.action = "ins"
        FormSalesPOSDet.is_from_cancel_cn = True
        FormSalesPOSDet.id_return_refuse = id_return_refuse
        FormSalesPOSDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim rrf As New ClassShowPopUp()
            rrf.report_mark_type = "290"
            rrf.id_report = GVData.GetFocusedRowCellValue("id_return_refuse").ToString
            rrf.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub view_bap()
        Dim query As String = "
            SELECT b.id_st_store_bap, b.number, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, DATE_FORMAT(b.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, b.id_report_status, r.report_status
            FROM tb_st_store_bap AS b
            LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS u ON b.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON b.id_report_status = r.id_report_status
            WHERE b.id_report_status = 6 AND b.id_st_store_bap NOT IN (SELECT IFNULL(id_st_store_bap, 0) FROM tb_sales_pos WHERE id_report_status <> 5)
            ORDER BY b.id_st_store_bap ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCInvBAP.DataSource = data

        GVInvBAP.BestFitColumns()
    End Sub

    Private Sub SBCreateInv_Click(sender As Object, e As EventArgs) Handles SBCreateInv.Click
        FormSalesPOSDet.action = "ins"
        FormSalesPOSDet.id_menu = id_menu
        FormSalesPOSDet.id_st_store_bap = GVInvBAP.GetFocusedRowCellValue("id_st_store_bap").ToString
        FormSalesPOSDet.ShowDialog()
    End Sub
End Class