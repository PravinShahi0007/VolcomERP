Public Class FormAccessProcessSingle 
    Public action As String
    Public id_form_control As String
    Public id_form As String
    Dim form_name As String = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
    Dim id_form_control_type As String
    Public is_required As Boolean
    'Validating
    Private Sub TxtDescription_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDescription.Validating
        EP_TE_cant_blank(EPProcess, TxtDescription)
    End Sub
    'Form Load
    Private Sub FormAccessProcessSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewType()
        'MsgBox(is_required.ToString)
        If is_required Then
            Me.LEType.ItemIndex = Me.LEType.Properties.GetDataSourceRowIndex("id_form_control_type", "3")
            Dim query As String = "SELECT * FROM tb_menu_form_control a WHERE a.id_form_control = '" + id_form_control + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtDescription.Text = data.Rows(0)("description_form_control").ToString
            LEType.Enabled = False
            TxtFormControlName.Enabled = False
            'LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
            Me.Text = "Required Process for View Data/Form"
        End If
        If action = "upd" And Not is_required Then
            Dim query As String = "SELECT * FROM tb_menu_form_control a WHERE a.id_form_control = '" + id_form_control + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Me.LEType.ItemIndex = Me.LEType.Properties.GetDataSourceRowIndex("id_form_control_type", data.Rows(0)("id_form_control_type").ToString)
            TxtFormControlName.Text = data.Rows(0)("form_control_name").ToString
            TxtDescription.Text = data.Rows(0)("description_form_control").ToString
        End If
    End Sub
    'Fill Lookup Type
    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_form_control_type a ORDER BY a.id_form_control_type ASC "
        viewLookupQuery(LEType, query, 0, "form_control_type", "id_form_control_type")
    End Sub
    'Cancel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Form Closed
    Private Sub FormAccessProcessSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Save Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPProcess) Then
            errorInput()
        Else
            Dim query As String = ""
            Dim description_form_control As String = addSlashes(TxtDescription.Text)
            id_form_control_type = LEType.EditValue
            Dim form_control_name As String = addSlashes(TxtFormControlName.Text)
            Dim is_view As String = "2"
            If action = "ins" Then
                Try
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', '" + description_form_control + "', '" + id_form_control_type + "', '" + is_view + "', '" + form_control_name + "')"
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewFormControl()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_menu_form_control SET id_form = '" + id_form + "', description_form_control = '" + description_form_control + "', "
                    If form_control_name <> "" Then ' jika form kontrol name tidak kosong
                        query += "id_form_control_type = '" + id_form_control_type + "', form_control_name = '" + form_control_name + "' WHERE id_form_control = '" + id_form_control + "' "
                    Else ' jika form kontrol name kosong isi dengan NULL
                        query += "id_form_control_type = '" + id_form_control_type + "' WHERE id_form_control = '" + id_form_control + "' "
                    End If
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewFormControl()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
    'Validating Control Name
    Private Sub TxtFormControlName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFormControlName.Validating
        'Declare
        Dim found As Boolean = False

        'Cek control
        If id_form_control_type = "1" Then 'Bar Btn Item
            'For Each item As DevExpress.XtraBars.BarButtonItem In FormMain.RibbonControl.Items
            '    If item.Name = TxtFormControlName.Text Then
            '        found = True
            '    End If
            'Next item
            found = True
        ElseIf id_form_control_type = "2" Then 'Simple Button
            'Cek form 
            found = True
        Else
            found = True
        End If

        'Validate
        If Not found Then
            EP_TE_check_value(EPProcess, TxtFormControlName, 0)
        Else
            EP_TE_check_value(EPProcess, TxtFormControlName, -1)
            Dim query As String
            If action = "ins" Then
                query = "SELECT COUNT(*) FROM tb_menu_form_control WHERE form_control_name = '" + TxtFormControlName.Text.ToString + "' AND id_form = '" + id_form + "' "
            Else
                query = "SELECT COUNT(*) FROM tb_menu_form_control WHERE form_control_name = '" + TxtFormControlName.Text.ToString + "' AND id_form_control != '" + id_form_control + "' AND id_form = '" + id_form + "' "
            End If
            Dim jum As Integer = execute_query(query, 0, True, "", "", "", "")
            If jum > 0 Then
                EP_TE_already_used(EPProcess, TxtFormControlName, 0)
            Else
                EP_TE_already_used(EPProcess, TxtFormControlName, -1)
                If id_form_control_type <> "3" Then 'execpt other component
                    EP_TE_cant_blank(EPProcess, TxtFormControlName)
                End If
            End If
        End If
    End Sub
    'Value Changed Type
    Private Sub LEType_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEType.EditValueChanged
        id_form_control_type = LEType.EditValue
    End Sub
End Class