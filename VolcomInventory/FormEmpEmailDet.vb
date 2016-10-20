Public Class FormEmpEmailDet
    Public id As String = "-1"

    Private Sub FormEmpEmailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_m_employee emp "
        query += "INNER JOIN tb_m_departement dept ON dept.id_departement = emp.id_departement "
        query += "WHERE emp.id_employee='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtName.Text = data.Rows(0)("employee_name").ToString
        TxtDepartement.Text = data.Rows(0)("departement").ToString
        TxtExternal.Text = data.Rows(0)("email_external").ToString
        TxtExternalPass.Text = data.Rows(0)("email_external_pass").ToString
        TxtLocal.Text = data.Rows(0)("email_lokal").ToString
        TxtLocalPass.Text = data.Rows(0)("email_lokal_pass").ToString
        TxtOther.Text = data.Rows(0)("email_other").ToString
        TxtOtherPass.Text = data.Rows(0)("email_other_pass").ToString
    End Sub

    Private Sub FormEmpEmailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        FormMain.SplashScreenManager1.ShowWaitForm()
        Dim email_external As String = TxtExternal.Text.ToString
        Dim email_external_pass As String = TxtExternalPass.Text.ToString
        Dim email_lokal As String = TxtLocal.Text.ToString
        Dim email_lokal_pass As String = TxtLocalPass.Text.ToString
        Dim email_other As String = TxtOther.Text.ToString
        Dim email_other_pass As String = TxtOtherPass.Text.ToString
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
        Close()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class