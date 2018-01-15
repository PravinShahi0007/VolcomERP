Public Class FormEmpPayrollOvertimeDet
    Public id_overtime As String = ""
    Public id_employee As String = ""

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEPoint.EditValue = 0.0
        TETotHour.EditValue = 0.0
        TEBreak.EditValue = 0.0
        load_dayoff()
        load_ot_type()
    End Sub

    Sub load_dayoff()
        Dim query As String = "SELECT '1' AS is_dayoff,'Yes' AS dayoff
                                UNION
                                SELECT '2' AS is_dayoff,'No' AS dayoff"
        viewLookupQuery(LEDayoff, query, 0, "dayoff", "is_dayoff")
    End Sub

    Sub load_ot_type()
        Dim query As String = "SELECT id_ot_type,ot_type,IF(is_event='1','Yes','No') AS is_event FROM tb_lookup_ot_type"
        viewLookupQuery(LECategory, query, 0, "ot_type", "id_ot_type")
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "5"
        FormPopUpEmployee.ShowDialog()
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            LEDayoff.Focus()
        End If
    End Sub
    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            '
        Else
            stopCustom("No employee found.")
        End If
    End Sub

    Private Sub LEDayoff_KeyDown(sender As Object, e As KeyEventArgs) Handles LEDayoff.KeyDown
        If e.KeyCode = Keys.Enter Then
            LECategory.Focus()
        End If
    End Sub

    Private Sub LECategory_KeyDown(sender As Object, e As KeyEventArgs) Handles LECategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEStart.Focus()
        End If
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEBreak.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
            calc()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TEBreak_KeyDown(sender As Object, e As KeyEventArgs) Handles TEBreak.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Sub calc()
        If Not DEStart.EditValue > DEUntil.EditValue Then
            '
            Dim date_start As Date = DEStart.EditValue
            Dim date_until As Date = DEUntil.EditValue
            Dim time_diff As TimeSpan
            Dim diff As Decimal = 0.0
            Dim break As Decimal = 0.0

            Try
                break = TEBreak.EditValue
            Catch ex As Exception
            End Try

            time_diff = date_until - date_start
            diff = Math.Round((time_diff.TotalHours * 2), MidpointRounding.AwayFromZero) / 2
            TETotHour.EditValue = diff - break
        Else
            '
            TETotHour.EditValue = 0
        End If
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        calc()
    End Sub

    Private Sub TEBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEBreak.EditValueChanged
        calc()
    End Sub
End Class