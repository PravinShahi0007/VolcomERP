Public Class FormSetupRawMatCodeSingle
    Public action As String
    Public id_raw_mat_code As String
    Dim indeks_selected As Integer
    Dim list As DataTable

    'Form Load
    Private Sub FormSetupRawMatCodeSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewDefault()
        viewActive()
        loadAction()
    End Sub
    'Load Action
    Private Sub loadAction()
        Dim query As String
        Dim data As DataTable
       
        If action = "ins" Then
            Try
                BtnMoveUp.Enabled = False
                query = "SELECT * FROM tb_m_raw_mat_code_lookup ORDER BY code_lookup ASC"
                data = execute_query(query, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    LBCCriteria.Items.Add(data.Rows(i)("code_lookup").ToString)
                Next
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        ElseIf action = "upd" Then
            Try
                'Listbox List
                query = "SELECT * FROM tb_m_raw_mat_code_lookup a WHERE id_code_lookup NOT IN "
                query += "(SELECT id_code_lookup FROM tb_m_raw_mat_code_detail WHERE id_raw_mat_code = '" + id_raw_mat_code + "')"
                data = execute_query(query, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    LBCCriteria.Items.Add(data.Rows(i)("code_lookup").ToString)
                Next

                'Lixtbox Selected
                query = "SELECT * FROM tb_m_raw_mat_code_detail a INNER JOIN tb_m_raw_mat_code b ON a.id_raw_mat_code = b.id_raw_mat_code INNER JOIN tb_m_raw_mat_code_lookup c ON a.id_code_lookup = c.id_code_lookup WHERE b.id_raw_mat_code = '" + id_raw_mat_code + "'"
                data = execute_query(query, -1, True, "", "", "", "")
                For i As Integer = 0 To (data.Rows.Count - 1)
                    LBCCriteriaSelected.Items.Add(data.Rows(i)("code_lookup").ToString)
                Next
                TxtRawMatCodeName.Text = data.Rows(0)("raw_mat_code_name").ToString
                LeDefault.ItemIndex = LeDefault.Properties.GetDataSourceRowIndex("id_default", data.Rows(0)("is_default").ToString)

                LEActive.ItemIndex = LEActive.Properties.GetDataSourceRowIndex("id_status", data.Rows(0)("is_active").ToString)
            Catch ex As Exception
                errorConnection()
                'Close()
            End Try
        End If
    End Sub
    'Default Lookup
    Private Sub viewDefault()
        Dim query As String = "SELECT * FROM tb_lookup_default ORDER BY id_default ASC"
        viewLookupQuery(LeDefault, query, 1, "default_name", "id_default")
    End Sub
    'Active Lookup
    Private Sub viewActive()
        Dim query As String = "SELECT * FROM tb_lookup_status ORDER BY id_status ASC"
        viewLookupQuery(LEActive, query, 1, "status", "id_status")
    End Sub
    'Validate
    Private Sub TxtRawMatCodeName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRawMatCodeName.Validating
        EP_TE_cant_blank(ErrorProviderSetup, TxtRawMatCodeName)
    End Sub
    'Select All
    Private Sub BtnSelectedAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectedAll.Click
        Dim jumlah_data As Integer = LBCCriteria.ItemCount
        For i As Integer = 0 To (jumlah_data - 1)
            LBCCriteriaSelected.Items.Add(LBCCriteria.GetItemValue(i).ToString)
        Next
        LBCCriteria.Items.Clear()
        indeks_selected = LBCCriteriaSelected.SelectedIndex
        activeBtnMoveUp()
    End Sub
    'Unselect All
    Private Sub BtnUnselectedAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnselectedAll.Click
        Dim jumlah_data As Integer = LBCCriteriaSelected.ItemCount
        For i As Integer = 0 To (jumlah_data - 1)
            LBCCriteria.Items.Add(LBCCriteriaSelected.GetItemValue(i).ToString)
        Next
        LBCCriteriaSelected.Items.Clear()
        indeks_selected = LBCCriteriaSelected.SelectedIndex
        activeBtnMoveUp()
    End Sub
    'Select
    Private Sub BtnSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelected.Click
        LBCCriteriaSelected.Items.Add(LBCCriteria.SelectedValue)
        LBCCriteria.Items.Remove(LBCCriteria.SelectedValue)
        indeks_selected = LBCCriteriaSelected.SelectedIndex
        activeBtnMoveUp()
    End Sub
    'UnSelect
    Private Sub BtnUnselected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnselected.Click
        LBCCriteria.Items.Add(LBCCriteriaSelected.SelectedValue)
        LBCCriteriaSelected.Items.Remove(LBCCriteriaSelected.SelectedValue)
        indeks_selected = LBCCriteriaSelected.SelectedIndex
        activeBtnMoveUp()
    End Sub
    'Move Up
    Private Sub BtnMoveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoveUp.Click
        If LBCCriteriaSelected.SelectedIndex > 0 Then
            Dim i As Integer = LBCCriteriaSelected.SelectedIndex - 1
            LBCCriteriaSelected.Items.Insert(i, LBCCriteriaSelected.SelectedItem)
            LBCCriteriaSelected.Items.RemoveAt(LBCCriteriaSelected.SelectedIndex)
            LBCCriteriaSelected.SelectedIndex = i
        End If
    End Sub
    'Move Down
    Private Sub BtnMoveDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMoveDown.Click
        If LBCCriteriaSelected.SelectedIndex < LBCCriteriaSelected.Items.Count - 1 Then
            Dim i As Integer = LBCCriteriaSelected.SelectedIndex + 2
            LBCCriteriaSelected.Items.Insert(i, LBCCriteriaSelected.SelectedItem)
            LBCCriteriaSelected.Items.RemoveAt(LBCCriteriaSelected.SelectedIndex)
            LBCCriteriaSelected.SelectedIndex = i - 1
        End If
    End Sub
    'Click To Get Selected Index 
    Private Sub LBCCriteriaSelected_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBCCriteriaSelected.SelectedIndexChanged
        indeks_selected = LBCCriteriaSelected.SelectedIndex
        activeBtnMoveUp()
    End Sub
    'Active/Nonactive Button
    Private Sub activeBtnMoveUp()
        If indeks_selected <= 0 Then
            BtnMoveUp.Enabled = False
        Else
            BtnMoveUp.Enabled = True
        End If
        If indeks_selected = (LBCCriteriaSelected.Items.Count - 1) Then
            BtnMoveDown.Enabled = False
        Else
            BtnMoveDown.Enabled = True
        End If
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        Me.ValidateChildren()

        If Not formIsValidInGroup(ErrorProviderSetup, GCtrlCodeType) Or LBCCriteriaSelected.Items.Count <= 0 Then
            errorInput()
        Else
            Try
                Dim raw_mat_code_name = TxtRawMatCodeName.Text.ToString
                Dim is_default As String = LeDefault.EditValue
                Dim is_active As String = LEActive.EditValue
                Dim query As String
                Dim i As Integer
                Dim id_code_lookup As String

                If is_default = "1" Then
                    query = "UPDATE tb_m_raw_mat_code SET is_default='2'"
                    execute_non_query(query, True, "", "", "", "")
                End If

                If action = "ins" Then
                    query = String.Format("INSERT INTO tb_m_raw_mat_code(raw_mat_code_name, is_default, is_active) VALUES('{0}', '{1}', '{2}')", raw_mat_code_name, is_default, is_active)
                    execute_non_query(query, True, "", "", "", "")
                    query = "SELECT LAST_INSERT_ID()"
                    id_raw_mat_code = execute_query(query, 0, True, "", "", "", "")
                    For i = 0 To (LBCCriteriaSelected.Items.Count - 1)
                        query = "SELECT id_code_lookup FROM tb_m_raw_mat_code_lookup WHERE code_lookup='" + LBCCriteriaSelected.GetItemValue(i).ToString + "'"
                        id_code_lookup = execute_query(query, 0, True, "", "", "", "")
                        query = String.Format("INSERT INTO tb_m_raw_mat_code_detail(id_raw_mat_code, id_code_lookup, index_code) VALUES('{0}', '{1}', '{2}')", id_raw_mat_code, id_code_lookup, i)
                        execute_non_query(query, True, "", "", "", "")
                    Next
                    FormSetupRawMatCode.viewCodeType(1, FormSetupRawMatCode.GCCodeType)
                    Dispose()
                ElseIf action = "upd" Then
                    'Update Main Code
                    query = String.Format("UPDATE tb_m_raw_mat_code SET raw_mat_code_name = '{0}', is_default='{1}', is_active='{2}' WHERE id_raw_mat_code='{3}'", raw_mat_code_name, is_default, is_active, id_raw_mat_code)
                    execute_non_query(query, True, "", "", "", "")

                    'Delete Detail
                    query = "DELETE FROM tb_m_raw_mat_code_detail WHERE id_raw_mat_code='" + id_raw_mat_code + "'"
                    execute_non_query(query, True, "", "", "", "")

                    'Update Detail
                    For i = 0 To (LBCCriteriaSelected.Items.Count - 1)
                        query = "SELECT id_code_lookup FROM tb_m_raw_mat_code_lookup WHERE code_lookup='" + LBCCriteriaSelected.GetItemValue(i).ToString + "'"
                        id_code_lookup = execute_query(query, 0, True, "", "", "", "")
                        query = String.Format("INSERT INTO tb_m_raw_mat_code_detail(id_raw_mat_code, id_code_lookup, index_code) VALUES('{0}', '{1}', '{2}')", id_raw_mat_code, id_code_lookup, i)
                        execute_non_query(query, True, "", "", "", "")
                    Next
                    FormSetupRawMatCode.viewCodeType(1, FormSetupRawMatCode.GCCodeType)
                    Dispose()
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub
    'Form Closed
    Private Sub FormSetupRawMatCodeSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Event Set Default
    Private Sub LeDefault_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeDefault.EditValueChanged
        'conditionDefault()
    End Sub
    'Condition default
    Private Sub conditionDefault()
        If LeDefault.EditValue.ToString = "1" Then ' jika set default
            LEActive.Properties.ReadOnly = True
            LEActive.ItemIndex = 0
        Else
            LEActive.Properties.ReadOnly = False
            LEActive.ItemIndex = 1
        End If
    End Sub
End Class