Public Class FormFGMissingInvoice 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGMissingInvoice_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGMissingInvoice_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVFGMissingInvoice.RowCount < 1 Then
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

    Private Sub FormFGMissingInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewFGMissingInvoice()
    End Sub

    Sub viewFGMissingInvoice()
        Dim query As String = ""
        query += "SELECT a.id_report_status,a.id_fg_missing_invoice, a.fg_missing_invoice_discount, "
        query += "a.fg_missing_invoice_end_period, a.fg_missing_invoice_note, a.fg_missing_invoice_number, a.fg_missing_invoice_start_period, "
        query += "a.fg_missing_invoice_total, a.fg_missing_invoice_vat, c.report_status, "
        query += "CONCAT_WS(' - ', DATE_FORMAT(a.fg_missing_invoice_start_period, '%d %M %Y') ,DATE_FORMAT(a.fg_missing_invoice_start_period, '%d %M %Y')) AS fg_missing_invoice_period, "
        query += "(e.comp_name) AS store_name_to, (e.id_comp) AS id_store, (e.address_primary) AS store_address_to, (e.comp_number) AS store_number_to, a.id_store_contact_to, "
        query += "DATE_FORMAT(a.fg_missing_invoice_date, '%d %M %Y') AS fg_missing_invoice_date, "
        query += "DATE_FORMAT(a.fg_missing_invoice_due_date, '%d %M %Y') AS fg_missing_invoice_due_date "
        query += "FROM tb_fg_missing_invoice a "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "ORDER BY a.id_fg_missing_invoice DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGMissingInvoice.DataSource = data
        check_menu()
    End Sub
End Class