Public Class FormLineListChangesHistory
    Public id_season As String = "-1"
    Public id_design As String = "-1"
    Public is_from_beginning As Boolean = False
    Private Sub FormLineListChangesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtnow As DateTime = getTimeDB()
        DEFrom.EditValue = dtnow
        DEUntil.EditValue = dtnow
        If is_from_beginning Then
            DEFrom.EditValue = New Date(2010, 1, 1)
        End If
        If id_design <> "-1" Then
            viewLog()
        End If
    End Sub

    Private Sub FormLineListChangesHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewLog()
    End Sub

    Sub viewLog()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT ll.log_date, IFNULL(eu.employee_name,'Volcom ERP') AS `user_modified`, IFNULL(ec.employee_name,'Volcom ERP') AS `user_created`,
        ll.report_mark_type, rmt.report_mark_type_name, ll.id_report, ll.report_number, ll.report_date,
        ll.id_design, d.design_code AS `code`, cd.class, d.design_display_name AS `name`, cd.color, cd.sht,
        ll.note
        FROM tb_log_line_list ll
        LEFT JOIN tb_m_user u ON u.id_user = ll.id_user_modified
        LEFT JOIN tb_m_employee eu ON eu.id_employee = u.id_employee
        LEFT JOIN tb_m_user uc ON uc.id_user = ll.id_user_created
        LEFT JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = ll.report_mark_type
        INNER JOIN tb_m_design d ON d.id_design = ll.id_design
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
        ) cd ON cd.id_design = d.id_design
        WHERE DATE(ll.log_date)>='" + date_from_selected + "' AND DATE(ll.log_date)<='" + date_until_selected + "' "
        If id_season <> "-1" Then
            query += "AND (d.id_season='" + id_season + "' OR d.id_season_move='" + id_season + "') "
        End If
        If id_design <> "-1" Then
            query += "AND d.id_design='" + id_design + "' "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class