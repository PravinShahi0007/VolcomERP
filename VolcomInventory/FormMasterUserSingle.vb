Public Class FormMasterUserSingle
    Public id_user As String
    Private Sub FormMasterUserSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewEmployee()
        viewRole()
        If id_user <> "-1" Then
            'edit
            Dim query As String = String.Format("SELECT * FROM tb_m_user WHERE id_user='{0}'", id_user)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim id_role As String = data.Rows(0)("id_role").ToString
            Dim username As String = data.Rows(0)("username").ToString
            LERole.ItemIndex = LERole.Properties.GetDataSourceRowIndex("id_role", id_role)
            TEUsername.Text = username
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
        Else
            getEmp()
        End If
    End Sub

    Sub getEmp()
        Dim q As String = "SELECT employee_code FROM tb_m_employee WHERE id_employee = '" + SLEEmployee.EditValue.ToString + "' "
        Dim d As DataTable = execute_query(q, -1, True, "", "", "", "")
        TEUsername.Text = d.Rows(0)("employee_code").ToString
        TEPassword.Text = d.Rows(0)("employee_code").ToString
        TERepeatPassword.Text = d.Rows(0)("employee_code").ToString
    End Sub

    'Search Lookup EWmployee
    Sub viewEmployee()
        Dim query As String = "SELECT * FROM tb_m_employee a "
        query += "INNER JOIN tb_m_departement b ON a.id_departement = b.id_departement "
        query += "INNER JOIN tb_lookup_sex c ON a.id_sex = c.id_sex "
        query += "ORDER BY a.employee_name ASC "
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub
    'Lookup User
    Sub viewRole()
        Dim query As String = "SELECT * FROM tb_m_role a ORDER BY a.role ASC"
        viewLookupQuery(LERole, query, 0, "role", "id_role")
    End Sub
    'Form Closed
    Private Sub FormMasterUserSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        checkFormAccess("FormMasterUser")
    End Sub
    'Save
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String
        ValidateChildren()
        If id_user <> "-1" Then
            'edit
            If Not formIsValid(EPUser)  Then
                errorInput()
            Else
                Try
                    'edit to user
                    query = String.Format("UPDATE tb_m_user SET id_employee='{0}', id_role='{1}', username='{2}', password=MD5('{3}'), is_change='2' WHERE id_user='{4}'", SLEEmployee.EditValue, LERole.EditValue, TEUsername.Text, TEPassword.Text, id_user)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_user", 2)
                    FormMasterUser.view_user()
                    Close()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            'new
            If Not formIsValid(EPUser) Then
                errorInput()
            Else
                Try
                    'insert to user
                    query = String.Format("INSERT INTO tb_m_user(id_employee,username,password,id_role) VALUES('{0}','{1}',MD5('{2}'),'{3}')", SLEEmployee.EditValue, TEUsername.Text, TEPassword.Text, LERole.EditValue)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_user", 1)
                    FormMasterUser.view_user()
                    Close()
                    Dispose()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub
    'Validating username
    Private Sub TEUsername_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEUsername.Validating
        '
        Dim query_jml As String
        If id_user = "-1" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_user) FROM tb_m_user WHERE username='{0}'", TEUsername.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_user) FROM tb_m_user WHERE username='{0}' AND id_user!='{1}'", TEUsername.Text, id_user)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPUser, TEUsername, "1")
        Else
            EP_TE_cant_blank(EPUser, TEUsername)
        End If
    End Sub
    'Validating Password
    Private Sub TEPassword_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPassword.Validating
        EP_TE_cant_blank(EPUser, TEPassword)
    End Sub
    'Validating repeat pass
    Private Sub TERepeatPassword_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERepeatPassword.Validating
        EP_TE_must_same(EPUser, TERepeatPassword, TEPassword)
    End Sub

    Private Sub SLEEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmployee.EditValueChanged
        Dim def As String = ""
        Try
            def = SLEEmployee.Properties.View.GetFocusedRowCellValue("employee_code").ToString
        Catch ex As Exception
        End Try
        TEUsername.Text = def
        TEPassword.Text = def
        TERepeatPassword.Text = def
    End Sub

    Private Sub LabelControl4_Click(sender As Object, e As EventArgs) Handles LabelControl4.Click

    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        getEmp()
    End Sub
End Class