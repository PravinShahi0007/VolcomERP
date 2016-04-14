Public Class FormMatInvoiceReturDet 
    Public id_retur As String = "-1"
    Public id_invoice As String = "-1"
    Public id_prod_wo As String = "-1"
    Public id_comp_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"

    Private Sub BPickPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickInvoice.Click
        FormPopUpMatInvoice.id_pop_up = "1"
        FormPopUpMatInvoice.ShowDialog()
    End Sub

    Private Sub FormMatInvoiceDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_report_status(LEReportStatus)

        If id_retur = "-1" Then
            'new
            BPickInvoice.Enabled = True
            TEReturNumber.Text = header_number_mat(13)
            TEDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            load_retur()
            If Not id_invoice = "-1" Then
                'from invoice
                Dim query As String = "SELECT a.id_pl_mrs,inv.id_comp_contact_to,inv.id_inv_pl_mrs,inv.inv_pl_mrs_number, inv.id_comp_contact_to, inv.id_report_status,m.design_name,k.prod_order_number,j.prod_order_wo_number, "
                query += "(f.comp_name) AS comp_name_to,inv.id_report_status,j.prod_order_wo_number,i.prod_order_mrs_number,DATE_FORMAT(inv.inv_pl_mrs_date,'%Y-%m-%d') AS inv_pl_mrs_datex, "
                query += "inv.inv_pl_mrs_top , inv.id_report_status, inv.id_currency,inv.inv_pl_mrs_note,inv.inv_pl_mrs_vat "
                query += "FROM tb_inv_pl_mrs inv "
                query += "INNER JOIN tb_m_comp_contact e ON inv.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_prod_order_wo j ON inv.id_prod_order_wo = j.id_prod_order_wo "
                query += "INNER JOIN tb_prod_order k ON j.id_prod_order = k.id_prod_order "
                query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
                query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
                query += "WHERE inv.id_inv_pl_mrs='" & id_invoice & "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                TEInvNumber.Text = data.Rows(0)("inv_pl_mrs_number").ToString

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
            End If
        Else
            'edit
            Dim query As String = "SELECT inv.id_inv_pl_mrs_ret,inv.inv_pl_mrs_ret_number, inv.id_comp_contact_from, "
            query += "DATE_FORMAT(inv.inv_pl_mrs_ret_date,'%Y-%m-%d') AS inv_pl_mrs_ret_datex, "
            query += "inv.inv_pl_mrs_ret_top , inv.id_report_status, inv.id_currency,inv.inv_pl_mrs_ret_note,inv.inv_pl_mrs_ret_vat "
            query += "FROM tb_inv_pl_mrs_ret inv "
            query += "WHERE inv.id_inv_pl_mrs_ret='" & id_retur & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status_g = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")

            MENote.Text = data.Rows(0)("inv_pl_mrs_ret_note").ToString
            TEVat.EditValue = data.Rows(0)("inv_pl_mrs_ret_vat")

            date_created = data.Rows(0)("inv_pl_mrs_ret_datex").ToString
            TEDate.Text = view_date_from(date_created, 0)
            TETOP.EditValue = data.Rows(0)("inv_pl_mrs_ret_top")
            TEDueDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("inv_pl_mrs_ret_top").ToString))

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            GConListPurchase.Enabled = True
            BPickInvoice.Enabled = False
            '
            load_retur()
            calculate()
        End If
        view_all_ret()
        check_but()
        allow_status()
    End Sub
    Sub check_but()
        If GVRetInProd.RowCount > 0 Then
            BtnDel.Visible = True
        Else
            BtnDel.Visible = False
        End If
    End Sub
    Sub view_all_ret()
        Dim query As String = "CALL view_inv_all_ret('" + id_retur + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetInProd.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
        ''
    End Sub
    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged
        If id_retur <> "-1" Then
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
    Sub load_retur()
        Dim query As String = "CALL view_inv_mat_retur('" + id_retur + "')"
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
        If id_retur = "-1" Then 'new
            If id_invoice = "-1" Or id_comp_to = "-1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    query = String.Format("INSERT INTO tb_inv_pl_mrs_ret(id_inv_pl_mrs,inv_pl_mrs_ret_number,id_comp_contact_from,inv_pl_mrs_ret_date,inv_pl_mrs_ret_vat,inv_pl_mrs_ret_top,inv_pl_mrs_ret_note,id_currency) VALUES('{0}','{1}','{2}',NOW(),'{3}','{4}','{5}','{6}')", id_invoice, TEReturNumber.Text, id_comp_to, decimalSQL(TEVat.EditValue.ToString), TETOP.EditValue.ToString, MENote.Text, LECurrency.EditValue.ToString)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    query = "SELECT LAST_INSERT_ID()"
                    id_retur = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("35", id_retur, id_user)
                    'end insert who prepared
                    '
                    increase_inc_mat(13)

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString = "" Then
                            query = String.Format("INSERT INTO tb_inv_pl_mrs_ret_det(id_inv_pl_mrs_ret,id_mat_prod_ret_in_det,inv_pl_mrs_ret_det_price,inv_pl_mrs_ret_det_qty,inv_pl_mrs_ret_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_retur, GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), GVListPurchase.GetRowCellValue(i, "inv_pl_mrs_ret_det_qty").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                Catch ex As Exception
                    errorConnection()
                End Try
                '
                FormMatInvoice.view_retur()
                FormMatInvoice.GVRetur.FocusedRowHandle = find_row(FormMatInvoice.GVRetur, "id_inv_pl_mrs_ret", id_retur)
                Close()
            End If
        Else 'edit
            If id_invoice = "-1" Or id_comp_to = "-1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    query = String.Format("UPDATE tb_inv_pl_mrs_ret SET inv_pl_mrs_ret_vat='{0}',inv_pl_mrs_ret_top='{1}',inv_pl_mrs_ret_note='{2}' WHERE id_inv_pl_mrs_ret='{3}'", decimalSQL(TEVat.EditValue.ToString), TETOP.EditValue.ToString, MENote.Text, id_retur)
                    execute_non_query(query, True, "", "", "", "")
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_inv_pl_mrs_ret_det FROM tb_inv_pl_mrs_ret_det WHERE id_inv_pl_mrs_ret='" & id_retur & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_inv_pl_mrs_ret_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_inv_pl_mrs_ret_det").ToString = data_del.Rows(i)("id_inv_pl_mrs_ret_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_inv_pl_mrs_ret_det WHERE id_inv_pl_mrs_ret_det='{0}'", data_del.Rows(i)("id_inv_pl_mrs_ret_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_inv_pl_mrs_ret_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_inv_pl_mrs_ret_det(id_inv_pl_mrs_ret,id_mat_prod_ret_in_det,inv_pl_mrs_ret_det_price,inv_pl_mrs_ret_det_qty,inv_pl_mrs_ret_det_note) VALUES('{0}','{1}','{2}','{3}','{4}')", id_retur, GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "inv_pl_mrs_ret_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_inv_pl_mrs_ret_det SET id_mat_prod_ret_in_det='{0}',inv_pl_mrs_ret_det_price='{1}',inv_pl_mrs_ret_det_qty='{2}',inv_pl_mrs_ret_det_note='{3}' WHERE id_inv_pl_mrs_ret_det='{4}'", GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in_det").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "inv_pl_mrs_ret_det_qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_inv_pl_mrs_ret_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    '
                    FormMatInvoice.view_retur()
                    FormMatInvoice.GVRetur.FocusedRowHandle = find_row(FormMatInvoice.GVRetur, "id_inv_pl_mrs_ret", id_retur)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub TEInvNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEInvNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_inv_pl_mrs_ret) FROM tb_inv_pl_mrs_ret WHERE inv_pl_mrs_ret_number='{0}' AND id_inv_pl_mrs_ret!='{1}'", TEReturNumber.Text, id_retur)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePR, TEReturNumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePR, TEReturNumber)
        End If
    End Sub

    Private Sub FormMatInvoiceDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_retur
        FormReportMark.report_mark_type = "35"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "35", id_retur) Then
            'BPickInvoice.Enabled = True
            TETOP.Properties.ReadOnly = False
            TEVat.Properties.ReadOnly = False
            BSave.Enabled = True
        Else
            'BPickInvoice.Enabled = False
            TETOP.Properties.ReadOnly = True
            TEVat.Properties.ReadOnly = True
            BSave.Enabled = False
        End If

        If check_print_report_status(id_report_status_g) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportMatInvoiceRetur.id_retur = id_retur
        ReportMatInvoiceRetur.comp_to_name = TECompName.Text

        Dim Report As New ReportMatInvoiceRetur()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
    Private Sub RepositoryItemSpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        Try
            Dim sqty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_limit As Decimal = CType(GVListPurchase.GetFocusedRowCellDisplayText("qty").ToString, Decimal)
            Dim price As Decimal = CType(GVListPurchase.GetFocusedRowCellDisplayText("price").ToString, Decimal)
            Dim qty_rec As Decimal = CType(sqty.EditValue.ToString, Decimal)
            If (qty_rec > qty_limit) Then
                DevExpress.XtraEditors.XtraMessageBox.Show("- Qty retur must be smaller than qty invoiced or equal to qty invoiced !" + System.Environment.NewLine + "- Not allowed character input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim qty_bound As Decimal = qty_rec - 1
                If qty_bound < 0 Then
                    qty_bound = 0
                End If
                Dim total_price As Decimal = qty_limit * price
                GVListPurchase.SetFocusedRowCellValue("inv_pl_mrs_ret_det_qty", qty_limit.ToString)
                GVListPurchase.SetFocusedRowCellValue("total_price", total_price)
                GVListPurchase.UpdateTotalSummary()
                calculate()
            Else
                Dim total_price As Decimal = qty_rec * price
                GVListPurchase.SetFocusedRowCellValue("total_price", total_price)
                GVListPurchase.UpdateTotalSummary()
                calculate()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpMatRetInv.id_prod_wo = id_prod_wo
        FormPopUpMatRetInv.id_pop_up = "1"
        FormPopUpMatRetInv.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this return from list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                For i As Integer = (GVListPurchase.RowCount - 1) To 0 Step -1
                    If GVListPurchase.GetRowCellValue(i, "id_mat_prod_ret_in").ToString = GVRetInProd.GetFocusedRowCellValue("id_mat_prod_ret_in").ToString Then
                        GVListPurchase.DeleteRow(i)
                    End If
                Next
                GVRetInProd.DeleteSelectedRows()
                check_but()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This return can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class