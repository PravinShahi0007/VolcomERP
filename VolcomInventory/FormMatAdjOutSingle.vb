Public Class FormMatAdjOutSingle 
    Public id_adj_out_mat As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormMatAdjOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtAdjDate.Text = view_date(0)
            TxtAdjNumber.Text = header_number_mat("10")
            BMark.Enabled = False
            BtnPrint.Enabled = False
            viewDetailReturn()
        ElseIf action = "upd" Then
            BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_out_mat_date, '%Y-%m-%d') AS adj_out_mat_datex FROM tb_adj_out_mat a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_out_mat = '" + id_adj_out_mat + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'tampung ke form
            id_adj_out_mat = data.Rows(0)("id_adj_out_mat").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_out_mat_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_out_mat_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_out_mat_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If check_edit_report_status(id_report_status, "27", id_adj_out_mat) Then
                BMark.Enabled = True
                BtnSave.Enabled = True
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = False
                BtnAdd.Enabled = True
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
            Else
                BMark.Enabled = True
                BtnSave.Enabled = False
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = True
                BtnAdd.Enabled = False
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
            End If

            If check_print_report_status(id_report_status) Then
                BtnPrint.Enabled = True
            Else
                BtnPrint.Enabled = False
            End If

            'Fetch db detail
            viewDetailReturn()

            'get Total
            sayCurr()

            'disable add edit delete
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
        check_but()
    End Sub

    Sub viewReportStatus()
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

    Private Sub FormMatAdjOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT ('0') AS id_adj_out_mat_det, "
            query += "('0') AS id_mat_det, ('0') AS id_wh_drawer,('0') AS id_mat_det_price, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_mat_det_qty, CAST('0' AS DECIMAL(13,2)) AS adj_out_mat_det_amount, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_mat_det_price, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_mat_det_kurs, "
            query += "('') AS name, "
            query += "('') AS code, "
            query += "('') AS size, "
            query += "('') AS uom, "
            query += "('') AS adj_out_mat_det_note, "
            query += "('0') as id_comp, ('0') as id_wh_locator, ('0') as id_wh_rack, ('0') as id_wh_drawer, "
            query += "('') as comp_name, ('') as wh_locator, ('') as wh_rack, ('') as wh_drawer "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            deleteRows()
        Else
            query += "CALL view_mat_adj_out('" + id_adj_out_mat + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
        End If
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
            If check_edit_report_status(id_report_status, "27", id_adj_out_mat) Or action = "ins" Then
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

        FormPopUpMatAdjOut.id_pop_up = "1"
        FormPopUpMatAdjOut.action = "ins"
        FormPopUpMatAdjOut.SLEWH.Enabled = True
        FormPopUpMatAdjOut.SLELocator.Enabled = True
        FormPopUpMatAdjOut.SLERack.Enabled = True
        FormPopUpMatAdjOut.SLEDrawer.Enabled = True
        FormPopUpMatAdjOut.allow_all_locator = True
        FormPopUpMatAdjOut.allow_all_rack = True
        FormPopUpMatAdjOut.allow_all_drawer = True
        FormPopUpMatAdjOut.allow_all_wh = True
        FormPopUpMatAdjOut.GroupControlInput.Visible = True
        If action = "ins" Then
            FormPopUpMatAdjOut.id_adj_out_mat = "0"
        Else
            FormPopUpMatAdjOut.id_adj_out_mat = "-1"
        End If
        FormPopUpMatAdjOut.ShowDialog()
        Cursor = Cursors.Default
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
    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        confirm = "Are you sure to delete this data?"
        If (MessageBox.Show(confirm, "Delete Confirmation",MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_mat_det As String = GVDetail.GetFocusedRowCellValue("id_mat_det").ToString
        Dim id_adj_out_mat_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_out_mat_det").ToString
        Dim id_wh_drawer As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim adj_out_mat_det_qty As String = GVDetail.GetFocusedRowCellValue("adj_out_mat_det_qty").ToString
        Try
            deleteRows()
            sayCurr()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_wh_locator_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("wh_drawer").ToString
        Dim id_wh_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_comp").ToString
        Dim id_mat_det_edit As String = GVDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
        Dim id_mat_det_price As String = GVDetail.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
        Dim mat_det_edit As String = GVDetail.GetFocusedRowCellDisplayText("name").ToString
        Dim code_edit As String = GVDetail.GetFocusedRowCellDisplayText("code").ToString
        Dim qty As Decimal = GVDetail.GetFocusedRowCellValue("adj_out_mat_det_qty")
        Dim remark As String = GVDetail.GetFocusedRowCellDisplayText("adj_out_mat_det_note").ToString
        Dim id_adj_out_mat_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_out_mat_det").ToString
        Dim price As Decimal = GVDetail.GetFocusedRowCellValue("adj_out_mat_det_price")

        FormPopUpMatAdjOut.TEUnitPrice.EditValue = price
        FormPopUpMatAdjOut.id_mat_edit = id_mat_det_edit
        FormPopUpMatAdjOut.pl_mrs_det_qty = qty
        FormPopUpMatAdjOut.pl_mrs_det_note = remark
        FormPopUpMatAdjOut.id_wh_locator_edit = id_wh_locator_curr
        FormPopUpMatAdjOut.id_wh_rack_edit = id_wh_rack_curr
        FormPopUpMatAdjOut.id_wh_drawer_edit = id_wh_drawer_curr
        FormPopUpMatAdjOut.id_wh = id_wh_curr
        FormPopUpMatAdjOut.id_pop_up = "1"
        FormPopUpMatAdjOut.action = "upd"
        FormPopUpMatAdjOut.GroupControlInput.Visible = True
        FormPopUpMatAdjOut.id_adj_out_mat = id_adj_out_mat
        FormPopUpMatAdjOut.BtnChoose.Text = "Update"
        FormPopUpMatAdjOut.ShowDialog()

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
            Dim adj_out_mat_number As String = addSlashes(TxtAdjNumber.Text)
            Dim adj_out_mat_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim succes As Boolean = False
            Dim adj_out_mat_total As String = decimalSQL(GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue)
            Dim id_currency As String = LECurrency.EditValue.ToString
            If action = "ins" Then
                'Main table
                query = "INSERT INTO tb_adj_out_mat(adj_out_mat_number, adj_out_mat_date, adj_out_mat_note, id_report_status, adj_out_mat_total, id_currency) "
                query += "VALUES('" + adj_out_mat_number + "', NOW(), '" + adj_out_mat_note + "', '" + id_report_status + "', '" + adj_out_mat_total + "', '" + id_currency + "'); SELECT LAST_INSERT_ID(); "
                id_adj_out_mat = execute_query(query, 0, True, "", "", "", "")

                increase_inc_mat("10")

                'preapred default
                insert_who_prepared("27", id_adj_out_mat, id_user)


                'detail table
                For i As Integer = 0 To GVDetail.RowCount - 1
                    Try
                        Dim adj_out_mat_det_note As String = GVDetail.GetRowCellValue(i, "adj_out_mat_det_note").ToString
                        Dim adj_out_mat_det_qty As Decimal = GVDetail.GetRowCellValue(i, "adj_out_mat_det_qty")
                        Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                        Dim id_mat_det As String = GVDetail.GetRowCellValue(i, "id_mat_det").ToString
                        Dim adj_out_mat_det_price As Decimal = GVDetail.GetRowCellValue(i, "adj_out_mat_det_price")
                        Dim id_mat_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "id_mat_det_price").ToString)

                        'INSERT TB DETAIL
                        query = "INSERT tb_adj_out_mat_det(id_adj_out_mat, adj_out_mat_det_note, adj_out_mat_det_qty, id_wh_drawer, id_mat_det,id_mat_det_price, adj_out_mat_det_price) "
                        query += "VALUES('" + id_adj_out_mat + "','" + adj_out_mat_det_note + "', '" + decimalSQL(adj_out_mat_det_qty) + "', '" + id_wh_drawer + "', '" + id_mat_det + "','" + id_mat_det_price + "', '" + decimalSQL(adj_out_mat_det_price.ToString) + "') "
                        execute_non_query(query, True, "", "", "", "")

                        'INSERT TB PL STORAGE
                        Dim query_upd_storage As String = "INSERT INTO tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_stock_status,report_mark_type,id_report) "
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_mat_det + "','" + id_mat_det_price + "','" + decimalSQL(adj_out_mat_det_price.ToString) + "', '" + decimalSQL(adj_out_mat_det_qty) + "', NOW(), 'Adjustment In : " + adj_out_mat_number + "','2','27','" + id_adj_out_mat + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    Catch ex As Exception
                        Console.WriteLine(ex.ToString)
                    End Try
                Next

                FormMatAdj.XTCAdj.SelectedTabPageIndex = 1
                FormMatAdj.viewAdjOut()
                Close()
            ElseIf action = "upd" Then
                'update main table
                query = "UPDATE tb_adj_out_mat SET adj_out_mat_number = '" + adj_out_mat_number + "', adj_out_mat_note = '" + adj_out_mat_note + "' WHERE id_adj_out_mat = '" + id_adj_out_mat + "'"
                execute_non_query(query, True, "", "", "", "")
                FormMatAdj.XTCAdj.SelectedTabPageIndex = 1
                FormMatAdj.viewAdjOut()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "id_mat_det" Then
        End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_out_mat
        FormReportMark.report_mark_type = "27"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportMatAdjOut.id_adj_out_mat = id_adj_out_mat
        Dim Report As New ReportMatAdjOut()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        'If action = "upd" Then
        '    Dim adj_out_mat_total As String = decimalSQL(GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue)
        '    Dim query As String = "UPDATE tb_adj_out_mat SET adj_out_mat_total = '" + adj_out_mat_total + "' WHERE id_adj_out_mat = '" + id_adj_out_mat + "'"
        '    execute_non_query(query, True, "", "", "", "")
        '    FormMatAdj.XTCAdj.SelectedTabPageIndex = 1
        '    FormMatAdj.viewAdjOut()
        'End If
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_out_mat
        FormDocumentUpload.report_mark_type = "27"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class