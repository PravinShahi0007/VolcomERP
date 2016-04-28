Public Class FormMasterRawMaterialSingle
    Public action As String
    Public id_mat As String
    Public data_insert_parameter As New DataTable

    'Form Closed
    Private Sub FormMasterRawMaterialSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Validating Mat Name
    Private Sub TxtMatName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMatName.Validating
        EP_TE_cant_blank(EPMaterialType, TxtMatName)
    End Sub
    'Validating Mat Display Name
    Private Sub TxtMatDisplayName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMatDisplayName.Validating
        EP_TE_cant_blank(EPMaterialType, TxtMatDisplayName)
    End Sub
    'Form Load
    Private Sub FormMasterRawMaterialSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewUOM()
        viewMatCat()
        loadIsiParam()
        viewTemplate(LETemplate)
        If action = "upd" Then
            Try
                'parse data standard
                Dim query As String = "SELECT * FROM tb_m_mat WHERE id_mat = '" + id_mat + "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtMatDisplayName.Text = data.Rows(0)("mat_display_name").ToString
                TxtMatName.Text = data.Rows(0)("mat_name").ToString
                LEUOM.ItemIndex = LEUOM.Properties.GetDataSourceRowIndex("id_uom", data.Rows(0)("id_uom").ToString)
                LEMatCat.ItemIndex = LEMatCat.Properties.GetDataSourceRowIndex("id_mat_cat", data.Rows(0)("id_mat_cat").ToString)
                TxtMaterialCode.Text = data.Rows(0)("mat_code")

                'parse data code
                query = String.Format("SELECT tb_m_code_detail.id_code as id_code, tb_m_mat_code.id_code_detail as id_code_detail FROM tb_m_mat_code,tb_m_code_detail WHERE  tb_m_mat_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_m_mat_code.id_mat = '{0}'", id_mat)
                Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

                If Not data_value.Rows.Count = 0 Then
                    Dim id_check As String = "1"
                    For i As Integer = 0 To data_value.Rows.Count - 1
                        If data_insert_parameter.Select("code = '" + data_value.Rows(i)("id_code").ToString + "'").Length = 0 Then
                            id_check = "2"
                        End If
                    Next
                    If id_check = "2" Then 'old
                        data_insert_parameter.Clear()
                        For i As Integer = 0 To data_value.Rows.Count - 1
                            data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString, data_value.Rows(i)("id_code_detail").ToString)
                        Next
                    Else
                        For x As Integer = 0 To data_insert_parameter.Rows.Count - 1
                            For i As Integer = 0 To data_value.Rows.Count - 1
                                If data_insert_parameter.Rows(x)("code").ToString = data_value.Rows(i)("id_code").ToString Then
                                    data_insert_parameter.Rows(x)("value") = data_value.Rows(i)("id_code_detail").ToString
                                End If
                            Next
                        Next
                    End If
                End If

            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
    'Lookup view Material Category
    Sub viewMatCat()
        Dim query As String = "SELECT * FROM tb_m_mat_cat ORDER BY mat_cat ASC"
        viewLookupQuery(LEMatCat, query, 0, "mat_cat", "id_mat_cat")
    End Sub
    'Lookup view UOM
    Sub viewUOM()
        Dim query As String = "SELECT * FROM tb_m_uom ORDER BY uom ASC"
        viewLookupQuery(LEUOM, query, 0, "uom", "id_uom")
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub
    'Btn Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Me.ValidateChildren()
        If Not formIsValid(EPMaterialType) Then
            errorInput()
        Else
            Dim query As String
            Dim mat_name As String = addSlashes(TxtMatName.Text)
            Dim mat_display_name As String = addSlashes(TxtMatDisplayName.Text)
            Dim id_uom As String = LEUOM.EditValue
            Dim id_mat_cat As String = LEMatCat.EditValue
            Dim mat_code As String = addSlashes(TxtMaterialCode.Text)

            If action = "ins" Then 'INSERT RAW MATERIAL
                Try
                    'insert master mat
                    query = "INSERT INTO tb_m_mat(mat_name, mat_display_name, id_uom, mat_code, id_mat_cat) "
                    query += "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');SELECT LAST_INSERT_ID(); "
                    query = String.Format(query, mat_name, mat_display_name, id_uom, mat_code, id_mat_cat)

                    id_mat = execute_query(query, 0, True, "", "", "", "")
                    query = String.Format("DELETE FROM tb_m_mat_code WHERE id_mat='" & id_mat & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_code(id_mat, id_code_detail) VALUES('{0}','{1}')", id_mat, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'other
                    logData("tb_m_mat", 1)
                    FormMasterRawMaterial.viewMat()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            ElseIf action = "upd" Then 'UPDATE RAW MATERILA
                Try
                    'update tb
                    query = "UPDATE tb_m_mat SET mat_name='{0}', mat_display_name='{1}', id_uom = '{2}', mat_code='{3}', id_mat_cat='{4}' "
                    query += "WHERE id_mat = '{5}' "
                    query = String.Format(query, mat_name, mat_display_name, id_uom, mat_code, id_mat_cat, id_mat)
                    execute_non_query(query, True, "", "", "", "")

                    'update code
                    query = String.Format("DELETE FROM tb_m_mat_code WHERE id_mat='" & id_mat & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_code(id_mat, id_code_detail) VALUES('{0}','{1}')", id_mat, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'others
                    logData("tb_m_mat", 2)
                    FormMasterRawMaterial.viewMat()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
    End Sub
    'Validating Material Code Type
    Private Sub TxtMaterialCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMaterialCode.Validating
        Dim query_jml As String
        If action = "ins" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_mat) FROM tb_m_mat WHERE mat_code='{0}'", TxtMaterialCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_mat) FROM tb_m_mat WHERE mat_code='{0}' AND id_mat!='{1}'", TxtMaterialCode.Text, id_mat)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPMaterialType, TxtMaterialCode, "1")
        Else
            EP_TE_cant_blank(EPMaterialType, TxtMaterialCode)
        End If
    End Sub
    'View Template
    Private Sub viewTemplate(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_template_code,template_code FROM tb_template_code ORDER BY template_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "template_code"
        lookup.Properties.ValueMember = "id_template_code"
        Try
            lookup.EditValue = get_setup_field("id_code_template_mat")
        Catch ex As Exception
            lookup.EditValue = data.Rows(0)("id_template_code").ToString
        End Try
    End Sub
    'Load Paramter
    Sub loadIsiParam()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 2 Then
            data_insert_parameter.Columns.Add("code")
            data_insert_parameter.Columns.Add("value")
        End If

        GCCodeMaterial.DataSource = data_insert_parameter
        DNCodeMaterial.DataSource = data_insert_parameter

        Try
            add_combo_grid_val(GVCodeMaterial, 0)
            view_value_code(GVCodeMaterial, 1)
        Catch ex As Exception
        End Try

        Cursor = Cursors.Default
    End Sub
    Private Sub add_combo_grid_val(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,code_name as Code,description as Description FROM tb_m_code")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.ReadOnly = True
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    Sub view_value_code(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE,display_name,code_detail_name,CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code_detail").Visible = False
        lookup.View.Columns("value").Visible = False
        lookup.View.Columns("id_code").Visible = False
        '
        lookup.View.Columns("CODE").Caption = "Code"
        lookup.View.Columns("display_name").Caption = "Short Description"
        lookup.View.Columns("code_detail_name").Caption = "Description"

        lookup.DisplayMember = "value"
        lookup.ValueMember = "id_code_detail"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    'Event Template Edit 
    Private Sub LETemplate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub
    'Load Template
    Sub load_template(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub
    'Shown Editor
    Private clone As DataView = Nothing
    Private Sub GVCodeMaterial_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeMaterial.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "[id_code] = " + row("code").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub
    'Hidden Editor
    Private Sub GVCodeMaterial_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeMaterial.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub
    'Btn Generate
    Private Sub BGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerate.Click
        Dim id_code, code, query As String
        Dim code_full As String = ""

        For i As Integer = 0 To GVCodeMaterial.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCodeMaterial.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                query = String.Format("SELECT code FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                code = execute_query(query, 0, True, "", "", "", "")
            End If
            code_full += code
        Next
        TxtMaterialCode.Text = code_full
    End Sub

    Private Sub BRefreshCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefreshCode.Click
        loadIsiParam()
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BeditCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "5"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub
End Class