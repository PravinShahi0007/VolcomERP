Public Class FormPopUpSamplePLDel
    Public id_pop_up As String
    Private Sub FormPopUpPLDel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPl()
    End Sub

    Sub viewPl()
        'Dim query As String = "SELECT m.departement, m.departement_code, l.employee_name, l.employee_code,i.sample_requisition_number, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, "
        'query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,h.report_status, a.id_report_status "
        'query += "FROM tb_pl_sample_del a "
        'query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        'query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        'query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        'query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        'query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        'query += "INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        ''query += "INNER JOIN tb_pl_sample_del_det j ON a.id_pl_sample_del = j.id_pl_sample_del "
        'query += "INNER JOIN tb_m_user k ON k.id_user = i.id_user "
        'query += "INNER JOIN tb_m_employee l ON k.id_employee = l.id_employee "
        'query += "INNER JOIN tb_m_departement m ON l.id_departement = m.id_departement "
        'query += "WHERE a.id_report_status = '3' or a.id_report_status = '4' "
        'query += "GROUP BY a.id_pl_sample_del "
        'query += "ORDER BY a.id_pl_sample_del ASC "

        Dim query As String = "SELECT m.departement, m.departement_code, l.employee_name, l.employee_code,i.sample_requisition_number, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, (d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to,h.report_status, "
        query += " a.id_report_status, CAST(IFNULL(plx.qty_pl,0.0) AS DECIMAL(10,2)) AS qty_pl, CAST(IFNULL(retx.qty_ret,0.0) AS DECIMAL(10,2)) AS qty_ret,cod_det.code_detail_name as division  "
        query += " FROM tb_pl_sample_del a "
        query += " INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += " INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += " INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += " INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += " INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += " INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        query += " LEFT JOIN tb_m_code_detail cod_det ON cod_det.id_code_detail=i.id_division "
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
    End Sub

    Sub viewPLDet()
        Dim id_pl_sample_del As String = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
        Dim query As String = "CALL view_pl_sample_del_limit('" + id_pl_sample_del + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
    End Sub

    Private Sub GVPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        viewPLDet()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpPLDel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If id_pop_up = "1" Then
            Cursor = Cursors.WaitCursor
            FormSampleReturnSingle.id_pl_sample_del = GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
            FormSampleReturnSingle.id_comp_contact_from = GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
            FormSampleReturnSingle.TxtCodeUserFrom.Text = GVPL.GetFocusedRowCellValue("employee_code").ToString
            FormSampleReturnSingle.TxtNameUserFrom.Text = GVPL.GetFocusedRowCellValue("employee_name").ToString
            FormSampleReturnSingle.TxtCodeDeptFrom.Text = GVPL.GetFocusedRowCellValue("departement_code").ToString
            FormSampleReturnSingle.TxtNameDeptFrom.Text = GVPL.GetFocusedRowCellValue("departement").ToString
            FormSampleReturnSingle.TxtCodeCompFrom.Text = GVPL.GetFocusedRowCellValue("comp_code_to").ToString
            FormSampleReturnSingle.TxtNameCompFrom.Text = GVPL.GetFocusedRowCellValue("comp_name_to").ToString
            FormSampleReturnSingle.TxtPLSampleDelNumber.Text = GVPL.GetFocusedRowCellValue("pl_sample_del_number").ToString
            FormSampleReturnSingle.TEDivision.Text = GVPL.GetFocusedRowCellValue("division").ToString
            FormSampleReturnSingle.BtnInfoPL.Enabled = True
            FormSampleReturnSingle.viewDetailReturn()
            FormSampleReturnSingle.GroupControlRet.Enabled = True
            FormSampleReturnSingle.viewDetailBC()
            FormSampleReturnSingle.allowDelete()
            FormSampleReturnSingle.GroupControlScannedItem.Enabled = True
            Cursor = Cursors.Default
            Close()
        End If
    End Sub
End Class