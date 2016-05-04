Public Class FormMatInvoice
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewInv()
        viewPL()
        view_retur()
        viewInv_retur()
        check_but()
    End Sub

    Sub viewPL()
        Dim query As String = "SELECT a.id_pl_mrs ,m.design_name,k.prod_order_number,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,j.prod_order_wo_number,i.prod_order_mrs_number, "
        query += "a.pl_mrs_date AS pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "INNER JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_order_wo j ON i.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE NOT ISNULL(i.id_prod_order) AND (a.id_report_status='3' OR a.id_report_status='4')"
        query += "ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPL.DataSource = data
    End Sub

    Private Sub FormMatInvoice_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMatInvoice_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMatInvoice_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewInv()
        Dim query As String = "SELECT inv.id_inv_pl_mrs,inv.inv_pl_mrs_number,m.design_name,k.prod_order_number,j.prod_order_wo_number, inv.id_comp_contact_to, "
        query += " (f.comp_name) AS comp_name_to, h.report_status, inv.id_report_status,inv.id_prod_order_wo, "
        query += "inv.inv_pl_mrs_date AS inv_pl_mrs_date,"
        query += "DATE_ADD(inv.inv_pl_mrs_date,INTERVAL inv.inv_pl_mrs_top DAY) AS inv_pl_mrs_top , inv.id_report_status "
        query += "FROM tb_inv_pl_mrs inv "
        query += "INNER JOIN tb_m_comp_contact e ON inv.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "ORDER BY inv.id_inv_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdInvoice.DataSource = data
    End Sub

    Sub check_but()
        If XTCTabGeneral.SelectedTabPageIndex = 0 Then
            If XTCTabProduction.SelectedTabPageIndex = 0 Then 'invoice
                If GVProdInvoice.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            Else 'PL
                If GVProdPL.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
        Else
            If XTCRetur.SelectedTabPageIndex = 0 Then 'retur invoice
                If GVRetur.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            Else 'inv
                If GVInvoice.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub XTCTabProduction_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabProduction.SelectedPageChanged
        check_but()
    End Sub
    'invoice retur
    Sub view_retur()
        Dim query As String = "SELECT inv_ret.id_inv_pl_mrs_ret,inv_ret.inv_pl_mrs_ret_number,inv.id_inv_pl_mrs,inv.inv_pl_mrs_number,m.design_name,k.prod_order_number,j.prod_order_wo_number, inv_ret.id_comp_contact_from, "
        query += " (f.comp_name) AS comp_name_to, h.report_status, inv_ret.id_report_status,inv.id_prod_order_wo, "
        query += "inv_ret.inv_pl_mrs_ret_date AS inv_pl_mrs_ret_date,"
        query += "DATE_ADD(inv_ret.inv_pl_mrs_ret_date,INTERVAL inv_ret.inv_pl_mrs_ret_top DAY) AS inv_pl_mrs_ret_top , inv_ret.id_report_status "
        query += "FROM tb_inv_pl_mrs_ret inv_ret "
        query += "INNER JOIN tb_inv_pl_mrs inv ON inv.id_inv_pl_mrs=inv_ret.id_inv_pl_mrs "
        query += "INNER JOIN tb_m_comp_contact e ON inv_ret.id_comp_contact_from = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv_ret.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "ORDER BY inv_ret.id_inv_pl_mrs_ret DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetur.DataSource = data
    End Sub
    Sub viewInv_retur()
        Dim query As String = "SELECT inv.id_inv_pl_mrs,inv.inv_pl_mrs_number,m.design_name,k.prod_order_number, inv.id_comp_contact_to, "
        query += " (f.comp_name) AS comp_name_to, h.report_status, inv.id_report_status,j.prod_order_wo_number,inv.id_prod_order_wo, "
        query += "inv.inv_pl_mrs_date AS inv_pl_mrs_date,"
        query += "DATE_ADD(inv.inv_pl_mrs_date,INTERVAL inv.inv_pl_mrs_top DAY) AS inv_pl_mrs_top , inv.id_report_status "
        query += "FROM tb_inv_pl_mrs inv "
        query += "INNER JOIN tb_m_comp_contact e ON inv.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE (inv.id_report_status='3' OR inv.id_report_status='4' OR inv.id_report_status='6') "
        query += "ORDER BY inv.id_inv_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoice.DataSource = data
    End Sub

    Private Sub XTCTabGeneral_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabGeneral.SelectedPageChanged
        check_but()
    End Sub

    Private Sub XTCRetur_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRetur.SelectedPageChanged
        check_but()
    End Sub

End Class