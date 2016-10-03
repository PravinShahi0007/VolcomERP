Public Class FormMasterEmployeeStatus
    Public id As String = "-1"
    Public id_employee As String = "-1"

    Sub viewEmployeeStatus()
        Dim query As String = "SELECT * FROM tb_lookup_employee_status a WHERE a.id_employee_status>0 ORDER BY a.id_employee_status ASC "
        viewLookupQuery(LookUpEdit1, query, 0, "employee_status", "id_employee_status")
    End Sub

    Private Sub DEDOB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEStart.Validating
        EP_DE_cant_blank(ErrorProvider1, DEStart)
    End Sub

    Private Sub FormMasterEmployeeStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployeeStatus()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(ErrorProvider1) Then
            errorInput()
        Else
            Dim id_employee_status As String = LookUpEdit1.EditValue.ToString
            Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim end_period As String = "NULL"
            Try
                end_period = checkNullInput(DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd"))
            Catch ex As Exception
            End Try

            Dim query As String = "INSERT INTO tb_m_employee_status_det(id_employee, id_employee_status, start_period, end_period) "
            query += "VALUES('" + id_employee + "', '" + id_employee_status + "', '" + start_period + "', " + end_period + ") "
            execute_non_query(query, True, "", "", "", "")

            Dim query_upd As String = "UPDATE tb_m_employee SET id_employee_status='" + id_employee_status + "', start_period='" + start_period + "', end_period=" + end_period + " WHERE id_employee='" + id_employee + "' "
            execute_non_query(query_upd, True, "", "", "", "")


            FormMasterEmployeeNewDet.viewEmployeeStatus()
            Close()
        End If
    End Sub

    Private Sub FormMasterEmployeeStatus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class