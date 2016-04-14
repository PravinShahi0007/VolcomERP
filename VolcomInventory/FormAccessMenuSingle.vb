Public Class FormAccessMenuSingle
    Public action As String
    Public id_menu As String

    'Validating Menu name
    Private Sub TxtMenuName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMenuName.Validating
        Dim found As Boolean = False
        For Each item As DevExpress.XtraNavBar.NavBarItem In FormMain.NBProdRet.Items
            If item.Name = TxtMenuName.Text.ToString Then
                found = True
            End If
        Next item
        If Not found Then
            EP_TE_check_value(EPRole, TxtMenuName, 0)
        Else
            EP_TE_check_value(EPRole, TxtMenuName, -1)
            'Dim query As String
            'If action = "ins" Then
            '    query = "SELECT COUNT(*) FROM tb_menu WHERE menu_name = '" + TxtMenuName.Text.ToString + "'"
            'Else
            '    query = "SELECT COUNT(*) FROM tb_menu WHERE menu_name = '" + TxtMenuName.Text.ToString + "' AND id_menu!= '" + id_menu + "'"
            'End If
            'Dim jum As Integer = execute_query(query, 0, True, "", "", "", "")
            Dim jum As Integer
            jum = 0
            If jum > 0 Then
                EP_TE_already_used(EPRole, TxtMenuName, 0)
            Else
                EP_TE_already_used(EPRole, TxtMenuName, -1)
                EP_TE_cant_blank(EPRole, TxtMenuName)
            End If
        End If
    End Sub
    'Form Load
    Private Sub FormMasterUserMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewGroup()
        If action = "upd" Then
            GroupControlInvolved.Enabled = True
            Dim query As String = "SELECT * FROM tb_menu WHERE id_menu = '" + id_menu + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LEGroup.ItemIndex = LEGroup.Properties.GetDataSourceRowIndex("id_group_menu", data.Rows(0)("id_group_menu").ToString)
            viewFormInvolved()
        ElseIf action = "ins" Then
            GroupControlInvolved.Enabled = False
        End If
    End Sub
    'View Group
    Sub viewGroup()
        Dim query As String = "SELECT * FROM tb_lookup_group_menu "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEGroup, query, 0, "group_menu", "id_group_menu")
    End Sub
    'View Involved Form
    Sub viewFormInvolved()
        Dim query As String = "SELECT b.id_menu_involved, a.id_form, a.form_name, (IF(b.is_view='1', 'Yes', 'No')) AS is_view  FROM tb_menu_form a "
        query += "INNER JOIN tb_menu_involved b ON a.id_form = b.id_form "
        query += "WHERE b.id_menu = '" + id_menu + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvolved.DataSource = data
        If data.Rows.Count > 0 Then
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
        End If
    End Sub
    'Validating Memo
    Private Sub MEDescription_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEDescription.Validating
        EP_ME_cant_blank(EPRole, MEDescription)
    End Sub
    'Form Close
    Private Sub FormMasterUserMenu_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValidInGroup(EPRole, GroupControlGeneral) Then
            errorInput()
        Else
            Dim query As String
            Dim menu_name As String = TxtMenuName.Text
            Dim description_menu_name As String = MEDescription.Text
            Dim id_group_menu As String = LEGroup.EditValue
            If action = "ins" Then
                Try
                    query = String.Format("INSERT INTO tb_menu(menu_name, description_menu_name, id_group_menu) VALUES('{0}', '{1}', '{2}'); SELECT LAST_INSERT_ID(); ", menu_name, description_menu_name, id_group_menu)
                    id_menu = execute_query(query, 0, True, "", "", "", "")
                    FormAccess.viewMenu()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = String.Format("UPDATE tb_menu SET menu_name='{0}', description_menu_name='{1}', id_group_menu='{2}' WHERE id_menu='{3}'", menu_name, description_menu_name, id_group_menu, id_menu)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewMenu()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            FormAccess.GVMenu.FocusedRowHandle = find_row(FormAccess.GVMenu, "id_menu", id_menu)
        End If
    End Sub
    'Close
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Delete Menu Involved
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this involved form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim query As String
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_menu_involved As String = GVInvolved.GetFocusedRowCellDisplayText("id_menu_involved").ToString
                query = String.Format("DELETE FROM tb_menu_involved WHERE id_menu_involved = '" + id_menu_involved + "'")
                execute_non_query(query, True, "", "", "", "")
                viewFormInvolved()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    'Add Involved Menu
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormAccessMenuInvMenu.action = "ins"
        FormAccessMenuInvMenu.ShowDialog()
    End Sub
    'Edit Menu Involved
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormAccessMenuInvMenu.action = "upd"
        FormAccessMenuInvMenu.id_menu_involved = GVInvolved.GetFocusedRowCellDisplayText("id_menu_involved").ToString
        FormAccessMenuInvMenu.ShowDialog()
    End Sub
End Class