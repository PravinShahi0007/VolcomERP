Public Class FormTemplateCode
    Private data_insert_parameter As New DataTable
    Public id_template_code_det As String = "-1"
    Public id_template_code As String = "-1"
    '
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormTemplateCode_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        FormMain.hide_rb()
    End Sub
    Private Sub FormTemplateCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_isi_param()
        view_template()
    End Sub
    Sub view_template()
        Dim data As DataTable = execute_query("SELECT id_template_code,template_code FROM tb_template_code ORDER BY template_code", -1, True, "", "", "", "")
        GCTemplateCode.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            XTPCodeDet.PageEnabled = True
            LabelTemplate.Text = GVTemplateCode.GetFocusedRowCellDisplayText("template_code").ToString
            view_template_det(GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString)
        Else
            XTPCodeDet.PageEnabled = False
        End If
    End Sub
    Sub view_template_det(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub
    Sub load_isi_param()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 1 Then
            data_insert_parameter.Columns.Add("code_name")
        End If

        GCTemplateCodeDet.DataSource = data_insert_parameter
        DNTemplateCodeDet.DataSource = data_insert_parameter

        Try
            add_combo_grid(GVTemplateCodeDet, 0)
        Catch ex As Exception
        End Try

        Cursor = Cursors.Default
    End Sub
    Private Sub add_combo_grid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,code_name as Code,description as Description FROM tb_m_code")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub

    Private Sub FormTemplateCode_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        id_template_code = GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString
        Dim query As String

        Try
            'delete dulu
            query = String.Format("DELETE FROM tb_template_code_det WHERE id_template_code='{0}'", id_template_code)
            execute_non_query(query, True, "", "", "", "")
            'insert
            If Not GVTemplateCodeDet.DataRowCount > 0 Then
                errorInput()
            Else
                Dim code As Integer
                For i As Integer = 0 To GVTemplateCodeDet.DataRowCount - 1
                    code = GVTemplateCodeDet.GetRowCellValue(i, "code_name")
                    query = String.Format("INSERT INTO tb_template_code_det(id_template_code,id_code) VALUES('{0}','{1}')", id_template_code, code.ToString)
                    'MsgBox(query)
                    execute_non_query(query, True, "", "", "", "")
                Next i
            End If
        Catch ex As Exception
            errorConnection()
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub GVTemplateCode_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVTemplateCode.RowClick
        view_template_det(GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString)
    End Sub

    Private Sub XTCTemplateCode_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTemplateCode.SelectedPageChanged
        check_menu()
    End Sub
    Sub check_menu()
        If XTCTemplateCode.SelectedTabPageIndex = 0 Then
            'template
            If GVTemplateCode.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Else
            'detail
            'hide all
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub
End Class