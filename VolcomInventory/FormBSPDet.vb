Public Class FormBSPDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Dim rmt As String = "376"
    Dim dvs As System.IO.Stream

    Private Sub FormBSPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewStore()
        actionLoad()
    End Sub

    Private Sub FormBSPDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewStore()
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number, ' - ',c.comp_name) AS `comp` 
        FROM tb_m_comp c WHERE c.id_comp_cat=6 AND c.id_store_type=3 "
        If action = "ins" Then
            query += "AND c.is_active=1 "
        End If
        viewSearchLookupQuery(SLEStore, query, "id_comp", "comp", "id_comp")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            Width = 450
            Height = 200
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControl1.Visible = False
            PanelControlBottom.Visible = False
            XTCData.Visible = False
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
            DEStartDate.EditValue = curr_date
            DEEndDate.EditValue = curr_date
            TxtNumber.Text = "[auto generated]"
        ElseIf action = "upd" Then
            Dim mkd As New ClassBSP()
            Dim query As String = mkd.queryMain("AND  b.id_bsp='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            SLEStore.EditValue = data.Rows(0)("id_comp").ToString
            DEStartDate.EditValue = data.Rows(0)("start_date")
            DEEndDate.EditValue = data.Rows(0)("end_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            is_confirm = data.Rows(0)("is_confirm").ToString
            If is_confirm = "1" Then
                XTCData.SelectedTabPageIndex = 1
            End If

            'detail
            viewDetail()
            viewSum()
            allowStatus()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()

    End Sub

    Sub viewSum()

    End Sub

    Sub allowStatus()

    End Sub
End Class