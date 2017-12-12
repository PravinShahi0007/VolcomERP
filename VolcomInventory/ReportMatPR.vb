Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI
Public Class ReportMatPR
    Public Shared id_rec As String = "-1"
    Public Shared id_purc As String = "-1"
    Public Shared id_pr As String = "-1"
    Public Shared id_curr As String = "-1"

    Sub view_list_pr()
        Dim query = "CALL view_pr_mat_from_pr('" & id_pr & "')"
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

        LVatTot.Text = vat.ToString("N4")
        LDP.Text = dp.ToString("N4")
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
    Sub view_po()
        Dim query As String = String.Format("SELECT a.id_report_status, a.mat_purc_vat, b.id_season, a.mat_purc_number, a.id_comp_contact_to, a.id_comp_contact_ship_to, a.id_po_type, a.id_payment,DATE_FORMAT(a.mat_purc_date,'%Y-%m-%d') as mat_purc_datex, a.mat_purc_lead_time, a.mat_purc_top, a.id_currency, a.mat_purc_note, a.mat_purc_kurs FROM tb_mat_purc a INNER JOIN tb_season_delivery b ON a.id_delivery = b.id_delivery WHERE a.id_mat_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("mat_purc_number").ToString

        id_curr = data.Rows(0)("id_currency").ToString

        LKurs.Text = Decimal.Parse(data.Rows(0)("mat_purc_kurs")).ToString("N2")

        LPayToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        LPayToAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        LDueDate.Text = view_date_from(data.Rows(0)("mat_purc_datex").ToString, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))
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
        load_mark_horz("24", id_pr, "2", "1", XrTable1)
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim query As String = "SELECT z.pr_mat_purc_bill,z.pr_mat_purc_tax_inv,b.id_currency, z.id_mat_purc_rec, z.pr_mat_purc_dp,z.pr_mat_purc_vat,z.id_pr_mat_purc,z.id_comp_contact_to,z.id_report_status,z.pr_mat_purc_number,z.pr_mat_purc_note,DATE_FORMAT(z.pr_mat_purc_date,'%Y-%m-%d') as pr_mat_purc_date,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%d %M %Y') AS mat_purc_rec_date,d.comp_name AS comp_to,b.id_mat_purc "
        query += "FROM tb_pr_mat_purc z "
        query += "LEFT JOIN tb_mat_purc_rec a ON z.id_mat_purc_rec = a.id_mat_purc_rec "
        query += "INNER JOIN tb_mat_purc b ON z.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=g0.id_season "
        query += "WHERE z.id_pr_mat_purc ='" & id_pr & "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPRNumber.Text = data.Rows(0)("pr_mat_purc_number").ToString
        LPRDate.Text = "Date : " & view_date_from(data.Rows(0)("pr_mat_purc_date").ToString, 0)
        LNote.Text = data.Rows(0)("pr_mat_purc_note").ToString
        LCur.Text = get_currency(data.Rows(0)("id_currency").ToString)
        LBill.Text = data.Rows(0)("pr_mat_purc_bill").ToString
        LTaxInvNo.Text = data.Rows(0)("pr_mat_purc_tax_inv").ToString
        '
        LDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        LRecNumber.Text = data.Rows(0)("mat_purc_rec_number").ToString

        id_purc = data.Rows(0)("id_mat_purc").ToString
        view_po()
        view_list_pr()

        LVat.Text = data.Rows(0)("pr_mat_purc_vat").ToString
        LDP.Text = data.Rows(0)("pr_mat_purc_dp").ToString
        calculate()
    End Sub
End Class