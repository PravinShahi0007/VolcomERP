Public Class FormMatMRS
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatMRS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_mrs()
        view_mrs_wo()
    End Sub

    Sub view_mrs()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to,a.mrs_type, "
        query += "a.prod_order_mrs_date "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE ISNULL(a.id_prod_order) AND mrs_type='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRS.DataSource = data

        show_but_mrs()
    End Sub
    Sub view_mrs_wo()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to,a.mrs_type, "
        query += "a.prod_order_mrs_date "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE ISNULL(a.id_prod_order) AND mrs_type='2'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRSWO.DataSource = data

        show_but_mrs()
    End Sub
    Sub show_but_mrs()
        If XTCMRS.SelectedTabPageIndex = 0 Then 'wo mat
            If GVMRSWO.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        ElseIf XTCMRS.SelectedTabPageIndex = 1 Then 'other
            If GVMRS.RowCount > 0 Then
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

    Private Sub FormMatMRS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        show_but_mrs()
    End Sub

    Private Sub FormMatMRS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMatMRS_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub XTCMRS_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMRS.SelectedPageChanged
        show_but_mrs()
    End Sub
End Class