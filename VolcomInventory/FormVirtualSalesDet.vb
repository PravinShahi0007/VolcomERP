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
            WindowState = FormWindowState.Maximized

            Dim vs As New ClassVirtualSales()
            Dim query As String = vs.queryMain("AND vs.id_virtual_sales='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.EditValue = data.Rows(0)("created_by_name").ToString
            SLEComp.EditValue = data.Rows(0)("id_comp").ToString
            DEStart.EditValue = data.Rows(0)("start_period")
            DEEnd.EditValue = data.Rows(0)("end_period")
            MENote.Text = data.Rows(0)("note").ToString

            'detail
            viewDetail()
            allow_status()
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
            Dim query As String = "UPDATE tb_virtual_sales SET id_comp='" + id_comp + "',  
            start_period='" + start_period + "', end_period='" + end_period + "', note='" + note + "'
            WHERE id_virtual_sales='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshMainview()
        FormVirtualSales.viewDetail()
        FormVirtualSales.GVSales.FocusedRowHandle = find_row(FormVirtualSales.GVSales, "id_virtual_sales", id)
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        If id_report_status = "5" Then
            BtnCancelPropose.Visible = False
            BtnSave.Visible = False
            BtnImportXLS.Visible = False
            SLEComp.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
            MENote.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        saveHead()

        'view
        refreshMainview()
        actionLoad()
        infoCustom("Save success")
    End Sub

    Private Sub BtnCancelPropose_Click(sender As Object, e As EventArgs) Handles BtnCancelPropose.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_virtual_sales SET id_report_status=5 WHERE id_virtual_sales='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            refreshMainview()
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnImportXLS_Click(sender As Object, e As EventArgs) Handles BtnImportXLS.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "64"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class