Public Class FormViewMatPR 
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"

    Private Sub FormSamplePRDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_report_status(LEReportStatus)
        Dim query As String = "SELECT z.pr_mat_purc_bill,z.pr_mat_purc_tax_inv,z.id_mat_purc_rec, z.pr_mat_purc_dp,z.pr_mat_purc_vat,z.id_pr_mat_purc,z.id_comp_contact_to,z.id_report_status,z.pr_mat_purc_number,z.pr_mat_purc_note,DATE_FORMAT(z.pr_mat_purc_date,'%Y-%m-%d') as pr_mat_purc_date,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%d %M %Y') AS mat_purc_rec_date,d.comp_name AS comp_to,b.id_mat_purc "
        query += "FROM tb_pr_mat_purc z "
        query += "LEFT JOIN tb_mat_purc_rec a ON z.id_mat_purc_rec = a.id_mat_purc_rec "
        query += "INNER JOIN tb_mat_purc b ON z.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=g0.id_season "
        query += "WHERE z.id_pr_mat_purc ='" & id_pr & "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPRNumber.Text = data.Rows(0)("pr_mat_purc_number").ToString
        TEPRDate.Text = view_date_from(data.Rows(0)("pr_mat_purc_date").ToString, 0)
        MENote.Text = data.Rows(0)("pr_mat_purc_note").ToString
        '
        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        '
        TEBillNumber.Text = data.Rows(0)("pr_mat_purc_bill").ToString
        TETextInvNumber.Text = data.Rows(0)("pr_mat_purc_tax_inv").ToString
        '
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("mat_purc_rec_number").ToString
        If data.Rows(0)("id_mat_purc_rec") <= 0 Then
            id_rec = "-1"
        Else
            id_rec = data.Rows(0)("id_mat_purc_rec")
        End If

        id_purc = data.Rows(0)("id_mat_purc").ToString
        view_po()

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        GConListPurchase.Enabled = True
        view_list_pr()

        TEVat.EditValue = data.Rows(0)("pr_mat_purc_vat")

        TEDPTot.EditValue = data.Rows(0)("pr_mat_purc_dp")

        calculate()

        If Not Decimal.Parse(data.Rows(0)("pr_mat_purc_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
            TEDP.EditValue = ((Decimal.Parse(data.Rows(0)("pr_mat_purc_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
        End If

        BShowOrder.Enabled = False
        BPickPO.Enabled = False
    End Sub

    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowOrder.Click
        FormPopUpReceiveMat.id_pop_up = "1"
        FormPopUpReceiveMat.id_purc = id_purc
        FormPopUpReceiveMat.ShowDialog()
    End Sub

    Private Sub BPickContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickContact.Click
        FormPopUpContact.id_pop_up = "6"
        FormPopUpContact.ShowDialog()
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_pr_mat_from_po('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_pr()
        Dim query = "CALL view_pr_mat_from_pr('" & id_pr & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_mat_from_rec('" & id_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT a.id_report_status, a.mat_purc_vat, b.id_season, a.mat_purc_number, a.id_comp_contact_to, a.id_comp_contact_ship_to, a.id_po_type, a.id_payment,DATE_FORMAT(a.mat_purc_date,'%Y-%m-%d') as mat_purc_datex, a.mat_purc_lead_time, a.mat_purc_top, a.id_currency, a.mat_purc_note,a.mat_purc_kurs FROM tb_mat_purc a INNER JOIN tb_season_delivery b ON a.id_delivery = b.id_delivery WHERE a.id_mat_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("mat_purc_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        TEKurs.EditValue = data.Rows(0)("mat_purc_kurs")

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        TEDueDate.Text = view_date_from(data.Rows(0)("mat_purc_datex").ToString, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))
        TEVat.EditValue = data.Rows(0)("mat_purc_vat")
    End Sub

    Sub view_rec()
        Dim query As String = "SELECT d.id_mat_purc,a.id_mat_purc_rec, a.mat_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.mat_purc_rec_date, "
        query += "(SELECT COUNT(tb_pr_mat_purc.id_pr_mat_purc) FROM tb_pr_mat_purc WHERE tb_pr_mat_purc.id_mat_purc_rec = a.id_mat_purc_rec) AS pr_created, "
        query += "a.mat_purc_rec_note, c.comp_name, c.comp_number,e.season, a.id_comp_contact_to  "
        query += "FROM tb_mat_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_mat_purc d on a.id_mat_purc = d.id_mat_purc "
        query += "INNER JOIN tb_season_delivery e0 ON e0.id_delivery = d.id_delivery "
        query += "INNER JOIN tb_season e ON e.id_season = e0.id_season "
        query += "WHERE a.id_mat_purc_rec = '" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TERecNumber.Text = data.Rows(0)("mat_purc_rec_number").ToString
        id_purc = data.Rows(0)("id_mat_purc").ToString
        TEPONumber.Text = data.Rows(0)("mat_purc_rec_number").ToString
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

            TEDPTot.EditValue = Decimal.Parse(dp.ToString("N2"))

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
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
        If e.Column.FieldName = "debit" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
    End Sub

    Private Sub FormSamplePRDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpPurchaseMat.id_purc = id_purc
        FormPopUpPurchaseMat.id_pop_up = "3"
        FormPopUpPurchaseMat.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If id_pr = "-1" Then
            FormPopUpPRComponentMat.id_purc = id_purc
            FormPopUpPRComponentMat.id_rec = id_rec
            FormPopUpPRComponentMat.ShowDialog()
        Else
            FormPopUpPRComponentMat.id_pr = id_pr
            FormPopUpPRComponentMat.id_purc = id_purc
            FormPopUpPRComponentMat.id_rec = id_rec
            FormPopUpPRComponentMat.ShowDialog()
        End If
    End Sub

    Sub show_but()
        'If GVListPurchase.RowCount < 1 Then
        '    BEdit.Visible = False
        '    Bdel.Visible = False
        'Else
        '    BEdit.Visible = True
        '    Bdel.Visible = True
        'End If
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If id_pr = "-1" Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                GVListPurchase.DeleteSelectedRows()
                calculate_dp()
                calculate()
            End If
        Else
            Dim confirm As DialogResult
            Dim query As String
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            Dim id_pr_mat_purc_det As String = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_mat_purc_det").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc_det = '{0}'", id_pr_mat_purc_det)
                    execute_non_query(query, True, "", "", "", "")
                    view_list_pr()
                    calculate_dp()
                    calculate()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("This list item can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If

        show_but()
    End Sub

    Private Sub TEDP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDP.EditValueChanged
        calculate()
    End Sub

    Sub calculate_dp()
        ' Dim dp, gross_tot As Decimal

        ' calculate()

        '
        ' calculate()
    End Sub

    Private Sub TEDPTot_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDPTot.EditValueChanged
        calculate()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If id_pr = "-1" Then
            FormPopUpPRComponentMat.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentMat.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentMat.id_purc = id_purc
            FormPopUpPRComponentMat.id_rec = id_rec

            FormPopUpPRComponentMat.ShowDialog()
        Else
            FormPopUpPRComponentMat.id_pr = id_pr
            FormPopUpPRComponentMat.id_pr_det = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_mat_purc_det").ToString
            FormPopUpPRComponentMat.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentMat.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentMat.id_purc = id_purc
            FormPopUpPRComponentMat.id_rec = id_rec

            FormPopUpPRComponentMat.ShowDialog()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "24"
        FormReportMark.ShowDialog()
    End Sub
    Sub allow_status()
        'If LEReportStatus.EditValue = "3" Or LEReportStatus.EditValue = "4" Or LEReportStatus.EditValue = "6" Or LEReportStatus.EditValue = "7" Then
        '    BPrint.Enabled = True
        '    BSave.Enabled = False
        '    '
        '    BEdit.Enabled = False
        '    BAdd.Enabled = False
        '    Bdel.Enabled = False
        'Else
        '    BPrint.Enabled = False
        '    BSave.Enabled = True
        '    '
        '    BEdit.Enabled = True
        '    BAdd.Enabled = True
        '    Bdel.Enabled = True
        'End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pr
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "24"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class