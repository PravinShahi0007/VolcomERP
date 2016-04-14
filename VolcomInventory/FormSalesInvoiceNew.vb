Public Class FormSalesInvoiceNew 
    Dim id_store_contact_to_default As String = "0"

    Private Sub FormSalesInvoiceNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'view data
        viewStore()
        viewSoType()

        'default date
        Dim date_def As Date = execute_query("SELECT NOW()", 0, True, "", "", "", "")
        DEStart.EditValue = date_def
        DEEnd.EditValue = date_def
    End Sub

    Private Sub FormSalesInvoiceNew_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewStore()
        Dim id_store_cat As String = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")
        Dim query As String = "SELECT ('0') AS id_comp, ('0') AS id_comp_contact, ('-Select Store-') AS comp_name, ('-') AS comp_display_name, ('-') AS address_primary, ('-') AS comp_number, "
        query += "('-') AS contact_person, ('-') AS contact_number  "
        query += "UNION ALL "
        query += "SELECT a.id_comp, b.id_comp_contact,a.comp_name, a.comp_display_name, a.address_primary, a.comp_number, "
        query += "b.contact_person, b.contact_number  "
        query += "FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp = b.id_comp AND b.is_default ='1' "
        query += "WHERE a.id_comp_cat = '" + id_store_cat + "' "
        viewSearchLookupQuery(SLEStore, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub viewSoType()
        Dim query As String = "SELECT * FROM tb_lookup_so_type a ORDER BY a.id_so_type "
        viewLookupQuery(LETypeSO, query, 0, "so_type", "id_so_type")
    End Sub

    Private Sub SLEStore_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStore.EditValueChanged
        If SLEStore.EditValue.ToString = "0" Then
            BtnCreate.Enabled = False
        Else
            BtnCreate.Enabled = True
        End If
    End Sub


    Private Sub DEStart_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEStart.EditValueChanged
        Try
            Dim dt_str As String = DEStart.Text
            Dim date_start As Date = Date.Parse(DEStart.Text)
            DEEnd.Properties.MinValue = date_start
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
        Cursor = Cursors.WaitCursor
        FormSalesInvoiceDet.id_store_contact_to = SLEStore.EditValue.ToString
        FormSalesInvoiceDet.TxtCodeCompTo.Text = SLEStore.Properties.View.GetFocusedRowCellValue("comp_number").ToString
        FormSalesInvoiceDet.TxtNameCompTo.Text = SLEStore.Properties.View.GetFocusedRowCellValue("comp_name").ToString
        FormSalesInvoiceDet.MEAdrressCompTo.Text = SLEStore.Properties.View.GetFocusedRowCellValue("address_primary").ToString
        FormSalesInvoiceDet.id_so_type = LETypeSO.EditValue.ToString
        FormSalesInvoiceDet.DEStart.EditValue = DEStart.EditValue.ToString
        FormSalesInvoiceDet.DEStart.Text = DEStart.Text.ToString
        FormSalesInvoiceDet.DEEnd.EditValue = DEEnd.EditValue.ToString
        FormSalesInvoiceDet.DEEnd.Text = DEEnd.Text.ToString
        FormSalesInvoiceDet.action = "ins"
        Visible = False
        Close()
        FormSalesInvoiceDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class