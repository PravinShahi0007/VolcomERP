Public Class ReportSalesOrderNew
    Public Shared id_sales_order As String

    Private Sub ReportSalesOrderNew_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'header
        Dim query As String = "SELECT a.id_sales_order,a.sales_order_number AS `order_number`, h.printed_name AS `title`, 
        DATE_FORMAT(a.sales_order_date,'%d %M %Y') AS `order_date`, DATE_FORMAT(a.sales_order_ol_shop_date,'%d-%m-%Y %H:%i:%s') AS `ol_order_date`,
        d.id_commerce_type,CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `from`,CONCAT(d.comp_number, ' - ', d.comp_name) AS `to`,IFNULL(an.fg_so_reff_number,'-') AS `reff`, g.so_type, a.id_so_status,h.so_status, UPPER(ot.description) AS `judul`,
        ube.employee_code AS `nik`, IF(a.id_so_status=7,ube.employee_name, a.customer_name) AS `name`, a.sales_order_ol_shop_number AS `ol_order_number`, a.sales_order_note AS `order_note` "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_so_type g ON g.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_so_status h ON h.id_so_status = a.id_so_status 
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = h.id_order_type "
        query += "LEFT JOIN tb_fg_so_reff an ON an.id_fg_so_reff = a.id_fg_so_reff "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee "
        query += "WHERE a.id_sales_order = '" + id_sales_order + "' LIMIT 1"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        DataSource = data
        Dim id_so_status As String = data.Rows(0)("id_so_status")
        Dim id_commerce_type As String = data.Rows(0)("id_commerce_type")
        If id_so_status = "7" Then
            LabelNIK.Visible = True
            LabelNIKDot.Visible = True
            LabelTitleNIK.Visible = True
            LabelName.Visible = True
            LabelNameDot.Visible = True
            LabelTitleName.Visible = True
        End If

        If id_commerce_type = "2" Then
            LabelTitleName.Visible = True
            LabelNameDot.Visible = True
            LabelName.Visible = True

            LabelOLStoreOrder.Visible = True
            LabelTitleOLStoreOrder.Visible = True
            LabelDotOLStoreOrder.Visible = True

            LabelOLOrderDate.Visible = True
            LabelTitleOLOrderDate.Visible = True
            LabelDotOLOrderDate.Visible = True
            XRBarcode.Text = data.Rows(0)("ol_order_number").ToString
        Else
            XRBarcode.Text = data.Rows(0)("order_number").ToString
        End If

        'detail
        Dim qd As String = ""
        If id_commerce_type = "2" Then
            qd = "CALL view_sales_order_ol_store('" + id_sales_order + "')"

        Else
            qd = "CALL view_sales_order('" + id_sales_order + "')"
        End If
        Dim dd As DataTable = execute_query(qd, "-1", True, "", "", "", "")
        GCItemList.DataSource = dd
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)

    End Sub

    Private Sub GVItemList_CustomColumnDisplayText_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class