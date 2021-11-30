﻿Imports Microsoft.Office.Interop

Public Class FormSalesDelOrderDet
    Public action As String
    Public id_pl_sales_order_del As String = "-1"
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Dim id_store As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_report_status As String
    Public id_pl_sales_order_del_det_list As New List(Of String)
    Public id_pl_sales_order_del_det_counting_list As New List(Of String)
    Public id_pl_sales_order_del_det_drawer_list As New List(Of String)
    Dim id_season_default As String
    Dim id_delivery_default As String
    Public id_comp_user As String = "-1"
    Public dt As New DataTable
    Public id_pre As String = "-1"
    Public id_wh_drawer As String = "-1"
    'Dim is_scan As Boolean = False
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_do")
    Dim is_block_del_store As String = get_setup_field("is_block_del_store")
    Dim is_save_unreg_unique As String = "-1"
    Dim id_so_status As String = ""
    Dim id_commerce_type As String = "-1"
    Dim id_comp_group As String = "-1"
    Dim id_wh As String = "-1"



    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Dim id_store_type As String = "-1"
    Dim is_use_unique_code As String = "-1"
    Dim is_use_unique_code_wh As String = "-1"
    Dim action_scan_btn As String = ""
    Dim id_combine As String = "-1"
    Dim id_store_active As String = "-1"

    'scan
    Private cforKeyDown As Char = vbNullChar
    Private _lastKeystroke As DateTime = DateTime.Now
    Public speed_barcode_read As Integer = get_setup_field("speed_barcode_read")
    Public speed_barcode_read_timer As Integer = get_setup_field("speed_barcode_read_timer")

    Private Sub FormSalesDelOrderDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSoType()
        viewSoStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception

        End Try

        If action = "ins" Then
            'TxtSalesDelOrderNumber.Text = header_number_sales("3")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)
            check_but()

            'from waiting menu
            If id_sales_order <> "-1" Then
                viewSalesOrder()
            End If

            'check is_save_unreg_unique (unique tdk teregister)
            is_save_unreg_unique = get_setup_field("is_save_unreg_unique")

            'hold delivery
            Dim del As New ClassSalesDelOrder()
            If is_block_del_store = "1" And del.checkUnpaidInvoice(id_comp_group) Then
                stopCustom("Hold delivery")
                Cursor = Cursors.Default
                Close()
            End If

            'hold delivery (karna toko non aktif)
            If id_store_active <> "1" Then
                stopCustom("Store is not active")
                Cursor = Cursors.Default
                Close()
            End If
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlScannedItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseSO.Enabled = False
            BtnInfoSrs.Enabled = True
            XTPOutboundScanNew.PageEnabled = True
            BMark.Enabled = False
            DDBPrint.Enabled = True

            'query view based on edit id's
            Dim query_c As New ClassSalesDelOrder()
            Dim query As String = query_c.queryMainLess("AND a.id_pl_sales_order_del=" + id_pl_sales_order_del + " ", "2")

            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            id_store = data.Rows(0)("id_store").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString
            TxtNameCompFrom.Text = data.Rows(0)("wh_name").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("wh_number").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            TxtDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            TxtDrawer.Text = data.Rows(0)("wh_drawer").ToString
            DEForm.Text = view_date_from(data.Rows(0)("pl_sales_order_del_datex").ToString, 0)
            TxtSalesDelOrderNumber.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            TxtOLShopNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            TxtCustomer.Text = data.Rows(0)("customer_name").ToString
            MENote.Text = data.Rows(0)("pl_sales_order_del_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            id_sales_order = data.Rows(0)("id_sales_order").ToString
            id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
            TxtCombineNumber.Text = data.Rows(0)("combine_number").ToString
            id_combine = data.Rows(0)("id_combine").ToString
            is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString
            id_comp_group = data.Rows(0)("id_comp_group").ToString
            id_commerce_type = data.Rows(0)("id_commerce_type").ToString

            'uniform
            Dim id_so_status As String = data.Rows(0)("id_so_status").ToString
            If id_so_status = "7" Then
                GroupUni.Visible = True
                TxtPeriod.Text = data.Rows(0)("period_name").ToString
                TxtNIK.Text = data.Rows(0)("employee_code").ToString
                TxtEmployee.Text = data.Rows(0)("employee_name").ToString
            End If


            'detail2
            viewDetail()
            view_barcode_list()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If
    End Sub
    Sub viewSalesOrder()
        'Dim query_c As New ClassSalesOrder()
        'Dim query As String = query_c.queryMain("AND a.id_sales_order=" + id_sales_order + " ", "2")
        Dim qso As String = "SELECT a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,d.id_comp AS `id_store`, d.id_comp_group, d.is_use_unique_code, d.id_store_type, d.comp_number AS `store_number`, d.comp_name AS `store`, d.address_primary as `store_address`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, a.id_warehouse_contact_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to,  (wh.comp_name) AS `warehouse`, wh.is_use_unique_code AS `is_use_unique_code_wh`, wh.id_comp AS `id_wh`, wh.id_drawer_def AS `id_wh_drawer`, drw.wh_drawer_code, drw.wh_drawer, a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, a.sales_order_ol_shop_number, a.sales_order_ol_shop_date, (a.sales_order_date) AS sales_order_date, ps.id_prepare_status, ps.prepare_status, ('No') AS `is_select`, cat.id_so_status, cat.so_status, del_cat.id_so_cat, del_cat.so_cat, IFNULL(so_item.tot_so,0.00) AS `total_order`,  
        IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`,a.id_so_type, a.final_comment, a.final_date, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, a.id_prepare_status, a.customer_name, d.is_active
        FROM tb_sales_order a 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status 
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = a.id_so_status 
        LEFT JOIN ( 
            SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  
            FROM tb_sales_order_det so_det GROUP BY so_det.id_sales_order 
        ) so_item ON so_item.id_sales_order = a.id_sales_order 
        LEFT JOIN tb_fg_so_reff an On an.id_fg_so_reff = a.id_fg_so_reff 
        LEFT JOIN tb_lookup_pd_alloc alloc On alloc.id_pd_alloc = d.id_pd_alloc 
        LEFT JOIN tb_lookup_so_cat del_cat On del_cat.id_so_cat = alloc.id_so_cat 
        LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        WHERE a.id_sales_order>0 AND a.id_sales_order=" + id_sales_order + "  ORDER BY a.id_sales_order DESC "
        Dim data As DataTable = execute_query(qso, -1, True, "", "", "", "")

        'cek masi open ato close
        If data.Rows(0)("id_prepare_status") = "2" Then
            stopCustom("This order already closed")
            FormSalesDelOrder.viewSalesOrder()
            Close()
        End If

        'SO
        TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString
        MENote.Text = data.Rows(0)("sales_order_note").ToString

        'store data
        Dim id_comp_to As String = data.Rows(0)("id_store").ToString
        id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
        TxtCodeCompTo.Text = data.Rows(0)("store_number").ToString
        TxtNameCompTo.Text = data.Rows(0)("store").ToString
        MEAdrressCompTo.Text = data.Rows(0)("store_address").ToString
        id_store_type = data.Rows(0)("id_store_type").ToString
        is_use_unique_code = get_setup_field("is_use_unique_code_all")
        If id_store_type = "3" Then 'big sale
            id_store_type = "2"
        End If
        id_commerce_type = data.Rows(0)("id_commerce_type").ToString
        id_comp_group = data.Rows(0)("id_comp_group").ToString
        id_store_active = data.Rows(0)("is_active").ToString


        'wh
        id_comp_contact_from = data.Rows(0)("id_warehouse_contact_to").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("warehouse_number_to").ToString
        TxtNameCompFrom.Text = data.Rows(0)("warehouse").ToString
        TxtDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
        TxtDrawer.Text = data.Rows(0)("wh_drawer").ToString
        id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
        is_use_unique_code_wh = get_setup_field("is_use_unique_code_all")
        id_wh = data.Rows(0)("id_wh").ToString

        'tipe & status SO
        LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
        LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
        TxtOLShopNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
        TxtCustomer.Text = data.Rows(0)("customer_name").ToString
        MENote.Text += If(MENote.Text <> "", " ", "") + "" + data.Rows(0)("sales_order_ol_shop_number").ToString + " " + data.Rows(0)("customer_name").ToString + ""

        'uniform
        id_so_status = data.Rows(0)("id_so_status").ToString
        If id_so_status = "7" Then
            GroupUni.Visible = True
            TxtPeriod.Text = data.Rows(0)("period_name").ToString
            TxtNIK.Text = data.Rows(0)("employee_code").ToString
            TxtEmployee.Text = data.Rows(0)("employee_name").ToString
        End If

        'general
        viewDetail()
        'jika dia claim : account normal - harga normal; account sale - harga sale
        If id_so_status = "8" Then
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim dtp As DataTable = getNormalPrice(GVItemList.GetRowCellValue(i, "id_design").ToString)
                GVItemList.SetRowCellValue(i, "id_design_price", dtp.Rows(0)("id_design_price").ToString)
                GVItemList.SetRowCellValue(i, "design_price", dtp.Rows(0)("design_price"))
                GVItemList.SetRowCellValue(i, "design_price_type", dtp.Rows(0)("design_price_type"))
            Next
        End If
        view_barcode_list()
        'setDefaultDrawer()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        XTPOutboundScanNew.PageEnabled = True
        BtnInfoSrs.Enabled = True
        check_but()
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
        BtnBrowseSO.Enabled = False

        'cek coa online store
        If id_commerce_type = 2 Then
            Dim is_valid_coa As String = execute_query("SELECT IF(IFNULL(c.id_acc_ar,0)>0 AND IFNULL(c.id_acc_sales,0)>0 AND IFNULL(c.id_acc_sales_return,0)>0,1,2) AS `is_valid_coa` 
            FROM tb_m_comp c WHERE c.id_comp=" + id_comp_to + " ", 0, True, "", "", "", "")
            If is_valid_coa = "2" Then
                stopCustom("Can't process delivery. Please contact accounting dept. to setup COA AR/Sales for this store")
                Close()
            End If
        End If
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT * FROM tb_lookup_so_status a ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'action
            Dim query As String = "CALL view_sales_order_limit_less('" + id_sales_order + "', '0', '0')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            id_pl_sales_order_del_det_list.Clear()
            Dim query As String = "CALL view_pl_sales_order_del('" + id_pl_sales_order_del + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        End If
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('') AS `name`, ('') AS `size`,('') AS class, ('') AS color, ('') AS sht,('0') AS id_pl_sales_order_del_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_pl_sales_order_del_det_counting, '' AS `ol_store_id`, '' AS `item_id` "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            id_pl_sales_order_del_det_counting_list.Clear()
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_sales_order_del_det_counting) AS code, "
            query += "c.product_display_name AS `name`, cod.display_name AS `size`,cd.class, cd.color, cd.sht, (a.pl_sales_order_del_det_counting) AS counting_code, "
            query += "a.id_pl_sales_order_del_det_counting, ('2') AS is_fix, "
            query += "a.id_pl_prod_order_rec_det_unique, b.id_product "
            query += "FROM tb_pl_sales_order_del_det_counting a "
            query += "INNER JOIN tb_pl_sales_order_del_det b ON a.id_pl_sales_order_del_det = b.id_pl_sales_order_del_det "
            query += "JOIN tb_opt o "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product 
            INNER JOIN tb_m_design d ON d.id_design = c.id_design 
            LEFT JOIN (
		        SELECT dc.id_design, 
		        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
		        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
		        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
		        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
		        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
		        FROM tb_m_design_code dc
		        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
		        AND cd.id_code IN (32,30,14, 43)
		        GROUP BY dc.id_design
	        ) cd ON cd.id_design = d.id_design "
            query += "INNER JOIN tb_m_product_code cc ON cc.id_product = c.id_product "
            query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
            query += "WHERE b.id_pl_sales_order_del = '" + id_pl_sales_order_del + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_pl_sales_order_del_det_counting_list.Add(data.Rows(i)("id_pl_sales_order_del_det_counting").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub setDefaultDrawer()
        'get drw def
        Dim id_wh_par As String = get_company_contact_x(id_comp_contact_from, "3")
        Dim query As String = ""
        query += "SELECT wh.id_comp, wh.comp_number, loc.id_wh_locator, loc.wh_locator_code, rck.id_wh_rack, rck.wh_rack_code, drw.id_wh_drawer, drw.wh_drawer_code "
        query += "FROM tb_m_comp wh "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "WHERE wh.id_comp='" + id_wh_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Dim id_loc_def As String = data.Rows(0)("id_wh_locator").ToString
            Dim id_rck_def As String = data.Rows(0)("id_wh_rack").ToString
            Dim id_drw_def As String = data.Rows(0)("id_wh_drawer").ToString
            Dim wh As String = data.Rows(0)("comp_number").ToString
            Dim locator As String = data.Rows(0)("wh_locator_code").ToString
            Dim rack As String = data.Rows(0)("wh_rack_code").ToString
            Dim drawer As String = data.Rows(0)("wh_drawer_code").ToString
            Dim bom_unit_price As Decimal = 0
            Dim qty_all_product As Decimal = 0
            Dim total_cost As Decimal = 0

            'get stock
            Dim query_stc As String = "CALL view_stock_fg('" + id_wh_par + "','" + id_loc_def + "','" + id_rck_def + "','" + id_drw_def + "', '0','4', '9999-01-01') "
            Dim data_stc As DataTable = execute_query(query_stc, -1, True, "", "", "", "")


            For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim data_stc_filter As DataRow() = data_stc.Select("[id_product]='" + GVItemList.GetRowCellValue(j, "id_product").ToString + "' ")
                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                Dim code As String = GVItemList.GetRowCellValue(j, "code").ToString
                Dim name As String = GVItemList.GetRowCellValue(j, "name").ToString
                Dim size As String = GVItemList.GetRowCellValue(j, "size").ToString
                Dim qty_limit As Decimal = GVItemList.GetRowCellValue(j, "sales_order_det_qty_limit")
                Dim id_pl_sales_order_del_det_drawer As String = "0"
                Dim fill_status As Boolean = False

                If data_stc_filter.Length > 0 Then
                    Dim qty_avail As Decimal = data_stc_filter(0)("qty_all_product")
                    If qty_limit > 0 Then
                        If qty_avail = 0 Then
                            qty_all_product = 0
                            bom_unit_price = 0
                            total_cost = 0
                            fill_status = False
                        ElseIf qty_avail >= qty_limit Then
                            qty_all_product = qty_limit
                            bom_unit_price = data_stc_filter(0)("bom_unit_price")
                            total_cost = qty_all_product * bom_unit_price
                            fill_status = True
                        Else
                            qty_all_product = qty_avail
                            bom_unit_price = data_stc_filter(0)("bom_unit_price")
                            total_cost = qty_all_product * bom_unit_price
                            fill_status = True
                        End If
                    Else
                        qty_all_product = 0
                        bom_unit_price = 0
                        total_cost = 0
                        fill_status = False
                    End If
                Else
                    bom_unit_price = 0
                    qty_all_product = 0
                    total_cost = 0
                    fill_status = False
                End If

            Next
        End If
    End Sub


    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_product_param_comma As String)
        'unique
        dt.Clear()
        Dim query As String = ""
        If is_use_unique_code_wh = "1" Then
            query = "CALL view_stock_fg_unique_with_table('" + id_product_param_comma + "', '" + id_wh + "', '" + id_wh_drawer + "')"
        Else
            query = "CALL view_stock_fg_unique_del('" + id_product_param + "') "
        End If
        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        dt = datax


        'not unique 
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_product_param)
        Dim data_not As DataTable = execute_query(query_not, -1, True, "", "", "", "")

        'merge with not unique
        If data_not.Rows.Count > 0 Then
            If dt.Rows.Count = 0 Then
                dt = data_not
            Else
                dt.Merge(data_not, True, MissingSchemaAction.Ignore)
            End If
        End If

        If is_save_unreg_unique = "1" Then
            'merge with unique unregistered
            Dim data_unreg = query_c.dataUnregisteredCode(id_product_param)
            If data_unreg.Rows.Count > 0 Then
                If dt.Rows.Count = 0 Then
                    dt = data_unreg
                Else
                    dt.Merge(data_unreg, True, MissingSchemaAction.Ignore)
                End If
            End If
        End If
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "43", id_pl_sales_order_del) Then
            MENote.Properties.ReadOnly = False
            GVItemList.OptionsCustomization.AllowQuickHideColumns = False
            GVItemList.OptionsCustomization.AllowGroup = False
            BtnCombineDel.Visible = True
        Else
            MENote.Properties.ReadOnly = True
            GVItemList.OptionsCustomization.AllowQuickHideColumns = True
            GVItemList.OptionsCustomization.AllowGroup = True
            BtnCombineDel.Visible = False
        End If
        PanelNavBarcode.Enabled = False
        BtnSave.Enabled = False
        BtnVerify.Enabled = False
        GridColumnQtyLimit.Visible = False
        GridColumnStatus.Visible = False

        'attachment
        If check_attach_report_status(id_report_status, "43", id_pl_sales_order_del) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'pre print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If
        TxtSalesDelOrderNumber.Focus()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        'If e.Column.FieldName = "no" Then
        '    e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        'End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub countQty(ByVal id_product_param As String, ByVal ol_store_id_param As String, ByVal item_id_param As String)
        If id_commerce_type = "2" Then
            'onine store

            'focus
            makeSafeGV(GVItemList)
            If action_scan_btn = "start" Then
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [diff]>0 "
            ElseIf action_scan_btn = "delete" Then
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [ol_store_id]='" + ol_store_id_param + "' AND [item_id]='" + item_id_param + "' AND [pl_sales_order_del_det_qty]>0 "
            End If
            GVItemList.FocusedRowHandle = 0
            makeSafeGV(GVItemList)

            Dim tot As Integer = 0
            If action_scan_btn = "start" Then
                tot = GVItemList.GetFocusedRowCellValue("pl_sales_order_del_det_qty") + 1
            ElseIf action_scan_btn = "delete" Then
                tot = GVItemList.GetFocusedRowCellValue("pl_sales_order_del_det_qty") - 1
            End If


            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_qty", tot)
        Else
            GVBarcode.ActiveFilterString = "[id_product]='" + id_product_param + "' "
            Dim tot As Integer = GVBarcode.RowCount
            GVBarcode.ActiveFilterString = ""

            GVItemList.FocusedRowHandle = find_row(GVItemList, "id_product", id_product_param)

            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("pl_sales_order_del_det_qty", tot)
        End If
    End Sub

    Private Sub BtnBrowseSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseSO.Click
        FormPopUpSalesOrder.id_pop_up = "1"
        FormPopUpSalesOrder.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "39"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpSalesOrder.id_pop_up = "2"
        FormPopUpSalesOrder.id_sales_order = id_sales_order
        FormPopUpSalesOrder.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Close()
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub FormSalesDelOrderDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function verifyTrans() As Boolean
        GridColumnStatus.Visible = True
        Dim cond_check_data As Boolean = True
        Dim dt_cek As DataTable
        If action = "ins" Then
            dt_cek = execute_query("CALL view_sales_order_limit_less(" + id_sales_order + ", 0, 0)", -1, True, "", "", "", "")
        Else
            dt_cek = execute_query("CALL view_sales_order_limit(" + id_sales_order + ", 0, " + id_pl_sales_order_del + ")", -1, True, "", "", "", "")
        End If
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Dim id_sales_order_det_cekya As String = GVItemList.GetRowCellValue(i, "id_sales_order_det").ToString
            Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "pl_sales_order_del_det_qty")

            Dim data_filter_cek As DataRow() = dt_cek.Select("[id_sales_order_det]='" + id_sales_order_det_cekya + "' ")
            If data_filter_cek.Length <= 0 Then
                GVItemList.SetRowCellValue(i, "status", "Product not found;")
                cond_check_data = False
            Else
                If qty_cek > data_filter_cek(0)("sales_order_det_qty_limit") Then
                    cond_check_data = False
                End If
                GVItemList.SetRowCellValue(i, "sales_order_det_qty_limit", data_filter_cek(0)("sales_order_det_qty_limit"))
            End If
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        Return cond_check_data
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        makeSafeGV(GVBarcode)
        ValidateChildren()

        'cek qty limit SO di DB
        Dim cond_check_dt As Boolean = verifyTrans()

        'block stocktake eos
        Dim all_product As List(Of String) = New List(Of String)

        For i = 0 To GVItemList.RowCount - 1
            If GVItemList.IsValidRowHandle(i) Then
                If GVItemList.GetRowCellValue(i, "pl_sales_order_del_det_qty") > 0 Then
                    all_product.Add(GVItemList.GetRowCellValue(i, "id_product").ToString)
                End If
            End If
        Next

        Dim block_stocktake As Boolean = block_stocktake_eos(all_product)

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMiddle) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Or GVBarcode.RowCount = 0 Then
            errorCustom("Delivery item or scanned item data can't blank")
        ElseIf Not cond_check_dt Then
            stopCustom("Please see different in column status.")
        ElseIf Not block_stocktake And id_commerce_type = "1" Then
            stopCustom("Some product already in EOS and need to stock take first.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim pl_sales_order_del_note As String = addSlashes(MENote.Text.ToString)
                If action = "ins" Then
                    'query main table
                    Dim pl_sales_order_del_number As String = ""
                    Dim query_main As String = "INSERT tb_pl_sales_order_del(id_sales_order, pl_sales_order_del_number, id_comp_contact_from, id_store_contact_to, pl_sales_order_del_date, pl_sales_order_del_note, id_report_status, last_update, last_update_by, id_wh_drawer, is_use_unique_code, is_use_unique_code_wh) "
                    query_main += "VALUES('" + id_sales_order + "', '', '" + id_comp_contact_from + "', '" + id_store_contact_to + "', NOW(), '" + pl_sales_order_del_note + "', '1', NOW(), " + id_user + ", '" + id_wh_drawer + "', '" + is_use_unique_code + "', '" + is_use_unique_code_wh + "'); SELECT LAST_INSERT_ID(); "
                    id_pl_sales_order_del = execute_query(query_main, 0, True, "", "", "", "")


                    'insert who prepared
                    insert_who_prepared("43", id_pl_sales_order_del, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_pl_sales_order_del_det(id_pl_sales_order_del, id_sales_order_det, id_product, id_design_price, design_price, pl_sales_order_del_det_qty, pl_sales_order_del_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            If GVItemList.GetRowCellValue(j, "pl_sales_order_del_det_qty") > 0 Then
                                Dim id_sales_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_order_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                                Dim pl_sales_order_del_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "pl_sales_order_del_det_qty").ToString)
                                Dim pl_sales_order_del_det_note As String = GVItemList.GetRowCellValue(j, "pl_sales_order_del_det_note").ToString

                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_pl_sales_order_del + "', '" + id_sales_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + pl_sales_order_del_det_qty + "', '" + pl_sales_order_del_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If GVItemList.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_pl_sales_order_del_det, a.id_product, sod.ol_store_id, sod.item_id "
                    query_get_detail_id += "FROM tb_pl_sales_order_del_det a "
                    query_get_detail_id += "INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = a.id_sales_order_det "
                    query_get_detail_id += "WHERE a.id_pl_sales_order_del = '" + id_pl_sales_order_del + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_pl_sales_order_del_det_counting(id_pl_sales_order_del_det, id_pl_prod_order_rec_det_unique, pl_sales_order_del_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL "
                        End If
                        Dim pl_sales_order_del_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim ol_store_id_counting As String = GVBarcode.GetRowCellValue(p, "ol_store_id").ToString
                        Dim item_id_counting As String = GVBarcode.GetRowCellValue(p, "item_id").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And ol_store_id_counting = data_get_detail_id.Rows(p1)("ol_store_id").ToString And item_id_counting = data_get_detail_id.Rows(p1)("item_id").ToString Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_pl_sales_order_del_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + pl_sales_order_del_det_counting + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'reserved unique code
                    If is_use_unique_code_wh = "1" Then
                        Dim quniq As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_pl_sales_order_del + " AND report_mark_type=43 AND id_report_status=1;
                        INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`,`id_pl_sales_order_del_det_counting`,`id_type`,`unique_code`,
                        `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`, `id_report`, `report_mark_type`, `id_report_status`) 
                        SELECT cc.id_comp, '" + id_wh_drawer + "', td.id_product,  tc.id_pl_prod_order_rec_det_unique,tc.id_pl_sales_order_del_det_counting, '1', 
                        CONCAT(p.product_full_code,tc.pl_sales_order_del_det_counting), td.id_design_price, td.design_price, -1, 1, NOW(), td.id_pl_sales_order_del,'43','1'
                        FROM tb_pl_sales_order_del_det td
                        INNER JOIN tb_pl_sales_order_del t ON t.id_pl_sales_order_del = td.id_pl_sales_order_del
                        INNER JOIN tb_pl_sales_order_del_det_counting tc ON tc.id_pl_sales_order_del_det = td.id_pl_sales_order_del_det
                        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_from
                        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                        INNER JOIN tb_m_product p ON p.id_product = td.id_product
                        INNER JOIN tb_m_design d ON d.id_design = p.id_design
                        WHERE t.id_pl_sales_order_del=" + id_pl_sales_order_del + "
                        AND d.is_old_design=2 AND t.is_use_unique_code_wh=1 "
                        execute_non_query(quniq, True, "", "", "", "")
                    End If


                    'submit who prepared
                    submit_who_prepared("43", id_pl_sales_order_del, id_user)


                    FormSalesDelOrder.GCSalesDelOrder.DataSource = Nothing
                    'FormSalesDelOrder.viewSalesDelOrder()
                    'FormSalesDelOrder.GVSalesDelOrder.FocusedRowHandle = find_row(FormSalesDelOrder.GVSalesDelOrder, "id_pl_sales_order_del", id_pl_sales_order_del)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Delivery Order : " + TxtSalesDelOrderNumber.Text + " was created successfully.")
                ElseIf action = "upd" Then
                    'update main table
                    Dim pl_sales_order_del_number As String = TxtSalesDelOrderNumber.Text
                    Dim query_main As String = "UPDATE tb_pl_sales_order_del SET pl_sales_order_del_number = '" + pl_sales_order_del_number + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_store_contact_to = '" + id_store_contact_to + "', pl_sales_order_del_note = '" + pl_sales_order_del_note + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_sales_order_del = '" + id_pl_sales_order_del + "'"
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_pl_sales_order_del_det(id_pl_sales_order_del, id_sales_order_det, id_product, id_design_price, design_price, pl_sales_order_del_det_qty, pl_sales_order_del_det_note) "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_pl_sales_order_del_det As String = GVItemList.GetRowCellValue(j, "id_pl_sales_order_del_det").ToString
                            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim pl_sales_order_del_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "pl_sales_order_del_det_qty").ToString)
                            Dim pl_sales_order_del_det_note As String = GVItemList.GetRowCellValue(j, "pl_sales_order_del_det_note").ToString

                            If id_pl_sales_order_del_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "VALUES('" + id_pl_sales_order_del + "', '" + id_sales_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + pl_sales_order_del_det_qty + "', '" + pl_sales_order_del_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_detail_upd As String = "UPDATE tb_pl_sales_order_del_det SET id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price='" + design_price + "', pl_sales_order_del_det_qty = '" + pl_sales_order_del_det_qty + "', pl_sales_order_del_det_note = '" + pl_sales_order_del_det_note + "' WHERE id_pl_sales_order_del_det = '" + id_pl_sales_order_del_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_pl_sales_order_del_det_list.Remove(id_pl_sales_order_del_det)
                            End If
                        Catch ex As Exception
                            'MsgBox(ex.ToString)
                        End Try
                    Next
                    If GVItemList.RowCount > 0 And jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    For j_del As Integer = 0 To (id_pl_sales_order_del_det_list.Count - 1)
                        Try
                            Dim query_detail_del As String = "DELETE FROM tb_pl_sales_order_del_det WHERE id_pl_sales_order_del_det = '" + id_pl_sales_order_del_det_list(j_del) + "'"
                            execute_non_query(query_detail_del, True, "", "", "", "")
                        Catch ex As Exception

                        End Try
                    Next

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_pl_sales_order_del_det, a.id_product "
                    query_get_detail_id += "FROM tb_pl_sales_order_del_det a "
                    query_get_detail_id += "WHERE a.id_pl_sales_order_del = '" + id_pl_sales_order_del + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_pl_sales_order_del_det_counting(id_pl_sales_order_del_det, id_pl_prod_order_rec_det_unique, pl_sales_order_del_det_counting) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_pl_sales_order_del_det_counting As String = GVBarcode.GetRowCellValue(p, "id_pl_sales_order_del_det_counting").ToString
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL "
                        End If
                        Dim pl_sales_order_del_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_pl_sales_order_del_det_counting = "0" Then
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_pl_sales_order_del_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + pl_sales_order_del_det_counting + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            End If
                        Next
                    Next
                    If GVBarcode.RowCount > 0 And jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    FormSalesDelOrder.viewSalesDelOrder()
                    FormSalesDelOrder.GVSalesDelOrder.FocusedRowHandle = find_row(FormSalesDelOrder.GVSalesDelOrder, "id_pl_sales_order_del", id_pl_sales_order_del)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Delivery Order : " + pl_sales_order_del_number + " was edited successfully.")
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        If id_combine <> "0" And (id_report_status = "1" Or id_report_status = "3") Then
            FormReportMark.GCMark.Enabled = False
        End If
        FormReportMark.id_report = id_pl_sales_order_del
        FormReportMark.report_mark_type = "43"
        FormReportMark.form_origin = Name
        FormReportMark.is_disabled_set_stt = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtSalesOrder_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSalesOrder.Validating
        EP_TE_cant_blank(EPForm, TxtSalesOrder)
        EPForm.SetIconPadding(TxtSalesOrder, 58)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
        ' EPForm.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 1)
    End Sub


    Private Sub BtnAddDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Dim id_product As String = "-1"
        Try
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
        FormSalesDelOrderSingle.id_comp = get_company_contact_x(id_comp_contact_from, "3")
        FormSalesDelOrderSingle.id_product = "0"
        FormSalesDelOrderSingle.action_pop = "ins"
        FormSalesDelOrderSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub allowScanPage()

    End Sub
    Sub disableControl()
        'is_scan = True
        GVBarcode.ActiveFilterString = ""
        MENote.Enabled = False
        If action = "ins" Then
            BtnBrowseSO.Enabled = False
        ElseIf action = "upd" Then
            DDBPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            BtnXlsBOF.Enabled = False
        End If
        BtnSave.Enabled = False
        BtnVerify.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        ControlBox = False
        BtnInfoSrs.Enabled = False
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        action_scan_btn = "start"
        loadCodeDetail()
        verifyTrans()
        disableControl()
        newRowsBc()
        focusColumnCodeBc()
        'allowDelete()
    End Sub

    Dim data_eos As DataTable = Nothing
    Sub loadCodeDetail()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        GVItemList.ActiveFilterString = "[status]<>'0'"
        If GVItemList.RowCount > 0 Then
            Dim id_product_param As String = ""
            Dim id_product_param_comma As String = ""
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                id_product_param += GVItemList.GetRowCellValue(i, "id_product").ToString
                id_product_param_comma += GVItemList.GetRowCellValue(i, "id_product").ToString
                If i < ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList)) Then
                    id_product_param += ";"
                    id_product_param_comma += ","
                End If
            Next
            codeAvailableIns(id_product_param, id_product_param_comma)
        End If
        GVItemList.ActiveFilterString = ""

        'check eos
        Try
            data_eos.Clear()
        Catch ex As Exception
        End Try
        data_eos = listBlockProductEOS(id_commerce_type)
        Cursor = Cursors.Default
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        'is_scan = False
        action_scan_btn = "stop"
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next

        enableScan()
    End Sub

    Sub enableScan()
        MENote.Enabled = True
        If action = "ins" Then
            BtnBrowseSO.Enabled = True
        ElseIf action = "upd" Then
            DDBPrint.Enabled = True
            BMark.Enabled = True
            BtnAttachment.Enabled = True
            BtnXlsBOF.Enabled = True
        End If
        BtnSave.Enabled = True
        BtnVerify.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        ControlBox = True
        BtnInfoSrs.Enabled = True
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        action_scan_btn = "delete"
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()
        'Dim id_pl_sales_order_del_det_counting As String = "-1"
        'Try
        '    id_pl_sales_order_del_det_counting = GVBarcode.GetFocusedRowCellValue("id_pl_sales_order_del_det_counting").ToString
        'Catch ex As Exception
        'End Try

        'If action = "ins" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '        deleteRowsBc()
        '        If id_product <> "" Or id_product <> Nothing Then
        '            GVBarcode.ApplyFindFilter("")
        '            countQty(id_product)
        '        End If
        '        GCItemList.RefreshDataSource()
        '        GVItemList.RefreshData()
        '        allowDelete()
        '    End If
        'ElseIf action = "upd" Then
        '    If id_pl_sales_order_del_det_counting = "0" Then
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '            deleteRowsBc()
        '            If id_product <> "" Or id_product <> Nothing Then
        '                GVBarcode.ApplyFindFilter("")
        '                countQty(id_product)
        '            End If
        '            GCItemList.RefreshDataSource()
        '            GVItemList.RefreshData()
        '            allowDelete()
        '        End If
        '    Else
        '        errorCustom("This data already locked and can't delete.")
        '    End If
        'End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        'If e.Column.FieldName = "no" Then
        '    e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        'End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = "0"
        Dim id_product As String = ""
        Dim product_name As String = ""
        Dim id_design_cat As String = ""
        Dim size As String = ""
        Dim prod_class As String = ""
        Dim prod_color As String = ""
        Dim prod_sht As String = ""
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0
        Dim ol_store_id As String = ""
        Dim item_id As String = ""
        Dim is_old As String = "0"
        Dim prc As Decimal = 0

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
            id_product = dt_filter(0)("id_product").ToString
            product_name = dt_filter(0)("name").ToString
            id_design_cat = dt_filter(0)("id_design_cat").ToString
            size = dt_filter(0)("size").ToString
            prod_class = dt_filter(0)("class").ToString
            prod_color = dt_filter(0)("color").ToString
            prod_sht = dt_filter(0)("sht").ToString
            is_old = dt_filter(0)("is_old_design").ToString
            prc = dt_filter(0)("design_price")
            code_found = True
        End If

        'check eos
        If data_eos.Rows.Count > 0 And code_found Then
            Dim data_eos_filter As DataRow() = data_eos.Select("[id_product]='" + id_product + "' ")
            If data_eos_filter.Length > 0 Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustomDialog("This item can't scan, because already proposed on EOS")
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If


        'get jum del & limit
        If id_commerce_type = "2" Then 'online store
            GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' AND [diff]>0 "
        Else
            GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' "
        End If

        GVItemList.FocusedRowHandle = 0
        Try
            jum_limit = GVItemList.GetFocusedRowCellValue("sales_order_det_qty_limit")
        Catch ex As Exception
        End Try
        Try
            jum_scan = GVItemList.GetFocusedRowCellValue("pl_sales_order_del_det_qty")
        Catch ex As Exception
        End Try
        Try
            ol_store_id = GVItemList.GetFocusedRowCellValue("ol_store_id").ToString
        Catch ex As Exception
        End Try
        Try
            item_id = GVItemList.GetFocusedRowCellValue("item_id").ToString
        Catch ex As Exception
        End Try
        makeSafeGV(GVItemList)

        If Not code_found Then
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
            GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
            stopCustomDialog("Data not found!")
        Else
            'jika akun normal/sale
            If (id_store_type = "1" Or id_store_type = "2") And id_so_status <> 8 Then
                If (id_store_type <> id_design_cat) And prc > 0 Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    If id_store_type = "1" Then
                        stopCustomDialog(TxtCodeCompTo.Text + " is only for normal product. ")
                    Else
                        stopCustomDialog(TxtCodeCompTo.Text + " is only for sale product. ")
                    End If
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If is_old = "1" Then 'no unique
                If jum_limit <= 0 Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("This item cannot scan, because limit qty is zero.")
                ElseIf jum_scan >= jum_limit Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("Maximum qty : " + jum_limit.ToString)
                Else
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_sales_order_del_det_counting", "0")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "class", prod_class)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "color", prod_color)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "sht", prod_sht)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "ol_store_id", ol_store_id)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "item_id", item_id)
                    countQty(id_product, ol_store_id, item_id)
                    newRowsBc()
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                End If
            ElseIf is_old = "2" Or is_old = "3" 'unique code
                'check duplicate code
                GVBarcode.ActiveFilterString = "[code]='" + code_check + "' AND [is_fix]='2' "
                If GVBarcode.RowCount > 0 Then
                    code_duplicate = True
                End If
                GVBarcode.ActiveFilterString = ""

                If Not code_found Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("Data not found or duplicate!")
                ElseIf code_duplicate Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("Data duplicate !")
                Else
                    If jum_limit <= 0 Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustomDialog("This item cannot scan, because limit qty is zero.")
                    ElseIf jum_scan >= jum_limit Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustomDialog("Maximum qty : " + jum_limit.ToString)
                    Else
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_sales_order_del_det_counting", "0")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "class", prod_class)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "color", prod_color)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "sht", prod_sht)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "ol_store_id", ol_store_id)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "item_id", item_id)
                        countQty(id_product, ol_store_id, item_id)
                        newRowsBc()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                End If
            Else 'not found
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustomDialog("Data not found !")
            End If
        End If
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    Sub infoQty()
        If action = "ins" Then
            FormInfoSalesOrder.id_pop_up = "1"
            FormInfoSalesOrder.id_sales_order = id_sales_order
            FormInfoSalesOrder.id_sales_order_det = "0"
            FormInfoSalesOrder.ShowDialog()
        ElseIf action = "upd" Then
            If check_edit_report_status(id_report_status, "43", id_pl_sales_order_del) Then
                FormInfoSalesOrder.id_pop_up = "1"
                FormInfoSalesOrder.id_pl_sales_order_del = id_pl_sales_order_del
                FormInfoSalesOrder.id_sales_order = id_sales_order
                FormInfoSalesOrder.id_sales_order_det = "0"
                FormInfoSalesOrder.ShowDialog()
            Else
                FormInfoSalesOrder.id_pop_up = "1"
                FormInfoSalesOrder.id_sales_order = id_sales_order
                FormInfoSalesOrder.id_sales_order_det = "0"
                FormInfoSalesOrder.ShowDialog()
            End If
        End If
    End Sub

    'check limit qty
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_sales_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name

        Dim query_check As String = ""
        If action = "ins" Then
            query_check = "call view_sales_order_limit('" + id_sales_order + "', '" + id_sales_order_det_cek + "', '0') "
        ElseIf action = "upd" Then
            query_check = "call view_sales_order_limit('" + id_sales_order + "', '" + id_sales_order_det_cek + "', '" + id_pl_sales_order_del + "') "
        End If

        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("sales_order_det_qty_limit"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        'View
        'FormViewSalesDelOrder.id_pl_sales_order_del = id_pl_sales_order_del
        'FormViewSalesDelOrder.ShowDialog()

        'Print
        ReportSalesDelOrderDet.id_pl_sales_order_del = id_pl_sales_order_del
        Dim Report As New ReportSalesDelOrderDet()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub getReport()
        'cek boleh print ato tidak
        Dim del As New ClassSalesDelOrder()
        If is_block_del_store = "1" And del.checkUnpaidInvoice(id_comp_group) Then
            stopCustom("Hold delivery")
            Cursor = Cursors.Default
            Exit Sub
        End If

        If is_use_unique_code = "-1" Then
            GridColumnNo.VisibleIndex = 0
            GVItemList.ActiveFilterString = "[pl_sales_order_del_det_qty]>0"
            For i As Integer = 0 To GVItemList.RowCount - 1
                GVItemList.SetRowCellValue(i, "no", (i + 1).ToString)
            Next
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            ReportSalesDelOrderDet.dt = GCItemList.DataSource
            ReportSalesDelOrderDet.id_pl_sales_order_del = id_pl_sales_order_del
            Dim Report As New ReportSalesDelOrderDet()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVItemList)

            'Parse val
            Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
            Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
            Report.LabelAddress.Text = MEAdrressCompTo.Text
            Report.LRecDate.Text = DEForm.Text
            Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
            Report.LabelNote.Text = MENote.Text
            Report.LabelPrepare.Text = TxtSalesOrder.Text
            Report.LabelCat.Text = LEStatusSO.Text
            Report.LabelUni3.Text = TxtNIK.Text
            Report.LabelUni6.Text = TxtEmployee.Text


            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            GVItemList.ActiveFilterString = ""
            GridColumnNo.Visible = False
        Else
            If id_commerce_type = "2" Then
                ReportSalesDelOrderOwnStore2.id = id_pl_sales_order_del
                ReportSalesDelOrderOwnStore2.rmt = "43"
                ReportSalesDelOrderOwnStore2.id_report_status = id_report_status
                ReportSalesDelOrderOwnStore2.id_store = id_store
                ReportSalesDelOrderOwnStore2.is_combine = "2"
                ReportSalesDelOrderOwnStore2.is_use_unique_code = is_use_unique_code
                ReportSalesDelOrderOwnStore2.is_no_print = "-1"
                Dim Report As New ReportSalesDelOrderOwnStore2()
                Report.XRBarcode.Text = TxtSalesDelOrderNumber.Text

                'Grid Detail
                'ReportStyleGridviewBlackLine(Report.GVItemList)

                'Parse val
                Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
                Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
                Report.LabelAddress.Text = MEAdrressCompTo.Text
                Report.LRecDate.Text = DEForm.Text
                Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
                Report.LabelNote.Text = MENote.Text
                Report.LabelPrepare.Text = TxtSalesOrder.Text
                Report.LabelCat.Text = LEStatusSO.Text
                'Report.LabelUni3.Text = TxtNIK.Text
                Report.LabelUni6.Text = TxtEmployee.Text
                If id_so_status = "7" Or id_so_status = "9" Then
                    Report.PanelUni.Visible = True
                Else
                    Report.PanelUni.Visible = False
                End If

                'Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            Else
                ReportSalesDelOrderOwnStore.id = id_pl_sales_order_del
                ReportSalesDelOrderOwnStore.rmt = "43"
                ReportSalesDelOrderOwnStore.id_report_status = id_report_status
                ReportSalesDelOrderOwnStore.id_store = id_store
                ReportSalesDelOrderOwnStore.is_combine = "2"
                ReportSalesDelOrderOwnStore.is_use_unique_code = is_use_unique_code
                ReportSalesDelOrderOwnStore.is_no_print = "-1"
                Dim Report As New ReportSalesDelOrderOwnStore()
                Report.XRBarcode.Text = TxtSalesDelOrderNumber.Text

                'Grid Detail
                'ReportStyleGridviewBlackLine(Report.GVItemList)

                'Parse val
                Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
                Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
                Report.LabelAddress.Text = MEAdrressCompTo.Text
                Report.LRecDate.Text = DEForm.Text
                Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
                Report.LabelNote.Text = MENote.Text
                Report.LabelPrepare.Text = TxtSalesOrder.Text
                Report.LabelCat.Text = LEStatusSO.Text
                'Report.LabelUni3.Text = TxtNIK.Text
                Report.LabelUni6.Text = TxtEmployee.Text
                If id_so_status = "7" Or id_so_status = "9" Then
                    Report.PanelUni.Visible = True
                Else
                    Report.PanelUni.Visible = False
                End If

                'Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            End If
        End If
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("HAH")
        'Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        'e.Appearance.BackColor = Color.White
        'e.Appearance.BackColor2 = Color.White

        'Try
        'Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
        'If id_product_check = id_product_style Then
        'e.Appearance.BackColor = Color.Lavender
        'e.Appearance.BackColor2 = Color.White
        'End If
        'Catch ex As Exception
        'End Try
    End Sub

    Public Sub my_color_cell2(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            If id_product_check = id_product_style Then
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_sales_order_del
        FormDocumentUpload.report_mark_type = "43"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub DDBPrint_Click(sender As Object, e As EventArgs) Handles DDBPrint.Click

    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        If is_use_unique_code = "-1" Then
            ReportSalesDelOrderDet.id_pre = "1"
        Else
            If id_commerce_type = "2" Then
                ReportSalesDelOrderOwnStore2.id_pre = "1"
            Else
                ReportSalesDelOrderOwnStore.id_pre = "1"
            End If
        End If
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        If is_use_unique_code = "-1" Then
            ReportSalesDelOrderDet.id_pre = "-1"
        Else
            If id_commerce_type = "2" Then
                ReportSalesDelOrderOwnStore2.id_pre = "-1"
            Else
                ReportSalesDelOrderOwnStore.id_pre = "-1"
            End If
        End If

        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVItemList.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "status") Then
                Dim val As Integer = 0
                Try
                    val = CType(sender.GetRowCellValue(e.RowHandle, sender.Columns("status")), Integer)
                Catch ex As Exception

                End Try
                If val > 0 Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                ElseIf val < 0 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.Yellow
                Else
                    e.Appearance.BackColor = Color.Green
                    e.Appearance.BackColor2 = Color.Green
                End If
            End If
        End If
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDeleteScan.KeyDown
        If e.KeyCode = Keys.Enter And TxtDeleteScan.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            GVBarcode.ActiveFilterString = "[code]='" + TxtDeleteScan.Text + "'"
            If GVBarcode.RowCount <= 0 Then
                stopCustomDialog("Code not found.")
                GVBarcode.ActiveFilterString = ""
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            Else
                Dim id_pl_sales_order_del_det_counting As String = "-1"
                Try
                    id_pl_sales_order_del_det_counting = GVBarcode.GetFocusedRowCellValue("id_pl_sales_order_del_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                        Dim ol_store_id As String = GVBarcode.GetFocusedRowCellValue("ol_store_id").ToString
                        Dim item_id As String = GVBarcode.GetFocusedRowCellValue("item_id").ToString
                        deleteRowsBc()
                        If id_product <> "" Or id_product <> Nothing Then
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_product, ol_store_id, item_id)
                        End If
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                ElseIf action = "upd" Then

                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GridColumnOrderNumber.VisibleIndex = 6
            GridColumnCustomer.VisibleIndex = 7
            GridColumnNoteDel.VisibleIndex = 8
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
            GridColumnCode.VisibleIndex = 0
            GridColumnName.VisibleIndex = 1
            GridColumnSize.VisibleIndex = 2
            GridColumnQty.VisibleIndex = 3
            GridColumnPriceType.VisibleIndex = 4
            GridColumnPrice.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnRemark.VisibleIndex = 7
            GridColumnStatus.Visible = False
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GridColumnOrderNumber.Visible = False
            GridColumnCustomer.Visible = False
            GridColumnNoteDel.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
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
                If j = 0 Then 'code A
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then ' B
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_sales_order_del_det_qty")
                ElseIf j = 2 Then 'number C
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from D
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to E
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                ElseIf j = 5 Then 'remark detil F
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_sales_order_del_det_note").ToString
                ElseIf j = 6 Then 'order number G
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtOLShopNumber.Text
                ElseIf j = 7 Then 'customer Name H
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtCustomer.Text
                ElseIf j = 8 Then 'note I
                    wSheet.Cells(rowIndex + 1, colIndex) = MENote.Text
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

    Private Sub GVItemList_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVItemList.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Cursor = Cursors.WaitCursor
        'cek qty limit SO di DB
        verifyTrans()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesDelOrderNumber.Text.ToString
        ElseIf e.Column.FieldName = "status" AndAlso e.IsGetData Then
            e.Value = getDiff(view, e.ListSourceRowIndex)
        End If
    End Sub

    Private Function getDiff(view As DevExpress.XtraGrid.Views.Grid.GridView, listSourceRowIndex As Integer) As String
        Dim qty As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "pl_sales_order_del_det_qty"))
        Dim limit As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "sales_order_det_qty_limit"))
        Dim diff As Integer = qty - limit
        Dim stt As String = ""
        If diff > 0 Then
            stt = "+" + diff.ToString
        Else
            stt = diff.ToString
        End If
        Return stt
    End Function

    Private Sub BtnCombineDel_Click(sender As Object, e As EventArgs) Handles BtnCombineDel.Click
        Cursor = Cursors.WaitCursor
        FormSalesDelOrderSlip.action = "ins"
        FormSalesDelOrderSlip.direct_menu = True
        FormSalesDelOrderSlip.ShowDialog()
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesDelOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            FormMenuAuth.type = "13"
            FormMenuAuth.ShowDialog()
        End If
    End Sub

    Private Sub RepositoryItemTextEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles RepositoryItemTextEdit.KeyDown
        cforKeyDown = ChrW(e.KeyCode)
    End Sub

    Private Sub RepositoryItemTextEdit_KeyUp(sender As Object, e As KeyEventArgs) Handles RepositoryItemTextEdit.KeyUp
        If Len(GVBarcode.EditingValue.ToString) > 1 Then
            If cforKeyDown <> ChrW(e.KeyCode) OrElse cforKeyDown = vbNullChar Then
                cforKeyDown = vbNullChar
                GVBarcode.SetRowCellValue(GVBarcode.FocusedRowHandle, "code", "")
                Return
            End If

            Dim elapsed As TimeSpan = DateTime.Now - _lastKeystroke

            If elapsed.TotalMilliseconds > speed_barcode_read Then GVBarcode.SetRowCellValue(GVBarcode.FocusedRowHandle, "code", "")

            'If e.KeyCode = Keys.[Return] AndAlso TextEdit1.Text.Count > 0 Then
            'action enter
            'End If
        End If

        _lastKeystroke = DateTime.Now
    End Sub
End Class