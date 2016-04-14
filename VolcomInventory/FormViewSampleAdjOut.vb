Public Class FormViewSampleAdjOut 
    Public id_adj_out_sample As String
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
            TxtAdjNumber.Text = header_number("13")
            BMark.Enabled = False
            'BtnPrint.Enabled = False
            viewDetailReturn()
        ElseIf action = "upd" Then
            'BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_out_sample_date, '%Y-%m-%d') AS adj_out_sample_datex FROM tb_adj_out_sample a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_out_sample = '" + id_adj_out_sample + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ''tampung ke form
            id_adj_out_sample = data.Rows(0)("id_adj_out_sample").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_out_sample_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_out_sample_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_out_sample_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If check_edit_report_status(id_report_status, "21", id_adj_out_sample) Then
                'MsgBox("Masih Boleh")
                BMark.Enabled = True
                'BtnSave.Enabled = True
                'BtnPrint.Enabled = False
                'MENote.Properties.ReadOnly = False
                'BtnAdd.Enabled = True
                'BtnEdit.Enabled = True
                'BtnDel.Enabled = True
            Else
                'MsgBox("Nggak Boleh")
                BMark.Enabled = True
                'BtnSave.Enabled = False
                'BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = True
                'BtnAdd.Enabled = False
                'BtnEdit.Enabled = False
                'BtnDel.Enabled = False
            End If

            If check_print_report_status(id_report_status) Then
                'BtnPrint.Enabled = True
            Else
                ' BtnPrint.Enabled = False
            End If

            'Fetch db detail
            viewDetailReturn()

            'get Total
            total_amount = Double.Parse(GVDetail.Columns("adj_out_sample_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
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

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT ('0') AS id_adj_out_sample_det, "
            query += "('0') AS id_sample, ('0') AS id_wh_drawer, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_sample_det_qty, CAST('0' AS DECIMAL(13,2)) AS adj_out_sample_det_amount, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_sample_det_price, "
            query += "CAST('0' AS DECIMAL(13,2)) AS adj_out_sample_det_kurs, "
            query += "('') AS name, "
            query += "('') AS code, "
            query += "('') AS size, "
            query += "('') AS uom, "
            query += "('') AS adj_out_sample_det_note, "
            query += "('0') as id_comp, ('0') as id_wh_locator, ('0') as id_wh_rack, ('0') as id_wh_drawer, "
            query += "('') as comp_name, ('') as wh_locator, ('') as wh_rack, ('') as wh_drawer "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            deleteRows()
        Else
            query += "CALL view_sample_adj_out('" + id_adj_out_sample + "')"
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
        cantEdit()
    End Sub

    Sub cantEdit()
        Dim id_sample_curr As String = ""
        Dim id_drawer_curr As String = ""
        Try
            'id_sample_curr = GVDetail.GetFocusedRowCellDisplayText("id_sample").ToString()
            id_drawer_curr = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString()
        Catch ex As Exception

        End Try
        If GVDetail.RowCount < 1 Or id_drawer_curr = "" Then
            'BtnEdit.Enabled = False
            'BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, "21", id_adj_out_sample) Or action = "ins" Then
                'BtnEdit.Enabled = True
                'BtnDel.Enabled = True
            End If
        End If
    End Sub

   

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub
    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "id_sample" Then
            'Dim rowhandle As Integer = e.RowHandle
            'If GVDetail.IsGroupRow(rowhandle) Then
            '    rowhandle = GVDetail.GetDataRowHandleByGroupRowHandle(rowhandle)
            '    e.DisplayText = GVDetail.GetRowCellDisplayText(rowhandle, "name")
            'End If
        End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ReportSampleAdjIn.id_adj_out_sample = id_adj_out_sample
        'Dim Report As New ReportSampleAdjIn()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVDetail.Columns("adj_out_sample_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_out_sample
        FormReportMark.report_mark_type = "21"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class