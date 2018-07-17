Public Class FormBudgetRevProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormBudgetRevProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTotalInput.EditValue = 0.00
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormBudgetRevProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        BtnPrint.Visible = True
        BtnAttachment.Visible = True
        BtnMark.Visible = True
        Dim query_c As New ClassBudgetRevPropose()
        Dim query As String = query_c.queryMain("AND rp.id_b_revenue_propose=" + id + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtYear.Text = data.Rows(0)("year").ToString
        TxtTotal.EditValue = data.Rows(0)("total")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        viewDetail()
        getTotal()
        allow_status()
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_b_revenue_propose(" + id + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If
    End Sub

    Sub getTotal()
        Dim query As String = "SELECT IFNULL(SUM(bd.b_revenue_propose),0) AS `total` FROM tb_b_revenue_propose_det bd WHERE bd.id_b_revenue_propose=" + id + ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotalInput.EditValue = data.Rows(0)("total")
        TxtDiff.EditValue = TxtTotal.EditValue - TxtTotalInput.EditValue
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "133"
        FormReportMark.id_report = id
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnChange.Click
        Cursor = Cursors.WaitCursor
        FormBudgetRevProposeNew.action = "upd"
        FormBudgetRevProposeNew.id = id
        FormBudgetRevProposeNew.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim old_val As Decimal = 0
        Try
            old_val = GVData.ActiveEditor.OldEditValue
        Catch ex As Exception
            old_val = 0
        End Try
        Dim row_foc As String = e.RowHandle.ToString
        Dim month As String = e.Column.FieldName.ToString
        Dim id_store As String = GVData.GetRowCellValue(row_foc, "id_comp")
        Dim b_revenue_propose As String = decimalSQL(e.Value.ToString)
        If (TxtTotalInput.EditValue + e.Value) <= TxtTotal.EditValue Then
            Dim query As String = "DELETE FROM tb_b_revenue_propose_det 
            WHERE id_b_revenue_propose = " + id + " And id_store = " + id_store + " And month = " + month + ";
            INSERT INTO tb_b_revenue_propose_det(id_b_revenue_propose, id_store, month, b_revenue_propose)
            VALUES('" + id + "','" + id_store + "', '" + month + "','" + b_revenue_propose + "'); "
            execute_non_query(query, True, "", "", "", "")
            GVData.RefreshData()
            GVData.BestFitColumns()
            getTotal()
        Else
            stopCustom("Total budget higher than yearly budget.")
            GVData.SetRowCellValue(row_foc, month, old_val)
            GVData.RefreshData()
            GVData.BestFitColumns()
        End If

        Cursor = Cursors.Default
        'Dim id_comp As String = GVData.GetRowCellValue(row_foc, "id_comp").ToString
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText

    End Sub
End Class