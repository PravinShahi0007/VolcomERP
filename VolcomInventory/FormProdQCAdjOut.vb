Public Class FormProdQCAdjOut 
    Public id_adj_out As String = "-1"
    Public id_prod_order As String = "-1"
    Public id_report_status As String = "-1"

    Private Sub FormProdQCAdjOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If id_adj_out = "-1" Then 'new
            viewDetailQCAdjOut()
            TxtAdjDate.EditValue = view_date(-1)

            BMark.Visible = False
            BtnAttachment.Visible = False
            BtnPrint.Visible = False

            TxtAdjNumber.Text = header_number_prod("11")
        Else 'edit
            Dim query As String = "SELECT tb_prod_order_qc_adj_out.id_prod_order,tb_prod_order.prod_order_number,prod_order_qc_adj_out_number,prod_order_qc_adj_out_date,prod_order_qc_adj_out_note,tb_prod_order_qc_adj_out.id_report_status FROM tb_prod_order_qc_adj_out INNER JOIN tb_prod_order ON tb_prod_order.id_prod_order=tb_prod_order_qc_adj_out.id_prod_order WHERE id_prod_order_qc_adj_out='" + id_adj_out + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtAdjNumber.Text = data.Rows(0)("prod_order_qc_adj_out_number").ToString
            TxtAdjDate.EditValue = data.Rows(0)("prod_order_qc_adj_out_date")
            MENote.Text = data.Rows(0)("prod_order_qc_adj_out_note").ToString
            TEProdOrderNumber.Text = data.Rows(0)("prod_order_number").ToString

            BPickPO.Enabled = False

            id_prod_order = data.Rows(0)("id_prod_order").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetailQCAdjOut()
        End If
        allow_status()
    End Sub

    Sub viewDetailQCAdjOut()
        Dim query As String = ""
        query += "CALL view_qc_adj_out('" + id_adj_out + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub

    Private Sub FormProdQCAdjOut_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpProd.id_prod_order = "-1"
        FormPopUpProd.id_pop_up = "7"

        FormPopUpProd.ShowDialog()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue.ToString, "73", id_adj_out) Then
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
            
            If id_adj_out = "-1" Then
                'Main table
                query = "INSERT INTO tb_prod_order_qc_adj_out(id_prod_order,prod_order_qc_adj_out_number,prod_order_qc_adj_out_date,prod_order_qc_adj_out_note,prod_order_qc_adj_out_total,id_report_status) "
                query += "VALUES('" + id_prod_order + "','" + TxtAdjNumber.Text + "',NOW(),'" + MENote.Text + "'," + decimalSQL(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString) + ",'1'); SELECT LAST_INSERT_ID() "
                id_adj_out = execute_query(query, 0, True, "", "", "", "")

                increase_inc_prod("11")

                'preapred default
                insert_who_prepared("73", id_adj_out, id_user)

                'detail table
                query = "INSERT INTO tb_prod_order_qc_adj_out_det(id_prod_order_qc_adj_out,id_prod_order_det,prod_order_qc_adj_out_det_qty,prod_order_qc_adj_out_det_price,prod_order_qc_adj_out_det_note) VALUES "
                For i As Integer = 0 To GVDetail.RowCount - 1
                    query += "('" + id_adj_out + "','" + GVDetail.GetRowCellValue(i, "id_prod_order_det").ToString + "','" + GVDetail.GetRowCellValue(i, "qty").ToString + "','" + GVDetail.GetRowCellValue(i, "cost").ToString + "','" + GVDetail.GetRowCellValue(i, "note").ToString + "')"
                    If Not i = GVDetail.RowCount - 1 Then
                        query += ","
                    End If
                Next
                execute_non_query(query, True, "", "", "", "")

                FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 1
                FormProdQCAdj.viewAdjOut()
                Close()
            Else
                Try
                    'update main table
                    query = "UPDATE tb_prod_order_qc_adj_out SET prod_order_qc_adj_out_note='" + MENote.Text + "',prod_order_qc_adj_out_total='" + decimalSQL(Decimal.Parse(GVDetail.Columns("amount").SummaryItem.SummaryValue).ToString) + "' WHERE id_prod_order_qc_adj_out='" + id_adj_out + "' "
                    execute_non_query(query, True, "", "", "", "")

                    'detail table
                    query = ""
                    For i As Integer = 0 To GVDetail.RowCount - 1
                        query += "UPDATE tb_prod_order_qc_adj_out_det SET prod_order_qc_adj_out_det_qty='" + decimalSQL(GVDetail.GetRowCellValue(i, "qty").ToString) + "',prod_order_qc_adj_out_det_price='" + decimalSQL(GVDetail.GetRowCellValue(i, "cost").ToString) + "',prod_order_qc_adj_out_det_note='" + GVDetail.GetRowCellValue(i, "note").ToString + "' WHERE id_prod_order_qc_adj_out_det='" + GVDetail.GetRowCellValue(i, "id_prod_order_qc_adj_out_det").ToString + "';"
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
        FormReportMark.id_report = id_adj_out
        FormReportMark.report_mark_type = "73"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_adj_out
        FormDocumentUpload.report_mark_type = "73"
        If Not check_edit_report_status(LEReportStatus.EditValue.ToString, "73", id_adj_out) Then
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
        ReportProdQCAdjOut.id_adj_out = id_adj_out

        Dim Report As New ReportProdQCAdjOut()
        Report.LDesignCode.Text = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("design_code").ToString
        Report.LDesign.Text = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("design_name").ToString
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class