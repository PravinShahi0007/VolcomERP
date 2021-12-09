Public Class FormEtsDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "370"
    Dim dvs As System.IO.Stream

    Private Sub FormEtsDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormEtsDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
            Dim qcek As String = "SELECT * FROM tb_ets c WHERE c.id_report_status<5 "
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                Cursor = Cursors.Default
                stopCustom("Please complete all pending propose first")
                Close()
            End If

            'option
            BtnCreateNew.Visible = True
            Width = 450
            Height = 230
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            'location form
            Dim r As Rectangle
            If Parent IsNot Nothing Then
                r = Parent.RectangleToScreen(Parent.ClientRectangle)
            Else
                r = Screen.FromPoint(Location).WorkingArea
            End If

            Dim x = r.Left + (r.Width - Width) \ 2
            Dim y = r.Top + (r.Height - Height) \ 2
            Location = New Point(x, y)
            'default date
            Dim curr_date As DateTime = getTimeDB()
            DEEffectDate.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim mkd As New ClassEts()
            Dim query As String = mkd.queryMain("AND  e.id_ets='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DEEffectDate.EditValue = data.Rows(0)("effective_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            Dim is_show_all As String = ""
            If is_confirm = "2" And id_report_status = "1" Then
                is_show_all = "1"
            Else
                is_show_all = "2"
            End If

            'detail
            viewDetailPTH()
            viewDetail(is_show_all)
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailPTH()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT p.id_pp_change, p.number, p.effective_date, p.plan_end_date 
        FROM tb_ets_det e
        INNER JOIN tb_pp_change_det pd ON pd.id_pp_change_det = e.id_pp_change_det
        INNER JOIN tb_pp_change p ON p.id_pp_change = pd.id_pp_change
        WHERE e.id_ets='" + id + "'
        GROUP BY p.id_pp_change "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPTH.DataSource = data
        GVPTH.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail(ByVal is_show_all As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()

    End Sub
End Class