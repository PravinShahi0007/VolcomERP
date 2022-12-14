Public Class FormFGAdjInDet 
    Public id_adj_in_fg As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double
    '
    Public id_drawer As String = ""
    Public drawer_name As String = ""
    Public id_rack As String = ""
    Public rack_name As String = ""
    Public id_locator As String = ""
    Public locator_name As String = ""
    Public id_comp As String = ""
    Public comp_name As String = ""
    Public id_st_store_bap As String = ""
    Public report_mark_type As String = "41"

    Private Sub FormFGAdjInDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_adj_type()

        If Not id_st_store_bap = "" Then
            report_mark_type = "342"
        End If

        If Not id_adj_in_fg = "" Then
            Dim data_header As DataTable = execute_query("
                SELECT id_st_store_bap, report_mark_type, id_adj_type
                FROM tb_adj_in_fg
                WHERE id_adj_in_fg = " + id_adj_in_fg + "
            ", -1, True, "", "", "", "")

            If data_header.Rows.Count > 0 Then
                id_st_store_bap = data_header.Rows(0)("id_st_store_bap").ToString
                report_mark_type = data_header.Rows(0)("report_mark_type").ToString
                SLUEAdjType.EditValue = data_header.Rows(0)("id_adj_type").ToString
            End If
        End If

        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtAdjDate.Text = view_date(0)
            TxtAdjNumber.Text = ""
            BMark.Enabled = False
            BtnPrint.Enabled = False
            viewDetailReturn()
            PCEdit.Visible = True

            If Not id_st_store_bap = "" Then
                Dim query As String = "
                    SELECT 0 AS id_adj_in_fg_det, d.id_product, p.name, p.size, u.uom, p.full_code AS code, ABS(v.qty) AS adj_in_fg_det_qty, p.unit_cost AS adj_in_fg_det_price, (ABS(v.qty) * p.unit_cost) AS adj_in_fg_det_amount, d.price AS retail_price, (ABS(v.qty) * d.price) AS retail_price_amount, '' AS adj_in_fg_det_note, c.id_drawer_def AS id_wh_drawer, w.id_wh_rack, r.id_wh_locator, b.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp, w.wh_drawer, r.wh_rack, l.wh_locator, CONCAT(c.comp_number, ' - ', c.comp_name) AS comp_name, NULL AS id_sales_pos_det, '' AS sales_pos_number, DATE_FORMAT(sp.schedule_start, '%d %M %Y') AS stocktake_date
                    FROM tb_st_store_bap_ver AS v
                    LEFT JOIN tb_st_store_bap_det AS d ON v.id_st_store_bap_det = d.id_st_store_bap_det
                    LEFT JOIN tb_st_store_bap AS b ON d.id_st_store_bap = b.id_st_store_bap
                    LEFT JOIN tb_st_store_period AS sp ON b.id_st_store_period = sp.id_st_store_period
                    LEFT JOIN tb_m_product_store AS p ON d.id_product = p.id_product
                    LEFT JOIN tb_m_design AS s ON p.id_design = s.id_design
                    LEFT JOIN tb_m_uom AS u ON s.id_uom = u.id_uom
                    LEFT JOIN tb_m_comp AS c ON b.id_comp = c.id_comp
                    LEFT JOIN tb_m_wh_drawer AS w ON c.id_drawer_def = w.id_wh_drawer
                    LEFT JOIN tb_m_wh_rack AS r ON w.id_wh_rack = r.id_wh_rack
                    LEFT JOIN tb_m_wh_locator AS l ON r.id_wh_locator = l.id_wh_locator
                    WHERE d.id_st_store_bap = " + id_st_store_bap + " AND v.qty < 0 AND v.report_mark_type = 0
                "

                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                GCDetail.DataSource = data

                GVDetail.BestFitColumns()

                BImport.Enabled = False
                BtnDel.Enabled = False
                BtnEdit.Enabled = False
                BtnAdd.Enabled = False

                MENote.EditValue = FormFGAdj.GVInBAP.GetFocusedRowCellValue("number").ToString + " - " + data.Rows(0)("stocktake_date").ToString
            End If
        ElseIf action = "upd" Then
            PCEdit.Visible = False
            BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_in_fg_date, '%Y-%m-%d') AS adj_in_fg_datex FROM tb_adj_in_fg a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_in_fg = '" + id_adj_in_fg + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ''tampung ke form
            id_adj_in_fg = data.Rows(0)("id_adj_in_fg").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_in_fg_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_in_fg_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_in_fg_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            SLUEAdjType.EditValue = data.Rows(0)("id_adj_type").ToString

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If check_edit_report_status(id_report_status, report_mark_type, id_adj_in_fg) Then
                BMark.Enabled = True
                BtnSave.Enabled = True
                MENote.Properties.ReadOnly = False
            Else
                BMark.Enabled = True
                BtnSave.Enabled = False
                MENote.Properties.ReadOnly = True
            End If

            BtnPrint.Enabled = True

            SBSelectInvoice.Visible = False

            'Fetch db detail
            viewDetailReturn()

            'disable changing stock
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False

            'get Total
            total_amount = Double.Parse(GVDetail.Columns("adj_in_fg_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)

            SLUEAdjType.Properties.ReadOnly = True
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

        If SLUEAdjType.EditValue.ToString = "2" Then
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

    Private Sub FormFGAdjInDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_fg_adj_in_less('" + id_adj_in_fg + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        'GVDetail.Columns("id_product").GroupIndex = 0
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
        cantEdit()
    End Sub

    Sub cantEdit()
        Dim id_product_curr As String = ""
        Dim id_drawer_curr As String = ""
        Try
            'id_product_curr = GVDetail.GetFocusedRowCellDisplayText("id_product").ToString()
            id_drawer_curr = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString()
        Catch ex As Exception

        End Try
        If GVDetail.RowCount < 1 Or id_drawer_curr = "" Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, report_mark_type, id_adj_in_fg) Or action = "ins" Then
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
        FormFGAdjInSingle.id_wh = "-1"
        FormFGAdjInSingle.id_pop_up = "1"
        FormFGAdjInSingle.action = "ins"
        If action = "ins" Then
            FormFGAdjInSingle.id_adj_x_fg_det = "0"
        Else
            FormFGAdjInSingle.id_adj_x_fg_det = "-1"
        End If
        FormFGAdjInSingle.ShowDialog()
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
        Dim id_product_edit As String = GVDetail.GetFocusedRowCellDisplayText("id_product").ToString
        Dim qty As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_fg_det_qty")
        Dim remark As String = GVDetail.GetFocusedRowCellDisplayText("adj_in_fg_det_note").ToString
        Dim id_adj_in_fg_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_in_fg_det").ToString
        Dim adj_in_fg_det_price As Decimal = GVDetail.GetFocusedRowCellValue("adj_in_fg_det_price")
        If id_adj_in_fg_det = "0" Then
            FormFGAdjInSingle.id_pop_up = "1"
            FormFGAdjInSingle.indeks_edit = GVDetail.FocusedRowHandle
            FormFGAdjInSingle.id_product_edit = id_product_edit
            FormFGAdjInSingle.id_adj_x_fg_det = id_adj_in_fg_det
            FormFGAdjInSingle.adj_x_fg_det_qty = qty
            FormFGAdjInSingle.adj_x_fg_det_price = adj_in_fg_det_price
            FormFGAdjInSingle.adj_x_fg_det_note = remark
            FormFGAdjInSingle.id_wh_locator_edit = id_wh_locator_curr
            FormFGAdjInSingle.id_wh_rack_edit = id_wh_rack_curr
            FormFGAdjInSingle.id_wh_drawer_edit = id_wh_drawer_curr
            FormFGAdjInSingle.id_wh = id_wh_curr
            FormFGAdjInSingle.action = "upd"
            FormFGAdjInSingle.SLEWH.Enabled = True
            FormFGAdjInSingle.BtnChoose.Text = "Update"
            FormFGAdjInSingle.ShowDialog()
        End If
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
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                'Main var
                Dim query As String = ""
                Dim query2 As String = ""
                Dim adj_in_fg_number As String = addSlashes(TxtAdjNumber.Text)
                Dim adj_in_fg_note As String = addSlashes(MENote.Text)
                Dim id_report_status As String = LEReportStatus.EditValue
                Dim succes As Boolean = False
                Dim adj_in_fg_total As String = decimalSQL(GVDetail.Columns("adj_in_fg_det_amount").SummaryItem.SummaryValue.ToString)
                Dim retail_price_total As String = decimalSQL(GVDetail.Columns("retail_price_amount").SummaryItem.SummaryValue.ToString)
                Dim id_currency As String = LECurrency.EditValue.ToString

                If SLUEAdjType.EditValue.ToString = "2" Then
                    report_mark_type = "354"
                End If

                If action = "ins" Then
                    'Main table
                    query = "INSERT INTO tb_adj_in_fg(adj_in_fg_number, adj_in_fg_date, adj_in_fg_note, id_report_status, adj_in_fg_total, id_currency, retail_price_total, id_st_store_bap, report_mark_type, id_adj_type) "
                    query += "VALUES('', NOW(), '" + adj_in_fg_note + "', '" + id_report_status + "', '" + adj_in_fg_total + "', '" + id_currency + "', '" + retail_price_total + "', " + If(id_st_store_bap = "", "NULL", id_st_store_bap) + ", " + report_mark_type + ", " + SLUEAdjType.EditValue.ToString + "); SELECT LAST_INSERT_ID(); "
                    id_adj_in_fg = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id_adj_in_fg + ",41); ", True, "", "", "", "")
                    'MsgBox(id_product_return)

                    'increase_inc_sales("14")

                    'preapred default
                    submit_who_prepared(report_mark_type, id_adj_in_fg, id_user)

                    'detail table
                    query = "INSERT tb_adj_in_fg_det(id_adj_in_fg, adj_in_fg_det_note, adj_in_fg_det_qty, id_wh_drawer, id_product, adj_in_fg_det_price, retail_price, id_sales_pos_det) "
                    query += "VALUES "

                    For i As Integer = 0 To GVDetail.RowCount - 1
                        'Try
                        Dim adj_in_fg_det_note As String = GVDetail.GetRowCellValue(i, "adj_in_fg_det_note").ToString
                        Dim adj_in_fg_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_fg_det_qty").ToString)
                        Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                        Dim id_product As String = GVDetail.GetRowCellValue(i, "id_product").ToString
                        Dim adj_in_fg_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_in_fg_det_price").ToString)
                        Dim retail_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "retail_price").ToString)
                        Dim id_sales_pos_det As String = If(GVDetail.GetRowCellValue(i, "id_sales_pos_det").ToString = "", "NULL", "'" + GVDetail.GetRowCellValue(i, "id_sales_pos_det").ToString + "'")

                        'INSERT TB DETAIL
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" + id_adj_in_fg + "','" + adj_in_fg_det_note + "', '" + adj_in_fg_det_qty + "', '" + id_wh_drawer + "', '" + id_product + "', '" + adj_in_fg_det_price + "', '" + retail_price + "', " + id_sales_pos_det + ") "
                        'Catch ex As Exception
                        'End Try
                    Next

                    execute_non_query(query, True, "", "", "", "")


                    FormFGAdj.XTCAdj.SelectedTabPageIndex = 0
                    FormFGAdj.viewAdjIn()
                    Close()
                ElseIf action = "upd" Then
                    Try
                        'update main table
                        query = "UPDATE tb_adj_in_fg SET adj_in_fg_number = '" + adj_in_fg_number + "', adj_in_fg_note = '" + adj_in_fg_note + "', id_report_status = '" + id_report_status + "', adj_in_fg_total = '" + adj_in_fg_total + "', id_currency = '" + id_currency + "' WHERE id_adj_in_fg = '" + id_adj_in_fg + "' "
                        execute_non_query(query, True, "", "", "", "")
                        FormFGAdj.XTCAdj.SelectedTabPageIndex = 0
                        FormFGAdj.viewAdjIn()
                        Close()
                    Catch ex As Exception
                        errorCustom(ex.ToString)
                    End Try
                End If
            End If
        End If
        FormFGAdj.view_in_bap()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        'If e.Column.FieldName = "id_product" Then
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
        FormReportMark.id_report = id_adj_in_fg
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportFGAdjIn.id_adj_in_fg = id_adj_in_fg
        Dim Report As New ReportFGAdjIn()
        Report.report_mark_type = report_mark_type
        If id_report_status!= "6" Then
            Report.is_pre = "1"
        End If

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        ReportFGAdjIn.id_adj_in_fg = id_adj_in_fg
        Dim Report As New ReportFGAdjIn()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub FormFGAdjInDet_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F1 Then

        End If
    End Sub

    Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
        'import excel
        FormPopUpDrawer.include_all = False
        FormPopUpDrawer.id_pop_up = "7"
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub SBExportToXLS_Click(sender As Object, e As EventArgs) Handles SBExportToXLS.Click
        Cursor = Cursors.WaitCursor
        If GVDetail.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'Dim dt_from As String = DEFromRec.Text.Replace(" ", "")
            'Dim dt_until As String = DEUntilRec.Text.Replace(" ", "")
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "adj_in.xlsx"
            exportToXLS(path, "adj_in", GCDetail)
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub view_adj_type()
        Dim query As String = "SELECT id_adj_type, adj_type FROM tb_lookup_adj_type"

        viewSearchLookupQuery(SLUEAdjType, query, "id_adj_type", "adj_type", "id_adj_type")
    End Sub

    Private Sub SLUEAdjType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEAdjType.EditValueChanged
        If SLUEAdjType.EditValue.ToString = "1" Then
            SBSelectInvoice.Visible = False
            BtnAdd.Visible = True
            BImport.Visible = True
            check_but()

            GVDetail.Columns("sales_pos_number").Visible = False
            GVDetail.Columns("sales_pos_number").VisibleIndex = -1
            GVDetail.Columns("sales_period").Visible = False
            GVDetail.Columns("sales_period").VisibleIndex = -1
        Else
            SBSelectInvoice.Visible = True
            BImport.Visible = False
            BtnEdit.Visible = False
            BtnAdd.Visible = False

            GVDetail.Columns("sales_pos_number").Visible = True
            GVDetail.Columns("sales_pos_number").VisibleIndex = 2
            GVDetail.Columns("sales_period").Visible = True
            GVDetail.Columns("sales_period").VisibleIndex = 3
        End If

        Dim query As String = "CALL view_fg_adj_in_less(0)"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDetail.DataSource = data

        GVDetail.BestFitColumns()
    End Sub

    Private Sub SBSelectInvoice_Click(sender As Object, e As EventArgs) Handles SBSelectInvoice.Click
        FormFGAdjInInvoice.ShowDialog()
    End Sub
End Class