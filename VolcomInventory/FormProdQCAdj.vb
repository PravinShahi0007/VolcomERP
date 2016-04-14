Public Class FormProdQCAdj 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProdQCAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewAdjIn()
        viewAdjOut()
    End Sub

    Private Sub FormProdQCAdj_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProdQCAdj_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'View Data
    Sub viewAdjIn()
        Dim query As String = ""
        query += "SELECT * "
        query += "FROM tb_prod_order_qc_adj_in adj_in "
        query += "INNER JOIN tb_lookup_report_status rep_s ON rep_s.id_report_status = adj_in.id_report_status "
        query += "INNER JOIN tb_prod_order prod ON prod.id_prod_order = adj_in.id_prod_order  "
        query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design=prod.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pd_desg.id_design "
        query += "ORDER BY adj_in.id_prod_order_qc_adj_in DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjIn.DataSource = data
        check_menu()
    End Sub
    Sub viewAdjOut()
        Dim query As String = ""
        query += "SELECT * "
        query += "FROM tb_prod_order_qc_adj_out adj_out "
        query += "INNER JOIN tb_lookup_report_status rep_s ON rep_s.id_report_status = adj_out.id_report_status "
        query += "INNER JOIN tb_prod_order prod ON prod.id_prod_order = adj_out.id_prod_order  "
        query += "INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design=prod.id_prod_demand_design "
        query += "INNER JOIN tb_m_design desg ON desg.id_design=pd_desg.id_design "
        query += "ORDER BY adj_out.id_prod_order_qc_adj_out DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjOut.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCAdj.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVAdjIn.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCAdj.SelectedTabPageIndex = 1 Then
            ''based on PO
            If GVAdjOut.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        End If
    End Sub
End Class