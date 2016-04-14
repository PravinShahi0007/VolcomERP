Public Class FormSampleReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim date_now As Date

    'Form
    Private Sub FormSampleReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSampleReturn()
        viewPl()

        Dim query_date As String = "SELECT DATE(NOW()) as date_now"
        date_now = execute_query(query_date, 0, True, "", "", "", "")
    End Sub
    Private Sub FormSampleReturn_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormSampleReturn_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    'View Data
    Sub viewSampleReturn()
        Dim query As String = ""
        query += "SELECT a.id_sample_return, a.sample_return_date, a.sample_return_note,  "
        query += "a.sample_return_number, a.id_comp_contact_from, a.id_comp_contact_to,(c.comp_name) AS comp_from,  (e.comp_name) AS comp_to, f.report_status, a.id_report_status,cod_det.code_detail_name as division "
        query += "FROM tb_sample_return a "
        query += "INNER JOIN tb_pl_sample_del pl_del ON pl_del.id_pl_sample_del=a.id_pl_sample_del "
        query += "INNER JOIN tb_sample_requisition samp_req ON samp_req.id_sample_requisition=pl_del.id_sample_requisition "
        query += "LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=samp_req.id_division "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "ORDER BY a.id_sample_return DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetSample.DataSource = data
        check_menu()
    End Sub
    Sub viewPl()
        Dim query As String = "SELECT DATE(a.pl_sample_del_date) as pl_sample_del_date, DATE(DATE_ADD(a.pl_sample_del_date, INTERVAL a.pl_sample_del_duration DAY)) as pl_sample_del_real_date, "
        query += "IF(DATEDIFF(DATE(NOW()), DATE_ADD(a.pl_sample_del_date, INTERVAL a.pl_sample_del_duration DAY)) >0, CONCAT('+', DATEDIFF(DATE(NOW()), DATE_ADD(a.pl_sample_del_date, INTERVAL a.pl_sample_del_duration DAY)) ), DATEDIFF(DATE(NOW()), DATE_ADD(a.pl_sample_del_date, INTERVAL a.pl_sample_del_duration DAY)) ) AS pl_sample_del_time_remaining, "
        query += "m.departement, m.departement_code, l.employee_name, l.employee_code,i.sample_requisition_number, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, (d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,h.report_status, "
        query += " a.id_report_status, CAST(IFNULL(plx.qty_pl,0.0) AS DECIMAL(10,2)) AS qty_pl, CAST(IFNULL(retx.qty_ret,0.0) AS DECIMAL(10,2)) AS qty_ret,cod_det.code_detail_name as division "
        query += " FROM tb_pl_sample_del a "
        query += " INNER JOIN tb_sample_requisition samp_req ON samp_req.id_sample_requisition=a.id_sample_requisition "
        query += " LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=samp_req.id_division "
        query += " INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += " INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += " INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += " INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += " INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += " INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        query += " INNER JOIN tb_m_user k ON k.id_user = i.id_user "
        query += " INNER JOIN tb_m_employee l ON k.id_employee = l.id_employee "
        query += " INNER JOIN tb_m_departement m ON l.id_departement = m.id_departement "
        query += " LEFT JOIN "
        query += " ("
        query += " 	SELECT id_pl_sample_del,SUM(pl_sample_del_det_qty) AS qty_pl"
        query += "         FROM(tb_pl_sample_del_det)"
        query += " 	GROUP BY id_pl_sample_del"
        query += " ) plx ON plx.id_pl_sample_del=a.id_pl_sample_del"
        query += " LEFT JOIN "
        query += " ("
        query += " 	SELECT r.id_pl_sample_del,SUM(r_d.sample_return_det_qty) AS qty_ret"
        query += " 	FROM tb_sample_return_det r_d INNER JOIN tb_sample_return r ON r.id_sample_return=r_d.id_sample_return WHERE r.id_report_status!='5'"
        query += " 	GROUP BY r.id_pl_sample_del"
        query += " ) retx ON retx.id_pl_sample_del=a.id_pl_sample_del"
        query += " WHERE a.id_report_status='6'"
        query += " ORDER BY a.id_pl_sample_del ASC "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data

        If data.Rows.Count > 0 Then
            GVPL.ActiveFilterString = "[qty_pl] > [qty_ret]"
        End If

        viewPLDet()
        check_menu()
    End Sub

    Sub viewPLDet()
        Dim id_pl_sample_del As String = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
        Dim query As String = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCReturn.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVRetSample.RowCount < 1 Then
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
        ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
            ''based on PO
            If GVPL.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        End If
    End Sub

    Private Sub GVPL_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVPL.RowClick

    End Sub

    Private Sub GVPL_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPL.RowStyle
        If (e.RowHandle >= 0) Then
            'pick field
            'see if already marked
            Dim tgl_sekarang As Date = date_now
            If tgl_sekarang >= Date.Parse(sender.GetRowCellValue(e.RowHandle, sender.Columns("pl_sample_del_real_date"))) Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.White
            End If
        End If
        '
        'If sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_user")).ToString = id_user Then
        '    e.Appearance.Font = New Font(GVMark.Appearance.Row.Font, FontStyle.Bold)
        'End If
    End Sub

    Private Sub XTCReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturn.SelectedPageChanged
        check_menu()
        'If XTCReturn.SelectedTabPageIndex = 0 Then
        '    FormMain.BBPrint.Enabled = True
        'ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
        '    FormMain.BBPrint.Enabled = False
        'End If
    End Sub

    Private Sub GVPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        viewPLDet()
    End Sub
End Class