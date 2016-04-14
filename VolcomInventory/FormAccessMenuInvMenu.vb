Public Class FormAccessMenuInvMenu 
    Public action As String
    Public id_menu_involved As String
    Dim id_menu As String = FormAccessMenuSingle.id_menu
    'Form Load
    Private Sub FormAccessMenuInvMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewForm()
        viewLookupAnswer()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_menu_involved a WHERE a.id_menu_involved = '" + id_menu_involved + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEForm.EditValue = data.Rows(0)("id_form")
            LEAnswer.ItemIndex = LEAnswer.Properties.GetDataSourceRowIndex("id_answer", data.Rows(0)("is_view").ToString)
        End If
    End Sub
    'Form Closed
    Private Sub FormAccessMenuInvMenu_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View Form
    Sub viewForm()
        Dim query As String = "SELECT a.id_form, a.form_name, a.form_note FROM tb_menu_form a "
        query += "LEFT JOIN tb_menu_involved b ON a.id_form = b.id_form AND b.id_menu = '" + id_menu + "' "
        query += "WHERE ISNULL(b.id_form) "
        If action = "upd" Then
            query += "OR b.id_menu_involved = '" + id_menu_involved + "' "
        End If
        query += "ORDER BY a.form_name ASC "
        viewSearchLookupQuery(SLEForm, query, "id_form", "form_name", "id_form")
    End Sub
    'View LookupAnswer
    Sub viewLookupAnswer()
        Dim query As String = "SELECT * FROM tb_lookup_answer a ORDER BY a.id_answer "
        viewLookupQuery(LEAnswer, query, 0, "answer", "id_answer")
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Btn Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim query As String = ""
        Dim id_form As String = SLEForm.EditValue
        Dim is_view As String = LEAnswer.EditValue
        If is_view = "1" Then
            Try
                query = "UPDATE tb_menu_involved SET is_view= '2' WHERE id_menu = '" + id_menu + "'"
                execute_non_query(query, True, "", "", "", "")
            Catch ex As Exception

            End Try
        End If
        If action = "ins" Then
            Try
                query = "INSERT INTO tb_menu_involved(id_form, id_menu, is_view) VALUES ('" + id_form + "', '" + id_menu + "', '" + is_view + "')"
                execute_non_query(query, True, "", "", "", "")
                FormAccessMenuSingle.viewFormInvolved()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
        ElseIf action = "upd" Then
            Try
                query = "UPDATE tb_menu_involved SET id_form = '" + id_form + "', id_menu='" + id_menu + "', is_view = '" + is_view + "' WHERE id_menu_involved = '" + id_menu_involved + "'"
                execute_non_query(query, True, "", "", "", "")
                FormAccessMenuSingle.viewFormInvolved()
                Close()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub
End Class