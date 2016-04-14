Public Class FormTemplateSize 
    Public id_popup As String = "-1"

    Private Sub FormTemplateSize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_popup = "1" Then
            PanelControlBottom.Visible = True
        End If
        viewTemplate()
    End Sub

    Private Sub FormTemplateSize_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewTemplate()
        Dim query As String = "SELECT * FROM tb_template_size a ORDER BY a.id_template_size ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCTemplate.DataSource = data
        If GVTemplate.RowCount > 0 Then
            BtnEditTemplate.Enabled = True
            BtnDelTemplate.Enabled = True
        Else
            BtnEditTemplate.Enabled = False
            BtnDelTemplate.Enabled = False
        End If
        viewTemplateDet()
    End Sub

    Sub viewTemplateDet()
        Dim id_template_size_param As String = "-1"
        Try
            id_template_size_param = GVTemplate.GetFocusedRowCellValue("id_template_size").ToString
        Catch ex As Exception
        End Try
        If id_template_size_param = "" Then
            id_template_size_param = "-1"
        End If
        Dim query As String = ""
        query += "SELECT * FROM tb_template_size_det a "
        query += "INNER JOIN tb_m_code_detail b ON a.id_code_detail = b.id_code_detail "
        query += "WHERE a.id_template_size = '" + id_template_size_param + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSize.DataSource = data
        If GVSize.RowCount > 0 Then
            BtnEditSize.Enabled = True
            BtnDelSize.Enabled = True
        Else
            BtnEditSize.Enabled = False
            BtnDelSize.Enabled = False
        End If
        MsgBox("aw")
    End Sub

    Sub check_but1()
        Dim id_template_size As String = "-1"
        Try
            id_template_size = GVTemplate.GetFocusedRowCellValue("id_template_size").ToString
        Catch ex As Exception
        End Try
        If id_template_size = "" Or id_template_size = "-1" Then
            BtnEditTemplate.Enabled = False
            BtnDelTemplate.Enabled = False
        Else
            BtnEditTemplate.Enabled = True
            BtnDelTemplate.Enabled = True
        End If
    End Sub

    Sub check_but2()
        Dim id_template_size_det As String = "-1"
        Try
            id_template_size_det = GVSize.GetFocusedRowCellValue("id_template_size_det").ToString
        Catch ex As Exception
        End Try
        If id_template_size_det = "" Or id_template_size_det = "-1" Then
            BtnEditSize.Enabled = False
            BtnDelSize.Enabled = False
        Else
            BtnEditSize.Enabled = True
            BtnDelSize.Enabled = True
        End If
    End Sub


    Private Sub GVTemplate_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVTemplate.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        viewTemplateDet()
        check_but1()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVTemplate_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVTemplate.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewTemplateDet()
        check_but1()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVSize_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSize.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but2()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSize_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSize.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but2()
        Cursor = Cursors.Default
    End Sub
End Class