Public Class FormSalesOrderReport
    Private Sub FormSalesOrderReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim now As DateTime = getTimeDB()
        DEFrom.EditValue = now
        DEUntil.EditValue = now
    End Sub

    Private Sub FormSalesOrderReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderReport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesOrderReport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewNewOrder()
    End Sub

    Sub viewNewOrder()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT sog.id_sales_order_gen, sog.id_so_status, sog.sales_order_gen_reff, sog.sales_order_gen_date, sog.sales_order_gen_note, sog.id_report_status, 
        sog.id_user, e.id_employee, e.employee_name,
        SUM(sod.sales_order_det_qty) AS `total_order`, IFNULL(sc.total_trs,0) AS `total_scan`, IFNULL(comp.total_trs,0) AS `total_completed`
        FROM tb_sales_order_gen sog
        INNER JOIN tb_m_user u ON u.id_user = sog.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_sales_order so ON so.id_sales_order_gen = sog.id_sales_order_gen 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN (
	        SELECT trs.id_sales_order_gen, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order_gen, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
		        WHERE del.id_report_status!=5 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND del.pl_sales_order_del_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order_gen, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        WHERE del.id_report_status!=5 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND del.fg_trf_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order_gen
        ) sc ON sc.id_sales_order_gen = sog.id_sales_order_gen
        LEFT JOIN (
	        SELECT trs.id_sales_order_gen, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order_gen, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
		        WHERE del.id_report_status=6 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND del.pl_sales_order_del_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order_gen, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        WHERE del.id_report_status=6 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND del.fg_trf_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order_gen
        ) comp ON comp.id_sales_order_gen = sog.id_sales_order_gen
        WHERE sog.id_report_status=6 AND sog.id_so_status=1 AND (sog.sales_order_gen_date>='" + date_from_selected + "' AND sog.sales_order_gen_date<='" + date_until_selected + "')
        GROUP BY sog.id_sales_order_gen "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNew.DataSource = data
        GVNew.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNew_DoubleClick(sender As Object, e As EventArgs) Handles GVNew.DoubleClick
        If GVNew.RowCount > 0 And GVNew.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderReportDetNew.id_gen = GVNew.GetFocusedRowCellValue("id_sales_order_gen").ToString
            FormSalesOrderReportDetNew.gen_number = GVNew.GetFocusedRowCellValue("sales_order_gen_reff").ToString
            FormSalesOrderReportDetNew.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class