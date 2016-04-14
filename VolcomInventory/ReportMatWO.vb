Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportMatWO
    Public Shared id_mat_purc As String = "-1"
    Public Shared sign_col As String = "-1"
    Public Shared id_cur As String = "-1"

    Sub view_mat_purchase()
        Dim query = "CALL view_mat_wo_det('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub
    Sub view_mat()
        Dim query = "CALL view_mat_wo_mat('" & id_mat_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaterial.DataSource = data
        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub
    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            vat = (Decimal.Parse(LVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            discount = Decimal.Parse(GVListPurchase.Columns("discount").SummaryText.ToString)
        Catch ex As Exception
        End Try

        LDiscount.Text = discount.ToString("N2")
        LVatTot.Text = vat.ToString("N2")

        gross_tot = sub_tot + discount
        LGrossTot.Text = gross_tot.ToString("N2")

        total = sub_tot + vat
        LTot.Text = total.ToString("N2")
        LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_cur)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT b.id_mat_wo_rev as id_mat_wo_rev,IFNULL(b.mat_wo_number,'-') as mat_wo_number_rev,a.id_ovh,a.mat_wo_kurs,a.id_report_status,a.mat_wo_vat,a.id_delivery,a.mat_wo_number,a.id_comp_contact_to,a.id_comp_contact_ship_to,a.id_payment,DATE_FORMAT(a.mat_wo_date,'%Y-%m-%d') as mat_wo_datex,a.mat_wo_lead_time,a.mat_wo_top,a.id_currency,a.mat_wo_note" _
                                                & " FROM tb_mat_wo a " _
                                                & " LEFT JOIN tb_mat_wo b ON a.id_mat_wo_rev=b.id_mat_wo " _
                                                & " WHERE a.id_mat_wo = '{0}'", id_mat_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("mat_wo_number").ToString
        LWORev.Text = data.Rows(0)("mat_wo_number_rev").ToString
        DisplayName = "Material WO " & data.Rows(0)("mat_wo_number").ToString

        Dim date_created As String = data.Rows(0)("mat_wo_datex").ToString

        LPODate.Text = view_date_from(date_created, 0)
        LLeadTime.Text = data.Rows(0)("mat_wo_lead_time").ToString
        LRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))
        LTOP.Text = data.Rows(0)("mat_wo_top").ToString
        LDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_wo_top").ToString)))

        Dim id_comp_to As String = data.Rows(0)("id_comp_contact_to").ToString
        LToName.Text = get_company_x(get_id_company(id_comp_to), "1")
        LToAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        LToAttn.Text = get_company_contact_x(id_comp_to, "1")

        Dim id_comp_ship_to As String = data.Rows(0)("id_comp_contact_ship_to").ToString
        LShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        LShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        LTax.Text = get_company_x(get_id_company(id_comp_ship_to), "4")
        LNPWMP.Text = get_company_x(get_id_company(id_comp_ship_to), "5")

        LRange.Text = get_range_x(get_id_range(get_id_season(data.Rows(0)("id_delivery").ToString)), "1")
        LSeason.Text = get_season_x(get_id_season(data.Rows(0)("id_delivery").ToString), "1")
        LDelivery.Text = get_delivery_x(data.Rows(0)("id_delivery").ToString, "1")

        LPayment.Text = get_payment(data.Rows(0)("id_payment").ToString)
        LPOType.Text = get_overhead_x(data.Rows(0)("id_ovh").ToString, "1")
        id_cur = data.Rows(0)("id_currency").ToString
        LCur.Text = get_currency(id_cur)
        LKurs.Text = data.Rows(0)("mat_wo_kurs").ToString
        LVat.Text = data.Rows(0)("mat_wo_vat").ToString
    End Sub

    Private Sub ReportMatWO_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        view_mat_purchase()
        view_mat()
        load_mark_horz("15", id_mat_purc, "2", "1", XrTable1)
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

    End Sub

    Private Sub GVMaterial_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMaterial.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub ReportFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter.BeforePrint
        calculate()
    End Sub
End Class