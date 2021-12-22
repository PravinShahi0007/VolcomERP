Public Class FormSOPIndex
    Public is_super_admin As String = "2"

    Private Sub FormSOPIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_super_admin = "1" Then
            BMasterCatSOP.Visible = True
            XTPIndexPPS.PageVisible = True
            XTPScheduleSOPAdmin.PageVisible = True
            XTPDepartemenTerkait.PageVisible = True
            XTPReqMenuERP.PageVisible = True
        Else
            BMasterCatSOP.Visible = False
            XTPIndexPPS.PageVisible = False
            XTPScheduleSOPAdmin.PageVisible = False
            XTPDepartemenTerkait.PageVisible = True
            XTPReqMenuERP.PageVisible = False
        End If
        XTCSOPIndex.SelectedTabPageIndex = 0
    End Sub

    Private Sub FormSOPIndex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BNewSOP_Click(sender As Object, e As EventArgs) Handles BNewSOP.Click
        'FormSOPNew.ShowDialog()
        FormSOPIndexPPS.ShowDialog()
    End Sub

    Private Sub GVBySOP_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVBySOP.CellMerge
        If (e.Column.FieldName = "doc_desc" Or e.Column.FieldName = "milestone" Or e.Column.FieldName = "sop_name" Or e.Column.FieldName = "sop_number" Or e.Column.FieldName = "sop_prosedur" Or e.Column.FieldName = "sop_prosedur_sub" Or e.Column.FieldName = "departement") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_sop")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_sop")

            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub GVDepartementTerkait_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVDepartementTerkait.CellMerge
        If (e.Column.FieldName = "doc_desc" Or e.Column.FieldName = "milestone" Or e.Column.FieldName = "sop_name" Or e.Column.FieldName = "sop_number" Or e.Column.FieldName = "sop_prosedur" Or e.Column.FieldName = "sop_prosedur_sub" Or e.Column.FieldName = "departement") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_sop")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_sop")

            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub GVByModul_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVByModul.CellMerge
        If (e.Column.FieldName = "menu_caption") Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "id_menu")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "id_menu")

            e.Merge = (val1.ToString = val2.ToString)
            e.Handled = True
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        If XTCSOPIndex.SelectedTabPageIndex = 0 Then 'by SOP
            Dim q As String = "SELECT s.*,spsub.sop_prosedur_sub,sp.sop_prosedur,dep.departement,m.menu_name,m.`menu_caption`,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename,d.doc_desc
,CONCAT(sch.milestone,' - ',sch.sts_meeting) AS milestone
FROM `tb_sop` s
INNER JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
INNER JOIN tb_sop_prosedur_sub spsub ON spsub.id_sop_prosedur_sub=s.id_sop_prosedur_sub
INNER JOIN tb_sop_prosedur sp ON sp.id_sop_prosedur=spsub.id_sop_prosedur
LEFT JOIN tb_sop_menu_erp er ON er.id_sop=s.id_sop
LEFT JOIN tb_menu m ON m.`id_menu`=er.`id_menu`
LEFT JOIN (SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop AND d.report_mark_type=371
LEFT JOIN
(
    SELECT sch.*,IF(sch.is_complete=1,'Complete','Not Complete') AS sts_meeting,ml.milestone 
    FROM tb_sop_schedule_sop sch
    INNER JOIN tb_lookup_milestone ml ON ml.id_milestone=sch.id_milestone
    INNER JOIN (
	    SELECT id_sop,MAX(`datetime`) AS dt
	    FROM `tb_sop_schedule_sop`
	    WHERE NOT ISNULL(id_milestone) AND NOT ISNULL(is_complete)
	    GROUP BY id_sop
    )schm ON schm.id_sop=sch.id_sop AND sch.datetime=schm.dt
)sch ON sch.id_sop=s.id_sop "
            If Not is_super_admin = "1" Then
                q += " WHERE s.id_departement='" & id_departement_user & "' "
            End If

            q += " ORDER BY s.id_sop "

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCBySOP.DataSource = dt
            GVBySOP.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 1 Then 'by menu
            Dim qw As String = ""

            If Not is_super_admin = "1" Then
                qw = " AND emp.`id_departement`='" & id_departement_user & "' AND emp.`id_employee_active`=1 "
            End If

            Dim q As String = "SELECT s.*,spsub.sop_prosedur_sub,sp.sop_prosedur,dep.departement,m.id_menu,m.menu_name,m.`menu_caption`,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename,d.doc_desc
,CONCAT(sch.milestone,' - ',sch.sts_meeting) AS milestone
FROM (
	SELECT m.id_menu,m.`description_menu_name`,m.`menu_caption`,m.`menu_name`
	FROM tb_m_user usr
	INNER JOIN tb_m_employee emp ON usr.`id_employee`=emp.`id_employee` " & qw & "
	INNER JOIN `tb_menu_acc` menu ON menu.`id_role`=usr.`id_role`
	INNER JOIN tb_m_role role ON role.`id_role`=menu.`id_role`
	INNER JOIN tb_menu_form_control c ON c.`id_form_control`=menu.`id_form_control`
	INNER JOIN tb_menu_form f ON f.`id_form`=c.`id_form`
	INNER JOIN `tb_menu_involved` i ON i.`id_form`=f.`id_form`
	INNER JOIN tb_menu m ON m.`id_menu`=i.`id_menu`
	GROUP BY m.`id_menu`
) m
LEFT JOIN tb_sop_menu_erp er ON er.id_menu=m.id_menu
LEFT JOIN `tb_sop` s ON s.`id_sop`=er.`id_sop`
LEFT JOIN
(
    SELECT sch.*,IF(sch.is_complete=1,'Complete','Not Complete') AS sts_meeting,ml.milestone 
    FROM tb_sop_schedule_sop sch
    INNER JOIN tb_lookup_milestone ml ON ml.id_milestone=sch.id_milestone
    INNER JOIN (
	    SELECT id_sop,MAX(`datetime`) AS dt
	    FROM `tb_sop_schedule_sop`
	    WHERE NOT ISNULL(id_milestone) AND NOT ISNULL(is_complete)
	    GROUP BY id_sop
    )schm ON schm.id_sop=sch.id_sop AND sch.datetime=schm.dt
)sch ON sch.id_sop=s.id_sop
LEFT JOIN tb_sop_prosedur_sub spsub ON spsub.id_sop_prosedur_sub=s.id_sop_prosedur_sub
LEFT JOIN tb_sop_prosedur sp ON sp.id_sop_prosedur=spsub.id_sop_prosedur
LEFT JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
LEFT JOIN 
(SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop
ORDER BY id_menu"

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCByModul.DataSource = dt
            GVByModul.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 2 Then 'schedule admin
            view_sop_schedule_admin()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 3 Then 'schedule guest
            view_sop_schedule_guest()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 4 Then 'Index Proposal
            Dim q As String = "SELECT pps.*,sts.report_status,dep.departement FROM `tb_sop_pps` pps
INNER JOIN tb_m_departement dep ON dep.id_departement=pps.id_departement
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_sop_pps DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCIndexPPS.DataSource = dt
            GVIndexPPS.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 5 Then 'kelengkapan SOP Proposal
            Dim q As String = "SELECT pps.*,sts.report_status,s.sop_name
FROM `tb_sop_dep_pps` pps
INNER JOIN tb_sop s ON s.id_sop=pps.id_sop
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status
ORDER BY pps.id_sop_dep_pps DESC"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCPengajuanKelengkapan.DataSource = dt
            GVPengajuanKelengkapan.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 6 Then
            Dim q As String = "SELECT s.*,spsub.sop_prosedur_sub,sp.sop_prosedur,dep.departement
,d.doc_desc
,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename
,sch.sts_milestone AS milestone
FROM `tb_sop` s
INNER JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
INNER JOIN tb_sop_prosedur_sub spsub ON spsub.id_sop_prosedur_sub=s.id_sop_prosedur_sub
INNER JOIN tb_sop_prosedur sp ON sp.id_sop_prosedur=spsub.id_sop_prosedur
LEFT JOIN (SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop AND d.report_mark_type=371 
LEFT JOIN
(
    SELECT sch.*,IF(sch.is_complete=1,'Complete','Not Complete') AS sts_meeting,ml.milestone ,CONCAT(ml.milestone,' - ',IF(sch.is_complete=1,'Complete','Not Complete')) AS sts_milestone
    FROM tb_sop_schedule_sop sch
    INNER JOIN tb_lookup_milestone ml ON ml.id_milestone=sch.id_milestone
    INNER JOIN (
	    SELECT id_sop,MAX(`datetime`) AS dt
	    FROM `tb_sop_schedule_sop`
	    WHERE NOT ISNULL(id_milestone) AND NOT ISNULL(is_complete)
	    GROUP BY id_sop
    )schm ON schm.id_sop=sch.id_sop AND sch.datetime=schm.dt
)sch ON sch.id_sop=s.id_sop
INNER JOIN `tb_sop_dep_terkait` sd ON sd.`id_sop`=s.`id_sop`
WHERE sd.`id_departement`='" & id_departement_user & "'
GROUP BY s.`id_sop`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCDepartementTerkait.DataSource = dt
            GVDepartementTerkait.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 7 Then
            Dim q As String = "SELECT s.*,pps.`created_date`,dep.departement,pps.req_menu_erp
,d.doc_desc
,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename
FROM `tb_sop_dep_pps` pps
INNER JOIN `tb_sop` s ON s.`id_sop`=pps.`id_sop` AND pps.`id_report_status`=6
INNER JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
LEFT JOIN (SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop AND d.report_mark_type=371 
WHERE req_menu_erp != ''"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCReqMenuERP.DataSource = dt
            GVReqMenuERP.BestFitColumns()
        End If
    End Sub

    Private Sub GVBySOP_DoubleClick(sender As Object, e As EventArgs) Handles GVBySOP.DoubleClick
        If GVBySOP.RowCount > 0 Then
            'FormSOPNew.id_sop = GVBySOP.GetFocusedRowCellValue("id_sop").ToString
            'FormSOPNew.ShowDialog()
        End If
    End Sub

    Sub download_doc(ByVal server_file_name As String, ByVal file_desc As String)
        Dim FILE_NAME As String = ""
        Try
            Dim path As String = Application.StartupPath & "\download\"
            Dim source_path As String = get_setup_field("upload_dir")

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            'download
            My.Computer.Network.DownloadFile(source_path & "371" & "\" & server_file_name, path & file_desc & "_" & server_file_name, "", "", True, 100, True)

            'open folder
            If IO.File.Exists(path & file_desc & "_" & server_file_name) Then
                FILE_NAME = ""
                FILE_NAME = path & file_desc & "_" & server_file_name

                Dim small_filename As String = ""
                small_filename = file_desc & "_" & server_file_name

                If IO.File.Exists(FILE_NAME) = True Then
                    Dim processinfo As ProcessStartInfo = New ProcessStartInfo()
                    processinfo.WindowStyle = ProcessWindowStyle.Maximized
                    processinfo.WorkingDirectory = path
                    processinfo.FileName = small_filename
                    Process.Start(processinfo)
                Else
                    MsgBox("File Does Not Exist")
                End If
            Else
                stopCustom("No Supporting Document !")
            End If
        Catch ex As Exception
            log_error("Path : " & FILE_NAME & vbNewLine & "Errornya : " & ex.ToString)
        End Try
    End Sub

    Private Sub RepoLinkFile_Click(sender As Object, e As EventArgs) Handles RepoLinkFile.Click
        'download file
        'merge gk bisa
        If XTCSOPIndex.SelectedTabPageIndex = 0 Then
            If Not GVBySOP.GetFocusedRowCellValue("doc_desc").ToString = "" Then
                download_doc(GVBySOP.GetFocusedRowCellValue("filename").ToString, GVBySOP.GetFocusedRowCellValue("doc_desc").ToString)
            End If
        End If
    End Sub

    Private Sub RepoLinkFileDepTerkait_Click(sender As Object, e As EventArgs) Handles RepoLinkFileDepTerkait.Click
        'download file
        'merge gk bisa
        If XTCSOPIndex.SelectedTabPageIndex = 6 Then
            If Not GVDepartementTerkait.GetFocusedRowCellValue("doc_desc").ToString = "" Then
                download_doc(GVDepartementTerkait.GetFocusedRowCellValue("filename").ToString, GVDepartementTerkait.GetFocusedRowCellValue("doc_desc").ToString)
            End If
        End If
    End Sub

    Private Sub RepoReqMenu_Click(sender As Object, e As EventArgs) Handles RepoReqMenu.Click
        'download file
        'merge gk bisa
        If XTCSOPIndex.SelectedTabPageIndex = 7 Then
            If Not GVReqMenuERP.GetFocusedRowCellValue("doc_desc").ToString = "" Then
                download_doc(GVReqMenuERP.GetFocusedRowCellValue("filename").ToString, GVReqMenuERP.GetFocusedRowCellValue("doc_desc").ToString)
            End If
        End If
    End Sub

    Private Sub RepoFileByModul_Click(sender As Object, e As EventArgs) Handles RepoFileByModul.Click
        'download file
        If XTCSOPIndex.SelectedTabPageIndex = 1 Then
            If Not GVByModul.GetFocusedRowCellValue("doc_desc").ToString = "" Then
                download_doc(GVByModul.GetFocusedRowCellValue("filename").ToString, GVByModul.GetFocusedRowCellValue("doc_desc").ToString)
            End If
        End If
    End Sub

    Private Sub RepoLinkMenuERP_Click(sender As Object, e As EventArgs) Handles RepoLinkMenuERP.Click
        'menu link
        If XTCSOPIndex.SelectedTabPageIndex = 0 Then
            If Not GVBySOP.GetFocusedRowCellValue("menu_name").ToString = "" Then
                FormMain.call_click(GVBySOP.GetFocusedRowCellValue("menu_name").ToString)
            End If
        End If
    End Sub

    Private Sub RepoMenuByModul_Click(sender As Object, e As EventArgs) Handles RepoMenuByModul.Click
        'menu link
        'merge gk bisa
        If XTCSOPIndex.SelectedTabPageIndex = 1 Then
            If Not GVByModul.GetFocusedRowCellValue("menu_name").ToString = "" Then
                FormMain.call_click(GVByModul.GetFocusedRowCellValue("menu_name").ToString)
            End If
        End If
    End Sub

    Private Sub GCBySOP_MouseClick(sender As Object, e As MouseEventArgs) Handles GCBySOP.MouseClick
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GVBySOP.CalcHitInfo(New Point(e.X, e.Y))
        If hi.InRowCell AndAlso hi.Column IsNot Nothing AndAlso hi.Column.FieldName = "doc_desc" Then
            If Not GVBySOP.GetFocusedRowCellValue("doc_desc").ToString = "" Then
                download_doc(GVBySOP.GetFocusedRowCellValue("filename").ToString, GVBySOP.GetFocusedRowCellValue("doc_desc").ToString)
            End If
        End If
    End Sub

    Private Sub GCByModul_MouseClick(sender As Object, e As MouseEventArgs) Handles GCByModul.MouseClick
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = GVByModul.CalcHitInfo(New Point(e.X, e.Y))
        If hi.InRowCell AndAlso hi.Column IsNot Nothing AndAlso hi.Column.FieldName = "menu_caption" Then
            If Not GVByModul.GetFocusedRowCellValue("menu_name").ToString = "" Then
                FormMain.call_click(GVByModul.GetFocusedRowCellValue("menu_name").ToString)
            End If
        End If
    End Sub

    Private Sub SBAddSchedule_Click(sender As Object, e As EventArgs) Handles SBAddSchedule.Click
        FormSOPIndexSchedule.ShowDialog()
    End Sub

    Private Sub BMasterCatSOP_Click(sender As Object, e As EventArgs) Handles BMasterCatSOP.Click
        FormSOPCat.ShowDialog()
    End Sub

    Private Sub GVIndexPPS_DoubleClick(sender As Object, e As EventArgs) Handles GVIndexPPS.DoubleClick
        If GVIndexPPS.RowCount > 0 Then
            FormSOPIndexPPS.id = GVIndexPPS.GetFocusedRowCellValue("id_sop_pps").ToString
            FormSOPIndexPPS.ShowDialog()
        End If
    End Sub

    Sub view_sop_schedule_admin()
        Dim query As String = "
            SELECT s.id_sop_schedule, s.id_departement, d.departement, DATE_FORMAT(s.date, '%d %M %Y') AS `date`, CONCAT(s.time_start, ' - ', s.time_end) AS `time`, m.sop, m.milestone, m.status    
            FROM tb_sop_schedule AS s
            LEFT JOIN tb_m_departement AS d ON s.id_departement = d.id_departement
            LEFT JOIN (
                SELECT tb.id_sop_schedule, GROUP_CONCAT(tb.sop SEPARATOR '\n') AS sop, GROUP_CONCAT(tb.milestone SEPARATOR '\n') AS milestone, GROUP_CONCAT(tb.status SEPARATOR '\n') AS `status`
                FROM (
                    SELECT s.id_sop_schedule, CONCAT(t.sop_number, ' | ', t.sop_name) AS sop, m.milestone, IF(s.is_complete IS NULL, '', IF(s.is_complete = 1, 'Complete', 'Not Complete')) AS `status`
                    FROM tb_sop_schedule_sop AS s
                    LEFT JOIN tb_sop AS t ON s.id_sop = t.id_sop
                    LEFT JOIN tb_lookup_milestone AS m ON s.id_milestone = m.id_milestone
                ) AS tb
                GROUP BY tb.id_sop_schedule
            ) AS m ON s.id_sop_schedule = m.id_sop_schedule
            ORDER BY s.date DESC, s.time_start DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCScheduleAdmin.DataSource = data

        GVScheduleAdmin.BestFitColumns()

        schedule_check_control()
    End Sub

    Sub view_sop_schedule_guest()
        Dim query As String = "
            SELECT s.id_sop_schedule, s.id_departement, d.departement, DATE_FORMAT(s.date, '%d %M %Y') AS `date`, CONCAT(s.time_start, ' - ', s.time_end) AS `time`, m.sop, m.milestone, m.status    
            FROM tb_sop_schedule AS s
            LEFT JOIN tb_m_departement AS d ON s.id_departement = d.id_departement
            LEFT JOIN (
                SELECT tb.id_sop_schedule, GROUP_CONCAT(tb.sop SEPARATOR '\n') AS sop, GROUP_CONCAT(tb.milestone SEPARATOR '\n') AS milestone, GROUP_CONCAT(tb.status SEPARATOR '\n') AS `status`
                FROM (
                    SELECT s.id_sop_schedule, CONCAT(t.sop_number, ' | ', t.sop_name) AS sop, m.milestone, IF(s.is_complete IS NULL, '-', IF(s.is_complete = 1, 'Complete', 'Not Complete')) AS `status`
                    FROM tb_sop_schedule_sop AS s
                    LEFT JOIN tb_sop AS t ON s.id_sop = t.id_sop
                    LEFT JOIN tb_lookup_milestone AS m ON s.id_milestone = m.id_milestone
                ) AS tb
                GROUP BY tb.id_sop_schedule
            ) AS m ON s.id_sop_schedule = m.id_sop_schedule
            WHERE s.id_departement = '" + id_departement_user + "'
            ORDER BY s.date DESC, s.time_start DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCScheduleGuest.DataSource = data

        GVScheduleGuest.BestFitColumns()
    End Sub

    Private Sub SBSetSOP_Click(sender As Object, e As EventArgs) Handles SBSetSOP.Click
        FormSOPSelectSOP.ShowDialog()
    End Sub

    Private Sub SBSetComplete_Click(sender As Object, e As EventArgs) Handles SBSetComplete.Click
        FormSOPSetComplete.ShowDialog()
    End Sub

    Private Sub GVScheduleAdmin_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVScheduleAdmin.FocusedRowChanged
        schedule_check_control()
    End Sub

    Sub schedule_check_control()
        Try
            Dim is_complete As String = execute_query("SELECT COUNT(*) FROM tb_sop_schedule_sop WHERE id_sop_schedule = '" + GVScheduleAdmin.GetFocusedRowCellValue("id_sop_schedule").ToString + "'", 0, True, "", "", "", "")

            If is_complete = "0" Then
                SBSetSOP.Visible = True
                SBSetComplete.Visible = False
            Else
                SBSetSOP.Visible = True
                SBSetComplete.Visible = True
            End If

            If Not GVScheduleAdmin.GetFocusedRowCellValue("status").ToString = "" Then
                SBSetComplete.Visible = False
                SBSetSOP.Visible = False
            End If
        Catch ex As Exception
            SBSetComplete.Visible = False
            SBSetSOP.Visible = False
        End Try
    End Sub

    Private Sub XTCSOPIndex_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSOPIndex.SelectedPageChanged
        If XTCSOPIndex.SelectedTabPageIndex = 2 Then
            view_sop_schedule_admin()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 3 Then
            view_sop_schedule_guest()
        End If
    End Sub

    Private Sub BSOPAsset_Click(sender As Object, e As EventArgs) Handles BSOPAsset.Click
        If GVBySOP.RowCount > 0 Then
            FormSOPNew.id_pps = "-1"
            FormSOPNew.id_sop = GVBySOP.GetFocusedRowCellValue("id_sop").ToString
            FormSOPNew.ShowDialog()
        End If
    End Sub

    Private Sub GVPengajuanKelengkapan_DoubleClick(sender As Object, e As EventArgs) Handles GVPengajuanKelengkapan.DoubleClick
        If GVPengajuanKelengkapan.RowCount > 0 Then
            FormSOPNew.id_pps = GVPengajuanKelengkapan.GetFocusedRowCellValue("id_sop_dep_pps").ToString
            FormSOPNew.id_sop = GVPengajuanKelengkapan.GetFocusedRowCellValue("id_sop").ToString
            FormSOPNew.ShowDialog()
        End If
    End Sub
End Class