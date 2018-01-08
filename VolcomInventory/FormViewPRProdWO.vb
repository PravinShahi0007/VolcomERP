Public Class FormViewPRProdWO 
    Public id_rec As String = "-1"
    Public id_prod_order_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"
    '
    Public is_po_pr As String = "-1"
    '
    Private Sub FormViewPRProdWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_report_status(LEReportStatus)

        '
        Dim query_po As String = "SELECT IF(ISNULL(id_prod_order),IF(ISNULL(id_prod_order_wo),3,1),2) as penanda FROM tb_pr_prod_order WHERE id_pr_prod_order ='" & id_pr & "'"
        Dim data_po As DataTable = execute_query(query_po, -1, True, "", "", "", "")

        If data_po.Rows(0)("penanda") = "1" Then 'wo
            Dim query As String = "SELECT z.bof_no,z.inv_no,z.tax_inv_no,z.pr_prod_order_aju,z.pr_prod_order_pib,z.id_prod_order_wo,z.pr_prod_order_vat,z.pr_prod_order_dp,z.id_comp_contact_to,po.id_prod_order,po.prod_order_number,IFNULL(z.id_prod_order_rec,0) as id_prod_order_rec,l.overhead, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,DATE_FORMAT(rec.delivery_order_date,'%Y-%m-%d') AS delivery_order_date,rec.delivery_order_number,wo.prod_order_wo_number,DATE_FORMAT(rec.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date, d.comp_name AS comp_to, "
            query += "z.id_currency,DATE_FORMAT(DATE_ADD(wo.prod_order_wo_date,INTERVAL (wo.prod_order_wo_top+wo.prod_order_wo_lead_time) DAY),'%Y-%m-%d') AS prod_order_wo_top,z.pr_prod_order_due_date "
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
            '
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEBOFNo.Text = data.Rows(0)("bof_no").ToString
            TEInvNo.Text = data.Rows(0)("inv_no").ToString
            TETaxInvNo.Text = data.Rows(0)("tax_inv_no").ToString
            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEPRNumber.Text = data.Rows(0)("pr_prod_order_number").ToString
            DEPRDate.EditValue = data.Rows(0)("pr_prod_order_date")
            MENote.Text = data.Rows(0)("pr_prod_order_note").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
            TERecNumber.Text = data.Rows(0)("prod_order_rec_number").ToString
            If data.Rows(0)("id_prod_order_rec") <= 0 Then
                id_rec = "-1"
            Else
                id_rec = data.Rows(0)("id_prod_order_rec")
            End If

            id_prod_order_wo = data.Rows(0)("id_prod_order_wo").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            view_wo()

            id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
            MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

            GConListPurchase.Enabled = True
            view_list_pr()

            view_currency(LECurrency)
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            LECurrency.Enabled = False

            TEVat.EditValue = data.Rows(0)("pr_prod_order_vat")

            TEDPTot.EditValue = data.Rows(0)("pr_prod_order_dp")

            TEPIB.Text = data.Rows(0)("pr_prod_order_pib").ToString
            TEAju.Text = data.Rows(0)("pr_prod_order_aju").ToString

            calculate()

            DEDueDate.EditValue = data.Rows(0)("pr_prod_order_due_date")

            If Not Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
                TEDP.EditValue = ((Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
            End If
        ElseIf data_po.Rows(0)("penanda") = "2" Then 'po
            LWOCaption.Text = "PO Number"
            LRecCaption.Visible = False
            TERecNumber.Visible = False
            '
            TEPONumber.Visible = False
            LFGPOCaption.Visible = False
            '
            LDOCaption.Visible = False
            TEDONumber.Visible = False

            Dim query As String = "SELECT z.bof_no,z.inv_no,z.tax_inv_no,z.pr_prod_order_aju,z.pr_prod_order_pib,z.id_prod_order_wo,z.pr_prod_order_vat,z.pr_prod_order_dp,z.id_comp_contact_to,po.id_prod_order,po.prod_order_number,
                                        IFNULL(z.id_prod_order_rec,0) AS id_prod_order_rec, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,
                                        DATE_FORMAT(rec.delivery_order_date,'%Y-%m-%d') AS delivery_order_date,rec.delivery_order_number,z.id_currency,
                                        DATE_FORMAT(rec.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date, d.comp_name AS comp_to, 
                                        z.pr_prod_order_due_date 
                                        FROM tb_pr_prod_order z 
                                        INNER JOIN tb_prod_order po ON po.id_prod_order = z.id_prod_order 
                                        LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec 
                                        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to 
                                        INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp 
                                        INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status 
                                        WHERE z.id_pr_prod_order ='" & id_pr & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEBOFNo.Text = data.Rows(0)("bof_no").ToString
            TEInvNo.Text = data.Rows(0)("inv_no").ToString
            TETaxInvNo.Text = data.Rows(0)("tax_inv_no").ToString
            TEWOPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEPRNumber.Text = data.Rows(0)("pr_prod_order_number").ToString
            DEPRDate.EditValue = data.Rows(0)("pr_prod_order_date")
            MENote.Text = data.Rows(0)("pr_prod_order_note").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            '
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            '
            id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
            MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")
            '
            GConListPurchase.Enabled = True
            view_list_pr()
            '
            view_currency(LECurrency)
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            LECurrency.Enabled = False
            '
            TEVat.EditValue = data.Rows(0)("pr_prod_order_vat")

            TEDPTot.EditValue = data.Rows(0)("pr_prod_order_dp")

            TEPIB.Text = data.Rows(0)("pr_prod_order_pib").ToString
            TEAju.Text = data.Rows(0)("pr_prod_order_aju").ToString

            'add due date
            DEDueDate.EditValue = data.Rows(0)("pr_prod_order_due_date")
            '
            calculate()

            If Not Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
                TEDP.EditValue = ((Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
            End If
        ElseIf data_po.Rows(0)("penanda") = "3" Then 'no reff
            LWOCaption.Visible = False
            TEWOPONumber.Visible = False

            LRecCaption.Visible = False
            TERecNumber.Visible = False
            '
            TEPONumber.Visible = False
            LFGPOCaption.Visible = False
            '
            LDOCaption.Visible = False
            TEDONumber.Visible = False

            Dim query As String = "SELECT z.bof_no,z.inv_no,z.tax_inv_no,z.pr_prod_order_aju,z.pr_prod_order_pib,z.id_prod_order_wo,z.pr_prod_order_vat,z.pr_prod_order_dp,z.id_comp_contact_to,
                                        IFNULL(z.id_prod_order_rec,0) AS id_prod_order_rec, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,
                                        d.comp_name AS comp_to, 
                                        z.pr_prod_order_due_date ,z.id_currency
                                        FROM tb_pr_prod_order z 
                                        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to 
                                        INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp 
                                        INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status 
                                        WHERE z.id_pr_prod_order ='" & id_pr & "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEBOFNo.Text = data.Rows(0)("bof_no").ToString
            TEInvNo.Text = data.Rows(0)("inv_no").ToString
            TETaxInvNo.Text = data.Rows(0)("tax_inv_no").ToString
            TEPRNumber.Text = data.Rows(0)("pr_prod_order_number").ToString
            DEPRDate.EditValue = data.Rows(0)("pr_prod_order_date")
            MENote.Text = data.Rows(0)("pr_prod_order_note").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            '
            id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
            MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")
            '
            GConListPurchase.Enabled = True
            view_list_pr()
            '
            view_currency(LECurrency)
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            LECurrency.Enabled = False
            '
            TEVat.EditValue = data.Rows(0)("pr_prod_order_vat")

            TEDPTot.EditValue = data.Rows(0)("pr_prod_order_dp")

            TEPIB.Text = data.Rows(0)("pr_prod_order_pib").ToString
            TEAju.Text = data.Rows(0)("pr_prod_order_aju").ToString

            'add due date
            DEDueDate.EditValue = data.Rows(0)("pr_prod_order_due_date")
            '
            calculate()

            If Not Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
                TEDP.EditValue = ((Decimal.Parse(data.Rows(0)("pr_prod_order_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
            End If
        End If
        '
    End Sub
    Sub view_list_wo()
        Dim query = "CALL view_pr_prod_from_wo('" & id_prod_order_wo & "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_pr()
        Dim query = "CALL view_pr_prod_from_pr('" & id_pr & "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_prod_from_rec('" & id_prod_order_wo & "','" & id_rec & "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_wo()
        Dim query As String = String.Format("SELECT a.id_report_status, a.prod_order_wo_vat, a.prod_order_wo_number, b.id_comp_contact, DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex, a.prod_order_wo_lead_time, a.prod_order_wo_top, b.id_currency, a.prod_order_wo_note FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price WHERE a.id_prod_order_wo = '{0}'", id_prod_order_wo)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEWOPONumber.Text = data.Rows(0)("prod_order_wo_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "3")

        'TEDueDate.Text = view_date_from(data.Rows(0)("prod_order_wo_datex").ToString, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))
        TEVat.EditValue = data.Rows(0)("prod_order_wo_vat")
    End Sub

    Sub view_rec()
        Dim query As String = "SELECT d.id_prod_order,a.id_prod_order_rec, a.prod_order_rec_number, a.delivery_order_number,  a.delivery_order_date, a.prod_order_rec_date, "
        'query += "(SELECT COUNT(tb_pr_prod_order.id_pr_prod_order) FROM tb_pr_prod_order WHERE tb_pr_prod_order.id_prod_order_rec = a.id_prod_order_rec) AS pr_created, "
        query += "a.prod_order_rec_note, c.comp_name, c.comp_number, a.id_comp_contact_to  "
        query += "FROM tb_prod_order_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_prod_order d on a.id_prod_order = d.id_prod_order "
        query += "WHERE a.id_prod_order_rec = '" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TERecNumber.Text = data.Rows(0)("prod_order_rec_number").ToString
        id_prod_order = data.Rows(0)("id_prod_order").ToString
        TEWOPONumber.Text = data.Rows(0)("prod_order_rec_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TECompTo.Text = data.Rows(0)("comp_name").ToString
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
        Dim tot_credit, tot_debit, total, gross_tot, vat, dp As Decimal

        Try
            tot_credit = Decimal.Parse(GVListPurchase.Columns("total").SummaryItem.SummaryValue)
            tot_debit = Decimal.Parse(GVListPurchase.Columns("debit").SummaryItem.SummaryValue)
            'MsgBox("1-" & tot_credit.ToString)
            'MsgBox("2-" & tot_debit.ToString)
            gross_tot = tot_credit - tot_debit
            dp = (Decimal.Parse(TEDP.EditValue) / 100) * gross_tot

            TEDPTot.EditValue = Decimal.Parse(dp.ToString("N4"))

            dp = Decimal.Parse(TEDPTot.EditValue)
            'MsgBox("3-" & dp.ToString)

            If dp <= 0 Or dp.ToString = "" Then
                vat = (Decimal.Parse(TEVat.EditValue) / 100) * gross_tot
            Else
                vat = (Decimal.Parse(TEVat.EditValue) / 100) * dp
            End If
            'MsgBox("4-" & vat.ToString)
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat
        TEDPTot.EditValue = dp
        TEGrossTot.EditValue = gross_tot

        If dp.ToString = "" Or dp = 0 Or dp = 0.0 Then
            total = gross_tot + vat
        Else
            total = dp + vat
        End If

        TETot.EditValue = total
        ' MsgBox("5-" & total.ToString)
        Try
            METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
        Catch ex As Exception
        End Try

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

    Private Sub FormSamplePRDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "50"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.id_report = id_pr
        FormDocumentUpload.report_mark_type = "50"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub TEDP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDP.EditValueChanged
        calculate()
    End Sub

    Private Sub BViewPIB_Click(sender As Object, e As EventArgs) Handles BViewPIB.Click
        FormViewPRProdWOPIB.Text = FormViewPRProdWOPIB.Text & " PIB : " & TEPIB.Text
        FormViewPRProdWOPIB.pib_number = TEPIB.Text
        FormViewPRProdWOPIB.ShowDialog()
    End Sub
End Class