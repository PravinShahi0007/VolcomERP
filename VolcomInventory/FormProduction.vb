Public Class FormProduction
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Images As Hashtable = New Hashtable()
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"
    '
    Dim id_season As String = "0"
    Dim id_vendor As String = "-1"
    Dim id_design As String = "0"

    Private Sub FormProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDesign()
        viewSeason()
        viewVendor()

        viewProdDemand()
        checkFormAccess(Name)
    End Sub
    'view season
    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub
    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub
    Sub viewDesign()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignStockStore.Properties.DataSource = Nothing
        SLEDesignStockStore.Properties.DataSource = data
        SLEDesignStockStore.Properties.DisplayMember = "display_name"
        SLEDesignStockStore.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockStore.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockStore.EditValue = Nothing
        End If
    End Sub
    Private Sub FormProduction_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProduction_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
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
    End Sub
    Sub view_production_order()
        Dim query_where As String = ""

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND b.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT "
        query += "IFNULL(SUM(rec.prod_order_rec_det_qty),0) AS qty_rec, "
        query += "IFNULL(SUM(pod.prod_order_qty),0) As qty_order, "
        query += "comp.comp_name,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type,d.design_cop, "
        query += "a.prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_order_det pod ON pod.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b On a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d On b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e On b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f On f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g On g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h On h.id_term_production=a.id_term_production "
        query += "LEFT JOIN tb_prod_order_wo wo On wo.id_prod_order=a.id_prod_order And wo.is_main_vendor='1' "
        query += "LEFT JOIN tb_m_ovh_price ovh_p On ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact "
        query += "LEFT JOIN tb_m_comp comp On comp.id_comp=cc.id_comp "
        query += "LEFT JOIN  "
        query += "( "
        query += "SELECT recd.id_prod_order_det,SUM(recd.prod_order_rec_det_qty) AS prod_order_rec_det_qty "
        query += "FROM "
        query += "tb_prod_order_rec rec "
        query += "LEFT JOIN tb_prod_order_rec_det recd On recd.id_prod_order_rec=rec.id_prod_order_rec "
        query += "GROUP BY recd.id_prod_order_det "
        query += ") rec On rec.id_prod_order_det=pod.id_prod_order_det "
        query += "WHERE 1=1 " & query_where
        query += "GROUP BY a.id_prod_order"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'data.Columns.Add("images", GetType(Image))
        'For i As Integer = 0 To data.Rows.Count - 1
        '    Dim img As Image
        '    Dim fileName As String = ""
        '    If System.IO.File.Exists(product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower) Then
        '        fileName = product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower
        '    Else
        '        fileName = product_image_path & "Default" & ".jpg".ToLower
        '    End If

        '    img = Image.FromFile(fileName)

        '    data.Rows(i)("images") = img
        'Next
        '
        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
        check_but()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub

    '=== prod demand ====
    'View Production Demand
    Sub viewProdDemand()
        Dim query As String = "CALL view_design_demand_all(0)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        If data.Rows.Count > 0 Then
            GVDesign.FocusedRowHandle = 0
            view_prod_demand_product()
        End If
        check_but()
    End Sub
    Sub view_prod_demand_product()
        Dim query As String = "CALL view_prod_demand_product('" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
    End Sub

    Private Sub XTCTabProduction_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabProduction.SelectedPageChanged
        check_but()
    End Sub
    Sub check_but()
        If XTCTabProduction.SelectedTabPageIndex = 0 Then
            If GVProd.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCTabProduction.SelectedTabPageIndex = 1 Then
            If GVDesign.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVDesign_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDesign.RowClick
        view_prod_demand_product()
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
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
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_production_order()
    End Sub
End Class