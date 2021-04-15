Public Class FormViewSalesOrderOnline
    Public id_sales_order As String = "-1"
    Public is_print As String = "-1"
    Dim id_commerce_type As String = "-1"
    Private Sub FormViewSalesOrderOnline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_print = "1" Then
            printSO()
            Close()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        If id_commerce_type = "2" Then
            query = "CALL view_sales_order_ol_store('" + id_sales_order + "')"

        Else
            query = "CALL view_sales_order('" + id_sales_order + "')"
        End If
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool
    Sub printSO()
        Cursor = Cursors.WaitCursor
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
        Dim rpt As New ReportSalesOrder()
        Dim query As String = "SELECT a.id_so_status, h.so_status, a.id_sales_order, a.id_store_contact_to, d.id_commerce_type, (d.id_comp) AS id_store,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, (d.address_primary) AS store_address_to, a.id_warehouse_contact_to, (wh.id_comp) AS id_comp_par,(wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to, a.id_report_status, f.report_status, "
        query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "DATE_FORMAT(a.sales_order_date,'%Y-%m-%d') AS sales_order_datex, a.id_so_type, g.so_type, IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`, ps.id_prepare_status, ps.prepare_status, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, a.sales_order_ol_shop_number, a.customer_name "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status "
        query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee "
        query += "WHERE a.id_sales_order IN(" + id_sales_order + ") "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            id_commerce_type = data.Rows(0)("id_commerce_type").ToString
            Dim id_so_status As String = data.Rows(0)("id_so_status").ToString

            GCItemList.DataSource = Nothing
            viewDetail()
            ReportSalesOrder.dt = GCItemList.DataSource
            ReportSalesOrder.id_sales_order = data.Rows(0)("id_sales_order").ToString
            Dim Report As New ReportSalesOrder()

            'Grid Detail
            ReportStyleGridview(Report.GVSalesOrder)

            'parse val
            Report.LabelTo.Text = data.Rows(0)("store_number_to").ToString + "-" + data.Rows(0)("store_name_to").ToString
            Report.LabelWarehouse.Text = data.Rows(0)("warehouse_number_to").ToString + "-" + data.Rows(0)("warehouse_name_to").ToString
            Report.LabelCategory.Text = data.Rows(0)("so_status").ToString
            Report.LabelReff.Text = data.Rows(0)("fg_so_reff_number").ToString
            Report.LRecDate.Text = view_date_from(data.Rows(0)("sales_order_datex").ToString, 0)
            Report.LRecNumber.Text = data.Rows(0)("sales_order_number").ToString
            Report.LabelNote.Text = data.Rows(0)("sales_order_note").ToString
            Report.LabelType.Text = data.Rows(0)("so_type").ToString
            If id_so_status = "7" Then
                Report.LabelNIK.Visible = True
                Report.LabelNIKDot.Visible = True
                Report.LabelTitleNIK.Visible = True
                Report.LabelName.Visible = True
                Report.LabelNameDot.Visible = True
                Report.LabelTitleName.Visible = True
                Report.LabelNIK.Text = data.Rows(0)("employee_code").ToString
                Report.LabelName.Text = data.Rows(0)("employee_name").ToString
            End If

            If id_commerce_type = "2" Then
                Report.LabelTitleName.Visible = True
                Report.LabelNameDot.Visible = True
                Report.LabelName.Visible = True
                Report.LabelName.Text = data.Rows(0)("customer_name").ToString

                Report.LabelOLStoreOrder.Visible = True
                Report.LabelTitleOLStoreOrder.Visible = True
                Report.LabelDotOLStoreOrder.Visible = True
                Report.LabelOLStoreOrder.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            End If
            Report.PrintingSystem.ContinuousPageNumbering = False
            Report.CreateDocument()

            For j = 0 To Report.Pages.Count - 1
                list.Add(Report.Pages(j))
            Next
        Next

        rpt.Pages.AddRange(list)
        tool_detail = New DevExpress.XtraReports.UI.ReportPrintTool(rpt)
        tool_detail.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub PrintingSystem_EndPrint(ByVal sender As Object, ByVal e As EventArgs)
        'insert log
        Dim query As String = "INSERT INTO tb_sales_order_log_print(id_sales_order, id_user, log_date) 
        SELECT so.id_sales_order, '" + id_user + "', NOW() 
        FROM tb_sales_order so WHERE so.id_sales_order IN(" + id_sales_order + "); "
        execute_non_query(query, True, "", "", "", "")
        tool_detail.ClosePreview()
    End Sub

    Private Sub FormViewSalesOrderOnline_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class