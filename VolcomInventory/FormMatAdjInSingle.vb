Public Class FormMatAdjInSingle 
    Public id_adj_in_mat As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormMatAdjInSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtAdjDate.Text = view_date(0)
            TxtAdjNumber.Text = header_number_mat("9")
            BMark.Enabled = False
            BAttach.Enabled = False
            BtnPrint.Enabled = False
            viewDetailReturn()
        ElseIf action = "upd" Then
            BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_in_mat_date, '%Y-%m-%d') AS adj_in_mat_datex FROM tb_adj_in_mat a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_in_mat = '" + id_adj_in_mat + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ''tampung ke form
            id_adj_in_mat = data.Rows(0)("id_adj_in_mat").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_in_mat_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_in_mat_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_in_mat_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If check_edit_report_status(id_report_status, "26", id_adj_in_mat) Then
                BMark.Enabled = True
                BAttach.Enabled = True
                BtnSave.Enabled = True
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = False
            Else
                BMark.Enabled = True
                BAttach.Enabled = True
                BtnSave.Enabled = False
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = True
            End If

            If check_print_report_status(id_report_status) Then
                BtnPrint.Enabled = True
            Else
                BtnPrint.Enabled = False
            End If

            'Fetch db detail
            viewDetailReturn()

            'get Total
            total_amount = Double.Parse(GVDetail.Columns("adj_in_mat_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        End If
        check_but()
    End Sub

    Sub check_but()
        If GVDetail.RowCount > 0 Then
            BtnDel.Visible = True
            BtnEdit.Visible = True
        Else
            BtnDel.Visible = False
            BtnEdit.Visible = False
        End If
    End Sub

    Sub viewReportStatus()
        'MsgBox("Aewww")
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCurrency()
        Dim id_currency_default As String = execute_query("SELECT id_currency_default FROM tb_opt LIMIT 1", 0, True, "", "", "", "")
        Dim query As String = "SELECT * FROM tb_lookup_currency WHERE id_currency = '" + id_currency_default + "' ORDER BY id_currency ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub FormMatAdjInSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        If action = "ins" Then
            query += "CALL view_mat_adj_in('" + id_adj_in_mat + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
        Else
            query += "CALL view_mat_adj_in('" + id_adj_in_mat + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
        End If
        'GVDetail.Columns("id_mat_det").GroupIndex = 0
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDetail.FocusedColumn = GVDetail.VisibleColumns(0)
        GVDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVDetail.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
        cantEdit()
    End Sub

    Sub cantEdit()
        Dim id_mat_det_curr As String = ""
        Dim id_drawer_curr As String = ""
        Try
            'id_mat_det_curr = GVDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString()
            id_drawer_curr = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString()
        Catch ex As Exception

        End Try
        If GVDetail.RowCount < 1 Or id_drawer_curr = "" Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, "26", id_adj_in_mat) Or action = "ins" Then
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
            End If
        End If
    End Sub

    Private Sub LECurrency_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LECurrency.Validating
        EP_LE_cant_blank(EPAdj, LECurrency)
    End Sub

    Private Sub LEReportStatus_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LEReportStatus.Validating
        EP_LE_cant_blank(EPAdj, LEReportStatus)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPopUpMatAdjIn.id_wh = "-1"
        FormPopUpMatAdjIn.id_pop_up = "1"
        FormPopUpMatAdjIn.action = "ins"
        If action = "ins" Then
            FormPopUpMatAdjIn.id_adj_x_mat_det = "0"
        Else
            FormPopUpMatAdjIn.id_adj_x_mat_det = "-1"
        End If
        FormPopUpMatAdjIn.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        confirm = "Are you sure to delete this data?"
        If (MessageBox.Show(confirm, "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        deleteRows()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_wh_locator_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_wh_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_comp").ToString
        Dim id_mat_det_edit As String = GVDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Dim id_mat_det_price As String = GVDetail.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
        Dim qty As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_mat_det_qty")
        Dim remark As String = GVDetail.GetFocusedRowCellDisplayText("adj_in_mat_det_note").ToString
        Dim id_adj_in_mat_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_in_mat_det").ToString
        Dim price As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_mat_det_price")
        FormPopUpMatAdjIn.id_pop_up = "1"
        FormPopUpMatAdjIn.id_mat_det_price_edit = id_mat_det_price
        FormPopUpMatAdjIn.indeks_edit = GVDetail.FocusedRowHandle
        FormPopUpMatAdjIn.id_mat_det_edit = id_mat_det_edit
        FormPopUpMatAdjIn.id_adj_x_mat_det = id_adj_in_mat_det
        FormPopUpMatAdjIn.adj_x_mat_det_qty = qty
        FormPopUpMatAdjIn.adj_x_mat_det_price = price
        FormPopUpMatAdjIn.adj_x_mat_det_note = remark
        FormPopUpMatAdjIn.id_wh_locator_edit = id_wh_locator_curr
        FormPopUpMatAdjIn.id_wh_rack_edit = id_wh_rack_curr
        FormPopUpMatAdjIn.id_wh_drawer_edit = id_wh_drawer_curr
        FormPopUpMatAdjIn.id_wh = id_wh_curr
        FormPopUpMatAdjIn.action = "upd"
        FormPopUpMatAdjIn.SLEWH.Enabled = True
        FormPopUpMatAdjIn.BtnChoose.Text = "Update"
        FormPopUpMatAdjIn.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        Dim cond_qty As Boolean = True
        GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        If Not formIsValidInGroup(EPAdj, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVDetail.RowCount = 0 Then
            errorCustom("Error : " + System.Environment.NewLine + "- Data can't blank. " + System.Environment.NewLine + "- Qty can't blank or zero value !")
        Else
            'Main var
            Dim query As String = ""
            Dim query2 As String = ""
            Dim adj_in_mat_number As String = addSlashes(TxtAdjNumber.Text)
            Dim adj_in_mat_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim succes As Boolean = False
            Dim adj_in_mat_total As String = decimalSQL(GVDetail.Columns("adj_in_mat_det_amount").SummaryItem.SummaryValue.ToString)
            Dim id_currency As String = LECurrency.EditValue.ToString
            If action = "ins" Then
                'Main table
                query = "INSERT INTO tb_adj_in_mat(adj_in_mat_number, adj_in_mat_date, adj_in_mat_note, id_report_status, adj_in_mat_total, id_currency) "
                query += "VALUES('" + adj_in_mat_number + "', NOW(), '" + adj_in_mat_note + "', '" + id_report_status + "', '" + adj_in_mat_total + "', '" + id_currency + "'); SELECT LAST_INSERT_ID(); "
                id_adj_in_mat = execute_query(query, 0, True, "", "", "", "")
                'MsgBox(id_mat_det_return)

                increase_inc_mat("9")

                'preapred default
                insert_who_prepared("26", id_adj_in_mat, id_user)

                'detail table
                For i As Integer = 0 To GVDetail.RowCount - 1
                    Try
                        Dim adj_in_mat_det_note As String = GVDetail.GetRowCellValue(i, "adj_in_mat_det_note").ToString
                        Dim adj_in_mat_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_mat_det_qty").ToString)
                        Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                        Dim id_mat_det_price As String = GVDetail.GetRowCellValue(i, "id_mat_det_price").ToString
                        Dim id_mat_det As String = GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                        Dim adj_in_mat_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_mat_det_price").ToString)

                        'INSERT TB DETAIL
                        query = "INSERT tb_adj_in_mat_det(id_adj_in_mat, adj_in_mat_det_note, adj_in_mat_det_qty, id_wh_drawer, id_mat_det,id_mat_det_price, adj_in_mat_det_price) "
                        query += "VALUES('" + id_adj_in_mat + "','" + adj_in_mat_det_note + "', '" + adj_in_mat_det_qty + "', '" + id_wh_drawer + "', '" + id_mat_det + "','" + id_mat_det_price + "', '" + adj_in_mat_det_price + "') "
                        execute_non_query(query, True, "", "", "", "")
                    Catch ex As Exception
                    End Try
                Next

                FormMatAdj.XTCAdj.SelectedTabPageIndex = 0
                FormMatAdj.viewAdjIn()
                Close()
            ElseIf action = "upd" Then
                Try
                    'update main table
                    query = "UPDATE tb_adj_in_mat SET adj_in_mat_number = '" + adj_in_mat_number + "', adj_in_mat_note = '" + adj_in_mat_note + "', id_report_status = '" + id_report_status + "', adj_in_mat_total = '" + adj_in_mat_total + "', id_currency = '" + id_currency + "' WHERE id_adj_in_mat = '" + id_adj_in_mat + "'"
                    execute_non_query(query, True, "", "", "", "")

                    query = "DELETE FROM tb_adj_in_mat_det WHERE id_adj_in_mat = '" + id_adj_in_mat + "'"
                    execute_non_query(query, True, "", "", "", "")
                    '
                    For i As Integer = 0 To GVDetail.RowCount - 1
                        Try
                            Dim adj_in_mat_det_note As String = GVDetail.GetRowCellValue(i, "adj_in_mat_det_note").ToString
                            Dim adj_in_mat_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_mat_det_qty").ToString)
                            Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                            Dim id_mat_det_price As String = GVDetail.GetRowCellValue(i, "id_mat_det_price").ToString
                            Dim id_mat_det As String = GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                            Dim adj_in_mat_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_mat_det_price").ToString)

                            'INSERT TB DETAIL
                            query = "INSERT tb_adj_in_mat_det(id_adj_in_mat, adj_in_mat_det_note, adj_in_mat_det_qty, id_wh_drawer, id_mat_det,id_mat_det_price, adj_in_mat_det_price) "
                            query += "VALUES('" + id_adj_in_mat + "','" + adj_in_mat_det_note + "', '" + adj_in_mat_det_qty + "', '" + id_wh_drawer + "', '" + id_mat_det + "','" + id_mat_det_price + "', '" + adj_in_mat_det_price + "') "
                            execute_non_query(query, True, "", "", "", "")
                        Catch ex As Exception
                        End Try
                    Next

                    FormMatAdj.XTCAdj.SelectedTabPageIndex = 0
                    FormMatAdj.viewAdjIn()
                    Close()
                Catch ex As Exception
                    errorCustom(ex.ToString)
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        'If e.Column.FieldName = "id_mat_det" Then
        '    Dim rowhandle As Integer = e.RowHandle
        '    If GVDetail.IsGroupRow(rowhandle) Then
        '        rowhandle = GVDetail.GetDataRowHandleByGroupRowHandle(rowhandle)
        '        e.DisplayText = GVDetail.GetRowCellDisplayText(rowhandle, "name")
        '    End If
        'End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_in_mat
        FormReportMark.report_mark_type = "26"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportMatAdjIn.id_adj_in_mat = id_adj_in_mat
        Dim Report As New ReportMatAdjIn()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_in_mat
        FormDocumentUpload.report_mark_type = "26"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class