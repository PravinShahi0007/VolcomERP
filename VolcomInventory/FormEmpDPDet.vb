Public Class FormEmpDPDet
    Public id_employee As String = "-1"
    Public id_emp_dp As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpDPDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "3"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Private Sub FormEmpDPDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TENumber.Text = header_number_emp("1")
        DEDateCreated.EditValue = Now
        '
        If id_emp_dp = "-1" Then 'new

        Else 'edit

        End If
    End Sub

    Sub calc()

    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
        End If
    End Sub
    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            TEDept.Text = data.Rows(0)("departement").ToString
            TEPosition.Text = data.Rows(0)("employee_position").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            '
        Else
            stopCustom("No employee found.")
        End If
    End Sub
End Class