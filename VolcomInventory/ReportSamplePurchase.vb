Public Class ReportSamplePurchase
    Public Shared id_sample_purc As String = "-1"
    Public Shared sign_col As String = "-1"
    Public Shared id_pre As String = "-1"
    Public id_cur As String = "-1"

    Public Shared is_com As String = "-1"

    Sub view_list_purchase()
        Dim query = ""
        If is_com = "1" Then
            query = "CALL view_purc_sample_det_com('" & id_sample_purc & "')"
        Else
            query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        GVListPurchase.BestFitColumns()

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Private Sub Detail_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
        view_list_purchase()
    End Sub

    Private Sub TopMargin_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles TopMargin.BeforePrint
        Dim query As String = String.Format("SELECT CONCAT((SELECT sample_po_com_code_head FROM tb_opt LIMIT 1),LPAD(sp.id_sample_purc,(SELECT sample_po_com_code_digit FROM tb_opt LIMIT 1),0)) AS wo_number,sp.sample_purc_vat,sp.id_season_orign,sp.sample_purc_number,sp.id_comp_contact_to,sp.id_comp_contact_ship_to,sp.id_po_type,sp.id_payment
,DATE_FORMAT(sp.sample_purc_date,'%d %M %Y') AS sample_purc_datex,DATE_FORMAT(DATE_ADD(sp.sample_purc_date, INTERVAL sp.sample_purc_lead_time DAY),'%d %M %Y') AS sample_purc_lead_time_date
,DATE_FORMAT(DATE_ADD(sp.sample_purc_date, INTERVAL (sp.sample_purc_lead_time+sp.sample_purc_top) DAY),'%d %M %Y') AS sample_purc_top_date
,sp.sample_purc_lead_time,sp.sample_purc_top,sp.id_currency,sp.sample_purc_note,sp.sample_purc_kurs,py.payment 
FROM tb_sample_purc sp 
INNER JOIN tb_lookup_payment py ON py.id_payment=sp.id_payment
WHERE sp.id_sample_purc ='{0}'", id_sample_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        LPODate.Text = "Date : " & data.Rows(0)("sample_purc_datex").ToString
        '
        If is_com = "1" Then
            LPOReff.Visible = True
            LPOReffbits.Visible = True
            LPOReffTitle.Visible = True
            LPOReff.Text = data.Rows(0)("sample_purc_number").ToString
            LPONumber.Text = data.Rows(0)("wo_number").ToString
            LPayment.Text = data.Rows(0)("payment").ToString
        Else
            LPOReff.Visible = False
            LPOReffbits.Visible = False
            LPOReffTitle.Visible = False
            LPONumber.Text = data.Rows(0)("sample_purc_number").ToString
            LPayment.Text = data.Rows(0)("payment").ToString
        End If
        '
        Dim id_comp_to As String = data.Rows(0)("id_comp_contact_to").ToString
        LToName.Text = get_company_x(get_id_company(id_comp_to), "1")
        LToAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        LToAttn.Text = get_company_contact_x(id_comp_to, "1")
        '
        Dim id_comp_ship_to As String = data.Rows(0)("id_comp_contact_ship_to").ToString
        LShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        LShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")
        '
        LSeason.Text = get_season_orign_x(data.Rows(0)("id_season_orign").ToString, "1")
        id_cur = data.Rows(0)("id_currency")
        LNote.Text = data.Rows(0)("sample_purc_note").ToString
        LCur.Text = get_currency(data.Rows(0)("id_currency").ToString)
        '
        Dim date_created As String = data.Rows(0)("sample_purc_datex").ToString
        LLeadTime.Text = data.Rows(0)("sample_purc_lead_time").ToString
        LRecDate.Text = data.Rows(0)("sample_purc_lead_time_date").ToString
        LTOP.Text = data.Rows(0)("sample_purc_top").ToString
        LDueDate.Text = data.Rows(0)("sample_purc_top_date").ToString
        '
        If Not data.Rows(0)("id_currency").ToString = get_setup_field("id_currency_default") Then
            LKurs.Text = Decimal.Parse(data.Rows(0)("sample_purc_kurs")).ToString("N2")
        Else
            LKurs.Text = ""
            LHKurs.Text = ""
        End If

    End Sub
    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            vat = (Decimal.Parse(LVat.Text) / 100) * GVListPurchase.Columns("total").SummaryItem.SummaryValue
            discount = GVListPurchase.Columns("tot_discount").SummaryItem.SummaryValue
        Catch ex As Exception
            'MsgBox("A")
        End Try

        LDiscount.Text = discount.ToString("N2")
        LVatTot.Text = vat.ToString("N2")

        gross_tot = sub_tot + discount
        LGrossTot.Text = gross_tot.ToString("N2")

        total = sub_tot + vat
        LTot.Text = total.ToString("N2")
        LSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), id_cur)
    End Sub

    Private Sub ReportSamplePurchase_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If id_pre = "-1" Then
            load_mark_horz("1", id_sample_purc, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("1", id_sample_purc, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub PageFooter_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint
        calculate()
    End Sub
End Class