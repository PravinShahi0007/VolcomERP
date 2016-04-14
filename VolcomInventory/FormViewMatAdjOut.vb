Public Class FormViewMatAdjOut 
    Public id_adj_out_mat As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormViewMatAdjOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        GVDetail.OptionsBehavior.AutoExpandAllGroups = True

        'Fetch from db main
        Dim query As String = "SELECT *, DATE_FORMAT(a.adj_out_mat_date, '%Y-%m-%d') AS adj_out_mat_datex FROM tb_adj_out_mat a "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "WHERE a.id_adj_out_mat = '" + id_adj_out_mat + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''tampung ke form
        id_adj_out_mat = data.Rows(0)("id_adj_out_mat").ToString
        TxtAdjNumber.Text = data.Rows(0)("adj_out_mat_number").ToString
        TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_out_mat_datex").ToString, 0)
        MENote.Text = data.Rows(0)("adj_out_mat_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        'Fetch db detail
        viewDetailReturn()

        'get Total
        sayCurr()
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

    Private Sub FormViewMatAdjOut_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT ('0') AS id_adj_out_mat_det, "
            query += "('0') AS id_mat_det, ('0') AS id_wh_drawer, "
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
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "id_mat_det" Then
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

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_out_mat
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "27"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Sub sayCurr()
        total_amount = Double.Parse(GVDetail.Columns("adj_out_mat_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_out_mat
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "27"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class