Public Class FormProdPRWODet
    Public id_rec As String = "-1"
    Public id_prod_order_wo As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"
    Public id_report_status As String = "-1"
    Private Sub FormSamplePRDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEKurs.EditValue = 0.0
        If id_prod_order_wo = "-1" Then 'there is wo
            view_currency(LECurrency)
        Else
            If Not id_rec = "-1" Then 'there is rec
                view_rec()
                view_wo()
                view_list_rec()
            Else
                view_wo()
                view_list_wo()
            End If
            GConListPurchase.Enabled = True
        End If

        view_report_status(LEReportStatus)

        If id_pr = "-1" Then 'new
            DEPRDate.EditValue = Now
            TEPRNumber.Text = header_number_prod("9")
            BPrint.Visible = False
            BMark.Visible = False
            TEGrossTot.EditValue = 0.0
            TEDPTot.EditValue = 0.0
            TEVatTot.EditValue = 0.0
            TETot.EditValue = 0.0
            id_report_status = 1
        Else 'editpr_prod_order_date
            Dim query As String = "SELECT z.pr_prod_order_aju,z.pr_prod_order_pib,z.id_prod_order_wo,z.pr_prod_order_vat,z.pr_prod_order_dp,z.id_comp_contact_to,po.id_prod_order,po.prod_order_number,IFNULL(z.id_prod_order_rec,0) as id_prod_order_rec,l.overhead, z.id_report_status,h.report_status,z.pr_prod_order_note,z.id_pr_prod_order,z.pr_prod_order_number,z.pr_prod_order_date,rec.id_prod_order_rec,rec.prod_order_rec_number,DATE_FORMAT(rec.delivery_order_date,'%Y-%m-%d') AS delivery_order_date,rec.delivery_order_number,wo.prod_order_wo_number,DATE_FORMAT(rec.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date, d.comp_name AS comp_to, "
            query += "DATE_FORMAT(DATE_ADD(wo.prod_order_wo_date,INTERVAL (wo.prod_order_wo_top+wo.prod_order_wo_lead_time) DAY),'%Y-%m-%d') AS prod_order_wo_top,z.pr_prod_order_due_date "
            query += "FROM tb_pr_prod_order z "
            query += "INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo = z.id_prod_order_wo "
            query += "INNER JOIN tb_prod_order po ON po.id_prod_order = wo.id_prod_order "
            query += "LEFT JOIN tb_prod_order_rec rec ON z.id_prod_order_rec = rec.id_prod_order_rec "
            query += "INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price "
            query += "INNER JOIN tb_m_ovh l ON ovh_p.id_ovh = l.id_ovh "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
            query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
            query += "WHERE z.id_pr_prod_order ='" & id_pr & "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEPRNumber.Text = data.Rows(0)("pr_prod_order_number").ToString
            DEPRDate.EditValue = data.Rows(0)("pr_prod_order_date")
            MENote.Text = data.Rows(0)("pr_prod_order_note").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
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
            BPickRec.Enabled = False
            BPickWO.Enabled = False
        End If

        allow_status()
    End Sub

    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickRec.Click
        FormPopUpRecQC.id_pop_up = "1"
        FormPopUpRecQC.id_prod_order = id_prod_order
        FormPopUpRecQC.id_rec = id_rec
        FormPopUpRecQC.ShowDialog()
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
        Dim query As String = String.Format("SELECT a.id_report_status, a.prod_order_wo_vat, a.prod_order_wo_number, b.id_comp_contact, DATE_FORMAT(a.prod_order_wo_date,'%Y-%m-%d') as prod_order_wo_datex, a.prod_order_wo_lead_time, a.prod_order_wo_top, a.id_currency, a.prod_order_wo_note, a.prod_order_wo_kurs FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price WHERE a.id_prod_order_wo = '{0}'", id_prod_order_wo)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        TEKurs.EditValue = data.Rows(0)("prod_order_wo_kurs")

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact").ToString), "3")

        'TEDueDate.Text = view_date_from(data.Rows(0)("prod_order_wo_datex").ToString, (Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString)))

        DEDueDate.EditValue = Date.Parse(data.Rows(0)("prod_order_wo_datex")).AddDays(Integer.Parse(data.Rows(0)("prod_order_wo_lead_time").ToString) + Integer.Parse(data.Rows(0)("prod_order_wo_top").ToString))

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
        TEWONumber.Text = data.Rows(0)("prod_order_rec_number").ToString
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

    Private Sub TEPRNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPRNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_pr_mat_purc) FROM tb_pr_mat_purc WHERE pr_mat_purc_number='{0}' AND id_pr_mat_purc!='{1}'", TEPRNumber.Text, id_pr)
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

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickWO.Click
        FormPopUpWOProd.id_prod_order = id_prod_order
        FormPopUpWOProd.id_wo = id_prod_order_wo
        FormPopUpWOProd.id_popup = "2"
        FormPopUpWOProd.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        If id_pr = "-1" Then
            FormPopUpPRComponentProd.id_wo = id_prod_order_wo
            FormPopUpPRComponentProd.id_rec = id_rec
            FormPopUpPRComponentProd.ShowDialog()
        Else
            FormPopUpPRComponentProd.id_pr = id_pr
            FormPopUpPRComponentProd.id_wo = id_prod_order_wo
            FormPopUpPRComponentProd.id_rec = id_rec
            FormPopUpPRComponentProd.ShowDialog()
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
        'If id_pr = "-1" Then
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVListPurchase.DeleteSelectedRows()
            calculate()
        End If
        'Else
        'Dim confirm As DialogResult
        'Dim query As String
        'confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        'Dim id_pr_mat_purc_det As String = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_mat_purc_det").ToString
        'If confirm = Windows.Forms.DialogResult.Yes Then
        '    Cursor = Cursors.WaitCursor
        '    Try
        '        query = String.Format("DELETE FROM tb_pr_mat_purc_det WHERE id_pr_mat_purc_det = '{0}'", id_pr_mat_purc_det)
        '        execute_non_query(query, True, "", "", "", "")
        '        view_list_pr()
        '        calculate()
        '    Catch ex As Exception
        '        DevExpress.XtraEditors.XtraMessageBox.Show("This list item can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        '    Cursor = Cursors.Default
        'End If
        'End If

        show_but()
    End Sub

    Private Sub TEDP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDP.EditValueChanged
        calculate()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim pr_number, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, id_dc, pib, aju As String
        Dim id_pr_new As String = ""
        Dim due_date As Date
        pr_number = ""
        pr_note = ""
        pr_stats = ""
        pr_vat = ""
        pr_dp = ""
        pr_tot = ""
        pib = ""
        aju = ""
        due_date = Now
        'validasi
        Try
            pr_number = TEPRNumber.Text
            pr_note = MENote.Text
            pr_stats = LEReportStatus.EditValue.ToString
            pr_vat = decimalSQL(TEVat.EditValue)
            pr_dp = decimalSQL(TEDPTot.EditValue)
            pr_tot = decimalSQL(TETot.EditValue)
            pib = TEPIB.Text
            aju = TEAju.Text
            due_date = DEDueDate.EditValue
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
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Or id_prod_order_wo = "-1" Then
                errorInput()
            Else
                Try
                    'insert pr
                    If id_rec = "-1" Then
                        query = String.Format("INSERT INTO tb_pr_prod_order(id_prod_order_wo, pr_prod_order_number, pr_prod_order_date, pr_prod_order_note, id_report_status, pr_prod_order_vat, pr_prod_order_dp, pr_prod_order_total, id_currency,id_comp_contact_to,pr_prod_order_pib,pr_prod_order_aju,pr_prod_order_due_date) VALUES('{0}','{1}',DATE(NOW()),'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID(); ", id_prod_order_wo, pr_number, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, LECurrency.EditValue, id_comp_contact_pay_to, pib, aju, Date.Parse(due_date.ToString).ToString("yyyy-MM-dd"))
                    Else
                        query = String.Format("INSERT INTO tb_pr_prod_order(id_prod_order_wo, id_prod_order_rec, pr_prod_order_number, pr_prod_order_date, pr_prod_order_note, id_report_status, pr_prod_order_vat, pr_prod_order_dp, pr_prod_order_total, id_currency,id_comp_contact_to,pr_prod_order_pib,pr_prod_order_aju) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID(); ", id_prod_order_wo, id_rec, pr_number, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, LECurrency.EditValue, id_comp_contact_pay_to, pib, aju)
                    End If

                    id_pr_new = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("50", id_pr_new, id_user)
                    'end insert who prepared
                    '
                    increase_inc_prod("9")
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
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_pr_prod_order_dp,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_prod_order_wo_det,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_ovh,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    Next

                    FormProdPRWO.view_pr()
                    FormProdPRWO.GVMatPR.FocusedRowHandle = find_row(FormProdPRWO.GVMatPR, "id_pr_prod_order", id_pr_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            'edit
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Or id_prod_order_wo = "-1" Then
                errorInput()
            Else
                'Try
                'update pr
                query = String.Format("UPDATE tb_pr_prod_order SET pr_prod_order_number='{0}',pr_prod_order_note='{1}',id_report_status='{2}',pr_prod_order_vat='{4}',pr_prod_order_dp='{5}',pr_prod_order_total='{6}',id_comp_contact_to='{7}',pr_prod_order_pib='{8}',pr_prod_order_aju='{9}',pr_prod_order_due_date='{10}' WHERE id_pr_prod_order='{3}'", pr_number, pr_note, pr_stats, id_pr, pr_vat, pr_dp, pr_tot, id_comp_contact_pay_to, pib, aju, Date.Parse(due_date.ToString).ToString("yyyy-MM-dd"))
                execute_non_query(query, True, "", "", "", "")
                    'pr detail
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_pr_prod_order_det FROM tb_pr_prod_order_det WHERE id_pr_prod_order='" & id_pr & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_pr_prod_order_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_pr_prod_order_det").ToString = data_del.Rows(i)("id_pr_prod_order_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_pr_prod_order_det WHERE id_pr_prod_order_det='{0}'", data_del.Rows(i)("id_pr_prod_order_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_pr_prod_order_det").ToString = "" Then
                                'insert new
                                If GVListPurchase.GetRowCellValue(i, "total").ToString = "" Or GVListPurchase.GetRowCellValue(i, "total").ToString = "0" Then
                                    id_dc = 1
                                Else
                                    id_dc = 2
                                End If
                                If GVListPurchase.GetRowCellValue(i, "type").ToString = "1" Then
                                    'dp
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_pr_prod_order_dp,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_prod_order_wo_det,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("INSERT INTO tb_pr_prod_order_det(id_pr_prod_order,id_pr_det_type,id_ovh,pr_prod_order_det_note,pr_prod_order_det_price,pr_prod_order_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Else
                                'update
                                If GVListPurchase.GetRowCellValue(i, "total").ToString = "" Or GVListPurchase.GetRowCellValue(i, "total").ToString = "0" Then
                                    id_dc = 1
                                Else
                                    id_dc = 2
                                End If
                                If GVListPurchase.GetRowCellValue(i, "type").ToString = "1" Then
                                    'dp
                                    query = String.Format("UPDATE tb_pr_prod_order_det SET id_pr_det_type='{0}',id_pr_prod_order_dp='{1}',id_prod_order_wo_det=NULL,id_ovh=NULL,pr_prod_order_det_note='{2}',pr_prod_order_det_price='{3}',pr_prod_order_det_qty='{4}',id_dc='{5}' WHERE id_pr_prod_order_det='{6}'", GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc, GVListPurchase.GetRowCellValue(i, "id_pr_prod_order_det").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("UPDATE tb_pr_prod_order_det SET id_pr_det_type='{0}',id_pr_prod_order_dp=NULL,id_prod_order_wo_det='{1}',id_ovh=NULL,pr_prod_order_det_note='{2}',pr_prod_order_det_price='{3}',pr_prod_order_det_qty='{4}',id_dc='{5}' WHERE id_pr_prod_order_det='{6}'", GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc, GVListPurchase.GetRowCellValue(i, "id_pr_prod_order_det").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("UPDATE tb_pr_prod_order_det SET id_pr_det_type='{0}',id_pr_prod_order_dp=NULL,id_prod_order_wo_det=NULL,id_ovh='{1}',pr_prod_order_det_note='{2}',pr_prod_order_det_price='{3}',pr_prod_order_det_qty='{4}',id_dc='{5}' WHERE id_pr_prod_order_det='{6}'", GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc, GVListPurchase.GetRowCellValue(i, "id_pr_prod_order_det").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        End If
                    Next

                    FormProdPRWO.view_pr()
                    FormProdPRWO.check_but()
                    FormProdPRWO.GVMatPR.FocusedRowHandle = find_row(FormProdPRWO.GVMatPR, "id_pr_prod_order", id_pr)
                    Close()
                'Catch ex As Exception
                'errorConnection()
                'End Try
            End If
        End If
        FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0
        Cursor = Cursors.Default
    End Sub

    Private Sub TEDPTot_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDPTot.EditValueChanged
        calculate()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        If id_pr = "-1" Then
            FormPopUpPRComponentProd.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentProd.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentProd.id_wo = id_prod_order_wo
            FormPopUpPRComponentProd.id_rec = id_rec

            FormPopUpPRComponentProd.ShowDialog()
        Else
            FormPopUpPRComponentProd.id_pr = id_pr
            FormPopUpPRComponentProd.id_pr_det = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_prod_order_det").ToString
            FormPopUpPRComponentProd.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponentProd.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponentProd.id_wo = id_prod_order_wo
            FormPopUpPRComponentProd.id_rec = id_rec

            FormPopUpPRComponentProd.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportProdPRWO.id_pr = id_pr
        ReportProdPRWO.id_rec = id_rec
        ReportProdPRWO.id_prod_order = id_prod_order
        ReportProdPRWO.id_prod_order_wo = id_prod_order_wo

        Dim Report As New ReportProdPRWO()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.report_mark_type = "50"
        FormReportMark.ShowDialog()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "24", id_pr) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

End Class