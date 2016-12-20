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
        view_pr()
        view_wo()
        check_but()
    End Sub

    Sub view_pr()
        Dim query As String = "SELECT desg.design_code,desg.design_display_name,po.id_prod_order,po.prod_order_number,rec.id_prod_order_rec,l.overhead, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,rec.delivery_order_date,rec.delivery_order_number,wo.prod_order_wo_number,rec.prod_order_rec_date, d.comp_name AS comp_to, "
        query += "z.pr_prod_order_due_date "
        query += " ,wo.id_currency,wo.prod_order_wo_kurs "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo = z.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order = wo.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pdd.id_design "
        query += "LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec "
        query += "INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "INNER JOIN tb_m_ovh l ON ovh_p.id_ovh = l.id_ovh "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "ORDER BY z.id_pr_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPR.DataSource = data
        GVMatPR.BestFitColumns()
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
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "INNER JOIN tb_pr_prod_order pr ON pr.id_prod_order_wo=a.id_prod_order_wo "
        query += "WHERE a.id_report_status='3' OR a.id_report_status='4' OR a.id_report_status='6' "
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
End Class