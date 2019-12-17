Public Class FormInvMat
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormInvoiceMat_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormInvoiceMat_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bedit_active = "1"
        bdel_active = "1"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormInvMat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub print_list()

    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        Dim q_where As String = ""

        If Not SLEVendorPayment.EditValue.ToString = "0" Then
            q_where = " AND c.id_comp='" & SLEVendorPayment.EditValue.ToString & "' "
        End If

        If XTCMatInv.SelectedTabPageIndex = 0 Then
            'list invoice

        ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
            'pl mrs
            Dim query As String = "SELECT 'no' AS is_check,c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar`,pl.`id_pl_mrs`,pl.`pl_mrs_number`,SUM(pld.`pl_mrs_det_price`*pld.`pl_mrs_det_qty`) AS amount,mrs.`id_prod_order`,po.`prod_order_number`
,dsg.`design_display_name`
FROM tb_pl_mrs_det pld
INNER JOIN tb_pl_mrs pl ON pl.`id_pl_mrs`=pld.`id_pl_mrs`
INNER JOIN `tb_prod_order_mrs` mrs ON mrs.`id_prod_order_mrs`=pl.`id_prod_order_mrs`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=mrs.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & q_where & "
GROUP BY pl.`id_pl_mrs`"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPL.DataSource = data
            GVPL.BestFitColumns()
        ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
            'retur
            Dim query As String = "SELECT 'no' AS is_check,c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar`,ret.`id_mat_prod_ret_in`,ret.`mat_prod_ret_in_number`,SUM(retd.`mat_prod_ret_in_det_price`*retd.`mat_prod_ret_in_det_qty`) AS amount,po.`id_prod_order`,po.`prod_order_number`
,dsg.`design_display_name`
FROM `tb_mat_prod_ret_in_det` retd
INNER JOIN tb_mat_prod_ret_in ret ON ret.`id_mat_prod_ret_in`=retd.`id_mat_prod_ret_in`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=ret.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ret.`id_comp_contact_from` AND ret.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` " & q_where & "
GROUP BY ret.`id_mat_prod_ret_in`"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRetur.DataSource = data
            GVRetur.BestFitColumns()
        End If
    End Sub

    Sub check_but()
        If XTCMatInv.SelectedTabPageIndex = 0 Then

        ElseIf XTCMatInv.SelectedTabPageIndex = 1 Then
            'pl mrs
            If SLEVendorPayment.EditValue.ToString = "0" Then
                BCreateBPB.Visible = False
            Else
                BCreateBPB.Visible = False
            End If
        ElseIf XTCMatInv.SelectedTabPageIndex = 2 Then
            'retur
            If SLEVendorPayment.EditValue.ToString = "0" Then
                BCreateBRP.Visible = False
            Else
                BCreateBRP.Visible = False
            End If
        End If
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All' as comp_number,'All' as comp_name,'0' AS id_comp,'0' AS id_acc_ar
                                UNION
                                SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar` FROM tb_pl_mrs pl
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
GROUP BY c.`id_comp`"
        viewSearchLookupQuery(SLEVendorPayment, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormInvMat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCreateBPB_Click(sender As Object, e As EventArgs) Handles BCreateBPB.Click
        FormInvMatDet.id_inv = "-1"
        FormInvMatDet.ShowDialog()
    End Sub

    Private Sub BCreateBRP_Click(sender As Object, e As EventArgs) Handles BCreateBRP.Click
        FormInvMatDet.id_inv = "-1"
        FormInvMatDet.ShowDialog()
    End Sub
End Class