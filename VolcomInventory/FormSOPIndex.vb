Public Class FormSOPIndex
    Public is_super_admin As String = "2"

    Private Sub FormSOPIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not is_super_admin = "1" Then
            BNewSOP.Visible = False
        Else
            BNewSOP.Visible = True
        End If
    End Sub

    Private Sub FormSOPIndex_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BNewSOP_Click(sender As Object, e As EventArgs) Handles BNewSOP.Click
        FormSOPNew.ShowDialog()
    End Sub

    Private Sub GVBySOP_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles GVBySOP.CellMerge
        If (e.Column.FieldName = "doc_desc" Or e.Column.FieldName = "sop_name" Or e.Column.FieldName = "departement") Then
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
            Dim q As String = "SELECT s.*,dep.departement,m.menu_name,m.`menu_caption`,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename,d.doc_desc
FROM `tb_sop` s
INNER JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
LEFT JOIN tb_sop_menu_erp er ON er.id_sop=s.id_sop
LEFT JOIN tb_menu m ON m.`id_menu`=er.`id_menu`
LEFT JOIN (SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop AND d.report_mark_type=371
ORDER BY s.id_sop ASC"
            If Not is_super_admin = "1" Then
                q += " WHERE s.id_departement='" & id_departement_user & "' "
            End If

            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCBySOP.DataSource = dt
            GVBySOP.BestFitColumns()
        ElseIf XTCSOPIndex.SelectedTabPageIndex = 1 Then 'by menu
            Dim qw As String = ""

            If Not is_super_admin = "1" Then
                qw = " AND emp.`id_departement`='" & id_departement_user & "' AND emp.`id_employee_active`=1 "
            End If

            Dim q As String = "SELECT s.*,dep.departement,m.id_menu,m.menu_name,m.`menu_caption`,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename,d.doc_desc
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
LEFT JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
LEFT JOIN 
(SELECT * FROM tb_doc WHERE report_mark_type=371) d ON d.id_report=s.id_sop
ORDER BY id_menu"


            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCByModul.DataSource = dt
            GVByModul.BestFitColumns()
        End If
    End Sub

    Private Sub GVBySOP_DoubleClick(sender As Object, e As EventArgs) Handles GVBySOP.DoubleClick
        If GVBySOP.RowCount > 0 Then
            FormSOPNew.id = GVBySOP.GetFocusedRowCellValue("id_sop").ToString
            FormSOPNew.ShowDialog()
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
End Class