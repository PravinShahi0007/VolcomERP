Public Class FormEmpUniSumReport
    Private Sub FormEmpUniSumReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        viewPeriodUniform()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpUniSumReport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmpUniSumReport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewPeriodUniform()
        Dim query As String = "SELECT * FROM tb_emp_uni_period p ORDER BY p.id_emp_uni_period ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        LEPeriodx.Properties.DataSource = Nothing
        LEPeriodx.Properties.DataSource = data
        LEPeriodx.Properties.DisplayMember = "period_name"
        LEPeriodx.Properties.ValueMember = "id_emp_uni_period"
        LEPeriodx.ItemIndex = 0
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewSummaryByPeriod()
    End Sub

    Sub viewSummaryByPeriod()
        Cursor = Cursors.WaitCursor
        Dim id_period As String = LEPeriodx.EditValue.ToString
        Dim query As String = "SELECT e.id_departement, d.departement, 
        SUM(b.budget) AS `budget`, SUM(IFNULL(so.`order_amount`,0)) AS `actual`,
        SUM(IFNULL(so.`order_qty`,0)) AS `qty`
        FROM tb_emp_uni_budget b
        INNER JOIN tb_emp_uni_period p ON p.id_emp_uni_period = b.id_emp_uni_period
        INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        LEFT JOIN tb_lookup_employee_level l ON l.id_employee_level=e.id_employee_level
        LEFT JOIN (
	        SELECT so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, rs.report_status AS `order_status`, so.id_emp_uni_period, so.id_emp_uni_budget, 
	        IFNULL(SUM(d.design_cop * sod.sales_order_det_qty),0) AS `order_amount`, SUM(sod.sales_order_det_qty) AS `order_qty`
	        FROM tb_sales_order so
	        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        LEFT JOIN tb_m_product p ON p.id_product = sod.id_product
	        LEFT JOIN tb_m_design d ON d.id_design = p.id_design
	        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
	        WHERE so.id_report_status!=5 AND !ISNULL(so.id_emp_uni_budget) AND so.id_emp_uni_period=" + id_period + "
	        GROUP BY so.id_sales_order
        ) so ON so.id_emp_uni_budget = b.id_emp_uni_budget AND so.id_emp_uni_period=p.id_emp_uni_period
        WHERE b.id_emp_uni_period=" + id_period + "
        GROUP BY e.id_departement
        ORDER BY d.departement ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPeriod.DataSource = data
        GVPeriod.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewSummaryByDate()
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
        Dim query As String = "SELECT e.id_departement, d.departement, 
        SUM(b.budget) AS `budget`, SUM(IFNULL(so.`order_amount`,0)) AS actual,
        SUM(IFNULL(so.`order_qty`,0)) AS `qty`
        FROM tb_emp_uni_budget b
        INNER JOIN tb_emp_uni_period p ON p.id_emp_uni_period = b.id_emp_uni_period
        INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        LEFT JOIN tb_lookup_employee_level l ON l.id_employee_level=e.id_employee_level
        LEFT JOIN (
	        SELECT so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, rs.report_status AS `order_status`, so.id_emp_uni_period, so.id_emp_uni_budget, 
	        IFNULL(SUM(d.design_cop * sod.sales_order_det_qty),0) AS `order_amount`, SUM(sod.sales_order_det_qty) AS `order_qty`
	        FROM tb_sales_order so
	        LEFT JOIN tb_emp_uni_period ep ON ep.id_emp_uni_period = so.id_emp_uni_period
	        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        LEFT JOIN tb_m_product p ON p.id_product = sod.id_product
	        LEFT JOIN tb_m_design d ON d.id_design = p.id_design
	        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
	        WHERE so.id_report_status!=5 AND !ISNULL(so.id_emp_uni_budget) AND (ep.selection_date_end>='" + date_from_selected + "' AND ep.selection_date_end<='" + date_until_selected + "')
	        GROUP BY so.id_sales_order
        ) so ON so.id_emp_uni_budget = b.id_emp_uni_budget AND so.id_emp_uni_period=p.id_emp_uni_period
        WHERE (p.selection_date_end>='" + date_from_selected + "' AND p.selection_date_end<='" + date_until_selected + "')
        GROUP BY e.id_departement
        ORDER BY d.departement ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByDate.DataSource = data
        GVByDate.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewByDate_Click(sender As Object, e As EventArgs) Handles BtnViewByDate.Click
        viewSummaryByDate()
    End Sub
End Class