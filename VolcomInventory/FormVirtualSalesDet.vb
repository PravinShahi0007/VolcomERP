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
        FormVirtualSales.viewSalesList()
        FormVirtualSales.GVSales.FocusedRowHandle = find_row(FormVirtualSales.GVSales, "id_virtual_sales", id)
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT vd.id_virtual_sales_det, vd.id_virtual_sales, 
        vd.barcode, vd.id_product, vd.id_design, cd.class,p.product_display_name AS `name`, cd.color, cd.code_detail_name AS `size`, 
        vd.qty, vd.qty_erp 
        FROM tb_virtual_sales_det vd
        INNER JOIN tb_m_product p ON p.id_product = vd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        LEFT JOIN (
	        SELECT dc.id_design, 
	        MAX(CASE WHEN cd.id_code=32 THEN cd.id_code_detail END) AS `id_division`,
	        MAX(CASE WHEN cd.id_code=32 THEN cd.code_detail_name END) AS `division`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.id_code_detail END) AS `id_class`,
	        MAX(CASE WHEN cd.id_code=30 THEN cd.display_name END) AS `class`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.id_code_detail END) AS `id_color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.display_name END) AS `color`,
	        MAX(CASE WHEN cd.id_code=14 THEN cd.code_detail_name END) AS `color_desc`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.id_code_detail END) AS `id_sht`,
	        MAX(CASE WHEN cd.id_code=43 THEN cd.code_detail_name END) AS `sht`
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail 
	        AND cd.id_code IN (32,30,14, 43)
	        GROUP BY dc.id_design
        ) cd ON cd.id_design = vd.id_design
        WHERE vd.id_virtual_sales=" + id + "
        ORDER BY cd.class ASC, p.product_display_name ASC, vd.barcode ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCreateNew.Visible = False
        SLEComp.Enabled = False
        DEStart.Enabled = False
        DEEnd.Enabled = False
        If id_report_status = "5" Then
            BtnCancelPropose.Visible = False
            BtnSave.Visible = False
            BtnImportXLS.Visible = False
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

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        If action = "ins" Then
            Dim id_comp As String = "-1"
            Try
                id_comp = SLEComp.EditValue.ToString
            Catch ex As Exception
            End Try
            Dim qry As String = "SELECT STR_TO_DATE(DATE_ADD(DATE(NOW()), INTERVAL - (WEEKDAY(DATE(NOW()))+1) DAY), '%Y-%m-%d') AS `last_beg_date` "
            Dim dt As DataTable = execute_query(qry, -1, True, "", "", "", "")
            Dim last_beg_date As String = Date.Parse(dt.Rows(0)("last_beg_date").ToString).ToString("yyyy-MM-dd")
            'get min date
            Dim query_cek As String = "SELECT IFNULL(DATE_ADD(MAX(sp.sales_pos_end_period),INTERVAL 1 DAY),'1991-05-18') AS `min_date`,
            DATE_ADD('" + last_beg_date + "', INTERVAL 7 DAY) AS `max_date`
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            WHERE c.id_comp=" + id_comp + " AND sp.sales_pos_date<='" + last_beg_date + "' AND sp.id_report_status=6 "
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            Dim min_date As Date = data_cek.Rows(0)("min_date")
            Dim max_date As Date =data_cek.Rows(0)("max_date")
            DEStart.Properties.MinValue = min_date
            DEStart.Properties.MaxValue = max_date
            DEEnd.Properties.MinValue = min_date
            DEEnd.Properties.MaxValue = max_date
            DEStart.EditValue = min_date
            DEEnd.EditValue = min_date
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        If action = "ins" Then
            DEEnd.Properties.MinValue = DEStart.EditValue
        End If
    End Sub
End Class