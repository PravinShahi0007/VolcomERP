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
        TENumber.Text = header_number_emp("2")
        DEDateCreated.EditValue = Now
        DEStartDP.EditValue = Now
        DEUntilDP.EditValue = Now
        '
        If id_emp_dp = "-1" Then 'new
            BMark.Visible = False
            BPrint.Visible = False
        Else 'edit
            BMark.Visible = True
            BPrint.Visible = True
        End If
    End Sub

    Sub calc()
        If Not DEStartDP.EditValue > DEUntilDP.EditValue Then
            '
            Dim date_start As Date = DEStartDP.EditValue
            Dim date_until As Date = DEUntilDP.EditValue
            Dim diff As Integer
            diff = Math.Floor((date_until - date_start).Hours)
            TETotHour.EditValue = diff
        Else
            '
            TETotHour.EditValue = 0
        End If
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            MEDPNote.Focus()
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
    Private Sub FormempDPdet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TEEmployeeCode.Focus()
    End Sub

    Private Sub DEStartDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStartDP.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilDP.Focus()
        End If
    End Sub

    Private Sub DEUntilDP_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilDP.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub DEStartDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartDP.EditValueChanged
        calc()
    End Sub

    Private Sub DEUntilDP_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilDP.EditValueChanged
        calc()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If id_emp_dp = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_emp_dp(dp_number,id_employee,dp_date_created,dp_time_start,dp_time_end,dp_total)
                                    VALUES('" & header_number_emp("2") & "','" & id_employee & "',NOW(),'" & Date.Parse(DEStartDP.EditValue.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & Date.Parse(DEUntilDP.EditValue.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & TETotHour.EditValue.ToString & "');SELECT LAST_INSERT_ID();"
            id_emp_dp = execute_query(query, 0, True, "", "", "", "")
            FormEmpDP.load_dp()
            increase_inc_emp("2")
            infoCustom("DP registered, waiting approval.")
            Close()
        Else 'edit

        End If
    End Sub
End Class