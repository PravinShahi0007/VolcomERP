Public Class FormMatInvoiceDet
    Public id_invoice As String = "-1"
    Public id_prod_order_wo As String = "-1"
    'Public id_pl As String = "-1"
    Public id_comp_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"

    Private Sub BPickPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickWO.Click
        FormPopUpWOProdMat.id_pop_up = "2"
        FormPopUpWOProdMat.ShowDialog()
    End Sub

    Private Sub FormMatInvoiceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_report_status(LEReportStatus)

        If id_invoice = "-1" Then
            'new
            BPickWO.Enabled = True
            BMark.Enabled = False

            TEInvNumber.Text = header_number_mat(12)
            TEDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            load_invoice()
            If Not id_prod_order_wo = "-1" Then
                'from PL
                Dim query As String = "SELECT a.id_currency,a.id_prod_order_wo ,m.design_name,k.prod_order_number,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
                query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,j.prod_order_wo_number, "
                query += "DATE_FORMAT(a.pl_mrs_date,'%d %M %Y') AS pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
                query += "INNER JOIN tb_prod_order_wo j ON a.id_prod_order_wo = j.id_prod_order_wo "
                query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
                query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
                query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
                query += "WHERE NOT ISNULL(i.id_prod_order) AND a.id_pl_mrs='" & id_prod_order_wo & "'"
                query += "ORDER BY a.id_pl_mrs DESC "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                TEWONumber.Text = data.Rows(0)("prod_order_wo_number").ToString
                TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
                TEDesign.Text = data.Rows(0)("design_name").ToString

                id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
                TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
                TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
                MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")

                LECurrency.EditValue = Nothing
                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

                GConListPurchase.Enabled = True
                '
                'load_pl()
                calculate()
            End If
        Else
            'edit
            BMark.Enabled = True

            Dim query As String = "SELECT inv.id_inv_pl_mrs,inv.inv_pl_mrs_number, inv.id_comp_contact_to, inv.id_report_status, "
            query += "DATE_FORMAT(inv.inv_pl_mrs_date,'%Y-%m-%d') AS inv_pl_mrs_datex, "
            query += "inv.inv_pl_mrs_top , inv.id_report_status, inv.id_currency,inv.inv_pl_mrs_note,inv.inv_pl_mrs_vat "
            query += "FROM tb_inv_pl_mrs inv "
            query += "WHERE inv.id_inv_pl_mrs='" & id_invoice & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status_g = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")

            TEInvNumber.Text = data.Rows(0)("inv_pl_mrs_number").ToString
            MENote.Text = data.Rows(0)("inv_pl_mrs_note").ToString
            TEVat.EditValue = data.Rows(0)("inv_pl_mrs_vat")

            date_created = data.Rows(0)("inv_pl_mrs_datex").ToString
            TEDate.Text = view_date_from(date_created, 0)
            TETOP.EditValue = data.Rows(0)("inv_pl_mrs_top")
            TEDueDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("inv_pl_mrs_top").ToString))

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            GConListPurchase.Enabled = True
            BPickWO.Enabled = False
            '
            load_invoice()
            calculate()
        End If
        view_all_pl()
        allow_status()
        check_but()
    End Sub
    Sub view_all_pl()
        Dim query As String = "CALL view_inv_all_pl('" + id_invoice + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPL.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        '
    End Sub
    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged
        If id_invoice <> "-1" Then
            Try
                TEDueDate.Text = view_date_from(date_created, Integer.Parse(TETOP.Text))
            Catch ex As Exception
                TEDueDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TEDueDate.Text = view_date(Integer.Parse(TETOP.Text))
            Catch ex As Exception
                TEDueDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Sub load_invoice()
        Dim query As String = "CALL view_inv_mat('" + id_invoice + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        ''
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
        Dim total, gross_tot, vat As Decimal

        Try
            gross_tot = Decimal.Parse(GVListPurchase.Columns("total_price").SummaryItem.SummaryValue)
            vat = (Decimal.Parse(TEVat.EditValue) / 100) * gross_tot
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat
        TEGrossTot.EditValue = gross_tot
        total = gross_tot + vat

        TETot.EditValue = total
        Try
            METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""

        ValidateChildren()
        If id_invoice = "-1" Then 'new
            If id_prod_order_wo = "-1" Or id_comp_to = "-1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    query = String.Format("INSERT INTO tb_inv_pl_mrs(id_prod_order_wo,inv_pl_mrs_number,id_comp_contact_to,inv_pl_mrs_date,inv_pl_mrs_vat,inv_pl_mrs_top,inv_pl_mrs_note,id_currency) VALUES('{0}','{1}','{2}',NOW(),'{3}','{4}','{5}','{6}');SELECT LAST_INSERT_ID(); ", id_prod_order_wo, TEInvNumber.Text, id_comp_to, decimalSQL(TEVat.EditValue.ToString), TETOP.EditValue.ToString, MENote.Text, LECurrency.EditValue.ToString)

                    id_invoice = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("34", id_invoice, id_user)
                    'end insert who prepared
                    '
                    increase_inc_mat(12)

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString = "" Then
                            query = String.Format("INSERT INTO tb_inv_pl_mrs_det(id_inv_pl_mrs,id_pl_mrs_det,inv_pl_mrs_det_price,inv_pl_mrs_det_qty,inv_pl_mrs_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_invoice, GVListPurchase.GetRowCellValue(i, "id_pl_mrs_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    FormMatInvoice.viewInv()
                    FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs", id_invoice)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
                '
            End If
        Else 'edit
            If id_prod_order_wo = "-1" Or id_comp_to = "-1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    query = String.Format("UPDATE tb_inv_pl_mrs SET inv_pl_mrs_vat='{0}',inv_pl_mrs_top='{1}',inv_pl_mrs_note='{2}' WHERE id_inv_pl_mrs='{3}'", decimalSQL(TEVat.EditValue.ToString), TETOP.EditValue.ToString, MENote.Text, id_invoice)
                    execute_non_query(query, True, "", "", "", "")
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_inv_pl_mrs_det FROM tb_inv_pl_mrs_det WHERE id_inv_pl_mrs='" & id_invoice & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_inv_pl_mrs_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_inv_pl_mrs_det").ToString = data_del.Rows(i)("id_inv_pl_mrs_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_inv_pl_mrs_det WHERE id_inv_pl_mrs_det='{0}'", data_del.Rows(i)("id_inv_pl_mrs_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_pl_mrs_det").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_inv_pl_mrs_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_inv_pl_mrs_det(id_inv_pl_mrs,id_pl_mrs_det,inv_pl_mrs_det_price,inv_pl_mrs_det_qty,inv_pl_mrs_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_invoice, GVListPurchase.GetRowCellValue(i, "id_pl_mrs_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_inv_pl_mrs_det SET id_pl_mrs_det='{0}',inv_pl_mrs_det_price='{1}',inv_pl_mrs_det_qty='{2}',inv_pl_mrs_det_note='{3}' WHERE id_inv_pl_mrs_det='{4}'", GVListPurchase.GetRowCellValue(i, "id_pl_mrs_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), GVListPurchase.GetRowCellValue(i, "qty").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_inv_pl_mrs_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    '
                    FormMatInvoice.viewInv()
                    FormMatInvoice.GVProdInvoice.FocusedRowHandle = find_row(FormMatInvoice.GVProdInvoice, "id_inv_pl_mrs", id_invoice)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub TEInvNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEInvNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_inv_pl_mrs) FROM tb_inv_pl_mrs WHERE inv_pl_mrs_number='{0}' AND id_inv_pl_mrs!='{1}'", TEInvNumber.Text, id_invoice)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePR, TEInvNumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePR, TEInvNumber)
        End If
    End Sub

    Private Sub FormMatInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_invoice
        FormReportMark.report_mark_type = "34"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "34", id_invoice) Then
            BPickWO.Enabled = True
            TETOP.Properties.ReadOnly = False
            TEVat.Properties.ReadOnly = False
            BtnAdd.Enabled = True
            BtnDel.Enabled = True
            BSave.Enabled = True
        Else
            BPickWO.Enabled = False
            TETOP.Properties.ReadOnly = True
            TEVat.Properties.ReadOnly = True
            BtnAdd.Enabled = False
            BtnDel.Enabled = False
            BSave.Enabled = False
        End If

        If check_print_report_status(id_report_status_g) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatInvoice.id_invoice = id_invoice
        ReportMatInvoice.comp_to_name = TECompName.Text

        Dim Report As New ReportMatInvoice()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpMatPLInv.id_prod_wo = id_prod_order_wo
        FormPopUpMatPLInv.id_pop_up = "1"
        FormPopUpMatPLInv.ShowDialog()
    End Sub
    Sub check_but()
        If GVProdPL.RowCount > 0 Then
            BtnDel.Visible = True
        Else
            BtnDel.Visible = False
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this packing list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                For i As Integer = (GVListPurchase.RowCount - 1) To 0 Step -1
                    If GVListPurchase.GetRowCellValue(i, "id_pl_mrs").ToString = GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString Then
                        GVListPurchase.DeleteRow(i)
                    End If
                Next
                GVProdPL.DeleteSelectedRows()
                check_but()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This packing list can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class