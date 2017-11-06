Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportProdPRWO
    Public Shared id_rec As String = "-1"
    Public Shared id_prod_order_wo As String = "-1"
    Public Shared id_prod_order As String = "-1"
    Public Shared id_pr As String = "-1"
    Public Shared id_comp_contact_pay_to As String = "-1"
    Public Shared id_curr As String = "1"
    Sub view_list_pr()
        Dim query = "CALL view_pr_prod_from_pr('" & id_pr & "',2)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub
    Sub calculate()
        Dim tot_credit, tot_debit, total, gross_tot, vat, dp As Decimal

        Try
            tot_credit = Decimal.Parse(GVListPurchase.Columns("total").SummaryItem.SummaryValue)
            tot_debit = Decimal.Parse(GVListPurchase.Columns("debit").SummaryItem.SummaryValue)
            gross_tot = tot_credit - tot_debit
            dp = Decimal.Parse(LDP.Text)

            If dp <= 0 Or dp.ToString = "" Then
                vat = (Decimal.Parse(LVat.Text) / 100) * gross_tot
            Else
                vat = (Decimal.Parse(LVat.Text) / 100) * dp
            End If
        Catch ex As Exception
        End Try

        LDP.Text = dp.ToString("N4")
        LVatTot.Text = vat.ToString("N4")
        LGrossTot.Text = gross_tot.ToString("N4")

        If dp.ToString = "" Or dp = 0 Or dp = 0.0 Then
            total = gross_tot + vat
        Else
            total = dp + vat
        End If

        LTot.Text = total.ToString("N4")
        Try
            LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_curr)
        Catch ex As Exception
        End Try

    End Sub
    Sub view_wo()
        Dim query As String = String.Format("SELECT a.id_report_status, a.prod_order_wo_vat, a.prod_order_wo_number, b.id_comp_contact, DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex, a.prod_order_wo_lead_time, a.prod_order_wo_top, b.id_currency, a.prod_order_wo_note,a.prod_order_wo_kurs FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price WHERE a.id_prod_order_wo = '{0}'", id_prod_order_wo)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
        Dim kurs As Decimal = data.Rows(0)("prod_order_wo_kurs")
        LKurs.Text = kurs.ToString("N4")
        'LDueDate.Text = view_date_from(data.Rows(0)("prod_order_wo_datex").ToString, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
        If e.Column.FieldName = "total" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N4")
            End If
        End If
        If e.Column.FieldName = "debit" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N4")
            End If
        End If
    End Sub
    Private Sub ReportSamplePR_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_mark_horz("50", id_pr, "2", "1", XrTable1)
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub
    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim query As String = "SELECT z.id_currency,z.pr_prod_order_aju,z.pr_prod_order_pib,z.id_prod_order_wo,z.pr_prod_order_vat,z.pr_prod_order_dp,z.id_comp_contact_to,po.id_prod_order,po.prod_order_number,IFNULL(z.id_prod_order_rec,0) as id_prod_order_rec,l.overhead, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,DATE_FORMAT(z.pr_prod_order_due_date,'%Y-%m-%d') as pr_prod_order_due_date,DATE_FORMAT(z.pr_prod_order_date,'%Y-%m-%d') as pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,DATE_FORMAT(rec.delivery_order_date,'%Y-%m-%d') AS delivery_order_date,rec.delivery_order_number,wo.prod_order_wo_number,DATE_FORMAT(rec.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date, d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(wo.prod_order_wo_date,INTERVAL (wo.prod_order_wo_top+wo.prod_order_wo_lead_time) DAY),'%Y-%m-%d') AS prod_order_wo_top "
        query += "FROM tb_pr_prod_order z "
        query += "INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo = z.id_prod_order_wo "
        query += "INNER JOIN tb_prod_order po ON po.id_prod_order = wo.id_prod_order "
        query += "LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec "
        query += "INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price "
        query += "INNER JOIN tb_m_ovh l ON ovh_p.id_ovh = l.id_ovh "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "WHERE z.id_pr_prod_order ='" & id_pr & "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("prod_order_number").ToString
        LPRNumber.Text = data.Rows(0)("pr_prod_order_number").ToString
        LPRDate.Text = view_date_from(data.Rows(0)("pr_prod_order_date").ToString, 0)
        LNote.Text = data.Rows(0)("pr_prod_order_note").ToString
        '
        id_curr = data.Rows(0)("id_currency").ToString
        LCur.Text = get_currency(data.Rows(0)("id_currency").ToString)

        LDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        LRecNumber.Text = data.Rows(0)("prod_order_rec_number").ToString

        If data.Rows(0)("id_prod_order_rec") <= 0 Then
            id_rec = "-1"
        Else
            id_rec = data.Rows(0)("id_prod_order_rec")
        End If

        id_prod_order_wo = data.Rows(0)("id_prod_order_wo").ToString
        id_prod_order = data.Rows(0)("id_prod_order").ToString
        view_wo()

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        LPayToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        LPayToAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        view_list_pr()

        LDueDate.Text = data.Rows(0)("pr_prod_order_due_date").ToString

        LVat.Text = data.Rows(0)("pr_prod_order_vat").ToString

        LDP.Text = data.Rows(0)("pr_prod_order_dp").ToString
        LPIB.Text = data.Rows(0)("pr_prod_order_pib").ToString
        LAju.Text = data.Rows(0)("pr_prod_order_aju").ToString

        calculate()
    End Sub
End Class