Public Class FormRoyaltyRateDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "407"
    Dim dvs As System.IO.Stream

    Private Sub FormRoyaltyRateDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormRoyaltyRateDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'cek on process
            Dim qcek As String = "SELECT * FROM tb_royalty_rate c WHERE c.id_report_status<5 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                Cursor = Cursors.Default
                stopCustom("Please complete all pending propose first")
                Close()
            End If

            'option
            'default date
            Dim curr_date As DateTime = getTimeDB()
            Dim curr_year As String = DateTime.Parse(curr_date.ToString).ToString("yyyy")
            DECreated.EditValue = curr_date
            TxtStart.Text = curr_year
            TxtEnd.Text = curr_year
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim r As New ClassRoyaltyRate()
            Dim query As String = r.queryMain("AND  r.id_royalty_rate='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            TxtStart.Text = data.Rows(0)("year_start").ToString
            TxtEnd.Text = data.Rows(0)("year_end").ToString
            TxtRoyaltyRate.EditValue = data.Rows(0)("royalty_rate").ToString
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")

            'detail
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnSaveChanges.Visible = False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        TxtStart.Enabled = False
        TxtEnd.Enabled = False
        TxtRoyaltyRate.Enabled = False
        MENote.Enabled = False
        BtnPrint.Visible = True

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to submit this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim royalty_rate As String = decimalSQL(TxtRoyaltyRate.Text.ToString).ToString

        End If
    End Sub
End Class