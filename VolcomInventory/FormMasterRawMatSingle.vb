Public Class FormMasterRawMatSingle 
    Public action As String
    Public id_raw_mat As String
    Dim id_item_category As String

    'Load
    Private Sub FormMasterRawMatSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewUOM(LEUOM)
        viewCategory(LECategory)
        viewCategorySub(LECategorySub, id_item_category)
        If action = "upd" Then
            Try
                Dim query As String = "SELECT * FROM tb_m_raw_mat a INNER JOIN tb_m_raw_mat_category_sub b ON a.id_item_category_sub = b.id_item_category_sub WHERE a.id_raw_mat='" + id_raw_mat + "'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtRawMaterial.Text = data.Rows(0)("raw_mat").ToString
                LEUOM.ItemIndex = LEUOM.Properties.GetDataSourceRowIndex("id_uom", data.Rows(0)("id_uom").ToString)
                LECategory.ItemIndex = LECategory.Properties.GetDataSourceRowIndex("id_item_category", data.Rows(0)("id_item_category").ToString)
                LECategorySub.ItemIndex = LECategorySub.Properties.GetDataSourceRowIndex("id_item_category_sub", data.Rows(0)("id_item_category_sub").ToString)
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Dispose()
    End Sub
    'View UOM
    Private Sub viewUOM(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT * FROM tb_m_uom ORDER BY uom ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "uom"
        lookup.Properties.ValueMember = "id_uom"
        lookup.ItemIndex = 0
    End Sub
    'View Category
    Private Sub viewCategory(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT a.id_item_category, a.code_item_category, a.item_category FROM tb_m_raw_mat_category a WHERE a.is_active='1' ORDER BY a.code_item_category ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "item_category"
        lookup.Properties.ValueMember = "id_item_category"
        lookup.ItemIndex = 0
    End Sub
    'View Sub Category 
    Private Sub viewCategorySub(ByVal Lookup As DevExpress.XtraEditors.LookUpEdit, ByVal id_item_category As String)
        Dim query As String = "SELECT a.id_item_category_sub, a.code_item_category_sub, a.item_category_sub FROM tb_m_raw_mat_category_sub a WHERE a.id_item_category='" + id_item_category + "' AND a.is_active='1' ORDER BY a.code_item_category_sub ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Lookup.Properties.DataSource = Nothing
        Lookup.Properties.DataSource = data

        Lookup.Properties.DisplayMember = "item_category_sub"
        Lookup.Properties.ValueMember = "id_item_category_sub"
        Lookup.ItemIndex = 0
    End Sub
    'Edit value Category
    Private Sub LECategory_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LECategory.EditValueChanged
        id_item_category = LECategory.EditValue
        viewCategorySub(LECategorySub, id_item_category)
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Me.ValidateChildren()
        If TxtRawMaterial.Text.ToString.Length < 1 Then
            errorInput()
        Else
            Dim raw_mat As String = SqlSafe(TxtRawMaterial.Text.ToString)
            Dim id_uom As String = LEUOM.EditValue
            Dim id_item_category_sub As String = LECategorySub.EditValue
            Dim query As String
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_m_raw_mat(raw_mat, id_uom, id_item_category_sub) VALUES('{0}', '{1}', '{2}')", raw_mat, id_uom, id_item_category_sub)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMat()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_m_raw_mat SET raw_mat='{0}', id_uom='{1}', id_item_category_sub='{2}' WHERE id_raw_mat='{3}'", raw_mat, id_uom, id_item_category_sub, id_raw_mat)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterRawMat.viewRawMat()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
    'Validate
    Private Sub TxtRawMaterial_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRawMaterial.Validating
        EP_TE_cant_blank(ErrorProviderRawMat, TxtRawMaterial)
    End Sub
End Class