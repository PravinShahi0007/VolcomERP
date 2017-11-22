Public Class FormProdPRWO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormProdPRWO_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProdPRWO_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormProdPRWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDesign()
        viewSeason()
        viewVendor()

        'view_pr()
        'view_wo()
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
    Sub view_pr()
        Dim query_where As String = " WHERE ISNULL(z.id_prod_order) "

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND desg.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND d.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT desg.design_code,desg.design_display_name,po.id_prod_order,po.prod_order_number,rec.id_prod_order_rec,l.overhead, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,rec.delivery_order_date,rec.delivery_order_number,wo.prod_order_wo_number,rec.prod_order_rec_date, d.comp_name AS comp_to, "
        query += "z.pr_prod_order_due_date,maxd.employee_name as last_mark "
        query += " ,wo.id_currency,wo.prod_order_wo_kurs "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo = z.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order = wo.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design "
        query += "INNER JOIN tb_season_delivery e On desg.id_delivery=e.id_delivery "
        query += "LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec "
        query += "INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "INNER JOIN tb_m_ovh l ON ovh_p.id_ovh = l.id_ovh "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='50'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='50'
                  ) maxd ON maxd.id_report = z.id_pr_prod_order "
        query += query_where & " "
        query += "ORDER BY z.id_pr_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPR.DataSource = data
        GVMatPR.BestFitColumns()

        check_but()
    End Sub
    Sub view_pr_courier()
        Dim query_where As String = " WHERE NOT ISNULL(z.id_prod_order) "

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND desg.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND e.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND d.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT desg.design_code,desg.design_display_name,po.id_prod_order,po.prod_order_number,rec.id_prod_order_rec, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,rec.delivery_order_date,rec.delivery_order_number,rec.prod_order_rec_date, d.comp_name AS comp_to, "
        query += "z.pr_prod_order_due_date,maxd.employee_name as last_mark "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order = z.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design "
        query += "INNER JOIN tb_season_delivery e On desg.id_delivery=e.id_delivery "
        query += "LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='50'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='50'
                  ) maxd ON maxd.id_report = z.id_pr_prod_order "
        query += query_where & " "
        query += "ORDER BY z.id_pr_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPRPO.DataSource = data
        GVPRPO.BestFitColumns()

        check_but()
    End Sub
    Sub view_pr_no_reff()
        Dim query_where As String = " WHERE (ISNULL(z.id_prod_order) AND ISNULL(z.id_prod_order_wo)) "

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND d.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date, d.comp_name AS comp_to, "
        query += "z.pr_prod_order_due_date,maxd.employee_name as last_mark "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "LEFT JOIN
                 (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
                    FROM tb_report_mark mark
                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
                    INNER JOIN 
                    (
	                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                    FROM tb_report_mark mark
	                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='50'
	                    GROUP BY report_mark_type,id_report
                    ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
                    WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='50'
                  ) maxd ON maxd.id_report = z.id_pr_prod_order "
        query += query_where & " "
        query += "ORDER BY z.id_pr_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPRNoReff.DataSource = data
        GVPRNoReff.BestFitColumns()

        check_but()
    End Sub
    Sub check_but()
        If XTCTabPR.SelectedTabPageIndex = 0 Then 'list pr
            If GVMatPR.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCTabPR.SelectedTabPageIndex = 1 Then 'list po
            If GVProdWO.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCTabPR.SelectedTabPageIndex = 2 Then 'list pr courier
            If GVPRPO.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCTabPR.SelectedTabPageIndex = 3 Then 'list pr no reff
            If GVPRNoReff.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub GVMatPR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPR.FocusedRowChanged
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
    Sub view_wo()
        Dim query_where As String = " "

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            query_where += " AND desg.id_design='" & SLEDesignStockStore.EditValue.ToString & "'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND del.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND d.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query = "SELECT desg.design_display_name,desg.design_code,po.prod_order_number,a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_prod_order "
        query += ",(SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = a.id_prod_order_wo) as progress,"
        query += "g.payment,COUNT(pr.id_pr_prod_order) AS qty_pr, "
        query += "b.id_comp_contact,d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_date AS prod_order_wo_date, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL a.prod_order_wo_lead_time DAY) AS prod_order_wo_lead_time, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_topx, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_top "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order=a.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design "
        query += "INNER JOIN tb_season_delivery del On desg.id_delivery=del.id_delivery "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "INNER JOIN tb_pr_prod_order pr ON pr.id_prod_order_wo=a.id_prod_order_wo "
        query += "WHERE (a.id_report_status='3' OR a.id_report_status='4' OR a.id_report_status='6') " & query_where
        query += "GROUP BY pr.id_prod_order_wo "

        GridColumnPONumber.Visible = True

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdWO.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdWO.BestFitColumns()
            GVProdWO.FocusedRowHandle = 0
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
        End If
    End Sub
    Sub view_wo(ByVal id_prod_wo As String)
        Dim query = "CALL view_prod_order_wo_det('" & id_prod_wo & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProdWO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdWO.FocusedRowChanged
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
        If GVProdWO.RowCount > 0 Then
            view_wo(GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString)
        End If
    End Sub

    Private Sub XTCTabPR_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabPR.SelectedPageChanged
        check_but()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        If XTCTabPR.SelectedTabPageIndex = 0 Then
            view_pr()
        ElseIf XTCTabPR.SelectedTabPageIndex = 1 Then
            view_wo()
        ElseIf XTCTabPR.SelectedTabPageIndex = 2 Then
            view_pr_courier()
        ElseIf XTCTabPR.SelectedTabPageIndex = 3 Then
            view_pr_no_reff()
        End If
    End Sub
End Class