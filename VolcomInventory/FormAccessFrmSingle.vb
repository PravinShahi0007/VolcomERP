Public Class FormAccessFrmSingle 
    Public action As String
    Public id_form As String = "-1"
    'Form Load
    Private Sub FormAccessFrmSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_form <> "-1" Then
            Dim query As String = "SELECT * FROM tb_menu_form a WHERE a.id_form=" + id_form + ""
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            MENote.Text = data.Rows(0)("form_note").ToString
        End If
    End Sub
    'Validating
    Private Sub TxtFormName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtFormName.Validating
        Dim found As Boolean = False
        Dim form_name As String = TxtFormName.Text
        Dim query As String = ""
        Dim jum As Integer = 0

        'Cek form 
        Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim types As Type() = myAssembly.GetTypes()
        For Each myType As Object In types
            If form_name = myType.Name Then
                found = True
                Exit For
            End If
        Next


        'validate
        If found Then
            EPForm.SetError(TxtFormName, String.Empty)

            'saaat ini tidak digunakan karena bisa byk form contoh line list
            'query = "SELECT COUNT(*) FROM tb_menu_form a WHERE a.form_name = '" + addSlashes(form_name) + "' "
            'If action = "upd" Then
            '    query += "AND a.id_form != '" + id_form + "'"
            'End If
            'jum = execute_query(query, 0, True, "", "", "", "")

            If Not jum < 1 Then
                EP_TE_already_used(EPForm, TxtFormName, "1")
            End If
        Else
            If TxtFormName.Text.Length < 1 Then
                EPForm.SetError(TxtFormName, "Don't leave this field blank.")
            Else
                EPForm.SetError(TxtFormName, String.Empty)
                EPForm.SetError(TxtFormName, "This form name not found in application.")
            End If
        End If
    End Sub
    'Form Closed
    Private Sub FormAccessFrmSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Close Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Save Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPForm) Then
            errorInput()
        Else
            Dim form_name As String = addSlashes(TxtFormName.Text)
            Dim form_note As String = addSlashes(MENote.Text)
            Dim query As String = ""
            Dim description_form_control_view As String = ""
            If action = "ins" Then
                Try
                    'insert db
                    query = "INSERT INTO tb_menu_form(form_name, form_note) VALUES ('" + form_name + "', '" + form_note + "'); SELECT LAST_INSERT_ID(); "
                    id_form = execute_query(query, 0, True, "", "", "", "")
                    FormAccess.viewForm()

                    query = "SELECT description_form_control_view FROM tb_opt "
                    description_form_control_view = execute_query(query, 0, True, "", "", "", "")

                    query = "INSERT tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view) "
                    query += "VALUES('" + id_form + "', '" + description_form_control_view + "', '3', '1'); SELECT LAST_INSERT_ID(); "
                    Dim id_form_control As String = execute_query(query, 0, True, "", "", "", "").ToString
                    FormAccess.GVForm.FocusedRowHandle = find_row(FormAccess.GVForm, "id_form", id_form)
                    Close()

                    'open form control required process
                    FormAccessProcessSingle.action = "upd"
                    FormAccessProcessSingle.id_form_control = id_form_control
                    FormAccessProcessSingle.id_form = id_form
                    FormAccessProcessSingle.is_required = True
                    FormAccessProcessSingle.LabelTitle.Text = form_name
                    FormAccessProcessSingle.ShowDialog()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_menu_form SET form_name = '" + form_name + "', form_note='" + form_note + "' WHERE id_form = '" + id_form + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewForm()
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
End Class