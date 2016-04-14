Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatPurchase
    Public Shared dt As DataTable

    Public Shared id_mat_purc As String = "-1"
    'Public Shared sign_col As String = "-1"
    'Public Shared id_cur As String = "-1"
    Public Shared is_pre As String = "-1"
    Private Sub ReportMatPurchase_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCListPurchase.DataSource = dt
        If is_pre = "1" Then
            pre_load_mark_horz("13", id_mat_purc, LToName.Text, "2", XrTable1)
        Else
            load_mark_horz("13", id_mat_purc, LToName.Text, "2", XrTable1)
        End If
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    'Sub view_mat_purchase()
    '    Dim query = "CALL view_mat_purc_det('" & id_mat_purc & "')"
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCListPurchase.DataSource = data
    '    If data.Rows.Count > 0 Then
    '        calculate()
    '    End If
    'End Sub

    'Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
    '    ' view_mat_purchase()
    'End Sub

    'Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
    '    Dim query As String = String.Format("SELECT IFNULL(a.id_mat_purc_rev,'-1') AS id_mat_purc_rev,IFNULL(b.mat_purc_number,'-') AS mat_purc_rev_number,a.mat_purc_kurs,a.id_report_status,a.mat_purc_vat,a.id_delivery,a.mat_purc_number,a.id_comp_contact_to,a.id_comp_contact_ship_to,a.id_po_type,a.id_payment,DATE_FORMAT(a.mat_purc_date,'%Y-%m-%d') as mat_purc_datex,a.mat_purc_lead_time,a.mat_purc_top,a.id_currency,a.mat_purc_note " _
    '    & "FROM tb_mat_purc a " _
    '    & "LEFT JOIN tb_mat_purc b ON a.id_mat_purc_rev=b.id_mat_purc " _
    '    & "WHERE a.id_mat_purc = '{0}'", id_mat_purc)
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

    '    LPORev.Text = data.Rows(0)("mat_purc_rev_number").ToString
    '    LPONumber.Text = data.Rows(0)("mat_purc_number").ToString

    '    Dim date_created As String = data.Rows(0)("mat_purc_datex").ToString

    '    LPODate.Text = view_date_from(date_created, 0)
    '    LLeadTime.Text = data.Rows(0)("mat_purc_lead_time").ToString
    '    LRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString))
    '    LTOP.Text = data.Rows(0)("mat_purc_top").ToString
    '    LDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))

    '    Dim id_comp_to As String = data.Rows(0)("id_comp_contact_to").ToString
    '    LToName.Text = get_company_x(get_id_company(id_comp_to), "1")
    '    LToAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
    '    LToAttn.Text = get_company_contact_x(id_comp_to, "1")

    '    Dim id_comp_ship_to As String = data.Rows(0)("id_comp_contact_ship_to").ToString
    '    LShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
    '    LShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

    '    LTax.Text = get_company_x(get_id_company(id_comp_ship_to), "4")
    '    LNPWMP.Text = get_company_x(get_id_company(id_comp_ship_to), "5")

    '    LRange.Text = get_range_x(get_id_range(get_id_season(data.Rows(0)("id_delivery").ToString)), "1")
    '    LSeason.Text = get_season_x(get_id_season(data.Rows(0)("id_delivery").ToString), "1")
    '    LDelivery.Text = get_delivery_x(data.Rows(0)("id_delivery").ToString, "1")

    '    LPayment.Text = get_payment(data.Rows(0)("id_payment").ToString)
    '    LPOType.Text = get_potype_x(data.Rows(0)("id_po_type").ToString, "1")
    '    id_cur = data.Rows(0)("id_currency").ToString
    '    LCur.Text = get_currency(id_cur)
    '    LKurs.Text = data.Rows(0)("mat_purc_kurs").ToString
    '    LVat.Text = data.Rows(0)("mat_purc_vat").ToString
    'End Sub
    'Sub calculate()
    '    Dim total, sub_tot, gross_tot, vat, discount As Decimal

    '    Try
    '        sub_tot = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
    '        vat = (Decimal.Parse(LVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
    '        discount = Decimal.Parse(GVListPurchase.Columns("discount").SummaryText.ToString)
    '    Catch ex As Exception
    '    End Try

    '    LDiscount.Text = discount.ToString("N2")
    '    LVatTot.Text = vat.ToString("N2")

    '    gross_tot = sub_tot + discount
    '    LGrossTot.Text = gross_tot.ToString("N2")

    '    total = sub_tot + vat
    '    LTot.Text = total.ToString("N2")
    '    LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_cur)
    'End Sub

    'Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
    '    'calculate()
    'End Sub
End Class