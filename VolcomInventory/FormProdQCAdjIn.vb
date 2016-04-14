Public Class FormProdQCAdjIn 
    Public id_adj_in As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_report_status As String = "-1"

    Private Sub FormProdQCAdjIn_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProdQCAdjIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If id_adj_in = "-1" Then 'new
            viewDetailReturn()
            TxtAdjDate.EditValue = view_date(-1)

            BMark.Visible = False
            BtnAttachment.Visible = False
            BtnPrint.Visible = False

            TxtAdjNumber.Text = header_number_prod("10")
        Else 'edit
            Dim query As String = "SELECT tb_prod_order_qc_adj_in.id_prod_order,tb_prod_order.prod_order_number,prod_order_qc_adj_in_number,prod_order_qc_adj_in_date,prod_order_qc_adj_in_note,tb_prod_order_qc_adj_in.id_report_status FROM tb_prod_order_qc_adj_in INNER JOIN tb_prod_order ON tb_prod_order.id_prod_order=tb_prod_order_qc_adj_in.id_prod_order WHERE id_prod_order_qc_adj_in='" + id_adj_in + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtAdjNumber.Text = data.Rows(0)("prod_order_qc_adj_in_number").ToString
            TxtAdjDate.EditValue = data.Rows(0)("prod_order_qc_adj_in_date")
            MENote.Text = data.Rows(0)("prod_order_qc_adj_in_note").ToString
            TEProdOrderNumber.Text = data.Rows(0)("prod_order_number").ToString

            BPickPO.Enabled = False

            id_prod_order = data.Rows(0)("id_prod_order").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetailReturn()
        End If
        allow_status()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue.ToString, "72", id_adj_in) Then
            BtnSave.Enabled = True
            GridColumnQtyInQC.Visible = True
        Else
            GridColumnQtyInQC.Visible = False
            BtnSave.Enabled = False
            GVDetail.OptionsBehavior.ReadOnly = True
        End If

        If check_print_report_status(LEReportStatus.EditValue.ToString) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_qc_adj_in('" + id_adj_in + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpProd.id_prod_order = "-1"
        FormPopUpProd.id_pop_up = "6"

        FormPopUpProd.ShowDialog()
    End Sub
    Sub empty_grid()
        For i As Integer = GVDetail.RowCount - 1 To 0 Step -1
            GVDetail.DeleteRow(i)
        Next
    End Sub
    Sub calculate()
        For i As Integer = 0 To GVDetail.RowCount - 1
            GVDetail.SetRowCellValue(i, "amount", (GVDetail.GetRowCellValue(i, "cost") * GVDetail.GetRowCellValue(i, "qty")))
        Next
        GVDetail.RefreshData()
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString), "1")
    End Sub

    Private Sub GVDetail_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        If e.Column.FieldName.ToString = "qty" Then
            calculate()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If id_prod_order = "-1" Then
            errorCustom("Please select Production Order first.")
        Else
            Dim query As String = ""

            If id_adj_in = "-1" Then
                'Main table
                query = "INSERT INTO tb_prod_order_qc_adj_in(id_prod_order,prod_order_qc_adj_in_number,prod_order_qc_adj_in_date,prod_order_qc_adj_in_note,prod_order_qc_adj_in_total,id_report_status) "
                query += "VALUES('" + id_prod_order + "','" + TxtAdjNumber.Text + "',NOW(),'" + MENote.Text + "'," + decimalSQL(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString) + ",'1'); SELECT LAST_INSERT_ID() "
                id_adj_in = execute_query(query, 0, True, "", "", "", "")

                increase_inc_prod("10")

                'preapred default
                insert_who_prepared("72", id_adj_in, id_user)

                'detail table
                query = "INSERT INTO tb_prod_order_qc_adj_in_det(id_prod_order_qc_adj_in,id_prod_order_det,prod_order_qc_adj_in_det_qty,prod_order_qc_adj_in_det_price,prod_order_qc_adj_in_det_note) VALUES "
                For i As Integer = 0 To GVDetail.RowCount - 1
                    query += "('" + id_adj_in + "','" + GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString + "','" + GVDetail.GetRowCellValue(i, "qty").ToString + "','" + GVDetail.GetRowCellValue(i, "cost").ToString + "','" + GVDetail.GetRowCellValue(i, "note").ToString + "')"
                    If Not i = GVDetail.RowCount - 1 Then
                        query += ","
                    End If
                Next
                execute_non_query(query, True, "", "", "", "")

                FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0
                FormProdQCAdj.viewAdjIn()
                Close()
            Else
                Try
                    'update main table
                    query = "UPDATE tb_prod_order_qc_adj_in SET prod_order_qc_adj_in_note='" + MENote.Text + "',prod_order_qc_adj_in_total='" + decimalSQL(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString) + "' WHERE id_prod_order_qc_adj_in='" + id_adj_in + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail table
                    query = ""
                    For i As Integer = 0 To GVDetail.RowCount - 1
                        query += "UPDATE tb_prod_order_qc_adj_in_det SET prod_order_qc_adj_in_det_qty=" + decimalSQL(GVDetail.GetRowCellValue(i, "qty").ToString) + ",prod_order_qc_adj_in_det_price=" + decimalSQL(GVDetail.GetRowCellValue(i, "cost").ToString) + ",prod_order_qc_adj_in_det_note='" + GVDetail.GetRowCellValue(i, "note").ToString + "' WHERE id_prod_order_qc_adj_in_det='" + GVDetail.GetRowCellValue(i, "id_prod_order_qc_adj_in_det").ToString + "';"
                    Next
                    execute_non_query(query, True, "", "", "", "")

                    FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0
                    FormProdQCAdj.viewAdjIn()
                    Close()
                Catch ex As Exception
                    errorCustom(ex.ToString)
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_adj_in
        FormReportMark.report_mark_type = "72"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_in
        FormDocumentUpload.report_mark_type = "72"
        If Not check_edit_report_status(LEReportStatus.EditValue.ToString, "72", id_adj_in) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        ReportProdQCAdjIn.id_adj_in = id_adj_in

        Dim Report As New ReportProdQCAdjIn()
        Report.LDesignCode.Text = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("design_code").ToString
        Report.LDesign.Text = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("design_name").ToString
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class