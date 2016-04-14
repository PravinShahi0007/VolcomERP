Public Class FormSampleAdjustmentInSingle
    Public id_adj_in_sample As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormSampleAdjustmentInSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtAdjDate.Text = view_date(0)
            TxtAdjNumber.Text = header_number("12")
            BMark.Enabled = False
            BtnPrint.Enabled = False
            viewDetailReturn()
        ElseIf action = "upd" Then
            BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_in_sample_date, '%Y-%m-%d') AS adj_in_sample_datex FROM tb_adj_in_sample a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_in_sample = '" + id_adj_in_sample + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ''tampung ke form
            id_adj_in_sample = data.Rows(0)("id_adj_in_sample").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_in_sample_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_in_sample_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_in_sample_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            allow_status()

            'Fetch db detail
            viewDetailReturn()

            'get Total
            total_amount = Double.Parse(GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        End If
    End Sub

    Sub allow_status()
        'Updated 17 Oktober 2014
        If check_edit_report_status(id_report_status, "20", id_adj_in_sample) Then
            'MsgBox("Masih Boleh")
            BMark.Enabled = True
            BtnSave.Enabled = True
            BtnPrint.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            'MsgBox("Nggak Boleh")
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

    Private Sub FormSampleAdjustmentInSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDetailReturn()
        'UPDATED 17 Okrober 2014
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT ('0') AS id_adj_in_sample_det, "
            query += "('0') AS id_sample, ('0') AS id_wh_drawer, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_in_sample_det_qty, CAST('0' AS DECIMAL(13,2)) AS adj_in_sample_det_amount, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_in_sample_det_price, "
            query += "('0') AS id_sample_price, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_in_sample_det_kurs, "
            query += "('') AS name, "
            query += "('') AS code, "
            query += "('') AS color, "
            query += "('') AS size, "
            query += "('') AS uom, "
            query += "('') AS adj_in_sample_det_note, "
            query += "('0') as id_comp, ('0') as id_wh_locator, ('0') as id_wh_rack, ('0') as id_wh_drawer, "
            query += "('') as comp_name, ('') as wh_locator, ('') as wh_rack, ('') as wh_drawer "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            deleteRows()
        Else
            query += "CALL view_sample_adj_in('" + id_adj_in_sample + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
        End If
        'GVDetail.Columns("id_sample").GroupIndex = 0
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
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()

        'get total (Updated 17 Oktober 2014)
        total_amount = Double.Parse(GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)

        cantEdit()
    End Sub

    Sub cantEdit()
        If action = "ins" Then
            Dim id_sample_curr As String = ""
            Dim id_drawer_curr As String = ""
            Try
                'id_sample_curr = GVDetail.GetFocusedRowCellDisplayText("id_sample").ToString()
                id_drawer_curr = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString()
            Catch ex As Exception

            End Try
            If GVDetail.RowCount < 1 Or id_drawer_curr = "" Then
                BtnEdit.Enabled = False
                BtnDel.Enabled = False
            Else
                If check_edit_report_status(id_report_status, "20", id_adj_in_sample) Or action = "ins" Then
                    BtnEdit.Enabled = True
                    BtnDel.Enabled = True
                End If
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
        FormPopUpSampleAdj.id_wh = "-1"
        FormPopUpSampleAdj.id_pop_up = "1"
        FormPopUpSampleAdj.action = "ins"
        If action = "ins" Then
            FormPopUpSampleAdj.id_adj_x_sample_det = "0"
        Else
            FormPopUpSampleAdj.id_adj_x_sample_det = "-1"
        End If
        FormPopUpSampleAdj.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        If action = "ins" Then
            confirm = "Are you sure to delete this data?"
        ElseIf action = "upd" Then
            confirm = "Stock qty will be updated after this process, are you sure to delete this data?"
        End If
        If (MessageBox.Show(confirm, "Delete Confirmation", _
         MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_sample As String = GVDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim id_adj_in_sample_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_in_sample_det").ToString
        Dim id_wh_drawer As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim adj_in_sample_det_qty As String = GVDetail.GetFocusedRowCellValue("adj_in_sample_det_qty").ToString
        Try
            deleteRows()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_wh_locator_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim id_wh_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_comp").ToString
        Dim id_sample_edit As String = GVDetail.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim qty As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_sample_det_qty")
        Dim remark As String = GVDetail.GetFocusedRowCellDisplayText("adj_in_sample_det_note").ToString
        Dim id_adj_in_sample_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_in_sample_det").ToString
        Dim price As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_sample_det_price")
        Dim kurs As Decimal = 1
        FormPopUpSampleAdj.id_pop_up = "1"
        FormPopUpSampleAdj.indeks_edit = GVDetail.FocusedRowHandle
        FormPopUpSampleAdj.id_sample_edit = id_sample_edit
        FormPopUpSampleAdj.id_adj_x_sample_det = id_adj_in_sample_det
        FormPopUpSampleAdj.adj_x_sample_det_qty = qty
        FormPopUpSampleAdj.adj_x_sample_det_kurs = kurs
        FormPopUpSampleAdj.adj_x_sample_det_price = price
        FormPopUpSampleAdj.adj_x_sample_det_note = remark
        FormPopUpSampleAdj.id_wh_locator_edit = id_wh_locator_curr
        FormPopUpSampleAdj.id_wh_rack_edit = id_wh_rack_curr
        FormPopUpSampleAdj.id_wh_drawer_edit = id_wh_drawer_curr
        FormPopUpSampleAdj.id_wh = id_wh_curr
        FormPopUpSampleAdj.action = "upd"
        FormPopUpSampleAdj.SLEWH.Enabled = True
        FormPopUpSampleAdj.BtnChoose.Text = "Update"
        FormPopUpSampleAdj.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'UPDATED 17 Oktober 2014
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()

        Cursor = Cursors.WaitCursor
        ValidateChildren()
        Dim cond_qty As Boolean = True
        GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        If Not formIsValidInGroup(EPAdj, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVDetail.RowCount = 0 Then
            errorCustom("Error : " + System.Environment.NewLine + "- Data can't blank. " + System.Environment.NewLine + "- Qty can't blank or zero value !")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'Main var
                Dim query As String = ""
                Dim query2 As String = ""
                Dim adj_in_sample_number As String = addSlashes(TxtAdjNumber.Text)
                Dim adj_in_sample_note As String = addSlashes(MENote.Text)
                Dim id_report_status As String = LEReportStatus.EditValue
                Dim succes As Boolean = False
                Dim adj_in_sample_total As String = decimalSQL(GVDetail.Columns("adj_in_sample_det_amount").SummaryItem.SummaryValue.ToString)
                Dim id_currency As String = LECurrency.EditValue.ToString
                If action = "ins" Then
                    Try
                        'Main table
                        query = "INSERT INTO tb_adj_in_sample(adj_in_sample_number, adj_in_sample_date, adj_in_sample_note, id_report_status, adj_in_sample_total, id_currency) "
                        query += "VALUES('" + adj_in_sample_number + "', NOW(), '" + adj_in_sample_note + "', '" + id_report_status + "', '" + adj_in_sample_total + "', '" + id_currency + "'); SELECT LAST_INSERT_ID(); "
                        id_adj_in_sample = execute_query(query, 0, True, "", "", "", "")
                        'MsgBox(id_sample_return)

                        increase_inc("12")

                        'preapred default
                        insert_who_prepared("20", id_adj_in_sample, id_user)


                        'detail table
                        For i As Integer = 0 To GVDetail.RowCount - 1
                            Try
                                Dim adj_in_sample_det_note As String = GVDetail.GetRowCellValue(i, "adj_in_sample_det_note").ToString
                                Dim adj_in_sample_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_sample_det_qty").ToString)
                                Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                                Dim id_sample As String = GVDetail.GetRowCellValue(i, "id_sample").ToString
                                'Dim id_adj_in_sample_det As String = GVDetail.GetRowCellValue(i, "id_sample").ToString
                                Dim adj_in_sample_det_kurs As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_sample_det_kurs").ToString)
                                Dim adj_in_sample_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_sample_det_price").ToString)
                                Dim id_sample_price As String = GVDetail.GetRowCellValue(i, "id_sample_price")

                                'INSERT TB DETAIL
                                query = "INSERT tb_adj_in_sample_det(id_adj_in_sample, adj_in_sample_det_note, adj_in_sample_det_qty, id_wh_drawer, id_sample, adj_in_sample_det_kurs, adj_in_sample_det_price, id_sample_price) "
                                query += "VALUES('" + id_adj_in_sample + "','" + adj_in_sample_det_note + "', '" + adj_in_sample_det_qty + "', '" + id_wh_drawer + "', '" + id_sample + "', '" + adj_in_sample_det_kurs + "', '" + adj_in_sample_det_price + "', '" + id_sample_price + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                            End Try
                        Next

                        FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0
                        FormSampleAdjustment.viewAdjInSample()
                        FormSampleAdjustment.GVAdjSampleIn.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjSampleIn, "id_adj_in_sample", id_adj_in_sample)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                ElseIf action = "upd" Then
                    Try
                        'update main table
                        query = "UPDATE tb_adj_in_sample SET adj_in_sample_number = '" + adj_in_sample_number + "', adj_in_sample_note = '" + adj_in_sample_note + "', id_report_status = '" + id_report_status + "', adj_in_sample_total = '" + adj_in_sample_total + "', id_currency = '" + id_currency + "' WHERE id_adj_in_sample = '" + id_adj_in_sample + "'"
                        execute_non_query(query, True, "", "", "", "")
                        FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0
                        FormSampleAdjustment.viewAdjOutSample()
                        FormSampleAdjustment.GVAdjSampleIn.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjSampleIn, "id_adj_in_sample", id_adj_in_sample)
                        Close()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "id_sample" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVDetail.IsGroupRow(rowhandle) Then
                rowhandle = GVDetail.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVDetail.GetRowCellDisplayText(rowhandle, "name")
            End If
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_in_sample
        FormReportMark.report_mark_type = "20"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportSampleAdjIn.id_adj_in_sample = id_adj_in_sample
        Dim Report As New ReportSampleAdjIn()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class