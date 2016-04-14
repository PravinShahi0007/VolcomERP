Public Class FormProductionWOList
    Private Sub FormProductionWOList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        viewSeason()
        viewVendor()
        '

    End Sub
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

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_work_order()
        GVProdWO.ExpandAllGroups()
    End Sub

    Sub view_work_order()
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
        query += " wo.id_prod_order_wo,wo.prod_order_wo_number,comp.comp_name,ovh.overhead,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name, d.design_code, h.term_production, g.po_type"
        query += " ,wo.prod_order_wo_date, wo.id_report_status,c.report_status, b.id_design,b.id_delivery, e.delivery, f.season, e.id_season , wo.prod_order_wo_progress"
        query += " ,SUM(wod.prod_order_wo_det_qty) AS qty, SUM(wod.prod_order_wo_det_qty * prod_order_wo_det_price) AS amount"
        query += " FROM tb_prod_order_wo wo"
        query += " LEFT JOIN tb_prod_order a On wo.id_prod_order=a.id_prod_order"
        query += " LEFT JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo"
        query += " INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design"
        query += " INNER JOIN tb_lookup_report_status c On wo.id_report_status = c.id_report_status"
        query += " INNER JOIN tb_m_design d ON b.id_design = d.id_design"
        query += " INNER JOIN tb_season_delivery e On b.id_delivery=e.id_delivery"
        query += " INNER JOIN tb_season f ON f.id_season=e.id_season"
        query += " INNER JOIN tb_lookup_po_type g On g.id_po_type=a.id_po_type"
        query += " INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production"
        query += " LEFT JOIN tb_m_ovh_price ovh_p On ovh_p.id_ovh_price=wo.id_ovh_price"
        query += " LEFT JOIN tb_m_ovh ovh ON ovh.id_ovh=ovh_p.id_ovh"
        query += " LEFT JOIN tb_m_comp_contact cc On cc.id_comp_contact=ovh_p.id_comp_contact"
        query += " LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp"
        query += " WHERE 1=1 " & query_where
        query += " GROUP BY wod.id_prod_order_wo"
        query += " ORDER BY id_prod_order ASC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'data.Columns.Add("images", GetType(Image))
        'For i As Integer = 0 To data.Rows.Count - 1
        '    Dim img As Image
        '    Dim fileName As String = ""
        '    If System.IO.File.Exists(product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower) Then
        '        fileName = product_image_path & data.Rows(i)("id_design").ToString & ".jpg".ToLower
        '    Else
        '        fileName = product_image_path & "default" & ".jpg".ToLower
        '    End If

        '    img = Image.FromFile(fileName)

        '    data.Rows(i)("images") = img
        'Next
        '

        GCProdWO.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdWO.FocusedRowHandle = 0
            GVProdWO.BestFitColumns()
        End If
        'check_but()
    End Sub
    Private Sub FormProductionWOList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub
    Private Sub FormProductionWOList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Private Sub GVProdWO_DoubleClick(sender As Object, e As EventArgs) Handles GVProdWO.DoubleClick
        If GVProdWO.FocusedRowHandle >= 0 And GVProdWO.RowCount > 0 Then
            FormProductionDet.id_prod_order = GVProdWO.GetFocusedRowCellValue("id_prod_order").ToString
            FormProductionDet.is_wo_view = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
            FormProductionDet.ShowDialog()
        End If
    End Sub
    Private Sub GVProdWO_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProdWO.ColumnFilterChanged
        GVProdWO.ExpandAllGroups()
    End Sub
End Class