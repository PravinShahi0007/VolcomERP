Public Class FormDepartementSubDet
    Public id_subdept As String = "-1"
    Private Sub FormDepartementSubDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDepartementSubDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_dept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.id_departement "
        viewLookupQuery(LETypeSO, query, 0, "departement", "id_departement")
    End Sub

    Sub load_user()
        Dim query As String = "SELECT a.`id_user`,a.`username`,emp.`employee_name` FROM tb_m_user a 
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=a.`id_employee`
                                ORDER BY a.id_user "
        viewLookupQuery(LETypeSO, query, 0, "employee_name", "id_user")
    End Sub
End Class
