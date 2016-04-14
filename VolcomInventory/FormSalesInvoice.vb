Public Class FormSalesInvoice 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesInvoice_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesInvoice_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVSalesInvoice.RowCount < 1 Then
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
    End Sub

    Private Sub FormSalesInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesInvoice()
    End Sub

    Sub viewSalesInvoice()
        Dim query As String = ""
        query += "SELECT a.id_report_status,a.id_sales_invoice, a.sales_invoice_discount, "
        query += "a.sales_invoice_discount, a.sales_invoice_end_period, a.sales_invoice_note, a.sales_invoice_number, a.sales_invoice_start_period, "
        query += "a.sales_invoice_total, a.sales_invoice_vat, b.so_type, c.report_status, "
        query += "CONCAT_WS(' - ', DATE_FORMAT(a.sales_invoice_start_period, '%d %M %Y') ,DATE_FORMAT(a.sales_invoice_start_period, '%d %M %Y')) AS sales_invoice_period, "
        query += "(e.comp_name) AS store_name_to, (e.id_comp) AS id_store, (e.address_primary) AS store_address_to, (e.comp_number) AS store_number_to, a.id_store_contact_to, "
        query += "DATE_FORMAT(a.sales_invoice_date, '%d %M %Y') AS sales_invoice_date, "
        query += "DATE_FORMAT(a.sales_invoice_due_date, '%d %M %Y') AS sales_invoice_due_date "
        query += "FROM tb_sales_invoice a "
        query += "INNER JOIN tb_lookup_so_type b ON b.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "ORDER BY a.id_sales_invoice DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesInvoice.DataSource = data
        check_menu()
    End Sub
End Class