Public Class FormMatPRWODet 
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"

    Private Sub FormSamplePRDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccess(Name)
        If id_purc = "-1" Then
            view_currency(LECurrency)
        Else
            view_po()
            view_list_purchase()
            GConListPurchase.Enabled = True
        End If

        If Not id_rec = "-1" Then
            view_rec()
            view_po()
            view_list_rec()
            GConListPurchase.Enabled = True
            'MsgBox("Rec")
        End If

        view_report_status(LEReportStatus)

        If id_pr = "-1" Then
            'new
            TEPRDate.Text = view_date(0)
            TEPRNumber.Text = header_number_mat("8")
            BPrint.Visible = False
            BMark.Visible = False
            TEGrossTot.EditValue = 0.0
            TEDPTot.EditValue = 0.0
            TEVatTot.EditValue = 0.0
            TETot.EditValue = 0.0
            calculate()
        Else
            'edit
            Dim query As String = "SELECT z.pr_mat_wo_bill,z.pr_mat_wo_tax_inv,z.id_mat_wo_rec, z.pr_mat_wo_dp,z.pr_mat_wo_vat,z.id_pr_mat_wo,z.id_comp_contact_to,z.id_report_status,z.pr_mat_wo_number,z.pr_mat_wo_note,DATE_FORMAT(z.pr_mat_wo_date,'%Y-%m-%d') as pr_mat_wo_date,g.season,a.id_mat_wo_rec,a.mat_wo_rec_number,a.delivery_order_number,b.mat_wo_number,DATE_FORMAT(a.mat_wo_rec_date,'%d %M %Y') AS mat_wo_rec_date,d.comp_name AS comp_to,b.id_mat_wo "
            query += "FROM tb_pr_mat_wo z "
            query += "LEFT JOIN tb_mat_wo_rec a ON z.id_mat_wo_rec = a.id_mat_wo_rec "
            query += "INNER JOIN tb_mat_wo b ON z.id_mat_wo=b.id_mat_wo "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
            query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
            query += "INNER JOIN tb_season g ON g.id_season=g0.id_season "
            query += "WHERE z.id_pr_mat_wo ='" & id_pr & "' "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPRNumber.Text = data.Rows(0)("pr_mat_wo_number").ToString
            TEPRDate.Text = view_date_from(data.Rows(0)("pr_mat_wo_date").ToString, 0)
            MENote.Text = data.Rows(0)("pr_mat_wo_note").ToString
            '
            TEBillNumber.Text = data.Rows(0)("pr_mat_wo_bill").ToString
            TETextInvNumber.Text = data.Rows(0)("pr_mat_wo_tax_inv").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
            TERecNumber.Text = data.Rows(0)("mat_wo_rec_number").ToString
            If data.Rows(0)("id_mat_wo_rec") <= 0 Then
                id_rec = "-1"
            Else
                id_rec = data.Rows(0)("id_mat_wo_rec")
            End If

            id_purc = data.Rows(0)("id_mat_wo").ToString
            view_po()

            id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
            MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

            GConListPurchase.Enabled = True
            view_list_pr()

            TEVat.EditValue = data.Rows(0)("pr_mat_wo_vat")

            TEDPTot.EditValue = data.Rows(0)("pr_mat_wo_dp")

            calculate()

            If Not Decimal.Parse(data.Rows(0)("pr_mat_wo_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
                TEDP.EditValue = ((Decimal.Parse(data.Rows(0)("pr_mat_wo_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
            End If

            BShowOrder.Enabled = False
            BPickPO.Enabled = False
        End If
        allow_status()
        allow_rec()
    End Sub
    Sub refreshData()
        GCListPurchase.RefreshDataSource()
        GVListPurchase.RefreshData()
    End Sub

    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowOrder.Click
        FormPopUpReceiveWOMat.id_pop_up = "1"
        FormPopUpReceiveWOMat.id_purc = id_purc
        FormPopUpReceiveWOMat.ShowDialog()
    End Sub

    Private Sub BPickContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickContact.Click
        'wut the f
        FormPopUpContact.id_pop_up = "6"
        FormPopUpContact.ShowDialog()
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_pr_mat_wo_from_wo('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_pr()
        Dim query = "CALL view_pr_mat_wo_from_pr('" & id_pr & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_mat_wo_from_rec('" & id_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT xc.overhead, a.id_report_status, a.mat_wo_vat, b.id_season, a.mat_wo_number, a.id_comp_contact_to, a.id_comp_contact_ship_to , a.id_payment,DATE_FORMAT(a.mat_wo_date,'%Y-%m-%d') as mat_wo_datex, a.mat_wo_lead_time, a.mat_wo_top, a.id_currency, a.mat_wo_note, a.mat_wo_kurs FROM tb_mat_wo a INNER JOIN tb_season_delivery b ON a.id_delivery = b.id_delivery INNER JOIN tb_m_ovh xc ON a.id_ovh = xc.id_ovh WHERE a.id_mat_wo = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("mat_wo_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        TEKurs.EditValue = data.Rows(0)("mat_wo_kurs")

        TEOVH.Text = data.Rows(0)("overhead").ToString
        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        TEDueDate.Text = view_date_from(data.Rows(0)("mat_wo_datex").ToString, (Integer.Parse(data.Rows(0)("mat_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_wo_top").ToString)))
        TEVat.EditValue = data.Rows(0)("mat_wo_vat")
    End Sub

    Sub view_rec()
        Dim query As String = "SELECT d.id_mat_wo,a.id_mat_wo_rec, a.mat_wo_rec_number, a.delivery_order_number,  a.delivery_order_date, a.mat_wo_rec_date, "
        query += "(SELECT COUNT(tb_pr_mat_wo.id_pr_mat_wo) FROM tb_pr_mat_wo WHERE tb_pr_mat_wo.id_mat_wo_rec = a.id_mat_wo_rec) AS pr_created, "
        query += "a.mat_wo_rec_note, c.comp_name, c.comp_number,e.season, a.id_comp_contact_to  "
        query += "FROM tb_mat_wo_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_mat_wo d on a.id_mat_wo = d.id_mat_wo "
        query += "INNER JOIN tb_season_delivery e0 ON e0.id_delivery = d.id_delivery "
        query += "INNER JOIN tb_season e ON e.id_season = e0.id_season "
        query += "WHERE a.id_mat_wo_rec = '" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TERecNumber.Text = data.Rows(0)("mat_wo_rec_number").ToString
        id_purc = data.Rows(0)("id_mat_wo").ToString
        TEPONumber.Text = data.Rows(0)("mat_wo_rec_number").ToString
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
        GVListPurchase.RefreshData()
        GCListPurchase.Refresh()
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

    Private Sub TEPRNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPRNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_pr_mat_wo) FROM tb_pr_mat_wo WHERE pr_mat_wo_number='{0}' AND id_pr_mat_wo!='{1}'", TEPRNumber.Text, id_pr)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePR, TEPRNumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePR, TEPRNumber)
        End If
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpWOMat.id_wo = id_purc
        FormPopUpWOMat.id_pop_up = "2"
        FormPopUpWOMat.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        If id_pr = "-1" Then
            FormPopUpPRComponentMatWO.id_purc = id_purc
            FormPopUpPRComponentMatWO.id_rec = id_rec
            FormPopUpPRComponentMatWO.ShowDialog()
        Else
            FormPopUpPRComponentMatWO.id_pr = id_pr
            FormPopUpPRComponentMatWO.id_purc = id_purc
            FormPopUpPRComponentMatWO.id_rec = id_rec
            FormPopUpPRComponentMatWO.ShowDialog()
        End If
    End Sub

    Sub show_but()
        If GVListPurchase.RowCount < 1 Then
            BEdit.Visible = False
            Bdel.Visible = False
        Else
            BEdit.Visible = True
            Bdel.Visible = True
        End If
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
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

            Dim id_pr_mat_wo_det As String = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_mat_wo_det").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_pr_mat_wo_det WHERE id_pr_mat_wo_det = '{0}'", id_pr_mat_wo_det)
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

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim pr_number, pr_date, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, id_dc, pr_bill, pr_tax_inv As String
        Dim id_pr_new As String = ""

        pr_number = ""
        pr_date = ""
        pr_note = ""
        pr_stats = ""
        pr_vat = ""
        pr_dp = ""
        pr_tot = ""
        pr_bill = ""
        pr_tax_inv = ""
        'validasi
        Try
            pr_number = TEPRNumber.Text
            pr_date = TEPRDate.Text
            pr_note = MENote.Text
            pr_stats = LEReportStatus.EditValue.ToString
            'MsgBox(TEDPTot.EditValue.ToString)
            pr_vat = decimalSQL(TEVat.EditValue)
            pr_dp = decimalSQL(TEDPTot.EditValue)
            pr_tot = decimalSQL(TETot.EditValue)
            pr_bill = TEBillNumber.Text
            pr_tax_inv = TETextInvNumber.Text
            'MsgBox(TEDPTot.EditValue.ToString("N2"))
            'MsgBox(pr_tot)
        Catch ex As Exception
            err_txt = "1"
        End Try

        For i As Integer = 0 To GVListPurchase.RowCount - 1
            Try
                If GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                    err_txt = "1"
                End If
            Catch ex As Exception
            End Try
        Next

        'end of validasi
        If id_pr = "-1" Then
            'new
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    'insert pr
                    query = String.Format("INSERT INTO tb_pr_mat_wo(id_mat_wo, id_mat_wo_rec, pr_mat_wo_number, pr_mat_wo_date, pr_mat_wo_note, id_report_status, pr_mat_wo_vat, pr_mat_wo_dp, pr_mat_wo_total,id_comp_contact_to,pr_mat_wo_bill,pr_mat_wo_tax_inv) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", id_purc, id_rec, pr_number, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, id_comp_contact_pay_to, pr_bill, pr_tax_inv)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = "SELECT LAST_INSERT_ID()"
                    id_pr_new = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("25", id_pr_new, id_user)
                    'end insert who prepared
                    '
                    increase_inc_mat("8")
                    'pr detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                                If GVListPurchase.GetRowCellValue(i, "total").ToString = "" Or GVListPurchase.GetRowCellValue(i, "total").ToString = "0" Then
                                    id_dc = 1
                                Else
                                    id_dc = 2
                                End If

                                If GVListPurchase.GetRowCellValue(i, "type").ToString = "1" Then
                                    'dp
                                    query = String.Format("INSERT INTO tb_pr_mat_wo_det(id_pr_mat_wo,id_pr_det_type,id_pr_mat_wo_dp,pr_mat_wo_det_note,pr_mat_wo_det_price,pr_mat_wo_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("INSERT INTO tb_pr_mat_wo_det(id_pr_mat_wo,id_pr_det_type,id_mat_wo_det,pr_mat_wo_det_note,pr_mat_wo_det_price,pr_mat_wo_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("INSERT INTO tb_pr_mat_wo_det(id_pr_mat_wo,id_pr_det_type,id_ovh,pr_mat_wo_det_note,pr_mat_wo_det_price,pr_mat_wo_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    Next

                    FormMatPRWO.view_mat_pr()
                    FormMatPRWO.view_mat_wo()
                    FormMatPRWO.view_mat_rec()
                    FormMatPRWO.GVMatPRWO.FocusedRowHandle = find_row(FormMatPRWO.GVMatPRWO, "id_pr_mat_wo", id_pr_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            'edit
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    'update pr
                    query = String.Format("UPDATE tb_pr_mat_wo SET pr_mat_wo_number='{0}',pr_mat_wo_note='{1}',id_report_status='{2}',pr_mat_wo_vat='{4}',pr_mat_wo_dp='{5}',pr_mat_wo_total='{6}',id_comp_contact_to='{7}',pr_mat_wo_bill='{8}',pr_mat_wo_tax_inv='{9}' WHERE id_pr_mat_wo='{3}'", pr_number, pr_note, pr_stats, id_pr, pr_vat, pr_dp, pr_tot, id_comp_contact_pay_to, pr_bill, pr_tax_inv)
                    execute_non_query(query, True, "", "", "", "")
                    'pr detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                                query = String.Format("UPDATE tb_pr_mat_wo_det SET pr_mat_wo_det_note='{0}',pr_mat_wo_det_qty='{2}' WHERE id_pr_mat_wo_det='{1}'", GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_pr_mat_wo_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString))
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    FormMatPRWO.view_mat_pr()
                    FormMatPRWO.view_mat_wo()
                    FormMatPRWO.view_mat_rec()
                    FormMatPRWO.GVMatPRWO.FocusedRowHandle = find_row(FormMatPRWO.GVMatPRWO, "id_pr_mat_wo", id_pr)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
        'FormMatPR.XTCTabPR.SelectedTabPageIndex = 0
        Cursor = Cursors.Default
    End Sub

    Private Sub TEDPTot_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDPTot.EditValueChanged
        calculate()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        If id_pr = "-1" Then
            FormPopUpPRComponentMatWO.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentMatWO.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentMatWO.id_purc = id_purc
            FormPopUpPRComponentMatWO.id_rec = id_rec

            FormPopUpPRComponentMatWO.ShowDialog()
        Else
            FormPopUpPRComponentMatWO.id_pr = id_pr
            FormPopUpPRComponentMatWO.id_pr_det = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_mat_wo_det").ToString
            FormPopUpPRComponentMatWO.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentMatWO.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentMatWO.id_purc = id_purc
            FormPopUpPRComponentMatWO.id_rec = id_rec

            FormPopUpPRComponentMatWO.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatPRWO.id_pr = id_pr

        Dim Report As New ReportMatPRWO()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.form_origin = Name
        FormReportMark.report_mark_type = "25"
        FormReportMark.ShowDialog()
    End Sub
    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue.ToString, "25", id_pr) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            TEVat.Properties.ReadOnly = False
            TEVatTot.Properties.ReadOnly = False
            TEDP.Properties.ReadOnly = False
            TEDPTot.Properties.ReadOnly = False
            ColQtyRec.ColumnEdit.ReadOnly = False
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            TEVat.Properties.ReadOnly = True
            TEVatTot.Properties.ReadOnly = True
            TEDP.Properties.ReadOnly = True
            TEDPTot.Properties.ReadOnly = True
            ColQtyRec.ColumnEdit.ReadOnly = True
        End If

        If check_print_report_status(LEReportStatus.EditValue.ToString) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Sub allow_rec()
        If id_pr = "-1" Then
            'MsgBox(id_purc)
            If id_purc <> "-1" Then
                BShowOrder.Enabled = True
            Else
                BShowOrder.Enabled = False
            End If
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pr
        FormDocumentUpload.report_mark_type = "25"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVListPurchase_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListPurchase.HiddenEditor
        calculate()
        calculate_grid()
    End Sub
    Sub calculate_grid()
        If GVListPurchase.RowCount > 0 Then
            For i As Integer = 0 To GVListPurchase.RowCount - 1
                If GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                    Dim tot As Decimal = 0.0
                    tot = GVListPurchase.GetRowCellValue(i, "qty") * GVListPurchase.GetRowCellValue(i, "price")
                    GVListPurchase.SetRowCellValue(i, "total", tot)
                End If
            Next
            GCListPurchase.RefreshDataSource()
            GVListPurchase.RefreshData()
        End If
    End Sub

    Private Sub GVListPurchase_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListPurchase.ShownEditor
        If GVListPurchase.RowCount > 0 Then
            If GVListPurchase.GetFocusedRowCellValue("type").ToString = "2" Then
                ColQtyRec.ColumnEdit.ReadOnly = False
            Else
                ColQtyRec.ColumnEdit.ReadOnly = True
            End If
        End If
    End Sub
End Class