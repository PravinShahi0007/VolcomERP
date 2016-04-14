Imports System.Drawing
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class ReportSamplePR
    Public Shared id_rec As String = "-1"
    Public Shared id_purc As String = "-1"
    Public Shared id_pr As String = "-1"
    Public Shared id_curr As String = "-1"
    Public Shared id_pre As String = "-1"

    Sub view_list_pr()
        Dim query = "CALL view_pr_sample_from_pr('" & id_pr & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub
    Sub calculate()
        Dim tot_credit, tot_debit, total, gross_tot, vat, dp As Decimal

        Try
            tot_credit = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            tot_debit = Decimal.Parse(GVListPurchase.Columns("debit").SummaryText.ToString)
            gross_tot = tot_credit - tot_debit
            dp = Decimal.Parse(LDP.Text)
            If dp <= 0 Or dp.ToString = "" Then
                vat = (Decimal.Parse(LVat.Text) / 100) * gross_tot
            Else
                vat = (Decimal.Parse(LVat.Text) / 100) * dp
            End If
        Catch ex As Exception
        End Try

        LVatTot.Text = vat.ToString("N2")
        LDP.Text = dp.ToString("N2")

        LGrossTot.Text = gross_tot.ToString("N2")

        If dp.ToString = "" Or dp = 0 Then
            total = gross_tot + vat
        Else
            total = dp + vat
        End If

        LTot.Text = total.ToString("N2")

        Try
            LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_curr)
        Catch ex As Exception
        End Try

    End Sub
    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        id_curr = data.Rows(0)("id_currency").ToString

        LPayToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        LPayToAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        LDueDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, (Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("sample_purc_top").ToString)))
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
        If e.Column.FieldName = "total" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
        If e.Column.FieldName = "debit" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
    End Sub

    Private Sub ReportSamplePR_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If id_pre = "-1" Then
            load_mark_horz("4", id_pr, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("4", id_pr, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        Dim query As String = "SELECT b.id_currency,z.pr_sample_purc_dp,z.pr_sample_purc_vat,z.id_pr_sample_purc,z.id_comp_contact_to,z.id_report_status,z.pr_sample_purc_number,z.pr_sample_purc_note,DATE_FORMAT(z.pr_sample_purc_date,'%Y-%m-%d') as pr_sample_purc_date,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%d %M %Y') AS sample_purc_rec_date,d.comp_name AS comp_to,b.id_sample_purc "
        query += "FROM tb_pr_sample_purc z "
        query += "LEFT JOIN tb_sample_purc_rec a ON z.id_sample_purc_rec = a.id_sample_purc_rec "
        query += "INNER JOIN tb_sample_purc b ON z.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "WHERE z.id_pr_sample_purc ='" & id_pr & "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPRNumber.Text = data.Rows(0)("pr_sample_purc_number").ToString
        LPRDate.Text = "Date : " & view_date_from(data.Rows(0)("pr_sample_purc_date").ToString, 0)
        LNote.Text = data.Rows(0)("pr_sample_purc_note").ToString
        LCur.Text = get_currency(data.Rows(0)("id_currency").ToString)
        '
        LDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        LRecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString

        id_purc = data.Rows(0)("id_sample_purc").ToString
        view_po()
        view_list_pr()

        LVat.Text = data.Rows(0)("pr_sample_purc_vat").ToString
        LDP.Text = data.Rows(0)("pr_sample_purc_dp").ToString
        calculate()
    End Sub
End Class