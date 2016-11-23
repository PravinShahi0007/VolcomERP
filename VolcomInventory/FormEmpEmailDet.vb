Public Class FormEmpEmailDet
    Public id As String = "-1"
    Public type As String = "-1"

    Sub viewDept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
    End Sub

    Private Sub FormEmpEmailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        Dim query As String = ""
        If type = "1" Then ' employee
            query = "SELECT * FROM tb_m_employee emp "
            query += "INNER JOIN tb_m_departement dept ON dept.id_departement = emp.id_departement "
            query += "WHERE emp.id_employee='" + id + "' "
        Else 'non employee
            TxtName.Enabled = True
            LEDepartement.Enabled = True
            query = "SELECT emp.name AS `employee_name`, emp.id_departement, emp.email_lokal, emp.email_lokal_pass, emp.email_external, emp.email_external_pass, emp.email_other, emp.email_other_pass FROM tb_m_other_email emp "
            query += "INNER JOIN tb_m_departement dept ON dept.id_departement = emp.id_departement "
            query += "WHERE emp.id_other_email='" + id + "' "
        End If

        If id <> "-1" Then
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtName.Text = data.Rows(0)("employee_name").ToString
            LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            TxtExternal.Text = data.Rows(0)("email_external").ToString
            TxtExternalPass.Text = data.Rows(0)("email_external_pass").ToString
            TxtLocal.Text = data.Rows(0)("email_lokal").ToString
            TxtLocalPass.Text = data.Rows(0)("email_lokal_pass").ToString
            TxtOther.Text = data.Rows(0)("email_other").ToString
            TxtOtherPass.Text = data.Rows(0)("email_other_pass").ToString
        End If
    End Sub

    Private Sub FormEmpEmailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim name As String = addSlashes(TxtName.Text.ToString)
        Dim id_departement As String = LEDepartement.EditValue.ToString
        Dim email_external As String = TxtExternal.Text.ToString
        Dim email_external_pass As String = TxtExternalPass.Text.ToString
        Dim email_lokal As String = TxtLocal.Text.ToString
        Dim email_lokal_pass As String = TxtLocalPass.Text.ToString
        Dim email_other As String = TxtOther.Text.ToString
        Dim email_other_pass As String = TxtOtherPass.Text.ToString

        If type = "1" Then 'employee
            Dim query As String = "UPDATE tb_m_employee SET 
            email_external='" + email_external + "', 
            email_external_pass='" + email_external_pass + "', 
            email_lokal='" + email_lokal + "', 
            email_lokal_pass='" + email_lokal_pass + "', 
            email_other='" + email_other + "', 
            email_other_pass='" + email_other_pass + "' 
            WHERE id_employee='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormEmpEmail.viewEmployee("-1")
            FormEmpEmail.GVEmail.FocusedRowHandle = find_row(FormEmpEmail.GVEmail, "id_employee", id)
        Else 'non employee
            If id = "-1" Then
                Dim query As String = "INSERT INTO tb_m_other_email(name, id_departement, email_lokal, email_lokal_pass, email_external, email_external_pass, email_other, email_other_pass) 
                                       VALUES('" + name + "', '" + id_departement + "','" + email_lokal + "', '" + email_lokal_pass + "', '" + email_external + "', '" + email_external_pass + "', '" + email_other + "', '" + email_other_pass + "'); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
            Else
                Dim query As String = "UPDATE tb_m_other_email SET 
                name='" + name + "',
                id_departement = '" + id_departement + "',
                email_external='" + email_external + "', 
                email_external_pass='" + email_external_pass + "', 
                email_lokal='" + email_lokal + "', 
                email_lokal_pass='" + email_lokal_pass + "', 
                email_other='" + email_other + "', 
                email_other_pass='" + email_other_pass + "' 
                WHERE id_other_email='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
            End If
            FormEmpEmail.viewEmployee("-1")
            FormEmpEmail.GVEmail.FocusedRowHandle = find_row(FormEmpEmail.GVEmail, "id_other_email", id)
        End If

        'close
        Close()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class