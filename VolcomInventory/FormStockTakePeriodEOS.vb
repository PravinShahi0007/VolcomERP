Public Class FormStockTakePeriodEOS
    Private Sub FormStockTakePeriodEOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.`number`, p.created_date, p.effective_date, p.soh_sal_date, 
        p.note, p.id_report_status, rs.report_status,p.id_design_price_type, p.id_design_mkd, pt.design_price_type, p.is_confirm, p.confirm_date,
        la.employee_name
        FROM tb_pp_change p 
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = p.id_report_status
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type
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
        WHERE p.id_pp_change>0 AND p.id_report_status = 6 "
        query += "ORDER BY p.id_pp_change DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        Cursor = Cursors.WaitCursor

        Dim dataSource As DataTable = FormStockTakePeriodSOH.GCSOH.DataSource

        Dim query As String = "SELECT id_product FROM tb_m_product WHERE id_design IN (SELECT id_design FROM tb_pp_change_det WHERE id_pp_change = " + GVSummary.GetFocusedRowCellValue("id_pp_change").ToString + " AND propose_price_final > 0 AND propose_price_final IS NOT NULL)"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To dataSource.Rows.Count - 1
            dataSource.Rows(i)("is_select") = "no"

            For j = 0 To data.Rows.Count - 1
                If dataSource.Rows(i)("id_product").ToString = data.Rows(j)("id_product").ToString Then
                    dataSource.Rows(i)("is_select") = "yes"

                    Exit For
                End If
            Next
        Next

        FormStockTakePeriodSOH.GCSOH.DataSource = dataSource

        FormStockTakePeriodSOH.CheckEdit1.Enabled = False
        FormStockTakePeriodSOH.GVSOH.OptionsBehavior.Editable = False

        Cursor = Cursors.Default

        Close()
    End Sub

    Private Sub FormStockTakePeriodEOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class