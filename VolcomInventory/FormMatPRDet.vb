Public Class FormMatPRDet 
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
        End If

        view_report_status(LEReportStatus)

        If id_pr = "-1" Then
            'new
            TEPRDate.Text = view_date(0)
            TEPRNumber.Text = header_number_mat("7")
            BPrint.Visible = False
            BMark.Visible = False
            TEGrossTot.EditValue = 0.0
            TEDPTot.EditValue = 0.0
            TEVatTot.EditValue = 0.0
            TETot.EditValue = 0.0
        Else
            'edit
            Dim query As String = "SELECT z.pr_mat_purc_bill,z.pr_mat_purc_tax_inv,z.id_mat_purc_rec, z.pr_mat_purc_dp,z.pr_mat_purc_vat,z.id_pr_mat_purc,z.id_comp_contact_to,z.id_report_status,z.pr_mat_purc_number,z.pr_mat_purc_note,DATE_FORMAT(z.pr_mat_purc_date,'%Y-%m-%d') as pr_mat_purc_date,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%d %M %Y') AS mat_purc_rec_date,d.comp_name AS comp_to,b.id_mat_purc "
            query += ",z.pr_mat_purc_due_date "
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
            '
            DEDueDate.EditValue = data.Rows(0)("pr_mat_purc_due_date")
            '
            '
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

            'BShowOrder.Enabled = False
            BPickPO.Enabled = False
            BPickRec.Enabled = False
        End If
        allow_status()
    End Sub

    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpReceiveMat.id_pop_up = "1"
        FormPopUpReceiveMat.id_purc = id_purc
        FormPopUpReceiveMat.ShowDialog()
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
        Dim query As String = String.Format("SELECT a.id_report_status, a.mat_purc_vat, b.id_season, a.mat_purc_number, a.id_comp_contact_to, a.id_comp_contact_ship_to, a.id_po_type, a.id_payment,DATE_FORMAT(a.mat_purc_date,'%Y-%m-%d') as mat_purc_datex, a.mat_purc_lead_time, a.mat_purc_top, a.id_currency, a.mat_purc_note, a.mat_purc_kurs FROM tb_mat_purc a INNER JOIN tb_season_delivery b ON a.id_delivery = b.id_delivery WHERE a.id_mat_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEWONumber.Text = data.Rows(0)("mat_purc_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        TEkurs.EditValue = data.Rows(0)("mat_purc_kurs")

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        'DEDueDate.Text = view_date_from(data.Rows(0)("mat_purc_datex").ToString, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))
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
        TEWONumber.Text = data.Rows(0)("mat_purc_rec_number").ToString
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
            tot_credit = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            tot_debit = GVListPurchase.Columns("debit").SummaryItem.SummaryValue
            'MsgBox("1-" & tot_credit.ToString)
            'MsgBox("2-" & tot_debit.ToString)
            gross_tot = tot_credit - tot_debit
            dp = (TEDP.EditValue / 100) * gross_tot

            TEDPTot.EditValue = dp

            'MsgBox("3-" & dp.ToString)

            If dp <= 0 Or dp.ToString = "" Then
                vat = (TEVat.EditValue / 100) * gross_tot
            Else
                vat = (TEVat.EditValue / 100) * dp
            End If
            'MsgBox("4-" & vat.ToString)
        Catch ex As Exception
            ex.ToString()
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

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpPurchaseMat.id_purc = id_purc
        FormPopUpPurchaseMat.id_pop_up = "3"
        FormPopUpPurchaseMat.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
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
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim pr_number, pr_date, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, id_dc, pr_tax_inv_number, pr_bill_number, pr_due_date As String
        Dim id_pr_new As String = ""

        pr_number = ""
        pr_date = ""
        pr_note = ""
        pr_stats = ""
        pr_vat = ""
        pr_dp = ""
        pr_tot = ""
        pr_tax_inv_number = ""
        pr_bill_number = ""
        pr_due_date = Now.ToString("yyy-MM-dd")
        'validasi
        Try
            pr_number = header_number_mat("7")

            pr_date = TEPRDate.Text
            pr_note = MENote.Text
            pr_stats = LEReportStatus.EditValue.ToString
            pr_vat = decimalSQL(TEVat.EditValue)
            pr_dp = decimalSQL(TEDPTot.EditValue)
            pr_tot = decimalSQL(TETot.EditValue)
            pr_bill_number = TEBillNumber.Text
            pr_tax_inv_number = TETextInvNumber.Text
            pr_due_date = DateTime.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd")
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
                    query = String.Format("INSERT INTO tb_pr_mat_purc(id_mat_purc, id_mat_purc_rec, pr_mat_purc_number, pr_mat_purc_date, pr_mat_purc_note, id_report_status, pr_mat_purc_vat, pr_mat_purc_dp, pr_mat_purc_total,id_comp_contact_to,pr_mat_purc_bill,pr_mat_purc_tax_inv,pr_mat_purc_due_date) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID(); ", id_purc, id_rec, pr_number, pr_note, pr_stats, pr_vat, pr_dp, pr_tot, id_comp_contact_pay_to, pr_bill_number, pr_tax_inv_number, pr_due_date)

                    id_pr_new = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("24", id_pr_new, id_user)
                    'end insert who prepared
                    '
                    increase_inc_mat("7")
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
                                    query = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_pr_mat_purc_dp,pr_mat_purc_det_note,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_mat_purc_det,pr_mat_purc_det_note,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("INSERT INTO tb_pr_mat_purc_det(id_pr_mat_purc,id_pr_det_type,id_ovh,pr_mat_purc_det_note,pr_mat_purc_det_price,pr_mat_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    Next

                    FormMatPR.view_mat_pr()
                    FormMatPR.view_mat_purc()
                    FormMatPR.view_mat_rec()
                    FormMatPR.GVMatPR.FocusedRowHandle = find_row(FormMatPR.GVMatPR, "id_pr_mat_purc", id_pr_new)
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
                    query = String.Format("UPDATE tb_pr_mat_purc SET pr_mat_purc_note='{1}',id_report_status='{2}',pr_mat_purc_vat='{4}',pr_mat_purc_dp='{5}',pr_mat_purc_total='{6}',id_comp_contact_to='{7}',pr_mat_purc_bill='{8}',pr_mat_purc_tax_inv='{9}',pr_mat_purc_due_date='{10}' WHERE id_pr_mat_purc='{3}'", pr_number, pr_note, pr_stats, id_pr, pr_vat, pr_dp, pr_tot, id_comp_contact_pay_to, pr_bill_number, pr_tax_inv_number, pr_due_date)
                    execute_non_query(query, True, "", "", "", "")
                    'pr detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                                query = String.Format("UPDATE tb_pr_mat_purc_det SET pr_mat_purc_det_note='{0}',pr_mat_purc_det_qty='{2}' WHERE id_pr_mat_purc_det='{1}'", GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_pr_mat_purc_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString))
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    FormMatPR.view_mat_pr()
                    FormMatPR.view_mat_purc()
                    FormMatPR.view_mat_rec()
                    FormMatPR.GVMatPR.FocusedRowHandle = find_row(FormMatPR.GVMatPR, "id_pr_mat_purc", id_pr)
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

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatPR.id_pr = id_pr

        Dim Report As New ReportMatPR()
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
        FormReportMark.report_mark_type = "24"
        FormReportMark.ShowDialog()
    End Sub
    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue.ToString, "24", id_pr) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            ColQtyRec.ColumnEdit.ReadOnly = False
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            ColQtyRec.ColumnEdit.ReadOnly = True
        End If

        If check_print_report_status(LEReportStatus.EditValue.ToString) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Private Sub BPickRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickRec.Click
        If id_purc = "-1" Then
            stopCustom("Please choose PO first.")
        Else
            FormPopUpReceiveMat.id_pop_up = "1"
            FormPopUpReceiveMat.id_purc = id_purc
            FormPopUpReceiveMat.ShowDialog()
        End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pr
        FormDocumentUpload.report_mark_type = "24"
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