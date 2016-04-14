Public Class FormViewMatInvoiceRetur 
    Public id_retur As String = "-1"
    Public id_invoice As String = "-1"
    Public id_prod_wo As String = "-1"
    Public id_comp_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"
    Private Sub FormMatInvoiceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_report_status(LEReportStatus)

        'edit
        Dim query As String = "SELECT inv_ret.id_inv_pl_mrs_ret,inv_ret.inv_pl_mrs_ret_number, inv_ret.id_comp_contact_from, "
        query += "inv.inv_pl_mrs_number,m.design_name,k.prod_order_number,j.prod_order_wo_number,DATE_FORMAT(inv_ret.inv_pl_mrs_ret_date,'%Y-%m-%d') AS inv_pl_mrs_ret_datex, "
        query += "inv_ret.inv_pl_mrs_ret_top , inv_ret.id_report_status, inv_ret.id_currency,inv_ret.inv_pl_mrs_ret_note,inv_ret.inv_pl_mrs_ret_vat "
        query += "FROM tb_inv_pl_mrs_ret inv_ret "
        query += "INNER JOIN tb_inv_pl_mrs inv ON inv.id_inv_pl_mrs=inv_ret.id_inv_pl_mrs "
        query += "INNER JOIN tb_m_comp_contact e ON inv_ret.id_comp_contact_from = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv_ret.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE inv_ret.id_inv_pl_mrs_ret='" & id_retur & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status_g = data.Rows(0)("id_report_status").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        TEReturNumber.Text = data.Rows(0)("inv_pl_mrs_ret_number").ToString
        TEInvNumber.Text = data.Rows(0)("inv_pl_mrs_number").ToString
        TEWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TEDesign.Text = data.Rows(0)("design_name").ToString

        id_comp_to = data.Rows(0)("id_comp_contact_from").ToString

        TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
        TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")

        MENote.Text = data.Rows(0)("inv_pl_mrs_ret_note").ToString
        TEVat.EditValue = data.Rows(0)("inv_pl_mrs_ret_vat")

        date_created = data.Rows(0)("inv_pl_mrs_ret_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TETOP.EditValue = data.Rows(0)("inv_pl_mrs_ret_top")
        TEDueDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("inv_pl_mrs_ret_top").ToString))

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        GConListPurchase.Enabled = True
        '
        load_retur()
        calculate()
        view_all_ret()
    End Sub
    Sub view_all_ret()
        Dim query As String = "CALL view_inv_all_ret('" + id_retur + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetInProd.DataSource = data
        ''
    End Sub
    Sub load_retur()
        Dim query As String = "CALL view_inv_mat_retur('" + id_retur + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        ''
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Sub calculate()
        Dim total, gross_tot, vat As Decimal

        Try
            gross_tot = Decimal.Parse(GVListPurchase.Columns("total_price").SummaryItem.SummaryValue)
            vat = (Decimal.Parse(TEVat.EditValue) / 100) * gross_tot
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat
        TEGrossTot.EditValue = gross_tot
        total = gross_tot + vat

        TETot.EditValue = total
        Try
            METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FormMatInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_retur
        FormReportMark.report_mark_type = "35"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class