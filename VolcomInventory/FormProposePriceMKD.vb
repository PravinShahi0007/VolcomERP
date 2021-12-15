Public Class FormProposePriceMKD
    Public is_load_new As Boolean = False
    Private Sub FormProposePriceMKD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSummary()
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.`number`, p.created_date, p.effective_date, p.soh_sal_date, 
        p.note, p.id_report_status, rs.report_status,p.id_design_price_type, p.id_design_mkd, pt.design_price_type, p.is_confirm, p.confirm_date,
        la.employee_name, p.id_design_mkd,dm.design_mkd
        FROM tb_pp_change p 
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = p.id_report_status
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
        LEFT JOIN tb_lookup_design_mkd dm ON dm.id_design_mkd = p.id_design_mkd
        LEFT JOIN (
	        SELECT a.id_report, a.id_user, a.username, a.employee_name 
	        FROM (
		        SELECT rm.id_report, rm.id_user, u.username, e.employee_name
		        FROM tb_report_mark rm 
		        INNER JOIN tb_m_user u ON u.id_user = rm.id_user
		        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
		        WHERE (rm.report_mark_type=306) AND rm.id_report_status>1 AND rm.id_mark=2
		        ORDER BY rm.report_mark_datetime DESC
	        ) a
	        GROUP BY a.id_report
        ) la ON la.id_report = p.id_pp_change
        WHERE p.id_pp_change>0 "
        query += "ORDER BY p.id_pp_change DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProposePriceMKD_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProposePriceMKD_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewDetail()

    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged

    End Sub

    Sub loadNewDetail()
        If is_load_new Then
            is_load_new = False
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub PriceListForStoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceListForStoreToolStripMenuItem.Click
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            If GVSummary.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                FormProposePriceMKDStore.ShowDialog()
            Else
                warningCustom("Only for completed transaction")
            End If
        End If
    End Sub
End Class