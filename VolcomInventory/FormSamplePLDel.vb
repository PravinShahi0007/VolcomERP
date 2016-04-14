Public Class FormSamplePLDel
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    'Form Load
    Private Sub FormPLDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPL()
        viewSampleReq()
    End Sub
    'Activated/DeadActivated
    Private Sub FormPLDel_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormPLDel_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'View Data
    'View Packing List
    Sub viewPL()
        'get id role super admin & role user
        Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")

        Dim query As String = "SELECT i.sample_requisition_number, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,cod_det.code_detail_name as division "
        query += "FROM tb_pl_sample_del a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=i.id_division "
        'query += "INNER JOIN tb_pl_sample_del_det j ON a.id_pl_sample_del = j.id_pl_sample_del "
        query += "GROUP BY a.id_pl_sample_del "
        query += "ORDER BY a.id_pl_sample_del DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
        check_menu()
    End Sub
    Sub viewSampleReq()
        'get id role super admin & role user
        Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")
        Dim query As String = ""
        query += "SELECT a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from, (c.id_comp) AS id_comp_to, "
        query += "f.report_status, a.id_report_status, IFNULL(jum_pl.tot_pl , 0) AS tot_pl,dvx.code_detail_name as division "
        query += "FROM tb_sample_requisition a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp  "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_sample_requisition_det g ON g.id_sample_requisition = a.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail dvx ON dvx.id_code_detail = a.id_division "
        query += "LEFT JOIN ( "
        query += "SELECT a.id_sample_requisition ,COUNT(a.id_pl_sample_del) AS tot_pl FROM tb_pl_sample_del a WHERE a.id_report_status!='5' GROUP BY a.id_sample_requisition "
        query += ") jum_pl ON jum_pl.id_sample_requisition = a.id_sample_requisition "
        query += "WHERE a.id_report_status = '6' "
        query += "GROUP BY a.id_sample_requisition ORDER BY a.id_sample_requisition ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReq.DataSource = data
        GVReq.ActiveFilterString = "[tot_pl]=0"
        viewDetailReq()
        check_menu()
    End Sub
    Sub viewDetailReq()
        'get id role super admin & role user
        Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")
        Dim id_comp_param As String = ""
        If id_role_login <> id_super_admin Then
            id_comp_param = id_comp_user
        Else
            id_comp_param = "0"
        End If
        Dim id_sample_requisition As String = "-1"
        Try
            id_sample_requisition = GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "CALL view_sample_req_det_limit('" + id_sample_requisition + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
        viewPLSrs()
    End Sub
    Sub viewPLSrs()
        Dim id_srs_det As String = GVRetDetail.GetFocusedRowCellValue("id_sample_requisition_det")
        Dim query As String = "CALL view_pl_sample_del_srs('" + id_srs_det + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCreatedPLDetail.DataSource = data
    End Sub
    Private Sub GVPL_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPL.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVPL_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVPL.RowClick
        noManipulating()
    End Sub

    Private Sub GVPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVPL.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub

    Sub check_menu()
        If XTCPL.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVPL.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        ElseIf XTCPL.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVReq.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub
    Private Sub GVReq_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVReq.RowClick

    End Sub

    Private Sub XTCPL_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPL.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVReq_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVReq.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        viewPLSrs()
    End Sub

    Private Sub GVReq_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVReq.FocusedRowChanged
        viewDetailReq()
    End Sub
End Class