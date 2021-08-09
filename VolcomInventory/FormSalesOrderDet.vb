﻿Imports Microsoft.Office.Interop

Public Class FormSalesOrderDet
    Public action As String
    Public id_sales_order As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_store As String = "-1"
    Public id_store_cat As String = "-1"
    Public id_report_status As String
    Public id_sales_order_det_list As New List(Of String)
    Public id_so_type As String = "0"
    Public id_comp_contact_par As String = "-1"
    Public id_comp_par As String = "-1"
    Dim id_comp_cat_wh As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_so")
    Public dt As DataTable
    Public dt_shop As DataTable
    Public id_type As String
    Public id_commerce_type As String = "-1"
    Public id_store_type As String = "-1"
    Public id_wh_type As String = "-1"
    Public id_account_type As String = "-1"
    Dim is_block_same_nw As String = get_setup_field("is_block_same_nw")
    Public is_transfer_data As String = "2"
    Public id_ol_promo As String = "-1"

    Private Sub FormSalesOrderDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        id_type = FormSalesOrder.id_type
        id_comp_cat_wh = get_setup_field("id_comp_cat_wh")
        viewReportStatus()
        viewSoType()
        viewOrderType()
        'viewSoStatus()
        viewPeriodUniform()
        viewUniType()
        actionLoad()

        'packing status invisible
        LabelControl4.Visible = False
        TxtPackingStatus.Visible = False


        WindowState = FormWindowState.Maximized
    End Sub

    Sub viewWH()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT er.id_comp, er.comp_number, er.comp_name, CONCAT_WS(' - ', er.comp_number, er.comp_name) AS comp_name_label 
        FROM tb_m_comp e 
        INNER JOIN tb_m_comp er ON er.id_comp = e.id_wh_group
        WHERE e.is_only_for_alloc=1
        GROUP BY e.id_wh_group  "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub getDataReference()
        If action = "ins" Then
            Try
                dt.Clear()
            Catch ex As Exception
            End Try
            Dim query As String = "CALL view_sales_order_prod_list_less('0', '" + id_comp_par + "')"
            dt = execute_query(query, -1, True, "", "", "", "")
        End If
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtPackingStatus.Text = "-"
            TxtSalesOrderNumber.Text = ""
            BtnPrint.Enabled = False
            BtnAttachment.Enabled = False
            BMark.Enabled = False
            DEForm.Text = view_date(0)
            viewDetail(id_sales_order)
            noEdit()
            check_but()

            'trf data
            If is_transfer_data = "1" Then
                GroupControlAlloc.Visible = True
                viewWH()
                LEOrderType.ItemIndex = LEOrderType.Properties.GetDataSourceRowIndex("id_order_type", "3")
                LEOrderType.Enabled = False
                LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", "5")
                LEStatusSO.Enabled = False
            End If
            'replace promo
            If id_ol_promo <> "-1" Then
                BtnAddV3.Visible = False
                BtnDel.Visible = False
                GridColumnCode.OptionsColumn.AllowEdit = False
                GridColumnQty.OptionsColumn.AllowEdit = False
            End If
        ElseIf action = "upd" Then
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True

            'query view based on edit id's
            Dim query As String = "SELECT a.id_so_status, h.id_order_type, a.id_sales_order, a.id_store_contact_to, (d.id_comp) AS id_store,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, IFNULL(d.id_commerce_type,1) AS `id_commerce_type`, a.sales_order_ol_shop_number, a.sales_order_ol_shop_date, a.id_warehouse_contact_to, (wh.id_comp) AS id_comp_par,(wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to, a.id_report_status, f.report_status, "
            query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, "
            query += "DATE_FORMAT(a.sales_order_date,'%Y-%m-%d') AS sales_order_datex, a.id_so_type, IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`, ps.id_prepare_status, ps.prepare_status, a.id_emp_uni_period, a.id_uni_type, a.is_sync_stock, a.customer_name "
            query += "FROM tb_sales_order a "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
            query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
            query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status "
            query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
            query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
            query += "WHERE a.id_sales_order = '" + id_sales_order + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtReff.Text = data.Rows(0)("fg_so_reff_number").ToString

            id_store = data.Rows(0)("id_store").ToString
            id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString

            id_comp_par = data.Rows(0)("id_comp_par").ToString
            id_comp_contact_par = data.Rows(0)("id_warehouse_contact_to").ToString
            TxtWHCodeTo.Text = data.Rows(0)("warehouse_number_to").ToString
            TxtWHNameTo.Text = data.Rows(0)("warehouse_name_to").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_order_datex").ToString, 0)
            TxtSalesOrderNumber.Text = data.Rows(0)("sales_order_number").ToString
            MENote.Text = data.Rows(0)("sales_order_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            LEOrderType.ItemIndex = LEOrderType.Properties.GetDataSourceRowIndex("id_order_type", data.Rows(0)("id_order_type").ToString)
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            LEPeriodx.ItemIndex = LEPeriodx.Properties.GetDataSourceRowIndex("id_emp_uni_period", data.Rows(0)("id_emp_uni_period").ToString)
            LEUniType.ItemIndex = LEUniType.Properties.GetDataSourceRowIndex("id_uni_type", data.Rows(0)("id_uni_type").ToString)
            TxtPackingStatus.Text = data.Rows(0)("prepare_status").ToString
            CESync.Checked = If(data.Rows(0)("is_sync_stock").ToString = "1", True, False)

            'commertcce type
            id_commerce_type = data.Rows(0)("id_commerce_type").ToString
            checkCommerceType()
            If id_commerce_type = "1" Then
                TxtOLShopNumber.Text = ""
                DEOLShop.EditValue = Nothing
                TxtCustName.EditValue = ""
            ElseIf id_commerce_type = "2" Then
                TxtOLShopNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
                DEOLShop.EditValue = data.Rows(0)("sales_order_ol_shop_date")
                TxtCustName.EditValue = data.Rows(0)("customer_name").ToString
            End If


            'set type
            If Not IsDBNull(data.Rows(0)("id_emp_uni_period")) Then
                id_type = "1"
            Else
                id_type = "-1"
            End If

            'detail2
            viewDetail(id_sales_order)
            noEdit()
            getDataReference()
            check_but()
            allow_status()

            'view log jika dia sync
            If CESync.EditValue And id_report_status = "6" Then
                Dim id_trf As String = "-1"
                Try
                    id_trf = execute_query("SELECT t.id_fg_trf FROM tb_fg_trf t WHERE t.id_sales_order=" + id_sales_order + "", 0, True, "", "", "", "")
                Catch ex As Exception
                    id_trf = "-1"
                End Try

                Try
                    Dim ql As String = "SELECT * FROM tb_shopify_api_log a WHERE a.report_mark_type=57 AND a.id_report=" + id_trf + " AND a.is_verify<>1 "
                    Dim dl As DataTable = execute_query(ql, -1, True, "", "", "", "")
                    If dl.Rows.Count > 0 Then
                        stopCustom("Some product failed to sync")
                        viewLog()
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

        'general view
        If id_type = "1" Then 'prepare uniform
            GroupUni.Visible = True
            LEPeriodx.Focus()
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", "5")
            LEStatusSO.Enabled = False
        Else
            GroupUni.Visible = False
        End If
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Sub viewOrderType()
        Dim query As String = "SELECT ot.id_order_type, ot.order_type, ot.description
        FROM tb_lookup_so_status a 
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = a.id_order_type
        INNER JOIN tb_lookup_so_status_acc b ON a.id_so_status = b.id_so_status 
        WHERE b.id_departement='" + id_departement_user + "' 
        GROUP BY ot.id_order_type
        ORDER BY ot.id_order_type ASC "
        viewLookupQuery(LEOrderType, query, 0, "order_type", "id_order_type")
    End Sub

    Sub viewSoStatus()
        Dim id_order_type As String = "-1"
        Try
            id_order_type = LEOrderType.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT a.id_so_status, a.so_status FROM tb_lookup_so_status a "
        query += "INNER JOIN tb_lookup_so_status_acc b ON a.id_so_status = b.id_so_status "
        query += "WHERE b.id_departement='" + id_departement_user + "' AND a.id_order_type='" + id_order_type + "' "
        query += "ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewPeriodUniform()
        Dim query As String = "SELECT * FROM tb_emp_uni_period p ORDER BY p.id_emp_uni_period DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.Properties.DataSource = Nothing
        LEPeriodx.Properties.DataSource = data
        LEPeriodx.Properties.DisplayMember = "period_name"
        LEPeriodx.Properties.ValueMember = "id_emp_uni_period"
        LEPeriodx.ItemIndex = 0
    End Sub

    Sub viewUniType()
        Dim query As String = "SELECT * FROM tb_lookup_uni_type t ORDER BY t.id_uni_type ASC "
        viewLookupQuery(LEUniType, query, 0, "uni_type", "id_uni_type")
    End Sub

    Sub viewDetail(ByVal id_sales_order_par As String)
        Dim query As String = ""
        If id_commerce_type = "2" Then
            query = "CALL view_sales_order_ol_store('" + id_sales_order_par + "')"
        Else
            query = "CALL view_sales_order('" + id_sales_order_par + "')"
        End If
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        If action = "ins" Then
            'action
        ElseIf action = "upd" Then
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_order_det_list.Add(data.Rows(i)("id_sales_order_det").ToString)
            Next
        End If
        GCItemList.DataSource = data
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 28)
    End Sub

    Private Function checkOrderExist(ByVal qry_par As String, ByVal show_number As Boolean)
        Dim cond_isnull As String = ""
        If show_number = False Then
            cond_isnull = "AND ISNULL(b.id_sales_order)"
        End If

        Dim query As String = "SELECT a.id_store_contact_to, a.id_product, SUM(a.qty) AS `qty`, a.id_design_price, b.id_sales_order, b.sales_order_number
        FROM (
	        " + qry_par + "
        ) a
        LEFT JOIN (
	        SELECT so.id_sales_order,so.sales_order_number,so.id_store_contact_to, sod.id_product, SUM(sod.sales_order_det_qty) AS `qty`, sod.id_design_price 
	        FROM tb_sales_order_det sod
	        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
	        WHERE so.id_report_status!=5 AND so.id_store_contact_to=" + id_store_contact_to + " AND so.id_so_status=6
	        GROUP BY so.id_sales_order, sod.id_product
        ) b ON b.id_store_contact_to = a.id_store_contact_to AND b.id_product = a.id_product AND b.qty = a.qty AND b.id_design_price = a.id_design_price
        WHERE 1=1 
        " + cond_isnull + "
        GROUP BY a.id_product "

        If Not show_number Then
            Return query
        Else
            Dim qnum As String = query + "LIMIT 1 "
            Dim dnum As DataTable = execute_query(qnum, -1, True, "", "", "", "")
            Return dnum
        End If
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        GVItemList.CloseEditor()
        BtnSave.Focus()
        makeSafeGV(GVItemList)
        ValidateChildren()

        'del not found
        delNotFoundMyRow()

        'check stock
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking stock")
        Dim dts As DataTable
        Dim cond_data As Boolean = True
        If id_commerce_type = "1" Then
            'offline store
            getDataReference()
            For c As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_product_cek As String = GVItemList.GetRowCellValue(c, "id_product").ToString
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(c, "sales_order_det_qty")
                Dim id_sales_order_det As String = GVItemList.GetRowCellValue(c, "id_sales_order_det").ToString
                If id_sales_order_det = "0" Then
                    Dim data_filter_cek As DataRow() = dt.Select("[id_product]='" + id_product_cek + "' ")
                    If data_filter_cek.Length <= 0 Then
                        GVItemList.SetRowCellValue(c, "error_status", "Product not found;")
                        cond_data = False
                    Else
                        If qty_cek > data_filter_cek(0)("total_allow") Then
                            GVItemList.SetRowCellValue(c, "error_status", "Qty can't exceed " + data_filter_cek(0)("total_allow").ToString + ";")
                            cond_data = False
                        Else
                            GVItemList.SetRowCellValue(c, "error_status", "")
                        End If
                    End If
                End If
            Next
        ElseIf id_commerce_type = "2" Then
            'online
            If GVItemList.RowCount > 0 Then
                Dim qs As String = "DELETE FROM tb_temp_val_stock WHERE id_user='" + id_user + "'; 
                            INSERT INTO tb_temp_val_stock(id_user, code, name, size, id_product, qty) VALUES "
                Dim id_prod As String = ""
                For s As Integer = 0 To GVItemList.RowCount - 1
                    If s > 0 Then
                        qs += ","
                        id_prod += ","
                    End If
                    qs += "('" + id_user + "','" + GVItemList.GetRowCellValue(s, "code").ToString + "','" + addSlashes(GVItemList.GetRowCellValue(s, "name").ToString) + "', '" + GVItemList.GetRowCellValue(s, "size").ToString + "', '" + GVItemList.GetRowCellValue(s, "id_product").ToString + "', '" + decimalSQL(GVItemList.GetRowCellValue(s, "sales_order_det_qty").ToString) + "') "
                    id_prod += GVItemList.GetRowCellValue(s, "id_product").ToString
                Next
                qs += "; CALL view_validate_stock(" + id_user + ", " + id_comp_par + ", '" + id_prod + "',1); "
                dts = execute_query(qs, -1, True, "", "", "", "")
                If dts.Rows.Count > 0 Then
                    Cursor = Cursors.Default
                    cond_data = False
                End If
            End If
        End If
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        FormMain.SplashScreenManager1.CloseWaitForm()


        'check account trf
        Dim cond_cat_trf As Boolean = True
        If id_store_cat = "5" And LEStatusSO.EditValue.ToString <> "5" Then
            cond_cat_trf = False
        End If

        'check account store
        Dim cond_cat_str As Boolean = True
        If id_store_cat <> "5" And LEStatusSO.EditValue.ToString = "5" Then
            cond_cat_str = False
        End If

        'check number reference ol shop
        Dim cond_ol_shop As Boolean = True
        If id_commerce_type = "2" Then
            If TxtOLShopNumber.Text = "" Or DEOLShop.Text = "" Or TxtCustName.Text = "" Then
                cond_ol_shop = False
            End If
        End If

        'check item id ol shop
        makeSafeGV(GVItemList)
        Dim cond_not_blank_item_id_ol_shop As Boolean = True
        If id_commerce_type = "2" Then
            GVItemList.ActiveFilterString = "isnullorempty([item_id]) OR isnullorempty([ol_store_id])"
            If GVItemList.RowCount > 0 Then
                cond_not_blank_item_id_ol_shop = False
            End If
        End If
        GVItemList.ActiveFilterString = ""

        'blok order jika sudah pernah dibuat khiusus new wholesale
        Dim dt_existing_order As DataTable = Nothing
        Dim cond_no_exist As Boolean = True
        If LEStatusSO.EditValue.ToString = "6" And is_block_same_nw = "1" And id_commerce_type = "1" Then
            Dim qry As String = ""
            For f As Integer = 0 To GVItemList.RowCount - 1
                If f > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT " + id_store_contact_to + " AS `id_store_contact_to`," + GVItemList.GetRowCellValue(f, "id_product").ToString + " AS `id_product`," + GVItemList.GetRowCellValue(f, "sales_order_det_qty").ToString + " AS `qty`, " + GVItemList.GetRowCellValue(f, "id_design_price").ToString + " AS `id_design_price` "
            Next

            'check
            Dim qcek As String = checkOrderExist(qry, False)
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count = 0 Then
                cond_no_exist = False
                dt_existing_order = checkOrderExist(qry, True)
            End If
        End If

        'cek coa jika Wholesale Online Store
        If LEStatusSO.EditValue.ToString = "14" Then
            If Not viewCheckCoa() Then
                stopCustom("Account COA for this store is not found, please contact Accounting Dept.")
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        'check sku shopify
        If CESync.Checked Then
            If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                FormMain.SplashScreenManager1.ShowWaitForm()
            End If

            'get shopify product
            FormMain.SplashScreenManager1.SetWaitFormDescription("Get shopify product")
            Dim found_sku As Boolean = True
            Dim sku_shopify As String = ""
            Dim sku_shopify_copy As String = ""
            getProductShopify()

            'cek promo
            FormMain.SplashScreenManager1.SetWaitFormDescription("Get promo product")
            Dim already_no_promo As Boolean = True
            Dim sku_promo As String = ""
            Dim sku_promo_copy As String = ""
            Dim dpp As DataTable
            If id_ol_promo = "-1" Then
                Dim query_get_promo As String = "SELECT GROUP_CONCAT(DISTINCT p.id_ol_promo_collection) AS `id_prm`
                FROM tb_ol_promo_collection p WHERE p.id_report_status=6 
                AND NOW()<=p.end_period"
                Dim id_prm As String = execute_query(query_get_promo, 0, True, "", "", "", "")
                If id_prm = "" Then
                    id_prm = "0"
                End If
                'get data product
                Dim qpp As String = "SELECT d.id_product 
                FROM tb_ol_promo_collection_sku d 
                WHERE d.id_ol_promo_collection IN(" + id_prm + ")
                GROUP BY d.id_product "
                dpp = execute_query(qpp, -1, True, "", "", "", "")
            End If



            Dim sku_already As Boolean = True
            Dim sku_in As String = ""
            Dim sku_copy As String = ""

            For i = 0 To GVItemList.RowCount - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking order " + (i + 1).ToString + " of " + GVItemList.RowCount.ToString)
                If GVItemList.IsValidRowHandle(i) Then
                    Dim q_already As String = "SELECT COUNT(*) AS total, sku FROM tb_m_product_shopify WHERE sku = " + GVItemList.GetRowCellValue(i, "code").ToString

                    Dim d_already As DataTable = execute_query(q_already, -1, True, "", "", "", "")

                    If d_already.Rows(0)("total").ToString = "0" Then
                        sku_already = False

                        sku_in += GVItemList.GetRowCellValue(i, "code").ToString + ", "

                        sku_copy += GVItemList.GetRowCellValue(i, "code").ToString + Environment.NewLine
                    End If

                    'cek promo
                    If id_ol_promo = "-1" Then
                        If dpp.Rows.Count > 0 Then
                            Dim dpp_filter As DataRow() = dpp.Select("[id_product]='" + GVItemList.GetRowCellValue(i, "id_product").ToString + "' ")
                            If dpp_filter.Length > 0 Then
                                already_no_promo = False

                                sku_promo += GVItemList.GetRowCellValue(i, "code").ToString + ", "

                                sku_promo_copy += GVItemList.GetRowCellValue(i, "code").ToString + Environment.NewLine
                            End If
                        End If
                    End If

                    'cek shopify
                    Dim dt_shop_filter As DataRow() = dt_shop.Select("[sku]='" + GVItemList.GetRowCellValue(i, "code").ToString + "'")
                    If dt_shop_filter.Length <= 0 Then
                        found_sku = False

                        sku_shopify += GVItemList.GetRowCellValue(i, "code").ToString + ", "

                        sku_shopify_copy += GVItemList.GetRowCellValue(i, "code").ToString + Environment.NewLine
                    End If
                End If
            Next

            'not found sku di tabel
            If Not sku_already Then
                FormMain.SplashScreenManager1.CloseWaitForm()
                stopCustom("Can't find SKU: " + sku_in.Substring(0, sku_in.Length - 2) + ". Please make sure these SKU already on web or sync to shopify first.")

                My.Computer.Clipboard.SetText(sku_copy)

                Cursor = Cursors.Default
                Exit Sub
            End If

            'termasuk barang promo
            If Not already_no_promo Then
                FormMain.SplashScreenManager1.CloseWaitForm()
                stopCustom("These product already in promo programs : " + sku_promo.Substring(0, sku_promo.Length - 2) + ". Please use menu 'Replace Online Promo' for replace stock these products.")

                My.Computer.Clipboard.SetText(sku_promo_copy)

                Cursor = Cursors.Default
                Exit Sub
            End If

            'sku di web gak ada
            If Not found_sku Then
                FormMain.SplashScreenManager1.CloseWaitForm()
                stopCustom("These product not found on website : " + sku_shopify.Substring(0, sku_shopify.Length - 2))

                My.Computer.Clipboard.SetText(sku_shopify_copy)

                Cursor = Cursors.Default
                Exit Sub
            End If
            FormMain.SplashScreenManager1.CloseWaitForm()
        End If

        'block stocktake eos
        Dim all_product As List(Of String) = New List(Of String)

        For i = 0 To GVItemList.RowCount - 1
            If GVItemList.IsValidRowHandle(i) Then
                all_product.Add(GVItemList.GetRowCellValue(i, "id_product").ToString)
            End If
        Next

        Dim block_stocktake As Boolean = block_stocktake_eos(all_product)

        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopMain) Then
            errorInput()
        ElseIf Not cond_data Then
            If id_commerce_type = "1" Then
                stopCustom("Please see error log in item list !")
                GridColumnErr.Visible = True
                GridColumnErr.VisibleIndex = 100
            ElseIf id_commerce_type = "2" Then
                stopCustom("No stock available for some items.")
                FormValidateStock.dt = dts
                FormValidateStock.ShowDialog()
            End If
        ElseIf Not cond_cat_trf Then
            stopCustom("Please select category 'Transfer' !")
        ElseIf Not cond_cat_str Then
            stopCustom("Transfer order can't process, please select another category !")
        ElseIf Not cond_ol_shop Then
            stopCustom("Please input online store order number, order date and cust. name !")
            TxtOLShopNumber.Focus()
        ElseIf Not cond_not_blank_item_id_ol_shop Then
            stopCustom("Please input order id & ol store id")
        ElseIf Not cond_no_exist Then
            Cursor = Cursors.WaitCursor
            FormCustomDialog.LabelContent.Text = "This order already exist in order number : " + dt_existing_order.Rows(0)("sales_order_number").ToString
            FormCustomDialog.id_report = dt_existing_order.Rows(0)("id_sales_order").ToString
            FormCustomDialog.rmt = "39"
            FormCustomDialog.BtnAction.Text = "View " + dt_existing_order.Rows(0)("sales_order_number").ToString
            FormCustomDialog.ShowDialog()
            Cursor = Cursors.Default
        ElseIf Not block_stocktake Then
            stopCustom("Some product already in EOS and need to stock take first.")
        Else
            Dim sales_order_note As String = addSlashes(MENote.Text)
            Dim id_so_type As String = LETypeSO.EditValue.ToString
            Dim id_so_status As String = LEStatusSO.EditValue.ToString
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim sales_order_number As String = ""
            Dim id_emp_uni_period As String = "NULL"
            Dim id_uni_type As String = "NULL"
            If id_type = "1" Then 'prepare uniform
                id_emp_uni_period = LEPeriodx.EditValue.ToString
                id_uni_type = LEUniType.EditValue.ToString
            End If
            Dim sales_order_ol_shop_number As String = addSlashes(TxtOLShopNumber.Text)
            Dim sales_order_ol_shop_date As String = "NULL "
            Dim customer_name As String = "NULL "
            If id_commerce_type = "2" Then
                sales_order_ol_shop_date = "'" + DateTime.Parse(DEOLShop.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
                customer_name = "'" + addSlashes(TxtCustName.EditValue.ToString) + "'"
            End If
            Dim is_sync_stock As String = If(CESync.Checked, "1", "2")

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    sales_order_number = ""
                    'Main tbale
                    Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_uni_type, sales_order_ol_shop_number, sales_order_ol_shop_date, is_transfer_data, is_sync_stock, customer_name) "
                    query += "VALUES('" + id_store_contact_to + "', '" + id_comp_contact_par + "', '" + sales_order_number + "', NOW(), '" + sales_order_note + "', '" + id_so_type + "', '" + id_report_status + "', '" + id_so_status + "', '" + id_user + "'," + id_emp_uni_period + ", " + id_uni_type + ",'" + sales_order_ol_shop_number + "', " + sales_order_ol_shop_date + ", '" + is_transfer_data + "', '" + is_sync_stock + "', " + customer_name + "); SELECT LAST_INSERT_ID(); "
                    id_sales_order = execute_query(query, 0, True, "", "", "", "")

                    'insert who prepared
                    insert_who_prepared("39", id_sales_order, id_user)

                    'Detail 
                    Dim query_detail As String = ""
                    Dim jum_ins_j As Integer = 0
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note, item_id, ol_store_id,id_ol_promo_collection_sku_replace) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_order_det_qty").ToString)
                            Dim sales_order_det_note As String = addSlashes(GVItemList.GetRowCellValue(i, "sales_order_det_note").ToString)
                            Dim item_id As String = addSlashes(GVItemList.GetRowCellValue(i, "item_id").ToString)
                            Dim ol_store_id As String = addSlashes(GVItemList.GetRowCellValue(i, "ol_store_id").ToString)
                            Dim id_ol_promo_collection_sku_replace = GVItemList.GetRowCellValue(i, "id_ol_promo_collection_sku_replace").ToString
                            If id_ol_promo_collection_sku_replace = "" Then
                                id_ol_promo_collection_sku_replace = "NULL"
                            End If
                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "','" + item_id + "','" + ol_store_id + "'," + id_ol_promo_collection_sku_replace + ") "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'reserved
                    Dim rsv As New ClassSalesOrder()
                    rsv.reservedStock(id_sales_order)

                    FormSalesOrder.viewSalesOrder()
                    FormSalesOrder.viewDet()
                    FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_sales_order)
                    action = "upd"
                    actionLoad()

                    'gen xls
                    exportToBOF(False)

                    infoCustom("Prepare order : " + TxtSalesOrderNumber.Text.ToString + " was created successfully. ")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    sales_order_number = TxtSalesOrderNumber.Text
                    Dim query As String = "UPDATE tb_sales_order SET id_store_contact_to='" + id_store_contact_to + "', id_warehouse_contact_to='" + id_comp_contact_par + "', sales_order_number = '" + sales_order_number + "', sales_order_note='" + sales_order_note + "', id_so_type='" + id_so_type + "', id_so_status = '" + id_so_status + "', 
                    id_emp_uni_period=" + id_emp_uni_period + ", id_uni_type=" + id_uni_type + ", sales_order_ol_shop_number='" + sales_order_ol_shop_number + "', is_sync_stock = '" + is_sync_stock + "', customer_name = " + customer_name + "
                    WHERE id_sales_order='" + id_sales_order + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'edit detail table
                    Dim query_detail As String = ""
                    Dim jum_ins_j As Integer = 0
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) VALUES "
                    End If
                    For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(i, "id_sales_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            Dim sales_order_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(i, "sales_order_det_qty").ToString)
                            Dim sales_order_det_note As String = GVItemList.GetRowCellValue(i, "sales_order_det_note").ToString
                            If id_sales_order_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_order + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "')"
                                jum_ins_j = jum_ins_j + 1
                            Else
                                Dim query_edit As String = "UPDATE tb_sales_order_det SET id_product = '" + id_product + "', id_design_price='" + id_design_price + "', design_price = '" + design_price + "', sales_order_det_qty = '" + sales_order_det_qty + "', sales_order_det_note='" + sales_order_det_note + "' WHERE id_sales_order_det = '" + id_sales_order_det + "' "
                                execute_non_query(query_edit, True, "", "", "", "")
                                id_sales_order_det_list.Remove(id_sales_order_det)
                            End If
                        Catch ex As Exception
                            ex.ToString()
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'delete sisa
                    'For k As Integer = 0 To (id_sales_order_det_list.Count - 1)
                    '    Try
                    '        Dim querydel As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det = '" + id_sales_order_det_list(k) + "' "
                    '        execute_non_query(querydel, True, "", "", "", "")
                    '    Catch ex As Exception
                    '        ex.ToString()
                    '    End Try
                    'Next

                    FormSalesOrder.viewSalesOrder()
                    FormSalesOrder.viewDet()
                    FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", id_sales_order)
                    action = "upd"
                    actionLoad()

                    'gen xls
                    exportToBOF(False)

                    infoCustom("Prepare order : " + sales_order_number.ToString + " was edited successfully. ")
                    Cursor = Cursors.Default
                End If
            End If

            'hide col err
            GridColumnErr.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    'sub check_but
    Sub check_but()
        'Dim id_productx As String = "0"
        'Try
        '    id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        'Catch ex As Exception

        'End Try

        ''MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "39", id_sales_order) Then
            BtnBrowseContactTo.Enabled = False
            BtnBrowseWH.Enabled = False
            GVItemList.OptionsBehavior.Editable = True
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = False
            LETypeSO.Enabled = False
            LEStatusSO.Enabled = False
            TxtCodeCompTo.Enabled = False
            TxtWHCodeTo.Enabled = False
            LEPeriodx.Enabled = True
            LEUniType.Enabled = True
            If id_commerce_type = "2" Then
                TxtOLShopNumber.Enabled = False
                DEOLShop.Enabled = False
                TxtCustName.Enabled = False
            End If
        Else
            BtnBrowseContactTo.Enabled = False
            BtnBrowseWH.Enabled = False
            GVItemList.OptionsBehavior.Editable = False
            PanelControlNav.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            LETypeSO.Enabled = False
            LEStatusSO.Enabled = False
            TxtCodeCompTo.Enabled = False
            TxtWHCodeTo.Enabled = False
            LEPeriodx.Enabled = False
            LEUniType.Enabled = False
            TxtOLShopNumber.Enabled = False
            DEOLShop.Enabled = False
            TxtCustName.Enabled = False
        End If
        LEOrderType.Enabled = False

        'attachment
        BtnAttachment.Enabled = True
        'If check_attach_report_status(id_report_status, "39", id_sales_order) Then
        'BtnAttachment.Enabled = True
        'Else
        'BtnAttachment.Enabled = False
        'End If

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
        TxtSalesOrderNumber.Focus()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "38"
        FormPopUpContact.id_so_type = id_so_type
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesOrderDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormSalesOrderSingle.action_pop = "ins"
        FormSalesOrderSingle.ShowDialog()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
        check_but()
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormSalesOrderSingle.action_pop = "upd"
        FormSalesOrderSingle.indeks_edit = GVItemList.FocusedRowHandle()
        FormSalesOrderSingle.id_product_edit = GVItemList.GetFocusedRowCellValue("id_product").ToString
        FormSalesOrderSingle.product_code = GVItemList.GetFocusedRowCellValue("code").ToString
        FormSalesOrderSingle.id_design_price_edit = GVItemList.GetFocusedRowCellValue("id_design_price")
        FormSalesOrderSingle.qty_edit = GVItemList.GetFocusedRowCellValue("sales_order_det_qty")
        FormSalesOrderSingle.remark_edit = GVItemList.GetFocusedRowCellValue("sales_order_det_note").ToString
        FormSalesOrderSingle.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        delMyRow()
    End Sub

    Public Sub delAllList(ByVal rh_par As Integer)
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            GVItemList.DeleteRow(i)
        Next
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        'For i As Integer = 0 To (GVItemList.RowCount - 1)
        '    Try
        '        Dim id_product As String = GVItemList.GetRowCellValue(i, "id_product").ToString
        '        MsgBox(id_product)
        '    Catch ex As Exception

        '    End Try
        'Next
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        If AllowOpenMark("39", id_sales_order, id_report_status) Then
            FormReportMark.id_report = id_sales_order
            FormReportMark.report_mark_type = "39"
            FormReportMark.form_origin = Name
            FormReportMark.ShowDialog()
        Else
            stopCustom("Data not found")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportSalesOrder.dt = GCItemList.DataSource
        ReportSalesOrder.id_sales_order = id_sales_order
        Dim Report As New ReportSalesOrder()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSalesOrder.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSalesOrder)

        'Parse val
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelWarehouse.Text = TxtWHCodeTo.Text + "-" + TxtWHNameTo.Text
        Report.LabelCategory.Text = LEStatusSO.Text
        Report.LabelReff.Text = TxtReff.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LRecNumber.Text = TxtSalesOrderNumber.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelType.Text = LETypeSO.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.id_report = id_sales_order
        FormDocumentUpload.report_mark_type = "39"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "62"
        FormPopUpContact.is_must_active = "1"
        FormPopUpContact.id_cat = id_comp_cat_wh
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddV2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddV2.Click
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            Cursor = Cursors.WaitCursor
            If id_ol_promo = "-1" Then
                FormSalesOrderSingleV2.id_wh_par = id_comp_par
                FormSalesOrderSingleV2.id_store_par = id_store
                FormSalesOrderSingleV2.data_par = GCItemList.DataSource
                FormSalesOrderSingleV2.ShowDialog()
            Else
                FormSalesOrderPromoList.id_ol_promo = id_ol_promo
                FormSalesOrderPromoList.data_par = GCItemList.DataSource
                FormSalesOrderPromoList.data_stock = dt
                FormSalesOrderPromoList.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LETypeSO_EditValueChanged(sender As Object, e As EventArgs) Handles LETypeSO.EditValueChanged
        id_so_type = LETypeSO.EditValue.ToString
        If action = "ins" Then
            id_store_contact_to = ""
            TxtCodeCompTo.Text = ""
            TxtNameCompTo.Text = ""
            MEAdrressCompTo.Text = ""
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim id_so_type As String = LETypeSO.EditValue.ToString
            Dim query_cond As String = "AND comp.id_comp<>'" + get_setup_field("wh_temp") + "' "
            If is_transfer_data = "2" Then
                query_cond += "AND (comp.id_comp_cat=5 OR comp.id_comp_cat=6) AND comp.is_active=1 AND comp.is_only_for_alloc=2 "
            Else
                Dim id_wh_parent As String = SLEAccount.EditValue.ToString
                query_cond += "AND comp.is_active=1 AND comp.id_wh_group='" + id_wh_parent + "' "
            End If
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                resetStore()
                TxtCodeCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                If data.Rows.Count > 1 Then
                    'jika ada 2 akun yang sama
                    FormPopUpContact.id_pop_up = "38"
                    FormPopUpContact.id_so_type = id_so_type
                    FormPopUpContact.comp_number = TxtCodeCompTo.Text
                    FormPopUpContact.ShowDialog()
                    If id_store = "-1" Then
                        TxtCodeCompTo.Text = ""
                        resetStore()
                        TxtCodeCompTo.Focus()
                        Exit Sub
                    Else
                        TxtWHCodeTo.Focus()
                    End If
                Else
                    viewDetail("-1")
                    noEdit()
                    id_store = data.Rows(0)("id_comp").ToString
                    id_commerce_type = data.Rows(0)("id_commerce_type").ToString
                    checkCommerceType()
                    id_store_cat = data.Rows(0)("id_comp_cat").ToString
                    id_store_type = data.Rows(0)("id_store_type").ToString
                    id_wh_type = data.Rows(0)("id_wh_type").ToString

                    'tentukan akun type
                    If data.Rows(0)("id_comp_cat").ToString = "5" Then
                        'wh
                        id_account_type = id_wh_type
                    Else
                        'store
                        id_account_type = id_store_type
                        If id_account_type = "3" Then
                            id_account_type = "2"
                        End If
                    End If

                    id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                    TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                    MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                    TxtWHCodeTo.Focus()
                    'check sync
                    check_sync()
                End If
                Cursor = Cursors.Default
            End If
        Else
            'selain enter informasi store di reset
            resetStore()
        End If
    End Sub

    Sub check_sync()
        'cek sync
        Dim q_sync As String = "SELECT * FROM tb_m_comp_volcom_ol
WHERE id_comp IN (" & id_store & ", " & id_comp_par & ")"
        Dim dt_sync As DataTable = execute_query(q_sync, -1, True, "", "", "", "")
        If dt_sync.Rows.Count > 0 Then
            'ol shop
            CESync.Checked = True
        Else
            'bukan ol shop
            CESync.Checked = False
        End If
    End Sub

    Sub resetStore()
        If GVItemList.RowCount > 0 Then
            viewDetail("-1")
        End If
        id_store = "-1"
        id_commerce_type = "-1"
        id_store_cat = "-1"
        id_store_type = "-1"
        id_wh_type = "-1"
        id_account_type = "-1"
        id_store_contact_to = "-1"
        TxtNameCompTo.Text = ""
        MEAdrressCompTo.Text = ""
        TxtOLShopNumber.Text = ""
        TxtOLShopNumber.Enabled = False
    End Sub

    Sub checkCommerceType()
        If action = "ins" Then
            DEOLShop.EditValue = Nothing
        End If

        If id_commerce_type = "1" Then
            TxtOLShopNumber.Enabled = False
            DEOLShop.Enabled = False
            TxtCustName.Enabled = False
            GridColumnItemId.Visible = False
            GridColumnOLStoreId.Visible = False
            RepositoryItemSpinEdit1.ReadOnly = False
        ElseIf id_commerce_type = "2" Then
            TxtOLShopNumber.Enabled = True
            DEOLShop.Enabled = True
            TxtCustName.Enabled = True
            GridColumnItemId.VisibleIndex = 1
            GridColumnOLStoreId.VisibleIndex = 2
            GridColumnCode.VisibleIndex = 3
            RepositoryItemSpinEdit1.ReadOnly = True

            'get own ol store comp
            Dim qol As String = "SELECT o.own_ol_store_normal, o.own_ol_store_sale FROM tb_opt o "
            Dim dol As DataTable = execute_query(qol, -1, True, "", "", "", "")
            Dim own_ol_store_normal As String = dol.Rows(0)("own_ol_store_normal").ToString
            Dim own_ol_store_sale As String = dol.Rows(0)("own_ol_store_sale").ToString
            If id_store = own_ol_store_normal Or id_store = own_ol_store_sale Then
                LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", "14")
                LEStatusSO.Enabled = False
            End If
        End If
    End Sub

    Private Sub TxtWHCodeTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtWHCodeTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim condwh As String = "AND comp.id_comp<>'" + get_setup_field("wh_temp") + "' "
            If is_transfer_data = "2" Then
                condwh += "AND id_comp_cat = '" + id_comp_cat_wh + "' AND comp.is_active=1 AND comp.is_only_for_alloc=2 "
            Else
                condwh += "AND comp.is_active=1 AND comp.id_wh_group='" + SLEAccount.EditValue.ToString + "' "
            End If
            Dim data As DataTable = get_company_by_code(TxtWHCodeTo.Text, condwh)
            If data.Rows.Count = 0 Then
                stopCustom("Warehouse not found!")
                viewDetail("-1")
                id_comp_par = "-1"
                id_comp_contact_par = "-1"
                TxtWHNameTo.Text = ""
                TxtWHCodeTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                viewDetail("-1")
                noEdit()
                id_comp_par = data.Rows(0)("id_comp").ToString
                id_comp_contact_par = data.Rows(0)("id_comp_contact").ToString
                TxtWHNameTo.Text = data.Rows(0)("comp_name").ToString
                getDataReference()
                If LEStatusSO.Enabled = False Then
                    addMyRow()
                    GCItemList.Focus()
                Else
                    LEStatusSO.Focus()
                End If
                'check sync
                check_sync()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAddV3_Click(sender As Object, e As EventArgs) Handles BtnAddV3.Click
        Cursor = Cursors.WaitCursor
        addMyRow()
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        GCItemList.Focus()
        GVItemList.FocusedColumn = GridColumnCode
        Cursor = Cursors.Default
    End Sub

    Sub addMyRow()
        If id_ol_promo = "-1" Then
            Dim newRow As DataRow = (TryCast(GCItemList.DataSource, DataTable)).NewRow()
            newRow("id_sales_order_det") = "0"
            newRow("name") = ""
            newRow("code") = ""
            newRow("size") = ""
            newRow("sales_order_det_qty") = 0
            newRow("id_design_price") = 0
            newRow("design_price") = 0
            newRow("design_price_type") = ""
            newRow("amount") = 0
            newRow("qty_avail") = 0
            newRow("sales_order_det_note") = ""
            newRow("id_design") = "0"
            newRow("id_product") = "0"
            newRow("id_sample") = "0"
            newRow("is_found") = "2"
            newRow("error_status") = ""
            TryCast(GCItemList.DataSource, DataTable).Rows.Add(newRow)
            'CType(GCItemList.DataSource, DataTable).AcceptChanges()
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            check_but()
        End If
    End Sub

    Sub delMyRow()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            If action = "ins" Then
                Cursor = Cursors.WaitCursor
                GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                CType(GCItemList.DataSource, DataTable).AcceptChanges()
                GCItemList.RefreshDataSource()
                GVItemList.RefreshData()
                check_but()
                Cursor = Cursors.Default
            ElseIf action = "upd" Then
                Cursor = Cursors.WaitCursor
                Dim id_sales_order_det_par As String = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
                If id_sales_order_det_par = "0" Then
                    GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                    CType(GCItemList.DataSource, DataTable).AcceptChanges()
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                    check_but()
                Else
                    Try
                        Dim query_del As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det='" + id_sales_order_det_par + "' "
                        execute_non_query(query_del, True, "", "", "", "")
                        FormSalesOrder.viewDet()
                        GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
                        CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        check_but()
                        getDataReference()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub LEStatusSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LEStatusSO.KeyDown
        If e.KeyCode = Keys.Enter Then
            If id_commerce_type = "1" Then
                addMyRow()
                GCItemList.Focus()
                If GVItemList.FocusedColumn.ToString = GVItemList.Columns("no").ToString Then
                    GVItemList.FocusedColumn = GridColumnCode
                End If
            Else
                TxtOLShopNumber.Focus()
            End If
        End If
    End Sub

    Private Sub GVItemList_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVItemList.FocusedColumnChanged
        'Try
        '    If e.FocusedColumn.ToString = GVItemList.Columns("no").ToString Then
        '        GVItemList.FocusedColumn = GridColumnCode
        '        'If id_commerce_type = "1" Then
        '        '    GVItemList.FocusedColumn = GridColumnCode
        '        'ElseIf id_commerce_type = "2" Then
        '        '    MsgBox("a")
        '        '    GVItemList.FocusedColumn = GridColumnItemId
        '        'End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub


    Private Sub GVItemList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVItemList.CellValueChanged
        If e.Column.FieldName = "sales_order_det_qty" Then
            'GVItemList.CloseEditor()
            Dim rh As Integer = GVItemList.FocusedRowHandle
            Dim qty_par As Integer = GVItemList.GetRowCellValue(rh, "sales_order_det_qty")
            If qty_par > 0 Then
                Dim qty_limit As Integer = GVItemList.GetRowCellValue(rh, "qty_avail")
                If qty_par > qty_limit Then
                    stopCustom("Qty can't exceed " + qty_limit.ToString)
                    GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 0)
                    GVItemList.FocusedColumn = GridColumnQty
                Else
                    GVItemList.SetRowCellValue(rh, "amount", qty_par * GVItemList.GetRowCellValue(rh, "design_price"))
                    GVItemList.FocusedColumn = GridColumnRemark
                End If
            End If
        End If
    End Sub

    Private Sub GVItemList_KeyDown(sender As Object, e As KeyEventArgs) Handles GVItemList.KeyDown
        If (e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control) And action = "ins" Then
            addMyRow()
            GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
            GVItemList.FocusedColumn = GridColumnCode
        ElseIf (e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control) And action = "ins" Then
            If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
                delMyRow()
            End If
        ElseIf e.KeyCode = Keys.Enter And action = "ins" Then
            Dim rh As Integer = GVItemList.FocusedRowHandle
            Dim id_sales_order_det As String = GVItemList.GetRowCellValue(rh, "id_sales_order_det").ToString
            If id_sales_order_det = "0" Then
                If GVItemList.FocusedColumn.ToString = "Item Id" Then
                    GVItemList.FocusedColumn = GridColumnOLStoreId
                ElseIf GVItemList.FocusedColumn.ToString = "Zalora Id" Then
                    GVItemList.FocusedColumn = GridColumnCode
                ElseIf GVItemList.FocusedColumn.ToString = "Code" Then
                    GVItemList.CloseEditor()
                    Dim code_pas As String = addSlashes(GVItemList.GetRowCellValue(rh, "code").ToString)
                    Dim data_filter As DataRow() = dt.Select("[product_full_code]='" + code_pas + "' ")
                    If data_filter.Length = 0 Then
                        stopCustom("Product not found !")
                        setDefautMyRow(rh)
                        CType(GCItemList.DataSource, DataTable).AcceptChanges()
                    Else
                        Dim dt_dupe As DataTable = GCItemList.DataSource
                        Dim data_filter_dupe As DataRow() = dt_dupe.Select("[code]='" + code_pas + "' AND [is_found]='1' ")
                        If data_filter_dupe.Length <= 0 Or id_commerce_type = "2" Then

                            'untuk akun tujuan sale dan normal
                            If (id_account_type = "1" Or id_account_type = "2") And LEStatusSO.EditValue.ToString <> 8 And is_transfer_data <> "1" Then
                                If (id_account_type <> data_filter(0)("id_design_cat").ToString) And data_filter(0)("design_price") > 0 Then
                                    GVItemList.SetRowCellValue(GVItemList.RowCount - 1, "code", "")
                                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                                    If id_account_type = "1" Then
                                        stopCustom(TxtCodeCompTo.Text + " is only for normal product. ")
                                    Else
                                        stopCustom(TxtCodeCompTo.Text + " is only for sale product. ")
                                    End If
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If

                            GVItemList.SetRowCellValue(rh, "id_sales_order_det", "0")
                            GVItemList.SetRowCellValue(rh, "name", data_filter(0)("design_display_name").ToString)
                            GVItemList.SetRowCellValue(rh, "size", data_filter(0)("Size").ToString)
                            GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 0)

                            'untuk claim toko normal
                            If LEStatusSO.EditValue.ToString = "8" And id_store_type = "1" Then 'jika cat claim dan toko normal => harga normal
                                Dim dtp As DataTable = getNormalPrice(data_filter(0)("id_design").ToString)
                                If dtp.Rows.Count > 0 Then
                                    GVItemList.SetRowCellValue(rh, "id_design_price", dtp(0)("id_design_price").ToString)
                                    GVItemList.SetRowCellValue(rh, "design_price", dtp(0)("design_price"))
                                    GVItemList.SetRowCellValue(rh, "design_price_type", dtp(0)("design_price_type").ToString)
                                Else
                                    GVItemList.SetRowCellValue(rh, "id_design_price", data_filter(0)("id_design_price").ToString)
                                    GVItemList.SetRowCellValue(rh, "design_price", data_filter(0)("design_price"))
                                    GVItemList.SetRowCellValue(rh, "design_price_type", data_filter(0)("design_price_type").ToString)
                                End If
                            Else 'selaiinnya haga update
                                GVItemList.SetRowCellValue(rh, "id_design_price", data_filter(0)("id_design_price").ToString)
                                GVItemList.SetRowCellValue(rh, "design_price", data_filter(0)("design_price"))
                                GVItemList.SetRowCellValue(rh, "design_price_type", data_filter(0)("design_price_type").ToString)
                            End If

                            GVItemList.SetRowCellValue(rh, "amount", 0)
                            GVItemList.SetRowCellValue(rh, "qty_avail", data_filter(0)("total_allow"))
                            GVItemList.SetRowCellValue(rh, "sales_order_det_note", "")
                            GVItemList.SetRowCellValue(rh, "id_design", data_filter(0)("id_design").ToString)
                            GVItemList.SetRowCellValue(rh, "id_product", data_filter(0)("id_product").ToString)
                            GVItemList.SetRowCellValue(rh, "id_sample", data_filter(0)("id_sample").ToString)
                            GVItemList.SetRowCellValue(rh, "is_found", "1")
                            GVItemList.SetRowCellValue(rh, "error_status", "")
                            GVItemList.FocusedColumn = GridColumnQty
                            CType(GCItemList.DataSource, DataTable).AcceptChanges()
                            If id_commerce_type = "2" Then
                                GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 1)
                            End If
                        Else
                            GVItemList.SetFocusedRowCellValue("code", "")
                            GVItemList.ActiveFilterString = "[code]='" + code_pas + "'"
                            FormSalesOrderDetEdit.ShowDialog()
                            GVItemList.ActiveFilterString = ""
                            GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                            GVItemList.FocusedColumn = GridColumnCode
                            'stopCustom("You already entry this product.")
                            'setDefautMyRow(rh)
                            'CType(GCItemList.DataSource, DataTable).AcceptChanges()
                        End If
                    End If
                ElseIf GVItemList.FocusedColumn.ToString = "Qty" Then
                    GVItemList.CloseEditor()
                    'Dim qty_par As Integer = GVItemList.GetRowCellValue(rh, "sales_order_det_qty")
                    'Dim qty_limit As Integer = GVItemList.GetRowCellValue(rh, "qty_avail")
                    'If qty_par > qty_limit Then
                    '    stopCustom("Qty can't exceed " + qty_limit.ToString)
                    '    GVItemList.SetRowCellValue(rh, "sales_order_det_qty", 0)
                    'Else
                    '    GVItemList.SetRowCellValue(rh, "amount", qty_par * GVItemList.GetRowCellValue(rh, "design_price"))
                    '    GVItemList.FocusedColumn = GridColumnRemark
                    'End If
                ElseIf GVItemList.FocusedColumn.ToString = "Remark" Then 'for remark
                    GVItemList.CloseEditor()
                    If GVItemList.GetRowCellValue(GVItemList.RowCount - 1, "code").ToString <> "" Then
                        addMyRow()
                    End If
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    If id_commerce_type = "1" Then
                        GVItemList.FocusedColumn = GridColumnCode
                    ElseIf id_commerce_type = "2" Then
                        GVItemList.FocusedColumn = GridColumnItemId
                    End If
                End If
            Else
                If GVItemList.FocusedColumn.ToString = "Remark" Then 'for remark
                    GVItemList.CloseEditor()
                    addMyRow()
                    GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
                    If id_commerce_type = "1" Then
                        GVItemList.FocusedColumn = GridColumnCode
                    ElseIf id_commerce_type = "2" Then
                        GVItemList.FocusedColumn = GridColumnItemId
                    End If
                End If
            End If
        End If
    End Sub

    Sub setDefautMyRow(ByVal rhx As Integer)
        GVItemList.SetRowCellValue(rhx, "id_sales_order_det", "0")
        GVItemList.SetRowCellValue(rhx, "code", "")
        GVItemList.SetRowCellValue(rhx, "name", "")
        GVItemList.SetRowCellValue(rhx, "size", "")
        GVItemList.SetRowCellValue(rhx, "sales_order_det_qty", 0)
        GVItemList.SetRowCellValue(rhx, "id_design_price", "0")
        GVItemList.SetRowCellValue(rhx, "design_price", 0)
        GVItemList.SetRowCellValue(rhx, "design_price_type", "")
        GVItemList.SetRowCellValue(rhx, "amount", 0)
        GVItemList.SetRowCellValue(rhx, "qty_avail", 0)
        GVItemList.SetRowCellValue(rhx, "sales_order_det_note", "")
        GVItemList.SetRowCellValue(rhx, "id_design", "0")
        GVItemList.SetRowCellValue(rhx, "id_product", "0")
        GVItemList.SetRowCellValue(rhx, "id_sample", "0")
        GVItemList.SetRowCellValue(rhx, "is_found", "2")
        GVItemList.SetRowCellValue(rhx, "error_status", "")
    End Sub

    Sub delNotFoundMyRow()
        GVItemList.ActiveFilterString = "[is_found]='2'"
        Dim i As Integer = GVItemList.RowCount - 1
        While (i >= 0)
            GVItemList.DeleteRow(i)
            i = i - 1
        End While
        makeSafeGV(GVItemList)
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
    End Sub

    Private Sub GVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVItemList.RowCellStyle
        If e.Column.FieldName = "error_status" Then
            If sender.GetRowCellValue(e.RowHandle, sender.Columns("error_status")) <> "" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.White
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub

    Sub noEdit()
        If GVItemList.FocusedRowHandle >= 0 Then
            Dim id_sales_order_det_cek As String = GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString
            If id_sales_order_det_cek = "0" Then
                GVItemList.Columns("code").OptionsColumn.AllowEdit = True
                GVItemList.Columns("sales_order_det_qty").OptionsColumn.AllowEdit = True
            Else
                GVItemList.Columns("code").OptionsColumn.AllowEdit = False
                GVItemList.Columns("sales_order_det_qty").OptionsColumn.AllowEdit = False
            End If
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            If id_ol_promo <> "-1" Then
                FormImportExcel.id_pop_up = "56"
            Else
                FormImportExcel.id_pop_up = "15"
            End If
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LETypeSO_KeyDown(sender As Object, e As KeyEventArgs) Handles LETypeSO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtCodeCompTo.Focus()
        End If
    End Sub

    Private Sub TxtWHNameTo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtWHNameTo.Validating
        EP_TE_cant_blank(EPForm, TxtWHNameTo)
        EPForm.SetIconPadding(TxtWHNameTo, 28)
    End Sub

    Private Sub BtnImportExcelNew_Click(sender As Object, e As EventArgs) Handles BtnImportExcelNew.Click
        Cursor = Cursors.WaitCursor
        If id_comp_par = "-1" Or id_store = "-1" Then
            stopCustom("Please select warehouse and store first !")
        Else
            If id_ol_promo <> "-1" Then
                FormImportExcel.id_pop_up = "57"
            Else
                FormImportExcel.id_pop_up = "25"
            End If
            FormImportExcel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
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
            GridColumnOLStoreNumber.VisibleIndex = 6
            GridColumnOLStoreOrderDate.VisibleIndex = 7
            GridColumnItemId.VisibleIndex = 8
            GridColumnOLStoreId.VisibleIndex = 9
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
            GridColumnNo.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnName.VisibleIndex = 2
            GridColumnSize.VisibleIndex = 3
            GridColumnQty.VisibleIndex = 4
            GridColumnPrice.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnRemark.VisibleIndex = 7
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GridColumnOLStoreNumber.Visible = False
            GridColumnOLStoreOrderDate.Visible = False
            GridColumnItemId.Visible = False
            GridColumnOLStoreId.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            checkCommerceType()
            Cursor = Cursors.Default
        End If
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
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_order_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                ElseIf j = 5 Then 'remark det
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_order_det_note").ToString
                ElseIf j = 6 Then 'ol store number
                    wSheet.Cells(rowIndex + 1, colIndex) = TxtOLShopNumber.Text
                ElseIf j = 7 Then 'ol store date
                    wSheet.Cells(rowIndex + 1, colIndex) = DEOLShop.Text
                ElseIf j = 8 Then 'item id
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "item_id").ToString
                ElseIf j = 9 Then 'ol store id
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "ol_store_id").ToString
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

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtWHCodeTo.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesOrderNumber.Text.ToString
        End If
    End Sub

    Private Sub LEStatusSO_EditValueChanged(sender As Object, e As EventArgs) Handles LEStatusSO.EditValueChanged
        If Not LEStatusSO.EditValue = LEStatusSO.OldEditValue Then
            If GVItemList.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset your item list order, are you sure want to continue this action?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    viewDetail("-1")
                Else
                    LEStatusSO.EditValue = LEStatusSO.OldEditValue
                End If
            End If

            'check coa for wholesale ol store
            If id_store <> "-1" And LEStatusSO.EditValue.ToString = "14" And action = "ins" Then
                If Not viewCheckCoa() Then
                    stopCustom("Account COA for this store is not found, please contact Accounting Dept.")
                    LEStatusSO.EditValue = LEStatusSO.OldEditValue
                    Close()
                End If
            End If
        End If
    End Sub


    Private Sub LEPeriodx_KeyDown(sender As Object, e As KeyEventArgs) Handles LEPeriodx.KeyDown
        If e.KeyCode = Keys.Enter Then
            LEUniType.Focus()
        End If
    End Sub

    Private Sub LEUniType_KeyDown(sender As Object, e As KeyEventArgs) Handles LEUniType.KeyDown
        If e.KeyCode = Keys.Enter Then
            LETypeSO.Focus()
        End If
    End Sub

    Private Sub TxtOLShopNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOLShopNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtOLShopNumber.Text <> "" Then
                DEOLShop.Focus()
            Else
                stopCustom("Please input online store order number !")
                TxtOLShopNumber.Focus()
            End If
        End If
    End Sub

    Private Sub DEOLShop_KeyDown(sender As Object, e As KeyEventArgs) Handles DEOLShop.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DEOLShop.Text <> "" Then
                addMyRow()
                GCItemList.Focus()
                If GVItemList.FocusedColumn.ToString = GVItemList.Columns("no").ToString Then
                    GVItemList.FocusedColumn = GridColumnItemId
                End If
            Else
                stopCustom("Please input online store order date !")
                DEOLShop.Focus()
            End If
        End If
    End Sub

    Private Sub BtnExportAsFile_Click(sender As Object, e As EventArgs) Handles BtnExportAsFile.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCItemList, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub LEOrderType_EditValueChanged(sender As Object, e As EventArgs) Handles LEOrderType.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim value As String = row("description").ToString
        TxtOrderType.Text = value
        viewSoStatus()
    End Sub

    Function viewCheckCoa() As Boolean
        Dim query As String = "SELECT *
        FROM tb_m_comp c 
        WHERE c.id_comp=" + id_store + " AND !ISNULL(c.id_acc_sales) AND !ISNULL(c.id_acc_sales_return) AND !ISNULL(c.id_acc_ar) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SBSyncShopify_Click(sender As Object, e As EventArgs) Handles SBSyncShopify.Click
        Cursor = Cursors.WaitCursor
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If

        FormMain.SplashScreenManager1.SetWaitFormDescription("Please wait")
        Dim cls As ClassShopifyApi = New ClassShopifyApi

        Dim no_duplicate As Boolean = cls.sync_sku()
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default

        If no_duplicate Then
            infoCustom("Sync complete.")
        End If
    End Sub

    Private Sub SBViewLog_Click(sender As Object, e As EventArgs) Handles SBViewLog.Click
        viewLog()
    End Sub

    Sub viewLog()
        FormSalesOrderDetViewLogSync.ShowDialog()
    End Sub

    Private Sub CESync_CheckedChanged(sender As Object, e As EventArgs) Handles CESync.CheckedChanged
        If CESync.EditValue Then
            SBViewLog.Visible = True
        Else
            SBViewLog.Visible = False
        End If
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        'reset store
        resetStore()
        TxtCodeCompTo.Text = ""
        'reset wh
        id_comp_par = "-1"
        id_comp_contact_par = "-1"
        TxtWHNameTo.Text = ""
        TxtWHCodeTo.Text = ""
    End Sub

    Sub getProductShopify()
        Cursor = Cursors.WaitCursor
        'clear dt
        Try
            dt_shop.Clear()
        Catch ex As Exception
        End Try
        Try
            Dim s As New ClassShopifyApi()
            dt_shop = s.get_product()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class