Public Class FormProdClosing
    Private Sub FormProdClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        '
        viewSeason()
        '
        viewVendor()
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
        view_production_order()
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

        Dim query = "SELECT 'no' AS `check`,"
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

        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProd.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVProd.RowCount - 1) - GetGroupRowCount(GVProd))
                If cek Then
                    GVProd.SetRowCellValue(i, "check", "yes")
                Else
                    GVProd.SetRowCellValue(i, "check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub BClosingFGPO_Click(sender As Object, e As EventArgs) Handles BClosingFGPO.Click
        Cursor = Cursors.WaitCursor
        GVProd.ActiveFilterString = ""
        GVProd.ActiveFilterString = "[check]='yes' "
        If GVProd.RowCount = 0 Then
            stopCustom("Please select FG PO first.")
            GVProd.ActiveFilterString = ""
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to close this FG PO?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                For i As Integer = 0 To (GVProd.RowCount - 1) - GetGroupRowCount(GVProd)
                    Dim query As String = "UPDATE tb_prod_order SET id_report_status='6' WHERE id_prod_order='" & GVProd.GetRowCellValue(i, "id_prod_order").ToString & "'"

                    execute_non_query(query, True, "", "", "", "")
                Next
                infoCustom("FG PO Closed.")
            End If
        End If

        GVProd.ActiveFilterString = ""
        view_production_order()
        Cursor = Cursors.Default
    End Sub
End Class