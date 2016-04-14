Public Class FormFGDSSONew 
    Public id_season_par As String = "-1"
    Public id_comp_par As String = "-1"
    Public id_comp_contact_par As String = "-1"

    Private Sub FormFGDSSONew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        viewDel()
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        If id_season_par <> "-1" Then
            query += "WHERE a.id_season = '" + id_season_par + "' "
        End If
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewDel()
        Dim id_season As String = "-1"
        Try
            id_season = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT del.id_delivery, del.delivery FROM tb_season_delivery del WHERE del.id_season = '" + id_season + "' ORDER BY del.delivery ASC "
        viewSearchLookupQuery(SLEDel, query, "id_delivery", "delivery", "id_delivery")
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        viewDel()
    End Sub


    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGDSSONew_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "59"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        If id_comp_contact_par = "-1" Then
            stopCustom("Data can't blank!")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                'get product
                Dim ix As Integer = 0
                Dim id_product_sel As String = ""
                For j As Integer = 0 To ((FormFGDistScheme.GVDS.RowCount - 1) - GetGroupRowCount(FormFGDistScheme.GVDS)) 'looping product
                    Dim cek As String = FormFGDistScheme.GVDS.GetRowCellValue(j, "SELECT").ToString
                    If cek = "Yes" Then
                        Dim id_product As String = FormFGDistScheme.GVDS.GetRowCellValue(j, "id_product").ToString
                        If ix > 0 Then
                            id_product_sel += "OR "
                        End If
                        id_product_sel += "ds.id_product = '" + id_product + "' "
                        ix += 1
                    End If
                Next

                'looping based on store
                Dim sales_order_reff As String = ""
                Dim data_fg_store As DataTable = FormFGDistScheme.GCDS.DataSource
                Dim cond_success As Boolean = False
                Dim str_err As String = ""
                Dim nx As Integer = 0
                Dim min_so As Integer = 0 'utk melihat minimal SO
                For i As Integer = 0 To data_fg_store.Columns.Count - 1 'looping account
                    Dim col As String = data_fg_store.Columns(i).ToString
                    If col.Contains("#id#") Then
                        nx += 1
                        Dim col_foc_arr As String() = Split(col, "#id#")
                        Try
                            Dim id_sales_order As String = "0"
                            Dim id_delivery As String = SLEDel.EditValue.ToString
                            Dim id_store_to As String = col_foc_arr(1)
                            Dim id_store_contact_to As String = get_company_x(id_store_to, "6")
                            Dim id_warehouse_contact_to As String = id_comp_contact_par
                            Dim id_so_type As String = col_foc_arr(3)


                            'cek harus dibuat so atau tidak
                            Dim query_cek_so As String = ""
                            query_cek_so += "SELECT SUM(ds.fg_ds_qty) AS `tot_ds` FROM tb_fg_ds ds "
                            query_cek_so += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                            query_cek_so += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                            query_cek_so += "WHERE ds.id_ds_type='" + FormFGDistScheme.SLEType.EditValue.ToString + "' AND ds_store.id_season='" + FormFGDistScheme.SLESeason.EditValue.ToString + "' "
                            query_cek_so += "AND ( "
                            query_cek_so += id_product_sel + " "
                            query_cek_so += ") "
                            query_cek_so += "AND comp.id_comp = '" + id_store_to + "' "
                            Dim tot_ds As String = execute_query(query_cek_so, 0, True, "", "", "", "")

                            'create so
                            If tot_ds > "0" Then
                                'minimal SO
                                min_so += 1
                                If min_so = 1 Then
                                    sales_order_reff = header_number_sales("21")
                                    increase_inc_sales("21")
                                End If

                                'insert SO by store
                                Dim sales_order_number As String = header_number_sales("2")
                                Dim query_so As String = "INSERT INTO tb_sales_order(id_delivery, id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_so_status, sales_order_reff, id_report_status) "
                                query_so += "VALUES ('" + id_delivery + "', '" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '" + sales_order_number + "', now(), '', '" + id_so_type + "', '1', '" + sales_order_reff + "', '1'); SELECT LAST_INSERT_ID(); "
                                Dim id_sales_order_new As String = execute_query(query_so, 0, True, "", "", "", "")

                                'increment sales ord number
                                increase_inc_sales("2")

                                'insert who prepared
                                insert_who_prepared("39", id_sales_order_new, id_user)

                                'insert detail
                                Dim query_det As String = ""
                                query_det += "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty) "
                                query_det += "SELECT ('" + id_sales_order_new + "'),ds.id_product, prc.id_design_price, prc.design_price, ds.fg_ds_qty "
                                query_det += "FROM tb_fg_ds ds "
                                query_det += "INNER JOIN tb_fg_ds_store ds_store ON ds.id_fg_ds_store = ds_store.id_fg_ds_store "
                                query_det += "INNER JOIN tb_m_comp comp ON comp.id_comp = ds_store.id_comp "
                                query_det += "INNER JOIN tb_lookup_pd_alloc pd_alloc ON pd_alloc.id_pd_alloc = comp.id_pd_alloc "
                                query_det += "INNER JOIN tb_m_product prod ON prod.id_product = ds.id_product "
                                query_det += "LEFT JOIN ( "
                                query_det += "SELECT * FROM ( "
                                query_det += "SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price "
                                query_det += "FROM tb_m_design_price price "
                                query_det += "INNER JOIN tb_lookup_design_price_type price_type "
                                query_det += "ON price.id_design_price_type = price_type.id_design_price_type "
                                query_det += "INNER JOIN tb_lookup_currency curr ON curr.id_currency = price.id_currency "
                                query_det += "INNER JOIN tb_m_user `user` ON user.id_user = price.id_user "
                                query_det += "INNER JOIN tb_m_employee emp ON emp.id_employee = user.id_employee "
                                query_det += "WHERE price.is_active_wh='1' AND price.design_price_start_date <= NOW() "
                                query_det += "ORDER BY price.design_price_start_date DESC ) a "
                                query_det += "GROUP BY a.id_design "
                                query_det += ") prc ON prc.id_design = prod.id_design "
                                query_det += "WHERE ds.id_ds_type = '" + FormFGDistScheme.SLEType.EditValue.ToString + "' AND ds_store.id_season = '" + FormFGDistScheme.SLESeason.EditValue.ToString + "' "
                                query_det += "AND ( "
                                query_det += id_product_sel + " "
                                query_det += ") "
                                query_det += "AND ds.fg_ds_qty >0 "
                                query_det += "AND comp.id_comp = '" + id_store_to + "' "
                                query_det += "ORDER BY ds.id_product ASC "
                                execute_non_query(query_det, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                            str_err += "- " + col_foc_arr(0).ToString + System.Environment.NewLine
                        End Try

                        'colom statis = 14
                        progres_bar_update(nx, data_fg_store.Columns.Count - 14)
                    End If
                Next
                If str_err = "" Then
                    infoCustom("Prepare order with Tracker Number : '" + sales_order_reff + "' was created succesfully.")
                Else
                    stopCustom("There are some problem with this process. These account are not successfully to create prepare order : " + System.Environment.NewLine + str_err + System.Environment.NewLine + "Please try again later !")
                End If
                FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class