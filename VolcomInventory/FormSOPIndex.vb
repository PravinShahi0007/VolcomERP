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

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        Dim q As String = "SELECT s.*,dep.departement,m.menu_name,m.`menu_caption`,CONCAT(d.id_doc,'_371_',s.id_sop,d.ext) AS filename,d.doc_desc
FROM `tb_sop` s
INNER JOIN tb_m_departement dep ON dep.id_departement=s.id_departement
LEFT JOIN tb_sop_menu_erp er ON er.id_sop=s.id_sop
LEFT JOIN tb_menu m ON m.`id_menu`=er.`id_menu`
LEFT JOIN tb_doc d ON d.id_report=s.id_sop AND d.report_mark_type=371
ORDER BY s.id_sop ASC"
        If Not is_super_admin = "1" Then
            q += " WHERE s.id_departement='" & id_departement_user & "' "
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCBySOP.DataSource = dt
        GVBySOP.BestFitColumns()
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
        If Not GVBySOP.GetFocusedRowCellValue("doc_desc").ToString = "" Then
            download_doc(GVBySOP.GetFocusedRowCellValue("filename").ToString, GVBySOP.GetFocusedRowCellValue("doc_desc").ToString)
        End If
    End Sub

    Private Sub RepoLinkMenuERP_Click(sender As Object, e As EventArgs) Handles RepoLinkMenuERP.Click
        'menu file
        If Not GVBySOP.GetFocusedRowCellValue("menu_name").ToString = "" Then
            FormMain.call_click(GVBySOP.GetFocusedRowCellValue("menu_name").ToString)
        End If
    End Sub
End Class