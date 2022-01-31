Public Class FormVirtualSalesDet
    Public id As String = "-1"
    Public action As String = ""
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "390"

    Private Sub FormVirtualSalesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewComp()
        actionLoad()
    End Sub

    Private Sub FormVirtualSalesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewComp()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        (SELECT c.id_comp, CONCAT(c.comp_number, ' - ', c.comp_name) AS `comp` 
        FROM tb_m_comp c 
        WHERE c.id_comp_cat=6 
        ORDER BY c.id_comp ASC) "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If Action = "ins" Then
            'option
            BtnCreateNew.Visible = True
            Width = 456
            Height = 216
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            FormBorderStyle = FormBorderStyle.FixedDialog
            StartPosition = FormStartPosition.CenterScreen
            PanelControlTopLeft.Visible = False
            PanelControlNav.Visible = False
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
        ElseIf Action = "upd" Then
            'WindowState = FormWindowState.Maximized

            'Dim sd As New ClassStoreDisplay()
            'Dim query As String = sd.queryMain("AND  p.id_display_pps='" + id + "' ", "1")
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'TxtNumber.Text = data.Rows(0)("number").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'id_report_status = data.Rows(0)("id_report_status").ToString
            'is_confirm = data.Rows(0)("is_confirm").ToString
            'DECreated.EditValue = data.Rows(0)("created_date")
            'TxtCreatedBy.EditValue = data.Rows(0)("created_by_name").ToString
            'DEUpdated.EditValue = data.Rows(0)("updated_date")
            'TxtUpdatedBy.EditValue = data.Rows(0)("updated_by_name").ToString
            'SLESeason.EditValue = data.Rows(0)("id_season").ToString
            'SLEComp.EditValue = data.Rows(0)("id_comp").ToString
            'MENote.Text = data.Rows(0)("note").ToString
            'is_confirm = data.Rows(0)("is_confirm").ToString

            ''detail
            'viewDetailSeason()
            'viewDetail()
            'allow_status()

            ''cek class mapping - aktifkan saat live
            ''checkClassGroup()

            ''cek status toko
            'Dim store_stt As String = execute_query("SELECT IFNULL(c.is_active,0) AS `is_active` FROM tb_m_comp c WHERE c.id_comp='" + SLEComp.EditValue.ToString + "'", 0, True, "", "", "", "")
            'If store_stt <> "1" Then
            '    warningCustom("Display toko tidak bisa diproses karena status toko tidak aktif")
            '    Cursor = Cursors.Default
            '    Close()
            'End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles BtnCreateNew.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create New propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            saveHead()
        End If
    End Sub

    Sub saveHead()
        Cursor = Cursors.WaitCursor
        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim note As String = addSlashes(MENote.Text)
        If action = "ins" Then
            Dim query As String = "INSERT INTO tb_virtual_sales(created_date, created_by, id_comp, start_period, end_period, id_report_status, note) 
            VALUES(NOW(), '" + id_user + "', '" + id_comp + "', '" + start_period + "', '" + end_period + "', 1, '" + note + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")
            refreshMainview()
            FormVirtualSales.is_load_new = True
            Close()
        ElseIf action = "upd" Then

        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshMainview()

        FormStoreDisplay.viewPps()
        FormStoreDisplay.GVPPS.FocusedRowHandle = find_row(FormStoreDisplay.GVPPS, "id_display_pps", id)
    End Sub
End Class