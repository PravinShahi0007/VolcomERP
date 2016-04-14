Public Class FormViewProductionWO
    Public id_wo As String = "-1"
    Public id_ovh_price As String = "-1"
    Public id_po As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"
    Public id_wo_type As String = "-1"

    Private Sub FormViewProductionWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        viewSeason(LESeason)
        'view delivery
        view_payment_type(LEpayment)


        Dim query = "SELECT a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price,a.id_payment, "
        query += "a.id_prod_order,g.payment,b.id_currency,a.prod_order_wo_note, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to,a.id_comp_contact_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex,a.prod_order_wo_lead_time,a.prod_order_wo_top,a.prod_order_wo_vat "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "WHERE a.id_prod_order_wo='" & id_wo & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        id_po = data.Rows(0)("id_prod_order").ToString
        load_po(id_po)
        id_ovh_price = data.Rows(0)("id_ovh_price").ToString
        '
        TEWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEpayment.EditValue = Nothing
        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        id_report_status_g = data.Rows(0)("id_report_status").ToString

        TEWO.Text = data.Rows(0)("overhead").ToString()

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        MENote.Text = data.Rows(0)("prod_order_wo_note").ToString

        date_created = data.Rows(0)("prod_order_wo_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TELeadTime.Text = data.Rows(0)("prod_order_wo_lead_time").ToString
        TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString))
        TETOP.Text = data.Rows(0)("prod_order_wo_top").ToString
        TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))
        '
        GConListPurchase.Enabled = True
        TEVat.Properties.ReadOnly = False
        load_wo()
        TEVat.Text = data.Rows(0)("prod_order_wo_vat").ToString
        calculate()
    End Sub

    Sub load_po(ByVal id_po As String)
        Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_po)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString
        TEDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
        LESeason.EditValue = get_id_season(get_prod_demand_design_x(id_prod_demand_design, "2"))
        LEDelivery.EditValue = get_prod_demand_design_x(id_prod_demand_design, "2")
        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TEDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
    End Sub

    Sub load_wo()
        view_list_purchase()

        Dim query As String = "SELECT a.id_currency, a.ovh_price, b.overhead as name, b.overhead_code as code,a.id_comp_contact from tb_m_ovh_price a INNER JOIN tb_m_ovh b WHERE a.id_ovh_price='" & id_ovh_price & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEWO.Text = data.Rows(0)("name").ToString
        TEWOCode.Text = data.Rows(0)("code").ToString
        TECompCode.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "2")
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "3")
        TECompAttn.Text = get_company_contact_x(data.Rows(0)("id_comp_contact").ToString, "1")
        LECurrency.EditValue = data.Rows(0)("id_currency").ToString

        query = "SELECT id_prod_order_det,prod_order_wo_det_qty,prod_order_wo_det_price FROM tb_prod_order_wo_det WHERE id_prod_order_wo='" & id_wo & "'"
        data = execute_query(query, -1, True, "", "", "", "")

        For i As Integer = 0 To data.Rows.Count - 1
            Try
                Dim qty, price, subtotal As Decimal
                qty = Decimal.Parse(data.Rows(i)("prod_order_wo_det_qty").ToString)
                price = Decimal.Parse(data.Rows(i)("prod_order_wo_det_price").ToString)
                subtotal = qty * price
                Dim rowh As Integer = find_row(GVListPurchase, "id_prod_order_det", data.Rows(i)("id_prod_order_det").ToString)
                GVListPurchase.SetRowCellValue(rowh, "estimate_cost", price)
                GVListPurchase.SetRowCellValue(rowh, "total_cost", subtotal)
            Catch ex As Exception
            End Try
        Next

        calculate()
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_po & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        calculate()
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
    Private Sub view_payment_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment,payment FROM tb_lookup_payment"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment"
        lookup.Properties.ValueMember = "id_payment"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_wo_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_ovh,overhead FROM tb_m_ovh ORDER BY id_ovh ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "overhead"
        lookup.Properties.ValueMember = "id_ovh"
        lookup.EditValue = data.Rows(0)("id_ovh").ToString
        id_wo_type = lookup.EditValue.ToString
    End Sub
    'View Season
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season ORDER BY id_season DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"

        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_season").ToString
            view_delivery(data.Rows(0)("id_season").ToString, LEDelivery)
        End If
    End Sub
    Sub view_delivery(ByVal id_season As String, ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_delivery,delivery FROM tb_season_delivery WHERE id_season='" & id_season & "' ORDER BY id_delivery DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "delivery"
        lookup.Properties.ValueMember = "id_delivery"
        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_delivery").ToString
        End If
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpContact.id_pop_up = "24"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEWONumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_prod_order_wo) FROM tb_prod_order_wo WHERE prod_order_wo_number='{0}' AND id_prod_order_wo!='{1}'", TEWONumber.Text, id_wo)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPMatWO, TEWONumber, "1")
        Else
            EP_TE_cant_blank(EPMatWO, TEWONumber)
        End If
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        If id_wo <> "-1" Then
            Try
                TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged
        If id_wo <> "-1" Then
            Try
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Catch ex As Exception
                TEDueDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            Catch ex As Exception
                TEDueDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub LEpayment_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEpayment.EditValueChanged
        If LEpayment.EditValue = 1 Then
            TETOP.Enabled = True
        Else
            TETOP.Text = 0
            If id_wo <> "-1" Then
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Else
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            End If
            TETOP.Enabled = False
        End If
    End Sub

    Private Sub FormSamplePurchaseDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("total_cost").SummaryText.ToString)
            vat = (Decimal.Parse(TEVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total_cost").SummaryText.ToString)
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat

        gross_tot = sub_tot
        TEGrossTot.EditValue = gross_tot

        total = sub_tot + vat
        TETot.EditValue = total
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_wo
        FormReportMark.report_mark_type = "23"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        view_delivery(LESeason.EditValue, LEDelivery)
    End Sub

    Private Sub BPickWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpProdOVH.id_prod_demand_design = get_prod_order_x(id_po, "1")
        FormPopUpProdOVH.ShowDialog()
    End Sub
End Class