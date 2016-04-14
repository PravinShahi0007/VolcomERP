Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatInvoice
    Public Shared id_invoice As String = "-1"
    Public id_pl As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_from As String = "-1"
    Public date_created As String = ""
    Public id_cur As String = "1"
    Public Shared comp_to_name As String = ""

    Sub load_invoice()
        Dim query As String = "CALL view_inv_mat('" + id_invoice + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        ''
        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub
    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        load_invoice()
    End Sub
    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint

        Dim query As String = "SELECT inv.id_inv_pl_mrs,inv.inv_pl_mrs_number, inv.id_comp_contact_to, inv.id_report_status, "
        query += "DATE_FORMAT(inv.inv_pl_mrs_date,'%Y-%m-%d') AS inv_pl_mrs_datex,m.design_name,k.prod_order_number,j.prod_order_wo_number, "
        query += "inv.inv_pl_mrs_top , inv.id_report_status, inv.id_currency,inv.inv_pl_mrs_note,inv.inv_pl_mrs_vat "
        query += "FROM tb_inv_pl_mrs inv "
        query += "INNER JOIN tb_m_comp_contact e ON inv.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = inv.id_report_status "
        query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE inv.id_inv_pl_mrs='" & id_invoice & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_cur = data.Rows(0)("id_currency").ToString
        LCur.Text = get_currency(id_cur)

        LWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
        LPDONumber.Text = data.Rows(0)("prod_order_number").ToString
        LDesign.Text = data.Rows(0)("design_name").ToString

        'id_pl = data.Rows(0)("id_pl_mrs").ToString

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        LToName.Text = get_company_x(get_id_company(id_comp_to), "1")
        comp_to_name = get_company_x(get_id_company(id_comp_to), "1")
        LToAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        LToNPWP.Text = get_company_x(get_id_company(id_comp_to), "5")
        LToAttn.Text = get_company_contact_x(id_comp_to, "1")

        id_comp_from = get_setup_field("id_own_company")
        LFromName.Text = get_company_x(id_comp_from, "1")
        LFromAddress.Text = get_company_x(id_comp_from, "3")
        LFromNPWP.Text = get_company_x(id_comp_from, "5")

        LInvNumber.Text = data.Rows(0)("inv_pl_mrs_number").ToString
        LNote.Text = data.Rows(0)("inv_pl_mrs_note").ToString
        LVat.Text = data.Rows(0)("inv_pl_mrs_vat").ToString

        date_created = data.Rows(0)("inv_pl_mrs_datex").ToString
        LDate.Text = view_date_from(date_created, 0)
        LDueDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("inv_pl_mrs_top").ToString))
    End Sub
    Sub calculate()
        Dim total, sub_tot, gross_tot, vat As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("total_price").SummaryText.ToString)
            vat = (Decimal.Parse(LVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total_price").SummaryText.ToString)
        Catch ex As Exception
        End Try

        LVatTot.Text = vat.ToString("N2")

        gross_tot = sub_tot
        LGrossTot.Text = gross_tot.ToString("N2")

        total = sub_tot + vat
        LTot.Text = total.ToString("N2")
        LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_cur)
    End Sub
    Private Sub ReportMatPurchase_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("34", id_invoice, comp_to_name, "2", XrTable1)
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class