Public Class ReportSalesOrderAll
    Public Shared id_sales_order As String = "-1"
    Public Shared id_delivery As String = "-1"
    Public Shared id_so_status As String = "-1"

    Sub viewSODetail()
        Dim query As String = ""
        query += "SELECT g.sales_order_number, e.id_design, e.id_product, (CONCAT_WS('-', e1.design_code,e1.design_display_name)) AS design_display_name, e1.design_name,b.display_name, i.comp_name, "
        query += "SUM(CASE WHEN b.display_name = 'XXS' THEN f.sales_order_det_qty END) 'XXS', "
        query += "SUM(CASE WHEN b.display_name = 'XS' THEN f.sales_order_det_qty END) 'XS', "
        query += "SUM(CASE WHEN b.display_name = 'S' THEN f.sales_order_det_qty END) 'S', "
        query += "SUM(CASE WHEN b.display_name = 'M' THEN f.sales_order_det_qty END) 'M', "
        query += "SUM(CASE WHEN b.display_name = 'ML' THEN f.sales_order_det_qty END) 'ML', "
        query += "SUM(CASE WHEN b.display_name = 'L' THEN f.sales_order_det_qty END) 'L', "
        query += "SUM(CASE WHEN b.display_name = 'XL' THEN f.sales_order_det_qty END) 'XL', "
        query += "SUM(CASE WHEN b.display_name = 'XXL' THEN f.sales_order_det_qty END) 'XXL', "
        query += "SUM(CASE WHEN b.display_name = 'ALL' THEN f.sales_order_det_qty END) 'ALL', "
        query += "SUM(CASE WHEN b.display_name = 'SM' THEN f.sales_order_det_qty END) 'SM', "
        query += "SUM(f.sales_order_det_qty ) 'Qty' "
        query += "FROM tb_m_code a "
        query += "INNER JOIN tb_m_code_detail b ON a.id_code = b.id_code "
        query += "INNER JOIN tb_m_product_code d ON d.id_code_detail = b.id_code_detail "
        query += "INNER JOIN tb_m_product e ON e.id_product = d.id_product "
        query += "INNER JOIN tb_m_design e1 ON e.id_design = e1.id_design "
        query += "INNER JOIN tb_sales_order_det f ON f.id_product = e.id_product "
        query += "INNER JOIN tb_sales_order g ON g.id_sales_order = f.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact h ON h.id_comp_contact = g.id_store_contact_to "
        query += "INNER JOIN tb_m_comp i ON i.id_comp = h.id_comp "
        query += "WHERE (g.id_report_status = '3' OR g.id_report_status = '4') AND g.id_delivery = '" + id_delivery + "' AND id_so_status = '" + id_so_status + "' "
        query += "GROUP BY e.id_design, g.id_sales_order "
        query += "ORDER BY e.id_design "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSO.DataSource = data
    End Sub

    Private Sub ReportSalesOrderAll_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query_get_season As String = ""
        query_get_season += "SELECT a.delivery, b.season_printed_name FROM tb_season_delivery a "
        query_get_season += "INNER JOIN tb_season b ON a.id_season = b.id_season "
        query_get_season += "WHERE a.id_delivery = '" + id_delivery + "' "
        Dim data As DataTable = execute_query(query_get_season, -1, True, "", "", "", "")
        LabelSeason.Text = data.Rows(0)("season_printed_name").ToString + "/" + data.Rows(0)("delivery").ToString
        'LabelDelivery.Text = data.Rows(0)("delivery").ToString

        Dim query_get_so_status As String = "SELECT * FROM tb_lookup_so_status a WHERE a.id_so_status = '" + id_so_status + "' "
        LabelStatus.Text = execute_query(query_get_so_status, 0, True, "", "", "", "")


        viewSODetail()
    End Sub

    Private Sub GVSO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class