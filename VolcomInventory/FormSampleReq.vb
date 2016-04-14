Public Class FormSampleReq 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Private Sub FormSampleReq_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleReq()
    End Sub
    'Activated/Deadactivated
    Private Sub FormSampleReq_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormSampleReq_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'View Data
    Sub viewSampleReq()
        'get id role super admin & role user
        Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")

        'cek in report mark 
        Dim query As String = ""
        query += "SELECT i.employee_name, j.departement, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from,  "
        query += "f.report_status, a.id_report_status,divx.code_detail_name as division, "
        query += "IFNULL(jum_req.tot_req,0.00), IFNULL(jum_pl.tot_pl,0.00) AS tot_pl, IFNULL(CAST((jum_pl.tot_pl/jum_req.tot_req)*100 AS DECIMAL(10,2)), 0.00) AS progress_req  "
        query += "FROM tb_sample_requisition a "
        query += "LEFT JOIN tb_m_code_detail divx ON divx.id_code_detail = a.id_division "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp  "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_m_user h ON a.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_m_departement j ON j.id_departement = i.id_departement "
        query += "LEFT JOIN ( "
        query += "SELECT req_det.id_sample_requisition,SUM(req_det.sample_requisition_det_qty) AS tot_req FROM tb_sample_requisition_det req_det INNER JOIN tb_sample_requisition req ON req.id_sample_requisition = req_det.id_sample_requisition WHERE req.id_report_status!='5' "
        query += "GROUP BY req_det.id_sample_requisition "
        query += ") jum_req ON jum_req.id_sample_requisition = a.id_sample_requisition "
        query += "LEFT JOIN( "
        query += "SELECT pl.id_sample_requisition, SUM(pl_det.pl_sample_del_det_qty) AS tot_pl FROM tb_pl_sample_del_det pl_det "
        query += "INNER JOIN tb_pl_sample_del pl ON pl.id_pl_sample_del = pl_det.id_pl_sample_del "
        query += "WHERE pl.id_report_status='6' "
        query += "GROUP BY pl.id_sample_requisition "
        query += ") jum_pl ON jum_pl.id_sample_requisition = a.id_sample_requisition "
        If id_role_login <> id_super_admin Then
            query += "WHERE a.id_user = '" + id_user + "' "
        End If
        query += "ORDER BY a.id_sample_requisition DESC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReq.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
        PBCProg.LookAndFeel.SkinName = "Blue"
    End Sub
    Sub isSomeonePrepared()
        Dim id_sample_requisition As String = GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
        Dim query As String = "SELECT * FROM tb_report_mark a "
        query += "INNER JOIN tb_m_user b ON a.id_user = b.id_user "
        query += "WHERE a.report_mark_type = '11' AND a.id_report = '" + id_sample_requisition + "' AND a.id_report_status = '1' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'get id role super admin
        Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")

        If data.Rows(0)("id_role").ToString <> id_super_admin Then
            bedit_active = "0"
        Else
            bedit_active = "1"
        End If
    End Sub

    Private Sub GVReq_DoubleClick(sender As Object, e As EventArgs) Handles GVReq.DoubleClick
        If GVReq.FocusedRowHandle >= 0 And GVReq.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class