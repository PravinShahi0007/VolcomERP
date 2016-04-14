Public Class FormViewMatWO
    Public id_purc As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"
    Public id_wo_type As String = "-1"

    Private Sub FormViewMatWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_wo_type(LEWOType)
        viewSeason(LESeason)
        'view delivery
        view_payment_type(LEpayment)

        Dim query As String = String.Format("SELECT b.id_mat_wo_rev as id_mat_wo_rev,IFNULL(b.mat_wo_number,'-') as mat_wo_number_rev,a.id_ovh,a.mat_wo_kurs,a.id_report_status,a.mat_wo_vat,a.id_delivery,a.mat_wo_number,a.id_comp_contact_to,a.id_comp_contact_ship_to,a.id_payment,DATE_FORMAT(a.mat_wo_date,'%Y-%m-%d') as mat_wo_datex,a.mat_wo_lead_time,a.mat_wo_top,a.id_currency,a.mat_wo_note" _
                                                 & " FROM tb_mat_wo a " _
                                                 & " LEFT JOIN tb_mat_wo b ON a.id_mat_wo_rev=b.id_mat_wo " _
                                                 & " WHERE a.id_mat_wo = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString
        TEKurs.Text = data.Rows(0)("mat_wo_kurs").ToString

        TEWORevNumber.Text = data.Rows(0)("mat_wo_number_rev").ToString

        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEpayment.EditValue = Nothing
        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        id_report_status_g = data.Rows(0)("id_report_status").ToString

        LESeason.EditValue = get_id_season(data.Rows(0)("id_delivery").ToString)
        LEDelivery.EditValue = data.Rows(0)("id_delivery").ToString

        LEWOType.EditValue = data.Rows(0)("id_ovh").ToString()
        id_wo_type = LEWOType.EditValue.ToString

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        MENote.Text = data.Rows(0)("mat_wo_note").ToString

        date_created = data.Rows(0)("mat_wo_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TELeadTime.Text = data.Rows(0)("mat_wo_lead_time").ToString
        TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString))
        TETOP.Text = data.Rows(0)("mat_wo_top").ToString
        TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_wo_top").ToString)))
        '
        GConListPurchase.Enabled = True
        TEVat.Properties.ReadOnly = False
        view_list_purchase()
        view_list_mat()
        TEVat.Text = data.Rows(0)("mat_wo_vat").ToString
        calculate()
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

    Sub view_list_purchase()
        Dim query = "CALL view_mat_wo_det('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        calculate()
    End Sub
    Sub view_list_purchase_ext(ByVal ext As String)
        Dim query = "CALL view_mat_wo_det('" & ext & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        calculate()
    End Sub
    Sub view_list_mat()
        Dim query = "CALL view_mat_wo_mat('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaterial.DataSource = data
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

    Private Sub FormViewMatWO_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            vat = (Decimal.Parse(TEVat.Text) / 100) * Decimal.Parse(GVListPurchase.Columns("total").SummaryText.ToString)
            discount = Decimal.Parse(GVListPurchase.Columns("discount").SummaryText.ToString)
        Catch ex As Exception
        End Try

        TEDiscount.Text = discount.ToString("0.00")
        TEVatTot.Text = vat.ToString("0.00")

        gross_tot = sub_tot + discount
        TEGrossTot.Text = gross_tot.ToString("0.00")

        total = sub_tot + vat
        TETot.Text = total.ToString("0.00")
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_purc
        FormReportMark.report_mark_type = "15"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListMat_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMaterial.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_purc
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "15"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class