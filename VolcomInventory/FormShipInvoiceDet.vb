Public Class FormShipInvoiceDet
    Public id As String = "-1"
    Public report_mark_type As String = "249"
    Public is_view = "-1"

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub FormShipInvoiceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim sh As New ClassShipInvoice()
        Dim query As String = sh.queryMain("AND s.id_invoice_ship='" + id + "'", 1)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
        TxtOLStoreNumber.Text = data.Rows(0)("order_number").ToString
        TXTName.Text = data.Rows(0)("customer_name").ToString
        DEDueDate.EditValue = data.Rows(0)("due_date")
        DEStart.EditValue = data.Rows(0)("start_period")
        DEEnd.EditValue = data.Rows(0)("end_period")
        DECreated.Text = data.Rows(0)("created_date")
        TxtNumber.Text = data.Rows(0)("number").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        'MENote.Text = data.Rows(0)("order_number").ToString
        viewDetail()
        allowStatus()
        BtnPrint.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_invoice_ship_det, d.id_invoice_ship, d.id_acc, coa.acc_name, coa.acc_description, d.value, d.note 
        FROM tb_invoice_ship_det d 
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        WHERE d.id_invoice_ship=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()

    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.report_mark_type = report_mark_type
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=" + report_mark_type + " AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            FormViewJournal.show_trans_number = True
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormShipInvoiceDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class