Public Class FormEmpAttnAssignDet
    Public id_emp_assign_sch As String = "-1"

    Private Sub FormEmpAttnAssignDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_emp_assign_sch = "-1" Then 'new
            Dim query As String = "SELECT emp.employee_name,emp.employee_code,dep.departement FROM tb_m_employee emp
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    WHERE id_employee='" & id_employee_user & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEEmpCode.Text = data.Rows(0)("employee_code").ToString
            TEEmpName.Text = data.Rows(0)("employee_name").ToString
            TEDepartement.Text = data.Rows(0)("departement").ToString

            DEDate.EditValue = Now
            TENumber.Text = header_number_emp("4")

            '
            FormEmpScheduleTableSet.opt = "2"
            FormEmpScheduleTableSet.ShowDialog()
        Else

        End If
    End Sub

    Private Sub FormEmpAttnAssignDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BViewShift_Click(sender As Object, e As EventArgs) Handles BViewShift.Click
        FormEmpAttnAssignShift.ShowDialog()
    End Sub
End Class