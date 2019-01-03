Public Class FormCashAdvanceDet
    Public id_ca As String = "-1"
    Public is_no_schedule As Boolean = False
    Public is_load As Boolean = False

    Private Sub FormCashAdvanceDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormCashAdvanceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETotal.EditValue = 0.00
        load_type()
        load_pay_from()
        load_pay_to()
        load_dep()
        load_employee()
        load_report_status()

        DEDateCreated.EditValue = Now
        DEAdvanceEnd.EditValue = Now
        DEDueDate.EditValue = Now
        '
        TENumber.Text = "[auto generate]"
        '
        If id_ca = "-1" Then 'new

        Else 'edit

        End If

        is_load = True
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_cash_advance_type,cash_advance_type FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_pay_to()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayTo, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT id_employee,employee_name FROM tb_m_employee"
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_report_status()
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        calculate_report_day()
    End Sub

    Sub calculate_report_day()
        If is_load = True Then
            Try
                Dim date_start As String = Date.Parse(DEAdvanceEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim query As String = ""

                If SLEType.EditValue.ToString = "1" Then 'dinas H+3
                    query = "CALL work_days(3,'" & date_start & "','" & SLEEmployee.EditValue.ToString & "')"
                ElseIf SLEType.EditValue.ToString = "2" Then 'operation H+1
                    query = "CALL work_days(1,'" & date_start & "','" & SLEEmployee.EditValue.ToString & "')"
                End If

                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    DEDueDate.EditValue = data.Rows(0)("date")
                    is_no_schedule = False
                Else
                    warningCustom("Please register schedule for this employee first, contact HRD for further detail.")
                    is_no_schedule = True
                End If
                '
                Console.WriteLine(query)
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub DEAdvanceEnd_EditValueChanged(sender As Object, e As EventArgs) Handles DEAdvanceEnd.EditValueChanged
        calculate_report_day()
    End Sub

    Private Sub SLEEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmployee.EditValueChanged
        calculate_report_day()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If is_no_schedule = True Then
            warningCustom("Please register schedule for this employee first, contact HRD for further detail.")
        Else

        End If
    End Sub
End Class