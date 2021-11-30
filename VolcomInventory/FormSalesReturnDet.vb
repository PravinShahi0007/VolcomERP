﻿Imports Microsoft.Office.Interop

Public Class FormSalesReturnDet
    Public action As String
    Public id_sales_return As String = "-1"
    Public id_sales_return_order As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_wh_drawer_store As String = "-1"
    Public id_wh_rack_store As String = "-1"
    Public id_wh_locator_store As String = "-1"
    Public id_store As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sales_return_det_list As New List(Of String)
    Public id_sales_return_det_counting_list As New List(Of String)
    Public id_sales_return_det_drawer_list As New List(Of String)
    Public id_sales_return_det_drawer_detail_list As New List(Of String)
    Public id_comp_user As String = "-1"
    Public dt As New DataTable
    Public dt_cust As New DataTable
    Public id_comp_to As String = "-1"
    Public id_drawer As String = "-1"
    Public id_pre As String = "-1"
    'Dim is_scan As Boolean = False
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_ret")
    Public bof_xls_nsi As String = get_setup_field("bof_xls_nsi")

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'updated 19 December 2014
    Dim locator_sel As String = "-1"
    Dim rack_sel As String = "-1"
    Dim drawer_sel As String = "-1"
    Dim is_save_unreg_unique As String = "-1"
    Dim is_scan_prob As String = "-1"
    Public id_ret_type As String = ""
    Public is_view As String = "-1"
    Dim id_store_type As String = "-1"
    Public id_wh_type As String = "-1"

    Public is_use_unique_code As String = "2"
    Dim id_commerce_type As String = "-1"
    Dim action_scan_btn As String = ""
    Public is_non_list As String = "-1"
    Public is_for_approve_combine As String = "-1"
    Public id_wh_awb_det As String = "-1"
    Public id_return_note As String = "-1"

    Dim is_input_manual_ret_store As String = "2"

    'scan
    Private cforKeyDown As Char = vbNullChar
    Private _lastKeystroke As DateTime = DateTime.Now
    Public speed_barcode_read As Integer = get_setup_field("speed_barcode_read")
    Public speed_barcode_read_timer As Integer = get_setup_field("speed_barcode_read_timer")

    Private Sub FormSalesReturnDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_type_scan()

        LUETypeScan.EditValue = "2"

        'cek input mnual surat jalan
        is_input_manual_ret_store = get_setup_field("is_input_manual_ret_store")
        If is_input_manual_ret_store = "1" Then
            TxtStoreReturnNumber.Properties.ReadOnly = False
        Else
            TxtStoreReturnNumber.Properties.ReadOnly = True
        End If

        viewReportStatus()
        actionLoad()

        'sementara bahkan selamanya
        SCCStorage.Panel2.Hide()
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
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("design_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            XTPStorage.PageEnabled = False
            TxtSalesReturnNumber.Text = ""
            TxtCombineNumber.Text = ""
            TxtCombineFrom.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            DDBPrint.Enabled = False

            'from waiting menu
            If id_sales_return_order <> "-1" Then
                viewSalesReturnOrder()
                BtnBrowseRO.Enabled = False
            End If
            check_but()

            'check is_save_unreg_unique (unique tdk teregister)
            is_save_unreg_unique = get_setup_field("is_save_unreg_unique")
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlScannedItem.Enabled = True
            GroupControlProb.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseRO.Enabled = False
            BtnInfoSrs.Enabled = True
            BtnCreateReturn.Visible = True
            BtnCreateReturnNonList.Visible = True
            BtnCreateNonStock.Visible = True
            DDBPrint.Enabled = True
            'mark
            If is_view = "1" Then
                BMark.Enabled = True
            Else
                BMark.Enabled = False
            End If


            'query view based on edit id's
            Dim query As String = "SELECT a.is_non_list,a.id_wh_drawer,dw.wh_drawer_code,b.id_sales_return_order, a.id_store_contact_from, d.id_commerce_type,(d.id_drawer_def) AS `id_wh_drawer_store`,IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`, a.id_comp_contact_to, (d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to, (d.comp_number) AS store_number_from, (d1.comp_number) AS comp_number_to, (d.address_primary) AS store_address_from, a.id_report_status, f.report_status, "
            query += "a.sales_return_note,a.sales_return_date, a.combine_number,a.sales_return_number, IFNULL(a.id_wh_awb_det,-1) AS `id_wh_awb_det`, IFNULL(a.id_return_note,-1) AS `id_return_note`,sales_return_store_number,b.sales_return_order_number, "
            query += "DATE_FORMAT(a.sales_return_date,'%Y-%m-%d') AS sales_return_datex, (c.id_comp) AS id_store, (c1.id_comp) AS id_comp_to, dw.wh_drawer, rc.wh_rack, loc.wh_locator, a.id_ret_type, rt.ret_type, so.sales_order_ol_shop_number, a.is_use_unique_code "
            query += "FROM tb_sales_return a "
            query += "INNER JOIN tb_sales_return_order b ON a.id_sales_return_order = b.id_sales_return_order "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "LEFT JOIN tb_m_wh_drawer dw ON dw.id_wh_drawer=a.id_wh_drawer "
            query += "LEFT JOIN tb_m_wh_rack rc ON rc.id_wh_rack = dw.id_wh_rack "
            query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rc.id_wh_locator "
            query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = d.id_drawer_def "
            query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "LEFT JOIN tb_lookup_ret_type rt ON rt.id_ret_type = a.id_ret_type "
            query += "LEFT JOIN tb_sales_order so ON so.id_sales_order = b.id_sales_order "
            query += "WHERE a.id_sales_return = '" + id_sales_return + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString

            id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString

            id_wh_awb_det = data.Rows(0)("id_wh_awb_det").ToString
            id_return_note = data.Rows(0)("id_return_note").ToString
            TxtStoreReturnNumber.Text = data.Rows(0)("sales_return_store_number").ToString
            TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString
            TxtSalesReturnOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString

            TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString

            MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_return_datex").ToString, 0)
            TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString
            TxtCombineNumber.Text = data.Rows(0)("combine_number").ToString
            MENote.Text = data.Rows(0)("sales_return_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_sales_return_order = data.Rows(0)("id_sales_return_order").ToString
            id_store = data.Rows(0)("id_store").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_wh_drawer_store = data.Rows(0)("id_wh_drawer_store").ToString
            id_wh_locator_store = data.Rows(0)("id_wh_locator_store").ToString
            id_wh_rack_store = data.Rows(0)("id_wh_rack_store").ToString
            id_commerce_type = data.Rows(0)("id_commerce_type").ToString

            drawer_sel = data.Rows(0)("wh_drawer").ToString
            rack_sel = data.Rows(0)("wh_rack").ToString
            locator_sel = data.Rows(0)("wh_locator").ToString

            id_drawer = data.Rows(0)("id_wh_drawer").ToString
            TEDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
            id_ret_type = data.Rows(0)("id_ret_type").ToString
            If id_ret_type = "2" Then
                XTPCombine.PageEnabled = False
            Else
                XTPCombine.PageEnabled = True
            End If

            TxtReturnType.Text = data.Rows(0)("ret_type").ToString
            TxtOLStoreOrder.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString
            is_non_list = data.Rows(0)("is_non_list").ToString
            If is_non_list = "1" Then
                CENonList.EditValue = True
            Else
                CENonList.EditValue = False
            End If


            'detail2
            viewDetail()
            view_barcode_list()
            view_barcode_list_prob()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If

            'for approve combine
            If is_for_approve_combine = "1" Then
                BtnCreateReturn.Visible = False
                BtnCreateReturnNonList.Visible = False
                BtnCreateNonStock.Visible = False
                XTCReturnMain.SelectedTabPageIndex = 2
            End If
        End If

        'ret type
        If id_ret_type = "2" Then
            XTCReturn.SelectedTabPageIndex = 1
            XTPReturn.PageEnabled = False
            XTPNonStock.PageEnabled = True
        Else
            XTCReturn.SelectedTabPageIndex = 0
            XTPNonStock.PageEnabled = False
            XTPReturn.PageEnabled = True
        End If


        'color form
        If is_non_list = "-1" Then
            Text = "Return"
            LookAndFeel.UseDefaultLookAndFeel = True
        End If

        If is_non_list = "1" Then
            Text = "Return Non List"
            LookAndFeel.UseDefaultLookAndFeel = False
            LookAndFeel.SkinName = "Office 2007 Green"
        End If

        If id_ret_type = "2" Then
            Text = "Non Inventory Stock"
            LookAndFeel.UseDefaultLookAndFeel = False
            LookAndFeel.SkinName = "Office 2007 Pink"
        End If
    End Sub
    Sub viewSalesReturnOrder()
        Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, a.id_wh_contact_to, d.is_use_unique_code, d.id_commerce_type, d.id_store_type,(d.comp_name) AS store_name_to, (d.id_drawer_def) AS `id_wh_drawer_store`, IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
        query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date "
        If id_ret_type = "4" Then
            query += ", wh.id_comp AS `id_wh`, wh.id_wh_type,wh.comp_number AS `wh_number`, wh.comp_name AS `wh_name`, wh.id_drawer_def AS `wh_drawer`, so.sales_order_ol_shop_number, wh.is_active AS `wh_is_active` "
        End If
        query += "FROM tb_sales_return_order a "
        'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = d.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        If id_ret_type = "4" Then
            query += "INNER JOIN tb_m_comp_contact whc ON whc.id_comp_contact = a.id_wh_contact_to "
            query += "INNER JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp "
            query += "INNER JOIN tb_sales_order so ON so.id_sales_order = a.id_sales_order "
        End If
        query += "WHERE a.id_sales_return_order ='" + id_sales_return_order + "' "
        query += "ORDER BY a.id_sales_return_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'SO
        TxtSalesReturnOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString

        'store data
        Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_to").ToString + "'"
        Dim id_comp_from As String = execute_query(query_comp_to, 0, True, "", "", "", "")
        id_store = id_comp_from
        id_store_contact_from = data.Rows(0)("id_store_contact_to").ToString
        id_store_type = data.Rows(0)("id_store_type").ToString
        id_commerce_type = data.Rows(0)("id_commerce_type").ToString
        'is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString
        is_use_unique_code = get_setup_field("is_use_unique_code_all")
        TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
        TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
        id_wh_drawer_store = data.Rows(0)("id_wh_drawer_store").ToString
        id_wh_rack_store = data.Rows(0)("id_wh_rack_store").ToString
        id_wh_locator_store = data.Rows(0)("id_wh_locator_store").ToString
        'MEAdrressCompTo.Text = get_company_x(id_comp_to, 3)

        If id_ret_type = "2" Then 'for non stock
            XTPCombine.PageEnabled = False
            id_comp_contact_to = id_store_contact_from
            TxtNameCompTo.Text = TxtNameCompFrom.Text
            TxtCodeCompTo.Text = TxtCodeCompFrom.Text
            id_comp_user = id_store
            setDefDrawer()
        ElseIf id_ret_type = "4" Then 'for ol store
            BtnBrowseContactTo.Enabled = True
            BPickDrawer.Enabled = False
            TxtOLStoreOrder.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            id_comp_contact_to = data.Rows(0)("id_wh_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("wh_name").ToString
            TxtCodeCompTo.Text = data.Rows(0)("wh_number").ToString
            id_wh_type = data.Rows(0)("id_wh_type").ToString
            If data.Rows(0)("wh_is_active").ToString <> "1" Then
                stopCustom("WH already freeze")
                Cursor = Cursors.Default
                Close()
                Exit Sub
            End If
            setDefDrawer()

            'get unik per item id
            Try
                dt_cust.Clear()
            Catch ex As Exception
            End Try
            Dim qry As String = "SELECT sod.item_id, sod.ol_store_id, CONCAT(p.product_full_code, dc.pl_sales_order_del_det_counting) AS `full_code`, '2' AS `is_used`
            FROM tb_sales_return_order_det rod
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = rod.id_sales_order_det
            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
            INNER JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
            INNER JOIN tb_m_product p ON p.id_product = dd.id_product
            WHERE rod.id_sales_return_order=" + id_sales_return_order + " "
            dt_cust = execute_query(qry, -1, True, "", "", "", "")
        End If

        If is_non_list = "1" Then
            CENonList.EditValue = True
        Else
            CENonList.EditValue = False
        End If


        'general
        viewDetail()
        view_barcode_list()
        view_barcode_list_prob()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        GroupControlProb.Enabled = True
        BtnInfoSrs.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True

        'referensi surat jalan
        Dim dtr As DataTable = getRefStoreRetNumber(id_store)
        If dtr.Rows.Count > 0 And TxtStoreReturnNumber.Text = "" Then
            FormSalesReturnStoreReturn.dt = dtr
            FormSalesReturnStoreReturn.ShowDialog()
        End If
    End Sub

    Function getRefStoreRetNumber(ByVal id_store_par As String) As DataTable
        Dim query As String = "SELECT ad.id_wh_awb_det,'0' AS id_return_note,'' AS label_number, ad.do_no, ad.qty, ad.is_active 
        FROM tb_wh_awbill_det_in ad
        INNER JOIN tb_wh_awbill a ON a.id_awbill = ad.id_awbill
        WHERE a.id_store=" + id_store_par + " AND ad.is_active=1 AND a.is_lock=1 
        UNION ALL 
        SELECT '0' AS id_wh_awb_det,rn.id_return_note,rn.label_number,rn.number_return_note AS do_no,rn.qty AS qty,1 AS is_active
        FROM tb_return_note rn 
        INNER JOIN tb_return_note_store st ON st.id_return_note=rn.id_return_note AND st.id_comp='" + id_store_par + "'
        WHERE rn.is_lock=1 AND rn.is_void=2"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Sub setDefDrawer()
        'get default drawer
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        Dim query_def_drw As String = ""
        query_def_drw += "SELECT IFNULL(drw.id_wh_drawer,'-1') AS `id_wh_drawer`, IFNULL(drw.wh_drawer_code,'') AS `wh_drawer_code`, "
        query_def_drw += "IFNULL(drw.wh_drawer,'') AS `wh_drawer` "
        query_def_drw += "FROM tb_m_comp comp "
        query_def_drw += "LEFT JOIN tb_m_wh_drawer drw ON comp.id_drawer_def = drw.id_wh_drawer "
        query_def_drw += "WHERE comp.id_comp='" + id_comp_param + "' "
        Dim data_def_drw As DataTable = execute_query(query_def_drw, -1, True, "", "", "", "")
        id_drawer = data_def_drw(0)("id_wh_drawer").ToString
        TEDrawer.Text = data_def_drw(0)("wh_drawer_code").ToString
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        dt.Clear()
        If action = "ins" Then
            'action
            Dim query As String = ""
            If is_non_list = "1" Then
                query = "CALL view_sales_return_order_limit_non_list('" + id_sales_return_order + "','" + id_store + "')"
            Else
                query = "CALL view_sales_return_order_limit_for_trans('" + id_sales_return_order + "', '0', '0')"
            End If
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            If id_ret_type = "4" Then
                For i As Integer = 0 To data.Rows.Count - 1

                Next
            End If
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_sales_return('" + id_sales_return + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_return_det_list.Add(data.Rows(i)("id_sales_return_det").ToString)
                'codeAvailableIns(data.Rows(i)("id_product").ToString, id_store, data.Rows(i)("id_design_price").ToString)
            Next
            GCItemList.DataSource = data
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('') AS name, ('') AS size,('') AS class, ('') AS color, ('') AS sht, ('0') AS id_sales_return_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_sales_return_det_counting, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price, CAST('0' AS DECIMAL(13,2)) AS design_price, ('0') AS id_design_price, '0' AS ` is_unique_report`, '' AS `ol_store_id`, '' AS `item_id` "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.sales_return_det_counting) AS code, (c.product_full_code) AS product_code, "
            query += "c.product_display_name AS `name`, cod.display_name AS `size`, cd.class, cd.color, cd.sht,
            (a.sales_return_det_counting) AS counting_code, "
            query += "a.id_sales_return_det_counting, ('2') AS is_fix, "
            query += "IFNULL(a.id_pl_prod_order_rec_det_unique,'0') AS `id_pl_prod_order_rec_det_unique`, b.id_product, "
            query += "d.bom_unit_price, b.id_design_price, b.design_price, a. is_unique_report "
            query += "FROM tb_sales_return_det_counting a "
            query += "INNER JOIN tb_sales_return_det b ON a.id_sales_return_det = b.id_sales_return_det "
            query += "JOIN tb_opt o "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product 
            INNER JOIN tb_m_design dsg ON dsg.id_design = c.id_design
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
	        ) cd ON cd.id_design = dsg.id_design "
            query += "INNER JOIN tb_m_product_code cc ON cc.id_product = c.id_product "
            query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
            query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
            query += "WHERE b.id_sales_return = '" + id_sales_return + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_return_det_counting_list.Add(data.Rows(i)("id_sales_return_det_counting").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub view_barcode_list_prob()
        Dim query As String = "SELECT '0' AS `no`,rp.id_sales_return_problem, rp.id_product, d.design_code, rp.scanned_code AS `code`,
            d.design_display_name AS `name`, cd.code_detail_name AS `size`, dcd.class, dcd.color, dcd.sht,
            rp.remark, rp.is_unique_not_found, rp.is_no_stock, rp.id_scan_type, ty.scan_type
            FROM tb_sales_return_problem rp
            INNER JOIN tb_m_product p ON p.id_product = rp.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
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
	        ) dcd ON dcd.id_design = d.id_design
            INNER JOIN tb_lookup_scan_type ty ON rp.id_scan_type = ty.id_scan_type
            WHERE rp.id_sales_return=" + id_sales_return + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcodeProb.DataSource = data
        GVBarcodeProb.BestFitColumns()
    End Sub

    Sub viewCombine()
        Cursor = Cursors.WaitCursor
        If TxtCombineNumber.Text = "" And action = "upd" Then
            BtnCombineReturn.Visible = True
        Else
            BtnCombineReturn.Visible = False
        End If
        Dim query As String = "SELECT rd.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        prc.id_design_price, rd.design_price, pt.design_price_type, SUM(rd.sales_return_det_qty) AS `sales_return_det_qty`,
        '" + TxtCombineNumber.Text + "' AS `number`, '" + TxtCodeCompFrom.Text + "' AS `from`, '" + TxtCodeCompTo.Text + "' AS `to`
        FROM tb_sales_return r
        INNER JOIN tb_sales_return_det rd ON rd.id_sales_return = r.id_sales_return
        INNER JOIN tb_m_product p ON p.id_product = rd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = rd.id_design_price
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        WHERE r.id_sales_return>0 AND r.sales_return_store_number='" + addSlashes(TxtStoreReturnNumber.Text) + "' 
        AND r.id_store_contact_from=" + id_store_contact_from + " "
        If BtnCombineReturn.Visible = True Then
            query += "AND r.id_report_status=1 AND r.combine_number='' AND r.last_update_by='" + id_user + "' "
        Else
            query += "AND r.combine_number='" + addSlashes(TxtCombineNumber.Text) + "' "
        End If
        query += "GROUP BY rd.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCombine.DataSource = data
        GVCombine.BestFitColumns()

        'member number
        Dim qm As String = "SELECT GROUP_CONCAT(DISTINCT r.sales_return_number ORDER BY r.id_sales_return ASC SEPARATOR ', ') AS `number`
                FROM tb_sales_return r
                WHERE r.combine_number='" + addSlashes(TxtCombineNumber.Text) + "' AND r.sales_return_store_number='" + addSlashes(TxtStoreReturnNumber.Text) + "' "
        If BtnCombineReturn.Visible = True Then
            qm += "AND r.last_update_by='" + id_user + "' AND r.id_ret_type!=2 "
        End If
        qm += "GROUP BY r.combine_number "
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        If dm.Rows.Count > 0 Then
            TxtCombineFrom.Text = dm.Rows(0)("number").ToString
        End If
        Cursor = Cursors.Default
    End Sub



    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_product_param_or As String, ByVal id_store_param As String, ByVal id_design_price_param As String, ByVal id_product_param_comma As String)
        'unique
        Dim query As String = ""
        If is_use_unique_code = "1" Then
            query = "CALL view_stock_fg_unique_with_table('" + id_product_param_comma + "', '" + id_store + "', '" + id_wh_drawer_store + "')"
        Else
            query = "CALL view_stock_fg_unique_ret('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "','0')"
        End If

        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        dt = datax
        'For k As Integer = 0 To (datax.Rows.Count - 1)
        'insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString), datax.Rows(k)("id_design_price").ToString, Decimal.Parse(datax.Rows(k)("design_price").ToString))
        'Next

        'not unique 
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_product_param)
        Dim data_not As DataTable = execute_query(query_not, -1, True, "", "", "", "")

        'merge
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

    Sub codeAvailableInsProb(ByVal id_product_param As String, ByVal id_store_param As String, ByVal id_design_price_param As String)

    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal, ByVal id_design_price_param As String, ByVal design_price_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("id_design_price") = id_design_price_param
        R("design_price") = design_price_param
        R("is_old_design") = "2"
        dt.Rows.Add(R)
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

    Private Sub BtnBrowseRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseRO.Click
        FormPopUpSalesReturnOrder.id_pop_up = "1"
        FormPopUpSalesReturnOrder.id_sales_return_order_det = "0"
        FormPopUpSalesReturnOrder.id_sales_return = "0"
        FormPopUpSalesReturnOrder.ShowDialog()
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
        Dim rm As String = ""
        If id_ret_type = "1" Then
            rm = "46"
        ElseIf id_ret_type = "3" Then
            rm = "113"
        Else
            rm = "111"
        End If
        If check_edit_report_status(id_report_status, rm, id_sales_return) Then
            PanelControlNav.Enabled = True
            PanelNavBarcode.Enabled = False
            PanelNavBarcodeProb.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = False
            TxtStoreReturnNumber.Properties.ReadOnly = True
            BtnInfoSrs.Enabled = True
            GridColumnQtyLimit.Visible = False
            BtnBrowseContactTo.Enabled = False
            BPickDrawer.Enabled = True
        Else
            PanelControlNav.Enabled = False
            PanelNavBarcode.Enabled = False
            PanelNavBarcodeProb.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            TxtStoreReturnNumber.Properties.ReadOnly = True
            BtnInfoSrs.Enabled = False
            GridColumnQtyLimit.Visible = False
            BtnBrowseContactTo.Enabled = False
            BPickDrawer.Enabled = False
        End If
        BtnVerify.Enabled = False
        GridColumnStt.Visible = False
        BtnBrowseStoreReturn.Enabled = False

        'non stock report
        If is_view = "1" Then
            BtnCreateNonStock.Visible = False
        End If

        'attachment
        If check_attach_report_status(id_report_status, rm, id_sales_return) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'Pre Print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'Btn Storage
        If check_storage_report_status(id_report_status) Then
            XTPStorage.PageEnabled = True
        Else
            XTPStorage.PageEnabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        TxtSalesReturnNumber.Focus()
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

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        'If GVBarcode.RowCount > 0 Then
        '    BDelete.Enabled = True
        'Else
        '    BDelete.Enabled = False
        'End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
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
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [ol_store_id]='" + ol_store_id_param + "' AND [item_id]='" + item_id_param + "' "
            ElseIf action_scan_btn = "delete" Then
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [ol_store_id]='" + ol_store_id_param + "' AND [item_id]='" + item_id_param + "' "
            End If
            GVItemList.FocusedRowHandle = 0
            makeSafeGV(GVItemList)

            Dim tot As Integer = 0
            If action_scan_btn = "start" Then
                tot = GVItemList.GetFocusedRowCellValue("sales_return_det_qty") + 1
            ElseIf action_scan_btn = "delete" Then
                tot = GVItemList.GetFocusedRowCellValue("sales_return_det_qty") - 1
            End If

            'update dt
            Dim dtf As DataRow() = dt_cust.Select("[ol_store_id]='" + ol_store_id_param + "' AND [item_id]='" + item_id_param + "' ")
            If action_scan_btn = "start" Then
                dtf(0)("is_used") = "1"
            ElseIf action_scan_btn = "delete" Then
                dtf(0)("is_used") = "2"
            End If


            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("sales_return_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("sales_return_det_qty", tot)
        Else
            Dim tot As Decimal = 0.0
            For i As Integer = 0 To GVBarcode.RowCount - 1
                Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
                If id_product = id_product_param Then
                    tot = tot + 1.0
                End If
            Next

            Dim indeks As Integer = -1
            For j As Integer = 0 To GVItemList.RowCount - 1
                Try
                    Dim id_productx As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                    If id_productx = id_product_param Then
                        indeks = j
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next



            GVItemList.FocusedRowHandle = indeks
            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("sales_return_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("sales_return_det_qty", tot)
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpSalesReturnOrder.id_pop_up = "2"
        FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
        FormPopUpSalesReturnOrder.id_sales_return_order_det = "0"
        If action = "ins" Then
            FormPopUpSalesReturnOrder.id_sales_return = "0"
        Else
            FormPopUpSalesReturnOrder.id_sales_return = id_sales_return
        End If
        FormPopUpSalesReturnOrder.ShowDialog()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim id_sales_return_order_det As String = "0"
        'Dim qty_from_wh As Decimal = 0.0
        Dim qty As Decimal = 0.0
        Dim id_sales_return_det = "-1"
        Try
            id_sales_return_order_det = GVItemList.GetRowCellValue(GVItemList.FocusedRowHandle, "id_sales_return_order_det")
            'qty_from_wh = Decimal.Parse(GVItemList.GetFocusedRowCellValue("qty_from_wh"))
            qty = Decimal.Parse(GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            id_sales_return_det = GVItemList.GetFocusedRowCellValue("id_sales_return_det").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            If qty = 0.0 Then
                'MsgBox(id_sales_return_order_det)
                FormPopUpSalesReturnOrder.id_pop_up = "2"
                FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
                FormPopUpSalesReturnOrder.id_sales_return_order_det = id_sales_return_order_det
                FormPopUpSalesReturnOrder.indeks_edit = GVItemList.FocusedRowHandle()
                FormPopUpSalesReturnOrder.ShowDialog()
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        ElseIf action = "upd" Then
            If id_sales_return_det = "0" Then
                If qty = 0.0 Then
                    'MsgBox(id_sales_return_order_det)
                    FormPopUpSalesReturnOrder.id_pop_up = "2"
                    FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
                    FormPopUpSalesReturnOrder.id_sales_return_order_det = id_sales_return_order_det
                    FormPopUpSalesReturnOrder.indeks_edit = GVItemList.FocusedRowHandle()
                    FormPopUpSalesReturnOrder.ShowDialog()
                Else
                    errorCustom("This data already locked and can't edit.")
                End If
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        Dim id_sales_return_order_det As String = "0"
        Dim qty As Decimal = 0.0
        Dim id_product As String = "0"
        Dim id_sales_return_det = "-1"
        Dim bom_unit_price As Decimal = 0.0
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim code As String = ""
        Try
            id_sales_return_order_det = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
            qty = Decimal.Parse(GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_sales_return_det = GVItemList.GetFocusedRowCellValue("id_sales_return_det").ToString
            bom_unit_price = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
            counting_code = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
            id_pl_prod_order_rec_det_unique = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
            code = GVBarcode.GetFocusedRowCellValue("code").ToString
        Catch ex As Exception

        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            codeAvailableDel(id_product)
            deleteDetailBC(id_product)
            deleteDetailDrawer(id_product)
            check_but()
        End If
        Cursor = Cursors.Default
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

    Private Sub FormSalesReturnDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_return
        If id_ret_type = "1" Then
            FormReportMark.report_mark_type = "46"
        ElseIf id_ret_type = "3" Then
            FormReportMark.report_mark_type = "113"
        ElseIf id_ret_type = "4" Then
            FormReportMark.report_mark_type = "120"
        Else
            FormReportMark.report_mark_type = "111"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        check_but()
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell
        ''AddHandler GVBarcode.RowCellStyle, AddressOf my_color_cell
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
        ''GCBarcode.RefreshDataSource()
        ''GVBarcode.RefreshData()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        If GVBarcode.RowCount = 0 Then
            FormPopUpContact.id_pop_up = "41"
            FormPopUpContact.is_must_active = "1"
            FormPopUpContact.id_departement = id_departement_user
            FormPopUpContact.id_cat = "5"
            FormPopUpContact.ShowDialog()
        Else
            stopCustom("Scan already process for this destination. If you want to change destination, please discard this transaction")
        End If
    End Sub

    Private Sub TxtSalesReturnOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSalesReturnOrderNumber.Validating
        EP_TE_cant_blank(EPForm, TxtSalesReturnOrderNumber)
        EPForm.SetIconPadding(TxtSalesReturnOrderNumber, 58)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Function verifyTrans() As Boolean
        GridColumnStt.Visible = True
        Dim cond_list As Boolean = True
        'Dim query_cek_stok As String = "CALL view_stock_fg('" + id_store + "', '" + id_wh_locator_store + "', '" + id_wh_rack_store + "', '" + id_wh_drawer_store + "', '0', 4, '9999-01-01') "
        Dim query_cek_stok As String = ""
        If is_non_list = "1" Then
            query_cek_stok = "CALL view_sales_return_order_limit_non_list('" + id_sales_return_order + "','" + id_store + "') "
        Else
            query_cek_stok = "CALL view_sales_return_order_limit_for_trans('" + id_sales_return_order + "','0','0') "
        End If
        Dim dt_cek As DataTable = execute_query(query_cek_stok, -1, True, "", "", "", "")

        If id_commerce_type = "2" Then
            'online store
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_sales_return_order_det_cek As String = GVItemList.GetRowCellValue(i, "id_sales_return_order_det").ToString
                Dim name_cek As String = GVItemList.GetRowCellValue(i, "name").ToString
                Dim size_cek As String = GVItemList.GetRowCellValue(i, "size").ToString
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "sales_return_det_qty")
                Dim qty_soh As Integer = 0
                Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_sales_return_order_det]='" + id_sales_return_order_det_cek + "' ")
                If dt_filter_cek.Length > 0 Then
                    ' qty_soh = dt_filter_cek(0)("qty_all_product")
                    qty_soh = dt_filter_cek(0)("sales_return_det_qty_limit")
                Else
                    qty_soh = 0
                End If

                If qty_cek > qty_soh Then
                    cond_list = False
                End If
                GVItemList.SetRowCellValue(i, "sales_return_det_qty_limit", qty_soh)
            Next
        Else
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_product_cek As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                Dim name_cek As String = GVItemList.GetRowCellValue(i, "name").ToString
                Dim size_cek As String = GVItemList.GetRowCellValue(i, "size").ToString
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "sales_return_det_qty")
                Dim qty_soh As Integer = 0
                Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_product]='" + id_product_cek + "' ")
                If dt_filter_cek.Length > 0 Then
                    ' qty_soh = dt_filter_cek(0)("qty_all_product")
                    qty_soh = dt_filter_cek(0)("sales_return_det_qty_limit")
                Else
                    qty_soh = 0
                End If

                If qty_cek > qty_soh Then
                    cond_list = False
                End If
                GVItemList.SetRowCellValue(i, "sales_return_det_qty_limit", qty_soh)
            Next
        End If
        Return cond_list
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        makeSafeGV(GVItemList)
        makeSafeGV(GVBarcode)
        makeSafeGV(GVBarcodeProb)

        'check limit
        Dim error_list As String = ""
        Dim cond_list As Boolean = True
        If id_ret_type <> "2" Then
            GVItemList.ActiveFilterString = "[sales_return_det_qty]>0 "
            If action = "ins" Then
                cond_list = verifyTrans()
            End If
            GVItemList.ActiveFilterString = ""
            makeSafeGV(GVItemList)
        End If

        Dim block_stocktake As Boolean = True

        'cek stok
        If id_ret_type = "1" Or id_ret_type = "3" Then
            Cursor = Cursors.WaitCursor
            GVItemList.ActiveFilterString = "[sales_return_det_qty]>0 "
            If GVItemList.RowCount > 0 Then
                Dim qs As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; 
                            INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES "
                Dim id_prod As String = ""
                For s As Integer = 0 To GVItemList.RowCount - 1
                    If s > 0 Then
                        qs += ","
                        id_prod += ","
                    End If
                    qs += "('" + id_user + "','" + GVItemList.GetRowCellValue(s, "code").ToString + "','" + addSlashes(GVItemList.GetRowCellValue(s, "name").ToString) + "', '" + GVItemList.GetRowCellValue(s, "size").ToString + "', '" + GVItemList.GetRowCellValue(s, "id_product").ToString + "', '" + decimalSQL(GVItemList.GetRowCellValue(s, "sales_return_det_qty").ToString) + "') "
                    id_prod += GVItemList.GetRowCellValue(s, "id_product").ToString
                Next
                qs += "; CALL view_validate_stock(" + id_user + ", " + id_store + ", '" + id_prod + "',1); "
                Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")
                If dts.Rows.Count > 0 Then
                    Cursor = Cursors.Default
                    stopCustom("No stock available for some items.")
                    FormValidateStock.dt = dts
                    FormValidateStock.ShowDialog()
                    Exit Sub
                End If
            End If
            makeSafeGV(GVItemList)

            'block stocktake eos
            Dim all_product As List(Of String) = New List(Of String)

            For i = 0 To GVItemList.RowCount - 1
                If GVItemList.IsValidRowHandle(i) Then
                    If GVItemList.GetRowCellValue(i, "sales_return_det_qty") > 0 Then
                        all_product.Add(GVItemList.GetRowCellValue(i, "id_product").ToString)
                    End If
                End If
            Next

            block_stocktake = block_stocktake_eos(all_product)

            Cursor = Cursors.Default
        End If

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopRight) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 And id_ret_type <> "2" Then
            errorCustom("Return item data can't blank")
        ElseIf TxtStoreReturnNumber.Text = "" Then
            stopCustom("Store return number can't blank")
        ElseIf Not cond_list Then
            stopCustom("Please see different in column status.")
        ElseIf Not block_stocktake And id_commerce_type = "1" Then
            stopCustom("Some product already in EOS and need to stock take first.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim sales_return_store_number As String = TxtStoreReturnNumber.Text
                Dim sales_return_note As String = addSlashes(MENote.Text)
                Dim err As String = ""

                If action = "ins" Then
                    'query main table
                    Dim sales_return_number As String = ""
                    If id_ret_type = "1" Or id_ret_type = "3" Or id_ret_type = "4" Then
                        sales_return_number = header_number_sales("5")
                    Else
                        sales_return_number = header_number_sales("32")
                    End If

                    'referensi surat jalan
                    Dim id_wh_awb_det_simpan As String = "NULL"
                    If id_wh_awb_det = "-1" Or id_wh_awb_det = "0" Or id_wh_awb_det = "" Then
                        id_wh_awb_det_simpan = "NULL"
                    Else
                        id_wh_awb_det_simpan = id_wh_awb_det
                    End If
                    '
                    Dim id_return_note_simpan As String = "NULL"
                    If id_return_note = "-1" Or id_return_note = "0" Or id_return_note = "" Then
                        id_return_note_simpan = "NULL"
                    Else
                        id_return_note_simpan = id_return_note
                    End If

                    'header
                    Try
                        Dim query_main As String = "INSERT tb_sales_return(id_store_contact_from, id_comp_contact_to, id_sales_return_order, sales_return_number, sales_return_store_number, sales_return_date, sales_return_note,id_wh_drawer ,id_report_status, last_update, last_update_by, id_ret_type, is_use_unique_code, is_non_list, id_wh_awb_det, id_return_note) "
                        query_main += "VALUES('" + id_store_contact_from + "', '" + id_comp_contact_to + "', '" + id_sales_return_order + "', '" + sales_return_number + "', '" + sales_return_store_number + "', NOW(), '" + sales_return_note + "','" + id_drawer + "', '1', NOW(), " + id_user + ",'" + id_ret_type + "', '" + is_use_unique_code + "', '" + is_non_list + "', " + id_wh_awb_det_simpan + ", " + id_return_note_simpan + ");SELECT LAST_INSERT_ID(); "
                        id_sales_return = execute_query(query_main, 0, True, "", "", "", "")

                        If id_ret_type = "1" Then
                            increase_inc_sales("5")
                            'insert who prepared
                            insert_who_prepared("46", id_sales_return, id_user)
                        ElseIf id_ret_type = "3" Then
                            increase_inc_sales("5")
                            'insert who prepared
                            insert_who_prepared("113", id_sales_return, id_user)
                        ElseIf id_ret_type = "4" Then
                            increase_inc_sales("5")
                            'insert who prepared
                            insert_who_prepared("120", id_sales_return, id_user)
                        Else
                            increase_inc_sales("32")
                            'insert who prepared
                            insert_who_prepared("111", id_sales_return, id_user)
                        End If
                    Catch ex As Exception
                        err += "[header]:" + ex.ToString + ";"
                    End Try



                    'Detail return
                    Try
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        GVItemList.ActiveFilterString = "[sales_return_det_qty]>0 "
                        If GVItemList.RowCount > 0 Then
                            query_detail = "INSERT tb_sales_return_det(id_sales_return, id_sales_return_order_det, id_product, id_design_price, design_price, sales_return_det_qty, sales_return_det_note) VALUES "
                        End If
                        For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                            Try
                                Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_order_det").ToString
                                Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                                Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                                Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                                Dim sales_return_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_det_qty").ToString)
                                Dim sales_return_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_det_note").ToString

                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_return + "', '" + id_sales_return_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_det_qty + "', '" + sales_return_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If
                        GVItemList.ActiveFilterString = ""
                    Catch ex As Exception
                        err += "[detil]:" + ex.ToString + ";"
                    End Try


                    'get all detail id
                    Try
                        Dim query_get_detail_id As String = ""
                        If id_ret_type = "4" Then
                            'online store
                            query_get_detail_id += "SELECT a.id_sales_return_det, a.id_product, a.id_design_price, a.design_price, sod.ol_store_id, sod.item_id "
                            query_get_detail_id += "FROM tb_sales_return_det a "
                            query_get_detail_id += "INNER JOIN tb_sales_return_order_det rod ON rod.id_sales_return_order_det = a.id_sales_return_order_det 
                        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = rod.id_sales_order_det "
                            query_get_detail_id += "WHERE a.id_sales_return = '" + id_sales_return + "' "
                        Else
                            'offline store
                            query_get_detail_id += "SELECT a.id_sales_return_det, a.id_product, a.id_design_price, a.design_price, '' AS `ol_store_id`, '' AS `item_id` "
                            query_get_detail_id += "FROM tb_sales_return_det a "
                            query_get_detail_id += "WHERE a.id_sales_return = '" + id_sales_return + "' "
                        End If
                        Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                        'counting
                        Dim jum_ins_p As Integer = 0
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_sales_return_det_counting(id_sales_return_det, id_pl_prod_order_rec_det_unique, sales_return_det_counting, is_unique_report) VALUES "
                        End If
                        For p As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                            If id_pl_prod_order_rec_det_unique = "0" Then
                                id_pl_prod_order_rec_det_unique = "NULL "
                            End If
                            Dim sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                            Dim is_unique_report As String = GVBarcode.GetRowCellValue(p, "is_unique_report").ToString
                            Dim ol_store_id_counting As String = GVBarcode.GetRowCellValue(p, "ol_store_id").ToString
                            Dim item_id_counting As String = GVBarcode.GetRowCellValue(p, "item_id").ToString
                            For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                                If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And ol_store_id_counting = data_get_detail_id.Rows(p1)("ol_store_id").ToString And item_id_counting = data_get_detail_id.Rows(p1)("item_id").ToString Then
                                    If jum_ins_p > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + sales_return_det_counting + "', '" + is_unique_report + "') "
                                    jum_ins_p = jum_ins_p + 1
                                    Exit For
                                End If
                            Next
                        Next
                        If jum_ins_p > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        err += "[unique_trans]:" + ex.ToString + ";"
                    End Try


                    'unik record
                    'If is_use_unique_code = "1" Then
                    '    Dim un As New ClassSalesReturn()
                    '    un.insertUnique(id_sales_return)
                    'End If

                    'reserved unique code
                    Try
                        If is_use_unique_code = "1" Then
                            Dim quniq As String = "DELETE FROM tb_m_unique_code WHERE id_report=" + id_sales_return + " AND report_mark_type=46 AND id_report_status=1;
                            INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_pl_prod_order_rec_det_unique`, `id_sales_return_det_counting`,`id_type`,`unique_code`,
                            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`, `id_report`, `report_mark_type`, `id_report_status`) 
                            SELECT cc.id_comp, '" + id_wh_drawer_store + "', td.id_product, tc.id_pl_prod_order_rec_det_unique,tc.id_sales_return_det_counting, '4', 
                            CONCAT(p.product_full_code,tc.sales_return_det_counting), td.id_design_price, td.design_price, -1, tc.is_unique_report, NOW(),
                            td.id_sales_return, 46, 1
                            FROM tb_sales_return_det td
                            INNER JOIN tb_sales_return t ON t.id_sales_return = td.id_sales_return
                            INNER JOIN tb_sales_return_det_counting tc ON tc.id_sales_return_det = td.id_sales_return_det
                            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_store_contact_from
                            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                            INNER JOIN tb_m_product p ON p.id_product = td.id_product
                            INNER JOIN tb_m_design d ON d.id_design = p.id_design
                            WHERE t.id_sales_return=" + id_sales_return + "
                            AND d.is_old_design=2 
                            AND t.is_use_unique_code=1 "
                            execute_non_query(quniq, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        err += "[unique_master]:" + ex.ToString + ";"
                    End Try


                    'code problem scan
                    Try
                        Dim jum_ins_k As Integer = 0
                        Dim query_problem_stock As String = ""
                        If GVBarcodeProb.RowCount > 0 Then
                            query_problem_stock = "INSERT INTO tb_sales_return_problem(id_sales_return, id_product, scanned_code, remark, is_unique_not_found, is_no_stock, id_scan_type) VALUES "
                        End If
                        For k As Integer = 0 To ((GVBarcodeProb.RowCount - 1) - GetGroupRowCount(GVBarcodeProb))
                            Dim id_product As String = GVBarcodeProb.GetRowCellValue(k, "id_product").ToString
                            Dim scanned_code As String = GVBarcodeProb.GetRowCellValue(k, "code").ToString
                            Dim remark As String = addSlashes(GVBarcodeProb.GetRowCellValue(k, "remark").ToString)
                            Dim is_unique_not_found As String = addSlashes(GVBarcodeProb.GetRowCellValue(k, "is_unique_not_found").ToString)
                            Dim is_no_stock As String = addSlashes(GVBarcodeProb.GetRowCellValue(k, "is_no_stock").ToString)
                            Dim id_scan_type As String = addSlashes(GVBarcodeProb.GetRowCellValue(k, "id_scan_type").ToString)

                            If jum_ins_k > 0 Then
                                query_problem_stock += ", "
                            End If
                            query_problem_stock += "('" + id_sales_return + "','" + id_product + "','" + scanned_code + "', '" + remark + "', " + is_unique_not_found + ", " + is_no_stock + ", " + id_scan_type + ") "
                            jum_ins_k = jum_ins_k + 1
                        Next
                        If jum_ins_k > 0 Then
                            execute_non_query(query_problem_stock, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                        err += "[detail_no_stock]:" + ex.ToString + ";"
                    End Try


                    'reserved stock
                    Try
                        If id_ret_type <> "4" Then 'ol store reserved di ro
                            Dim stc_rev As ClassSalesReturn = New ClassSalesReturn()
                            stc_rev.reservedStock(id_sales_return)
                        End If
                    Catch ex As Exception
                        err += "[reserved_stock]:" + ex.ToString + ";"
                    End Try


                    If err = "" Then
                        If id_ret_type = "1" Then
                            'submit who prepared
                            submit_who_prepared("46", id_sales_return, id_user)
                        ElseIf id_ret_type = "3" Then
                            'submit who prepared
                            submit_who_prepared("113", id_sales_return, id_user)
                        ElseIf id_ret_type = "4" Then
                            'submit who prepared
                            submit_who_prepared("120", id_sales_return, id_user)
                        Else
                            'submit who prepared
                            submit_who_prepared("111", id_sales_return, id_user)
                        End If


                        FormSalesReturn.viewSalesReturn()
                        FormSalesReturn.viewSalesReturnOrder()
                        FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_sales_return)
                        action = "upd"
                        actionLoad()
                        exportToBOF(False)
                        infoCustom("Return #" + sales_return_number + " was created successfully ")
                    Else
                        execute_non_query("INSERT INTO tb_log_trans(id_report, report_mark_type, id_user, log_date, log) VALUES('" + id_sales_return + "', '46','" + id_user + "',NOW(),'" + addSlashes(err) + "');", True, "", "", "", "")
                        stopCustom("Save failed. Please contact Administrator.")
                    End If

                ElseIf action = "upd" Then
                    'update main table
                    Dim sales_return_number As String = TxtSalesReturnNumber.Text
                    Dim query_main As String = "UPDATE tb_sales_return SET id_store_contact_from = '" + id_store_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', sales_return_store_number= '" + sales_return_store_number + "', sales_return_note = '" + sales_return_note + "',id_wh_drawer='" + id_drawer + "', last_update = NOW(), last_update_by=" + id_user + " WHERE id_sales_return = '" + id_sales_return + "'"
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sales_return_det(id_sales_return, id_sales_return_order_det, id_product, id_design_price, design_price, sales_return_det_qty, sales_return_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_sales_return_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_det").ToString
                            Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim sales_return_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_det_qty").ToString)
                            Dim sales_return_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_det_note").ToString

                            If id_sales_return_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_return + "', '" + id_sales_return_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_det_qty + "', '" + sales_return_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                'Dim query_detail_upd As String = "UPDATE tb_sales_return_det SET id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price='" + design_price + "', sales_return_det_qty = '" + sales_return_det_qty + "', sales_return_det_note = '" + sales_return_det_note + "' WHERE id_sales_return_det = '" + id_sales_return_det + "'"
                                Dim query_detail_upd As String = "UPDATE tb_sales_return_det SET sales_return_det_note = '" + sales_return_det_note + "' WHERE id_sales_return_det = '" + id_sales_return_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_sales_return_det_list.Remove(id_sales_return_det)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'For j_del As Integer = 0 To (id_sales_return_det_list.Count - 1)
                    '    Try
                    '        Dim query_detail_del As String = "DELETE FROM tb_sales_return_det WHERE id_sales_return_det = '" + id_sales_return_det_list(j_del) + "'"
                    '        execute_non_query(query_detail_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    'get all detail id
                    'Dim query_get_detail_id As String = "SELECT a.id_sales_return_det, a.id_product, a.id_design_price, a.design_price "
                    'query_get_detail_id += "FROM tb_sales_return_det a "
                    'query_get_detail_id += "WHERE a.id_sales_return = '" + id_sales_return + "' "
                    'Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update counting
                    'Dim jum_ins_p As Integer = 0
                    'Dim query_counting As String = ""
                    'If GVBarcode.RowCount > 0 Then
                    '    query_counting = "INSERT INTO tb_sales_return_det_counting(id_sales_return_det, id_pl_prod_order_rec_det_unique, sales_return_det_counting) VALUES "
                    'End If
                    'For p As Integer = 0 To (GVBarcode.RowCount - 1)
                    '    Dim id_sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "id_sales_return_det_counting").ToString
                    '    Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                    '    Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                    '    If id_pl_prod_order_rec_det_unique = "0" Then
                    '        id_pl_prod_order_rec_det_unique = "NULL "
                    '    End If
                    '    Dim sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                    '    Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                    '    Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                    '    For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                    '        If id_sales_return_det_counting = "0" Then
                    '            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                    '                If jum_ins_p > 0 Then
                    '                    query_counting += ", "
                    '                End If
                    '                query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + sales_return_det_counting + "') "
                    '                jum_ins_p = jum_ins_p + 1
                    '                Exit For
                    '            End If
                    '        Else
                    '            Dim query_upd_counting As String = "UPDATE tb_sales_return_det_counting SET id_pl_prod_order_rec_det_unique = " + id_pl_prod_order_rec_det_unique + ", sales_return_det_counting = '" + sales_return_det_counting + "' WHERE id_sales_return_det_counting = '" + id_sales_return_det_counting + "'"
                    '            execute_non_query(query_upd_counting, True, "", "", "", "")
                    '            id_sales_return_det_counting_list.Remove(id_sales_return_det_counting)
                    '        End If
                    '    Next
                    'Next
                    'If jum_ins_p > 0 Then
                    '    execute_non_query(query_counting, True, "", "", "", "")
                    'End If

                    'For p_del As Integer = 0 To (id_sales_return_det_counting_list.Count - 1)
                    '    Try
                    '        Dim query_counting_del As String = "DELETE FROM tb_sales_return_det_counting WHERE id_sales_return_det_counting = '" + id_sales_return_det_counting_list(p_del) + "'"
                    '        execute_non_query(query_counting_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    FormSalesReturn.viewSalesReturn()
                    FormSalesReturn.viewSalesReturnOrder()
                    FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_sales_return)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Return #" + sales_return_number + " was edited successfully ")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub disableControl()
        MENote.Enabled = False
        BtnSave.Enabled = False
        BtnVerify.Enabled = False
        BScan.Enabled = False
        BScanProb.Enabled = False
        LUETypeScan.Enabled = False
        BStop.Enabled = True
        BStopProb.Enabled = True
        BDelete.Enabled = False
        BDeleteProb.Enabled = False
        BtnCancel.Enabled = False
        ControlBox = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnDel.Enabled = False
        BtnInfoSrs.Enabled = False
        TxtStoreReturnNumber.Enabled = False
        BtnBrowseContactTo.Enabled = False
    End Sub

    Dim data_eos As DataTable = Nothing
    Sub loadCodeDetail()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        GVItemList.ActiveFilterString = "[status]<>0 "

        Dim id_product_param As String = ""
        Dim id_product_param_comma As String = ""
        Dim id_product_param_or As String = ""
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            id_product_param += GVItemList.GetRowCellValue(i, "id_product").ToString
            If i < ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList)) Then
                id_product_param += ";"
            End If

            If i > 0 Then
                id_product_param_or += "OR "
                id_product_param_comma += ","
            End If
            id_product_param_or += "u.id_product='" + GVItemList.GetRowCellValue(i, "id_product").ToString + "' "
            id_product_param_comma += GVItemList.GetRowCellValue(i, "id_product").ToString
        Next
        If GVItemList.RowCount > 0 Then
            codeAvailableIns(id_product_param, id_product_param_or, id_store, "0", id_product_param_comma)
        End If

        GVItemList.ActiveFilterString = ""

        'check eos
        Try
            data_eos.Clear()
        Catch ex As Exception
        End Try
        If id_commerce_type = "1" Then
            data_eos = listBlockProductEOS()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub loadCodeDetailProb()
        Cursor = Cursors.WaitCursor
        Dim id_product_param As String = ""
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            id_product_param += GVItemList.GetRowCellValue(i, "id_product").ToString
            If i < ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList)) Then
                id_product_param += ";"
            End If
        Next
        codeAvailableInsProb(id_product_param, id_store, "0")
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        action_scan_btn = "start"
        If GVItemList.RowCount > 0 Or is_non_list = "1" Then
            If id_comp_contact_to <> "-1" Then
                loadCodeDetail()
                verifyTrans()
                disableControl()
                newRowsBc()
                focusColumnCodeBc()
            Else
                errorCustom("Select destination first")
            End If
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
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
        enableControl()
    End Sub

    Sub enableControl()
        MENote.Enabled = True
        BtnSave.Enabled = True
        BtnVerify.Enabled = True
        BScan.Enabled = True
        BScanProb.Enabled = True
        LUETypeScan.Enabled = True
        BStop.Enabled = False
        BStopProb.Enabled = False
        BDelete.Enabled = True
        BDeleteProb.Enabled = True
        BtnCancel.Enabled = True
        allowDelete()
        ControlBox = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        BtnInfoSrs.Enabled = True
        TxtStoreReturnNumber.Enabled = True
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
        LabelScanProb.Visible = False
        TxtScanProb.Visible = False
        BtnBrowseContactTo.Enabled = True
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        action_scan_btn = "delete"
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()
        'Dim id_sales_return_det_counting As String = "-1"
        'Try
        '    id_sales_return_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
        'Catch ex As Exception
        'End Try

        'If action = "ins" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '        deleteRowsBc()
        '        If id_product <> "" Or id_product <> Nothing Then
        '            GVBarcode.ApplyFindFilter("")
        '            countQty(id_product)
        '            countUnitCost(id_product, bom_unit_price)
        '        End If

        '        allowDelete()
        '    End If
        'ElseIf action = "upd" Then
        '    If id_sales_return_det_counting = "0" Then
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        '            deleteRowsBc()
        '            If id_product <> "" Or id_product <> Nothing Then
        '                GVBarcode.ApplyFindFilter("")
        '                countQty(id_product)
        '                countUnitCost(id_product, bom_unit_price)
        '            End If
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
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim product_name As String = ""
        Dim id_design_cat As String = ""
        Dim size As String = ""
        Dim prod_class As String = ""
        Dim prod_color As String = ""
        Dim prod_sht As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim index_atas As Integer = -100
        Dim is_old As String = "0"
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0
        Dim is_unique_report As String = "2"
        Dim ol_store_id As String = ""
        Dim item_id As String = ""
        Dim prc As Decimal = 0

        'check in ro 
        Dim code_list_found As Boolean = False
        Dim code_list As String = ""
        If code_check.Length >= 12 Then
            code_list = code_check.Substring(0, 12)
        Else
            code_list = code_check
        End If
        GVItemList.ActiveFilterString = "[code]='" + code_list + "' "
        GVItemList.FocusedRowHandle = 0
        If GVItemList.RowCount > 0 Then
            code_list_found = True
        End If
        If is_non_list = "1" And Not code_list_found Then
            'cek di return order
            Dim qrc As String = "SELECT rod.id_sales_return_order_det, rod.is_non_list, (rod.sales_return_order_det_qty-IFNULL(r.qty_ret,0)) AS `qty_limit`
            FROM tb_sales_return_order_det rod
            INNER JOIN tb_m_product p ON p.id_product = rod.id_product
            LEFT JOIN (
                SELECT rd.id_sales_return_order_det, SUM(rd.sales_return_det_qty) AS `qty_ret` 
                FROM tb_sales_return_det rd
                INNER JOIN tb_sales_return r ON r.id_sales_return = rd.id_sales_return
                WHERE r.id_sales_return_order=" + id_sales_return_order + " AND r.id_report_status!=5
                GROUP BY rd.id_sales_return_order_det
            ) r ON r.id_sales_return_order_det = rod.id_sales_return_order_det
            WHERE p.product_full_code='" + addSlashes(code_list) + "' AND rod.id_sales_return_order=" + id_sales_return_order + " "
            Dim drc As DataTable = execute_query(qrc, -1, True, "", "", "", "")
            If drc.Rows.Count > 0 Then
                Cursor = Cursors.Default
                makeSafeGV(GVItemList)
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                If drc.Rows(0)("is_non_list").ToString = "1" Then
                    stopCustomDialog("Stock not available")
                Else
                    If drc.Rows(0)("qty_limit") > 0 Then
                        stopCustomDialog("Please scan this product in regular process")
                    Else
                        stopCustomDialog("Stock not available")
                    End If
                End If
                Exit Sub
            Else
                'tambah ror jika ada SOH
                Dim qcr As String = "SELECT p.id_product, d.id_design, d.is_old_design, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`, 
                SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty_avl,
                prc.id_design_price, prc.design_price, prc.design_price_type, dcd.class, dcd.color, dcd.sht
                FROM tb_storage_fg f 
                INNER JOIN tb_m_comp c ON c.id_drawer_def = f.id_wh_drawer
                INNER JOIN tb_m_product p ON p.id_product = f.id_product
                INNER JOIN tb_m_design d ON d.id_design = p.id_design
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
	            ) dcd ON dcd.id_design = d.id_design
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                LEFT JOIN( 
                  Select * FROM ( 
                  Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                  price.id_design_price_type, price_type.design_price_type,
                  cat.id_design_cat, cat.design_cat
                  From tb_m_design_price price 
                  INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                  INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                  WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
                  ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
                  GROUP BY a.id_design 
                ) prc ON prc.id_design = p.id_design 
                WHERE c.id_comp=" + id_store + " AND p.product_full_code='" + addSlashes(code_list) + "' HAVING qty_avl>0 "
                Dim dcr As DataTable = execute_query(qcr, -1, True, "", "", "", "")
                If dcr.Rows.Count <= 0 Then
                    Cursor = Cursors.Default
                    makeSafeGV(GVItemList)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("Stock not available")
                    Exit Sub
                Else
                    Dim dtu As DataTable = Nothing
                    If dcr.Rows(0)("is_old_design").ToString <> "2" Then
                        'jika bukan unik
                        Dim old As ClassDesign = New ClassDesign()
                        Dim qold As String = old.queryOldDesignCode(dcr.Rows(0)("id_product").ToString)
                        dtu = execute_query(qold, -1, True, "", "", "", "")
                    Else
                        'jika unik cek unik code
                        If is_use_unique_code = "1" Then
                            dtu = execute_query("CALL view_stock_fg_unique_with_table('" + dcr.Rows(0)("id_product").ToString + "', '" + id_store + "', '" + id_wh_drawer_store + "')", -1, True, "", "", "", "")
                        Else
                            dtu = execute_query("CALL view_stock_fg_unique_ret('" + dcr.Rows(0)("id_product").ToString + "','" + id_store + "', '0','0')", -1, True, "", "", "", "")
                        End If
                    End If


                    Dim dtu_filter As DataRow() = dtu.Select("[product_full_code]='" + code_check + "' ")
                    If (dtu_filter.Length > 0) Then
                        ' add ror detail
                        Dim qar As String = "INSERT INTO tb_sales_return_order_det(id_sales_return_order, id_product, id_return_cat, id_design_price, design_price, sales_return_order_det_qty, sales_return_order_det_note, is_non_list) 
                        VALUES(" + id_sales_return_order + ", " + dcr.Rows(0)("id_product").ToString + ",1, '" + dcr.Rows(0)("id_design_price").ToString + "', '" + decimalSQL(dcr.Rows(0)("design_price").ToString) + "',0,'',1); SELECT LAST_INSERT_ID(); "
                        Dim id_rod_new As String = execute_query(qar, 0, True, "", "", "", "")

                        'add on Grid list
                        Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
                        newRow("id_sales_return_order_det") = id_rod_new
                        newRow("id_product") = dcr.Rows(0)("id_product").ToString
                        newRow("code") = dcr.Rows(0)("code").ToString
                        newRow("name") = dcr.Rows(0)("name").ToString
                        newRow("size") = dcr.Rows(0)("size").ToString
                        newRow("class") = dcr.Rows(0)("class").ToString
                        newRow("color") = dcr.Rows(0)("color").ToString
                        newRow("sht") = dcr.Rows(0)("sht").ToString
                        newRow("sales_return_det_qty") = 0
                        newRow("sales_return_det_qty_limit") = dcr.Rows(0)("qty_avl")
                        newRow("design_price_type") = dcr.Rows(0)("design_price_type").ToString
                        newRow("design_price") = dcr.Rows(0)("design_price")
                        newRow("id_design_price") = dcr.Rows(0)("id_design_price").ToString
                        newRow("sales_return_det_amount") = 0
                        newRow("sales_return_det_note") = ""
                        TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        code_list_found = True

                        'load unique new ror detail
                        If dt.Rows.Count > 0 Then
                            dt.Merge(dtu, True, MissingSchemaAction.Ignore)
                        Else
                            dt = dtu
                        End If

                        'codeAvailableIns(dcr.Rows(0)("id_product").ToString, "u.id_product='" + dcr.Rows(0)("id_product").ToString + "' ", id_store, 0)
                    Else
                        Cursor = Cursors.Default
                        makeSafeGV(GVItemList)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustomDialog("Code not found")
                        Exit Sub
                    End If
                End If
            End If
        End If
        makeSafeGV(GVItemList)

        If code_list_found Then
            'check available code
            Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
            If dt_filter.Length > 0 Then
                counting_code = dt_filter(0)("product_counting_code").ToString
                id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
                id_product = dt_filter(0)("id_product").ToString
                product_name = dt_filter(0)("name").ToString
                size = dt_filter(0)("size").ToString
                prod_class = dt_filter(0)("class").ToString
                prod_color = dt_filter(0)("color").ToString
                prod_sht = dt_filter(0)("sht").ToString
                bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
                is_old = dt_filter(0)("is_old_design").ToString
                is_unique_report = dt_filter(0)("is_unique_report").ToString
                id_design_cat = dt_filter(0)("id_design_cat").ToString
                prc = dt_filter(0)("design_price").ToString
                code_found = True
            End If

            'check eos
            If data_eos.Rows.Count > 0 Then
                Dim data_eos_filter As DataRow() = data_eos.Select("[id_product]='" + id_product + "' ")
                If data_eos_filter.Length > 0 Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("This item can't scan, because already proposed on EOS")
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If


            'check unik code custormer - ol store
            If id_ret_type = "4" Then
                Dim condition_str As String = "[full_code]='" + code_check + "' AND [is_used]='2' "
                Dim dt_cust_filter As DataRow() = dt_cust.Select(condition_str)
                If dt_cust_filter.Length > 0 Then
                    ol_store_id = dt_cust_filter(0)("ol_store_id").ToString
                    item_id = dt_cust_filter(0)("item_id").ToString
                End If
                Console.WriteLine(condition_str)
            End If


            'get jum del & limit
            If id_commerce_type = "2" Then 'online store
                GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' AND [ol_store_id]='" + ol_store_id + "' AND [item_id]='" + item_id + "' "
            Else
                GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' "
            End If


            GVItemList.FocusedRowHandle = 0
            Try
                jum_limit = GVItemList.GetFocusedRowCellValue("sales_return_det_qty_limit")
            Catch ex As Exception
            End Try
            Try
                jum_scan = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
            Catch ex As Exception
            End Try
            makeSafeGV(GVItemList)

            'jika akun normal/sale
            If (id_wh_type = "1" Or id_wh_type = "2") Then
                If (id_wh_type <> id_design_cat) And prc > 0 Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    If id_wh_type = "1" Then
                        stopCustomDialog(TxtCodeCompTo.Text + " is only for normal product. ")
                    Else
                        stopCustomDialog(TxtCodeCompTo.Text + " is only for sale product. ")
                    End If
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If


            If is_old = "1" Then 'old product
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
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", "0")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "class", prod_class)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "color", prod_color)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "sht", prod_sht)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_unique_report", is_unique_report)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "ol_store_id", ol_store_id)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "item_id", item_id)
                    countQty(id_product, ol_store_id, item_id)
                    checkUnitCost(id_product, bom_unit_price)
                    newRowsBc()
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                End If
            ElseIf is_old = "2" Or is_old = "3" Then 'new product
                'check duplicate code
                GVBarcode.ActiveFilterString = "[code]='" + code_check + "' AND [is_fix]='2' "
                If GVBarcode.RowCount > 0 Then
                    code_duplicate = True
                End If
                GVBarcode.ActiveFilterString = ""

                If Not code_found Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustomDialog("Code not found !")
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
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", "0")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "class", prod_class)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "color", prod_color)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "sht", prod_sht)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_unique_report", is_unique_report)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "ol_store_id", ol_store_id)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "item_id", item_id)
                        countQty(id_product, ol_store_id, item_id)
                        checkUnitCost(id_product, bom_unit_price)
                        newRowsBc()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                End If
            Else
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustomDialog("Code not found !")
            End If
        Else
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
            GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
            stopCustomDialog("Product not found in return order list!")
        End If
        Cursor = Cursors.Default
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

    Sub deleteDetailDrawer(ByVal id_product_param As String)
        'delete(detail)
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            'MsgBox(id_product_param)
            Dim id_product As String = ""
            Try
                id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    Sub infoQty()
        FormInfoSalesReturnOrder.id_pop_up = "1"
        FormInfoSalesReturnOrder.id_sales_return_order = id_sales_return_order
        FormInfoSalesReturnOrder.id_sales_return_order_det = "0"
        If action = "ins" Then
            FormInfoSalesReturnOrder.id_sales_return = "0"
        Else
            FormInfoSalesReturnOrder.id_sales_return = "0"
        End If
        FormInfoSalesReturnOrder.id_wh_drawer = id_wh_drawer_store
        FormInfoSalesReturnOrder.id_wh_rack = id_wh_rack_store
        FormInfoSalesReturnOrder.id_wh_locator = id_wh_locator_store
        FormInfoSalesReturnOrder.ShowDialog()
    End Sub


    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        ' jika complete
        Dim stc_compl As ClassSalesReturn = New ClassSalesReturn()
        stc_compl.completeReservedStock(id_sales_return)
        MsgBox("Done")
    End Sub

    Sub getReport()
        GridColumnNo.VisibleIndex = 0
        GVItemList.ActiveFilterString = "[sales_return_det_qty]>0"
        For i As Integer = 0 To GVItemList.RowCount - 1
            GVItemList.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        ReportSalesReturn.dt = GCItemList.DataSource
        ReportSalesReturn.id_sales_return = id_sales_return
        Dim Report As New ReportSalesReturn()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GridView1)

        'Parse val
        Report.LRecNumber.Text = "NO. " + TxtSalesReturnNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelReturnOrder.Text = TxtSalesReturnOrderNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelAddressFrom.Text = MEAdrressCompFrom.Text
        'Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        'Report.LLocator.Text = locator_sel
        'Report.LRack.Text = rack_sel
        'Report.LDrawer.Text = drawer_sel
        Report.LabelNote.Text = MENote.Text
        Report.LType.Text = TxtReturnType.Text + If(CENonList.EditValue, " Non List", "")
        Report.LReffNo.Text = TxtStoreReturnNumber.Text
        Report.LabelDestination.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LabelDrawer.Text = TEDrawer.Text

        If id_ret_type = "1" Then
            Report.report_mark_type = "46"
        ElseIf id_ret_type = "3" Then
            Report.report_mark_type = "113"
        ElseIf id_ret_type = "4" Then
            Report.report_mark_type = "120"
        Else
            Report.report_mark_type = "111"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        GVItemList.ActiveFilterString = ""
        GridColumnNo.Visible = False
    End Sub

    Sub checkUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal)

    End Sub

    Sub countUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = "-1"
            Dim cost As Decimal = 0.0
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString
                cost = Decimal.Parse(GVBarcode.GetRowCellValue(i, "bom_unit_price").ToString)
            Catch ex As Exception
            End Try

            If id_product = id_product_param And cost = bom_unit_price_param Then
                tot = tot + 1.0
            End If
        Next

        'cari yg sesuai
        For j As Integer = 0 To (GVDrawer.RowCount - 1)
            Dim id_product_cek As String = "-1"
            Dim cost As Decimal = 0.0
            Try
                id_product_cek = GVDrawer.GetRowCellValue(j, "id_product").ToString
                cost = Decimal.Parse(GVDrawer.GetRowCellValue(j, "bom_unit_price").ToString)
                If id_product_cek = id_product_param And bom_unit_price_param = cost Then
                    'MsgBox(tot.ToString)
                    GVDrawer.SetRowCellValue(j, "sales_return_det_drawer_qty", tot)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub BtnSaveToStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveToStorage.Click
        Cursor = Cursors.WaitCursor
        Dim sales_return_det_drawer_qty As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_det_drawer_qty"))
        Dim sales_return_det_drawer_qty_stored As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_det_drawer_qty_stored"))
        If sales_return_det_drawer_qty <> sales_return_det_drawer_qty_stored Then
            FormProductionStorageIn.id_transaction_det = GVDrawer.GetFocusedRowCellValue("id_sales_return_det_drawer").ToString
            FormProductionStorageIn.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
            FormProductionStorageIn.id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            FormProductionStorageIn.action = "ins"
            FormProductionStorageIn.colorku = GVItemList.GetFocusedRowCellValue("color").ToString
            FormProductionStorageIn.sizeku = GVItemList.GetFocusedRowCellValue("size").ToString
            FormProductionStorageIn.id_report = id_sales_return
            FormProductionStorageIn.report_mark_type = "46"
            FormProductionStorageIn.id_product = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            FormProductionStorageIn.cost = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("bom_unit_price").ToString)
            FormProductionStorageIn.id_pop_up = "2"
            FormProductionStorageIn.id_wh_origin = id_comp_to
            FormProductionStorageIn.ShowDialog()
        Else
            errorCustom("- All item for this product has been stored in warehouse" + System.Environment.NewLine + "- If yo want to edit location storage, please edit on 'Transfer Product' menu")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        Try
            Dim id_product As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price As String = GVDrawer.GetFocusedRowCellValue("id_design_price").ToString

            Dim indeks As Integer
            For i As Integer = 0 To (GVItemList.RowCount - 1)
                Try
                    If id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString And id_design_price = GVDrawer.GetRowCellValue(i, "id_design_price").ToString Then
                        indeks = i
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            GVItemList.FocusedRowHandle = indeks

            'drawer detail
            check_but_drawer()
        Catch ex As Exception
        End Try
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("HAH")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price_style As String = GVItemList.GetFocusedRowCellValue("id_design_price").ToString

            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            Dim id_design_price_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_design_price"))
            If id_product_check = id_product_style And id_design_price_check = id_design_price_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub check_but_drawer()
        If GVDrawer.RowCount > 0 Then
            PanelNavStorage.Enabled = True
        Else
            PanelNavStorage.Enabled = False
        End If
    End Sub

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "1"
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        FormPopUpDrawer.id_comp = id_comp_param
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub TEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDrawer.Validating
        EP_TE_cant_blank(EPForm, TEDrawer)
        EPForm.SetIconPadding(TEDrawer, 30)
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_return
        If id_ret_type = "1" Then
            FormDocumentUpload.report_mark_type = "46"
        ElseIf id_ret_type = "3" Then
            FormDocumentUpload.report_mark_type = "113"
        ElseIf id_ret_type = "4" Then
            FormDocumentUpload.report_mark_type = "120"
        Else
            FormDocumentUpload.report_mark_type = "111"
        End If
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesReturn.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesReturn.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
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
                Dim id_sales_return_det_counting As String = "-1"
                Try
                    id_sales_return_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                        Dim ol_store_id As String = GVBarcode.GetFocusedRowCellValue("ol_store_id").ToString
                        Dim item_id As String = GVBarcode.GetFocusedRowCellValue("item_id").ToString
                        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
                        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                        deleteRowsBc()
                        If id_product <> "" Or id_product <> Nothing Then
                            GVBarcode.ApplyFindFilter("")
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_product, ol_store_id, item_id)
                            countUnitCost(id_product, bom_unit_price)
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
            If XTCReturnMain.SelectedTabPageIndex = 2 And TxtCombineNumber.Text <> "" Then
                Cursor = Cursors.WaitCursor
                'hide column
                For c As Integer = 0 To GVCombine.Columns.Count - 1
                    GVCombine.Columns(c).Visible = False
                Next
                GridColumnCodeComb.VisibleIndex = 0
                GridColumnQtyComb.VisibleIndex = 1
                GridColumnNumberComb.VisibleIndex = 2
                GridColumnFromComb.VisibleIndex = 3
                GridColumnToComb.VisibleIndex = 4
                GridColumnRemarkComb.VisibleIndex = 5
                GVCombine.OptionsPrint.PrintFooter = False
                GVCombine.OptionsPrint.PrintHeader = False

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
                    ExportToExcel(GVCombine, exp, show_msg)
                Catch ex As Exception
                    stopCustom("Please close your excel file first then try again later")
                End Try

                'show column
                GridColumnCodeComb.VisibleIndex = 0
                GridColumnNameComb.VisibleIndex = 1
                GridColumnSizeComb.VisibleIndex = 2
                GridColumnQtyComb.VisibleIndex = 3
                GridColumnPriceTypeComb.VisibleIndex = 4
                GridColumnPriceComb.VisibleIndex = 5
                GridColumnAmountComb.VisibleIndex = 6
                GridColumnRemarkComb.Visible = False
                GridColumnNumberComb.Visible = False
                GridColumnFromComb.Visible = False
                GridColumnToComb.Visible = False
                GVCombine.OptionsPrint.PrintFooter = True
                GVCombine.OptionsPrint.PrintHeader = True
                Cursor = Cursors.Default
            Else
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
                GridColumnStt.Visible = False
                GridColumnNumber.Visible = False
                GridColumnFrom.Visible = False
                GridColumnTo.Visible = False
                GVItemList.OptionsPrint.PrintFooter = True
                GVItemList.OptionsPrint.PrintHeader = True
                Cursor = Cursors.Default
            End If
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
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_return_det_qty")
                ElseIf j = 2 Then  'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then  'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then  'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = ""
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

    Sub exportToBOFProb(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

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

            Dim fileName As String = bof_xls_nsi + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            ' Try
            ExportToExcelProb(exp, show_msg)
            'Catch ex As Exception
            'stopCustom("Please close your excel file first then try again later")
            'End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcelProb(ByVal filepath As String, show_msg As Boolean)
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
        Dim query As String = "SELECT p.id_product,p.product_full_code AS `code` , d.design_display_name AS `name`, cd.code_detail_name AS `size`,
        COUNT(rp.id_product) AS `qty`, r.sales_return_number AS `number`, s.comp_number AS `from`,
        o.non_inv_account AS `to`
        FROM tb_sales_return_problem rp
        INNER JOIN tb_sales_return r ON r.id_sales_return = rp.id_sales_return
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = r.id_store_contact_from
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_m_product p ON p.id_product = RP.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        JOIN tb_opt_sales o
        WHERE rp.id_sales_return='" + id_sales_return + "'
        GROUP BY rp.id_product "
        Dim dtTemp As DataTable = execute_query(query, -1, True, "", "", "", "")

        'export the rows 
        For i As Integer = 0 To dtTemp.Rows.Count - 1
            rowIndex = rowIndex + 1
            colIndex = 0

            For j As Integer = 0 To dtTemp.Columns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("qty")
                ElseIf j = 2 Then  'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("number").ToString
                ElseIf j = 3 Then  'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("from").ToString
                ElseIf j = 4 Then  'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = ""
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



    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(False)
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

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Cursor = Cursors.WaitCursor
        verifyTrans()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVItemList.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesReturnNumber.Text.ToString
        ElseIf e.Column.FieldName = "status" AndAlso e.IsGetData Then
            e.Value = getDiff(view, e.ListSourceRowIndex)
        End If
    End Sub

    Private Function getDiff(view As DevExpress.XtraGrid.Views.Grid.GridView, listSourceRowIndex As Integer) As String
        Dim qty As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "sales_return_det_qty"))
        Dim limit As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "sales_return_det_qty_limit"))
        Dim diff As Integer = qty - limit
        Dim stt As String = ""
        If diff > 0 Then
            stt = "+" + diff.ToString
        Else
            stt = diff.ToString
        End If
        Return stt
    End Function

    Private Sub BScanProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtScanProb_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub BStopProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BDeleteProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GVBarcodeProb_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)

    End Sub

    Private Sub GVBarcodeProb_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcodeProb.HiddenEditor

    End Sub

    Function isNoAvailableStock(ByVal id_prod) As Boolean
        Dim query As String = "SELECT f.id_product, IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `qty`
        FROM tb_storage_fg f
        WHERE f.id_wh_drawer=" + id_wh_drawer_store + " AND f.id_product=" + id_prod + "
        GROUP BY f.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            If data.Rows(0)("qty") > 0 Then
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Sub TxtScanProb_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TxtScanProb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtScanProb.Text)

            If is_scan_prob = "1" Then 'scan
                'filter id product
                Dim code12 As String = ""
                If code.Length >= 12 Then
                    code12 = code.Substring(0, 12)
                Else
                    code12 = code
                End If
                Dim id_product_find As String = "-1"
                Try
                    id_product_find = execute_query("SELECT id_product FROM tb_m_product p WHERE p.product_full_code='" + code12 + "'", 0, True, "", "", "", "")
                Catch ex As Exception
                    id_product_find = "-1"
                End Try

                Dim query As String = "CALL view_scan_code_active('AND list.code=''" + code + "'''," + id_product_find + ")"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    'check duplicate
                    'code
                    If data.Rows(0)("is_old_design").ToString = "2" Then
                        GVBarcodeProb.ActiveFilterString = "[code]='" + code + "' "
                        Dim jum_duplicate As Integer = GVBarcodeProb.RowCount
                        GVBarcodeProb.ActiveFilterString = ""
                        If jum_duplicate > 0 Then
                            stopCustomDialog("Data duplicate")
                            TxtScanProb.Text = ""
                            TxtScanProb.Focus()
                            Exit Sub
                        End If
                    End If

                    'check unique sesuai toko
                    Dim cond_unique_not_found As Boolean = False
                    Dim is_unique_not_found As String = "2"
                    If data.Rows(0)("is_old_design").ToString = "2" Then
                        Dim qcu As String = "CALL view_stock_fg_unique_ret(" + data.Rows(0)("id_product").ToString + ", " + id_store + ", 0, 0) "
                        Dim dcu As DataTable = execute_query(qcu, -1, True, "", "", "", "")
                        Dim dtu_f As DataRow() = dcu.Select("[product_full_code]='" + code + "' ")
                        If dtu_f.Length > 0 Then
                            cond_unique_not_found = False
                            is_unique_not_found = "2"
                        Else
                            cond_unique_not_found = True
                            is_unique_not_found = "1"
                        End If
                    End If


                    'ada stock ato gak (diaktifkan setelah jalan 1 sistem)
                    'Dim cond_no_stock As Boolean = isNoAvailableStock(data.Rows(0)("id_product").ToString)
                    'Dim is_no_stock As String = "2"
                    'If cond_no_stock Then
                    '    is_no_stock = "1"
                    'Else
                    '    is_no_stock = "2"
                    'End If
                    Dim cond_no_stock As Boolean = True
                    Dim is_no_stock As String = "1"

                    'cek
                    If Not cond_unique_not_found And Not cond_no_stock Then
                        stopCustomDialog("This product still has stock, please scan in Return-Non List")
                        Exit Sub
                    End If


                    Dim newRow As DataRow = (TryCast(GCBarcodeProb.DataSource, DataTable)).NewRow()
                    newRow("id_sales_return_problem") = "0"
                    newRow("id_product") = data.Rows(0)("id_product").ToString
                    newRow("design_code") = data.Rows(0)("design_code").ToString
                    newRow("code") = data.Rows(0)("code").ToString
                    newRow("name") = data.Rows(0)("name").ToString
                    newRow("size") = data.Rows(0)("size").ToString
                    newRow("class") = data.Rows(0)("class").ToString
                    newRow("color") = data.Rows(0)("color").ToString
                    newRow("sht") = data.Rows(0)("sht").ToString
                    newRow("is_unique_not_found") = is_unique_not_found
                    newRow("is_no_stock") = is_no_stock
                    newRow("id_scan_type") = LUETypeScan.EditValue
                    newRow("scan_type") = LUETypeScan.Text
                    TryCast(GCBarcodeProb.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnDetProblem.TxtCode.Text = data.Rows(0)("design_code").ToString
                    FormSalesReturnDetProblem.TxtBarcode.Text = data.Rows(0)("code").ToString
                    FormSalesReturnDetProblem.TxtSize.Text = data.Rows(0)("size").ToString
                    FormSalesReturnDetProblem.TxtClass.Text = data.Rows(0)("class").ToString
                    FormSalesReturnDetProblem.Txtcolor.Text = data.Rows(0)("color").ToString
                    FormSalesReturnDetProblem.TxtDesign.Text = data.Rows(0)("name").ToString
                    FormSalesReturnDetProblem.id_product = data.Rows(0)("id_product").ToString
                    FormSalesReturnDetProblem.id_type = "1"
                    FormSalesReturnDetProblem.ShowDialog()
                    GCBarcodeProb.RefreshDataSource()
                    GVBarcodeProb.RefreshData()
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                Else
                    stopCustomDialog("Data not found")
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                End If
            ElseIf is_scan_prob = "2" Then 'del scan
                Cursor = Cursors.WaitCursor
                GVBarcodeProb.ActiveFilterString = "[code]='" + TxtScanProb.Text + "'"
                If GVBarcodeProb.RowCount <= 0 Then
                    stopCustomDialog("Code not found.")
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        GVBarcodeProb.DeleteRow(GVBarcodeProb.FocusedRowHandle)
                        GVBarcodeProb.ActiveFilterString = ""
                    Else
                        GVBarcodeProb.ActiveFilterString = ""
                    End If
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                End If
                Cursor = Cursors.Default
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BScanProb_Click_1(sender As Object, e As EventArgs) Handles BScanProb.Click
        If GVItemList.RowCount > 0 Then
            TxtScanProb.Text = ""
            is_scan_prob = "1"
            disableControl()
            LabelScanProb.Visible = True
            TxtScanProb.Visible = True
            TxtScanProb.Focus()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStopProb_Click_1(sender As Object, e As EventArgs) Handles BStopProb.Click
        TxtScanProb.Text = ""
        is_scan_prob = "-1"
        enableControl()
    End Sub

    Private Sub BDeleteProb_Click_1(sender As Object, e As EventArgs) Handles BDeleteProb.Click
        is_scan_prob = "2"
        disableControl()
        TxtScanProb.Text = ""
        LabelScanProb.Visible = True
        TxtScanProb.Visible = True
        TxtScanProb.Focus()
    End Sub

    Private Sub GVBarcodeProb_CustomColumnDisplayText_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcodeProb.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAddManual_Click(sender As Object, e As EventArgs) Handles BtnAddManual.Click
        FormSalesReturnDetProblem.ShowDialog()
    End Sub

    Private Sub EditRemarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRemarkToolStripMenuItem.Click
        If GVBarcodeProb.RowCount > 0 And GVBarcodeProb.FocusedRowHandle >= 0 Then
            FormSalesReturnDetProblem.id_type = "2"
            FormSalesReturnDetProblem.TxtSearch.Text = ""
            FormSalesReturnDetProblem.TxtCode.Text = GVBarcodeProb.GetFocusedRowCellValue("design_code").ToString
            FormSalesReturnDetProblem.TxtBarcode.Text = GVBarcodeProb.GetFocusedRowCellValue("code").ToString
            FormSalesReturnDetProblem.TxtSize.Text = GVBarcodeProb.GetFocusedRowCellValue("size").ToString
            FormSalesReturnDetProblem.TxtDesign.Text = GVBarcodeProb.GetFocusedRowCellValue("name").ToString
            FormSalesReturnDetProblem.TxtRemark.Text = GVBarcodeProb.GetFocusedRowCellValue("remark").ToString
            FormSalesReturnDetProblem.id_product = GVBarcodeProb.GetFocusedRowCellValue("id_product").ToString
            FormSalesReturnDetProblem.ShowDialog()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVBarcodeProb.RowCount > 0 And GVBarcodeProb.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                GVBarcodeProb.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub BBPrintNonStock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrintNonStock.ItemClick
        Cursor = Cursors.WaitCursor
        ReportSalesReturnNonStock.dt = GCBarcodeProb.DataSource
        Dim Report As New ReportSalesReturnNonStock()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVBarcodeProb.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVBarcodeProb.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVBarcodeProb)

        'Parse val
        Report.LRecNumber.Text = TxtSalesReturnNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelReturnStore.Text = TxtStoreReturnNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelAddressFrom.Text = MEAdrressCompFrom.Text
        Report.LabelPrint.Text = name_user + " (" + execute_query("SELECT DATE_FORMAT(NOW(),'%d/%m/%Y %T')", 0, True, "", "", "", "") + ")"
        'Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNonStock_Click(sender As Object, e As EventArgs) Handles BtnCreateNonStock.Click
        Cursor = Cursors.WaitCursor
        action = "ins"
        id_ret_type = "2"
        id_sales_return = "-1"
        TxtReturnType.Text = "Non Stock"
        Dim store_ret_number As String = TxtStoreReturnNumber.Text
        actionLoad()
        TxtStoreReturnNumber.Text = store_ret_number
        TxtSalesReturnNumber.Text = ""
        TxtSalesReturnNumber.Text = ""
        BtnPrint.Enabled = False
        BMark.Enabled = False
        BtnAttachment.Enabled = False
        DEForm.Text = view_date(0)
        DDBPrint.Enabled = False
        BtnSave.Enabled = True
        BtnXlsBOF.Visible = False
        BtnCreateReturn.Visible = False
        BtnCreateReturnNonList.Visible = False
        BtnCreateNonStock.Visible = False
        PanelNavBarcode.Enabled = True
        PanelNavBarcodeProb.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateReturnNonList_Click(sender As Object, e As EventArgs) Handles BtnCreateReturnNonList.Click
        Cursor = Cursors.WaitCursor
        XTCReturnMain.SelectedTabPageIndex = 0
        action = "ins"
        id_ret_type = "1"
        FormSalesReturnSelectRetType.ShowDialog()
        is_non_list = "1"
        id_sales_return = "-1"
        TxtReturnType.Text = "Return Non List"
        Dim store_ret_number As String = TxtStoreReturnNumber.Text
        actionLoad()
        TxtStoreReturnNumber.Text = store_ret_number
        TxtSalesReturnNumber.Text = ""
        TxtSalesReturnNumber.Text = ""
        id_comp_contact_to = "-1"
        TxtCodeCompTo.Text = ""
        TxtNameCompTo.Text = ""
        BtnPrint.Enabled = False
        BMark.Enabled = False
        BtnAttachment.Enabled = False
        DEForm.Text = view_date(0)
        DDBPrint.Enabled = False
        BtnSave.Enabled = True
        BtnXlsBOF.Visible = False
        BtnBrowseContactTo.Enabled = True
        BtnCreateReturn.Visible = False
        BtnCreateReturnNonList.Visible = False
        BtnCreateNonStock.Visible = False
        PanelNavBarcode.Enabled = True
        PanelNavBarcodeProb.Enabled = True
        GridColumnQtyLimit.VisibleIndex = 3
        GridColumnStt.VisibleIndex = 5
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateReturn_Click(sender As Object, e As EventArgs) Handles BtnCreateReturn.Click
        Cursor = Cursors.WaitCursor
        XTCReturnMain.SelectedTabPageIndex = 0
        action = "ins"
        id_ret_type = "1"
        FormSalesReturnSelectRetType.ShowDialog()
        is_non_list = "-1"
        id_sales_return = "-1"
        TxtReturnType.Text = "Return"
        Dim store_ret_number As String = TxtStoreReturnNumber.Text
        actionLoad()
        TxtStoreReturnNumber.Text = store_ret_number
        TxtSalesReturnNumber.Text = ""
        TxtSalesReturnNumber.Text = ""
        id_comp_contact_to = "-1"
        TxtCodeCompTo.Text = ""
        TxtNameCompTo.Text = ""
        BtnPrint.Enabled = False
        BMark.Enabled = False
        BtnAttachment.Enabled = False
        DEForm.Text = view_date(0)
        DDBPrint.Enabled = False
        BtnSave.Enabled = True
        BtnXlsBOF.Visible = False
        BtnBrowseContactTo.Enabled = True
        BtnCreateReturn.Visible = False
        BtnCreateReturnNonList.Visible = False
        BtnCreateNonStock.Visible = False
        PanelNavBarcode.Enabled = True
        PanelNavBarcodeProb.Enabled = True
        GridColumnQtyLimit.VisibleIndex = 3
        GridColumnStt.VisibleIndex = 5
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCReturnMain_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturnMain.SelectedPageChanged
        If XTCReturnMain.SelectedTabPageIndex = 2 Then
            viewCombine()
        End If
    End Sub

    Private Sub BtnCombineReturn_Click(sender As Object, e As EventArgs) Handles BtnCombineReturn.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim combine_number As String = header_number_sales("5")
            increase_inc_sales("5")
            Dim query_upd As String = "/*update combine number*/
            UPDATE tb_sales_return r SET r.combine_number='" + combine_number + "' 
            WHERE r.sales_return_store_number='" + addSlashes(TxtStoreReturnNumber.Text) + "' 
            AND r.id_store_contact_from=" + id_store_contact_from + " 
            AND r.id_report_status=1 AND r.combine_number='' AND r.last_update_by='" + id_user + "' ; 
            /*update deskripsi report mark*/
            UPDATE tb_report_mark rm 
            INNER JOIN tb_sales_return r ON r.id_sales_return = rm.id_report
            SET rm.info_design = CONCAT('Combine No:', r.combine_number,'; Qty:','" + GVCombine.Columns("sales_return_det_qty").SummaryItem.SummaryValue.ToString + "')
            WHERE (rm.report_mark_type=46 OR rm.report_mark_type=113 OR rm.report_mark_type=120) AND r.combine_number='" + combine_number + "'; "
            execute_non_query(query_upd, True, "", "", "", "")

            'refresh
            actionLoad()
            viewCombine()
            FormSalesReturn.viewSalesReturn()
            FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_sales_return)
            exportToBOF(False)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnBrowseStoreReturn_Click(sender As Object, e As EventArgs) Handles BtnBrowseStoreReturn.Click
        'referensi surat jalan
        Dim dtr As DataTable = getRefStoreRetNumber(id_store)
        If dtr.Rows.Count > 0 Then
            FormSalesReturnStoreReturn.dt = dtr
            FormSalesReturnStoreReturn.ShowDialog()
        Else
            stopCustom("Data not found")
        End If
    End Sub

    Sub view_type_scan()
        Dim query As String = "
            SELECT id_scan_type, scan_type FROM tb_lookup_scan_type WHERE id_scan_type <> 1
        "

        viewLookupQuery(LUETypeScan, query, 0, "scan_type", "id_scan_type")
    End Sub

    Private Sub FormSalesReturnDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            FormMenuAuth.type = "7"
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